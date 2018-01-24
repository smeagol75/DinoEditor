Public Class Language_sel




    Private Sub Language_sel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Select Case Form1.Language
            Case 1
                RadioButton1.Checked = True
            Case 2
                RadioButton2.Checked = True
            Case 3
                RadioButton3.Checked = True
            Case 4
                RadioButton4.Checked = True
            Case 5
                RadioButton5.Checked = True
            Case 6
                RadioButton6.Checked = True
            Case 7
                RadioButton7.Checked = True
            Case 8
                RadioButton8.Checked = True
            Case 9
                RadioButton9.Checked = True
            Case 10
                RadioButton10.Checked = True
            Case 11
                RadioButton11.Checked = True
            Case 12
                RadioButton12.Checked = True
            Case 13
                RadioButton13.Checked = True
            Case 14
                RadioButton14.Checked = True
            Case 15
                RadioButton15.Checked = True
            Case 16
                RadioButton16.Checked = True
          
        End Select
        If Form1.Language_read_1 = 1 Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
        If Form1.Language_read_2 = 1 Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If
        If Form1.Language_read_3 = 1 Then
            CheckBox4.Checked = True
        Else
            CheckBox4.Checked = False
        End If
        If Form1.Language_read_4 = 1 Then
            CheckBox5.Checked = True
        Else
            CheckBox5.Checked = False
        End If
        If Form1.Language_read_5 = 1 Then
            CheckBox6.Checked = True
        Else
            CheckBox6.Checked = False
        End If
        If Form1.Language_read_6 = 1 Then
            CheckBox7.Checked = True
        Else
            CheckBox7.Checked = False
        End If
        If Form1.Language_read_7 = 1 Then
            CheckBox8.Checked = True
        Else
            CheckBox8.Checked = False
        End If
        If Form1.Language_read_8 = 1 Then
            CheckBox15.Checked = True
        Else
            CheckBox15.Checked = False
        End If
        If Form1.Language_read_9 = 1 Then
            CheckBox14.Checked = True
        Else
            CheckBox14.Checked = False
        End If
        If Form1.Language_read_10 = 1 Then
            CheckBox13.Checked = True
        Else
            CheckBox13.Checked = False
        End If
        If Form1.Language_read_11 = 1 Then
            CheckBox12.Checked = True
        Else
            CheckBox12.Checked = False
        End If
        If Form1.Language_read_12 = 1 Then
            CheckBox11.Checked = True
        Else
            CheckBox11.Checked = False
        End If
        If Form1.Language_read_13 = 1 Then
            CheckBox10.Checked = True
        Else
            CheckBox10.Checked = False
        End If
        If Form1.Language_read_14 = 1 Then
            CheckBox9.Checked = True
        Else
            CheckBox9.Checked = False
        End If
        If Form1.Language_read_15 = 1 Then
            CheckBox17.Checked = True
        Else
            CheckBox17.Checked = False
        End If
        If Form1.Language_read_16 = 1 Then
            CheckBox16.Checked = True
        Else
            CheckBox16.Checked = False
        End If




    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            Form1.Show_sel = 1
        Else
            Form1.Show_sel = 0
        End If

        If RadioButton1.Checked = True Then
            Form1.Language = 1
        ElseIf RadioButton2.Checked = True Then
            Form1.Language = 2
        ElseIf RadioButton3.Checked = True Then
            Form1.Language = 3
        ElseIf RadioButton4.Checked = True Then
            Form1.Language = 4
        ElseIf RadioButton5.Checked = True Then
            Form1.Language = 5
        ElseIf RadioButton6.Checked = True Then
            Form1.Language = 6
        ElseIf RadioButton7.Checked = True Then
            Form1.Language = 7
        ElseIf RadioButton8.Checked = True Then
            Form1.Language = 8
        ElseIf RadioButton9.Checked = True Then
            Form1.Language = 9
        ElseIf RadioButton10.Checked = True Then
            Form1.Language = 10
        ElseIf RadioButton11.Checked = True Then
            Form1.Language = 11
        ElseIf RadioButton12.Checked = True Then
            Form1.Language = 12
        ElseIf RadioButton13.Checked = True Then
            Form1.Language = 13
        ElseIf RadioButton14.Checked = True Then
            Form1.Language = 14
        ElseIf RadioButton15.Checked = True Then
            Form1.Language = 15
        ElseIf RadioButton16.Checked = True Then
            Form1.Language = 16

        End If
        If CheckBox2.Checked = True Then
            Form1.Language_read_1 = 1
        Else
            Form1.Language_read_1 = 0
        End If
        If CheckBox3.Checked = True Then
            Form1.Language_read_2 = 1
        Else
            Form1.Language_read_2 = 0
        End If
        If CheckBox4.Checked = True Then
            Form1.Language_read_3 = 1
        Else
            Form1.Language_read_3 = 0
        End If
        If CheckBox5.Checked = True Then
            Form1.Language_read_4 = 1
        Else
            Form1.Language_read_4 = 0
        End If
        If CheckBox6.Checked = True Then
            Form1.Language_read_5 = 1
        Else
            Form1.Language_read_5 = 0
        End If
        If CheckBox7.Checked = True Then
            Form1.Language_read_6 = 1
        Else
            Form1.Language_read_6 = 0
        End If
        If CheckBox8.Checked = True Then
            Form1.Language_read_7 = 1
        Else
            Form1.Language_read_7 = 0
        End If
        If CheckBox15.Checked = True Then
            Form1.Language_read_8 = 1
        Else
            Form1.Language_read_8 = 0
        End If
        If CheckBox14.Checked = True Then
            Form1.Language_read_9 = 1
        Else
            Form1.Language_read_9 = 0
        End If
        If CheckBox13.Checked = True Then
            Form1.Language_read_10 = 1
        Else
            Form1.Language_read_10 = 0
        End If
        If CheckBox12.Checked = True Then
            Form1.Language_read_11 = 1
        Else
            Form1.Language_read_11 = 0
        End If
        If CheckBox11.Checked = True Then
            Form1.Language_read_12 = 1
        Else
            Form1.Language_read_12 = 0
        End If
        If CheckBox10.Checked = True Then
            Form1.Language_read_13 = 1
        Else
            Form1.Language_read_13 = 0
        End If
        If CheckBox9.Checked = True Then
            Form1.Language_read_14 = 1
        Else
            Form1.Language_read_14 = 0
        End If
        If CheckBox17.Checked = True Then
            Form1.Language_read_15 = 1
        Else
            Form1.Language_read_15 = 0
        End If
        If CheckBox16.Checked = True Then
            Form1.Language_read_16 = 1
        Else
            Form1.Language_read_16 = 0
        End If



        Form1.Show()
        Me.Close()


    End Sub
End Class