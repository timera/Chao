Imports Microsoft.VisualBasic.PowerPacks

Public Class Machine_choose
    'coordinates for 6 points
    Dim pos(5, 2) As Double
    'coordinates for 4 points
    Dim pos2(3, 2) As Double
    'Origin for the coordinates system
    Dim origin(0, 1) As Double
    Dim length As Double
    ' Set plotting vars
    Dim canvas As New ShapeContainer
    Dim xAxis As New LineShape
    ' xCor(0) is the start point, xCor(1) is the end point
    Dim yAxis As New LineShape
    ' x y axis coordinates
    Dim xCor(1, 1) As Double
    Dim yCor(1, 1) As Double

    Dim pointLabels As ArrayList

    
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
        xLabel.Parent = GroupBox_Plot
        yLabel.Parent = GroupBox_Plot

        pointLabels = New ArrayList(6)
        pointLabels.Add(p1Label)
        pointLabels.Add(p2Label)
        pointLabels.Add(p3Label)
        pointLabels.Add(p4Label)
        pointLabels.Add(p5Label)
        pointLabels.Add(p6Label)
        For index = 0 To pointLabels.Count - 1
            Dim label = pointLabels.Item(index)
            label.Parent = GroupBox_Plot
        Next

        GroupBox_Plot.Visible = True

        'x
        origin(0, 0) = 200
        'y
        origin(0, 1) = 150:
        length = 150
        'xStart
        xCor(0, 0) = origin(0, 0) - length 'x
        xCor(0, 1) = origin(0, 1) 'y
        'xEnd
        xCor(1, 0) = origin(0, 0) + length 'x
        xCor(1, 1) = origin(0, 1) 'y

        'yStart
        yCor(0, 0) = origin(0, 0) 'x
        yCor(0, 1) = origin(0, 1) - length 'y
        'yEnd
        yCor(1, 0) = origin(0, 0) 'x
        yCor(1, 1) = origin(0, 1) + length 'y
        'draw coordinates
        canvas.Parent = GroupBox_Plot
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
    Private Sub plot(ByVal xCor, ByVal yCor, ByVal parent, ByVal r, ByVal coors)
        'clear canvas first
        If Not IsNothing(canvas) Then
            canvas.Dispose()
        End If
        canvas = New ShapeContainer()
        canvas.Parent = parent

        'plot the coordinates
        plotCor(xCor, yCor)

        'plot the circle with r
        Dim temp As Double = length / r
        Dim ratio As Double = CInt(temp)

        If ratio > temp Then
            ratio = ratio - 1
        End If
        r = r * ratio
        Dim rCircle = New OvalShape((origin(0, 0) - r), (origin(0, 1) - r), 2 * r, 2 * r)
        rCircle.Parent = canvas
        'plot normalized points

        For index = 0 To coors.getLength(0) - 1
            Dim x = coors(index, 0) * ratio
            Dim y = coors(index, 1) * ratio
            Dim rPoint = New OvalShape((origin(0, 0) + x - 2), (origin(0, 1) - y - 2), 2, 2)
            rPoint.Parent = canvas
            pointLabels.Item(index).Text = "(" + coors(index, 0).ToString() + "," + coors(index, 1).ToString() + ")"
            pointLabels.Item(index).Location = New System.Drawing.Point(origin(0, 0) + x, origin(0, 1) - y)
        Next


    End Sub

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
        pos(0, 0) = r1 * 0.7
        pos(0, 1) = r1 * 0.7
        pos(0, 2) = 1.5
        pos(1, 2) = 1.5
        pos(2, 2) = 1.5
        pos(3, 2) = 1.5
        pos(1, 0) = -1 * pos(0, 0)
        pos(1, 1) = pos(0, 1)
        pos(2, 0) = pos(1, 0)
        pos(2, 1) = -1 * pos(1, 2)
        pos(3, 0) = pos(0, 0)
        pos(3, 1) = pos(2, 1)
        pos(4, 0) = r1 * -0.27
        pos(4, 1) = r1 * 0.65
        pos(5, 0) = -1 * pos(4, 0)
        pos(5, 1) = -1 * pos(4, 1)
        pos(4, 2) = pos(5, 2) = r1 * 0.71
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
        pos2(0, 0) = D0_2 * -0.45
        pos2(0, 1) = D0_2 * 0.77
        pos2(0, 2) = D0_2 * 0.45
        pos2(1, 0) = D0_2 * -0.45
        pos2(1, 1) = D0_2 * -0.77
        pos2(1, 2) = D0_2 * 0.45
        pos2(2, 0) = D0_2 * 0.89
        pos2(2, 1) = 0
        pos2(2, 2) = D0_2 * 0.45
        pos2(3, 0) = 0
        pos2(3, 1) = 0
        pos2(3, 2) = D0_2

        plot(xCor, yCor, GroupBox_Plot, r, pos)

        setup_finish.Enabled = True
    End Sub

    Private Sub setup_finish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setup_finish.Click
        Main.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Program.Show()
    End Sub
End Class
