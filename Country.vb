Imports Db_Xbox_editor
Imports System.IO






Public Class Country


    Public Const tamanho_bloque As UInteger = 1348
    Public CHECK_Country As UInt32
    Public Violet As UInt32
    Public Blue As UInt32
    Public Country_ID As UInt32
    Public green As UInt32
    Public Nom_Country As String
    Public Nom_Country_short As String



    Public Sub Leer_Valores(ByVal Selected_index As UInt32)

        Dim Index As UInt32 = Selected_index * tamanho_bloque
        Form1.Leer_Country.BaseStream.Position = Index
        Dim Valor_imp_32 As UInt32 = swaps.swap32(Form1.Leer_Country.ReadUInt32)
        If Form1.Tipo_consola = 1 Or Form1.Tipo_consola = 2 Then
            Valor_imp_32 = converter.bitworking_Country_toPc(Valor_imp_32)
        End If


        CHECK_Country = Valor_imp_32 >> 31
        If CHECK_Country = 1 Then
            Form1.CheckBox102.Checked = True
        Else
            Form1.CheckBox102.Checked = False
        End If
        Violet = Valor_imp_32 << 1
        Violet = Violet >> 29
        Form1.NumericUpDown2.Value = Violet
        Blue = Valor_imp_32 << 4
        Blue = Blue >> 23
        Form1.NumericUpDown3.Value = Blue
        Country_ID = Valor_imp_32 << 13
        Country_ID = Country_ID >> 23
        Form1.Country_ID_box.Value = Country_ID
        green = Valor_imp_32 << 22
        green = green >> 22
        Form1.NumericUpDown5.Value = green

        Form1.NumericUpDown6.Value = Form1.Leer_Country.ReadByte
        Form1.NumericUpDown7.Value = Form1.Leer_Country.ReadByte
        Select Case Form1.NumericUpDown7.Value
            Case 2
                Form1.Label167.Text = "EUROPE"
            Case 3
                Form1.Label167.Text = "ASIA"
            Case 4
                Form1.Label167.Text = "SOUTH AMERICA"
            Case 5
                Form1.Label167.Text = "AFRICA"
            Case 6
                Form1.Label167.Text = "NORTH AMERICA"
            Case 7
                Form1.Label167.Text = "OCEANIA"
        End Select

        Form1.Leer_Country.BaseStream.Position = Index + 288
        Dim Aux_problemas_lenguas_varias As Integer = Form1.Leer_Country.BaseStream.Position
        Nom_Country = Form1.Leer_Country.ReadChars(70)
        Nom_Country = Nom_Country.TrimEnd("")
        Form1.Leer_Country.BaseStream.Position = Aux_problemas_lenguas_varias
        Form1.Leer_Country.BaseStream.Position += 420

        Nom_Country_short = Form1.Leer_Country.ReadChars(3)




    End Sub




End Class
