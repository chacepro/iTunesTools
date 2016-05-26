Public Class frmUserInfo

    Private Sub frmUserInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tw As New TwitterVB2.TwitterAPI
        tw.AuthenticateWith(My.Settings.ConsumerKey, My.Settings.ConsumerSecret, My.Settings.Token, My.Settings.TokenSecret)
        Dim MyAccountInfo As TwitterVB2.TwitterUser = tw.AccountInformation
        lblUser.Text = MyAccountInfo.ScreenName()
        lblName.text = MyAccountInfo.Name()
        lblFollowers.Text = MyAccountInfo.FollowersCount
        lblFriends.Text = MyAccountInfo.FriendsCount
        lblTweets.Text = MyAccountInfo.StatusesCount
        lblCreated.text = MyAccountInfo.CreatedAtLocalTime
        lblStatus.Text = MyAccountInfo.Status.Text
        lblDesc.text = MyAccountInfo.Description
        lblLocation.text = MyAccountInfo.Location
        lblTZ.text = MyAccountInfo.TimeZone
    End Sub
End Class