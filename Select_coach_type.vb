Public Class Select_coach_type

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Select Case ComboBox1.SelectedIndex
            Case 0

                Form1.Text_COach_type.Text = 0

            Case 1
                Form1.Text_COach_type.Text = 1
            Case 2
                Form1.Text_COach_type.Text = 2
            Case 3
                Form1.Text_COach_type.Text = 3
            Case 4
                Form1.Text_COach_type.Text = 4
            Case 5
                Form1.Text_COach_type.Text = 5
            Case 6
                Form1.Text_COach_type.Text = 6

            Case Else
                MsgBox("Not recognized sorry")

        End Select



        

        Form1.Show()

        Me.Hide()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()

    End Sub
End Class