Imports Microsoft.VisualBasic
Imports System.Windows.Forms.DataVisualization.Charting

Public Class CGraph
    'protected global variables
    Protected chart As Chart
    Protected series As System.Collections.Generic.List(Of Series)
    Protected legend As Legend
    Protected TestMode As Modes
    Protected NumOfMics As Integer
    Protected Panel As Panel
    Protected SecTextFontSize As Integer = 12
    Protected SecTextBoxSize As Size = New Size(50, 20)
    Protected SetTimeButtonFontSize As Integer = 12
    Protected SetTimeButtonSize As Size = New Size(50, 40)

    Enum Modes
        A1A2A3
        A4
    End Enum

    Public Sub New()
    End Sub
    'Constructor
    'loc = Location
    'siz = Size
    'parent = Parent control
    'sDimensions = series dimensions
    'type = chart type
    Public Sub New(ByVal loc As Point,
                   ByVal size As Size,
                   ByVal parent As Control,
                   ByVal mode As Modes
                   )
        'Plot controls
        chart = New Chart
        Panel = New Panel()
        parent.Controls.Add(Panel)
        Panel.Controls.Add(chart)
        'Panel.Name = "Panel"
        Panel.Size = size
        Panel.Location = loc

        series = New List(Of Series)

        chart.Location = New Point(0, 0) 'so it hugs the border
        chart.Size = size - New Size(0, SecTextBoxSize.Height)
        chart.ChartAreas.Add(New ChartArea("ChartArea1"))
        chart.Legends.Add(New Legend("Legend1"))




        TestMode = mode
        If mode = Modes.A1A2A3 Then
            NumOfMics = 6
        ElseIf mode = Modes.A4 Then
            NumOfMics = 4
        End If


    End Sub
    'Update function
    Public Overridable Sub Update(ByVal newVal() As Double)
    End Sub

End Class

Public Class LineGraph
    Inherits CGraph
    'private global vars
    Dim SecTextBox As MaskedTextBox
    Dim TimeInSec As Integer
    Dim SetTimeButton As Button

    'constructor
    Public Sub New(ByVal loc As Point,
                   ByVal size As Size,
                   ByVal parent As Control,
                   ByVal mode As Modes,
                   ByVal time As Integer
                   )
        MyBase.New(loc, size, parent, mode)
        'Offset the chart a bit to the right to allow room for the button and textbox
        chart.Location = chart.Location + New Point(SetTimeButtonSize.Width, 0)
        chart.Size = chart.Size - New Size(SecTextBoxSize.Width, 0)
        'Set Time TextBox
        SecTextBox = New MaskedTextBox()
        Panel.Controls.Add(SecTextBox)
        SecTextBox.Font = New Font(SecTextBox.Font.FontFamily, SecTextFontSize)
        SecTextBox.Size = SecTextBoxSize
        SecTextBox.Location = New Point(0, size.Height / 2)
        If time > 0 Then
            SecTextBox.Text = time.ToString()
            SecTextBox.Enabled = False
            SetTime(time)
        End If
        SecTextBox.Mask = "999" 'digits including empty spaces

        'Set Time button
        SetTimeButton = New Button()
        Panel.Controls.Add(SetTimeButton)
        SetTimeButton.Font = New Font(SetTimeButton.Font.FontFamily, SecTextFontSize)
        SetTimeButton.Size = SetTimeButtonSize
        SetTimeButton.Location = New Point(0, size.Height / 2 + SecTextBox.Size.Height)
        SetTimeButton.Text = "Set"

        'Set Chart zoomability
        chart.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
        chart.ChartAreas(0).AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount
        chart.ChartAreas(0).AxisY.IsLabelAutoFit = False

        'set up series
        For i As Integer = 2 To NumOfMics * 2 Step 2
            Dim s As Series = New Series(i.ToString())
            series.Add(s)
            s.ChartType = SeriesChartType.Line
            s.IsVisibleInLegend = False
            s.IsValueShownAsLabel = False
            chart.Series.Add(s)
        Next

    End Sub

    'get the time for chart
    Public Function GetTime()
        Return TimeInSec
    End Function
    'Show initial chart
    Public Sub ShowInitChart(ByVal width As Integer, ByVal height As Integer)
        chart.ChartAreas(0).AxisX.Maximum = width
        chart.ChartAreas(0).AxisY.Maximum = height
    End Sub

    'Set time from the textbox 
    Public Sub SetTimeFromBox()
        If Integer.TryParse(SecTextBox.Text, TimeInSec) Then
            chart.ChartAreas(0).AxisX.Maximum = TimeInSec
        End If
    End Sub
    'Set Time
    Public Sub SetTime(ByVal time As Integer)
        TimeInSec = time
        chart.ChartAreas(0).AxisX.Maximum = TimeInSec
    End Sub

    'Update function
    Public Overrides Sub Update(ByVal newVal() As Double)
        If Not newVal.Length = NumOfMics Then
            Return
        End If
        For i As Integer = 0 To newVal.Length - 1
            Dim tag = (i + 1) * 2
            If Not IsNothing(series(i)) Then
                series(i).Points.Add(newVal(i))
            End If
        Next
    End Sub
End Class



Public Class BarGraph
    Inherits CGraph
    'private global vars
    Dim Labels As List(Of Label)
    Dim listOfNames As List(Of String)

    'constructor
    Public Sub New(ByVal loc As Point,
                   ByVal size As Size,
                   ByVal parent As Control,
                   ByVal mode As Modes)

        MyBase.New(loc, size, parent, mode)
        Labels = New List(Of Label)

        'set up series
        Dim s As Series = New Series()
        series.Add(s)
        s.ChartType = SeriesChartType.Column
        s.IsVisibleInLegend = False
        s.IsValueShownAsLabel = False
        chart.Series.Add(s)
        listOfNames = New List(Of String)
        Dim listOfPoints = New List(Of Double)

        For i As Integer = 0 To NumOfMics - 1
            Dim tag As String = "P" + CStr((i + 1) * 2)
            listOfNames.Add(tag)
            listOfPoints.Add(0)
        Next
        listOfNames.Add("Average")
        listOfPoints.Add(0)
        series(0).Points.DataBindXY(listOfNames, listOfPoints)

    End Sub

    'Update function
    Public Overrides Sub Update(ByVal newVal() As Double)
        If Not newVal.Length = NumOfMics Then
            Return
        End If
        'adding average datapoint
        Dim temp(newVal.Length + 1) As Double
        Dim sum As Double = 0
        For i = 0 To newVal.Length - 1
            temp(i) = newVal(i)
            sum += newVal(i)
        Next
        temp(newVal.Length) = sum / newVal.Length
        series(0).Points.DataBindXY(listOfNames, temp)
    End Sub
End Class