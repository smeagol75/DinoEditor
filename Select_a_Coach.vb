﻿Public Class Select_a_Coach

    Private Sub Select_a_Coach_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For i = 0 To Db_Xbox_editor.Form1.DataGridView_coach.Rows.Count - 2
            DataGridView1.Rows.Add(Db_Xbox_editor.Form1.DataGridView_coach.Rows(i).Cells(0).Value, Db_Xbox_editor.Form1.DataGridView_coach.Rows(i).Cells(1).Value)
        Next


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Db_Xbox_editor.Form1.Show()
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Db_Xbox_editor.Form1.Coach_elegido = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        Db_Xbox_editor.Form1.Show()
        Me.Close()
    End Sub

End Class