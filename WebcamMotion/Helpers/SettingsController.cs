using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WebcamMotion.Helpers
{
    public class SettingsController : ISettingsController
    {
        private string googleApiRefreshToken;
        private string saveToGoogleDrive;
        private string saveTo;
        private int saveAndSendMinutesAfterDetection;
        private bool showPreview;
        private bool automaticVideoStart;
        private int startDelayInMinutes;
        private bool startOnWindowsStartup;
        private bool printDateTime;
        private string selectedCamera;
        private bool trayOnStartup;
        private bool googleDriveIntegration;
        private string language;
        private int sensitivity;
        private int snapshotsInterval;
        private bool onlyInterval;
        private string telegramPhoneNumber;
        private bool telegramIntegration;

        public SettingsController()
        {
            if (ConfigurationManager.AppSettings["SaveTo"] != null)
                saveTo = ConfigurationManager.AppSettings["SaveTo"];
            else
                SaveTo = "";
            if (ConfigurationManager.AppSettings["SaveToGoogleDrive"] != null)
                saveToGoogleDrive = ConfigurationManager.AppSettings["SaveToGoogleDrive"];
            else
                SaveToGoogleDrive = "";
            if (ConfigurationManager.AppSettings["TelegramPhoneNumber"] != null)
                telegramPhoneNumber = ConfigurationManager.AppSettings["TelegramPhoneNumber"];
            else
                TelegramPhoneNumber = "";
            googleApiRefreshToken = ConfigurationManager.AppSettings["GoogleApiRefreshToken"];
            selectedCamera = ConfigurationManager.AppSettings["SelectedCamera"];
            language = ConfigurationManager.AppSettings["Language"];
            if (ConfigurationManager.AppSettings["GoogleDriveIntegration"] != null)
                googleDriveIntegration = Convert.ToBoolean(int.Parse(ConfigurationManager.AppSettings["GoogleDriveIntegration"]));
            if (ConfigurationManager.AppSettings["TrayOnStartup"] != null)
                trayOnStartup = Convert.ToBoolean(int.Parse(ConfigurationManager.AppSettings["TrayOnStartup"]));
            if (ConfigurationManager.AppSettings["PrintDateTime"] != null)
                printDateTime = Convert.ToBoolean(int.Parse(ConfigurationManager.AppSettings["PrintDateTime"]));
            if (ConfigurationManager.AppSettings["ShowPreview"] != null)
                showPreview = Convert.ToBoolean(int.Parse(ConfigurationManager.AppSettings["ShowPreview"]));
            if (ConfigurationManager.AppSettings["StartDelayInMinutes"] != null)
                startDelayInMinutes = int.Parse(ConfigurationManager.AppSettings["StartDelayInMinutes"]);
            if (ConfigurationManager.AppSettings["AutomaticVideoStart"] != null)
                automaticVideoStart = Convert.ToBoolean(int.Parse(ConfigurationManager.AppSettings["AutomaticVideoStart"]));
            if (ConfigurationManager.AppSettings["StartOnWindowsStartup"] != null)
                startOnWindowsStartup = Convert.ToBoolean(int.Parse(ConfigurationManager.AppSettings["StartOnWindowsStartup"]));
            if (ConfigurationManager.AppSettings["Sensitivity"] != null)
                sensitivity = int.Parse(ConfigurationManager.AppSettings["Sensitivity"]);
            if (ConfigurationManager.AppSettings["SnapshotsInterval"] != null)
                snapshotsInterval = int.Parse(ConfigurationManager.AppSettings["SnapshotsInterval"]);
            if (ConfigurationManager.AppSettings["OnlyInterval"] != null)
                onlyInterval = Convert.ToBoolean(int.Parse(ConfigurationManager.AppSettings["OnlyInterval"]));
            if (ConfigurationManager.AppSettings["TelegramIntegration"] != null)
                telegramIntegration = Convert.ToBoolean(int.Parse(ConfigurationManager.AppSettings["TelegramIntegration"]));
        }

        public bool TelegramIntegration
        {
            get { return telegramIntegration; }
            set
            {
                telegramIntegration = value;
                UpdateSetting("TelegramIntegration", Convert.ToInt32(value).ToString());
            }
        }

        public string TelegramPhoneNumber
        {
            get { return telegramPhoneNumber; }
            set
            {
                telegramPhoneNumber = value;
                UpdateSetting("TelegramPhoneNumber", value);
            }
        }

        public bool OnlyInterval
        {
            get { return onlyInterval; }
            set
            {
                onlyInterval = value;
                UpdateSetting("OnlyInterval", Convert.ToInt32(value).ToString());
            }
        }

        public int SnapshotsInterval
        {
            get { return Math.Max(1, snapshotsInterval); }
            set
            {
                snapshotsInterval = value;
                UpdateSetting("SnapshotsInterval", snapshotsInterval.ToString());
            }
        }

        public int Sensitivity
        {
            get { return sensitivity; }
            set
            {
                sensitivity = value;
                UpdateSetting("Sensitivity", sensitivity.ToString());
            }
        }

        public string Language
        {
            get { return language; }
            set
            {
                language = value;
                UpdateSetting("Language", value);
            }
        }

        public string SelectedCamera
        {
            get { return selectedCamera; }
            set
            {
                selectedCamera = value;
                UpdateSetting("SelectedCamera", value);
            }
        }

        public bool PrintDateTime
        {
            get { return printDateTime; }
            set
            {
                printDateTime = value;
                UpdateSetting("PrintDateTime", Convert.ToInt32(value).ToString());
            }
        }

        public bool StartOnWindowsStartup
        {
            get { return startOnWindowsStartup; }
            set
            {
                startOnWindowsStartup = value;
                UpdateSetting("StartOnWindowsStartup", Convert.ToInt32(value).ToString());
                var path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                var key = Registry.CurrentUser.OpenSubKey(path, true);
                if (value)
                {
                    key?.SetValue("WebcamMotion", $"\"{Application.ExecutablePath}\"");
                }
                else
                {
                    key?.DeleteValue("WebcamMotion", false);
                }
            }
        }

        public bool TrayOnStartup
        {
            get { return trayOnStartup; }
            set
            {
                trayOnStartup = value;
                UpdateSetting("TrayOnStartup", Convert.ToInt32(value).ToString());
            }
        }

        public int StartDelayInMinutes
        {
            get { return startDelayInMinutes; }
            set
            {
                startDelayInMinutes = value;
                UpdateSetting("StartDelayInMinutes", value.ToString());
            }
        }

        public bool AutomaticVideoStart
        {
            get { return automaticVideoStart; }
            set
            {
                automaticVideoStart = value;
                UpdateSetting("AutomaticVideoStart", Convert.ToInt32(value).ToString());
            }
        }

        public bool GoogleDriveIntegration
        {
            get { return googleDriveIntegration; }
            set
            {
                googleDriveIntegration = value;
                UpdateSetting("GoogleDriveIntegration", Convert.ToInt32(value).ToString());
            }
        }

        public bool ShowPreview
        {
            get { return showPreview; }
            set
            {
                showPreview = value;
                UpdateSetting("ShowPreview", Convert.ToInt32(value).ToString());
            }
        }

        public int SaveAndSendMinutesAfterDetection
        {
            get { return saveAndSendMinutesAfterDetection; }
            set
            {
                saveAndSendMinutesAfterDetection = value;
                UpdateSetting("SaveAndSendMinutesAfterDetection", value.ToString());
            }
        }

        public string SaveTo
        {
            get
            {
                return string.IsNullOrEmpty(saveTo) ? AppDomain.CurrentDomain.BaseDirectory : saveTo;
            }
            set
            {
                saveTo = value;
                UpdateSetting("SaveTo", value);
            }
        }

        public string SaveToGoogleDrive
        {
            get
            {
                return string.IsNullOrEmpty(saveToGoogleDrive) ? AppDomain.CurrentDomain.BaseDirectory : saveToGoogleDrive;
            }
            set
            {
                saveToGoogleDrive = value;
                UpdateSetting("SaveToGoogleDrive", value);
            }
        }

        public string GoogleApiRefreshToken
        {
            get { return googleApiRefreshToken; }
            set
            {
                googleApiRefreshToken = value;
                UpdateSetting("GoogleApiRefreshToken", value);
            }
        }

        private void UpdateSetting(string key, string value)
        {
            if (value == null) value = string.Empty;
            var configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            configuration.AppSettings.Settings.Remove(key);
            configuration.AppSettings.Settings.Add(key, value);
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}