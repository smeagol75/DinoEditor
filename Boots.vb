Imports Db_Xbox_editor
Imports System.IO






Public Class Boots


    Public Const tamanho_bloque As UInteger = 304
    Public Id As UInt16
    Public Order As Byte
    
    Public Color As String
    Public Nom_boot As String
    Public Material As String



    Public Sub Leer_Valores(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * tamanho_bloque
        Form1.Leer_boots.BaseStream.Position = Index
        Id = swaps.swap16(Form1.Leer_boots.ReadUInt16)
        Order = Form1.Leer_boots.ReadByte
        Form1.Leer_boots.BaseStream.Position = Index + 4
        Color = Form1.Leer_Boots.ReadChars(98)
        Color = Color.TrimEnd("")
        Form1.Leer_Boots.BaseStream.Position = Index + 104
        Material = Form1.Leer_Boots.ReadChars(98)
        Material = Material.TrimEnd("")
        Form1.Leer_Boots.BaseStream.Position = Index + 204
        Nom_boot = Form1.Leer_Boots.ReadChars(98)
        Nom_boot = Nom_boot.TrimEnd("")


    End Sub

    Public Sub grabar_Valores(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * tamanho_bloque
        Form1.Grabar_boots.BaseStream.Position = Index

        Dim Zero As Byte = 0
        If Index = Form1.unzlib_boots.Length Then
            For i = 0 To tamanho_bloque - 1
                Form1.Grabar_boots.Write(Zero)
            Next
            Form1.Leer_boots.BaseStream.Position = Index
        End If

        Id = Form1.Boots_Id_box.Value
        Order = Form1.Boots_Order_box.Value
        Color = Form1.TextBox_Boots_Color.Text
        Material = Form1.TextBox_Boots_Material.Text
        Nom_boot = Form1.TextBox_Boots_name.Text
        Form1.Grabar_boots.Write(swaps.swap16(Id))
        Form1.Grabar_boots.Write(Order)
        Form1.Grabar_boots.BaseStream.Position = Index + 4

        For i = 0 To 299
            Form1.Grabar_Boots.Write(Zero)
        Next
        Form1.Grabar_boots.BaseStream.Position = Index + 4
        Form1.Grabar_Boots.Write(Color.ToCharArray)
        Form1.Grabar_Boots.BaseStream.Position = Index + 104
        Form1.Grabar_Boots.Write(Material.ToCharArray)
        Form1.Grabar_Boots.BaseStream.Position = Index + 204
        Form1.Grabar_Boots.Write(Nom_boot.ToCharArray)
    End Sub

    Public Shared Function Buscar_botas(ByVal Player_id As UInt32) As UInt16
        If Form1.Boot_List_present = True Then


            Form1.Leer_Boots_list.BaseStream.Position = 0
            Dim Boots_id As UInt16 = 0
            For i = 0 To Form1.unzlib_Boots_list.Length / 8 - 1
                If Player_id = swaps.swap32(Form1.Leer_Boots_list.ReadUInt32) Then
                    Boots_id = swaps.swap16(Form1.Leer_Boots_list.ReadUInt16)
                    Exit For
                Else
                    Form1.Leer_Boots_list.BaseStream.Position += 4
                End If

            Next
            Return Boots_id
        End If

    End Function


End Class
