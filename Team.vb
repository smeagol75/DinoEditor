Imports Db_Xbox_editor
Imports System.IO
Imports System.Drawing

Public Class Team

    Public Index As UInt32
    Private Const Coach_pos As UInteger = 0
    Public Const Id_32_pos As UInteger = 8
    'Private Const Id_16_2_pos As UInteger = 6
    Private Const Stadium_16_pos As UInteger = 16
    Private Const Country_16_pos As UInteger = 20
    Private Const Tipo_equipo_byte_pos As UInteger = 21
    Private Const Licenciado_byte_pos As UInteger = 23
    Private Const coach_lic_byte_pos As UInteger = 22
    'Private Const byte_1 As UInteger = 22
    Private Const Order_in_league_16_pos As UInteger = 18
    Public Const Nombre_equipo_english_70Lenght_pos As UInteger = 234
    Public Const Nombre_corto_pos As UInteger = 748
    Public Const tamanho_bloque As UInteger = 1400


    Public Coach As UInt32
    Public Id_32 As UInt32
    ' Public Id_16_2 As UInt16
    Public Stadium_16 As UInteger
    Public Country_16 As UInt32
    Public Tipo_equipo_byte As Byte
    Public Licenciado_byte As Byte
    Public Nombre_equipo_english As String
    Public Nombre_Corto As String
    'Public byte_1_valor As UInteger
    Public Order_in_league_16 As UInt16
    Public coach_lic As Byte
    Public Order As UInt16
    Public League As UInt16

    Public Sub Leer_valores(ByVal selected_index As Integer)
        Index = selected_index * tamanho_bloque
        Form1.Leer_Team.BaseStream.Position = Index
        Coach = swaps.swap32(Form1.Leer_Team.ReadUInt32())
        Form1.Leer_Team.BaseStream.Position = Index + Id_32_pos
        Id_32 = swaps.swap32(Form1.Leer_Team.ReadUInt32())
        'Form1.Leer_Team.BaseStream.Position = Index + Id_32_pos
        'Id_32 = swaps.swap32(Form1.Leer_Team.ReadUInt32())
        'Form1.Leer_Team.BaseStream.Position = Index + Id_16_2_pos
        'Id_16_2 = swaps.swap16(Form1.Leer_Team.ReadUInt16())
        Form1.Leer_Team.BaseStream.Position = Index + Stadium_16_pos
        Stadium_16 = swaps.swap16(Form1.Leer_Team.ReadUInt16())


        ' Form1.Leer_Team.BaseStream.Position = Index + Country_16_pos

        ' Country_16 = swaps.swap16(Form1.Leer_Team.ReadUInt16())
        'If Form1.Tipo_consola = 0 Then
        'Country_16 = Country_16 << 7
        'Country_16 = Country_16 >> 7

        'Else

        'Country_16 = Country_16 >> 7


        'End If

        'Form1.Leer_Team.BaseStream.Position = Index + Tipo_equipo_byte_pos
        'Tipo_equipo_byte = Form1.Leer_Team.ReadByte

        'If Form1.Tipo_consola = 0 Then
        'Tipo_equipo_byte = Tipo_equipo_byte >> 1
        'Tipo_equipo_byte = Tipo_equipo_byte << 1
        'Else
        'Tipo_equipo_byte = Tipo_equipo_byte << 1
        'Tipo_equipo_byte = Tipo_equipo_byte >> 1
        'End If

        'Form1.Leer_Team.BaseStream.Position = Index + Licenciado_byte_pos
        'Licenciado_byte = Form1.Leer_Team.ReadByte
        'Form1.Leer_Team.BaseStream.Position = Index + coach_lic_byte_pos
        'coach_lic = Form1.Leer_Team.ReadByte

        Form1.Leer_Team.BaseStream.Position = Index + Country_16_pos

        Dim Valor_IMP_32 As UInt32 = Form1.Leer_Team.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Valor_IMP_32 = converter.bitworking_Team_toPc(swaps.swap32(Valor_IMP_32))
        End If

        Dim CHECK90 As UInt32 = Valor_IMP_32 >> 31
        If CHECK90 = 1 Then
            Form1.CheckBox90.Checked = True
        Else
            Form1.CheckBox90.Checked = False
        End If
        Dim CHECK91 As UInt32 = Valor_IMP_32 << 1
        CHECK91 = CHECK91 >> 31
        If CHECK91 = 1 Then
            Form1.CheckBox91.Checked = True
        Else
            Form1.CheckBox91.Checked = False
        End If
        Dim CHECK92 As UInt32 = Valor_IMP_32 << 2
        CHECK92 = CHECK92 >> 31
        If CHECK92 = 1 Then
            Form1.CheckBox92.Checked = True
        Else
            Form1.CheckBox92.Checked = False
        End If
        Dim CHECK93 As UInt32 = Valor_IMP_32 << 3
        CHECK93 = CHECK93 >> 31
        If CHECK93 = 1 Then
            Form1.CheckBox93.Checked = True
        Else
            Form1.CheckBox93.Checked = False
        End If
        Dim CHECK94 As UInt32 = Valor_IMP_32 << 4
        CHECK94 = CHECK94 >> 31
        If CHECK94 = 1 Then
            Form1.CheckBox94.Checked = True
        Else
            Form1.CheckBox94.Checked = False
        End If
        Dim CHECK95 As UInt32 = Valor_IMP_32 << 5
        CHECK95 = CHECK95 >> 31
        If CHECK95 = 1 Then
            Form1.CheckBox95.Checked = True
        Else
            Form1.CheckBox95.Checked = False
        End If
        Dim CHECK96 As UInt32 = Valor_IMP_32 << 6
        CHECK96 = CHECK96 >> 31
        If CHECK96 = 1 Then
            Form1.CheckBox96.Checked = True
        Else
            Form1.CheckBox96.Checked = False
        End If
        Dim CHECK97 As UInt32 = Valor_IMP_32 << 7
        CHECK97 = CHECK97 >> 31
        If CHECK97 = 1 Then
            Form1.CheckBox97.Checked = True
        Else
            Form1.CheckBox97.Checked = False
        End If
        Dim CHECK98 As UInt32 = Valor_IMP_32 << 8
        CHECK98 = CHECK98 >> 31
        If CHECK98 = 1 Then
            Form1.CheckBox98.Checked = True
        Else
            Form1.CheckBox98.Checked = False
        End If
        Dim CHECK99 As UInt32 = Valor_IMP_32 << 9
        CHECK99 = CHECK99 >> 31
        If CHECK99 = 1 Then
            Form1.CheckBox99.Checked = True
        Else
            Form1.CheckBox99.Checked = False
        End If
        Dim CHECK100 As UInt32 = Valor_IMP_32 << 10
        CHECK100 = CHECK100 >> 31
        If CHECK100 = 1 Then
            Form1.CheckBox100.Checked = True
        Else
            Form1.CheckBox100.Checked = False
        End If
        Dim CHECK101 As UInt32 = Valor_IMP_32 << 11
        CHECK101 = CHECK101 >> 31
        If CHECK101 = 1 Then
            Form1.CheckBox101.Checked = True
        Else
            Form1.CheckBox101.Checked = False
        End If
        Dim Gray As UInt32 = Valor_IMP_32 << 12
        Gray = Gray >> 30
        Form1.Gray_box.Value = Gray
        Dim Orange As UInt32 = Valor_IMP_32 << 14
        Orange = Orange >> 30
        Form1.Orange_box.Value = Orange
        Dim Pink As UInt32 = Valor_IMP_32 << 16
        Pink = Pink >> 29
        Form1.Pink_box.Value = Pink
        Dim Non_playable_team As UInt32 = Valor_IMP_32 << 19
        Non_playable_team = Non_playable_team >> 28
        Form1.Non_playable_team_box.Value = Non_playable_team
        Country_16 = Valor_IMP_32 << 23
        Country_16 = Country_16 >> 23
        Form1.Team_country_box.Text = Country_16.ToString

        Dim Position_sel As ULong
        Dim Position_team As ULong

        Select Case Form1.Language
            Case 1
                Position_sel = 24
                Position_team = 234
            Case 2
                Position_sel = 94
                Position_team = 234
            Case 3
                Position_sel = 164
                Position_team = 234
            Case 4
                Position_sel = 234
                Position_team = 234
            Case 5
                Position_sel = 94
                Position_team = 234
            Case 6
                Position_sel = 374
                Position_team = 234
            Case 7
                Position_sel = 444
                Position_team = 234
            Case 8
                Position_sel = 514
                Position_team = 234
            Case 9
                Position_sel = 584
                Position_team = 304
            Case 10
                Position_sel = 678
                Position_team = 234
            Case 11
                Position_sel = 758
                Position_team = 234
            Case 12
                Position_sel = 898
                Position_team = 234
            Case 13
                Position_sel = 1038
                Position_team = 234
            Case 14
                Position_sel = 1108
                Position_team = 234
            Case 15
                Position_sel = 1178
                Position_team = 234
            Case 16
                Position_sel = 1328
                Position_team = 234

        End Select

        If CHECK97 = 1 Then
            Form1.Leer_Team.BaseStream.Position = Index + Position_sel
            Nombre_equipo_english = Form1.Leer_Team.ReadChars(45)
            Nombre_equipo_english = Nombre_equipo_english.TrimEnd("")
            Form1.Leer_Team.BaseStream.Position = Index + Nombre_corto_pos
            Nombre_Corto = Form1.Leer_Team.ReadChars(3)
        Else
            Form1.Leer_Team.BaseStream.Position = Index + Position_team
            Nombre_equipo_english = Form1.Leer_Team.ReadChars(45)
            Nombre_equipo_english = Nombre_equipo_english.TrimEnd("")
            If CHECK96 = 1 Or CHECK98 = 1 Then
                Form1.Leer_Team.BaseStream.Position = Index + Nombre_corto_pos
                Nombre_Corto = Form1.Leer_Team.ReadChars(3)
            Else
                Form1.Leer_Team.BaseStream.Position = Index + 1248
                Nombre_Corto = Form1.Leer_Team.ReadChars(3)
            End If

        End If


        'Form1.Leer_Team.BaseStream.Position = Index + byte_1
        'byte_1_valor = Form1.Leer_Team.ReadByte
        Form1.Leer_Team.BaseStream.Position = Index + Order_in_league_16_pos
        Order_in_league_16 = swaps.swap16(Form1.Leer_Team.ReadUInt16())
        League = Order_in_league_16




    End Sub

    Public Sub Leer_valores_team_2(ByVal selected_index As Integer)
        Index = selected_index * tamanho_bloque
        Form1.Leer_Team.BaseStream.Position = Index + Id_32_pos
        Id_32 = swaps.swap32(Form1.Leer_Team.ReadUInt32())

        'Form1.Leer_Team.BaseStream.Position = Index + Nombre_equipo_english_70Lenght_pos
        'Nombre_equipo_english = Form1.Leer_Team.ReadChars(65)
        'Nombre_equipo_english = Nombre_equipo_english.Trim

        Form1.Leer_Team.BaseStream.Position = Index + Country_16_pos

        Dim Valor_IMP_32 As UInt32 = Form1.Leer_Team.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Valor_IMP_32 = converter.bitworking_Team_toPc(swaps.swap32(Valor_IMP_32))
        End If

        Dim CHECK90 As UInt32 = Valor_IMP_32 >> 31

        Dim CHECK91 As UInt32 = Valor_IMP_32 << 1
        CHECK91 = CHECK91 >> 31

        Dim CHECK92 As UInt32 = Valor_IMP_32 << 2
        CHECK92 = CHECK92 >> 31

        Dim CHECK93 As UInt32 = Valor_IMP_32 << 3
        CHECK93 = CHECK93 >> 31

        Dim CHECK94 As UInt32 = Valor_IMP_32 << 4
        CHECK94 = CHECK94 >> 31

        Dim CHECK95 As UInt32 = Valor_IMP_32 << 5
        CHECK95 = CHECK95 >> 31

        Dim CHECK96 As UInt32 = Valor_IMP_32 << 6
        CHECK96 = CHECK96 >> 31

        Dim CHECK97 As UInt32 = Valor_IMP_32 << 7
        CHECK97 = CHECK97 >> 31
        If CHECK97 = 1 Then
            Form1.CheckBox_NATION_TEAM2.Checked = True
        Else
            Form1.CheckBox_NATION_TEAM2.Checked = False
        End If
        Dim CHECK98 As UInt32 = Valor_IMP_32 << 8
        CHECK98 = CHECK98 >> 31

        Dim CHECK99 As UInt32 = Valor_IMP_32 << 9
        CHECK99 = CHECK99 >> 31

        Dim CHECK100 As UInt32 = Valor_IMP_32 << 10
        CHECK100 = CHECK100 >> 31

        Dim CHECK101 As UInt32 = Valor_IMP_32 << 11
        CHECK101 = CHECK101 >> 31

        Dim Gray As UInt32 = Valor_IMP_32 << 12
        Gray = Gray >> 30
        'Form1.Gray_box.Value = Gray
        Dim Orange As UInt32 = Valor_IMP_32 << 14
        Orange = Orange >> 30
        'Form1.Orange_box.Value = Orange
        Dim Pink As UInt32 = Valor_IMP_32 << 16
        Pink = Pink >> 29
        ' Form1.Pink_box.Value = Pink
        Dim Green_team As UInt32 = Valor_IMP_32 << 19
        Green_team = Green_team >> 28
        'Form1.Non_playable_team_box.Value = Green_team
        Dim Nationality As UInt32 = Valor_IMP_32 << 23
        Nationality = Nationality >> 23
        ' Form1.Team_country_box.Text = Nationality

        Dim Position_sel As ULong
        Dim Position_team As ULong

        Select Case Form1.Language
            Case 1
                Position_sel = 24
                Position_team = 24
            Case 2
                Position_sel = 94
                Position_team = 234
            Case 3
                Position_sel = 164
                Position_team = 164
            Case 4
                Position_sel = 234
                Position_team = 234
            Case 5
                Position_sel = 304
                Position_team = 304
            Case 6
                Position_sel = 374
                Position_team = 304
            Case 7
                Position_sel = 444
                Position_team = 234
            Case 8
                Position_sel = 514
                Position_team = 234
            Case 9
                Position_sel = 584
                Position_team = 304
            Case 10
                Position_sel = 678
                Position_team = 234
            Case 11
                Position_sel = 758
                Position_team = 304
            Case 12
                Position_sel = 898
                Position_team = 234
            Case 13
                Position_sel = 1038
                Position_team = 234
            Case 14
                Position_sel = 1108
                Position_team = 234
            Case 15
                Position_sel = 1178
                Position_team = 234
            Case 16
                Position_sel = 1328
                Position_team = 234

        End Select

        If CHECK97 = 1 Then
            Form1.Leer_Team.BaseStream.Position = Index + Position_sel
            Nombre_equipo_english = Form1.Leer_Team.ReadChars(60)
            Nombre_equipo_english = Nombre_equipo_english.TrimEnd("")
            Form1.Leer_Team.BaseStream.Position = Index + Nombre_corto_pos
            Nombre_Corto = Form1.Leer_Team.ReadChars(3)
        Else
            Form1.Leer_Team.BaseStream.Position = Index + Position_team
            Nombre_equipo_english = Form1.Leer_Team.ReadChars(60)
            Nombre_equipo_english = Nombre_equipo_english.TrimEnd("")
            If CHECK96 = 1 Then
                Form1.Leer_Team.BaseStream.Position = Index + Nombre_corto_pos
                Nombre_Corto = Form1.Leer_Team.ReadChars(3)
            Else
                Form1.Leer_Team.BaseStream.Position = Index + 1248
                Nombre_Corto = Form1.Leer_Team.ReadChars(3)
            End If

        End If




    End Sub

    Public Sub leer_jugadores_equipo()
        Try


            Form1.Leer_Player_Assignament.BaseStream.Position = 0
            Dim bloques_assig As UInteger = Form1.unzlib_Player_Assignament.Length / 16

            For i = 0 To bloques_assig - 1
                Form1.Leer_Player_Assignament.BaseStream.Position += 8
                Dim Team As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32())
                If Team = Id_32 Then
                    Form1.Leer_Player_Assignament.BaseStream.Position -= 12
                    Dim Index_PLASSIG As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32())
                    Dim Player_id As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32())
                    Form1.Leer_Player_Assignament.BaseStream.Position += 4
                    Dim number As Byte = Form1.Leer_Player_Assignament.ReadByte
                    Form1.Leer_Player.BaseStream.Position = 8
                    Dim Aux As UInt32
                    Dim contador As Long = 0
                    While Aux <> Player_id
                        Aux = swaps.swap32(Form1.Leer_Player.ReadUInt32)
                        Form1.Leer_Player.BaseStream.Position += 188
                        contador += 1
                    End While

                    contador -= 1

                    Dim player As String = ""
                    Dim Position As UInt32 = 0
                    Dim PositionText As String = ""
                    'For j = 0 To (Form1.unzlib_Player.Length / 184) - 1
                    Dim jug_check As New Player
                    jug_check.Leer_valores_sin_pantalla(contador)
                    'If jug_check.Player_ID = Player_id Then
                    player = jug_check.Nom_Jugador_shirt
                    Position = jug_check.Position
                    'Exit For
                    'End If
                    'Next


                    Select Case Position
                        Case &H0
                            PositionText = "GK"
                        Case &H1
                            PositionText = "CB"
                        Case &H2
                            PositionText = "LB"
                        Case &H3
                            PositionText = "RB"
                        Case &H4
                            PositionText = "DMF"
                        Case &H5
                            PositionText = "CMF"
                        Case &H6
                            PositionText = "LMF"
                        Case &H7
                            PositionText = "RMF"
                        Case &H8
                            PositionText = "AMF"
                        Case &H9
                            PositionText = "LWF"
                        Case &HA
                            PositionText = "RWF"
                        Case &HB
                            PositionText = "SS"
                        Case &HC
                            PositionText = "CF"

                        Case Else
                            PositionText = "Unknown"
                    End Select




                    'Form1.Leer_Player.BaseStream.Position -= 98
                    ' Dim player As String = Form1.Leer_Player.ReadChars(44)


                    Dim Valor_partido As UInt16 = Form1.Leer_Player_Assignament.ReadUInt16
                    If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                        Valor_partido = converter.bitworking_PlayerAssignment_toPc(Valor_partido)
                    End If

                    Dim CHECK46 As UInt32 = Valor_partido << 4
                    CHECK46 = CHECK46 >> 15
                    If CHECK46 = 1 Then
                        Form1.TextBox_CAPTAIN.Text = player
                    End If
                    Dim CHECK47 As UInt32 = Valor_partido << 5
                    CHECK47 = CHECK47 >> 15
                    If CHECK47 = 1 Then
                        Form1.TextBoxPENALTY_KICK.Text = player
                    End If
                    Dim CHECK48 As UInt32 = Valor_partido << 6
                    CHECK48 = CHECK48 >> 15
                    If CHECK48 = 1 Then
                        Form1.TextBox_LONG_SHOT.Text = player
                    End If
                    Dim CHECK49 As UInt32 = Valor_partido << 7
                    CHECK49 = CHECK49 >> 15
                    If CHECK49 = 1 Then
                        Form1.TextBoxLEFT_CK.Text = player
                    End If
                    Dim CHECK50 As UInt32 = Valor_partido << 8
                    CHECK50 = CHECK50 >> 15
                    If CHECK50 = 1 Then
                        Form1.TextBox_SHORT_FOUL.Text = player
                    End If
                    Dim CHECK51 As UInt32 = Valor_partido << 9
                    CHECK51 = CHECK51 >> 15
                    If CHECK51 = 1 Then
                        Form1.TextBox_RIGHT_CK.Text = player
                    End If

                    Dim Order_in_Team As UInt16 = Valor_partido << 10
                    Order_in_Team = Order_in_Team >> 10


                    Form1.Leer_Player_Assignament.BaseStream.Position += 1

                    Form1.DataGridView_playersOfTeam.Rows.Add(Order_in_Team, player, number, CHECK46, CHECK47, CHECK48, CHECK49, CHECK50, CHECK51, Index_PLASSIG, Player_id, PositionText)


                Else
                    Form1.Leer_Player_Assignament.BaseStream.Position += 4
                End If

            Next

            Form1.Leer_Player_Assignament.BaseStream.Position = 0
            Form1.DataGridView_playersOfTeam.Sort(Form1.DataGridView_playersOfTeam.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            For i = 0 To Form1.DataGridView_playersOfTeam.Rows.Count - 1
                Select Case Form1.DataGridView_playersOfTeam.Rows(i).Cells(11).Value
                    Case "GK"
                        Form1.DataGridView_playersOfTeam.Rows(i).Cells(11).Style.BackColor = Color.Orange
                    Case "CB", "LB", "RB"
                        Form1.DataGridView_playersOfTeam.Rows(i).Cells(11).Style.BackColor = Color.LightBlue
                    Case "DMF", "CMF", "LMF", "RMF", "AMF"
                        Form1.DataGridView_playersOfTeam.Rows(i).Cells(11).Style.BackColor = Color.LightGreen
                    Case "LWF", "RWF", "CF", "SS"
                        Form1.DataGridView_playersOfTeam.Rows(i).Cells(11).Style.BackColor = Color.OrangeRed

                End Select
            Next





        Catch ex As Exception
            MsgBox("Sorry some problem with player of this team" + ex.ToString)
        End Try

    End Sub

    Public Sub grabar_jugadores()

        Try
            'Poner los 1 de los coach y demas en el datagrid
            'Captain

            For Each row As DataGridViewRow In Form1.DataGridView_playersOfTeam.Rows
                If String.Compare(row.Cells(1).Value, Form1.TextBox_CAPTAIN.Text) = 0 Then
                    row.Cells(3).Value = 1
                Else
                    row.Cells(3).Value = 0
                End If

                If String.Compare(row.Cells(1).Value, Form1.TextBoxPENALTY_KICK.Text) = 0 Then
                    row.Cells(4).Value = 1
                Else
                    row.Cells(4).Value = 0
                End If

                If String.Compare(row.Cells(1).Value, Form1.TextBox_LONG_SHOT.Text) = 0 Then
                    row.Cells(5).Value = 1
                Else
                    row.Cells(5).Value = 0
                End If

                If String.Compare(row.Cells(1).Value, Form1.TextBoxLEFT_CK.Text) = 0 Then
                    row.Cells(6).Value = 1
                Else
                    row.Cells(6).Value = 0
                End If

                If String.Compare(row.Cells(1).Value, Form1.TextBox_SHORT_FOUL.Text) = 0 Then
                    row.Cells(7).Value = 1
                Else
                    row.Cells(7).Value = 0
                End If

                If String.Compare(row.Cells(1).Value, Form1.TextBox_RIGHT_CK.Text) = 0 Then
                    row.Cells(8).Value = 1
                Else
                    row.Cells(8).Value = 0
                End If

                'Poner los valores en playerassignament

            Next

            'Grabar Player assignment en cada Row buscar el index y poner todos los valores de nuevo
            Dim contador As UInteger = 0
            For i = 0 To Form1.DataGridView_playersOfTeam.Rows.Count - 1

                Dim ASSIG_INDEX As UInt32 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(9).Value
                Form1.Leer_Player_Assignament.BaseStream.Position = 0
                Dim bloques_assig As UInteger = Form1.unzlib_Player_Assignament.Length / 16
                For j = 0 To bloques_assig - 1
                    Dim Aux_index As UInteger = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
                    If Aux_index = ASSIG_INDEX Then
                        Dim New_ID As UInt32 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(10).Value
                        Dim New_team As UInt32 = Form1.Team_id_box.Text
                        Dim New_Number As Byte = Form1.DataGridView_playersOfTeam.Rows(i).Cells(2).Value

                        Form1.Grabar_Player_Assignament.Write(swaps.swap32(New_ID))
                        Form1.Grabar_Player_Assignament.Write(swaps.swap32(New_team))
                        Form1.Grabar_Player_Assignament.Write(New_Number)
                        Dim Nuevo_Valor_16 As UInt16 = 0
                        Dim Aux_16 As UInt16 = 0
                        Dim CHECK_CAP As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(3).Value
                        Dim CHECK_PENAL As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(4).Value
                        Dim CHECK_Long As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(5).Value
                        Dim CHECK_LCK As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(6).Value
                        Dim CHECK_SHORT As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(7).Value
                        Dim CHECK_RCK As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(8).Value
                        Dim New_Order As UInt16 = contador
                        Aux_16 = CHECK_CAP
                        Aux_16 = Aux_16 << 11
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_PENAL
                        Aux_16 = Aux_16 << 10
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_Long
                        Aux_16 = Aux_16 << 9
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_LCK
                        Aux_16 = Aux_16 << 8
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_SHORT
                        Aux_16 = Aux_16 << 7
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_RCK
                        Aux_16 = Aux_16 << 6
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = New_Order
                        'Aux_16 = Aux_16 << 6
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                            Nuevo_Valor_16 = converter.bitworking_PlayerAssignment_toConsole(Nuevo_Valor_16)
                        End If

                        Form1.Grabar_Player_Assignament.Write(Nuevo_Valor_16)
                        Form1.Leer_Player_Assignament.BaseStream.Position += 1
                        contador += 1
                        Exit For
                    Else
                        Form1.Leer_Player_Assignament.BaseStream.Position += 12

                    End If


                Next


            Next




        Catch ex As Exception
            MsgBox("Sorry some problem with player of this team" + ex.ToString)
        End Try


    End Sub

    Public Sub grabar_traspasos_1()

        Try
            'Poner los 1 de los coach y demas en el datagrid
            'Captain

            'Grabar Player assignment en cada Row buscar el index y poner todos los valores de nuevo
            Dim contador As UInteger = 0
            For i = 0 To Form1.DataGridView_playersOfTeam.Rows.Count - 1

                Dim ASSIG_INDEX As UInt32 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(9).Value
                Form1.Leer_Player_Assignament.BaseStream.Position = 0
                Dim bloques_assig As UInteger = Form1.unzlib_Player_Assignament.Length / 16
                For j = 0 To bloques_assig - 1
                    Dim Aux_index As UInteger = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
                    If Aux_index = ASSIG_INDEX Then
                        Dim New_ID As UInt32 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(10).Value
                        Dim New_team As UInt32 = Form1.Team_id_box.Text
                        Dim New_Number As Byte = Form1.DataGridView_playersOfTeam.Rows(i).Cells(2).Value

                        Form1.Grabar_Player_Assignament.Write(swaps.swap32(New_ID))
                        Form1.Grabar_Player_Assignament.Write(swaps.swap32(New_team))
                        Form1.Grabar_Player_Assignament.Write(New_Number)
                        Dim Nuevo_Valor_16 As UInt16 = 0
                        Dim Aux_16 As UInt16 = 0
                        Dim CHECK_CAP As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(3).Value
                        Dim CHECK_PENAL As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(4).Value
                        Dim CHECK_Long As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(5).Value
                        Dim CHECK_LCK As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(6).Value
                        Dim CHECK_SHORT As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(7).Value
                        Dim CHECK_RCK As UInt16 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(8).Value
                        Dim New_Order As UInt16 = contador
                        Aux_16 = CHECK_CAP
                        Aux_16 = Aux_16 << 11
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_PENAL
                        Aux_16 = Aux_16 << 10
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_Long
                        Aux_16 = Aux_16 << 9
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_LCK
                        Aux_16 = Aux_16 << 8
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_SHORT
                        Aux_16 = Aux_16 << 7
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_RCK
                        Aux_16 = Aux_16 << 6
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = New_Order
                        'Aux_16 = Aux_16 << 6
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                            Nuevo_Valor_16 = converter.bitworking_PlayerAssignment_toConsole(Nuevo_Valor_16)
                        End If

                        Form1.Grabar_Player_Assignament.Write(Nuevo_Valor_16)
                        Form1.Leer_Player_Assignament.BaseStream.Position += 1
                        contador += 1
                        Exit For
                    ElseIf j = bloques_assig - 1 Then
                        Form1.Leer_Player_Assignament.BaseStream.Position = Form1.unzlib_Player_Assignament.Length

                        Dim New_assig_index As UInt32 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(9).Value
                        Dim New_ID As UInt32 = Form1.DataGridView_playersOfTeam.Rows(i).Cells(10).Value
                        Dim New_team As UInt32 = Form1.Team_id_box.Text
                        Dim New_Number As Byte = Form1.DataGridView_playersOfTeam.Rows(i).Cells(2).Value
                        Form1.Grabar_Player_Assignament.Write(swaps.swap32(New_assig_index))
                        Form1.Grabar_Player_Assignament.Write(swaps.swap32(New_ID))
                        Form1.Grabar_Player_Assignament.Write(swaps.swap32(New_team))
                        Form1.Grabar_Player_Assignament.Write(New_Number)
                        Dim Nuevo_Valor_16 As UInt16 = contador
                        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                            Nuevo_Valor_16 = converter.bitworking_PlayerAssignment_toConsole(Nuevo_Valor_16)
                        End If
                        Dim cero As Byte = 0
                        Form1.Grabar_Player_Assignament.Write(Nuevo_Valor_16)
                        Form1.Grabar_Player_Assignament.Write(cero)

                        contador += 1

                        Form1.PlayerAssignment_index_mayor += 1
                        Exit For
                    Else
                        Form1.Leer_Player_Assignament.BaseStream.Position += 12

                    End If


                Next


            Next




        Catch ex As Exception
            MsgBox("Sorry some problem with player of this team" + ex.ToString)
        End Try


    End Sub

    Public Sub grabar_traspasos_2()

        Try
            'Poner los 1 de los coach y demas en el datagrid
            'Captain

            'Grabar Player assignment en cada Row buscar el index y poner todos los valores de nuevo
            Dim contador As UInteger = 0
            For i = 0 To Form1.DataGridView_playersOfTeam_2.Rows.Count - 1

                Dim ASSIG_INDEX As UInt32 = Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(9).Value
                Form1.Leer_Player_Assignament.BaseStream.Position = 0
                Dim bloques_assig As UInteger = Form1.unzlib_Player_Assignament.Length / 16
                For j = 0 To bloques_assig - 1
                    Dim Aux_index As UInteger = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
                    If Aux_index = ASSIG_INDEX Then
                        Dim New_ID As UInt32 = Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(10).Value
                        Dim New_team As UInt32 = Form1.Team_id_box_2.Text
                        Dim New_Number As Byte = Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(2).Value

                        Form1.Grabar_Player_Assignament.Write(swaps.swap32(New_ID))
                        Form1.Grabar_Player_Assignament.Write(swaps.swap32(New_team))
                        Form1.Grabar_Player_Assignament.Write(New_Number)
                        Dim Nuevo_Valor_16 As UInt16 = 0
                        Dim Aux_16 As UInt16 = 0
                        Dim CHECK_CAP As UInt16 = Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(3).Value
                        Dim CHECK_PENAL As UInt16 = Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(4).Value
                        Dim CHECK_Long As UInt16 = Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(5).Value
                        Dim CHECK_LCK As UInt16 = Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(6).Value
                        Dim CHECK_SHORT As UInt16 = Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(7).Value
                        Dim CHECK_RCK As UInt16 = Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(8).Value
                        Dim New_Order As UInt16 = contador
                        Aux_16 = CHECK_CAP
                        Aux_16 = Aux_16 << 11
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_PENAL
                        Aux_16 = Aux_16 << 10
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_Long
                        Aux_16 = Aux_16 << 9
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_LCK
                        Aux_16 = Aux_16 << 8
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_SHORT
                        Aux_16 = Aux_16 << 7
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = CHECK_RCK
                        Aux_16 = Aux_16 << 6
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        Aux_16 = New_Order
                        'Aux_16 = Aux_16 << 6
                        Nuevo_Valor_16 = (Aux_16 Or Nuevo_Valor_16)
                        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                            Nuevo_Valor_16 = converter.bitworking_PlayerAssignment_toConsole(Nuevo_Valor_16)
                        End If

                        Form1.Grabar_Player_Assignament.Write(Nuevo_Valor_16)
                        Form1.Leer_Player_Assignament.BaseStream.Position += 1
                        contador += 1
                        Exit For
                    Else
                        Form1.Leer_Player_Assignament.BaseStream.Position += 12

                    End If


                Next


            Next




        Catch ex As Exception
            MsgBox("Sorry some problem with player of this team" + ex.ToString)
        End Try


    End Sub

    Public Sub leer_jugadores_equipo_2()
        Try


            Form1.Leer_Player_Assignament.BaseStream.Position = 0
            Dim bloques_assig As UInteger = Form1.unzlib_Player_Assignament.Length / 16

            For i = 0 To bloques_assig - 1
                Form1.Leer_Player_Assignament.BaseStream.Position += 8
                Dim Team As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32())
                If Team = Id_32 Then
                    Form1.Leer_Player_Assignament.BaseStream.Position -= 12
                    Dim Index_PLASSIG As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32())
                    Dim Player_id As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32())
                    Form1.Leer_Player_Assignament.BaseStream.Position += 4
                    Dim number As Byte = Form1.Leer_Player_Assignament.ReadByte
                    Form1.Leer_Player.BaseStream.Position = 8
                    Dim Aux As UInt32
                    Dim contador As Long = 0
                    While Aux <> Player_id
                        Aux = swaps.swap32(Form1.Leer_Player.ReadUInt32)
                        Form1.Leer_Player.BaseStream.Position += 188
                        contador += 1
                    End While

                    contador -= 1

                    Dim player As String = ""
                    Dim Position As UInt32 = 0
                    Dim PositionText As String = ""
                    'For j = 0 To (Form1.unzlib_Player.Length / 184) - 1
                    Dim jug_check As New Player
                    jug_check.Leer_valores_sin_pantalla(contador)
                    'If jug_check.Player_ID = Player_id Then
                    player = jug_check.Nom_Jugador_shirt
                    Position = jug_check.Position
                    'Exit For
                    'End If
                    'Next


                    Select Case Position
                        Case &H0
                            PositionText = "GK"
                        Case &H1
                            PositionText = "CB"
                        Case &H2
                            PositionText = "LB"
                        Case &H3
                            PositionText = "RB"
                        Case &H4
                            PositionText = "DMF"
                        Case &H5
                            PositionText = "CMF"
                        Case &H6
                            PositionText = "LMF"
                        Case &H7
                            PositionText = "RMF"
                        Case &H8
                            PositionText = "AMF"
                        Case &H9
                            PositionText = "LWF"
                        Case &HA
                            PositionText = "RWF"
                        Case &HB
                            PositionText = "SS"
                        Case &HC
                            PositionText = "CF"

                        Case Else
                            PositionText = "Unknown"
                    End Select



                    Dim Valor_partido As UInt16 = Form1.Leer_Player_Assignament.ReadUInt16
                    If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                        Valor_partido = converter.bitworking_PlayerAssignment_toPc(Valor_partido)
                    End If

                    Dim CHECK46 As UInt32 = Valor_partido << 4
                    CHECK46 = CHECK46 >> 15

                    Dim CHECK47 As UInt32 = Valor_partido << 5
                    CHECK47 = CHECK47 >> 15

                    Dim CHECK48 As UInt32 = Valor_partido << 6
                    CHECK48 = CHECK48 >> 15

                    Dim CHECK49 As UInt32 = Valor_partido << 7
                    CHECK49 = CHECK49 >> 15

                    Dim CHECK50 As UInt32 = Valor_partido << 8
                    CHECK50 = CHECK50 >> 15

                    Dim CHECK51 As UInt32 = Valor_partido << 9
                    CHECK51 = CHECK51 >> 15


                    Dim Order_in_Team As UInt16 = Valor_partido << 10
                    Order_in_Team = Order_in_Team >> 10


                    Form1.Leer_Player_Assignament.BaseStream.Position += 1

                    Form1.DataGridView_playersOfTeam_2.Rows.Add(Order_in_Team, player, number, CHECK46, CHECK47, CHECK48, CHECK49, CHECK50, CHECK51, Index_PLASSIG, Player_id, PositionText)


                Else
                    Form1.Leer_Player_Assignament.BaseStream.Position += 4
                End If

            Next

            Form1.Leer_Player_Assignament.BaseStream.Position = 0
            Form1.DataGridView_playersOfTeam_2.Sort(Form1.DataGridView_playersOfTeam_2.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            For i = 0 To Form1.DataGridView_playersOfTeam_2.Rows.Count - 1
                Select Case Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(11).Value
                    Case "GK"
                        Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(11).Style.BackColor = Color.Orange
                    Case "CB", "LB", "RB"
                        Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(11).Style.BackColor = Color.LightBlue
                    Case "DMF", "CMF", "LMF", "RMF", "AMF"
                        Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(11).Style.BackColor = Color.LightGreen
                    Case "LWF", "RWF", "CF", "SS"
                        Form1.DataGridView_playersOfTeam_2.Rows(i).Cells(11).Style.BackColor = Color.OrangeRed

                End Select
            Next





        Catch ex As Exception
            MsgBox("Sorry some problem with player of this team" + ex.ToString)
        End Try


    End Sub

    Public Sub Grabar_valores(ByVal selected_index As Integer)
        Form1.Leer_Team.BaseStream.Position = selected_index * Team.tamanho_bloque
        Dim pos_ini_team_block As UInteger = Form1.Leer_Team.BaseStream.Position
        Dim New_coach As UInt32 = swaps.swap32(Convert.ToInt32(Form1.COach_id_box.Text))
        Form1.Grabar_Team.Write(New_coach)
        Dim NewId As UInt32 = swaps.swap32(Convert.ToInt32(Form1.Team_id_box.Text))
        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 8
        Form1.Grabar_Team.Write(NewId)
        Dim NewStadium As UInt16 = swaps.swap16(Convert.ToInt16(Form1.Team_stadium_box.Text))
        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 16
        Form1.Grabar_Team.Write(NewStadium)
        Dim NewCountry As UInt32 = Convert.ToUInt32(Form1.Team_country_box.Text)
        'Dim NewLicensed As Byte = Convert.ToByte(Form1.Team_Licensed_box.Text)
        'Dim NewOther_league As UInt16 = Convert.ToInt16(Form1.Non_playable_league_box.Text)
        'Dim new_byte9_and_otherleague As UInt16 = 0
        'Dim NewCoach_Licensed As Byte = Convert.ToByte(Form1.Coach_textbox.Text)
        'Dim NewOrderInLeague As UInt16 = 0
        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 20

        Dim Aux As UInt32 = 0
        Dim Nuevo_val_32 As UInt32 = 0

        Dim CHECK90 As UInt32
        If Form1.CheckBox90.Checked = True Then
            CHECK90 = 1
        Else
            CHECK90 = 0
        End If
        Dim CHECK91 As UInt32
        If Form1.CheckBox91.Checked = True Then
            CHECK91 = 1
        Else
            CHECK91 = 0
        End If
        Dim CHECK92 As UInt32
        If Form1.CheckBox92.Checked = True Then
            CHECK92 = 1
        Else
            CHECK92 = 0
        End If
        Dim CHECK93 As UInt32
        If Form1.CheckBox93.Checked = True Then
            CHECK93 = 1
        Else
            CHECK93 = 0
        End If
        Dim CHECK94 As UInt32
        If Form1.CheckBox94.Checked = True Then
            CHECK94 = 1
        Else
            CHECK94 = 0
        End If
        Dim CHECK95 As UInt32
        If Form1.CheckBox95.Checked = True Then
            CHECK95 = 1
        Else
            CHECK95 = 0
        End If
        Dim CHECK96 As UInt32
        If Form1.CheckBox96.Checked = True Then
            CHECK96 = 1
        Else
            CHECK96 = 0
        End If
        Dim CHECK97 As UInt32
        If Form1.CheckBox97.Checked = True Then
            CHECK97 = 1
        Else
            CHECK97 = 0
        End If
        Dim CHECK98 As UInt32
        If Form1.CheckBox98.Checked = True Then
            CHECK98 = 1
        Else
            CHECK98 = 0
        End If
        Dim CHECK99 As UInt32
        If Form1.CheckBox99.Checked = True Then
            CHECK99 = 1
        Else
            CHECK99 = 0
        End If
        Dim CHECK100 As UInt32
        If Form1.CheckBox100.Checked = True Then
            CHECK100 = 1
        Else
            CHECK100 = 0
        End If
        Dim CHECK101 As UInt32
        If Form1.CheckBox101.Checked = True Then
            CHECK101 = 1
        Else
            CHECK101 = 0
        End If
        Dim New_Gray As UInt32 = Form1.Gray_box.Value
        Dim New_Orange As UInt32 = Form1.Orange_box.Value
        Dim New_Pink As UInt32 = Form1.Pink_box.Value
        Dim New_Non_playable_team As UInt32 = Form1.Non_playable_team_box.Value
        Dim New_Country_16 As UInt32 = Convert.ToUInt32(Form1.Team_country_box.Text)

        Aux = CHECK90
        Aux = Aux << 31
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK91
        Aux = Aux << 30
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK92
        Aux = Aux << 29
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK93
        Aux = Aux << 28
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK94
        Aux = Aux << 27
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK95
        Aux = Aux << 26
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK96
        Aux = Aux << 25
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK97
        Aux = Aux << 24
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK98
        Aux = Aux << 23
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK99
        Aux = Aux << 22
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK100
        Aux = Aux << 21
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = CHECK101
        Aux = Aux << 20
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = New_Gray
        Aux = Aux << 18
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = New_Orange
        Aux = Aux << 16
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = New_Pink
        Aux = Aux << 13
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = New_Non_playable_team
        Aux = Aux << 9
        Nuevo_val_32 = (Aux Or Nuevo_val_32)
        Aux = New_Country_16
        'Aux = Aux << 20
        Nuevo_val_32 = (Aux Or Nuevo_val_32)

        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Nuevo_val_32 = converter.bitworking_Team_toConsole(Nuevo_val_32)
        End If

        Form1.Grabar_Team.Write(Nuevo_val_32)


        If Form1.NombreEquipo_cambiado = True Then

            Dim Position_sel As ULong


            Select Case Form1.CheckBox97.Checked

                Case (True)

                    If Form1.Language_read_1 = 1 Then
                        Position_sel = 24
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If
                    If Form1.Language_read_2 = 1 Then
                        Position_sel = 94
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_3 = 1 Then
                        Position_sel = 164
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_4 = 1 Then
                        Position_sel = 234
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_5 = 1 Then
                        Position_sel = 304
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_6 = 1 Then
                        Position_sel = 374
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_7 = 1 Then
                        Position_sel = 444
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_8 = 1 Then
                        Position_sel = 514
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_9 = 1 Then
                        Position_sel = 584
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_10 = 1 Then
                        Position_sel = 678
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_11 = 1 Then
                        Position_sel = 758
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_12 = 1 Then
                        Position_sel = 898
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_13 = 1 Then
                        Position_sel = 1038
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_14 = 1 Then
                        Position_sel = 1108
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_15 = 1 Then
                        Position_sel = 1178
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_16 = 1 Then
                        Position_sel = 1328
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If






                    'Nombre Short
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 748
                    For i = (pos_ini_team_block + 748) To ((pos_ini_team_block + 748) + 3)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 748
                    Form1.Grabar_Team.Write(Form1.Team_short_box.Text.ToCharArray)


                    Form1.NombreEquipo_cambiado = False

                    Dim Seleccionado As UInteger = Form1.ListBox3.SelectedIndex
                    Form1.ListBox3.Items.RemoveAt(Seleccionado)
                    Form1.ListBox3.Items.Insert(Seleccionado, Form1.TextBox_Team_Na.Text)
                    Form1.ListBox3.SelectedIndex = Seleccionado
                    Form1.DataGridView_TEAM(2, Form1.ListBox3.SelectedIndex).Value = Form1.TextBox_Team_Na.Text

                Case Else

                    If Form1.Language_read_1 = 1 Then
                        Position_sel = 24
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_3 = 1 Then
                        Position_sel = 164
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_15 = 1 Then
                        Position_sel = 1178
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                    End If

                    If Form1.Language_read_2 = 1 Or Form1.Language_read_4 = 1 Or Form1.Language_read_5 = 1 Or Form1.Language_read_6 = 1 Or Form1.Language_read_7 = 1 Or Form1.Language_read_8 = 1 Or Form1.Language_read_9 = 1 Or Form1.Language_read_10 = 1 Or Form1.Language_read_11 = 1 Or Form1.Language_read_12 = 1 Or Form1.Language_read_13 = 1 Or Form1.Language_read_14 = 1 Or Form1.Language_read_16 = 1 Then
                        Position_sel = 234
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)
                        Position_sel = 304
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                        Form1.Grabar_Team.Write(Form1.TextBox_Team_Na.Text.ToCharArray)


                    End If

                    'bloque short si es o no licensed
                    If CHECK96 = 1 Or CHECK98 = 1 Then
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 748
                        For i = (pos_ini_team_block + 748) To ((pos_ini_team_block + 748) + 3)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 748
                        Form1.Grabar_Team.Write(Form1.Team_short_box.Text.ToCharArray)

                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 1248
                        For i = (pos_ini_team_block + 1248) To ((pos_ini_team_block + 1248) + 3)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        If CHECK96 = 1 Then
                            Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 1248
                            Form1.Grabar_Team.Write("None".ToCharArray)
                        End If


                    Else

                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 1248
                        For i = (pos_ini_team_block + 1248) To ((pos_ini_team_block + 1248) + 3)
                            Dim cero As Byte = &H0
                            Form1.Grabar_Team.Write(cero)
                        Next
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 1248
                        Form1.Grabar_Team.Write(Form1.Team_short_box.Text.ToCharArray)


                    End If

                    Form1.NombreEquipo_cambiado = False


                  

        Dim Seleccionado As UInteger = Form1.ListBox3.SelectedIndex
        Form1.ListBox3.Items.RemoveAt(Seleccionado)
        Form1.ListBox3.Items.Insert(Seleccionado, Form1.TextBox_Team_Na.Text)
        Form1.ListBox3.SelectedIndex = Seleccionado
        Form1.DataGridView_TEAM(2, Form1.ListBox3.SelectedIndex).Value = Form1.TextBox_Team_Na.Text


            End Select
        End If

        Dim Tactics_a_grabar As New Tactics

        Tactics_a_grabar.Grabar_ID(Form1.NumericUpDownSlot_tact_1.Value)

        Tactics_a_grabar.Grabar_ID(Form1.NumericUpDownSlot_tact_2.Value)



    End Sub

    Public Sub Grabar_Coach(ByVal selected_index As Integer, ByVal Coach_Id As UInt32, ByVal Coach_LIC_byte As UInteger)

        Form1.Grabar_Team.BaseStream.Position = selected_index * Team.tamanho_bloque
        Dim pos_ini_team_block As UInteger = Form1.Grabar_Team.BaseStream.Position
        Dim byte_a_escribir As UInt32
        Form1.Grabar_Team.BaseStream.Position = pos_ini_team_block + Team.Coach_pos
        Form1.Grabar_Team.Write(Coach_Id)

        Form1.Grabar_Team.BaseStream.Position = pos_ini_team_block + Team.Country_16_pos

        Dim Valor32 As UInt32 = Form1.Leer_Team.ReadUInt32
        Dim Nuevo_val32 As UInt32 = 0

        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Valor32 = converter.bitworking_Team_toPc(swaps.swap32(Valor32))
        End If

        Dim Aux As UInt32
        Form1.Leer_Team.BaseStream.Position -= 4
        Select Case Coach_LIC_byte

            Case 0, 1, 2, 3
                byte_a_escribir = 1

            Case 4, 5, 6, 7
                byte_a_escribir = 0
        End Select

        Dim Check99 As UInt32 = byte_a_escribir
        Dim CHECK100 As UInt32 = byte_a_escribir

        Aux = Valor32
        Aux = Aux >> 23
        Aux = Aux << 23
        Nuevo_val32 = (Aux Or Nuevo_val32)

        Aux = Valor32
        Aux = Aux << 11
        Aux = Aux >> 11
        Nuevo_val32 = (Aux Or Nuevo_val32)

        Aux = Check99
        Aux = Aux << 22
        Nuevo_val32 = (Aux Or Nuevo_val32)
        Aux = CHECK100
        Aux = Aux << 21
        Nuevo_val32 = (Aux Or Nuevo_val32)

        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Nuevo_val32 = converter.bitworking_Team_toConsole(Nuevo_val32)
        End If


        Form1.Grabar_Team.Write(Nuevo_val32)



    End Sub

    Public Sub Grabar_nombres_exportados(ByVal selected_index As UInt32, new_name As String, new_short As String)
        Dim Position_sel As ULong
        Dim pos_ini_team_block As UInt32 = selected_index * tamanho_bloque


        Select Case Form1.CheckBox97.Checked

            Case (True)

                If Form1.Language_read_1 = 1 Then
                    Position_sel = 24
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If
                If Form1.Language_read_2 = 1 Then
                    Position_sel = 94
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_3 = 1 Then
                    Position_sel = 164
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_4 = 1 Then
                    Position_sel = 234
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_5 = 1 Then
                    Position_sel = 304
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_6 = 1 Then
                    Position_sel = 374
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_7 = 1 Then
                    Position_sel = 444
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_8 = 1 Then
                    Position_sel = 514
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_9 = 1 Then
                    Position_sel = 584
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_10 = 1 Then
                    Position_sel = 678
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_11 = 1 Then
                    Position_sel = 758
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_12 = 1 Then
                    Position_sel = 898
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_13 = 1 Then
                    Position_sel = 1038
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_14 = 1 Then
                    Position_sel = 1108
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_15 = 1 Then
                    Position_sel = 1178
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_16 = 1 Then
                    Position_sel = 1328
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If






                'Nombre Short
                Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 748
                For i = (pos_ini_team_block + 748) To ((pos_ini_team_block + 748) + 3)
                    Dim cero As Byte = &H0
                    Form1.Grabar_Team.Write(cero)
                Next
                Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 748
                Form1.Grabar_Team.Write(new_short.ToCharArray)


            Case Else

                If Form1.Language_read_1 = 1 Then
                    Position_sel = 24
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_3 = 1 Then
                    Position_sel = 164
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_15 = 1 Then
                    Position_sel = 1178
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                End If

                If Form1.Language_read_2 = 1 Or Form1.Language_read_4 = 1 Or Form1.Language_read_5 = 1 Or Form1.Language_read_6 = 1 Or Form1.Language_read_7 = 1 Or Form1.Language_read_8 = 1 Or Form1.Language_read_9 = 1 Or Form1.Language_read_10 = 1 Or Form1.Language_read_11 = 1 Or Form1.Language_read_12 = 1 Or Form1.Language_read_13 = 1 Or Form1.Language_read_14 = 1 Or Form1.Language_read_16 = 1 Then
                    Position_sel = 234
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)
                    Position_sel = 304
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    For i = (pos_ini_team_block + Position_sel) To ((pos_ini_team_block + Position_sel) + 69)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + Position_sel
                    Form1.Grabar_Team.Write(new_name.ToCharArray)


                End If

                'bloque short si es o no licensed
                If Form1.CheckBox96.Checked = True Or Form1.CheckBox98.Checked = True Then
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 748
                    For i = (pos_ini_team_block + 748) To ((pos_ini_team_block + 748) + 3)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 748
                    Form1.Grabar_Team.Write(new_short.ToCharArray)

                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 1248
                    For i = (pos_ini_team_block + 1248) To ((pos_ini_team_block + 1248) + 3)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    If Form1.CheckBox96.Checked = True Then
                        Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 1248
                        Form1.Grabar_Team.Write("None".ToCharArray)
                    End If


                Else

                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 1248
                    For i = (pos_ini_team_block + 1248) To ((pos_ini_team_block + 1248) + 3)
                        Dim cero As Byte = &H0
                        Form1.Grabar_Team.Write(cero)
                    Next
                    Form1.Leer_Team.BaseStream.Position = pos_ini_team_block + 1248
                    Form1.Grabar_Team.Write(new_short.ToCharArray)


                End If

               
               
        End Select
    End Sub

End Class
