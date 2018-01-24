Imports Db_Xbox_editor
Imports System.IO


Public Class Competition

    Public comp_id As UInteger

    Public Sub Leer_competition(ByVal selected_index As UInt32)
        Dim Pos_ini As UInteger = selected_index * 32
        Form1.Leer_Competition.BaseStream.Position = Pos_ini
        Dim Valor_32_imp As UInt32 = swaps.swap32(Form1.Leer_Competition.ReadUInt32)
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Valor_32_imp = converter.bitworking_Competition_toPc(Valor_32_imp)
        End If

        Dim CHECK54 As UInt32 = Valor_32_imp >> 31
        If CHECK54 = 1 Then
            Form1.CheckBox54.Checked = True
        Else
            Form1.CheckBox54.Checked = False
        End If
        Dim CHECK55 As UInt32 = Valor_32_imp << 1
        CHECK55 = CHECK55 >> 31
        If CHECK55 = 1 Then
            Form1.CheckBox55.Checked = True
        Else
            Form1.CheckBox55.Checked = False
        End If
        Dim CHECK56 As UInt32 = Valor_32_imp << 2
        CHECK56 = CHECK56 >> 31
        If CHECK56 = 1 Then
            Form1.CheckBox56.Checked = True
        Else
            Form1.CheckBox56.Checked = False
        End If
        Dim CHECK57 As UInt32 = Valor_32_imp << 3
        CHECK57 = CHECK57 >> 31
        If CHECK57 = 1 Then
            Form1.CheckBox57.Checked = True
        Else
            Form1.CheckBox57.Checked = False
        End If
        Dim CHECK58 As UInt32 = Valor_32_imp << 4
        CHECK58 = CHECK58 >> 31
        If CHECK58 = 1 Then
            Form1.CheckBox58.Checked = True
        Else
            Form1.CheckBox58.Checked = False
        End If
        Dim CHECK59 As UInt32 = Valor_32_imp << 5
        CHECK59 = CHECK59 >> 31
        If CHECK59 = 1 Then
            Form1.CheckBox59.Checked = True
        Else
            Form1.CheckBox59.Checked = False
        End If
        Dim CHECK60 As UInt32 = Valor_32_imp << 6
        CHECK60 = CHECK60 >> 31
        If CHECK60 = 1 Then
            Form1.CheckBox60.Checked = True
        Else
            Form1.CheckBox60.Checked = False
        End If
        Dim CHECK61 As UInt32 = Valor_32_imp << 7
        CHECK61 = CHECK61 >> 31
        If CHECK61 = 1 Then
            Form1.CheckBox61.Checked = True
        Else
            Form1.CheckBox61.Checked = False
        End If

        Dim UNK_1 As UInt32 = Valor_32_imp << 8
        UNK_1 = UNK_1 >> 30
        Form1.UNK1_box.Value = UNK_1

        Select Case UNK_1
            Case 0
                Form1.Label26.Text = "Club Team"
            Case 1
                Form1.Label26.Text = "National Team"
            Case 2
                Form1.Label26.Text = "Fake Team"
            Case Else
                Form1.Label26.Text = "Unknown"

        End Select



        Dim CHECK62 As UInt32 = Valor_32_imp << 10
        CHECK62 = CHECK62 >> 31
        If CHECK62 = 1 Then
            Form1.CheckBox62.Checked = True
        Else
            Form1.CheckBox62.Checked = False
        End If
        Dim UNK_2 As UInt32 = Valor_32_imp << 11
        UNK_2 = UNK_2 >> 26
        Form1.UNK2_box.Value = UNK_2

        Dim UNK_3 As UInt32 = Valor_32_imp << 17
        UNK_3 = UNK_3 >> 25
        Form1.UNK3_box.Value = UNK_3

        Dim UNK_4 As UInt32 = Valor_32_imp << 24
        UNK_4 = UNK_4 >> 24
        Form1.UNK_4_BOX.Value = UNK_4




    End Sub

    Public Sub Grabar_competition(ByVal selected_index As UInt32)
        Dim Pos_ini As UInteger = selected_index * 32
        Form1.Leer_Competition.BaseStream.Position = Pos_ini



        Dim CHECK54 As UInt32
        If Form1.CheckBox54.Checked Then
            CHECK54 = 1
        Else
            CHECK54 = 0
        End If
        Dim CHECK55 As UInt32
        If Form1.CheckBox55.Checked Then
            CHECK55 = 1
        Else
            CHECK55 = 0
        End If
        Dim CHECK56 As UInt32
        If Form1.CheckBox56.Checked Then
            CHECK56 = 1
        Else
            CHECK56 = 0
        End If
        Dim CHECK57 As UInt32
        If Form1.CheckBox57.Checked Then
            CHECK57 = 1
        Else
            CHECK57 = 0
        End If
        Dim CHECK58 As UInt32
        If Form1.CheckBox58.Checked Then
            CHECK58 = 1
        Else
            CHECK58 = 0
        End If
        Dim CHECK59 As UInt32
        If Form1.CheckBox59.Checked Then
            CHECK59 = 1
        Else
            CHECK59 = 0
        End If
        Dim CHECK60 As UInt32
        If Form1.CheckBox60.Checked Then
            CHECK60 = 1
        Else
            CHECK60 = 0
        End If
        Dim CHECK61 As UInt32
        If Form1.CheckBox61.Checked Then
            CHECK61 = 1
        Else
            CHECK61 = 0
        End If


        Dim UNK_1 As UInt32 = Form1.UNK1_box.Value

        Dim CHECK62 As UInt32
        If Form1.CheckBox62.Checked Then
            CHECK62 = 1
        Else
            CHECK62 = 0
        End If
        Dim UNK_2 As UInt32 = Form1.UNK2_box.Value
        Dim UNK_3 As UInt32 = Form1.UNK3_box.Value
        Dim UNK_4 As UInt32 = Form1.UNK_4_BOX.Value

        Dim Valor_32_imp As UInt32 = 0
        Dim Aux32 = CHECK54 << 31
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = CHECK55 << 30
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = CHECK56 << 29
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = CHECK57 << 28
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = CHECK58 << 27
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = CHECK59 << 26
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = CHECK60 << 25
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = CHECK61 << 24
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = UNK_1 << 22
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = CHECK62 << 21
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = UNK_2 << 15
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = UNK_3 << 8
        Valor_32_imp = (Aux32 Or Valor_32_imp)
        Aux32 = UNK_4
        Valor_32_imp = (Aux32 Or Valor_32_imp)

        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Valor_32_imp = converter.bitworking_Competition_toConsole(swaps.swap32(Valor_32_imp))
        End If

        Form1.Grabar_Competition.Write(Valor_32_imp)

    End Sub

    Public Sub Leer_Competition_Kind(ByVal Selected_index As UInt32)


        Dim Pos_ini As UInteger = Selected_index * 88
        Form1.Leer_Competition_Kind.BaseStream.Position = Pos_ini
        Dim Order As Byte = Form1.Leer_Competition_Kind.ReadByte
        Form1.NumericUpDown19.Value = Order
        Dim Byte_imp As Byte = Form1.Leer_Competition_Kind.ReadByte
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Byte_imp = converter.Byte_comp_kind_to_pc(Byte_imp)
        End If
        Dim UNK1 As Byte = Byte_imp >> 6
        Form1.UNK1_KIND_BOX.Value = UNK1
        Dim UNK2 As Byte = Byte_imp << 2
        UNK2 = UNK2 >> 5
        Form1.UNK2_KIND_BOX.Value = UNK2
        Dim UNK3 As Byte = Byte_imp << 5
        UNK3 = UNK3 >> 5
        Form1.UNK3_KIND_BOX.Value = UNK3
    End Sub

    Public Sub Grabar_Competition_Kind(ByVal Selected_index As UInt32)


        Dim Pos_ini As UInteger = Selected_index * 88
        Form1.Leer_Competition_Kind.BaseStream.Position = Pos_ini
        Dim Order As Byte = Form1.NumericUpDown19.Value
        Dim Byte_imp As Byte

        Dim UNK1 As Byte = Form1.UNK1_KIND_BOX.Value
        Dim UNK2 As Byte = Form1.UNK2_KIND_BOX.Value
        Dim UNK3 As Byte = Form1.UNK3_KIND_BOX.Value
        Dim Aux_byte As Byte = UNK1 << 6
        Byte_imp = (Aux_byte Or Byte_imp)
        Aux_byte = UNK2 << 3
        Byte_imp = (Aux_byte Or Byte_imp)
        Aux_byte = UNK3
        Byte_imp = (Aux_byte Or Byte_imp)

        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Byte_imp = converter.Byte_comp_kind_to_console(Byte_imp)
        End If
        Form1.Grabar_Competition_Kind.Write(Order)
        Form1.Grabar_Competition_Kind.Write(Byte_imp)



    End Sub

    Public Sub Leer_Competition_Reg(ByVal Selected_index As UInt32)

        Dim Pos_ini As UInteger = Selected_index * 148

        Form1.Leer_Competition_regulation.BaseStream.Position = Pos_ini

        Dim UNK1 As UInt16 = swaps.swap16(Form1.Leer_Competition_regulation.ReadUInt16)
        Form1.UNK1_COMP_REG_BOX.Value = UNK1
        Dim UNK2 As UInt16 = swaps.swap16(Form1.Leer_Competition_regulation.ReadUInt16)
        Form1.UNK2_COMP_REG_BOX.Value = UNK2
        Dim UNK3 As UInt16 = swaps.swap16(Form1.Leer_Competition_regulation.ReadUInt16)
        Form1.UNK3_COMP_REG_BOX.Value = UNK3
        Dim UNK4 As Byte = Form1.Leer_Competition_regulation.ReadByte
        Form1.UNK4_COMP_REG_BOX.Value = UNK4
        Dim UNK5 As Byte = Form1.Leer_Competition_regulation.ReadByte
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            UNK5 = converter.rotr(UNK5, 1)
        End If
        Form1.UNK5_COMP_REG_BOX.Value = UNK5
        Dim Big_32_BYTE_VAL As UInt32 = Form1.Leer_Competition_regulation.ReadUInt32
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Big_32_BYTE_VAL = converter.bitworking_CompetitionRegulation32_toPc(swaps.swap32(Big_32_BYTE_VAL))
        End If
        comp_id = UNK5
        Dim UNK6 As UInt32 = Big_32_BYTE_VAL >> 29
        Form1.UNK6_COMP_REG_BOX.Value = UNK6
        Dim UNK7 As UInt32 = Big_32_BYTE_VAL << 3
        UNK7 = UNK7 >> 27
        Form1.UNK7_COMP_REG_BOX.Value = UNK7
        Dim UNK8 As UInt32 = Big_32_BYTE_VAL << 8
        UNK8 = UNK8 >> 26
        Form1.UNK8_COMP_REG_BOX.Value = UNK8
        Dim UNK9 As UInt32 = Big_32_BYTE_VAL << 14
        UNK9 = UNK9 >> 26
        Form1.UNK9_COMP_REG_BOX.Value = UNK9
        Dim UNK10 As UInt32 = Big_32_BYTE_VAL << 20
        UNK10 = UNK10 >> 26
        Form1.UNK10_COMP_REG_BOX.Value = UNK10
        Dim UNK11 As UInt32 = Big_32_BYTE_VAL << 26
        UNK11 = UNK11 >> 26
        Form1.UNK11_COMP_REG_BOX.Value = UNK11
        Dim Big_16_BYTE_VAL As UInt16 = Form1.Leer_Competition_regulation.ReadUInt16
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Big_16_BYTE_VAL = converter.bitworking_CompetitionRegulation16_1_toPc(swaps.swap16(Big_16_BYTE_VAL))
        End If

        Dim CHECK63 As UInt16 = Big_16_BYTE_VAL >> 15
        If CHECK63 = 1 Then
            Form1.CheckBox63.Checked = True
        Else
            Form1.CheckBox63.Checked = False
        End If
        Dim CHECK64 As UInt16 = Big_16_BYTE_VAL << 1
        CHECK64 = CHECK64 >> 15
        If CHECK64 = 1 Then
            Form1.CheckBox64.Checked = True
        Else
            Form1.CheckBox64.Checked = False
        End If
        Dim CHECK65 As UInt16 = Big_16_BYTE_VAL << 2
        CHECK65 = CHECK65 >> 14
        If CHECK65 = 1 Then
            Form1.CheckBox65.Checked = True
        Else
            Form1.CheckBox65.Checked = False
        End If

        Dim UNK12 As UInt16 = Big_16_BYTE_VAL << 4
        UNK12 = UNK12 >> 13
        Form1.UNK12_COMP_REG_BOX.Value = UNK12
        Dim UNK13 As UInt16 = Big_16_BYTE_VAL << 7
        UNK13 = UNK13 >> 13
        Form1.UNK13_COMP_REG_BOX.Value = UNK13
        Dim UNK14 As UInt16 = Big_16_BYTE_VAL << 10
        UNK14 = UNK14 >> 13
        Form1.UNK14_COMP_REG_BOX.Value = UNK14
        Dim UNK15 As UInt16 = Big_16_BYTE_VAL << 13
        UNK15 = UNK15 >> 13
        Form1.UNK15_COMP_REG_BOX.Value = UNK15
        'Dim UNK16 As UInt16 = Big_16_BYTE_VAL << 13
        'UNK16 = UNK16 >> 13
        'Form1.UNK16_COMP_REG_BOX.Value = UNK16

        Dim Byte_1 As Byte = Form1.Leer_Competition_regulation.ReadByte
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Byte_1 = converter.Reverse_byte(Byte_1)
        End If

        Dim CHECK66 As Byte = Byte_1 >> 7
        If CHECK66 = 1 Then
            Form1.CheckBox66.Checked = True
        Else
            Form1.CheckBox66.Checked = False
        End If

        Dim CHECK67 As Byte = Byte_1 << 1
        CHECK67 = CHECK67 >> 7
        If CHECK67 = 1 Then
            Form1.CheckBox67.Checked = True
        Else
            Form1.CheckBox67.Checked = False
        End If

        Dim CHECK68 As Byte = Byte_1 << 2
        CHECK68 = CHECK68 >> 7
        If CHECK68 = 1 Then
            Form1.CheckBox68.Checked = True
        Else
            Form1.CheckBox68.Checked = False
        End If

        Dim CHECK69 As Byte = Byte_1 << 3
        CHECK69 = CHECK69 >> 7
        If CHECK69 = 1 Then
            Form1.CheckBox69.Checked = True
        Else
            Form1.CheckBox69.Checked = False
        End If


        Dim CHECK70 As Byte = Byte_1 << 4
        CHECK70 = CHECK70 >> 7
        If CHECK70 = 1 Then
            Form1.CheckBox70.Checked = True
        Else
            Form1.CheckBox70.Checked = False
        End If

        Dim CHECK71 As Byte = Byte_1 << 5
        CHECK71 = CHECK71 >> 7
        If CHECK71 = 1 Then
            Form1.CheckBox71.Checked = True
        Else
            Form1.CheckBox71.Checked = False
        End If

        Dim CHECK72 As Byte = Byte_1 << 6
        CHECK72 = CHECK72 >> 7
        If CHECK72 = 1 Then
            Form1.CheckBox72.Checked = True
        Else
            Form1.CheckBox72.Checked = False
        End If

        Dim CHECK73 As Byte = Byte_1 << 7
        CHECK73 = CHECK73 >> 7
        If CHECK73 = 1 Then
            Form1.CheckBox73.Checked = True
        Else
            Form1.CheckBox73.Checked = False
        End If

        Dim Byte_2 As Byte = Form1.Leer_Competition_regulation.ReadByte
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Byte_2 = converter.Reverse_byte(Byte_2)
        End If

        Dim CHECK74 As Byte = Byte_2 >> 7
        If CHECK74 = 1 Then
            Form1.CheckBox74.Checked = True
        Else
            Form1.CheckBox74.Checked = False
        End If

        Dim CHECK75 As Byte = Byte_2 << 1
        CHECK75 = CHECK75 >> 7
        If CHECK75 = 1 Then
            Form1.CheckBox75.Checked = True
        Else
            Form1.CheckBox75.Checked = False
        End If

        Dim CHECK76 As Byte = Byte_2 << 2
        CHECK76 = CHECK76 >> 7
        If CHECK76 = 1 Then
            Form1.CheckBox76.Checked = True
        Else
            Form1.CheckBox76.Checked = False
        End If

        Dim CHECK77 As Byte = Byte_2 << 3
        CHECK77 = CHECK77 >> 7
        If CHECK77 = 1 Then
            Form1.CheckBox77.Checked = True
        Else
            Form1.CheckBox77.Checked = False
        End If


        Dim CHECK78 As Byte = Byte_2 << 4
        CHECK78 = CHECK78 >> 7
        If CHECK78 = 1 Then
            Form1.CheckBox78.Checked = True
        Else
            Form1.CheckBox78.Checked = False
        End If

        Dim CHECK79 As Byte = Byte_2 << 5
        CHECK79 = CHECK79 >> 7
        If CHECK79 = 1 Then
            Form1.CheckBox79.Checked = True
        Else
            Form1.CheckBox79.Checked = False
        End If

        Dim CHECK80 As Byte = Byte_2 << 6
        CHECK80 = CHECK80 >> 7
        If CHECK80 = 1 Then
            Form1.CheckBox80.Checked = True
        Else
            Form1.CheckBox80.Checked = False
        End If

        Dim CHECK81 As Byte = Byte_2 << 7
        CHECK81 = CHECK81 >> 7
        If CHECK81 = 1 Then
            Form1.CheckBox81.Checked = True
        Else
            Form1.CheckBox81.Checked = False
        End If




    End Sub

    Public Sub Grabar_Competition_Reg(ByVal Selected_index As UInt32)

        Dim Pos_ini As UInteger = Selected_index * 148

        Form1.Leer_Competition_regulation.BaseStream.Position = Pos_ini

        Dim UNK1 As UInt16 = Form1.UNK1_COMP_REG_BOX.Value
        Dim UNK2 As UInt16 = Form1.UNK2_COMP_REG_BOX.Value
        Dim UNK3 As UInt16 = Form1.UNK3_COMP_REG_BOX.Value
        Dim UNK4 As Byte = Form1.UNK4_COMP_REG_BOX.Value
        Dim UNK5 As Byte = Form1.UNK5_COMP_REG_BOX.Value
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            UNK5 = converter.rotl(UNK5, 1)
        End If

        Dim Big_32_BYTE_VAL As UInt32


        Dim UNK6 As UInt32 = Form1.UNK6_COMP_REG_BOX.Value
        Dim UNK7 As UInt32 = Form1.UNK7_COMP_REG_BOX.Value
        Dim UNK8 As UInt32 = Form1.UNK8_COMP_REG_BOX.Value
        Dim UNK9 As UInt32 = Form1.UNK9_COMP_REG_BOX.Value
        Dim UNK10 As UInt32 = Form1.UNK10_COMP_REG_BOX.Value
        Dim UNK11 As UInt32 = Form1.UNK11_COMP_REG_BOX.Value

        Dim aux_32 As UInt32 = UNK6 << 29
        Big_32_BYTE_VAL = (aux_32 Or Big_32_BYTE_VAL)
        aux_32 = UNK7 << 24
        Big_32_BYTE_VAL = (aux_32 Or Big_32_BYTE_VAL)
        aux_32 = UNK8 << 18
        Big_32_BYTE_VAL = (aux_32 Or Big_32_BYTE_VAL)
        aux_32 = UNK9 << 12
        Big_32_BYTE_VAL = (aux_32 Or Big_32_BYTE_VAL)
        aux_32 = UNK10 << 6
        Big_32_BYTE_VAL = (aux_32 Or Big_32_BYTE_VAL)
        aux_32 = UNK11
        Big_32_BYTE_VAL = (aux_32 Or Big_32_BYTE_VAL)

        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Big_32_BYTE_VAL = converter.bitworking_CompetitionRegulation32_toConsole(Big_32_BYTE_VAL)
        End If




        Dim Big_16_BYTE_VAL As UInt16


        Dim CHECK63 As UInt16
        If Form1.CheckBox63.Checked Then
            CHECK63 = 1
        Else
            CHECK63 = 0
        End If
        Dim CHECK64 As UInt16
        If Form1.CheckBox64.Checked Then
            CHECK64 = 1
        Else
            CHECK64 = 0
        End If
        Dim CHECK65 As UInt16
        If Form1.CheckBox65.Checked Then
            CHECK65 = 1
        Else
            CHECK65 = 0
        End If

        Dim UNK12 As UInt16 = Form1.UNK12_COMP_REG_BOX.Value
        Dim UNK13 As UInt16 = Form1.UNK13_COMP_REG_BOX.Value
        Dim UNK14 As UInt16 = Form1.UNK14_COMP_REG_BOX.Value
        Dim UNK15 As UInt16 = Form1.UNK15_COMP_REG_BOX.Value


        Dim aux16 = CHECK63 << 15
        Big_16_BYTE_VAL = aux16 Or Big_16_BYTE_VAL
        aux16 = CHECK64 << 14
        Big_16_BYTE_VAL = aux16 Or Big_16_BYTE_VAL
        aux16 = CHECK65 << 12
        Big_16_BYTE_VAL = aux16 Or Big_16_BYTE_VAL
        aux16 = UNK12 << 9
        Big_16_BYTE_VAL = aux16 Or Big_16_BYTE_VAL
        aux16 = UNK13 << 6
        Big_16_BYTE_VAL = aux16 Or Big_16_BYTE_VAL
        aux16 = UNK14 << 3
        Big_16_BYTE_VAL = aux16 Or Big_16_BYTE_VAL
        aux16 = UNK15
        Big_16_BYTE_VAL = aux16 Or Big_16_BYTE_VAL
        


        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Big_16_BYTE_VAL = converter.bitworking_CompetitionRegulation16_1_toConsole(swaps.swap16(Big_16_BYTE_VAL))
        End If


        Dim Byte_1 As Byte

        Dim CHECK66 As Byte
        If Form1.CheckBox66.Checked Then
            CHECK66 = 1
        Else
            CHECK66 = 0
        End If
        Dim CHECK67 As Byte
        If Form1.CheckBox67.Checked Then
            CHECK67 = 1
        Else
            CHECK67 = 0
        End If
        Dim CHECK68 As Byte
        If Form1.CheckBox68.Checked Then
            CHECK68 = 1
        Else
            CHECK68 = 0
        End If
        Dim CHECK69 As Byte
        If Form1.CheckBox69.Checked Then
            CHECK69 = 1
        Else
            CHECK69 = 0
        End If
        Dim CHECK70 As Byte
        If Form1.CheckBox70.Checked Then
            CHECK70 = 1
        Else
            CHECK70 = 0
        End If
        Dim CHECK71 As Byte
        If Form1.CheckBox71.Checked Then
            CHECK71 = 1
        Else
            CHECK71 = 0
        End If
        Dim CHECK72 As Byte
        If Form1.CheckBox72.Checked Then
            CHECK72 = 1
        Else
            CHECK72 = 0
        End If
        Dim CHECK73 As Byte
        If Form1.CheckBox73.Checked Then
            CHECK73 = 1
        Else
            CHECK73 = 0
        End If

        Dim Aux_byte As Byte

        Aux_byte = CHECK66 << 7
        Byte_1 = Aux_byte Or Byte_1
        Aux_byte = CHECK67 << 6
        Byte_1 = Aux_byte Or Byte_1
        Aux_byte = CHECK68 << 5
        Byte_1 = Aux_byte Or Byte_1
        Aux_byte = CHECK69 << 4
        Byte_1 = Aux_byte Or Byte_1
        Aux_byte = CHECK70 << 3
        Byte_1 = Aux_byte Or Byte_1
        Aux_byte = CHECK71 << 2
        Byte_1 = Aux_byte Or Byte_1
        Aux_byte = CHECK72 << 1
        Byte_1 = Aux_byte Or Byte_1
        Aux_byte = CHECK73
        Byte_1 = Aux_byte Or Byte_1



        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Byte_1 = converter.Reverse_byte(Byte_1)
        End If

        Dim Byte_2 As Byte

        Dim CHECK74 As Byte
        If Form1.CheckBox74.Checked Then
            CHECK74 = 1
        Else
            CHECK74 = 0
        End If
        Dim CHECK75 As Byte
        If Form1.CheckBox75.Checked Then
            CHECK75 = 1
        Else
            CHECK75 = 0
        End If
        Dim CHECK76 As Byte
        If Form1.CheckBox76.Checked Then
            CHECK76 = 1
        Else
            CHECK76 = 0
        End If
        Dim CHECK77 As Byte
        If Form1.CheckBox77.Checked Then
            CHECK77 = 1
        Else
            CHECK77 = 0
        End If
        Dim CHECK78 As Byte
        If Form1.CheckBox78.Checked Then
            CHECK78 = 1
        Else
            CHECK78 = 0
        End If
        Dim CHECK79 As Byte
        If Form1.CheckBox79.Checked Then
            CHECK79 = 1
        Else
            CHECK79 = 0
        End If
        Dim CHECK80 As Byte
        If Form1.CheckBox80.Checked Then
            CHECK80 = 1
        Else
            CHECK80 = 0
        End If
        Dim CHECK81 As Byte
        If Form1.CheckBox81.Checked Then
            CHECK81 = 1
        Else
            CHECK81 = 0
        End If



        Aux_byte = CHECK74 << 7
        Byte_2 = Aux_byte Or Byte_2
        Aux_byte = CHECK75 << 6
        Byte_2 = Aux_byte Or Byte_2
        Aux_byte = CHECK76 << 5
        Byte_2 = Aux_byte Or Byte_2
        Aux_byte = CHECK77 << 4
        Byte_2 = Aux_byte Or Byte_2
        Aux_byte = CHECK78 << 3
        Byte_2 = Aux_byte Or Byte_2
        Aux_byte = CHECK79 << 2
        Byte_2 = Aux_byte Or Byte_2
        Aux_byte = CHECK80 << 1
        Byte_2 = Aux_byte Or Byte_2
        Aux_byte = CHECK81
        Byte_2 = Aux_byte Or Byte_2



        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Byte_2 = converter.Reverse_byte(Byte_2)
        End If

        Form1.Grabar_Competition_regulation.Write(swaps.swap16(UNK1))
        Form1.Grabar_Competition_regulation.Write(swaps.swap16(UNK2))
        Form1.Grabar_Competition_regulation.Write(swaps.swap16(UNK3))
        Form1.Grabar_Competition_regulation.Write(UNK4)
        Form1.Grabar_Competition_regulation.Write(UNK5)
        Form1.Grabar_Competition_regulation.Write(Big_32_BYTE_VAL)
        Form1.Grabar_Competition_regulation.Write(Big_16_BYTE_VAL)
        Form1.Grabar_Competition_regulation.Write(Byte_1)
        Form1.Grabar_Competition_regulation.Write(Byte_2)



    End Sub



End Class
