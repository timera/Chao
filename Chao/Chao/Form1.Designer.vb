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
        Me.yLabel = New System.Windows.Forms.Label()
        Me.xLabel = New System.Windows.Forms.Label()
        Me.O = New System.Windows.Forms.Label()
        Me.setup_finish = New System.Windows.Forms.Button()
        Me.Picture_machine = New System.Windows.Forms.PictureBox()
        Me.GroupBox_Plot = New System.Windows.Forms.GroupBox()
        Me.p1Label = New System.Windows.Forms.Label()
        Me.p2Label = New System.Windows.Forms.Label()
        Me.p3Label = New System.Windows.Forms.Label()
        Me.p4Label = New System.Windows.Forms.Label()
        Me.p5Label = New System.Windows.Forms.Label()
        Me.p6Label = New System.Windows.Forms.Label()
        Me.GroupBox_A1_A2_A3.SuspendLayout()
        Me.GroupBox_A4.SuspendLayout()
        CType(Me.Picture_machine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_Plot.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox_machine_list
        '
        Me.ComboBox_machine_list.FormattingEnabled = True
        Me.ComboBox_machine_list.Items.AddRange(New Object() {"開挖機", "拖索開挖機", "抓斗開挖機", "履帶起重機", "推土機", "牽引裝料機", "振動式打樁機", "鑽岩機", "壓路機", "輪胎式壓路機", "振動式壓路機", "瀝青混凝土舖料機(延長部分除外)", "混凝土割切機", "發電機(不含輪胎)", "空氣壓縮機(不含輪胎)", "卡車起重機", "輪形起重機", "混凝土泵", "油壓式打樁機", "油壓式鋼管壓入機", "拔樁機", "油壓式壓入拉拔樁機", "土壤取樣器", "全套管鑽掘機", "鑽土機", "混凝土破碎機"})
        Me.ComboBox_machine_list.Location = New System.Drawing.Point(27, 48)
        Me.ComboBox_machine_list.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboBox_machine_list.Name = "ComboBox_machine_list"
        Me.ComboBox_machine_list.Size = New System.Drawing.Size(381, 23)
        Me.ComboBox_machine_list.TabIndex = 0
        Me.ComboBox_machine_list.Text = "請選擇"
        '
        'Label_machine_choose
        '
        Me.Label_machine_choose.AutoSize = True
        Me.Label_machine_choose.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_machine_choose.Location = New System.Drawing.Point(20, 11)
        Me.Label_machine_choose.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_machine_choose.Name = "Label_machine_choose"
        Me.Label_machine_choose.Size = New System.Drawing.Size(123, 35)
        Me.Label_machine_choose.TabIndex = 1
        Me.Label_machine_choose.Text = "機具選擇"
        '
        'Label_machine_pic
        '
        Me.Label_machine_pic.AutoSize = True
        Me.Label_machine_pic.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_machine_pic.Location = New System.Drawing.Point(21, 81)
        Me.Label_machine_pic.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_machine_pic.Name = "Label_machine_pic"
        Me.Label_machine_pic.Size = New System.Drawing.Size(92, 25)
        Me.Label_machine_pic.TabIndex = 3
        Me.Label_machine_pic.Text = "機具圖示"
        '
        'Label_input_L
        '
        Me.Label_input_L.AutoSize = True
        Me.Label_input_L.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_input_L.Location = New System.Drawing.Point(16, 29)
        Me.Label_input_L.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_input_L.Name = "Label_input_L"
        Me.Label_input_L.Size = New System.Drawing.Size(97, 35)
        Me.Label_input_L.TabIndex = 4
        Me.Label_input_L.Text = "輸入L :"
        '
        'Label_r1
        '
        Me.Label_r1.AutoSize = True
        Me.Label_r1.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_r1.Location = New System.Drawing.Point(76, 64)
        Me.Label_r1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_r1.Name = "Label_r1"
        Me.Label_r1.Size = New System.Drawing.Size(40, 35)
        Me.Label_r1.TabIndex = 5
        Me.Label_r1.Text = "r :"
        '
        'TextBox_L
        '
        Me.TextBox_L.Location = New System.Drawing.Point(140, 34)
        Me.TextBox_L.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_L.Name = "TextBox_L"
        Me.TextBox_L.Size = New System.Drawing.Size(131, 25)
        Me.TextBox_L.TabIndex = 6
        '
        'TextBox_r1
        '
        Me.TextBox_r1.Location = New System.Drawing.Point(140, 69)
        Me.TextBox_r1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_r1.Name = "TextBox_r1"
        Me.TextBox_r1.Size = New System.Drawing.Size(131, 25)
        Me.TextBox_r1.TabIndex = 7
        '
        'Button_L_check
        '
        Me.Button_L_check.Location = New System.Drawing.Point(292, 34)
        Me.Button_L_check.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_L_check.Name = "Button_L_check"
        Me.Button_L_check.Size = New System.Drawing.Size(56, 26)
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
        Me.GroupBox_A1_A2_A3.Location = New System.Drawing.Point(579, 48)
        Me.GroupBox_A1_A2_A3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox_A1_A2_A3.Name = "GroupBox_A1_A2_A3"
        Me.GroupBox_A1_A2_A3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox_A1_A2_A3.Size = New System.Drawing.Size(371, 118)
        Me.GroupBox_A1_A2_A3.TabIndex = 9
        Me.GroupBox_A1_A2_A3.TabStop = False
        Me.GroupBox_A1_A2_A3.Text = "A1 or A2 or A3"
        '
        'Label_input_L1
        '
        Me.Label_input_L1.AutoSize = True
        Me.Label_input_L1.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_input_L1.Location = New System.Drawing.Point(8, 21)
        Me.Label_input_L1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_input_L1.Name = "Label_input_L1"
        Me.Label_input_L1.Size = New System.Drawing.Size(113, 35)
        Me.Label_input_L1.TabIndex = 10
        Me.Label_input_L1.Text = "輸入L1 :"
        '
        'Label_input_L3
        '
        Me.Label_input_L3.AutoSize = True
        Me.Label_input_L3.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_input_L3.Location = New System.Drawing.Point(8, 86)
        Me.Label_input_L3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_input_L3.Name = "Label_input_L3"
        Me.Label_input_L3.Size = New System.Drawing.Size(113, 35)
        Me.Label_input_L3.TabIndex = 11
        Me.Label_input_L3.Text = "輸入L3 :"
        '
        'Label_input_L2
        '
        Me.Label_input_L2.AutoSize = True
        Me.Label_input_L2.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_input_L2.Location = New System.Drawing.Point(8, 54)
        Me.Label_input_L2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_input_L2.Name = "Label_input_L2"
        Me.Label_input_L2.Size = New System.Drawing.Size(113, 35)
        Me.Label_input_L2.TabIndex = 12
        Me.Label_input_L2.Text = "輸入L2 :"
        '
        'Label_r2
        '
        Me.Label_r2.AutoSize = True
        Me.Label_r2.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_r2.Location = New System.Drawing.Point(73, 136)
        Me.Label_r2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_r2.Name = "Label_r2"
        Me.Label_r2.Size = New System.Drawing.Size(40, 35)
        Me.Label_r2.TabIndex = 13
        Me.Label_r2.Text = "r :"
        '
        'TextBox_L1
        '
        Me.TextBox_L1.Location = New System.Drawing.Point(137, 26)
        Me.TextBox_L1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_L1.Name = "TextBox_L1"
        Me.TextBox_L1.Size = New System.Drawing.Size(131, 25)
        Me.TextBox_L1.TabIndex = 14
        '
        'TextBox_L2
        '
        Me.TextBox_L2.Location = New System.Drawing.Point(137, 59)
        Me.TextBox_L2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_L2.Name = "TextBox_L2"
        Me.TextBox_L2.Size = New System.Drawing.Size(131, 25)
        Me.TextBox_L2.TabIndex = 15
        '
        'TextBox_L3
        '
        Me.TextBox_L3.Location = New System.Drawing.Point(137, 91)
        Me.TextBox_L3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_L3.Name = "TextBox_L3"
        Me.TextBox_L3.Size = New System.Drawing.Size(131, 25)
        Me.TextBox_L3.TabIndex = 16
        '
        'TextBox_r2
        '
        Me.TextBox_r2.Location = New System.Drawing.Point(137, 141)
        Me.TextBox_r2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox_r2.Name = "TextBox_r2"
        Me.TextBox_r2.Size = New System.Drawing.Size(131, 25)
        Me.TextBox_r2.TabIndex = 17
        '
        'Button_L1_L2_L3_check
        '
        Me.Button_L1_L2_L3_check.Location = New System.Drawing.Point(289, 92)
        Me.Button_L1_L2_L3_check.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_L1_L2_L3_check.Name = "Button_L1_L2_L3_check"
        Me.Button_L1_L2_L3_check.Size = New System.Drawing.Size(56, 26)
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
        Me.GroupBox_A4.Location = New System.Drawing.Point(579, 211)
        Me.GroupBox_A4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox_A4.Name = "GroupBox_A4"
        Me.GroupBox_A4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox_A4.Size = New System.Drawing.Size(371, 211)
        Me.GroupBox_A4.TabIndex = 18
        Me.GroupBox_A4.TabStop = False
        Me.GroupBox_A4.Text = "A4"
        '
        'yLabel
        '
        Me.yLabel.AutoSize = True
        Me.yLabel.Location = New System.Drawing.Point(453, 452)
        Me.yLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.yLabel.Name = "yLabel"
        Me.yLabel.Size = New System.Drawing.Size(17, 15)
        Me.yLabel.TabIndex = 19
        Me.yLabel.Text = "Y"
        '
        'xLabel
        '
        Me.xLabel.AutoSize = True
        Me.xLabel.Location = New System.Drawing.Point(713, 635)
        Me.xLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xLabel.Name = "xLabel"
        Me.xLabel.Size = New System.Drawing.Size(17, 15)
        Me.xLabel.TabIndex = 20
        Me.xLabel.Text = "X"
        '
        'O
        '
        Me.O.AutoSize = True
        Me.O.Location = New System.Drawing.Point(432, 644)
        Me.O.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.O.Name = "O"
        Me.O.Size = New System.Drawing.Size(0, 15)
        Me.O.TabIndex = 21
        '
        'setup_finish
        '
        Me.setup_finish.Location = New System.Drawing.Point(873, 780)
        Me.setup_finish.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.setup_finish.Name = "setup_finish"
        Me.setup_finish.Size = New System.Drawing.Size(96, 35)
        Me.setup_finish.TabIndex = 25
        Me.setup_finish.Text = "設置完成"
        Me.setup_finish.UseVisualStyleBackColor = True
        '
        'Picture_machine
        '
        Me.Picture_machine.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Picture_machine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture_machine.Location = New System.Drawing.Point(27, 116)
        Me.Picture_machine.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Picture_machine.Name = "Picture_machine"
        Me.Picture_machine.Size = New System.Drawing.Size(510, 306)
        Me.Picture_machine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Picture_machine.TabIndex = 2
        Me.Picture_machine.TabStop = False
        '
        'GroupBox_Plot
        '
        Me.GroupBox_Plot.Controls.Add(Me.p6Label)
        Me.GroupBox_Plot.Controls.Add(Me.p1Label)
        Me.GroupBox_Plot.Controls.Add(Me.p5Label)
        Me.GroupBox_Plot.Controls.Add(Me.p2Label)
        Me.GroupBox_Plot.Controls.Add(Me.p4Label)
        Me.GroupBox_Plot.Controls.Add(Me.p3Label)
        Me.GroupBox_Plot.Location = New System.Drawing.Point(360, 430)
        Me.GroupBox_Plot.Name = "GroupBox_Plot"
        Me.GroupBox_Plot.Size = New System.Drawing.Size(400, 330)
        Me.GroupBox_Plot.TabIndex = 29
        Me.GroupBox_Plot.TabStop = False
        '
        'p1Label
        '
        Me.p1Label.AutoSize = True
        Me.p1Label.Location = New System.Drawing.Point(370, 63)
        Me.p1Label.Name = "p1Label"
        Me.p1Label.Size = New System.Drawing.Size(0, 15)
        Me.p1Label.TabIndex = 30
        '
        'p2Label
        '
        Me.p2Label.AutoSize = True
        Me.p2Label.Location = New System.Drawing.Point(370, 100)
        Me.p2Label.Name = "p2Label"
        Me.p2Label.Size = New System.Drawing.Size(0, 15)
        Me.p2Label.TabIndex = 31
        '
        'p3Label
        '
        Me.p3Label.AutoSize = True
        Me.p3Label.Location = New System.Drawing.Point(370, 132)
        Me.p3Label.Name = "p3Label"
        Me.p3Label.Size = New System.Drawing.Size(0, 15)
        Me.p3Label.TabIndex = 32
        '
        'p4Label
        '
        Me.p4Label.AutoSize = True
        Me.p4Label.Location = New System.Drawing.Point(370, 166)
        Me.p4Label.Name = "p4Label"
        Me.p4Label.Size = New System.Drawing.Size(0, 15)
        Me.p4Label.TabIndex = 33
        '
        'p5Label
        '
        Me.p5Label.AutoSize = True
        Me.p5Label.Location = New System.Drawing.Point(370, 203)
        Me.p5Label.Name = "p5Label"
        Me.p5Label.Size = New System.Drawing.Size(0, 15)
        Me.p5Label.TabIndex = 34
        '
        'p6Label
        '
        Me.p6Label.AutoSize = True
        Me.p6Label.Location = New System.Drawing.Point(370, 241)
        Me.p6Label.Name = "p6Label"
        Me.p6Label.Size = New System.Drawing.Size(0, 15)
        Me.p6Label.TabIndex = 35
        '
        'Machine_choose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(1035, 769)
        Me.Controls.Add(Me.setup_finish)
        Me.Controls.Add(Me.O)
        Me.Controls.Add(Me.xLabel)
        Me.Controls.Add(Me.yLabel)
        Me.Controls.Add(Me.GroupBox_A4)
        Me.Controls.Add(Me.GroupBox_A1_A2_A3)
        Me.Controls.Add(Me.Label_machine_pic)
        Me.Controls.Add(Me.Picture_machine)
        Me.Controls.Add(Me.Label_machine_choose)
        Me.Controls.Add(Me.ComboBox_machine_list)
        Me.Controls.Add(Me.GroupBox_Plot)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Machine_choose"
        Me.Text = "機具選擇畫面"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox_A1_A2_A3.ResumeLayout(False)
        Me.GroupBox_A1_A2_A3.PerformLayout()
        Me.GroupBox_A4.ResumeLayout(False)
        Me.GroupBox_A4.PerformLayout()
        CType(Me.Picture_machine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_Plot.ResumeLayout(False)
        Me.GroupBox_Plot.PerformLayout()
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
    Friend WithEvents yLabel As System.Windows.Forms.Label
    Friend WithEvents xLabel As System.Windows.Forms.Label
    Friend WithEvents O As System.Windows.Forms.Label
    Friend WithEvents setup_finish As System.Windows.Forms.Button
    Friend WithEvents GroupBox_Plot As System.Windows.Forms.GroupBox
    Friend WithEvents p6Label As System.Windows.Forms.Label
    Friend WithEvents p1Label As System.Windows.Forms.Label
    Friend WithEvents p5Label As System.Windows.Forms.Label
    Friend WithEvents p2Label As System.Windows.Forms.Label
    Friend WithEvents p4Label As System.Windows.Forms.Label
    Friend WithEvents p3Label As System.Windows.Forms.Label

End Class
