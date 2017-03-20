using System.Globalization;
using WebcamMotion.Helpers;
using System.Resources;
using System.Threading;

namespace WebcamMotion.Resources
{
    public class StringResources : IStringResources
    {
        private readonly ISettingsController settingsController;

        public StringResources(ISettingsController settingsController)
        {
            this.settingsController = settingsController;
            if (settingsController.Language == SupportedLanguages.Russian || Equals(Thread.CurrentThread.CurrentUICulture, new CultureInfo("ru-RU")))
            {
                settingsController.Language = SupportedLanguages.Russian;
            }
            else
            {
                settingsController.Language = SupportedLanguages.English;
            }

            RefreshResources();
        }

        public string Settings { get; set; }
        public string Device { get; set; }
        public string Log { get; set; }
        public string PreviewWindow { get; set; }
        public string Start { get; set; }
        public string Stop { get; set; }
        public string RunWithWindows { get; set; }
        public string MinimizeToTray { get; set; }
        public string BeginDetection { get; set; }
        public string ShowPreview { get; set; }
        public string ShowDateTime { get; set; }
        public string StartDelay { get; set; }
        public string SaveTo { get; set; }
        public string Browse { get; set; }
        public string GoogleDrive { get; set; }
        public string UploadToGoogleDrive { get; set; }
        public string SaveCopiesTo { get; set; }
        public string Ok { get; set; }
        public string Cancel { get; set; }
        public string Minutes { get; set; }
        public string Language { get; set; }
        public string AppSettings { get; set; }
        public string CapturingSettings { get; set; }
        public string MotionDetected { get; set; }
        public string AppStarted { get; set; }
        public string AppStoped { get; set; }
        public string SelectedDevice { get; set; }
        public string CapturingStarted { get; set; }
        public string CapturingStoped { get; set; }
        public string UploadFileToGoogleDrive { get; set; }
        public string FileUploadException { get; set; }
        public string SaveFrameToFile { get; set; }
        public string Error { get; set; }
        public string StartDelayedTo { get; set; }
        public string MotionSensorSensitivity { get; set; }
        public string SettingsApplyError { get; set; }
        public string SnapshotsInterval { get; set; }
        public string Seconds { get; set; }
        public string SnapshotsOnlyByInterval { get; set; }
        public string TelegramNotify { get; set; }
        public string TelegramPhoneNumber { get; set; }
        public string TelegramGetCode { get; set; }
        public string TelegramCode { get; set; }
        public string TelegramLogin { get; set; }
        public string TelegramSessionStatus { get; set; }
        public string TelegramStatusChecking { get; set; }
        public string TelegramStatusActive { get; set; }
        public string TelegramStatusInactive { get; set; }

        public void RefreshResources()
        {
            if (settingsController.Language == SupportedLanguages.English)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-EN");
            }
            else if (settingsController.Language == SupportedLanguages.Russian)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-EN");
            }

            var rm = new ResourceManager("WebcamMotion.Resources.strings", typeof(MainForm).Assembly);

            Settings = rm.GetString("settings");
            Device = rm.GetString("device");
            Log = rm.GetString("log");
            PreviewWindow = rm.GetString("previewWindow");
            Start = rm.GetString("start");
            Stop = rm.GetString("stop");
            RunWithWindows = rm.GetString("runWithWindows");
            MinimizeToTray = rm.GetString("minimizeToTray");
            BeginDetection = rm.GetString("beginDetection");
            ShowPreview = rm.GetString("showPreview");
            ShowDateTime = rm.GetString("showDateTime");
            StartDelay = rm.GetString("startDelay");
            SaveTo = rm.GetString("saveTo");
            Browse = rm.GetString("browse");
            GoogleDrive = rm.GetString("googleDrive");
            UploadToGoogleDrive = rm.GetString("uploadToGoogleDrive");
            SaveCopiesTo = rm.GetString("saveCopiesTo");
            Ok = rm.GetString("ok");
            Cancel = rm.GetString("cancel");
            Minutes = rm.GetString("minutes");
            Language = rm.GetString("language");
            AppSettings = rm.GetString("appSettings");
            CapturingSettings = rm.GetString("capturingSettings");
            MotionDetected = rm.GetString("motionDetected");
            AppStarted = rm.GetString("appStarted");
            AppStoped = rm.GetString("appStoped");
            SelectedDevice = rm.GetString("selectedDevice");
            CapturingStarted = rm.GetString("capturingStarted");
            CapturingStoped = rm.GetString("capturingStoped");
            UploadFileToGoogleDrive = rm.GetString("uploadToGoogleDrive");
            FileUploadException = rm.GetString("fileUploadException");
            SaveFrameToFile = rm.GetString("saveFrameToFile");
            Error = rm.GetString("error");
            StartDelayedTo = rm.GetString("startDelayedTo");
            MotionSensorSensitivity = rm.GetString("motionSensorSensitivity");
            SettingsApplyError = rm.GetString("settingsApplyError");
            SnapshotsInterval = rm.GetString("snapshotsInterval");
            Seconds = rm.GetString("seconds");
            SnapshotsOnlyByInterval = rm.GetString("snapshotsOnlyByInterval");
            TelegramNotify = rm.GetString("telegramNotify");
            TelegramPhoneNumber = rm.GetString("telegramPhoneNumber");
            TelegramGetCode = rm.GetString("telegramGetCode");
            TelegramCode = rm.GetString("telegramCode");
            TelegramLogin = rm.GetString("telegramLogin");
            TelegramSessionStatus = rm.GetString("telegramSessionStatus");
            TelegramStatusChecking = rm.GetString("telegramStatusChecking");
            TelegramStatusActive = rm.GetString("telegramStatusActive");
            TelegramStatusInactive = rm.GetString("telegramStatusInactive");
        }
    }
}