Public Class Select_Nationality_for_Coach

    Private Sub Select_Nationality_for_Coach_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For i = 0 To Db_Xbox_editor.Form1.DataGridView_Countries.Rows.Count - 1
            DataGridView1.Rows.Add(Db_Xbox_editor.Form1.DataGridView_Countries.Rows(i).Cells(0).Value, Db_Xbox_editor.Form1.DataGridView_Countries.Rows(i).Cells(1).Value, Db_Xbox_editor.Form1.DataGridView_Countries.Rows(i).Cells(2).Value)
        Next

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Db_Xbox_editor.Form1.Show()
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Db_Xbox_editor.Form1.TextNAtion_COach_sel.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        Form1.Label58.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value

        Db_Xbox_editor.Form1.Show()
        Me.Close()
    End Sub
End Class