Imports Db_Xbox_editor
Imports System


Public Class Tactics

    Public Team_tactic_id As UInt32
    Public Short_Val As UInt16
    Public Frag_val1 As UInt16
    Public Frag_val2 As UInt16
    Public Frag_val3 As UInt16
    Public Frag_val4 As UInt16
    Public Frag_val5 As UInt16
    'Public CHECBOXES_VAL As Byte
    Public FRAG_VAL As UInt16

    Public Team_tactic_id_formation As UInt32
    Public Short_Val_formation As UInt16
    Public byte1_formation As Byte
    Public byte2_formation As Byte
    Public byte_frag As Byte
    Public byte_frag1 As Byte
    Public byte_frag2 As Byte
    Public byte_frag3 As Byte



    Public Sub Leer_Valores(ByVal Selected_Index As UInt32)


        Dim Index As UInt32 = Selected_Index * 12
        Form1.Leer_Tactics.BaseStream.Position = Index
        Team_tactic_id = swaps.swap32(Form1.Leer_Tactics.ReadUInt32)
        Form1.NumericUpDown4.Value = Team_tactic_id
        Short_Val = swaps.swap16(Form1.Leer_Tactics.ReadUInt16)
        Form1.NumericUpDown8.Value = Short_Val
        FRAG_VAL = swaps.swap16(Form1.Leer_Tactics.ReadUInt16)
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            FRAG_VAL = converter.bitworking_Tactics_16_1_toPc(FRAG_VAL)
        End If
        'lo hice sin reversar asi que fuerzo a reverse
        'If Form1.Tipo_consola = 0 Or Form1.Tipo_consola = 4 Then
        'FRAG_VAL = swaps.swap16_pcforzado(FRAG_VAL)

        'End If


        Frag_val1 = FRAG_VAL >> 14
        Form1.NumericUpDown9.Value = Frag_val1
        Frag_val2 = FRAG_VAL << 2
        Frag_val2 = Frag_val2 >> 14
        Form1.NumericUpDown10.Value = Frag_val2
        Frag_val3 = FRAG_VAL << 4
        Frag_val3 = Frag_val3 >> 12
        Form1.NumericUpDown11.Value = Frag_val3 + 1
        Frag_val4 = FRAG_VAL << 8
        Frag_val4 = Frag_val4 >> 12
        Form1.NumericUpDown12.Value = Frag_val4 + 1
        Frag_val5 = FRAG_VAL << 12
        Frag_val5 = Frag_val5 >> 12
        Form1.NumericUpDown13.Value = Frag_val5 + 1

        Dim CHECBOXES_VAL As Byte = Form1.Leer_Tactics.ReadByte
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            CHECBOXES_VAL = converter.Reverse_byte(CHECBOXES_VAL)
        End If

        Dim CHECK103 As Byte = CHECBOXES_VAL >> 7
        If CHECK103 = 1 Then
            Form1.CheckBox103.Checked = True
        Else
            Form1.CheckBox103.Checked = False
        End If
        Dim CHECK104 As Byte = CHECBOXES_VAL << 1
        CHECK104 = CHECK104 >> 7
        If CHECK104 = 1 Then
            Form1.CheckBox104.Checked = True
        Else
            Form1.CheckBox104.Checked = False
        End If
        Dim CHECK105 As Byte = CHECBOXES_VAL << 2
        CHECK105 = CHECK105 >> 7
        If CHECK105 = 1 Then
            Form1.CheckBox105.Checked = True
        Else
            Form1.CheckBox105.Checked = False
        End If
        Dim CHECK106 As Byte = CHECBOXES_VAL << 3
        CHECK106 = CHECK106 >> 7
        If CHECK106 = 1 Then
            Form1.CheckBox106.Checked = True
        Else
            Form1.CheckBox106.Checked = False
        End If
        Dim CHECK107 As Byte = CHECBOXES_VAL << 4
        CHECK107 = CHECK107 >> 7
        If CHECK107 = 1 Then
            Form1.CheckBox107.Checked = True
        Else
            Form1.CheckBox107.Checked = False
        End If
        Dim CHECK108 As Byte = CHECBOXES_VAL << 5
        CHECK108 = CHECK108 >> 7
        If CHECK108 = 1 Then
            Form1.CheckBox108.Checked = True
        Else
            Form1.CheckBox108.Checked = False
        End If
        Dim CHECK109 As Byte = CHECBOXES_VAL << 6
        CHECK109 = CHECK109 >> 7
        If CHECK109 = 1 Then
            Form1.CheckBox109.Checked = True
        Else
            Form1.CheckBox109.Checked = False
        End If
        Dim CHECK110 As Byte = CHECBOXES_VAL << 7
        CHECK110 = CHECK110 >> 7
        If CHECK110 = 1 Then
            Form1.CheckBox110.Checked = True
        Else
            Form1.CheckBox110.Checked = False
        End If


    End Sub

    Public Sub Leer_Valores_formation(ByVal Selected_Index As UInt32)

        'no se usa, lo he usado para algo de investigar
        Dim Index As UInt32 = Selected_Index * 12
        Form1.Leer_Tactics_formation.BaseStream.Position = Index
        Team_tactic_id_formation = swaps.swap32(Form1.Leer_Tactics_formation.ReadUInt32)

        Short_Val_formation = swaps.swap16(Form1.Leer_Tactics_formation.ReadUInt16)
        byte1_formation = Form1.Leer_Tactics_formation.ReadByte
        byte2_formation = Form1.Leer_Tactics_formation.ReadByte
        byte_frag = Form1.Leer_Tactics_formation.ReadByte


        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            byte_frag = converter.bitworking_TacticsFormation_toPc(byte_frag)
        End If

        byte_frag1 = byte_frag >> 4
        byte_frag2 = byte_frag << 4
        byte_frag2 = byte_frag2 >> 6
        byte_frag3 = byte_frag << 6
        byte_frag3 = byte_frag3 >> 6



    End Sub


    Public Sub Grabar_Valores(ByVal Selected_Index As UInt32)


        Dim Index As UInt32 = Selected_Index * 12
        Form1.Leer_Tactics.BaseStream.Position = Index
        Team_tactic_id = Form1.NumericUpDown4.Value
        Short_Val = Form1.NumericUpDown8.Value
        Frag_val1 = Form1.NumericUpDown9.Value
        Frag_val2 = Form1.NumericUpDown10.Value
        Frag_val3 = Form1.NumericUpDown11.Value - 1
        Frag_val4 = Form1.NumericUpDown12.Value - 1
        Frag_val5 = Form1.NumericUpDown13.Value - 1
        Dim aux16 As UInt16 = Frag_val1 << 14
        FRAG_VAL = (aux16 Or FRAG_VAL)
        aux16 = Frag_val2 << 12
        FRAG_VAL = (aux16 Or FRAG_VAL)
        aux16 = Frag_val3 << 8
        FRAG_VAL = (aux16 Or FRAG_VAL)
        aux16 = Frag_val4 << 4
        FRAG_VAL = (aux16 Or FRAG_VAL)
        aux16 = Frag_val5
        FRAG_VAL = (aux16 Or FRAG_VAL)
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            FRAG_VAL = swaps.swap16(converter.bitworking_Tactics_16_1_toConsole(FRAG_VAL))
        End If
        Dim CHECK103 As Byte
        If Form1.CheckBox103.Checked = True Then
            CHECK103 = 1
        Else
            CHECK103 = 0
        End If

        Dim CHECK104 As Byte
        If Form1.CheckBox104.Checked = True Then
            CHECK104 = 1
        Else
            CHECK104 = 0
        End If

        Dim CHECK105 As Byte
        If Form1.CheckBox105.Checked = True Then
            CHECK105 = 1
        Else
            CHECK105 = 0
        End If

        Dim CHECK106 As Byte
        If Form1.CheckBox106.Checked = True Then
            CHECK106 = 1
        Else
            CHECK106 = 0
        End If

        Dim CHECK107 As Byte
        If Form1.CheckBox107.Checked = True Then
            CHECK107 = 1
        Else
            CHECK107 = 0
        End If

        Dim CHECK108 As Byte
        If Form1.CheckBox108.Checked = True Then
            CHECK108 = 1
        Else
            CHECK108 = 0
        End If

        Dim CHECK109 As Byte
        If Form1.CheckBox109.Checked = True Then
            CHECK109 = 1
        Else
            CHECK109 = 0
        End If

        Dim CHECK110 As Byte
        If Form1.CheckBox110.Checked = True Then
            CHECK110 = 1
        Else
            CHECK110 = 0
        End If

        Dim AuxByte As Byte = CHECK103 << 7
        Dim Byte_GRAB As Byte = 0
        Byte_GRAB = (AuxByte Or Byte_GRAB)
        AuxByte = CHECK104 << 6
        Byte_GRAB = (AuxByte Or Byte_GRAB)
        AuxByte = CHECK105 << 5
        Byte_GRAB = (AuxByte Or Byte_GRAB)
        AuxByte = CHECK106 << 4
        Byte_GRAB = (AuxByte Or Byte_GRAB)
        AuxByte = CHECK107 << 3
        Byte_GRAB = (AuxByte Or Byte_GRAB)
        AuxByte = CHECK108 << 2
        Byte_GRAB = (AuxByte Or Byte_GRAB)
        AuxByte = CHECK109 << 1
        Byte_GRAB = (AuxByte Or Byte_GRAB)
        AuxByte = CHECK110
        Byte_GRAB = (AuxByte Or Byte_GRAB)

        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Byte_GRAB = converter.Reverse_byte(Byte_GRAB)
        End If

        ' Form1.Grabar_Tactics.Write(swaps.swap32(Team_tactic_id))
        'Form1.Grabar_Tactics.Write(swaps.swap16(Short_Val))
        Form1.Grabar_Tactics.BaseStream.Position += 6
        Form1.Grabar_Tactics.Write(swaps.swap16(FRAG_VAL))
        Form1.Grabar_Tactics.Write(Byte_GRAB)

    End Sub

    Public Sub Grabar_ID(ByVal Selected_Index As UInt32)


        Dim Index As UInt32 = Selected_Index * 12
        Form1.Leer_Tactics.BaseStream.Position = Index
        Team_tactic_id = Convert.ToUInt32(Form1.Team_id_box.Text)
        Form1.NumericUpDown4.Value = Team_tactic_id
       

        Form1.Grabar_Tactics.Write(swaps.swap32(Team_tactic_id))
        'Form1.Grabar_Tactics.Write(swaps.swap16(Short_Val))
       
    End Sub



End Class
