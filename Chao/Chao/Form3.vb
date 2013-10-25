Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.PowerPacks

Public Class Program
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure MARGINS
        Public cxLeftWidth As Integer
        Public cxRightWidth As Integer
        Public cyTopHeight As Integer
        Public cyButtomHeight As Integer
    End Structure

    <DllImport("dwmapi.dll")> Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarinset As MARGINS) As Integer
    End Function

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

    'determine whether we can go to the main tab
    Dim MachChosen As Boolean
    Enum Machines
        Excavator
        Loader
        Loader_Excavator
        Tractor
        Others
    End Enum
    Dim Machine As Machines

    'Graphs for the main screen
    Dim MainLineGraphs As LineGraphPanel
    Dim MainBarGraph As BarGraph

    Dim timeLeft As Integer
    Dim status As Integer  'status=1==>A1+A2  ,status=2==>A1+A3  ,status=3==>A1+A2+A3  ,status=4==>A4

    'state表示現在正在測的main_process為何
    'state :1 = A1 ,2 = A2 ,3 = A3 ,4 = A4 , 5 = pre cal, 6 = background
    'state :7 = Additional ,8 = RSS ,9 = post cal
    Dim state As Integer

    '手動設秒數 = false  ,  自動設30s = true
    Dim auto As Boolean

    'sStep==>循環開始(start)的步驟 ,eStep==>循環的最後一個(end)步驟, cStep==>current step
    Dim sStep As Integer
    Dim eStep As Integer
    Dim cStep As Integer
    Dim labelRepeat As Label

    'trial represents 1st or 2nd or 3rd
    Dim trial As Integer

    'lights arrays
    Dim MainLightArray As List(Of OvalShape)
    Dim A1234LightArray As List(Of OvalShape)
    Dim A1234LinkArray As List(Of LinkLabel)

    'current main light
    Dim CurMainLight As Integer
    'current A1234 light
    Dim CurALight As Integer

    'pass 為是否接受數據還是要加測
    Dim pass As Integer

    Dim TimeofStep(1, 8) As Double
    Dim array_step(8) As Label

    '紀錄a2 a3跑到哪個步驟
    Dim A2_step As Integer
    Dim A3_step As Integer

    Dim NoisesArray(5) As Label

    'temporary constant
    Const seconds As Integer = 3
    Const graphW As Integer = 700
    Const graphH As Integer = 200

    'used for first time clicking start button
    Dim Virgin As Boolean

    Public Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    ' things that need to be instantiated at startup
    Private Sub Program_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Virgin = True
        Dim margins As MARGINS = New MARGINS
        margins.cxLeftWidth = 2
        margins.cxRightWidth = 2
        margins.cyTopHeight = 23
        margins.cyButtomHeight = 2
        Dim hwnd As IntPtr = Handle
        Dim result As Integer = DwmExtendFrameIntoClientArea(hwnd, margins)

        TextBox_L.Parent = GroupBox_A1_A2_A3
        TextBox_r1.Parent = GroupBox_A1_A2_A3
        Button_L_check.Parent = GroupBox_A1_A2_A3
        GroupBox_A1_A2_A3.Enabled = False



        TextBox_L1.Parent = GroupBox_A4
        TextBox_L2.Parent = GroupBox_A4
        TextBox_L3.Parent = GroupBox_A4
        TextBox_r2.Parent = GroupBox_A4
        Button_L1_L2_L3_check.Parent = GroupBox_A4
        GroupBox_A4.Enabled = False

        GroupBox_Plot.Parent = TabPage1
        GroupBox_Plot.AllowDrop = True
        xLabel.Parent = GroupBox_Plot
        yLabel.Parent = GroupBox_Plot
        GroupBox_Plot.BackColor = Color.Transparent

        light_preCal.BackColor = Color.Red
        light_BG.BackColor = Color.Red
        light_1st.BackColor = Color.Red
        light_2nd.BackColor = Color.Red
        light_3rd.BackColor = Color.Red
        light_Additional.BackColor = Color.Red
        light_RSS.BackColor = Color.Red
        light_postCal.BackColor = Color.Red



        startButton.Enabled = True
        stopButton.Enabled = False

        array_step(0) = Step1
        array_step(1) = Step2
        array_step(2) = Step3
        array_step(3) = Step4
        array_step(4) = Step5
        array_step(5) = Step6
        array_step(6) = Step7
        array_step(7) = Step8
        array_step(8) = Step9

        A2_step = 0
        A3_step = 0

        Noise1.Text = 100
        Noise2.Text = 105
        Noise3.Text = 103.8


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
            pos(i).Label.Parent = TabPage1
            Points.Add(pos(i))
        Next
        For i = 0 To 3
            pos2(i).Label.Parent = TabPage1
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



        'location of all objects
        light_preCal.Location = New Point(19, 17)
        light_BG.Location = New Point(19, 57)
        light_1st.Location = New Point(19, 97)
        light_2nd.Location = New Point(19, 137)
        light_3rd.Location = New Point(19, 177)
        light_Additional.Location = New Point(19, 217)
        light_RSS.Location = New Point(19, 257)
        light_postCal.Location = New Point(19, 297)

        light_A1.Location = New Point(19, 508)
        light_A1.Enabled = False
        light_A1.BackColor = Color.DarkGray
        light_A2.Location = New Point(19, 548)
        light_A2.Enabled = False
        light_A2.BackColor = Color.DarkGray
        light_A3.Location = New Point(19, 588)
        light_A3.Enabled = False
        light_A3.BackColor = Color.DarkGray
        light_A4.Location = New Point(19, 628)
        light_A4.Enabled = False
        light_A4.BackColor = Color.DarkGray

        LinkLabel_preCal.Location = New Point(50, 22)
        LinkLabel_BG.Location = New Point(50, 62)
        LinkLabel_1st.Location = New Point(50, 102)
        LinkLabel_2nd.Location = New Point(50, 142)
        LinkLabel_3rd.Location = New Point(50, 182)
        LinkLabel_Additional.Location = New Point(50, 222)
        LinkLabel_RSS.Location = New Point(50, 262)
        LinkLabel_postCal.Location = New Point(50, 302)

        LinkLabel_A1.Location = New Point(50, 513)
        LinkLabel_A2.Location = New Point(50, 553)
        LinkLabel_A3.Location = New Point(50, 593)
        LinkLabel_A4.Location = New Point(50, 633)
        LinkLabel_A1.Enabled = False
        LinkLabel_A2.Enabled = False
        LinkLabel_A3.Enabled = False
        LinkLabel_A4.Enabled = False

        startButton.Location = New Point(9, 354)
        timeLabel.Location = New Point(9, 380)
        stopButton.Location = New Point(9, 461)

        NoisesArray = {Noise1, Noise2, Noise3, Noise4, Noise5, Noise6}
        Dim noiseX = 90
        Dim noiseY = 580
        Noise1.Location = New Point(250, 580)
        Noise2.Location = New Point(250 + noiseX, 580)
        Noise3.Location = New Point(250 + noiseX * 2, 580)
        Noise4.Location = New Point(250 + noiseX * 3, 580)
        Noise5.Location = New Point(250 + noiseX * 4, 580)
        Noise6.Location = New Point(250 + noiseX * 5, 580)

        Dim stepX As Integer = 960
        Step1.Location = New Point(stepX, 22)
        Step2.Location = New Point(stepX, 84)
        Step3.Location = New Point(stepX, 146)
        Step4.Location = New Point(stepX, 208)
        Step5.Location = New Point(stepX, 270)
        Step6.Location = New Point(stepX, 332)
        Step7.Location = New Point(stepX, 394)
        Step8.Location = New Point(stepX, 456)
        Step9.Location = New Point(stepX, 518)
        Step10.Location = New Point(stepX, 580)

        MachChosen = False
        status = 0
        state = 0
        trial = 0
        MainLightArray = New List(Of OvalShape)
        A1234LightArray = New List(Of OvalShape)
        A1234LinkArray = New List(Of LinkLabel)
    End Sub


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
        ElseIf ratio = 0 Then
            ratio = temp
        End If
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
            coors(index).Label.Location = translate(New System.Drawing.Point(origin(0) + x, origin(1) - y), GroupBox_Plot.Location, TabPage1.Location)
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

    'prevents user from clicking on tab b4 choosing machinery
    Private Sub TabControl1_IndexChanged(ByVal sender As TabControl, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Not MachChosen Then
            If sender.SelectedIndex = 1 Then
                MessageBox.Show("還未選機具!", "My application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedIndex = 0 ' go back to the machinery choose stage
            End If
        End If
    End Sub

    Private Sub ComboBox_machine_list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_machine_list.SelectedIndexChanged

        'step1~9清空
        For index = 0 To 8
            array_step(index).Text = ""
            array_step(index).BackColor = Color.DarkGray
        Next
        Dim choice As String = ComboBox_machine_list.Text

        'xxx I have changed all these into else's
        'A1+A2
        If choice = "開挖機(Excavator)" Then
            Picture_machine.Image = My.Resources.Resource1.小型開挖機_compact_excavator_
            status = 1
            Machine = Machines.Excavator

        ElseIf choice = "推土機(Crawler and wheel tractor)" Then  'A1+A3
            Picture_machine.Image = My.Resources.Resource1.履帶式推土機_crawler_dozer_
            status = 2
            Machine = Machines.Tractor

        ElseIf choice = "鐵輪壓路機(Road roller)" Then
            Picture_machine.Image = My.Resources.Resource1.壓路機_rollers_
            status = 2
            Machine = Machines.Others
        ElseIf choice = "膠輪壓路機(Wheel roller)" Then
            Picture_machine.Image = My.Resources.Resource1.壓路機_rollers_
            status = 2
            Machine = Machines.Others
        ElseIf choice = "振動式壓路機(Vibrating roller)" Then
            Picture_machine.Image = My.Resources.Resource1.壓路機_rollers_
            status = 2
            Machine = Machines.Others


        ElseIf choice = "裝料機(Crawler and wheel loader)" Then 'A1+A2+A3
            Picture_machine.Image = My.Resources.Resource1.履帶式裝料機_crawler_loader_
            status = 3
            Machine = Machines.Loader
        ElseIf choice = "裝料開挖機" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式開挖裝料機_crawler_backhoe_loader_
            status = 3
            Machine = Machines.Loader_Excavator

        ElseIf choice = "履帶起重機(Crawler crane)" Then 'A4
            Picture_machine.Image = My.Resources.Resource1.膠輪式推土機_wheeled_dozer_
            status = 4
            Machine = Machines.Others
            Step1.Text = My.Resources.A4_Crane
            Step1.BackColor = Color.MistyRose
        ElseIf choice = "卡車起重機(Truck crane)" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式開挖裝料機_wheeled_backhoe_loader_
            status = 4
            Step1.Text = My.Resources.A4_Crane
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "輪形起重機(Wheel crane)" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式開挖機_wheeled_excavator_
            status = 4
            Step1.Text = My.Resources.A4_Crane
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "振動式樁錘(Vibrating hammer)" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式裝料機_wheeled_loader_
            status = 4
            Step1.Text = My.Resources.A4_Vibrating_Hammer
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "油壓式打樁機(Hydraulic pile driver)" Then
            Picture_machine.Image = My.Resources.Resource1.壓路機_rollers_
            status = 4
            Step1.Text = My.Resources.A4_Auger_Drill_Driver
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "拔樁機" Then
            Picture_machine.Image = My.Resources.Resource1.小型開挖機_compact_excavator_
            status = 4
            Step1.Text = My.Resources.A4_Auger_Drill_Driver
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "油壓式拔樁機" Then
            Picture_machine.Image = My.Resources.Resource1.小型膠輪式裝料機_compact_loader__wheeled_
            status = 4
            Step1.Text = My.Resources.A4_Auger_Drill_Driver
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "土壤取樣器(地鑽) (Earth auger)" Then
            Picture_machine.Image = My.Resources.Resource1.滑移裝料機_skid_steer_loader_
            status = 4
            Step1.Text = My.Resources.A4_Auger_Drill_Driver
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "全套管鑽掘機" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式開挖裝料機_crawler_backhoe_loader_
            status = 4
            Step1.Text = My.Resources.A4_Auger_Drill_Driver
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "鑽土機(Earth drill)" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式推土機_crawler_dozer_
            status = 4
            Step1.Text = My.Resources.A4_Auger_Drill_Driver
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "鑽岩機(Rock breaker)" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式裝料機_crawler_loader_
            status = 4
            Step1.Text = My.Resources.A4_Auger_Drill_Driver
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "混凝土泵車(Concrete pump)" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式開挖機_crawler_excavator_
            status = 4
            Step1.Text = My.Resources.A4_Concrete_Pump
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "混凝土破碎機(Concrete breaker)" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式推土機_wheeled_dozer_
            status = 4
            Step1.Text = My.Resources.A4_Concrete_Breaker
            Step1.BackColor = Color.MistyRose

            Machine = Machines.Others
        ElseIf choice = "瀝青混凝土舖築機(Asphalt finisher)" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式開挖裝料機_wheeled_backhoe_loader_
            status = 4
            Step1.Text = My.Resources.A4_Asphalt_Finisher
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "混凝土割切機(Concrete cutter)" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式開挖機_wheeled_excavator_
            status = 4
            Step1.Text = My.Resources.A4_Concrete_Cutter
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "發電機(Generator)" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式裝料機_wheeled_loader_
            status = 4
            Step1.Text = My.Resources.A4_Generator
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        ElseIf choice = "空氣壓縮機(Compressor)" Then
            Picture_machine.Image = My.Resources.Resource1.壓路機_rollers_
            status = 4
            Step1.Text = My.Resources.A4_Compressor
            Step1.BackColor = Color.MistyRose
            Machine = Machines.Others
        End If

        'mach區分要輸入至哪個 groupbox for plotting the coordinates
        If Not status = 0 Then
            If Not status = 4 Then
                GroupBox_A1_A2_A3.Enabled = True
                GroupBox_A4.Enabled = False
            Else
                GroupBox_A1_A2_A3.Enabled = False
                GroupBox_A4.Enabled = True
            End If

            'if machine chose, then allow to go to the 2nd tab
            MachChosen = True
        End If


        If choice = "A1+A2" Or choice = "A1+A3" Or choice = "A1+A2+A3" Or choice = "A4" Then
            For index = 0 To 8
                array_step(index).Text = ""
                array_step(index).BackColor = Color.DarkGray
            Next

            light_A1.BackColor = Color.DarkGray
            light_A2.BackColor = Color.DarkGray
            light_A3.BackColor = Color.DarkGray
            light_A4.BackColor = Color.DarkGray

            LinkLabel_A1.Enabled = False
            LinkLabel_A2.Enabled = False
            LinkLabel_A3.Enabled = False
            LinkLabel_A4.Enabled = False
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

        'load light arrays
        If Not status = 0 Then
            load_light_arrays()
            determine_next()
        End If

    End Sub

    Private Sub Button_L1_L2_L3_check_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_L1_L2_L3_check.Click
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

        'load light arrays
        If Not status = 0 Then
            load_light_arrays()
            determine_next()
        End If

    End Sub

    Private MouseIsDown As Boolean = False
    Private lastPos As Point

    Private Sub pLabel_MouseDown(ByVal sender As Object, ByVal e As  _
    System.Windows.Forms.MouseEventArgs) Handles p1Label.MouseDown, p2Label.MouseDown, p3Label.MouseDown, p4Label.MouseDown, p5Label.MouseDown, p6Label.MouseDown, p7Label.MouseDown, p8Label.MouseDown, p9Label.MouseDown, p10Label.MouseDown
        ' Set a flag to show that the mouse is down.
        MouseIsDown = True
        lastPos = Cursor.Position
        For Each l As CoorPoint In Points
            If l.Label.Name = sender.Name Then
                If Not IsNothing(l.Line) Then
                    l.Line.Dispose()
                End If
            End If
        Next
    End Sub

    Private Sub pLabel_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p9Label.MouseUp, p8Label.MouseUp, p7Label.MouseUp, p10Label.MouseUp, p6Label.MouseUp, p5Label.MouseUp, p4Label.MouseUp, p3Label.MouseUp, p2Label.MouseUp, p1Label.MouseUp
        MouseIsDown = False
        For Each l As CoorPoint In Points
            If l.Label.Name = sender.Name Then
                l.Line = New LineShape(canvas)
                l.Line.StartPoint = New System.Drawing.Point((origin(0) + ratio * l.Coors.Xc), (origin(1) - ratio * l.Coors.Yc))
                l.Line.EndPoint = translate(New Point(l.Label.Location.X + l.Label.Size.Width / 2, l.Label.Location.Y - l.Label.Size.Height), TabPage1.Location, GroupBox_Plot.Location + canvas.Location)
            End If
        Next
    End Sub
    Private Sub pLabel_MouseMove(ByVal sender As Label, ByVal e As System.Windows.Forms.MouseEventArgs) Handles p9Label.MouseMove, p8Label.MouseMove, p7Label.MouseMove, p10Label.MouseMove, p6Label.MouseMove, p5Label.MouseMove, p4Label.MouseMove, p3Label.MouseMove, p2Label.MouseMove, p1Label.MouseMove
        If MouseIsDown Then
            ' Initiate dragging.
            Dim temp As Point = Cursor.Position
            sender.Location = temp - lastPos + sender.Location
            lastPos = temp
        End If
    End Sub
    ' for now produce fake data
    Private Function GetInstantData()
        Dim num As Integer
        If Not status = 4 Then
            num = 6
        Else
            num = 4
        End If
        Dim r = New Random()
        Dim result(num - 1) As Double
        For i = 0 To num - 1
            result(i) = r.Next(90, 120)
        Next
        Return result
    End Function

    Private Sub SetScreenValuesAndGraphs(ByVal vals() As Double)
        Dim num As Integer
        If Not status = 4 Then
            num = 6
        Else
            num = 4
        End If
        'Set Texts
        For i = 0 To num - 1
            NoisesArray(i).Text = vals(i)
        Next
        'Set graphs
        MainBarGraph.Update(vals)
        MainLineGraphs.Update(vals)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If timeLeft > 0 Then 'counting
            timeLeft = timeLeft - 1
            timeLabel.Text = timeLeft & " s"

            'send values to display as text and graphs
            SetScreenValuesAndGraphs(GetInstantData())

        ElseIf timeLeft = 0 Then 'time's up
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            'System.Threading.Thread.Sleep(1000)
            startButton.Enabled = True
            stopButton.Enabled = False
            'determine what the next step is
            determine_next()
            timeLeft = TimeofStep(0, cStep - 1)
            timeLabel.Text = timeLeft & " s"
        End If

    End Sub

    ' click event on Start Button
    Private Sub startButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startButton.Click
        startButton.Enabled = False
        stopButton.Enabled = True

        timeLeft = TimeofStep(0, 0)
        TimeofStep(1, cStep - 1) -= 1
        Timer1.Start()
        If Not Virgin Then
            MainLineGraphs.MoveToNextGraph()
        End If
        Virgin = False
    End Sub

    Private Sub stopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stopButton.Click
        startButton.Enabled = True
        stopButton.Enabled = False
        Timer1.Stop()
    End Sub

    Private Sub load_light_arrays()
        MainLightArray.Add(light_preCal)
        MainLightArray.Add(light_BG)
        MainLightArray.Add(light_1st)
        MainLightArray.Add(light_2nd)
        MainLightArray.Add(light_3rd)
        MainLightArray.Add(light_Additional)
        MainLightArray.Add(light_RSS)
        MainLightArray.Add(light_postCal)
        CurMainLight = -1

        If status = 1 Or status = 2 Or status = 3 Then
            A1234LightArray.Add(light_A1)
            A1234LinkArray.Add(LinkLabel_A1)
            If status = 1 Or status = 3 Then
                A1234LightArray.Add(light_A2)
                A1234LinkArray.Add(LinkLabel_A2)
            End If
            If status = 2 Or status = 3 Then
                A1234LightArray.Add(light_A3)
                A1234LinkArray.Add(LinkLabel_A3)
            End If
        Else
            A1234LightArray.Add(light_A4)
            A1234LinkArray.Add(LinkLabel_A4)
        End If
        CurALight = -1
    End Sub


    '  If MessageBox.Show("A4所有數據已測量完畢且接受此數據?", "My application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    'light_A4.BackColor = Color.DarkGreen
    ' MessageBox.Show("此機具所有測量步驟已結束")
    ' End If

    Private Sub SetupNextLights()
        'if set up lights for the first time
        If CurMainLight < 0 Then
            CurMainLight = 1
            MainLightArray(0).BackColor = Color.LightGreen
            For i = 1 To MainLightArray.Count - 1
                MainLightArray(i).BackColor = Color.Red
            Next
            CurALight = 1
            For i = 0 To A1234LightArray.Count - 1
                A1234LightArray(i).Enabled = True
                A1234LightArray(i).BackColor = Color.Red
                A1234LinkArray(i).Enabled = True
            Next

            'if next time is first of A's
        ElseIf state = 6 Then
            'change light to A1 or A4
            CurALight = 1
            A1234LightArray(CurALight - 1).BackColor = Color.LightGreen

            'change light to 1st
            MainLightArray(CurMainLight - 1).BackColor = Color.DarkGreen
            MainLightArray(CurMainLight).BackColor = Color.LightGreen
            CurMainLight += 1

            'if previous was already A
        ElseIf state <= 4 Then
            If trial = 3 Then
                A1234LightArray(CurALight - 1).BackColor = Color.DarkGreen
            End If
            MainLightArray(CurMainLight - 1).BackColor = Color.DarkGreen

            'if there's next A
            If CurALight < A1234LightArray.Count Then
                If trial = 3 Then
                    A1234LightArray(CurALight).BackColor = Color.LightGreen
                    CurALight += 1
                End If
                'if next step is not third
                If trial < 3 Then
                    CurMainLight += 1
                Else 'if next step is third
                    CurMainLight -= 2 ' move back to 1st
                End If
                MainLightArray(CurMainLight - 1).BackColor = Color.LightGreen
            Else 'A finishes here, move on to RSS and so on
                MainLightArray(CurMainLight).BackColor = Color.LightGreen
                CurMainLight += 1
            End If

        ElseIf state = 7 Then
            'need_additional
        Else
            MainLightArray(CurMainLight - 1).BackColor = Color.DarkGreen
            'if there's next step
            If Not CurMainLight = MainLightArray.Count Then
                MainLightArray(CurMainLight).BackColor = Color.LightGreen
                CurMainLight += 1
            End If
        End If
    End Sub

    Private Sub clearSteps()
        For index = 0 To 8
            array_step(index).Text = ""
            array_step(index).BackColor = Color.DarkGray
        Next
    End Sub

    'step10 is label for occurances when there are too many steps
    Private Function determine_next()
        Dim mode As CGraph.Modes = CGraph.Modes.A1A2A3
        If status = 4 Then
            mode = CGraph.Modes.A4
        End If

        'set up lights for the first time
        If state = 0 Then
            cStep = 1
            sStep = 1
            eStep = 1

            'initialize timeofstep
            TimeofStep(0, cStep - 1) = seconds
            TimeofStep(1, cStep - 1) = 1
            'start from pre cal
            state = 5
            SetupNextLights()

            'Graphing for the main screen
            MainLineGraphs = New LineGraphPanel(New Point(300, 100), New Size(graphW, graphH), TabPage2, mode, TimeofStep(1, cStep - 1), {TimeofStep(0, cStep - 1)})
            MainBarGraph = New BarGraph(New Point(300, 300), New Size(graphW, graphH), TabPage2, mode)
        ElseIf state = 7 Then 'If additional, need special treatment because we don't know if we need to change lights or not

            'If left step change (including repetitions)
        ElseIf state > 4 Or (cStep = eStep And TimeofStep(1, eStep - 1) = 0) Then ' if running precal,bg,RSS,or post cal, or right hand side runs out 3 times
            ''set up the lights
            SetupNextLights()
            ''if previous is additional determine if we need another additional
            If state > 7 Or state = 5 Then 'if previous is RSS or postcal or precal 
                state += 1
            ElseIf (state = 6 And Not status = 4) Or (state = 1 And Not trial = 3) Then  '' A1 is next -background or A1 is the previous, meaning current is A1
                auto = True
                'if previous is background
                If state = 6 Then
                    state = 1
                    trial = 1
                Else 'if previous is A1
                    trial += 1
                    array_step(eStep - 1).ForeColor = Color.Black 'make last step black
                End If


                ''set up sStep and eStep and cStep
                sStep = 1
                eStep = 1
                cStep = 1
                labelRepeat = Step2
                TimeofStep(1, 0) = 3
                TimeofStep(0, 0) = seconds
                Step1.Text = My.Resources.A1_step1
                Step1.BackColor = Color.Orange
                ' times-1
                labelRepeat.Text = "第幾次循環 : 第 " & 4 - TimeofStep(1, sStep - 1) & " 次 / 共 3 次"
                ' set the next step red
                array_step(sStep - 1).ForeColor = Color.Red
            ElseIf (state = 1 And status = 1 And trial = 3) Or (state = 2 And Not trial = 3) Then ''' if next is A2 (A1->A2, or A2 repeat)
                auto = False
                'if previous is A1
                If state = 1 Then
                    state = 2
                    trial = 1
                    clearSteps()
                Else 'if previous is A2
                    trial += 1
                    array_step(eStep - 1).ForeColor = Color.Black 'make last step black
                End If

                If Machine = Machines.Excavator Then
                    sStep = 2
                    eStep = 9
                    cStep = 1
                    For i = sStep - 1 To eStep - 1
                        TimeofStep(0, i) = seconds 'defaulted to global var first
                        TimeofStep(1, i) = 3
                    Next
                    labelRepeat = Step10
                    '載入步驟
                    For i = 0 To eStep - 1
                        array_step(i).Visible = True
                    Next
                    Step1.Text = My.Resources.A2_Excavator_step1
                    Step1.BackColor = Color.MistyRose
                    Step2.Text = My.Resources.A2_Excavator_step2
                    Step2.BackColor = Color.Orange
                    Step3.Text = My.Resources.A2_Excavator_step3
                    Step3.BackColor = Color.Orange
                    Step4.Text = My.Resources.A2_Excavator_step4
                    Step4.BackColor = Color.Orange
                    Step5.Text = My.Resources.A2_Excavator_step5
                    Step5.BackColor = Color.Orange
                    Step6.Text = My.Resources.A2_Excavator_step6
                    Step6.BackColor = Color.Orange
                    Step7.Text = My.Resources.A2_Excavator_step7
                    Step7.BackColor = Color.Orange
                    Step8.Text = My.Resources.A2_Excavator_step8
                    Step8.BackColor = Color.Orange
                    Step9.Text = My.Resources.A2_Excavator_step9
                    Step9.BackColor = Color.Orange
                    labelRepeat.Text = "第幾次循環 : 第 " & 4 - TimeofStep(1, sStep - 1) & " 次 / 共 3 次"
                    ' set the next step red
                    array_step(sStep - 1).ForeColor = Color.Red
                ElseIf Machine = Machines.Loader_Excavator Then
                    '''''''''''''''FILL IN
                End If
            ElseIf (state = 1 And trial = 3) Or (state = 2 And status = 3 And trial = 3) Or (state = 3 And Not trial = 3) Then ''' if next is A3 (A1->A3, A1->A2->A3, A3 repeat)
                auto = False
                'if previous is A3
                If state = 3 Then
                    trial += 1
                    array_step(eStep - 1).ForeColor = Color.Black 'make last step black
                Else 'if previous is A1,A2
                    state = 3
                    trial = 1
                    clearSteps()
                End If

                If Machine = Machines.Loader_Excavator Then
                    '''''''''''''''FILL IN
                    For i = 0 To eStep
                        array_step(i).Visible = True
                    Next
                    labelRepeat.Text = "第幾次循環 : 第 " & 4 - TimeofStep(1, sStep - 1) & " 次 / 共 3 次"
                    ' set the next step red
                    array_step(sStep - 1).ForeColor = Color.Red
                ElseIf Machine = Machines.Loader Then
                    For i = sStep - 1 To eStep - 1
                        TimeofStep(0, i) = seconds 'defaulted to global var first
                        TimeofStep(1, i) = 3
                    Next
                    sStep = 2
                    eStep = 3
                    cStep = 1
                    For i = 0 To eStep
                        array_step(i).Visible = True
                    Next
                    Step1.Text = My.Resources.A2_Loader_step1
                    Step1.BackColor = Color.MistyRose
                    Step2.Text = My.Resources.A2_Loader_step2
                    Step2.BackColor = Color.Orange
                    Step3.Text = My.Resources.A2_Loader_step3
                    Step3.BackColor = Color.Orange
                    Step4.BackColor = Color.DarkGray
                    Step5.BackColor = Color.DarkGray
                    Step6.BackColor = Color.DarkGray
                    Step7.BackColor = Color.DarkGray
                    Step8.BackColor = Color.DarkGray
                    Step9.BackColor = Color.DarkGray
                    labelRepeat.Text = "第幾次循環 : 第 " & 4 - TimeofStep(1, sStep - 1) & " 次 / 共 3 次"
                    ' set the next step red
                    array_step(sStep - 1).ForeColor = Color.Red
                ElseIf Machine = Machines.Tractor Then
                    For i = sStep - 1 To eStep - 1
                        TimeofStep(0, i) = seconds 'defaulted to global var first
                        TimeofStep(1, i) = 3
                    Next
                    sStep = 3
                    eStep = 4
                    cStep = 1
                    For i = 0 To eStep
                        array_step(i).Visible = True
                    Next
                    Step1.Text = My.Resources.A3_Tractor_step1
                    Step1.BackColor = Color.MistyRose
                    Step2.Text = My.Resources.A3_Tractor_step2
                    Step2.BackColor = Color.MistyRose
                    Step3.Text = My.Resources.A3_Tractor_step3
                    Step3.BackColor = Color.Orange
                    Step4.Text = My.Resources.A3_Tractor_step4
                    Step4.BackColor = Color.Orange
                    Step5.BackColor = Color.DarkGray
                    Step6.BackColor = Color.DarkGray
                    Step7.BackColor = Color.DarkGray
                    Step8.BackColor = Color.DarkGray
                    Step9.BackColor = Color.DarkGray
                    labelRepeat.Text = "第幾次循環 : 第 " & 4 - TimeofStep(1, sStep - 1) & " 次 / 共 3 次"
                    ' set the next step red
                    array_step(sStep - 1).ForeColor = Color.Red
                End If
            ElseIf ((status = 1 And state = 2) Or (status = 2 And state = 3) Or (status = 3 And state = 3)) And trial = 3 Then ''' if next step is additional

                '''''''''''''''FILL IN

                If (cStep = sStep) Then 'if the first step is the repetitive step
                    labelRepeat.Text = "第幾次循環 : 第 " & 4 - TimeofStep(1, sStep - 1) & " 次 / 共 3 次"
                End If
            ElseIf (state = 6 And status = 4) Or (state = 4 And Not trial = 3) Then ' A4 from background or repeat
                auto = True
                state = 4
                trial += 1
                sStep = 1
                eStep = 1
                cStep = 1
                TimeofStep(0, 0) = seconds
                TimeofStep(1, 0) = 1
                For i = 0 To eStep
                    array_step(i).Visible = True
                Next
                Step1.BackColor = Color.MistyRose
                Dim choice As String = ComboBox_machine_list.Text

                If choice = "履帶起重機(Crawler crane)" Then
                    Step1.Text = My.Resources.A4_Crane
                ElseIf choice = "卡車起重機(Truck crane)" Then
                    Step1.Text = My.Resources.A4_Crane
                ElseIf choice = "輪形起重機(Wheel crane)" Then
                    Step1.Text = My.Resources.A4_Crane
                ElseIf choice = "振動式樁錘(Vibrating hammer)" Then
                    Step1.Text = My.Resources.A4_Vibrating_Hammer
                ElseIf choice = "油壓式打樁機(Hydraulic pile driver)" Then
                    Step1.Text = My.Resources.A4_Auger_Drill_Driver
                ElseIf choice = "拔樁機" Then
                    Step1.Text = My.Resources.A4_Auger_Drill_Driver
                ElseIf choice = "油壓式拔樁機" Then
                    Step1.Text = My.Resources.A4_Auger_Drill_Driver
                ElseIf choice = "土壤取樣器(地鑽) (Earth auger)" Then
                    Step1.Text = My.Resources.A4_Auger_Drill_Driver
                ElseIf choice = "全套管鑽掘機" Then
                    Step1.Text = My.Resources.A4_Auger_Drill_Driver
                ElseIf choice = "鑽土機(Earth drill)" Then
                    Step1.Text = My.Resources.A4_Auger_Drill_Driver
                ElseIf choice = "鑽岩機(Rock breaker)" Then
                    Step1.Text = My.Resources.A4_Auger_Drill_Driver
                ElseIf choice = "混凝土泵車(Concrete pump)" Then
                    Step1.Text = My.Resources.A4_Concrete_Pump
                ElseIf choice = "混凝土破碎機(Concrete breaker)" Then
                    Step1.Text = My.Resources.A4_Concrete_Breaker
                ElseIf choice = "瀝青混凝土舖築機(Asphalt finisher)" Then
                    Step1.Text = My.Resources.A4_Asphalt_Finisher
                ElseIf choice = "混凝土割切機(Concrete cutter)" Then
                    Step1.Text = My.Resources.A4_Concrete_Cutter
                ElseIf choice = "發電機(Generator)" Then
                    Step1.Text = My.Resources.A4_Generator
                ElseIf choice = "空氣壓縮機(Compressor)" Then
                    Step1.Text = My.Resources.A4_Compressor
                End If
            End If
            Dim numTimes(TimeofStep.GetLength(0)) As Integer
            For i = 0 To TimeofStep.GetLength(0) - 1
                numTimes(i) = TimeofStep(0, i)
            Next
            MainLineGraphs = New LineGraphPanel(New Point(300, 100), New Size(graphW, graphH), TabPage2, mode, eStep, numTimes)
        Else 'If right step change
            'if loop again
            If cStep = eStep Then
                ' times-1
                labelRepeat.Text = "第幾次循環 : 第 " & 4 - TimeofStep(1, sStep - 1) & " 次 / 共 3 次"
                ' set the next step red
                array_step(cStep - 1).ForeColor = Color.Black
                array_step(sStep - 1).ForeColor = Color.Red
                cStep = sStep

                'set graphs
                Dim numTimes(TimeofStep.GetLength(0)) As Integer
                For i = 0 To TimeofStep.GetLength(0) - 1
                    numTimes(i) = TimeofStep(0, i)
                Next
                MainLineGraphs = New LineGraphPanel(New Point(300, 100), New Size(graphW, graphH), TabPage2, mode, eStep, numTimes)
            Else
                'set the next step red
                array_step(cStep - 1).ForeColor = Color.Black
                cStep += 1
                array_step(cStep - 1).ForeColor = Color.Red

                'move to next step in graph
                MainLineGraphs.MoveToNextGraph()
            End If
        End If

        Return True
    End Function
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