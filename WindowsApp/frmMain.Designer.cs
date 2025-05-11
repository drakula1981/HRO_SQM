namespace WindowsApp
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            tcConfig = new TabControl();
            tDatas = new TabPage();
            gpDatasWeather = new GroupBox();
            lblPresUnits = new Label();
            lblPressData = new Label();
            lblPressLabel = new Label();
            lblHumUnits = new Label();
            lblHumData = new Label();
            lblHumLabel = new Label();
            lblTempUnits = new Label();
            lblTempData = new Label();
            lblTempLabel = new Label();
            tGraph = new TabPage();
            gpSQM = new GroupBox();
            fpSQM = new ScottPlot.WinForms.FormsPlot();
            gpTempHumPress = new GroupBox();
            fpTempHumPress = new ScottPlot.WinForms.FormsPlot();
            tConfig = new TabPage();
            gpCalibrationDatas = new GroupBox();
            btnUploadCal = new Button();
            btnDownloadCal = new Button();
            SttStripMain = new StatusStrip();
            tsLblResult = new ToolStripStatusLabel();
            gpConfigHostDatas = new GroupBox();
            ipbConfigSensorSttBatt = new FontAwesome.Sharp.IconPictureBox();
            lblConfigDeviceWifiText = new Label();
            lblConfigDeviceIdText = new Label();
            lblConfigDeviceNameText = new Label();
            gpConfigSensorStatuses = new GroupBox();
            ipbConfigSensorSttEnv = new FontAwesome.Sharp.IconPictureBox();
            ipbConfigSensorSttSqm = new FontAwesome.Sharp.IconPictureBox();
            ipbConfigSensorSttCloud = new FontAwesome.Sharp.IconPictureBox();
            lblConfigSensorSttSqmTxt = new Label();
            lblConfigSensorSttEnvTxt = new Label();
            lblConfigSensorSttCloudTxt = new Label();
            lblConfigDeviceWifiLbl = new Label();
            lblConfigDeviceIdLbl = new Label();
            lblConfigDeviceNameLabel = new Label();
            btnConfigConnectHost = new Button();
            lbConfigHostsList = new ListBox();
            btnConfigScan = new Button();
            txtConfigHost = new TextBox();
            tRetrieveDatas = new System.Windows.Forms.Timer(components);
            tcConfig.SuspendLayout();
            tDatas.SuspendLayout();
            gpDatasWeather.SuspendLayout();
            tGraph.SuspendLayout();
            gpSQM.SuspendLayout();
            gpTempHumPress.SuspendLayout();
            tConfig.SuspendLayout();
            gpCalibrationDatas.SuspendLayout();
            SttStripMain.SuspendLayout();
            gpConfigHostDatas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ipbConfigSensorSttBatt).BeginInit();
            gpConfigSensorStatuses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ipbConfigSensorSttEnv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ipbConfigSensorSttSqm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ipbConfigSensorSttCloud).BeginInit();
            SuspendLayout();
            // 
            // tcConfig
            // 
            tcConfig.Controls.Add(tDatas);
            tcConfig.Controls.Add(tGraph);
            tcConfig.Controls.Add(tConfig);
            tcConfig.Location = new Point(-1, 2);
            tcConfig.Name = "tcConfig";
            tcConfig.SelectedIndex = 0;
            tcConfig.Size = new Size(1226, 810);
            tcConfig.TabIndex = 0;
            // 
            // tDatas
            // 
            tDatas.Controls.Add(gpDatasWeather);
            tDatas.Location = new Point(10, 55);
            tDatas.Name = "tDatas";
            tDatas.Padding = new Padding(3);
            tDatas.Size = new Size(1206, 745);
            tDatas.TabIndex = 0;
            tDatas.Text = "Données";
            tDatas.UseVisualStyleBackColor = true;
            // 
            // gpDatasWeather
            // 
            gpDatasWeather.Controls.Add(lblPresUnits);
            gpDatasWeather.Controls.Add(lblPressData);
            gpDatasWeather.Controls.Add(lblPressLabel);
            gpDatasWeather.Controls.Add(lblHumUnits);
            gpDatasWeather.Controls.Add(lblHumData);
            gpDatasWeather.Controls.Add(lblHumLabel);
            gpDatasWeather.Controls.Add(lblTempUnits);
            gpDatasWeather.Controls.Add(lblTempData);
            gpDatasWeather.Controls.Add(lblTempLabel);
            gpDatasWeather.Location = new Point(9, 15);
            gpDatasWeather.Name = "gpDatasWeather";
            gpDatasWeather.Size = new Size(450, 225);
            gpDatasWeather.TabIndex = 0;
            gpDatasWeather.TabStop = false;
            gpDatasWeather.Text = "Environnement";
            // 
            // lblPresUnits
            // 
            lblPresUnits.AutoSize = true;
            lblPresUnits.Location = new Point(318, 129);
            lblPresUnits.Name = "lblPresUnits";
            lblPresUnits.Size = new Size(64, 37);
            lblPresUnits.TabIndex = 8;
            lblPresUnits.Text = "HPa";
            // 
            // lblPressData
            // 
            lblPressData.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPressData.Location = new Point(207, 129);
            lblPressData.Name = "lblPressData";
            lblPressData.Size = new Size(105, 42);
            lblPressData.TabIndex = 7;
            lblPressData.Text = "0.00";
            lblPressData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPressLabel
            // 
            lblPressLabel.Location = new Point(6, 134);
            lblPressLabel.Name = "lblPressLabel";
            lblPressLabel.Size = new Size(215, 37);
            lblPressLabel.TabIndex = 6;
            lblPressLabel.Text = "Pression :";
            lblPressLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHumUnits
            // 
            lblHumUnits.AutoSize = true;
            lblHumUnits.Location = new Point(318, 92);
            lblHumUnits.Name = "lblHumUnits";
            lblHumUnits.Size = new Size(39, 37);
            lblHumUnits.TabIndex = 5;
            lblHumUnits.Text = "%";
            // 
            // lblHumData
            // 
            lblHumData.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHumData.Location = new Point(207, 87);
            lblHumData.Name = "lblHumData";
            lblHumData.Size = new Size(105, 42);
            lblHumData.TabIndex = 4;
            lblHumData.Text = "0.00";
            lblHumData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHumLabel
            // 
            lblHumLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblHumLabel.Location = new Point(6, 92);
            lblHumLabel.Name = "lblHumLabel";
            lblHumLabel.Size = new Size(215, 37);
            lblHumLabel.TabIndex = 3;
            lblHumLabel.Text = "Humidité :";
            lblHumLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTempUnits
            // 
            lblTempUnits.AutoSize = true;
            lblTempUnits.Location = new Point(318, 47);
            lblTempUnits.Name = "lblTempUnits";
            lblTempUnits.Size = new Size(44, 37);
            lblTempUnits.TabIndex = 2;
            lblTempUnits.Text = "°C";
            // 
            // lblTempData
            // 
            lblTempData.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTempData.Location = new Point(207, 47);
            lblTempData.Name = "lblTempData";
            lblTempData.Size = new Size(105, 42);
            lblTempData.TabIndex = 1;
            lblTempData.Text = "0.00";
            lblTempData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTempLabel
            // 
            lblTempLabel.Location = new Point(6, 47);
            lblTempLabel.Name = "lblTempLabel";
            lblTempLabel.Size = new Size(215, 37);
            lblTempLabel.TabIndex = 0;
            lblTempLabel.Text = "Température :";
            lblTempLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tGraph
            // 
            tGraph.Controls.Add(gpSQM);
            tGraph.Controls.Add(gpTempHumPress);
            tGraph.Location = new Point(10, 55);
            tGraph.Name = "tGraph";
            tGraph.Padding = new Padding(3);
            tGraph.Size = new Size(1206, 745);
            tGraph.TabIndex = 1;
            tGraph.Text = "Graphiques";
            tGraph.UseVisualStyleBackColor = true;
            // 
            // gpSQM
            // 
            gpSQM.Controls.Add(fpSQM);
            gpSQM.Location = new Point(9, 391);
            gpSQM.Name = "gpSQM";
            gpSQM.Size = new Size(1230, 348);
            gpSQM.TabIndex = 3;
            gpSQM.TabStop = false;
            gpSQM.Text = "Qualité du ciel";
            // 
            // fpSQM
            // 
            fpSQM.DisplayScale = 2.25F;
            fpSQM.Location = new Point(12, 56);
            fpSQM.Name = "fpSQM";
            fpSQM.Size = new Size(1204, 277);
            fpSQM.TabIndex = 1;
            // 
            // gpTempHumPress
            // 
            gpTempHumPress.Controls.Add(fpTempHumPress);
            gpTempHumPress.Location = new Point(6, 6);
            gpTempHumPress.Name = "gpTempHumPress";
            gpTempHumPress.Size = new Size(1233, 375);
            gpTempHumPress.TabIndex = 2;
            gpTempHumPress.TabStop = false;
            gpTempHumPress.Text = "Données environnementales";
            // 
            // fpTempHumPress
            // 
            fpTempHumPress.DisplayScale = 2.25F;
            fpTempHumPress.Location = new Point(15, 61);
            fpTempHumPress.Name = "fpTempHumPress";
            fpTempHumPress.Size = new Size(1204, 267);
            fpTempHumPress.TabIndex = 0;
            // 
            // tConfig
            // 
            tConfig.Controls.Add(gpCalibrationDatas);
            tConfig.Controls.Add(SttStripMain);
            tConfig.Controls.Add(gpConfigHostDatas);
            tConfig.Controls.Add(btnConfigConnectHost);
            tConfig.Controls.Add(lbConfigHostsList);
            tConfig.Controls.Add(btnConfigScan);
            tConfig.Controls.Add(txtConfigHost);
            tConfig.Location = new Point(10, 55);
            tConfig.Name = "tConfig";
            tConfig.Padding = new Padding(3);
            tConfig.Size = new Size(1206, 745);
            tConfig.TabIndex = 2;
            tConfig.Text = "Configuration";
            tConfig.UseVisualStyleBackColor = true;
            // 
            // gpCalibrationDatas
            // 
            gpCalibrationDatas.Controls.Add(btnUploadCal);
            gpCalibrationDatas.Controls.Add(btnDownloadCal);
            gpCalibrationDatas.Location = new Point(46, 467);
            gpCalibrationDatas.Name = "gpCalibrationDatas";
            gpCalibrationDatas.Size = new Size(1144, 225);
            gpCalibrationDatas.TabIndex = 9;
            gpCalibrationDatas.TabStop = false;
            gpCalibrationDatas.Text = "Calibration";
            // 
            // btnUploadCal
            // 
            btnUploadCal.Location = new Point(958, 87);
            btnUploadCal.Name = "btnUploadCal";
            btnUploadCal.Size = new Size(169, 52);
            btnUploadCal.TabIndex = 1;
            btnUploadCal.Text = "Envoyer >>";
            btnUploadCal.UseVisualStyleBackColor = true;
            // 
            // btnDownloadCal
            // 
            btnDownloadCal.Location = new Point(28, 87);
            btnDownloadCal.Name = "btnDownloadCal";
            btnDownloadCal.Size = new Size(169, 52);
            btnDownloadCal.TabIndex = 0;
            btnDownloadCal.Text = "<< Obtenir";
            btnDownloadCal.UseVisualStyleBackColor = true;
            // 
            // SttStripMain
            // 
            SttStripMain.ImageScalingSize = new Size(36, 36);
            SttStripMain.Items.AddRange(new ToolStripItem[] { tsLblResult });
            SttStripMain.Location = new Point(3, 720);
            SttStripMain.Name = "SttStripMain";
            SttStripMain.Size = new Size(1200, 22);
            SttStripMain.TabIndex = 8;
            SttStripMain.Text = "statusStrip1";
            // 
            // tsLblResult
            // 
            tsLblResult.Name = "tsLblResult";
            tsLblResult.Size = new Size(0, 11);
            // 
            // gpConfigHostDatas
            // 
            gpConfigHostDatas.Controls.Add(ipbConfigSensorSttBatt);
            gpConfigHostDatas.Controls.Add(lblConfigDeviceWifiText);
            gpConfigHostDatas.Controls.Add(lblConfigDeviceIdText);
            gpConfigHostDatas.Controls.Add(lblConfigDeviceNameText);
            gpConfigHostDatas.Controls.Add(gpConfigSensorStatuses);
            gpConfigHostDatas.Controls.Add(lblConfigDeviceWifiLbl);
            gpConfigHostDatas.Controls.Add(lblConfigDeviceIdLbl);
            gpConfigHostDatas.Controls.Add(lblConfigDeviceNameLabel);
            gpConfigHostDatas.Location = new Point(538, 17);
            gpConfigHostDatas.Name = "gpConfigHostDatas";
            gpConfigHostDatas.Size = new Size(652, 431);
            gpConfigHostDatas.TabIndex = 7;
            gpConfigHostDatas.TabStop = false;
            gpConfigHostDatas.Text = "Données";
            // 
            // ipbConfigSensorSttBatt
            // 
            ipbConfigSensorSttBatt.BackColor = Color.Transparent;
            ipbConfigSensorSttBatt.ForeColor = SystemColors.ControlText;
            ipbConfigSensorSttBatt.IconChar = FontAwesome.Sharp.IconChar.Battery0;
            ipbConfigSensorSttBatt.IconColor = SystemColors.ControlText;
            ipbConfigSensorSttBatt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ipbConfigSensorSttBatt.IconSize = 72;
            ipbConfigSensorSttBatt.Location = new Point(545, 46);
            ipbConfigSensorSttBatt.Name = "ipbConfigSensorSttBatt";
            ipbConfigSensorSttBatt.Size = new Size(72, 72);
            ipbConfigSensorSttBatt.TabIndex = 10;
            ipbConfigSensorSttBatt.TabStop = false;
            // 
            // lblConfigDeviceWifiText
            // 
            lblConfigDeviceWifiText.AutoSize = true;
            lblConfigDeviceWifiText.Location = new Point(187, 156);
            lblConfigDeviceWifiText.Name = "lblConfigDeviceWifiText";
            lblConfigDeviceWifiText.Size = new Size(153, 37);
            lblConfigDeviceWifiText.TabIndex = 6;
            lblConfigDeviceWifiText.Text = "Wifi status :";
            // 
            // lblConfigDeviceIdText
            // 
            lblConfigDeviceIdText.AutoSize = true;
            lblConfigDeviceIdText.Location = new Point(187, 103);
            lblConfigDeviceIdText.Name = "lblConfigDeviceIdText";
            lblConfigDeviceIdText.Size = new Size(151, 37);
            lblConfigDeviceIdText.TabIndex = 5;
            lblConfigDeviceIdText.Text = "Identifiant :";
            // 
            // lblConfigDeviceNameText
            // 
            lblConfigDeviceNameText.AutoSize = true;
            lblConfigDeviceNameText.Location = new Point(187, 54);
            lblConfigDeviceNameText.Name = "lblConfigDeviceNameText";
            lblConfigDeviceNameText.Size = new Size(89, 37);
            lblConfigDeviceNameText.TabIndex = 4;
            lblConfigDeviceNameText.Text = "Nom :";
            // 
            // gpConfigSensorStatuses
            // 
            gpConfigSensorStatuses.Controls.Add(ipbConfigSensorSttEnv);
            gpConfigSensorStatuses.Controls.Add(ipbConfigSensorSttSqm);
            gpConfigSensorStatuses.Controls.Add(ipbConfigSensorSttCloud);
            gpConfigSensorStatuses.Controls.Add(lblConfigSensorSttSqmTxt);
            gpConfigSensorStatuses.Controls.Add(lblConfigSensorSttEnvTxt);
            gpConfigSensorStatuses.Controls.Add(lblConfigSensorSttCloudTxt);
            gpConfigSensorStatuses.Location = new Point(26, 211);
            gpConfigSensorStatuses.Name = "gpConfigSensorStatuses";
            gpConfigSensorStatuses.Size = new Size(609, 179);
            gpConfigSensorStatuses.TabIndex = 3;
            gpConfigSensorStatuses.TabStop = false;
            gpConfigSensorStatuses.Text = "Capteurs";
            // 
            // ipbConfigSensorSttEnv
            // 
            ipbConfigSensorSttEnv.BackColor = Color.Transparent;
            ipbConfigSensorSttEnv.ForeColor = SystemColors.InactiveCaption;
            ipbConfigSensorSttEnv.IconChar = FontAwesome.Sharp.IconChar.Thermometer;
            ipbConfigSensorSttEnv.IconColor = SystemColors.InactiveCaption;
            ipbConfigSensorSttEnv.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ipbConfigSensorSttEnv.IconSize = 72;
            ipbConfigSensorSttEnv.Location = new Point(264, 42);
            ipbConfigSensorSttEnv.Name = "ipbConfigSensorSttEnv";
            ipbConfigSensorSttEnv.Size = new Size(72, 72);
            ipbConfigSensorSttEnv.TabIndex = 8;
            ipbConfigSensorSttEnv.TabStop = false;
            // 
            // ipbConfigSensorSttSqm
            // 
            ipbConfigSensorSttSqm.BackColor = Color.Transparent;
            ipbConfigSensorSttSqm.ForeColor = SystemColors.InactiveCaption;
            ipbConfigSensorSttSqm.IconChar = FontAwesome.Sharp.IconChar.Sun;
            ipbConfigSensorSttSqm.IconColor = SystemColors.InactiveCaption;
            ipbConfigSensorSttSqm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ipbConfigSensorSttSqm.IconSize = 72;
            ipbConfigSensorSttSqm.Location = new Point(465, 42);
            ipbConfigSensorSttSqm.Name = "ipbConfigSensorSttSqm";
            ipbConfigSensorSttSqm.Size = new Size(72, 72);
            ipbConfigSensorSttSqm.TabIndex = 7;
            ipbConfigSensorSttSqm.TabStop = false;
            // 
            // ipbConfigSensorSttCloud
            // 
            ipbConfigSensorSttCloud.BackColor = Color.Transparent;
            ipbConfigSensorSttCloud.ForeColor = SystemColors.InactiveCaption;
            ipbConfigSensorSttCloud.IconChar = FontAwesome.Sharp.IconChar.Cloud;
            ipbConfigSensorSttCloud.IconColor = SystemColors.InactiveCaption;
            ipbConfigSensorSttCloud.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ipbConfigSensorSttCloud.IconSize = 72;
            ipbConfigSensorSttCloud.Location = new Point(66, 42);
            ipbConfigSensorSttCloud.Name = "ipbConfigSensorSttCloud";
            ipbConfigSensorSttCloud.Size = new Size(72, 72);
            ipbConfigSensorSttCloud.TabIndex = 6;
            ipbConfigSensorSttCloud.TabStop = false;
            // 
            // lblConfigSensorSttSqmTxt
            // 
            lblConfigSensorSttSqmTxt.AutoSize = true;
            lblConfigSensorSttSqmTxt.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfigSensorSttSqmTxt.Location = new Point(401, 117);
            lblConfigSensorSttSqmTxt.Name = "lblConfigSensorSttSqmTxt";
            lblConfigSensorSttSqmTxt.Size = new Size(204, 41);
            lblConfigSensorSttSqmTxt.TabIndex = 5;
            lblConfigSensorSttSqmTxt.Text = "DisConnected";
            // 
            // lblConfigSensorSttEnvTxt
            // 
            lblConfigSensorSttEnvTxt.AutoSize = true;
            lblConfigSensorSttEnvTxt.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfigSensorSttEnvTxt.Location = new Point(198, 117);
            lblConfigSensorSttEnvTxt.Name = "lblConfigSensorSttEnvTxt";
            lblConfigSensorSttEnvTxt.Size = new Size(204, 41);
            lblConfigSensorSttEnvTxt.TabIndex = 4;
            lblConfigSensorSttEnvTxt.Text = "DisConnected";
            // 
            // lblConfigSensorSttCloudTxt
            // 
            lblConfigSensorSttCloudTxt.AutoSize = true;
            lblConfigSensorSttCloudTxt.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfigSensorSttCloudTxt.Location = new Point(6, 117);
            lblConfigSensorSttCloudTxt.Name = "lblConfigSensorSttCloudTxt";
            lblConfigSensorSttCloudTxt.Size = new Size(204, 41);
            lblConfigSensorSttCloudTxt.TabIndex = 3;
            lblConfigSensorSttCloudTxt.Text = "DisConnected";
            // 
            // lblConfigDeviceWifiLbl
            // 
            lblConfigDeviceWifiLbl.AutoSize = true;
            lblConfigDeviceWifiLbl.Location = new Point(15, 156);
            lblConfigDeviceWifiLbl.Name = "lblConfigDeviceWifiLbl";
            lblConfigDeviceWifiLbl.Size = new Size(153, 37);
            lblConfigDeviceWifiLbl.TabIndex = 2;
            lblConfigDeviceWifiLbl.Text = "Wifi status :";
            // 
            // lblConfigDeviceIdLbl
            // 
            lblConfigDeviceIdLbl.AutoSize = true;
            lblConfigDeviceIdLbl.Location = new Point(15, 103);
            lblConfigDeviceIdLbl.Name = "lblConfigDeviceIdLbl";
            lblConfigDeviceIdLbl.Size = new Size(151, 37);
            lblConfigDeviceIdLbl.TabIndex = 1;
            lblConfigDeviceIdLbl.Text = "Identifiant :";
            // 
            // lblConfigDeviceNameLabel
            // 
            lblConfigDeviceNameLabel.AutoSize = true;
            lblConfigDeviceNameLabel.Location = new Point(15, 54);
            lblConfigDeviceNameLabel.Name = "lblConfigDeviceNameLabel";
            lblConfigDeviceNameLabel.Size = new Size(89, 37);
            lblConfigDeviceNameLabel.TabIndex = 0;
            lblConfigDeviceNameLabel.Text = "Nom :";
            // 
            // btnConfigConnectHost
            // 
            btnConfigConnectHost.Enabled = false;
            btnConfigConnectHost.Location = new Point(363, 83);
            btnConfigConnectHost.Name = "btnConfigConnectHost";
            btnConfigConnectHost.Size = new Size(169, 52);
            btnConfigConnectHost.TabIndex = 6;
            btnConfigConnectHost.Text = "Connecter";
            btnConfigConnectHost.UseVisualStyleBackColor = true;
            btnConfigConnectHost.Click += btnConfigConnectHost_Click;
            // 
            // lbConfigHostsList
            // 
            lbConfigHostsList.DisplayMember = "Key";
            lbConfigHostsList.FormattingEnabled = true;
            lbConfigHostsList.Location = new Point(42, 81);
            lbConfigHostsList.Name = "lbConfigHostsList";
            lbConfigHostsList.Size = new Size(301, 374);
            lbConfigHostsList.TabIndex = 4;
            lbConfigHostsList.ValueMember = "Value";
            lbConfigHostsList.SelectedIndexChanged += lbConfigHostsList_SelectedIndexChanged;
            // 
            // btnConfigScan
            // 
            btnConfigScan.Location = new Point(362, 17);
            btnConfigScan.Name = "btnConfigScan";
            btnConfigScan.Size = new Size(169, 52);
            btnConfigScan.TabIndex = 3;
            btnConfigScan.Text = "Scan";
            btnConfigScan.UseVisualStyleBackColor = true;
            btnConfigScan.Click += btnConfigScan_Click;
            // 
            // txtConfigHost
            // 
            txtConfigHost.Location = new Point(46, 22);
            txtConfigHost.Name = "txtConfigHost";
            txtConfigHost.Size = new Size(297, 43);
            txtConfigHost.TabIndex = 0;
            txtConfigHost.TextChanged += txtConfigHost_TextChanged;
            // 
            // tRetrieveDatas
            // 
            tRetrieveDatas.Interval = 5000;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1221, 813);
            Controls.Add(tcConfig);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HRO Environment";
            tcConfig.ResumeLayout(false);
            tDatas.ResumeLayout(false);
            gpDatasWeather.ResumeLayout(false);
            gpDatasWeather.PerformLayout();
            tGraph.ResumeLayout(false);
            gpSQM.ResumeLayout(false);
            gpTempHumPress.ResumeLayout(false);
            tConfig.ResumeLayout(false);
            tConfig.PerformLayout();
            gpCalibrationDatas.ResumeLayout(false);
            SttStripMain.ResumeLayout(false);
            SttStripMain.PerformLayout();
            gpConfigHostDatas.ResumeLayout(false);
            gpConfigHostDatas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ipbConfigSensorSttBatt).EndInit();
            gpConfigSensorStatuses.ResumeLayout(false);
            gpConfigSensorStatuses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ipbConfigSensorSttEnv).EndInit();
            ((System.ComponentModel.ISupportInitialize)ipbConfigSensorSttSqm).EndInit();
            ((System.ComponentModel.ISupportInitialize)ipbConfigSensorSttCloud).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcConfig;
        private TabPage tDatas;
        private TabPage tGraph;
        private TabPage tConfig;
        private Button btnConfigScan;
        private TextBox txtConfigHost;
        private ListBox lbConfigHostsList;
        private Button btnConfigConnectHost;
        private GroupBox gpConfigHostDatas;
        private Label lblConfigDeviceIdLbl;
        private Label lblConfigDeviceNameLabel;
        private Label lblConfigDeviceWifiLbl;
        private GroupBox gpConfigSensorStatuses;
        private Label lblConfigDeviceWifiText;
        private Label lblConfigDeviceIdText;
        private Label lblConfigDeviceNameText;
        private Label lblConfigSensorSttCloudTxt;
        private Label lblConfigSensorSttSqmTxt;
        private Label lblConfigSensorSttEnvTxt;
        private StatusStrip SttStripMain;
        private ToolStripStatusLabel tsLblResult;
        private GroupBox gpCalibrationDatas;
        private Button btnDownloadCal;
        private Button btnUploadCal;
        private FontAwesome.Sharp.IconPictureBox ipbConfigSensorSttCloud;
        private FontAwesome.Sharp.IconPictureBox ipbConfigSensorSttSqm;
        private FontAwesome.Sharp.IconPictureBox ipbConfigSensorSttEnv;
        private ScottPlot.WinForms.FormsPlot fpSQM;
        private ScottPlot.WinForms.FormsPlot fpTempHumPress;
        private GroupBox gpTempHumPress;
        private GroupBox gpSQM;
        private FontAwesome.Sharp.IconPictureBox ipbConfigSensorSttBatt;
        private GroupBox gpDatasWeather;
        private Label lblTempUnits;
        private Label lblTempData;
        private Label lblTempLabel;
        private System.Windows.Forms.Timer tRetrieveDatas;
        private Label lblHumLabel;
        private Label lblPressLabel;
        private Label lblHumUnits;
        private Label lblHumData;
        private Label lblPresUnits;
        private Label lblPressData;
    }
}
