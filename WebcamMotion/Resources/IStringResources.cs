namespace WebcamMotion.Resources
{
    public interface IStringResources
    {
        void RefreshResources();

        string Settings { get; set; }
        string Device { get; set; }
        string Log { get; set; }
        string PreviewWindow { get; set; }
        string Start { get; set; }
        string Stop { get; set; }
        string RunWithWindows { get; set; }
        string MinimizeToTray { get; set; }
        string BeginDetection { get; set; }
        string ShowPreview { get; set; }
        string ShowDateTime { get; set; }
        string StartDelay { get; set; }
        string SaveTo { get; set; }
        string Browse { get; set; }
        string GoogleDrive { get; set; }
        string UploadToGoogleDrive { get; set; }
        string SaveCopiesTo { get; set; }
        string Ok { get; set; }
        string Cancel { get; set; }
        string Minutes { get; set; }
        string Language { get; set; }
        string AppSettings { get; set; }
        string CapturingSettings { get; set; }
        string MotionDetected { get; set; }
        string AppStarted { get; set; }
        string AppStoped { get; set; }
        string SelectedDevice { get; set; }
        string CapturingStarted { get; set; }
        string CapturingStoped { get; set; }
        string UploadFileToGoogleDrive { get; set; }
        string FileUploadException { get; set; }
        string SaveFrameToFile { get; set; }
        string Error { get; set; }
        string StartDelayedTo { get; set; }
        string MotionSensorSensitivity { get; set; }
        string SettingsApplyError { get; set; }
        string SnapshotsInterval { get; set; }
        string Seconds { get; set; }
        string SnapshotsOnlyByInterval { get; set; }
        string TelegramNotify { get; set; }
        string TelegramPhoneNumber { get; set; }
        string TelegramGetCode { get; set; }
        string TelegramCode { get; set; }
        string TelegramLogin { get; set; }
        string TelegramSessionStatus { get; set; }
        string TelegramStatusChecking { get; set; }
        string TelegramStatusActive { get; set; }
        string TelegramStatusInactive { get; set; }
    }
}