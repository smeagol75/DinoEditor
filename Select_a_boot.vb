Imports Db_Xbox_editor
Imports System


Public Class Select_a_boot

    Private Sub Select_a_boot_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Clear()

        For i = 0 To Form1.DataGridView_boots.Rows.Count - 1
            DataGridView1.Rows.Add(Form1.DataGridView_boots.Rows(i).Cells(0).Value, Db_Xbox_editor.Form1.DataGridView_boots.Rows(i).Cells(4).Value)
        Next


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Db_Xbox_editor.Form1.Show()
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Db_Xbox_editor.Form1.Player_boots_Id_box.Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        Db_Xbox_editor.Form1.TextBox_player_boots_name.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
        Db_Xbox_editor.Form1.Show()
        Me.Close()
    End Sub

End Class