using System;
using System.Threading;
using System.Windows.Forms;
using WebcamMotion.Classes;
using WebcamMotion.FormsBase;
using WebcamMotion.Helpers;
using WebcamMotion.Resources;

namespace WebcamMotion
{
    public partial class SettingsForm : Form, ILocalizableForm
    {
        private readonly IStringResources stringResources;
        private readonly ISettingsController settingsController;
        private readonly IGoogleDriveClient googleDriveClient;
        private readonly IFormLogger logger;
        private readonly ILocalizableForm mainForm;
        private readonly ITelegramClientWrapper telegramClientWrapper;
        private string telegramHash;

        public SettingsForm(IStringResources stringResources, ISettingsController settingsController,
            IGoogleDriveClient googleDriveClient, IFormLogger logger, ILocalizableForm mainForm,
            ITelegramClientWrapper telegramClientWrapper)
        {
            this.stringResources = stringResources;
            this.settingsController = settingsController;
            this.googleDriveClient = googleDriveClient;
            this.logger = logger;
            this.mainForm = mainForm;
            this.telegramClientWrapper = telegramClientWrapper;
            InitializeComponent();
        }

        public void ApplyLanguage()
        {
            Text = stringResources.Settings;
            startupCheckBox.Text = stringResources.RunWithWindows;
            minimizeTrayCheckBox.Text = stringResources.MinimizeToTray;
            detectionStartCheckBox.Text = stringResources.BeginDetection;
            showPreviewCheckBox.Text = stringResources.ShowPreview;
            printTimeCheckBox.Text = stringResources.ShowDateTime;
            detectionDelayLabel.Text = stringResources.StartDelay + ':';
            savePathLabel.Text = stringResources.SaveTo + ':';
            saveBrowseButton.Text = stringResources.Browse;
            googleDriveCheckBox.Text = stringResources.UploadToGoogleDrive;
            drivePathLabel.Text = stringResources.SaveCopiesTo + ':';
            driveBrowseButton.Text = stringResources.Browse;
            acceptButton.Text = stringResources.Ok;
            declineButton.Text = stringResources.Cancel;
            minutesLabel.Text = stringResources.Minutes;
            languageLabel.Text = stringResources.Language + ':';
            appSettingsBox.Text = stringResources.AppSettings;
            capturingrSettingsBox.Text = stringResources.CapturingSettings;
            sensitivityLabel.Text = stringResources.MotionSensorSensitivity + ':';
            intervalLabel.Text = stringResources.SnapshotsInterval + ':';
            secondsLabel.Text = stringResources.Seconds;
            disableMotionSensorCheckBox.Text = stringResources.SnapshotsOnlyByInterval;
            telegramCheckBox.Text = stringResources.TelegramNotify;
            telegramPhoneLabel.Text = stringResources.TelegramPhoneNumber + ':';
            telegramGetCodeButton.Text = stringResources.TelegramGetCode;
            telegramCodeLabel.Text = stringResources.TelegramCode + ':';
            telegramLoginButton.Text = stringResources.TelegramLogin;
            telegramSessionLabel.Text = stringResources.TelegramSessionStatus + ':';
            telegramStatusLabel.Text = stringResources.TelegramStatusChecking + @"...";
            CheckTelegramSessionStatus();
        }

        private void FillLanguageComboBoxUsingReflection()
        {
            var langFields = typeof(SupportedLanguages).GetFields();
            foreach (var field in langFields)
            {
                languageComboBox.Items.Add(field.GetValue(null));
            }
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            FillLanguageComboBoxUsingReflection();
            ApplyLanguage();
            googleDriveCheckBox.Checked = settingsController.GoogleDriveIntegration;
            saveFolderBox.Text = settingsController.SaveTo;
            printTimeCheckBox.Checked = settingsController.PrintDateTime;
            minimizeTrayCheckBox.Checked = settingsController.TrayOnStartup;
            showPreviewCheckBox.Checked = settingsController.ShowPreview;
            motionDelayUpDown.Value = settingsController.StartDelayInMinutes;
            drivePathTextBox.Text = settingsController.SaveToGoogleDrive;
            detectionStartCheckBox.Checked = settingsController.AutomaticVideoStart;
            startupCheckBox.Checked = settingsController.StartOnWindowsStartup;
            languageComboBox.Text = settingsController.Language;
            sensitivityTrackBar.Value = settingsController.Sensitivity;
            trackBarValLabel.Text = sensitivityTrackBar.Value.ToString();
            intervalUpDown.Value = settingsController.SnapshotsInterval;
            disableMotionSensorCheckBox.Checked = settingsController.OnlyInterval;
            telegramPhone.Text = settingsController.TelegramPhoneNumber;
            telegramCheckBox.Checked = settingsController.TelegramIntegration;
        }

        private void CheckTelegramSessionStatus()
        {
            if (telegramClientWrapper.IsSessionActive())
            {
                telegramStatusLabel.Text = stringResources.TelegramStatusActive;
            }
            else
            {
                telegramStatusLabel.Text = stringResources.TelegramStatusInactive;
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                settingsController.GoogleDriveIntegration = googleDriveCheckBox.Checked;
                settingsController.SaveTo = saveFolderBox.Text;
                settingsController.PrintDateTime = printTimeCheckBox.Checked;
                settingsController.TrayOnStartup = minimizeTrayCheckBox.Checked;
                settingsController.ShowPreview = showPreviewCheckBox.Checked;
                settingsController.StartDelayInMinutes = (int)motionDelayUpDown.Value;
                settingsController.SaveToGoogleDrive = drivePathTextBox.Text;
                settingsController.AutomaticVideoStart = detectionStartCheckBox.Checked;
                settingsController.StartOnWindowsStartup = startupCheckBox.Checked;
                settingsController.Sensitivity = sensitivityTrackBar.Value;
                settingsController.SnapshotsInterval = (int)intervalUpDown.Value;
                settingsController.OnlyInterval = disableMotionSensorCheckBox.Checked;
                settingsController.TelegramPhoneNumber = telegramPhone.Text;
                settingsController.TelegramIntegration = telegramCheckBox.Checked;
                if (settingsController.GoogleDriveIntegration)
                {
                    googleDriveClient.Init();
                }
                if (settingsController.TelegramIntegration)
                {
                    telegramClientWrapper.Init();
                }
                this.Close();
            }
            catch (Exception exception)
            {
                logger.Log($"{stringResources.SettingsApplyError}: {exception.Message}");
                throw;
            }
        }

        private void driveBrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = drivePathTextBox.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                drivePathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)languageComboBox.SelectedItem == SupportedLanguages.English)
            {
                settingsController.Language = SupportedLanguages.English;
            }
            if ((string)languageComboBox.SelectedItem == SupportedLanguages.Russian)
            {
                settingsController.Language = SupportedLanguages.Russian;
            }
            stringResources.RefreshResources();
            this.ApplyLanguage();
            mainForm.ApplyLanguage();
        }

        private void saveBrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = saveFolderBox.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                saveFolderBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void sensitivityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            trackBarValLabel.Text = sensitivityTrackBar.Value.ToString();
        }

        private void telegramCodeButton_Click(object sender, EventArgs e)
        {
            GetTelegramHash();
        }

        private async void GetTelegramHash()
        {
            await telegramClientWrapper.Init();
            telegramHash = await telegramClientWrapper.SendCodeAsync(telegramPhone.Text);
        }

        private void telegramLoginButton_Click(object sender, EventArgs e)
        {
            AuthToTelegram();
        }

        private async void AuthToTelegram()
        {
            await telegramClientWrapper.LoginAsync(telegramPhone.Text, telegramHash, telegramCode.Text);
            CheckTelegramSessionStatus();
        }
    }
}