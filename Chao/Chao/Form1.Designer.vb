<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Machine_choose
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
        Me.ComboBox_machine_list = New System.Windows.Forms.ComboBox()
        Me.Label_machine_choose = New System.Windows.Forms.Label()
        Me.Label_machine_pic = New System.Windows.Forms.Label()
        Me.Label_input_L = New System.Windows.Forms.Label()
        Me.Label_r1 = New System.Windows.Forms.Label()
        Me.TextBox_L = New System.Windows.Forms.TextBox()
        Me.TextBox_r1 = New System.Windows.Forms.TextBox()
        Me.Button_L_check = New System.Windows.Forms.Button()
        Me.GroupBox_A1_A2_A3 = New System.Windows.Forms.GroupBox()
        Me.Label_input_L1 = New System.Windows.Forms.Label()
        Me.Label_input_L3 = New System.Windows.Forms.Label()
        Me.Label_input_L2 = New System.Windows.Forms.Label()
        Me.Label_r2 = New System.Windows.Forms.Label()
        Me.TextBox_L1 = New System.Windows.Forms.TextBox()
        Me.TextBox_L2 = New System.Windows.Forms.TextBox()
        Me.TextBox_L3 = New System.Windows.Forms.TextBox()
        Me.TextBox_r2 = New System.Windows.Forms.TextBox()
        Me.Button_L1_L2_L3_check = New System.Windows.Forms.Button()
        Me.GroupBox_A4 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.O = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.setup_finish = New System.Windows.Forms.Button()
        Me.Picture_machine = New System.Windows.Forms.PictureBox()
        Me.GroupBox_A1_A2_A3.SuspendLayout()
        Me.GroupBox_A4.SuspendLayout()
        CType(Me.Picture_machine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox_machine_list
        '
        Me.ComboBox_machine_list.FormattingEnabled = True
        Me.ComboBox_machine_list.Items.AddRange(New Object() {"開挖機", "拖索開挖機", "抓斗開挖機", "履帶起重機", "推土機", "牽引裝料機", "振動式打樁機", "鑽岩機", "壓路機", "輪胎式壓路機", "振動式壓路機", "瀝青混凝土舖料機(延長部分除外)", "混凝土割切機", "發電機(不含輪胎)", "空氣壓縮機(不含輪胎)", "卡車起重機", "輪形起重機", "混凝土泵", "油壓式打樁機", "油壓式鋼管壓入機", "拔樁機", "油壓式壓入拉拔樁機", "土壤取樣器", "全套管鑽掘機", "鑽土機", "混凝土破碎機"})
        Me.ComboBox_machine_list.Location = New System.Drawing.Point(20, 38)
        Me.ComboBox_machine_list.Name = "ComboBox_machine_list"
        Me.ComboBox_machine_list.Size = New System.Drawing.Size(287, 20)
        Me.ComboBox_machine_list.TabIndex = 0
        Me.ComboBox_machine_list.Text = "請選擇"
        '
        'Label_machine_choose
        '
        Me.Label_machine_choose.AutoSize = True
        Me.Label_machine_choose.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_machine_choose.Location = New System.Drawing.Point(15, 9)
        Me.Label_machine_choose.Name = "Label_machine_choose"
        Me.Label_machine_choose.Size = New System.Drawing.Size(96, 26)
        Me.Label_machine_choose.TabIndex = 1
        Me.Label_machine_choose.Text = "機具選擇"
        '
        'Label_machine_pic
        '
        Me.Label_machine_pic.AutoSize = True
        Me.Label_machine_pic.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_machine_pic.Location = New System.Drawing.Point(16, 65)
        Me.Label_machine_pic.Name = "Label_machine_pic"
        Me.Label_machine_pic.Size = New System.Drawing.Size(74, 21)
        Me.Label_machine_pic.TabIndex = 3
        Me.Label_machine_pic.Text = "機具圖示"
        '
        'Label_input_L
        '
        Me.Label_input_L.AutoSize = True
        Me.Label_input_L.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_input_L.Location = New System.Drawing.Point(12, 23)
        Me.Label_input_L.Name = "Label_input_L"
        Me.Label_input_L.Size = New System.Drawing.Size(75, 26)
        Me.Label_input_L.TabIndex = 4
        Me.Label_input_L.Text = "輸入L :"
        '
        'Label_r1
        '
        Me.Label_r1.AutoSize = True
        Me.Label_r1.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_r1.Location = New System.Drawing.Point(57, 51)
        Me.Label_r1.Name = "Label_r1"
        Me.Label_r1.Size = New System.Drawing.Size(30, 26)
        Me.Label_r1.TabIndex = 5
        Me.Label_r1.Text = "r :"
        '
        'TextBox_L
        '
        Me.TextBox_L.Location = New System.Drawing.Point(105, 27)
        Me.TextBox_L.Name = "TextBox_L"
        Me.TextBox_L.Size = New System.Drawing.Size(99, 22)
        Me.TextBox_L.TabIndex = 6
        '
        'TextBox_r1
        '
        Me.TextBox_r1.Location = New System.Drawing.Point(105, 55)
        Me.TextBox_r1.Name = "TextBox_r1"
        Me.TextBox_r1.Size = New System.Drawing.Size(99, 22)
        Me.TextBox_r1.TabIndex = 7
        '
        'Button_L_check
        '
        Me.Button_L_check.Location = New System.Drawing.Point(219, 27)
        Me.Button_L_check.Name = "Button_L_check"
        Me.Button_L_check.Size = New System.Drawing.Size(42, 21)
        Me.Button_L_check.TabIndex = 8
        Me.Button_L_check.Text = "確認"
        Me.Button_L_check.UseVisualStyleBackColor = True
        '
        'GroupBox_A1_A2_A3
        '
        Me.GroupBox_A1_A2_A3.Controls.Add(Me.Button_L_check)
        Me.GroupBox_A1_A2_A3.Controls.Add(Me.TextBox_r1)
        Me.GroupBox_A1_A2_A3.Controls.Add(Me.TextBox_L)
        Me.GroupBox_A1_A2_A3.Controls.Add(Me.Label_r1)
        Me.GroupBox_A1_A2_A3.Controls.Add(Me.Label_input_L)
        Me.GroupBox_A1_A2_A3.Location = New System.Drawing.Point(434, 38)
        Me.GroupBox_A1_A2_A3.Name = "GroupBox_A1_A2_A3"
        Me.GroupBox_A1_A2_A3.Size = New System.Drawing.Size(278, 94)
        Me.GroupBox_A1_A2_A3.TabIndex = 9
        Me.GroupBox_A1_A2_A3.TabStop = False
        Me.GroupBox_A1_A2_A3.Text = "A1 or A2 or A3"
        '
        'Label_input_L1
        '
        Me.Label_input_L1.AutoSize = True
        Me.Label_input_L1.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_input_L1.Location = New System.Drawing.Point(6, 17)
        Me.Label_input_L1.Name = "Label_input_L1"
        Me.Label_input_L1.Size = New System.Drawing.Size(88, 26)
        Me.Label_input_L1.TabIndex = 10
        Me.Label_input_L1.Text = "輸入L1 :"
        '
        'Label_input_L3
        '
        Me.Label_input_L3.AutoSize = True
        Me.Label_input_L3.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_input_L3.Location = New System.Drawing.Point(6, 69)
        Me.Label_input_L3.Name = "Label_input_L3"
        Me.Label_input_L3.Size = New System.Drawing.Size(88, 26)
        Me.Label_input_L3.TabIndex = 11
        Me.Label_input_L3.Text = "輸入L3 :"
        '
        'Label_input_L2
        '
        Me.Label_input_L2.AutoSize = True
        Me.Label_input_L2.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_input_L2.Location = New System.Drawing.Point(6, 43)
        Me.Label_input_L2.Name = "Label_input_L2"
        Me.Label_input_L2.Size = New System.Drawing.Size(88, 26)
        Me.Label_input_L2.TabIndex = 12
        Me.Label_input_L2.Text = "輸入L2 :"
        '
        'Label_r2
        '
        Me.Label_r2.AutoSize = True
        Me.Label_r2.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_r2.Location = New System.Drawing.Point(55, 109)
        Me.Label_r2.Name = "Label_r2"
        Me.Label_r2.Size = New System.Drawing.Size(30, 26)
        Me.Label_r2.TabIndex = 13
        Me.Label_r2.Text = "r :"
        '
        'TextBox_L1
        '
        Me.TextBox_L1.Location = New System.Drawing.Point(103, 21)
        Me.TextBox_L1.Name = "TextBox_L1"
        Me.TextBox_L1.Size = New System.Drawing.Size(99, 22)
        Me.TextBox_L1.TabIndex = 14
        '
        'TextBox_L2
        '
        Me.TextBox_L2.Location = New System.Drawing.Point(103, 47)
        Me.TextBox_L2.Name = "TextBox_L2"
        Me.TextBox_L2.Size = New System.Drawing.Size(99, 22)
        Me.TextBox_L2.TabIndex = 15
        '
        'TextBox_L3
        '
        Me.TextBox_L3.Location = New System.Drawing.Point(103, 73)
        Me.TextBox_L3.Name = "TextBox_L3"
        Me.TextBox_L3.Size = New System.Drawing.Size(99, 22)
        Me.TextBox_L3.TabIndex = 16
        '
        'TextBox_r2
        '
        Me.TextBox_r2.Location = New System.Drawing.Point(103, 113)
        Me.TextBox_r2.Name = "TextBox_r2"
        Me.TextBox_r2.Size = New System.Drawing.Size(99, 22)
        Me.TextBox_r2.TabIndex = 17
        '
        'Button_L1_L2_L3_check
        '
        Me.Button_L1_L2_L3_check.Location = New System.Drawing.Point(217, 74)
        Me.Button_L1_L2_L3_check.Name = "Button_L1_L2_L3_check"
        Me.Button_L1_L2_L3_check.Size = New System.Drawing.Size(42, 21)
        Me.Button_L1_L2_L3_check.TabIndex = 9
        Me.Button_L1_L2_L3_check.Text = "確認"
        Me.Button_L1_L2_L3_check.UseVisualStyleBackColor = True
        '
        'GroupBox_A4
        '
        Me.GroupBox_A4.Controls.Add(Me.Button_L1_L2_L3_check)
        Me.GroupBox_A4.Controls.Add(Me.TextBox_r2)
        Me.GroupBox_A4.Controls.Add(Me.TextBox_L3)
        Me.GroupBox_A4.Controls.Add(Me.TextBox_L2)
        Me.GroupBox_A4.Controls.Add(Me.TextBox_L1)
        Me.GroupBox_A4.Controls.Add(Me.Label_r2)
        Me.GroupBox_A4.Controls.Add(Me.Label_input_L2)
        Me.GroupBox_A4.Controls.Add(Me.Label_input_L3)
        Me.GroupBox_A4.Controls.Add(Me.Label_input_L1)
        Me.GroupBox_A4.Location = New System.Drawing.Point(434, 169)
        Me.GroupBox_A4.Name = "GroupBox_A4"
        Me.GroupBox_A4.Size = New System.Drawing.Size(278, 169)
        Me.GroupBox_A4.TabIndex = 18
        Me.GroupBox_A4.TabStop = False
        Me.GroupBox_A4.Text = "A4"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(340, 362)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 12)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Y"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(535, 508)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 12)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "X"
        '
        'O
        '
        Me.O.AutoSize = True
        Me.O.Location = New System.Drawing.Point(324, 515)
        Me.O.Name = "O"
        Me.O.Size = New System.Drawing.Size(0, 12)
        Me.O.TabIndex = 21
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(776, 664)
        Me.ShapeContainer1.TabIndex = 23
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 352
        Me.LineShape2.X2 = 352
        Me.LineShape2.Y1 = 362
        Me.LineShape2.Y2 = 651
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 181
        Me.LineShape1.X2 = 522
        Me.LineShape1.Y1 = 512
        Me.LineShape1.Y2 = 512
        '
        'setup_finish
        '
        Me.setup_finish.Location = New System.Drawing.Point(655, 624)
        Me.setup_finish.Name = "setup_finish"
        Me.setup_finish.Size = New System.Drawing.Size(72, 28)
        Me.setup_finish.TabIndex = 25
        Me.setup_finish.Text = "設置完成"
        Me.setup_finish.UseVisualStyleBackColor = True
        '
        'Picture_machine
        '
        Me.Picture_machine.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Picture_machine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture_machine.Location = New System.Drawing.Point(20, 93)
        Me.Picture_machine.Name = "Picture_machine"
        Me.Picture_machine.Size = New System.Drawing.Size(383, 245)
        Me.Picture_machine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Picture_machine.TabIndex = 2
        Me.Picture_machine.TabStop = False
        '
        'Machine_choose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(776, 664)
        Me.Controls.Add(Me.setup_finish)
        Me.Controls.Add(Me.O)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox_A4)
        Me.Controls.Add(Me.GroupBox_A1_A2_A3)
        Me.Controls.Add(Me.Label_machine_pic)
        Me.Controls.Add(Me.Picture_machine)
        Me.Controls.Add(Me.Label_machine_choose)
        Me.Controls.Add(Me.ComboBox_machine_list)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.IsMdiContainer = True
        Me.Name = "Machine_choose"
        Me.Text = "機具選擇畫面"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox_A1_A2_A3.ResumeLayout(False)
        Me.GroupBox_A1_A2_A3.PerformLayout()
        Me.GroupBox_A4.ResumeLayout(False)
        Me.GroupBox_A4.PerformLayout()
        CType(Me.Picture_machine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox_machine_list As System.Windows.Forms.ComboBox
    Friend WithEvents Label_machine_choose As System.Windows.Forms.Label
    Friend WithEvents Picture_machine As System.Windows.Forms.PictureBox
    Friend WithEvents Label_machine_pic As System.Windows.Forms.Label
    Friend WithEvents Label_input_L As System.Windows.Forms.Label
    Friend WithEvents Label_r1 As System.Windows.Forms.Label
    Friend WithEvents TextBox_L As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_r1 As System.Windows.Forms.TextBox
    Friend WithEvents Button_L_check As System.Windows.Forms.Button
    Friend WithEvents GroupBox_A1_A2_A3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label_input_L1 As System.Windows.Forms.Label
    Friend WithEvents Label_input_L3 As System.Windows.Forms.Label
    Friend WithEvents Label_input_L2 As System.Windows.Forms.Label
    Friend WithEvents Label_r2 As System.Windows.Forms.Label
    Friend WithEvents TextBox_L1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_L2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_L3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_r2 As System.Windows.Forms.TextBox
    Friend WithEvents Button_L1_L2_L3_check As System.Windows.Forms.Button
    Friend WithEvents GroupBox_A4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents O As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents setup_finish As System.Windows.Forms.Button

End Class
