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
            lblExpDatasLabel = new Label();
            gpSkyBrightness = new GroupBox();
            lblBortleClassDatas = new Label();
            lblBortleClassLabel = new Label();
            lblExpDatas = new Label();
            lblDmpsasDatas = new Label();
            lblDmpsasLabel = new Label();
            lblVisibleDatas = new Label();
            lblVisibleLabel = new Label();
            lblIrDatas = new Label();
            lblSqmLabel = new Label();
            lblIrLabel = new Label();
            lblSqmDatas = new Label();
            lblSqmUnits = new Label();
            lblFullLumDatas = new Label();
            lblFullLumLabel = new Label();
            gpCloudCoverture = new GroupBox();
            ipbCloudCover = new FontAwesome.Sharp.IconPictureBox();
            lblCloudCoverUnits = new Label();
            lblSkyTempUnits = new Label();
            lblCloudCoverData = new Label();
            lblCloudCoverLabel = new Label();
            lblSkyTempData = new Label();
            lblSkyTempLabel = new Label();
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
            label1 = new Label();
            nudRefreshFreq = new NumericUpDown();
            label2 = new Label();
            tcConfig.SuspendLayout();
            tDatas.SuspendLayout();
            gpSkyBrightness.SuspendLayout();
            gpCloudCoverture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ipbCloudCover).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)nudRefreshFreq).BeginInit();
            SuspendLayout();
            // 
            // tcConfig
            // 
            tcConfig.Controls.Add(tDatas);
            tcConfig.Controls.Add(tGraph);
            tcConfig.Controls.Add(tConfig);
            tcConfig.Location = new Point(0, 1);
            tcConfig.Margin = new Padding(1);
            tcConfig.Name = "tcConfig";
            tcConfig.SelectedIndex = 0;
            tcConfig.Size = new Size(572, 328);
            tcConfig.TabIndex = 0;
            // 
            // tDatas
            // 
            tDatas.Controls.Add(lblExpDatasLabel);
            tDatas.Controls.Add(gpSkyBrightness);
            tDatas.Controls.Add(gpCloudCoverture);
            tDatas.Controls.Add(gpDatasWeather);
            tDatas.Location = new Point(4, 24);
            tDatas.Margin = new Padding(1);
            tDatas.Name = "tDatas";
            tDatas.Padding = new Padding(1);
            tDatas.Size = new Size(564, 300);
            tDatas.TabIndex = 0;
            tDatas.Text = "Données";
            tDatas.UseVisualStyleBackColor = true;
            // 
            // lblExpDatasLabel
            // 
            lblExpDatasLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblExpDatasLabel.Location = new Point(439, 131);
            lblExpDatasLabel.Margin = new Padding(1, 0, 1, 0);
            lblExpDatasLabel.Name = "lblExpDatasLabel";
            lblExpDatasLabel.Size = new Size(102, 15);
            lblExpDatasLabel.TabIndex = 21;
            lblExpDatasLabel.Text = "Exp/Gain/Nb Iter :";
            lblExpDatasLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gpSkyBrightness
            // 
            gpSkyBrightness.Controls.Add(lblBortleClassDatas);
            gpSkyBrightness.Controls.Add(lblBortleClassLabel);
            gpSkyBrightness.Controls.Add(lblExpDatas);
            gpSkyBrightness.Controls.Add(lblDmpsasDatas);
            gpSkyBrightness.Controls.Add(lblDmpsasLabel);
            gpSkyBrightness.Controls.Add(lblVisibleDatas);
            gpSkyBrightness.Controls.Add(lblVisibleLabel);
            gpSkyBrightness.Controls.Add(lblIrDatas);
            gpSkyBrightness.Controls.Add(lblSqmLabel);
            gpSkyBrightness.Controls.Add(lblIrLabel);
            gpSkyBrightness.Controls.Add(lblSqmDatas);
            gpSkyBrightness.Controls.Add(lblSqmUnits);
            gpSkyBrightness.Controls.Add(lblFullLumDatas);
            gpSkyBrightness.Controls.Add(lblFullLumLabel);
            gpSkyBrightness.Location = new Point(7, 110);
            gpSkyBrightness.Name = "gpSkyBrightness";
            gpSkyBrightness.Size = new Size(547, 100);
            gpSkyBrightness.TabIndex = 2;
            gpSkyBrightness.TabStop = false;
            gpSkyBrightness.Text = "Qualité du ciel";
            // 
            // lblBortleClassDatas
            // 
            lblBortleClassDatas.Font = new Font("Cambria", 22F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBortleClassDatas.Location = new Point(67, 60);
            lblBortleClassDatas.Margin = new Padding(1, 0, 1, 0);
            lblBortleClassDatas.Name = "lblBortleClassDatas";
            lblBortleClassDatas.Size = new Size(66, 33);
            lblBortleClassDatas.TabIndex = 24;
            lblBortleClassDatas.Text = "0";
            lblBortleClassDatas.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBortleClassLabel
            // 
            lblBortleClassLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBortleClassLabel.Location = new Point(13, 68);
            lblBortleClassLabel.Margin = new Padding(1, 0, 1, 0);
            lblBortleClassLabel.Name = "lblBortleClassLabel";
            lblBortleClassLabel.Size = new Size(51, 22);
            lblBortleClassLabel.TabIndex = 23;
            lblBortleClassLabel.Text = "Bortle";
            lblBortleClassLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblExpDatas
            // 
            lblExpDatas.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpDatas.Location = new Point(432, 41);
            lblExpDatas.Margin = new Padding(1, 0, 1, 0);
            lblExpDatas.Name = "lblExpDatas";
            lblExpDatas.Size = new Size(111, 17);
            lblExpDatas.TabIndex = 22;
            lblExpDatas.Text = "0.00";
            lblExpDatas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDmpsasDatas
            // 
            lblDmpsasDatas.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDmpsasDatas.Location = new Point(298, 76);
            lblDmpsasDatas.Margin = new Padding(1, 0, 1, 0);
            lblDmpsasDatas.Name = "lblDmpsasDatas";
            lblDmpsasDatas.Size = new Size(125, 17);
            lblDmpsasDatas.TabIndex = 20;
            lblDmpsasDatas.Text = "0.00";
            lblDmpsasDatas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDmpsasLabel
            // 
            lblDmpsasLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblDmpsasLabel.Location = new Point(238, 78);
            lblDmpsasLabel.Margin = new Padding(1, 0, 1, 0);
            lblDmpsasLabel.Name = "lblDmpsasLabel";
            lblDmpsasLabel.Size = new Size(62, 15);
            lblDmpsasLabel.TabIndex = 19;
            lblDmpsasLabel.Text = "DMPSAS :";
            lblDmpsasLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVisibleDatas
            // 
            lblVisibleDatas.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVisibleDatas.Location = new Point(298, 58);
            lblVisibleDatas.Margin = new Padding(1, 0, 1, 0);
            lblVisibleDatas.Name = "lblVisibleDatas";
            lblVisibleDatas.Size = new Size(125, 17);
            lblVisibleDatas.TabIndex = 18;
            lblVisibleDatas.Text = "0.00";
            lblVisibleDatas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVisibleLabel
            // 
            lblVisibleLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblVisibleLabel.Location = new Point(238, 60);
            lblVisibleLabel.Margin = new Padding(1, 0, 1, 0);
            lblVisibleLabel.Name = "lblVisibleLabel";
            lblVisibleLabel.Size = new Size(51, 15);
            lblVisibleLabel.TabIndex = 17;
            lblVisibleLabel.Text = "Visible :";
            lblVisibleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIrDatas
            // 
            lblIrDatas.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIrDatas.Location = new Point(298, 39);
            lblIrDatas.Margin = new Padding(1, 0, 1, 0);
            lblIrDatas.Name = "lblIrDatas";
            lblIrDatas.Size = new Size(125, 17);
            lblIrDatas.TabIndex = 16;
            lblIrDatas.Text = "0.00";
            lblIrDatas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSqmLabel
            // 
            lblSqmLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSqmLabel.Location = new Point(13, 27);
            lblSqmLabel.Margin = new Padding(1, 0, 1, 0);
            lblSqmLabel.Name = "lblSqmLabel";
            lblSqmLabel.Size = new Size(51, 22);
            lblSqmLabel.TabIndex = 9;
            lblSqmLabel.Text = "SQM";
            lblSqmLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIrLabel
            // 
            lblIrLabel.Location = new Point(238, 41);
            lblIrLabel.Margin = new Padding(1, 0, 1, 0);
            lblIrLabel.Name = "lblIrLabel";
            lblIrLabel.Size = new Size(51, 15);
            lblIrLabel.TabIndex = 15;
            lblIrLabel.Text = "IR :";
            lblIrLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSqmDatas
            // 
            lblSqmDatas.Font = new Font("Cambria", 22F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSqmDatas.Location = new Point(62, 19);
            lblSqmDatas.Margin = new Padding(1, 0, 1, 0);
            lblSqmDatas.Name = "lblSqmDatas";
            lblSqmDatas.Size = new Size(77, 33);
            lblSqmDatas.TabIndex = 10;
            lblSqmDatas.Text = "0.00";
            lblSqmDatas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSqmUnits
            // 
            lblSqmUnits.AutoSize = true;
            lblSqmUnits.Location = new Point(143, 32);
            lblSqmUnits.Margin = new Padding(1, 0, 1, 0);
            lblSqmUnits.Name = "lblSqmUnits";
            lblSqmUnits.Size = new Size(73, 15);
            lblSqmUnits.TabIndex = 11;
            lblSqmUnits.Text = "mag/arcsec²";
            // 
            // lblFullLumDatas
            // 
            lblFullLumDatas.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFullLumDatas.Location = new Point(298, 22);
            lblFullLumDatas.Margin = new Padding(1, 0, 1, 0);
            lblFullLumDatas.Name = "lblFullLumDatas";
            lblFullLumDatas.Size = new Size(125, 17);
            lblFullLumDatas.TabIndex = 13;
            lblFullLumDatas.Text = "0.00";
            lblFullLumDatas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFullLumLabel
            // 
            lblFullLumLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblFullLumLabel.Location = new Point(238, 24);
            lblFullLumLabel.Margin = new Padding(1, 0, 1, 0);
            lblFullLumLabel.Name = "lblFullLumLabel";
            lblFullLumLabel.Size = new Size(51, 15);
            lblFullLumLabel.TabIndex = 12;
            lblFullLumLabel.Text = "Full :";
            lblFullLumLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gpCloudCoverture
            // 
            gpCloudCoverture.Controls.Add(ipbCloudCover);
            gpCloudCoverture.Controls.Add(lblCloudCoverUnits);
            gpCloudCoverture.Controls.Add(lblSkyTempUnits);
            gpCloudCoverture.Controls.Add(lblCloudCoverData);
            gpCloudCoverture.Controls.Add(lblCloudCoverLabel);
            gpCloudCoverture.Controls.Add(lblSkyTempData);
            gpCloudCoverture.Controls.Add(lblSkyTempLabel);
            gpCloudCoverture.Location = new Point(241, 6);
            gpCloudCoverture.Name = "gpCloudCoverture";
            gpCloudCoverture.Size = new Size(260, 91);
            gpCloudCoverture.TabIndex = 1;
            gpCloudCoverture.TabStop = false;
            gpCloudCoverture.Text = "Nuages";
            // 
            // ipbCloudCover
            // 
            ipbCloudCover.BackColor = Color.Transparent;
            ipbCloudCover.ForeColor = SystemColors.ControlText;
            ipbCloudCover.IconChar = FontAwesome.Sharp.IconChar.Cloud;
            ipbCloudCover.IconColor = SystemColors.ControlText;
            ipbCloudCover.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ipbCloudCover.IconSize = 55;
            ipbCloudCover.Location = new Point(185, 19);
            ipbCloudCover.Name = "ipbCloudCover";
            ipbCloudCover.Size = new Size(55, 60);
            ipbCloudCover.TabIndex = 12;
            ipbCloudCover.TabStop = false;
            // 
            // lblCloudCoverUnits
            // 
            lblCloudCoverUnits.AutoSize = true;
            lblCloudCoverUnits.Location = new Point(164, 42);
            lblCloudCoverUnits.Margin = new Padding(1, 0, 1, 0);
            lblCloudCoverUnits.Name = "lblCloudCoverUnits";
            lblCloudCoverUnits.Size = new Size(17, 15);
            lblCloudCoverUnits.TabIndex = 11;
            lblCloudCoverUnits.Text = "%";
            // 
            // lblSkyTempUnits
            // 
            lblSkyTempUnits.AutoSize = true;
            lblSkyTempUnits.Location = new Point(161, 24);
            lblSkyTempUnits.Margin = new Padding(1, 0, 1, 0);
            lblSkyTempUnits.Name = "lblSkyTempUnits";
            lblSkyTempUnits.Size = new Size(20, 15);
            lblSkyTempUnits.TabIndex = 11;
            lblSkyTempUnits.Text = "°C";
            // 
            // lblCloudCoverData
            // 
            lblCloudCoverData.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCloudCoverData.Location = new Point(111, 39);
            lblCloudCoverData.Margin = new Padding(1, 0, 1, 0);
            lblCloudCoverData.Name = "lblCloudCoverData";
            lblCloudCoverData.Size = new Size(49, 17);
            lblCloudCoverData.TabIndex = 10;
            lblCloudCoverData.Text = "0.00";
            lblCloudCoverData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCloudCoverLabel
            // 
            lblCloudCoverLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblCloudCoverLabel.Location = new Point(4, 41);
            lblCloudCoverLabel.Margin = new Padding(1, 0, 1, 0);
            lblCloudCoverLabel.Name = "lblCloudCoverLabel";
            lblCloudCoverLabel.Size = new Size(108, 15);
            lblCloudCoverLabel.TabIndex = 9;
            lblCloudCoverLabel.Text = "Couverture :";
            lblCloudCoverLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSkyTempData
            // 
            lblSkyTempData.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSkyTempData.Location = new Point(111, 21);
            lblSkyTempData.Margin = new Padding(1, 0, 1, 0);
            lblSkyTempData.Name = "lblSkyTempData";
            lblSkyTempData.Size = new Size(49, 17);
            lblSkyTempData.TabIndex = 10;
            lblSkyTempData.Text = "0.00";
            lblSkyTempData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSkyTempLabel
            // 
            lblSkyTempLabel.Location = new Point(4, 23);
            lblSkyTempLabel.Margin = new Padding(1, 0, 1, 0);
            lblSkyTempLabel.Name = "lblSkyTempLabel";
            lblSkyTempLabel.Size = new Size(108, 15);
            lblSkyTempLabel.TabIndex = 9;
            lblSkyTempLabel.Text = "Température Ciel :";
            lblSkyTempLabel.TextAlign = ContentAlignment.MiddleLeft;
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
            gpDatasWeather.Location = new Point(4, 6);
            gpDatasWeather.Margin = new Padding(1);
            gpDatasWeather.Name = "gpDatasWeather";
            gpDatasWeather.Padding = new Padding(1);
            gpDatasWeather.Size = new Size(210, 91);
            gpDatasWeather.TabIndex = 0;
            gpDatasWeather.TabStop = false;
            gpDatasWeather.Text = "Environnement";
            // 
            // lblPresUnits
            // 
            lblPresUnits.AutoSize = true;
            lblPresUnits.Location = new Point(148, 54);
            lblPresUnits.Margin = new Padding(1, 0, 1, 0);
            lblPresUnits.Name = "lblPresUnits";
            lblPresUnits.Size = new Size(29, 15);
            lblPresUnits.TabIndex = 8;
            lblPresUnits.Text = "HPa";
            // 
            // lblPressData
            // 
            lblPressData.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPressData.Location = new Point(97, 52);
            lblPressData.Margin = new Padding(1, 0, 1, 0);
            lblPressData.Name = "lblPressData";
            lblPressData.Size = new Size(49, 17);
            lblPressData.TabIndex = 7;
            lblPressData.Text = "0.00";
            lblPressData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPressLabel
            // 
            lblPressLabel.Location = new Point(3, 54);
            lblPressLabel.Margin = new Padding(1, 0, 1, 0);
            lblPressLabel.Name = "lblPressLabel";
            lblPressLabel.Size = new Size(100, 15);
            lblPressLabel.TabIndex = 6;
            lblPressLabel.Text = "Pression :";
            lblPressLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHumUnits
            // 
            lblHumUnits.AutoSize = true;
            lblHumUnits.Location = new Point(148, 38);
            lblHumUnits.Margin = new Padding(1, 0, 1, 0);
            lblHumUnits.Name = "lblHumUnits";
            lblHumUnits.Size = new Size(17, 15);
            lblHumUnits.TabIndex = 5;
            lblHumUnits.Text = "%";
            // 
            // lblHumData
            // 
            lblHumData.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHumData.Location = new Point(97, 35);
            lblHumData.Margin = new Padding(1, 0, 1, 0);
            lblHumData.Name = "lblHumData";
            lblHumData.Size = new Size(49, 17);
            lblHumData.TabIndex = 4;
            lblHumData.Text = "0.00";
            lblHumData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHumLabel
            // 
            lblHumLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblHumLabel.Location = new Point(3, 37);
            lblHumLabel.Margin = new Padding(1, 0, 1, 0);
            lblHumLabel.Name = "lblHumLabel";
            lblHumLabel.Size = new Size(100, 15);
            lblHumLabel.TabIndex = 3;
            lblHumLabel.Text = "Humidité :";
            lblHumLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTempUnits
            // 
            lblTempUnits.AutoSize = true;
            lblTempUnits.Location = new Point(148, 22);
            lblTempUnits.Margin = new Padding(1, 0, 1, 0);
            lblTempUnits.Name = "lblTempUnits";
            lblTempUnits.Size = new Size(20, 15);
            lblTempUnits.TabIndex = 2;
            lblTempUnits.Text = "°C";
            // 
            // lblTempData
            // 
            lblTempData.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTempData.Location = new Point(97, 19);
            lblTempData.Margin = new Padding(1, 0, 1, 0);
            lblTempData.Name = "lblTempData";
            lblTempData.Size = new Size(49, 17);
            lblTempData.TabIndex = 1;
            lblTempData.Text = "0.00";
            lblTempData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTempLabel
            // 
            lblTempLabel.Location = new Point(3, 19);
            lblTempLabel.Margin = new Padding(1, 0, 1, 0);
            lblTempLabel.Name = "lblTempLabel";
            lblTempLabel.Size = new Size(100, 15);
            lblTempLabel.TabIndex = 0;
            lblTempLabel.Text = "Température :";
            lblTempLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tGraph
            // 
            tGraph.Controls.Add(gpSQM);
            tGraph.Controls.Add(gpTempHumPress);
            tGraph.Location = new Point(4, 24);
            tGraph.Margin = new Padding(1);
            tGraph.Name = "tGraph";
            tGraph.Padding = new Padding(1);
            tGraph.Size = new Size(564, 300);
            tGraph.TabIndex = 1;
            tGraph.Text = "Graphiques";
            tGraph.UseVisualStyleBackColor = true;
            // 
            // gpSQM
            // 
            gpSQM.Controls.Add(fpSQM);
            gpSQM.Location = new Point(4, 159);
            gpSQM.Margin = new Padding(1);
            gpSQM.Name = "gpSQM";
            gpSQM.Padding = new Padding(1);
            gpSQM.Size = new Size(574, 141);
            gpSQM.TabIndex = 3;
            gpSQM.TabStop = false;
            gpSQM.Text = "Qualité du ciel";
            // 
            // fpSQM
            // 
            fpSQM.DisplayScale = 2.25F;
            fpSQM.Location = new Point(6, 23);
            fpSQM.Margin = new Padding(1);
            fpSQM.Name = "fpSQM";
            fpSQM.Size = new Size(562, 112);
            fpSQM.TabIndex = 1;
            // 
            // gpTempHumPress
            // 
            gpTempHumPress.Controls.Add(fpTempHumPress);
            gpTempHumPress.Location = new Point(3, 2);
            gpTempHumPress.Margin = new Padding(1);
            gpTempHumPress.Name = "gpTempHumPress";
            gpTempHumPress.Padding = new Padding(1);
            gpTempHumPress.Size = new Size(575, 152);
            gpTempHumPress.TabIndex = 2;
            gpTempHumPress.TabStop = false;
            gpTempHumPress.Text = "Données environnementales";
            // 
            // fpTempHumPress
            // 
            fpTempHumPress.DisplayScale = 2.25F;
            fpTempHumPress.Location = new Point(7, 25);
            fpTempHumPress.Margin = new Padding(1);
            fpTempHumPress.Name = "fpTempHumPress";
            fpTempHumPress.Size = new Size(562, 108);
            fpTempHumPress.TabIndex = 0;
            // 
            // tConfig
            // 
            tConfig.Controls.Add(label2);
            tConfig.Controls.Add(nudRefreshFreq);
            tConfig.Controls.Add(label1);
            tConfig.Controls.Add(gpCalibrationDatas);
            tConfig.Controls.Add(SttStripMain);
            tConfig.Controls.Add(gpConfigHostDatas);
            tConfig.Controls.Add(btnConfigConnectHost);
            tConfig.Controls.Add(lbConfigHostsList);
            tConfig.Controls.Add(btnConfigScan);
            tConfig.Controls.Add(txtConfigHost);
            tConfig.Location = new Point(4, 24);
            tConfig.Margin = new Padding(1);
            tConfig.Name = "tConfig";
            tConfig.Padding = new Padding(1);
            tConfig.Size = new Size(564, 300);
            tConfig.TabIndex = 2;
            tConfig.Text = "Configuration";
            tConfig.UseVisualStyleBackColor = true;
            // 
            // gpCalibrationDatas
            // 
            gpCalibrationDatas.Controls.Add(btnUploadCal);
            gpCalibrationDatas.Controls.Add(btnDownloadCal);
            gpCalibrationDatas.Location = new Point(21, 213);
            gpCalibrationDatas.Margin = new Padding(1);
            gpCalibrationDatas.Name = "gpCalibrationDatas";
            gpCalibrationDatas.Padding = new Padding(1);
            gpCalibrationDatas.Size = new Size(534, 67);
            gpCalibrationDatas.TabIndex = 9;
            gpCalibrationDatas.TabStop = false;
            gpCalibrationDatas.Text = "Calibration";
            // 
            // btnUploadCal
            // 
            btnUploadCal.Location = new Point(447, 35);
            btnUploadCal.Margin = new Padding(1);
            btnUploadCal.Name = "btnUploadCal";
            btnUploadCal.Size = new Size(79, 21);
            btnUploadCal.TabIndex = 1;
            btnUploadCal.Text = "Envoyer >>";
            btnUploadCal.UseVisualStyleBackColor = true;
            // 
            // btnDownloadCal
            // 
            btnDownloadCal.Location = new Point(13, 35);
            btnDownloadCal.Margin = new Padding(1);
            btnDownloadCal.Name = "btnDownloadCal";
            btnDownloadCal.Size = new Size(79, 21);
            btnDownloadCal.TabIndex = 0;
            btnDownloadCal.Text = "<< Obtenir";
            btnDownloadCal.UseVisualStyleBackColor = true;
            // 
            // SttStripMain
            // 
            SttStripMain.ImageScalingSize = new Size(36, 36);
            SttStripMain.Items.AddRange(new ToolStripItem[] { tsLblResult });
            SttStripMain.Location = new Point(1, 277);
            SttStripMain.Name = "SttStripMain";
            SttStripMain.Padding = new Padding(0, 0, 7, 0);
            SttStripMain.Size = new Size(562, 22);
            SttStripMain.TabIndex = 8;
            SttStripMain.Text = "statusStrip1";
            // 
            // tsLblResult
            // 
            tsLblResult.Name = "tsLblResult";
            tsLblResult.Size = new Size(0, 0);
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
            gpConfigHostDatas.Location = new Point(251, 7);
            gpConfigHostDatas.Margin = new Padding(1);
            gpConfigHostDatas.Name = "gpConfigHostDatas";
            gpConfigHostDatas.Padding = new Padding(1);
            gpConfigHostDatas.Size = new Size(304, 175);
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
            ipbConfigSensorSttBatt.IconSize = 29;
            ipbConfigSensorSttBatt.Location = new Point(254, 19);
            ipbConfigSensorSttBatt.Margin = new Padding(1);
            ipbConfigSensorSttBatt.Name = "ipbConfigSensorSttBatt";
            ipbConfigSensorSttBatt.Size = new Size(34, 29);
            ipbConfigSensorSttBatt.TabIndex = 10;
            ipbConfigSensorSttBatt.TabStop = false;
            // 
            // lblConfigDeviceWifiText
            // 
            lblConfigDeviceWifiText.AutoSize = true;
            lblConfigDeviceWifiText.Location = new Point(87, 63);
            lblConfigDeviceWifiText.Margin = new Padding(1, 0, 1, 0);
            lblConfigDeviceWifiText.Name = "lblConfigDeviceWifiText";
            lblConfigDeviceWifiText.Size = new Size(62, 15);
            lblConfigDeviceWifiText.TabIndex = 6;
            lblConfigDeviceWifiText.Text = "Wifi status";
            // 
            // lblConfigDeviceIdText
            // 
            lblConfigDeviceIdText.AutoSize = true;
            lblConfigDeviceIdText.Location = new Point(87, 42);
            lblConfigDeviceIdText.Margin = new Padding(1, 0, 1, 0);
            lblConfigDeviceIdText.Name = "lblConfigDeviceIdText";
            lblConfigDeviceIdText.Size = new Size(61, 15);
            lblConfigDeviceIdText.TabIndex = 5;
            lblConfigDeviceIdText.Text = "Identifiant";
            // 
            // lblConfigDeviceNameText
            // 
            lblConfigDeviceNameText.AutoSize = true;
            lblConfigDeviceNameText.Location = new Point(87, 22);
            lblConfigDeviceNameText.Margin = new Padding(1, 0, 1, 0);
            lblConfigDeviceNameText.Name = "lblConfigDeviceNameText";
            lblConfigDeviceNameText.Size = new Size(34, 15);
            lblConfigDeviceNameText.TabIndex = 4;
            lblConfigDeviceNameText.Text = "Nom";
            // 
            // gpConfigSensorStatuses
            // 
            gpConfigSensorStatuses.Controls.Add(ipbConfigSensorSttEnv);
            gpConfigSensorStatuses.Controls.Add(ipbConfigSensorSttSqm);
            gpConfigSensorStatuses.Controls.Add(ipbConfigSensorSttCloud);
            gpConfigSensorStatuses.Controls.Add(lblConfigSensorSttSqmTxt);
            gpConfigSensorStatuses.Controls.Add(lblConfigSensorSttEnvTxt);
            gpConfigSensorStatuses.Controls.Add(lblConfigSensorSttCloudTxt);
            gpConfigSensorStatuses.Location = new Point(12, 86);
            gpConfigSensorStatuses.Margin = new Padding(1);
            gpConfigSensorStatuses.Name = "gpConfigSensorStatuses";
            gpConfigSensorStatuses.Padding = new Padding(1);
            gpConfigSensorStatuses.Size = new Size(284, 73);
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
            ipbConfigSensorSttEnv.IconSize = 29;
            ipbConfigSensorSttEnv.Location = new Point(123, 17);
            ipbConfigSensorSttEnv.Margin = new Padding(1);
            ipbConfigSensorSttEnv.Name = "ipbConfigSensorSttEnv";
            ipbConfigSensorSttEnv.Size = new Size(34, 29);
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
            ipbConfigSensorSttSqm.IconSize = 29;
            ipbConfigSensorSttSqm.Location = new Point(217, 17);
            ipbConfigSensorSttSqm.Margin = new Padding(1);
            ipbConfigSensorSttSqm.Name = "ipbConfigSensorSttSqm";
            ipbConfigSensorSttSqm.Size = new Size(34, 29);
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
            ipbConfigSensorSttCloud.IconSize = 29;
            ipbConfigSensorSttCloud.Location = new Point(31, 17);
            ipbConfigSensorSttCloud.Margin = new Padding(1);
            ipbConfigSensorSttCloud.Name = "ipbConfigSensorSttCloud";
            ipbConfigSensorSttCloud.Size = new Size(34, 29);
            ipbConfigSensorSttCloud.TabIndex = 6;
            ipbConfigSensorSttCloud.TabStop = false;
            // 
            // lblConfigSensorSttSqmTxt
            // 
            lblConfigSensorSttSqmTxt.AutoSize = true;
            lblConfigSensorSttSqmTxt.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfigSensorSttSqmTxt.Location = new Point(187, 47);
            lblConfigSensorSttSqmTxt.Margin = new Padding(1, 0, 1, 0);
            lblConfigSensorSttSqmTxt.Name = "lblConfigSensorSttSqmTxt";
            lblConfigSensorSttSqmTxt.Size = new Size(94, 19);
            lblConfigSensorSttSqmTxt.TabIndex = 5;
            lblConfigSensorSttSqmTxt.Text = "DisConnected";
            // 
            // lblConfigSensorSttEnvTxt
            // 
            lblConfigSensorSttEnvTxt.AutoSize = true;
            lblConfigSensorSttEnvTxt.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfigSensorSttEnvTxt.Location = new Point(92, 47);
            lblConfigSensorSttEnvTxt.Margin = new Padding(1, 0, 1, 0);
            lblConfigSensorSttEnvTxt.Name = "lblConfigSensorSttEnvTxt";
            lblConfigSensorSttEnvTxt.Size = new Size(94, 19);
            lblConfigSensorSttEnvTxt.TabIndex = 4;
            lblConfigSensorSttEnvTxt.Text = "DisConnected";
            // 
            // lblConfigSensorSttCloudTxt
            // 
            lblConfigSensorSttCloudTxt.AutoSize = true;
            lblConfigSensorSttCloudTxt.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfigSensorSttCloudTxt.Location = new Point(3, 47);
            lblConfigSensorSttCloudTxt.Margin = new Padding(1, 0, 1, 0);
            lblConfigSensorSttCloudTxt.Name = "lblConfigSensorSttCloudTxt";
            lblConfigSensorSttCloudTxt.Size = new Size(94, 19);
            lblConfigSensorSttCloudTxt.TabIndex = 3;
            lblConfigSensorSttCloudTxt.Text = "DisConnected";
            // 
            // lblConfigDeviceWifiLbl
            // 
            lblConfigDeviceWifiLbl.AutoSize = true;
            lblConfigDeviceWifiLbl.Location = new Point(7, 63);
            lblConfigDeviceWifiLbl.Margin = new Padding(1, 0, 1, 0);
            lblConfigDeviceWifiLbl.Name = "lblConfigDeviceWifiLbl";
            lblConfigDeviceWifiLbl.Size = new Size(68, 15);
            lblConfigDeviceWifiLbl.TabIndex = 2;
            lblConfigDeviceWifiLbl.Text = "Wifi status :";
            // 
            // lblConfigDeviceIdLbl
            // 
            lblConfigDeviceIdLbl.AutoSize = true;
            lblConfigDeviceIdLbl.Location = new Point(7, 42);
            lblConfigDeviceIdLbl.Margin = new Padding(1, 0, 1, 0);
            lblConfigDeviceIdLbl.Name = "lblConfigDeviceIdLbl";
            lblConfigDeviceIdLbl.Size = new Size(67, 15);
            lblConfigDeviceIdLbl.TabIndex = 1;
            lblConfigDeviceIdLbl.Text = "Identifiant :";
            // 
            // lblConfigDeviceNameLabel
            // 
            lblConfigDeviceNameLabel.AutoSize = true;
            lblConfigDeviceNameLabel.Location = new Point(7, 22);
            lblConfigDeviceNameLabel.Margin = new Padding(1, 0, 1, 0);
            lblConfigDeviceNameLabel.Name = "lblConfigDeviceNameLabel";
            lblConfigDeviceNameLabel.Size = new Size(40, 15);
            lblConfigDeviceNameLabel.TabIndex = 0;
            lblConfigDeviceNameLabel.Text = "Nom :";
            // 
            // btnConfigConnectHost
            // 
            btnConfigConnectHost.Enabled = false;
            btnConfigConnectHost.Location = new Point(169, 34);
            btnConfigConnectHost.Margin = new Padding(1);
            btnConfigConnectHost.Name = "btnConfigConnectHost";
            btnConfigConnectHost.Size = new Size(79, 21);
            btnConfigConnectHost.TabIndex = 6;
            btnConfigConnectHost.Text = "Connecter";
            btnConfigConnectHost.UseVisualStyleBackColor = true;
            btnConfigConnectHost.Click += btnConfigConnectHost_Click;
            // 
            // lbConfigHostsList
            // 
            lbConfigHostsList.DisplayMember = "Key";
            lbConfigHostsList.FormattingEnabled = true;
            lbConfigHostsList.Location = new Point(20, 33);
            lbConfigHostsList.Margin = new Padding(1);
            lbConfigHostsList.Name = "lbConfigHostsList";
            lbConfigHostsList.Size = new Size(143, 154);
            lbConfigHostsList.TabIndex = 4;
            lbConfigHostsList.ValueMember = "Value";
            lbConfigHostsList.SelectedIndexChanged += lbConfigHostsList_SelectedIndexChanged;
            // 
            // btnConfigScan
            // 
            btnConfigScan.Location = new Point(169, 7);
            btnConfigScan.Margin = new Padding(1);
            btnConfigScan.Name = "btnConfigScan";
            btnConfigScan.Size = new Size(79, 21);
            btnConfigScan.TabIndex = 3;
            btnConfigScan.Text = "Scan";
            btnConfigScan.UseVisualStyleBackColor = true;
            btnConfigScan.Click += btnConfigScan_Click;
            // 
            // txtConfigHost
            // 
            txtConfigHost.Location = new Point(21, 9);
            txtConfigHost.Margin = new Padding(1);
            txtConfigHost.Name = "txtConfigHost";
            txtConfigHost.Size = new Size(141, 23);
            txtConfigHost.TabIndex = 0;
            txtConfigHost.TextChanged += txtConfigHost_TextChanged;
            // 
            // tRetrieveDatas
            // 
            tRetrieveDatas.Interval = 10000;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 197);
            label1.Name = "label1";
            label1.Size = new Size(161, 15);
            label1.TabIndex = 10;
            label1.Text = "Fréquence Rafraichissement :";
            // 
            // nudRefreshFreq
            // 
            nudRefreshFreq.Location = new Point(188, 195);
            nudRefreshFreq.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nudRefreshFreq.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudRefreshFreq.Name = "nudRefreshFreq";
            nudRefreshFreq.Size = new Size(45, 23);
            nudRefreshFreq.TabIndex = 11;
            nudRefreshFreq.Value = new decimal(new int[] { 5, 0, 0, 0 });
            nudRefreshFreq.ValueChanged += nudRefreshFreq_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 199);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 12;
            label2.Text = "secondes";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 330);
            Controls.Add(tcConfig);
            Margin = new Padding(1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HRO Environment";
            tcConfig.ResumeLayout(false);
            tDatas.ResumeLayout(false);
            gpSkyBrightness.ResumeLayout(false);
            gpSkyBrightness.PerformLayout();
            gpCloudCoverture.ResumeLayout(false);
            gpCloudCoverture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ipbCloudCover).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)nudRefreshFreq).EndInit();
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
        private GroupBox gpCloudCoverture;
        private Label lblCloudCoverUnits;
        private Label lblSkyTempUnits;
        private Label lblCloudCoverData;
        private Label lblCloudCoverLabel;
        private Label lblSkyTempData;
        private Label lblSkyTempLabel;
        private FontAwesome.Sharp.IconPictureBox ipbCloudCover;
        private GroupBox gpSkyBrightness;
        private Label lblIrDatas;
        private Label lblSqmLabel;
        private Label lblIrLabel;
        private Label lblSqmDatas;
        private Label lblSqmUnits;
        private Label lblFullLumDatas;
        private Label lblFullLumLabel;
        private Label lblDmpsasDatas;
        private Label lblDmpsasLabel;
        private Label lblVisibleDatas;
        private Label lblVisibleLabel;
        private Label lblExpDatasLabel;
        private Label lblExpDatas;
        private Label lblBortleClassLabel;
        private Label lblBortleClassDatas;
        private Label label2;
        private NumericUpDown nudRefreshFreq;
        private Label label1;
    }
}
