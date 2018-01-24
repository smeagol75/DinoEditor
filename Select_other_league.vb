Public Class Select_other_league

    Private Sub Select_other_league_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
     
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Select Case ComboBox1.SelectedIndex
            Case 0

                Form1.Liga_nojugable_elegida = 1

            Case 1
                Form1.Liga_nojugable_elegida = 2
            Case 2
                Form1.Liga_nojugable_elegida = 3
            Case 3
                Form1.Liga_nojugable_elegida = 4
            Case 4
                Form1.Liga_nojugable_elegida = 5
            Case 5
                Form1.Liga_nojugable_elegida = 6
            Case 6
                Form1.Liga_nojugable_elegida = 7

            Case Else
                Form1.Liga_nojugable_elegida = 0

        End Select


        Form1.Show()

        Me.Hide()

    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()

    End Sub
End Class