Imports Db_Xbox_editor


Public Class Select_a_Team_toReplace




    Private Sub Select_a_Team_toReplace_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Db_Xbox_editor.Form1.Label_form2
        Db_Xbox_editor.Form1.ComboBox1.BringToFront()

        If ComboBox1.Items.Count = 0 Or Form1.ListBox3.Items.Count > Form1.ComboBox1.Items.Count Then
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""

            For i = 0 To Db_Xbox_editor.Form1.ListBox3.Items.Count - 1
                Dim Selected_item As Object = Db_Xbox_editor.Form1.ListBox3.Items(i)
                ComboBox1.Items.Add(Selected_item)
            Next

        End If


    End Sub



  
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Db_Xbox_editor.Form1.CheckSelected = False
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If MsgBox("Do you want To Replace With " & ComboBox1.SelectedItem.ToString & " to " & Db_Xbox_editor.Form1.ListBox2.SelectedItem.ToString & " League ?", MsgBoxStyle.YesNo, "Add Team") = MsgBoxResult.Yes Then
            Db_Xbox_editor.Form1.combo1_selec_index = ComboBox1.SelectedIndex
            Db_Xbox_editor.Form1.CheckSelected = True
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        If (TextBox_search_team.Text <> String.Empty) Then

            Dim Start_index As UInteger = ComboBox1.SelectedIndex + 1
            Dim i As Integer = 0
            For i = Start_index To ComboBox1.Items.Count - 1
                Dim List_BOX_STR As String = ComboBox1.Items(i).ToUpper
                If List_BOX_STR.Contains(TextBox_search_team.Text.ToUpper) = True Then
                    ComboBox1.SelectedIndex = i
                    Exit For
                ElseIf i = ComboBox1.Items.Count - 1 Then
                    If MsgBox("Maybe your search was before the index, want to start from the beggining? ", MsgBoxStyle.YesNo, "Team Search") = MsgBoxResult.Yes Then
                        ComboBox1.SelectedIndex = 0
                        PictureBox2_Click(PictureBox2, Nothing)
                    Else
                        ComboBox1.SelectedIndex = 0
                    End If

                End If
            Next

        End If


    End Sub



    Private Sub TextBox_search_team_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox_search_team.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox2_Click(PictureBox2, Nothing)

        End If
    End Sub
End Class