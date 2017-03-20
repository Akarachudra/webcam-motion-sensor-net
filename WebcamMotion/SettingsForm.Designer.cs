namespace WebcamMotion
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.acceptButton = new System.Windows.Forms.Button();
            this.declineButton = new System.Windows.Forms.Button();
            this.googleDriveGroupBox = new System.Windows.Forms.GroupBox();
            this.driveBrowseButton = new System.Windows.Forms.Button();
            this.drivePathLabel = new System.Windows.Forms.Label();
            this.drivePathTextBox = new System.Windows.Forms.TextBox();
            this.googleDriveCheckBox = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.telegramGroupBox = new System.Windows.Forms.GroupBox();
            this.appSettingsBox = new System.Windows.Forms.GroupBox();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.saveBrowseButton = new System.Windows.Forms.Button();
            this.savePathLabel = new System.Windows.Forms.Label();
            this.saveFolderBox = new System.Windows.Forms.TextBox();
            this.showPreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.detectionStartCheckBox = new System.Windows.Forms.CheckBox();
            this.minimizeTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.capturingrSettingsBox = new System.Windows.Forms.GroupBox();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.intervalUpDown = new System.Windows.Forms.NumericUpDown();
            this.trackBarValLabel = new System.Windows.Forms.Label();
            this.sensitivityTrackBar = new System.Windows.Forms.TrackBar();
            this.sensitivityLabel = new System.Windows.Forms.Label();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.motionDelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.detectionDelayLabel = new System.Windows.Forms.Label();
            this.printTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.disableMotionSensorCheckBox = new System.Windows.Forms.CheckBox();
            this.telegramCheckBox = new System.Windows.Forms.CheckBox();
            this.telegramPhone = new System.Windows.Forms.TextBox();
            this.telegramGetCodeButton = new System.Windows.Forms.Button();
            this.telegramPhoneLabel = new System.Windows.Forms.Label();
            this.telegramCode = new System.Windows.Forms.TextBox();
            this.telegramLoginButton = new System.Windows.Forms.Button();
            this.telegramCodeLabel = new System.Windows.Forms.Label();
            this.telegramSessionLabel = new System.Windows.Forms.Label();
            this.telegramStatusLabel = new System.Windows.Forms.Label();
            this.googleDriveGroupBox.SuspendLayout();
            this.telegramGroupBox.SuspendLayout();
            this.appSettingsBox.SuspendLayout();
            this.capturingrSettingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionDelayUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(284, 386);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // declineButton
            // 
            this.declineButton.Location = new System.Drawing.Point(380, 386);
            this.declineButton.Name = "declineButton";
            this.declineButton.Size = new System.Drawing.Size(75, 23);
            this.declineButton.TabIndex = 5;
            this.declineButton.Text = "Cancel";
            this.declineButton.UseVisualStyleBackColor = true;
            this.declineButton.Click += new System.EventHandler(this.declineButton_Click);
            // 
            // googleDriveGroupBox
            // 
            this.googleDriveGroupBox.Controls.Add(this.driveBrowseButton);
            this.googleDriveGroupBox.Controls.Add(this.drivePathLabel);
            this.googleDriveGroupBox.Controls.Add(this.drivePathTextBox);
            this.googleDriveGroupBox.Controls.Add(this.googleDriveCheckBox);
            this.googleDriveGroupBox.Location = new System.Drawing.Point(12, 218);
            this.googleDriveGroupBox.Name = "googleDriveGroupBox";
            this.googleDriveGroupBox.Size = new System.Drawing.Size(347, 150);
            this.googleDriveGroupBox.TabIndex = 2;
            this.googleDriveGroupBox.TabStop = false;
            this.googleDriveGroupBox.Text = "Google Drive";
            // 
            // driveBrowseButton
            // 
            this.driveBrowseButton.Location = new System.Drawing.Point(261, 108);
            this.driveBrowseButton.Name = "driveBrowseButton";
            this.driveBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.driveBrowseButton.TabIndex = 2;
            this.driveBrowseButton.Text = "Browse";
            this.driveBrowseButton.UseVisualStyleBackColor = true;
            this.driveBrowseButton.Click += new System.EventHandler(this.driveBrowseButton_Click);
            // 
            // drivePathLabel
            // 
            this.drivePathLabel.AutoSize = true;
            this.drivePathLabel.Location = new System.Drawing.Point(9, 93);
            this.drivePathLabel.Name = "drivePathLabel";
            this.drivePathLabel.Size = new System.Drawing.Size(207, 13);
            this.drivePathLabel.TabIndex = 15;
            this.drivePathLabel.Text = "Save copies to (will be deleted after send):";
            // 
            // drivePathTextBox
            // 
            this.drivePathTextBox.Location = new System.Drawing.Point(12, 110);
            this.drivePathTextBox.Name = "drivePathTextBox";
            this.drivePathTextBox.ReadOnly = true;
            this.drivePathTextBox.Size = new System.Drawing.Size(243, 20);
            this.drivePathTextBox.TabIndex = 1;
            // 
            // googleDriveCheckBox
            // 
            this.googleDriveCheckBox.AutoSize = true;
            this.googleDriveCheckBox.Location = new System.Drawing.Point(12, 19);
            this.googleDriveCheckBox.Name = "googleDriveCheckBox";
            this.googleDriveCheckBox.Size = new System.Drawing.Size(167, 17);
            this.googleDriveCheckBox.TabIndex = 0;
            this.googleDriveCheckBox.Text = "Upload copies to google drive";
            this.googleDriveCheckBox.UseVisualStyleBackColor = true;
            // 
            // telegramGroupBox
            // 
            this.telegramGroupBox.Controls.Add(this.telegramStatusLabel);
            this.telegramGroupBox.Controls.Add(this.telegramSessionLabel);
            this.telegramGroupBox.Controls.Add(this.telegramCodeLabel);
            this.telegramGroupBox.Controls.Add(this.telegramLoginButton);
            this.telegramGroupBox.Controls.Add(this.telegramCode);
            this.telegramGroupBox.Controls.Add(this.telegramPhoneLabel);
            this.telegramGroupBox.Controls.Add(this.telegramGetCodeButton);
            this.telegramGroupBox.Controls.Add(this.telegramPhone);
            this.telegramGroupBox.Controls.Add(this.telegramCheckBox);
            this.telegramGroupBox.Location = new System.Drawing.Point(380, 218);
            this.telegramGroupBox.Name = "telegramGroupBox";
            this.telegramGroupBox.Size = new System.Drawing.Size(347, 150);
            this.telegramGroupBox.TabIndex = 4;
            this.telegramGroupBox.TabStop = false;
            this.telegramGroupBox.Text = "Telegram";
            // 
            // appSettingsBox
            // 
            this.appSettingsBox.Controls.Add(this.languageComboBox);
            this.appSettingsBox.Controls.Add(this.languageLabel);
            this.appSettingsBox.Controls.Add(this.saveBrowseButton);
            this.appSettingsBox.Controls.Add(this.savePathLabel);
            this.appSettingsBox.Controls.Add(this.saveFolderBox);
            this.appSettingsBox.Controls.Add(this.showPreviewCheckBox);
            this.appSettingsBox.Controls.Add(this.detectionStartCheckBox);
            this.appSettingsBox.Controls.Add(this.minimizeTrayCheckBox);
            this.appSettingsBox.Controls.Add(this.startupCheckBox);
            this.appSettingsBox.Location = new System.Drawing.Point(12, 12);
            this.appSettingsBox.Name = "appSettingsBox";
            this.appSettingsBox.Size = new System.Drawing.Size(347, 200);
            this.appSettingsBox.TabIndex = 1;
            this.appSettingsBox.TabStop = false;
            this.appSettingsBox.Text = "Application settings";
            // 
            // languageComboBox
            // 
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Location = new System.Drawing.Point(230, 40);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(106, 21);
            this.languageComboBox.TabIndex = 4;
            this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.languageComboBox_SelectedIndexChanged);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(227, 20);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(58, 13);
            this.languageLabel.TabIndex = 23;
            this.languageLabel.Text = "Language:";
            // 
            // saveBrowseButton
            // 
            this.saveBrowseButton.Location = new System.Drawing.Point(261, 157);
            this.saveBrowseButton.Name = "saveBrowseButton";
            this.saveBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.saveBrowseButton.TabIndex = 6;
            this.saveBrowseButton.Text = "Browse";
            this.saveBrowseButton.UseVisualStyleBackColor = true;
            this.saveBrowseButton.Click += new System.EventHandler(this.saveBrowseButton_Click);
            // 
            // savePathLabel
            // 
            this.savePathLabel.AutoSize = true;
            this.savePathLabel.Location = new System.Drawing.Point(9, 142);
            this.savePathLabel.Name = "savePathLabel";
            this.savePathLabel.Size = new System.Drawing.Size(98, 13);
            this.savePathLabel.TabIndex = 21;
            this.savePathLabel.Text = "Save snapshots to:";
            // 
            // saveFolderBox
            // 
            this.saveFolderBox.Location = new System.Drawing.Point(12, 159);
            this.saveFolderBox.Name = "saveFolderBox";
            this.saveFolderBox.ReadOnly = true;
            this.saveFolderBox.Size = new System.Drawing.Size(243, 20);
            this.saveFolderBox.TabIndex = 5;
            // 
            // showPreviewCheckBox
            // 
            this.showPreviewCheckBox.AutoSize = true;
            this.showPreviewCheckBox.Location = new System.Drawing.Point(12, 88);
            this.showPreviewCheckBox.Name = "showPreviewCheckBox";
            this.showPreviewCheckBox.Size = new System.Drawing.Size(93, 17);
            this.showPreviewCheckBox.TabIndex = 3;
            this.showPreviewCheckBox.Text = "Show preview";
            this.showPreviewCheckBox.UseVisualStyleBackColor = true;
            // 
            // detectionStartCheckBox
            // 
            this.detectionStartCheckBox.AutoSize = true;
            this.detectionStartCheckBox.Location = new System.Drawing.Point(12, 65);
            this.detectionStartCheckBox.Name = "detectionStartCheckBox";
            this.detectionStartCheckBox.Size = new System.Drawing.Size(150, 17);
            this.detectionStartCheckBox.TabIndex = 2;
            this.detectionStartCheckBox.Text = "Begin detection on startup";
            this.detectionStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // minimizeTrayCheckBox
            // 
            this.minimizeTrayCheckBox.AutoSize = true;
            this.minimizeTrayCheckBox.Location = new System.Drawing.Point(12, 42);
            this.minimizeTrayCheckBox.Name = "minimizeTrayCheckBox";
            this.minimizeTrayCheckBox.Size = new System.Drawing.Size(148, 17);
            this.minimizeTrayCheckBox.TabIndex = 1;
            this.minimizeTrayCheckBox.Text = "Minimize to tray on startup";
            this.minimizeTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // startupCheckBox
            // 
            this.startupCheckBox.AutoSize = true;
            this.startupCheckBox.Location = new System.Drawing.Point(12, 19);
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.Size = new System.Drawing.Size(112, 17);
            this.startupCheckBox.TabIndex = 0;
            this.startupCheckBox.Text = "Run with windows";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            // 
            // capturingrSettingsBox
            // 
            this.capturingrSettingsBox.Controls.Add(this.disableMotionSensorCheckBox);
            this.capturingrSettingsBox.Controls.Add(this.secondsLabel);
            this.capturingrSettingsBox.Controls.Add(this.intervalLabel);
            this.capturingrSettingsBox.Controls.Add(this.intervalUpDown);
            this.capturingrSettingsBox.Controls.Add(this.trackBarValLabel);
            this.capturingrSettingsBox.Controls.Add(this.sensitivityTrackBar);
            this.capturingrSettingsBox.Controls.Add(this.sensitivityLabel);
            this.capturingrSettingsBox.Controls.Add(this.minutesLabel);
            this.capturingrSettingsBox.Controls.Add(this.motionDelayUpDown);
            this.capturingrSettingsBox.Controls.Add(this.detectionDelayLabel);
            this.capturingrSettingsBox.Controls.Add(this.printTimeCheckBox);
            this.capturingrSettingsBox.Location = new System.Drawing.Point(380, 12);
            this.capturingrSettingsBox.Name = "capturingrSettingsBox";
            this.capturingrSettingsBox.Size = new System.Drawing.Size(347, 200);
            this.capturingrSettingsBox.TabIndex = 3;
            this.capturingrSettingsBox.TabStop = false;
            this.capturingrSettingsBox.Text = "Capturing settings";
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Location = new System.Drawing.Point(124, 40);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(24, 13);
            this.secondsLabel.TabIndex = 22;
            this.secondsLabel.Text = "sec";
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(9, 20);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(97, 13);
            this.intervalLabel.TabIndex = 21;
            this.intervalLabel.Text = "Snapshots interval:";
            // 
            // intervalUpDown
            // 
            this.intervalUpDown.Location = new System.Drawing.Point(12, 39);
            this.intervalUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.intervalUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intervalUpDown.Name = "intervalUpDown";
            this.intervalUpDown.Size = new System.Drawing.Size(106, 20);
            this.intervalUpDown.TabIndex = 0;
            this.intervalUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // trackBarValLabel
            // 
            this.trackBarValLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarValLabel.Location = new System.Drawing.Point(239, 125);
            this.trackBarValLabel.Name = "trackBarValLabel";
            this.trackBarValLabel.Size = new System.Drawing.Size(100, 23);
            this.trackBarValLabel.TabIndex = 19;
            this.trackBarValLabel.Text = "0";
            this.trackBarValLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sensitivityTrackBar
            // 
            this.sensitivityTrackBar.LargeChange = 100;
            this.sensitivityTrackBar.Location = new System.Drawing.Point(6, 149);
            this.sensitivityTrackBar.Maximum = 1000;
            this.sensitivityTrackBar.Name = "sensitivityTrackBar";
            this.sensitivityTrackBar.Size = new System.Drawing.Size(333, 45);
            this.sensitivityTrackBar.TabIndex = 4;
            this.sensitivityTrackBar.ValueChanged += new System.EventHandler(this.sensitivityTrackBar_ValueChanged);
            // 
            // sensitivityLabel
            // 
            this.sensitivityLabel.AutoSize = true;
            this.sensitivityLabel.Location = new System.Drawing.Point(9, 130);
            this.sensitivityLabel.Name = "sensitivityLabel";
            this.sensitivityLabel.Size = new System.Drawing.Size(124, 13);
            this.sensitivityLabel.TabIndex = 17;
            this.sensitivityLabel.Text = "Motion sensor sensitivity:";
            // 
            // minutesLabel
            // 
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Location = new System.Drawing.Point(316, 40);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(23, 13);
            this.minutesLabel.TabIndex = 16;
            this.minutesLabel.Text = "min";
            // 
            // motionDelayUpDown
            // 
            this.motionDelayUpDown.Location = new System.Drawing.Point(204, 39);
            this.motionDelayUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.motionDelayUpDown.Name = "motionDelayUpDown";
            this.motionDelayUpDown.Size = new System.Drawing.Size(106, 20);
            this.motionDelayUpDown.TabIndex = 1;
            // 
            // detectionDelayLabel
            // 
            this.detectionDelayLabel.AutoSize = true;
            this.detectionDelayLabel.Location = new System.Drawing.Point(201, 20);
            this.detectionDelayLabel.Name = "detectionDelayLabel";
            this.detectionDelayLabel.Size = new System.Drawing.Size(106, 13);
            this.detectionDelayLabel.TabIndex = 14;
            this.detectionDelayLabel.Text = "Capturing start delay:";
            // 
            // printTimeCheckBox
            // 
            this.printTimeCheckBox.AutoSize = true;
            this.printTimeCheckBox.Location = new System.Drawing.Point(12, 65);
            this.printTimeCheckBox.Name = "printTimeCheckBox";
            this.printTimeCheckBox.Size = new System.Drawing.Size(120, 17);
            this.printTimeCheckBox.TabIndex = 2;
            this.printTimeCheckBox.Text = "Show date and time";
            this.printTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // disableMotionSensorCheckBox
            // 
            this.disableMotionSensorCheckBox.AutoSize = true;
            this.disableMotionSensorCheckBox.Location = new System.Drawing.Point(12, 88);
            this.disableMotionSensorCheckBox.Name = "disableMotionSensorCheckBox";
            this.disableMotionSensorCheckBox.Size = new System.Drawing.Size(285, 17);
            this.disableMotionSensorCheckBox.TabIndex = 3;
            this.disableMotionSensorCheckBox.Text = "Take snapshots only by interval (disable motion sensor)";
            this.disableMotionSensorCheckBox.UseVisualStyleBackColor = true;
            // 
            // telegramCheckBox
            // 
            this.telegramCheckBox.AutoSize = true;
            this.telegramCheckBox.Location = new System.Drawing.Point(12, 19);
            this.telegramCheckBox.Name = "telegramCheckBox";
            this.telegramCheckBox.Size = new System.Drawing.Size(219, 17);
            this.telegramCheckBox.TabIndex = 1;
            this.telegramCheckBox.Text = "Send motion detection notify to Telegram";
            this.telegramCheckBox.UseVisualStyleBackColor = true;
            // 
            // telegramPhone
            // 
            this.telegramPhone.Location = new System.Drawing.Point(12, 66);
            this.telegramPhone.Name = "telegramPhone";
            this.telegramPhone.Size = new System.Drawing.Size(120, 20);
            this.telegramPhone.TabIndex = 2;
            // 
            // telegramGetCodeButton
            // 
            this.telegramGetCodeButton.Location = new System.Drawing.Point(141, 64);
            this.telegramGetCodeButton.Name = "telegramGetCodeButton";
            this.telegramGetCodeButton.Size = new System.Drawing.Size(96, 23);
            this.telegramGetCodeButton.TabIndex = 3;
            this.telegramGetCodeButton.Text = "Get code";
            this.telegramGetCodeButton.UseVisualStyleBackColor = true;
            this.telegramGetCodeButton.Click += new System.EventHandler(this.telegramCodeButton_Click);
            // 
            // telegramPhoneLabel
            // 
            this.telegramPhoneLabel.AutoSize = true;
            this.telegramPhoneLabel.Location = new System.Drawing.Point(9, 47);
            this.telegramPhoneLabel.Name = "telegramPhoneLabel";
            this.telegramPhoneLabel.Size = new System.Drawing.Size(196, 13);
            this.telegramPhoneLabel.TabIndex = 4;
            this.telegramPhoneLabel.Text = "Phone number (example 79991234567):";
            // 
            // telegramCode
            // 
            this.telegramCode.Location = new System.Drawing.Point(12, 110);
            this.telegramCode.Name = "telegramCode";
            this.telegramCode.Size = new System.Drawing.Size(120, 20);
            this.telegramCode.TabIndex = 5;
            // 
            // telegramLoginButton
            // 
            this.telegramLoginButton.Location = new System.Drawing.Point(141, 108);
            this.telegramLoginButton.Name = "telegramLoginButton";
            this.telegramLoginButton.Size = new System.Drawing.Size(96, 23);
            this.telegramLoginButton.TabIndex = 6;
            this.telegramLoginButton.Text = "Login";
            this.telegramLoginButton.UseVisualStyleBackColor = true;
            this.telegramLoginButton.Click += new System.EventHandler(this.telegramLoginButton_Click);
            // 
            // telegramCodeLabel
            // 
            this.telegramCodeLabel.AutoSize = true;
            this.telegramCodeLabel.Location = new System.Drawing.Point(9, 93);
            this.telegramCodeLabel.Name = "telegramCodeLabel";
            this.telegramCodeLabel.Size = new System.Drawing.Size(35, 13);
            this.telegramCodeLabel.TabIndex = 7;
            this.telegramCodeLabel.Text = "Code:";
            // 
            // telegramSessionLabel
            // 
            this.telegramSessionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.telegramSessionLabel.AutoSize = true;
            this.telegramSessionLabel.Location = new System.Drawing.Point(261, 93);
            this.telegramSessionLabel.Name = "telegramSessionLabel";
            this.telegramSessionLabel.Size = new System.Drawing.Size(78, 13);
            this.telegramSessionLabel.TabIndex = 8;
            this.telegramSessionLabel.Text = "Session status:";
            this.telegramSessionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // telegramStatusLabel
            // 
            this.telegramStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.telegramStatusLabel.Location = new System.Drawing.Point(239, 110);
            this.telegramStatusLabel.Name = "telegramStatusLabel";
            this.telegramStatusLabel.Size = new System.Drawing.Size(100, 23);
            this.telegramStatusLabel.TabIndex = 9;
            this.telegramStatusLabel.Text = "Checking...";
            this.telegramStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 421);
            this.Controls.Add(this.capturingrSettingsBox);
            this.Controls.Add(this.appSettingsBox);
            this.Controls.Add(this.telegramGroupBox);
            this.Controls.Add(this.googleDriveGroupBox);
            this.Controls.Add(this.declineButton);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.googleDriveGroupBox.ResumeLayout(false);
            this.googleDriveGroupBox.PerformLayout();
            this.telegramGroupBox.ResumeLayout(false);
            this.telegramGroupBox.PerformLayout();
            this.appSettingsBox.ResumeLayout(false);
            this.appSettingsBox.PerformLayout();
            this.capturingrSettingsBox.ResumeLayout(false);
            this.capturingrSettingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionDelayUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button declineButton;
        private System.Windows.Forms.GroupBox googleDriveGroupBox;
        private System.Windows.Forms.CheckBox googleDriveCheckBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button driveBrowseButton;
        private System.Windows.Forms.Label drivePathLabel;
        private System.Windows.Forms.TextBox drivePathTextBox;
        private System.Windows.Forms.GroupBox telegramGroupBox;
        private System.Windows.Forms.GroupBox appSettingsBox;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Button saveBrowseButton;
        private System.Windows.Forms.Label savePathLabel;
        private System.Windows.Forms.TextBox saveFolderBox;
        private System.Windows.Forms.CheckBox showPreviewCheckBox;
        private System.Windows.Forms.CheckBox detectionStartCheckBox;
        private System.Windows.Forms.CheckBox minimizeTrayCheckBox;
        private System.Windows.Forms.CheckBox startupCheckBox;
        private System.Windows.Forms.GroupBox capturingrSettingsBox;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.NumericUpDown motionDelayUpDown;
        private System.Windows.Forms.Label detectionDelayLabel;
        private System.Windows.Forms.CheckBox printTimeCheckBox;
        private System.Windows.Forms.TrackBar sensitivityTrackBar;
        private System.Windows.Forms.Label sensitivityLabel;
        private System.Windows.Forms.Label trackBarValLabel;
        private System.Windows.Forms.NumericUpDown intervalUpDown;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.CheckBox disableMotionSensorCheckBox;
        private System.Windows.Forms.CheckBox telegramCheckBox;
        private System.Windows.Forms.Label telegramPhoneLabel;
        private System.Windows.Forms.Button telegramGetCodeButton;
        private System.Windows.Forms.TextBox telegramPhone;
        private System.Windows.Forms.Label telegramCodeLabel;
        private System.Windows.Forms.Button telegramLoginButton;
        private System.Windows.Forms.TextBox telegramCode;
        private System.Windows.Forms.Label telegramSessionLabel;
        private System.Windows.Forms.Label telegramStatusLabel;
    }
}