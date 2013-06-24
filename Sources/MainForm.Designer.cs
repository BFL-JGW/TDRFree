namespace TDRFree
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.btnExit = new System.Windows.Forms.Button();
      this.txtExcelFile = new System.Windows.Forms.TextBox();
      this.lblTDRFile = new System.Windows.Forms.Label();
      this.lblPrecipitationFile = new System.Windows.Forms.Label();
      this.txtbxPrecipitation = new System.Windows.Forms.TextBox();
      this.lblOutputDir = new System.Windows.Forms.Label();
      this.txtbxOutputDir = new System.Windows.Forms.TextBox();
      this.chckbxPPT = new System.Windows.Forms.CheckBox();
      this.txtbxPPT = new System.Windows.Forms.TextBox();
      this.btnBrowse1 = new System.Windows.Forms.Button();
      this.btnBrowse2 = new System.Windows.Forms.Button();
      this.btnLoad = new System.Windows.Forms.Button();
      this.pnlShow = new System.Windows.Forms.Panel();
      this.brPoints = new System.Windows.Forms.ProgressBar();
      this.brTimes = new System.Windows.Forms.ProgressBar();
      this.lblSteps = new System.Windows.Forms.Label();
      this.lblTimes = new System.Windows.Forms.Label();
      this.tbctrlMain = new System.Windows.Forms.TabControl();
      this.tbpgControl = new System.Windows.Forms.TabPage();
      this.chrtPrec1 = new Steema.TeeChart.TChart();
      this.bar1 = new Steema.TeeChart.Styles.Bar();
      this.bar2 = new Steema.TeeChart.Styles.Bar();
      this.line1 = new Steema.TeeChart.Styles.Line();
      this.clndrLast = new System.Windows.Forms.DateTimePicker();
      this.lblLast = new System.Windows.Forms.Label();
      this.lblFirst = new System.Windows.Forms.Label();
      this.clndrFirst = new System.Windows.Forms.DateTimePicker();
      this.tbpgAdvanced = new System.Windows.Forms.TabPage();
      this.grpbxColors = new System.Windows.Forms.GroupBox();
      this.lblIrrigationColor = new System.Windows.Forms.Label();
      this.lblPrecipitationColor = new System.Windows.Forms.Label();
      this.btnIrrigationColor = new System.Windows.Forms.Button();
      this.btnPrecipitationColor = new System.Windows.Forms.Button();
      this.lblAxisColor = new System.Windows.Forms.Label();
      this.lblBackgroundColor = new System.Windows.Forms.Label();
      this.btnAxesColor = new System.Windows.Forms.Button();
      this.btnBackgroundColor = new System.Windows.Forms.Button();
      this.tbpgPicture = new System.Windows.Forms.TabPage();
      this.pctrbxShow = new System.Windows.Forms.PictureBox();
      this.tbpgLog = new System.Windows.Forms.TabPage();
      this.rchdtLog = new System.Windows.Forms.RichTextBox();
      this.btnRun = new System.Windows.Forms.Button();
      this.chckbxIrrigation = new System.Windows.Forms.CheckBox();
      this.txtbxIrrigationFile = new System.Windows.Forms.TextBox();
      this.btnBrowse3 = new System.Windows.Forms.Button();
      this.btnBrowse4 = new System.Windows.Forms.Button();
      this.btnBrowse5 = new System.Windows.Forms.Button();
      this.pnlShow.SuspendLayout();
      this.tbctrlMain.SuspendLayout();
      this.tbpgControl.SuspendLayout();
      this.tbpgAdvanced.SuspendLayout();
      this.grpbxColors.SuspendLayout();
      this.tbpgPicture.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pctrbxShow)).BeginInit();
      this.tbpgLog.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnExit
      // 
      this.btnExit.Location = new System.Drawing.Point(738, 518);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(79, 37);
      this.btnExit.TabIndex = 0;
      this.btnExit.Text = "E&xit";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // txtExcelFile
      // 
      this.txtExcelFile.Location = new System.Drawing.Point(160, 10);
      this.txtExcelFile.Name = "txtExcelFile";
      this.txtExcelFile.Size = new System.Drawing.Size(474, 20);
      this.txtExcelFile.TabIndex = 2;
      this.txtExcelFile.Text = "d:\\userdata\\wesseling\\tdr_shape\\data\\tdr1.xlsx";
      // 
      // lblTDRFile
      // 
      this.lblTDRFile.AutoSize = true;
      this.lblTDRFile.Location = new System.Drawing.Point(50, 13);
      this.lblTDRFile.Name = "lblTDRFile";
      this.lblTDRFile.Size = new System.Drawing.Size(70, 13);
      this.lblTDRFile.TabIndex = 5;
      this.lblTDRFile.Text = "TDR data file";
      // 
      // lblPrecipitationFile
      // 
      this.lblPrecipitationFile.AutoSize = true;
      this.lblPrecipitationFile.Location = new System.Drawing.Point(50, 38);
      this.lblPrecipitationFile.Name = "lblPrecipitationFile";
      this.lblPrecipitationFile.Size = new System.Drawing.Size(81, 13);
      this.lblPrecipitationFile.TabIndex = 6;
      this.lblPrecipitationFile.Text = "Precipitation file";
      // 
      // txtbxPrecipitation
      // 
      this.txtbxPrecipitation.Location = new System.Drawing.Point(160, 35);
      this.txtbxPrecipitation.Name = "txtbxPrecipitation";
      this.txtbxPrecipitation.Size = new System.Drawing.Size(474, 20);
      this.txtbxPrecipitation.TabIndex = 7;
      this.txtbxPrecipitation.Text = "D:\\USERDATA\\Wesseling\\tdr_shape\\Data\\Rainprocessor.xls";
      // 
      // lblOutputDir
      // 
      this.lblOutputDir.AutoSize = true;
      this.lblOutputDir.Location = new System.Drawing.Point(50, 88);
      this.lblOutputDir.Name = "lblOutputDir";
      this.lblOutputDir.Size = new System.Drawing.Size(82, 13);
      this.lblOutputDir.TabIndex = 12;
      this.lblOutputDir.Text = "Output directory";
      // 
      // txtbxOutputDir
      // 
      this.txtbxOutputDir.Location = new System.Drawing.Point(160, 85);
      this.txtbxOutputDir.Name = "txtbxOutputDir";
      this.txtbxOutputDir.Size = new System.Drawing.Size(474, 20);
      this.txtbxOutputDir.TabIndex = 13;
      this.txtbxOutputDir.Text = "D:\\USERDATA\\Wesseling\\tdr_shape\\Output\\";
      // 
      // chckbxPPT
      // 
      this.chckbxPPT.AutoSize = true;
      this.chckbxPPT.Location = new System.Drawing.Point(50, 113);
      this.chckbxPPT.Name = "chckbxPPT";
      this.chckbxPPT.Size = new System.Drawing.Size(80, 17);
      this.chckbxPPT.TabIndex = 14;
      this.chckbxPPT.Text = "PowerPoint";
      this.chckbxPPT.UseVisualStyleBackColor = true;
      this.chckbxPPT.CheckedChanged += new System.EventHandler(this.chckbxPPT_CheckedChanged);
      // 
      // txtbxPPT
      // 
      this.txtbxPPT.Enabled = false;
      this.txtbxPPT.Location = new System.Drawing.Point(160, 110);
      this.txtbxPPT.Name = "txtbxPPT";
      this.txtbxPPT.Size = new System.Drawing.Size(474, 20);
      this.txtbxPPT.TabIndex = 15;
      this.txtbxPPT.Text = "D:\\USERDATA\\Wesseling\\tdr_shape\\Output\\test.ppt";
      // 
      // btnBrowse1
      // 
      this.btnBrowse1.Location = new System.Drawing.Point(640, 10);
      this.btnBrowse1.Name = "btnBrowse1";
      this.btnBrowse1.Size = new System.Drawing.Size(27, 20);
      this.btnBrowse1.TabIndex = 16;
      this.btnBrowse1.Text = "...";
      this.btnBrowse1.UseVisualStyleBackColor = true;
      this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
      // 
      // btnBrowse2
      // 
      this.btnBrowse2.Location = new System.Drawing.Point(640, 35);
      this.btnBrowse2.Name = "btnBrowse2";
      this.btnBrowse2.Size = new System.Drawing.Size(27, 20);
      this.btnBrowse2.TabIndex = 17;
      this.btnBrowse2.Text = "...";
      this.btnBrowse2.UseVisualStyleBackColor = true;
      this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
      // 
      // btnLoad
      // 
      this.btnLoad.Location = new System.Drawing.Point(738, 93);
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.Size = new System.Drawing.Size(79, 37);
      this.btnLoad.TabIndex = 18;
      this.btnLoad.Text = "&Load";
      this.btnLoad.UseVisualStyleBackColor = true;
      this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // pnlShow
      // 
      this.pnlShow.Controls.Add(this.brPoints);
      this.pnlShow.Controls.Add(this.brTimes);
      this.pnlShow.Controls.Add(this.lblSteps);
      this.pnlShow.Controls.Add(this.lblTimes);
      this.pnlShow.Controls.Add(this.tbctrlMain);
      this.pnlShow.Controls.Add(this.btnRun);
      this.pnlShow.Location = new System.Drawing.Point(6, 136);
      this.pnlShow.Name = "pnlShow";
      this.pnlShow.Size = new System.Drawing.Size(715, 419);
      this.pnlShow.TabIndex = 19;
      this.pnlShow.Visible = false;
      // 
      // brPoints
      // 
      this.brPoints.Location = new System.Drawing.Point(39, 384);
      this.brPoints.Name = "brPoints";
      this.brPoints.Size = new System.Drawing.Size(578, 23);
      this.brPoints.TabIndex = 16;
      // 
      // brTimes
      // 
      this.brTimes.Location = new System.Drawing.Point(39, 355);
      this.brTimes.Name = "brTimes";
      this.brTimes.Size = new System.Drawing.Size(578, 23);
      this.brTimes.TabIndex = 15;
      // 
      // lblSteps
      // 
      this.lblSteps.AutoSize = true;
      this.lblSteps.Location = new System.Drawing.Point(6, 385);
      this.lblSteps.Name = "lblSteps";
      this.lblSteps.Size = new System.Drawing.Size(31, 13);
      this.lblSteps.TabIndex = 14;
      this.lblSteps.Text = "Point";
      // 
      // lblTimes
      // 
      this.lblTimes.AutoSize = true;
      this.lblTimes.Location = new System.Drawing.Point(6, 366);
      this.lblTimes.Name = "lblTimes";
      this.lblTimes.Size = new System.Drawing.Size(30, 13);
      this.lblTimes.TabIndex = 13;
      this.lblTimes.Text = "Time";
      // 
      // tbctrlMain
      // 
      this.tbctrlMain.Controls.Add(this.tbpgControl);
      this.tbctrlMain.Controls.Add(this.tbpgAdvanced);
      this.tbctrlMain.Controls.Add(this.tbpgPicture);
      this.tbctrlMain.Controls.Add(this.tbpgLog);
      this.tbctrlMain.Location = new System.Drawing.Point(0, 3);
      this.tbctrlMain.Name = "tbctrlMain";
      this.tbctrlMain.SelectedIndex = 0;
      this.tbctrlMain.Size = new System.Drawing.Size(712, 343);
      this.tbctrlMain.TabIndex = 12;
      // 
      // tbpgControl
      // 
      this.tbpgControl.Controls.Add(this.chrtPrec1);
      this.tbpgControl.Controls.Add(this.clndrLast);
      this.tbpgControl.Controls.Add(this.lblLast);
      this.tbpgControl.Controls.Add(this.lblFirst);
      this.tbpgControl.Controls.Add(this.clndrFirst);
      this.tbpgControl.Location = new System.Drawing.Point(4, 22);
      this.tbpgControl.Name = "tbpgControl";
      this.tbpgControl.Padding = new System.Windows.Forms.Padding(3);
      this.tbpgControl.Size = new System.Drawing.Size(704, 317);
      this.tbpgControl.TabIndex = 0;
      this.tbpgControl.Text = "Control";
      this.tbpgControl.UseVisualStyleBackColor = true;
      // 
      // chrtPrec1
      // 
      // 
      // 
      // 
      this.chrtPrec1.Aspect.View3D = false;
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Bottom.Automatic = false;
      this.chrtPrec1.Axes.Bottom.AutomaticMaximum = false;
      this.chrtPrec1.Axes.Bottom.AutomaticMinimum = false;
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Bottom.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.Bottom.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.Bottom.Labels.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.Bottom.Labels.Bevel.StringColorTwo = "FF808080";
      this.chrtPrec1.Axes.Bottom.Maximum = 40448.403322210717D;
      this.chrtPrec1.Axes.Bottom.Minimum = 0D;
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Bottom.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.Bottom.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.Bottom.Title.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.Bottom.Title.Bevel.StringColorTwo = "FF808080";
      this.chrtPrec1.Axes.Bottom.Title.Caption = "Date";
      this.chrtPrec1.Axes.Bottom.Title.Lines = new string[] {
        "Date"};
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Depth.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.Depth.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.Depth.Labels.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.Depth.Labels.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Depth.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.Depth.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.Depth.Title.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.Depth.Title.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.DepthTop.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.DepthTop.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.DepthTop.Labels.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.DepthTop.Labels.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.DepthTop.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.DepthTop.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.DepthTop.Title.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.DepthTop.Title.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Left.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.Left.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.Left.Labels.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.Left.Labels.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Left.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.Left.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.Left.Title.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.Left.Title.Bevel.StringColorTwo = "FF808080";
      this.chrtPrec1.Axes.Left.Title.Caption = "Volume (mm)";
      this.chrtPrec1.Axes.Left.Title.Lines = new string[] {
        "Volume (mm)"};
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Right.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.Right.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.Right.Labels.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.Right.Labels.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Right.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.Right.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.Right.Title.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.Right.Title.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Top.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.Top.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.Top.Labels.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.Top.Labels.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Axes.Top.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Axes.Top.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Axes.Top.Title.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Axes.Top.Title.Bevel.StringColorTwo = "FF808080";
      this.chrtPrec1.BackColor = System.Drawing.Color.Transparent;
      this.chrtPrec1.Cursor = System.Windows.Forms.Cursors.Default;
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Footer.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Footer.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Footer.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Footer.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Header.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Header.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Header.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Header.Bevel.StringColorTwo = "FF808080";
      this.chrtPrec1.Header.Visible = false;
      // 
      // 
      // 
      this.chrtPrec1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
      // 
      // 
      // 
      this.chrtPrec1.Legend.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Legend.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Legend.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Legend.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Legend.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Legend.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Legend.Title.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Legend.Title.Bevel.StringColorTwo = "FF808080";
      this.chrtPrec1.Location = new System.Drawing.Point(6, 6);
      this.chrtPrec1.Name = "chrtPrec1";
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Panel.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Panel.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Panel.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Panel.Bevel.StringColorTwo = "FEFFFFFF";
      // 
      // 
      // 
      this.chrtPrec1.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Panel.Brush.ForegroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      // 
      // 
      // 
      this.chrtPrec1.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.chrtPrec1.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.chrtPrec1.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.chrtPrec1.Panel.Brush.Gradient.Visible = false;
      this.chrtPrec1.Panel.Brush.Solid = false;
      this.chrtPrec1.Panel.Brush.Style = System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal;
      this.chrtPrec1.Panel.Brush.Visible = false;
      // 
      // 
      // 
      this.chrtPrec1.Panel.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.chrtPrec1.Series.Add(this.bar1);
      this.chrtPrec1.Series.Add(this.bar2);
      this.chrtPrec1.Series.Add(this.line1);
      this.chrtPrec1.Size = new System.Drawing.Size(537, 305);
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.SubFooter.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.SubFooter.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.SubFooter.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.SubFooter.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.SubHeader.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.SubHeader.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.SubHeader.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.SubHeader.Bevel.StringColorTwo = "FF808080";
      this.chrtPrec1.TabIndex = 18;
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Walls.Back.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Walls.Back.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Walls.Back.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Walls.Back.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      this.chrtPrec1.Walls.Back.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Walls.Bottom.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Walls.Bottom.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Walls.Bottom.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Walls.Bottom.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Walls.Left.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Walls.Left.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Walls.Left.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Walls.Left.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      this.chrtPrec1.Walls.Left.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      // 
      // 
      // 
      // 
      // 
      // 
      this.chrtPrec1.Walls.Right.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.chrtPrec1.Walls.Right.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.chrtPrec1.Walls.Right.Bevel.StringColorOne = "FFFFFFFF";
      this.chrtPrec1.Walls.Right.Bevel.StringColorTwo = "FF808080";
      this.chrtPrec1.Walls.Visible = false;
      // 
      // 
      // 
      this.chrtPrec1.Zoom.Allow = false;
      // 
      // 
      // 
      this.chrtPrec1.Zoom.Brush.Visible = false;
      // 
      // 
      // 
      this.chrtPrec1.Zoom.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.chrtPrec1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chrtPrec1_MouseClick);
      // 
      // bar1
      // 
      // 
      // 
      // 
      this.bar1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.bar1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.bar1.ColorEach = false;
      // 
      // 
      // 
      // 
      // 
      // 
      this.bar1.Marks.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.bar1.Marks.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.bar1.Marks.Bevel.StringColorOne = "FFFFFFFF";
      this.bar1.Marks.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.bar1.Marks.Symbol.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.bar1.Marks.Symbol.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.bar1.Marks.Symbol.Bevel.StringColorOne = "FFFFFFFF";
      this.bar1.Marks.Symbol.Bevel.StringColorTwo = "FF808080";
      this.bar1.Marks.Visible = false;
      // 
      // 
      // 
      this.bar1.Pen.Visible = false;
      this.bar1.Title = "Precipitation";
      // 
      // 
      // 
      this.bar1.XValues.DataMember = "X";
      this.bar1.XValues.DateTime = true;
      this.bar1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
      // 
      // 
      // 
      this.bar1.YValues.DataMember = "Bar";
      // 
      // bar2
      // 
      // 
      // 
      // 
      this.bar2.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.bar2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.bar2.ColorEach = false;
      // 
      // 
      // 
      // 
      // 
      // 
      this.bar2.Marks.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.bar2.Marks.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.bar2.Marks.Bevel.StringColorOne = "FFFFFFFF";
      this.bar2.Marks.Bevel.StringColorTwo = "FF808080";
      // 
      // 
      // 
      // 
      // 
      // 
      this.bar2.Marks.Symbol.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.bar2.Marks.Symbol.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.bar2.Marks.Symbol.Bevel.StringColorOne = "FFFFFFFF";
      this.bar2.Marks.Symbol.Bevel.StringColorTwo = "FF808080";
      this.bar2.Marks.Visible = false;
      // 
      // 
      // 
      this.bar2.Pen.Visible = false;
      this.bar2.Title = "Irrigation";
      // 
      // 
      // 
      this.bar2.XValues.DataMember = "X";
      this.bar2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
      // 
      // 
      // 
      this.bar2.YValues.DataMember = "Bar";
      // 
      // line1
      // 
      // 
      // 
      // 
      this.line1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
      this.line1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
      this.line1.ColorEach = false;
      // 
      // 
      // 
      this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
      // 
      // 
      // 
      // 
      // 
      // 
      this.line1.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
      this.line1.ShowInLegend = false;
      this.line1.Title = "line1";
      // 
      // 
      // 
      this.line1.XValues.DataMember = "X";
      this.line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
      // 
      // 
      // 
      this.line1.YValues.DataMember = "Y";
      // 
      // clndrLast
      // 
      this.clndrLast.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.clndrLast.Location = new System.Drawing.Point(605, 73);
      this.clndrLast.Name = "clndrLast";
      this.clndrLast.Size = new System.Drawing.Size(93, 20);
      this.clndrLast.TabIndex = 8;
      this.clndrLast.ValueChanged += new System.EventHandler(this.clndrLast_ValueChanged);
      // 
      // lblLast
      // 
      this.lblLast.AutoSize = true;
      this.lblLast.Location = new System.Drawing.Point(549, 77);
      this.lblLast.Name = "lblLast";
      this.lblLast.Size = new System.Drawing.Size(51, 13);
      this.lblLast.TabIndex = 7;
      this.lblLast.Text = "Last date";
      // 
      // lblFirst
      // 
      this.lblFirst.AutoSize = true;
      this.lblFirst.Location = new System.Drawing.Point(549, 38);
      this.lblFirst.Name = "lblFirst";
      this.lblFirst.Size = new System.Drawing.Size(50, 13);
      this.lblFirst.TabIndex = 6;
      this.lblFirst.Text = "First date";
      // 
      // clndrFirst
      // 
      this.clndrFirst.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.clndrFirst.Location = new System.Drawing.Point(605, 34);
      this.clndrFirst.Name = "clndrFirst";
      this.clndrFirst.Size = new System.Drawing.Size(93, 20);
      this.clndrFirst.TabIndex = 5;
      this.clndrFirst.ValueChanged += new System.EventHandler(this.clndrFirst_ValueChanged);
      // 
      // tbpgAdvanced
      // 
      this.tbpgAdvanced.Controls.Add(this.grpbxColors);
      this.tbpgAdvanced.Location = new System.Drawing.Point(4, 22);
      this.tbpgAdvanced.Name = "tbpgAdvanced";
      this.tbpgAdvanced.Size = new System.Drawing.Size(704, 317);
      this.tbpgAdvanced.TabIndex = 3;
      this.tbpgAdvanced.Text = "Advanced";
      this.tbpgAdvanced.UseVisualStyleBackColor = true;
      // 
      // grpbxColors
      // 
      this.grpbxColors.Controls.Add(this.lblIrrigationColor);
      this.grpbxColors.Controls.Add(this.lblPrecipitationColor);
      this.grpbxColors.Controls.Add(this.btnIrrigationColor);
      this.grpbxColors.Controls.Add(this.btnPrecipitationColor);
      this.grpbxColors.Controls.Add(this.lblAxisColor);
      this.grpbxColors.Controls.Add(this.lblBackgroundColor);
      this.grpbxColors.Controls.Add(this.btnAxesColor);
      this.grpbxColors.Controls.Add(this.btnBackgroundColor);
      this.grpbxColors.Location = new System.Drawing.Point(150, 52);
      this.grpbxColors.Name = "grpbxColors";
      this.grpbxColors.Size = new System.Drawing.Size(301, 194);
      this.grpbxColors.TabIndex = 3;
      this.grpbxColors.TabStop = false;
      this.grpbxColors.Text = "Colors";
      // 
      // lblIrrigationColor
      // 
      this.lblIrrigationColor.AutoSize = true;
      this.lblIrrigationColor.Location = new System.Drawing.Point(18, 133);
      this.lblIrrigationColor.Name = "lblIrrigationColor";
      this.lblIrrigationColor.Size = new System.Drawing.Size(47, 13);
      this.lblIrrigationColor.TabIndex = 7;
      this.lblIrrigationColor.Text = "Irrigation";
      // 
      // lblPrecipitationColor
      // 
      this.lblPrecipitationColor.AutoSize = true;
      this.lblPrecipitationColor.Location = new System.Drawing.Point(18, 95);
      this.lblPrecipitationColor.Name = "lblPrecipitationColor";
      this.lblPrecipitationColor.Size = new System.Drawing.Size(65, 13);
      this.lblPrecipitationColor.TabIndex = 6;
      this.lblPrecipitationColor.Text = "Precipitation";
      // 
      // btnIrrigationColor
      // 
      this.btnIrrigationColor.BackColor = System.Drawing.Color.White;
      this.btnIrrigationColor.Location = new System.Drawing.Point(184, 123);
      this.btnIrrigationColor.Name = "btnIrrigationColor";
      this.btnIrrigationColor.Size = new System.Drawing.Size(41, 32);
      this.btnIrrigationColor.TabIndex = 5;
      this.btnIrrigationColor.UseVisualStyleBackColor = false;
      this.btnIrrigationColor.Click += new System.EventHandler(this.btnIrrigationColor_Click);
      // 
      // btnPrecipitationColor
      // 
      this.btnPrecipitationColor.BackColor = System.Drawing.Color.White;
      this.btnPrecipitationColor.Location = new System.Drawing.Point(184, 85);
      this.btnPrecipitationColor.Name = "btnPrecipitationColor";
      this.btnPrecipitationColor.Size = new System.Drawing.Size(41, 32);
      this.btnPrecipitationColor.TabIndex = 4;
      this.btnPrecipitationColor.UseVisualStyleBackColor = false;
      this.btnPrecipitationColor.Click += new System.EventHandler(this.btnPrecipitationColor_Click);
      // 
      // lblAxisColor
      // 
      this.lblAxisColor.AutoSize = true;
      this.lblAxisColor.Location = new System.Drawing.Point(18, 57);
      this.lblAxisColor.Name = "lblAxisColor";
      this.lblAxisColor.Size = new System.Drawing.Size(71, 13);
      this.lblAxisColor.TabIndex = 3;
      this.lblAxisColor.Text = "Axes and text";
      // 
      // lblBackgroundColor
      // 
      this.lblBackgroundColor.AutoSize = true;
      this.lblBackgroundColor.Location = new System.Drawing.Point(18, 20);
      this.lblBackgroundColor.Name = "lblBackgroundColor";
      this.lblBackgroundColor.Size = new System.Drawing.Size(65, 13);
      this.lblBackgroundColor.TabIndex = 2;
      this.lblBackgroundColor.Text = "Background";
      // 
      // btnAxesColor
      // 
      this.btnAxesColor.BackColor = System.Drawing.Color.White;
      this.btnAxesColor.Location = new System.Drawing.Point(184, 47);
      this.btnAxesColor.Name = "btnAxesColor";
      this.btnAxesColor.Size = new System.Drawing.Size(41, 32);
      this.btnAxesColor.TabIndex = 1;
      this.btnAxesColor.UseVisualStyleBackColor = false;
      this.btnAxesColor.Click += new System.EventHandler(this.btnAxesColor_Click);
      // 
      // btnBackgroundColor
      // 
      this.btnBackgroundColor.BackColor = System.Drawing.Color.Black;
      this.btnBackgroundColor.Location = new System.Drawing.Point(184, 10);
      this.btnBackgroundColor.Name = "btnBackgroundColor";
      this.btnBackgroundColor.Size = new System.Drawing.Size(41, 32);
      this.btnBackgroundColor.TabIndex = 0;
      this.btnBackgroundColor.UseVisualStyleBackColor = false;
      this.btnBackgroundColor.Click += new System.EventHandler(this.btnBackgroundColor_Click);
      // 
      // tbpgPicture
      // 
      this.tbpgPicture.Controls.Add(this.pctrbxShow);
      this.tbpgPicture.Location = new System.Drawing.Point(4, 22);
      this.tbpgPicture.Name = "tbpgPicture";
      this.tbpgPicture.Padding = new System.Windows.Forms.Padding(3);
      this.tbpgPicture.Size = new System.Drawing.Size(704, 317);
      this.tbpgPicture.TabIndex = 1;
      this.tbpgPicture.Text = "Picture";
      this.tbpgPicture.UseVisualStyleBackColor = true;
      // 
      // pctrbxShow
      // 
      this.pctrbxShow.Location = new System.Drawing.Point(9, 14);
      this.pctrbxShow.Name = "pctrbxShow";
      this.pctrbxShow.Size = new System.Drawing.Size(571, 277);
      this.pctrbxShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pctrbxShow.TabIndex = 0;
      this.pctrbxShow.TabStop = false;
      // 
      // tbpgLog
      // 
      this.tbpgLog.Controls.Add(this.rchdtLog);
      this.tbpgLog.Location = new System.Drawing.Point(4, 22);
      this.tbpgLog.Name = "tbpgLog";
      this.tbpgLog.Padding = new System.Windows.Forms.Padding(3);
      this.tbpgLog.Size = new System.Drawing.Size(704, 317);
      this.tbpgLog.TabIndex = 2;
      this.tbpgLog.Text = "Log";
      this.tbpgLog.UseVisualStyleBackColor = true;
      // 
      // rchdtLog
      // 
      this.rchdtLog.Location = new System.Drawing.Point(6, 6);
      this.rchdtLog.Name = "rchdtLog";
      this.rchdtLog.Size = new System.Drawing.Size(455, 305);
      this.rchdtLog.TabIndex = 5;
      this.rchdtLog.Text = "";
      // 
      // btnRun
      // 
      this.btnRun.Location = new System.Drawing.Point(623, 366);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(79, 37);
      this.btnRun.TabIndex = 1;
      this.btnRun.Text = "&Run";
      this.btnRun.UseVisualStyleBackColor = true;
      this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
      // 
      // chckbxIrrigation
      // 
      this.chckbxIrrigation.AutoSize = true;
      this.chckbxIrrigation.Location = new System.Drawing.Point(50, 63);
      this.chckbxIrrigation.Name = "chckbxIrrigation";
      this.chckbxIrrigation.Size = new System.Drawing.Size(82, 17);
      this.chckbxIrrigation.TabIndex = 20;
      this.chckbxIrrigation.Text = "IrrigationFile";
      this.chckbxIrrigation.UseVisualStyleBackColor = true;
      this.chckbxIrrigation.CheckedChanged += new System.EventHandler(this.chckbxIrrigation_CheckedChanged);
      // 
      // txtbxIrrigationFile
      // 
      this.txtbxIrrigationFile.Enabled = false;
      this.txtbxIrrigationFile.Location = new System.Drawing.Point(160, 60);
      this.txtbxIrrigationFile.Name = "txtbxIrrigationFile";
      this.txtbxIrrigationFile.Size = new System.Drawing.Size(474, 20);
      this.txtbxIrrigationFile.TabIndex = 21;
      this.txtbxIrrigationFile.Text = "D:\\USERDATA\\Wesseling\\tdr_shape\\Data\\Irrigation.xls";
      // 
      // btnBrowse3
      // 
      this.btnBrowse3.Enabled = false;
      this.btnBrowse3.Location = new System.Drawing.Point(640, 60);
      this.btnBrowse3.Name = "btnBrowse3";
      this.btnBrowse3.Size = new System.Drawing.Size(27, 20);
      this.btnBrowse3.TabIndex = 22;
      this.btnBrowse3.Text = "...";
      this.btnBrowse3.UseVisualStyleBackColor = true;
      this.btnBrowse3.Click += new System.EventHandler(this.btnBrowse3_Click);
      // 
      // btnBrowse4
      // 
      this.btnBrowse4.Location = new System.Drawing.Point(640, 84);
      this.btnBrowse4.Name = "btnBrowse4";
      this.btnBrowse4.Size = new System.Drawing.Size(27, 20);
      this.btnBrowse4.TabIndex = 23;
      this.btnBrowse4.Text = "...";
      this.btnBrowse4.UseVisualStyleBackColor = true;
      this.btnBrowse4.Click += new System.EventHandler(this.btnBrowse4_Click);
      // 
      // btnBrowse5
      // 
      this.btnBrowse5.Enabled = false;
      this.btnBrowse5.Location = new System.Drawing.Point(640, 109);
      this.btnBrowse5.Name = "btnBrowse5";
      this.btnBrowse5.Size = new System.Drawing.Size(27, 20);
      this.btnBrowse5.TabIndex = 24;
      this.btnBrowse5.Text = "...";
      this.btnBrowse5.UseVisualStyleBackColor = true;
      this.btnBrowse5.Click += new System.EventHandler(this.btnBrowse5_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(819, 558);
      this.Controls.Add(this.btnBrowse5);
      this.Controls.Add(this.btnBrowse4);
      this.Controls.Add(this.btnBrowse3);
      this.Controls.Add(this.txtbxIrrigationFile);
      this.Controls.Add(this.chckbxIrrigation);
      this.Controls.Add(this.pnlShow);
      this.Controls.Add(this.btnLoad);
      this.Controls.Add(this.btnBrowse2);
      this.Controls.Add(this.btnBrowse1);
      this.Controls.Add(this.txtbxPPT);
      this.Controls.Add(this.chckbxPPT);
      this.Controls.Add(this.txtbxOutputDir);
      this.Controls.Add(this.lblOutputDir);
      this.Controls.Add(this.txtbxPrecipitation);
      this.Controls.Add(this.lblPrecipitationFile);
      this.Controls.Add(this.lblTDRFile);
      this.Controls.Add(this.txtExcelFile);
      this.Controls.Add(this.btnExit);
      this.Name = "MainForm";
      this.Text = "TDR Data show (V2.1.1, 10 Jan. 2013)";
      this.pnlShow.ResumeLayout(false);
      this.pnlShow.PerformLayout();
      this.tbctrlMain.ResumeLayout(false);
      this.tbpgControl.ResumeLayout(false);
      this.tbpgControl.PerformLayout();
      this.tbpgAdvanced.ResumeLayout(false);
      this.grpbxColors.ResumeLayout(false);
      this.grpbxColors.PerformLayout();
      this.tbpgPicture.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pctrbxShow)).EndInit();
      this.tbpgLog.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.TextBox txtExcelFile;
    private System.Windows.Forms.Label lblTDRFile;
    private System.Windows.Forms.Label lblPrecipitationFile;
    private System.Windows.Forms.TextBox txtbxPrecipitation;
    private System.Windows.Forms.Label lblOutputDir;
    private System.Windows.Forms.TextBox txtbxOutputDir;
    private System.Windows.Forms.CheckBox chckbxPPT;
    private System.Windows.Forms.TextBox txtbxPPT;
    private System.Windows.Forms.Button btnBrowse1;
    private System.Windows.Forms.Button btnBrowse2;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Panel pnlShow;
    private System.Windows.Forms.ProgressBar brPoints;
    private System.Windows.Forms.ProgressBar brTimes;
    private System.Windows.Forms.Label lblSteps;
    private System.Windows.Forms.Label lblTimes;
    private System.Windows.Forms.TabControl tbctrlMain;
    private System.Windows.Forms.TabPage tbpgControl;
    private Steema.TeeChart.TChart chrtPrec1;
    private System.Windows.Forms.DateTimePicker clndrLast;
    private System.Windows.Forms.Label lblLast;
    private System.Windows.Forms.Label lblFirst;
    private System.Windows.Forms.DateTimePicker clndrFirst;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.TabPage tbpgPicture;
    private System.Windows.Forms.PictureBox pctrbxShow;
    private System.Windows.Forms.TabPage tbpgLog;
    private System.Windows.Forms.RichTextBox rchdtLog;
    private Steema.TeeChart.Styles.Bar bar1;
    private System.Windows.Forms.CheckBox chckbxIrrigation;
    private System.Windows.Forms.TextBox txtbxIrrigationFile;
    private System.Windows.Forms.Button btnBrowse3;
    private Steema.TeeChart.Styles.Bar bar2;
    private Steema.TeeChart.Styles.Line line1;
    private System.Windows.Forms.Button btnBrowse4;
    private System.Windows.Forms.Button btnBrowse5;
    private System.Windows.Forms.TabPage tbpgAdvanced;
    private System.Windows.Forms.GroupBox grpbxColors;
    private System.Windows.Forms.Button btnAxesColor;
    private System.Windows.Forms.Button btnBackgroundColor;
    private System.Windows.Forms.Label lblAxisColor;
    private System.Windows.Forms.Label lblBackgroundColor;
    private System.Windows.Forms.Label lblIrrigationColor;
    private System.Windows.Forms.Label lblPrecipitationColor;
    private System.Windows.Forms.Button btnIrrigationColor;
    private System.Windows.Forms.Button btnPrecipitationColor;
  }
}

