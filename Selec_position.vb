Public Class Selec_position

    Private Sub Selec_position_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub


    
    Private Sub TextBox11_DoubleClick(sender As System.Object, e As System.EventArgs) Handles TextBox9.DoubleClick, TextBox8.DoubleClick, TextBox7.DoubleClick, TextBox6.DoubleClick, TextBox5.DoubleClick, TextBox4.DoubleClick, TextBox3.DoubleClick, TextBox2.DoubleClick, TextBox12.DoubleClick, TextBox11.DoubleClick, TextBox10.DoubleClick, TextBox1.DoubleClick
        Dim tChanged As TextBox = DirectCast(sender, TextBox)
        Form1.pos_jug = tChanged.Text
        Form1.color_jug = tChanged.BackColor

        Form1.Show()
        Me.Close()

    End Sub

    Private Sub Selec_position_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Show()
    End Sub
End Class