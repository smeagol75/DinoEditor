Imports Db_Xbox_editor
Imports System


Public Class Derby

    Public Team1_Derby_id As UInt32
    Public Team2_Derby_id As UInt32
    Public Frag_val1 As UInt16
    Public Frag_val2 As UInt16
    Public Frag_val3 As UInt16
    Public Frag_val4 As UInt16
    Public FRAG_VAL As UInt16


    Public Sub Leer_Valores(ByVal Selected_Index As UInt32)


        Dim Index As UInt32 = Selected_Index * 12
        Form1.Leer_Derby.BaseStream.Position = Index
        Team1_Derby_id = swaps.swap32(Form1.Leer_Derby.ReadUInt32)
        Team2_Derby_id = swaps.swap32(Form1.Leer_Derby.ReadUInt32)
        FRAG_VAL = swaps.swap16(Form1.Leer_Derby.ReadUInt16)
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            FRAG_VAL = converter.bitworking_Derby_toPc(FRAG_VAL)
        End If

        Frag_val1 = FRAG_VAL >> 12

        Frag_val2 = FRAG_VAL << 4
        Frag_val2 = Frag_val2 >> 14
        Form1.NumericUpDown15.Value = Frag_val2
        Frag_val3 = FRAG_VAL << 6
        Frag_val3 = Frag_val3 >> 13
        Form1.NumericUpDown17.Value = Frag_val3
        Frag_val4 = FRAG_VAL << 9
        Frag_val4 = Frag_val4 >> 9
        Form1.NumericUpDown18.Value = Frag_val4




    End Sub

    Public Sub Grabar_Valores(ByVal Selected_Index As UInt32)


        Dim Index As UInt32 = Selected_Index * 12
        If Index > Form1.unzlib_Derby.Length Then
            Index = Form1.unzlib_Derby.Length
        End If
        Form1.Leer_Derby.BaseStream.Position = Index
        Team1_Derby_id = Form1.DataGridView_derby.Rows(Form1.DataGridView_derby.CurrentRow.Index).Cells(0).Value
        Team2_Derby_id = Form1.DataGridView_derby.Rows(Form1.DataGridView_derby.CurrentRow.Index).Cells(2).Value

        FRAG_VAL = 0
        Frag_val1 = Form1.NumericUpDown14.Value
        Frag_val2 = Form1.NumericUpDown15.Value
        Frag_val3 = Form1.NumericUpDown17.Value
        Frag_val4 = Form1.NumericUpDown18.Value

        Dim aux16 As UInt16 = Frag_val1 << 12
        FRAG_VAL = (aux16 Or FRAG_VAL)
        aux16 = Frag_val2 << 10
        FRAG_VAL = (aux16 Or FRAG_VAL)
        aux16 = Frag_val3 << 7
        FRAG_VAL = (aux16 Or FRAG_VAL)
        aux16 = Frag_val4
        FRAG_VAL = (aux16 Or FRAG_VAL)

        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            FRAG_VAL = swaps.swap16(converter.bitworking_Derby_toConsole(swaps.swap16(FRAG_VAL)))
        End If
        Dim Zero_16 As UShort = 0

        Form1.Grabar_Derby.Write(swaps.swap32(Team1_Derby_id))
        Form1.Grabar_Derby.Write(swaps.swap32(Team2_Derby_id))
        Form1.Grabar_Derby.Write(swaps.swap16(FRAG_VAL))
        Form1.Grabar_Derby.Write(swaps.swap16(Zero_16))

    End Sub



End Class
