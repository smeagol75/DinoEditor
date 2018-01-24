Imports Db_Xbox_editor
Imports System


Public Class Select_a_Glove

    Private Sub Select_a_Glove_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Clear()
        For i = 0 To Form1.DataGridView_gloves.Rows.Count - 1
            DataGridView1.Rows.Add(Form1.DataGridView_gloves.Rows(i).Cells(0).Value, Form1.DataGridView_gloves.Rows(i).Cells(3).Value)
        Next


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Db_Xbox_editor.Form1.Show()
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Db_Xbox_editor.Form1.Player_Gloves_Id_box.Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        Db_Xbox_editor.Form1.TextBox_player_gloves_name.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
        Db_Xbox_editor.Form1.Show()
        Me.Close()
    End Sub

End Class