Imports System
Imports System.IO
Imports System.Collections
Imports System.Text
Imports System.Drawing




Public Class Form1
    Dim OpenPes As New OpenFileDialog
    Dim archivo As String
    Dim correctos As Integer = 0
    Dim incorrectos As Integer = 0
    Dim Stream_para_version As FileStream
    Dim Check_FF As Byte = 3


    Public Leer_Player As BinaryReader
    Public Grabar_player As BinaryWriter
    Public unzlib_Player As MemoryStream
    Public Leer_Competition_regulation As BinaryReader
    Public Grabar_Competition_regulation As BinaryWriter
    Public unzlib_Competition_regulation As MemoryStream
    Public Leer_Competition As BinaryReader
    Public Grabar_Competition As BinaryWriter
    Public unzlib_Competition As MemoryStream

    Public Leer_Team As BinaryReader
    Public Grabar_Team As BinaryWriter
    Public unzlib_Team As MemoryStream
    Public Leer_Competition_Entry As BinaryReader
    Public Grabar_Competition_Entry As BinaryWriter
    Public unzlib_CompetitionEntry As MemoryStream
    Public Leer_Player_Assignament As BinaryReader
    Public Grabar_Player_Assignament As BinaryWriter
    Public unzlib_Player_Assignament As MemoryStream
    Public Leer_Stadium As BinaryReader
    Public Grabar_Stadium As BinaryWriter
    Public unzlib_Stadium As MemoryStream
    Public Leer_Coach As BinaryReader
    Public Grabar_Coach As BinaryWriter
    Public unzlib_Coach As MemoryStream
    Public Leer_Country As BinaryReader
    Public Grabar_Country As BinaryWriter
    Public unzlib_Country As MemoryStream
    Public Leer_PlayerAppareance As BinaryReader
    Public Grabar_PlayerAppareance As BinaryWriter
    Public PlayerAppareance_Stream As FileStream
    Public PlayerAppareance_MemStream As MemoryStream
    Public Leer_Competition_Kind As BinaryReader
    Public Grabar_Competition_Kind As BinaryWriter
    Public unzlib_Competition_Kind As MemoryStream
    Public Leer_Tactics As BinaryReader
    Public Grabar_Tactics As BinaryWriter
    Public unzlib_Tactics As MemoryStream
    Public Leer_Derby As BinaryReader
    Public Grabar_Derby As BinaryWriter
    Public unzlib_Derby As MemoryStream
    Public Leer_Stadium_order As BinaryReader
    Public Grabar_Stadium_order As BinaryWriter
    Public unzlib_Stadium_order As MemoryStream
    Public Leer_Stadium_order_in_conf As BinaryReader
    Public Grabar_Stadium_order_in_conf As BinaryWriter
    Public unzlib_Stadium_order_in_conf As MemoryStream
    Public Leer_Ball As BinaryReader
    Public Grabar_Ball As BinaryWriter
    Public unzlib_Ball As MemoryStream
    Public Leer_Ball_condition As BinaryReader
    Public Grabar_Ball_condition As BinaryWriter
    Public unzlib_Ball_condition As MemoryStream
    Public Leer_Boots As BinaryReader
    Public Grabar_Boots As BinaryWriter
    Public unzlib_Boots As MemoryStream
    Public Leer_Boots_list As BinaryReader
    Public Grabar_Boots_list As BinaryWriter
    Public unzlib_Boots_list As MemoryStream
    Public Leer_Gloves As BinaryReader
    Public Grabar_Gloves As BinaryWriter
    Public unzlib_Gloves As MemoryStream
    Public Leer_Gloves_list As BinaryReader
    Public Grabar_Gloves_list As BinaryWriter
    Public unzlib_Gloves_list As MemoryStream
    Public Leer_Tactics_formation As BinaryReader
    Public Grabar_Tactics_formation As BinaryWriter
    Public unzlib_Tactics_formation As MemoryStream



    Dim openfolder As FolderBrowserDialog
    Dim Competition_entry_index_mayor As UInt16
    Public PlayerAssignment_index_mayor As UInteger = 0
    Dim Player_id_mayor As UInteger = 17000
    Dim Temp_Competition_entry_index_mayor As UInt16
    Public Label_form2 As String
    Public combo1_selec_index As UInteger
    Public combo1_selec_index_name As String


    Public NombreEquipo_cambiado As Boolean = False
    Dim num_orig_equipos_antes_de_cambios As UInteger
    Public CheckSelected As Boolean
    Public Id_de_equipo_max As UInt16
    Public index_de_equipo_max As UInt32
    Public Tipo_consola As UInt32
    Public Estadio_elegido As UInteger = 29
    Public Coach_elegido As UInteger = 0
    Public Liga_nojugable_elegida As UInteger = 0
    Public Nationality_elegida As UInteger = 0
    Public Cargando As New SplashScreen1
    Dim nombrePlayer As String
    Dim nombreCompetitionReg As String
    Dim nombreTeam As String
    Dim nombreCompetitionEntry As String
    Dim nombrePlayerAssignment As String
    Dim nombreStadium As String
    Dim NombreCoach As String
    Dim NombreCountry As String
    Dim nombrePlayerApareance As String = "\PlayerAppearance.bin"
    Dim nombreBootList As String = "\BootsList.bin"
    Dim nombreGloveList As String = "\GloveList.bin"
    Dim Nombrecompetition As String
    Dim Nombrecompetition_Kind As String
    Dim NombreTactics As String
    Dim NombreDerby As String
    Dim NombreStadium_order As String
    Dim NombreStadium_order_in_conf As String
    Dim NombreBall As String
    Dim NombreBall_condition As String
    Dim NombreBoots As String
    Dim NombreGloves As String
    Dim NombreTactics_formation As String



    Public PLayer_Appareance_present As Boolean = False
    Public Boot_List_present As Boolean = False
    Public Glove_List_present As Boolean = False
    Public Player_id_orig As UInt32
    Dim ID_cambiada As Boolean = False
    Public ID_ORIGINAL_ANTES_CAMBIAR As UInt32 = 0
    Public Eyescol As Byte = 1
    Public skincol As Byte = 20
    Public Language As Integer = 2
    Public Show_sel As Integer = 0
    Public Language_read_1 As Integer = 1
    Public Language_read_2 As Integer = 1
    Public Language_read_3 As Integer = 1
    Public Language_read_4 As Integer = 1
    Public Language_read_5 As Integer = 1
    Public Language_read_6 As Integer = 1
    Public Language_read_7 As Integer = 1
    Public Language_read_8 As Integer = 1
    Public Language_read_9 As Integer = 1
    Public Language_read_10 As Integer = 1
    Public Language_read_11 As Integer = 1
    Public Language_read_12 As Integer = 1
    Public Language_read_13 As Integer = 1
    Public Language_read_14 As Integer = 1
    Public Language_read_15 As Integer = 1
    Public Language_read_16 As Integer = 1



    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim CheckVersion As Double = 14
        Dim texto As String
        Try
              Dim objHttp As Object
            objHttp = CreateObject("MSXML2.XMLHTTP")
            objHttp.Open("GET", "https://u.jimcdn.com/e/o/sa7131c437043117e/userlayout/css/2017.css", False)
            objHttp.Send()
            texto = objHttp.ResponseText
            objHttp = Nothing
            Dim newVersion As Double = Convert.ToDouble(texto)
            If newVersion > CheckVersion Then
                New_Version.ShowDialog()
            End If


        Catch ex As Exception

        End Try

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ComboBox1.Items.Clear()
        DataGridView_coach.Rows.Clear()
        DataGridView_Countries.Rows.Clear()
        DataGridView_player.Rows.Clear()
        DataGridView_playersOfTeam.Rows.Clear()
        DataGridView_Stadium.Rows.Clear()
        DataGridView_TEAM.Rows.Clear()



        openfolder = New FolderBrowserDialog



        If openfolder.ShowDialog() = System.Windows.Forms.DialogResult.OK Then




            TabControl1.Visible = True




            If RadioButton1.Checked = True Then
                nombrePlayer = "\Player1.Bin"
                nombreCompetitionReg = "\CompetitionRegulation1.bin"
                nombreTeam = "\Team1.bin"
                nombreCompetitionEntry = "\CompetitionEntry1.bin"
                nombrePlayerAssignment = "\PlayerAssignment1.bin"
                nombreStadium = "\Stadium1.bin"
                NombreCoach = "\Coach1.bin"
                NombreCountry = "\Country1.bin"
                Nombrecompetition = "\Competition1.bin"
                Nombrecompetition_Kind = "\CompetitionKind1.bin"
                NombreTactics = "\Tactics1.bin"
                NombreDerby = "\Derby1.bin"
                NombreStadium_order = "\StadiumOrder1.bin"
                NombreStadium_order_in_conf = "\StadiumOrderInConfederation1.bin"
                NombreBall = "\Ball1.bin"
                NombreBall_condition = "\BallCondition1.bin"
                NombreBoots = "\Boots1.bin"
                NombreGloves = "\Glove1.bin"
                NombreTactics_formation = "\TacticsFormation1.bin"


            ElseIf RadioButton2.Checked = True Then
                nombrePlayer = "\Player2.Bin"
                nombreCompetitionReg = "\CompetitionRegulation2.bin"
                nombreTeam = "\Team2.bin"
                nombreCompetitionEntry = "\CompetitionEntry2.bin"
                nombrePlayerAssignment = "\PlayerAssignment2.bin"
                nombreStadium = "\Stadium2.bin"
                NombreCoach = "\Coach2.bin"
                NombreCountry = "\Country2.bin"
                Nombrecompetition = "\Competition2.bin"
                Nombrecompetition_Kind = "\CompetitionKind2.bin"
                NombreTactics = "\Tactics2.bin"
                NombreDerby = "\Derby2.bin"
                NombreStadium_order = "\StadiumOrder2.bin"
                NombreStadium_order_in_conf = "\StadiumOrderInConfederation2.bin"
                NombreBall = "\Ball2.bin"
                NombreBall_condition = "\BallCondition2.bin"
                NombreBoots = "\Boots2.bin"
                NombreGloves = "\Glove2.bin"
                NombreTactics_formation = "\TacticsFormation2.bin"

            ElseIf RadioButton3.Checked = True Then
                nombrePlayer = "\Player3.Bin"
                nombreCompetitionReg = "\CompetitionRegulation3.bin"
                nombreTeam = "\Team3.bin"
                nombreCompetitionEntry = "\CompetitionEntry3.bin"
                nombrePlayerAssignment = "\PlayerAssignment3.bin"
                nombreStadium = "\Stadium3.bin"
                NombreCoach = "\Coach3.bin"
                NombreCountry = "\Country3.bin"
                Nombrecompetition = "\Competition3.bin"
                Nombrecompetition_Kind = "\CompetitionKind3.bin"
                NombreTactics = "\Tactics3.bin"
                NombreDerby = "\Derby3.bin"
                NombreStadium_order = "\StadiumOrder3.bin"
                NombreStadium_order_in_conf = "\StadiumOrderInConfederation3.bin"
                NombreBall = "\Ball3.bin"
                NombreBall_condition = "\BallCondition3.bin"
                NombreBoots = "\Boots3.bin"
                NombreGloves = "\Glove3.bin"
                NombreTactics_formation = "\TacticsFormation3.bin"

            ElseIf RadioButton4.Checked = True Then
                nombrePlayer = "\Player4.Bin"
                nombreCompetitionReg = "\CompetitionRegulation4.bin"
                nombreTeam = "\Team4.bin"
                nombreCompetitionEntry = "\CompetitionEntry4.bin"
                nombrePlayerAssignment = "\PlayerAssignment4.bin"
                nombreStadium = "\Stadium4.bin"
                NombreCoach = "\Coach4.bin"
                NombreCountry = "\Country4.bin"
                Nombrecompetition = "\Competition4.bin"
                Nombrecompetition_Kind = "\CompetitionKind4.bin"
                NombreTactics = "\Tactics4.bin"
                NombreDerby = "\Derby4.bin"
                NombreStadium_order = "\StadiumOrder4.bin"
                NombreStadium_order_in_conf = "\StadiumOrderInConfederation4.bin"
                NombreBall = "\Ball4.bin"
                NombreBall_condition = "\BallCondition4.bin"
                NombreBoots = "\Boots4.bin"
                NombreGloves = "\Glove4.bin"
                NombreTactics_formation = "\TacticsFormation4.bin"

            ElseIf RadioButton5.Checked = True Then
                nombrePlayer = "\Player5.Bin"
                nombreCompetitionReg = "\CompetitionRegulation5.bin"
                nombreTeam = "\Team5.bin"
                nombreCompetitionEntry = "\CompetitionEntry5.bin"
                nombrePlayerAssignment = "\PlayerAssignment5.bin"
                nombreStadium = "\Stadium5.bin"
                NombreCoach = "\Coach5.bin"
                NombreCountry = "\Country5.bin"
                Nombrecompetition = "\Competition5.bin"
                Nombrecompetition_Kind = "\CompetitionKind5.bin"
                NombreTactics = "\Tactics5.bin"
                NombreDerby = "\Derby5.bin"
                NombreStadium_order = "\StadiumOrder5.bin"
                NombreStadium_order_in_conf = "\StadiumOrderInConfederation5.bin"
                NombreBall = "\Ball5.bin"
                NombreBall_condition = "\BallCondition5.bin"
                NombreBoots = "\Boots5.bin"
                NombreGloves = "\Glove5.bin"
                NombreTactics_formation = "\TacticsFormation5.bin"

            ElseIf RadioButton6.Checked = True Then
                nombrePlayer = "\Player6.Bin"
                nombreCompetitionReg = "\CompetitionRegulation6.bin"
                nombreTeam = "\Team6.bin"
                nombreCompetitionEntry = "\CompetitionEntry6.bin"
                nombrePlayerAssignment = "\PlayerAssignment6.bin"
                nombreStadium = "\Stadium6.bin"
                NombreCoach = "\Coach6.bin"
                NombreCountry = "\Country6.bin"
                Nombrecompetition = "\Competition6.bin"
                Nombrecompetition_Kind = "\CompetitionKind6.bin"
                NombreTactics = "\Tactics6.bin"
                NombreDerby = "\Derby6.bin"
                NombreStadium_order = "\StadiumOrder6.bin"
                NombreStadium_order_in_conf = "\StadiumOrderInConfederation6.bin"
                NombreBall = "\Ball6.bin"
                NombreBall_condition = "\BallCondition6.bin"
                NombreBoots = "\Boots6.bin"
                NombreGloves = "\Glove6.bin"
                NombreTactics_formation = "\TacticsFormation6.bin"

            Else
                nombrePlayer = "\Player.Bin"
                nombreCompetitionReg = "\CompetitionRegulation.bin"
                nombreTeam = "\Team.bin"
                nombreCompetitionEntry = "\CompetitionEntry.bin"
                nombrePlayerAssignment = "\PlayerAssignment.bin"
                nombreStadium = "\Stadium.bin"
                NombreCoach = "\Coach.bin"
                NombreCountry = "\Country.bin"
                Nombrecompetition = "\Competition.bin"
                Nombrecompetition_Kind = "\CompetitionKind.bin"
                NombreTactics = "\Tactics.bin"
                NombreDerby = "\Derby.bin"
                NombreStadium_order = "\StadiumOrder.bin"
                NombreStadium_order_in_conf = "\StadiumOrderInConfederation.bin"
                NombreBall = "\Ball.bin"
                NombreBall_condition = "\BallCondition.bin"
                NombreBoots = "\Boots.bin"
                NombreGloves = "\Glove.bin"
                NombreTactics_formation = "\TacticsFormation.bin"

            End If


            Try

                Cargando.Show()

                Dim infoplayer As New FileInfo(openfolder.SelectedPath + nombrePlayer)

                If File.Exists(openfolder.SelectedPath + nombrePlayer) = False Then
                    MsgBox("No player file found sorry")
                    Me.Close()
                ElseIf infoplayer.Length = 0 Then
                    MsgBox("player file size 0 sorry")
                    Me.Close()

                End If



                Dim Player_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + nombrePlayer, FileMode.Open, FileAccess.Read)
                Dim CompetitionRegulation_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + nombreCompetitionReg, FileMode.Open, FileAccess.Read)
                Dim Team_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + nombreTeam, FileMode.Open, FileAccess.Read)
                Dim CompetitionEntry_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + nombreCompetitionEntry, FileMode.Open, FileAccess.Read)
                Dim Player_Assignament_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + nombrePlayerAssignment, FileMode.Open, FileAccess.Read)
                Dim Competition_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + Nombrecompetition, FileMode.Open, FileAccess.Read)
                Dim Competition_Kind_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + Nombrecompetition_Kind, FileMode.Open, FileAccess.Read)
                Dim Tactics_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreTactics, FileMode.Open, FileAccess.Read)
                Dim Derby_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreDerby, FileMode.Open, FileAccess.Read)
               
                Dim infoball As New FileInfo(openfolder.SelectedPath + NombreBall)
                Dim infoboots As New FileInfo(openfolder.SelectedPath + NombreBoots)
                Dim infogloves As New FileInfo(openfolder.SelectedPath + NombreGloves)
                Dim infostadium As New FileInfo(openfolder.SelectedPath + nombreStadium)
                Dim infocoach As New FileInfo(openfolder.SelectedPath + NombreCoach)
                




                If File.Exists(openfolder.SelectedPath + NombreBall) = False Then
                    NombreBall = "\Ball.bin"
                    NombreBall_condition = "\BallCondition.bin"
                    MsgBox("Will use Ball.bin and Ball condition cause doesn´t Exists ball on bin Selection!!!")
                    MsgBox("Will use Ball.bin and Ball condition cause doesn´t Exists ball on bin Selection!!!")
                ElseIf infoball.Length = 0 Then
                    NombreBall = "\Ball.bin"
                    NombreBall_condition = "\BallCondition.bin"
                    MsgBox("Will use Ball.bin and Ball condition cause doesn´t Exists ball on bin Selection!!!")
                End If

                If File.Exists(openfolder.SelectedPath + NombreBoots) = False Then
                    NombreBoots = "\Boots.bin"
                    'NombreBall_condition = "\BallCondition.bin"
                    MsgBox("Will use Boots.bin and Ball condition cause doesn´t Exists ball on bin Selection!!!")
                ElseIf infoboots.Length = 0 Then
                    NombreBoots = "\Boots.bin"
                    'NombreBall_condition = "\BallCondition.bin"
                    MsgBox("Will use Boots.bin and Ball condition cause doesn´t Exists ball on bin Selection!!!")

                End If
                If File.Exists(openfolder.SelectedPath + NombreGloves) = False Then
                    NombreGloves = "\Glove.bin"
                    'NombreBall_condition = "\BallCondition.bin"
                    MsgBox("Will use Glove.bin and Ball condition cause doesn´t Exists ball on bin Selection!!!")
                ElseIf infogloves.Length = 0 Then
                    NombreGloves = "\Glove.bin"
                    'NombreBall_condition = "\BallCondition.bin"
                    MsgBox("Will use Glove.bin and Ball condition cause doesn´t Exists ball on bin Selection!!!")

                End If

                Dim Ball_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreBall, FileMode.Open, FileAccess.Read)
                Dim Ball_condition_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreBall_condition, FileMode.Open, FileAccess.Read)
                Dim Boots_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreBoots, FileMode.Open, FileAccess.Read)
                Dim Gloves_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreGloves, FileMode.Open, FileAccess.Read)
                Dim Tactics_formation_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreTactics_formation, FileMode.Open, FileAccess.Read)


                If File.Exists(openfolder.SelectedPath + nombreStadium) = False Then
                    nombreStadium = "\Stadium.bin"
                    NombreStadium_order = "\StadiumOrder.bin"
                    NombreStadium_order_in_conf = "\StadiumOrderInConfederation.bin"
                    MsgBox("Will use Stadium.bin and StadiumOrder.bin cause doesn´t Exists Stadium on bin Selection!!!")
                ElseIf infostadium.Length = 0 Then
                    nombreStadium = "\Stadium.bin"
                    NombreStadium_order = "\StadiumOrder.bin"
                    NombreStadium_order_in_conf = "\StadiumOrderInConfederation.bin"
                    MsgBox("Will use Stadium.bin and StadiumOrder.bin cause doesn´t Exists Stadium on bin Selection!!!")

                End If
                Dim Stadium_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + nombreStadium, FileMode.Open, FileAccess.Read)
                Dim Stadium_order_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreStadium_order, FileMode.Open, FileAccess.Read)
                Dim Stadium_order_in_conf_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreStadium_order_in_conf, FileMode.Open, FileAccess.Read)

                If File.Exists(openfolder.SelectedPath + NombreCoach) = False Then
                    NombreCoach = "\Coach.bin"
                    MsgBox("Will use Coach.bin cause doesn´t Exists coach on bin Selection!!!")
                ElseIf infocoach.Length = 0 Then
                    NombreCoach = "\Coach.bin"
                    MsgBox("Will use Coach.bin cause doesn´t Exists coach on bin Selection!!!")
                End If
                If File.Exists(openfolder.SelectedPath + nombrePlayerApareance) = False Then

                    MsgBox("No PlayerAppearance.bin Found on folder!!!!!!, If you want That file to be auto edited Exit place on same folder than PesDB and start Again")
                Else
                    PLayer_Appareance_present = True

                End If

                If File.Exists(openfolder.SelectedPath + nombreBootList) = False Then

                    MsgBox("No BootList.bin Found on folder!!!!!!, If you want That file to be auto edited Exit place on same folder than PesDB and start Again")
                Else
                    Boot_List_present = True

                End If
                If File.Exists(openfolder.SelectedPath + nombreGloveList) = False Then

                    MsgBox("No GloveList.bin Found on folder!!!!!!, If you want That file to be auto edited Exit place on same folder than PesDB and start Again")
                Else
                    Glove_List_present = True

                End If








                Dim Coach_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreCoach, FileMode.Open, FileAccess.Read)
                Dim Country_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + NombreCountry, FileMode.Open, FileAccess.Read)

                If File.Exists(Application.StartupPath + "\Files\Language.ini") = False Then

                    Dim Crear_Selector_lenguaje_save As New System.IO.StreamWriter(Application.StartupPath + "\Files\Language.ini")
                    Crear_Selector_lenguaje_save.WriteLine(0)
                    Crear_Selector_lenguaje_save.WriteLine(4)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.WriteLine(1)
                    Crear_Selector_lenguaje_save.Close()

                End If

                Dim Selector_lenguaje As New System.IO.StreamReader(Application.StartupPath + "\Files\Language.ini", System.Text.Encoding.Default)
                Try
                    Show_sel = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_1 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_2 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_3 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_4 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_5 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_6 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_7 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_8 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_9 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_10 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_11 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_12 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_13 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_14 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_15 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                    Language_read_16 = Convert.ToInt32(Selector_lenguaje.ReadLine)
                Catch
                    Show_sel = 0

                End Try


                If Show_sel = 0 Then
                    Me.Hide()
                    Language_sel.ShowDialog()
                End If
                Selector_lenguaje.Close()
                Dim Selector_lenguaje_save As New System.IO.StreamWriter(Application.StartupPath + "\Files\Language.ini")

                Selector_lenguaje_save.WriteLine(Show_sel)
                Selector_lenguaje_save.WriteLine(Language)
                Selector_lenguaje_save.WriteLine(Language_read_1)
                Selector_lenguaje_save.WriteLine(Language_read_2)
                Selector_lenguaje_save.WriteLine(Language_read_3)
                Selector_lenguaje_save.WriteLine(Language_read_4)
                Selector_lenguaje_save.WriteLine(Language_read_5)
                Selector_lenguaje_save.WriteLine(Language_read_6)
                Selector_lenguaje_save.WriteLine(Language_read_7)
                Selector_lenguaje_save.WriteLine(Language_read_8)
                Selector_lenguaje_save.WriteLine(Language_read_9)
                Selector_lenguaje_save.WriteLine(Language_read_10)
                Selector_lenguaje_save.WriteLine(Language_read_11)
                Selector_lenguaje_save.WriteLine(Language_read_12)
                Selector_lenguaje_save.WriteLine(Language_read_13)
                Selector_lenguaje_save.WriteLine(Language_read_14)
                Selector_lenguaje_save.WriteLine(Language_read_15)
                Selector_lenguaje_save.WriteLine(Language_read_16)

                Selector_lenguaje_save.Close()


                If (Player_stream IsNot Nothing) And (CompetitionRegulation_stream IsNot Nothing) And (Team_stream IsNot Nothing) And (CompetitionEntry_stream IsNot Nothing) And (Player_Assignament_stream IsNot Nothing) And (Stadium_stream IsNot Nothing) And (Coach_stream IsNot Nothing) And (Country_stream IsNot Nothing) And (Competition_stream IsNot Nothing) And (Competition_Kind_stream IsNot Nothing) And (Tactics_stream IsNot Nothing) And (Derby_stream IsNot Nothing) And (Stadium_order_stream IsNot Nothing) And (Stadium_order_in_conf_stream IsNot Nothing) And (Ball_stream IsNot Nothing) And (Ball_condition_stream IsNot Nothing) And (Boots_stream IsNot Nothing) And (Gloves_stream IsNot Nothing) And (Tactics_formation_stream IsNot Nothing) Then
                    'bloque playerAppareance

                    If PLayer_Appareance_present = True Then
                        PlayerAppareance_Stream = System.IO.File.Open(openfolder.SelectedPath + nombrePlayerApareance, FileMode.Open)
                        PlayerAppareance_MemStream = New MemoryStream
                        PlayerAppareance_Stream.CopyTo(PlayerAppareance_MemStream)
                        Leer_PlayerAppareance = New BinaryReader(PlayerAppareance_MemStream)
                        Grabar_PlayerAppareance = New BinaryWriter(PlayerAppareance_MemStream)
                        PlayerAppareance_Stream.Close()
                    End If




                    'Bloque Player
                    Dim Leer As New BinaryReader(Player_stream)
                    Leer.ReadBytes(Player_stream.Length)
                    Leer.BaseStream.Position = 0
                    Dim Console As UInteger = Leer.ReadSByte
                    Leer.BaseStream.Position = 3
                    Dim CheckPesFile As Integer = Leer.ReadUInt32
                    Tipo_consola = Console

                    Select Case Tipo_consola
                        Case 0,4
                            'MsgBox(" Pc Mode recognized ")
                            Label_mode.Text = "Pc Mode"
                        Case 1
                            ' MsgBox(" Xbox 360 Mode recognized ")
                            Label_mode.Text = "Xbox 360 Mode"
                        Case 2
                            ' MsgBox(" PS3 Mode recognized")
                            Label_mode.Text = "PS3 Mode"
                        Case Else
                            MsgBox(" File type not recognized ")

                    End Select

                    If (CheckPesFile = &H59534557) Then

                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Player = zlib1.unzlibconsole_to_MemStream(Player_stream)
                            Player_stream.Close()
                            Leer.Close()
                            Leer_Player = New BinaryReader(unzlib_Player)
                            Grabar_player = New BinaryWriter(unzlib_Player)
                            'If Console = &H1 Then
                            'Tipo_consola = 1
                            'Else
                            'Tipo_consola = 2
                            'End If
                        Else

                            unzlib_Player = zlib1.unzlibPc_to_Memstream(Player_stream)
                            Player_stream.Close()
                            Leer.Close()
                            Leer_Player = New BinaryReader(unzlib_Player)
                            Grabar_player = New BinaryWriter(unzlib_Player)

                            'Tipo_consola = 0
                        End If

                        Dim bloques As UInteger = unzlib_Player.Length / Player.tamanho_bloque
                        Total_players_box.Text = bloques.ToString
                        Leer_Player.BaseStream.Position = 0
                        Dim Nom_Jugador As String

                        For i = 0 To bloques - 1
                            Leer_Player.BaseStream.Position += 8
                            Dim Player_ID As UInt32 = swaps.swap32(Leer_Player.ReadUInt32())
                            Leer_Player.BaseStream.Position -= 4
                            If Player_id_mayor < Player_ID And Player_ID < 30000 Then
                                Player_id_mayor = Player_ID
                            End If
                            'Dim Nationality As UInteger = Leer_Player.ReadByte

                            Leer_Player.BaseStream.Position += 90
                            Dim Posicion_por_variaciones_nombres As UInteger = Leer_Player.BaseStream.Position
                            Dim Nom_Jugador_shirt As String = Leer_Player.ReadChars(44)
                            Nom_Jugador_shirt = Nom_Jugador_shirt.TrimEnd("")
                            Leer_Player.BaseStream.Position = Posicion_por_variaciones_nombres + 46
                            Nom_Jugador = Leer_Player.ReadChars(44)
                            Nom_Jugador = Nom_Jugador.TrimEnd("")
                            Leer_Player.BaseStream.Position = Posicion_por_variaciones_nombres
                            Leer_Player.BaseStream.Position += 94

                            'DataGridView_player.Rows.Add(Player_ID, Nationality, Nom_Jugador, Nom_Jugador_shirt)
                            'Leer_Player.BaseStream.Position += 90
                            'Nom_Jugador = Leer_Player.ReadChars(46)
                            ListBox1.Items.Add(Nom_Jugador_shirt)
                            'DataGridView_player.Rows(i).Cells(2).Value = Nom_Jugador
                            ' Leer_Player.BaseStream.Position += 48
                        Next



                    Else
                        MsgBox("Not a Xbox player.bin file")

                    End If




                    'Bloque Competiton_regulation
                    Leer = New BinaryReader(CompetitionRegulation_stream)
                    Leer.ReadBytes(CompetitionRegulation_stream.Length)
                    Leer.BaseStream.Position = 0
                    Console = Leer.ReadSByte
                    Leer.BaseStream.Position = 3
                    CheckPesFile = Leer.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("CompetitionRegulation.bin File are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If

                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Competition_regulation = zlib1.unzlibconsole_to_MemStream(CompetitionRegulation_stream)
                            CompetitionRegulation_stream.Close()
                            Leer.Close()
                            Leer_Competition_regulation = New BinaryReader(unzlib_Competition_regulation)
                            Grabar_Competition_regulation = New BinaryWriter(unzlib_Competition_regulation)
                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else

                            unzlib_Competition_regulation = zlib1.unzlibPc_to_Memstream(CompetitionRegulation_stream)
                            CompetitionRegulation_stream.Close()
                            Leer.Close()
                            Leer_Competition_regulation = New BinaryReader(unzlib_Competition_regulation)
                            Grabar_Competition_regulation = New BinaryWriter(unzlib_Competition_regulation)

                            ' Tipo_consola = 0
                        End If





                        Dim bloques As UInteger = unzlib_Competition_regulation.Length / 148
                        'Total_Competitions_box.Text = bloques.ToString
                        Leer_Competition_regulation.BaseStream.Position = 0
                        Dim Nom_Competition As String


                        For i = 0 To bloques - 1
                            Leer_Competition_regulation.BaseStream.Position += 16
                            Nom_Competition = Leer_Competition_regulation.ReadChars(32)
                            Nom_Competition = Nom_Competition.TrimEnd("")
                            ListBox2.Items.Add(Nom_Competition)
                            ListBox_comp_reg.Items.Add(Nom_Competition)
                            Leer_Competition_regulation.BaseStream.Position += 100
                        Next



                    Else
                        MsgBox("Not a Xbox CompetitionRegulation.bin file")

                    End If

                    'Bloque CompetitonEntry
                    Leer = New BinaryReader(CompetitionEntry_stream)
                    Leer.ReadBytes(CompetitionEntry_stream.Length)
                    Leer.BaseStream.Position = 0
                    Console = Leer.ReadSByte
                    Leer.BaseStream.Position = 3
                    CheckPesFile = Leer.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("CompetitionEntry.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_CompetitionEntry = zlib1.unzlibconsole_to_MemStream(CompetitionEntry_stream)
                            CompetitionEntry_stream.Close()
                            Leer.Close()
                            Leer_Competition_Entry = New BinaryReader(unzlib_CompetitionEntry)
                            Grabar_Competition_Entry = New BinaryWriter(unzlib_CompetitionEntry)

                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else

                            unzlib_CompetitionEntry = zlib1.unzlibPc_to_Memstream(CompetitionEntry_stream)
                            CompetitionEntry_stream.Close()
                            Leer.Close()
                            Leer_Competition_Entry = New BinaryReader(unzlib_CompetitionEntry)
                            Grabar_Competition_Entry = New BinaryWriter(unzlib_CompetitionEntry)

                            'Tipo_consola = 0
                        End If

                        Dim bloques As UInteger = unzlib_CompetitionEntry.Length / 12
                        'Total_Competitions_box.Text = bloques.ToString
                        Leer_Competition_Entry.BaseStream.Position = 0

                        Competition_entry_index_mayor = 0
                        For i = 0 To bloques - 1
                            Leer_Competition_Entry.BaseStream.Position += 6
                            Dim Aux As UInt16 = swaps.swap16(Leer_Competition_Entry.ReadUInt16)
                            If Aux > Competition_entry_index_mayor Then
                                Competition_entry_index_mayor = Aux
                            End If
                            Leer_Competition_Entry.BaseStream.Position += 4
                        Next

                    Else
                        MsgBox("Not a Xbox CompetitionEntry.bin file")

                    End If

                    'Bloque Competiton
                    Leer = New BinaryReader(Competition_stream)
                    Leer.ReadBytes(Competition_stream.Length)
                    Leer.BaseStream.Position = 0
                    Console = Leer.ReadSByte
                    Leer.BaseStream.Position = 2
                    Dim CHECK_HALFZLIB As Byte = Leer.ReadByte
                    CheckPesFile = Leer.ReadUInt32



                    If Console <> Tipo_consola Then
                        MsgBox("Competition.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            If CHECK_HALFZLIB <> 0 Then
                                unzlib_Competition = zlib1.unzlibconsole_to_MemStream(Competition_stream)
                            Else
                                Leer.BaseStream.Position = 16
                                Dim buffer As Byte() = Leer.ReadBytes(Competition_stream.Length - 16)
                                unzlib_Competition = New MemoryStream
                                unzlib_Competition.Write(buffer, 0, buffer.Length)
                            End If
                            Competition_stream.Close()
                            Leer.Close()
                            Leer_Competition = New BinaryReader(unzlib_Competition)
                            Grabar_Competition = New BinaryWriter(unzlib_Competition)

                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else
                            If CHECK_HALFZLIB <> 0 Then
                                unzlib_Competition = zlib1.unzlibPc_to_Memstream(Competition_stream)
                            Else
                                Leer.BaseStream.Position = 16
                                Dim buffer As Byte() = Leer.ReadBytes(Competition_stream.Length - 16)
                                unzlib_Competition = New MemoryStream
                                unzlib_Competition.Write(buffer, 0, buffer.Length)

                            End If



                            Competition_stream.Close()
                            Leer.Close()
                            Leer_Competition = New BinaryReader(unzlib_Competition)
                            Grabar_Competition = New BinaryWriter(unzlib_Competition)

                            'Tipo_consola = 0
                        End If
                        Leer_Competition.BaseStream.Position = 4

                        For i = 0 To unzlib_Competition.Length / 32 - 1

                            Dim Start_block As UInt32 = Leer_Competition.BaseStream.Position
                            Dim Name_comp As String = Leer_Competition.ReadChars(28)
                            Name_comp = Name_comp.TrimEnd("")
                            ListBox_competition.Items.Add(Name_comp)
                            Leer_Competition.BaseStream.Position = Start_block + 32

                        Next



                    Else
                        MsgBox("Not a Xbox Competition.bin file")

                    End If



                    'Bloque Competiton_Kind
                    Leer = New BinaryReader(Competition_Kind_stream)
                    Leer.ReadBytes(Competition_Kind_stream.Length)
                    Leer.BaseStream.Position = 0
                    Console = Leer.ReadSByte
                    Leer.BaseStream.Position = 3
                    CheckPesFile = Leer.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("CompetitionKind.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Competition_Kind = zlib1.unzlibconsole_to_MemStream(Competition_Kind_stream)
                            Competition_Kind_stream.Close()
                            Leer.Close()
                            Leer_Competition_Kind = New BinaryReader(unzlib_Competition_Kind)
                            Grabar_Competition_Kind = New BinaryWriter(unzlib_Competition_Kind)

                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else

                            unzlib_Competition_Kind = zlib1.unzlibPc_to_Memstream(Competition_Kind_stream)
                            Competition_Kind_stream.Close()
                            Leer.Close()
                            Leer_Competition_Kind = New BinaryReader(unzlib_Competition_Kind)
                            Grabar_Competition_Kind = New BinaryWriter(unzlib_Competition_Kind)

                            'Tipo_consola = 0
                        End If
                        Leer_Competition_Kind.BaseStream.Position = 65

                        For i = 0 To unzlib_Competition_Kind.Length / 88 - 1

                            Dim Start_block As UInt32 = Leer_Competition_Kind.BaseStream.Position
                            Dim Name_comp As String = Leer_Competition_Kind.ReadChars(23)
                            Name_comp = Name_comp.TrimEnd("")
                            ListBox_comp_Kind.Items.Add(Name_comp)
                            Leer_Competition_Kind.BaseStream.Position = Start_block + 88

                        Next



                    Else
                        MsgBox("Not a Xbox CompetitionKind.bin file")

                    End If





                    'Bloque Team
                    Leer = New BinaryReader(Team_stream)
                    Leer.ReadBytes(Team_stream.Length)
                    Leer.BaseStream.Position = 0
                    Console = Leer.ReadSByte
                    Leer.BaseStream.Position = 3
                    CheckPesFile = Leer.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("Team.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Team = zlib1.unzlibconsole_to_MemStream(Team_stream)
                            Team_stream.Close()
                            Leer.Close()
                            Leer_Team = New BinaryReader(unzlib_Team)
                            Grabar_Team = New BinaryWriter(unzlib_Team)

                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else

                            unzlib_Team = zlib1.unzlibPc_to_Memstream(Team_stream)
                            Team_stream.Close()
                            Leer.Close()
                            Leer_Team = New BinaryReader(unzlib_Team)
                            Grabar_Team = New BinaryWriter(unzlib_Team)
                            'Tipo_consola = 0
                        End If


                        Dim bloques As UInteger = unzlib_Team.Length / Team.tamanho_bloque
                        Total_teams_Box.Text = bloques.ToString
                        Leer_Team.BaseStream.Position = 0
                        'Dim Nom_equipo As String

                        ' For i = 0 To bloques - 1


                        'Leer_Team.BaseStream.Position += 234
                        'Dim Aux_problemas_lenguas_varias As Integer = Leer_Team.BaseStream.Position
                        'Nom_equipo = Leer_Team.ReadChars(70)
                        ' Leer_Team.BaseStream.Position = Aux_problemas_lenguas_varias
                        ' ListBox3.Items.Add(Nom_equipo)
                        ' Leer_Team.BaseStream.Position += 1166
                        ' Next

                        Leer_Team.BaseStream.Position = 0
                        Dim Orden As UInt32 = 0


                        For i = 0 To bloques - 1

                            Dim Equipo_a_mirar As New Team
                            Equipo_a_mirar.Leer_valores(i)

                            DataGridView_TEAM.Rows.Add(Orden, Equipo_a_mirar.Id_32, Equipo_a_mirar.Nombre_equipo_english, Equipo_a_mirar.League, Equipo_a_mirar.Country_16)

                            If Equipo_a_mirar.Id_32 > Id_de_equipo_max Then
                                Id_de_equipo_max = Equipo_a_mirar.Id_32
                            End If
                            If Orden > index_de_equipo_max And Orden < 900 Then
                                index_de_equipo_max = Orden
                            End If

                            Orden += 1
                            ListBox3.Items.Add(Equipo_a_mirar.Nombre_equipo_english)
                        Next

                    Else
                        MsgBox("Not a Xbox Team.bin file")

                    End If



                    'Bloque PlayerAssignament
                    Leer = New BinaryReader(Player_Assignament_stream)
                    Leer.ReadBytes(Player_Assignament_stream.Length)
                    Leer.BaseStream.Position = 0
                    Console = Leer.ReadSByte
                    Leer.BaseStream.Position = 3
                    CheckPesFile = Leer.ReadUInt32
                    If Console <> Tipo_consola Then
                        MsgBox("PlayerAssignment.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Player_Assignament = zlib1.unzlibconsole_to_MemStream(Player_Assignament_stream)
                            Player_Assignament_stream.Close()
                            Leer.Close()
                            Leer_Player_Assignament = New BinaryReader(unzlib_Player_Assignament)
                            Grabar_Player_Assignament = New BinaryWriter(unzlib_Player_Assignament)

                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else

                            unzlib_Player_Assignament = zlib1.unzlibPc_to_Memstream(Player_Assignament_stream)
                            Player_Assignament_stream.Close()
                            Leer.Close()
                            Leer_Player_Assignament = New BinaryReader(unzlib_Player_Assignament)
                            Grabar_Player_Assignament = New BinaryWriter(unzlib_Player_Assignament)

                            'Tipo_consola = 0
                        End If


                        Dim bloques_playerAssignament As UInteger = unzlib_Player_Assignament.Length / 16
                        'Total_Competitions_box.Text = bloques.ToString
                        Leer_Player_Assignament.BaseStream.Position = 0

                        For i = 0 To bloques_playerAssignament - 1
                            Dim temp_index As UInt32 = swaps.swap32(Leer_Player_Assignament.ReadUInt32)
                            If temp_index >= PlayerAssignment_index_mayor Then
                                PlayerAssignment_index_mayor = temp_index + 1
                            End If
                            Leer_Player_Assignament.BaseStream.Position += 12
                        Next


                    Else
                        MsgBox("Not a Xbox PlayerAssignment.bin file")

                    End If






                    'Bloque Countries
                    Leer_Country = New BinaryReader(Country_stream)
                    Leer_Country.ReadBytes(Country_stream.Length)
                    Leer_Country.BaseStream.Position = 0
                    Console = Leer_Country.ReadSByte
                    Leer_Country.BaseStream.Position = 3
                    CheckPesFile = Leer_Country.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("Country.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Country = zlib1.unzlibconsole_to_MemStream(Country_stream)
                            Country_stream.Close()
                            Leer_Country.Close()
                            Leer_Country = New BinaryReader(unzlib_Country)
                            Grabar_Country = New BinaryWriter(unzlib_Country)

                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else

                            unzlib_Country = zlib1.unzlibPc_to_Memstream(Country_stream)
                            Country_stream.Close()
                            Leer_Country.Close()
                            Leer_Country = New BinaryReader(unzlib_Country)
                            Grabar_Country = New BinaryWriter(unzlib_Country)
                            'Tipo_consola = 0
                        End If


                        Dim bloques_coun As UInt32 = unzlib_Country.Length / 1348
                        Leer_Country.BaseStream.Position = 0



                        For i = 0 To bloques_coun - 1
                            Dim Country_a_Leer As New Country
                            Country_a_Leer.Leer_Valores(i)
                            DataGridView_Countries.Rows.Add(Country_a_Leer.Country_ID, Country_a_Leer.Nom_Country, Country_a_Leer.Nom_Country_short)
                        Next


                    Else
                        MsgBox("Not a Xbox Country.bin file")

                    End If

                    'Bloque Stadium
                    Leer_Stadium = New BinaryReader(Stadium_stream)
                    Leer_Stadium.ReadBytes(Stadium_stream.Length)
                    Leer_Stadium.BaseStream.Position = 0
                    Console = Leer_Stadium.ReadSByte
                    Leer_Stadium.BaseStream.Position = 3
                    CheckPesFile = Leer_Stadium.ReadUInt32

                    If Console <> Tipo_consola And Tipo_consola <> 4 Then
                        MsgBox("Stadium.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Stadium = zlib1.unzlibconsole_to_MemStream(Stadium_stream)
                            Stadium_stream.Close()
                            Leer_Stadium.Close()
                            Leer_Stadium = New BinaryReader(unzlib_Stadium)
                            Grabar_Stadium = New BinaryWriter(unzlib_Stadium)

                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else

                            unzlib_Stadium = zlib1.unzlibPc_to_Memstream(Stadium_stream)
                            Stadium_stream.Close()
                            Leer_Stadium.Close()
                            Leer_Stadium = New BinaryReader(unzlib_Stadium)
                            Grabar_Stadium = New BinaryWriter(unzlib_Stadium)
                            'Tipo_consola = 0
                        End If


                        Dim bloques As UInteger = unzlib_Stadium.Length / Stadium.tamanho_bloque
                        Total_stadium_box.Text = bloques.ToString
                        Leer_Stadium.BaseStream.Position = 0





                        For i = 0 To bloques - 1
                            Dim stadium_to_read As New Stadium
                            stadium_to_read.Leer_Valores(i)
                            DataGridView_Stadium.Rows.Add(stadium_to_read.Id, stadium_to_read.Nom_Stadium, stadium_to_read.negro, stadium_to_read.Licensed, stadium_to_read.Country, stadium_to_read.Nom_country, stadium_to_read.zone, stadium_to_read.Capacidad, stadium_to_read.Nom_Jap, stadium_to_read.NOM_PROGRAMATIC)

                        Next
                    Else
                        MsgBox("Not a Xbox Stadium.bin file")

                    End If

                    'Bloque StadiumOrder
                    Leer_Stadium_order = New BinaryReader(Stadium_order_stream)
                    Leer_Stadium_order.ReadBytes(Stadium_order_stream.Length)
                    Leer_Stadium_order.BaseStream.Position = 0
                    Console = Leer_Stadium_order.ReadSByte
                    Leer_Stadium_order.BaseStream.Position = 3
                    CheckPesFile = Leer_Stadium_order.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("StadiumOrder.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Stadium_order = zlib1.unzlibconsole_to_MemStream(Stadium_order_stream)
                            Stadium_order_stream.Close()
                            Leer_Stadium_order.Close()
                            Leer_Stadium_order = New BinaryReader(unzlib_Stadium_order)
                            Grabar_Stadium_order = New BinaryWriter(unzlib_Stadium_order)

                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else

                            unzlib_Stadium_order = zlib1.unzlibPc_to_Memstream(Stadium_order_stream)
                            Stadium_order_stream.Close()
                            Leer_Stadium_order.Close()
                            Leer_Stadium_order = New BinaryReader(unzlib_Stadium_order)
                            Grabar_Stadium_order = New BinaryWriter(unzlib_Stadium_order)
                            'Tipo_consola = 0
                        End If



                        Dim bloques As UInt32 = unzlib_Stadium_order.Length / 8

                        Leer_Stadium_order.BaseStream.Position = 0





                        For i = 0 To bloques - 1
                            Dim stadium_to_read As New Stadium
                            stadium_to_read.Leer_Valores_order(i)
                            Dim Nombre As String = ""
                            For j = 0 To DataGridView_Stadium.Rows.Count - 1
                                If DataGridView_Stadium.Rows(j).Cells(0).Value = stadium_to_read.order_id Then
                                    Nombre = DataGridView_Stadium.Rows(j).Cells(1).Value
                                End If
                            Next
                            DataGridView_stadium_order.Rows.Add(Nombre, stadium_to_read.order_index, stadium_to_read.order_id, stadium_to_read.negro7, stadium_to_read.rojo2, stadium_to_read.verde7)
                        Next

                    Else
                        MsgBox("Not a Xbox StadiumOrder.bin file")

                    End If

                    'Bloque StadiumOrder_inConf
                    Leer_Stadium_order_in_conf = New BinaryReader(Stadium_order_in_conf_stream)
                    Leer_Stadium_order_in_conf.ReadBytes(Stadium_order_in_conf_stream.Length)
                    Leer_Stadium_order_in_conf.BaseStream.Position = 0
                    Console = Leer_Stadium_order_in_conf.ReadSByte
                    Leer_Stadium_order_in_conf.BaseStream.Position = 3
                    CheckPesFile = Leer_Stadium_order_in_conf.ReadUInt32

                    If Console <> Tipo_consola And Tipo_consola <> 4 Then
                        MsgBox("StadiumOrderInConfederation.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Stadium_order_in_conf = zlib1.unzlibconsole_to_MemStream(Stadium_order_in_conf_stream)
                            Stadium_order_in_conf_stream.Close()
                            Leer_Stadium_order_in_conf.Close()
                            Leer_Stadium_order_in_conf = New BinaryReader(unzlib_Stadium_order_in_conf)
                            Grabar_Stadium_order_in_conf = New BinaryWriter(unzlib_Stadium_order_in_conf)

                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else

                            unzlib_Stadium_order_in_conf = zlib1.unzlibPc_to_Memstream(Stadium_order_in_conf_stream)
                            Stadium_order_in_conf_stream.Close()
                            Leer_Stadium_order_in_conf.Close()
                            Leer_Stadium_order_in_conf = New BinaryReader(unzlib_Stadium_order_in_conf)
                            Grabar_Stadium_order_in_conf = New BinaryWriter(unzlib_Stadium_order_in_conf)
                            'Tipo_consola = 0
                        End If



                        Dim bloques As UInt32 = unzlib_Stadium_order_in_conf.Length / 8

                        Leer_Stadium_order_in_conf.BaseStream.Position = 0





                        For i = 0 To bloques - 1
                            Dim stadium_to_read As New Stadium
                            stadium_to_read.Leer_Valores_order_in_conf(i)
                            Dim Nombre As String = ""
                            For j = 0 To DataGridView_Stadium.Rows.Count - 1
                                If DataGridView_Stadium.Rows(j).Cells(0).Value = stadium_to_read.order_id_in_conf Then
                                    Nombre = DataGridView_Stadium.Rows(j).Cells(1).Value
                                End If
                            Next

                            DataGridView_stadium_order_in_conf.Rows.Add(Nombre, stadium_to_read.order_index_in_conf, stadium_to_read.order_id_in_conf, stadium_to_read.byte_in_conf)
                        Next

                    Else
                        MsgBox("Not a Xbox StadiumOrderInConfederation.bin file")

                    End If



                    'Bloque Coach
                    Leer_Coach = New BinaryReader(Coach_stream)
                    Leer_Coach.ReadBytes(Coach_stream.Length)
                    Leer_Coach.BaseStream.Position = 0
                    Console = Leer_Coach.ReadSByte
                    Leer_Coach.BaseStream.Position = 3
                    CheckPesFile = Leer_Coach.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("Coach.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Coach = zlib1.unzlibconsole_to_MemStream(Coach_stream)
                            Coach_stream.Close()
                            Leer_Coach.Close()
                            Leer_Coach = New BinaryReader(unzlib_Coach)
                            Grabar_Coach = New BinaryWriter(unzlib_Coach)

                            'If Console = &H1 Then
                            '    Tipo_consola = 1
                            'Else
                            '    Tipo_consola = 2
                            'End If
                        Else

                            unzlib_Coach = zlib1.unzlibPc_to_Memstream(Coach_stream)
                            Coach_stream.Close()
                            Leer_Coach.Close()
                            Leer_Coach = New BinaryReader(unzlib_Coach)
                            Grabar_Coach = New BinaryWriter(unzlib_Coach)
                            ' Tipo_consola = 0
                        End If


                        Dim bloques As UInt32 = unzlib_Coach.Length / Coach.tamanho_bloque
                        Leer_Coach.BaseStream.Position = 0



                        For i = 0 To bloques - 1

                            Dim Coach_Id As UInt32 = swaps.swap32(Leer_Coach.ReadUInt32)


                            Leer_Coach.BaseStream.Position += 58

                            Dim Aux_problemas_lenguas_varias As Integer = Leer_Coach.BaseStream.Position
                            Dim Nom_Coach As String = Leer_Coach.ReadChars(40)
                            Nom_Coach = Nom_Coach.TrimEnd("")
                            Leer_Coach.BaseStream.Position = Aux_problemas_lenguas_varias
                            Leer_Coach.BaseStream.Position += 46


                            'Buscar Equipo

                            Dim bloques_equipos As UInteger = unzlib_Team.Length / Team.tamanho_bloque
                            Dim nombre_a_añadir As String = ""
                            Dim Team_id_a_añadir As UInteger

                            Leer_Team.BaseStream.Position = 0

                            For j = 0 To bloques_equipos - 1
                                Dim equipo1 As New Team

                                equipo1.Leer_valores(j)
                                If Coach_Id = equipo1.Coach Then
                                    nombre_a_añadir = equipo1.Nombre_equipo_english
                                    Team_id_a_añadir = equipo1.Id_32
                                End If



                            Next


                            DataGridView_coach.Rows.Add(Coach_Id, Nom_Coach, nombre_a_añadir, Team_id_a_añadir)



                        Next




                    Else
                        MsgBox("Not a Xbox Coach.bin file")

                    End If

                    'Bloque Tactics
                    Leer_Tactics = New BinaryReader(Tactics_stream)
                    Leer_Tactics.ReadBytes(Tactics_stream.Length)
                    Leer_Tactics.BaseStream.Position = 0
                    Console = Leer_Tactics.ReadSByte
                    Leer_Tactics.BaseStream.Position = 3
                    CheckPesFile = Leer_Tactics.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("Tactics.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Tactics = zlib1.unzlibconsole_to_MemStream(Tactics_stream)
                            Tactics_stream.Close()
                            Leer_Tactics.Close()
                            Leer_Tactics = New BinaryReader(unzlib_Tactics)
                            Grabar_Tactics = New BinaryWriter(unzlib_Tactics)

                          
                        Else

                            unzlib_Tactics = zlib1.unzlibPc_to_Memstream(Tactics_stream)
                            Tactics_stream.Close()
                            Leer_Tactics.Close()
                            Leer_Tactics = New BinaryReader(unzlib_Tactics)
                            Grabar_Tactics = New BinaryWriter(unzlib_Tactics)
                            'Tipo_consola = 0
                        End If


                        Dim bloques As UInt32 = unzlib_Tactics.Length / 12
                        Leer_Tactics.BaseStream.Position = 0


                    Else
                        MsgBox("Not a Xbox Tactics.bin file")

                    End If
                    'Bloque Derby
                    Leer_Derby = New BinaryReader(Derby_stream)
                    Leer_Derby.ReadBytes(Derby_stream.Length)
                    Leer_Derby.BaseStream.Position = 0
                    Console = Leer_Derby.ReadSByte
                    Leer_Derby.BaseStream.Position = 3
                    CheckPesFile = Leer_Derby.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("Derby.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Derby = zlib1.unzlibconsole_to_MemStream(Derby_stream)
                            Derby_stream.Close()
                            Leer_Derby.Close()
                            Leer_Derby = New BinaryReader(unzlib_Derby)
                            Grabar_Derby = New BinaryWriter(unzlib_Derby)

                        Else

                            unzlib_Derby = zlib1.unzlibPc_to_Memstream(Derby_stream)
                            Derby_stream.Close()
                            Leer_Derby.Close()
                            Leer_Derby = New BinaryReader(unzlib_Derby)
                            Grabar_Derby = New BinaryWriter(unzlib_Derby)

                        End If


                        Dim bloques As UInt32 = unzlib_Derby.Length / 12
                        Leer_Derby.BaseStream.Position = 0



                        For i = 0 To bloques - 1

                            Dim Derby_to_read As New Derby
                            Derby_to_read.Leer_Valores(i)

                            'Buscar Equipo

                            Dim bloques_equipos As UInteger = unzlib_Team.Length / Team.tamanho_bloque
                            Dim nombre_a_añadir1 As String = ""
                            Dim nombre_a_añadir2 As String = ""
                            Dim Team_id_a_añadir1 As UInteger = 0
                            Dim Team_id_a_añadir2 As UInteger = 0

                            Leer_Team.BaseStream.Position = 0

                            For j = 0 To bloques_equipos - 1
                                Dim equipo1 As New Team

                                equipo1.Leer_valores(j)


                                If Derby_to_read.Team1_Derby_id = equipo1.Id_32 Then
                                    nombre_a_añadir1 = equipo1.Nombre_equipo_english
                                    Team_id_a_añadir1 = equipo1.Id_32

                                ElseIf Derby_to_read.Team2_Derby_id = equipo1.Id_32 Then
                                    nombre_a_añadir2 = equipo1.Nombre_equipo_english
                                    Team_id_a_añadir2 = equipo1.Id_32

                                End If



                            Next


                            DataGridView_derby.Rows.Add(Derby_to_read.Team1_Derby_id, nombre_a_añadir1, Derby_to_read.Team2_Derby_id, nombre_a_añadir2, Derby_to_read.Frag_val1, Derby_to_read.Frag_val2, Derby_to_read.Frag_val3, Derby_to_read.Frag_val4)



                        Next



                    Else
                        MsgBox("Not a Xbox Derby.bin file")

                    End If

                    'Bloque Ball
                    Leer_Ball = New BinaryReader(Ball_stream)
                    Leer_Ball.ReadBytes(Ball_stream.Length)
                    Leer_Ball.BaseStream.Position = 0
                    Console = Leer_Ball.ReadSByte
                    Leer_Ball.BaseStream.Position = 3
                    CheckPesFile = Leer_Ball.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("Ball.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Ball = zlib1.unzlibconsole_to_MemStream(Ball_stream)
                            Ball_stream.Close()
                            Leer_Ball.Close()
                            Leer_Ball = New BinaryReader(unzlib_Ball)
                            Grabar_Ball = New BinaryWriter(unzlib_Ball)

                        Else

                            unzlib_Ball = zlib1.unzlibPc_to_Memstream(Ball_stream)
                            Ball_stream.Close()
                            Leer_Ball.Close()
                            Leer_Ball = New BinaryReader(unzlib_Ball)
                            Grabar_Ball = New BinaryWriter(unzlib_Ball)

                        End If


                        Dim bloques As UInteger = unzlib_Ball.Length / Ball.tamanho_bloque

                        Leer_Ball.BaseStream.Position = 0





                        For i = 0 To bloques - 1
                            Dim ball_to_read As New Ball
                            ball_to_read.Leer_Valores(i)
                            DataGridView_ball.Rows.Add(ball_to_read.Nom_ball, ball_to_read.Id, ball_to_read.Order)

                        Next
                    Else
                        MsgBox("Not a Xbox Ball.bin file")

                    End If


                    'Bloque Ball Condition
                    Leer_Ball_condition = New BinaryReader(Ball_condition_stream)
                    Leer_Ball_condition.ReadBytes(Ball_condition_stream.Length)
                    Leer_Ball_condition.BaseStream.Position = 0
                    Console = Leer_Ball_condition.ReadSByte
                    Leer_Ball_condition.BaseStream.Position = 3
                    CheckPesFile = Leer_Ball_condition.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("BallCondition.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Ball_condition = zlib1.unzlibconsole_to_MemStream(Ball_condition_stream)
                            Ball_condition_stream.Close()
                            Leer_Ball_condition.Close()
                            Leer_Ball_condition = New BinaryReader(unzlib_Ball_condition)
                            Grabar_Ball_condition = New BinaryWriter(unzlib_Ball_condition)

                        Else

                            unzlib_Ball_condition = zlib1.unzlibPc_to_Memstream(Ball_condition_stream)
                            Ball_condition_stream.Close()
                            Leer_Ball_condition.Close()
                            Leer_Ball_condition = New BinaryReader(unzlib_Ball_condition)
                            Grabar_Ball_condition = New BinaryWriter(unzlib_Ball_condition)

                        End If


                        Dim bloques As UInteger = unzlib_Ball_condition.Length / 8
                        Leer_Ball_condition.BaseStream.Position = 0





                        For i = 0 To bloques - 1
                            Dim Ball_condition_to_read As New Ball
                            Ball_condition_to_read.Leer_Valores_condition(i)
                            Dim Nombre As String = ""
                            For j = 0 To DataGridView_ball.Rows.Count - 1
                                If DataGridView_ball.Rows(j).Cells(1).Value = Ball_condition_to_read.Id_condition Then
                                    Nombre = DataGridView_ball.Rows(j).Cells(0).Value
                                End If
                            Next
                            DataGridView_ball_condition.Rows.Add(Nombre, Ball_condition_to_read.Id_condition, Ball_condition_to_read.order_condition, Ball_condition_to_read.byte_condition)

                        Next
                    Else
                        MsgBox("Not a Xbox Ball_condition.bin file")

                    End If

                    'Bloque Boots
                    Leer_Boots = New BinaryReader(Boots_stream)
                    Leer_Boots.ReadBytes(Boots_stream.Length)
                    Leer_Boots.BaseStream.Position = 0
                    Console = Leer_Boots.ReadSByte
                    Leer_Boots.BaseStream.Position = 3
                    CheckPesFile = Leer_Boots.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("Boots.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Boots = zlib1.unzlibconsole_to_MemStream(Boots_stream)
                            Boots_stream.Close()
                            Leer_Boots.Close()
                            Leer_Boots = New BinaryReader(unzlib_Boots)
                            Grabar_Boots = New BinaryWriter(unzlib_Boots)

                        Else

                            unzlib_Boots = zlib1.unzlibPc_to_Memstream(Boots_stream)
                            Boots_stream.Close()
                            Leer_Boots.Close()
                            Leer_Boots = New BinaryReader(unzlib_Boots)
                            Grabar_Boots = New BinaryWriter(unzlib_Boots)

                        End If


                        Dim bloques As UInteger = unzlib_Boots.Length / Boots.tamanho_bloque
                        Leer_Boots.BaseStream.Position = 0





                        For i = 0 To bloques - 1
                            Dim Boots_to_read As New Boots
                            Boots_to_read.Leer_Valores(i)

                            DataGridView_boots.Rows.Add(Boots_to_read.Id, Boots_to_read.Order, Boots_to_read.Color, Boots_to_read.Material, Boots_to_read.Nom_boot)

                        Next
                    Else
                        MsgBox("Not a Xbox Boots.bin file")

                    End If

                    'Bloque Gloves
                    Leer_Gloves = New BinaryReader(Gloves_stream)
                    Leer_Gloves.ReadBytes(Gloves_stream.Length)
                    Leer_Gloves.BaseStream.Position = 0
                    Console = Leer_Gloves.ReadSByte
                    Leer_Gloves.BaseStream.Position = 3
                    CheckPesFile = Leer_Gloves.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("Gloves.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If


                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Gloves = zlib1.unzlibconsole_to_MemStream(Gloves_stream)
                            Gloves_stream.Close()
                            Leer_Gloves.Close()
                            Leer_Gloves = New BinaryReader(unzlib_Gloves)
                            Grabar_Gloves = New BinaryWriter(unzlib_Gloves)

                        Else

                            unzlib_Gloves = zlib1.unzlibPc_to_Memstream(Gloves_stream)
                            Gloves_stream.Close()
                            Leer_Gloves.Close()
                            Leer_Gloves = New BinaryReader(unzlib_Gloves)
                            Grabar_Gloves = New BinaryWriter(unzlib_Gloves)

                        End If


                        Dim bloques As UInteger = unzlib_Gloves.Length / Gloves.tamanho_bloque
                        Leer_Gloves.BaseStream.Position = 0





                        For i = 0 To bloques - 1
                            Dim Gloves_to_read As New Gloves
                            Gloves_to_read.Leer_Valores(i)

                            DataGridView_gloves.Rows.Add(Gloves_to_read.Id, Gloves_to_read.Order, Gloves_to_read.Color, Gloves_to_read.Nom_Gloves)

                        Next
                    Else
                        MsgBox("Not a Xbox Gloves.bin file")

                    End If

                    If Boot_List_present = True Then
                        'Bloque BootList
                        Dim Boot_list_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + nombreBootList, FileMode.Open, FileAccess.Read)
                        Leer = New BinaryReader(Boot_list_stream)
                        Leer.ReadBytes(Boot_list_stream.Length)
                        Leer.BaseStream.Position = 0
                        Console = Leer.ReadSByte
                        Leer.BaseStream.Position = 3
                        CheckPesFile = Leer.ReadUInt32

                        If Console <> Tipo_consola Then
                            MsgBox("BootList.bin are not from same platform, use only Xbox files, or pc files.")
                            Me.Close()

                        End If

                        If (CheckPesFile = &H59534557) Then


                            If Console = &H1 Or Console = &H2 Then
                                unzlib_Boots_list = zlib1.unzlibconsole_to_MemStream(Boot_list_stream)
                                Boot_list_stream.Close()
                                Leer.Close()
                                Leer_Boots_list = New BinaryReader(unzlib_Boots_list)
                                Grabar_Boots_list = New BinaryWriter(unzlib_Boots_list)
                               
                            Else

                                unzlib_Boots_list = zlib1.unzlibPc_to_Memstream(Boot_list_stream)
                                Boot_list_stream.Close()
                                Leer.Close()
                                Leer_Boots_list = New BinaryReader(unzlib_Boots_list)
                                Grabar_Boots_list = New BinaryWriter(unzlib_Boots_list)

                            End If


                        Else
                            MsgBox("Not a Xbox BootList.bin file")

                        End If


                    End If

                    If Glove_List_present = True Then
                        'Bloque BootList
                        Dim Gloves_list_stream As FileStream = System.IO.File.Open(openfolder.SelectedPath + nombreGloveList, FileMode.Open, FileAccess.Read)
                        Leer = New BinaryReader(Gloves_list_stream)
                        Leer.ReadBytes(Gloves_list_stream.Length)
                        Leer.BaseStream.Position = 0
                        Console = Leer.ReadSByte
                        Leer.BaseStream.Position = 3
                        CheckPesFile = Leer.ReadUInt32

                        If Console <> Tipo_consola Then
                            MsgBox("GloveList.bin are not from same platform, use only Xbox files, or pc files.")
                            Me.Close()

                        End If

                        If (CheckPesFile = &H59534557) Then


                            If Console = &H1 Or Console = &H2 Then
                                unzlib_Gloves_list = zlib1.unzlibconsole_to_MemStream(Gloves_list_stream)
                                Gloves_list_stream.Close()
                                Leer.Close()
                                Leer_Gloves_list = New BinaryReader(unzlib_Gloves_list)
                                Grabar_Gloves_list = New BinaryWriter(unzlib_Gloves_list)
                              
                            Else

                                unzlib_Gloves_list = zlib1.unzlibPc_to_Memstream(Gloves_list_stream)
                                Gloves_list_stream.Close()
                                Leer.Close()
                                Leer_Gloves_list = New BinaryReader(unzlib_Gloves_list)
                                Grabar_Gloves_list = New BinaryWriter(unzlib_Gloves_list)

                            End If


                        Else
                            MsgBox("Not a Xbox GloveList.bin file")

                        End If


                    End If



                    'Bloque TacticsFormation
                    Leer = New BinaryReader(Tactics_formation_stream)
                    Leer.ReadBytes(Tactics_formation_stream.Length)
                    Leer.BaseStream.Position = 0
                    Console = Leer.ReadSByte
                    Leer.BaseStream.Position = 3
                    CheckPesFile = Leer.ReadUInt32

                    If Console <> Tipo_consola Then
                        MsgBox("GloveList.bin are not from same platform, use only Xbox files, or pc files.")
                        Me.Close()

                    End If

                    If (CheckPesFile = &H59534557) Then


                        If Console = &H1 Or Console = &H2 Then
                            unzlib_Tactics_formation = zlib1.unzlibconsole_to_MemStream(Tactics_formation_stream)
                            Tactics_formation_stream.Close()
                            Leer.Close()
                            Leer_Tactics_formation = New BinaryReader(unzlib_Tactics_formation)
                            Grabar_Tactics_formation = New BinaryWriter(unzlib_Tactics_formation)
                          
                        Else

                            unzlib_Tactics_formation = zlib1.unzlibPc_to_Memstream(Tactics_formation_stream)
                            Tactics_formation_stream.Close()
                            Leer.Close()
                            Leer_Tactics_formation = New BinaryReader(unzlib_Tactics_formation)
                            Grabar_Tactics_formation = New BinaryWriter(unzlib_Tactics_formation)

                        End If


                    Else
                        MsgBox("Not a Xbox GloveList.bin file")

                    End If

                    'bloque exportar todas las playerId. 



                    'este end if no es del ultimo bloque
                End If


                Campo.Controls.Clear()
                Button1.Hide()
                Cargando.Hide()
                Button43.Hide()

            Catch ex As Exception
                MsgBox(ex.ToString)
                MsgBox("All files in PesDb folder must be present!!!!! Or Files are the same, close and try again." + vbCr + "Needed files from dt10.cpk and if there is a dlc replace old ones with the dlc ones" + vbCr + "-Player.bin" + vbCr + "-PlayerAssignment.bin" + vbCr + "-Team.bin" + vbCr + "-CompetitionRegulation.bin" + vbCr + "-CompetitionEntry.bin" + vbCr + "-Coach.bin" + vbCr + "-country.bin" + vbCr + "-Stadium.bin" + vbCr + "-Competition.bin" + vbCr + "-CompetitionKind.bin" + vbCr + "-Tactics.bin" + vbCr + "-Derby.bin" + vbCr + "-StadiumOrder.bin" + vbCr + "-StadiumOrderInConfederation.bin" + vbCr + "-Ball.bin" + vbCr + "-BallCondition.bin" + vbCr + "-Boots.bin" + vbCr + "-Glove.bin" + vbCr + "-TacticsFormation.bin")
                Me.Close()

                Cargando.Hide()

            End Try


        Else
                MsgBox("No Folder Selected!!")

        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex <> -1 Then

            Skin_box.Value = 0
            PictureBoxSkin_col.Image = Nothing
            NumericPLAYERASS_INDEX_2.Value = 0
            NumericTEAMID_2.Value = 0
            NumericDorsal_2.Value = 0
            TextBox_team_name_2.Clear()

            PlAssigIndex_to_delete.Value = 0
            PlAssigIndex_to_delete_2.Value = 0
            Valor_nuevo32_box.Value = 0
           

            ORDER_IN_TEAM_BOX_2.Value = 0
            CheckBox48.Checked = False
            CheckBox49.Checked = False
            CheckBox50.Checked = False
            CheckBox51.Checked = False
            CheckBox52.Checked = False
            CheckBox53.Checked = False
            CheckBox89.Checked = False
            CheckBox88.Checked = False
            CheckBox87.Checked = False
            CheckBox86.Checked = False
            CheckBox46.Checked = False
            CheckBox47.Checked = False
            CheckBox82.Checked = False
            CheckBox83.Checked = False
            CheckBox84.Checked = False
            CheckBox85.Checked = False
            


            ID_cambiada = False

            Dim Player_a_buscar As New Player
            Player_a_buscar.Leer_valores(ListBox1.SelectedIndex)
            Player_a_buscar.leer_player_assig()
            Player_a_buscar.Leer_botas()
            Player_a_buscar.Leer_guantes()
            Player_a_buscar.Leer_Playerappareance()




        End If

   End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        unzlib_Player.Position = unzlib_Player.Length
        Dim Player_fake_array As Byte() = My.Resources.Player_fake()
        Dim Player_fake_array_xb As Byte() = My.Resources.Player_fake_xb()
        Dim number_of_players As Integer = NumericUpDown1.Value

        For i = 0 To number_of_players - 1
            Player_id_mayor += 1
            Dim cero32 As UInt32 = 0

            Grabar_player.Write(cero32)
            Grabar_player.Write(cero32)

            Grabar_player.Write(swaps.swap32(Player_id_mayor))
            If Tipo_consola = 0 Or Tipo_consola = 4 Then
                unzlib_Player.Write(Player_fake_array, 0, Player_fake_array.Length)
            Else
                unzlib_Player.Write(Player_fake_array_xb, 0, Player_fake_array.Length)
            End If

            ListBox1.Items.Add("SMEAGOL75")


            'para poner botas aleatorias al crear player, y appareance aleatoria


            If Boot_List_present = True Then
                Dim Boots_aleatorias As New Random
                Dim botas_aleatorias As UInt32 = Boots_aleatorias.Next(0, DataGridView_boots.Rows.Count)
                Dim end_of_file As Byte()
                Leer_Boots_list.BaseStream.Position = 0
                Dim boots_to_add As UInt16 = Convert.ToUInt16(DataGridView_boots.Rows(botas_aleatorias).Cells(0).Value)
                Dim Zero_16 As UInt16 = 0
                For j = 0 To unzlib_Boots_list.Length / 8
                    Dim Check_order As UInt32 = swaps.swap32(Leer_Boots_list.ReadUInt32)
                    If Check_order < Player_id_mayor Then
                        Leer_Boots_list.BaseStream.Position += 4

                    ElseIf j = unzlib_Boots_list.Length / 8 - 1 Then

                        Leer_Boots_list.BaseStream.Position = unzlib_Boots_list.Length
                        Grabar_Boots_list.Write(swaps.swap32(Player_id_mayor))

                        Grabar_Boots_list.Write(swaps.swap16(boots_to_add))
                        Grabar_Boots_list.Write(swaps.swap16(Zero_16))
                        Exit For
                    Else
                        If Check_order = Player_id_mayor Then

                            Grabar_Boots_list.Write(swaps.swap16(boots_to_add))
                            Grabar_Boots_list.Write(swaps.swap16(Zero_16))
                            Exit For
                        Else
                            'leer hasta el final
                            Leer_Boots_list.BaseStream.Position -= 4
                            Dim Posicion_a_grabar As ULong = Leer_Boots_list.BaseStream.Position
                            Dim Tamanho_a_leer As ULong = unzlib_Boots_list.Length - Leer_Boots_list.BaseStream.Position
                            end_of_file = Leer_Boots_list.ReadBytes(Tamanho_a_leer)
                            Leer_Boots_list.BaseStream.Position = Posicion_a_grabar
                            Grabar_Boots_list.Write(swaps.swap32(Player_id_mayor))

                            Grabar_Boots_list.Write(swaps.swap16(boots_to_add))
                            Grabar_Boots_list.Write(swaps.swap16(Zero_16))
                            Grabar_Boots_list.Write(end_of_file)
                            Exit For

                        End If

                    End If
                Next


            End If

            If PLayer_Appareance_present = True Then
                Dim Player_Player_appareance_block As Byte()

                Dim numAleatorio As New Random()
                Dim valorAleatorio As Integer = numAleatorio.Next(0, 1000)
                Leer_PlayerAppareance.BaseStream.Position = (valorAleatorio * 60) + 4
                Player_Player_appareance_block = Leer_PlayerAppareance.ReadBytes(56)
                Dim end_of_file As Byte()
                Leer_PlayerAppareance.BaseStream.Position = 0

                For j = 0 To PlayerAppareance_MemStream.Length / 60
                    Dim Check_order As UInt32 = swaps.swap32(Leer_PlayerAppareance.ReadUInt32)
                    If Check_order < Player_id_mayor Then
                        Leer_PlayerAppareance.BaseStream.Position += 56

                    ElseIf j = PlayerAppareance_MemStream.Length / 60 - 1 Then
                        Leer_PlayerAppareance.BaseStream.Position = PlayerAppareance_MemStream.Length
                        Grabar_PlayerAppareance.Write(swaps.swap32(Player_id_mayor))
                        Grabar_PlayerAppareance.Write(Player_Player_appareance_block)

                        Exit For
                    Else
                        If Check_order = Player_id_mayor Then
                            Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
                            Exit For
                        Else
                            'leer hasta el final
                            Leer_PlayerAppareance.BaseStream.Position -= 4
                            Dim Posicion_a_grabar As ULong = Leer_PlayerAppareance.BaseStream.Position
                            Dim Tamanho_a_leer As ULong = PlayerAppareance_MemStream.Length - Leer_PlayerAppareance.BaseStream.Position
                            end_of_file = Leer_PlayerAppareance.ReadBytes(Tamanho_a_leer)
                            Leer_PlayerAppareance.BaseStream.Position = Posicion_a_grabar
                            Grabar_PlayerAppareance.Write(swaps.swap32(Player_id_mayor))
                            Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
                            Grabar_PlayerAppareance.Write(end_of_file)
                            Exit For
                        End If

                    End If
                Next

            End If

        Next


        Total_players_box.Text = (unzlib_Player.Length / Player.tamanho_bloque).ToString

        MsgBox(number_of_players.ToString + " players added")

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click


        Dim Player_modif As New Player

        Player_modif.Grabar_valores(ListBox1.SelectedIndex)
        Player_modif.Grabar_boots()
        Player_modif.Grabar_Gloves()
        Player_modif.Grabar_Playerappareance()


       

        Dim Nom_Jugador As String = Shirt_name.Text

        Dim Seleccionado As UInteger = ListBox1.SelectedIndex
        ListBox1.Items.RemoveAt(Seleccionado)
        ListBox1.Items.Insert(Seleccionado, Nom_Jugador)
        ListBox1.SelectedIndex = Seleccionado

        MsgBox("Changes applied")

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex <> -1 Then
            Leer_Competition_Entry.BaseStream.Position = 0
            Temp_Competition_entry_index_mayor = 0
            Dim bloques_CompetitionEntry As UInteger = unzlib_CompetitionEntry.Length / 12
            Competition_entry_index_mayor = 0
            For i = 0 To bloques_CompetitionEntry - 1
                Leer_Competition_Entry.BaseStream.Position += 6
                Dim Aux As UInt16 = swaps.swap16(Leer_Competition_Entry.ReadUInt16)
                If Aux > Competition_entry_index_mayor Then
                    Competition_entry_index_mayor = Aux
                End If
                Leer_Competition_Entry.BaseStream.Position += 4
            Next



            Dim comp_to_read As New Competition
            comp_to_read.Leer_Competition_Reg(ListBox2.SelectedIndex)
            Leer_Competition_regulation.BaseStream.Position = ListBox2.SelectedIndex * 148
            Leer_Competition_regulation.BaseStream.Position += 7
            Dim Comp_Id As UInteger = Leer_Competition_regulation.ReadByte
            NumericCompetitionID.Value = comp_to_read.comp_id
            DataGridView1.Rows.Clear()
            DataGridView1_orig.Rows.Clear()
            Leer_Competition_Entry.BaseStream.Position = 0
            Dim Num_bloques_compEntry As UInteger = unzlib_CompetitionEntry.Length / 12

            For i = 0 To Num_bloques_compEntry - 1

                Leer_Competition_Entry.BaseStream.Position += 10
                Dim Check_league As UInteger = Leer_Competition_Entry.ReadByte

                If Check_league = Comp_Id Then
                    Leer_Competition_Entry.BaseStream.Position -= 11
                    Dim TeamId As UInteger = swaps.swap32(Leer_Competition_Entry.ReadUInt32())

                    Dim ValorUNK16 As UInt16 = swaps.swap16(Leer_Competition_Entry.ReadUInt16())


                    Dim C_Entry_Index As UInt16 = swaps.swap16(Leer_Competition_Entry.ReadUInt16())

                    Leer_Competition_Entry.BaseStream.Position += 1
                    Dim Order As Byte = Leer_Competition_Entry.ReadByte

                    Dim Num_bloques_team As UInteger = unzlib_Team.Length / Team.tamanho_bloque
                    Dim Nombre_texto_team As String = ""
                    Leer_Team.BaseStream.Position = 8
                    Dim Id_check As UInt32 = swaps.swap32(Leer_Team.ReadUInt32())
                    Dim j As UInteger = 0

                    Do While (Id_check <> TeamId) And (j < (Num_bloques_team - 1))
                        Leer_Team.BaseStream.Position += 1396
                        j += 1
                        Id_check = swaps.swap32(Leer_Team.ReadUInt32())
                    Loop

                    If j < Num_bloques_team Then
                        Dim index As UInt32 = (Leer_Team.BaseStream.Position - 14) / Team.tamanho_bloque
                        Dim Equipo_a_buscar As New Team
                        Equipo_a_buscar.Leer_valores(index)
                        Nombre_texto_team = Equipo_a_buscar.Nombre_equipo_english
                    End If

                    DataGridView1.Rows.Add(Order, TeamId, Nombre_texto_team, C_Entry_Index, ValorUNK16)
                    Nombre_texto_team = ""
                    Leer_Competition_Entry.BaseStream.Position += 2




                Else
                    Leer_Competition_Entry.BaseStream.Position += 1
                End If


            Next
            For Each row In DataGridView1.Rows
                DataGridView1_orig.Rows.Add(DataGridView1.Rows(row.index).Cells(0).Value, DataGridView1.Rows(row.index).Cells(1).Value, DataGridView1.Rows(row.index).Cells(2).Value, DataGridView1.Rows(row.index).Cells(3).Value)
            Next

        End If

    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        If ListBox3.SelectedIndex <> -1 Then

            If DataGridView_playersOfTeam_2.Visible = True Then

                Button10.Visible = False
                Button11.Visible = False
                Button12.Visible = False
                Button9.Visible = True
                DataGridView_playersOfTeam_2.Visible = False
                Campo.Visible = True
                ComboBox_Form_slot.Visible = True
                ComboBox_Attack_type.Visible = True
                TextBox_Team_Na_2.Visible = False
                Team_id_box_2.Visible = False
                Button7.Visible = True
                Label36.Visible = False
                Label37.Visible = False
                Button24.Visible = False
                Button50.Visible = False
                GroupBox12.Visible = False

            End If
            marcado = False




            Dim equipo1 As New Team
            TextBox_stadium_name.Text = ""
            DataGridView_playersOfTeam.Rows.Clear()
            equipo1.Leer_valores(ListBox3.SelectedIndex)
            equipo1.leer_jugadores_equipo()


            COach_id_box.Text = equipo1.Coach
            Team_id_box.Text = equipo1.Id_32
            Team_stadium_box.Text = equipo1.Stadium_16
           

            'Poner el tipo de coach


            ' Buscar nacionalidad nombre.
            Dim Texto_Nacionalidad As String = ""
            For i = 0 To DataGridView_Countries.Rows.Count - 1
                If DataGridView_Countries.Rows(i).Cells(0).Value = equipo1.Country_16.ToString Then
                    Texto_Nacionalidad = DataGridView_Countries.Rows(i).Cells(1).Value.ToString
                End If



            Next

            Label46.Text = Texto_Nacionalidad



            Select Case Non_playable_team_box.Value

                Case 1
                    Label41.Text = "Classic Teams"
                Case 2
                    Label41.Text = "Other Europe League"
                Case 3
                    Label41.Text = "Other Asian League"
                Case 4
                    Label41.Text = "Hidden Fake European Teams"
                Case 5
                    Label41.Text = "ML Hidden teams"
                Case 6
                    Label41.Text = "Other America League"
                Case 7
                    Label41.Text = "Other Africa League"

                Case Else
                    Label41.Text = "No one non playable League"

            End Select
           

            Team_short_box.Text = equipo1.Nombre_Corto
            TextBox_Team_Na.Text = equipo1.Nombre_equipo_english


            'buscar nombre entrenador


            For i = 0 To DataGridView_coach.Rows.Count - 1
                If DataGridView_coach.Rows(i).Cells(0).Value = equipo1.Coach Then
                    Label43.Text = DataGridView_coach.Rows(i).Cells(1).Value.ToString
                End If

            Next


            'buscar nombre estadio


            For i = 0 To DataGridView_Stadium.Rows.Count - 1
                If DataGridView_Stadium.Rows(i).Cells(0).Value = equipo1.Stadium_16 Then
                    TextBox_stadium_name.Text = DataGridView_Stadium.Rows(i).Cells(1).Value
                End If

            Next

            'leo aqui los jugadores para que se centre el nombre
            If DataGridView_playersOfTeam.Rows.Count > 11 Then
                l0.Text = DataGridView_playersOfTeam.Rows(0).Cells(1).Value
                l1.Text = DataGridView_playersOfTeam.Rows(1).Cells(1).Value
                l2.Text = DataGridView_playersOfTeam.Rows(2).Cells(1).Value
                l3.Text = DataGridView_playersOfTeam.Rows(3).Cells(1).Value
                l4.Text = DataGridView_playersOfTeam.Rows(4).Cells(1).Value
                l5.Text = DataGridView_playersOfTeam.Rows(5).Cells(1).Value
                l6.Text = DataGridView_playersOfTeam.Rows(6).Cells(1).Value
                l7.Text = DataGridView_playersOfTeam.Rows(7).Cells(1).Value
                l8.Text = DataGridView_playersOfTeam.Rows(8).Cells(1).Value
                l9.Text = DataGridView_playersOfTeam.Rows(9).Cells(1).Value
                l10.Text = DataGridView_playersOfTeam.Rows(10).Cells(1).Value

                Leer_tactica(equipo1.Id_32)
                'TextBox_nombre_es.Text = Label43.Text

                'Label43.Text = Nombre_estadio
            End If
        End If



    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        zlib1.zlib_memstream_to_console_overwriting(unzlib_Player, openfolder.SelectedPath + "\Player.bin")
        MsgBox("Player.bin Succesfully Saved at : " & openfolder.SelectedPath)
        unzlib_Player.Close()
        ListBox1.Items.Clear()

    End Sub

    Private Sub ComboBox1_Click(sender As System.Object, e As System.EventArgs) Handles ComboBox1.Click

        If ListBox2.SelectedItem Is Nothing Then
            MsgBox("Select competition before")
        ElseIf DataGridView1.Rows.Count = 0 Then
            MsgBox("This competition don´t have Original Assignament.... ")
        Else
            ' If ComboBox1.Items.Count = 0 Or ListBox3.Items.Count > ComboBox1.Items.Count Then
            ComboBox1.Items.Clear()

            For i = 0 To ListBox3.Items.Count - 1
                Dim Selected_item As Object = ListBox3.Items(i)
                ComboBox1.Items.Add(Selected_item)
            Next

            Me.Hide()

            Select_a_team.ShowDialog()
            ComboBox1.SelectedIndex = combo1_selec_index

            Me.Show()

            'End If

        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        If MsgBox("Do you want To add " + ComboBox1.SelectedItem.ToString + " to " + ListBox2.SelectedItem.ToString + " League ?", MsgBoxStyle.YesNo, "Add Team") = MsgBoxResult.Yes Then
            Leer_Team.BaseStream.Position = ComboBox1.SelectedIndex * Team.tamanho_bloque
            Leer_Team.BaseStream.Position += 8
            Dim Id As UInt32 = swaps.swap32(Leer_Team.ReadUInt32())




            If DataGridView1.Rows.Count < DataGridView1_orig.Rows.Count Then

                Dim row_index As UInteger = DataGridView1.Rows.Count
                Temp_Competition_entry_index_mayor = DataGridView1_orig.Rows(row_index).Cells(3).Value
            ElseIf Temp_Competition_entry_index_mayor < Competition_entry_index_mayor Then
                Temp_Competition_entry_index_mayor = Competition_entry_index_mayor + 1
            Else
                Temp_Competition_entry_index_mayor += 1
            End If



            DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, Id, ComboBox1.SelectedItem.ToString, Temp_Competition_entry_index_mayor)


        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 1)
        Else
            MsgBox(" No Items to Remove!!!!! :))")
        End If

        If (Temp_Competition_entry_index_mayor > 0) Then
            Temp_Competition_entry_index_mayor -= 1
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim Get_row As UInteger = DataGridView1.CurrentRow.Index
        Dim Team As String = DataGridView1.Rows(Get_row).Cells(2).Value.ToString
        Label_form2 = ("Select a Team to replace " + Team)
        Select_a_Team_toReplace.ShowDialog()

        If CheckSelected = True Then
            Leer_Team.BaseStream.Position = combo1_selec_index * 1400

            Leer_Team.BaseStream.Position += 8
            Dim Id As UInt32 = swaps.swap32(Leer_Team.ReadUInt32())
            ListBox3.SelectedIndex = combo1_selec_index
            DataGridView1.Rows(Get_row).Cells(2).Value = ListBox3.SelectedItem.ToString
            DataGridView1.Rows(Get_row).Cells(1).Value = Id
            CheckSelected = False
        End If
    End Sub

    Private Sub Boton_aplicar_cambios_ligas_Click(sender As System.Object, e As System.EventArgs) Handles Boton_aplicar_cambios_ligas.Click

        If DataGridView1.Rows.Count = DataGridView1_orig.Rows.Count Then
            For Each row In DataGridView1.Rows
                Dim new_c_entry_index As UInt16 = DataGridView1.Rows(row.index).Cells(3).Value
                Dim new_team_Id As UInt32 = DataGridView1.Rows(row.index).Cells(1).Value

                Leer_Competition_Entry.BaseStream.Position = 0


                Leer_Competition_Entry.BaseStream.Position += 6
                Dim Old_c_entry_index As UInt16 = swaps.swap16(Leer_Competition_Entry.ReadUInt16())

                While (new_c_entry_index <> Old_c_entry_index) And (Leer_Competition_Entry.BaseStream.Position < unzlib_CompetitionEntry.Length)
                    Leer_Competition_Entry.BaseStream.Position += 10
                    Old_c_entry_index = swaps.swap16(Leer_Competition_Entry.ReadUInt16())
                End While
                Leer_Competition_Entry.BaseStream.Position -= 8

                new_team_Id = swaps.swap32(new_team_Id)
                Grabar_Competition_Entry.Write(new_team_Id)

            Next

            MsgBox("Cahnges applied succesfully")
            ListBox2.SelectedItem = ListBox2.SelectedItem


            '''''''''voy por aqui'''''''
        ElseIf DataGridView1.Rows.Count < DataGridView1_orig.Rows.Count Then
            For Each row In DataGridView1.Rows
                Dim new_c_entry_index As UInt16 = DataGridView1.Rows(row.index).Cells(3).Value
                Dim new_team_Id As UInt32 = DataGridView1.Rows(row.index).Cells(1).Value

                Leer_Competition_Entry.BaseStream.Position = 6
                Dim Old_c_entry_index As UInt16 = swaps.swap16(Leer_Competition_Entry.ReadUInt16())

                While (new_c_entry_index <> Old_c_entry_index) And (Leer_Competition_Entry.BaseStream.Position < unzlib_CompetitionEntry.Length)
                    Leer_Competition_Entry.BaseStream.Position += 10
                    Old_c_entry_index = swaps.swap16(Leer_Competition_Entry.ReadUInt16())
                End While

                Leer_Competition_Entry.BaseStream.Position -= 8
                new_team_Id = swaps.swap32(new_team_Id)
                Grabar_Competition_Entry.Write(new_team_Id)

                Leer_Competition_Entry.BaseStream.Position += 8


            Next
            'Poner para borrar los elementos existentes anteriores
            Dim unzlib_CompetitionEntry_aux As New MemoryStream
            Dim Grabar_Competition_Entry_aux As New BinaryWriter(unzlib_CompetitionEntry_aux)

            For i = DataGridView1.Rows.Count To DataGridView1_orig.Rows.Count - 1
                Leer_Competition_Entry.BaseStream.Position = 6
                Dim index_a_borrar As UInt16 = DataGridView1_orig.Rows(i).Cells(3).Value
                Dim Index_leido As UInt16 = swaps.swap16(Leer_Competition_Entry.ReadUInt16)
                While Index_leido <> index_a_borrar
                    Leer_Competition_Entry.BaseStream.Position += 10
                    Index_leido = swaps.swap16(Leer_Competition_Entry.ReadUInt16)
                End While
                Leer_Competition_Entry.BaseStream.Position -= 2
                Dim cero As UInt16 = 0
                Grabar_Competition_Entry.Write(cero)

            Next
            Leer_Competition_Entry.BaseStream.Position = 6
            Dim Centry_bloques As UInteger = unzlib_CompetitionEntry.Length / 12
            For i = 0 To Centry_bloques - 1
                If Leer_Competition_Entry.ReadUInt16 <> 0 Then
                    Leer_Competition_Entry.BaseStream.Position -= 8
                    Grabar_Competition_Entry_aux.Write(Leer_Competition_Entry.ReadUInt32)
                    Grabar_Competition_Entry_aux.Write(Leer_Competition_Entry.ReadUInt16)
                    Grabar_Competition_Entry_aux.Write(Leer_Competition_Entry.ReadUInt16)
                    Grabar_Competition_Entry_aux.Write(Leer_Competition_Entry.ReadByte)
                    Grabar_Competition_Entry_aux.Write(Leer_Competition_Entry.ReadByte)
                    Grabar_Competition_Entry_aux.Write(Leer_Competition_Entry.ReadByte)
                    Grabar_Competition_Entry_aux.Write(Leer_Competition_Entry.ReadByte)
                    Leer_Competition_Entry.BaseStream.Position += 6
                Else
                    Leer_Competition_Entry.BaseStream.Position += 10
                End If

            Next
            unzlib_CompetitionEntry.Close()
            unzlib_CompetitionEntry = New MemoryStream
            unzlib_CompetitionEntry_aux.Position = 0
            unzlib_CompetitionEntry_aux.CopyTo(unzlib_CompetitionEntry)
            unzlib_CompetitionEntry_aux.Close()
            Leer_Competition_Entry = New BinaryReader(unzlib_CompetitionEntry)
            Grabar_Competition_Entry = New BinaryWriter(unzlib_CompetitionEntry)


            MsgBox("Changes applied succesfully")
            ListBox2.SelectedItem = ListBox2.SelectedItem

        Else
            For Each row In DataGridView1_orig.Rows
                Dim new_c_entry_index As UInt16 = DataGridView1.Rows(row.index).Cells(3).Value
                Dim new_team_Id As UInt32 = DataGridView1.Rows(row.index).Cells(1).Value

                Leer_Competition_Entry.BaseStream.Position = 6
                Dim Old_c_entry_index As UInt16 = swaps.swap16(Leer_Competition_Entry.ReadUInt16())

                While (new_c_entry_index <> Old_c_entry_index) And (Leer_Competition_Entry.BaseStream.Position < unzlib_CompetitionEntry.Length - 10)
                    Leer_Competition_Entry.BaseStream.Position += 10
                    Old_c_entry_index = swaps.swap16(Leer_Competition_Entry.ReadUInt16())
                End While
                Leer_Competition_Entry.BaseStream.Position -= 8

                Grabar_Competition_Entry.Write(swaps.swap32(new_team_Id))


            Next
            'Poner para borrar los elementos existentes anteriores

            For i = DataGridView1_orig.Rows.Count To DataGridView1.Rows.Count - 1
                Leer_Competition_Entry.BaseStream.Position = unzlib_CompetitionEntry.Length
                Dim Centry_Index As UInt16 = DataGridView1.Rows(i).Cells(3).Value
                Dim Team_id As UInt32 = DataGridView1.Rows(i).Cells(1).Value
                Dim Order As Byte = DataGridView1.Rows(i).Cells(0).Value
                Dim League As Byte = NumericCompetitionID.Value
                If Tipo_consola <> 0 And Tipo_consola <> 4 Then
                    League = converter.rotl(League, 1)
                End If



                Dim UNK As UInt16 = DataGridView1.Rows(0).Cells(4).Value
                Dim cero_byte As Byte = 0
                Grabar_Competition_Entry.Write(swaps.swap32(Team_id))
                Grabar_Competition_Entry.Write(swaps.swap16(UNK))
                Grabar_Competition_Entry.Write(swaps.swap16(Centry_Index))
                Grabar_Competition_Entry.Write(cero_byte)
                Grabar_Competition_Entry.Write(Order)
                Grabar_Competition_Entry.Write(League)
                Grabar_Competition_Entry.Write(cero_byte)



            Next



            MsgBox("Cahnges applied succesfully")
            ListBox2.SelectedItem = ListBox2.SelectedItem
            'Poner para grabar los elementos que añades.
        End If


    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click

        Try
            If Tipo_consola = 1 Or Tipo_consola = 2 Then
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Player, openfolder.SelectedPath + nombrePlayer)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_CompetitionEntry, openfolder.SelectedPath + nombreCompetitionEntry)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Team, openfolder.SelectedPath + nombreTeam)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Player_Assignament, openfolder.SelectedPath + nombrePlayerAssignment)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Coach, openfolder.SelectedPath + NombreCoach)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Tactics, openfolder.SelectedPath + NombreTactics)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Derby, openfolder.SelectedPath + NombreDerby)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Competition, openfolder.SelectedPath + Nombrecompetition)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Competition_Kind, openfolder.SelectedPath + Nombrecompetition_Kind)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Competition_regulation, openfolder.SelectedPath + nombreCompetitionReg)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Stadium, openfolder.SelectedPath + nombreStadium)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Ball, openfolder.SelectedPath + NombreBall)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Ball_condition, openfolder.SelectedPath + NombreBall_condition)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Boots, openfolder.SelectedPath + NombreBoots)
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Gloves, openfolder.SelectedPath + NombreGloves)
                If Boot_List_present = True Then
                    zlib1.zlib_memstream_to_console_overwriting(unzlib_Boots_list, openfolder.SelectedPath + nombreBootList)
                End If

                If Glove_List_present = True Then
                    zlib1.zlib_memstream_to_console_overwriting(unzlib_Gloves_list, openfolder.SelectedPath + nombreGloveList)
                End If
                zlib1.zlib_memstream_to_console_overwriting(unzlib_Tactics_formation, openfolder.SelectedPath + NombreTactics_formation)
                If File.Exists(openfolder.SelectedPath + nombrePlayerApareance) = True Then
                    System.IO.File.Delete(openfolder.SelectedPath + nombrePlayerApareance)
                End If

                If PLayer_Appareance_present = True Then
                    Dim PlayerAppareance_Stream = New FileStream(openfolder.SelectedPath + nombrePlayerApareance, FileMode.OpenOrCreate, FileAccess.Write)
                    PlayerAppareance_MemStream.Position = 0
                    PlayerAppareance_MemStream.CopyTo(PlayerAppareance_Stream)
                    PlayerAppareance_Stream.Close()
                End If

            ElseIf Tipo_consola = 0 Or Tipo_consola = 4 Then
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Player, openfolder.SelectedPath + nombrePlayer)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_CompetitionEntry, openfolder.SelectedPath + nombreCompetitionEntry)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Team, openfolder.SelectedPath + nombreTeam)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Player_Assignament, openfolder.SelectedPath + nombrePlayerAssignment)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Coach, openfolder.SelectedPath + NombreCoach)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Tactics, openfolder.SelectedPath + NombreTactics)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Derby, openfolder.SelectedPath + NombreDerby)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Competition, openfolder.SelectedPath + Nombrecompetition)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Competition_Kind, openfolder.SelectedPath + Nombrecompetition_Kind)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Competition_regulation, openfolder.SelectedPath + nombreCompetitionReg)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Stadium, openfolder.SelectedPath + nombreStadium)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Ball, openfolder.SelectedPath + NombreBall)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Ball_condition, openfolder.SelectedPath + NombreBall_condition)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Boots, openfolder.SelectedPath + NombreBoots)
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Gloves, openfolder.SelectedPath + NombreGloves)
                If Boot_List_present = True Then
                    zlib1.zlib_memstream_to_pc_overwriting(unzlib_Boots_list, openfolder.SelectedPath + nombreBootList)
                End If

                If Glove_List_present = True Then
                    zlib1.zlib_memstream_to_pc_overwriting(unzlib_Gloves_list, openfolder.SelectedPath + nombreGloveList)
                End If
                zlib1.zlib_memstream_to_pc_overwriting(unzlib_Tactics_formation, openfolder.SelectedPath + NombreTactics_formation)

                If PLayer_Appareance_present = True Then
                    Dim PlayerAppareance_Stream = New FileStream(openfolder.SelectedPath + nombrePlayerApareance, FileMode.OpenOrCreate, FileAccess.Write)
                    PlayerAppareance_MemStream.Position = 0
                    PlayerAppareance_MemStream.CopyTo(PlayerAppareance_Stream)
                    PlayerAppareance_Stream.Close()

                End If

            End If

            MsgBox("All Files Succesfully Saved at : " & openfolder.SelectedPath)
            Me.Close()
            Me.Dispose()


        Catch Ex As Exception
            MsgBox("No files founded to save :)")

        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        If (TextBox_search.Text <> String.Empty) Then
            If ListBox1.SelectedIndex = -1 Then
                ListBox1.SelectedIndex = 0
            End If
            If CheckBoxPlayer_id.Checked = False Then

                Dim Start_index As UInteger = ListBox1.SelectedIndex + 1
                Dim i As Integer = 0
                For i = Start_index To ListBox1.Items.Count - 1
                    Dim List_BOX_STR As String = ListBox1.Items(i).ToUpper
                    If List_BOX_STR.Contains(TextBox_search.Text.ToUpper) = True Then
                        ListBox1.SelectedIndex = i
                        Exit For
                    ElseIf i = ListBox1.Items.Count - 1 Then
                        If MsgBox("Maybe your search was before the index, want to start from the beggining? ", MsgBoxStyle.YesNo, "Team Search") = MsgBoxResult.Yes Then
                            ListBox1.SelectedIndex = 0
                            PictureBox2_Click(PictureBox2, Nothing)
                        Else
                            ListBox1.SelectedIndex = 0
                        End If

                    End If

                Next
            Else
                Leer_Player.BaseStream.Position = Player.Id_32_pos
                For i = 0 To unzlib_Player.Length / Player.tamanho_bloque - 1

                    If swaps.swap32(Leer_Player.ReadUInt32) = TextBox_search.Text Then
                        ListBox1.SelectedIndex = i
                        Exit For
                    ElseIf i = unzlib_Player.Length / Player.tamanho_bloque - 1 Then
                        MsgBox("Id not found sorry")
                        Exit For
                    Else
                        Leer_Player.BaseStream.Position += (Player.tamanho_bloque - 4)
                    End If

                Next


            End If

        End If
    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        If (TextBox_search_team.Text <> String.Empty) Then
            If ListBox3.SelectedIndex = -1 Then
                ListBox3.SelectedIndex = 0
            End If
            Dim Start_index As UInteger = ListBox3.SelectedIndex + 1
            Dim i As Integer = 0
            For i = Start_index To ListBox3.Items.Count - 1
                Dim List_BOX_STR As String = ListBox3.Items(i).ToUpper
                If List_BOX_STR.Contains(TextBox_search_team.Text.ToUpper) = True Then
                    ListBox3.SelectedIndex = i
                    Exit For
                ElseIf i = ListBox3.Items.Count - 1 Then
                    If MsgBox("Maybe your search was before the index, want to start from the beggining? ", MsgBoxStyle.YesNo, "Team Search") = MsgBoxResult.Yes Then
                        ListBox3.SelectedIndex = 0
                        PictureBox2_Click(PictureBox2, Nothing)
                    Else
                        ListBox3.SelectedIndex = 0
                    End If

                End If

            Next




        End If
    End Sub

    Private Sub TextBox_search_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox1_Click(PictureBox1, Nothing)

        End If
    End Sub

    Private Sub TextBox_search_team_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox_search_team.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox2_Click(PictureBox2, Nothing)

        End If
    End Sub

    Private Sub Apply_changes_team_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Try
            Dim Team_changed As New Team
            Team_changed.grabar_jugadores()
            Team_changed.Grabar_valores(ListBox3.SelectedIndex)
            MsgBox("Changes Applied Succesfully")
            Dim indice_seleccionado As UInteger = ListBox3.SelectedIndex
            ListBox3.SelectedIndex = -1
            ListBox3.SelectedIndex = indice_seleccionado


        Catch ex As Exception
            MsgBox("Values must be numeric and inside the range")
        End Try



    End Sub

    Private Sub Team_id_box_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Team_id_box.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Team_Na_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox_Team_Na.TextChanged
        NombreEquipo_cambiado = True
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        If ListBox3.SelectedIndex = -1 Then
            MsgBox("Select the team you want to clone as base")
        Else
            If MsgBox("Do you want To Clone " & ListBox3.SelectedItem.ToString, MsgBoxStyle.YesNo, "Clone Team") = MsgBoxResult.Yes Then
                Leer_Team.BaseStream.Position = ListBox3.SelectedIndex * Team.tamanho_bloque
                Dim New_team(Team.tamanho_bloque) As Byte
                New_team = Leer_Team.ReadBytes(Team.tamanho_bloque)
                Dim posicion_para_grabar As UInteger = unzlib_Team.Length
                unzlib_Team.SetLength(unzlib_Team.Length + New_team.Length)
                unzlib_Team.Position = posicion_para_grabar
                unzlib_Team.Write(New_team, 0, New_team.Length)
                Leer_Team.BaseStream.Position = posicion_para_grabar + 8

                index_de_equipo_max += 1
                Id_de_equipo_max += 1

                Grabar_Team.Write(swaps.swap32(Id_de_equipo_max))
                Leer_Tactics.BaseStream.Position = 0
                Dim TEAM_ID_to_clone As UInt32 = Team_id_box.Text
                While swaps.swap32(Leer_Tactics.ReadUInt32()) <> TEAM_ID_to_clone
                    Leer_Tactics.BaseStream.Position += 8
                End While
                Leer_Tactics.BaseStream.Position -= 4
                Dim New_tactic As Byte() = Leer_Tactics.ReadBytes(12)
                While swaps.swap32(Leer_Tactics.ReadUInt32()) <> TEAM_ID_to_clone
                    Leer_Tactics.BaseStream.Position += 8
                End While
                Leer_Tactics.BaseStream.Position -= 4
                Dim New_tactic2 As Byte() = Leer_Tactics.ReadBytes(12)


                ' Dim Slot1 As UInt32 = unzlib_Tactics.Length / 12
                Leer_Tactics.BaseStream.Position = unzlib_Tactics.Length
                Grabar_Tactics.Write(New_tactic)
                Grabar_Tactics.Write(New_tactic2)

                Dim Slot_de_formacion_max As UInt16 = 0
                Leer_Tactics_formation.BaseStream.Position = 4
                Dim Aux As UInt16
                For i = 0 To unzlib_Tactics_formation.Length / 12 - 1
                    'busco el slot mas alto para poner el siguiente valor
                    Aux = swaps.swap16(Leer_Tactics_formation.ReadUInt16())
                    If Aux > Slot_de_formacion_max Then
                        Slot_de_formacion_max = Aux
                    End If

                Next
                Slot_de_formacion_max = Slot_de_formacion_max + 1


                Leer_Tactics.BaseStream.Position = unzlib_Tactics.Length - 24
                Grabar_Tactics.Write(swaps.swap32(Id_de_equipo_max))
                Dim Slot_orig1 As UInt16 = swaps.swap16(Leer_Tactics.ReadUInt16)
                Leer_Tactics.BaseStream.Position -= 2
                Grabar_Tactics.Write(swaps.swap16(Slot_de_formacion_max))
                Leer_Tactics.BaseStream.Position += 6

                Grabar_Tactics.Write(swaps.swap32(Id_de_equipo_max))
                Dim Slot_orig2 As UInt16 = swaps.swap16(Leer_Tactics.ReadUInt16)
                Leer_Tactics.BaseStream.Position -= 2
                Grabar_Tactics.Write(swaps.swap16(Slot_de_formacion_max + 1))


                Leer_Tactics_formation.BaseStream.Position = 4
                While swaps.swap16(Leer_Tactics_formation.ReadUInt16) <> Slot_orig1
                    Leer_Tactics_formation.BaseStream.Position += 10
                End While

                Leer_Tactics_formation.BaseStream.Position -= 6
                Dim Bloque_Tactics_form As Byte() = Leer_Tactics_formation.ReadBytes(396)
                Leer_Tactics_formation.BaseStream.Position = unzlib_Tactics_formation.Length
                Grabar_Tactics_formation.Write(Bloque_Tactics_form)
                Leer_Tactics_formation.BaseStream.Position -= 392
                For i = 1 To 33
                    Grabar_Tactics_formation.Write(swaps.swap16(Slot_de_formacion_max))
                    Leer_Tactics_formation.BaseStream.Position += 10
                Next

                Leer_Tactics_formation.BaseStream.Position = 4
                While swaps.swap16(Leer_Tactics_formation.ReadUInt16) <> Slot_orig2
                    Leer_Tactics_formation.BaseStream.Position += 10
                End While

                Leer_Tactics_formation.BaseStream.Position -= 6
                Dim Bloque_Tactics_form_2 As Byte() = Leer_Tactics_formation.ReadBytes(396)
                Leer_Tactics_formation.BaseStream.Position = unzlib_Tactics_formation.Length
                Grabar_Tactics_formation.Write(Bloque_Tactics_form_2)
                Leer_Tactics_formation.BaseStream.Position -= 392
                For i = 1 To 33
                    Grabar_Tactics_formation.Write(swaps.swap16(Slot_de_formacion_max + 1))
                    Leer_Tactics_formation.BaseStream.Position += 10
                Next





                DataGridView_TEAM.Rows.Add(index_de_equipo_max, Id_de_equipo_max, "ADDED", 10)
                ListBox3.Items.Add("ADDED TEAM")
                ListBox3.SelectedIndex = ListBox3.Items.Count - 1

                'Y poner 16 jugadores

                unzlib_Player.Position = unzlib_Player.Length
                Dim Player_fake_array As Byte() = My.Resources.Player_fake()
                Dim Player_fake_array_xb As Byte() = My.Resources.Player_fake_xb()
                Dim Primer_player_metido As UInt32

                For i = 0 To 15

                    Player_id_mayor += 1
                    Dim cero32 As UInt32 = 0

                    Grabar_player.Write(cero32)
                    Grabar_player.Write(cero32)

                    Grabar_player.Write(swaps.swap32(Player_id_mayor))
                    If i = 0 Then
                        Primer_player_metido = Player_id_mayor

                    End If
                    If Tipo_consola = 0 Or Tipo_consola = 4 Then
                        unzlib_Player.Write(Player_fake_array, 0, Player_fake_array.Length)
                    Else
                        unzlib_Player.Write(Player_fake_array_xb, 0, Player_fake_array.Length)
                    End If

                    ListBox1.Items.Add("SMEAGOL75")


                    'para poner botas aleatorias al crear player, y appareance aleatoria


                    If Boot_List_present = True Then
                        Dim Boots_aleatorias As New Random
                        Dim botas_aleatorias As UInt32 = Boots_aleatorias.Next(0, DataGridView_boots.Rows.Count)
                        Dim end_of_file As Byte()
                        Leer_Boots_list.BaseStream.Position = 0
                        Dim boots_to_add As UInt16 = Convert.ToUInt16(DataGridView_boots.Rows(botas_aleatorias).Cells(0).Value)
                        Dim Zero_16 As UInt16 = 0
                        For j = 0 To unzlib_Boots_list.Length / 8
                            Dim Check_order As UInt32 = swaps.swap32(Leer_Boots_list.ReadUInt32)
                            If Check_order < Player_id_mayor Then
                                Leer_Boots_list.BaseStream.Position += 4

                            ElseIf j = unzlib_Boots_list.Length / 8 - 1 Then

                                Leer_Boots_list.BaseStream.Position = unzlib_Boots_list.Length
                                Grabar_Boots_list.Write(swaps.swap32(Player_id_mayor))

                                Grabar_Boots_list.Write(swaps.swap16(boots_to_add))
                                Grabar_Boots_list.Write(swaps.swap16(Zero_16))
                                Exit For
                            Else
                                If Check_order = Player_id_mayor Then

                                    Grabar_Boots_list.Write(swaps.swap16(boots_to_add))
                                    Grabar_Boots_list.Write(swaps.swap16(Zero_16))
                                    Exit For
                                Else
                                    'leer hasta el final
                                    Leer_Boots_list.BaseStream.Position -= 4
                                    Dim Posicion_a_grabar As ULong = Leer_Boots_list.BaseStream.Position
                                    Dim Tamanho_a_leer As ULong = unzlib_Boots_list.Length - Leer_Boots_list.BaseStream.Position
                                    end_of_file = Leer_Boots_list.ReadBytes(Tamanho_a_leer)
                                    Leer_Boots_list.BaseStream.Position = Posicion_a_grabar
                                    Grabar_Boots_list.Write(swaps.swap32(Player_id_mayor))

                                    Grabar_Boots_list.Write(swaps.swap16(boots_to_add))
                                    Grabar_Boots_list.Write(swaps.swap16(Zero_16))
                                    Grabar_Boots_list.Write(end_of_file)
                                    Exit For

                                End If

                            End If
                        Next


                    End If

                    If PLayer_Appareance_present = True Then
                        Dim Player_Player_appareance_block As Byte()

                        Dim numAleatorio As New Random()
                        Dim valorAleatorio As Integer = numAleatorio.Next(0, 1000)
                        Leer_PlayerAppareance.BaseStream.Position = (valorAleatorio * 60) + 4
                        Player_Player_appareance_block = Leer_PlayerAppareance.ReadBytes(56)
                        Dim end_of_file As Byte()
                        Leer_PlayerAppareance.BaseStream.Position = 0

                        For j = 0 To PlayerAppareance_MemStream.Length / 60
                            Dim Check_order As UInt32 = swaps.swap32(Leer_PlayerAppareance.ReadUInt32)
                            If Check_order < Player_id_mayor Then
                                Leer_PlayerAppareance.BaseStream.Position += 56

                            ElseIf j = PlayerAppareance_MemStream.Length / 60 - 1 Then
                                Leer_PlayerAppareance.BaseStream.Position = PlayerAppareance_MemStream.Length
                                Grabar_PlayerAppareance.Write(swaps.swap32(Player_id_mayor))
                                Grabar_PlayerAppareance.Write(Player_Player_appareance_block)

                                Exit For
                            Else
                                If Check_order = Player_id_mayor Then
                                    Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
                                    Exit For
                                Else
                                    'leer hasta el final
                                    Leer_PlayerAppareance.BaseStream.Position -= 4
                                    Dim Posicion_a_grabar As ULong = Leer_PlayerAppareance.BaseStream.Position
                                    Dim Tamanho_a_leer As ULong = PlayerAppareance_MemStream.Length - Leer_PlayerAppareance.BaseStream.Position
                                    end_of_file = Leer_PlayerAppareance.ReadBytes(Tamanho_a_leer)
                                    Leer_PlayerAppareance.BaseStream.Position = Posicion_a_grabar
                                    Grabar_PlayerAppareance.Write(swaps.swap32(Player_id_mayor))
                                    Grabar_PlayerAppareance.Write(Player_Player_appareance_block)
                                    Grabar_PlayerAppareance.Write(end_of_file)
                                    Exit For
                                End If

                            End If
                        Next

                    End If



                    DataGridView_playersOfTeam.Rows.Add(DataGridView_playersOfTeam.Rows.Count, "SMG75", i + 1, 0, 0, 0, 0, 0, 0, PlayerAssignment_index_mayor, Primer_player_metido + i, Label121.Text)
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.Rows.Count - 1).Selected = True
                    Dim Equipo1_a_grabar As New Team
                    Equipo1_a_grabar.grabar_traspasos_1()

                Next


                Total_players_box.Text = (unzlib_Player.Length / Player.tamanho_bloque).ToString
                ListBox3.SelectedIndex = ListBox3.Items.Count - 1
                'Ficharlos en el equipo.
               
                




                MsgBox("Team Added succesfully qith Id: " + Id_de_equipo_max.ToString + vbCrLf + "Change Name and desired Options :) ")
                ListBox3.SelectedIndex = ListBox3.Items.Count - 1
            End If
        End If

    End Sub

    Private Sub NumericTEAMID_Click(sender As System.Object, e As System.EventArgs) Handles NumericTEAMID.Click
        If ListBox1.SelectedItem <> Nothing And NumericTEAMID.Value <> 0 Then
            Leer_Team.BaseStream.Position = 8
            Do While swaps.swap32(Leer_Team.ReadUInt32) <> NumericTEAMID.Value
                Leer_Team.BaseStream.Position -= 4
                Leer_Team.BaseStream.Position += Team.tamanho_bloque

            Loop
            Leer_Team.BaseStream.Position -= 12
            Dim Indice As UInt32 = Leer_Team.BaseStream.Position / Team.tamanho_bloque
            ListBox3.SelectedIndex = Indice
            TabControl1.SelectedTab = TabPage2
            'Poner para que seleccione al jugador solo
            For i = 0 To DataGridView_playersOfTeam.Rows.Count - 1
                If DataGridView_playersOfTeam.Rows(i).Cells(10).Value = Player_num.Value Then
                    DataGridView_playersOfTeam.Rows(i).Selected = True
                    Exit For
                End If
            Next



        Else
            Label_form2 = ("Select a Team to Transfer " + ListBox1.SelectedItem + " from " + TextBox_team_name.ToString)
            Player_transfer.ShowDialog()
            'no añade al jugador
            If CheckSelected = True Then

                Leer_Team.BaseStream.Position = combo1_selec_index * Team.tamanho_bloque
                ListBox3.SelectedIndex = combo1_selec_index

                If CheckBox97.Checked = True And Nation_box.Value <> Convert.ToUInt32(Team_country_box.Text) And Nationalized_box.Value <> Convert.ToUInt32(Team_country_box.Text) Then

                    MsgBox("Change Player´s Nationality, to fit on his National Team first")

                Else

                    TabControl1.SelectedTab = TabPage2
                    CheckSelected = False
                    Button7.Visible = False
                    Button11.Visible = True
                    Button24.Visible = True

                    Dim repetido As Boolean = False
                    Dim usados As New List(Of Integer)
                    Dim dorsal As UInt32 = 1
                    For i = 0 To DataGridView_playersOfTeam.Rows.Count - 1
                        usados.Add(DataGridView_playersOfTeam.Rows(i).Cells(2).Value)

                        If DataGridView_playersOfTeam.Rows(i).Cells(2).Value = dorsal Then
                            repetido = True
                        End If
                    Next
                    If repetido = True Then
                        dorsal = 1

                        While (usados.Contains(dorsal))
                            dorsal += 1
                        End While

                    End If

                    DataGridView_playersOfTeam.Rows.Add(DataGridView_playersOfTeam.Rows.Count, ListBox1.SelectedItem.ToString, dorsal, 0, 0, 0, 0, 0, 0, PlayerAssignment_index_mayor, Player_num.Value, Label121.Text)
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.Rows.Count - 1).Selected = True



                End If




            End If

        End If



    End Sub

    Private Sub TextBox_team_name_Click(sender As System.Object, e As System.EventArgs) Handles TextBox_team_name.Click
        NumericTEAMID_Click(NumericTEAMID, Nothing)
    End Sub

    Private Sub NumericTEAMID_2_Click(sender As System.Object, e As System.EventArgs) Handles NumericTEAMID_2.Click
        If NumericTEAMID.Value <> 0 Then


            If ListBox1.SelectedItem <> Nothing And NumericTEAMID_2.Value <> 0 Then
                Leer_Team.BaseStream.Position = 8
                Do While swaps.swap32(Leer_Team.ReadUInt32) <> NumericTEAMID_2.Value
                    Leer_Team.BaseStream.Position -= 4
                    Leer_Team.BaseStream.Position += Team.tamanho_bloque

                Loop
                Leer_Team.BaseStream.Position -= 12
                Dim Indice As UInt32 = Leer_Team.BaseStream.Position / Team.tamanho_bloque
                ListBox3.SelectedIndex = Indice
                TabControl1.SelectedTab = TabPage2
                'Poner para que seleccione al jugador solo
                For i = 0 To DataGridView_playersOfTeam.Rows.Count - 1
                    If DataGridView_playersOfTeam.Rows(i).Cells(10).Value = Player_num.Value Then
                        DataGridView_playersOfTeam.Rows(i).Selected = True
                        Exit For
                    End If
                Next



            Else
                Label_form2 = ("Select a Team to Transfer " + ListBox1.SelectedItem + " from " + TextBox_team_name.ToString)
                Player_transfer.ShowDialog()
                'no añade al jugador
                If CheckSelected = True Then

                    Leer_Team.BaseStream.Position = combo1_selec_index * Team.tamanho_bloque
                    ListBox3.SelectedIndex = combo1_selec_index

                    If CheckBox97.Checked = True And Nation_box.Value <> Convert.ToUInt32(Team_country_box.Text) And Nationalized_box.Value <> Convert.ToUInt32(Team_country_box.Text) Then

                        MsgBox("Change Player´s Nationality, to fit on his National Team first")

                    Else

                        TabControl1.SelectedTab = TabPage2
                        CheckSelected = False
                        Button7.Visible = False
                        Button11.Visible = True
                        Button24.Visible = True

                        Dim repetido As Boolean = False
                        Dim usados As New List(Of Integer)
                        Dim dorsal As UInt32 = 1
                        For i = 0 To DataGridView_playersOfTeam.Rows.Count - 1
                            usados.Add(DataGridView_playersOfTeam.Rows(i).Cells(2).Value)

                            If DataGridView_playersOfTeam.Rows(i).Cells(2).Value = dorsal Then
                                repetido = True
                            End If
                        Next
                        If repetido = True Then
                            dorsal = 1

                            While (usados.Contains(dorsal))
                                dorsal += 1
                            End While

                        End If

                        DataGridView_playersOfTeam.Rows.Add(DataGridView_playersOfTeam.Rows.Count, ListBox1.SelectedItem.ToString, dorsal, 0, 0, 0, 0, 0, 0, PlayerAssignment_index_mayor, Player_num.Value, Label121.Text)
                        DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.Rows.Count - 1).Selected = True




                    End If




                End If

            End If
        Else
            MsgBox("Assign a National Team Before, if you want to use this second Team")
        End If



    End Sub

    Private Sub TextBox_team_name_2_Click(sender As System.Object, e As System.EventArgs) Handles TextBox_team_name_2.Click
        NumericTEAMID_2_Click(NumericTEAMID_2, Nothing)
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        DataGridView_playersOfTeam_2.Rows.Clear()

        If ListBox3.SelectedItem <> Nothing Then


            Button10.Visible = True
            Button11.Visible = True
            Button12.Visible = True
            Button9.Visible = False
            DataGridView_playersOfTeam_2.Visible = True
            TextBox_Team_Na_2.Visible = True
            Team_id_box_2.Visible = True
            Button7.Visible = False
            Label36.Visible = True
            Label37.Visible = True
            Button24.Visible = True
            Me.Hide()
            If CheckBox97.Checked = True Then
                Button10.Visible = False
            End If
            Campo.Visible = False
            ComboBox_Form_slot.Visible = False
            ComboBox_Attack_type.Visible = False
            Button50.Visible = False
            GroupBox12.Visible = False

            Select_a_team.ShowDialog()


            If CheckSelected = True Then
                Me.Show()

                Dim equipo2 As New Team
                'poner selecindex no  name
                TextBox_Team_Na_2.Text = combo1_selec_index_name
                Team_id_box_2.Text = DataGridView_TEAM.Rows(combo1_selec_index).Cells(1).Value.ToString
                equipo2.Leer_valores_team_2(combo1_selec_index)
                equipo2.leer_jugadores_equipo_2()
                CheckSelected = False
                If CheckBox_NATION_TEAM2.Checked = True Then
                    Me.Show()
                    Button10.Visible = False
                    Button11.Visible = False
                    Button12.Visible = False
                    Button9.Visible = True
                    DataGridView_playersOfTeam_2.Visible = False
                    Campo.Visible = True
                    ComboBox_Form_slot.Visible = True
                    ComboBox_Attack_type.Visible = True
                    TextBox_Team_Na_2.Visible = False
                    Team_id_box_2.Visible = False
                    Button7.Visible = True
                    Label36.Visible = False
                    Label37.Visible = False
                    Button24.Visible = False
                    Campo.Visible = True
                    ComboBox_Form_slot.Visible = True
                    ComboBox_Attack_type.Visible = True
                    Button50.Visible = True
                    GroupBox12.Visible = True

                    MsgBox("Sorry, On National Teams only could be convocated Not Transfered!!!!")
                End If




            Else
                Me.Show()
                Button10.Visible = False
                Button11.Visible = False
                Button12.Visible = False
                Button9.Visible = True
                DataGridView_playersOfTeam_2.Visible = False
                Campo.Visible = True
                ComboBox_Form_slot.Visible = True
                ComboBox_Attack_type.Visible = True
                TextBox_Team_Na_2.Visible = False
                Team_id_box_2.Visible = False
                Button7.Visible = True
                Label36.Visible = False
                Label37.Visible = False
                Button24.Visible = False
                Campo.Visible = True
                ComboBox_Form_slot.Visible = True
                ComboBox_Attack_type.Visible = True
                Button50.Visible = True
                GroupBox12.Visible = True
            End If
        Else
            MsgBox("Select origin team please")
        End If
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        If DataGridView_playersOfTeam_2.Rows.Count < 32 And DataGridView_playersOfTeam.Rows.Count > 16 Then

            Dim dorsal As Integer = DataGridView_playersOfTeam.CurrentRow.Cells(2).Value
            Dim repetido As Boolean = False
            Dim usados As New List(Of Integer)
            Dim Team_Origen As UInt32 = Convert.ToUInt32(Team_id_box.Text)

            Dim Team_destino As UInt32 = Convert.ToUInt32(Team_id_box_2.Text)
            Dim Equipo_origenIndex As UInteger = ListBox3.SelectedIndex

            For i = 0 To DataGridView_playersOfTeam_2.Rows.Count - 1
                usados.Add(DataGridView_playersOfTeam_2.Rows(i).Cells(2).Value)

                If DataGridView_playersOfTeam_2.Rows(i).Cells(2).Value = dorsal Then
                    repetido = True
                End If
            Next
            If repetido = True Then
                dorsal = 1

                While (usados.Contains(dorsal))
                    dorsal += 1
                End While

            End If

            DataGridView_playersOfTeam_2.Rows.Add(DataGridView_playersOfTeam_2.Rows.Count, DataGridView_playersOfTeam.CurrentRow.Cells(1).Value, dorsal, 0, 0, 0, 0, 0, 0, DataGridView_playersOfTeam.CurrentRow.Cells(9).Value, DataGridView_playersOfTeam.CurrentRow.Cells(10).Value, DataGridView_playersOfTeam.CurrentRow.Cells(11).Value)

            'copio los datos del 1 al 2 poniendo 0 en lo de capitan y lanzador.
            'mirar si tienen algo de capitan o lanzador para ponerselo a otro y borrar la fila.
            If DataGridView_playersOfTeam.CurrentRow.Cells(3).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(3).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(3).Value = 1
                End If
            End If
            If DataGridView_playersOfTeam.CurrentRow.Cells(4).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(4).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(4).Value = 1
                End If
            End If
            If DataGridView_playersOfTeam.CurrentRow.Cells(5).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(5).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(5).Value = 1
                End If
            End If
            If DataGridView_playersOfTeam.CurrentRow.Cells(6).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(6).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(6).Value = 1
                End If
            End If
            If DataGridView_playersOfTeam.CurrentRow.Cells(7).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(7).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(7).Value = 1
                End If
            End If
            If DataGridView_playersOfTeam.CurrentRow.Cells(8).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(8).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(8).Value = 1
                End If
            End If



            Dim fila_actual As Integer = DataGridView_playersOfTeam.CurrentRow.Index
            DataGridView_playersOfTeam.Rows.Remove(DataGridView_playersOfTeam.CurrentRow)
            For i = fila_actual To DataGridView_playersOfTeam.Rows.Count - 1
                DataGridView_playersOfTeam.Rows(i).Cells(0).Value = DataGridView_playersOfTeam.Rows(i).Cells(0).Value - 1
            Next

            ListBox3.SelectedIndex = Equipo_origenIndex


        Else
            MsgBox("Team Full or few players, delete or add players")
        End If


    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        If DataGridView_playersOfTeam.Rows.Count < 32 And DataGridView_playersOfTeam_2.Rows.Count > 16 Then
            If CheckBox97.Checked = False Then

                Dim dorsal As Integer = DataGridView_playersOfTeam_2.CurrentRow.Cells(2).Value
                Dim repetido As Boolean = False
                Dim usados As New List(Of Integer)
                Dim Team_Origen As UInt32 = Convert.ToUInt32(Team_id_box_2.Text)
                Dim Team_destino As UInt32 = Convert.ToUInt32(Team_id_box.Text)
                Dim Equipo_origenIndex As UInteger = combo1_selec_index

                For i = 0 To DataGridView_playersOfTeam.Rows.Count - 1
                    usados.Add(DataGridView_playersOfTeam.Rows(i).Cells(2).Value)

                    If DataGridView_playersOfTeam.Rows(i).Cells(2).Value = dorsal Then
                        repetido = True
                    End If
                Next
                If repetido = True Then
                    dorsal = 1

                    While (usados.Contains(dorsal))
                        dorsal += 1
                    End While

                End If

                DataGridView_playersOfTeam.Rows.Add(DataGridView_playersOfTeam.Rows.Count, DataGridView_playersOfTeam_2.CurrentRow.Cells(1).Value, dorsal, 0, 0, 0, 0, 0, 0, DataGridView_playersOfTeam_2.CurrentRow.Cells(9).Value, DataGridView_playersOfTeam_2.CurrentRow.Cells(10).Value, DataGridView_playersOfTeam_2.CurrentRow.Cells(11).Value)



                'copio los datos del 1 al 2 poniendo 0 en lo de capitan y lanzador.
                'mirar si tienen algo de capitan o lanzador para ponerselo a otro y borrar la fila.
                If DataGridView_playersOfTeam_2.CurrentRow.Cells(3).Value = 1 Then
                    If DataGridView_playersOfTeam_2.CurrentRow.Index = 0 Then
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index + 1).Cells(3).Value = 1
                    Else
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index - 1).Cells(3).Value = 1
                    End If
                End If
                If DataGridView_playersOfTeam_2.CurrentRow.Cells(4).Value = 1 Then
                    If DataGridView_playersOfTeam_2.CurrentRow.Index = 0 Then
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index + 1).Cells(4).Value = 1
                    Else
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index - 1).Cells(4).Value = 1
                    End If
                End If
                If DataGridView_playersOfTeam_2.CurrentRow.Cells(5).Value = 1 Then
                    If DataGridView_playersOfTeam_2.CurrentRow.Index = 0 Then
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index + 1).Cells(5).Value = 1
                    Else
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index - 1).Cells(5).Value = 1
                    End If
                End If
                If DataGridView_playersOfTeam_2.CurrentRow.Cells(6).Value = 1 Then
                    If DataGridView_playersOfTeam_2.CurrentRow.Index = 0 Then
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index + 1).Cells(6).Value = 1
                    Else
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index - 1).Cells(6).Value = 1
                    End If
                End If
                If DataGridView_playersOfTeam_2.CurrentRow.Cells(7).Value = 1 Then
                    If DataGridView_playersOfTeam_2.CurrentRow.Index = 0 Then
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index + 1).Cells(7).Value = 1
                    Else
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index - 1).Cells(7).Value = 1
                    End If
                End If
                If DataGridView_playersOfTeam_2.CurrentRow.Cells(8).Value = 1 Then
                    If DataGridView_playersOfTeam_2.CurrentRow.Index = 0 Then
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index + 1).Cells(8).Value = 1
                    Else
                        DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index - 1).Cells(8).Value = 1
                    End If
                End If



                Dim fila_actual As Integer = DataGridView_playersOfTeam_2.CurrentRow.Index
                DataGridView_playersOfTeam_2.Rows.Remove(DataGridView_playersOfTeam_2.CurrentRow)
                For i = fila_actual To DataGridView_playersOfTeam_2.Rows.Count - 1
                    DataGridView_playersOfTeam_2.Rows(i).Cells(0).Value = DataGridView_playersOfTeam_2.Rows(i).Cells(0).Value - 1
                Next

                combo1_selec_index = Equipo_origenIndex
            Else
                Dim Index_club_2_sel_player As UInt32 = DataGridView_playersOfTeam_2.Rows(DataGridView_playersOfTeam_2.CurrentRow.Index).Cells(10).Value
                Dim List_players As New List(Of Integer)
                'caso de selección nacional
                For j = 0 To DataGridView_playersOfTeam.Rows.Count - 1
                    List_players.Add(DataGridView_playersOfTeam.CurrentRow.Cells(10).Value)
                Next
                'comprobar que es un jugador de ese pais y que no esté repetido
                If List_players.Contains(Index_club_2_sel_player) Then

                    MsgBox("Player already on National Team")

                Else
                    Leer_Player.BaseStream.Position = 4
                    For i = 0 To unzlib_Player.Length / Player.tamanho_bloque - 1
                        Leer_Player.BaseStream.Position += 4
                        Dim CHECK_PLAYER As UInt32 = swaps.swap32(Leer_Player.ReadUInt32)

                        If CHECK_PLAYER = Index_club_2_sel_player Then
                            Dim Player_check As New Player
                            Dim index_new_player As UInt32 = i
                            Player_check.Leer_valores_sin_pantalla(index_new_player)
                            If Player_check.country = Convert.ToUInt32(Team_country_box.Text) Then
                                'Hacer traspaso
                                DataGridView_playersOfTeam.CurrentRow.Cells(1).Value = DataGridView_playersOfTeam_2.CurrentRow.Cells(1).Value
                                DataGridView_playersOfTeam.CurrentRow.Cells(10).Value = DataGridView_playersOfTeam_2.CurrentRow.Cells(10).Value.ToString
                                Exit For
                            Else

                                MsgBox("The player of team 2, doesn´t belong to " + TextBox_Team_Na.Text + " Nationality!!!")
                                Exit For
                            End If


                        Else
                            Leer_Player.BaseStream.Position += (Player.tamanho_bloque - 8)
                        End If

                    Next
                End If
            End If


        Else
            MsgBox("Team Full, Please remove player before")
        End If
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        Dim Equipo1_a_grabar As New Team
        Dim equipo2_a_grabar As New Team
        Equipo1_a_grabar.grabar_traspasos_1()
        equipo2_a_grabar.grabar_traspasos_2()
        Dim Selected_team_index As UInt32 = ListBox3.SelectedIndex
        Button10.Visible = False
        Button11.Visible = False
        Button12.Visible = False
        Button9.Visible = True
        Button24.Visible = False
        Button7.Visible = True

        DataGridView_playersOfTeam_2.Rows.Clear()
        DataGridView_playersOfTeam_2.Visible = False
        Campo.Visible = True
        ComboBox_Form_slot.Visible = True
        ComboBox_Attack_type.Visible = True
        TextBox_Team_Na_2.Visible = False
        Team_id_box_2.Visible = False
        Label36.Visible = False
        Label37.Visible = False
        Button50.Visible = True
        GroupBox12.Visible = True
        ListBox3.SelectedIndex = -1
        ListBox3.SelectedIndex = Selected_team_index



    End Sub

    Public marcado As Boolean = False

    Private Sub DataGridView_playersOfTeam_DoubleClick(sender As System.Object, e As System.EventArgs) Handles DataGridView_playersOfTeam.DoubleClick
        If marcado = False Then
            DataGridView_playersOfTeam.CurrentRow.DefaultCellStyle.BackColor = Color.Aquamarine
            marcado = True
        Else
            If DataGridView_playersOfTeam.CurrentRow.DefaultCellStyle.BackColor = Color.Aquamarine Then
                DataGridView_playersOfTeam.CurrentRow.DefaultCellStyle.BackColor = Color.White
                marcado = False
            Else

                Button7.Visible = False
                Button11.Visible = True
                Button24.Visible = True


                Dim Row_aux As New DataGridViewRow
                Dim Current_index As UInt32 = DataGridView_playersOfTeam.CurrentRow.Index
                Dim colored_index As UInt32 = 0
                For i = 0 To DataGridView_playersOfTeam.Rows.Count - 1
                    If DataGridView_playersOfTeam.Rows(i).DefaultCellStyle.BackColor = Color.Aquamarine Then
                        colored_index = i
                        Exit For
                    End If
                Next
                DataGridView_playersOfTeam.Rows.Add(DataGridView_playersOfTeam.Rows.Count, DataGridView_playersOfTeam.Rows(Current_index).Cells(1).Value, DataGridView_playersOfTeam.Rows(Current_index).Cells(2).Value, DataGridView_playersOfTeam.Rows(Current_index).Cells(3).Value, DataGridView_playersOfTeam.Rows(Current_index).Cells(4).Value, DataGridView_playersOfTeam.Rows(Current_index).Cells(5).Value, DataGridView_playersOfTeam.Rows(Current_index).Cells(6).Value, DataGridView_playersOfTeam.Rows(Current_index).Cells(7).Value, DataGridView_playersOfTeam.Rows(Current_index).Cells(8).Value, DataGridView_playersOfTeam.Rows(Current_index).Cells(9).Value, DataGridView_playersOfTeam.Rows(Current_index).Cells(10).Value, DataGridView_playersOfTeam.CurrentRow.Cells(11).Value)

                DataGridView_playersOfTeam.Rows(Current_index).Cells(1).Value = DataGridView_playersOfTeam.Rows(colored_index).Cells(1).Value
                DataGridView_playersOfTeam.Rows(Current_index).Cells(2).Value = DataGridView_playersOfTeam.Rows(colored_index).Cells(2).Value
                DataGridView_playersOfTeam.Rows(Current_index).Cells(10).Value = DataGridView_playersOfTeam.Rows(colored_index).Cells(10).Value


                DataGridView_playersOfTeam.Rows(colored_index).Cells(1).Value = DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.Rows.Count - 1).Cells(1).Value
                DataGridView_playersOfTeam.Rows(colored_index).Cells(2).Value = DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.Rows.Count - 1).Cells(2).Value
                DataGridView_playersOfTeam.Rows(colored_index).Cells(10).Value = DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.Rows.Count - 1).Cells(10).Value


                DataGridView_playersOfTeam.Rows(colored_index).DefaultCellStyle.BackColor = Color.White
                DataGridView_playersOfTeam.Rows.RemoveAt(DataGridView_playersOfTeam.Rows.Count - 1)

                marcado = False
            End If
        End If



    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click

        If MsgBox("Aru You sure you what to delete player from team? " & DataGridView_playersOfTeam.CurrentRow.Cells(1).Value.ToString & " ?", MsgBoxStyle.YesNo, "Delete player") = MsgBoxResult.Yes Then



            Dim Player_Ass_to_delete As UInt32 = DataGridView_playersOfTeam.CurrentRow.Cells(9).Value
            Dim unzlib_player_Assignament_aux As New MemoryStream
            Dim Grabar_Player_Assignament_aux As New BinaryWriter(unzlib_player_Assignament_aux)



            Leer_Player_Assignament.BaseStream.Position = 0

            Dim index_a_borrar As UInt32 = swaps.swap32(Leer_Player_Assignament.ReadUInt32)

            'mirar si tienen algo de capitan o lanzador para ponerselo a otro y borrar la fila.
            If DataGridView_playersOfTeam.CurrentRow.Cells(3).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(3).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(3).Value = 1
                End If
            End If
            If DataGridView_playersOfTeam.CurrentRow.Cells(4).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(4).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(4).Value = 1
                End If
            End If
            If DataGridView_playersOfTeam.CurrentRow.Cells(5).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(5).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(5).Value = 1
                End If
            End If
            If DataGridView_playersOfTeam.CurrentRow.Cells(6).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(6).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(6).Value = 1
                End If
            End If
            If DataGridView_playersOfTeam.CurrentRow.Cells(7).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(7).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(7).Value = 1
                End If
            End If
            If DataGridView_playersOfTeam.CurrentRow.Cells(8).Value = 1 Then
                If DataGridView_playersOfTeam.CurrentRow.Index = 0 Then
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index + 1).Cells(8).Value = 1
                Else
                    DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index - 1).Cells(8).Value = 1
                End If
            End If


            While index_a_borrar <> Player_Ass_to_delete
                Leer_Player_Assignament.BaseStream.Position += 12
                index_a_borrar = swaps.swap32(Leer_Player_Assignament.ReadUInt32)
            End While


            Dim Posicion_a_borrar As UInt32 = Leer_Player_Assignament.BaseStream.Position - 4
            Leer_Player_Assignament.BaseStream.Position = 0

            While unzlib_Player_Assignament.Position < Posicion_a_borrar
                Grabar_Player_Assignament_aux.Write(Leer_Player_Assignament.ReadByte)
            End While


            Leer_Player_Assignament.BaseStream.Position += 16

            While Leer_Player_Assignament.BaseStream.Position < (unzlib_Player_Assignament.Length)
                Grabar_Player_Assignament_aux.Write(Leer_Player_Assignament.ReadByte)

            End While




            unzlib_Player_Assignament.Close()
            unzlib_Player_Assignament = New MemoryStream
            unzlib_player_Assignament_aux.Position = 0
            unzlib_player_Assignament_aux.CopyTo(unzlib_Player_Assignament)
            unzlib_player_Assignament_aux.Close()
            Leer_Player_Assignament = New BinaryReader(unzlib_Player_Assignament)
            Grabar_Player_Assignament = New BinaryWriter(unzlib_Player_Assignament)


            DataGridView_playersOfTeam.Rows.RemoveAt(DataGridView_playersOfTeam.CurrentRow.Index)

            Dim Equipo1_a_grabar As New Team

            Equipo1_a_grabar.grabar_traspasos_1()
            Dim Selected_team_index As UInt32 = ListBox3.SelectedIndex
            ListBox3.SelectedIndex = -1
            ListBox3.SelectedIndex = Selected_team_index

            MsgBox("Player set as free Player succesfully")




        End If


    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        ComboBox1_Click(ComboBox1, Nothing)
    End Sub

    Private Sub Team_stadium_box_Click(sender As System.Object, e As System.EventArgs) Handles Team_stadium_box.Click

        If ListBox3.SelectedIndex <> -1 Then



            MsgBox("Select the new Stadium by doubleclick on cell")
            Estadio_elegido = Team_stadium_box.Text
            Me.Hide()

            seleccionar_estadio.ShowDialog()



            Team_stadium_box.Text = Estadio_elegido

            For i = 0 To DataGridView_Stadium.Rows.Count - 1
                If DataGridView_Stadium.Rows(i).Cells(0).Value = Estadio_elegido Then
                    TextBox_stadium_name.Text = DataGridView_Stadium.Rows(i).Cells(1).Value
                End If

            Next



        Else
            MsgBox("Select a Team Before!")
        End If

    End Sub

    Private Sub DataGridView_problemas_estadios_Click(sender As System.Object, e As System.EventArgs)
        Team_stadium_box_Click(Team_stadium_box, Nothing)
    End Sub

    Private Sub Team_index_box_Click(sender As System.Object, e As System.EventArgs) Handles COach_id_box.Click

        If ListBox3.SelectedIndex <> -1 Then



            MsgBox("Select the new Coach by doubleclick on cell")
            Coach_elegido = COach_id_box.Text
            Me.Hide()

            Select_a_Coach.ShowDialog()



            COach_id_box.Text = Coach_elegido

            For i = 0 To DataGridView_coach.Rows.Count - 1
                If DataGridView_coach.Rows(i).Cells(0).Value = Coach_elegido Then
                    Label43.Text = DataGridView_coach.Rows(i).Cells(1).Value
                End If

            Next



        Else
            MsgBox("Select a Team Before!")
        End If

    End Sub

    Private Sub Non_playable_league_box_Click(sender As System.Object, e As System.EventArgs) Handles Non_playable_team_box.Click
        If ListBox3.SelectedIndex <> -1 Then
            MsgBox("Select the new non playable league")
            Liga_nojugable_elegida = Non_playable_team_box.Value
            Me.Hide()
            Select_other_league.ShowDialog()

            Non_playable_team_box.Text = Liga_nojugable_elegida

            Select Case Liga_nojugable_elegida

                Case 1
                    Label41.Text = "Classic Teams"
                Case 2
                    Label41.Text = "Other Europe League"
                Case 3
                    Label41.Text = "Other Asian League"
                Case 4
                    Label41.Text = "Hidden Fake European Teams"
                Case 5
                    Label41.Text = "ML Hidden teams"
                Case 6
                    Label41.Text = "Other America League"
                Case 7
                    Label41.Text = "Other Africa League"

                Case Else
                    Label41.Text = "No one non playable League"

            End Select

        Else
            MsgBox("Select a Team Before!")
        End If
    End Sub

    Private Sub Team_country_box_Click(sender As System.Object, e As System.EventArgs) Handles Team_country_box.Click
        If ListBox3.SelectedIndex <> -1 Then



            MsgBox("Select the new Nationality by doubleclick on cell")
            Nationality_elegida = Team_country_box.Text
            Me.Hide()

            Select_a_nationality.ShowDialog()




            Team_country_box.Text = Nationality_elegida

            For i = 0 To DataGridView_Countries.Rows.Count - 1
                If DataGridView_Countries.Rows(i).Cells(0).Value = Nationality_elegida Then
                    Label46.Text = DataGridView_Countries.Rows(i).Cells(1).Value
                End If

            Next



        Else
            MsgBox("Select a Team Before!")
        End If

    End Sub

    Private Sub Label46_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label46.MouseClick
        Team_country_box_Click(Team_country_box, Nothing)
    End Sub

    Private Sub NationalityUP_Down_Click(sender As System.Object, e As System.EventArgs) Handles Nation_box.MouseClick
        If ListBox1.SelectedIndex <> -1 Then



            MsgBox("Select the new Nationality by doubleclick on cell")
            Nationality_elegida = Nation_box.Value.ToString
            Me.Hide()

            Select_a_nationality.ShowDialog()


            Nation_box.Value = Nationality_elegida

            For i = 0 To DataGridView_Countries.Rows.Count - 1
                If DataGridView_Countries.Rows(i).Cells(0).Value = Nationality_elegida Then
                    Label111.Text = DataGridView_Countries.Rows(i).Cells(1).Value
                End If

            Next



        Else
            MsgBox("Select a Player Before!")
        End If

    End Sub

    Private Sub Label45_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        NationalityUP_Down_Click(Nation_box, Nothing)
    End Sub

    Private Sub DataGridView_coach_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView_coach.CellDoubleClick
        Dim coach_elegido As New Coach
        coach_elegido.Leer_valores(DataGridView_coach.CurrentCell.RowIndex)
        ' DataGridView3.Rows.Add(DataGridView_coach.Rows(e.RowIndex).Cells(0).Value, DataGridView_coach.Rows(e.RowIndex).Cells(6).Value, coach_elegido.val1, coach_elegido.val2, coach_elegido.val3, coach_elegido.val4, coach_elegido.val5, coach_elegido.country, coach_elegido.Texto_Nacionalidad, coach_elegido.val7, coach_elegido.val8, coach_elegido.val9, coach_elegido.val10, coach_elegido.val11, coach_elegido.val12, coach_elegido.val13, coach_elegido.val14, coach_elegido.val15)





    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        Try
            If System.IO.File.Exists(Application.StartupPath + "\Files\Team_list_exported.txt") = True Then
                System.IO.File.Delete(Application.StartupPath + "\Files\Team_list_exported.txt")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Dim Archivo_exportado As System.IO.TextWriter = New System.IO.StreamWriter(Application.StartupPath + "\Files\Team_list_exported.txt", False, System.Text.Encoding.Default)

        Leer_Team.BaseStream.Position = 0


        Dim NUm_Equip As UInteger = Leer_Team.BaseStream.Length / Team.tamanho_bloque
        Dim Linea As String = ""

        For i = 0 To NUm_Equip - 1
            Dim Equipo_a_a_leer As New Team
            Equipo_a_a_leer.Leer_valores(i)


            Linea += Equipo_a_a_leer.Id_32.ToString() + ";"
            Linea += Equipo_a_a_leer.Nombre_equipo_english + ";"
            Linea += Equipo_a_a_leer.Nombre_Corto
            Linea += Environment.NewLine.ToString()
        Next

        Linea = Linea.Substring(0, Linea.Length - 1)

        'Write the Text to file
        Archivo_exportado.Write(Linea)
        'Close the Textwrite
        Archivo_exportado.Close()


        MsgBox("file successfully exported to " + Application.StartupPath + "\Files\Team_list_exported.txt")
    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
        Cargando.Show()
        DataGridView_nombres_exportados.Rows.Clear()
        If System.IO.File.Exists(Application.StartupPath + "\Files\Team_list_exported.txt") = True Then

            Dim TextLine As String = ""

            Dim SplitLine() As String

            Try
                Dim objReader As New System.IO.StreamReader(Application.StartupPath + "\Files\Team_list_exported.txt", System.Text.Encoding.Default)

                Do While objReader.Peek() <> -1

                    TextLine = objReader.ReadLine()

                    SplitLine = Split(TextLine, ";")

                    Me.DataGridView_nombres_exportados.Rows.Add(SplitLine)

                Loop

                Leer_Team.BaseStream.Position = 0
                Dim num_bloques As UInteger = Leer_Team.BaseStream.Length / Team.tamanho_bloque

                For i = 0 To num_bloques - 1

                    Dim equipo_a_comprobar As New Team
                    equipo_a_comprobar.Leer_valores(i)

                    For j = 0 To DataGridView_nombres_exportados.Rows.Count - 1
                        If (equipo_a_comprobar.Id_32 = DataGridView_nombres_exportados.Rows(j).Cells(0).Value) And (equipo_a_comprobar.Id_32 <> 4971) Then
                            equipo_a_comprobar.Grabar_nombres_exportados(i, DataGridView_nombres_exportados.Rows(j).Cells(1).Value.ToString, DataGridView_nombres_exportados.Rows(j).Cells(2).Value.ToString)
                            'hacemos que vaya al final.
                            j = DataGridView_nombres_exportados.Rows.Count - 1

                        End If
                    Next


                Next

                Cargando.Hide()

                MsgBox("imported")
            Catch ex As Exception
                MsgBox("An error ocurred sorry, post on evo-web please.")


            End Try





        Else
            MsgBox(Application.StartupPath + "\Files\Team_list_exported.txt" + "File not found sorry.")

        End If



    End Sub

    Private Sub DataGridView_coach_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView_coach.CellEnter
        Text_Coach_sel.Clear()
        Text_COach_type.Clear()
        Text_Equipo_coach_sel.Clear()
        TextNAtion_COach_sel.Clear()
        Label58.Text = ""
        Text_COACHID_SEL.Value = 0
        Text_Team_Coach_ID.Clear()
        Text_ID_SIN_LIC.Clear()


        Dim COach_sel As New Coach
        COach_sel.Leer_valores(DataGridView_coach.CurrentCell.RowIndex)

        Text_Coach_sel.Text = COach_sel.Nombre_entrenador
        Label58.Text = COach_sel.Texto_Nacionalidad
        Text_COach_type.Text = COach_sel.ByteLIC.ToString

        Select Case COach_sel.ByteLIC
            Case 0, 1
                Label56.Text = "licensed Club coach"
            Case 2, 3
                Label56.Text = "licensed NT coach"
            Case 4, 5
                Label56.Text = "Unlicensed Club coach"
            Case 6, 7
                Label56.Text = "unlicensed NT coach"

            Case Else
                Label56.Text = "UnkNown Code"
        End Select
        Text_Team_Coach_ID.Text = COach_sel.Equipo
        Text_Equipo_coach_sel.Text = COach_sel.Nombre_equipo
        TextNAtion_COach_sel.Text = COach_sel.country_16
        Text_COACHID_SEL.Text = COach_sel.Coach_Id.ToString
        Text_ID_SIN_LIC.Text = COach_sel.Id_sin_bytes_lic
    End Sub

    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
        Me.Hide()
        Dim current_id As UInt32 = DataGridView_coach.Rows(DataGridView_coach.CurrentCell.RowIndex).Cells(0).Value
        Select_coach_type.ShowDialog()


        Dim New_Id As UInt32 = Convert.ToUInt32(Text_ID_SIN_LIC.Text) + (Convert.ToUInt32(Text_COach_type.Text) * 131072)
        Dim Check_Changed As Boolean = True


        For i = 0 To DataGridView_coach.Rows.Count - 1
            If New_Id = DataGridView_coach.Rows(i).Cells(0).Value Then
                MsgBox("That ID already exists sorry")
                Text_COach_type.Text = current_id
                Check_Changed = False
            End If


        Next

        If Check_Changed = True Then
            Text_COACHID_SEL.Value = New_Id
            MsgBox("Id succesfully Changed")

        End If

    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        Me.Hide()
        Select_a_team_tocoach.ShowDialog()

    End Sub

    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        Me.Hide()
        Select_Nationality_for_Coach.ShowDialog()

    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        Dim Modded_coach As New Coach
        Modded_coach.Grabar_valores(DataGridView_coach.CurrentCell.RowIndex)
        DataGridView_coach.Rows(DataGridView_coach.CurrentCell.RowIndex).Cells(0).Value = Text_COACHID_SEL.Text
        DataGridView_coach.Rows(DataGridView_coach.CurrentCell.RowIndex).Cells(1).Value = Text_Coach_sel.Text
        DataGridView_coach.Rows(DataGridView_coach.CurrentCell.RowIndex).Cells(2).Value = Text_Equipo_coach_sel.Text
        MsgBox("Changes succesfully applied")
    End Sub

    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        If MsgBox("Do you want To Clone " & DataGridView_coach.Rows(DataGridView_coach.CurrentCell.RowIndex).Cells(1).Value, MsgBoxStyle.YesNo, "Clone Team") = MsgBoxResult.Yes Then
            Leer_Coach.BaseStream.Position = DataGridView_coach.CurrentCell.RowIndex * Coach.tamanho_bloque

            Dim New_coach(Coach.tamanho_bloque) As Byte
            New_coach = Leer_Coach.ReadBytes(Coach.tamanho_bloque)
            Dim posicion_para_grabar As UInteger = unzlib_Coach.Length
            unzlib_Coach.SetLength(unzlib_Coach.Length + New_coach.Length)
            unzlib_Coach.Position = posicion_para_grabar
            unzlib_Coach.Write(New_coach, 0, New_coach.Length)
            Leer_Coach.BaseStream.Position = posicion_para_grabar

            Dim NEW_coachID As UInt32 = 1



            ' index_de_equipo_max += 1
            'Id_de_equipo_max += 1

            Grabar_Coach.Write(swaps.swap32(NEW_coachID))


            DataGridView_coach.Rows.Add(NEW_coachID, "ADDED", "none")



            MsgBox("Coach Added succesfully qith Id: 1" + vbCrLf + "Change ID and Name and other options, be carefull with Bins 1,4 and 5 Have Coaches with ids too :) ")

            DataGridView_coach.Rows(DataGridView_coach.Rows.Count - 1).Selected = True

        End If
    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        If (TextBOX_SEARCH_COACH.Text <> String.Empty) Then

            Dim Indice_comienzo As UInteger = DataGridView_coach.CurrentCell.RowIndex + 1
            If Indice_comienzo > DataGridView_coach.Rows.Count - 1 Then
                Indice_comienzo = 0
            End If
            DataGridView_coach.ClearSelection()
            Dim i As UInteger = 0
            Dim Encontrado As Boolean = False
            ' For i = Indice_comienzo To DataGridView_coach.Rows.Count - 1
            i = Indice_comienzo

            While (Encontrado = False) And (i < DataGridView_coach.Rows.Count - 1)

                For Each cell As DataGridViewCell In DataGridView_coach.Rows(i).Cells
                    If cell.Value.ToString.ToUpper.Contains(TextBOX_SEARCH_COACH.Text.ToUpper) Then
                        'This is the cell we want to select
                        DataGridView_coach.ClearSelection()
                        DataGridView_coach.Rows(i).Selected = True
                        DataGridView_coach.CurrentCell = DataGridView_coach(1, Convert.ToInt32(i))
                        Encontrado = True
                        'Yellow background for all matches
                    End If

                Next
                i += 1

            End While
            ' Next

            If Encontrado = False Then
                MsgBox(TextBOX_SEARCH_COACH.Text + " not found sorry, blame on starvin and smeagol! lol")
                DataGridView_coach.Rows(0).Cells(0).Selected = True
            End If


        End If




    End Sub

    Private Sub TextBOX_SEARCH_COACH_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBOX_SEARCH_COACH.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox3_Click(PictureBox3, Nothing)

        End If
    End Sub

    Private Sub LWF_box_ValueChanged(sender As System.Object, e As System.EventArgs) Handles SS_box.ValueChanged, RWF_box.ValueChanged, LWF_box.ValueChanged, CF_box.ValueChanged

        Dim celda_posicion As NumericUpDown = DirectCast(sender, NumericUpDown)

        Select Case celda_posicion.Value
            Case 0
                celda_posicion.BackColor = Color.White
            Case 1
                celda_posicion.BackColor = Color.MistyRose
            Case 2
                celda_posicion.BackColor = Color.Red
            Case Else
                celda_posicion.BackColor = Color.White

        End Select

    End Sub

    Private Sub AMF_box_ValueChanged(sender As System.Object, e As System.EventArgs) Handles RMF_box.ValueChanged, LMF_box.ValueChanged, DMF_box.ValueChanged, CMF_box.ValueChanged, AMF_box.ValueChanged

        Dim celda_posicion As NumericUpDown = DirectCast(sender, NumericUpDown)

        Select Case celda_posicion.Value
            Case 0
                celda_posicion.BackColor = Color.White
            Case 1
                celda_posicion.BackColor = Color.LightGreen
            Case 2
                celda_posicion.BackColor = Color.Green
            Case Else
                celda_posicion.BackColor = Color.White
        End Select


    End Sub

    Private Sub LB_box_ValueChanged(sender As System.Object, e As System.EventArgs) Handles RB_box.ValueChanged, LB_box.ValueChanged, CB_box.ValueChanged


        Dim celda_posicion As NumericUpDown = DirectCast(sender, NumericUpDown)

        Select Case celda_posicion.Value
            Case 0
                celda_posicion.BackColor = Color.White
            Case 1
                celda_posicion.BackColor = Color.LightBlue
            Case 2
                celda_posicion.BackColor = Color.Blue
            Case Else
                celda_posicion.BackColor = Color.White
        End Select


    End Sub

    Private Sub GK_box_ValueChanged(sender As System.Object, e As System.EventArgs) Handles GK_box.ValueChanged

        Dim celda_posicion As NumericUpDown = DirectCast(sender, NumericUpDown)

        Select Case celda_posicion.Value
            Case 0
                celda_posicion.BackColor = Color.White
            Case 1
                celda_posicion.BackColor = Color.Bisque
            Case 2
                celda_posicion.BackColor = Color.Orange
            Case Else
                celda_posicion.BackColor = Color.White
        End Select
    End Sub

    Private Sub Swerve_box_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Swerve_box.ValueChanged, Stamina_box.ValueChanged, Speed_box.ValueChanged, Reflexes_Box.ValueChanged, Set_piece_taking_box.ValueChanged, Low_pass_box.ValueChanged, Lofted_pass_box.ValueChanged, Kicking_power_box.ValueChanged, Jump_box.ValueChanged, Header_box.ValueChanged, GoalKeeping_box.ValueChanged, Finishing_box.ValueChanged, Explosive_power_box.ValueChanged, Dribling_box.ValueChanged, def_prowess_box.ValueChanged, coverage_box.ValueChanged, Clearing_box.ValueChanged, catching_box.ValueChanged, Body_Balance_box.ValueChanged, Ball_winning_box.ValueChanged, Ball_control_box.ValueChanged, Attacking_Prowess_box.ValueChanged, Physical_Contact_box.ValueChanged
        Dim celda_posicion As NumericUpDown = DirectCast(sender, NumericUpDown)


        If celda_posicion.Value >= 70 And celda_posicion.Value < 80 Then
            celda_posicion.BackColor = Color.Green
        ElseIf celda_posicion.Value >= 80 And celda_posicion.Value < 90 Then
            celda_posicion.BackColor = Color.Yellow
        ElseIf celda_posicion.Value >= 90 And celda_posicion.Value < 95 Then
            celda_posicion.BackColor = Color.Orange
        ElseIf celda_posicion.Value >= 95 Then
            celda_posicion.BackColor = Color.Red
        Else
            celda_posicion.BackColor = Color.White
        End If

    End Sub

    Private Sub Position_box_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Position_box.ValueChanged
        If Position_box.Value = 0 Then
            Position_box.BackColor = Color.Orange
        ElseIf Position_box.Value > 0 And Position_box.Value <= 3 Then
            Position_box.BackColor = Color.Blue
        ElseIf Position_box.Value > 3 And Position_box.Value <= 8 Then
            Position_box.BackColor = Color.Green
        ElseIf Position_box.Value > 8 And Position_box.Value <= 12 Then
            Position_box.BackColor = Color.Red
        Else
            Position_box.BackColor = Color.White

        End If

        Select Case Position_box.Value
            Case &H0
                Label121.Text = "GK"
            Case &H1
                Label121.Text = "CB"
            Case &H2
                Label121.Text = "LB"
            Case &H3
                Label121.Text = "RB"
            Case &H4
                Label121.Text = "DMF"
            Case &H5
                Label121.Text = "CMF"
            Case &H6
                Label121.Text = "LMF"
            Case &H7
                Label121.Text = "RMF"
            Case &H8
                Label121.Text = "AMF"
            Case &H9
                Label121.Text = "LWF"
            Case &HA
                Label121.Text = "RWF"
            Case &HB
                Label121.Text = "SS"
            Case &HC
                Label121.Text = "CF"

            Case Else
                Label121.Text = "Unknown"
        End Select





    End Sub

    Private Sub Nationalized_box_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Nationalized_box.MouseClick
        If ListBox1.SelectedIndex <> -1 Then



            MsgBox("Select the new Nationality by doubleclick on cell")
            Nationality_elegida = Nationalized_box.Value.ToString
            Me.Hide()

            Select_a_nationality.ShowDialog()

            Nationalized_box.Value = Nationality_elegida

            For i = 0 To DataGridView_Countries.Rows.Count - 1
                If DataGridView_Countries.Rows(i).Cells(0).Value = Nationality_elegida Then
                    Label112.Text = DataGridView_Countries.Rows(i).Cells(1).Value
                End If

            Next



        Else
            MsgBox("Select a Player Before!")
        End If

    End Sub

    Private Sub Playing_Style_box_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Playing_Style_box.ValueChanged
        Select Case Playing_Style_box.Value
            Case 0
                Label_playing_style.Text = "N/A"
            Case 1
                Label_playing_style.Text = "Goal Poacher"
            Case 2
                Label_playing_style.Text = "Dummy Runner"
            Case 3
                Label_playing_style.Text = "Fox in the Box"
            Case 4
                Label_playing_style.Text = "Prolific Winger"
            Case 5
                Label_playing_style.Text = "Classic No. 10"
            Case 6
                Label_playing_style.Text = "Hole Player"
            Case 7
                Label_playing_style.Text = "Box-to-Box"
            Case 8
                Label_playing_style.Text = "Anchor Man"
            Case 9
                Label_playing_style.Text = "The Destroyer"
            Case 10
                Label_playing_style.Text = "Extra Frontman"
            Case 11
                Label_playing_style.Text = "Offensive Full-back"
            Case 12
                Label_playing_style.Text = "Defensive Full-back"
            Case 13
                Label_playing_style.Text = "Target Man"
            Case 14
                Label_playing_style.Text = "Creative Playmaker"
            Case 15
                Label_playing_style.Text = "Build Up"
            Case 16
                Label_playing_style.Text = "Offensive Goalkeeper"
            Case 17
                Label_playing_style.Text = "Defensive Goalkeeper"

            Case Else
                Label_playing_style.Text = "Unknown Value"

        End Select
    End Sub

    Private Sub Player_num_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Player_num.ValueChanged
        ID_cambiada = True

    End Sub

    Private Sub Player_num_Leave(sender As System.Object, e As System.EventArgs) Handles Player_num.Leave
        If ID_cambiada = True Then
            Leer_Player.BaseStream.Position = 4
            For i = 0 To unzlib_Player.Length / Player.tamanho_bloque - 1
                Dim Aux_for_check As UInt32 = swaps.swap32(Leer_Player.ReadUInt32)
                If Aux_for_check = Player_num.Value Then
                    MsgBox("Player ID already exists use another one please")
                    Player_num.Value = Player_id_mayor
                    Exit For
                End If
                Leer_Player.BaseStream.Position += (Player.tamanho_bloque - 4)
            Next
            ID_cambiada = False
        End If
    End Sub

    Private Sub CheckBoxFAKE_ID_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles CheckBoxFAKE_ID.MouseClick

        If CheckBoxFAKE_ID.Checked = True Then
            Player_num.Value = Player_num.Value + 262144
        Else
            Player_num.Value = Player_num.Value - 262144
        End If


    End Sub

    Private Sub ListBox_competition_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox_competition.SelectedIndexChanged
        Dim Comp_a_leer As New Competition
        Comp_a_leer.Leer_competition(ListBox_competition.SelectedIndex)
    End Sub

    Private Sub ListBox_comp_Kind_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox_comp_Kind.SelectedIndexChanged
        Dim comp_kind_a_leer As New Competition
        comp_kind_a_leer.Leer_Competition_Kind(ListBox_comp_Kind.SelectedIndex)

    End Sub

    Private Sub ListBox_comp_reg_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox_comp_reg.SelectedIndexChanged
        Dim comp_reg_a_leer As New Competition
        comp_reg_a_leer.Leer_Competition_Reg(ListBox_comp_reg.SelectedIndex)
    End Sub

    Private Sub TextBox_CAPTAIN_DoubleClick(sender As System.Object, e As System.EventArgs) Handles TextBoxPENALTY_KICK.DoubleClick, TextBoxLEFT_CK.DoubleClick, TextBox_SHORT_FOUL.DoubleClick, TextBox_RIGHT_CK.DoubleClick, TextBox_LONG_SHOT.DoubleClick, TextBox_CAPTAIN.DoubleClick
        Dim POS_unica As TextBox = DirectCast(sender, TextBox)

        Dim Jugador_antiguo As String = POS_unica.Text

        Me.Hide()
        Select_a_Player.ShowDialog()
        If TextBox_aux_player.Text <> "" Then
            POS_unica.Text = TextBox_aux_player.Text
        End If
    End Sub

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        Select_a_valid_dorsal_Team.ShowDialog()
    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        Dim Equipo1_a_grabar As New Team
        Dim equipo2_a_grabar As New Team
        Equipo1_a_grabar.grabar_traspasos_1()
        If DataGridView_playersOfTeam_2.Visible = True Then
            equipo2_a_grabar.grabar_traspasos_2()
        End If

        Dim Selected_team_index As UInt32 = ListBox3.SelectedIndex
        Button10.Visible = False
        Button11.Visible = False
        Button12.Visible = False
        Button9.Visible = True
        Button24.Visible = False
        Button7.Visible = True
        DataGridView_playersOfTeam_2.Visible = False
        Campo.Visible = True
        ComboBox_Form_slot.Visible = True
        ComboBox_Attack_type.Visible = True
        TextBox_Team_Na_2.Visible = False
        Team_id_box_2.Visible = False
        Label36.Visible = False
        Label37.Visible = False
        Button50.Visible = True
        GroupBox12.Visible = True
        ListBox3.SelectedIndex = -1
        ListBox3.SelectedIndex = Selected_team_index

        MsgBox("Transfers applied succesfully")

        'Arreglar capitan etc equipo2, y fichaje se pone el primero.



    End Sub

    Private Sub TextBox_CAPTAIN_MouseHover(sender As System.Object, e As System.EventArgs) Handles TextBoxPENALTY_KICK.MouseHover, TextBoxLEFT_CK.MouseHover, TextBox_SHORT_FOUL.MouseHover, TextBox_RIGHT_CK.MouseHover, TextBox_LONG_SHOT.MouseHover, TextBox_CAPTAIN.MouseHover
        Dim texto_cap As TextBox = DirectCast(sender, TextBox)

        Dim tt As New ToolTip()
        tt.SetToolTip(texto_cap, "Doubleclick to change")
    End Sub

    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
        If DataGridView_playersOfTeam.SelectedRows.Count <> 0 Then


            Dim Id_jug_seleccionado As UInt32 = DataGridView_playersOfTeam.Rows(DataGridView_playersOfTeam.CurrentRow.Index).Cells(10).Value
            Dim Id_to_search As UInt32 = 0

            Dim Cargando As New SplashScreen1
            Cargando.Show()
            Leer_Player.BaseStream.Position = 4
            For i = 0 To unzlib_Player.Length / Player.tamanho_bloque - 1
                Leer_Player.BaseStream.Position += 4
                Id_to_search = swaps.swap32(Leer_Player.ReadUInt32())
                If Id_to_search = Id_jug_seleccionado Then
                    ListBox1.SelectedIndex = i
                    TabControl1.SelectedTab = TabPage1
                    Cargando.Close()
                    Exit For
                Else
                    Leer_Player.BaseStream.Position += Player.tamanho_bloque - 8
                    If i > unzlib_Player.Length / Player.tamanho_bloque - 1 Then
                        MsgBox("What the fuck! Must be there!!!!!")
                    End If
                End If

            Next

        End If

    End Sub

    Private Sub DataGridView_playersOfTeam_MouseHover(sender As System.Object, e As System.EventArgs) Handles DataGridView_playersOfTeam.MouseHover

        Dim tt As New ToolTip()
        tt.SetToolTip(DataGridView_playersOfTeam, "Doubleclick on player to select and then doubleclick on player to change position")
    End Sub

    Private Sub DataGridView_Countries_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles DataGridView_Countries.SelectionChanged
        Dim Country_a_leer As New Country
        Country_a_leer.Leer_Valores(DataGridView_Countries.CurrentRow.Index)

    End Sub

    Private Sub CheckBox99_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox99.CheckedChanged
        If CheckBox99.Checked = False Then
            CheckBox100.Checked = False
        Else
            CheckBox100.Checked = True
        End If
    End Sub

    Private Sub CheckBox100_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox100.CheckedChanged
        If CheckBox100.Checked = False Then
            CheckBox99.Checked = False
        Else
            CheckBox99.Checked = True
        End If
    End Sub

    Private Sub TextBox_team_name_MouseHover(sender As System.Object, e As System.EventArgs) Handles TextBox_team_name.MouseHover

        Dim tt As New ToolTip()
        tt.SetToolTip(TextBox_team_name, "Click on player to transfer or edit his values on Team Tab")

    End Sub

    Private Sub TextBox_team_name_2_MouseHover(sender As System.Object, e As System.EventArgs) Handles TextBox_team_name_2.MouseHover

        Dim tt As New ToolTip()
        tt.SetToolTip(TextBox_team_name_2, "Click on player to transfer or edit his values on Team Tab")

    End Sub

    'Código para convertir la primera letra de cada palabra en mayúscula y el resto en minusculas
    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        If MsgBox("Do you want To Change Player and Team Names To only first one capital Letter? ", MsgBoxStyle.YesNo, "Change Names") = MsgBoxResult.Yes Then

            Cargando.Show()

            Leer_Player.BaseStream.Position = Player.Nombre_pos
            For i = 0 To ((unzlib_Player.Length / Player.tamanho_bloque) - 1)
                Dim Posicion_previa As UInt32 = Leer_Player.BaseStream.Position
                Dim Nombre_a_cambiar As String = Leer_Player.ReadChars(44)
                Nombre_a_cambiar = Nombre_a_cambiar.TrimEnd("")
                Nombre_a_cambiar = StrConv(Nombre_a_cambiar, 3)
                Leer_Player.BaseStream.Position = Posicion_previa
                Grabar_player.Write(Nombre_a_cambiar.ToCharArray)
                Leer_Player.BaseStream.Position = Posicion_previa + Player.tamanho_bloque
            Next

            For i = 0 To ListBox3.Items.Count - 1
                ListBox3.SelectedIndex = i
                TextBox_Team_Na.Text = StrConv(TextBox_Team_Na.Text, 3)
                Dim Team_modif As New Team
                Team_modif.Grabar_valores(ListBox3.SelectedIndex)

            Next

            Cargando.Hide()

            MsgBox("FINISHED")

        End If


    End Sub

    Private Sub PictureBoxSkin_col_Click(sender As System.Object, e As System.EventArgs) Handles PictureBoxSkin_col.Click
        If PLayer_Appareance_present = False Then
            MsgBox("Playerappareance not found, be sure is in same files than pesdb and it´s unzlib")

        Else

            skincol = Skin_box.Value
            If skincol < 20 Then

                Me.Hide()
                Select_Skin_colour.ShowDialog()
                Select Case skincol
                    Case 0
                        PictureBoxSkin_col.Image = My.Resources._7
                        Skin_box.Value = 0
                    Case 1
                        PictureBoxSkin_col.Image = My.Resources._01
                        Skin_box.Value = 1
                    Case 2
                        PictureBoxSkin_col.Image = My.Resources._02
                        Skin_box.Value = 2
                    Case 3
                        PictureBoxSkin_col.Image = My.Resources._3
                        Skin_box.Value = 3
                    Case 4
                        PictureBoxSkin_col.Image = My.Resources._4
                        Skin_box.Value = 4
                    Case 5
                        PictureBoxSkin_col.Image = My.Resources._5
                        Skin_box.Value = 5
                    Case 6
                        PictureBoxSkin_col.Image = My.Resources._06
                        Skin_box.Value = 6
                    Case 7
                        PictureBoxSkin_col.Image = My.Resources._7
                        Skin_box.Value = 7

                End Select
                skincol = 20
            End If


        End If

    End Sub

    Private Sub DataGridView_tactics_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles DataGridView_tactics.CurrentCellChanged

        Dim Tactic_a_mirar As New Tactics
        Tactic_a_mirar.Leer_Valores(DataGridView_tactics.CurrentRow.Index)
    End Sub

    Private Sub Button27_Click(sender As System.Object, e As System.EventArgs) Handles Button27.Click
        Dim Tactics_a_grabar As New Tactics
        Tactics_a_grabar.Grabar_Valores(DataGridView_tactics.CurrentRow.Index)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://www.evo-web.co.uk/threads/dino-editor-2018-v-beta-0-1-21-09-17-pc-xbox360-ps3-support.77968/")
    End Sub

    Private Sub Button28_Click(sender As System.Object, e As System.EventArgs) Handles Button28.Click
        If ListBox1.SelectedIndex <> -1 Then
            Dim Byte_array_Export As Byte()
            Leer_Player.BaseStream.Position = ListBox1.SelectedIndex * Player.tamanho_bloque
            Byte_array_Export = Leer_Player.ReadBytes(Player.tamanho_bloque)
            Dim Nombre_archivo As String = Player_num.Value.ToString + "_" + Shirt_name.Text.ToString + ".exported"
            Try
                If System.IO.File.Exists(Application.StartupPath + "\Files\" + Nombre_archivo) = True Then
                    System.IO.File.Delete(Application.StartupPath + "\Files\" + Nombre_archivo)
                End If
            Catch ex As Exception
                MsgBox(ex)
            End Try
            Dim Stream_a_exportar As FileStream = New FileStream(Application.StartupPath + "\Files\" + Nombre_archivo, FileMode.OpenOrCreate)
            Stream_a_exportar.Write(Byte_array_Export, 0, Byte_array_Export.Length)
            Stream_a_exportar.Close()
            MsgBox(Name_box.Text.ToString + " Succesfully Exported")
        Else
            MsgBox("Select a Player BEFORE :)!!")
        End If

    End Sub

    Private Sub Button29_Click(sender As System.Object, e As System.EventArgs) Handles Button29.Click
        Dim OpenPes As New OpenFileDialog

        OpenPes.Title = "Open A Pes 2016 Exported Player"
        OpenPes.Filter = "*.exported (*.exported)|*.exported"
        OpenPes.Multiselect = True
        If (Directory.Exists(Application.StartupPath + "\Files\")) Then
            OpenPes.InitialDirectory = (Application.StartupPath + "\Files\")
        End If



        If OpenPes.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim number_of_files As Integer = OpenPes.FileNames.Count

            For Each archivo In OpenPes.FileNames

                Dim NombreSinPath As String = Path.GetFileNameWithoutExtension(archivo)
                Dim Id As String = ""
                For Each val As Char In NombreSinPath.ToCharArray()
                    If val = "_" Then
                        Exit For
                    Else
                        Id += val
                    End If
                Next

                Dim ID_A_IMPORTAR As UInt32 = Convert.ToUInt32(Id)
                Dim stream_a_importar As FileStream = New FileStream(archivo, FileMode.Open, FileAccess.Read)
                Dim Leer_archivo As New BinaryReader(stream_a_importar)

                Leer_Player.BaseStream.Position = 0

                For i = 0 To unzlib_Player.Length / Player.tamanho_bloque - 1
                    Leer_Player.BaseStream.Position += 8
                    Dim player_check As UInt32 = swaps.swap32(Leer_Player.ReadUInt32)
                    If player_check = ID_A_IMPORTAR Then
                        Leer_Player.BaseStream.Position -= 12
                        Dim Byte_array As Byte() = Leer_archivo.ReadBytes(Player.tamanho_bloque)
                        Grabar_player.Write(Byte_array, 0, Byte_array.Length)
                        ListBox1.SelectedIndex = i
                        Exit For
                    End If
                    Leer_Player.BaseStream.Position -= 12
                    Leer_Player.BaseStream.Position += Player.tamanho_bloque
                Next


            Next

            MsgBox("Player(s) imported succesfully")
        End If


    End Sub




    Private Sub Button30_Click(sender As System.Object, e As System.EventArgs) Handles Button30.Click
        If (Directory.Exists(Application.StartupPath + "\Files\")) Then
            Cargando.Show()

            Dim lineasCSV As New System.Text.StringBuilder
            Dim lineaActual As String = "New 32byte val;New 32byte 2nd val;Player Id;Weight;Height;Nacionalized;Nation;Early_cross;def_prowess;Clearing;Low_pass;place_kicking;Goal_celeb;LB;coverage;catching;Jump;Header;Ball_control;GK;GoalKeeping;Reflexes;Finishing;Ball_winning;Speed;Penalty_kick;Kicking_power;Dribling;Explosive_power;Stamina;Swerve;Pink_2;Age;Lofted_pass;Physical Contact;Body_Balance;Attacking_Prowess;Weak_foot_use;DMF;Player Develop;Running_arm_mov;Dribling_arm_mov;Corner_kick;FORM;Position;Free_kick;Playing_Style;Pinpoint Crossing;Sombrero;Runing_Hutching;SS;Blue_2;RWF;LMF;RB;LWF;CF;CB;Dribling_hutching;AMF;Weak_foot_acc;RMF;Injury_res;CMF;COM Speeding Bullet;Scotch Move;GK Long Throw;Long Throw;Scissors Feint;Track Back;Super-sub;Rabona;Acrobatic Finishing;Stronger Foot;Knuckle Shot;First-time Shot;COM Incisive Run;CHECK22;Hidden Player;COM Long Ranger ;One-touch Pass;Heel Trick;UNK 27;Man Marking;UNK29; Marseille Turn; Heading;Outside Curler;Captaincy;Malicia;Low Punt Trajectory;COM Trickster;Low Lofted Pass;Fighting Spirit;Flip Flap;Weighted Pass;CHECK3;CHECK4;COM Mazing Run;Acrobatic Clear;COM Long Ball Expert;Cut Behind & Turn; Long Range Drive;Shirt_name;Name"
            lineasCSV.AppendLine(lineaActual.Substring(0, lineaActual.Length))
            lineaActual = String.Empty
            For i = 0 To ListBox1.Items.Count - 1
                Dim Player_a_exp As New Player
                Player_a_exp.Leer_valores(i)
                lineaActual = (Valor_nuevo32_box.Value.ToString + ";" + Valor_nuevo32_2_box.Value.ToString + ";" + Player_num.Value.ToString + ";" + weight_box.Value.ToString + ";" + height_box.Value.ToString + ";" + Nationalized_box.Value.ToString + ";" + Nation_box.Value.ToString + ";" + Player_a_exp.CHECK40.ToString + ";" + def_prowess_box.Value.ToString + ";" + Clearing_box.Value.ToString + ";" + Low_pass_box.Value.ToString + ";" + Set_piece_taking_box.Value.ToString + ";" + Goal_celeb_box.Value.ToString + ";" + LB_box.Value.ToString + ";" + coverage_box.Value.ToString + ";" + catching_box.Value.ToString + ";" + Jump_box.Value.ToString + ";" + Header_box.Value.ToString + ";" + Ball_control_box.Value.ToString + ";" + GK_box.Value.ToString + ";" + GoalKeeping_box.Value.ToString + ";" + Reflexes_Box.Value.ToString + ";" + Finishing_box.Value.ToString + ";" + Ball_winning_box.Value.ToString + ";" + Speed_box.Value.ToString + ";" + Penalty_kick_box.Value.ToString + ";" + Kicking_power_box.Value.ToString + ";" + Dribling_box.Value.ToString + ";" + Explosive_power_box.Value.ToString + ";" + Stamina_box.Value.ToString + ";" + Swerve_box.Value.ToString + ";" + Pink_2_box.Value.ToString + ";" + Age_box.Value.ToString + ";" + Lofted_pass_box.Value.ToString + ";" + Physical_Contact_box.Value.ToString + ";" + Body_Balance_box.Value.ToString + ";" + Attacking_Prowess_box.Value.ToString + ";" + Weak_foot_use_box.Value.ToString + ";" + DMF_box.Value.ToString + ";" + ulti_nuevo_box.Value.ToString + ";" + Running_arm_mov_box.Value.ToString + ";" + Dribling_arm_mov_box.Value.ToString + ";" + Corner_kick_box.Value.ToString + ";" + FORM_box.Value.ToString + ";" + Position_box.Value.ToString + ";" + Free_kick_box.Value.ToString + ";" + Playing_Style_box.Value.ToString + ";" + Player_a_exp.CHECK2.ToString + ";" + Player_a_exp.CHECK1.ToString + ";" + Runing_Hutching_box.Value.ToString + ";" + SS_box.Value.ToString + ";" + blue_2_box.Value.ToString + ";" + RWF_box.Value.ToString + ";" + LMF_box.Value.ToString + ";" + RB_box.Value.ToString + ";" + LWF_box.Value.ToString + ";" + CF_box.Value.ToString + ";" + CB_box.Value.ToString + ";" + Dribling_hutching_box.Value.ToString + ";" + AMF_box.Value.ToString + ";" + Weak_foot_acc_box.Value.ToString + ";" + RMF_box.Value.ToString + ";" + Injury_res__box.Value.ToString + ";" + CMF_box.Value.ToString + ";" + Player_a_exp.CHECK142.ToString + ";" + Player_a_exp.CHECK9.ToString + ";" + Player_a_exp.CHECK10.ToString + ";" + Player_a_exp.CHECK11.ToString + ";" + Player_a_exp.CHECK12.ToString + ";" + Player_a_exp.CHECK13.ToString + ";" + Player_a_exp.CHECK14.ToString + ";" + Player_a_exp.CHECK15.ToString + ";" + Player_a_exp.CHECK16.ToString + ";" + Player_a_exp.CHECK25.ToString + ";" + Player_a_exp.CHECK17.ToString + ";" + Player_a_exp.CHECK19.ToString + ";" + Player_a_exp.CHECK20.ToString + ";" + Player_a_exp.CHECK21.ToString + ";" + Player_a_exp.CHECK22.ToString + ";" + Player_a_exp.CHECK23.ToString + ";" + Player_a_exp.CHECK24.ToString + ";" + Player_a_exp.CHECK18.ToString + ";" + Player_a_exp.CHECK26.ToString + ";" + Player_a_exp.CHECK27.ToString + ";" + Player_a_exp.CHECK28.ToString + ";" + Player_a_exp.CHECK29.ToString + ";" + Player_a_exp.CHECK30.ToString + ";" + Player_a_exp.CHECK31.ToString + ";" + Player_a_exp.CHECK32.ToString + ";" + Player_a_exp.CHECK33.ToString + ";" + Player_a_exp.CHECK34.ToString + ";" + Player_a_exp.CHECK35.ToString + ";" + Player_a_exp.CHECK36.ToString + ";" + Player_a_exp.CHECK37.ToString + ";" + Player_a_exp.CHECK38.ToString + ";" + Player_a_exp.CHECK39.ToString + ";" + Player_a_exp.CHECK3.ToString + ";" + Player_a_exp.CHECK4.ToString + ";" + Player_a_exp.CHECK5.ToString + ";" + Player_a_exp.CHECK6.ToString + ";" + Player_a_exp.CHECK7.ToString + ";" + Player_a_exp.CHECK8.ToString + ";" + Player_a_exp.CHECK141.ToString + ";" + Shirt_name.Text + ";" + Name_box.Text)
                lineasCSV.AppendLine(lineaActual.Substring(0, lineaActual.Length))
                lineaActual = String.Empty

            Next

            Dim Sys As New System.IO.StreamWriter(Application.StartupPath + "\Files\PLayers_exp.csv", False, Encoding.Default)
            Sys.WriteLine(lineasCSV.ToString)
            Sys.Flush()
            Sys.Dispose()
            Cargando.Hide()

            MsgBox("Exported")
        Else
            MsgBox("Create a folder called Files on app´s folder please")
        End If

    End Sub

    Private Sub Button31_Click(sender As System.Object, e As System.EventArgs) Handles Button31.Click
        If File.Exists(Application.StartupPath + "\Files\PLayers_exp.csv") = True Then
            MsgBox(" Import Player from csv is simple rule, respect values (min, max), respect header(first line), If you only have modded lines will be faster, and if you want to create players, Create before on tool, then modify on csv, then import, Import will be over same ID, example, Player Id, 520, Id on csv must be 520, will not create players if doesn´t exists. You could create 30 players if you want, then export, then modify, then import. Hope is clear, and sorry for my English.")
            Cargando.Show()

            Dim CSV_file As New System.IO.StreamReader(Application.StartupPath + "\Files\PLayers_exp.csv", System.Text.Encoding.Default)
            Dim newline() As String = CSV_file.ReadLine.Split(";"c)
            Dim Datagridview_Aux As New DataGridView
            Datagridview_Aux.ColumnCount = newline.Length
            While (Not CSV_file.EndOfStream)
                newline = CSV_file.ReadLine.Split(";"c)
                Datagridview_Aux.Rows.Add(newline)
            End While


            For i = 0 To ListBox1.Items.Count - 1
                ListBox1.SelectedIndex = i
                For j = 0 To Datagridview_Aux.Rows.Count - 1
                    If Player_num.Value = Datagridview_Aux.Rows(j).Cells(2).Value Then
                        Valor_nuevo32_box.Value = Datagridview_Aux.Rows(j).Cells(0).Value
                        Valor_nuevo32_2_box.Value = Datagridview_Aux.Rows(j).Cells(1).Value
                        Player_num.Value = Datagridview_Aux.Rows(j).Cells(2).Value
                        weight_box.Value = Datagridview_Aux.Rows(j).Cells(3).Value
                        height_box.Value = Datagridview_Aux.Rows(j).Cells(4).Value
                        Nationalized_box.Value = Datagridview_Aux.Rows(j).Cells(5).Value
                        Nation_box.Value = Datagridview_Aux.Rows(j).Cells(6).Value
                        If Datagridview_Aux.Rows(j).Cells(7).Value = 1 Then
                            CheckBox41.Checked = True
                        Else
                            CheckBox41.Checked = False
                        End If
                        def_prowess_box.Value = Datagridview_Aux.Rows(j).Cells(8).Value
                        Clearing_box.Value = Datagridview_Aux.Rows(j).Cells(9).Value
                        Low_pass_box.Value = Datagridview_Aux.Rows(j).Cells(10).Value
                        Set_piece_taking_box.Value = Datagridview_Aux.Rows(j).Cells(11).Value
                        Goal_celeb_box.Value = Datagridview_Aux.Rows(j).Cells(12).Value
                        LB_box.Value = Datagridview_Aux.Rows(j).Cells(13).Value
                        coverage_box.Value = Datagridview_Aux.Rows(j).Cells(14).Value
                        catching_box.Value = Datagridview_Aux.Rows(j).Cells(15).Value
                        Jump_box.Value = Datagridview_Aux.Rows(j).Cells(16).Value
                        Header_box.Value = Datagridview_Aux.Rows(j).Cells(17).Value
                        Ball_control_box.Value = Datagridview_Aux.Rows(j).Cells(18).Value
                        GK_box.Value = Datagridview_Aux.Rows(j).Cells(19).Value
                        GoalKeeping_box.Value = Datagridview_Aux.Rows(j).Cells(20).Value
                        Reflexes_Box.Value = Datagridview_Aux.Rows(j).Cells(21).Value
                        Finishing_box.Value = Datagridview_Aux.Rows(j).Cells(22).Value
                        Ball_winning_box.Value = Datagridview_Aux.Rows(j).Cells(23).Value
                        Speed_box.Value = Datagridview_Aux.Rows(j).Cells(24).Value
                        Penalty_kick_box.Value = Datagridview_Aux.Rows(j).Cells(25).Value
                        Kicking_power_box.Value = Datagridview_Aux.Rows(j).Cells(26).Value
                        Dribling_box.Value = Datagridview_Aux.Rows(j).Cells(27).Value
                        Explosive_power_box.Value = Datagridview_Aux.Rows(j).Cells(28).Value
                        Stamina_box.Value = Datagridview_Aux.Rows(j).Cells(29).Value
                        Swerve_box.Value = Datagridview_Aux.Rows(j).Cells(30).Value
                        FORM_box.Value = Datagridview_Aux.Rows(j).Cells(43).Value
                        Playing_Style_box.Value = Datagridview_Aux.Rows(j).Cells(46).Value
                        Age_box.Value = Datagridview_Aux.Rows(j).Cells(32).Value
                        Lofted_pass_box.Value = Datagridview_Aux.Rows(j).Cells(33).Value
                        Physical_Contact_box.Value = Datagridview_Aux.Rows(j).Cells(34).Value
                        Body_Balance_box.Value = Datagridview_Aux.Rows(j).Cells(35).Value
                        Attacking_Prowess_box.Value = Datagridview_Aux.Rows(j).Cells(36).Value
                        RMF_box.Value = Datagridview_Aux.Rows(j).Cells(61).Value
                        Injury_res__box.Value = Datagridview_Aux.Rows(j).Cells(62).Value
                        CMF_box.Value = Datagridview_Aux.Rows(j).Cells(63).Value
                        Weak_foot_use_box.Value = Datagridview_Aux.Rows(j).Cells(37).Value
                        DMF_box.Value = Datagridview_Aux.Rows(j).Cells(38).Value
                        ulti_nuevo_box.Value = Datagridview_Aux.Rows(j).Cells(39).Value
                        Pink_2_box.Value = Datagridview_Aux.Rows(j).Cells(31).Value
                        Running_arm_mov_box.Value = Datagridview_Aux.Rows(j).Cells(40).Value
                        Dribling_arm_mov_box.Value = Datagridview_Aux.Rows(j).Cells(41).Value
                        Corner_kick_box.Value = Datagridview_Aux.Rows(j).Cells(42).Value
                        Position_box.Value = Datagridview_Aux.Rows(j).Cells(44).Value
                        Free_kick_box.Value = Datagridview_Aux.Rows(j).Cells(45).Value
                        If Datagridview_Aux.Rows(j).Cells(47).Value = 1 Then
                            CheckBox2.Checked = True
                        Else
                            CheckBox2.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(48).Value = 1 Then
                            CheckBox1.Checked = True
                        Else
                            CheckBox1.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(96).Value = 1 Then
                            CheckBox3.Checked = True
                        Else
                            CheckBox3.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(97).Value = 1 Then
                            CheckBox4.Checked = True
                        Else
                            CheckBox4.Checked = False
                        End If
                        
                        If Datagridview_Aux.Rows(j).Cells(98).Value = 1 Then
                            CheckBox5.Checked = True
                        Else
                            CheckBox5.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(99).Value = 1 Then
                            CheckBox6.Checked = True
                        Else
                            CheckBox6.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(100).Value = 1 Then
                            CheckBox7.Checked = True
                        Else
                            CheckBox7.Checked = False
                        End If
                        blue_2_box.Value = Datagridview_Aux.Rows(j).Cells(51).Value
                        SS_box.Value = Datagridview_Aux.Rows(j).Cells(50).Value
                        Runing_Hutching_box.Value = Datagridview_Aux.Rows(j).Cells(49).Value
                        RWF_box.Value = Datagridview_Aux.Rows(j).Cells(52).Value
                        LMF_box.Value = Datagridview_Aux.Rows(j).Cells(53).Value
                        RB_box.Value = Datagridview_Aux.Rows(j).Cells(54).Value
                        LWF_box.Value = Datagridview_Aux.Rows(j).Cells(55).Value
                        CF_box.Value = Datagridview_Aux.Rows(j).Cells(56).Value
                        CB_box.Value = Datagridview_Aux.Rows(j).Cells(57).Value
                        Dribling_hutching_box.Value = Datagridview_Aux.Rows(j).Cells(58).Value
                        AMF_box.Value = Datagridview_Aux.Rows(j).Cells(59).Value
                        Weak_foot_acc_box.Value = Datagridview_Aux.Rows(j).Cells(60).Value
                        If Datagridview_Aux.Rows(j).Cells(64).Value = 1 Then
                            CheckBox112.Checked = True
                        Else
                            CheckBox112.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(65).Value = 1 Then
                            CheckBox9.Checked = True
                        Else
                            CheckBox9.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(66).Value = 1 Then
                            CheckBox10.Checked = True
                        Else
                            CheckBox10.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(67).Value = 1 Then
                            CheckBox11.Checked = True
                        Else
                            CheckBox11.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(68).Value = 1 Then
                            CheckBox12.Checked = True
                        Else
                            CheckBox12.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(69).Value = 1 Then
                            CheckBox13.Checked = True
                        Else
                            CheckBox13.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(70).Value = 1 Then
                            CheckBox14.Checked = True
                        Else
                            CheckBox14.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(71).Value = 1 Then
                            CheckBox15.Checked = True
                        Else
                            CheckBox15.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(72).Value = 1 Then
                            CheckBox16.Checked = True
                        Else
                            CheckBox16.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(80).Value = 1 Then
                            CheckBox24.Checked = True
                        Else
                            CheckBox24.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(74).Value = 1 Then
                            CheckBox17.Checked = True
                        Else
                            CheckBox17.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(75).Value = 1 Then
                            CheckBox19.Checked = True
                        Else
                            CheckBox19.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(76).Value = 1 Then
                            CheckBox20.Checked = True
                        Else
                            CheckBox20.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(77).Value = 1 Then
                            CheckBox21.Checked = True
                        Else
                            CheckBox21.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(78).Value = 1 Then
                            CheckBox22.Checked = True
                        Else
                            CheckBox22.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(79).Value = 1 Then
                            CheckBox23.Checked = True
                        Else
                            CheckBox23.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(73).Value = 1 Then
                            CheckBox25.Checked = True
                        Else
                            CheckBox25.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(81).Value = 1 Then
                            CheckBox18.Checked = True
                        Else
                            CheckBox18.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(82).Value = 1 Then
                            CheckBox26.Checked = True
                        Else
                            CheckBox26.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(83).Value = 1 Then
                            CheckBox27.Checked = True
                        Else
                            CheckBox27.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(84).Value = 1 Then
                            CheckBox28.Checked = True
                        Else
                            CheckBox28.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(85).Value = 1 Then
                            CheckBox29.Checked = True
                        Else
                            CheckBox29.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(86).Value = 1 Then
                            CheckBox30.Checked = True
                        Else
                            CheckBox30.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(87).Value = 1 Then
                            CheckBox31.Checked = True
                        Else
                            CheckBox31.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(88).Value = 1 Then
                            CheckBox32.Checked = True
                        Else
                            CheckBox32.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(89).Value = 1 Then
                            CheckBox33.Checked = True
                        Else
                            CheckBox33.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(90).Value = 1 Then
                            CheckBox34.Checked = True
                        Else
                            CheckBox34.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(91).Value = 1 Then
                            CheckBox35.Checked = True
                        Else
                            CheckBox35.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(92).Value = 1 Then
                            CheckBox36.Checked = True
                        Else
                            CheckBox36.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(93).Value = 1 Then
                            CheckBox37.Checked = True
                        Else
                            CheckBox37.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(94).Value = 1 Then
                            CheckBox38.Checked = True
                        Else
                            CheckBox38.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(95).Value = 1 Then
                            CheckBox39.Checked = True
                        Else
                            CheckBox39.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(101).Value = 1 Then
                            CheckBox8.Checked = True
                        Else
                            CheckBox8.Checked = False
                        End If
                        If Datagridview_Aux.Rows(j).Cells(102).Value = 1 Then
                            CheckBox111.Checked = True
                        Else
                            CheckBox111.Checked = False
                        End If


                        Shirt_name.Text = Datagridview_Aux.Rows(j).Cells(103).Value.ToString
                        Name_box.Text = Datagridview_Aux.Rows(j).Cells(104).Value.ToString

                        ' Paso a Grabar los cambios

                        Dim Player_modif As New Player

                        Player_modif.Grabar_valores(ListBox1.SelectedIndex)

                        Dim Nom_Jugador As String = Shirt_name.Text

                        Dim Seleccionado As UInteger = ListBox1.SelectedIndex
                        ListBox1.Items.RemoveAt(Seleccionado)
                        ListBox1.Items.Insert(Seleccionado, Nom_Jugador)
                        ListBox1.SelectedIndex = Seleccionado

                        Exit For
                    End If



                Next

            Next




            Datagridview_Aux.Rows.Clear()
            CSV_file.Close()
            Cargando.Hide()

            MsgBox("Imported from csv succesfully!!!")




        Else
            MsgBox("Export to CSV before Import, Are we getting mad? lol")
        End If



    End Sub

    Private Sub PictureBox4_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox4.Click
        If (TextBox_SEARCH_TACTICS.Text <> String.Empty) Then

            Dim Indice_comienzo As UInteger = DataGridView_tactics.CurrentCell.RowIndex + 1
            If Indice_comienzo > DataGridView_tactics.Rows.Count - 1 Then
                Indice_comienzo = 0
            End If
            DataGridView_tactics.ClearSelection()
            Dim i As UInteger = 0
            Dim Encontrado As Boolean = False
            ' For i = Indice_comienzo To DataGridView_tactics.Rows.Count - 1
            i = Indice_comienzo

            While (Encontrado = False) And (i < DataGridView_tactics.Rows.Count - 1)

                For Each cell As DataGridViewCell In DataGridView_tactics.Rows(i).Cells
                    If cell.Value.ToString.ToUpper.Contains(TextBox_SEARCH_TACTICS.Text.ToUpper) Then
                        'This is the cell we want to select
                        'cell.Selected = True

                        DataGridView_tactics.ClearSelection()
                        DataGridView_tactics.Rows(i).Selected = True
                        DataGridView_tactics.CurrentCell = DataGridView_tactics(1, Convert.ToInt32(i))
                        Encontrado = True
                        'Yellow background for all matches
                    End If

                Next
                i += 1

            End While
            ' Next

            If Encontrado = False Then
                MsgBox(TextBox_SEARCH_TACTICS.Text + " not found sorry, blame on starvin and smeagol! lol")
                DataGridView_tactics.Rows(0).Cells(0).Selected = True
            End If


        End If



    End Sub

    Private Sub TextBox_SEARCH_TACTICS_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox_SEARCH_TACTICS.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox4_Click(PictureBox4, Nothing)
        End If
    End Sub

    'Public play_selected_index As UInteger
    Private Sub Button32_Click(sender As System.Object, e As System.EventArgs) Handles Button32.Click
        'Me.Hide()
        Cargando.Show()
        Search_player_by.Show()
        'ListBox1.SelectedIndex = play_selected_index

    End Sub


    Private Sub DataGridView_derby_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles DataGridView_derby.SelectionChanged
        NumericUpDown14.Value = DataGridView_derby.CurrentRow.Cells(4).Value
        NumericUpDown15.Value = DataGridView_derby.CurrentRow.Cells(5).Value
        NumericUpDown17.Value = DataGridView_derby.CurrentRow.Cells(6).Value
        NumericUpDown18.Value = DataGridView_derby.CurrentRow.Cells(7).Value

    End Sub

    Private Sub Label168_MouseHover(sender As System.Object, e As System.EventArgs) Handles Label168.MouseHover
        Dim tt As New ToolTip()
        tt.SetToolTip(Label168, "0, Nat Teams and some teams I don´t Know diff between val 1, 1 Geographic derby (spain, Italy etc, 2 Top teams For league ej(BarcavsReal Mad.)")

    End Sub

    Private Sub Button33_Click(sender As System.Object, e As System.EventArgs) Handles Button33.Click


        If MsgBox("Do you want To save changes to derby with: " + vbCrLf + DataGridView_derby.CurrentRow.Cells(1).Value.ToString + DataGridView_derby.CurrentRow.Cells(3).Value, MsgBoxStyle.YesNo, "Add Team") = MsgBoxResult.Yes Then

            DataGridView_derby.CurrentRow.Cells(4).Value = NumericUpDown14.Value
            DataGridView_derby.CurrentRow.Cells(5).Value = NumericUpDown15.Value
            DataGridView_derby.CurrentRow.Cells(6).Value = NumericUpDown17.Value
            DataGridView_derby.CurrentRow.Cells(7).Value = NumericUpDown18.Value
            Dim New_derby As New Derby
            New_derby.Grabar_Valores(DataGridView_derby.CurrentRow.Index)
            MsgBox("Changes applied succesfully")
        End If

    End Sub



    Public chosen_derby_team As UInt32
    Public chosen_derby_team_name As String

    Private Sub DataGridView_derby_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView_derby.CellDoubleClick
        If DataGridView_derby.CurrentCell.ColumnIndex = 1 Or DataGridView_derby.CurrentCell.ColumnIndex = 3 Then
            Me.Hide()
            Select_a_team_toDerby.ShowDialog()


            If DataGridView_derby.CurrentCell.ColumnIndex = 1 Then
                DataGridView_derby.CurrentCell.Value = chosen_derby_team_name
                DataGridView_derby.CurrentRow.Cells(0).Value = chosen_derby_team

            ElseIf DataGridView_derby.CurrentCell.ColumnIndex = 3 Then
                DataGridView_derby.CurrentCell.Value = chosen_derby_team_name
                DataGridView_derby.CurrentRow.Cells(2).Value = chosen_derby_team

            End If
        Else
            MsgBox("Double click on names to change values please")
        End If

    End Sub

    Private Sub PictureBox5_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox5.Click
        If (TextBox_search_derby.Text <> String.Empty) Then

            Dim Indice_comienzo As UInteger = DataGridView_derby.CurrentCell.RowIndex + 1
            If Indice_comienzo > DataGridView_derby.Rows.Count - 1 Then
                Indice_comienzo = 0
            End If
            DataGridView_derby.ClearSelection()
            Dim i As UInteger = 0
            Dim Encontrado As Boolean = False
            ' For i = Indice_comienzo To Datagridview_derby.Rows.Count - 1
            i = Indice_comienzo

            While (Encontrado = False) And (i < DataGridView_derby.Rows.Count - 1)

                For Each cell As DataGridViewCell In DataGridView_derby.Rows(i).Cells
                    If cell.Value.ToString.ToUpper.Contains(TextBox_search_derby.Text.ToUpper) Then
                        'This is the cell we want to select
                        DataGridView_derby.ClearSelection()
                        DataGridView_derby.Rows(i).Selected = True
                        DataGridView_derby.CurrentCell = DataGridView_derby(1, Convert.ToInt32(i))
                        Encontrado = True
                        'Yellow background for all matches
                    End If

                Next
                i += 1

            End While
            ' Next

            If Encontrado = False Then
                MsgBox(TextBox_search_derby.Text + " not found sorry, blame on starvin and smeagol! lol")
                DataGridView_derby.Rows(0).Cells(0).Selected = True
            End If


        End If




    End Sub

    Private Sub TextBox_search_derby_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox_search_derby.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox5_Click(PictureBox5, Nothing)

        End If
    End Sub



    Private Sub Button34_Click(sender As System.Object, e As System.EventArgs) Handles Button34.Click
        Dim New_order As UInteger = Convert.ToUInt32(DataGridView_derby.Rows(DataGridView_derby.Rows.Count - 1).Cells(7).Value)
        New_order = New_order + 1
        Dim new_slot As UInteger = DataGridView_derby.Rows(DataGridView_derby.Rows.Count - 1).Cells(6).Value
        If New_order > 127 Then
            new_slot = new_slot + 1
            New_order = 0
            If new_slot > 3 Then
                MsgBox(" Maximum slots are reached, please eidt, not add more")
            Else
                DataGridView_derby.Rows.Add("", "", "", "", 0, 0, new_slot, New_order)

            End If
        Else
            DataGridView_derby.Rows.Add("", "", "", "", 0, 0, new_slot, New_order)

        End If
    End Sub

    Private Sub Button35_Click(sender As System.Object, e As System.EventArgs) Handles Button35.Click
        If ListBox_competition.SelectedIndex <> -1 Then
            Dim New_comp As New Competition
            New_comp.Grabar_competition(ListBox_competition.SelectedIndex)

            MsgBox("Changes applied Succesfully")
        End If
    End Sub

    Private Sub Button36_Click(sender As System.Object, e As System.EventArgs) Handles Button36.Click
        If ListBox_comp_Kind.SelectedIndex <> -1 Then
            Dim New_comp As New Competition
            New_comp.Grabar_Competition_Kind(ListBox_comp_Kind.SelectedIndex)
            MsgBox("Changes applied Succesfully")
        End If
    End Sub

    Private Sub Button37_Click(sender As System.Object, e As System.EventArgs) Handles Button37.Click
        If ListBox_comp_reg.SelectedIndex <> -1 Then
            Dim New_comp As New Competition
            New_comp.Grabar_Competition_Reg(ListBox_comp_reg.SelectedIndex)
            MsgBox("Changes applied Succesfully")
        End If
    End Sub

    Private Sub UNK4_COMP_REG_BOX_ValueChanged(sender As System.Object, e As System.EventArgs) Handles UNK4_COMP_REG_BOX.ValueChanged
        Select Case (UNK4_COMP_REG_BOX.Value)
            Case 1
                Label146.Text = "playoff ckind"
            Case 2
                Label146.Text = "group stage"
            Case 3
                Label146.Text = "knockout ckind"
            Case 4
                Label146.Text = "league ckind"
            Case 5
                Label146.Text = "league 2 seasons"
            Case 6
                Label146.Text = "quailfacation_1"
            Case 7
                Label146.Text = "quailfacation_2"
            Case 8
                Label146.Text = "practice"
            Case Else
                Label146.Text = "Unknown"

        End Select
    End Sub


    Private Sub DataGridView_Stadium_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles DataGridView_Stadium.SelectionChanged
        If DataGridView_Stadium.Rows.Count > 1 Then
            'leer de nuevo el valor para ver si se cambió bien.
            Stadium_id_box.Value = DataGridView_Stadium.CurrentRow.Cells(0).Value
            Stadium_name_box.Text = DataGridView_Stadium.CurrentRow.Cells(1).Value.ToString
            N_A_stadium_BOX.Value = DataGridView_Stadium.CurrentRow.Cells(2).Value
            Real_stadium_box.Value = DataGridView_Stadium.CurrentRow.Cells(3).Value
            Country_stadium_box.Value = DataGridView_Stadium.CurrentRow.Cells(4).Value
            Label177.Text = DataGridView_Stadium.CurrentRow.Cells(5).Value
            Zone_stadium_box.Value = DataGridView_Stadium.CurrentRow.Cells(6).Value
            Capacity_Stadium_box.Value = DataGridView_Stadium.CurrentRow.Cells(7).Value
            TextBox_jap_name_satdium.Text = DataGridView_Stadium.CurrentRow.Cells(8).Value
            TextBox_prog_name_stadium.Text = DataGridView_Stadium.CurrentRow.Cells(9).Value

        End If
    End Sub

    Private Sub Button39_Click(sender As System.Object, e As System.EventArgs) Handles Button39.Click
        Dim Stadium_a_grabar As New Stadium
        Stadium_a_grabar.Grabar_Valores(DataGridView_Stadium.CurrentRow.Index)
        DataGridView_Stadium.CurrentRow.Cells(0).Value = Stadium_id_box.Value
        DataGridView_Stadium.CurrentRow.Cells(1).Value = Stadium_name_box.Text
        DataGridView_Stadium.CurrentRow.Cells(2).Value = N_A_stadium_BOX.Value
        DataGridView_Stadium.CurrentRow.Cells(3).Value = Real_stadium_box.Value
        DataGridView_Stadium.CurrentRow.Cells(4).Value = Country_stadium_box.Value
        DataGridView_Stadium.CurrentRow.Cells(5).Value = Label177.Text
        DataGridView_Stadium.CurrentRow.Cells(6).Value = Zone_stadium_box.Value
        DataGridView_Stadium.CurrentRow.Cells(7).Value = Capacity_Stadium_box.Value
        DataGridView_Stadium.CurrentRow.Cells(8).Value = TextBox_jap_name_satdium.Text
        DataGridView_Stadium.CurrentRow.Cells(9).Value = TextBox_prog_name_stadium.Text
        DataGridView_Stadium.Rows.Clear()

        Dim bloques As UInteger = unzlib_Stadium.Length / Stadium.tamanho_bloque
        Total_stadium_box.Text = bloques.ToString
        Leer_Stadium.BaseStream.Position = 0





        For i = 0 To bloques - 1
            Dim stadium_to_read As New Stadium
            stadium_to_read.Leer_Valores(i)
            DataGridView_Stadium.Rows.Add(stadium_to_read.Id, stadium_to_read.Nom_Stadium, stadium_to_read.negro, stadium_to_read.Licensed, stadium_to_read.Country, stadium_to_read.Nom_country, stadium_to_read.zone, stadium_to_read.Capacidad, stadium_to_read.Nom_Jap, stadium_to_read.NOM_PROGRAMATIC)

        Next

        MsgBox("Changes applied Succesfully")
        DataGridView_coach.Rows(DataGridView_Stadium.CurrentRow.Index).Selected = True
    End Sub


    Private Sub Zone_stadium_box_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Zone_stadium_box.ValueChanged
        Select Case Zone_stadium_box.Value
            Case 2
                Label180.Text = "EUROPE"
            Case 3
                Label180.Text = "ASIA"
            Case 4
                Label180.Text = "SOUTH AMERICA"
            Case 5
                Label180.Text = "AFRICA"
            Case 6
                Label180.Text = "NORTH AMERICA"
            Case 7
                Label180.Text = "OCEANIA"

        End Select
    End Sub

    Private Sub PictureBox6_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox6.Click
        If (TextBox_stadium_search.Text <> String.Empty) Then

            Dim Indice_comienzo As UInteger = DataGridView_Stadium.CurrentCell.RowIndex + 1
            If Indice_comienzo > DataGridView_Stadium.Rows.Count - 1 Then
                Indice_comienzo = 0
            End If
            DataGridView_Stadium.ClearSelection()
            Dim i As UInteger = 0
            Dim Encontrado As Boolean = False
            ' For i = Indice_comienzo To Datagridview_stadium.Rows.Count - 1
            i = Indice_comienzo

            While (Encontrado = False) And (i < DataGridView_Stadium.Rows.Count - 1)

                For Each cell As DataGridViewCell In DataGridView_Stadium.Rows(i).Cells
                    If cell.Value.ToString.ToUpper.Contains(TextBox_stadium_search.Text.ToUpper) Then
                        'This is the cell we want to select
                        DataGridView_Stadium.ClearSelection()
                        DataGridView_Stadium.Rows(i).Selected = True
                        DataGridView_Stadium.CurrentCell = DataGridView_Stadium(1, Convert.ToInt32(i))
                        Encontrado = True
                        'Yellow background for all matches
                    End If

                Next
                i += 1

            End While
            ' Next

            If Encontrado = False Then
                MsgBox(TextBox_stadium_search.Text + " not found sorry, blame on starvin and smeagol! lol")
                DataGridView_Stadium.Rows(0).Cells(0).Selected = True
            End If


        End If




    End Sub

    Private Sub TextBox_stadium_search_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox_stadium_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox6_Click(PictureBox6, Nothing)

        End If
    End Sub


    Private Sub Button38_Click(sender As System.Object, e As System.EventArgs) Handles Button38.Click
        Dim New_id As UInt32 = 0

        For i = 0 To DataGridView_Stadium.Rows.Count - 1
            If DataGridView_Stadium.CurrentRow.Cells(0).Value > New_id Then
                New_id = DataGridView_Stadium.CurrentRow.Cells(0).Value + 1
            End If
        Next

        DataGridView_Stadium.Rows.Add(New_id, "", 0, 0, 0, "", 0, 0, "", "")

        Dim Zero As Byte = 0

        Grabar_Stadium.BaseStream.Position = unzlib_Stadium.Length

        For i = 0 To 271
            Grabar_Stadium.Write(Zero)
        Next

        DataGridView_Stadium.Rows(DataGridView_Stadium.Rows.Count - 1).Selected = True

    End Sub

    Private Sub Country_stadium_box_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Country_stadium_box.ValueChanged
        For i = 0 To DataGridView_Countries.Rows.Count - 1
            If DataGridView_Countries.Rows(i).Cells(0).Value = Country_stadium_box.Value Then
                Label177.Text = DataGridView_Countries.Rows(i).Cells(1).Value.ToString
            End If
        Next
    End Sub

    Private Sub DataGridView_ball_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles DataGridView_ball.SelectionChanged
        TextBox_ball.Text = DataGridView_ball.CurrentRow.Cells(0).Value
        Ball_id_box.Value = DataGridView_ball.CurrentRow.Cells(1).Value
        Ball_order_box.Value = DataGridView_ball.CurrentRow.Cells(2).Value
    End Sub

    Private Sub Button40_Click(sender As System.Object, e As System.EventArgs) Handles Button40.Click
        Dim Ball_changes As New Ball
        Ball_changes.grabar_Valores(DataGridView_ball.CurrentRow.Index)
        DataGridView_ball.CurrentRow.Cells(0).Value = TextBox_ball.Text
        DataGridView_ball.CurrentRow.Cells(1).Value = Ball_id_box.Value
        DataGridView_ball.CurrentRow.Cells(2).Value = Ball_order_box.Value
        MsgBox("Changes applied succesfully")
    End Sub



    Private Sub Button41_Click(sender As System.Object, e As System.EventArgs) Handles Button41.Click
        Dim New_id As UInt32 = 0
        Dim new_order As UInt32 = 0
        For i = 0 To DataGridView_ball.Rows.Count - 1
            If DataGridView_ball.CurrentRow.Cells(1).Value > New_id Then
                New_id = DataGridView_ball.CurrentRow.Cells(1).Value + 1
            End If
        Next
        For i = 0 To DataGridView_ball.Rows.Count - 1
            If DataGridView_ball.CurrentRow.Cells(2).Value > new_order Then
                new_order = DataGridView_ball.CurrentRow.Cells(1).Value + 1
            End If
        Next
        DataGridView_ball.Rows.Add("", New_id, new_order)

        Dim Zero As Byte = 0

        Grabar_Ball.BaseStream.Position = unzlib_Ball.Length

        For i = 0 To Ball.tamanho_bloque - 1
            Grabar_Ball.Write(Zero)
        Next
        DataGridView_ball.Rows(DataGridView_ball.Rows.Count - 1).Selected = True
    End Sub

    Private Sub DataGridView_ball_condition_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles DataGridView_ball_condition.SelectionChanged
        TextBox_ball_cond.Text = DataGridView_ball_condition.CurrentRow.Cells(0).Value
        Ball_id_cond_box.Value = DataGridView_ball_condition.CurrentRow.Cells(1).Value
        Ball_order_cond_box.Value = DataGridView_ball_condition.CurrentRow.Cells(2).Value
        byte_ball_cond_box.Value = DataGridView_ball_condition.CurrentRow.Cells(3).Value
    End Sub


    Private Sub Button42_Click(sender As System.Object, e As System.EventArgs) Handles Button42.Click
        Dim Ball_changes As New Ball
        Ball_changes.Grabar_Valores_condition(DataGridView_ball_condition.CurrentRow.Index)
        DataGridView_ball_condition.CurrentRow.Cells(0).Value = TextBox_ball_cond.Text
        DataGridView_ball_condition.CurrentRow.Cells(1).Value = Ball_id_cond_box.Value
        DataGridView_ball_condition.CurrentRow.Cells(2).Value = Ball_order_cond_box.Value
        DataGridView_ball_condition.CurrentRow.Cells(3).Value = byte_ball_cond_box.Value

        MsgBox("Changes applied succesfully")
    End Sub

    Private Sub Button43_Click(sender As System.Object, e As System.EventArgs) Handles Button43.Click
        If File.Exists(Application.StartupPath + "\Files\Language.ini") Then

            Dim Selector_lenguaje As New System.IO.StreamReader(Application.StartupPath + "\Files\Language.ini", System.Text.Encoding.Default)

            Show_sel = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_1 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_2 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_3 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_4 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_5 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_6 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_7 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_8 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_9 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_10 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_11 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_12 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_13 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_14 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_15 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Language_read_16 = Convert.ToInt32(Selector_lenguaje.ReadLine)
            Selector_lenguaje.Close()


            Me.Hide()
            Language_sel.ShowDialog()
        Else
            Dim Crear_Selector_lenguaje_save As New System.IO.StreamWriter(Application.StartupPath + "\Files\Language.ini")
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(4)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)
            Crear_Selector_lenguaje_save.WriteLine(0)

            Crear_Selector_lenguaje_save.Close()
            Me.Hide()
            Language_sel.ShowDialog()
        End If

        Dim Selector_lenguaje_save As New System.IO.StreamWriter(Application.StartupPath + "\Files\Language.ini")

        Selector_lenguaje_save.WriteLine(Show_sel)
        Selector_lenguaje_save.WriteLine(Language)
        Selector_lenguaje_save.WriteLine(Language_read_1)
        Selector_lenguaje_save.WriteLine(Language_read_2)
        Selector_lenguaje_save.WriteLine(Language_read_3)
        Selector_lenguaje_save.WriteLine(Language_read_4)
        Selector_lenguaje_save.WriteLine(Language_read_5)
        Selector_lenguaje_save.WriteLine(Language_read_6)
        Selector_lenguaje_save.WriteLine(Language_read_7)
        Selector_lenguaje_save.WriteLine(Language_read_8)
        Selector_lenguaje_save.WriteLine(Language_read_9)
        Selector_lenguaje_save.WriteLine(Language_read_10)
        Selector_lenguaje_save.WriteLine(Language_read_11)
        Selector_lenguaje_save.WriteLine(Language_read_12)
        Selector_lenguaje_save.WriteLine(Language_read_13)
        Selector_lenguaje_save.WriteLine(Language_read_14)
        Selector_lenguaje_save.WriteLine(Language_read_15)
        Selector_lenguaje_save.WriteLine(Language_read_16)

        Selector_lenguaje_save.Close()

    End Sub

    Private Sub DataGridView_boots_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles DataGridView_boots.SelectionChanged
        Boots_Id_box.Value = DataGridView_boots.CurrentRow.Cells(0).Value
        Boots_Order_box.Value = DataGridView_boots.CurrentRow.Cells(1).Value
        TextBox_Boots_Color.Text = DataGridView_boots.CurrentRow.Cells(2).Value
        TextBox_Boots_Material.Text = DataGridView_boots.CurrentRow.Cells(3).Value
        TextBox_Boots_name.Text = DataGridView_boots.CurrentRow.Cells(4).Value
    End Sub

    Private Sub Button45_Click(sender As System.Object, e As System.EventArgs) Handles Button45.Click
        Dim boots_changes As New Boots
        boots_changes.grabar_Valores(DataGridView_boots.CurrentRow.Index)
        DataGridView_boots.CurrentRow.Cells(0).Value = Boots_Id_box.Value
        DataGridView_boots.CurrentRow.Cells(1).Value = Boots_Order_box.Value
        DataGridView_boots.CurrentRow.Cells(2).Value = TextBox_Boots_Color.Text
        DataGridView_boots.CurrentRow.Cells(3).Value = TextBox_Boots_Material.Text
        DataGridView_boots.CurrentRow.Cells(4).Value = TextBox_Boots_name.Text
        MsgBox("Changes applied succesfully")
    End Sub

    Private Sub Button44_Click(sender As System.Object, e As System.EventArgs) Handles Button44.Click
        Dim New_id As UInt32 = 0
        Dim new_order As UInt32 = 0
        For i = 0 To DataGridView_boots.Rows.Count - 1
            If DataGridView_boots.CurrentRow.Cells(0).Value > New_id Then
                New_id = DataGridView_boots.CurrentRow.Cells(0).Value + 1
            End If
        Next
        For i = 0 To DataGridView_boots.Rows.Count - 1
            If DataGridView_boots.CurrentRow.Cells(1).Value > new_order Then
                new_order = DataGridView_boots.CurrentRow.Cells(1).Value + 1
            End If
        Next
        DataGridView_boots.Rows.Add(New_id, new_order, "", "", "")

        Dim Zero As Byte = 0

        Grabar_Boots.BaseStream.Position = unzlib_Boots.Length

        For i = 0 To Boots.tamanho_bloque - 1
            Grabar_Boots.Write(Zero)
        Next
        DataGridView_boots.Rows(DataGridView_boots.Rows.Count - 1).Selected = True
    End Sub

    Private Sub DataGridView_gloves_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles DataGridView_gloves.SelectionChanged
        Gloves_Id_box.Value = DataGridView_gloves.CurrentRow.Cells(0).Value
        Gloves_order_box.Value = DataGridView_gloves.CurrentRow.Cells(1).Value
        TextBox_Gloves_color.Text = DataGridView_gloves.CurrentRow.Cells(2).Value
        TextBox_Gloves_name.Text = DataGridView_gloves.CurrentRow.Cells(3).Value
    End Sub

    Private Sub Button47_Click(sender As System.Object, e As System.EventArgs) Handles Button47.Click
        Dim Gloves_changes As New Gloves
        Gloves_changes.grabar_Valores(DataGridView_gloves.CurrentRow.Index)
        DataGridView_gloves.CurrentRow.Cells(0).Value = Gloves_Id_box.Value
        DataGridView_gloves.CurrentRow.Cells(1).Value = Gloves_order_box.Value
        DataGridView_gloves.CurrentRow.Cells(2).Value = TextBox_Gloves_color.Text
        DataGridView_gloves.CurrentRow.Cells(3).Value = TextBox_Gloves_name.Text
        MsgBox("Changes applied succesfully")
    End Sub

    Private Sub Button46_Click(sender As System.Object, e As System.EventArgs) Handles Button46.Click
        Dim New_id As UInt32 = 0
        Dim new_order As UInt32 = 0
        For i = 0 To DataGridView_gloves.Rows.Count - 1
            If DataGridView_gloves.CurrentRow.Cells(0).Value > New_id Then
                New_id = DataGridView_gloves.CurrentRow.Cells(0).Value + 1
            End If
        Next
        For i = 0 To DataGridView_gloves.Rows.Count - 1
            If DataGridView_gloves.CurrentRow.Cells(1).Value > new_order Then
                new_order = DataGridView_gloves.CurrentRow.Cells(1).Value + 1
            End If
        Next
        DataGridView_gloves.Rows.Add(New_id, new_order, "", "")

        Dim Zero As Byte = 0

        Grabar_Gloves.BaseStream.Position = unzlib_Gloves.Length

        For i = 0 To Gloves.tamanho_bloque - 1
            Grabar_Gloves.Write(Zero)
        Next
        DataGridView_gloves.Rows(DataGridView_gloves.Rows.Count - 1).Selected = True
    End Sub

    Private Sub TextBox_player_boots_name_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TextBox_player_boots_name.MouseClick
        If Boot_List_present = False Then
            MsgBox("BootList.bin not found, be sure is in same files than pesdb")

        Else

            Leer_Boots_list.BaseStream.Position = 0
            Dim Player_ID As UInt32 = Player_num.Value

            Dim Changed As Boolean = False
            For i = 0 To unzlib_Boots_list.Length / 8
                Dim Check_Id As UInt32 = swaps.swap32(Leer_Boots_list.ReadUInt32)
                If Check_Id = Player_ID Then
                    Me.Hide()
                    Select_a_boot.ShowDialog()

                    Exit For

                End If
                If i <> unzlib_Boots_list.Length / 8 - 1 Then
                    Leer_Boots_list.BaseStream.Position += 4

                ElseIf i = unzlib_Boots_list.Length / 8 - 1 Then
                    Dim dlgRes As DialogResult
                    dlgRes = MessageBox.Show("Not info found on BootList.bin, Do you want to add?", "Add BootInfo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If dlgRes = Windows.Forms.DialogResult.Yes Then
                        'Meter botas

                        Dim end_of_file As Byte()
                        Leer_Boots_list.BaseStream.Position = 0

                        For j = 0 To unzlib_Boots_list.Length / 8
                            Dim Check_order As UInt32 = swaps.swap32(Leer_Boots_list.ReadUInt32)
                            If Check_order <= Player_ID Then
                                Leer_Boots_list.BaseStream.Position += 4

                                If j = unzlib_Boots_list.Length / 8 - 1 Then
                                    Me.Hide()
                                    Select_a_boot.ShowDialog()
                                    Leer_Boots_list.BaseStream.Position = unzlib_Boots_list.Length
                                    Grabar_Boots_list.Write(swaps.swap32(Player_ID))
                                    Dim boots_to_add As UInt16 = Player_boots_Id_box.Value
                                    Dim Zero_16 As UInt16 = 0
                                    Grabar_Boots_list.Write(swaps.swap16(boots_to_add))
                                    Grabar_Boots_list.Write(swaps.swap16(Zero_16))
                                    Exit For
                                End If
                            Else
                                Me.Hide()
                                Select_a_boot.ShowDialog()
                                'leer hasta el final
                                Leer_Boots_list.BaseStream.Position -= 4
                                Dim Posicion_a_grabar As ULong = Leer_Boots_list.BaseStream.Position
                                Dim Tamanho_a_leer As ULong = unzlib_Boots_list.Length - Leer_Boots_list.BaseStream.Position
                                end_of_file = Leer_Boots_list.ReadBytes(Tamanho_a_leer)
                                Leer_Boots_list.BaseStream.Position = Posicion_a_grabar
                                Grabar_Boots_list.Write(swaps.swap32(Player_ID))
                                Dim boots_to_add As UInt16 = Player_boots_Id_box.Value
                                Dim Zero_16 As UInt16 = 0
                                Grabar_Boots_list.Write(swaps.swap16(boots_to_add))
                                Grabar_Boots_list.Write(swaps.swap16(Zero_16))
                                Grabar_Boots_list.Write(end_of_file)
                                Exit For
                            End If
                        Next




                        MsgBox("Boots Edited!!")
                        Exit For
                    End If

                End If

            Next







        End If
    End Sub

    Private Sub TextBox_player_gloves_name_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TextBox_player_gloves_name.MouseClick


        If Glove_List_present = False Then
            MsgBox("GloveList.bin not found, be sure is in same files than pesdb")

        Else

            Leer_Gloves_list.BaseStream.Position = 0
            Dim Player_ID As UInt32 = Player_num.Value

            Dim Changed As Boolean = False
            For i = 0 To unzlib_Gloves_list.Length / 8
                Dim Check_Id As UInt32 = swaps.swap32(Leer_Gloves_list.ReadUInt32)
                If Check_Id = Player_ID Then
                    Me.Hide()
                    Select_a_Glove.ShowDialog()

                    Exit For

                End If
                If i <> unzlib_Gloves_list.Length / 8 - 1 Then
                    Leer_Gloves_list.BaseStream.Position += 4

                ElseIf i = unzlib_Gloves_list.Length / 8 - 1 Then
                    Dim dlgRes As DialogResult
                    dlgRes = MessageBox.Show("Not info found on GloveList.bin, Do you want to add?", "Add BootInfo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If dlgRes = Windows.Forms.DialogResult.Yes Then
                        'Meter player appareance

                        Dim end_of_file As Byte()
                        Leer_Gloves_list.BaseStream.Position = 0

                        For j = 0 To unzlib_Gloves_list.Length / 8 - 1
                            Dim Check_order As UInt32 = swaps.swap32(Leer_Gloves_list.ReadUInt32)
                            If Check_order <= Player_ID Then
                                Leer_Gloves_list.BaseStream.Position += 4

                                If j = unzlib_Gloves_list.Length / 8 - 1 Then
                                    Me.Hide()
                                    Select_a_Glove.ShowDialog()
                                    Leer_Gloves_list.BaseStream.Position = unzlib_Gloves_list.Length
                                    Grabar_Gloves_list.Write(swaps.swap32(Player_ID))
                                    Dim Gloves_to_add As UInt16 = Player_Gloves_Id_box.Value
                                    Dim Zero_16 As UInt16 = 0
                                    Grabar_Gloves_list.Write(swaps.swap16(Gloves_to_add))
                                    Grabar_Gloves_list.Write(swaps.swap16(Zero_16))
                                    Exit For
                                End If
                            Else
                                'leer hasta el final
                                Me.Hide()
                                Select_a_Glove.ShowDialog()
                                Leer_Gloves_list.BaseStream.Position -= 4
                                Dim Posicion_a_grabar As ULong = Leer_Gloves_list.BaseStream.Position
                                Dim Tamanho_a_leer As ULong = unzlib_Gloves_list.Length - Leer_Gloves_list.BaseStream.Position
                                end_of_file = Leer_Gloves_list.ReadBytes(Tamanho_a_leer)
                                Leer_Gloves_list.BaseStream.Position = Posicion_a_grabar
                                Grabar_Gloves_list.Write(swaps.swap32(Player_ID))
                                Dim Gloves_to_add As UInt16 = Player_Gloves_Id_box.Value
                                Dim Zero_16 As UInt16 = 0
                                Grabar_Gloves_list.Write(swaps.swap16(Gloves_to_add))
                                Grabar_Gloves_list.Write(swaps.swap16(Zero_16))
                                Grabar_Gloves_list.Write(end_of_file)
                                Exit For
                            End If
                        Next




                        MsgBox("Gloves Edited!!")
                        Exit For
                    End If

                End If

            Next







        End If
    End Sub


    Private Sub Button48_Click(sender As System.Object, e As System.EventArgs) Handles Button48.Click
        Try
            If System.IO.File.Exists(Application.StartupPath + "\Files\Tactics.txt") = True Then
                System.IO.File.Delete(Application.StartupPath + "\Files\Tactics.txt")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Dim Archivo_exportado As System.IO.TextWriter = New System.IO.StreamWriter(Application.StartupPath + "\Files\Tactics.txt", False, System.Text.Encoding.Default)

        Leer_Team.BaseStream.Position = 0


        Dim NUm_Equip As UInteger = Leer_Tactics.BaseStream.Length / 12
        Dim Linea As String = ""

        For i = 0 To NUm_Equip - 1
            Dim Equipo_a_a_leer As New Tactics
            Equipo_a_a_leer.Leer_Valores(i)



            Linea += Equipo_a_a_leer.Team_tactic_id.ToString() + ";"
            Linea += Equipo_a_a_leer.Short_Val.ToString + ";"
            Linea += Environment.NewLine.ToString()
        Next

        Linea = Linea.Substring(0, Linea.Length - 1)

        'Write the Text to file
        Archivo_exportado.Write(Linea)
        'Close the Textwrite
        Archivo_exportado.Close()


        Try
            If System.IO.File.Exists(Application.StartupPath + "\Files\Tactics_f.txt") = True Then
                System.IO.File.Delete(Application.StartupPath + "\Files\Tactics_f.txt")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Dim Archivo_exportado_f As System.IO.TextWriter = New System.IO.StreamWriter(Application.StartupPath + "\Files\Tactics_f.txt", False, System.Text.Encoding.Default)

        Leer_Team.BaseStream.Position = 0


        Dim NUm_Equip_f As UInteger = Leer_Tactics_formation.BaseStream.Length / 12
        Dim Linea_f As String = ""
        Dim Check As UInt16 = 0
        For i = 0 To NUm_Equip_f - 1

            Dim Equipo_a_a_leer_f As New Tactics
            Equipo_a_a_leer_f.Leer_Valores_formation(i)

            If Check <> Equipo_a_a_leer_f.Short_Val_formation Then
                ' Linea += Equipo_a_a_leer_f.Team_tactic_id.ToString() + ";"
                Linea += Equipo_a_a_leer_f.Short_Val_formation.ToString + ";"
                Check = Equipo_a_a_leer_f.Short_Val_formation
                Linea += Environment.NewLine.ToString()
            End If


        Next

        Linea = Linea.Substring(0, Linea.Length - 1)

        'Write the Text to file
        Archivo_exportado_f.Write(Linea)
        'Close the Textwrite
        Archivo_exportado_f.Close()






        MsgBox("file successfully exported to " + Application.StartupPath + "\Files\Team_list_exported.txt")

    End Sub

    Public tipo_jugador As UInt32 = 0


    Public Sub Leer_tactica(ByVal Team_id As UInt32)
        Campo.Controls.Clear()
        ComboBox_Form_slot.Items.Clear()
        ComboBox_Form_slot.Text = "Formation Slot"
        ComboBox_Attack_type.SelectedIndex = 1



        Dim Slot_Tactic1 As UInteger = 0
        Dim Slot_Tactic2 As UInteger = 0
        Leer_Tactics.BaseStream.Position = 0

        For i = 0 To unzlib_Tactics.Length / 12 - 1
            Dim team As UInt32 = swaps.swap32(Leer_Tactics.ReadUInt32)
            If Team_id_box.Text = team Then
                If Slot_Tactic1 = 0 Then
                    Slot_Tactic1 = i
                    NumericUpDownSlot_tact_1.Value = Slot_Tactic1
                Else
                    Slot_Tactic2 = i
                    NumericUpDownSlot_tact_2.Value = Slot_Tactic2
                    Exit For
                End If
                Leer_Tactics.BaseStream.Position += 8

            Else
                Leer_Tactics.BaseStream.Position += 8

            End If
        Next

        Dim Tactic1 As New Tactics
        Tactic1.Leer_Valores(Slot_Tactic1)
        Dim Tactic2 As New Tactics
        Tactic2.Leer_Valores(Slot_Tactic2)

        Dim SlotFormation1 As UInt16 = Tactic1.Short_Val
        Dim SlotFormation2 As UInt16 = Tactic2.Short_Val

        ComboBox_Form_slot.Items.Add(SlotFormation1)
        ComboBox_Form_slot.Items.Add(SlotFormation2)

        If Slot_Tactic1 <> 0 Or Slot_Tactic2 <> 0 Then
            ComboBox_Form_slot.SelectedIndex = 0

        End If


    End Sub



    Private Sub t0_Move(sender As System.Object, e As System.EventArgs) Handles t9.Move, t8.Move, t7.Move, t6.Move, t5.Move, t4.Move, t3.Move, t2.Move, t10.Move, t1.Move, t0.Move
        Dim text_changed As TextBox = DirectCast(sender, TextBox)
        Dim String_pos As String = ""



        Select Case tipo_jugador
            Case &H0
                text_changed.Text = "GK"
                text_changed.BackColor = Color.DarkOrange
            Case &H1
                text_changed.Text = "CB"
                text_changed.BackColor = Color.Blue
            Case &H2
                text_changed.Text = "LB"
                text_changed.BackColor = Color.Blue
            Case &H3
                text_changed.Text = "RB"
                text_changed.BackColor = Color.Blue
            Case &H4
                text_changed.Text = "DMF"
                text_changed.BackColor = Color.DarkGreen
            Case &H5
                text_changed.Text = "CMF"
                text_changed.BackColor = Color.DarkGreen
            Case &H6
                text_changed.Text = "LMF"
                text_changed.BackColor = Color.DarkGreen
            Case &H7
                text_changed.Text = "RMF"
                text_changed.BackColor = Color.DarkGreen
            Case &H8
                text_changed.Text = "AMF"
                text_changed.BackColor = Color.DarkGreen
            Case &H9
                text_changed.Text = "LWF"
                text_changed.BackColor = Color.DarkRed
            Case &HA
                text_changed.Text = "RWF"
                text_changed.BackColor = Color.DarkRed
            Case &HB
                text_changed.Text = "SS"
                text_changed.BackColor = Color.DarkRed
            Case &HC
                text_changed.Text = "CF"
                text_changed.BackColor = Color.DarkRed

            Case Else
                text_changed.Text = "Unknown"
        End Select



    End Sub
    'lee las posiciones de los jugadores
    Public Sub leer_formacion(ByVal Slot_a_leer As UInt16, tipo_form As UInteger)
        Leer_Tactics_formation.BaseStream.Position = 4
        If ComboBox_Form_slot.SelectedIndex = 0 Then
            Dim Tactic As New Tactics
            Tactic.Leer_Valores(NumericUpDownSlot_tact_1.Value)
        Else
            Dim Tactic As New Tactics
            Tactic.Leer_Valores(NumericUpDownSlot_tact_2.Value)
        End If

        For i = 0 To unzlib_Tactics_formation.Length / 12 - 1
            Dim current_slot As UInt16 = swaps.swap16(Leer_Tactics_formation.ReadUInt16)

            If Slot_a_leer = current_slot Then

                Select Case tipo_form
                    Case 0
                        Leer_Tactics_formation.BaseStream.Position -= 6
                        Leer_Tactics_formation.BaseStream.Position += 132
                    Case 1
                        Leer_Tactics_formation.BaseStream.Position -= 6
                    Case 2
                        Leer_Tactics_formation.BaseStream.Position -= 6
                        Leer_Tactics_formation.BaseStream.Position += 264
                End Select


                Exit For
            Else
                Leer_Tactics_formation.BaseStream.Position += 10
            End If

        Next

        Dim Prop_x As Double = Campo.Width / 104
        Dim Prop_y As Double = Campo.Height / 50
        Try


            Dim Player0 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player0
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t0 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t0 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            'LA POSICION POR LA PROPORCION PARA QUE QUEDE IGUAL - LA MITAD DEL TAMAÑO DEL NOMBRE PARA QUE SE CENTRE
            t0.Location = New Point((X_pos_t0 * Prop_x) - (t0.Width / 2), Campo.Height - ((y_pos_t0 * Prop_y) + (t0.Height / 2)))
            'l0.Text = DataGridView_playersOfTeam.Rows(0).Cells(1).Value
            l0.Location = New Point((X_pos_t0 * Prop_x) - (l0.Width / 2), Campo.Height - ((y_pos_t0 * Prop_y) + (t0.Height / 2)) - 15)
            Campo.Controls.Add(l0)
            Campo.Controls.Add(t0)


            Dim Player1 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player1
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t1 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t1 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            t1.Location = New Point((X_pos_t1 * Prop_x) - (t1.Width / 2), Campo.Height - ((y_pos_t1 * Prop_y) + (t1.Height / 2)))
            Campo.Controls.Add(t1)
            'l1.Text = DataGridView_playersOfTeam.Rows(1).Cells(1).Value
            l1.Location = New Point((X_pos_t1 * Prop_x) - (l1.Width / 2), Campo.Height - ((y_pos_t1 * Prop_y) + (t1.Height / 2)) - 15)
            Campo.Controls.Add(l1)

            Dim Player2 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player2
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t2 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t2 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            t2.Location = New Point((X_pos_t2 * Prop_x) - (t2.Width / 2), Campo.Height - ((y_pos_t2 * Prop_y) + (t2.Height / 2)))
            Campo.Controls.Add(t2)
            'l2.Text = DataGridView_playersOfTeam.Rows(2).Cells(1).Value
            l2.Location = New Point((X_pos_t2 * Prop_x) - (l2.Width / 2), Campo.Height - ((y_pos_t2 * Prop_y) + (t2.Height / 2)) - 15)
            Campo.Controls.Add(l2)


            Dim Player3 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player3
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t3 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t3 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            t3.Location = New Point((X_pos_t3 * Prop_x) - (t3.Width / 2), Campo.Height - ((y_pos_t3 * Prop_y) + (t3.Height / 2)))
            Campo.Controls.Add(t3)
            'l3.Text = DataGridView_playersOfTeam.Rows(3).Cells(1).Value
            l3.Location = New Point((X_pos_t3 * Prop_x) - (l3.Width / 2), Campo.Height - ((y_pos_t3 * Prop_y) + (t3.Height / 2)) - 15)
            Campo.Controls.Add(l3)

            Dim Player4 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player4
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t4 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t4 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            t4.Location = New Point((X_pos_t4 * Prop_x) - (t4.Width / 2), Campo.Height - ((y_pos_t4 * Prop_y) + (t4.Height / 2)))
            Campo.Controls.Add(t4)
            'l4.Text = DataGridView_playersOfTeam.Rows(4).Cells(1).Value
            l4.Location = New Point((X_pos_t4 * Prop_x) - (l4.Width / 2), Campo.Height - ((y_pos_t4 * Prop_y) + (t4.Height / 2)) - 15)
            Campo.Controls.Add(l4)

            Dim Player5 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player5
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t5 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t5 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            t5.Location = New Point((X_pos_t5 * Prop_x) - (t5.Width / 2), Campo.Height - ((y_pos_t5 * Prop_y) + (t5.Height / 2)))
            Campo.Controls.Add(t5)
            'l5.Text = DataGridView_playersOfTeam.Rows(5).Cells(1).Value
            l5.Location = New Point((X_pos_t5 * Prop_x) - (l5.Width / 2), Campo.Height - ((y_pos_t5 * Prop_y) + (t5.Height / 2)) - 15)
            Campo.Controls.Add(l5)

            Dim Player6 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player6
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t6 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t6 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            t6.Location = New Point((X_pos_t6 * Prop_x) - (t6.Width / 2), Campo.Height - ((y_pos_t6 * Prop_y) + (t6.Height / 2)))
            Campo.Controls.Add(t6)
            'l6.Text = DataGridView_playersOfTeam.Rows(6).Cells(1).Value
            l6.Location = New Point((X_pos_t6 * Prop_x) - (l6.Width / 2), Campo.Height - ((y_pos_t6 * Prop_y) + (t6.Height / 2)) - 15)
            Campo.Controls.Add(l6)

            Dim Player7 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player7
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t7 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t7 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            t7.Location = New Point((X_pos_t7 * Prop_x) - (t7.Width / 2), Campo.Height - ((y_pos_t7 * Prop_y) + (t7.Height / 2)))
            Campo.Controls.Add(t7)
            'l7.Text = DataGridView_playersOfTeam.Rows(7).Cells(1).Value
            l7.Location = New Point((X_pos_t7 * Prop_x) - (l7.Width / 2), Campo.Height - ((y_pos_t7 * Prop_y) + (t7.Height / 2)) - 15)
            Campo.Controls.Add(l7)

            Dim Player8 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player8
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t8 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t8 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            t8.Location = New Point((X_pos_t8 * Prop_x) - (t8.Width / 2), Campo.Height - ((y_pos_t8 * Prop_y) + (t8.Height / 2)))
            Campo.Controls.Add(t8)
            'l8.Text = DataGridView_playersOfTeam.Rows(8).Cells(1).Value
            l8.Location = New Point((X_pos_t8 * Prop_x) - (l8.Width / 2), Campo.Height - ((y_pos_t8 * Prop_y) + (t8.Height / 2)) - 15)
            Campo.Controls.Add(l8)


            Dim Player9 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player9
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t9 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t9 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            t9.Location = New Point((X_pos_t9 * Prop_x) - (t9.Width / 2), Campo.Height - ((y_pos_t9 * Prop_y) + (t9.Height / 2)))
            Campo.Controls.Add(t9)
            'l9.Text = DataGridView_playersOfTeam.Rows(9).Cells(1).Value
            l9.Location = New Point((X_pos_t9 * Prop_x) - (l9.Width / 2), Campo.Height - ((y_pos_t9 * Prop_y) + (t9.Height / 2)) - 15)
            Campo.Controls.Add(l9)


            Dim Player10 As UInt32 = swaps.swap32(Leer_Tactics_formation.ReadUInt32)
            tipo_jugador = Player10
            Leer_Tactics_formation.BaseStream.Position += 2
            Dim y_pos_t10 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Dim X_pos_t10 As UInteger = Convert.ToUInt32(Leer_Tactics_formation.ReadByte)
            Leer_Tactics_formation.BaseStream.Position += 4
            t10.Location = New Point((X_pos_t10 * Prop_x) - (t10.Width / 2), Campo.Height - ((y_pos_t10 * Prop_y) + (t10.Height / 2)))
            Campo.Controls.Add(t10)

            l10.Location = New Point((X_pos_t10 * Prop_x) - (l10.Width / 2), Campo.Height - ((y_pos_t10 * Prop_y) + (t10.Height / 2)) - 15)
            Campo.Controls.Add(l10)

        Catch ex As Exception
            MsgBox("Sorry, no info found about this team")

        End Try

    End Sub

    Private Sub ComboBox_Attack_type_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox_Form_slot.SelectedIndexChanged, ComboBox_Attack_type.SelectedIndexChanged
        Dim combo_changed As ComboBox = DirectCast(sender, ComboBox)
        If ComboBox_Form_slot.Items.Count > 0 Then
            leer_formacion(Convert.ToUInt16(ComboBox_Form_slot.SelectedItem), ComboBox_Attack_type.SelectedIndex)
        End If

    End Sub
    'Declaramos variables
    Private dragging As Boolean
    Private posicionX, posicionY As Integer

    'Capturamos la posición del control Panel mediante las variables 
    'PosicionX
    'PosicionY
    Private Sub t1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles t1.MouseDown, t2.MouseDown, t3.MouseDown, t4.MouseDown, t5.MouseDown, t6.MouseDown, t7.MouseDown, t8.MouseDown, t9.MouseDown, t10.MouseDown
        Dim tChanged As TextBox = DirectCast(sender, TextBox)
        Select Case tChanged.Text
            Case "GK"
                tipo_jugador = 0
            Case "CB"
                tipo_jugador = 1
            Case "LB"
                tipo_jugador = 2
            Case "RB"
                tipo_jugador = 3
            Case "DMF"
                tipo_jugador = 4
            Case "CMF"
                tipo_jugador = 5
            Case "LMF"
                tipo_jugador = 6
            Case "RMF"
                tipo_jugador = 7
            Case "AMF"
                tipo_jugador = 8
            Case "LWF"
                tipo_jugador = 9
            Case "RWF"
                tipo_jugador = 10
            Case "SS"
                tipo_jugador = 11
            Case "CF"
                tipo_jugador = 12
        End Select

        dragging = True

        posicionX = e.X
        posicionY = e.Y
    End Sub

    Private Sub t1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles t1.MouseMove, t2.MouseMove, t3.MouseMove, t4.MouseMove, t5.MouseMove, t6.MouseMove, t7.MouseMove, t8.MouseMove, t9.MouseMove, t10.MouseMove




        Dim tChanged As TextBox = DirectCast(sender, TextBox)
        Dim lChanged As Label = l1
        Select Case tChanged.Name
            Case "t1"
                lChanged = l1
            Case "t2"
                lChanged = l2
            Case "t3"
                lChanged = l3
            Case "t4"
                lChanged = l4
            Case "t5"
                lChanged = l5
            Case "t6"
                lChanged = l6
            Case "t7"
                lChanged = l7
            Case "t8"
                lChanged = l8
            Case "t9"
                lChanged = l9
            Case "t10"
                lChanged = l10

        End Select




        If dragging = True Then
            ' x: coordenada horizontal del ángulo superior izquierdo del area cliente del formulario
            Dim x As Integer = Campo.Location.X + 20

            ' y: coordenada vertical del ángulo superior izquierdo del area cliente del formulario
            Dim y As Integer = Campo.Location.Y + TabControl1.Location.Y + 20
            ' Creamos el punto que representa el ángulo superior izquierdo
            ' de el area cliente de nuestro formulario
            Dim PuntoInicio As Point = Me.PointToScreen(New Point(x, y))
            'Creamos un rectangulo del tamaño de el area cliente de nuestro formulario



            Dim r As New Rectangle(PuntoInicio, Campo.Size)

            Windows.Forms.Cursor.Clip = r


            tChanged.Location = New Point(tChanged.Location.X + e.X -
            posicionX, tChanged.Location.Y + e.Y - posicionY)

            lChanged.Location = New Point((tChanged.Location.X + e.X -
                       posicionX), (tChanged.Location.Y + e.Y - posicionY) + (tChanged.Height / 2) - 25)

        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles t1.MouseUp, t2.MouseUp, t3.MouseUp, t4.MouseUp, t5.MouseUp, t6.MouseUp, t7.MouseUp, t8.MouseUp, t9.MouseUp, t10.MouseUp

        dragging = False
        Windows.Forms.Cursor.Clip = Nothing
    End Sub

    Private Sub CheckBox103_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox103.CheckedChanged
        If CheckBox103.Checked = True Then
            CheckBox103.Text = "Build up - Short Pass"
        Else
            CheckBox103.Text = "Build up - Long Pass"
        End If
    End Sub

    Private Sub CheckBox104_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox104.CheckedChanged
        If CheckBox104.Checked = True Then
            CheckBox104.Text = "Defensive Style - All Out Deffence"
        Else
            CheckBox104.Text = "Defensive Style - Front Line Pressure"
        End If
    End Sub


    Private Sub CheckBox105_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox105.CheckedChanged
        If CheckBox105.Checked = True Then
            CheckBox105.Text = "Attacking Area - Centre"
        Else
            CheckBox105.Text = "Attacking Area - Wide"
        End If
    End Sub

    Private Sub CheckBox106_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox106.CheckedChanged
        If CheckBox106.Checked = True Then
            CheckBox106.Text = "Containment Area - Wide"
        Else
            CheckBox106.Text = "Containment Area - Middle"
        End If
    End Sub

    Private Sub CheckBox107_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox107.CheckedChanged
        If CheckBox107.Checked = True Then
            CheckBox107.Text = "Pressuring - Conservative"
        Else
            CheckBox107.Text = "Pressuring - Agressive"
        End If
    End Sub

    Private Sub CheckBox108_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox108.CheckedChanged
        If CheckBox108.Checked = True Then
            CheckBox108.Text = "Attacking Style - Possesion game"
        Else
            CheckBox108.Text = "Attacking Style - Counter Attack"
        End If
    End Sub

    Private Sub CheckBox109_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox109.CheckedChanged
        If CheckBox109.Checked = True Then
            CheckBox109.Text = "Fluid Formation - ON"
        Else
            CheckBox109.Text = "Fluid Formation - OFF"
        End If
    End Sub

    Private Sub CheckBox110_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox110.CheckedChanged
        If CheckBox110.Checked = True Then
            CheckBox110.Text = "Positioning - Flexible"
        Else
            CheckBox110.Text = "Positioning - Mantain Formation"
        End If
    End Sub



    Private Sub Button49_Click(sender As System.Object, e As System.EventArgs) Handles Button49.Click
        Dim Tactics_a_grabar As New Tactics
        If ComboBox_Form_slot.SelectedIndex = 0 Then
            Tactics_a_grabar.Grabar_Valores(NumericUpDownSlot_tact_1.Value)
        ElseIf ComboBox_Form_slot.SelectedIndex = 1 Then
            Tactics_a_grabar.Grabar_Valores(NumericUpDownSlot_tact_2.Value)
        Else
            MsgBox("no Tactic Selected or Exist!")
        End If

    End Sub

    Private Sub Button50_Click(sender As System.Object, e As System.EventArgs) Handles Button50.Click

        If ListBox3.SelectedIndex <> -1 And ComboBox_Form_slot.Items.Count > 0 Then
            Leer_Tactics_formation.BaseStream.Position = 4

            For i = 0 To unzlib_Tactics_formation.Length / 12 - 1
                Dim current_slot As UInt16 = swaps.swap16(Leer_Tactics_formation.ReadUInt16)

                If ComboBox_Form_slot.SelectedItem = current_slot Then


                    Select Case ComboBox_Attack_type.SelectedIndex
                        Case 0
                            Leer_Tactics_formation.BaseStream.Position -= 6
                            Leer_Tactics_formation.BaseStream.Position += 132
                        Case 1
                            Leer_Tactics_formation.BaseStream.Position -= 6
                        Case 2
                            Leer_Tactics_formation.BaseStream.Position -= 6
                            Leer_Tactics_formation.BaseStream.Position += 264
                    End Select


                    Exit For
                Else
                    Leer_Tactics_formation.BaseStream.Position += 10
                End If

            Next

            Leer_Tactics_formation.BaseStream.Position += 12

            Dim Prop_x As Double = Campo.Width / 104
            Dim Prop_y As Double = Campo.Height / 50


            Dim NewPosition_x As Integer
            Dim NewPosition_y As Integer
            Dim NewX As Byte
            Dim NewY As Byte
            Dim New_tact_pos As UInt32

            NewPosition_x = (((t1.Location.X + (t1.Width / 2)) / Prop_x))
            NewPosition_y = (((Campo.Height - t1.Location.Y) - (t1.Height / 2)) / Prop_y)
            If NewPosition_x > 98 Then
                NewPosition_x = 98
            End If
            If NewPosition_y > 47 Then
                NewPosition_y = 47
            End If
            NewX = NewPosition_x
            NewY = NewPosition_y
            New_tact_pos = PosJug_to_number(t1.Text)

            Grabar_Tactics_formation.Write(swaps.swap32(New_tact_pos))
            Grabar_Tactics_formation.BaseStream.Position += 2
            Grabar_Tactics_formation.Write(NewY)
            Grabar_Tactics_formation.Write(NewX)
            Grabar_Tactics_formation.BaseStream.Position += 4

            NewPosition_x = (((t2.Location.X + (t2.Width / 2)) / Prop_x))
            NewPosition_y = (((Campo.Height - t2.Location.Y) - (t2.Height / 2)) / Prop_y)
            If NewPosition_x > 98 Then
                NewPosition_x = 98
            End If
            If NewPosition_y > 47 Then
                NewPosition_y = 47
            End If
            NewX = NewPosition_x
            NewY = NewPosition_y
            New_tact_pos = PosJug_to_number(t2.Text)

            Grabar_Tactics_formation.Write(swaps.swap32(New_tact_pos))
            Grabar_Tactics_formation.BaseStream.Position += 2
            Grabar_Tactics_formation.Write(NewY)
            Grabar_Tactics_formation.Write(NewX)
            Grabar_Tactics_formation.BaseStream.Position += 4

            NewPosition_x = (((t3.Location.X + (t3.Width / 2)) / Prop_x))
            NewPosition_y = (((Campo.Height - t3.Location.Y) - (t3.Height / 2)) / Prop_y)
            If NewPosition_x > 98 Then
                NewPosition_x = 98
            End If
            If NewPosition_y > 47 Then
                NewPosition_y = 47
            End If
            NewX = NewPosition_x
            NewY = NewPosition_y
            New_tact_pos = PosJug_to_number(t3.Text)

            Grabar_Tactics_formation.Write(swaps.swap32(New_tact_pos))
            Grabar_Tactics_formation.BaseStream.Position += 2
            Grabar_Tactics_formation.Write(NewY)
            Grabar_Tactics_formation.Write(NewX)
            Grabar_Tactics_formation.BaseStream.Position += 4

            NewPosition_x = (((t4.Location.X + (t4.Width / 2)) / Prop_x))
            NewPosition_y = (((Campo.Height - t4.Location.Y) - (t4.Height / 2)) / Prop_y)
            If NewPosition_x > 98 Then
                NewPosition_x = 98
            End If
            If NewPosition_y > 47 Then
                NewPosition_y = 47
            End If
            NewX = NewPosition_x
            NewY = NewPosition_y
            New_tact_pos = PosJug_to_number(t4.Text)

            Grabar_Tactics_formation.Write(swaps.swap32(New_tact_pos))
            Grabar_Tactics_formation.BaseStream.Position += 2
            Grabar_Tactics_formation.Write(NewY)
            Grabar_Tactics_formation.Write(NewX)
            Grabar_Tactics_formation.BaseStream.Position += 4

            NewPosition_x = (((t5.Location.X + (t5.Width / 2)) / Prop_x))
            NewPosition_y = (((Campo.Height - t5.Location.Y) - (t5.Height / 2)) / Prop_y)
            If NewPosition_x > 98 Then
                NewPosition_x = 98
            End If
            If NewPosition_y > 47 Then
                NewPosition_y = 47
            End If
            NewX = NewPosition_x
            NewY = NewPosition_y
            New_tact_pos = PosJug_to_number(t5.Text)

            Grabar_Tactics_formation.Write(swaps.swap32(New_tact_pos))
            Grabar_Tactics_formation.BaseStream.Position += 2
            Grabar_Tactics_formation.Write(NewY)
            Grabar_Tactics_formation.Write(NewX)
            Grabar_Tactics_formation.BaseStream.Position += 4

            NewPosition_x = (((t6.Location.X + (t6.Width / 2)) / Prop_x))
            NewPosition_y = (((Campo.Height - t6.Location.Y) - (t6.Height / 2)) / Prop_y)
            If NewPosition_x > 98 Then
                NewPosition_x = 98
            End If
            If NewPosition_y > 47 Then
                NewPosition_y = 47
            End If
            NewX = NewPosition_x
            NewY = NewPosition_y
            New_tact_pos = PosJug_to_number(t6.Text)

            Grabar_Tactics_formation.Write(swaps.swap32(New_tact_pos))
            Grabar_Tactics_formation.BaseStream.Position += 2
            Grabar_Tactics_formation.Write(NewY)
            Grabar_Tactics_formation.Write(NewX)
            Grabar_Tactics_formation.BaseStream.Position += 4

            NewPosition_x = (((t7.Location.X + (t7.Width / 2)) / Prop_x))
            NewPosition_y = (((Campo.Height - t7.Location.Y) - (t7.Height / 2)) / Prop_y)
            If NewPosition_x > 98 Then
                NewPosition_x = 98
            End If
            If NewPosition_y > 47 Then
                NewPosition_y = 47
            End If
            NewX = NewPosition_x
            NewY = NewPosition_y
            New_tact_pos = PosJug_to_number(t7.Text)

            Grabar_Tactics_formation.Write(swaps.swap32(New_tact_pos))
            Grabar_Tactics_formation.BaseStream.Position += 2
            Grabar_Tactics_formation.Write(NewY)
            Grabar_Tactics_formation.Write(NewX)
            Grabar_Tactics_formation.BaseStream.Position += 4

            NewPosition_x = (((t8.Location.X + (t8.Width / 2)) / Prop_x))
            NewPosition_y = (((Campo.Height - t8.Location.Y) - (t8.Height / 2)) / Prop_y)
            If NewPosition_x > 98 Then
                NewPosition_x = 98
            End If
            If NewPosition_y > 47 Then
                NewPosition_y = 47
            End If
            NewX = NewPosition_x
            NewY = NewPosition_y
            New_tact_pos = PosJug_to_number(t8.Text)

            Grabar_Tactics_formation.Write(swaps.swap32(New_tact_pos))
            Grabar_Tactics_formation.BaseStream.Position += 2
            Grabar_Tactics_formation.Write(NewY)
            Grabar_Tactics_formation.Write(NewX)
            Grabar_Tactics_formation.BaseStream.Position += 4

            NewPosition_x = (((t9.Location.X + (t9.Width / 2)) / Prop_x))
            NewPosition_y = (((Campo.Height - t9.Location.Y) - (t9.Height / 2)) / Prop_y)
            If NewPosition_x > 98 Then
                NewPosition_x = 98
            End If
            If NewPosition_y > 47 Then
                NewPosition_y = 47
            End If
            NewX = NewPosition_x
            NewY = NewPosition_y
            New_tact_pos = PosJug_to_number(t9.Text)

            Grabar_Tactics_formation.Write(swaps.swap32(New_tact_pos))
            Grabar_Tactics_formation.BaseStream.Position += 2
            Grabar_Tactics_formation.Write(NewY)
            Grabar_Tactics_formation.Write(NewX)
            Grabar_Tactics_formation.BaseStream.Position += 4

            NewPosition_x = (((t10.Location.X + (t10.Width / 2)) / Prop_x))
            NewPosition_y = (((Campo.Height - t10.Location.Y) - (t10.Height / 2)) / Prop_y)
            If NewPosition_x > 98 Then
                NewPosition_x = 98
            End If
            If NewPosition_y > 47 Then
                NewPosition_y = 47
            End If
            NewX = NewPosition_x
            NewY = NewPosition_y
            New_tact_pos = PosJug_to_number(t10.Text)

            Grabar_Tactics_formation.Write(swaps.swap32(New_tact_pos))
            Grabar_Tactics_formation.BaseStream.Position += 2
            Grabar_Tactics_formation.Write(NewY)
            Grabar_Tactics_formation.Write(NewX)
            Grabar_Tactics_formation.BaseStream.Position += 4

            MsgBox("Formation Succesfully Changed")

        End If


    End Sub
    Public pos_jug As String = "GK"
    Public color_jug As Color = Color.AliceBlue
    Private Sub t1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles t9.DoubleClick, t8.DoubleClick, t7.DoubleClick, t6.DoubleClick, t5.DoubleClick, t4.DoubleClick, t3.DoubleClick, t2.DoubleClick, t10.DoubleClick, t1.DoubleClick

        Dim tChanged As TextBox = DirectCast(sender, TextBox)

        pos_jug = tChanged.Text
        color_jug = tChanged.BackColor

        Me.Hide()
        Selec_position.ShowDialog()

        tChanged.Text = pos_jug
        tChanged.BackColor = color_jug

    End Sub

    Public Function PosJug_to_number(ByVal Nombre_pos As String) As UInt32
        Dim ValorARetornar As UInt32 = 0
        Select Case Nombre_pos
            Case "GK"
                ValorARetornar = 0
            Case "CB"
                ValorARetornar = 1
            Case "LB"
                ValorARetornar = 2
            Case "RB"
                ValorARetornar = 3
            Case "DMF"
                ValorARetornar = 4
            Case "CMF"
                ValorARetornar = 5
            Case "LMF"
                ValorARetornar = 6
            Case "RMF"
                ValorARetornar = 7
            Case "AMF"
                ValorARetornar = 8
            Case "LWF"
                ValorARetornar = 9
            Case "RWF"
                ValorARetornar = 10
            Case "SS"
                ValorARetornar = 11
            Case "CF"
                ValorARetornar = 12

        End Select
        Return ValorARetornar

    End Function

    Private Sub Button51_Click(sender As System.Object, e As System.EventArgs) Handles Button51.Click
        If System.IO.File.Exists(openfolder.SelectedPath + "\data_st_list.bin") = True Then
            System.IO.File.Delete(openfolder.SelectedPath + "\data_st_list.bin")
        End If
        Dim st_list_new = New FileStream(openfolder.SelectedPath + "\data_st_list.bin", FileMode.OpenOrCreate, FileAccess.Write)
        Dim Grabar As New BinaryWriter(st_list_new)
        Dim Valores_32_a_grabar As UInt32 = DataGridView_Stadium.Rows.Count
        Grabar.Write(swaps.swap32(Valores_32_a_grabar))

        For i = 0 To DataGridView_Stadium.Rows.Count - 1
            Valores_32_a_grabar = Convert.ToUInt32(DataGridView_Stadium.Rows(i).Cells(0).Value)
            Grabar.Write(swaps.swap32(Valores_32_a_grabar))
        Next
        Grabar.Close()
        st_list_new.Close()
        st_list_new.Dispose()

        MsgBox("File data_st_list.bin Created succesfully, now put or replace the one located on Path: \common\etc/data_st_list.bin, thanks to Buenolacasito for tip")
    End Sub

    Private Sub Button52_Click(sender As System.Object, e As System.EventArgs) Handles Button52.Click
        Try
            If System.IO.File.Exists(Application.StartupPath + "\Files\playersid.csv") = True Then
                System.IO.File.Delete(Application.StartupPath + "\Files\playersid.csv")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Dim Archivo_exportado As System.IO.TextWriter = New System.IO.StreamWriter(Application.StartupPath + "\Files\playersid.csv", False, System.Text.Encoding.Default)

        Leer_Team.BaseStream.Position = 0


        Dim NUm_Player As UInteger = Leer_Player.BaseStream.Length / Player.tamanho_bloque
        Dim Linea As String = ""

        For i = 0 To NUm_Player - 1
            Dim Player_a_a_leer As New Player
            Player_a_a_leer.Leer_Valores(i)



            Linea += Player_a_a_leer.Player_ID.ToString + ";"
            Linea += Player_a_a_leer.Nombre_camiseta.ToString + ";"
            Linea += Environment.NewLine.ToString()
        Next

        Linea = Linea.Substring(0, Linea.Length - 1)

        'Write the Text to file
        Archivo_exportado.Write(Linea)
        'Close the Textwrite
        Archivo_exportado.Close()






        MsgBox("file successfully exported ")
    End Sub

   
   
    
    Private Sub Button26_Click(sender As System.Object, e As System.EventArgs) Handles Button26.Click
        If PLayer_Appareance_present = True Then


            If ListBox1.SelectedIndex <> -1 Then
                Dim Byte_array_Export As Byte()
                Leer_PlayerAppareance.BaseStream.Position = 0
                While swaps.swap32(Leer_PlayerAppareance.ReadUInt32) <> Player_num.Value
                    If Leer_PlayerAppareance.BaseStream.Position = PlayerAppareance_MemStream.Length - 56 Then
                        MsgBox("no Player Appareance found sorry")
                        Exit Sub

                    Else
                        Leer_PlayerAppareance.BaseStream.Position += 56
                    End If


                End While

                Leer_PlayerAppareance.BaseStream.Position -= 4
                Byte_array_Export = Leer_PlayerAppareance.ReadBytes(60)
                Dim Nombre_archivo As String = Player_num.Value.ToString + "_" + Shirt_name.Text.ToString + "_appareance" + ".exported_app"
                Try
                    If System.IO.File.Exists(Application.StartupPath + "\Files\" + Nombre_archivo) = True Then
                        System.IO.File.Delete(Application.StartupPath + "\Files\" + Nombre_archivo)
                    End If
                Catch ex As Exception
                    MsgBox(ex)
                End Try
                Dim Stream_a_exportar As FileStream = New FileStream(Application.StartupPath + "\Files\" + Nombre_archivo, FileMode.OpenOrCreate)
                Stream_a_exportar.Write(Byte_array_Export, 0, Byte_array_Export.Length)
                Stream_a_exportar.Close()
                MsgBox(Name_box.Text.ToString + " Succesfully Exported")
            Else
                MsgBox("Select a Player BEFORE :)!!")
            End If
        Else
            MsgBox("NOT PLAYERAPPAREANCE PRESENT SORRY")
        End If
    End Sub

    Private Sub Button53_Click(sender As System.Object, e As System.EventArgs) Handles Button53.Click
        Dim OpenPes As New OpenFileDialog

        OpenPes.Title = "Open A Pes 2016 Exported Player Appareance"
        OpenPes.Filter = "*.exported_app (*.exported_app)|*.exported_app"
        OpenPes.Multiselect = True
        If (Directory.Exists(Application.StartupPath + "\Files\")) Then
            OpenPes.InitialDirectory = (Application.StartupPath + "\Files\")
        End If



        If OpenPes.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim number_of_files As Integer = OpenPes.FileNames.Count

            For Each archivo In OpenPes.FileNames

                Dim NombreSinPath As String = Path.GetFileNameWithoutExtension(archivo)
                Dim Id As String = ""
                For Each val As Char In NombreSinPath.ToCharArray()
                    If val = "_" Then
                        Exit For
                    Else
                        Id += val
                    End If
                Next

                Dim ID_A_IMPORTAR As UInt32 = Convert.ToUInt32(Id)
                Dim stream_a_importar As FileStream = New FileStream(archivo, FileMode.Open, FileAccess.Read)
                Dim Leer_archivo As New BinaryReader(stream_a_importar)

                Leer_PlayerAppareance.BaseStream.Position = 0

                For i = 0 To PlayerAppareance_MemStream.Length / 60 - 1

                    Dim player_check As UInt32 = swaps.swap32(Leer_PlayerAppareance.ReadUInt32)
                    If player_check = ID_A_IMPORTAR Then
                        Leer_PlayerAppareance.BaseStream.Position -= 4
                        Dim Byte_array As Byte() = Leer_archivo.ReadBytes(60)
                        Grabar_PlayerAppareance.Write(Byte_array, 0, Byte_array.Length)
                        ListBox1.SelectedIndex = i
                        Exit For
                    End If

                    Leer_PlayerAppareance.BaseStream.Position += 56
                Next


            Next

            MsgBox("Player(s) imported succesfully")
        End If

    End Sub

   
    Private Sub Button58_Click(sender As System.Object, e As System.EventArgs) Handles Button58.Click

        OpenPes = Me.OpenFileDialog1

        OpenPes.Title = "Open A Pes 2018 compressed file"
        OpenPes.Filter = "*.* (*.*)|*.*"
        OpenPes.Multiselect = True


        If OpenPes.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Dim number_of_files As Integer = OpenPes.FileNames.Count

            ProgressBar1.Minimum = 1
            ProgressBar1.Value = 1
            ProgressBar1.Maximum = number_of_files


            For Each Me.archivo In OpenPes.FileNames





                Try
                    Dim Stream_file As FileStream = File.Open(archivo, FileMode.Open, FileAccess.Read)
                    If (Stream_file IsNot Nothing) Then
                        Dim Leer As New BinaryReader(Stream_file)
                        Leer.ReadBytes(Stream_file.Length)
                        Leer.BaseStream.Position = 3
                        Dim CheckPesFile As Integer = &H59534557

                        If Leer.ReadUInt32 = CheckPesFile Then
                            Leer.BaseStream.Position = 0
                            Dim Check_pc_console As Byte = Leer.ReadByte

                            Dim Check_Console As Byte = &H1
                            If Check_pc_console = Check_Console Then
                                zlib1.unzlibconsole(Stream_file, archivo)
                                Stream_file.Close()
                                'MsgBox("Console File Unzlibed Succesfully")
                                correctos = correctos + 1

                            ElseIf Check_pc_console = &H0 Or Check_pc_console = &H4 Or Check_pc_console = &HFF Then

                                zlib1.unzlibpc(Stream_file, archivo)
                                Stream_file.Close()
                                'MsgBox("Pc File Unzlibed Succesfully")
                                correctos = correctos + 1

                            ElseIf Check_pc_console = &H2 Then
                                zlib1.unzlibconsole(Stream_file, archivo)
                                Stream_file.Close()
                                'MsgBox("Console File Unzlibed Succesfully")
                                correctos = correctos + 1


                            Else
                                MsgBox("UnkNown Compression")
                                incorrectos = incorrectos + 1
                            End If

                        Else
                            If OpenPes.FileNames.Count = 1 Then
                                MsgBox(archivo + " isn´t a Pes2014 compressed file")
                            End If
                            Stream_file.Close()
                            incorrectos = incorrectos + 1
                            'Return
                        End If



                    End If
                Catch Ex As Exception
                    'MessageBox.Show("Cannot read file from disk or File is Sized 0. Original error: " & Ex.Message)
                    incorrectos = incorrectos + 1

                End Try
                ProgressBar1.Increment(1)
            Next archivo

        End If
        MsgBox(correctos.ToString + " unzlib Succesfully  " + vbCrLf + incorrectos.ToString + " Failed to unzlib (Maybe size 0 or unknown compression)")
        correctos = 0
        incorrectos = 0

    End Sub

    Private Sub Button54_Click(sender As System.Object, e As System.EventArgs) Handles Button54.Click
        Dim openfolder As New FolderBrowserDialog
        Dim Files As New ArrayList, Raiz As String
        If openfolder.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Raiz = openfolder.SelectedPath

            Try
                For Each f In Directory.GetFiles(Raiz)
                    Files.Add(f)
                Next

            Catch ex As System.Exception
                MsgBox(ex)
            End Try



            Try

                DirSearch(Raiz, Files)

            Catch ex As System.Exception
                MsgBox(ex)
            End Try

            Dim number_of_files As Integer = Files.Count

            ProgressBar1.Minimum = 1
            ProgressBar1.Value = 1
            ProgressBar1.Maximum = number_of_files


            For Each Me.archivo In Files





                Try
                    Dim Stream_file As FileStream = System.IO.File.Open(archivo, FileMode.Open, FileAccess.Read)
                    If (Stream_file IsNot Nothing) Then
                        Dim Leer As New BinaryReader(Stream_file)
                        Leer.ReadBytes(Stream_file.Length)
                        Leer.BaseStream.Position = 3
                        Dim CheckPesFile As Integer = &H59534557

                        If Leer.ReadUInt32 = CheckPesFile Then
                            Leer.BaseStream.Position = 0
                            Dim Check_pc_console As Byte = Leer.ReadByte

                            Dim Check_Console As Byte = &H1
                            If Check_pc_console = Check_Console Then
                                zlib1.unzlibconsole(Stream_file, archivo)
                                Stream_file.Close()
                                'MsgBox("Console File Unzlibed Succesfully")
                                correctos = correctos + 1

                            ElseIf Check_pc_console = &H0 Or Check_pc_console = &HFF Or Check_pc_console = &H4 Then

                                zlib1.unzlibpc(Stream_file, archivo)
                                Stream_file.Close()
                                'MsgBox("Pc File Unzlibed Succesfully")
                                correctos = correctos + 1

                            ElseIf Check_pc_console = &H2 Then
                                zlib1.unzlibconsole(Stream_file, archivo)
                                Stream_file.Close()
                                'MsgBox("Console File Unzlibed Succesfully")
                                correctos = correctos + 1


                            Else
                                MsgBox("UnkNown Compression")
                                incorrectos = incorrectos + 1
                            End If

                        Else
                            If Files.Count = 1 Then
                                MsgBox(archivo + " isn´t a Pes2014 compressed file")
                            End If
                            Stream_file.Close()
                            incorrectos = incorrectos + 1
                            'Return
                        End If



                    End If
                Catch Ex As Exception
                    'MessageBox.Show("Cannot read file from disk or File is Sized 0. Original error: " & Ex.Message)
                    incorrectos = incorrectos + 1

                End Try
                ProgressBar1.Increment(1)
            Next archivo

        End If
        MsgBox(correctos.ToString + " unzlib Succesfully  " + vbCrLf + incorrectos.ToString + " Failed to unzlib (Maybe size 0 or unknown compression)")
        correctos = 0
        incorrectos = 0
    End Sub

    Public Shared Sub DirSearch(ByVal sDir As String, ByRef files As ArrayList)
        Dim d As String
        Dim f As String

        Try

            For Each d In Directory.GetDirectories(sDir)
                For Each f In Directory.GetFiles(d)
                    files.Add(f)
                Next
                DirSearch(d, files)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
    End Sub

    Private Sub Button57_Click(sender As System.Object, e As System.EventArgs) Handles Button57.Click

        OpenPes = Me.OpenFileDialog1
        OpenPes.Title = "Open A Pes 2018 uncompressed file"
        OpenPes.Filter = "*.unzlib (*.unzlib)|*.unzlib"
        OpenPes.Multiselect = True

        If OpenPes.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Dim number_of_files As Integer = OpenPes.FileNames.Count

            ProgressBar1.Minimum = 1
            ProgressBar1.Value = 1
            ProgressBar1.Maximum = number_of_files

            For Each Me.archivo In OpenPes.FileNames




                Try
                    Dim Stream_file As FileStream = File.Open(archivo, FileMode.Open, FileAccess.Read)
                    If (Stream_file IsNot Nothing) Then

                        Dim src As Byte() = New Byte(Stream_file.Length) {}
                        Stream_file.Read(src, 0, Stream_file.Length)

                        Dim Destlen As UInt32 = Stream_file.Length * 2
                        Dim Dest(0 To Destlen) As Byte
                        Dim Retval As UInt32 = zlib1.compress2(Dest, Destlen, src, Stream_file.Length, 9)
                        If (Retval = 0) Then
                            Dim Filename As String = Path.GetFileNameWithoutExtension(archivo)
                            If File.Exists(Path.GetDirectoryName(archivo) + "\" + Filename) Then
                                System.IO.File.Delete(Path.GetDirectoryName(archivo) + "\" + Filename)

                            End If
                            Dim file_zlib = New FileStream(Path.GetDirectoryName(archivo) + "\" + Filename, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            Dim Grabar As New BinaryWriter(file_zlib)
                            file_zlib.WriteByte(&H1)
                            file_zlib.WriteByte(&H10)
                            file_zlib.WriteByte(&H81)
                            Grabar.Write("WESYS", 0, 5)
                            Destlen = swaps.swap32(Destlen)
                            Dim uncomp_length As UInt32 = swaps.swap32(Stream_file.Length)
                            Grabar.Write(Destlen)
                            Destlen = swaps.swap32(Destlen)
                            Grabar.Write(uncomp_length)
                            Grabar.Write(Dest, 0, Destlen)
                            file_zlib.Close()
                            Stream_file.Close()

                            'MsgBox("Succesfully Compressed to Console Format")
                            correctos = correctos + 1
                        End If
                    Else
                        'MsgBox("UnKnown Error")
                        incorrectos = incorrectos + 1
                        Stream_file.Close()

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
            Next archivo
            ProgressBar1.Increment(1)

        End If

        MsgBox(correctos.ToString + " zlib Succesfully to Xbox360 format " + vbCrLf + incorrectos.ToString + " Failed to zlib (Maybe size 0?)")
        correctos = 0
        incorrectos = 0
    End Sub

    Private Sub Button56_Click(sender As System.Object, e As System.EventArgs) Handles Button56.Click
        OpenPes = Me.OpenFileDialog1
        OpenPes.Title = "Open A Pes 2018 uncompressed file"
        OpenPes.Filter = "*.unzlib (*.unzlib)|*.unzlib"
        OpenPes.Multiselect = True

        If OpenPes.ShowDialog() = System.Windows.Forms.DialogResult.OK Then


            Dim number_of_files As Integer = OpenPes.FileNames.Count
            ProgressBar1.Minimum = 1
            ProgressBar1.Value = 1
            ProgressBar1.Maximum = number_of_files


            For Each Me.archivo In OpenPes.FileNames



                Try
                    Dim Stream_file As FileStream = File.Open(archivo, FileMode.Open, FileAccess.Read)
                    If (Stream_file IsNot Nothing) Then



                        Dim src As Byte() = New Byte(Stream_file.Length) {}
                        Stream_file.Read(src, 0, Stream_file.Length)

                        Dim Destlen As UInt32 = Stream_file.Length * 2
                        Dim Dest(0 To Destlen) As Byte
                        Dim Retval As UInt32 = zlib1.compress2(Dest, Destlen, src, Stream_file.Length, 9)
                        If (Retval = 0) Then
                            Dim Filename As String = Path.GetFileNameWithoutExtension(archivo)
                            If File.Exists(Path.GetDirectoryName(archivo) + "\" + Filename) Then
                                System.IO.File.Delete(Path.GetDirectoryName(archivo) + "\" + Filename)

                            End If
                            Dim file_zlib = New FileStream(Path.GetDirectoryName(archivo) + "\" + Filename, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            Dim Grabar As New BinaryWriter(file_zlib)
                            file_zlib.WriteByte(&H4)
                            file_zlib.WriteByte(&H10)
                            file_zlib.WriteByte(&H81)
                            Grabar.Write("WESYS", 0, 5)
                            Dim uncomp_length As UInt32 = Stream_file.Length
                            Grabar.Write(Destlen)
                            Grabar.Write(uncomp_length)
                            Grabar.Write(Dest, 0, Destlen)
                            file_zlib.Close()
                            Stream_file.Close()
                            'MsgBox("Succesfully Compressed to PC Format")
                            correctos = correctos + 1
                        End If
                    Else
                        'MsgBox("UnKnown Error")
                        Stream_file.Close()
                        incorrectos = incorrectos + 1


                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try

            Next archivo
            ProgressBar1.Increment(1)
        End If

        MsgBox(correctos.ToString + " zlib Succesfully to Pc format " + vbCrLf + incorrectos.ToString + " Failed to zlib (Maybe size 0?)")
        correctos = 0
        incorrectos = 0
    End Sub

    Private Sub Button55_Click(sender As System.Object, e As System.EventArgs) Handles Button55.Click
        OpenPes = Me.OpenFileDialog1
        OpenPes.Title = "Open A Pes 2018 uncompressed file"
        OpenPes.Filter = "*.unzlib (*.unzlib)|*.unzlib"
        OpenPes.Multiselect = True

        If OpenPes.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Dim number_of_files As Integer = OpenPes.FileNames.Count

            ProgressBar1.Minimum = 1
            ProgressBar1.Value = 1
            ProgressBar1.Maximum = number_of_files

            For Each Me.archivo In OpenPes.FileNames




                Try
                    Dim Stream_file As FileStream = File.Open(archivo, FileMode.Open, FileAccess.Read)
                    If (Stream_file IsNot Nothing) Then

                        Dim src As Byte() = New Byte(Stream_file.Length) {}
                        Stream_file.Read(src, 0, Stream_file.Length)

                        Dim Destlen As UInt32 = Stream_file.Length * 2
                        Dim Dest(0 To Destlen) As Byte
                        Dim Retval As UInt32 = zlib1.compress2(Dest, Destlen, src, Stream_file.Length, 9)
                        If (Retval = 0) Then
                            Dim Filename As String = Path.GetFileNameWithoutExtension(archivo)
                            If File.Exists(Path.GetDirectoryName(archivo) + "\" + Filename) Then
                                System.IO.File.Delete(Path.GetDirectoryName(archivo) + "\" + Filename)

                            End If
                            Dim file_zlib = New FileStream(Path.GetDirectoryName(archivo) + "\" + Filename, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                            Dim Grabar As New BinaryWriter(file_zlib)
                            file_zlib.WriteByte(&H2)
                            file_zlib.WriteByte(&H10)
                            file_zlib.WriteByte(&H81)
                            Grabar.Write("WESYS", 0, 5)
                            Destlen = swaps.swap32(Destlen)
                            Dim uncomp_length As UInt32 = swaps.swap32(Stream_file.Length)
                            Grabar.Write(Destlen)
                            Destlen = swaps.swap32(Destlen)
                            Grabar.Write(uncomp_length)
                            Grabar.Write(Dest, 0, Destlen)
                            file_zlib.Close()
                            Stream_file.Close()

                            'MsgBox("Succesfully Compressed to Console Format")
                            correctos = correctos + 1
                        End If
                    Else
                        'MsgBox("UnKnown Error")
                        incorrectos = incorrectos + 1
                        Stream_file.Close()

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
            Next archivo
            ProgressBar1.Increment(1)

        End If

        MsgBox(correctos.ToString + " zlib Succesfully to Ps3 format " + vbCrLf + incorrectos.ToString + " Failed to zlib (Maybe size 0?)")
        correctos = 0
        incorrectos = 0
    End Sub

    Private Sub Button59_Click(sender As System.Object, e As System.EventArgs) Handles Button59.Click

        OpenPes = Me.OpenFileDialog1
        OpenPes.Title = "Open A Pes 2016 Database file"
        OpenPes.Filter = "*.bin (*.bin)|*.bin"
        OpenPes.Multiselect = True

        Dim Contador_errores As Integer = 0
        Dim Pc_or_console As String = "UnkNown Format"

        If OpenPes.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Dim number_of_files As Integer = OpenPes.FileNames.Count

            ProgressBar1.Minimum = 1
            ProgressBar1.Value = 1
            ProgressBar1.Maximum = number_of_files



            For Each Me.archivo In OpenPes.FileNames



                Try

                    Dim Stream_file As FileStream = File.Open(archivo, FileMode.Open, FileAccess.Read)
                    If (Stream_file IsNot Nothing And Stream_file.Length <> 0) Then
                        Dim Leer As New BinaryReader(Stream_file)
                        Leer.ReadBytes(Stream_file.Length)
                        Leer.BaseStream.Position = 2
                        Dim CHECK_HALFZLIB As Byte = Leer.ReadByte

                        Leer.BaseStream.Position = 3
                        Dim CheckPesFile As Integer = &H59534557
                        Dim unzlib_memstream As New MemoryStream
                        If Leer.ReadUInt32 = CheckPesFile Then
                            Leer.BaseStream.Position = 0
                            Dim Check_pc_console As Byte = Leer.ReadByte

                            Dim Check_Console As Byte = &H1
                            Dim Check_ps3 As Byte = &H2
                            If Check_pc_console = Check_Console Or Check_pc_console = Check_ps3 Then
                                If CHECK_HALFZLIB <> 0 Then
                                    unzlib_memstream = zlib1.unzlibconsole_to_MemStream(Stream_file)
                                Else
                                    Leer.BaseStream.Position = 16
                                    Dim buffer As Byte() = Leer.ReadBytes(Stream_file.Length - 16)
                                    unzlib_memstream.Write(buffer, 0, buffer.Length)
                                End If


                                ' unzlib_memstream = zlib1.unzlibconsole_to_MemStream(Stream_file)
                                Stream_file.Close()
                                Leer.Close()
                                Pc_or_console = "To Pc "
                                Dim Nombre As String = Path.GetFileName(archivo)

                                Select Case Nombre

                                    Case "Ball.bin", "Ball1.bin", "Ball2.bin", "Ball3.bin", "Ball4.bin", "Ball5.bin", "Ball6.bin"
                                        converter.ball(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "BallCondition.bin", "BallCondition1.bin", "BallCondition2.bin", "BallCondition3.bin", "BallCondition4.bin", "BallCondition5.bin", "BallCondition6.bin"
                                        converter.BallCondition_topc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Boots.bin", "Boots1.bin", "Boots2.bin", "Boots3.bin", "Boots4.bin", "Boots5.bin", "Boots6.bin"
                                        converter.Boots(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Coach.bin", "Coach1.bin", "Coach2.bin", "Coach3.bin", "Coach4.bin", "Coach5.bin", "Coach6.bin"
                                        converter.Coach_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Competition.bin", "Competition1.bin", "Competition2.bin", "Competition3.bin", "Competition4.bin", "Competition5.bin", "Competition6.bin"
                                        converter.Competition_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "CompetitionEntry1.bin", "CompetitionEntry2.bin", "CompetitionEntry.bin", "CompetitionEntry3.bin", "CompetitionEntry4.bin", "CompetitionEntry5.bin", "CompetitionEntry6.bin"
                                        converter.CompetitionEntry_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "CompetitionKind1.bin", "CompetitionKind2.bin", "CompetitionKind.bin", "CompetitionKind3.bin", "CompetitionKind4.bin", "CompetitionKind5.bin", "CompetitionKind6.bin"
                                        converter.CompetitionKind_to_pc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "CompetitionRegulation.bin", "CompetitionRegulation1.bin", "CompetitionRegulation2.bin", "CompetitionRegulation3.bin", "CompetitionRegulation4.bin", "CompetitionRegulation5.bin", "CompetitionRegulation6.bin"
                                        converter.CompetitionRegulation_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Country.bin", "Country1.bin", "Country2.bin", "Country3.bin", "Country4.bin", "Country5.bin", "Country6.bin"
                                        converter.Country_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Derby.bin", "Derby1.bin", "Derby2.bin", "Derby3.bin", "Derby4.bin", "Derby5.bin", "Derby6.bin"
                                        converter.Derby_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "InstallVersionBallDlcAs.bin", "InstallVersionBallDlcEu.bin", "InstallVersionBallDlcJp.bin", "InstallVersionBallDlcUs.bin", "InstallVersionBallDp.bin"
                                        converter.InstallVersion_Ball_Boots_Stadium_Dlc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "InstallVersionBootsDlcAs.bin", "InstallVersionBootsDlcEu.bin", "InstallVersionBootsDlcJp.bin", "InstallVersionBootsDlcUs.bin", "InstallVersionBootsDp.bin"
                                        converter.InstallVersion_Ball_Boots_Stadium_Dlc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "InstallVersionStadiumDlcAs.bin", "InstallVersionStadiumDlcEu.bin", "InstallVersionStadiumDlcJp.bin", "InstallVersionStadiumDlcUs.bin", "InstallVersionStadiumDp.bin"
                                        converter.InstallVersion_Ball_Boots_Stadium_Dlc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "InstallVersionGloveDlcAs.bin", "InstallVersionGloveDlcEu.bin", "InstallVersionGloveDlcJp.bin", "InstallVersionGloveDlcUs.bin", "InstallVersionGloveDp.bin"
                                        converter.InstallVersion_Ball_Boots_Stadium_Dlc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Player.bin", "Player1.bin", "Player2.bin", "Player3.bin", "Player4.bin", "Player5.bin", "Player6.bin"
                                        converter.Player_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "PlayerAssignment.bin", "PlayerAssignment1.bin", "PlayerAssignment2.bin", "PlayerAssignment3.bin", "PlayerAssignment4.bin", "PlayerAssignment5.bin", "PlayerAssignment6.bin"
                                        converter.PlayerAssignment_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "SpecialPlayerAssignment.bin", "SpecialPlayerAssignment1.bin", "SpecialPlayerAssignment2.bin", "SpecialPlayerAssignment3.bin", "SpecialPlayerAssignment4.bin", "SpecialPlayerAssignment5.bin", "SpecialPlayerAssignment6.bin"
                                        converter.SpecialPlayerAssignment(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "SpecialPlayerAssignmentKind.bin", "SpecialPlayerAssignmentKind1.bin", "SpecialPlayerAssignmentKind2.bin", "SpecialPlayerAssignmentKind3.bin", "SpecialPlayerAssignmentKind4.bin", "SpecialPlayerAssignmentKind5.bin", "SpecialPlayerAssignmentKind6.bin"
                                        converter.SpecialPlayerAssignmentKind(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Stadium.bin", "Stadium1.bin", "Stadium2.bin", "Stadium3.bin", "Stadium4.bin", "Stadium5.bin", "Stadium6.bin"
                                        converter.Stadium_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "StadiumOrder.bin", "StadiumOrder1.bin", "StadiumOrder2.bin", "StadiumOrder3.bin", "StadiumOrder4.bin", "StadiumOrder5.bin", "StadiumOrder6.bin"
                                        converter.StadiumOrder_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "StadiumOrderInConfederation.bin", "StadiumOrderInConfederation1.bin", "StadiumOrderInConfederation2.bin", "StadiumOrderInConfederation3.bin", "StadiumOrderInConfederation4.bin", "StadiumOrderInConfederation5.bin", "StadiumOrderInConfederation6.bin"
                                        converter.StadiumOrderInConfederation_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Team.bin", "Team1.bin", "Team2.bin", "Team3.bin", "Team4.bin", "Team5.bin", "Team6.bin"
                                        converter.Team_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Glove.bin", "Glove1.bin", "Glove2.bin", "Glove3.bin", "Glove4.bin", "Glove5.bin", "Glove6.bin"
                                        converter.Glove(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Tactics.bin", "Tactics1.bin", "Tactics2.bin", "Tactics3.bin", "Tactics4.bin", "Tactics5.bin", "Tactics6.bin"
                                        converter.Tactics_toPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "TacticsFormation.bin", "TacticsFormation1.bin", "TacticsFormation2.bin", "TacticsFormation3.bin", "TacticsFormation4.bin", "TacticsFormation5.bin", "TacticsFormation6.bin"
                                        converter.Tactics_FormationToPc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_pc(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Pc Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case Else

                                        MsgBox("File Not Recognized as Pes 2014 Database file or not supported sorry")
                                End Select

                            ElseIf Check_pc_console = &H0 Or Check_pc_console = &H4 Then
                                If CHECK_HALFZLIB <> 0 Then
                                    unzlib_memstream = zlib1.unzlibPc_to_Memstream(Stream_file)
                                Else
                                    Leer.BaseStream.Position = 16
                                    Dim buffer As Byte() = Leer.ReadBytes(Stream_file.Length - 16)
                                    unzlib_memstream.Write(buffer, 0, buffer.Length)
                                End If
                                'unzlib_memstream = zlib1.unzlibPc_to_Memstream(Stream_file)
                                Stream_file.Close()
                                Leer.Close()
                                Pc_or_console = " to Console "
                                Dim Nombre As String = Path.GetFileName(archivo)

                                Select Case Nombre

                                    Case "Ball.bin", "Ball1.bin", "Ball2.bin", "Ball3.bin", "Ball4.bin", "Ball5.bin", "Ball6.bin"
                                        converter.ball(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "BallCondition.bin", "BallCondition1.bin", "BallCondition2.bin", "BallCondition3.bin", "BallCondition4.bin", "BallCondition5.bin", "BallCondition6.bin"
                                        converter.BallCondition_toconsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Boots.bin", "Boots1.bin", "Boots2.bin", "Boots3.bin", "Boots4.bin", "Boots5.bin", "Boots6.bin"
                                        converter.Boots(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Coach.bin", "Coach1.bin", "Coach2.bin", "Coach3.bin", "Coach4.bin", "Coach5.bin", "Coach6.bin"
                                        converter.Coach_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Competition.bin", "Competition1.bin", "Competition2.bin", "Competition3.bin", "Competition4.bin", "Competition5.bin", "Competition6.bin"
                                        converter.Competition_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "CompetitionEntry1.bin", "CompetitionEntry2.bin", "CompetitionEntry.bin", "CompetitionEntry3.bin", "CompetitionEntry4.bin", "CompetitionEntry5.bin", "CompetitionEntry6.bin"
                                        converter.CompetitionEntry_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "CompetitionKind1.bin", "CompetitionKind2.bin", "CompetitionKind.bin", "CompetitionKind3.bin", "CompetitionKind4.bin", "CompetitionKind5.bin", "CompetitionKind6.bin"
                                        converter.CompetitionKind_to_console(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "CompetitionRegulation.bin", "CompetitionRegulation1.bin", "CompetitionRegulation2.bin", "CompetitionRegulation3.bin", "CompetitionRegulation4.bin", "CompetitionRegulation5.bin", "CompetitionRegulation6.bin"
                                        converter.CompetitionRegulation_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Country.bin", "Country1.bin", "Country2.bin", "Country3.bin", "Country4.bin", "Country5.bin", "Country6.bin"
                                        converter.Country_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Derby.bin", "Derby1.bin", "Derby2.bin", "Derby3.bin", "Derby4.bin", "Derby5.bin", "Derby6.bin"
                                        converter.Derby_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "InstallVersionBallDlcAs.bin", "InstallVersionBallDlcEu.bin", "InstallVersionBallDlcJp.bin", "InstallVersionBallDlcUs.bin", "InstallVersionBallDp.bin"
                                        converter.InstallVersion_Ball_Boots_Stadium_Dlc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "InstallVersionBootsDlcAs.bin", "InstallVersionBootsDlcEu.bin", "InstallVersionBootsDlcJp.bin", "InstallVersionBootsDlcUs.bin", "InstallVersionBootsDp.bin"
                                        converter.InstallVersion_Ball_Boots_Stadium_Dlc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "InstallVersionStadiumDlcAs.bin", "InstallVersionStadiumDlcEu.bin", "InstallVersionStadiumDlcJp.bin", "InstallVersionStadiumDlcUs.bin", "InstallVersionStadiumDp.bin"
                                        converter.InstallVersion_Ball_Boots_Stadium_Dlc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "InstallVersionGloveDlcAs.bin", "InstallVersionGloveDlcEu.bin", "InstallVersionGloveDlcJp.bin", "InstallVersionGloveDlcUs.bin", "InstallVersionGloveDp.bin"
                                        converter.InstallVersion_Ball_Boots_Stadium_Dlc(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Player.bin", "Player1.bin", "Player2.bin", "Player3.bin", "Player4.bin", "Player5.bin", "Player6.bin"
                                        converter.Player_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "PlayerAssignment.bin", "PlayerAssignment1.bin", "PlayerAssignment2.bin", "PlayerAssignment3.bin", "PlayerAssignment4.bin", "PlayerAssignment5.bin", "PlayerAssignment6.bin"
                                        converter.PlayerAssignment_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "SpecialPlayerAssignment.bin", "SpecialPlayerAssignment1.bin", "SpecialPlayerAssignment2.bin", "SpecialPlayerAssignment3.bin", "SpecialPlayerAssignment4.bin", "SpecialPlayerAssignment5.bin", "SpecialPlayerAssignment6.bin"
                                        converter.SpecialPlayerAssignment(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "SpecialPlayerAssignmentKind.bin", "SpecialPlayerAssignmentKind1.bin", "SpecialPlayerAssignmentKind2.bin", "SpecialPlayerAssignmentKind3.bin", "SpecialPlayerAssignmentKind4.bin", "SpecialPlayerAssignmentKind5.bin", "SpecialPlayerAssignmentKind6.bin"
                                        converter.SpecialPlayerAssignmentKind(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Stadium.bin", "Stadium1.bin", "Stadium2.bin", "Stadium3.bin", "Stadium4.bin", "Stadium5.bin", "Stadium6.bin"
                                        converter.Stadium_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "StadiumOrder.bin", "StadiumOrder1.bin", "StadiumOrder2.bin", "StadiumOrder3.bin", "StadiumOrder4.bin", "StadiumOrder5.bin", "StadiumOrder6.bin"
                                        converter.StadiumOrder_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "StadiumOrderInConfederation.bin", "StadiumOrderInConfederation1.bin", "StadiumOrderInConfederation2.bin", "StadiumOrderInConfederation3.bin", "StadiumOrderInConfederation4.bin", "StadiumOrderInConfederation5.bin", "StadiumOrderInConfederation6.bin"
                                        converter.StadiumOrderInConfederation_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Team.bin", "Team1.bin", "Team2.bin", "Team3.bin", "Team4.bin", "Team5.bin", "Team6.bin"
                                        converter.Team_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()


                                    Case "Glove.bin", "Glove1.bin", "Glove2.bin", "Glove3.bin", "Glove4.bin", "Glove5.bin", "Glove6.bin"
                                        converter.Glove(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "Tactics.bin", "Tactics1.bin", "Tactics2.bin", "Tactics3.bin", "Tactics4.bin", "Tactics5.bin", "Tactics6.bin"
                                        converter.Tactics_toConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case "TacticsFormation.bin", "TacticsFormation1.bin", "TacticsFormation2.bin", "TacticsFormation3.bin", "TacticsFormation4.bin", "TacticsFormation5.bin", "TacticsFormation6.bin"
                                        converter.Tactics_FormationToConsole(unzlib_memstream)
                                        unzlib_memstream.Position = 0
                                        zlib1.zlib_memstream_to_console(unzlib_memstream, archivo)
                                        Stream_file.Close()
                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox(Nombre & " Succefully Converted to Console Format")
                                        End If
                                        unzlib_memstream.Close()

                                    Case Else

                                        If OpenPes.FileNames.Count = 1 Then
                                            MsgBox("File Not Recognized as Pes 2014 Database file or not supported sorry")
                                        End If
                                        Contador_errores += 1
                                End Select


                            Else
                                If OpenPes.FileNames.Count = 1 Then
                                    MsgBox("File Must be size 0 or corrupt")
                                End If

                                Contador_errores += 1
                            End If


                        Else
                            If OpenPes.FileNames.Count = 1 Then
                                MsgBox("File Must be size 0 or corrupt Or not a Pes 2014 database file")
                            End If
                            Contador_errores += 1

                        End If
                    Else
                        If OpenPes.FileNames.Count = 1 Then
                            MsgBox("File Must be size 0 or corrupt")
                        End If

                        Contador_errores += 1

                    End If

                Catch Ex As Exception
                    If OpenPes.FileNames.Count = 1 Then
                        MsgBox("Unknown error: " + Ex.ToString)
                    End If
                    Contador_errores += 1

                End Try
                ProgressBar1.Increment(1)
            Next archivo


        Else
            MsgBox("No File Selected!!!!!")
        End If

        If OpenPes.FileNames.Count <> 1 And OpenPes.FileNames.Count <> 0 And Pc_or_console <> "UnkNown Format" Then

            MsgBox((OpenPes.FileNames.Count - Contador_errores).ToString & " Files Succefully Converted " & Pc_or_console & " Format." & vbCrLf & Contador_errores.ToString & " Files Was Sized 0 or corrupt from a total of " & OpenPes.FileNames.Count.ToString & " Files.")

        End If



    End Sub

    Public Shared Sub Ordenar_boot_glove()
        Dim Aux = 0, Id As UInt32
        Dim Num_botas As UInteger = Form1.unzlib_Boots_list.Length / 8 - 1
        Dim ID_equipos_array(Num_botas) As UInt32


        If Form1.Boot_List_present = True Then

            Form1.Leer_Boots_list.BaseStream.Position = 0

            For i = 0 To Form1.unzlib_Boots_list.Length / 8 - 1
                ID_equipos_array(i) = swaps.swap32(Form1.Leer_Boots_list.ReadUInt32)
                Form1.Leer_Boots_list.BaseStream.Position += 4
            Next

            Dim aux_mem_stream As New MemoryStream()
            Form1.unzlib_Boots_list.CopyTo(aux_mem_stream)

            Array.Sort(ID_equipos_array)






        End If



    End Sub

End Class
