Imports Db_Xbox_editor
Imports System


Public Class Search_player_by

    Private Sub Search_player_by_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        For i = 0 To Form1.ListBox1.Items.Count - 1
            Dim PLAY_A_BUSCAR As New Player
            PLAY_A_BUSCAR.Leer_valores_sin_pantalla(i)
            PLAY_A_BUSCAR.leer_player_assig_sin_pantalla()
            DataGridView1.Rows.Add(i, PLAY_A_BUSCAR.Player_ID, PLAY_A_BUSCAR.Nom_Jugador_shirt, PLAY_A_BUSCAR.Texto_Nacion, PLAY_A_BUSCAR.Texto_Nacionalizado, PLAY_A_BUSCAR.Team1, PLAY_A_BUSCAR.Team2)
        Next

        Form1.Cargando.Hide()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        'Db_Xbox_editor.Form1.Show()
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'Db_Xbox_editor.Form1.play_selected_index = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        Form1.ListBox1.SelectedIndex = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        Form1.TabControl1.SelectedTab = Form1.TabPage1
        Form1.Select()
        Form1.BringToFront()


        'Db_Xbox_editor.Form1.Show()
        'Me.Close()
    End Sub

End Class