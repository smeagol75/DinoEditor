Imports Db_Xbox_editor
Imports System.IO






Public Class Stadium


    Public Const tamanho_bloque As UInteger = 272
    Public Id As UInt32
    Public negro As UInt32
    Public Licensed As UInt32
    Public Country As UInt32
    Public Capacidad As UInt32
    Public zone As Byte
    Public Nom_Jap As String
    Public Nom_Stadium As String
    Public Nom_country As String
    Public NOM_PROGRAMATIC As String

    Public order_index As UInt16
    Public order_id As UInt16
    Public Order_frag As UInt16
    Public negro7 As UInt16
    Public rojo2 As UInt16
    Public verde7 As UInt16

    Public order_index_in_conf As UInt16
    Public order_id_in_conf As UInt16
    Public byte_in_conf As Byte

    Public Sub Leer_Valores(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * tamanho_bloque
        Form1.Leer_Stadium.BaseStream.Position = Index
        Dim Valor_32 As UInt32 = swaps.swap32(Form1.Leer_Stadium.ReadUInt32)
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Valor_32 = converter.bitworking_Stadium_toPc(swaps.swap32(Valor_32))
        End If
        negro = Valor_32 >> 30
        Licensed = Valor_32 << 2
        Licensed = Licensed >> 31
        Country = Valor_32 << 3
        Country = Country >> 23
        Capacidad = Valor_32 << 12
        Capacidad = Capacidad >> 12
        Id = swaps.swap16(Form1.Leer_Stadium.ReadUInt16)

        For i = 0 To Form1.DataGridView_Countries.Rows.Count - 1
            If Form1.DataGridView_Countries.Rows(i).Cells(0).Value = Country Then
                Nom_country = Form1.DataGridView_Countries.Rows(i).Cells(1).Value.ToString
            End If
        Next
        zone = Form1.Leer_Stadium.ReadByte
        Form1.Zone_stadium_box.Value = zone


        Form1.Leer_Stadium.BaseStream.Position = Index + 8

        Nom_Jap = Form1.Leer_Stadium.ReadChars(110)
        Nom_Jap = Nom_Jap.TrimEnd("")
        Form1.Leer_Stadium.BaseStream.Position = Index + 129

        Dim Aux_problemas_lenguas_varias As Integer = Form1.Leer_Stadium.BaseStream.Position
        Nom_Stadium = Form1.Leer_Stadium.ReadChars(110)
        Nom_Stadium = Nom_Stadium.TrimEnd("")
        Form1.Leer_Stadium.BaseStream.Position = Aux_problemas_lenguas_varias

        Form1.Leer_Stadium.BaseStream.Position = Index + 250
        NOM_PROGRAMATIC = Form1.Leer_Stadium.ReadChars(20)
        NOM_PROGRAMATIC = NOM_PROGRAMATIC.TrimEnd("")


    End Sub

    Public Sub Grabar_Valores(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * tamanho_bloque
        Form1.Leer_Stadium.BaseStream.Position = Index
        Dim Zero As Byte = 0
        If Index = Form1.unzlib_Stadium.Length Then
            For i = 0 To 271
                Form1.Grabar_Stadium.Write(Zero)
            Next
            Form1.Leer_Stadium.BaseStream.Position = Index
        End If


        Dim Valor_32 As UInt32

        negro = Form1.N_A_stadium_BOX.Value
        Licensed = Form1.Real_stadium_box.Value
        Country = Form1.Country_stadium_box.Value
        Capacidad = Form1.Capacity_Stadium_box.Value
        Id = Form1.Stadium_id_box.Value
        Nom_Jap = Form1.TextBox_jap_name_satdium.Text
        Nom_Stadium = Form1.Stadium_name_box.Text
        NOM_PROGRAMATIC = Form1.TextBox_prog_name_stadium.Text
        zone = Form1.Zone_stadium_box.Value


        Dim Aux_32 As UInt32 = negro << 30
        Valor_32 = Aux_32 Or Valor_32
        Aux_32 = Licensed << 29
        Valor_32 = Aux_32 Or Valor_32
        Aux_32 = Country << 20
        Valor_32 = Aux_32 Or Valor_32
        Aux_32 = Capacidad
        Valor_32 = Aux_32 Or Valor_32

        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Valor_32 = swaps.swap32(converter.bitworking_Stadium_toConsole(Valor_32))
        End If
        Form1.Grabar_Stadium.Write(swaps.swap32(Valor_32))
        Form1.Grabar_Stadium.Write(swaps.swap16(Id))
        Form1.Grabar_Stadium.Write(zone)
        'grabar los ceros
        Form1.Grabar_Stadium.BaseStream.Position = Index + 8

        For i = 0 To 120
            Form1.Grabar_Stadium.Write(Zero)
        Next
        Form1.Grabar_Stadium.BaseStream.Position = Index + 8
        Form1.Grabar_Stadium.Write(Nom_Jap.ToCharArray)
        Form1.Leer_Stadium.BaseStream.Position = Index + 129
        For i = 0 To 120
            Form1.Grabar_Stadium.Write(Zero)
        Next
        Form1.Leer_Stadium.BaseStream.Position = Index + 129
        Form1.Grabar_Stadium.Write(Nom_Stadium.ToCharArray)
        Form1.Leer_Stadium.BaseStream.Position = Index + 250
        For i = 0 To 20
            Form1.Grabar_Stadium.Write(Zero)
        Next
        Form1.Leer_Stadium.BaseStream.Position = Index + 250
        Form1.Grabar_Stadium.Write(NOM_PROGRAMATIC.ToCharArray)

    End Sub

    Public Sub Leer_Valores_order(ByVal Selected_index As UInt32)
        Dim Index As UInt32 = Selected_index * 8
        Form1.Leer_Stadium_order.BaseStream.Position = Index

        order_index = swaps.swap16(Form1.Leer_Stadium_order.ReadUInt16)
        order_id = swaps.swap16(Form1.Leer_Stadium_order.ReadUInt16)
        Order_frag = swaps.swap16(Form1.Leer_Stadium_order.ReadUInt16)
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Order_frag = converter.bitworking_StadiumOrder_toPc(swaps.swap16(Order_frag))
        End If
        negro7 = Order_frag >> 9
        rojo2 = Order_frag << 7
        rojo2 = rojo2 >> 14
        verde7 = Order_frag << 9
        verde7 = verde7 >> 9




    End Sub


    Public Sub Leer_Valores_order_in_conf(ByVal Selected_index As UInt32)
        Dim Index As UInt32 = Selected_index * 8
        Form1.Leer_Stadium_order_in_conf.BaseStream.Position = Index

        order_id_in_conf = swaps.swap16(Form1.Leer_Stadium_order_in_conf.ReadUInt16)
        order_index_in_conf = swaps.swap16(Form1.Leer_Stadium_order_in_conf.ReadUInt16)
        byte_in_conf = Form1.Leer_Stadium_order_in_conf.ReadByte
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            byte_in_conf = converter.rotr(byte_in_conf, 1)
        End If




    End Sub


End Class
