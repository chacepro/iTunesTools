<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClean
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClean))
        Me.lblPerc = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.btnDialog = New System.Windows.Forms.Button()
        Me.lstOutput = New System.Windows.Forms.ListBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.prgBar = New System.Windows.Forms.ProgressBar()
        Me.fbdMain = New System.Windows.Forms.FolderBrowserDialog()
        Me.nicMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.bgDupes = New System.ComponentModel.BackgroundWorker()
        Me.chkNewSongs = New System.Windows.Forms.CheckBox()
        Me.chkOrphans = New System.Windows.Forms.CheckBox()
        Me.chkDupilcates = New System.Windows.Forms.CheckBox()
        Me.bgFiles = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'lblPerc
        '
        Me.lblPerc.BackColor = System.Drawing.Color.Transparent
        Me.lblPerc.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPerc.ForeColor = System.Drawing.Color.Black
        Me.lblPerc.Location = New System.Drawing.Point(11, 375)
        Me.lblPerc.Name = "lblPerc"
        Me.lblPerc.Size = New System.Drawing.Size(62, 15)
        Me.lblPerc.TabIndex = 67
        Me.lblPerc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(125, 375)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(241, 15)
        Me.lblStatus.TabIndex = 64
        Me.lblStatus.Text = "huh?"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnRun
        '
        Me.btnRun.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRun.Location = New System.Drawing.Point(10, 213)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(38, 22)
        Me.btnRun.TabIndex = 59
        Me.btnRun.Text = "Run!"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'btnDialog
        '
        Me.btnDialog.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDialog.Location = New System.Drawing.Point(54, 213)
        Me.btnDialog.Name = "btnDialog"
        Me.btnDialog.Size = New System.Drawing.Size(68, 22)
        Me.btnDialog.TabIndex = 58
        Me.btnDialog.Text = "Directory..."
        Me.btnDialog.UseVisualStyleBackColor = True
        '
        'lstOutput
        '
        Me.lstOutput.BackColor = System.Drawing.Color.White
        Me.lstOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstOutput.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstOutput.ForeColor = System.Drawing.Color.Black
        Me.lstOutput.FormattingEnabled = True
        Me.lstOutput.Location = New System.Drawing.Point(10, 240)
        Me.lstOutput.Name = "lstOutput"
        Me.lstOutput.Size = New System.Drawing.Size(356, 119)
        Me.lstOutput.TabIndex = 66
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.ForeColor = System.Drawing.Color.Black
        Me.txtPath.Location = New System.Drawing.Point(128, 213)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(238, 21)
        Me.txtPath.TabIndex = 63
        '
        'prgBar
        '
        Me.prgBar.Location = New System.Drawing.Point(10, 356)
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(356, 18)
        Me.prgBar.Step = 1
        Me.prgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgBar.TabIndex = 65
        '
        'nicMain
        '
        Me.nicMain.Icon = CType(resources.GetObject("nicMain.Icon"), System.Drawing.Icon)
        Me.nicMain.Text = "iTunes Tools from DBC"
        '
        'Timer3
        '
        Me.Timer3.Interval = 500
        '
        'bgDupes
        '
        Me.bgDupes.WorkerReportsProgress = True
        '
        'chkNewSongs
        '
        Me.chkNewSongs.BackColor = System.Drawing.Color.Transparent
        Me.chkNewSongs.Checked = True
        Me.chkNewSongs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNewSongs.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNewSongs.ForeColor = System.Drawing.Color.Black
        Me.chkNewSongs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkNewSongs.Location = New System.Drawing.Point(7, 107)
        Me.chkNewSongs.Name = "chkNewSongs"
        Me.chkNewSongs.Padding = New System.Windows.Forms.Padding(3)
        Me.chkNewSongs.Size = New System.Drawing.Size(358, 49)
        Me.chkNewSongs.TabIndex = 62
        Me.chkNewSongs.Text = "Browse folder for any new files not already added to iTunes. This will match all " & _
            "songs in iTunes with your music library. Any songs not matched will then be adde" & _
            "d to iTunes without duplicate entries!"
        Me.chkNewSongs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chkNewSongs.UseVisualStyleBackColor = False
        '
        'chkOrphans
        '
        Me.chkOrphans.BackColor = System.Drawing.Color.Transparent
        Me.chkOrphans.Checked = True
        Me.chkOrphans.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOrphans.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOrphans.ForeColor = System.Drawing.Color.Black
        Me.chkOrphans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkOrphans.Location = New System.Drawing.Point(7, 65)
        Me.chkOrphans.Name = "chkOrphans"
        Me.chkOrphans.Padding = New System.Windows.Forms.Padding(3)
        Me.chkOrphans.Size = New System.Drawing.Size(358, 42)
        Me.chkOrphans.TabIndex = 60
        Me.chkOrphans.Text = "Check for orphaned files or files with no source. This will remove any entries in" & _
            " iTunes without a music file behind it. (Recommended)"
        Me.chkOrphans.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chkOrphans.UseVisualStyleBackColor = False
        '
        'chkDupilcates
        '
        Me.chkDupilcates.BackColor = System.Drawing.Color.Transparent
        Me.chkDupilcates.Checked = True
        Me.chkDupilcates.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDupilcates.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.chkDupilcates.Location = New System.Drawing.Point(10, 164)
        Me.chkDupilcates.Name = "chkDupilcates"
        Me.chkDupilcates.Size = New System.Drawing.Size(355, 43)
        Me.chkDupilcates.TabIndex = 68
        Me.chkDupilcates.Text = "Also check for duplicate entries and remove the extras. The oldest/smallest/lowes" & _
            "t quality of any song in your iTunes library more than once will be removed. (Re" & _
            "commended)"
        Me.chkDupilcates.UseVisualStyleBackColor = False
        '
        'bgFiles
        '
        '
        'frmClean
        '
        Me.BackgroundImage = Global.iTunesAssistant.My.Resources.Resources.gui_dark
        Me.ClientSize = New System.Drawing.Size(379, 392)
        Me.Controls.Add(Me.chkDupilcates)
        Me.Controls.Add(Me.prgBar)
        Me.Controls.Add(Me.chkNewSongs)
        Me.Controls.Add(Me.lblPerc)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.chkOrphans)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.btnDialog)
        Me.Controls.Add(Me.lstOutput)
        Me.Controls.Add(Me.txtPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmClean"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cleanup iTunes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkNewSongs As System.Windows.Forms.CheckBox
    Friend WithEvents lblPerc As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents chkOrphans As System.Windows.Forms.CheckBox
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnDialog As System.Windows.Forms.Button
    Friend WithEvents lstOutput As System.Windows.Forms.ListBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents prgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents fbdMain As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents nicMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents bgDupes As System.ComponentModel.BackgroundWorker
    Friend WithEvents chkDupilcates As System.Windows.Forms.CheckBox
    Friend WithEvents bgFiles As System.ComponentModel.BackgroundWorker
End Class
