
Imports Db_Xbox_editor

Public Class Select_a_valid_dorsal_Team




    Private Sub Select_a_valid_dorsal_Team_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load




        Label1.Text = "Number of " + Form1.DataGridView_playersOfTeam.Rows(Form1.DataGridView_playersOfTeam.CurrentRow.Index).Cells(1).Value.ToString
        Label2.Text = " for " + Form1.TextBox_Team_Na.Text
        If Form1.DataGridView_playersOfTeam.Rows(Form1.DataGridView_playersOfTeam.CurrentRow.Index).Cells(2).Value <> 0 Then
            NumericUpDown1.Value = Form1.DataGridView_playersOfTeam.Rows(Form1.DataGridView_playersOfTeam.CurrentRow.Index).Cells(2).Value
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
            Form1.DataGridView_playersOfTeam.Rows(Form1.DataGridView_playersOfTeam.CurrentRow.Index).Cells(2).Value = NumericUpDown1.Value
            Me.Close()
        Else

            If MsgBox("Do you want To use used dorsal : " & NumericUpDown1.Value.ToString & " to interchange ?", MsgBoxStyle.YesNo, "Change number") = MsgBoxResult.Yes Then
                Dim aux As UInt32 = Form1.DataGridView_playersOfTeam.Rows(Form1.DataGridView_playersOfTeam.CurrentRow.Index).Cells(2).Value
                For i = 0 To Form1.DataGridView_playersOfTeam.Rows.Count - 1
                    If NumericUpDown1.Value = Form1.DataGridView_playersOfTeam.Rows(i).Cells(2).Value Then
                        Form1.DataGridView_playersOfTeam.Rows(i).Cells(2).Value = aux
                    End If
                Next

                Form1.DataGridView_playersOfTeam.Rows(Form1.DataGridView_playersOfTeam.CurrentRow.Index).Cells(2).Value = NumericUpDown1.Value
                Me.Close()
            Else
                MsgBox("Select a free Dorsal!!!!")
            End If

        End If
    End Sub
End Class
