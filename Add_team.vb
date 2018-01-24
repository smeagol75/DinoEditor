Public Class Add_team

    Private Sub Add_team_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim equipo_a_clonar As New Team
        equipo_a_clonar.Leer_valores(Form1.ListBox3.SelectedIndex)
        Dim indice_coach_a_clonar As UInt32 = 0
        Dim indice_slot_tactic1_a_clonar As UInt32 = Form1.NumericUpDownSlot_tact_1.Value
        Dim indice_slot_tactic2_a_clonar As UInt32 = Form1.NumericUpDownSlot_tact_2.Value
        Form1.Leer_Tactics_formation.BaseStream.Position = 4
        Dim slot_formation_a_añadir1 As UInt16 = Form1.Leer_Tactics_formation.ReadUInt16 + 1
        Dim slot_formation_a_añadir2 As UInt16 = slot_formation_a_añadir1 + 1


        New_team_Id_box.Value = Form1.Id_de_equipo_max + 1
        Dim New_coachId As UInt32 = 1
        For i = 0 To Form1.DataGridView_coach.Rows.Count - 1
            If Form1.DataGridView_coach.Rows(i).Cells(0).Value > New_coachId Then
                New_coachId = Form1.DataGridView_coach.Rows(i).Cells(0).Value + 1
            End If
        Next
        For i = 0 To Form1.DataGridView_coach.Rows.Count - 1
            If Form1.DataGridView_coach.Rows(i).Cells(0).Value = equipo_a_clonar.Coach Then
                indice_coach_a_clonar = i
            End If
        Next




    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim New_team(Team.tamanho_bloque) As Byte
        New_team = Form1.Leer_Team.ReadBytes(Team.tamanho_bloque)
        Dim posicion_para_grabar As UInteger = Form1.unzlib_Team.Length
        Form1.unzlib_Team.SetLength(Form1.unzlib_Team.Length + New_team.Length)
        Form1.unzlib_Team.Position = posicion_para_grabar
        Form1.unzlib_Team.Write(New_team, 0, New_team.Length)
        Form1.Leer_Team.BaseStream.Position = posicion_para_grabar + 8

        Form1.index_de_equipo_max += 1
        Form1.Id_de_equipo_max += 1

        Form1.Grabar_Team.Write(swaps.swap32(Form1.Id_de_equipo_max))
        'Grabar_Team.Write(swaps.swap16(Id_de_equipo_max))
        'Grabar_Team.Write(swaps.swap16(Id_de_equipo_max))

        Form1.DataGridView_TEAM.Rows.Add(Form1.index_de_equipo_max, Form1.Id_de_equipo_max, "ADDED", 10)
        Form1.ListBox3.Items.Add("ADDED TEAM")
        'Dim test As FileStream = New FileStream("C:\Users\Public\Desktop\test.u", FileMode.OpenOrCreate, FileAccess.Write)
        'unzlib_Team.Position = 0

        'unzlib_Team.CopyTo(test)
        ' test.Close()

        'ComboBox1_Click(ComboBox1, Nothing)
        MsgBox("Team Added succesfully qith Id: " + Form1.Id_de_equipo_max.ToString + vbCrLf + "Change Name and desired Options :) ")
        Form1.ListBox3.SelectedIndex = Form1.ListBox3.Items.Count - 1
    End Sub
End Class