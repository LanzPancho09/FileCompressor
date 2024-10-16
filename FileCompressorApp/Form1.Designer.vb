<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAbout = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.btnSettings = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.btnProgress = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.btnExplorer = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlNavigation = New System.Windows.Forms.Panel()
        Me.btnMinimize = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.btnClose = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.GunaElipse1 = New Guna.UI.WinForms.GunaElipse(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbMain = New System.Windows.Forms.TabPage()
        Me.lblCmpMode = New System.Windows.Forms.Label()
        Me.btnPageEnd = New Guna.UI.WinForms.GunaCircleButton()
        Me.btnPagePrev = New Guna.UI.WinForms.GunaCircleButton()
        Me.btnPageNext = New Guna.UI.WinForms.GunaCircleButton()
        Me.btnPageStart = New Guna.UI.WinForms.GunaCircleButton()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.btnUnbonk = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.btnBonk = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.cbDrives = New Guna.UI.WinForms.GunaComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnBack = New Guna.UI.WinForms.GunaCircleButton()
        Me.txtPath = New Guna.UI.WinForms.GunaTextBox()
        Me.vsbFileDirectory = New Guna.UI.WinForms.GunaVScrollBar()
        Me.pnlHeader = New Guna.UI.WinForms.GunaElipsePanel()
        Me.pnlDate = New System.Windows.Forms.Panel()
        Me.btnSortDate = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Splitter3 = New System.Windows.Forms.Splitter()
        Me.pnlType = New System.Windows.Forms.Panel()
        Me.btnSortType = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.pnlSize = New System.Windows.Forms.Panel()
        Me.btnSortSize = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.pnlName = New System.Windows.Forms.Panel()
        Me.btnSortName = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.flpFileDirectory = New System.Windows.Forms.FlowLayoutPanel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DesktopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicturesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VideosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbProcess = New System.Windows.Forms.TabPage()
        Me.pnlProcessDetail = New Guna.UI.WinForms.GunaShadowPanel()
        Me.lblReadAvgSpeed = New System.Windows.Forms.Label()
        Me.lblReadSpeed = New System.Windows.Forms.Label()
        Me.lblProcessedStatus = New System.Windows.Forms.Label()
        Me.lblProcessPercent = New System.Windows.Forms.Label()
        Me.lblWriteAvgSpeed = New System.Windows.Forms.Label()
        Me.lblWriteSpeed = New System.Windows.Forms.Label()
        Me.lblFileStatus = New System.Windows.Forms.Label()
        Me.pbProcessed = New Guna.UI.WinForms.GunaProgressBar()
        Me.pnlStatus = New Guna.UI.WinForms.GunaShadowPanel()
        Me.lblThreadType = New System.Windows.Forms.Label()
        Me.pnlDetails = New Guna.UI.WinForms.GunaPanel()
        Me.lblTotalFileSize = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLastAvgRead = New System.Windows.Forms.Label()
        Me.lblLastAvgWrite = New System.Windows.Forms.Label()
        Me.lblLastTimeElapsed = New System.Windows.Forms.Label()
        Me.lblElapsedTime = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTimeRemaining = New System.Windows.Forms.Label()
        Me.btnCancel = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.lblOverallPercent = New System.Windows.Forms.Label()
        Me.lblFolderStatus = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pnlLoading = New Guna.UI.WinForms.GunaPanel()
        Me.pbOverall = New Guna.UI.WinForms.GunaCircleProgressBar()
        Me.pbDone = New System.Windows.Forms.PictureBox()
        Me.tbAbout = New System.Windows.Forms.TabPage()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.tbSettings = New System.Windows.Forms.TabPage()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.swMulti = New Guna.UI.WinForms.GunaSwitch()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbReport = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.flpReport = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblActualSave = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblActualPer = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.lblOutputType = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblOutputSize = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblOutputF = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblSourceType = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblSourceSize = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblSourceF = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblProcessType = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.lblPackageType = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.lblProcessMode = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.gbCompression = New System.Windows.Forms.GroupBox()
        Me.lblCHeaderTotalByte = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lblCTreeTotalByte = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lblCExpSize = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.lblCReadSpeed = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblCWriteSpeed = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblCTimeElapsed = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.gbDecompression = New System.Windows.Forms.GroupBox()
        Me.lblDHeaderTotalByte = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.lblDTreeTotalByte = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.lblDExpSize = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.lblDReadSpeed = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.lblDWriteSpeed = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.lblDTimeElapsed = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblReportMsg = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.tmProgress = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.bwMulti = New System.ComponentModel.BackgroundWorker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GunaLabel7 = New Guna.UI.WinForms.GunaLabel()
        Me.swIgnore = New Guna.UI.WinForms.GunaSwitch()
        Me.GunaLabel8 = New Guna.UI.WinForms.GunaLabel()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigation.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.GunaPanel2.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlDate.SuspendLayout()
        Me.pnlType.SuspendLayout()
        Me.pnlSize.SuspendLayout()
        Me.pnlName.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.tbProcess.SuspendLayout()
        Me.pnlProcessDetail.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.pnlDetails.SuspendLayout()
        Me.pnlLoading.SuspendLayout()
        CType(Me.pbDone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbAbout.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSettings.SuspendLayout()
        Me.tbReport.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.flpReport.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gbCompression.SuspendLayout()
        Me.gbDecompression.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnAbout)
        Me.Panel1.Controls.Add(Me.btnSettings)
        Me.Panel1.Controls.Add(Me.btnProgress)
        Me.Panel1.Controls.Add(Me.btnExplorer)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 619)
        Me.Panel1.TabIndex = 0
        '
        'btnAbout
        '
        Me.btnAbout.Animated = True
        Me.btnAbout.AnimationHoverSpeed = 0.07!
        Me.btnAbout.AnimationSpeed = 0.03!
        Me.btnAbout.BaseColor = System.Drawing.Color.Transparent
        Me.btnAbout.BorderColor = System.Drawing.Color.Black
        Me.btnAbout.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton
        Me.btnAbout.CheckedBaseColor = System.Drawing.Color.Transparent
        Me.btnAbout.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnAbout.CheckedForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAbout.CheckedImage = Global.FileCompressorApp.My.Resources.Resources.info_48px1
        Me.btnAbout.CheckedLineColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAbout.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAbout.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAbout.FocusedColor = System.Drawing.Color.Empty
        Me.btnAbout.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAbout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnAbout.Image = Global.FileCompressorApp.My.Resources.Resources.info_48px_grey
        Me.btnAbout.ImageOffsetX = 20
        Me.btnAbout.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnAbout.LineColor = System.Drawing.Color.Transparent
        Me.btnAbout.LineLeft = 2
        Me.btnAbout.Location = New System.Drawing.Point(0, 251)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.btnAbout.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnAbout.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAbout.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.info_48px
        Me.btnAbout.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnAbout.OnPressedColor = System.Drawing.Color.Black
        Me.btnAbout.Size = New System.Drawing.Size(200, 42)
        Me.btnAbout.TabIndex = 11
        Me.btnAbout.Text = "About"
        Me.btnAbout.TextOffsetX = 10
        '
        'btnSettings
        '
        Me.btnSettings.Animated = True
        Me.btnSettings.AnimationHoverSpeed = 0.07!
        Me.btnSettings.AnimationSpeed = 0.03!
        Me.btnSettings.BaseColor = System.Drawing.Color.Transparent
        Me.btnSettings.BorderColor = System.Drawing.Color.Black
        Me.btnSettings.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton
        Me.btnSettings.CheckedBaseColor = System.Drawing.Color.Transparent
        Me.btnSettings.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnSettings.CheckedForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSettings.CheckedImage = Global.FileCompressorApp.My.Resources.Resources.wrench_purple_48px
        Me.btnSettings.CheckedLineColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSettings.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSettings.FocusedColor = System.Drawing.Color.Empty
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnSettings.Image = Global.FileCompressorApp.My.Resources.Resources.wrench_48px
        Me.btnSettings.ImageOffsetX = 20
        Me.btnSettings.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnSettings.LineColor = System.Drawing.Color.Transparent
        Me.btnSettings.LineLeft = 2
        Me.btnSettings.Location = New System.Drawing.Point(0, 209)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.btnSettings.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnSettings.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSettings.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.wrench_purple_48px
        Me.btnSettings.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSettings.OnPressedColor = System.Drawing.Color.Black
        Me.btnSettings.Size = New System.Drawing.Size(200, 42)
        Me.btnSettings.TabIndex = 12
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.TextOffsetX = 10
        '
        'btnProgress
        '
        Me.btnProgress.Animated = True
        Me.btnProgress.AnimationHoverSpeed = 0.07!
        Me.btnProgress.AnimationSpeed = 0.03!
        Me.btnProgress.BaseColor = System.Drawing.Color.Transparent
        Me.btnProgress.BorderColor = System.Drawing.Color.Black
        Me.btnProgress.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton
        Me.btnProgress.CheckedBaseColor = System.Drawing.Color.Transparent
        Me.btnProgress.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnProgress.CheckedForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnProgress.CheckedImage = Global.FileCompressorApp.My.Resources.Resources.in_progress_48px1
        Me.btnProgress.CheckedLineColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnProgress.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnProgress.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnProgress.FocusedColor = System.Drawing.Color.Empty
        Me.btnProgress.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnProgress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnProgress.Image = Global.FileCompressorApp.My.Resources.Resources.in_progress_48px_grey
        Me.btnProgress.ImageOffsetX = 20
        Me.btnProgress.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnProgress.LineColor = System.Drawing.Color.Transparent
        Me.btnProgress.LineLeft = 2
        Me.btnProgress.Location = New System.Drawing.Point(0, 167)
        Me.btnProgress.Name = "btnProgress"
        Me.btnProgress.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.btnProgress.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnProgress.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnProgress.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.in_progress_48px
        Me.btnProgress.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnProgress.OnPressedColor = System.Drawing.Color.Black
        Me.btnProgress.Size = New System.Drawing.Size(200, 42)
        Me.btnProgress.TabIndex = 10
        Me.btnProgress.Text = "Progress Status"
        Me.btnProgress.TextOffsetX = 10
        '
        'btnExplorer
        '
        Me.btnExplorer.Animated = True
        Me.btnExplorer.AnimationHoverSpeed = 0.07!
        Me.btnExplorer.AnimationSpeed = 0.03!
        Me.btnExplorer.BaseColor = System.Drawing.Color.Transparent
        Me.btnExplorer.BorderColor = System.Drawing.Color.Black
        Me.btnExplorer.ButtonType = Guna.UI.WinForms.AdvenceButtonType.RadioButton
        Me.btnExplorer.Checked = True
        Me.btnExplorer.CheckedBaseColor = System.Drawing.Color.Transparent
        Me.btnExplorer.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnExplorer.CheckedForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExplorer.CheckedImage = Global.FileCompressorApp.My.Resources.Resources.search_property_48px_violet2
        Me.btnExplorer.CheckedLineColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExplorer.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnExplorer.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnExplorer.FocusedColor = System.Drawing.Color.Empty
        Me.btnExplorer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnExplorer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnExplorer.Image = Global.FileCompressorApp.My.Resources.Resources.search_property_48px_silver1
        Me.btnExplorer.ImageOffsetX = 20
        Me.btnExplorer.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnExplorer.LineColor = System.Drawing.Color.Transparent
        Me.btnExplorer.LineLeft = 2
        Me.btnExplorer.Location = New System.Drawing.Point(0, 125)
        Me.btnExplorer.Name = "btnExplorer"
        Me.btnExplorer.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.btnExplorer.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnExplorer.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExplorer.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.search_property_48px_violet
        Me.btnExplorer.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnExplorer.OnPressedColor = System.Drawing.Color.Black
        Me.btnExplorer.Size = New System.Drawing.Size(200, 42)
        Me.btnExplorer.TabIndex = 8
        Me.btnExplorer.Text = "File Explorer"
        Me.btnExplorer.TextOffsetX = 10
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 125)
        Me.Panel3.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(102, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Bonker"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(76, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 17)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "File"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.FileCompressorApp.My.Resources.Resources.search_property_48px_violet1
        Me.PictureBox1.Location = New System.Drawing.Point(39, 47)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'pnlNavigation
        '
        Me.pnlNavigation.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlNavigation.Controls.Add(Me.btnMinimize)
        Me.pnlNavigation.Controls.Add(Me.btnClose)
        Me.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNavigation.Location = New System.Drawing.Point(200, 0)
        Me.pnlNavigation.Name = "pnlNavigation"
        Me.pnlNavigation.Size = New System.Drawing.Size(967, 45)
        Me.pnlNavigation.TabIndex = 2
        '
        'btnMinimize
        '
        Me.btnMinimize.Animated = True
        Me.btnMinimize.AnimationHoverSpeed = 0.2!
        Me.btnMinimize.AnimationSpeed = 0.3!
        Me.btnMinimize.BaseColor = System.Drawing.Color.Transparent
        Me.btnMinimize.BorderColor = System.Drawing.Color.Black
        Me.btnMinimize.CheckedBaseColor = System.Drawing.Color.Gray
        Me.btnMinimize.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnMinimize.CheckedForeColor = System.Drawing.Color.White
        Me.btnMinimize.CheckedImage = CType(resources.GetObject("btnMinimize.CheckedImage"), System.Drawing.Image)
        Me.btnMinimize.CheckedLineColor = System.Drawing.Color.DimGray
        Me.btnMinimize.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMinimize.FocusedColor = System.Drawing.Color.Empty
        Me.btnMinimize.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMinimize.ForeColor = System.Drawing.Color.White
        Me.btnMinimize.Image = Global.FileCompressorApp.My.Resources.Resources.min_48px
        Me.btnMinimize.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btnMinimize.ImageSize = New System.Drawing.Size(15, 15)
        Me.btnMinimize.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnMinimize.Location = New System.Drawing.Point(877, 0)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.btnMinimize.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnMinimize.OnHoverForeColor = System.Drawing.Color.White
        Me.btnMinimize.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.minus_48px_black
        Me.btnMinimize.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnMinimize.OnPressedColor = System.Drawing.Color.Black
        Me.btnMinimize.Size = New System.Drawing.Size(45, 45)
        Me.btnMinimize.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Animated = True
        Me.btnClose.AnimationHoverSpeed = 0.2!
        Me.btnClose.AnimationSpeed = 0.3!
        Me.btnClose.BaseColor = System.Drawing.Color.Transparent
        Me.btnClose.BorderColor = System.Drawing.Color.Black
        Me.btnClose.CheckedBaseColor = System.Drawing.Color.Gray
        Me.btnClose.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnClose.CheckedForeColor = System.Drawing.Color.White
        Me.btnClose.CheckedImage = CType(resources.GetObject("btnClose.CheckedImage"), System.Drawing.Image)
        Me.btnClose.CheckedLineColor = System.Drawing.Color.DimGray
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FocusedColor = System.Drawing.Color.Empty
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Image = Global.FileCompressorApp.My.Resources.Resources.Close_48px
        Me.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btnClose.ImageSize = New System.Drawing.Size(15, 15)
        Me.btnClose.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnClose.Location = New System.Drawing.Point(922, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnClose.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnClose.OnHoverForeColor = System.Drawing.Color.White
        Me.btnClose.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.Close_48px_white
        Me.btnClose.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnClose.OnPressedColor = System.Drawing.Color.Black
        Me.btnClose.Size = New System.Drawing.Size(45, 45)
        Me.btnClose.TabIndex = 1
        '
        'GunaElipse1
        '
        Me.GunaElipse1.TargetControl = Me
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbMain)
        Me.TabControl1.Controls.Add(Me.tbProcess)
        Me.TabControl1.Controls.Add(Me.tbAbout)
        Me.TabControl1.Controls.Add(Me.tbSettings)
        Me.TabControl1.Controls.Add(Me.tbReport)
        Me.TabControl1.Location = New System.Drawing.Point(195, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(978, 613)
        Me.TabControl1.TabIndex = 3
        '
        'tbMain
        '
        Me.tbMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.tbMain.Controls.Add(Me.lblCmpMode)
        Me.tbMain.Controls.Add(Me.btnPageEnd)
        Me.tbMain.Controls.Add(Me.btnPagePrev)
        Me.tbMain.Controls.Add(Me.btnPageNext)
        Me.tbMain.Controls.Add(Me.btnPageStart)
        Me.tbMain.Controls.Add(Me.GunaPanel2)
        Me.tbMain.Controls.Add(Me.btnBack)
        Me.tbMain.Controls.Add(Me.txtPath)
        Me.tbMain.Controls.Add(Me.vsbFileDirectory)
        Me.tbMain.Controls.Add(Me.pnlHeader)
        Me.tbMain.Controls.Add(Me.flpFileDirectory)
        Me.tbMain.Location = New System.Drawing.Point(4, 22)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMain.Size = New System.Drawing.Size(970, 587)
        Me.tbMain.TabIndex = 0
        Me.tbMain.Text = "Main"
        '
        'lblCmpMode
        '
        Me.lblCmpMode.AutoEllipsis = True
        Me.lblCmpMode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCmpMode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblCmpMode.Location = New System.Drawing.Point(787, 554)
        Me.lblCmpMode.Name = "lblCmpMode"
        Me.lblCmpMode.Size = New System.Drawing.Size(165, 15)
        Me.lblCmpMode.TabIndex = 15
        Me.lblCmpMode.Text = "Compression Mode: ST"
        Me.lblCmpMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPageEnd
        '
        Me.btnPageEnd.Animated = True
        Me.btnPageEnd.AnimationHoverSpeed = 0.07!
        Me.btnPageEnd.AnimationSpeed = 0.03!
        Me.btnPageEnd.BaseColor = System.Drawing.Color.Transparent
        Me.btnPageEnd.BorderColor = System.Drawing.Color.Black
        Me.btnPageEnd.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnPageEnd.FocusedColor = System.Drawing.Color.Empty
        Me.btnPageEnd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPageEnd.ForeColor = System.Drawing.Color.White
        Me.btnPageEnd.Image = Global.FileCompressorApp.My.Resources.Resources.end_48px
        Me.btnPageEnd.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnPageEnd.Location = New System.Drawing.Point(75, 554)
        Me.btnPageEnd.Name = "btnPageEnd"
        Me.btnPageEnd.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.btnPageEnd.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnPageEnd.OnHoverForeColor = System.Drawing.Color.White
        Me.btnPageEnd.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.end_purple_48px
        Me.btnPageEnd.OnPressedColor = System.Drawing.Color.Black
        Me.btnPageEnd.Size = New System.Drawing.Size(20, 20)
        Me.btnPageEnd.TabIndex = 14
        '
        'btnPagePrev
        '
        Me.btnPagePrev.Animated = True
        Me.btnPagePrev.AnimationHoverSpeed = 0.07!
        Me.btnPagePrev.AnimationSpeed = 0.03!
        Me.btnPagePrev.BaseColor = System.Drawing.Color.Transparent
        Me.btnPagePrev.BorderColor = System.Drawing.Color.Black
        Me.btnPagePrev.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnPagePrev.Enabled = False
        Me.btnPagePrev.FocusedColor = System.Drawing.Color.Empty
        Me.btnPagePrev.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPagePrev.ForeColor = System.Drawing.Color.White
        Me.btnPagePrev.Image = Global.FileCompressorApp.My.Resources.Resources.prev_48px
        Me.btnPagePrev.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnPagePrev.Location = New System.Drawing.Point(31, 554)
        Me.btnPagePrev.Name = "btnPagePrev"
        Me.btnPagePrev.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.btnPagePrev.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnPagePrev.OnHoverForeColor = System.Drawing.Color.White
        Me.btnPagePrev.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.prev_purple_48px
        Me.btnPagePrev.OnPressedColor = System.Drawing.Color.Black
        Me.btnPagePrev.Size = New System.Drawing.Size(20, 20)
        Me.btnPagePrev.TabIndex = 13
        '
        'btnPageNext
        '
        Me.btnPageNext.Animated = True
        Me.btnPageNext.AnimationHoverSpeed = 0.07!
        Me.btnPageNext.AnimationSpeed = 0.03!
        Me.btnPageNext.BaseColor = System.Drawing.Color.Transparent
        Me.btnPageNext.BorderColor = System.Drawing.Color.Black
        Me.btnPageNext.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnPageNext.FocusedColor = System.Drawing.Color.Empty
        Me.btnPageNext.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPageNext.ForeColor = System.Drawing.Color.White
        Me.btnPageNext.Image = Global.FileCompressorApp.My.Resources.Resources.next_48px
        Me.btnPageNext.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnPageNext.Location = New System.Drawing.Point(53, 554)
        Me.btnPageNext.Name = "btnPageNext"
        Me.btnPageNext.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.btnPageNext.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnPageNext.OnHoverForeColor = System.Drawing.Color.White
        Me.btnPageNext.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.next_purple_48px
        Me.btnPageNext.OnPressedColor = System.Drawing.Color.Black
        Me.btnPageNext.Size = New System.Drawing.Size(20, 20)
        Me.btnPageNext.TabIndex = 12
        '
        'btnPageStart
        '
        Me.btnPageStart.Animated = True
        Me.btnPageStart.AnimationHoverSpeed = 0.07!
        Me.btnPageStart.AnimationSpeed = 0.03!
        Me.btnPageStart.BaseColor = System.Drawing.Color.Transparent
        Me.btnPageStart.BorderColor = System.Drawing.Color.Black
        Me.btnPageStart.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnPageStart.Enabled = False
        Me.btnPageStart.FocusedColor = System.Drawing.Color.Empty
        Me.btnPageStart.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPageStart.ForeColor = System.Drawing.Color.White
        Me.btnPageStart.Image = Global.FileCompressorApp.My.Resources.Resources.start_48px
        Me.btnPageStart.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnPageStart.Location = New System.Drawing.Point(9, 554)
        Me.btnPageStart.Name = "btnPageStart"
        Me.btnPageStart.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.btnPageStart.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnPageStart.OnHoverForeColor = System.Drawing.Color.White
        Me.btnPageStart.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.start_purple_48px
        Me.btnPageStart.OnPressedColor = System.Drawing.Color.Black
        Me.btnPageStart.Size = New System.Drawing.Size(20, 20)
        Me.btnPageStart.TabIndex = 11
        '
        'GunaPanel2
        '
        Me.GunaPanel2.Controls.Add(Me.btnUnbonk)
        Me.GunaPanel2.Controls.Add(Me.btnBonk)
        Me.GunaPanel2.Controls.Add(Me.cbDrives)
        Me.GunaPanel2.Controls.Add(Me.Label9)
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 12)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(967, 45)
        Me.GunaPanel2.TabIndex = 10
        '
        'btnUnbonk
        '
        Me.btnUnbonk.Animated = True
        Me.btnUnbonk.AnimationHoverSpeed = 0.07!
        Me.btnUnbonk.AnimationSpeed = 0.03!
        Me.btnUnbonk.BaseColor = System.Drawing.Color.Transparent
        Me.btnUnbonk.BorderColor = System.Drawing.Color.Silver
        Me.btnUnbonk.CheckedBaseColor = System.Drawing.Color.Gray
        Me.btnUnbonk.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnUnbonk.CheckedForeColor = System.Drawing.Color.White
        Me.btnUnbonk.CheckedImage = CType(resources.GetObject("btnUnbonk.CheckedImage"), System.Drawing.Image)
        Me.btnUnbonk.CheckedLineColor = System.Drawing.Color.Silver
        Me.btnUnbonk.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnUnbonk.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnUnbonk.FocusedColor = System.Drawing.Color.Empty
        Me.btnUnbonk.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnUnbonk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnUnbonk.Image = Global.FileCompressorApp.My.Resources.Resources.Decode_48px
        Me.btnUnbonk.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnUnbonk.LineColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnUnbonk.LineRight = 1
        Me.btnUnbonk.Location = New System.Drawing.Point(180, 0)
        Me.btnUnbonk.Name = "btnUnbonk"
        Me.btnUnbonk.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUnbonk.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnUnbonk.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnUnbonk.OnHoverImage = Nothing
        Me.btnUnbonk.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUnbonk.OnPressedColor = System.Drawing.Color.Black
        Me.btnUnbonk.Size = New System.Drawing.Size(180, 45)
        Me.btnUnbonk.TabIndex = 10
        Me.btnUnbonk.Text = "Unbonk file/s to"
        '
        'btnBonk
        '
        Me.btnBonk.Animated = True
        Me.btnBonk.AnimationHoverSpeed = 0.07!
        Me.btnBonk.AnimationSpeed = 0.03!
        Me.btnBonk.BaseColor = System.Drawing.Color.Transparent
        Me.btnBonk.BorderColor = System.Drawing.Color.Silver
        Me.btnBonk.CheckedBaseColor = System.Drawing.Color.Gray
        Me.btnBonk.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnBonk.CheckedForeColor = System.Drawing.Color.White
        Me.btnBonk.CheckedImage = CType(resources.GetObject("btnBonk.CheckedImage"), System.Drawing.Image)
        Me.btnBonk.CheckedLineColor = System.Drawing.Color.DimGray
        Me.btnBonk.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnBonk.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBonk.FocusedColor = System.Drawing.Color.Empty
        Me.btnBonk.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBonk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnBonk.Image = Global.FileCompressorApp.My.Resources.Resources.compress_48px
        Me.btnBonk.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBonk.LineColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnBonk.LineLeft = 1
        Me.btnBonk.LineRight = 1
        Me.btnBonk.Location = New System.Drawing.Point(0, 0)
        Me.btnBonk.Name = "btnBonk"
        Me.btnBonk.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBonk.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnBonk.OnHoverForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnBonk.OnHoverImage = Nothing
        Me.btnBonk.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBonk.OnPressedColor = System.Drawing.Color.Black
        Me.btnBonk.Size = New System.Drawing.Size(180, 45)
        Me.btnBonk.TabIndex = 6
        Me.btnBonk.Text = "Bonk File/s to"
        '
        'cbDrives
        '
        Me.cbDrives.BackColor = System.Drawing.Color.Transparent
        Me.cbDrives.BaseColor = System.Drawing.Color.White
        Me.cbDrives.BorderColor = System.Drawing.Color.Silver
        Me.cbDrives.BorderSize = 1
        Me.cbDrives.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDrives.FocusedColor = System.Drawing.Color.Empty
        Me.cbDrives.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cbDrives.ForeColor = System.Drawing.Color.Black
        Me.cbDrives.FormattingEnabled = True
        Me.cbDrives.Location = New System.Drawing.Point(863, 16)
        Me.cbDrives.Name = "cbDrives"
        Me.cbDrives.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbDrives.OnHoverItemForeColor = System.Drawing.Color.White
        Me.cbDrives.Radius = 5
        Me.cbDrives.Size = New System.Drawing.Size(89, 26)
        Me.cbDrives.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Silver
        Me.Label9.Location = New System.Drawing.Point(812, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Drive\s:"
        '
        'btnBack
        '
        Me.btnBack.Animated = True
        Me.btnBack.AnimationHoverSpeed = 0.07!
        Me.btnBack.AnimationSpeed = 0.03!
        Me.btnBack.BaseColor = System.Drawing.Color.Transparent
        Me.btnBack.BorderColor = System.Drawing.Color.Black
        Me.btnBack.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnBack.FocusedColor = System.Drawing.Color.Empty
        Me.btnBack.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBack.ForeColor = System.Drawing.Color.White
        Me.btnBack.Image = Global.FileCompressorApp.My.Resources.Resources.collapse_arrow_24_greypx1
        Me.btnBack.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBack.Location = New System.Drawing.Point(9, 65)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBack.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnBack.OnHoverForeColor = System.Drawing.Color.White
        Me.btnBack.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.collapse_arrow_24px
        Me.btnBack.OnPressedColor = System.Drawing.Color.Black
        Me.btnBack.Size = New System.Drawing.Size(26, 26)
        Me.btnBack.TabIndex = 5
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.Transparent
        Me.txtPath.BaseColor = System.Drawing.Color.White
        Me.txtPath.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.txtPath.BorderSize = 1
        Me.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPath.FocusedBaseColor = System.Drawing.Color.White
        Me.txtPath.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPath.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPath.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPath.Location = New System.Drawing.Point(41, 65)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPath.Radius = 10
        Me.txtPath.Size = New System.Drawing.Size(911, 26)
        Me.txtPath.TabIndex = 4
        Me.txtPath.Text = "C:\Users\Lanz Pancho\Documents"
        Me.txtPath.TextOffsetX = 5
        '
        'vsbFileDirectory
        '
        Me.vsbFileDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vsbFileDirectory.LargeChange = 10
        Me.vsbFileDirectory.Location = New System.Drawing.Point(957, 124)
        Me.vsbFileDirectory.Maximum = 100
        Me.vsbFileDirectory.Name = "vsbFileDirectory"
        Me.vsbFileDirectory.ScrollIdleColor = System.Drawing.Color.Transparent
        Me.vsbFileDirectory.Size = New System.Drawing.Size(10, 418)
        Me.vsbFileDirectory.TabIndex = 3
        Me.vsbFileDirectory.ThumbColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.vsbFileDirectory.ThumbHoverColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.vsbFileDirectory.ThumbPressedColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.Transparent
        Me.pnlHeader.BaseColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlDate)
        Me.pnlHeader.Controls.Add(Me.Splitter3)
        Me.pnlHeader.Controls.Add(Me.pnlType)
        Me.pnlHeader.Controls.Add(Me.Splitter2)
        Me.pnlHeader.Controls.Add(Me.pnlSize)
        Me.pnlHeader.Controls.Add(Me.Splitter1)
        Me.pnlHeader.Controls.Add(Me.pnlName)
        Me.pnlHeader.Controls.Add(Me.Panel2)
        Me.pnlHeader.Location = New System.Drawing.Point(9, 97)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Radius = 4
        Me.pnlHeader.Size = New System.Drawing.Size(923, 28)
        Me.pnlHeader.TabIndex = 1
        '
        'pnlDate
        '
        Me.pnlDate.Controls.Add(Me.btnSortDate)
        Me.pnlDate.Controls.Add(Me.Label4)
        Me.pnlDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDate.Location = New System.Drawing.Point(814, 0)
        Me.pnlDate.Name = "pnlDate"
        Me.pnlDate.Size = New System.Drawing.Size(109, 28)
        Me.pnlDate.TabIndex = 6
        '
        'btnSortDate
        '
        Me.btnSortDate.Animated = True
        Me.btnSortDate.AnimationHoverSpeed = 0.07!
        Me.btnSortDate.AnimationSpeed = 0.03!
        Me.btnSortDate.BackColor = System.Drawing.Color.Transparent
        Me.btnSortDate.BaseColor = System.Drawing.Color.Transparent
        Me.btnSortDate.BorderColor = System.Drawing.Color.Black
        Me.btnSortDate.ButtonType = Guna.UI.WinForms.AdvenceButtonType.ToogleButton
        Me.btnSortDate.CheckedBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSortDate.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnSortDate.CheckedForeColor = System.Drawing.Color.White
        Me.btnSortDate.CheckedImage = CType(resources.GetObject("btnSortDate.CheckedImage"), System.Drawing.Image)
        Me.btnSortDate.CheckedLineColor = System.Drawing.Color.DimGray
        Me.btnSortDate.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSortDate.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSortDate.FocusedColor = System.Drawing.Color.Empty
        Me.btnSortDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSortDate.ForeColor = System.Drawing.Color.White
        Me.btnSortDate.Image = CType(resources.GetObject("btnSortDate.Image"), System.Drawing.Image)
        Me.btnSortDate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btnSortDate.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnSortDate.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSortDate.Location = New System.Drawing.Point(89, 0)
        Me.btnSortDate.Name = "btnSortDate"
        Me.btnSortDate.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSortDate.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnSortDate.OnHoverForeColor = System.Drawing.Color.White
        Me.btnSortDate.OnHoverImage = CType(resources.GetObject("btnSortDate.OnHoverImage"), System.Drawing.Image)
        Me.btnSortDate.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSortDate.OnPressedColor = System.Drawing.Color.Black
        Me.btnSortDate.Radius = 2
        Me.btnSortDate.Size = New System.Drawing.Size(20, 28)
        Me.btnSortDate.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(10, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Date Modified"
        '
        'Splitter3
        '
        Me.Splitter3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Splitter3.Location = New System.Drawing.Point(813, 0)
        Me.Splitter3.MinExtra = 100
        Me.Splitter3.MinSize = 50
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(1, 28)
        Me.Splitter3.TabIndex = 5
        Me.Splitter3.TabStop = False
        '
        'pnlType
        '
        Me.pnlType.Controls.Add(Me.btnSortType)
        Me.pnlType.Controls.Add(Me.Label3)
        Me.pnlType.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlType.Location = New System.Drawing.Point(701, 0)
        Me.pnlType.Name = "pnlType"
        Me.pnlType.Size = New System.Drawing.Size(112, 28)
        Me.pnlType.TabIndex = 4
        '
        'btnSortType
        '
        Me.btnSortType.Animated = True
        Me.btnSortType.AnimationHoverSpeed = 0.07!
        Me.btnSortType.AnimationSpeed = 0.03!
        Me.btnSortType.BackColor = System.Drawing.Color.Transparent
        Me.btnSortType.BaseColor = System.Drawing.Color.Transparent
        Me.btnSortType.BorderColor = System.Drawing.Color.Black
        Me.btnSortType.ButtonType = Guna.UI.WinForms.AdvenceButtonType.ToogleButton
        Me.btnSortType.CheckedBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSortType.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnSortType.CheckedForeColor = System.Drawing.Color.White
        Me.btnSortType.CheckedImage = CType(resources.GetObject("btnSortType.CheckedImage"), System.Drawing.Image)
        Me.btnSortType.CheckedLineColor = System.Drawing.Color.DimGray
        Me.btnSortType.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSortType.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSortType.FocusedColor = System.Drawing.Color.Empty
        Me.btnSortType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSortType.ForeColor = System.Drawing.Color.White
        Me.btnSortType.Image = CType(resources.GetObject("btnSortType.Image"), System.Drawing.Image)
        Me.btnSortType.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btnSortType.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnSortType.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSortType.Location = New System.Drawing.Point(92, 0)
        Me.btnSortType.Name = "btnSortType"
        Me.btnSortType.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSortType.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnSortType.OnHoverForeColor = System.Drawing.Color.White
        Me.btnSortType.OnHoverImage = CType(resources.GetObject("btnSortType.OnHoverImage"), System.Drawing.Image)
        Me.btnSortType.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSortType.OnPressedColor = System.Drawing.Color.Black
        Me.btnSortType.Radius = 2
        Me.btnSortType.Size = New System.Drawing.Size(20, 28)
        Me.btnSortType.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(10, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "File type"
        '
        'Splitter2
        '
        Me.Splitter2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Splitter2.Location = New System.Drawing.Point(700, 0)
        Me.Splitter2.MinExtra = 100
        Me.Splitter2.MinSize = 50
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(1, 28)
        Me.Splitter2.TabIndex = 3
        Me.Splitter2.TabStop = False
        '
        'pnlSize
        '
        Me.pnlSize.Controls.Add(Me.btnSortSize)
        Me.pnlSize.Controls.Add(Me.Label2)
        Me.pnlSize.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSize.Location = New System.Drawing.Point(598, 0)
        Me.pnlSize.Name = "pnlSize"
        Me.pnlSize.Size = New System.Drawing.Size(102, 28)
        Me.pnlSize.TabIndex = 2
        '
        'btnSortSize
        '
        Me.btnSortSize.Animated = True
        Me.btnSortSize.AnimationHoverSpeed = 0.07!
        Me.btnSortSize.AnimationSpeed = 0.03!
        Me.btnSortSize.BackColor = System.Drawing.Color.Transparent
        Me.btnSortSize.BaseColor = System.Drawing.Color.Transparent
        Me.btnSortSize.BorderColor = System.Drawing.Color.Black
        Me.btnSortSize.ButtonType = Guna.UI.WinForms.AdvenceButtonType.ToogleButton
        Me.btnSortSize.CheckedBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSortSize.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnSortSize.CheckedForeColor = System.Drawing.Color.White
        Me.btnSortSize.CheckedImage = Global.FileCompressorApp.My.Resources.Resources.collapse_arrow_24px_white
        Me.btnSortSize.CheckedLineColor = System.Drawing.Color.DimGray
        Me.btnSortSize.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSortSize.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSortSize.FocusedColor = System.Drawing.Color.Empty
        Me.btnSortSize.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSortSize.ForeColor = System.Drawing.Color.White
        Me.btnSortSize.Image = Global.FileCompressorApp.My.Resources.Resources.expand_arrow_24px_grey
        Me.btnSortSize.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btnSortSize.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnSortSize.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSortSize.Location = New System.Drawing.Point(82, 0)
        Me.btnSortSize.Name = "btnSortSize"
        Me.btnSortSize.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSortSize.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnSortSize.OnHoverForeColor = System.Drawing.Color.White
        Me.btnSortSize.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.collapse_arrow_24px_white
        Me.btnSortSize.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSortSize.OnPressedColor = System.Drawing.Color.Black
        Me.btnSortSize.Radius = 2
        Me.btnSortSize.Size = New System.Drawing.Size(20, 28)
        Me.btnSortSize.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(10, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Size"
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Splitter1.Location = New System.Drawing.Point(597, 0)
        Me.Splitter1.MinExtra = 100
        Me.Splitter1.MinSize = 50
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1, 28)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'pnlName
        '
        Me.pnlName.Controls.Add(Me.btnSortName)
        Me.pnlName.Controls.Add(Me.Label1)
        Me.pnlName.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlName.Location = New System.Drawing.Point(28, 0)
        Me.pnlName.Name = "pnlName"
        Me.pnlName.Size = New System.Drawing.Size(569, 28)
        Me.pnlName.TabIndex = 0
        '
        'btnSortName
        '
        Me.btnSortName.Animated = True
        Me.btnSortName.AnimationHoverSpeed = 0.07!
        Me.btnSortName.AnimationSpeed = 0.03!
        Me.btnSortName.BackColor = System.Drawing.Color.Transparent
        Me.btnSortName.BaseColor = System.Drawing.Color.Transparent
        Me.btnSortName.BorderColor = System.Drawing.Color.Black
        Me.btnSortName.ButtonType = Guna.UI.WinForms.AdvenceButtonType.ToogleButton
        Me.btnSortName.CheckedBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSortName.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnSortName.CheckedForeColor = System.Drawing.Color.White
        Me.btnSortName.CheckedImage = Global.FileCompressorApp.My.Resources.Resources.collapse_arrow_24px_white
        Me.btnSortName.CheckedLineColor = System.Drawing.Color.DimGray
        Me.btnSortName.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSortName.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSortName.FocusedColor = System.Drawing.Color.Empty
        Me.btnSortName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSortName.ForeColor = System.Drawing.Color.Silver
        Me.btnSortName.Image = Global.FileCompressorApp.My.Resources.Resources.expand_arrow_24px_grey
        Me.btnSortName.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btnSortName.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnSortName.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSortName.Location = New System.Drawing.Point(549, 0)
        Me.btnSortName.Name = "btnSortName"
        Me.btnSortName.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSortName.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnSortName.OnHoverForeColor = System.Drawing.Color.White
        Me.btnSortName.OnHoverImage = Global.FileCompressorApp.My.Resources.Resources.collapse_arrow_24px_white
        Me.btnSortName.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSortName.OnPressedColor = System.Drawing.Color.Black
        Me.btnSortName.Radius = 2
        Me.btnSortName.Size = New System.Drawing.Size(20, 28)
        Me.btnSortName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(10, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(28, 28)
        Me.Panel2.TabIndex = 7
        '
        'flpFileDirectory
        '
        Me.flpFileDirectory.AutoScroll = True
        Me.flpFileDirectory.ContextMenuStrip = Me.ContextMenuStrip1
        Me.flpFileDirectory.Location = New System.Drawing.Point(9, 124)
        Me.flpFileDirectory.Name = "flpFileDirectory"
        Me.flpFileDirectory.Size = New System.Drawing.Size(943, 418)
        Me.flpFileDirectory.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesktopToolStripMenuItem, Me.DocumentToolStripMenuItem, Me.DownloadsToolStripMenuItem, Me.MusicToolStripMenuItem, Me.PicturesToolStripMenuItem, Me.VideosToolStripMenuItem, Me.ToolStripMenuItem1, Me.NewFolderToolStripMenuItem, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(135, 170)
        '
        'DesktopToolStripMenuItem
        '
        Me.DesktopToolStripMenuItem.Name = "DesktopToolStripMenuItem"
        Me.DesktopToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.DesktopToolStripMenuItem.Text = "Desktop"
        '
        'DocumentToolStripMenuItem
        '
        Me.DocumentToolStripMenuItem.Name = "DocumentToolStripMenuItem"
        Me.DocumentToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.DocumentToolStripMenuItem.Text = "Document"
        '
        'DownloadsToolStripMenuItem
        '
        Me.DownloadsToolStripMenuItem.Name = "DownloadsToolStripMenuItem"
        Me.DownloadsToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.DownloadsToolStripMenuItem.Text = "Downloads"
        '
        'MusicToolStripMenuItem
        '
        Me.MusicToolStripMenuItem.Name = "MusicToolStripMenuItem"
        Me.MusicToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.MusicToolStripMenuItem.Text = "Music"
        '
        'PicturesToolStripMenuItem
        '
        Me.PicturesToolStripMenuItem.Name = "PicturesToolStripMenuItem"
        Me.PicturesToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.PicturesToolStripMenuItem.Text = "Pictures"
        '
        'VideosToolStripMenuItem
        '
        Me.VideosToolStripMenuItem.Name = "VideosToolStripMenuItem"
        Me.VideosToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.VideosToolStripMenuItem.Text = "Videos"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(131, 6)
        '
        'NewFolderToolStripMenuItem
        '
        Me.NewFolderToolStripMenuItem.Name = "NewFolderToolStripMenuItem"
        Me.NewFolderToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.NewFolderToolStripMenuItem.Text = "New Folder"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(131, 6)
        '
        'tbProcess
        '
        Me.tbProcess.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.tbProcess.Controls.Add(Me.pnlProcessDetail)
        Me.tbProcess.Controls.Add(Me.pnlStatus)
        Me.tbProcess.Location = New System.Drawing.Point(4, 22)
        Me.tbProcess.Name = "tbProcess"
        Me.tbProcess.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProcess.Size = New System.Drawing.Size(970, 587)
        Me.tbProcess.TabIndex = 1
        Me.tbProcess.Text = "TabPage2"
        '
        'pnlProcessDetail
        '
        Me.pnlProcessDetail.BackColor = System.Drawing.Color.Transparent
        Me.pnlProcessDetail.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlProcessDetail.Controls.Add(Me.lblReadAvgSpeed)
        Me.pnlProcessDetail.Controls.Add(Me.lblReadSpeed)
        Me.pnlProcessDetail.Controls.Add(Me.lblProcessedStatus)
        Me.pnlProcessDetail.Controls.Add(Me.lblProcessPercent)
        Me.pnlProcessDetail.Controls.Add(Me.lblWriteAvgSpeed)
        Me.pnlProcessDetail.Controls.Add(Me.lblWriteSpeed)
        Me.pnlProcessDetail.Controls.Add(Me.lblFileStatus)
        Me.pnlProcessDetail.Controls.Add(Me.pbProcessed)
        Me.pnlProcessDetail.Location = New System.Drawing.Point(7, 196)
        Me.pnlProcessDetail.Name = "pnlProcessDetail"
        Me.pnlProcessDetail.Radius = 3
        Me.pnlProcessDetail.ShadowColor = System.Drawing.Color.Black
        Me.pnlProcessDetail.ShadowDepth = 30
        Me.pnlProcessDetail.Size = New System.Drawing.Size(957, 145)
        Me.pnlProcessDetail.TabIndex = 1
        Me.pnlProcessDetail.Visible = False
        '
        'lblReadAvgSpeed
        '
        Me.lblReadAvgSpeed.AutoSize = True
        Me.lblReadAvgSpeed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReadAvgSpeed.ForeColor = System.Drawing.Color.White
        Me.lblReadAvgSpeed.Location = New System.Drawing.Point(269, 86)
        Me.lblReadAvgSpeed.Name = "lblReadAvgSpeed"
        Me.lblReadAvgSpeed.Size = New System.Drawing.Size(121, 15)
        Me.lblReadAvgSpeed.TabIndex = 11
        Me.lblReadAvgSpeed.Text = "Avg Read Speed: 0b/s"
        '
        'lblReadSpeed
        '
        Me.lblReadSpeed.AutoSize = True
        Me.lblReadSpeed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReadSpeed.ForeColor = System.Drawing.Color.White
        Me.lblReadSpeed.Location = New System.Drawing.Point(28, 86)
        Me.lblReadSpeed.Name = "lblReadSpeed"
        Me.lblReadSpeed.Size = New System.Drawing.Size(97, 15)
        Me.lblReadSpeed.TabIndex = 10
        Me.lblReadSpeed.Text = "Read Speed: 0b/s"
        '
        'lblProcessedStatus
        '
        Me.lblProcessedStatus.AutoSize = True
        Me.lblProcessedStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessedStatus.ForeColor = System.Drawing.Color.White
        Me.lblProcessedStatus.Location = New System.Drawing.Point(28, 24)
        Me.lblProcessedStatus.Name = "lblProcessedStatus"
        Me.lblProcessedStatus.Size = New System.Drawing.Size(69, 17)
        Me.lblProcessedStatus.TabIndex = 9
        Me.lblProcessedStatus.Text = "Processed"
        '
        'lblProcessPercent
        '
        Me.lblProcessPercent.Font = New System.Drawing.Font("Segoe UI Black", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessPercent.ForeColor = System.Drawing.Color.White
        Me.lblProcessPercent.Location = New System.Drawing.Point(807, 24)
        Me.lblProcessPercent.Name = "lblProcessPercent"
        Me.lblProcessPercent.Size = New System.Drawing.Size(121, 38)
        Me.lblProcessPercent.TabIndex = 5
        Me.lblProcessPercent.Text = "10%"
        Me.lblProcessPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWriteAvgSpeed
        '
        Me.lblWriteAvgSpeed.AutoSize = True
        Me.lblWriteAvgSpeed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWriteAvgSpeed.ForeColor = System.Drawing.Color.White
        Me.lblWriteAvgSpeed.Location = New System.Drawing.Point(269, 109)
        Me.lblWriteAvgSpeed.Name = "lblWriteAvgSpeed"
        Me.lblWriteAvgSpeed.Size = New System.Drawing.Size(123, 15)
        Me.lblWriteAvgSpeed.TabIndex = 8
        Me.lblWriteAvgSpeed.Text = "Avg Write Speed: 0b/s"
        '
        'lblWriteSpeed
        '
        Me.lblWriteSpeed.AutoSize = True
        Me.lblWriteSpeed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWriteSpeed.ForeColor = System.Drawing.Color.White
        Me.lblWriteSpeed.Location = New System.Drawing.Point(28, 109)
        Me.lblWriteSpeed.Name = "lblWriteSpeed"
        Me.lblWriteSpeed.Size = New System.Drawing.Size(99, 15)
        Me.lblWriteSpeed.TabIndex = 6
        Me.lblWriteSpeed.Text = "Write Speed: 0b/s"
        '
        'lblFileStatus
        '
        Me.lblFileStatus.AutoEllipsis = True
        Me.lblFileStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileStatus.ForeColor = System.Drawing.Color.White
        Me.lblFileStatus.Location = New System.Drawing.Point(28, 43)
        Me.lblFileStatus.Name = "lblFileStatus"
        Me.lblFileStatus.Size = New System.Drawing.Size(735, 15)
        Me.lblFileStatus.TabIndex = 3
        Me.lblFileStatus.Text = "C:\Users\Lanz Pancho\Documents\pncapp\Download files...."
        '
        'pbProcessed
        '
        Me.pbProcessed.BackColor = System.Drawing.Color.Transparent
        Me.pbProcessed.BorderColor = System.Drawing.Color.Black
        Me.pbProcessed.ColorStyle = Guna.UI.WinForms.ColorStyle.[Default]
        Me.pbProcessed.IdleColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.pbProcessed.Location = New System.Drawing.Point(31, 63)
        Me.pbProcessed.Maximum = 10000
        Me.pbProcessed.Name = "pbProcessed"
        Me.pbProcessed.ProgressMaxColor = System.Drawing.Color.White
        Me.pbProcessed.ProgressMinColor = System.Drawing.Color.White
        Me.pbProcessed.Size = New System.Drawing.Size(897, 10)
        Me.pbProcessed.TabIndex = 0
        Me.pbProcessed.Value = 50
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.Transparent
        Me.pnlStatus.BaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlStatus.Controls.Add(Me.lblThreadType)
        Me.pnlStatus.Controls.Add(Me.pnlDetails)
        Me.pnlStatus.Controls.Add(Me.lblElapsedTime)
        Me.pnlStatus.Controls.Add(Me.Label13)
        Me.pnlStatus.Controls.Add(Me.lblTimeRemaining)
        Me.pnlStatus.Controls.Add(Me.btnCancel)
        Me.pnlStatus.Controls.Add(Me.lblOverallPercent)
        Me.pnlStatus.Controls.Add(Me.lblFolderStatus)
        Me.pnlStatus.Controls.Add(Me.lblStatus)
        Me.pnlStatus.Controls.Add(Me.pnlLoading)
        Me.pnlStatus.Controls.Add(Me.pbDone)
        Me.pnlStatus.Location = New System.Drawing.Point(7, 17)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Radius = 3
        Me.pnlStatus.ShadowColor = System.Drawing.Color.Black
        Me.pnlStatus.ShadowDepth = 30
        Me.pnlStatus.Size = New System.Drawing.Size(957, 173)
        Me.pnlStatus.TabIndex = 0
        '
        'lblThreadType
        '
        Me.lblThreadType.AutoEllipsis = True
        Me.lblThreadType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThreadType.ForeColor = System.Drawing.Color.White
        Me.lblThreadType.Location = New System.Drawing.Point(611, 24)
        Me.lblThreadType.Name = "lblThreadType"
        Me.lblThreadType.Size = New System.Drawing.Size(165, 17)
        Me.lblThreadType.TabIndex = 13
        Me.lblThreadType.Text = "Single Thread Mode"
        Me.lblThreadType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblThreadType.Visible = False
        '
        'pnlDetails
        '
        Me.pnlDetails.Controls.Add(Me.lblTotalFileSize)
        Me.pnlDetails.Controls.Add(Me.Label5)
        Me.pnlDetails.Controls.Add(Me.lblLastAvgRead)
        Me.pnlDetails.Controls.Add(Me.lblLastAvgWrite)
        Me.pnlDetails.Controls.Add(Me.lblLastTimeElapsed)
        Me.pnlDetails.Location = New System.Drawing.Point(23, 74)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(504, 81)
        Me.pnlDetails.TabIndex = 12
        Me.pnlDetails.Visible = False
        '
        'lblTotalFileSize
        '
        Me.lblTotalFileSize.AutoEllipsis = True
        Me.lblTotalFileSize.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFileSize.ForeColor = System.Drawing.Color.White
        Me.lblTotalFileSize.Location = New System.Drawing.Point(5, 33)
        Me.lblTotalFileSize.Name = "lblTotalFileSize"
        Me.lblTotalFileSize.Size = New System.Drawing.Size(246, 15)
        Me.lblTotalFileSize.TabIndex = 8
        Me.lblTotalFileSize.Text = "File/s Overall Size: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(5, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Last Operation Detail"
        '
        'lblLastAvgRead
        '
        Me.lblLastAvgRead.AutoEllipsis = True
        Me.lblLastAvgRead.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastAvgRead.ForeColor = System.Drawing.Color.White
        Me.lblLastAvgRead.Location = New System.Drawing.Point(257, 33)
        Me.lblLastAvgRead.Name = "lblLastAvgRead"
        Me.lblLastAvgRead.Size = New System.Drawing.Size(206, 15)
        Me.lblLastAvgRead.TabIndex = 6
        Me.lblLastAvgRead.Text = "Avg Read Speed: 0b/s"
        '
        'lblLastAvgWrite
        '
        Me.lblLastAvgWrite.AutoEllipsis = True
        Me.lblLastAvgWrite.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastAvgWrite.ForeColor = System.Drawing.Color.White
        Me.lblLastAvgWrite.Location = New System.Drawing.Point(257, 55)
        Me.lblLastAvgWrite.Name = "lblLastAvgWrite"
        Me.lblLastAvgWrite.Size = New System.Drawing.Size(206, 15)
        Me.lblLastAvgWrite.TabIndex = 5
        Me.lblLastAvgWrite.Text = "Avg Write Speed: 0b/s"
        '
        'lblLastTimeElapsed
        '
        Me.lblLastTimeElapsed.AutoEllipsis = True
        Me.lblLastTimeElapsed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastTimeElapsed.ForeColor = System.Drawing.Color.White
        Me.lblLastTimeElapsed.Location = New System.Drawing.Point(5, 55)
        Me.lblLastTimeElapsed.Name = "lblLastTimeElapsed"
        Me.lblLastTimeElapsed.Size = New System.Drawing.Size(124, 15)
        Me.lblLastTimeElapsed.TabIndex = 4
        Me.lblLastTimeElapsed.Text = "Time Elapsed: 00:00:00"
        '
        'lblElapsedTime
        '
        Me.lblElapsedTime.AutoSize = True
        Me.lblElapsedTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElapsedTime.ForeColor = System.Drawing.Color.White
        Me.lblElapsedTime.Location = New System.Drawing.Point(28, 84)
        Me.lblElapsedTime.Name = "lblElapsedTime"
        Me.lblElapsedTime.Size = New System.Drawing.Size(124, 15)
        Me.lblElapsedTime.TabIndex = 10
        Me.lblElapsedTime.Text = "Elapsed Time: 00:00:00"
        Me.lblElapsedTime.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Black", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(548, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(237, 37)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Overall Progress"
        Me.Label13.Visible = False
        '
        'lblTimeRemaining
        '
        Me.lblTimeRemaining.AutoSize = True
        Me.lblTimeRemaining.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeRemaining.ForeColor = System.Drawing.Color.White
        Me.lblTimeRemaining.Location = New System.Drawing.Point(216, 84)
        Me.lblTimeRemaining.Name = "lblTimeRemaining"
        Me.lblTimeRemaining.Size = New System.Drawing.Size(141, 15)
        Me.lblTimeRemaining.TabIndex = 7
        Me.lblTimeRemaining.Text = "Time Remaining: 00:00:00"
        Me.lblTimeRemaining.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Animated = True
        Me.btnCancel.AnimationHoverSpeed = 0.07!
        Me.btnCancel.AnimationSpeed = 0.03!
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.BaseColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnCancel.BorderColor = System.Drawing.Color.Black
        Me.btnCancel.CheckedBaseColor = System.Drawing.Color.Gray
        Me.btnCancel.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnCancel.CheckedForeColor = System.Drawing.Color.White
        Me.btnCancel.CheckedImage = Nothing
        Me.btnCancel.CheckedLineColor = System.Drawing.Color.DimGray
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnCancel.FocusedColor = System.Drawing.Color.Empty
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Nothing
        Me.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.btnCancel.ImageOffsetX = 4
        Me.btnCancel.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnCancel.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnCancel.Location = New System.Drawing.Point(31, 119)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnCancel.OnHoverForeColor = System.Drawing.Color.White
        Me.btnCancel.OnHoverImage = Nothing
        Me.btnCancel.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnCancel.OnPressedColor = System.Drawing.Color.Black
        Me.btnCancel.Radius = 13
        Me.btnCancel.Size = New System.Drawing.Size(180, 30)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextOffsetX = 4
        Me.btnCancel.Visible = False
        '
        'lblOverallPercent
        '
        Me.lblOverallPercent.Font = New System.Drawing.Font("Segoe UI Black", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverallPercent.ForeColor = System.Drawing.Color.White
        Me.lblOverallPercent.Location = New System.Drawing.Point(664, 71)
        Me.lblOverallPercent.Name = "lblOverallPercent"
        Me.lblOverallPercent.Size = New System.Drawing.Size(121, 51)
        Me.lblOverallPercent.TabIndex = 4
        Me.lblOverallPercent.Text = "50%"
        Me.lblOverallPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblOverallPercent.Visible = False
        '
        'lblFolderStatus
        '
        Me.lblFolderStatus.AutoEllipsis = True
        Me.lblFolderStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderStatus.ForeColor = System.Drawing.Color.White
        Me.lblFolderStatus.Location = New System.Drawing.Point(28, 49)
        Me.lblFolderStatus.Name = "lblFolderStatus"
        Me.lblFolderStatus.Size = New System.Drawing.Size(458, 15)
        Me.lblFolderStatus.TabIndex = 2
        Me.lblFolderStatus.Text = "C:\Users\Lanz Pancho\Documents\pncapp\Download files...."
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(28, 24)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(84, 17)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "Reading File"
        '
        'pnlLoading
        '
        Me.pnlLoading.Controls.Add(Me.pbOverall)
        Me.pnlLoading.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlLoading.Location = New System.Drawing.Point(791, 0)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(166, 173)
        Me.pnlLoading.TabIndex = 0
        Me.pnlLoading.Visible = False
        '
        'pbOverall
        '
        Me.pbOverall.Animated = True
        Me.pbOverall.AnimationSpeed = 1.2!
        Me.pbOverall.BaseColor = System.Drawing.Color.Transparent
        Me.pbOverall.IdleColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pbOverall.IdleOffset = 10
        Me.pbOverall.IdleThickness = 13
        Me.pbOverall.Image = Nothing
        Me.pbOverall.ImageSize = New System.Drawing.Size(52, 52)
        Me.pbOverall.LineEndCap = System.Drawing.Drawing2D.LineCap.Round
        Me.pbOverall.LineStartCap = System.Drawing.Drawing2D.LineCap.Round
        Me.pbOverall.Location = New System.Drawing.Point(27, 30)
        Me.pbOverall.Maximum = 10000
        Me.pbOverall.Name = "pbOverall"
        Me.pbOverall.ProgressMaxColor = System.Drawing.Color.White
        Me.pbOverall.ProgressMinColor = System.Drawing.Color.White
        Me.pbOverall.ProgressOffset = 10
        Me.pbOverall.ProgressThickness = 13
        Me.pbOverall.Size = New System.Drawing.Size(110, 110)
        Me.pbOverall.TabIndex = 0
        Me.pbOverall.Value = 4000
        '
        'pbDone
        '
        Me.pbDone.Image = Global.FileCompressorApp.My.Resources.Resources.Checkmark_96px
        Me.pbDone.Location = New System.Drawing.Point(814, 30)
        Me.pbDone.Name = "pbDone"
        Me.pbDone.Size = New System.Drawing.Size(110, 110)
        Me.pbDone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbDone.TabIndex = 11
        Me.pbDone.TabStop = False
        '
        'tbAbout
        '
        Me.tbAbout.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.tbAbout.Controls.Add(Me.GunaLabel4)
        Me.tbAbout.Controls.Add(Me.GunaLabel3)
        Me.tbAbout.Controls.Add(Me.GunaLabel2)
        Me.tbAbout.Controls.Add(Me.Label8)
        Me.tbAbout.Controls.Add(Me.Label10)
        Me.tbAbout.Controls.Add(Me.GunaLabel1)
        Me.tbAbout.Controls.Add(Me.PictureBox2)
        Me.tbAbout.Location = New System.Drawing.Point(4, 22)
        Me.tbAbout.Name = "tbAbout"
        Me.tbAbout.Size = New System.Drawing.Size(970, 587)
        Me.tbAbout.TabIndex = 2
        Me.tbAbout.Text = "TabPage1"
        '
        'GunaLabel4
        '
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel4.ForeColor = System.Drawing.Color.Silver
        Me.GunaLabel4.Location = New System.Drawing.Point(784, 561)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(172, 15)
        Me.GunaLabel4.TabIndex = 8
        Me.GunaLabel4.Text = "Version: 1.0.0.0"
        Me.GunaLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GunaLabel3
        '
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel3.ForeColor = System.Drawing.Color.Silver
        Me.GunaLabel3.Location = New System.Drawing.Point(20, 106)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(686, 39)
        Me.GunaLabel3.TabIndex = 7
        Me.GunaLabel3.Text = "This app is created for compressing and decompressing files. It implements the Hu" &
    "ffman code algorithm which is a lossless file algorithm. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " "
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.ForeColor = System.Drawing.Color.Silver
        Me.GunaLabel2.Location = New System.Drawing.Point(20, 85)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(89, 15)
        Me.GunaLabel2.TabIndex = 6
        Me.GunaLabel2.Text = "About the app :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(86, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 17)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Bonker"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(60, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 17)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "File"
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.ForeColor = System.Drawing.Color.Silver
        Me.GunaLabel1.Location = New System.Drawing.Point(20, 160)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(172, 15)
        Me.GunaLabel1.TabIndex = 0
        Me.GunaLabel1.Text = "Created by: Lanz Rafael Pancho"
        Me.GunaLabel1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.FileCompressorApp.My.Resources.Resources.search_property_48px_violet1
        Me.PictureBox2.Location = New System.Drawing.Point(23, 37)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'tbSettings
        '
        Me.tbSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.tbSettings.Controls.Add(Me.GunaLabel8)
        Me.tbSettings.Controls.Add(Me.Label16)
        Me.tbSettings.Controls.Add(Me.GunaLabel7)
        Me.tbSettings.Controls.Add(Me.swIgnore)
        Me.tbSettings.Controls.Add(Me.GunaLabel6)
        Me.tbSettings.Controls.Add(Me.Label12)
        Me.tbSettings.Controls.Add(Me.GunaLabel5)
        Me.tbSettings.Controls.Add(Me.swMulti)
        Me.tbSettings.Controls.Add(Me.Label11)
        Me.tbSettings.Location = New System.Drawing.Point(4, 22)
        Me.tbSettings.Name = "tbSettings"
        Me.tbSettings.Size = New System.Drawing.Size(970, 587)
        Me.tbSettings.TabIndex = 3
        Me.tbSettings.Text = "TabPage1"
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(108, Byte), Integer))
        Me.GunaLabel6.Location = New System.Drawing.Point(186, 91)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(35, 15)
        Me.GunaLabel6.TabIndex = 11
        Me.GunaLabel6.Text = "Beta*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Silver
        Me.Label12.Location = New System.Drawing.Point(29, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(151, 17)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Multithreading Process"
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel5.ForeColor = System.Drawing.Color.Silver
        Me.GunaLabel5.Location = New System.Drawing.Point(66, 118)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(289, 15)
        Me.GunaLabel5.TabIndex = 9
        Me.GunaLabel5.Text = "Enable Multithread for faster encoding and decoding."
        '
        'swMulti
        '
        Me.swMulti.BaseColor = System.Drawing.SystemColors.Control
        Me.swMulti.CheckedOffColor = System.Drawing.Color.DarkGray
        Me.swMulti.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.swMulti.FillColor = System.Drawing.Color.White
        Me.swMulti.Location = New System.Drawing.Point(32, 116)
        Me.swMulti.Name = "swMulti"
        Me.swMulti.Size = New System.Drawing.Size(28, 20)
        Me.swMulti.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(29, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 17)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Settings"
        '
        'tbReport
        '
        Me.tbReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.tbReport.Controls.Add(Me.Panel4)
        Me.tbReport.Location = New System.Drawing.Point(4, 22)
        Me.tbReport.Name = "tbReport"
        Me.tbReport.Size = New System.Drawing.Size(970, 587)
        Me.tbReport.TabIndex = 4
        Me.tbReport.Text = "tbReport"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.flpReport)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Location = New System.Drawing.Point(13, 25)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(943, 548)
        Me.Panel4.TabIndex = 12
        '
        'flpReport
        '
        Me.flpReport.AutoScroll = True
        Me.flpReport.Controls.Add(Me.GroupBox1)
        Me.flpReport.Controls.Add(Me.GroupBox4)
        Me.flpReport.Controls.Add(Me.gbCompression)
        Me.flpReport.Controls.Add(Me.gbDecompression)
        Me.flpReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpReport.Location = New System.Drawing.Point(0, 125)
        Me.flpReport.Name = "flpReport"
        Me.flpReport.Size = New System.Drawing.Size(943, 423)
        Me.flpReport.TabIndex = 18
        Me.flpReport.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblActualSave)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.lblActualPer)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.Label57)
        Me.GroupBox1.Controls.Add(Me.lblOutputType)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.lblOutputSize)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.lblOutputF)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.lblSourceType)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.lblSourceSize)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.lblSourceF)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(10, 5, 10, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(900, 193)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Info"
        '
        'lblActualSave
        '
        Me.lblActualSave.AutoEllipsis = True
        Me.lblActualSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblActualSave.Location = New System.Drawing.Point(118, 120)
        Me.lblActualSave.Name = "lblActualSave"
        Me.lblActualSave.Size = New System.Drawing.Size(309, 17)
        Me.lblActualSave.TabIndex = 31
        Me.lblActualSave.Text = "0 Mb/s (0 byte/s)"
        '
        'Label20
        '
        Me.Label20.AutoEllipsis = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(7, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(105, 17)
        Me.Label20.TabIndex = 30
        Me.Label20.Text = "Actual Save:"
        '
        'lblActualPer
        '
        Me.lblActualPer.AutoEllipsis = True
        Me.lblActualPer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualPer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblActualPer.Location = New System.Drawing.Point(118, 137)
        Me.lblActualPer.Name = "lblActualPer"
        Me.lblActualPer.Size = New System.Drawing.Size(309, 17)
        Me.lblActualPer.TabIndex = 29
        Me.lblActualPer.Text = "0.00%"
        '
        'Label58
        '
        Me.Label58.AutoEllipsis = True
        Me.Label58.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label58.Location = New System.Drawing.Point(7, 137)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(105, 17)
        Me.Label58.TabIndex = 28
        Me.Label58.Text = "Actual Save (%):"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label57.Location = New System.Drawing.Point(7, 97)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(82, 17)
        Me.Label57.TabIndex = 27
        Me.Label57.Text = "Comparison"
        '
        'lblOutputType
        '
        Me.lblOutputType.AutoEllipsis = True
        Me.lblOutputType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblOutputType.Location = New System.Drawing.Point(516, 62)
        Me.lblOutputType.Name = "lblOutputType"
        Me.lblOutputType.Size = New System.Drawing.Size(309, 17)
        Me.lblOutputType.TabIndex = 24
        Me.lblOutputType.Text = "TXT File (.txt)"
        '
        'Label24
        '
        Me.Label24.AutoEllipsis = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(437, 62)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(73, 17)
        Me.Label24.TabIndex = 23
        Me.Label24.Text = "File Type:"
        '
        'lblOutputSize
        '
        Me.lblOutputSize.AutoEllipsis = True
        Me.lblOutputSize.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblOutputSize.Location = New System.Drawing.Point(516, 45)
        Me.lblOutputSize.Name = "lblOutputSize"
        Me.lblOutputSize.Size = New System.Drawing.Size(309, 17)
        Me.lblOutputSize.TabIndex = 22
        Me.lblOutputSize.Text = "0.00 Mb (0 byte/s)"
        '
        'Label26
        '
        Me.Label26.AutoEllipsis = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(437, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(73, 17)
        Me.Label26.TabIndex = 21
        Me.Label26.Text = "File Size:"
        '
        'lblOutputF
        '
        Me.lblOutputF.AutoEllipsis = True
        Me.lblOutputF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblOutputF.Location = New System.Drawing.Point(516, 27)
        Me.lblOutputF.Name = "lblOutputF"
        Me.lblOutputF.Size = New System.Drawing.Size(309, 17)
        Me.lblOutputF.TabIndex = 20
        Me.lblOutputF.Text = "C:\Users\Lanz Pancho\Documents\pncapp\Download files...."
        '
        'Label28
        '
        Me.Label28.AutoEllipsis = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(437, 27)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(73, 17)
        Me.Label28.TabIndex = 19
        Me.Label28.Text = "Output File:"
        '
        'lblSourceType
        '
        Me.lblSourceType.AutoEllipsis = True
        Me.lblSourceType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourceType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblSourceType.Location = New System.Drawing.Point(81, 62)
        Me.lblSourceType.Name = "lblSourceType"
        Me.lblSourceType.Size = New System.Drawing.Size(309, 17)
        Me.lblSourceType.TabIndex = 18
        Me.lblSourceType.Text = "TXT File (.txt)"
        '
        'Label21
        '
        Me.Label21.AutoEllipsis = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(7, 62)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 17)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "File Type:"
        '
        'lblSourceSize
        '
        Me.lblSourceSize.AutoEllipsis = True
        Me.lblSourceSize.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourceSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblSourceSize.Location = New System.Drawing.Point(81, 45)
        Me.lblSourceSize.Name = "lblSourceSize"
        Me.lblSourceSize.Size = New System.Drawing.Size(309, 17)
        Me.lblSourceSize.TabIndex = 16
        Me.lblSourceSize.Text = "0.00 Mb (0 byte/s)"
        '
        'Label19
        '
        Me.Label19.AutoEllipsis = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(7, 45)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 17)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "File Size:"
        '
        'lblSourceF
        '
        Me.lblSourceF.AutoEllipsis = True
        Me.lblSourceF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourceF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblSourceF.Location = New System.Drawing.Point(81, 27)
        Me.lblSourceF.Name = "lblSourceF"
        Me.lblSourceF.Size = New System.Drawing.Size(309, 17)
        Me.lblSourceF.TabIndex = 14
        Me.lblSourceF.Text = "C:\Users\Lanz Pancho\Documents\pncapp\Download files...."
        '
        'Label18
        '
        Me.Label18.AutoEllipsis = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(7, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 17)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "Source File:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblProcessType)
        Me.GroupBox4.Controls.Add(Me.Label54)
        Me.GroupBox4.Controls.Add(Me.lblPackageType)
        Me.GroupBox4.Controls.Add(Me.Label62)
        Me.GroupBox4.Controls.Add(Me.lblProcessMode)
        Me.GroupBox4.Controls.Add(Me.Label64)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 213)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(10, 10, 10, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Size = New System.Drawing.Size(900, 94)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Process Info"
        '
        'lblProcessType
        '
        Me.lblProcessType.AutoEllipsis = True
        Me.lblProcessType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblProcessType.Location = New System.Drawing.Point(113, 44)
        Me.lblProcessType.Name = "lblProcessType"
        Me.lblProcessType.Size = New System.Drawing.Size(309, 17)
        Me.lblProcessType.TabIndex = 18
        Me.lblProcessType.Text = "Single Thread / Multi-thread"
        '
        'Label54
        '
        Me.Label54.AutoEllipsis = True
        Me.Label54.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label54.Location = New System.Drawing.Point(7, 44)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(94, 17)
        Me.Label54.TabIndex = 17
        Me.Label54.Text = "Process Type:"
        '
        'lblPackageType
        '
        Me.lblPackageType.AutoEllipsis = True
        Me.lblPackageType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackageType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblPackageType.Location = New System.Drawing.Point(113, 62)
        Me.lblPackageType.Name = "lblPackageType"
        Me.lblPackageType.Size = New System.Drawing.Size(309, 17)
        Me.lblPackageType.TabIndex = 16
        Me.lblPackageType.Text = "Single File / Multi-file"
        '
        'Label62
        '
        Me.Label62.AutoEllipsis = True
        Me.Label62.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label62.Location = New System.Drawing.Point(7, 62)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(94, 17)
        Me.Label62.TabIndex = 15
        Me.Label62.Text = "Package Type:"
        '
        'lblProcessMode
        '
        Me.lblProcessMode.AutoEllipsis = True
        Me.lblProcessMode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessMode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblProcessMode.Location = New System.Drawing.Point(113, 27)
        Me.lblProcessMode.Name = "lblProcessMode"
        Me.lblProcessMode.Size = New System.Drawing.Size(309, 17)
        Me.lblProcessMode.TabIndex = 14
        Me.lblProcessMode.Text = "Compression / Decompression"
        '
        'Label64
        '
        Me.Label64.AutoEllipsis = True
        Me.Label64.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label64.Location = New System.Drawing.Point(7, 27)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(94, 17)
        Me.Label64.TabIndex = 13
        Me.Label64.Text = "Process Mode:"
        '
        'gbCompression
        '
        Me.gbCompression.Controls.Add(Me.lblCHeaderTotalByte)
        Me.gbCompression.Controls.Add(Me.Label39)
        Me.gbCompression.Controls.Add(Me.lblCTreeTotalByte)
        Me.gbCompression.Controls.Add(Me.Label38)
        Me.gbCompression.Controls.Add(Me.lblCExpSize)
        Me.gbCompression.Controls.Add(Me.Label35)
        Me.gbCompression.Controls.Add(Me.lblCReadSpeed)
        Me.gbCompression.Controls.Add(Me.Label30)
        Me.gbCompression.Controls.Add(Me.lblCWriteSpeed)
        Me.gbCompression.Controls.Add(Me.Label32)
        Me.gbCompression.Controls.Add(Me.lblCTimeElapsed)
        Me.gbCompression.Controls.Add(Me.Label34)
        Me.gbCompression.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gbCompression.Location = New System.Drawing.Point(10, 317)
        Me.gbCompression.Margin = New System.Windows.Forms.Padding(10, 5, 10, 5)
        Me.gbCompression.Name = "gbCompression"
        Me.gbCompression.Size = New System.Drawing.Size(900, 101)
        Me.gbCompression.TabIndex = 16
        Me.gbCompression.TabStop = False
        Me.gbCompression.Text = "Compression"
        '
        'lblCHeaderTotalByte
        '
        Me.lblCHeaderTotalByte.AutoEllipsis = True
        Me.lblCHeaderTotalByte.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCHeaderTotalByte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblCHeaderTotalByte.Location = New System.Drawing.Point(191, 59)
        Me.lblCHeaderTotalByte.Name = "lblCHeaderTotalByte"
        Me.lblCHeaderTotalByte.Size = New System.Drawing.Size(231, 17)
        Me.lblCHeaderTotalByte.TabIndex = 30
        Me.lblCHeaderTotalByte.Text = "0 Mb/s (0 byte/s)"
        '
        'Label39
        '
        Me.Label39.AutoEllipsis = True
        Me.Label39.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label39.Location = New System.Drawing.Point(7, 59)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(178, 17)
        Me.Label39.TabIndex = 29
        Me.Label39.Text = "Computed Total Bytes (Header):"
        '
        'lblCTreeTotalByte
        '
        Me.lblCTreeTotalByte.AutoEllipsis = True
        Me.lblCTreeTotalByte.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTreeTotalByte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblCTreeTotalByte.Location = New System.Drawing.Point(191, 42)
        Me.lblCTreeTotalByte.Name = "lblCTreeTotalByte"
        Me.lblCTreeTotalByte.Size = New System.Drawing.Size(231, 17)
        Me.lblCTreeTotalByte.TabIndex = 28
        Me.lblCTreeTotalByte.Text = "0 Mb/s (0 byte/s)"
        '
        'Label38
        '
        Me.Label38.AutoEllipsis = True
        Me.Label38.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label38.Location = New System.Drawing.Point(7, 42)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(178, 17)
        Me.Label38.TabIndex = 27
        Me.Label38.Text = "Computed Total Bytes (Tree):"
        '
        'lblCExpSize
        '
        Me.lblCExpSize.AutoEllipsis = True
        Me.lblCExpSize.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCExpSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblCExpSize.Location = New System.Drawing.Point(191, 76)
        Me.lblCExpSize.Name = "lblCExpSize"
        Me.lblCExpSize.Size = New System.Drawing.Size(231, 17)
        Me.lblCExpSize.TabIndex = 26
        Me.lblCExpSize.Text = "0 Mb/s (0 byte/s)"
        '
        'Label35
        '
        Me.Label35.AutoEllipsis = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(7, 76)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(153, 17)
        Me.Label35.TabIndex = 25
        Me.Label35.Text = "Expected Compressed Size:"
        '
        'lblCReadSpeed
        '
        Me.lblCReadSpeed.AutoEllipsis = True
        Me.lblCReadSpeed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCReadSpeed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblCReadSpeed.Location = New System.Drawing.Point(556, 42)
        Me.lblCReadSpeed.Name = "lblCReadSpeed"
        Me.lblCReadSpeed.Size = New System.Drawing.Size(309, 17)
        Me.lblCReadSpeed.TabIndex = 24
        Me.lblCReadSpeed.Text = "0.00 Mb/s"
        '
        'Label30
        '
        Me.Label30.AutoEllipsis = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(437, 42)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(113, 17)
        Me.Label30.TabIndex = 23
        Me.Label30.Text = "Avg. Read Speed:"
        '
        'lblCWriteSpeed
        '
        Me.lblCWriteSpeed.AutoEllipsis = True
        Me.lblCWriteSpeed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCWriteSpeed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblCWriteSpeed.Location = New System.Drawing.Point(556, 24)
        Me.lblCWriteSpeed.Name = "lblCWriteSpeed"
        Me.lblCWriteSpeed.Size = New System.Drawing.Size(309, 17)
        Me.lblCWriteSpeed.TabIndex = 22
        Me.lblCWriteSpeed.Text = "0.00 Mb/s"
        '
        'Label32
        '
        Me.Label32.AutoEllipsis = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(437, 24)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(113, 17)
        Me.Label32.TabIndex = 21
        Me.Label32.Text = "Avg. Write Speed:"
        '
        'lblCTimeElapsed
        '
        Me.lblCTimeElapsed.AutoEllipsis = True
        Me.lblCTimeElapsed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTimeElapsed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblCTimeElapsed.Location = New System.Drawing.Point(191, 24)
        Me.lblCTimeElapsed.Name = "lblCTimeElapsed"
        Me.lblCTimeElapsed.Size = New System.Drawing.Size(231, 17)
        Me.lblCTimeElapsed.TabIndex = 20
        Me.lblCTimeElapsed.Text = "00:00:00"
        '
        'Label34
        '
        Me.Label34.AutoEllipsis = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(7, 24)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(178, 17)
        Me.Label34.TabIndex = 19
        Me.Label34.Text = "Time Elapsed:"
        '
        'gbDecompression
        '
        Me.gbDecompression.Controls.Add(Me.lblDHeaderTotalByte)
        Me.gbDecompression.Controls.Add(Me.Label42)
        Me.gbDecompression.Controls.Add(Me.lblDTreeTotalByte)
        Me.gbDecompression.Controls.Add(Me.Label44)
        Me.gbDecompression.Controls.Add(Me.lblDExpSize)
        Me.gbDecompression.Controls.Add(Me.Label46)
        Me.gbDecompression.Controls.Add(Me.lblDReadSpeed)
        Me.gbDecompression.Controls.Add(Me.Label48)
        Me.gbDecompression.Controls.Add(Me.lblDWriteSpeed)
        Me.gbDecompression.Controls.Add(Me.Label50)
        Me.gbDecompression.Controls.Add(Me.lblDTimeElapsed)
        Me.gbDecompression.Controls.Add(Me.Label52)
        Me.gbDecompression.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gbDecompression.Location = New System.Drawing.Point(10, 428)
        Me.gbDecompression.Margin = New System.Windows.Forms.Padding(10, 5, 10, 5)
        Me.gbDecompression.Name = "gbDecompression"
        Me.gbDecompression.Size = New System.Drawing.Size(900, 97)
        Me.gbDecompression.TabIndex = 17
        Me.gbDecompression.TabStop = False
        Me.gbDecompression.Text = "Decompression"
        '
        'lblDHeaderTotalByte
        '
        Me.lblDHeaderTotalByte.AutoEllipsis = True
        Me.lblDHeaderTotalByte.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDHeaderTotalByte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblDHeaderTotalByte.Location = New System.Drawing.Point(218, 59)
        Me.lblDHeaderTotalByte.Name = "lblDHeaderTotalByte"
        Me.lblDHeaderTotalByte.Size = New System.Drawing.Size(231, 17)
        Me.lblDHeaderTotalByte.TabIndex = 30
        Me.lblDHeaderTotalByte.Text = "0 Mb/s (0 byte/s)"
        '
        'Label42
        '
        Me.Label42.AutoEllipsis = True
        Me.Label42.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(7, 59)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(178, 17)
        Me.Label42.TabIndex = 29
        Me.Label42.Text = "Computed Total Bytes (Header):"
        '
        'lblDTreeTotalByte
        '
        Me.lblDTreeTotalByte.AutoEllipsis = True
        Me.lblDTreeTotalByte.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDTreeTotalByte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblDTreeTotalByte.Location = New System.Drawing.Point(218, 42)
        Me.lblDTreeTotalByte.Name = "lblDTreeTotalByte"
        Me.lblDTreeTotalByte.Size = New System.Drawing.Size(231, 17)
        Me.lblDTreeTotalByte.TabIndex = 28
        Me.lblDTreeTotalByte.Text = "0 Mb/s (0 byte/s)"
        '
        'Label44
        '
        Me.Label44.AutoEllipsis = True
        Me.Label44.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(7, 42)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(178, 17)
        Me.Label44.TabIndex = 27
        Me.Label44.Text = "Computed Total Bytes (Tree):"
        '
        'lblDExpSize
        '
        Me.lblDExpSize.AutoEllipsis = True
        Me.lblDExpSize.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDExpSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblDExpSize.Location = New System.Drawing.Point(218, 76)
        Me.lblDExpSize.Name = "lblDExpSize"
        Me.lblDExpSize.Size = New System.Drawing.Size(231, 17)
        Me.lblDExpSize.TabIndex = 26
        Me.lblDExpSize.Text = "0 Mb/s (0 byte/s)"
        '
        'Label46
        '
        Me.Label46.AutoEllipsis = True
        Me.Label46.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(7, 76)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(169, 17)
        Me.Label46.TabIndex = 25
        Me.Label46.Text = "Expected Decompressed Size:"
        '
        'lblDReadSpeed
        '
        Me.lblDReadSpeed.AutoEllipsis = True
        Me.lblDReadSpeed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDReadSpeed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblDReadSpeed.Location = New System.Drawing.Point(583, 42)
        Me.lblDReadSpeed.Name = "lblDReadSpeed"
        Me.lblDReadSpeed.Size = New System.Drawing.Size(309, 17)
        Me.lblDReadSpeed.TabIndex = 24
        Me.lblDReadSpeed.Text = "0.00 Mb/s"
        '
        'Label48
        '
        Me.Label48.AutoEllipsis = True
        Me.Label48.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label48.Location = New System.Drawing.Point(464, 42)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(113, 17)
        Me.Label48.TabIndex = 23
        Me.Label48.Text = "Avg. Read Speed:"
        '
        'lblDWriteSpeed
        '
        Me.lblDWriteSpeed.AutoEllipsis = True
        Me.lblDWriteSpeed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDWriteSpeed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblDWriteSpeed.Location = New System.Drawing.Point(583, 24)
        Me.lblDWriteSpeed.Name = "lblDWriteSpeed"
        Me.lblDWriteSpeed.Size = New System.Drawing.Size(309, 17)
        Me.lblDWriteSpeed.TabIndex = 22
        Me.lblDWriteSpeed.Text = "0.00 Mb/s"
        '
        'Label50
        '
        Me.Label50.AutoEllipsis = True
        Me.Label50.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label50.Location = New System.Drawing.Point(464, 24)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(113, 17)
        Me.Label50.TabIndex = 21
        Me.Label50.Text = "Avg. Write Speed:"
        '
        'lblDTimeElapsed
        '
        Me.lblDTimeElapsed.AutoEllipsis = True
        Me.lblDTimeElapsed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDTimeElapsed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblDTimeElapsed.Location = New System.Drawing.Point(218, 24)
        Me.lblDTimeElapsed.Name = "lblDTimeElapsed"
        Me.lblDTimeElapsed.Size = New System.Drawing.Size(231, 17)
        Me.lblDTimeElapsed.TabIndex = 20
        Me.lblDTimeElapsed.Text = "00:00:00"
        '
        'Label52
        '
        Me.Label52.AutoEllipsis = True
        Me.Label52.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label52.Location = New System.Drawing.Point(7, 24)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(178, 17)
        Me.Label52.TabIndex = 19
        Me.Label52.Text = "Time Elapsed:"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel5.Controls.Add(Me.lblReportMsg)
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(943, 125)
        Me.Panel5.TabIndex = 12
        '
        'lblReportMsg
        '
        Me.lblReportMsg.AutoEllipsis = True
        Me.lblReportMsg.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReportMsg.ForeColor = System.Drawing.Color.White
        Me.lblReportMsg.Location = New System.Drawing.Point(23, 51)
        Me.lblReportMsg.Name = "lblReportMsg"
        Me.lblReportMsg.Size = New System.Drawing.Size(289, 33)
        Me.lblReportMsg.TabIndex = 12
        Me.lblReportMsg.Text = "Operation Ready."
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Black", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(784, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(137, 72)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "50%"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label14.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(23, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 17)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Process Report"
        '
        'BackgroundWorker1
        '
        '
        'tmProgress
        '
        Me.tmProgress.Enabled = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'bwMulti
        '
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Silver
        Me.Label16.Location = New System.Drawing.Point(29, 158)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(154, 17)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Ignore Process Warning"
        '
        'GunaLabel7
        '
        Me.GunaLabel7.AutoSize = True
        Me.GunaLabel7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel7.ForeColor = System.Drawing.Color.Silver
        Me.GunaLabel7.Location = New System.Drawing.Point(66, 185)
        Me.GunaLabel7.Name = "GunaLabel7"
        Me.GunaLabel7.Size = New System.Drawing.Size(387, 15)
        Me.GunaLabel7.TabIndex = 13
        Me.GunaLabel7.Text = "Disables ""file/s not compressable"" and ""low compression rate"" message."
        '
        'swIgnore
        '
        Me.swIgnore.BaseColor = System.Drawing.SystemColors.Control
        Me.swIgnore.CheckedOffColor = System.Drawing.Color.DarkGray
        Me.swIgnore.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.swIgnore.FillColor = System.Drawing.Color.White
        Me.swIgnore.Location = New System.Drawing.Point(32, 183)
        Me.swIgnore.Name = "swIgnore"
        Me.swIgnore.Size = New System.Drawing.Size(28, 20)
        Me.swIgnore.TabIndex = 12
        '
        'GunaLabel8
        '
        Me.GunaLabel8.AutoSize = True
        Me.GunaLabel8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(108, Byte), Integer))
        Me.GunaLabel8.Location = New System.Drawing.Point(189, 160)
        Me.GunaLabel8.Name = "GunaLabel8"
        Me.GunaLabel8.Size = New System.Drawing.Size(91, 15)
        Me.GunaLabel8.TabIndex = 15
        Me.GunaLabel8.Text = "Advanced User*"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1167, 619)
        Me.Controls.Add(Me.pnlNavigation)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigation.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.GunaPanel2.ResumeLayout(False)
        Me.GunaPanel2.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlDate.ResumeLayout(False)
        Me.pnlDate.PerformLayout()
        Me.pnlType.ResumeLayout(False)
        Me.pnlType.PerformLayout()
        Me.pnlSize.ResumeLayout(False)
        Me.pnlSize.PerformLayout()
        Me.pnlName.ResumeLayout(False)
        Me.pnlName.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.tbProcess.ResumeLayout(False)
        Me.pnlProcessDetail.ResumeLayout(False)
        Me.pnlProcessDetail.PerformLayout()
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlStatus.PerformLayout()
        Me.pnlDetails.ResumeLayout(False)
        Me.pnlDetails.PerformLayout()
        Me.pnlLoading.ResumeLayout(False)
        CType(Me.pbDone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbAbout.ResumeLayout(False)
        Me.tbAbout.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSettings.ResumeLayout(False)
        Me.tbSettings.PerformLayout()
        Me.tbReport.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.flpReport.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.gbCompression.ResumeLayout(False)
        Me.gbDecompression.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnClose As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents btnMinimize As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents pnlNavigation As Panel
    Friend WithEvents GunaElipse1 As Guna.UI.WinForms.GunaElipse
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbMain As TabPage
    Friend WithEvents tbProcess As TabPage
    Friend WithEvents pnlHeader As Guna.UI.WinForms.GunaElipsePanel
    Friend WithEvents pnlSize As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents pnlName As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents flpFileDirectory As FlowLayoutPanel
    Friend WithEvents pnlDate As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Splitter3 As Splitter
    Friend WithEvents pnlType As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Splitter2 As Splitter
    Friend WithEvents vsbFileDirectory As Guna.UI.WinForms.GunaVScrollBar
    Friend WithEvents txtPath As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents btnBack As Guna.UI.WinForms.GunaCircleButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSortDate As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents btnSortType As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents btnSortSize As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents btnSortName As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents btnBonk As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents btnAbout As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents btnProgress As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents btnExplorer As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlStatus As Guna.UI.WinForms.GunaShadowPanel
    Friend WithEvents pnlLoading As Guna.UI.WinForms.GunaPanel
    Friend WithEvents pbOverall As Guna.UI.WinForms.GunaCircleProgressBar
    Friend WithEvents lblFolderStatus As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblOverallPercent As Label
    Friend WithEvents btnCancel As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents lblTimeRemaining As Label
    Friend WithEvents lblWriteSpeed As Label
    Friend WithEvents pnlProcessDetail As Guna.UI.WinForms.GunaShadowPanel
    Friend WithEvents pbProcessed As Guna.UI.WinForms.GunaProgressBar
    Friend WithEvents lblProcessPercent As Label
    Friend WithEvents lblFileStatus As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblWriteAvgSpeed As Label
    Friend WithEvents lblElapsedTime As Label
    Friend WithEvents lblProcessedStatus As Label
    Friend WithEvents cbDrives As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents btnUnbonk As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DesktopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MusicToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PicturesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VideosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents NewFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmProgress As Timer
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblReadAvgSpeed As Label
    Friend WithEvents lblReadSpeed As Label
    Friend WithEvents pbDone As PictureBox
    Friend WithEvents pnlDetails As Guna.UI.WinForms.GunaPanel
    Friend WithEvents lblLastAvgRead As Label
    Friend WithEvents lblLastAvgWrite As Label
    Friend WithEvents lblLastTimeElapsed As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTotalFileSize As Label
    Friend WithEvents DocumentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tbAbout As TabPage
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents bwMulti As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnPageStart As Guna.UI.WinForms.GunaCircleButton
    Friend WithEvents btnPageEnd As Guna.UI.WinForms.GunaCircleButton
    Friend WithEvents btnPagePrev As Guna.UI.WinForms.GunaCircleButton
    Friend WithEvents btnPageNext As Guna.UI.WinForms.GunaCircleButton
    Friend WithEvents btnSettings As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents tbSettings As TabPage
    Friend WithEvents swMulti As Guna.UI.WinForms.GunaSwitch
    Friend WithEvents Label11 As Label
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Label12 As Label
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents lblCmpMode As Label
    Friend WithEvents tbReport As TabPage
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents gbCompression As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblReportMsg As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblCWriteSpeed As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents lblCTimeElapsed As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents lblOutputType As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents lblOutputSize As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents lblOutputF As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents lblSourceType As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblSourceSize As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblSourceF As Label
    Friend WithEvents lblCReadSpeed As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents lblCExpSize As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents lblCTreeTotalByte As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents lblCHeaderTotalByte As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents gbDecompression As GroupBox
    Friend WithEvents lblDHeaderTotalByte As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents lblDTreeTotalByte As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents lblDExpSize As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents lblDReadSpeed As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents lblDWriteSpeed As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents lblDTimeElapsed As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents flpReport As FlowLayoutPanel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lblPackageType As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents lblProcessMode As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents lblProcessType As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents lblActualPer As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents lblActualSave As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lblThreadType As Label
    Friend WithEvents GunaLabel8 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Label16 As Label
    Friend WithEvents GunaLabel7 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents swIgnore As Guna.UI.WinForms.GunaSwitch
End Class
