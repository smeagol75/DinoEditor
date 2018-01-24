
Imports Db_Xbox_editor
Imports System.IO

Public Class Player
    Public Index As UInt32


    Private Const Valor_32_nuevo_pos As UInteger = 0
    Public Const Id_32_pos As UInteger = 8
    Private Const Country_16_pos As UInteger = 8
    Public Const Nombre_pos As UInteger = 144
    Public Const Nombre_camiseta_pos As UInteger = 98
    Public Const tamanho_bloque As UInteger = 192
    Public Const Foot_pos As UInteger = 18
    Public Const Position_pos As UInteger = 32
    Public Const Edad_pos As UInteger = 30

    Public country As UInt32
    Public Player_ID As UInt32

    Public Valor32_nuevo As UInt32
    Public Valor32_nuevo_2 As UInt32
    Public Texto_Nacionalidad As String = ""
    Public Nombre As String = ""
    Public Nombre_camiseta As String = ""


    Public weight As UInt32
    Public Height As UInt32
    Public Nacionalizado As UInt32
    Public Texto_Nacionalizado As String = ""
    Public Nacion As UInt32
    Public Texto_Nacion As String = ""
    Public Early_Cross As UInt32
    Public def_prowess As UInt32
    Public Clearing As UInt32
    Public Low_pass As UInt32
    Public place_kicking As UInt32
    Public Goal_celeb As UInt32
    Public LB As UInt32
    Public coverage As UInt32
    Public catching As UInt32
    Public Jump As UInt32
    Public Header As UInt32
    Public Ball_control As UInt32
    Public GK As UInt32
    Public GoalKeeping As UInt32
    Public Reflexes As UInt32
    Public Finishing As UInt32
    Public Ball_winning As UInt32
    Public Speed As UInt32
    Public Penalty_kick As UInt32
    Public Kicking_power As UInt32
    Public Dribling As UInt32
    Public Explosive_power As UInt32
    Public Stamina As UInt32
    Public Swerve As UInt32
    Public FORM As UInt32
    Public Playing_Style As UInt32
    Public Age As UInt32
    Public Lofted_pass As UInt32
    Public Physical_Contact As UInt32
    Public Body_Balance As UInt32
    Public Attacking_Prowess As UInt32
    Public RMF As UInt32
    Public Injury_res As UInt32
    Public CMF As UInt32
    Public Weak_foot_use As UInt32
    Public DMF As UInt32
    Public green As UInt32
    Public Pink_2 As UInt32
    Public Running_arm_mov As UInt32
    Public Dribling_arm_mov As UInt32
    Public Corner_kick As UInt32
    Public Position As UInt32
    Public Free_kick As UInt32
    Public original_32_8th_val As UInt32
    Public CHECK1 As UInt32
    Public CHECK2 As UInt32
    Public CHECK3 As UInt32
    Public CHECK4 As UInt32
    Public CHECK5 As UInt32
    Public CHECK6 As UInt32
    Public CHECK7 As UInt32
    Public CHECK8 As UInt32
    Public Blue_2 As UInt32
    Public SS As UInt32
    Public Runing_Hutching As UInt32
    Public RWF As UInt32
    Public LMF As UInt32
    Public RB As UInt32
    Public LWF As UInt32
    Public CF As UInt32
    Public CB As UInt32
    Public Dribling_hutching As UInt32
    Public AMF As UInt32
    Public Weak_foot_acc As UInt32
    Public ulti_nuevo As UInt32
    Public CHECK9 As UInt32
    Public CHECK10 As UInt32
    Public CHECK11 As UInt32
    Public CHECK12 As UInt32
    Public CHECK13 As UInt32
    Public CHECK14 As UInt32
    Public CHECK15 As UInt32
    Public CHECK16 As UInt32
    Public CHECK17 As UInt32
    Public CHECK18 As UInt32
    Public CHECK19 As UInt32
    Public CHECK20 As UInt32
    Public CHECK21 As UInt32
    Public CHECK22 As UInt32
    Public CHECK23 As UInt32
    Public CHECK24 As UInt32
    Public CHECK25 As UInt32
    Public CHECK26 As UInt32
    Public CHECK27 As UInt32
    Public CHECK28 As UInt32
    Public CHECK29 As UInt32
    Public CHECK30 As UInt32
    Public CHECK31 As UInt32
    Public CHECK32 As UInt32
    Public CHECK33 As UInt32
    Public CHECK34 As UInt32
    Public CHECK35 As UInt32
    Public CHECK36 As UInt32
    Public CHECK37 As UInt32
    Public CHECK38 As UInt32
    Public CHECK39 As UInt32
    Public CHECK40 As UInt32
    Public CHECK141 As UInt32 ' a apartir de aqui para buscar lo nuevo
    Public CHECK142 As UInt32
    
   


    Public Nom_Jugador_shirt As String
    Public Nom_Jugador As String
    Public Team1 As String
    Public Team2 As String
    Public boot_id As UInt16
    Public boot_name As String
    Public Glove_id As UInt16
    Public Glove_name As String




    Public Sub Leer_valores(ByVal selected_index As Integer)
        Index = selected_index * Player.tamanho_bloque
        'le pongo 4 bytes del pes2016
        Form1.Leer_Player.BaseStream.Position = Index + Valor_32_nuevo_pos
        Valor32_nuevo = swaps.swap32(Form1.Leer_Player.ReadUInt32())
        Form1.Valor_nuevo32_box.Value = Valor32_nuevo
        Valor32_nuevo_2 = swaps.swap32(Form1.Leer_Player.ReadUInt32())
        Form1.Valor_nuevo32_2_box.Value = Valor32_nuevo_2

        Form1.Leer_Player.BaseStream.Position = Index + Id_32_pos
        'Read Player Id
        Player_ID = swaps.swap32(Form1.Leer_Player.ReadUInt32())
        Form1.Player_num.Value = Player_ID
        Form1.Player_id_orig = Player_ID
        Form1.ID_ORIGINAL_ANTES_CAMBIAR = Player_ID
        Dim Resultado As Double = Player_ID - 262144

        If Resultado > 0 Then
            Form1.CheckBoxFAKE_ID.Checked = True
        Else
            Form1.CheckBoxFAKE_ID.Checked = False

        End If

        ' First Block of 32 bytes decoding
        Form1.Leer_Player.BaseStream.Position = Index + 12
        Dim original_32_first_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_first_val = swaps.swap32(original_32_first_val)
            original_32_first_val = converter.bitworking_Player32_1_toPc(original_32_first_val)
        End If

        'move bits to the right same than map 
        place_kicking = original_32_first_val >> 26
        place_kicking = place_kicking + 40 '30 is min value ''''es set piece tacking
        Form1.Set_piece_taking_box.Value = place_kicking
        'move bits to the left same than map
        Height = original_32_first_val << 6
        'move bits to the right to be at the begining and have correct value
        Height = Height >> 24
        Height = Height + 100 'min value
        Form1.height_box.Value = Height
        ' Then a 0000 block and nationality, already decoded
        'Second block of 32 bytes
        Nacionalizado = original_32_first_val << 14
        Nacionalizado = Nacionalizado >> 23
        Form1.Nationalized_box.Value = Nacionalizado


        ' Buscar nacionalidad nombre.

        For i = 0 To Form1.DataGridView_Countries.Rows.Count - 1
            If Form1.DataGridView_Countries.Rows(i).Cells(0).Value = Nacionalizado.ToString Then
                Texto_Nacionalizado = Form1.DataGridView_Countries.Rows(i).Cells(1).Value.ToString
            End If
        Next
        Form1.Label112.Text = Texto_Nacionalizado

        Nacion = original_32_first_val << 23
        Nacion = Nacion >> 23
        Form1.Nation_box.Value = Nacion

        country = Nacion
        ' Buscar nacionalidad nombre.

        For i = 0 To Form1.DataGridView_Countries.Rows.Count - 1
            If Form1.DataGridView_Countries.Rows(i).Cells(0).Value = Nacion.ToString Then
                Texto_Nacion = Form1.DataGridView_Countries.Rows(i).Cells(1).Value.ToString
            End If
        Next
        Form1.Label111.Text = Texto_Nacion




        Form1.Leer_Player.BaseStream.Position = Index + 16
        Dim original_32_second_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_second_val = swaps.swap32(original_32_second_val)
            original_32_second_val = converter.bitworking_Player32_14_toPc(original_32_second_val)
        End If
        'Early cross no existe 

        'Early_Cross = original_32_second_val >> 31
        'If Early_Cross = 1 Then
        'Form1.CheckBox41.Checked = True
        'Else
        'Form1.CheckBox41.Checked = False
        'End If


        def_prowess = original_32_second_val >> 26
        'First get out that bit from violet block then move to the right to be at first position.
        'def_prowess = def_prowess >> 26
        Form1.def_prowess_box.Value = def_prowess + 40 ' min value defensive prowess
        'Always the same for all blocks
        Clearing = original_32_second_val << 6
        Clearing = Clearing >> 26
        Form1.Clearing_box.Value = Clearing + 40 'min val 
        Low_pass = original_32_second_val << 12
        Low_pass = Low_pass >> 26
        Form1.Low_pass_box.Value = Low_pass + 40 'min val
        Goal_celeb = original_32_second_val << 18
        Goal_celeb = Goal_celeb >> 25
        Form1.Goal_celeb_box.Value = Goal_celeb
        weight = original_32_second_val << 25
        weight = weight >> 25
        Form1.weight_box.Value = weight + 30

        Dim original_32_3rd_val As UInt32 = Form1.Leer_Player.ReadUInt32
        'First single bit is last one of Nationality
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_3rd_val = swaps.swap32(original_32_3rd_val)
            original_32_3rd_val = converter.bitworking_Player32_2_toPc(original_32_3rd_val)
        End If

        LB = original_32_3rd_val >> 30
        'First get out that bit from violet block then move to the right to be at first position.

        Form1.LB_box.Value = LB  ' min value defensive prowess
        'Always the same for all blocks
        coverage = original_32_3rd_val << 2
        coverage = coverage >> 26
        Form1.coverage_box.Value = coverage + 40 'min val 
        catching = original_32_3rd_val << 8
        catching = catching >> 26
        Form1.catching_box.Value = catching + 40 'min val
        Jump = original_32_3rd_val << 14
        Jump = Jump >> 26
        Form1.Jump_box.Value = Jump + 40
        Header = original_32_3rd_val << 20
        Header = Header >> 26
        Form1.Header_box.Value = Header + 40 ' min val 
        Ball_control = original_32_3rd_val << 26
        Ball_control = Ball_control >> 26
        Form1.Ball_control_box.Value = Ball_control + 40 ' min val 



        Dim original_32_4th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_4th_val = swaps.swap32(original_32_4th_val)
            original_32_4th_val = converter.bitworking_Player32_2_toPc(original_32_4th_val)
        End If


        ''First single bit is last one of Nationality
        GK = original_32_4th_val >> 30
        'First get out that bit from violet block then move to the right to be at first position.

        Form1.GK_box.Value = GK  ' min value defensive prowess
        'Always the same for all blocks
        GoalKeeping = original_32_4th_val << 2
        GoalKeeping = GoalKeeping >> 26
        Form1.GoalKeeping_box.Value = GoalKeeping + 40 'min val 
        Reflexes = original_32_4th_val << 8
        Reflexes = Reflexes >> 26
        Form1.Reflexes_Box.Value = Reflexes + 40 'min val
        Finishing = original_32_4th_val << 14
        Finishing = Finishing >> 26
        Form1.Finishing_box.Value = Finishing + 40
        Ball_winning = original_32_4th_val << 20
        Ball_winning = Ball_winning >> 26
        Form1.Ball_winning_box.Value = Ball_winning + 40 ' min val 
        Speed = original_32_4th_val << 26
        Speed = Speed >> 26
        Form1.Speed_box.Value = Speed + 40 ' min val 

        Dim original_32_5th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_5th_val = swaps.swap32(original_32_5th_val)
            original_32_5th_val = converter.bitworking_Player32_2_toPc(original_32_5th_val)
        End If


        'First single bit is last one of Nationality
        Penalty_kick = original_32_5th_val >> 30
        Form1.Penalty_kick_box.Value = Penalty_kick + 1 ' min value defensive prowess
        'Always the same for all blocks
        Kicking_power = original_32_5th_val << 2
        Kicking_power = Kicking_power >> 26
        Form1.Kicking_power_box.Value = Kicking_power + 40 'min val 
        Dribling = original_32_5th_val << 8
        Dribling = Dribling >> 26
        Form1.Dribling_box.Value = Dribling + 40 'min val
        Explosive_power = original_32_5th_val << 14
        Explosive_power = Explosive_power >> 26
        Form1.Explosive_power_box.Value = Explosive_power + 40
        Stamina = original_32_5th_val << 20
        Stamina = Stamina >> 26
        Form1.Stamina_box.Value = Stamina + 40 ' min val 
        Swerve = original_32_5th_val << 26
        Swerve = Swerve >> 26
        Form1.Swerve_box.Value = Swerve + 40 ' min val 

        Dim original_32_6th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_6th_val = swaps.swap32(original_32_6th_val)
            original_32_6th_val = converter.bitworking_Player32_2_toPc(original_32_6th_val)
        End If


        'First single bit is last one of Nationality
        Pink_2 = original_32_6th_val >> 30
        Form1.Pink_2_box.Value = Pink_2 '+ 1 
        'Always the same for all blocks
        Age = original_32_6th_val << 2
        Age = Age >> 26
        Form1.Age_box.Value = Age + 15 'min val 
        Lofted_pass = original_32_6th_val << 8
        Lofted_pass = Lofted_pass >> 26
        Form1.Lofted_pass_box.Value = Lofted_pass + 40 'min val
        Physical_Contact = original_32_6th_val << 14
        Physical_Contact = Physical_Contact >> 26
        Form1.Physical_Contact_box.Value = Physical_Contact + 40
        Body_Balance = original_32_6th_val << 20
        Body_Balance = Body_Balance >> 26
        Form1.Body_Balance_box.Value = Body_Balance + 40 ' min val 
        Attacking_Prowess = original_32_6th_val << 26
        Attacking_Prowess = Attacking_Prowess >> 26
        Form1.Attacking_Prowess_box.Value = Attacking_Prowess + 40 ' min val 


        Dim original_32_7th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_7th_val = swaps.swap32(original_32_7th_val)
            original_32_7th_val = converter.bitworking_Player32_12_toPc(original_32_7th_val)
            original_32_7th_val = swaps.swap32(original_32_7th_val)
        End If



        'First single bit is last one of Nationality
        Weak_foot_use = original_32_7th_val >> 30
        Form1.Weak_foot_use_box.Value = Weak_foot_use + 1 'min val 

        DMF = original_32_7th_val << 2
        'First get out that bit from violet block then move to the right to be at first position.
        DMF = DMF >> 30
        Form1.DMF_box.Value = DMF   ' min value defensive prowess
        'Always the same for all blocks
        ulti_nuevo = original_32_7th_val << 4
        ulti_nuevo = ulti_nuevo >> 29
        Form1.ulti_nuevo_box.Value = ulti_nuevo
        Running_arm_mov = original_32_7th_val << 7
        Running_arm_mov = Running_arm_mov >> 29
        Form1.Running_arm_mov_box.Value = Running_arm_mov + 1
        Dribling_arm_mov = original_32_7th_val << 10
        Dribling_arm_mov = Dribling_arm_mov >> 29
        Form1.Dribling_arm_mov_box.Value = Dribling_arm_mov + 1
        Corner_kick = original_32_7th_val << 13
        Corner_kick = Corner_kick >> 29
        Form1.Corner_kick_box.Value = Corner_kick + 1  ' min val 
        FORM = original_32_7th_val << 16
        FORM = FORM >> 29
        Form1.FORM_box.Value = FORM + 1


        Position = original_32_7th_val << 19
        Position = Position >> 28
        Form1.Position_box.Value = Position
        Free_kick = original_32_7th_val << 23
        Free_kick = Free_kick >> 28
        Form1.Free_kick_box.Value = Free_kick + 1
        Playing_Style = original_32_7th_val << 27
        Playing_Style = Playing_Style >> 27
        Form1.Playing_Style_box.Value = Playing_Style   ' min val 


        Dim original_32_8th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_8th_val = swaps.swap32(original_32_8th_val)
            original_32_8th_val = converter.bitworking_Player32_13_toPc(original_32_8th_val)
            original_32_8th_val = swaps.swap32(original_32_8th_val)
        End If

        CHECK1 = original_32_8th_val >> 31
        If CHECK1 = 1 Then
            Form1.CheckBox1.Checked = True
        Else
            Form1.CheckBox1.Checked = False
        End If
        CHECK2 = original_32_8th_val << 1
        CHECK2 = CHECK2 >> 31
        If CHECK2 = 1 Then
            Form1.CheckBox2.Checked = True
        Else
            Form1.CheckBox2.Checked = False
        End If



        Runing_Hutching = original_32_8th_val << 2
        Runing_Hutching = Runing_Hutching >> 30
        Form1.Runing_Hutching_box.Value = Runing_Hutching + 1 ' min val 


        SS = original_32_8th_val << 4
        SS = SS >> 30
        Form1.SS_box.Value = SS





        Blue_2 = original_32_8th_val << 6
        Blue_2 = Blue_2 >> 30
        Form1.blue_2_box.Value = Blue_2

        RWF = original_32_8th_val << 8
        RWF = RWF >> 30
        Form1.RWF_box.Value = RWF
        LMF = original_32_8th_val << 10
        LMF = LMF >> 30
        Form1.LMF_box.Value = LMF
        RB = original_32_8th_val << 12
        RB = RB >> 30
        Form1.RB_box.Value = RB
        LWF = original_32_8th_val << 14
        LWF = LWF >> 30
        Form1.LWF_box.Value = LWF
        CF = original_32_8th_val << 16
        CF = CF >> 30
        Form1.CF_box.Value = CF
        CB = original_32_8th_val << 18
        CB = CB >> 30
        Form1.CB_box.Value = CB
        Dribling_hutching = original_32_8th_val << 20
        Dribling_hutching = Dribling_hutching >> 30
        Form1.Dribling_hutching_box.Value = Dribling_hutching + 1
        AMF = original_32_8th_val << 22
        AMF = AMF >> 30
        Form1.AMF_box.Value = AMF
        Weak_foot_acc = original_32_8th_val << 24
        Weak_foot_acc = Weak_foot_acc >> 30
        Form1.Weak_foot_acc_box.Value = Weak_foot_acc + 1
        RMF = original_32_8th_val << 26
        RMF = RMF >> 30
        Form1.RMF_box.Value = RMF
        Injury_res = original_32_8th_val << 28
        Injury_res = Injury_res >> 30
        Form1.Injury_res__box.Value = Injury_res + 1

        CMF = original_32_8th_val << 30
        CMF = CMF >> 30
        Form1.CMF_box.Value = CMF






        Dim original_32_9th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_9th_val = swaps.swap32(converter.Reverse_int32(original_32_9th_val))

        End If

        CHECK9 = original_32_9th_val >> 31
        If CHECK9 = 1 Then
            Form1.CheckBox9.Checked = True
        Else
            Form1.CheckBox9.Checked = False
        End If
        CHECK10 = original_32_9th_val << 1
        CHECK10 = CHECK10 >> 31
        If CHECK10 = 1 Then
            Form1.CheckBox10.Checked = True
        Else
            Form1.CheckBox10.Checked = False
        End If
        CHECK11 = original_32_9th_val << 2
        CHECK11 = CHECK11 >> 31
        If CHECK11 = 1 Then
            Form1.CheckBox11.Checked = True
        Else
            Form1.CheckBox11.Checked = False
        End If
        CHECK12 = original_32_9th_val << 3
        CHECK12 = CHECK12 >> 31
        If CHECK12 = 1 Then
            Form1.CheckBox12.Checked = True
        Else
            Form1.CheckBox12.Checked = False
        End If
        CHECK13 = original_32_9th_val << 4
        CHECK13 = CHECK13 >> 31
        If CHECK13 = 1 Then
            Form1.CheckBox13.Checked = True
        Else
            Form1.CheckBox13.Checked = False
        End If
        CHECK14 = original_32_9th_val << 5
        CHECK14 = CHECK14 >> 31
        If CHECK14 = 1 Then
            Form1.CheckBox14.Checked = True
        Else
            Form1.CheckBox14.Checked = False
        End If
        CHECK15 = original_32_9th_val << 6
        CHECK15 = CHECK15 >> 31
        If CHECK15 = 1 Then
            Form1.CheckBox15.Checked = True
        Else
            Form1.CheckBox15.Checked = False
        End If
        CHECK16 = original_32_9th_val << 7
        CHECK16 = CHECK16 >> 31
        If CHECK16 = 1 Then
            Form1.CheckBox16.Checked = True
        Else
            Form1.CheckBox16.Checked = False
        End If
        CHECK25 = original_32_9th_val << 8
        CHECK25 = CHECK25 >> 31
        If CHECK25 = 1 Then
            Form1.CheckBox25.Checked = True
        Else
            Form1.CheckBox25.Checked = False
        End If
        CHECK17 = original_32_9th_val << 9 'Stronger foot
        CHECK17 = CHECK17 >> 31
        If CHECK17 = 1 Then
            Form1.CheckBox17.Checked = True
        Else
            Form1.CheckBox17.Checked = False
        End If
        CHECK19 = original_32_9th_val << 10
        CHECK19 = CHECK19 >> 31
        If CHECK19 = 1 Then
            Form1.CheckBox19.Checked = True
        Else
            Form1.CheckBox19.Checked = False
        End If
        CHECK20 = original_32_9th_val << 11
        CHECK20 = CHECK20 >> 31
        If CHECK20 = 1 Then
            Form1.CheckBox20.Checked = True
        Else
            Form1.CheckBox20.Checked = False
        End If
        CHECK21 = original_32_9th_val << 12
        CHECK21 = CHECK21 >> 31
        If CHECK21 = 1 Then
            Form1.CheckBox21.Checked = True
        Else
            Form1.CheckBox21.Checked = False
        End If
        CHECK22 = original_32_9th_val << 13
        CHECK22 = CHECK22 >> 31
        If CHECK22 = 1 Then
            Form1.CheckBox22.Checked = True
        Else
            Form1.CheckBox22.Checked = False
        End If
        CHECK23 = original_32_9th_val << 14
        CHECK23 = CHECK23 >> 31
        If CHECK23 = 1 Then
            Form1.CheckBox23.Checked = True
        Else
            Form1.CheckBox23.Checked = False
        End If
        CHECK24 = original_32_9th_val << 15
        CHECK24 = CHECK24 >> 31
        If CHECK24 = 1 Then
            Form1.CheckBox24.Checked = True
        Else
            Form1.CheckBox24.Checked = False
        End If
        CHECK18 = original_32_9th_val << 16
        CHECK18 = CHECK18 >> 31
        If CHECK18 = 1 Then
            Form1.CheckBox18.Checked = True
        Else
            Form1.CheckBox18.Checked = False
        End If
        CHECK26 = original_32_9th_val << 17
        CHECK26 = CHECK26 >> 31
        If CHECK26 = 1 Then
            Form1.CheckBox26.Checked = True
        Else
            Form1.CheckBox26.Checked = False
        End If
        CHECK27 = original_32_9th_val << 18
        CHECK27 = CHECK27 >> 31
        If CHECK27 = 1 Then
            Form1.CheckBox27.Checked = True
        Else
            Form1.CheckBox27.Checked = False
        End If
        CHECK28 = original_32_9th_val << 19
        CHECK28 = CHECK28 >> 31
        If CHECK28 = 1 Then
            Form1.CheckBox28.Checked = True
        Else
            Form1.CheckBox28.Checked = False
        End If
        CHECK29 = original_32_9th_val << 20
        CHECK29 = CHECK29 >> 31
        If CHECK29 = 1 Then
            Form1.CheckBox29.Checked = True
        Else
            Form1.CheckBox29.Checked = False
        End If
        CHECK30 = original_32_9th_val << 21
        CHECK30 = CHECK30 >> 31
        If CHECK30 = 1 Then
            Form1.CheckBox30.Checked = True
        Else
            Form1.CheckBox30.Checked = False
        End If
        CHECK31 = original_32_9th_val << 22
        CHECK31 = CHECK31 >> 31
        If CHECK31 = 1 Then
            Form1.CheckBox31.Checked = True
        Else
            Form1.CheckBox31.Checked = False
        End If
        CHECK32 = original_32_9th_val << 23
        CHECK32 = CHECK32 >> 31
        If CHECK32 = 1 Then
            Form1.CheckBox32.Checked = True
        Else
            Form1.CheckBox32.Checked = False
        End If
        CHECK33 = original_32_9th_val << 24
        CHECK33 = CHECK33 >> 31
        If CHECK33 = 1 Then
            Form1.CheckBox33.Checked = True
        Else
            Form1.CheckBox33.Checked = False
        End If
        CHECK34 = original_32_9th_val << 25
        CHECK34 = CHECK34 >> 31
        If CHECK34 = 1 Then
            Form1.CheckBox34.Checked = True
        Else
            Form1.CheckBox34.Checked = False
        End If
        CHECK35 = original_32_9th_val << 26
        CHECK35 = CHECK35 >> 31
        If CHECK35 = 1 Then
            Form1.CheckBox35.Checked = True
        Else
            Form1.CheckBox35.Checked = False
        End If
        CHECK36 = original_32_9th_val << 27
        CHECK36 = CHECK36 >> 31
        If CHECK36 = 1 Then
            Form1.CheckBox36.Checked = True
        Else
            Form1.CheckBox36.Checked = False
        End If
        CHECK37 = original_32_9th_val << 28
        CHECK37 = CHECK37 >> 31
        If CHECK37 = 1 Then
            Form1.CheckBox37.Checked = True
        Else
            Form1.CheckBox37.Checked = False
        End If
        CHECK38 = original_32_9th_val << 29
        CHECK38 = CHECK38 >> 31
        If CHECK38 = 1 Then
            Form1.CheckBox38.Checked = True
        Else
            Form1.CheckBox38.Checked = False
        End If
        CHECK39 = original_32_9th_val << 30
        CHECK39 = CHECK39 >> 31
        If CHECK39 = 1 Then
            Form1.CheckBox39.Checked = True
        Else
            Form1.CheckBox39.Checked = False
        End If
        CHECK40 = original_32_9th_val << 31
        CHECK40 = CHECK40 >> 31
        If CHECK40 = 1 Then
            Form1.CheckBox40.Checked = True
        Else
            Form1.CheckBox40.Checked = False
        End If






        Dim byte_nuevo As Byte = Form1.Leer_Player.ReadByte
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            byte_nuevo = converter.Reverse_byte(byte_nuevo)

        End If



        CHECK3 = byte_nuevo >> 7
        If CHECK3 = 1 Then
            Form1.CheckBox3.Checked = True
        Else
            Form1.CheckBox3.Checked = False
        End If
        CHECK4 = byte_nuevo << 1
        CHECK4 = CHECK4 >> 7
        If CHECK4 = 1 Then
            Form1.CheckBox4.Checked = True
        Else
            Form1.CheckBox4.Checked = False
        End If
        CHECK5 = byte_nuevo << 2
        CHECK5 = CHECK5 >> 7
        If CHECK5 = 1 Then
            Form1.CheckBox5.Checked = True
        Else
            Form1.CheckBox5.Checked = False
        End If
        CHECK6 = byte_nuevo << 3
        CHECK6 = CHECK6 >> 7
        If CHECK6 = 1 Then
            Form1.CheckBox6.Checked = True
        Else
            Form1.CheckBox6.Checked = False
        End If
        CHECK7 = byte_nuevo << 4
        CHECK7 = CHECK7 >> 7
        If CHECK7 = 1 Then
            Form1.CheckBox7.Checked = True
        Else
            Form1.CheckBox7.Checked = False
        End If
        CHECK8 = byte_nuevo << 5
        CHECK8 = CHECK8 >> 7
        If CHECK8 = 1 Then
            Form1.CheckBox8.Checked = True
        Else
            Form1.CheckBox8.Checked = False
        End If

        CHECK141 = byte_nuevo << 6
        CHECK141 = CHECK141 >> 7
        If CHECK141 = 1 Then
            Form1.CheckBox111.Checked = True
        Else
            Form1.CheckBox111.Checked = False
        End If

        CHECK142 = byte_nuevo << 7
        CHECK142 = CHECK142 >> 7
        If CHECK142 = 1 Then
            Form1.CheckBox112.Checked = True
        Else
            Form1.CheckBox112.Checked = False
        End If



        ''''Nombres Camiseta


        Form1.Leer_Player.BaseStream.Position = Index + Nombre_camiseta_pos

        Nom_Jugador_shirt = Form1.Leer_Player.ReadChars(44)
        Nom_Jugador_shirt = Nom_Jugador_shirt.TrimEnd("")
        Form1.Shirt_name.Text = Nom_Jugador_shirt

        Form1.Leer_Player.BaseStream.Position = Index + Nombre_pos
        Nom_Jugador = Form1.Leer_Player.ReadChars(44)
        Nom_Jugador = Nom_Jugador.TrimEnd("")
        Form1.Name_box.Text = Nom_Jugador



    End Sub

    Public Sub Leer_valores_sin_pantalla(ByVal selected_index As Integer)

        Index = selected_index * Player.tamanho_bloque
        'le pongo 4 bytes del pes2016
        Form1.Leer_Player.BaseStream.Position = Index + Valor_32_nuevo_pos
        Valor32_nuevo = swaps.swap32(Form1.Leer_Player.ReadUInt32())
        'Form1.Valor_nuevo32_box.Value = Valor32_nuevo
        Valor32_nuevo_2 = swaps.swap32(Form1.Leer_Player.ReadUInt32())
        'Form1.Valor_nuevo32_2_box.Value = Valor32_nuevo_2

        Form1.Leer_Player.BaseStream.Position = Index + Id_32_pos
        'Read Player Id
        Player_ID = swaps.swap32(Form1.Leer_Player.ReadUInt32())
        ' Form1.Player_num.Value = Player_ID
        Form1.ID_ORIGINAL_ANTES_CAMBIAR = Player_ID

        Form1.Leer_Player.BaseStream.Position = Index + 12
        Dim original_32_first_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_first_val = swaps.swap32(original_32_first_val)
            original_32_first_val = converter.bitworking_Player32_1_toPc(original_32_first_val)
        End If

        'move bits to the right same than map 
        place_kicking = original_32_first_val >> 26
        place_kicking = place_kicking + 40 '30 is min value ''''es set piece tacking
        'Form1.Set_piece_taking_box.Value = place_kicking
        'move bits to the left same than map
        Height = original_32_first_val << 6
        'move bits to the right to be at the begining and have correct value
        Height = Height >> 24
        Height = Height + 100 'min value
        ' Form1.height_box.Value = Height
        ' Then a 0000 block and nationality, already decoded
        'Second block of 32 bytes
        Nacionalizado = original_32_first_val << 14
        Nacionalizado = Nacionalizado >> 23
        ' Form1.Nationalized_box.Value = Nacionalizado


        ' Buscar nacionalidad nombre.

        'For i = 0 To Form1.DataGridView_Countries.Rows.Count - 1
        '    If Form1.DataGridView_Countries.Rows(i).Cells(0).Value = Nacionalizado.ToString Then
        '        Texto_Nacionalizado = Form1.DataGridView_Countries.Rows(i).Cells(1).Value.ToString
        '    End If
        'Next
        'Form1.Label112.Text = Texto_Nacionalizado

        Nacion = original_32_first_val << 23
        Nacion = Nacion >> 23
        'Form1.Nation_box.Value = Nacion

        country = Nacion
        ' Buscar nacionalidad nombre.

        'For i = 0 To Form1.DataGridView_Countries.Rows.Count - 1
        '    If Form1.DataGridView_Countries.Rows(i).Cells(0).Value = Nacion.ToString Then
        '        Texto_Nacion = Form1.DataGridView_Countries.Rows(i).Cells(1).Value.ToString
        '    End If
        'Next
        'Form1.Label111.Text = Texto_Nacion




        Form1.Leer_Player.BaseStream.Position = Index + 16
        Dim original_32_second_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_second_val = swaps.swap32(original_32_second_val)
            original_32_second_val = converter.bitworking_Player32_14_toPc(original_32_second_val)
        End If
        'Early cross no existe 

        'Early_Cross = original_32_second_val >> 31
        'If Early_Cross = 1 Then
        'Form1.CheckBox41.Checked = True
        'Else
        'Form1.CheckBox41.Checked = False
        'End If


        def_prowess = original_32_second_val >> 26
        'First get out that bit from violet block then move to the right to be at first position.

        'Form1.def_prowess_box.Value = def_prowess + 40 ' min value defensive prowess
        'Always the same for all blocks
        Clearing = original_32_second_val << 6
        Clearing = Clearing >> 26
        'Form1.Clearing_box.Value = Clearing + 40 'min val 
        Low_pass = original_32_second_val << 12
        Low_pass = Low_pass >> 26
        ' Form1.Low_pass_box.Value = Low_pass + 40 'min val
        Goal_celeb = original_32_second_val << 18
        Goal_celeb = Goal_celeb >> 25
        ' Form1.Goal_celeb_box.Value = Goal_celeb
        weight = original_32_second_val << 25
        weight = weight >> 25
        ' Form1.weight_box.Value = weight + 30

        Dim original_32_3rd_val As UInt32 = Form1.Leer_Player.ReadUInt32
        'First single bit is last one of Nationality
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_3rd_val = swaps.swap32(original_32_3rd_val)
            original_32_3rd_val = converter.bitworking_Player32_2_toPc(original_32_3rd_val)
        End If

        LB = original_32_3rd_val >> 30
        'First get out that bit from violet block then move to the right to be at first position.

        ' Form1.LB_box.Value = LB  ' min value defensive prowess
        'Always the same for all blocks
        coverage = original_32_3rd_val << 2
        coverage = coverage >> 26
        'Form1.coverage_box.Value = coverage + 40 'min val 
        catching = original_32_3rd_val << 8
        catching = catching >> 26
        'Form1.catching_box.Value = catching + 40 'min val
        Jump = original_32_3rd_val << 14
        Jump = Jump >> 26
        ' Form1.Jump_box.Value = Jump + 40
        Header = original_32_3rd_val << 20
        Header = Header >> 26
        'Form1.Header_box.Value = Header + 40 ' min val 
        Ball_control = original_32_3rd_val << 26
        Ball_control = Ball_control >> 26
        ' Form1.Ball_control_box.Value = Ball_control + 40 ' min val 



        Dim original_32_4th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_4th_val = swaps.swap32(original_32_4th_val)
            original_32_4th_val = converter.bitworking_Player32_2_toPc(original_32_4th_val)
        End If


        ''First single bit is last one of Nationality
        GK = original_32_4th_val >> 30
        'First get out that bit from violet block then move to the right to be at first position.

        'Form1.GK_box.Value = GK  ' min value defensive prowess
        'Always the same for all blocks
        GoalKeeping = original_32_4th_val << 2
        GoalKeeping = GoalKeeping >> 26
        ' Form1.GoalKeeping_box.Value = GoalKeeping + 40 'min val 
        Reflexes = original_32_4th_val << 8
        Reflexes = Reflexes >> 26
        ' Form1.Reflexes_Box.Value = Reflexes + 40 'min val
        Finishing = original_32_4th_val << 14
        Finishing = Finishing >> 26
        ' Form1.Finishing_box.Value = Finishing + 40
        Ball_winning = original_32_4th_val << 20
        Ball_winning = Ball_winning >> 26
        ' Form1.Ball_winning_box.Value = Ball_winning + 40 ' min val 
        Speed = original_32_4th_val << 26
        Speed = Speed >> 26
        ' Form1.Speed_box.Value = Speed + 40 ' min val 

        Dim original_32_5th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_5th_val = swaps.swap32(original_32_5th_val)
            original_32_5th_val = converter.bitworking_Player32_2_toPc(original_32_5th_val)
        End If


        'First single bit is last one of Nationality
        Penalty_kick = original_32_5th_val >> 30
        ' Form1.Penalty_kick_box.Value = Penalty_kick + 1 ' min value defensive prowess
        'Always the same for all blocks
        Kicking_power = original_32_5th_val << 2
        Kicking_power = Kicking_power >> 26
        ' Form1.Kicking_power_box.Value = Kicking_power + 40 'min val 
        Dribling = original_32_5th_val << 8
        Dribling = Dribling >> 26
        'Form1.Dribling_box.Value = Dribling + 40 'min val
        Explosive_power = original_32_5th_val << 14
        Explosive_power = Explosive_power >> 26
        ' Form1.Explosive_power_box.Value = Explosive_power + 40
        Stamina = original_32_5th_val << 20
        Stamina = Stamina >> 26
        'Form1.Stamina_box.Value = Stamina + 40 ' min val 
        Swerve = original_32_5th_val << 26
        Swerve = Swerve >> 26
        ' Form1.Swerve_box.Value = Swerve + 40 ' min val 

        Dim original_32_6th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_6th_val = swaps.swap32(original_32_6th_val)
            original_32_6th_val = converter.bitworking_Player32_2_toPc(original_32_6th_val)
        End If


        'First single bit is last one of Nationality
        Pink_2 = original_32_6th_val >> 30
        ' Form1.Pink_2_box.Value = Pink_2 '+ 1 
        'Always the same for all blocks
        Age = original_32_6th_val << 2
        Age = Age >> 26
        ' Form1.Age_box.Value = Age + 15 'min val 
        Lofted_pass = original_32_6th_val << 8
        Lofted_pass = Lofted_pass >> 26
        'Form1.Lofted_pass_box.Value = Lofted_pass + 40 'min val
        Physical_Contact = original_32_6th_val << 14
        Physical_Contact = Physical_Contact >> 26
        ' Form1.Physical_Contact_box.Value = Physical_Contact + 40
        Body_Balance = original_32_6th_val << 20
        Body_Balance = Body_Balance >> 26
        ' Form1.Body_Balance_box.Value = Body_Balance + 40 ' min val 
        Attacking_Prowess = original_32_6th_val << 26
        Attacking_Prowess = Attacking_Prowess >> 26
        ' Form1.Attacking_Prowess_box.Value = Attacking_Prowess + 40 ' min val 


        Dim original_32_7th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_7th_val = swaps.swap32(original_32_7th_val)
            original_32_7th_val = converter.bitworking_Player32_12_toPc(original_32_7th_val)
            original_32_7th_val = swaps.swap32(original_32_7th_val)
        End If



        'First single bit is last one of Nationality
        Weak_foot_use = original_32_7th_val >> 30
        ' Form1.Weak_foot_use_box.Value = Weak_foot_use + 1 'min val 

        DMF = original_32_7th_val << 2
        'First get out that bit from violet block then move to the right to be at first position.
        DMF = DMF >> 30
        '  Form1.DMF_box.Value = DMF   ' min value defensive prowess
        'Always the same for all blocks
        ulti_nuevo = original_32_7th_val << 4
        ulti_nuevo = ulti_nuevo >> 29
        ' Form1.ulti_nuevo_box.Value = ulti_nuevo
        Running_arm_mov = original_32_7th_val << 7
        Running_arm_mov = Running_arm_mov >> 29
        ' Form1.Running_arm_mov_box.Value = Running_arm_mov
        Dribling_arm_mov = original_32_7th_val << 10
        Dribling_arm_mov = Dribling_arm_mov >> 29
        ' Form1.Dribling_arm_mov_box.Value = Dribling_arm_mov
        Corner_kick = original_32_7th_val << 13
        Corner_kick = Corner_kick >> 29
        ' Form1.Corner_kick_box.Value = Corner_kick + 1  ' min val 
        FORM = original_32_7th_val << 16
        FORM = FORM >> 29
        ' Form1.FORM_box.Value = FORM + 1


        Position = original_32_7th_val << 19
        Position = Position >> 28
        'Form1.Position_box.Value = Position
        Free_kick = original_32_7th_val << 23
        Free_kick = Free_kick >> 28
        'Form1.Free_kick_box.Value = Free_kick + 1
        Playing_Style = original_32_7th_val << 27
        Playing_Style = Playing_Style >> 27
        ' Form1.Playing_Style_box.Value = Playing_Style   ' min val 


        Dim original_32_8th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_8th_val = swaps.swap32(original_32_8th_val)
            original_32_8th_val = converter.bitworking_Player32_13_toPc(original_32_8th_val)
            original_32_8th_val = swaps.swap32(original_32_8th_val)
        End If

        CHECK1 = original_32_8th_val >> 31
        'If CHECK1 = 1 Then
        '    Form1.CheckBox1.Checked = True
        'Else
        '    Form1.CheckBox1.Checked = False
        'End If
        CHECK2 = original_32_8th_val << 1
        CHECK2 = CHECK2 >> 31
        'If CHECK2 = 1 Then
        '    Form1.CheckBox2.Checked = True
        'Else
        '    Form1.CheckBox2.Checked = False
        'End If



        Runing_Hutching = original_32_8th_val << 2
        Runing_Hutching = Runing_Hutching >> 30
        ' Form1.Runing_Hutching_box.Value = Runing_Hutching + 1 ' min val 


        SS = original_32_8th_val << 4
        SS = SS >> 30
        ' Form1.SS_box.Value = SS





        Blue_2 = original_32_8th_val << 6
        Blue_2 = Blue_2 >> 30
        'Form1.blue_2_box.Value = Blue_2

        RWF = original_32_8th_val << 8
        RWF = RWF >> 30
        ' Form1.RWF_box.Value = RWF
        LMF = original_32_8th_val << 10
        LMF = LMF >> 30
        ' Form1.LMF_box.Value = LMF
        RB = original_32_8th_val << 12
        RB = RB >> 30
        ' Form1.RB_box.Value = RB
        LWF = original_32_8th_val << 14
        LWF = LWF >> 30
        ' Form1.LWF_box.Value = LWF
        CF = original_32_8th_val << 16
        CF = CF >> 30
        ' Form1.CF_box.Value = CF
        CB = original_32_8th_val << 18
        CB = CB >> 30
        ' Form1.CB_box.Value = CB
        Dribling_hutching = original_32_8th_val << 20
        Dribling_hutching = Dribling_hutching >> 30
        'Form1.Dribling_hutching_box.Value = Dribling_hutching + 1
        AMF = original_32_8th_val << 22
        AMF = AMF >> 30
        'Form1.AMF_box.Value = AMF
        Weak_foot_acc = original_32_8th_val << 24
        Weak_foot_acc = Weak_foot_acc >> 30
        'Form1.Weak_foot_acc_box.Value = Weak_foot_acc + 1
        RMF = original_32_8th_val << 26
        RMF = RMF >> 30
        ' Form1.RMF_box.Value = RMF
        Injury_res = original_32_8th_val << 28
        Injury_res = Injury_res >> 30
        'Form1.Injury_res__box.Value = Injury_res + 1

        CMF = original_32_8th_val << 30
        CMF = CMF >> 30
        'Form1.CMF_box.Value = CMF






        Dim original_32_9th_val As UInt32 = Form1.Leer_Player.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            original_32_9th_val = swaps.swap32(converter.Reverse_int32(original_32_9th_val))

        End If

        CHECK9 = original_32_9th_val >> 31

        CHECK10 = original_32_9th_val << 1
        CHECK10 = CHECK10 >> 31

        CHECK11 = original_32_9th_val << 2
        CHECK11 = CHECK11 >> 31

        CHECK12 = original_32_9th_val << 3
        CHECK12 = CHECK12 >> 31

        CHECK13 = original_32_9th_val << 4
        CHECK13 = CHECK13 >> 31

        CHECK14 = original_32_9th_val << 5
        CHECK14 = CHECK14 >> 31

        CHECK15 = original_32_9th_val << 6
        CHECK15 = CHECK15 >> 31

        CHECK16 = original_32_9th_val << 7
        CHECK16 = CHECK16 >> 31

        CHECK17 = original_32_9th_val << 8
        CHECK17 = CHECK17 >> 31

        CHECK25 = original_32_9th_val << 9 'Stronger foot
        CHECK25 = CHECK25 >> 31

        CHECK19 = original_32_9th_val << 10
        CHECK19 = CHECK19 >> 31

        CHECK20 = original_32_9th_val << 11
        CHECK20 = CHECK20 >> 31

        CHECK21 = original_32_9th_val << 12
        CHECK21 = CHECK21 >> 31

        CHECK22 = original_32_9th_val << 13
        CHECK22 = CHECK22 >> 31

        CHECK23 = original_32_9th_val << 14
        CHECK23 = CHECK23 >> 31

        CHECK24 = original_32_9th_val << 15
        CHECK24 = CHECK24 >> 31

        CHECK18 = original_32_9th_val << 16
        CHECK18 = CHECK18 >> 31

        CHECK26 = original_32_9th_val << 17
        CHECK26 = CHECK26 >> 31

        CHECK27 = original_32_9th_val << 18
        CHECK27 = CHECK27 >> 31

        CHECK28 = original_32_9th_val << 19
        CHECK28 = CHECK28 >> 31

        CHECK29 = original_32_9th_val << 20
        CHECK29 = CHECK29 >> 31

        CHECK30 = original_32_9th_val << 21
        CHECK30 = CHECK30 >> 31

        CHECK31 = original_32_9th_val << 22
        CHECK31 = CHECK31 >> 31

        CHECK32 = original_32_9th_val << 23
        CHECK32 = CHECK32 >> 31

        CHECK33 = original_32_9th_val << 24
        CHECK33 = CHECK33 >> 31

        CHECK34 = original_32_9th_val << 25
        CHECK34 = CHECK34 >> 31

        CHECK35 = original_32_9th_val << 26
        CHECK35 = CHECK35 >> 31

        CHECK36 = original_32_9th_val << 27
        CHECK36 = CHECK36 >> 31

        CHECK37 = original_32_9th_val << 28
        CHECK37 = CHECK37 >> 31

        CHECK38 = original_32_9th_val << 29
        CHECK38 = CHECK38 >> 31

        CHECK39 = original_32_9th_val << 30
        CHECK39 = CHECK39 >> 31

        CHECK40 = original_32_9th_val << 31
        CHECK40 = CHECK40 >> 31







        Dim byte_nuevo As Byte = Form1.Leer_Player.ReadByte
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            byte_nuevo = converter.Reverse_byte(byte_nuevo)

        End If



        CHECK3 = byte_nuevo >> 7

        CHECK4 = byte_nuevo << 1
        CHECK4 = CHECK4 >> 7

        CHECK5 = byte_nuevo << 2
        CHECK5 = CHECK5 >> 7

        CHECK6 = byte_nuevo << 3
        CHECK6 = CHECK6 >> 7

        CHECK7 = byte_nuevo << 4
        CHECK7 = CHECK7 >> 7

        CHECK8 = byte_nuevo << 5
        CHECK8 = CHECK8 >> 7


        CHECK141 = byte_nuevo << 6
        CHECK141 = CHECK141 >> 7


        CHECK142 = byte_nuevo << 7
        CHECK142 = CHECK142 >> 7




        ''''Nombres Camiseta


        Form1.Leer_Player.BaseStream.Position = Index + Nombre_camiseta_pos

        Nom_Jugador_shirt = Form1.Leer_Player.ReadChars(44)
        Nom_Jugador_shirt = Nom_Jugador_shirt.TrimEnd("")
        ' Form1.Shirt_name.Text = Nom_Jugador_shirt

        Form1.Leer_Player.BaseStream.Position = Index + Nombre_pos
        Nom_Jugador = Form1.Leer_Player.ReadChars(44)
        Nom_Jugador = Nom_Jugador.TrimEnd("")
        ' Form1.Name_box.Text = Nom_Jugador




    End Sub

    Public Sub Grabar_valores(ByVal selected_index As Integer)

        Index = selected_index * tamanho_bloque
        Form1.Leer_Player.BaseStream.Position = Index
        Dim Num_nuevo_32 As UInt32 = Form1.Valor_nuevo32_box.Value
        Form1.Grabar_player.Write(swaps.swap32(Num_nuevo_32))
        Dim Num_nuevo_32_2 As UInt32 = Form1.Valor_nuevo32_2_box.Value
        Form1.Grabar_player.Write(swaps.swap32(Num_nuevo_32_2))
        Dim Player_ID As UInt32 = Form1.Player_num.Value
        Form1.Grabar_player.Write(swaps.swap32(Player_ID))

        'Grabar primer valor 32

        Dim Nuevo_val_32_first As UInt32

        Dim Height As UInt32 = Form1.height_box.Value - 100
        Dim Nacionalizado As UInt32 = Form1.Nationalized_box.Value
        Dim Nacion As UInt32 = Form1.Nation_box.Value
        Dim place_kicking As UInt32 = Form1.Set_piece_taking_box.Value - 40

        Dim Aux As UInt32
        Aux = place_kicking
        Aux = Aux << 26
        Nuevo_val_32_first = (Aux Or Nuevo_val_32_first)
        Aux = Height
        Aux = Aux << 18
        Nuevo_val_32_first = (Aux Or Nuevo_val_32_first)
        Aux = Nacionalizado
        Aux = Aux << 9
        Nuevo_val_32_first = (Aux Or Nuevo_val_32_first)
        Aux = Nacion
        'Aux = Aux << 9
        Nuevo_val_32_first = (Aux Or Nuevo_val_32_first)


        'Grabar Segundo

        Dim Nuevo_val_32_2nd As UInt32

        'Dim Early_cross As UInt32
        'If Form1.CheckBox41.Checked = True Then
        '    Early_cross = 1
        'Else
        '    Early_cross = 0
        'End If

        Dim def_prowess As UInt32 = Form1.def_prowess_box.Value - 40
        Dim Clearing As UInt32 = Form1.Clearing_box.Value - 40
        Dim Low_pass As UInt32 = Form1.Low_pass_box.Value - 40
        Dim weight As UInt32 = Form1.weight_box.Value - 30
        Dim Goal_celeb As UInt32 = Form1.Goal_celeb_box.Value


        Aux = def_prowess
        Aux = Aux << 26
        Nuevo_val_32_2nd = (Aux Or Nuevo_val_32_2nd)
        Aux = Clearing
        Aux = Aux << 20
        Nuevo_val_32_2nd = (Aux Or Nuevo_val_32_2nd)
        Aux = Low_pass
        Aux = Aux << 14
        Nuevo_val_32_2nd = (Aux Or Nuevo_val_32_2nd)
        Aux = Goal_celeb
        Aux = Aux << 7
        Nuevo_val_32_2nd = (Aux Or Nuevo_val_32_2nd)
        Aux = weight
        'Aux = Aux << 7
        Nuevo_val_32_2nd = (Aux Or Nuevo_val_32_2nd)

        'Grabar Tercero

        Dim Nuevo_val_32_3rd As UInt32
        Dim LB As UInt32 = Form1.LB_box.Value
        Dim coverage As UInt32 = Form1.coverage_box.Value - 40
        Dim catching As UInt32 = Form1.catching_box.Value - 40
        Dim Jump As UInt32 = Form1.Jump_box.Value - 40
        Dim Header As UInt32 = Form1.Header_box.Value - 40
        Dim Ball_control As UInt32 = Form1.Ball_control_box.Value - 40


        Aux = LB
        Aux = Aux << 30
        Nuevo_val_32_3rd = (Aux Or Nuevo_val_32_3rd)
        Aux = coverage
        Aux = Aux << 24
        Nuevo_val_32_3rd = (Aux Or Nuevo_val_32_3rd)
        Aux = catching
        Aux = Aux << 18
        Nuevo_val_32_3rd = (Aux Or Nuevo_val_32_3rd)
        Aux = Jump
        Aux = Aux << 12
        Nuevo_val_32_3rd = (Aux Or Nuevo_val_32_3rd)
        Aux = Header
        Aux = Aux << 6
        Nuevo_val_32_3rd = (Aux Or Nuevo_val_32_3rd)
        Aux = Ball_control
        'Aux = Aux << 7
        Nuevo_val_32_3rd = (Aux Or Nuevo_val_32_3rd)

        'Grabar cuarto

        Dim Nuevo_val_32_4th As UInt32
        Dim GK As UInt32 = Form1.GK_box.Value
        Dim GoalKeeping As UInt32 = Form1.GoalKeeping_box.Value - 40
        Dim Reflexes As UInt32 = Form1.Reflexes_Box.Value - 40
        Dim Finishing As UInt32 = Form1.Finishing_box.Value - 40
        Dim Ball_winning As UInt32 = Form1.Ball_winning_box.Value - 40
        Dim Speed As UInt32 = Form1.Speed_box.Value - 40


        Aux = GK
        Aux = Aux << 30
        Nuevo_val_32_4th = (Aux Or Nuevo_val_32_4th)
        Aux = GoalKeeping
        Aux = Aux << 24
        Nuevo_val_32_4th = (Aux Or Nuevo_val_32_4th)
        Aux = Reflexes
        Aux = Aux << 18
        Nuevo_val_32_4th = (Aux Or Nuevo_val_32_4th)
        Aux = Finishing
        Aux = Aux << 12
        Nuevo_val_32_4th = (Aux Or Nuevo_val_32_4th)
        Aux = Ball_winning
        Aux = Aux << 6
        Nuevo_val_32_4th = (Aux Or Nuevo_val_32_4th)
        Aux = Speed
        'Aux = Aux << 7
        Nuevo_val_32_4th = (Aux Or Nuevo_val_32_4th)

        'Grabar wuinto

        Dim Nuevo_val_32_5th As UInt32
        Dim Penalty_kick As UInt32 = Form1.Penalty_kick_box.Value - 1
        Dim Kicking_power As UInt32 = Form1.Kicking_power_box.Value - 40
        Dim Dribling As UInt32 = Form1.Dribling_box.Value - 40
        Dim Explosive_power As UInt32 = Form1.Explosive_power_box.Value - 40
        Dim Stamina As UInt32 = Form1.Stamina_box.Value - 40
        Dim Swerve As UInt32 = Form1.Swerve_box.Value - 40


        Aux = Penalty_kick
        Aux = Aux << 30
        Nuevo_val_32_5th = (Aux Or Nuevo_val_32_5th)
        Aux = Kicking_power
        Aux = Aux << 24
        Nuevo_val_32_5th = (Aux Or Nuevo_val_32_5th)
        Aux = Dribling
        Aux = Aux << 18
        Nuevo_val_32_5th = (Aux Or Nuevo_val_32_5th)
        Aux = Explosive_power
        Aux = Aux << 12
        Nuevo_val_32_5th = (Aux Or Nuevo_val_32_5th)
        Aux = Stamina
        Aux = Aux << 6
        Nuevo_val_32_5th = (Aux Or Nuevo_val_32_5th)
        Aux = Swerve
        'Aux = Aux << 7
        Nuevo_val_32_5th = (Aux Or Nuevo_val_32_5th)

        'Grabar sexto

        Dim Nuevo_val_32_6th As UInt32
        Dim Unk As UInt32 = Form1.Pink_2_box.Value
        Dim Age As UInt32 = Form1.Age_box.Value - 15
        Dim Lofted_pass As UInt32 = Form1.Lofted_pass_box.Value - 40
        Dim Physical_contact As UInt32 = Form1.Physical_Contact_box.Value - 40
        Dim Body_Balance As UInt32 = Form1.Body_Balance_box.Value - 40
        Dim Attacking_Prowess As UInt32 = Form1.Attacking_Prowess_box.Value - 40







        Aux = Unk
        Aux = Aux << 30
        Nuevo_val_32_6th = (Aux Or Nuevo_val_32_6th)
        Aux = Age
        Aux = Aux << 24
        Nuevo_val_32_6th = (Aux Or Nuevo_val_32_6th)
        Aux = Lofted_pass
        Aux = Aux << 18
        Nuevo_val_32_6th = (Aux Or Nuevo_val_32_6th)
        Aux = Physical_contact
        Aux = Aux << 12
        Nuevo_val_32_6th = (Aux Or Nuevo_val_32_6th)
        Aux = Body_Balance
        Aux = Aux << 6
        Nuevo_val_32_6th = (Aux Or Nuevo_val_32_6th)
        Aux = Attacking_Prowess
        'Aux = Aux << 7
        Nuevo_val_32_6th = (Aux Or Nuevo_val_32_6th)


        'Grabar septimo 

        Dim Nuevo_val_32_7th As UInt32

        Dim Weak_foot_use As UInt32 = Form1.Weak_foot_use_box.Value - 1
        Dim DMF As UInt32 = Form1.DMF_box.Value
        Dim ulti_nuevo As UInt32 = Form1.ulti_nuevo_box.Value
        Dim Running_arm_mov As UInt32 = Form1.Running_arm_mov_box.Value - 1
        Dim Dribling_arm_mov As UInt32 = Form1.Dribling_arm_mov_box.Value - 1
        Dim Corner_kick As UInt32 = Form1.Corner_kick_box.Value - 1
        Dim FORM As UInt32 = Form1.FORM_box.Value - 1
        Dim Position As UInt32 = Form1.Position_box.Value
        Dim Free_kick As UInt32 = Form1.Free_kick_box.Value - 1
        Dim Playing_Style As UInt32 = Form1.Playing_Style_box.Value


        Aux = Weak_foot_use
        Aux = Aux << 30
        Nuevo_val_32_7th = (Aux Or Nuevo_val_32_7th)
        Aux = DMF
        Aux = Aux << 28
        Nuevo_val_32_7th = (Aux Or Nuevo_val_32_7th)
        Aux = ulti_nuevo
        Aux = Aux << 25
        Nuevo_val_32_7th = (Aux Or Nuevo_val_32_7th)
        Aux = Running_arm_mov
        Aux = Aux << 22
        Nuevo_val_32_7th = (Aux Or Nuevo_val_32_7th)
        Aux = Dribling_arm_mov
        Aux = Aux << 19
        Nuevo_val_32_7th = (Aux Or Nuevo_val_32_7th)
        Aux = Corner_kick
        Aux = Aux << 16
        Nuevo_val_32_7th = (Aux Or Nuevo_val_32_7th)
        Aux = FORM
        Aux = Aux << 13
        Nuevo_val_32_7th = (Aux Or Nuevo_val_32_7th)
        Aux = Position
        Aux = Aux << 9
        Nuevo_val_32_7th = (Aux Or Nuevo_val_32_7th)
        Aux = Free_kick
        Aux = Aux << 5
        Nuevo_val_32_7th = (Aux Or Nuevo_val_32_7th)
        Aux = Playing_Style
        'Aux = Aux << 20
        Nuevo_val_32_7th = (Aux Or Nuevo_val_32_7th)

        'Grabar octavo
        '''''''''Voy aqui
        Dim Nuevo_val_32_8th As UInt32


        Dim Pinpoint_Crossing As UInt32
        If Form1.CheckBox1.Checked = True Then
            Pinpoint_Crossing = 1
        Else
            Pinpoint_Crossing = 0
        End If

        Dim Sombrero As UInt32
        If Form1.CheckBox2.Checked = True Then
            Sombrero = 1
        Else
            Sombrero = 0
        End If
        Dim Runing_Hutching As UInt32 = Form1.Runing_Hutching_box.Value - 1
        Dim ss As UInt32 = Form1.SS_box.Value
        Dim Blue_2 As UInt32 = Form1.blue_2_box.Value
        Dim RWF As UInt32 = Form1.RWF_box.Value
        Dim LMF As UInt32 = Form1.LMF_box.Value
        Dim RB As UInt32 = Form1.RB_box.Value
        Dim LWF As UInt32 = Form1.LWF_box.Value
        Dim CF As UInt32 = Form1.CF_box.Value
        Dim CB As UInt32 = Form1.CB_box.Value
        Dim Dribling_hutching As UInt32 = Form1.Dribling_hutching_box.Value - 1
        Dim AMF As UInt32 = Form1.AMF_box.Value
        Dim injury_res As UInt32 = Form1.Injury_res__box.Value - 1
        Dim RMF As UInt32 = Form1.RMF_box.Value
        Dim Weak_foot_acc As UInt32 = Form1.Weak_foot_acc_box.Value - 1
        Dim CMF As UInt32 = Form1.CMF_box.Value

        Aux = Pinpoint_Crossing
        Aux = Aux << 31
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = Sombrero
        Aux = Aux << 30
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = Runing_Hutching
        Aux = Aux << 28
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = ss
        Aux = Aux << 26
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = Blue_2
        Aux = Aux << 24
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = RWF
        Aux = Aux << 22
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = LMF
        Aux = Aux << 20
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = RB
        Aux = Aux << 18
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = LWF
        Aux = Aux << 16
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = CF
        Aux = Aux << 14
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = CB
        Aux = Aux << 12
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = Dribling_hutching
        Aux = Aux << 10
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = AMF
        Aux = Aux << 8
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = Weak_foot_acc
        Aux = Aux << 6
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = RMF
        Aux = Aux << 4
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = injury_res
        Aux = Aux << 2
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)
        Aux = CMF
        'Aux = Aux << 20
        Nuevo_val_32_8th = (Aux Or Nuevo_val_32_8th)

        'Grabar Noveno

        Dim Nuevo_val_32_9th As UInt32





        Dim CHECK9 As UInt32
        If Form1.CheckBox9.Checked = True Then
            CHECK9 = 1
        Else
            CHECK9 = 0
        End If
        Dim CHECK10 As UInt32
        If Form1.CheckBox10.Checked = True Then
            CHECK10 = 1
        Else
            CHECK10 = 0
        End If
        Dim CHECK11 As UInt32
        If Form1.CheckBox11.Checked = True Then
            CHECK11 = 1
        Else
            CHECK11 = 0
        End If
        Dim CHECK12 As UInt32
        If Form1.CheckBox12.Checked = True Then
            CHECK12 = 1
        Else
            CHECK12 = 0
        End If
        Dim CHECK13 As UInt32
        If Form1.CheckBox13.Checked = True Then
            CHECK13 = 1
        Else
            CHECK13 = 0
        End If
        Dim CHECK14 As UInt32
        If Form1.CheckBox14.Checked = True Then
            CHECK14 = 1
        Else
            CHECK14 = 0
        End If
        Dim CHECK15 As UInt32
        If Form1.CheckBox15.Checked = True Then
            CHECK15 = 1
        Else
            CHECK15 = 0
        End If
        Dim CHECK16 As UInt32
        If Form1.CheckBox16.Checked = True Then
            CHECK16 = 1
        Else
            CHECK16 = 0
        End If
        Dim CHECK17 As UInt32
        If Form1.CheckBox25.Checked = True Then
            CHECK17 = 1
        Else
            CHECK17 = 0
        End If
        Dim CHECK18 As UInt32
        If Form1.CheckBox17.Checked = True Then
            CHECK18 = 1
        Else
            CHECK18 = 0
        End If
        Dim CHECK19 As UInt32
        If Form1.CheckBox19.Checked = True Then
            CHECK19 = 1
        Else
            CHECK19 = 0
        End If
        Dim CHECK20 As UInt32
        If Form1.CheckBox20.Checked = True Then
            CHECK20 = 1
        Else
            CHECK20 = 0
        End If
        Dim CHECK21 As UInt32
        If Form1.CheckBox21.Checked = True Then
            CHECK21 = 1
        Else
            CHECK21 = 0
        End If
        Dim CHECK22 As UInt32
        If Form1.CheckBox22.Checked = True Then
            CHECK22 = 1
        Else
            CHECK22 = 0
        End If
        Dim CHECK23 As UInt32
        If Form1.CheckBox23.Checked = True Then
            CHECK23 = 1
        Else
            CHECK23 = 0
        End If
        Dim CHECK24 As UInt32
        If Form1.CheckBox24.Checked = True Then
            CHECK24 = 1
        Else
            CHECK24 = 0
        End If
        Dim CHECK25 As UInt32
        If Form1.CheckBox18.Checked = True Then
            CHECK25 = 1
        Else
            CHECK25 = 0
        End If
        Dim CHECK26 As UInt32
        If Form1.CheckBox26.Checked = True Then
            CHECK26 = 1
        Else
            CHECK26 = 0
        End If
        Dim CHECK27 As UInt32
        If Form1.CheckBox27.Checked = True Then
            CHECK27 = 1
        Else
            CHECK27 = 0
        End If
        Dim CHECK28 As UInt32
        If Form1.CheckBox28.Checked = True Then
            CHECK28 = 1
        Else
            CHECK28 = 0
        End If
        Dim CHECK29 As UInt32
        If Form1.CheckBox29.Checked = True Then
            CHECK29 = 1
        Else
            CHECK29 = 0
        End If
        Dim CHECK30 As UInt32
        If Form1.CheckBox30.Checked = True Then
            CHECK30 = 1
        Else
            CHECK30 = 0
        End If
        Dim CHECK31 As UInt32
        If Form1.CheckBox31.Checked = True Then
            CHECK31 = 1
        Else
            CHECK31 = 0
        End If
        Dim CHECK32 As UInt32
        If Form1.CheckBox32.Checked = True Then
            CHECK32 = 1
        Else
            CHECK32 = 0
        End If
        Dim CHECK33 As UInt32
        If Form1.CheckBox33.Checked = True Then
            CHECK33 = 1
        Else
            CHECK33 = 0
        End If
        Dim CHECK34 As UInt32
        If Form1.CheckBox34.Checked = True Then
            CHECK34 = 1
        Else
            CHECK34 = 0
        End If
        Dim CHECK35 As UInt32
        If Form1.CheckBox35.Checked = True Then
            CHECK35 = 1
        Else
            CHECK35 = 0
        End If
        Dim CHECK36 As UInt32
        If Form1.CheckBox36.Checked = True Then
            CHECK36 = 1
        Else
            CHECK36 = 0
        End If
        Dim CHECK37 As UInt32
        If Form1.CheckBox37.Checked = True Then
            CHECK37 = 1
        Else
            CHECK37 = 0
        End If
        Dim CHECK38 As UInt32
        If Form1.CheckBox38.Checked = True Then
            CHECK38 = 1
        Else
            CHECK38 = 0
        End If
        Dim CHECK39 As UInt32
        If Form1.CheckBox39.Checked = True Then
            CHECK39 = 1
        Else
            CHECK39 = 0
        End If
        Dim CHECK40 As UInt32
        If Form1.CheckBox40.Checked = True Then
            CHECK40 = 1
        Else
            CHECK40 = 0
        End If

        Aux = CHECK9
        Aux = Aux << 31
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK10
        Aux = Aux << 30
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK11
        Aux = Aux << 29
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK12
        Aux = Aux << 28
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK13
        Aux = Aux << 27
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK14
        Aux = Aux << 26
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK15
        Aux = Aux << 25
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK16
        Aux = Aux << 24
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK17
        Aux = Aux << 23
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK18
        Aux = Aux << 22
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK19
        Aux = Aux << 21
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK20
        Aux = Aux << 20
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK21
        Aux = Aux << 19
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK22
        Aux = Aux << 18
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK23
        Aux = Aux << 17
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK24
        Aux = Aux << 16
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK25
        Aux = Aux << 15
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK26
        Aux = Aux << 14
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK27
        Aux = Aux << 13
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK28
        Aux = Aux << 12
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK29
        Aux = Aux << 11
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK30
        Aux = Aux << 10
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK31
        Aux = Aux << 9
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK32
        Aux = Aux << 8
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK33
        Aux = Aux << 7
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK34
        Aux = Aux << 6
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK35
        Aux = Aux << 5
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK36
        Aux = Aux << 4
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK37
        Aux = Aux << 3
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK38
        Aux = Aux << 2
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK39
        Aux = Aux << 1
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)
        Aux = CHECK40
        'Aux = Aux << 24
        Nuevo_val_32_9th = (Aux Or Nuevo_val_32_9th)





        '10TH value byte size

        Dim Aux_byte As Byte
        Dim Nuevo_val_byte_10th As Byte

        Dim CHECK3 As Byte
        If Form1.CheckBox3.Checked = True Then
            CHECK3 = 1
        Else
            CHECK3 = 0
        End If
        Dim CHECK4 As Byte
        If Form1.CheckBox4.Checked = True Then
            CHECK4 = 1
        Else
            CHECK4 = 0
        End If
        Dim CHECK5 As Byte
        If Form1.CheckBox5.Checked = True Then
            CHECK5 = 1
        Else
            CHECK5 = 0
        End If
        Dim CHECK6 As Byte
        If Form1.CheckBox6.Checked = True Then
            CHECK6 = 1
        Else
            CHECK6 = 0
        End If
        Dim CHECK7 As Byte
        If Form1.CheckBox7.Checked = True Then
            CHECK7 = 1
        Else
            CHECK7 = 0
        End If
        Dim CHECK8 As Byte
        If Form1.CheckBox8.Checked = True Then
            CHECK8 = 1
        Else
            CHECK8 = 0
        End If
        Dim CHECK141 As Byte
        If Form1.CheckBox111.Checked = True Then
            CHECK141 = 1
        Else
            CHECK141 = 0
        End If
        Dim CHECK142 As Byte
        If Form1.CheckBox112.Checked = True Then
            CHECK142 = 1
        Else
            CHECK142 = 0
        End If



        Aux_byte = CHECK3
        Aux_byte = Aux_byte << 7
        Nuevo_val_byte_10th = (Aux_byte Or Nuevo_val_byte_10th)
        Aux_byte = CHECK4
        Aux_byte = Aux_byte << 6
        Nuevo_val_byte_10th = (Aux_byte Or Nuevo_val_byte_10th)
        Aux_byte = CHECK5
        Aux_byte = Aux_byte << 5
        Nuevo_val_byte_10th = (Aux_byte Or Nuevo_val_byte_10th)
        Aux_byte = CHECK6
        Aux_byte = Aux_byte << 4
        Nuevo_val_byte_10th = (Aux_byte Or Nuevo_val_byte_10th)
        Aux_byte = CHECK7
        Aux_byte = Aux_byte << 3
        Nuevo_val_byte_10th = (Aux_byte Or Nuevo_val_byte_10th)
        Aux_byte = CHECK8
        Aux_byte = Aux_byte << 2
        Nuevo_val_byte_10th = (Aux_byte Or Nuevo_val_byte_10th)
        Aux_byte = CHECK141
        Aux_byte = Aux_byte << 1
        Nuevo_val_byte_10th = (Aux_byte Or Nuevo_val_byte_10th)
        Aux_byte = CHECK142
        'Aux_byte = Aux_byte << 7
        Nuevo_val_byte_10th = (Aux_byte Or Nuevo_val_byte_10th)


        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Nuevo_val_32_first = converter.bitworking_Player32_1_toConsole(Nuevo_val_32_first)
            Nuevo_val_32_2nd = converter.bitworking_Player32_14_toConsole(Nuevo_val_32_2nd)
            Nuevo_val_32_3rd = converter.bitworking_Player32_2_toConsole(Nuevo_val_32_3rd)
            Nuevo_val_32_4th = converter.bitworking_Player32_2_toConsole(Nuevo_val_32_4th)
            Nuevo_val_32_5th = converter.bitworking_Player32_2_toConsole(Nuevo_val_32_5th)
            Nuevo_val_32_6th = converter.bitworking_Player32_2_toConsole(Nuevo_val_32_6th)
            Nuevo_val_32_7th = converter.bitworking_Player32_12_toConsole(Nuevo_val_32_7th)
            Nuevo_val_32_8th = converter.bitworking_Player32_13_toConsole(Nuevo_val_32_8th)
            Nuevo_val_32_9th = swaps.swap32(converter.Reverse_int32(Nuevo_val_32_9th))
            Nuevo_val_byte_10th = converter.Reverse_byte(Nuevo_val_byte_10th)

        End If

        Form1.Grabar_player.Write(Nuevo_val_32_first)
        Form1.Grabar_player.Write(Nuevo_val_32_2nd)
        Form1.Grabar_player.Write(Nuevo_val_32_3rd)
        Form1.Grabar_player.Write(Nuevo_val_32_4th)
        Form1.Grabar_player.Write(Nuevo_val_32_5th)
        Form1.Grabar_player.Write(Nuevo_val_32_6th)
        Form1.Grabar_player.Write(Nuevo_val_32_7th)
        Form1.Grabar_player.Write(Nuevo_val_32_8th)
        Form1.Grabar_player.Write(Nuevo_val_32_9th)
        Form1.Grabar_player.Write(Nuevo_val_byte_10th)


        'Grabar nombres


        Form1.Leer_Player.BaseStream.Position = Index + Nombre_camiseta_pos
        Dim Posicion_paraNombres As UInteger = Form1.Leer_Player.BaseStream.Position
        Dim cero_cero As Byte = &H0
        For i = 0 To 91
            Form1.Grabar_player.Write(cero_cero)
        Next
        Form1.Leer_Player.BaseStream.Position = Posicion_paraNombres
        Dim Nom_Jugador_shirt As String = Form1.Shirt_name.Text
        Form1.Grabar_player.Write(Nom_Jugador_shirt.ToCharArray)
        Form1.Leer_Player.BaseStream.Position = Posicion_paraNombres + 46
        Dim Nom_Jugador As String = Form1.Name_box.Text
        Form1.Grabar_player.Write(Nom_Jugador.ToCharArray)


        'Si han cambiado la Id cambiarla en la asignacion y en la apariencia y botas y guantes y ordenarlos
        If Form1.Player_num.Value <> Form1.Player_id_orig Then

            Form1.Leer_Player_Assignament.BaseStream.Position = 4
            For i = 0 To Form1.unzlib_Player_Assignament.Length / 16 - 1
                If swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32) = Form1.Player_id_orig Then
                    Form1.Leer_Player_Assignament.BaseStream.Position -= 4
                    Form1.Grabar_Player_Assignament.Write(swaps.swap32(Player_ID))
                End If
                Form1.Leer_Player_Assignament.BaseStream.Position += 12
            Next
            'çTengo que poner que se grabe en su posicion no donde estaba el fake.
            If Form1.PLayer_Appareance_present = True Then

                Form1.Leer_PlayerAppareance.BaseStream.Position = 0
                Dim bloq_plapp As UInt32 = Form1.PlayerAppareance_MemStream.Length / 60
                Dim contador As Integer = 0
                Dim Es_nuevo As Boolean = False
                Dim Posicion_a_incrustar As UInt32
                Dim Posicion_val_antiguo As UInt32
                Dim Player_Player_appareance_block As Byte()
                Dim Bloque_previo As Byte()
                Dim bloque_intermedio As Byte()
                Dim Bloque_posterior As Byte()

                Form1.Leer_PlayerAppareance.BaseStream.Position = 0
                While Player_ID > swaps.swap32(Form1.Leer_PlayerAppareance.ReadUInt32)
                    Form1.Leer_PlayerAppareance.BaseStream.Position += 56
                End While
                Posicion_a_incrustar = Form1.Leer_PlayerAppareance.BaseStream.Position - 4

                Form1.Leer_PlayerAppareance.BaseStream.Position = 0
                For i = 0 To bloq_plapp - 1


                    If swaps.swap32(Form1.Leer_PlayerAppareance.ReadUInt32) = Form1.Player_id_orig Then
                        Form1.Leer_PlayerAppareance.BaseStream.Position -= 4
                        Posicion_val_antiguo = Form1.Leer_PlayerAppareance.BaseStream.Position
                        Form1.Grabar_PlayerAppareance.Write(swaps.swap32(Player_ID))
                        Form1.Leer_PlayerAppareance.BaseStream.Position -= 4
                        Player_Player_appareance_block = Form1.Leer_PlayerAppareance.ReadBytes(60)
                        'Bloque_posterior = Form1.Leer_PlayerAppareance.ReadBytes(Form1.unzlib_Player_Assignament.Length - Form1.Leer_PlayerAppareance.BaseStream.Position)
                        'Form1.Leer_PlayerAppareance.BaseStream.Position = 0
                        'Bloque_previo = Form1.Leer_PlayerAppareance.ReadBytes(Posicion_aux - 1)
                        'Form1.unzlib_Player_Assignament.Close()
                        Exit For

                        ' Form1.Grabar_PlayerAppareance.Write(swaps.swap32(Player_ID))
                    End If
                    Form1.Leer_PlayerAppareance.BaseStream.Position += 56
                    contador = contador + 1
                Next
                'Por si no tiene playerappareance asignado
                If contador = bloq_plapp Then
                    Form1.Leer_PlayerAppareance.BaseStream.Position = 4
                    Player_Player_appareance_block = Form1.Leer_PlayerAppareance.ReadBytes(56)
                    Es_nuevo = True
                End If

                If Es_nuevo Then
                    'si es nuevo entonces se añade el bloque
                    Form1.Leer_PlayerAppareance.BaseStream.Position = 0
                    Bloque_previo = Form1.Leer_PlayerAppareance.ReadBytes(Posicion_a_incrustar)
                    Bloque_posterior = Form1.Leer_PlayerAppareance.ReadBytes(Form1.PlayerAppareance_MemStream.Length - Posicion_a_incrustar)
                    Form1.Leer_PlayerAppareance.BaseStream.Position = 0
                    Form1.Grabar_PlayerAppareance.Write(Bloque_previo)
                    Form1.Grabar_PlayerAppareance.Write(swaps.swap32(Player_ID))
                    Form1.Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
                    Form1.Grabar_PlayerAppareance.Write(Bloque_posterior)

                Else
                    ' Si la id es anterior a la antigua
                    If Player_ID < Form1.Player_id_orig Then
                        Form1.Leer_PlayerAppareance.BaseStream.Position = 0
                        Bloque_previo = Form1.Leer_PlayerAppareance.ReadBytes(Posicion_a_incrustar)
                        Form1.Leer_PlayerAppareance.BaseStream.Position = Posicion_a_incrustar
                        bloque_intermedio = Form1.Leer_PlayerAppareance.ReadBytes(Posicion_val_antiguo - Posicion_a_incrustar)
                        Form1.Leer_PlayerAppareance.BaseStream.Position = Posicion_val_antiguo + 60
                        Bloque_posterior = Form1.Leer_PlayerAppareance.ReadBytes(Form1.PlayerAppareance_MemStream.Length - (Posicion_val_antiguo + 60))
                        Form1.Leer_PlayerAppareance.BaseStream.Position = 0
                        Form1.Grabar_PlayerAppareance.Write(Bloque_previo)
                        ' Form1.Grabar_PlayerAppareance.Write(swaps.swap32(Player_ID))
                        Form1.Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
                        Form1.Grabar_PlayerAppareance.Write(bloque_intermedio)
                        Form1.Grabar_PlayerAppareance.Write(Bloque_posterior)


                    Else
                        ' Si la id es posterior a la antigua
                        Form1.Leer_PlayerAppareance.BaseStream.Position = 0
                        Bloque_previo = Form1.Leer_PlayerAppareance.ReadBytes(Posicion_val_antiguo)
                        Form1.Leer_PlayerAppareance.BaseStream.Position += 60
                        'Form1.Leer_PlayerAppareance.BaseStream.Position = Posicion_a_incrustar
                        bloque_intermedio = Form1.Leer_PlayerAppareance.ReadBytes(Posicion_a_incrustar - (Posicion_val_antiguo + 60))
                        Form1.Leer_PlayerAppareance.BaseStream.Position = Posicion_a_incrustar + 60
                        Bloque_posterior = Form1.Leer_PlayerAppareance.ReadBytes(Form1.PlayerAppareance_MemStream.Length - (Posicion_a_incrustar + 60))

                        Form1.Leer_PlayerAppareance.BaseStream.Position = 0
                        Form1.Grabar_PlayerAppareance.Write(Bloque_previo)
                        Form1.Grabar_PlayerAppareance.Write(bloque_intermedio)
                        ' Form1.Grabar_PlayerAppareance.Write(swaps.swap32(Player_ID))
                        Form1.Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
                        Form1.Grabar_PlayerAppareance.Write(Bloque_posterior)



                    End If

                End If


            End If




            If Form1.Boot_List_present = True Then

                Form1.Leer_Boots_list.BaseStream.Position = 0
                Dim bloq_boot_list As UInt32 = Form1.unzlib_Boots_list.Length / 8
                Dim contador As Integer = 0
                Dim Es_nuevo As Boolean = False
                Dim Posicion_a_incrustar As UInt32
                Dim Posicion_val_antiguo As UInt32
                Dim Boot_list_block As Byte()
                Dim Bloque_previo As Byte()
                Dim bloque_intermedio As Byte()
                Dim Bloque_posterior As Byte()

                Form1.Leer_Boots_list.BaseStream.Position = 0
                While Player_ID > swaps.swap32(Form1.Leer_Boots_list.ReadUInt32)
                    Form1.Leer_Boots_list.BaseStream.Position += 4
                End While
                Posicion_a_incrustar = Form1.Leer_Boots_list.BaseStream.Position - 4

                Form1.Leer_Boots_list.BaseStream.Position = 0
                For i = 0 To bloq_boot_list - 1


                    If swaps.swap32(Form1.Leer_Boots_list.ReadUInt32) = Form1.Player_id_orig Then
                        Form1.Leer_Boots_list.BaseStream.Position -= 4
                        Posicion_val_antiguo = Form1.Leer_Boots_list.BaseStream.Position
                        Form1.Grabar_Boots_list.Write(swaps.swap32(Player_ID))
                        Form1.Leer_Boots_list.BaseStream.Position -= 4
                        Boot_list_block = Form1.Leer_Boots_list.ReadBytes(8)
                        'Bloque_posterior = Form1.Leer_Boots_list.ReadBytes(Form1.unzlib_Player_Assignament.Length - Form1.Leer_Boots_list.BaseStream.Position)
                        'Form1.Leer_Boots_list.BaseStream.Position = 0
                        'Bloque_previo = Form1.Leer_Boots_list.ReadBytes(Posicion_aux - 1)
                        'Form1.unzlib_Player_Assignament.Close()
                        Exit For

                        ' Form1.Grabar_Boots_list.Write(swaps.swap32(Player_ID))
                    End If
                    Form1.Leer_Boots_list.BaseStream.Position += 4
                    contador = contador + 1
                Next
                'Por si no tiene playerappareance asignado
                If contador = bloq_boot_list Then
                    Form1.Leer_Boots_list.BaseStream.Position = 4
                    Boot_list_block = Form1.Leer_Boots_list.ReadBytes(4)
                    Es_nuevo = True
                End If

                If Es_nuevo Then
                    'si es nuevo entonces se añade el bloque
                    Form1.Leer_Boots_list.BaseStream.Position = 0
                    Bloque_previo = Form1.Leer_Boots_list.ReadBytes(Posicion_a_incrustar)
                    Bloque_posterior = Form1.Leer_Boots_list.ReadBytes(Form1.unzlib_Boots_list.Length - Posicion_a_incrustar)
                    Form1.Leer_Boots_list.BaseStream.Position = 0
                    Form1.Grabar_Boots_list.Write(Bloque_previo)
                    Form1.Grabar_Boots_list.Write(swaps.swap32(Player_ID))
                    Form1.Grabar_Boots_list.Write(Boot_list_block)
                    Form1.Grabar_Boots_list.Write(Bloque_posterior)

                Else
                    ' Si la id es anterior a la antigua
                    If Player_ID < Form1.Player_id_orig Then
                        Form1.Leer_Boots_list.BaseStream.Position = 0
                        Bloque_previo = Form1.Leer_Boots_list.ReadBytes(Posicion_a_incrustar)
                        Form1.Leer_Boots_list.BaseStream.Position = Posicion_a_incrustar
                        bloque_intermedio = Form1.Leer_Boots_list.ReadBytes(Posicion_val_antiguo - Posicion_a_incrustar)
                        Form1.Leer_Boots_list.BaseStream.Position = Posicion_val_antiguo + 8
                        Bloque_posterior = Form1.Leer_Boots_list.ReadBytes(Form1.unzlib_Boots_list.Length - (Posicion_val_antiguo + 8))
                        Form1.Leer_Boots_list.BaseStream.Position = 0
                        Form1.Grabar_Boots_list.Write(Bloque_previo)
                        ' Form1.Grabar_Boots_list.Write(swaps.swap32(Player_ID))
                        Form1.Grabar_Boots_list.Write(Boot_list_block)
                        Form1.Grabar_Boots_list.Write(bloque_intermedio)
                        Form1.Grabar_Boots_list.Write(Bloque_posterior)


                    Else
                        ' Si la id es posterior a la antigua
                        Form1.Leer_Boots_list.BaseStream.Position = 0
                        Bloque_previo = Form1.Leer_Boots_list.ReadBytes(Posicion_val_antiguo)
                        Form1.Leer_Boots_list.BaseStream.Position += 8
                        'Form1.Leer_Boots_list.BaseStream.Position = Posicion_a_incrustar
                        bloque_intermedio = Form1.Leer_Boots_list.ReadBytes(Posicion_a_incrustar - (Posicion_val_antiguo + 8))
                        Form1.Leer_Boots_list.BaseStream.Position = Posicion_a_incrustar + 8
                        Bloque_posterior = Form1.Leer_Boots_list.ReadBytes(Form1.unzlib_Boots_list.Length - (Posicion_a_incrustar + 8))

                        Form1.Leer_Boots_list.BaseStream.Position = 0
                        Form1.Grabar_Boots_list.Write(Bloque_previo)
                        Form1.Grabar_Boots_list.Write(bloque_intermedio)
                        ' Form1.Grabar_Boots_list.Write(swaps.swap32(Player_ID))
                        Form1.Grabar_Boots_list.Write(Boot_list_block)
                        Form1.Grabar_Boots_list.Write(Bloque_posterior)



                    End If

                End If


            End If

            If Form1.Glove_List_present = True Then

                Form1.Leer_Gloves_list.BaseStream.Position = 0
                Dim bloq_Gloves_list As UInt32 = Form1.unzlib_Gloves_list.Length / 8
                Dim contador As Integer = 0
                Dim Es_nuevo As Boolean = False
                Dim Posicion_a_incrustar As UInt32
                Dim Posicion_val_antiguo As UInt32
                Dim Gloves_list_block As Byte()
                Dim Bloque_previo As Byte()
                Dim bloque_intermedio As Byte()
                Dim Bloque_posterior As Byte()

                Form1.Leer_Gloves_list.BaseStream.Position = 0
                While Player_ID > swaps.swap32(Form1.Leer_Gloves_list.ReadUInt32)
                    Form1.Leer_Gloves_list.BaseStream.Position += 4
                End While
                Posicion_a_incrustar = Form1.Leer_Gloves_list.BaseStream.Position - 4

                Form1.Leer_Gloves_list.BaseStream.Position = 0
                For i = 0 To bloq_Gloves_list - 1


                    If swaps.swap32(Form1.Leer_Gloves_list.ReadUInt32) = Form1.Player_id_orig Then
                        Form1.Leer_Gloves_list.BaseStream.Position -= 4
                        Posicion_val_antiguo = Form1.Leer_Gloves_list.BaseStream.Position
                        Form1.Grabar_Gloves_list.Write(swaps.swap32(Player_ID))
                        Form1.Leer_Gloves_list.BaseStream.Position -= 4
                        Gloves_list_block = Form1.Leer_Gloves_list.ReadBytes(8)
                        'Bloque_posterior = Form1.Leer_Gloves_list.ReadBytes(Form1.unzlib_Player_Assignament.Length - Form1.Leer_Gloves_list.BaseStream.Position)
                        'Form1.Leer_Gloves_list.BaseStream.Position = 0
                        'Bloque_previo = Form1.Leer_Gloves_list.ReadBytes(Posicion_aux - 1)
                        'Form1.unzlib_Player_Assignament.Close()
                        Exit For

                        ' Form1.Grabar_Gloves_list.Write(swaps.swap32(Player_ID))
                    End If
                    Form1.Leer_Gloves_list.BaseStream.Position += 4
                    contador = contador + 1
                Next
                'Por si no tiene playerappareance asignado
                If contador = bloq_Gloves_list Then
                    Form1.Leer_Gloves_list.BaseStream.Position = 4
                    Gloves_list_block = Form1.Leer_Gloves_list.ReadBytes(4)
                    Es_nuevo = True
                End If

                If Es_nuevo Then
                    'si es nuevo entonces se añade el bloque
                    Form1.Leer_Gloves_list.BaseStream.Position = 0
                    Bloque_previo = Form1.Leer_Gloves_list.ReadBytes(Posicion_a_incrustar)
                    Bloque_posterior = Form1.Leer_Gloves_list.ReadBytes(Form1.unzlib_Gloves_list.Length - Posicion_a_incrustar)
                    Form1.Leer_Gloves_list.BaseStream.Position = 0
                    Form1.Grabar_Gloves_list.Write(Bloque_previo)
                    Form1.Grabar_Gloves_list.Write(swaps.swap32(Player_ID))
                    Form1.Grabar_Gloves_list.Write(Gloves_list_block)
                    Form1.Grabar_Gloves_list.Write(Bloque_posterior)

                Else
                    ' Si la id es anterior a la antigua
                    If Player_ID < Form1.Player_id_orig Then
                        Form1.Leer_Gloves_list.BaseStream.Position = 0
                        Bloque_previo = Form1.Leer_Gloves_list.ReadBytes(Posicion_a_incrustar)
                        Form1.Leer_Gloves_list.BaseStream.Position = Posicion_a_incrustar
                        bloque_intermedio = Form1.Leer_Gloves_list.ReadBytes(Posicion_val_antiguo - Posicion_a_incrustar)
                        Form1.Leer_Gloves_list.BaseStream.Position = Posicion_val_antiguo + 8
                        Bloque_posterior = Form1.Leer_Gloves_list.ReadBytes(Form1.unzlib_Gloves_list.Length - (Posicion_val_antiguo + 8))
                        Form1.Leer_Gloves_list.BaseStream.Position = 0
                        Form1.Grabar_Gloves_list.Write(Bloque_previo)
                        ' Form1.Grabar_Gloves_list.Write(swaps.swap32(Player_ID))
                        Form1.Grabar_Gloves_list.Write(Gloves_list_block)
                        Form1.Grabar_Gloves_list.Write(bloque_intermedio)
                        Form1.Grabar_Gloves_list.Write(Bloque_posterior)


                    Else
                        ' Si la id es posterior a la antigua
                        Form1.Leer_Gloves_list.BaseStream.Position = 0
                        Bloque_previo = Form1.Leer_Gloves_list.ReadBytes(Posicion_val_antiguo)
                        Form1.Leer_Gloves_list.BaseStream.Position += 8
                        'Form1.Leer_Gloves_list.BaseStream.Position = Posicion_a_incrustar
                        bloque_intermedio = Form1.Leer_Gloves_list.ReadBytes(Posicion_a_incrustar - (Posicion_val_antiguo + 8))
                        Form1.Leer_Gloves_list.BaseStream.Position = Posicion_a_incrustar + 8
                        Bloque_posterior = Form1.Leer_Gloves_list.ReadBytes(Form1.unzlib_Gloves_list.Length - (Posicion_a_incrustar + 8))

                        Form1.Leer_Gloves_list.BaseStream.Position = 0
                        Form1.Grabar_Gloves_list.Write(Bloque_previo)
                        Form1.Grabar_Gloves_list.Write(bloque_intermedio)
                        ' Form1.Grabar_Gloves_list.Write(swaps.swap32(Player_ID))
                        Form1.Grabar_Gloves_list.Write(Gloves_list_block)
                        Form1.Grabar_Gloves_list.Write(Bloque_posterior)



                    End If

                End If


            End If



        End If



    End Sub

    Public Sub leer_player_assig()
        '''''''''''''''''''''''''''''''''''Empieza PlayerAssig
        Form1.Leer_Player_Assignament.BaseStream.Position = 0
        'avanzo cuatro para la posición de comprobación
        Form1.Leer_Player_Assignament.BaseStream.Position += 4

        Dim Player_Ass_Id As UInteger = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
        While (Player_Ass_Id <> Player_ID) And (Form1.Leer_Player_Assignament.BaseStream.Position < (Form1.Leer_Player_Assignament.BaseStream.Length - 8))
            Form1.Leer_Player_Assignament.BaseStream.Position += 12
            Player_Ass_Id = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
        End While


        If (Form1.Leer_Player_Assignament.BaseStream.Position < (Form1.Leer_Player_Assignament.BaseStream.Length - 8)) Or Player_Ass_Id = Player_ID Then
            Form1.Leer_Player_Assignament.BaseStream.Position -= 8
            Dim PLayer_ass_Index As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
            Form1.Leer_Player_Assignament.BaseStream.Position += 4
            Form1.NumericPLAYERASS_INDEX.Value = PLayer_ass_Index
            Dim Team As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
            Form1.NumericTEAMID.Value = Team
            Dim Num_playerAssig_basestream_antes_buscar As UInteger = Form1.Leer_Player_Assignament.BaseStream.Position
            Form1.ListBox3.SelectedIndex = 0
            'Poner el nombre del equipo en el text box
            For i = 0 To Form1.DataGridView_TEAM.Rows.Count - 1
                If Form1.DataGridView_TEAM.Rows(i).Cells(1).Value = Team Then
                    Form1.TextBox_team_name.Text = Form1.DataGridView_TEAM.Rows(i).Cells(2).Value
                    Team1 = Form1.DataGridView_TEAM.Rows(i).Cells(2).Value
                End If
            Next
            Form1.Leer_Player_Assignament.BaseStream.Position = Num_playerAssig_basestream_antes_buscar

            Dim Dorsal As Byte = Form1.Leer_Player_Assignament.ReadByte
            Form1.NumericDorsal.Value = Dorsal
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''Empieza prueba
            Dim Prueba_colores As UInt16 = Form1.Leer_Player_Assignament.ReadUInt16
            If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                Prueba_colores = converter.bitworking_PlayerAssignment_toPc(Prueba_colores)
            End If

            'Form1.Leer_Player_Assignament.BaseStream.Position = Form1.Leer_Player_Assignament.BaseStream.Position - 2
            Dim CHECK42 As UInt32 = Prueba_colores >> 15
            If CHECK42 = 1 Then
                Form1.CheckBox42.Checked = True
            Else
                Form1.CheckBox42.Checked = False
            End If
            Dim CHECK43 As UInt32 = Prueba_colores << 1
            CHECK43 = CHECK43 >> 15
            If CHECK43 = 1 Then
                Form1.CheckBox43.Checked = True
            Else
                Form1.CheckBox43.Checked = False
            End If
            Dim CHECK44 As UInt32 = Prueba_colores << 2
            CHECK44 = CHECK44 >> 15
            If CHECK44 = 1 Then
                Form1.CheckBox44.Checked = True
            Else
                Form1.CheckBox44.Checked = False
            End If
            Dim CHECK45 As UInt32 = Prueba_colores << 3
            CHECK45 = CHECK45 >> 15
            If CHECK45 = 1 Then
                Form1.CheckBox45.Checked = True
            Else
                Form1.CheckBox45.Checked = False
            End If
            Dim CHECK46 As UInt32 = Prueba_colores << 4
            CHECK46 = CHECK46 >> 15
            If CHECK46 = 1 Then
                Form1.CheckBox46.Checked = True
            Else
                Form1.CheckBox46.Checked = False
            End If
            Dim CHECK47 As UInt32 = Prueba_colores << 5
            CHECK47 = CHECK47 >> 15
            If CHECK47 = 1 Then
                Form1.CheckBox47.Checked = True
            Else
                Form1.CheckBox47.Checked = False
            End If
            Dim CHECK82 As UInt32 = Prueba_colores << 6
            CHECK82 = CHECK82 >> 15
            If CHECK82 = 1 Then
                Form1.CheckBox82.Checked = True
            Else
                Form1.CheckBox82.Checked = False
            End If

            Dim CHECK83 As UInt32 = Prueba_colores << 7
            CHECK83 = CHECK83 >> 15
            If CHECK83 = 1 Then
                Form1.CheckBox83.Checked = True
            Else
                Form1.CheckBox83.Checked = False
            End If

            Dim CHECK84 As UInt32 = Prueba_colores << 8
            CHECK84 = CHECK84 >> 15
            If CHECK84 = 1 Then
                Form1.CheckBox84.Checked = True
            Else
                Form1.CheckBox84.Checked = False
            End If

            Dim CHECK85 As UInt32 = Prueba_colores << 9
            CHECK85 = CHECK85 >> 15
            If CHECK85 = 1 Then
                Form1.CheckBox85.Checked = True
            Else
                Form1.CheckBox85.Checked = False
            End If

            Dim ORDER_IN_TEAM As UInt16 = Prueba_colores << 10
            ORDER_IN_TEAM = ORDER_IN_TEAM >> 10
            Form1.ORDER_IN_TEAM_BOX.Value = ORDER_IN_TEAM

            Form1.Leer_Player_Assignament.BaseStream.Position += 1



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''






            'Mirar si es internacional y está dos veces.
            Form1.Leer_Player_Assignament.BaseStream.Position -= 8
            Player_Ass_Id = 0
            While (Player_Ass_Id <> Player_ID) And (Form1.Leer_Player_Assignament.BaseStream.Position < (Form1.Leer_Player_Assignament.BaseStream.Length - 8))
                Form1.Leer_Player_Assignament.BaseStream.Position += 12
                Player_Ass_Id = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
            End While
            If ((Player_Ass_Id = Player_ID) Or (Form1.Leer_Player_Assignament.BaseStream.Position < (Form1.Leer_Player_Assignament.BaseStream.Length - 8))) Then
                Form1.Leer_Player_Assignament.BaseStream.Position -= 8
                Dim PLayer_ass_Index_2 As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
                Form1.Leer_Player_Assignament.BaseStream.Position += 4
                Form1.NumericPLAYERASS_INDEX_2.Value = PLayer_ass_Index_2
                Dim Team_2 As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
                Form1.NumericTEAMID_2.Value = Team_2
                Form1.ListBox3.SelectedIndex = 0
                'Poner el nombre del equipo en el text box
                For i = 0 To Form1.DataGridView_TEAM.Rows.Count - 1
                    If Form1.DataGridView_TEAM.Rows(i).Cells(1).Value = Team_2 Then
                        Form1.TextBox_team_name_2.Text = Form1.DataGridView_TEAM.Rows(i).Cells(2).Value
                        Team2 = Form1.DataGridView_TEAM.Rows(i).Cells(2).Value
                    End If
                Next

                Dim Dorsal_2 As Byte = Form1.Leer_Player_Assignament.ReadByte
                Form1.NumericDorsal_2.Value = Dorsal_2

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''Empieza prueba
                Dim Prueba_colores_2 As UInt16 = Form1.Leer_Player_Assignament.ReadUInt16
                If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                    Prueba_colores_2 = converter.bitworking_PlayerAssignment_toPc(Prueba_colores_2)
                End If

                'Form1.Leer_Player_Assignament.BaseStream.Position = Form1.Leer_Player_Assignament.BaseStream.Position - 2
                Dim CHECK48 As UInt32 = Prueba_colores >> 15
                If CHECK48 = 1 Then
                    Form1.CheckBox48.Checked = True
                Else
                    Form1.CheckBox48.Checked = False
                End If
                Dim CHECK49 As UInt32 = Prueba_colores_2 << 1
                CHECK49 = CHECK49 >> 15
                If CHECK49 = 1 Then
                    Form1.CheckBox49.Checked = True
                Else
                    Form1.CheckBox49.Checked = False
                End If
                Dim CHECK50 As UInt32 = Prueba_colores_2 << 2
                CHECK50 = CHECK50 >> 15
                If CHECK50 = 1 Then
                    Form1.CheckBox50.Checked = True
                Else
                    Form1.CheckBox50.Checked = False
                End If
                Dim CHECK51 As UInt32 = Prueba_colores_2 << 3
                CHECK51 = CHECK51 >> 15
                If CHECK51 = 1 Then
                    Form1.CheckBox51.Checked = True
                Else
                    Form1.CheckBox51.Checked = False
                End If
                Dim CHECK52 As UInt32 = Prueba_colores_2 << 4
                CHECK52 = CHECK52 >> 15
                If CHECK52 = 1 Then
                    Form1.CheckBox52.Checked = True
                Else
                    Form1.CheckBox52.Checked = False
                End If
                Dim CHECK53 As UInt32 = Prueba_colores_2 << 5
                CHECK53 = CHECK53 >> 15
                If CHECK47 = 1 Then
                    Form1.CheckBox53.Checked = True
                Else
                    Form1.CheckBox53.Checked = False
                End If
                Dim CHECK89 As UInt32 = Prueba_colores_2 << 6
                CHECK89 = CHECK89 >> 15
                If CHECK89 = 1 Then
                    Form1.CheckBox89.Checked = True
                Else
                    Form1.CheckBox89.Checked = False
                End If

                Dim CHECK88 As UInt32 = Prueba_colores_2 << 7
                CHECK88 = CHECK88 >> 15
                If CHECK88 = 1 Then
                    Form1.CheckBox88.Checked = True
                Else
                    Form1.CheckBox88.Checked = False
                End If

                Dim CHECK87 As UInt32 = Prueba_colores_2 << 8
                CHECK87 = CHECK87 >> 15
                If CHECK87 = 1 Then
                    Form1.CheckBox87.Checked = True
                Else
                    Form1.CheckBox87.Checked = False
                End If

                Dim CHECK86 As UInt32 = Prueba_colores_2 << 9
                CHECK86 = CHECK86 >> 15
                If CHECK86 = 1 Then
                    Form1.CheckBox86.Checked = True
                Else
                    Form1.CheckBox86.Checked = False
                End If

                Dim ORDER_IN_TEAM_2 As UInt16 = Prueba_colores_2 << 10
                ORDER_IN_TEAM_2 = ORDER_IN_TEAM_2 >> 10
                Form1.ORDER_IN_TEAM_BOX_2.Value = ORDER_IN_TEAM_2

                Form1.Leer_Player_Assignament.BaseStream.Position += 1
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                Form1.NumericPLAYERASS_INDEX_2.Value = 0
                Form1.NumericTEAMID_2.Value = 0
                'Form1.ListBox3.SelectedIndex = 0
                'Poner el nombre del equipo en el text box

                Form1.NumericDorsal_2.Value = 0

                Form1.TextBox_team_name_2.Text = "FREE PLAYER"
                Team2 = "FREE PLAYER"


            End If




        Else
            Form1.NumericPLAYERASS_INDEX.Value = 0
            Form1.NumericTEAMID.Value = 0
            Form1.ListBox3.SelectedIndex = 0
            'Poner el nombre del equipo en el text box

            Form1.NumericDorsal.Value = 0

            Form1.TextBox_team_name.Text = "FREE PLAYER"
            Team1 = "FREE PLAYER"
        End If

    End Sub

    Public Sub leer_player_assig_sin_pantalla()
        '''''''''''''''''''''''''''''''''''Empieza PlayerAssig
        Form1.Leer_Player_Assignament.BaseStream.Position = 0
        'avanzo cuatro para la posición de comprobación
        Form1.Leer_Player_Assignament.BaseStream.Position += 4

        Dim Player_Ass_Id As UInteger = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
        While (Player_Ass_Id <> Player_ID) And (Form1.Leer_Player_Assignament.BaseStream.Position < (Form1.Leer_Player_Assignament.BaseStream.Length - 8))
            Form1.Leer_Player_Assignament.BaseStream.Position += 12
            Player_Ass_Id = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
        End While


        If (Form1.Leer_Player_Assignament.BaseStream.Position < (Form1.Leer_Player_Assignament.BaseStream.Length - 8)) Or Player_Ass_Id = Player_ID Then
            Form1.Leer_Player_Assignament.BaseStream.Position -= 8
            Dim PLayer_ass_Index As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
            Form1.Leer_Player_Assignament.BaseStream.Position += 4
            ' Form1.NumericPLAYERASS_INDEX.Value = PLayer_ass_Index
            Dim Team As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
            ' Form1.NumericTEAMID.Value = Team
            Dim Num_playerAssig_basestream_antes_buscar As UInteger = Form1.Leer_Player_Assignament.BaseStream.Position
            Form1.ListBox3.SelectedIndex = 0
            'Poner el nombre del equipo en el text box
            For i = 0 To Form1.DataGridView_TEAM.Rows.Count - 1
                If Form1.DataGridView_TEAM.Rows(i).Cells(1).Value = Team Then
                    'Form1.TextBox_team_name.Text = Form1.DataGridView_TEAM.Rows(i).Cells(2).Value
                    Team1 = Form1.DataGridView_TEAM.Rows(i).Cells(2).Value
                End If
            Next
            Form1.Leer_Player_Assignament.BaseStream.Position = Num_playerAssig_basestream_antes_buscar

            Dim Dorsal As Byte = Form1.Leer_Player_Assignament.ReadByte
            ' Form1.NumericDorsal.Value = Dorsal
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''Empieza prueba
            Dim Prueba_colores As UInt16 = Form1.Leer_Player_Assignament.ReadUInt16
            If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                Prueba_colores = converter.bitworking_PlayerAssignment_toPc(Prueba_colores)
            End If

            'Form1.Leer_Player_Assignament.BaseStream.Position = Form1.Leer_Player_Assignament.BaseStream.Position - 2
            Dim CHECK42 As UInt32 = Prueba_colores >> 15

            Dim CHECK43 As UInt32 = Prueba_colores << 1
            CHECK43 = CHECK43 >> 15

            Dim CHECK44 As UInt32 = Prueba_colores << 2
            CHECK44 = CHECK44 >> 15

            Dim CHECK45 As UInt32 = Prueba_colores << 3
            CHECK45 = CHECK45 >> 15

            Dim CHECK46 As UInt32 = Prueba_colores << 4
            CHECK46 = CHECK46 >> 15

            Dim CHECK47 As UInt32 = Prueba_colores << 5
            CHECK47 = CHECK47 >> 15

            Dim CHECK82 As UInt32 = Prueba_colores << 6
            CHECK82 = CHECK82 >> 15


            Dim CHECK83 As UInt32 = Prueba_colores << 7
            CHECK83 = CHECK83 >> 15


            Dim CHECK84 As UInt32 = Prueba_colores << 8
            CHECK84 = CHECK84 >> 15


            Dim CHECK85 As UInt32 = Prueba_colores << 9
            CHECK85 = CHECK85 >> 15


            Dim ORDER_IN_TEAM As UInt16 = Prueba_colores << 10
            ORDER_IN_TEAM = ORDER_IN_TEAM >> 10
            ' Form1.ORDER_IN_TEAM_BOX.Value = ORDER_IN_TEAM

            Form1.Leer_Player_Assignament.BaseStream.Position += 1



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''






            'Mirar si es internacional y está dos veces.
            Form1.Leer_Player_Assignament.BaseStream.Position -= 8
            Player_Ass_Id = 0
            While (Player_Ass_Id <> Player_ID) And (Form1.Leer_Player_Assignament.BaseStream.Position < (Form1.Leer_Player_Assignament.BaseStream.Length - 8))
                Form1.Leer_Player_Assignament.BaseStream.Position += 12
                Player_Ass_Id = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
            End While
            If ((Player_Ass_Id = Player_ID) Or (Form1.Leer_Player_Assignament.BaseStream.Position < (Form1.Leer_Player_Assignament.BaseStream.Length - 8))) Then
                Form1.Leer_Player_Assignament.BaseStream.Position -= 8
                Dim PLayer_ass_Index_2 As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
                Form1.Leer_Player_Assignament.BaseStream.Position += 4
                ' Form1.NumericPLAYERASS_INDEX_2.Value = PLayer_ass_Index_2
                Dim Team_2 As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
                ' Form1.NumericTEAMID_2.Value = Team_2
                Form1.ListBox3.SelectedIndex = 0
                'Poner el nombre del equipo en el text box
                For i = 0 To Form1.DataGridView_TEAM.Rows.Count - 1
                    If Form1.DataGridView_TEAM.Rows(i).Cells(1).Value = Team_2 Then
                        ' Form1.TextBox_team_name_2.Text = Form1.DataGridView_TEAM.Rows(i).Cells(2).Value
                        Team2 = Form1.DataGridView_TEAM.Rows(i).Cells(2).Value
                    End If
                Next

                Dim Dorsal_2 As Byte = Form1.Leer_Player_Assignament.ReadByte
                ' Form1.NumericDorsal_2.Value = Dorsal_2

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''Empieza prueba
                Dim Prueba_colores_2 As UInt16 = Form1.Leer_Player_Assignament.ReadUInt16
                If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                    Prueba_colores_2 = converter.bitworking_PlayerAssignment_toPc(Prueba_colores_2)
                End If

                'Form1.Leer_Player_Assignament.BaseStream.Position = Form1.Leer_Player_Assignament.BaseStream.Position - 2
                Dim CHECK48 As UInt32 = Prueba_colores >> 15

                Dim CHECK49 As UInt32 = Prueba_colores_2 << 1
                CHECK49 = CHECK49 >> 15

                Dim CHECK50 As UInt32 = Prueba_colores_2 << 2
                CHECK50 = CHECK50 >> 15

                Dim CHECK51 As UInt32 = Prueba_colores_2 << 3
                CHECK51 = CHECK51 >> 15

                Dim CHECK52 As UInt32 = Prueba_colores_2 << 4
                CHECK52 = CHECK52 >> 15

                Dim CHECK53 As UInt32 = Prueba_colores_2 << 5
                CHECK53 = CHECK53 >> 15

                Dim CHECK89 As UInt32 = Prueba_colores_2 << 6
                CHECK89 = CHECK89 >> 15


                Dim CHECK88 As UInt32 = Prueba_colores_2 << 7
                CHECK88 = CHECK88 >> 15


                Dim CHECK87 As UInt32 = Prueba_colores_2 << 8
                CHECK87 = CHECK87 >> 15


                Dim CHECK86 As UInt32 = Prueba_colores_2 << 9
                CHECK86 = CHECK86 >> 15


                Dim ORDER_IN_TEAM_2 As UInt16 = Prueba_colores_2 << 10
                ORDER_IN_TEAM_2 = ORDER_IN_TEAM_2 >> 10
                ' Form1.ORDER_IN_TEAM_BOX_2.Value = ORDER_IN_TEAM_2

                Form1.Leer_Player_Assignament.BaseStream.Position += 1
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                ' Form1.NumericPLAYERASS_INDEX_2.Value = 0
                ' Form1.NumericTEAMID_2.Value = 0
                'Form1.ListBox3.SelectedIndex = 0
                'Poner el nombre del equipo en el text box

                ' Form1.NumericDorsal_2.Value = 0

                ' Form1.TextBox_team_name_2.Text = "FREE PLAYER"
                Team2 = "FREE PLAYER"


            End If




        Else
            ' Form1.NumericPLAYERASS_INDEX.Value = 0
            ' Form1.NumericTEAMID.Value = 0
            ' Form1.ListBox3.SelectedIndex = 0
            'Poner el nombre del equipo en el text box

            ' Form1.NumericDorsal.Value = 0

            ' Form1.TextBox_team_name.Text = "FREE PLAYER"
            Team1 = "FREE PLAYER"
        End If

    End Sub




    ' Public Sub Grabar_player_assig()
    ' '''''''''''''''''''''''' A partir de aqui, player Assignment
    'Dim Player_ID As UInt32 = Form1.Player_num.Value
    'Dim Player_indextest As UInt32
    'Dim nuevo_dorsal As Byte
    'Dim nuevo_equipo As UInt32
    '    If Form1.NumericPLAYERASS_INDEX.Value <> 0 And Form1.NumericPLAYERASS_INDEX.Value <> Form1.PlAssigIndex_to_delete.Value And Form1.NumericPLAYERASS_INDEX.Value <> Form1.PlayerAssignment_index_mayor Then
    ''Grabo ahora el tema fichajes, hay que añadir que cambie el número del jugador.
    '        Form1.Leer_Player_Assignament.BaseStream.Position = 0
    '        Player_indextest = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32())
    '        While Player_indextest <> Form1.NumericPLAYERASS_INDEX.Value
    '            Form1.Leer_Player_Assignament.BaseStream.Position += 12
    '            Player_indextest = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32())
    '        End While
    '        Form1.Grabar_Player_Assignament.Write(swaps.swap32(Player_ID))
    '        nuevo_equipo = Form1.NumericTEAMID.Value
    '        Form1.Grabar_Player_Assignament.Write(swaps.swap32(nuevo_equipo))
    ''Grabo el dorsal
    '' Leer_Player_Assignament.BaseStream.Position += 2
    '        nuevo_dorsal = Form1.NumericDorsal.Value
    '        Form1.Grabar_Player_Assignament.Write(nuevo_dorsal)
    '        Form1.Leer_Player_Assignament.BaseStream.Position += 3



    '    ElseIf Form1.NumericPLAYERASS_INDEX.Value = Form1.PlAssigIndex_to_delete.Value And Form1.NumericPLAYERASS_INDEX.Value <> 0 Then

    'Dim unzlib_player_Assignament_aux As New MemoryStream
    'Dim Grabar_Player_Assignament_aux As New BinaryWriter(unzlib_player_Assignament_aux)



    '        Form1.Leer_Player_Assignament.BaseStream.Position = 0

    'Dim index_a_borrar As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)

    '        While index_a_borrar <> Form1.NumericPLAYERASS_INDEX.Value
    '            Form1.Leer_Player_Assignament.BaseStream.Position += 12
    '            index_a_borrar = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
    '        End While


    'Dim Posicion_a_borrar As UInt32 = Form1.Leer_Player_Assignament.BaseStream.Position - 4
    '        Form1.Leer_Player_Assignament.BaseStream.Position = 0

    '        While Form1.unzlib_Player_Assignament.Position < Posicion_a_borrar
    '            Grabar_Player_Assignament_aux.Write(Form1.Leer_Player_Assignament.ReadByte)
    '        End While


    '        Form1.Leer_Player_Assignament.BaseStream.Position += 16

    '        While Form1.Leer_Player_Assignament.BaseStream.Position < (Form1.unzlib_Player_Assignament.Length)
    '            Grabar_Player_Assignament_aux.Write(Form1.Leer_Player_Assignament.ReadByte)

    '        End While




    '        Form1.unzlib_Player_Assignament.Close()
    '        Form1.unzlib_Player_Assignament = New MemoryStream
    '        unzlib_player_Assignament_aux.Position = 0
    '        unzlib_player_Assignament_aux.CopyTo(Form1.unzlib_Player_Assignament)
    '        unzlib_player_Assignament_aux.Close()
    '        Form1.Leer_Player_Assignament = New BinaryReader(Form1.unzlib_Player_Assignament)
    '        Form1.Grabar_Player_Assignament = New BinaryWriter(Form1.unzlib_Player_Assignament)

    '        Form1.PlAssigIndex_to_delete.Value = 0


    '    Else
    '        Form1.Leer_Player_Assignament.BaseStream.Position = Form1.unzlib_Player_Assignament.Length
    ''Player_indextest = NumericPLAYERASS_INDEX.Value
    '        Form1.PlayerAssignment_index_mayor += 1
    '        Form1.Grabar_Player_Assignament.Write(swaps.swap32(Form1.PlayerAssignment_index_mayor))
    '        Form1.Grabar_Player_Assignament.Write(swaps.swap32(Player_ID))
    '        nuevo_equipo = Form1.NumericTEAMID.Value
    '        Form1.Grabar_Player_Assignament.Write(swaps.swap32(nuevo_equipo))
    'Dim cero As Byte = 0

    '        nuevo_dorsal = Form1.NumericDorsal.Value
    '        Form1.Grabar_Player_Assignament.Write(nuevo_dorsal)
    '        Form1.Grabar_Player_Assignament.Write(cero)
    '        Form1.Grabar_Player_Assignament.Write(cero)
    '        Form1.Grabar_Player_Assignament.Write(cero)



    '    End If

    '    If (Form1.ListBox1.SelectedItem <> Nothing) And ((Form1.NumericDorsal_2.Value <> 0) Or (Form1.TextBox_team_name_2.Text <> Nothing) Or (Form1.PlAssigIndex_to_delete_2.Value <> 0)) Then

    '        If Form1.NumericPLAYERASS_INDEX_2.Value <> 0 And Form1.NumericPLAYERASS_INDEX_2.Value <> Form1.PlAssigIndex_to_delete_2.Value And Form1.NumericPLAYERASS_INDEX_2.Value <> Form1.PlayerAssignment_index_mayor Then






    ''Leer_Player_Assignament.BaseStream.Position += 4

    '            Player_indextest = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32())
    '            While Player_indextest <> Form1.NumericPLAYERASS_INDEX_2.Value
    '                Form1.Leer_Player_Assignament.BaseStream.Position += 12
    '                Player_indextest = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32())
    '            End While
    '            Form1.Grabar_Player_Assignament.Write(swaps.swap32(Player_ID))
    '            nuevo_equipo = Form1.NumericTEAMID_2.Value
    '            Form1.Grabar_Player_Assignament.Write(swaps.swap32(nuevo_equipo))
    ''Grabo el dorsal
    ''Leer_Player_Assignament.BaseStream.Position += 1
    '            nuevo_dorsal = Form1.NumericDorsal_2.Value
    '            Form1.Grabar_Player_Assignament.Write(nuevo_dorsal)
    '            Form1.Leer_Player_Assignament.BaseStream.Position += 3


    '        ElseIf Form1.NumericPLAYERASS_INDEX_2.Value = Form1.PlAssigIndex_to_delete_2.Value And Form1.NumericPLAYERASS_INDEX_2.Value <> 0 Then

    'Dim unzlib_player_Assignament_aux As New MemoryStream
    'Dim Grabar_Player_Assignament_aux As New BinaryWriter(unzlib_player_Assignament_aux)



    '            Form1.Leer_Player_Assignament.BaseStream.Position = 0

    'Dim index_a_borrar As UInt32 = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)

    '            While index_a_borrar <> Form1.NumericPLAYERASS_INDEX_2.Value
    '                Form1.Leer_Player_Assignament.BaseStream.Position += 12
    '                index_a_borrar = swaps.swap32(Form1.Leer_Player_Assignament.ReadUInt32)
    '            End While


    'Dim Posicion_a_borrar As UInt32 = Form1.Leer_Player_Assignament.BaseStream.Position - 4
    '            Form1.Leer_Player_Assignament.BaseStream.Position = 0

    '            While Form1.unzlib_Player_Assignament.Position < Posicion_a_borrar
    '                Grabar_Player_Assignament_aux.Write(Form1.Leer_Player_Assignament.ReadByte)
    '            End While


    '            Form1.Leer_Player_Assignament.BaseStream.Position += 16

    '            While Form1.Leer_Player_Assignament.BaseStream.Position < (Form1.unzlib_Player_Assignament.Length)
    '                Grabar_Player_Assignament_aux.Write(Form1.Leer_Player_Assignament.ReadByte)

    '            End While




    '            Form1.unzlib_Player_Assignament.Close()
    '            Form1.unzlib_Player_Assignament = New MemoryStream
    '            unzlib_player_Assignament_aux.Position = 0
    '            unzlib_player_Assignament_aux.CopyTo(Form1.unzlib_Player_Assignament)
    '            unzlib_player_Assignament_aux.Close()
    '            Form1.Leer_Player_Assignament = New BinaryReader(Form1.unzlib_Player_Assignament)
    '            Form1.Grabar_Player_Assignament = New BinaryWriter(Form1.unzlib_Player_Assignament)

    '            Form1.PlAssigIndex_to_delete.Value = 0






    '        Else
    '            Form1.Leer_Player_Assignament.BaseStream.Position = Form1.unzlib_Player_Assignament.Length
    ''Player_indextest = NumericPLAYERASS_INDEX.Value
    '            Form1.PlayerAssignment_index_mayor += 1
    '            Form1.Grabar_Player_Assignament.Write(swaps.swap32(Form1.PlayerAssignment_index_mayor))
    '            Form1.Grabar_Player_Assignament.Write(swaps.swap32(Player_ID))
    '            nuevo_equipo = Form1.NumericTEAMID_2.Value
    '            Form1.Grabar_Player_Assignament.Write(swaps.swap32(nuevo_equipo))
    'Dim cero As Byte = 0

    '            nuevo_dorsal = Form1.NumericDorsal_2.Value
    '            Form1.Grabar_Player_Assignament.Write(nuevo_dorsal)
    '            Form1.Grabar_Player_Assignament.Write(cero)
    '            Form1.Grabar_Player_Assignament.Write(cero)
    '            Form1.Grabar_Player_Assignament.Write(cero)




    '        End If
    '    End If



    'End Sub

    Public Sub Leer_botas()
        If Form1.Boot_List_present = True Then

            boot_id = Boots.Buscar_botas(Player_ID)
            For k = 0 To Form1.DataGridView_boots.Rows.Count - 1
                If Form1.DataGridView_boots.Rows(k).Cells(0).Value = boot_id Then
                    boot_name = Form1.DataGridView_boots.Rows(k).Cells(4).Value
                End If
            Next
            Form1.TextBox_player_boots_name.Text = boot_name
            Form1.Player_boots_Id_box.Value = boot_id

        End If

    End Sub

    Public Sub Leer_guantes()
        If Form1.Glove_List_present = True Then
            Glove_id = Gloves.Buscar_Guantes(Player_ID)
            For k = 0 To Form1.DataGridView_gloves.Rows.Count - 1
                If Form1.DataGridView_gloves.Rows(k).Cells(0).Value = Glove_id Then
                    Glove_name = Form1.DataGridView_gloves.Rows(k).Cells(3).Value
                End If
            Next
            Form1.TextBox_player_gloves_name.Text = Glove_name
            Form1.Player_Gloves_Id_box.Value = Glove_id
        End If

    End Sub

    Public Sub Grabar_boots()
        If Form1.Boot_List_present = True Then

            Form1.Leer_Boots_list.BaseStream.Position = 0

            For i = 0 To Form1.unzlib_Boots_list.Length / 8 - 1
                Dim Player_to_find As UInt32 = swaps.swap32(Form1.Leer_Boots_list.ReadUInt32)

                If Form1.Player_num.Value = Player_to_find Then
                    Dim boot_to_save As UInt16 = Form1.Player_boots_Id_box.Value
                    Form1.Grabar_Boots_list.Write(swaps.swap16(boot_to_save))
                    Exit For
                Else
                    Form1.Leer_Boots_list.BaseStream.Position += 4
                End If

            Next

        End If
    End Sub

    Public Sub Grabar_Gloves()
        If Form1.Glove_List_present = True Then
            Form1.Leer_Gloves_list.BaseStream.Position = 0

            For i = 0 To Form1.unzlib_Gloves_list.Length / 8 - 1
                Dim Player_to_find As UInt32 = swaps.swap32(Form1.Leer_Gloves_list.ReadUInt32)

                If Form1.Player_num.Value = Player_to_find Then
                    Dim Glove_to_save As UInt16 = Form1.Player_Gloves_Id_box.Value
                    Form1.Grabar_Gloves_list.Write(swaps.swap16(Glove_to_save))
                    Exit For
                Else
                    Form1.Leer_Gloves_list.BaseStream.Position += 4
                End If

            Next
        End If

    End Sub

    Public Sub Leer_Playerappareance()
        If Form1.PLayer_Appareance_present = True Then

            Form1.Leer_PlayerAppareance.BaseStream.Position = 0
            Dim Player_ID As UInt32 = Form1.Player_num.Value
            Dim Current_index As UInt32 = Form1.ListBox1.SelectedIndex
            Dim Bloques As UInt32 = Form1.PlayerAppareance_MemStream.Length / 60
            'If CheckBoxFAKE_ID.Checked = False Then
            Form1.Leer_PlayerAppareance.BaseStream.Position = 0
            'Dim Changed As Boolean = False
            Dim Counter As UInt32 = 0

            For i = 0 To Form1.PlayerAppareance_MemStream.Length / 60 - 1
                Dim Check_REAL_FACE As UInt32 = swaps.swap32(Form1.Leer_PlayerAppareance.ReadUInt32)
                If Check_REAL_FACE = Player_ID Then
                    Form1.Leer_PlayerAppareance.BaseStream.Position -= 4
                    Dim Pos_ini As UInt32 = Form1.Leer_PlayerAppareance.BaseStream.Position
                    Form1.Leer_PlayerAppareance.BaseStream.Position += 37

                    Dim skincol_pic As Byte = Form1.Leer_PlayerAppareance.ReadByte

                    If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                        skincol_pic = skincol_pic >> 5

                    Else
                        skincol_pic = skincol_pic << 5
                        skincol_pic = skincol_pic >> 5
                    End If
                    Select Case skincol_pic
                        Case 0
                            Form1.PictureBoxSkin_col.Image = My.Resources._7
                            Form1.Skin_box.Value = 0
                        Case 1
                            Form1.PictureBoxSkin_col.Image = My.Resources._01
                            Form1.Skin_box.Value = 1
                        Case 2
                            Form1.PictureBoxSkin_col.Image = My.Resources._02
                            Form1.Skin_box.Value = 2
                        Case 3
                            Form1.PictureBoxSkin_col.Image = My.Resources._3
                            Form1.Skin_box.Value = 3
                        Case 4
                            Form1.PictureBoxSkin_col.Image = My.Resources._4
                            Form1.Skin_box.Value = 4
                        Case 5
                            Form1.PictureBoxSkin_col.Image = My.Resources._5
                            Form1.Skin_box.Value = 5
                        Case 6
                            Form1.PictureBoxSkin_col.Image = My.Resources._06
                            Form1.Skin_box.Value = 6
                        Case 7
                            Form1.PictureBoxSkin_col.Image = My.Resources._7
                            Form1.Skin_box.Value = 7

                    End Select


                    Exit For
                Else
                    Form1.Leer_PlayerAppareance.BaseStream.Position += 56

                End If
                Counter += 1
            Next
            'Dim bloques As UInt32 = Form1.PlayerAppareance_MemStream.Length / 60
            'If Counter = Form1.PlayerAppareance_MemStream.Length / 60 Then
            '    Dim dlgRes As DialogResult
            '    dlgRes = MessageBox.Show("Not info found on playerappareance, Do you want to add?", "Add Playerappareance", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            '    If dlgRes = Windows.Forms.DialogResult.Yes Then
            '        'Meter player appareance
            '        Dim Player_Player_appareance_block As Byte()

            '        Dim numAleatorio As New Random()
            '        Dim valorAleatorio As Integer = numAleatorio.Next(0, 500)
            '        Form1.Leer_PlayerAppareance.BaseStream.Position = (valorAleatorio * 60) + 4
            '        Player_Player_appareance_block = Form1.Leer_PlayerAppareance.ReadBytes(56)
            '        Dim end_of_file As Byte()
            '        Form1.Leer_PlayerAppareance.BaseStream.Position = 0

            '        For j = 0 To Form1.PlayerAppareance_MemStream.Length / 60 - 1
            '            Dim Check_order As UInt32 = swaps.swap32(Form1.Leer_PlayerAppareance.ReadUInt32)
            '            If Check_order < Player_ID Then
            '                Form1.Leer_PlayerAppareance.BaseStream.Position += 56

            '            ElseIf j = Form1.PlayerAppareance_MemStream.Length / 60 - 1 Then
            '                Form1.Leer_PlayerAppareance.BaseStream.Position = Form1.PlayerAppareance_MemStream.Length
            '                Form1.Grabar_PlayerAppareance.Write(swaps.swap32(Player_ID))
            '                Form1.Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
            '                Exit For
            '            Else
            '                If Check_order = Player_ID Then
            '                    Form1.Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
            '                    Exit For
            '                Else
            '                    'leer hasta el final
            '                    Form1.Leer_PlayerAppareance.BaseStream.Position -= 4
            '                    Dim Posicion_a_grabar As ULong = Form1.Leer_PlayerAppareance.BaseStream.Position
            '                    Dim Tamanho_a_leer As ULong = Form1.PlayerAppareance_MemStream.Length - Posicion_a_grabar
            '                    end_of_file = Form1.Leer_PlayerAppareance.ReadBytes(Tamanho_a_leer)
            '                    Form1.Leer_PlayerAppareance.BaseStream.Position = Posicion_a_grabar
            '                    Form1.Grabar_PlayerAppareance.Write(swaps.swap32(Player_ID))
            '                    Form1.Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
            '                    Form1.Grabar_PlayerAppareance.Write(end_of_file)

            '                    Exit For
            '                End If

            '            End If
            '        Next

            '        'Leer_PlayerAppareance.BaseStream.Position = PlayerAppareance_Stream.Length
            '        'Grabar_PlayerAppareance.Write(swaps.swap32(Player_ID))
            '        'Grabar_PlayerAppareance.Write(Player_Player_appareance_block)

            '        Form1.ListBox1.SelectedIndex = -1
            '        Form1.ListBox1.SelectedIndex = Current_index
            '    Else



            '        ' MsgBox("Edit Player again, now must work!")

            '    End If
            '    'Lo vuelvo a ejecutar para que funcione ahora que tiene bloque.


            'End If

        End If

    End Sub

    Public Sub Grabar_Playerappareance()

        If Form1.PLayer_Appareance_present = True Then


            Dim Player_ID As UInt32 = Form1.Player_num.Value
            Dim Bloques As UInt32 = Form1.PlayerAppareance_MemStream.Length / 60
            Form1.Leer_PlayerAppareance.BaseStream.Position = 0
            Dim counter As UInt32 = 0
            While Player_ID <> swaps.swap32(Form1.Leer_PlayerAppareance.ReadUInt32)
                counter += 1
                If Form1.Leer_PlayerAppareance.BaseStream.Position >= (Form1.PlayerAppareance_MemStream.Length - 56) Then
                    Exit While
                End If
                Form1.Leer_PlayerAppareance.BaseStream.Position += 56
            End While


            If counter < Bloques Then


                Form1.Leer_PlayerAppareance.BaseStream.Position -= 4
                Dim skin_val As Integer = Form1.Skin_box.Value
                Dim Pos_ini As UInt32 = Form1.Leer_PlayerAppareance.BaseStream.Position
                Form1.Leer_PlayerAppareance.BaseStream.Position += 37
                Dim OriginalSkin As Byte = Form1.Leer_PlayerAppareance.ReadByte
                Form1.Leer_PlayerAppareance.BaseStream.Position -= 1
                Dim Aux As Byte
                If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
                    skin_val = skin_val << 5
                    Aux = OriginalSkin << 5
                    Aux = Aux >> 5
                    Aux = (Aux Or skin_val)
                    OriginalSkin = Aux
                Else
                    Aux = OriginalSkin >> 3
                    Aux = Aux << 3
                    Aux = (Aux Or skin_val)
                    OriginalSkin = Aux
                End If
                Form1.Grabar_PlayerAppareance.Write(OriginalSkin)
            Else

                Dim dlgRes As DialogResult
                dlgRes = MessageBox.Show("Not info found on playerappareance, Do you want to add?", "Add Playerappareance", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If dlgRes = Windows.Forms.DialogResult.Yes Then
                    'Meter player appareance
                    Dim Player_Player_appareance_block As Byte()

                    Dim numAleatorio As New Random()
                    Dim valorAleatorio As Integer = numAleatorio.Next(0, 500)
                    Form1.Leer_PlayerAppareance.BaseStream.Position = (valorAleatorio * 60) + 4
                    Player_Player_appareance_block = Form1.Leer_PlayerAppareance.ReadBytes(56)
                    Dim end_of_file As Byte()
                    Form1.Leer_PlayerAppareance.BaseStream.Position = 0

                    For j = 0 To Form1.PlayerAppareance_MemStream.Length / 60 - 1
                        Dim Check_order As UInt32 = swaps.swap32(Form1.Leer_PlayerAppareance.ReadUInt32)
                        If Check_order < Player_ID Then
                            Form1.Leer_PlayerAppareance.BaseStream.Position += 56

                        ElseIf j = Form1.PlayerAppareance_MemStream.Length / 60 - 1 Then
                            Form1.Leer_PlayerAppareance.BaseStream.Position = Form1.PlayerAppareance_MemStream.Length
                            Form1.Grabar_PlayerAppareance.Write(swaps.swap32(Player_ID))
                            Form1.Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
                            Exit For
                        Else
                            If Check_order = Player_ID Then
                                Form1.Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
                                Exit For
                            Else
                                'leer hasta el final
                                Form1.Leer_PlayerAppareance.BaseStream.Position -= 4
                                Dim Posicion_a_grabar As ULong = Form1.Leer_PlayerAppareance.BaseStream.Position
                                Dim Tamanho_a_leer As ULong = Form1.PlayerAppareance_MemStream.Length - Posicion_a_grabar
                                end_of_file = Form1.Leer_PlayerAppareance.ReadBytes(Tamanho_a_leer)
                                Form1.Leer_PlayerAppareance.BaseStream.Position = Posicion_a_grabar
                                Form1.Grabar_PlayerAppareance.Write(swaps.swap32(Player_ID))
                                Form1.Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
                                Form1.Grabar_PlayerAppareance.Write(end_of_file)

                                Exit For
                            End If

                        End If
                    Next


                End If
            End If
        End If

    End Sub

End Class
