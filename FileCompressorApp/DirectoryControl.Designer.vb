<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DirectoryControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DirectoryControl))
        Me.pnlName = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmDesktop = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDownloads = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmMusic = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmPictures = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmVideos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmNewfolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtNewFilename = New Guna.UI.WinForms.GunaTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BonkHereToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnbonkHereToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MyDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesktopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicturesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VideosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlSize = New System.Windows.Forms.Panel()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.pnlType = New System.Windows.Forms.Panel()
        Me.lblType = New System.Windows.Forms.Label()
        Me.pnlDate = New System.Windows.Forms.Panel()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSelect = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pnlName.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlSize.SuspendLayout()
        Me.pnlType.SuspendLayout()
        Me.pnlDate.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlName
        '
        Me.pnlName.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlName.ContextMenuStrip = Me.ContextMenuStrip2
        Me.pnlName.Controls.Add(Me.txtNewFilename)
        Me.pnlName.Controls.Add(Me.lblName)
        Me.pnlName.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlName.Location = New System.Drawing.Point(28, 0)
        Me.pnlName.Name = "pnlName"
        Me.pnlName.Size = New System.Drawing.Size(570, 28)
        Me.pnlName.TabIndex = 1
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmDesktop, Me.tsmDocument, Me.tsmDownloads, Me.tsmMusic, Me.tsmPictures, Me.tsmVideos, Me.ToolStripSeparator1, Me.tsmNewfolder})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(181, 186)
        '
        'tsmDesktop
        '
        Me.tsmDesktop.Name = "tsmDesktop"
        Me.tsmDesktop.Size = New System.Drawing.Size(180, 22)
        Me.tsmDesktop.Text = "Desktop"
        '
        'tsmDocument
        '
        Me.tsmDocument.Name = "tsmDocument"
        Me.tsmDocument.Size = New System.Drawing.Size(180, 22)
        Me.tsmDocument.Text = "Document"
        '
        'tsmDownloads
        '
        Me.tsmDownloads.Name = "tsmDownloads"
        Me.tsmDownloads.Size = New System.Drawing.Size(180, 22)
        Me.tsmDownloads.Text = "Downloads"
        '
        'tsmMusic
        '
        Me.tsmMusic.Name = "tsmMusic"
        Me.tsmMusic.Size = New System.Drawing.Size(180, 22)
        Me.tsmMusic.Text = "Music"
        '
        'tsmPictures
        '
        Me.tsmPictures.Name = "tsmPictures"
        Me.tsmPictures.Size = New System.Drawing.Size(180, 22)
        Me.tsmPictures.Text = "Pictures"
        '
        'tsmVideos
        '
        Me.tsmVideos.Name = "tsmVideos"
        Me.tsmVideos.Size = New System.Drawing.Size(180, 22)
        Me.tsmVideos.Text = "Videos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'tsmNewfolder
        '
        Me.tsmNewfolder.Name = "tsmNewfolder"
        Me.tsmNewfolder.Size = New System.Drawing.Size(180, 22)
        Me.tsmNewfolder.Text = "New Folder"
        '
        'txtNewFilename
        '
        Me.txtNewFilename.BaseColor = System.Drawing.Color.White
        Me.txtNewFilename.BorderColor = System.Drawing.Color.Silver
        Me.txtNewFilename.BorderSize = 1
        Me.txtNewFilename.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNewFilename.FocusedBaseColor = System.Drawing.Color.White
        Me.txtNewFilename.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNewFilename.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNewFilename.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNewFilename.ForeColor = System.Drawing.Color.Silver
        Me.txtNewFilename.Location = New System.Drawing.Point(6, 1)
        Me.txtNewFilename.Name = "txtNewFilename"
        Me.txtNewFilename.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNewFilename.Size = New System.Drawing.Size(389, 27)
        Me.txtNewFilename.TabIndex = 1
        Me.txtNewFilename.Text = "Enter new filename..."
        Me.txtNewFilename.Visible = False
        '
        'lblName
        '
        Me.lblName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblName.AutoEllipsis = True
        Me.lblName.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(10, 8)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(554, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.BonkHereToolStripMenuItem, Me.UnbonkHereToolStripMenuItem, Me.ToolStripMenuItem2, Me.MyDocumentToolStripMenuItem, Me.ToolStripMenuItem1, Me.RenameToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 148)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'BonkHereToolStripMenuItem
        '
        Me.BonkHereToolStripMenuItem.Name = "BonkHereToolStripMenuItem"
        Me.BonkHereToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BonkHereToolStripMenuItem.Text = "Bonk Here"
        '
        'UnbonkHereToolStripMenuItem
        '
        Me.UnbonkHereToolStripMenuItem.Name = "UnbonkHereToolStripMenuItem"
        Me.UnbonkHereToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UnbonkHereToolStripMenuItem.Text = "Unbonk Here"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(149, 6)
        '
        'MyDocumentToolStripMenuItem
        '
        Me.MyDocumentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesktopToolStripMenuItem, Me.DocumentsToolStripMenuItem, Me.DownloadsToolStripMenuItem, Me.MusicToolStripMenuItem, Me.PicturesToolStripMenuItem, Me.VideosToolStripMenuItem})
        Me.MyDocumentToolStripMenuItem.Name = "MyDocumentToolStripMenuItem"
        Me.MyDocumentToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MyDocumentToolStripMenuItem.Text = "Special Folders"
        '
        'DesktopToolStripMenuItem
        '
        Me.DesktopToolStripMenuItem.Name = "DesktopToolStripMenuItem"
        Me.DesktopToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DesktopToolStripMenuItem.Text = "Desktop"
        '
        'DocumentsToolStripMenuItem
        '
        Me.DocumentsToolStripMenuItem.Name = "DocumentsToolStripMenuItem"
        Me.DocumentsToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DocumentsToolStripMenuItem.Text = "Documents"
        '
        'DownloadsToolStripMenuItem
        '
        Me.DownloadsToolStripMenuItem.Name = "DownloadsToolStripMenuItem"
        Me.DownloadsToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DownloadsToolStripMenuItem.Text = "Downloads"
        '
        'MusicToolStripMenuItem
        '
        Me.MusicToolStripMenuItem.Name = "MusicToolStripMenuItem"
        Me.MusicToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.MusicToolStripMenuItem.Text = "Music"
        '
        'PicturesToolStripMenuItem
        '
        Me.PicturesToolStripMenuItem.Name = "PicturesToolStripMenuItem"
        Me.PicturesToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PicturesToolStripMenuItem.Text = "Pictures"
        '
        'VideosToolStripMenuItem
        '
        Me.VideosToolStripMenuItem.Name = "VideosToolStripMenuItem"
        Me.VideosToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.VideosToolStripMenuItem.Text = "Videos"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'pnlSize
        '
        Me.pnlSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlSize.ContextMenuStrip = Me.ContextMenuStrip2
        Me.pnlSize.Controls.Add(Me.lblSize)
        Me.pnlSize.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSize.Location = New System.Drawing.Point(598, 0)
        Me.pnlSize.Name = "pnlSize"
        Me.pnlSize.Size = New System.Drawing.Size(103, 28)
        Me.pnlSize.TabIndex = 3
        '
        'lblSize
        '
        Me.lblSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSize.AutoEllipsis = True
        Me.lblSize.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lblSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblSize.Location = New System.Drawing.Point(10, 8)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(87, 13)
        Me.lblSize.TabIndex = 0
        Me.lblSize.Text = "Size"
        Me.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlType
        '
        Me.pnlType.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlType.ContextMenuStrip = Me.ContextMenuStrip2
        Me.pnlType.Controls.Add(Me.lblType)
        Me.pnlType.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlType.Location = New System.Drawing.Point(701, 0)
        Me.pnlType.Name = "pnlType"
        Me.pnlType.Size = New System.Drawing.Size(113, 28)
        Me.pnlType.TabIndex = 5
        '
        'lblType
        '
        Me.lblType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblType.AutoEllipsis = True
        Me.lblType.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lblType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblType.Location = New System.Drawing.Point(10, 8)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(97, 13)
        Me.lblType.TabIndex = 0
        Me.lblType.Text = "File type"
        Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDate
        '
        Me.pnlDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlDate.ContextMenuStrip = Me.ContextMenuStrip2
        Me.pnlDate.Controls.Add(Me.lblDate)
        Me.pnlDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDate.Location = New System.Drawing.Point(814, 0)
        Me.pnlDate.Name = "pnlDate"
        Me.pnlDate.Size = New System.Drawing.Size(109, 28)
        Me.pnlDate.TabIndex = 7
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.AutoEllipsis = True
        Me.lblDate.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblDate.Location = New System.Drawing.Point(6, 8)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(100, 13)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date Modified"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSelect)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(28, 28)
        Me.Panel1.TabIndex = 8
        '
        'btnSelect
        '
        Me.btnSelect.AnimationHoverSpeed = 0.07!
        Me.btnSelect.AnimationSpeed = 0.03!
        Me.btnSelect.BackColor = System.Drawing.SystemColors.Control
        Me.btnSelect.BaseColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnSelect.BorderColor = System.Drawing.Color.Black
        Me.btnSelect.CheckedBaseColor = System.Drawing.Color.Gray
        Me.btnSelect.CheckedBorderColor = System.Drawing.Color.Black
        Me.btnSelect.CheckedForeColor = System.Drawing.Color.White
        Me.btnSelect.CheckedImage = CType(resources.GetObject("btnSelect.CheckedImage"), System.Drawing.Image)
        Me.btnSelect.CheckedLineColor = System.Drawing.Color.DimGray
        Me.btnSelect.ContextMenuStrip = Me.ContextMenuStrip2
        Me.btnSelect.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSelect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSelect.FocusedColor = System.Drawing.Color.Empty
        Me.btnSelect.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSelect.ForeColor = System.Drawing.Color.White
        Me.btnSelect.Image = Global.FileCompressorApp.My.Resources.Resources.folder_48px
        Me.btnSelect.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btnSelect.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnSelect.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSelect.Location = New System.Drawing.Point(0, 0)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnSelect.OnHoverBorderColor = System.Drawing.Color.Black
        Me.btnSelect.OnHoverForeColor = System.Drawing.Color.White
        Me.btnSelect.OnHoverImage = Nothing
        Me.btnSelect.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSelect.OnPressedColor = System.Drawing.Color.Black
        Me.btnSelect.Size = New System.Drawing.Size(28, 28)
        Me.btnSelect.TabIndex = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'DirectoryControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ContextMenuStrip2
        Me.Controls.Add(Me.pnlDate)
        Me.Controls.Add(Me.pnlType)
        Me.Controls.Add(Me.pnlSize)
        Me.Controls.Add(Me.pnlName)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "DirectoryControl"
        Me.Size = New System.Drawing.Size(923, 28)
        Me.pnlName.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlSize.ResumeLayout(False)
        Me.pnlType.ResumeLayout(False)
        Me.pnlDate.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlName As Panel
    Friend WithEvents lblName As Label
    Friend WithEvents pnlSize As Panel
    Friend WithEvents lblSize As Label
    Friend WithEvents pnlType As Panel
    Friend WithEvents lblType As Label
    Friend WithEvents pnlDate As Panel
    Friend WithEvents lblDate As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSelect As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MyDocumentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesktopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MusicToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PicturesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VideosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents UnbonkHereToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BonkHereToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents RenameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DocumentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents tsmDesktop As ToolStripMenuItem
    Friend WithEvents tsmDocument As ToolStripMenuItem
    Friend WithEvents tsmDownloads As ToolStripMenuItem
    Friend WithEvents tsmMusic As ToolStripMenuItem
    Friend WithEvents tsmPictures As ToolStripMenuItem
    Friend WithEvents tsmVideos As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsmNewfolder As ToolStripMenuItem
    Friend WithEvents txtNewFilename As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
End Class
