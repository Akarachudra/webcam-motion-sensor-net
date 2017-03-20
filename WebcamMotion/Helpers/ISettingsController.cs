namespace WebcamMotion.Helpers
{
    public interface ISettingsController
    {
        bool AutomaticVideoStart { get; set; }
        string GoogleApiRefreshToken { get; set; }
        bool GoogleDriveIntegration { get; set; }
        bool PrintDateTime { get; set; }
        int SaveAndSendMinutesAfterDetection { get; set; }
        string SaveTo { get; set; }
        string SaveToGoogleDrive { get; set; }
        string SelectedCamera { get; set; }
        bool ShowPreview { get; set; }
        int StartDelayInMinutes { get; set; }
        bool StartOnWindowsStartup { get; set; }
        bool TrayOnStartup { get; set; }
        string Language { get; set; }
        int Sensitivity { get; set; }
        int SnapshotsInterval { get; set; }
        bool OnlyInterval { get; set; }
        string TelegramPhoneNumber { get; set; }
        bool TelegramIntegration { get; set; }
    }
}