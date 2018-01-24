Imports Db_Xbox_editor


Public Class Select_Skin_colour

    Private Sub Select_Skin_colour_load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = Form1.skincol
        ' NumericUpDown2.Value = Form1.Eyescol
      


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Form1.skincol = NumericUpDown1.Value
        ' Form1.Eyescol = NumericUpDown2.Value
        Me.Close()
        Form1.Show()
    End Sub
End Class