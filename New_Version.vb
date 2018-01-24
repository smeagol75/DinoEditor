Public Class New_Version

    Public stringMega As String = ""
    Public StringDropbox As String = ""

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(stringMega)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start(StringDropbox)
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        System.Diagnostics.Process.Start("https://www.evo-web.co.uk/threads/dino-editor-2017-v-1-0-beta-26-09-16.76793/")
    End Sub

    Private Sub New_Version_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Dim objHttp As Object
            objHttp = CreateObject("MSXML2.XMLHTTP")
            objHttp.Open("GET", "https://u.jimcdn.com/e/o/sa7131c437043117e/userlayout/css/2017dp.css", False)
            objHttp.Send()
            StringDropbox = objHttp.ResponseText
            objHttp = Nothing
            objHttp = CreateObject("MSXML2.XMLHTTP")
            objHttp.Open("GET", "https://u.jimcdn.com/e/o/sa7131c437043117e/userlayout/css/2017mega.css", False)
            objHttp.Send()
            stringMega = objHttp.ResponseText

        Catch ex As Exception

        End Try
    End Sub
End Class