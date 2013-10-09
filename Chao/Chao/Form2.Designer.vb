<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label_Background = New System.Windows.Forms.Label()
        Me.Label_1st = New System.Windows.Forms.Label()
        Me.Label_2nd = New System.Windows.Forms.Label()
        Me.Label_3rd = New System.Windows.Forms.Label()
        Me.Label_Additional = New System.Windows.Forms.Label()
        Me.Label_RSS = New System.Windows.Forms.Label()
        Me.Button_BGcheck = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.startButton = New System.Windows.Forms.Button()
        Me.timeLabel = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.light_1st = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.light_2nd = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.light_3rd = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.light_Additional = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.light_RSS = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.light_BG = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.stopButton = New System.Windows.Forms.Button()
        Me.continueButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label_Background
        '
        Me.Label_Background.AutoSize = True
        Me.Label_Background.Location = New System.Drawing.Point(68, 21)
        Me.Label_Background.Name = "Label_Background"
        Me.Label_Background.Size = New System.Drawing.Size(63, 12)
        Me.Label_Background.TabIndex = 6
        Me.Label_Background.Text = "Background"
        '
        'Label_1st
        '
        Me.Label_1st.AutoSize = True
        Me.Label_1st.Location = New System.Drawing.Point(68, 54)
        Me.Label_1st.Name = "Label_1st"
        Me.Label_1st.Size = New System.Drawing.Size(18, 12)
        Me.Label_1st.TabIndex = 7
        Me.Label_1st.Text = "1st"
        '
        'Label_2nd
        '
        Me.Label_2nd.AutoSize = True
        Me.Label_2nd.Location = New System.Drawing.Point(68, 90)
        Me.Label_2nd.Name = "Label_2nd"
        Me.Label_2nd.Size = New System.Drawing.Size(23, 12)
        Me.Label_2nd.TabIndex = 8
        Me.Label_2nd.Text = "2nd"
        '
        'Label_3rd
        '
        Me.Label_3rd.AutoSize = True
        Me.Label_3rd.Location = New System.Drawing.Point(68, 123)
        Me.Label_3rd.Name = "Label_3rd"
        Me.Label_3rd.Size = New System.Drawing.Size(21, 12)
        Me.Label_3rd.TabIndex = 9
        Me.Label_3rd.Text = "3rd"
        '
        'Label_Additional
        '
        Me.Label_Additional.AutoSize = True
        Me.Label_Additional.Location = New System.Drawing.Point(68, 156)
        Me.Label_Additional.Name = "Label_Additional"
        Me.Label_Additional.Size = New System.Drawing.Size(54, 12)
        Me.Label_Additional.TabIndex = 10
        Me.Label_Additional.Text = "Additional"
        '
        'Label_RSS
        '
        Me.Label_RSS.AutoSize = True
        Me.Label_RSS.Location = New System.Drawing.Point(68, 189)
        Me.Label_RSS.Name = "Label_RSS"
        Me.Label_RSS.Size = New System.Drawing.Size(25, 12)
        Me.Label_RSS.TabIndex = 11
        Me.Label_RSS.Text = "RSS"
        '
        'Button_BGcheck
        '
        Me.Button_BGcheck.Location = New System.Drawing.Point(137, 16)
        Me.Button_BGcheck.Name = "Button_BGcheck"
        Me.Button_BGcheck.Size = New System.Drawing.Size(75, 23)
        Me.Button_BGcheck.TabIndex = 12
        Me.Button_BGcheck.Text = "test"
        Me.Button_BGcheck.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(33, 425)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(75, 23)
        Me.startButton.TabIndex = 13
        Me.startButton.Text = "Start"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'timeLabel
        '
        Me.timeLabel.BackColor = System.Drawing.SystemColors.Info
        Me.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.timeLabel.Font = New System.Drawing.Font("微軟正黑體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.timeLabel.Location = New System.Drawing.Point(33, 451)
        Me.timeLabel.Name = "timeLabel"
        Me.timeLabel.Size = New System.Drawing.Size(156, 78)
        Me.timeLabel.TabIndex = 15
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.light_1st, Me.light_2nd, Me.light_3rd, Me.light_Additional, Me.light_RSS, Me.light_BG})
        Me.ShapeContainer1.Size = New System.Drawing.Size(811, 602)
        Me.ShapeContainer1.TabIndex = 16
        Me.ShapeContainer1.TabStop = False
        '
        'light_1st
        '
        Me.light_1st.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.light_1st.Location = New System.Drawing.Point(33, 49)
        Me.light_1st.Name = "light_1st"
        Me.light_1st.Size = New System.Drawing.Size(25, 22)
        '
        'light_2nd
        '
        Me.light_2nd.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.light_2nd.Location = New System.Drawing.Point(33, 82)
        Me.light_2nd.Name = "light_2nd"
        Me.light_2nd.Size = New System.Drawing.Size(25, 22)
        '
        'light_3rd
        '
        Me.light_3rd.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.light_3rd.Location = New System.Drawing.Point(33, 117)
        Me.light_3rd.Name = "light_3rd"
        Me.light_3rd.Size = New System.Drawing.Size(25, 22)
        '
        'light_Additional
        '
        Me.light_Additional.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.light_Additional.Location = New System.Drawing.Point(33, 151)
        Me.light_Additional.Name = "light_Additional"
        Me.light_Additional.Size = New System.Drawing.Size(25, 22)
        '
        'light_RSS
        '
        Me.light_RSS.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.light_RSS.Location = New System.Drawing.Point(33, 182)
        Me.light_RSS.Name = "light_RSS"
        Me.light_RSS.Size = New System.Drawing.Size(25, 22)
        '
        'light_BG
        '
        Me.light_BG.BackColor = System.Drawing.SystemColors.Window
        Me.light_BG.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.light_BG.Location = New System.Drawing.Point(33, 16)
        Me.light_BG.Name = "light_BG"
        Me.light_BG.Size = New System.Drawing.Size(25, 22)
        '
        'stopButton
        '
        Me.stopButton.Location = New System.Drawing.Point(33, 532)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(75, 23)
        Me.stopButton.TabIndex = 17
        Me.stopButton.Text = "Stop"
        Me.stopButton.UseVisualStyleBackColor = True
        '
        'continueButton
        '
        Me.continueButton.Location = New System.Drawing.Point(114, 532)
        Me.continueButton.Name = "continueButton"
        Me.continueButton.Size = New System.Drawing.Size(75, 23)
        Me.continueButton.TabIndex = 18
        Me.continueButton.Text = "Continue"
        Me.continueButton.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(811, 602)
        Me.Controls.Add(Me.continueButton)
        Me.Controls.Add(Me.stopButton)
        Me.Controls.Add(Me.timeLabel)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.Button_BGcheck)
        Me.Controls.Add(Me.Label_RSS)
        Me.Controls.Add(Me.Label_Additional)
        Me.Controls.Add(Me.Label_3rd)
        Me.Controls.Add(Me.Label_2nd)
        Me.Controls.Add(Me.Label_1st)
        Me.Controls.Add(Me.Label_Background)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "Main"
        Me.Text = "主測畫面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_Background As System.Windows.Forms.Label
    Friend WithEvents Label_1st As System.Windows.Forms.Label
    Friend WithEvents Label_2nd As System.Windows.Forms.Label
    Friend WithEvents Label_3rd As System.Windows.Forms.Label
    Friend WithEvents Label_Additional As System.Windows.Forms.Label
    Friend WithEvents Label_RSS As System.Windows.Forms.Label
    Friend WithEvents Button_BGcheck As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents startButton As System.Windows.Forms.Button
    Friend WithEvents timeLabel As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents light_1st As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents light_2nd As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents light_3rd As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents light_Additional As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents light_RSS As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents light_BG As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents stopButton As System.Windows.Forms.Button
    Friend WithEvents continueButton As System.Windows.Forms.Button
End Class
