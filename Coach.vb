
Imports Db_Xbox_editor
Imports System.IO


Public Class Coach




    Public Coach_Id As UInt32
    Public Id_sin_bytes_lic As UInt16
    Public ByteLIC As Byte
    Public country_16 As UInt16
    Public Equipo As UInt32
    Public Nombre_equipo As String
    Public Texto_Nacionalidad As String = ""
    Public Nombre_entrenador As String = ""
    Public Index As UInt32


    Public Const tamanho_bloque As UInteger = 108
    Public Const Coach_ID_pos As UInteger = 0
    Public Const Coach_country_pos As UInteger = 4
    Public Const Coach_Name_pos As UInteger = 62


    Public Sub Leer_valores(ByVal selected_index As Integer)
        Index = selected_index * tamanho_bloque
        Form1.Leer_Coach.BaseStream.Position = Index
        Coach_Id = swaps.swap32(Form1.Leer_Coach.ReadUInt32)
        country_16 = swaps.swap16(Form1.Leer_Coach.ReadUInt16)

        Form1.Leer_Coach.BaseStream.Position = Index + Coach_Name_pos


        Nombre_entrenador = Form1.Leer_Coach.ReadChars(40)
        Nombre_entrenador = Nombre_entrenador.TrimEnd("")



        'Buscamos Nacionalidad y  byte Licenciado según tipo consola

        If Form1.Tipo_consola = 0 Or Form1.Tipo_consola = 4 Then
            country_16 = country_16 << 7
            country_16 = country_16 >> 7
            Form1.Leer_Coach.BaseStream.Position = Index + 2
            ByteLIC = Form1.Leer_Coach.ReadByte


        Else

            country_16 = country_16 >> 7
            Form1.Leer_Coach.BaseStream.Position = Index + 1
            ByteLIC = Form1.Leer_Coach.ReadByte

        End If


        For i = 0 To Form1.DataGridView_Countries.Rows.Count - 1
            If Form1.DataGridView_Countries.Rows(i).Cells(0).Value = country_16.ToString Then
                Texto_Nacionalidad = Form1.DataGridView_Countries.Rows(i).Cells(1).Value.ToString
            End If



        Next

        'Buscamos Nombre equipo

        Dim bloques_equipos As UInteger = Form1.unzlib_Team.Length / Team.tamanho_bloque

        Form1.Leer_Team.BaseStream.Position = 0

        For j = 0 To bloques_equipos - 1
            Dim equipo1 As New Team

            equipo1.Leer_valores(j)
            If Coach_Id = equipo1.Coach Then
                Nombre_equipo = equipo1.Nombre_equipo_english
                Equipo = equipo1.Id_32
            End If


            Form1.Leer_Coach.BaseStream.Position = Index
        Next
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Form1.Leer_Coach.BaseStream.Position = Index + 2
        End If

        Id_sin_bytes_lic = swaps.swap16(Form1.Leer_Coach.ReadUInt16)

    End Sub

    Public Sub Grabar_valores(ByVal selected_index As Integer)
        Index = selected_index * tamanho_bloque
        Form1.Grabar_Coach.BaseStream.Position = Index
        'Form1.Leer_Coach.BaseStream.Position = Index
        Dim Coach_type As Byte = Convert.ToInt32(Form1.Text_COach_type.Text)
        Coach_Id = swaps.swap32(Form1.Text_COACHID_SEL.Value)
        country_16 = Convert.ToInt16(Form1.TextNAtion_COach_sel.Text)
        Nombre_entrenador = Form1.Text_Coach_sel.Text
        Equipo = Form1.Text_Team_Coach_ID.Text
        Form1.Leer_Coach.BaseStream.Position = Index + 5

        Dim Segundo_byte_porbyte9 As UInt16 = Form1.Leer_Coach.ReadUInt16
        Dim Aux1 As UInt16
        Dim new_byte9_and_secondbyte As UInt16
        If Form1.Tipo_consola = 0 Or Form1.Tipo_consola = 4 Then
            Aux1 = country_16
            Aux1 = (Aux1 And Convert.ToUInt32("111111111", 2))
            'aux1 = aux1 << 7
            new_byte9_and_secondbyte = (Aux1 Or new_byte9_and_secondbyte)

            Aux1 = Segundo_byte_porbyte9
            Aux1 = (Aux1 And Convert.ToUInt32("1111111", 2))
            Aux1 = Aux1 << 8
            new_byte9_and_secondbyte = (Aux1 Or new_byte9_and_secondbyte)
        Else
            Aux1 = country_16
            Aux1 = (Aux1 And Convert.ToUInt32("111111111", 2))
            Aux1 = Aux1 << 7
            new_byte9_and_secondbyte = (Aux1 Or new_byte9_and_secondbyte)

            Aux1 = Segundo_byte_porbyte9
            Aux1 = (Aux1 And Convert.ToUInt32("1111111", 2))
            ' aux1 = aux1 << 9
            new_byte9_and_secondbyte = (Aux1 Or new_byte9_and_secondbyte)
            new_byte9_and_secondbyte = swaps.swap16(new_byte9_and_secondbyte)
        End If


        country_16 = new_byte9_and_secondbyte

        Dim Equipo_a_mirar As New Team
        Dim Aux As UInt32 = 0

        If Form1.Text_Team_Coach_ID.Text <> 0 Then
            While Equipo_a_mirar.Id_32 <> Equipo
                Equipo_a_mirar.Leer_valores(Aux)
                Aux += 1
            End While

            Dim Index_for_coach As UInteger = Aux - 1

            Equipo_a_mirar.Grabar_Coach(Index_for_coach, Coach_Id, Coach_type)


        End If
        



        Form1.Grabar_Coach.BaseStream.Position = Index + Coach_ID_pos
        Form1.Grabar_Coach.Write(Coach_Id)
        Form1.Grabar_Coach.BaseStream.Position = Index + Coach_country_pos
        Form1.Grabar_Coach.Write(country_16)
        Form1.Grabar_Coach.BaseStream.Position = Index + Coach_Name_pos
        Dim cero_cero As Byte = &H0
        For i = 0 To 45
            Form1.Grabar_Coach.Write(cero_cero)
        Next
        Form1.Grabar_Coach.BaseStream.Position = Index + Coach_Name_pos
        Form1.Grabar_Coach.Write(Nombre_entrenador.ToCharArray)


    End Sub








End Class
