<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtTweet = New System.Windows.Forms.TextBox()
        Me.btnAuth = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.lblChars = New System.Windows.Forms.Label()
        Me.txtPreName = New System.Windows.Forms.TextBox()
        Me.txtPreGenre = New System.Windows.Forms.TextBox()
        Me.txtPreArtist = New System.Windows.Forms.TextBox()
        Me.txtPreAlbum = New System.Windows.Forms.TextBox()
        Me.txtPreBit = New System.Windows.Forms.TextBox()
        Me.txtPreExtra = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.cb1 = New System.Windows.Forms.CheckBox()
        Me.cb2 = New System.Windows.Forms.CheckBox()
        Me.cb3 = New System.Windows.Forms.CheckBox()
        Me.cb4 = New System.Windows.Forms.CheckBox()
        Me.cb5 = New System.Windows.Forms.CheckBox()
        Me.cb6 = New System.Windows.Forms.CheckBox()
        Me.lblSongName = New System.Windows.Forms.Label()
        Me.lblArtistName = New System.Windows.Forms.Label()
        Me.lblAlbumName = New System.Windows.Forms.Label()
        Me.cbAuto = New System.Windows.Forms.CheckBox()
        Me.lblBitRate = New System.Windows.Forms.Label()
        Me.lblGenre = New System.Windows.Forms.Label()
        Me.txtExtra = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.tmrClear = New System.Windows.Forms.Timer(Me.components)
        Me.btnUser = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtTweet
        '
        Me.txtTweet.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTweet.Location = New System.Drawing.Point(3, 274)
        Me.txtTweet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTweet.Multiline = True
        Me.txtTweet.Name = "txtTweet"
        Me.txtTweet.Size = New System.Drawing.Size(455, 62)
        Me.txtTweet.TabIndex = 0
        '
        'btnAuth
        '
        Me.btnAuth.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAuth.Location = New System.Drawing.Point(291, 346)
        Me.btnAuth.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAuth.Name = "btnAuth"
        Me.btnAuth.Size = New System.Drawing.Size(93, 25)
        Me.btnAuth.TabIndex = 1
        Me.btnAuth.Text = "Login"
        Me.btnAuth.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(392, 346)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 25)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Tweet!"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Enabled = True
        Me.tmrRefresh.Interval = 500
        '
        'lblChars
        '
        Me.lblChars.AutoSize = True
        Me.lblChars.BackColor = System.Drawing.Color.Transparent
        Me.lblChars.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChars.Location = New System.Drawing.Point(3, 255)
        Me.lblChars.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChars.Name = "lblChars"
        Me.lblChars.Size = New System.Drawing.Size(29, 17)
        Me.lblChars.TabIndex = 9
        Me.lblChars.Text = "140"
        Me.lblChars.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPreName
        '
        Me.txtPreName.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreName.Location = New System.Drawing.Point(31, 37)
        Me.txtPreName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPreName.Name = "txtPreName"
        Me.txtPreName.Size = New System.Drawing.Size(124, 24)
        Me.txtPreName.TabIndex = 15
        Me.txtPreName.Text = "« #NowPlaying |"
        Me.txtPreName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPreGenre
        '
        Me.txtPreGenre.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreGenre.Location = New System.Drawing.Point(31, 170)
        Me.txtPreGenre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPreGenre.Name = "txtPreGenre"
        Me.txtPreGenre.Size = New System.Drawing.Size(124, 24)
        Me.txtPreGenre.TabIndex = 16
        Me.txtPreGenre.Text = "| Genre:"
        Me.txtPreGenre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPreArtist
        '
        Me.txtPreArtist.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreArtist.Location = New System.Drawing.Point(31, 70)
        Me.txtPreArtist.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPreArtist.Name = "txtPreArtist"
        Me.txtPreArtist.Size = New System.Drawing.Size(124, 24)
        Me.txtPreArtist.TabIndex = 17
        Me.txtPreArtist.Text = "|"
        Me.txtPreArtist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPreAlbum
        '
        Me.txtPreAlbum.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreAlbum.Location = New System.Drawing.Point(31, 103)
        Me.txtPreAlbum.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPreAlbum.Name = "txtPreAlbum"
        Me.txtPreAlbum.Size = New System.Drawing.Size(124, 24)
        Me.txtPreAlbum.TabIndex = 18
        Me.txtPreAlbum.Text = "| Album: "
        Me.txtPreAlbum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPreBit
        '
        Me.txtPreBit.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreBit.Location = New System.Drawing.Point(31, 137)
        Me.txtPreBit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPreBit.Name = "txtPreBit"
        Me.txtPreBit.Size = New System.Drawing.Size(124, 24)
        Me.txtPreBit.TabIndex = 19
        Me.txtPreBit.Text = "| BitRate:"
        Me.txtPreBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPreExtra
        '
        Me.txtPreExtra.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreExtra.Location = New System.Drawing.Point(31, 203)
        Me.txtPreExtra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPreExtra.Name = "txtPreExtra"
        Me.txtPreExtra.Size = New System.Drawing.Size(124, 24)
        Me.txtPreExtra.TabIndex = 20
        Me.txtPreExtra.Text = "»"
        Me.txtPreExtra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(308, 236)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(79, 28)
        Me.btnUpdate.TabIndex = 22
        Me.btnUpdate.Text = "Update..."
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'cb1
        '
        Me.cb1.AutoSize = True
        Me.cb1.BackColor = System.Drawing.Color.Transparent
        Me.cb1.Checked = True
        Me.cb1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb1.Location = New System.Drawing.Point(7, 42)
        Me.cb1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(18, 17)
        Me.cb1.TabIndex = 23
        Me.cb1.UseVisualStyleBackColor = False
        '
        'cb2
        '
        Me.cb2.AutoSize = True
        Me.cb2.BackColor = System.Drawing.Color.Transparent
        Me.cb2.Checked = True
        Me.cb2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb2.Location = New System.Drawing.Point(7, 75)
        Me.cb2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(18, 17)
        Me.cb2.TabIndex = 24
        Me.cb2.UseVisualStyleBackColor = False
        '
        'cb3
        '
        Me.cb3.AutoSize = True
        Me.cb3.BackColor = System.Drawing.Color.Transparent
        Me.cb3.Location = New System.Drawing.Point(7, 107)
        Me.cb3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cb3.Name = "cb3"
        Me.cb3.Size = New System.Drawing.Size(18, 17)
        Me.cb3.TabIndex = 25
        Me.cb3.UseVisualStyleBackColor = False
        '
        'cb4
        '
        Me.cb4.AutoSize = True
        Me.cb4.BackColor = System.Drawing.Color.Transparent
        Me.cb4.Location = New System.Drawing.Point(7, 140)
        Me.cb4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cb4.Name = "cb4"
        Me.cb4.Size = New System.Drawing.Size(18, 17)
        Me.cb4.TabIndex = 26
        Me.cb4.UseVisualStyleBackColor = False
        '
        'cb5
        '
        Me.cb5.AutoSize = True
        Me.cb5.BackColor = System.Drawing.Color.Transparent
        Me.cb5.Location = New System.Drawing.Point(7, 174)
        Me.cb5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cb5.Name = "cb5"
        Me.cb5.Size = New System.Drawing.Size(18, 17)
        Me.cb5.TabIndex = 27
        Me.cb5.UseVisualStyleBackColor = False
        '
        'cb6
        '
        Me.cb6.AutoSize = True
        Me.cb6.BackColor = System.Drawing.Color.Transparent
        Me.cb6.Checked = True
        Me.cb6.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb6.Location = New System.Drawing.Point(7, 207)
        Me.cb6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cb6.Name = "cb6"
        Me.cb6.Size = New System.Drawing.Size(18, 17)
        Me.cb6.TabIndex = 28
        Me.cb6.UseVisualStyleBackColor = False
        '
        'lblSongName
        '
        Me.lblSongName.AutoSize = True
        Me.lblSongName.BackColor = System.Drawing.Color.Transparent
        Me.lblSongName.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSongName.ForeColor = System.Drawing.Color.Black
        Me.lblSongName.Location = New System.Drawing.Point(164, 42)
        Me.lblSongName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSongName.Name = "lblSongName"
        Me.lblSongName.Size = New System.Drawing.Size(45, 17)
        Me.lblSongName.TabIndex = 29
        Me.lblSongName.Text = "Label1"
        '
        'lblArtistName
        '
        Me.lblArtistName.AutoSize = True
        Me.lblArtistName.BackColor = System.Drawing.Color.Transparent
        Me.lblArtistName.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArtistName.ForeColor = System.Drawing.Color.Black
        Me.lblArtistName.Location = New System.Drawing.Point(164, 74)
        Me.lblArtistName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArtistName.Name = "lblArtistName"
        Me.lblArtistName.Size = New System.Drawing.Size(45, 17)
        Me.lblArtistName.TabIndex = 30
        Me.lblArtistName.Text = "Label1"
        '
        'lblAlbumName
        '
        Me.lblAlbumName.AutoSize = True
        Me.lblAlbumName.BackColor = System.Drawing.Color.Transparent
        Me.lblAlbumName.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlbumName.ForeColor = System.Drawing.Color.Black
        Me.lblAlbumName.Location = New System.Drawing.Point(164, 107)
        Me.lblAlbumName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlbumName.Name = "lblAlbumName"
        Me.lblAlbumName.Size = New System.Drawing.Size(45, 17)
        Me.lblAlbumName.TabIndex = 31
        Me.lblAlbumName.Text = "Label1"
        '
        'cbAuto
        '
        Me.cbAuto.AutoSize = True
        Me.cbAuto.BackColor = System.Drawing.Color.Transparent
        Me.cbAuto.Checked = True
        Me.cbAuto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAuto.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAuto.Location = New System.Drawing.Point(395, 241)
        Me.cbAuto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbAuto.Name = "cbAuto"
        Me.cbAuto.Size = New System.Drawing.Size(57, 21)
        Me.cbAuto.TabIndex = 32
        Me.cbAuto.Text = "Auto"
        Me.cbAuto.UseVisualStyleBackColor = False
        '
        'lblBitRate
        '
        Me.lblBitRate.AutoSize = True
        Me.lblBitRate.BackColor = System.Drawing.Color.Transparent
        Me.lblBitRate.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBitRate.Location = New System.Drawing.Point(164, 142)
        Me.lblBitRate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBitRate.Name = "lblBitRate"
        Me.lblBitRate.Size = New System.Drawing.Size(45, 17)
        Me.lblBitRate.TabIndex = 33
        Me.lblBitRate.Text = "Label1"
        '
        'lblGenre
        '
        Me.lblGenre.AutoSize = True
        Me.lblGenre.BackColor = System.Drawing.Color.Transparent
        Me.lblGenre.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGenre.Location = New System.Drawing.Point(164, 174)
        Me.lblGenre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGenre.Name = "lblGenre"
        Me.lblGenre.Size = New System.Drawing.Size(45, 17)
        Me.lblGenre.TabIndex = 34
        Me.lblGenre.Text = "Label1"
        '
        'txtExtra
        '
        Me.txtExtra.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExtra.Location = New System.Drawing.Point(168, 203)
        Me.txtExtra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtExtra.Name = "txtExtra"
        Me.txtExtra.Size = New System.Drawing.Size(287, 24)
        Me.txtExtra.TabIndex = 35
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(39, 346)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 25)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Clean"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblInfo.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Firebrick
        Me.lblInfo.Location = New System.Drawing.Point(188, 351)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(0, 17)
        Me.lblInfo.TabIndex = 38
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrClear
        '
        Me.tmrClear.Interval = 5000
        '
        'btnUser
        '
        Me.btnUser.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUser.Location = New System.Drawing.Point(308, 4)
        Me.btnUser.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(151, 23)
        Me.btnUser.TabIndex = 39
        Me.btnUser.Text = "-"
        Me.btnUser.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(7, 346)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(24, 25)
        Me.Button3.TabIndex = 40
        Me.Button3.Text = "?"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.iTunesAssistant.My.Resources.Resources.gui_dark
        Me.ClientSize = New System.Drawing.Size(463, 378)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnUser)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtExtra)
        Me.Controls.Add(Me.lblGenre)
        Me.Controls.Add(Me.lblBitRate)
        Me.Controls.Add(Me.cbAuto)
        Me.Controls.Add(Me.lblAlbumName)
        Me.Controls.Add(Me.lblArtistName)
        Me.Controls.Add(Me.lblSongName)
        Me.Controls.Add(Me.cb6)
        Me.Controls.Add(Me.cb5)
        Me.Controls.Add(Me.cb4)
        Me.Controls.Add(Me.cb3)
        Me.Controls.Add(Me.cb2)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtPreExtra)
        Me.Controls.Add(Me.txtPreBit)
        Me.Controls.Add(Me.txtPreAlbum)
        Me.Controls.Add(Me.txtPreArtist)
        Me.Controls.Add(Me.txtPreGenre)
        Me.Controls.Add(Me.txtPreName)
        Me.Controls.Add(Me.lblChars)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnAuth)
        Me.Controls.Add(Me.txtTweet)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "iTunes Assistant"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTweet As System.Windows.Forms.TextBox
    Friend WithEvents btnAuth As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents lblChars As System.Windows.Forms.Label
    Friend WithEvents txtPreName As System.Windows.Forms.TextBox
    Friend WithEvents txtPreGenre As System.Windows.Forms.TextBox
    Friend WithEvents txtPreArtist As System.Windows.Forms.TextBox
    Friend WithEvents txtPreAlbum As System.Windows.Forms.TextBox
    Friend WithEvents txtPreBit As System.Windows.Forms.TextBox
    Friend WithEvents txtPreExtra As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents cb1 As System.Windows.Forms.CheckBox
    Friend WithEvents cb2 As System.Windows.Forms.CheckBox
    Friend WithEvents cb3 As System.Windows.Forms.CheckBox
    Friend WithEvents cb4 As System.Windows.Forms.CheckBox
    Friend WithEvents cb5 As System.Windows.Forms.CheckBox
    Friend WithEvents cb6 As System.Windows.Forms.CheckBox
    Friend WithEvents lblSongName As System.Windows.Forms.Label
    Friend WithEvents lblArtistName As System.Windows.Forms.Label
    Friend WithEvents lblAlbumName As System.Windows.Forms.Label
    Friend WithEvents cbAuto As System.Windows.Forms.CheckBox
    Friend WithEvents lblBitRate As System.Windows.Forms.Label
    Friend WithEvents lblGenre As System.Windows.Forms.Label
    Friend WithEvents txtExtra As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents tmrClear As System.Windows.Forms.Timer
    Friend WithEvents btnUser As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
