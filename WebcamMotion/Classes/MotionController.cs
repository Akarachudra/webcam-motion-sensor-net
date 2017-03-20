using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using WebcamMotion.Helpers;
using WebcamMotion.Resources;

namespace WebcamMotion.Classes
{
    public class MotionController : IMotionController
    {
        private const int TelegramIntervalSeconds = 60;
        private readonly IStringResources stringResources;
        private readonly IFormLogger logger;
        private readonly IGoogleDriveClient googleDriveClient;
        private readonly ISettingsController settingsController;
        private readonly ITelegramClientWrapper telegramClientWrapper;
        private readonly MotionDetector detector;
        private readonly FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private DateTime lastDetectionCheckTime;
        private DateTime saveToTime;
        private DateTime lastSaveTime = DateTime.MinValue;
        private DateTime lastTelegramNotifyTime = DateTime.MinValue;
        private string lastFilePath;

        public MotionController(IStringResources stringResources, IFormLogger logger,
            IGoogleDriveClient googleDriveClient,
            ISettingsController settingsController,
            ITelegramClientWrapper telegramClientWrapper)
        {
            this.stringResources = stringResources;
            this.logger = logger;
            this.googleDriveClient = googleDriveClient;
            this.settingsController = settingsController;
            this.telegramClientWrapper = telegramClientWrapper;
            DevicesList = new List<string>();
            detector = new MotionDetector(
                new TwoFramesDifferenceDetector(),
                null);
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            for (var i = 0; i < videoDevices.Count; i++)
            {
                DevicesList.Add(videoDevices[i].Name);
            }
            StartGoogleDriveSending();
            IsActive = false;
        }

        public bool IsActive { get; private set; }
        public List<string> DevicesList { get; }
        public event NewFrameEventHandler OnFrameProcess;

        public void SelectDevice(int index)
        {
            if (videoDevices != null && videoDevices.Count > 0)
            {
                StopVideoSource();
                videoSource = new VideoCaptureDevice(videoDevices[index].MonikerString);
                if (IsActive)
                {
                    StartVideoSource();
                }
            }
        }

        public void SelectDevice(string deviceName)
        {
            if (videoDevices != null && videoDevices.Count > 0)
            {
                StopVideoSource();
                for (var i = 0; i < DevicesList.Count; i++)
                {
                    if (DevicesList[i] == deviceName)
                        videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
                }
                if (IsActive)
                {
                    StartVideoSource();
                }
            }
        }

        public void Stop()
        {
            if (!IsActive) return;
            StopVideoSource();
            logger.Log(stringResources.CapturingStoped);
            IsActive = false;
        }

        public async void StartWithDelay(int minutesDelay = 0)
        {
            IsActive = true;
            await Task.Delay(60000 * minutesDelay);
            if (!IsActive) return;
            StartVideoSource();
            logger.Log(stringResources.CapturingStarted);
        }

        private void StartVideoSource()
        {
            if (videoSource == null) return;
            videoSource.NewFrame += ProcessFrame;
            videoSource.Start();
        }

        private void StartGoogleDriveSending()
        {
            SendJpegsToGoogleDrive();
        }

        private async void SendJpegsToGoogleDrive()
        {
            while (true)
            {
                if (settingsController.GoogleDriveIntegration)
                {
                    var files = Directory.GetFiles(settingsController.SaveToGoogleDrive, "*.jpg");
                    try
                    {
                        foreach (var file in files)
                        {
                            logger.Log($"{stringResources.UploadFileToGoogleDrive}: {file}");
                            var sendResult = await googleDriveClient.UploadJpeg(file);
                            if (sendResult)
                                File.Delete(file);
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Log($"{stringResources.FileUploadException}: {e.Message}");
                    }
                }
                await Task.Delay(1000);
            }
        }

        private void InternalProcessFrame(Bitmap bitmap)
        {
            var motionDetected = false;
            if (!settingsController.OnlyInterval)
            {
                if ((DateTime.Now - lastDetectionCheckTime).Milliseconds > 50)
                {
                    lastDetectionCheckTime = DateTime.Now;
                    if (detector.ProcessFrame(bitmap) > 1.0 - (float)settingsController.Sensitivity / 1000)
                    {
                        logger.Log(stringResources.MotionDetected);
                        saveToTime = lastDetectionCheckTime.AddSeconds(10);
                        motionDetected = true;
                    }
                }
            }
            PrintDateTime(bitmap);
            if (DateTime.Now < saveToTime || settingsController.OnlyInterval)
            {
                if ((DateTime.Now - lastSaveTime).TotalSeconds > settingsController.SnapshotsInterval)
                {
                    lastSaveTime = DateTime.Now;
                    var fileName = $"{DateTime.Now.ToString("dd.MM.yyyy.HH-mm-ss")}.{Guid.NewGuid()}.jpg";
                    logger.Log($"{stringResources.SaveFrameToFile}: {fileName}");
                    lastFilePath = Path.Combine(settingsController.SaveTo, fileName);
                    bitmap.Save(lastFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (settingsController.GoogleDriveIntegration)
                    {
                        bitmap.Save(
                            Path.Combine(settingsController.SaveToGoogleDrive, fileName),
                            System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
            if (motionDetected)
            {
                NotifyToTelegram();
            }
        }

        private void PrintDateTime(Bitmap bitmap)
        {
            if (settingsController.PrintDateTime)
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    var rectf = new RectangleF(30, bitmap.Height - 110, 180, 80);
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawString(DateTime.Now.ToString(CultureInfo.CurrentCulture), new Font("Tahoma", 24),
                        Brushes.White, rectf);
                }
            }
        }

        private void NotifyToTelegram()
        {
            if (settingsController.TelegramIntegration &&
                (DateTime.Now - lastTelegramNotifyTime).TotalSeconds > TelegramIntervalSeconds)
            {
                if (!string.IsNullOrEmpty(lastFilePath))
                {
                    telegramClientWrapper.SendPhotoToSelf(lastFilePath, stringResources.MotionDetected);
                    lastTelegramNotifyTime = DateTime.Now;
                }
            }
        }

        private void StopVideoSource()
        {
            if (videoSource == null) return;
            videoSource.NewFrame -= ProcessFrame;
            videoSource.SignalToStop();
        }

        private void ProcessFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var bitmap = eventArgs.Frame;
            InternalProcessFrame(bitmap);
            OnFrameProcess?.Invoke(sender, eventArgs);
        }
    }
}