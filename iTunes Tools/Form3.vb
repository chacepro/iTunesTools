Public Class frmUserInfo

    Private Sub frmUserInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tw As New TwitterVB2.TwitterAPI
        tw.AuthenticateWith(My.Settings.ConsumerKey, My.Settings.ConsumerSecret, My.Settings.Token, My.Settings.TokenSecret)
        If My.Settings.Token = "" And My.Settings.TokenSecret = "" Then
            lblUser.Text = "None"
            lblName.Text = ""
            lblFollowers.Text = ""
            lblFriends.Text = ""
            lblTweets.Text = ""
            lblCreated.Text = ""
            lblStatus.Text = ""
            lblDesc.Text = ""
            lblLocation.Text = ""
            lblTZ.Text = ""
        Else
            Dim MyAccountInfo As TwitterVB2.TwitterUser = tw.AccountInformation
            lblUser.Text = MyAccountInfo.ScreenName()
            lblName.Text = MyAccountInfo.Name()
            lblFollowers.Text = MyAccountInfo.FollowersCount
            lblFriends.Text = MyAccountInfo.FriendsCount
            lblTweets.Text = MyAccountInfo.StatusesCount
            lblCreated.Text = MyAccountInfo.CreatedAtLocalTime
            lblStatus.Text = MyAccountInfo.Status.Text
            lblDesc.Text = MyAccountInfo.Description
            lblLocation.Text = MyAccountInfo.Location
            lblTZ.Text = MyAccountInfo.TimeZone
        End If
    End Sub
End Class