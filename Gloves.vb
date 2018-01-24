Imports Db_Xbox_editor
Imports System.IO






Public Class Gloves


    Public Const tamanho_bloque As UInteger = 204
    Public Id As UInt16
    Public Order As Byte
   
    Public Color As String
    Public Nom_Gloves As String

    Public Sub Leer_Valores(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * tamanho_bloque
        Form1.Leer_Gloves.BaseStream.Position = Index
        Id = swaps.swap16(Form1.Leer_Gloves.ReadUInt16)
        Order = Form1.Leer_Gloves.ReadByte
        Form1.Leer_Gloves.BaseStream.Position = Index + 4
        Color = Form1.Leer_Gloves.ReadChars(98)
        Color = Color.TrimEnd("")
        Form1.Leer_Gloves.BaseStream.Position = Index + 104
        Nom_Gloves = Form1.Leer_Gloves.ReadChars(98)
        Nom_Gloves = Nom_Gloves.TrimEnd("")

    End Sub

    Public Sub grabar_Valores(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * tamanho_bloque
        Form1.Grabar_Gloves.BaseStream.Position = Index

        Dim Zero As Byte = 0
        If Index = Form1.unzlib_Gloves.Length Then
            For i = 0 To tamanho_bloque - 1
                Form1.Grabar_Gloves.Write(Zero)
            Next
            Form1.Leer_Gloves.BaseStream.Position = Index
        End If

        Id = Form1.Gloves_Id_box.Value
        Order = Form1.Gloves_order_box.Value
        Color = Form1.TextBox_Gloves_color.Text
        Nom_Gloves = Form1.TextBox_Gloves_name.Text
        Form1.Grabar_Gloves.Write(swaps.swap16(Id))
        Form1.Grabar_Gloves.Write(Order)
        Form1.Grabar_Gloves.BaseStream.Position = Index + 4

        For i = 0 To 199
            Form1.Grabar_Gloves.Write(Zero)
        Next
        Form1.Grabar_Gloves.BaseStream.Position = Index + 4
        Form1.Grabar_Gloves.Write(Color.ToCharArray)
        Form1.Grabar_Gloves.BaseStream.Position = Index + 104
        Form1.Grabar_Gloves.Write(Nom_Gloves.ToCharArray)


    End Sub

    Public Shared Function Buscar_Guantes(ByVal Player_id As UInt32) As UInt16
        If Form1.Glove_List_present = True Then
            Form1.Leer_Gloves_list.BaseStream.Position = 0
            Dim Gloves_id As UInt16 = 0
            For i = 0 To Form1.unzlib_Gloves_list.Length / 8 - 1
                If Player_id = swaps.swap32(Form1.Leer_Gloves_list.ReadUInt32) Then
                    Gloves_id = swaps.swap16(Form1.Leer_Gloves_list.ReadUInt16)
                    Exit For
                Else
                    Form1.Leer_Gloves_list.BaseStream.Position += 4
                End If

            Next
            Return Gloves_id
        End If

    End Function



End Class
