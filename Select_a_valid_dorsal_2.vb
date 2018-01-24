
Imports Db_Xbox_editor

Public Class Select_a_valid_dorsal_2




    Private Sub Select_a_valid_dorsal_2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load




        Label1.Text = "Number of " + Form1.ListBox1.SelectedItem
        Label2.Text = " for " + Form1.TextBox_team_name_2.Text
        If Form1.NumericDorsal_2.Value <> 0 Then
            NumericUpDown1.Value = Form1.NumericDorsal_2.Value
        End If

        Label3.Text = "FREE DORSAL"
        Label3.BackColor = Color.Green
        For i = 0 To Form1.DataGridView_playersOfTeam.RowCount - 1
            If NumericUpDown1.Value = Form1.DataGridView_playersOfTeam.Rows(i).Cells(2).Value() Then
                Label3.Text = "USED DORSAL"
                Label3.BackColor = Color.Red
            End If
        Next

        NumericUpDown1.Value = 1

        Do While Label3.Text <> "FREE DORSAL"
            NumericUpDown1.Value = NumericUpDown1.Value + 1
        Loop

    End Sub
    Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Label3.Text = "FREE DORSAL"
        Label3.BackColor = Color.Green
        For i = 0 To Form1.DataGridView_playersOfTeam.RowCount - 1
            If NumericUpDown1.Value = Form1.DataGridView_playersOfTeam.Rows(i).Cells(2).Value() Then
                Label3.Text = "USED DORSAL"
                Label3.BackColor = Color.Red
            End If
        Next



    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Label3.Text = "FREE DORSAL" Then
            Form1.NumericDorsal_2.Value = NumericUpDown1.Value
            Me.Close()
        Else
            MsgBox("Select a free Dorsal!!!!")
        End If
    End Sub
End Class
