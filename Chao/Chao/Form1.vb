Imports Microsoft.VisualBasic.PowerPacks



Public Class Machine_choose
    'coordinates for 6 points
    Dim pos(5) As CoorPoint
    'Dim pos(5, 2) As Double
    'lines coresponding to the points

    'coordinates for 4 points
    Dim pos2(3) As CoorPoint
    'Dim pos2(3, 2) As Double
    'lines coresponding to the points
    
    'Origin for the coordinates system
    Dim origin(1) As Double
    Dim length As Double
    ' Set plotting vars
    Dim canvas As New ShapeContainer
    Dim xAxis As New LineShape
    ' xCor(0) is the start point, xCor(1) is the end point
    Dim yAxis As New LineShape
    ' x y axis coordinates
    Dim xCor(1, 1) As Double
    Dim yCor(1, 1) As Double

    Dim ratio As Double

    Dim Points As ArrayList

    Public Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Private Sub Machine_choose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setup_finish.Enabled = False

        TextBox_L.Parent = GroupBox_A1_A2_A3
        TextBox_r1.Parent = GroupBox_A1_A2_A3
        Button_L_check.Parent = GroupBox_A1_A2_A3
        GroupBox_A1_A2_A3.Enabled = False

        TextBox_L1.Parent = GroupBox_A4
        TextBox_L2.Parent = GroupBox_A4
        TextBox_L3.Parent = GroupBox_A4
        TextBox_r2.Parent = GroupBox_A4
        GroupBox_A4.Enabled = False

        GroupBox_Plot.Parent = Me
        GroupBox_Plot.AllowDrop = True
        xLabel.Parent = GroupBox_Plot
        yLabel.Parent = GroupBox_Plot
        GroupBox_Plot.BackColor = Color.Transparent

        Points = New ArrayList
        pos(0) = New CoorPoint(p1Label)
        pos(1) = New CoorPoint(p2Label)
        pos(2) = New CoorPoint(p3Label)
        pos(3) = New CoorPoint(p4Label)
        pos(4) = New CoorPoint(p5Label)
        pos(5) = New CoorPoint(p6Label)
        pos2(0) = New CoorPoint(p7Label)
        pos2(1) = New CoorPoint(p8Label)
        pos2(2) = New CoorPoint(p9Label)
        pos2(3) = New CoorPoint(p10Label)
        For i = 0 To 5
            pos(i).Label.Parent = Me
            Points.Add(pos(i))
        Next
        For i = 0 To 3
            pos2(i).Label.Parent = Me
            Points.Add(pos2(i))
        Next

        GroupBox_Plot.Visible = True

        'x
        origin(0) = 200
        'y
        origin(1) = 150
        length = 150
        'xStart
        xCor(0, 0) = origin(0) - length 'x
        xCor(0, 1) = origin(1) 'y
        'xEnd
        xCor(1, 0) = origin(0) + length 'x
        xCor(1, 1) = origin(1) 'y

        'yStart
        yCor(0, 0) = origin(0) 'x
        yCor(0, 1) = origin(1) - length 'y
        'yEnd
        yCor(1, 0) = origin(0) 'x
        yCor(1, 1) = origin(1) + length 'y
        'draw coordinates
        canvas.Parent = GroupBox_Plot
        canvas.Location = New System.Drawing.Point(0, 0)
        plotCor(xCor, yCor)
    End Sub

    '

    'plot the coordinate system on startup
    Private Sub plotCor(ByVal xCor, ByVal yCor)

        'x axis
        xAxis = New LineShape(xCor(0, 0), xCor(0, 1), xCor(1, 0), xCor(1, 1))
        xAxis.Parent = canvas
        xLabel.Text = "x"
        xLabel.Size = New System.Drawing.Size(10, 10)
        xLabel.Location = New System.Drawing.Point(xCor(1, 0), xCor(1, 1))

        'y axis
        yAxis = New LineShape(yCor(0, 0), yCor(0, 1), yCor(1, 0), yCor(1, 1))
        yAxis.Parent = canvas
        yLabel.Text = "y"
        yLabel.Location = New System.Drawing.Point(yCor(0, 0), yCor(0, 1))
    End Sub

    'given an array of coordinates, plot them out using the given coordinate system
    'xCor is x axis coordinates
    'yCor is y axis coordinates
    'parent is the parent control to canvas
    'r is the radius for the circle
    'coors is the coordinates for the points to be plotted
    Private Sub plot(ByVal xCor As Double(,), ByVal yCor As Double(,), ByVal parent As Control, ByVal r As Double, ByVal coors As CoorPoint())
        'clear canvas first
        If Not IsNothing(canvas) Then
            canvas.Dispose()
        End If
        'clear labels
        For Each cp As CoorPoint In pos
            cp.Label.Text = ""
        Next
        For Each cp As CoorPoint In pos2
            cp.Label.Text = ""
        Next

        canvas = New ShapeContainer()
        canvas.Parent = parent
        canvas.BackColor = Color.Transparent
        'plot the coordinates
        plotCor(xCor, yCor)

        'plot the circle with r
        Dim temp As Double = length / r
        ratio = CInt(temp)

        If ratio > temp Then
            ratio = ratio - 1
        else if ratio = 0
            ratio = temp
        End if
        r = r * ratio
        Dim rCircle = New OvalShape((origin(0) - r), (origin(1) - r), 2 * r, 2 * r)
        rCircle.Parent = canvas
        'plot normalized points

        For index = 0 To coors.GetLength(0) - 1
            Dim x = coors(index).Coors.Xc * ratio
            Dim y = coors(index).Coors.Yc * ratio
            Dim rPoint = New OvalShape((origin(0) + x - 2), (origin(1) - y - 2), 2, 2)

            rPoint.Parent = canvas
            Dim xText = Format(coors(index).Coors.Xc, "#.##")
            Dim yText = Format(coors(index).Coors.Yc, "#.##")
            Dim zText = Format(coors(index).Coors.Zc, "#.##")
            If xText = "" Then
                xText = "0"
            End If
            If yText = "" Then
                yText = "0"
            End If
            If zText = "" Then
                zText = "0"
            End If
            coors(index).Label.Text = "(" + xText + " , " + yText + " , " + zText + ")"
            coors(index).Label.Location = translate(New System.Drawing.Point(origin(0) + x, origin(1) - y), GroupBox_Plot.Location, Me.Location)
            coors(index).Label.BringToFront()
        Next
    End Sub

    'translate the location of point 1 from control 2's coordinates to control 3's coordinates
    'point 1 is given in var 2 coordinates
    'controls 2 and 3 are given in global terms)
    Private Function translate(ByVal p1, ByVal con2, ByVal con3)
        Dim x = p1.X + con2.X - con3.X
        Dim y = p1.Y + con2.Y - con3.Y
        Return New System.Drawing.Point(x, y)
    End Function

    Private Sub DomainUpDown1_SelectedItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox_machine_list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_machine_list.SelectedIndexChanged
        Dim mach As Integer
        If ComboBox_machine_list.Text = "開挖機" Then
            Picture_machine.Image = My.Resources.Resource1.小型開挖機_compact_excavator_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "拖索開挖機" Then
            Picture_machine.Image = My.Resources.Resource1.小型膠輪式裝料機_compact_loader__wheeled_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "抓斗開挖機" Then
            Picture_machine.Image = My.Resources.Resource1.滑移裝料機_skid_steer_loader_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "履帶起重機" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式開挖裝料機_crawler_backhoe_loader_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "推土機" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式推土機_crawler_dozer_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "牽引裝料機" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式裝料機_crawler_loader_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "振動式打樁機" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式開挖機_crawler_excavator_
            mach = 2
        End If
        If ComboBox_machine_list.Text = "鑽岩機" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式推土機_wheeled_dozer_
            mach = 2
        End If
        If ComboBox_machine_list.Text = "壓路機" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式開挖裝料機_wheeled_backhoe_loader_
            mach = 2
        End If
        If ComboBox_machine_list.Text = "輪胎式壓路機" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式開挖機_wheeled_excavator_
            mach = 2
        End If
        If ComboBox_machine_list.Text = "振動式壓路機" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式裝料機_wheeled_loader_
            mach = 2
        End If
        If ComboBox_machine_list.Text = "混凝土割切機" Then
            Picture_machine.Image = My.Resources.Resource1.壓路機_rollers_
            mach = 2
        End If
        If mach = 1 Then
            GroupBox_A1_A2_A3.Enabled = True
            GroupBox_A4.Enabled = False
        End If
        If mach = 2 Then
            GroupBox_A1_A2_A3.Enabled = False
            GroupBox_A4.Enabled = True
        End If
    End Sub


    Private Sub Button_L_check_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_L_check.Click
        Dim r1 As Integer
        If String.IsNullOrWhiteSpace(TextBox_L.Text) Then
            Return
        End If

        If TextBox_L.Text < 1.5 Then
            TextBox_r1.Text = "4"
            r1 = 4
        End If
        If TextBox_L.Text >= 1.5 And TextBox_L.Text < 4 Then
            TextBox_r1.Text = "10"
            r1 = 10
        End If
        If TextBox_L.Text >= 4 Then
            TextBox_r1.Text = "16"
            r1 = 16
        End If
        pos(0).Coors = New ThreeDPoint(r1 * 0.7, r1 * 0.7, 1.5)
        pos(1).Coors = New ThreeDPoint(-1 * r1 * 0.7, r1 * 0.7, 1.5)
        pos(2).Coors = New ThreeDPoint(-1 * r1 * 0.7, -1 * r1 * 0.7, 1.5)
        pos(3).Coors = New ThreeDPoint(r1 * 0.7, -1 * r1 * 0.7, 1.5)
        pos(4).Coors = New ThreeDPoint(r1 * -0.27, r1 * 0.65, r1 * 0.71)
        pos(5).Coors = New ThreeDPoint(r1 * 0.27, r1 * -0.65, r1 * 0.71)

        plot(xCor, yCor, GroupBox_Plot, r1, pos)

        setup_finish.Enabled = True


    End Sub

    Private Sub Button_L1_L2_L3_check_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_L1_L2_L3_check.Click
        If String.IsNullOrWhiteSpace(TextBox_L1.Text) Or String.IsNullOrWhiteSpace(TextBox_L2.Text) Or String.IsNullOrWhiteSpace(TextBox_L3.Text) Then
            Return
        End If
        Dim L1 As Double
        Dim L2 As Double
        Dim L3 As Double
        Dim D0_2 As Double
        L1 = TextBox_L1.Text
        L2 = TextBox_L2.Text
        L3 = TextBox_L3.Text
        D0_2 = 2 * Math.Sqrt(((L1 / 2) ^ 2) + ((L2 / 2) ^ 2) + (L3 ^ 2))
        TextBox_r2.Text = D0_2
        Dim r = D0_2
        pos2(0).Coors = New ThreeDPoint(D0_2 * -0.45, D0_2 * 0.77, D0_2 * 0.45)
        pos2(1).Coors = New ThreeDPoint(D0_2 * -0.45, D0_2 * -0.77, D0_2 * 0.45)
        pos2(2).Coors = New ThreeDPoint(D0_2 * 0.89, 0, D0_2 * 0.45)
        pos2(3).Coors = New ThreeDPoint(0, 0, D0_2)

        plot(xCor, yCor, GroupBox_Plot, r, pos2)

        setup_finish.Enabled = True
    End Sub

    Private Sub setup_finish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setup_finish.Click
        Main.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Program.Show()
    End Sub

    Private MouseIsDown As Boolean = False

    Private Sub pLabel_MouseDown(ByVal sender As Object, ByVal e As  _
    System.Windows.Forms.MouseEventArgs) Handles p1Label.MouseDown, p2Label.MouseDown, p3Label.MouseDown, p4Label.MouseDown, p5Label.MouseDown, p6Label.MouseDown, p7Label.MouseDown, p8Label.MouseDown, p9Label.MouseDown, p10Label.MouseDown
        ' Set a flag to show that the mouse is down.
        MouseIsDown = True
        For Each l As CoorPoint In Points
            If l.Label.Name = sender.Name Then
                If Not IsNothing(l.Line) Then
                    l.Line.Dispose()
                End If
            End If
        Next
    End Sub

    Private Sub pLabel_MouseMove(ByVal sender As Label, ByVal e As  _
    System.Windows.Forms.MouseEventArgs) Handles p1Label.MouseMove, p2Label.MouseMove, p3Label.MouseMove, p4Label.MouseMove, p5Label.MouseMove, p6Label.MouseMove, p7Label.MouseMove, p8Label.MouseMove, p9Label.MouseMove, p10Label.MouseMove
        If MouseIsDown Then
            ' Initiate dragging.
            sender.Location = Control.MousePosition
        End If
    End Sub

    Private Sub pLabel_MouseUp(ByVal sender As Label, ByVal e As  _
System.Windows.Forms.MouseEventArgs) Handles p1Label.MouseUp, p2Label.MouseUp, p3Label.MouseUp, p4Label.MouseUp, p5Label.MouseUp, p6Label.MouseUp, p7Label.MouseUp, p8Label.MouseUp, p9Label.MouseUp, p10Label.MouseUp
        MouseIsDown = False
        For Each l As CoorPoint In Points
            If l.Label.Name = sender.Name Then
                l.Line = New LineShape(canvas)
                l.Line.StartPoint = New System.Drawing.Point((origin(0) + ratio * l.Coors.Xc), (origin(1) - ratio * l.Coors.Yc))
                l.Line.EndPoint = translate(New Point(sender.Location.X + sender.Size.Width / 2, sender.Location.Y), Me.Location, GroupBox_Plot.Location)
            End If
        Next
    End Sub
End Class

'helper classes for keeping track of labels and points
Public Class CoorPoint
    Public Label As Label
    Public Coors As ThreeDPoint
    Public Line As LineShape

    Public Sub New(ByVal lab As Label)
        Label = lab
        Coors = New ThreeDPoint
    End Sub

    Public Sub New(ByVal lab As Label, ByVal p As ThreeDPoint, ByVal l As LineShape)
        Label = lab
        Coors = p
        Line = l
    End Sub

End Class

Public Class ThreeDPoint
    Public Xc As Double
    Public Yc As Double
    Public Zc As Double
    Public Sub New()
    End Sub

    Public Sub New(ByVal x As Double, ByVal y As Double, ByVal z As Double)
        Xc = x
        Yc = y
        Zc = z
    End Sub

End Class
