Imports Db_Xbox_editor


Public Class Select_a_Player

    Private Sub Select_a_Player_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ComboBox1.Items.Clear()
        ComboBox1.Text = ""

        Form1.TextBox_aux_player.Clear()
        For i = 0 To 10
            ComboBox1.Items.Add(Form1.DataGridView_playersOfTeam.Rows(i).Cells(1).Value)
        Next


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If MsgBox("Do you want To Select : " & ComboBox1.SelectedItem.ToString & " ?", MsgBoxStyle.YesNo, "Add Team") = MsgBoxResult.Yes Then
            Form1.TextBox_aux_player.Text = ComboBox1.SelectedItem.ToString
            Me.Close()
            Form1.Show()

        End If
    End Sub



   
End Class