Public Class frmMain

    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuth.Click
        Dim tw As New TwitterVB2.TwitterAPI
        Dim Url As String = tw.GetAuthorizationLink(My.Settings.ConsumerKey, My.Settings.ConsumerSecret)
        Dim Temp = CreateObject("InternetExplorer.Application")

        'Open URL
        Temp.Navigate2(Url)
        Temp.Visible = True

        '3646833
        Dim PinNumber = InputBox("Please fill in your credentials on the Twitter login and then enter the acceptance PIN below.", "Enter Twitter PIN")
        Dim IsValid As Boolean = tw.ValidatePIN(PinNumber)
        If IsValid Then
            Dim Mus = New My.MySettings()
            My.Settings.Token = tw.OAuth_Token()
            My.Settings.TokenSecret = tw.OAuth_TokenSecret()
            My.Settings.Save()
            MsgBox("Authorization complete!")
            UpdateUserInfo()
        Else
            MsgBox("Invalid PIN!")
            UpdateUserInfo()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If My.Settings.Token.Length > 0 Then
                Dim tw As New TwitterVB2.TwitterAPI
                tw.AuthenticateWith(My.Settings.ConsumerKey, My.Settings.ConsumerSecret, My.Settings.Token, My.Settings.TokenSecret)
                tw.Update(txtTweet.Text)
                lblInfo.Text = "Update sent."
                tmrClear.Enabled = True
            Else
                MsgBox("Account authorization not found!!")
            End If
        Catch ex As TwitterAPIException
            If (InStr(ex.ToString, "Forbidden")) Then
                MsgBox("There was a problem... Most likely this is a duplicate tweet. If this isn't the case, try again.")
            Else
                MsgBox(ex.Message & vbCrLf & vbCrLf & ex.ToString)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'UpdateUserInfo()

    End Sub

    Private Sub UpdateUserInfo()
        Dim tw As New TwitterVB2.TwitterAPI
        tw.AuthenticateWith(My.Settings.ConsumerKey, My.Settings.ConsumerSecret, My.Settings.Token, My.Settings.TokenSecret)
        Dim MyAccountInfo As TwitterVB2.TwitterUser = tw.AccountInformation
        btnUser.Text = "@" & MyAccountInfo.ScreenName()
        btnAuth.Text = "Change User"
    End Sub

    Private Sub UpdateCurrentSong()
        Dim iTunesLib, Track
        iTunesLib = CreateObject("iTunes.Application")
        'Find the current track
        Track = iTunesLib.CurrentTrack
        If Track Is Nothing Then
            lblSongName.Text = "no track playing"
            lblArtistName.Text = ""
            lblAlbumName.Text = ""
            lblBitRate.Text = ""
            lblGenre.Text = ""
        Else
            lblSongName.Text = Track.Name
            lblArtistName.Text = Track.Artist
            lblAlbumName.Text = Track.Album
            lblBitRate.Text = Track.BitRate & " KBPS"
            lblGenre.Text = Track.Genre
        End If
    End Sub

    Private Sub UpdateTweetBox()
        Dim tmpText As String = ""
        If cb1.Checked = True Then
            tmpText = txtPreName.Text & " " & lblSongName.Text & " "
        End If
        If cb2.Checked = True Then
            tmpText = tmpText & txtPreArtist.Text & " " & lblArtistName.Text & " "
        End If
        If cb3.Checked = True Then
            tmpText = tmpText & txtPreAlbum.Text & " " & lblAlbumName.Text & " "
        End If
        If cb4.Checked = True Then
            tmpText = tmpText & txtPreBit.Text & " " & lblBitRate.Text & " "
        End If
        If cb5.Checked = True Then
            tmpText = tmpText & txtPreGenre.Text & " " & lblGenre.Text & " "
        End If
        If cb6.Checked = True Then
            tmpText = tmpText & txtPreExtra.Text & " " & txtExtra.Text
        End If
        txtTweet.Text = tmpText
    End Sub

    Private Sub tmrRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefresh.Tick
        lblChars.Text = (140 - txtTweet.TextLength)
        UpdateCurrentSong()
        If cbAuto.Checked = True Then
            UpdateTweetBox()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        UpdateTweetBox()
    End Sub

    Private Sub cbAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAuto.CheckedChanged
        If cbAuto.Checked = True Then
            btnUpdate.Enabled = False
        Else
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmClean.Show()
    End Sub

    Private Sub tmrClear_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrClear.Tick
        lblInfo.Text = ""
        tmrClear.Enabled = False
    End Sub

    Private Sub btnUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUser.Click
        frmUserInfo.Show()

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmAbout.Show()
    End Sub

    Private Sub bgWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        frmClean.ShowDialog()
    End Sub
End Class