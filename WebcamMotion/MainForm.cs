using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using AForge.Video;
using TLSharp.Core;
using WebcamMotion.Classes;
using WebcamMotion.FormsBase;
using WebcamMotion.Helpers;
using WebcamMotion.Resources;

namespace WebcamMotion
{
    public partial class MainForm : Form, ILoggableForm, ILocalizableForm
    {
        private const int MaxLinesInLogTextBox = 1000;
        private readonly IGoogleDriveClient googleDriveClient;
        private readonly ISettingsController settingsController;
        private readonly IMotionController motionController;
        private readonly IFormLogger logger;
        private readonly ITelegramClientWrapper telegramClientWrapper;
        private readonly IStringResources stringResources;

        public MainForm(IStringResources stringResources, IGoogleDriveClient googleDriveClient,
            ISettingsController settingsController,
            IMotionController motionController, IFormLogger logger,
            ITelegramClientWrapper telegramClientWrapper)
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            this.googleDriveClient = googleDriveClient;
            this.settingsController = settingsController;
            this.motionController = motionController;
            this.logger = logger;
            this.telegramClientWrapper = telegramClientWrapper;
            this.stringResources = stringResources;
            logger.InitForm(this);
        }

        public void LogToForm(string message)
        {
            ExecuteInMainContext(() => InternalLogToForm(message));
        }

        public void ApplyLanguage()
        {
            mainMenu.Items[0].Text = stringResources.Settings;
            devicesLabel.Text = stringResources.Device + ':';
            previewLabel.Text = stringResources.PreviewWindow + ':';
            logLabel.Text = stringResources.Log + ':';
            startButton.Text = stringResources.Start;
            stopButton.Text = stringResources.Stop;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ApplyLanguage();
            if (settingsController.TelegramIntegration)
            {
                telegramClientWrapper.Init();
            }
            if (settingsController.GoogleDriveIntegration)
            {
                googleDriveClient.Init();
            }
            foreach (var deviceName in motionController.DevicesList)
            {
                devicesComboBox.Items.Add(deviceName);
            }
            motionController.OnFrameProcess += ProcessFrame;
            notifyIcon.Text = this.Text;
            logger.Log(stringResources.AppStarted);
            SyncControlsState();
        }

        private void ProcessFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var bitmap = eventArgs.Frame;
            ExecuteInMainContext(() => SyncProcessFrame(bitmap));
        }

        private void devicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            motionController.SelectDevice(devicesComboBox.SelectedIndex);
            settingsController.SelectedCamera = devicesComboBox.SelectedItem.ToString();
            logger.Log($"{stringResources.SelectedDevice}: {devicesComboBox.SelectedItem}");
            SyncControlsState();
        }

        private void SyncControlsState()
        {
            startButton.Enabled = !motionController.IsActive;
            stopButton.Enabled = motionController.IsActive;
            if (!string.IsNullOrEmpty(settingsController.SelectedCamera))
            {
                for (var i = 0; i < devicesComboBox.Items.Count; i++)
                {
                    if (devicesComboBox.Items[i].ToString() == settingsController.SelectedCamera)
                    {
                        devicesComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void SyncProcessFrame(Bitmap bitmap)
        {
            if (!settingsController.ShowPreview) return;
            using (var graphics = Graphics.FromHwnd(previewPanel.Handle))
            {
                graphics.DrawImage(bitmap, new Rectangle(0, 0, previewPanel.Width, previewPanel.Height));
            }
        }

        private void ExecuteInMainContext(Action action)
        {
            Invoke(action);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            motionController.OnFrameProcess -= ProcessFrame;
            motionController.Stop();
            logger.Log(stringResources.AppStoped);
            logger.StopFormLogging();
            Application.DoEvents();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingForm = new SettingsForm(stringResources, settingsController, googleDriveClient, logger, this,
                telegramClientWrapper);
            settingForm.ShowDialog();
        }

        private void InternalLogToForm(string message)
        {
            if (logTextBox.Lines.Length > MaxLinesInLogTextBox)
            {
                logTextBox.Clear();
            }
            logTextBox.AppendText(DateTime.Now.ToString(CultureInfo.CurrentCulture) + ": " + message + "\r\n");
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartMotionDetection();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            motionController.Stop();
            SyncControlsState();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (settingsController.TrayOnStartup)
            {
                this.Hide();
            }
            if (settingsController.AutomaticVideoStart)
            {
                StartMotionDetection();
            }
        }

        private void StartMotionDetection()
        {
            if (settingsController.StartDelayInMinutes > 0)
                logger.Log(
                    $"{stringResources.StartDelayedTo} {DateTime.Now.AddMinutes(settingsController.StartDelayInMinutes)}");
            motionController.StartWithDelay(settingsController.StartDelayInMinutes);
            SyncControlsState();
        }
    }
}