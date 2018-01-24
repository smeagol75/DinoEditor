<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Add_team
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Add_team))
        Me.New_team_Id_box = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.New_Coach_Id_box = New System.Windows.Forms.NumericUpDown()
        Me.New_tactic_slot2 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.New_tactic_slot1 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Number_Players_create_box = New System.Windows.Forms.NumericUpDown()
        Me.New_Team_name = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.New_formation_slot2 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.New_Formation_slot1 = New System.Windows.Forms.NumericUpDown()
        CType(Me.New_team_Id_box, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.New_Coach_Id_box, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.New_tactic_slot2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.New_tactic_slot1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Number_Players_create_box, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.New_formation_slot2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.New_Formation_slot1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'New_team_Id_box
        '
        Me.New_team_Id_box.Location = New System.Drawing.Point(123, 120)
        Me.New_team_Id_box.Name = "New_team_Id_box"
        Me.New_team_Id_box.Size = New System.Drawing.Size(66, 22)
        Me.New_team_Id_box.TabIndex = 0
        Me.New_team_Id_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(212, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "New Team Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "New Coach Id"
        '
        'New_Coach_Id_box
        '
        Me.New_Coach_Id_box.Location = New System.Drawing.Point(123, 174)
        Me.New_Coach_Id_box.Name = "New_Coach_Id_box"
        Me.New_Coach_Id_box.Size = New System.Drawing.Size(66, 22)
        Me.New_Coach_Id_box.TabIndex = 2
        Me.New_Coach_Id_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'New_tactic_slot2
        '
        Me.New_tactic_slot2.Location = New System.Drawing.Point(123, 281)
        Me.New_tactic_slot2.Name = "New_tactic_slot2"
        Me.New_tactic_slot2.Size = New System.Drawing.Size(66, 22)
        Me.New_tactic_slot2.TabIndex = 6
        Me.New_tactic_slot2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(199, 265)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "New Tactics Slots"
        '
        'New_tactic_slot1
        '
        Me.New_tactic_slot1.Location = New System.Drawing.Point(123, 241)
        Me.New_tactic_slot1.Name = "New_tactic_slot1"
        Me.New_tactic_slot1.Size = New System.Drawing.Size(66, 22)
        Me.New_tactic_slot1.TabIndex = 4
        Me.New_tactic_slot1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(212, 460)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(187, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Number of Players to Create"
        '
        'Number_Players_create_box
        '
        Me.Number_Players_create_box.Location = New System.Drawing.Point(123, 456)
        Me.Number_Players_create_box.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.Number_Players_create_box.Name = "Number_Players_create_box"
        Me.Number_Players_create_box.Size = New System.Drawing.Size(66, 22)
        Me.Number_Players_create_box.TabIndex = 9
        Me.Number_Players_create_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Number_Players_create_box.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'New_Team_name
        '
        Me.New_Team_name.Location = New System.Drawing.Point(95, 66)
        Me.New_Team_name.Name = "New_Team_name"
        Me.New_Team_name.Size = New System.Drawing.Size(269, 22)
        Me.New_Team_name.TabIndex = 11
        Me.New_Team_name.Text = "Smeagol75 F.C."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(148, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "New Team Name"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(175, 512)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 38)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Create"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'New_formation_slot2
        '
        Me.New_formation_slot2.Location = New System.Drawing.Point(123, 375)
        Me.New_formation_slot2.Name = "New_formation_slot2"
        Me.New_formation_slot2.Size = New System.Drawing.Size(66, 22)
        Me.New_formation_slot2.TabIndex = 16
        Me.New_formation_slot2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(199, 359)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "New Formation Slots"
        '
        'New_Formation_slot1
        '
        Me.New_Formation_slot1.Location = New System.Drawing.Point(123, 335)
        Me.New_Formation_slot1.Name = "New_Formation_slot1"
        Me.New_Formation_slot1.Size = New System.Drawing.Size(66, 22)
        Me.New_Formation_slot1.TabIndex = 14
        Me.New_Formation_slot1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Add_team
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 589)
        Me.Controls.Add(Me.New_formation_slot2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.New_Formation_slot1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.New_Team_name)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Number_Players_create_box)
        Me.Controls.Add(Me.New_tactic_slot2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.New_tactic_slot1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.New_Coach_Id_box)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.New_team_Id_box)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Add_team"
        Me.Text = "Add Team "
        CType(Me.New_team_Id_box, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.New_Coach_Id_box, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.New_tactic_slot2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.New_tactic_slot1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Number_Players_create_box, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.New_formation_slot2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.New_Formation_slot1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents New_team_Id_box As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents New_Coach_Id_box As System.Windows.Forms.NumericUpDown
    Friend WithEvents New_tactic_slot2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents New_tactic_slot1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Number_Players_create_box As System.Windows.Forms.NumericUpDown
    Friend WithEvents New_Team_name As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents New_formation_slot2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents New_Formation_slot1 As System.Windows.Forms.NumericUpDown
End Class
