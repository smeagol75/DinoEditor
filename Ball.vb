Imports Db_Xbox_editor
Imports System.IO






Public Class Ball


    Public Const tamanho_bloque As UInteger = 140
    Public Id As UInt16
    Public Order As Byte
    Public Id_condition As UInt16
    Public order_condition As UInt16
    Public byte_condition As Byte

    Public Nom_ball As String
   
    Public Sub Leer_Valores(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * tamanho_bloque
        Form1.Leer_Ball.BaseStream.Position = Index
        Id = swaps.swap16(Form1.Leer_Ball.ReadUInt16)
        Order = Form1.Leer_Ball.ReadByte
        Form1.Leer_Ball.BaseStream.Position = Index + 4

        Nom_ball = Form1.Leer_Ball.ReadChars(135)
        Nom_ball = Nom_ball.TrimEnd("")


    End Sub

    Public Sub grabar_Valores(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * tamanho_bloque
        Form1.Grabar_Ball.BaseStream.Position = Index

        Dim Zero As Byte = 0
        If Index = Form1.unzlib_Ball.Length Then
            For i = 0 To tamanho_bloque - 1
                Form1.Grabar_Ball.Write(Zero)
            Next
            Form1.Leer_Ball.BaseStream.Position = Index
        End If

        Id = Form1.Ball_id_box.Value
        Order = Form1.Ball_order_box.Value
        Nom_ball = Form1.TextBox_ball.Text
        Form1.Grabar_Ball.Write(swaps.swap16(Id))
        Form1.Grabar_Ball.Write(Order)
        Form1.Grabar_Ball.BaseStream.Position = Index + 4

        For i = 0 To 134
            Form1.Grabar_Ball.Write(zero)
        Next
        Form1.Grabar_Ball.BaseStream.Position = Index + 4
        Form1.Grabar_Ball.Write(Nom_ball.ToCharArray)
        

    End Sub

    Public Sub Leer_Valores_condition(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * 8
        Form1.Leer_Ball_condition.BaseStream.Position = Index
        Id_condition = swaps.swap16(Form1.Leer_Ball_condition.ReadUInt16)
        order_condition = swaps.swap16(Form1.Leer_Ball_condition.ReadUInt16)
        byte_condition = Form1.Leer_Ball_condition.ReadByte()
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            byte_condition = converter.rotr(byte_condition, 2)
        End If

    End Sub

    Public Sub Grabar_Valores_condition(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * 8
        Form1.Grabar_Ball_condition.BaseStream.Position = Index
        Id_condition = Form1.Ball_id_cond_box.Value
        order_condition = Form1.Ball_order_cond_box.Value
        byte_condition = Form1.byte_ball_cond_box.Value
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            byte_condition = converter.rotl(byte_condition, 2)
        End If

        Form1.Grabar_Ball_condition.Write(swaps.swap16(Id_condition))
        Form1.Grabar_Ball_condition.Write(swaps.swap16(order_condition))
        Form1.Grabar_Ball_condition.Write(byte_condition)


    End Sub


End Class
