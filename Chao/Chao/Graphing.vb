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
                   ByVal type As SeriesChartType,
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


        chart.Location = New Point(-20, -5) 'so it hugs the border
        chart.Size = size - New Size(0, SecTextBoxSize.Height)
        chart.ChartAreas.Add(New ChartArea("ChartArea1"))
        chart.Legends.Add(New Legend("Legend1"))

        series = New List(Of Series)



        TestMode = mode
        If mode = Modes.A1A2A3 Then
            NumOfMics = 6
        ElseIf mode = Modes.A4 Then
            NumOfMics = 4
        End If
        For i As Integer = 2 To NumOfMics * 2 Step 2
            Dim s As Series = New Series(i.ToString())
            series.Add(s)
            s.ChartType = type
            s.IsVisibleInLegend = False
            s.IsValueShownAsLabel = False
            chart.Series.Add(s)
        Next

    End Sub
    'Update function
    Public Overridable Sub Update(ByVal newVal() As Integer)
    End Sub

End Class

Public Class LineGraph
    Inherits CGraph
    'private global vars
    Dim SecTextBox As MaskedTextBox
    Dim TimeInSec As Integer

    'constructor
    Public Sub New(ByVal loc As Point,
                   ByVal size As Size,
                   ByVal parent As Control,
                   ByVal mode As Modes,
                   ByVal time As Integer
                   )
        MyBase.New(loc, size, parent, SeriesChartType.Line, mode)
        SecTextBox = New MaskedTextBox()
        Panel.Controls.Add(SecTextBox)
        SecTextBox.Font = New Font(SecTextBox.Font.FontFamily, SecTextFontSize)
        SecTextBox.Size = SecTextBoxSize
        SecTextBox.Location = New Point(size.Width / 2 - SecTextBox.Size.Width / 2, size.Height - SecTextBoxSize.Height)
        If time > 0 Then
            SecTextBox.Text = time.ToString()
            SecTextBox.Enabled = False
            SetTime(time)
        End If
        SecTextBox.Mask = "999" 'digits including empty spaces
    End Sub

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
    Public Overrides Sub Update(ByVal newVal() As Integer)
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

    'constructor
    Public Sub New(ByVal loc As Point,
                   ByVal size As Size,
                   ByVal parent As Control,
                   ByVal mode As Modes)

        MyBase.New(loc, size, parent, SeriesChartType.Column, mode)
        Labels = New List(Of Label)


        For i As Integer = 0 To NumOfMics - 1
            Dim tag As Integer = (i + 1) * 2
            series(i).Points.AddXY(tag, 0)
            Dim l As Label = New Label()
            Labels.Add(l)
            Panel.Controls.Add(l)
            l.Name = "P" + tag.ToString()
            l.AutoSize = True
            l.Font = New Font(l.Font.FontFamily, 20)
            l.ForeColor = System.Drawing.Color.Black
            l.BackColor = System.Drawing.Color.White
            l.Size = New Size(65, 20)
            l.Location = New Point(50 * tag, 200)
            l.Text = "P" + tag.ToString()
            l.BringToFront()

        Next

    End Sub

    'Update function
    Public Overrides Sub Update(ByVal newVal() As Integer)
        If Not newVal.Length = NumOfMics Then
            Return
        End If
        For i As Integer = 0 To NumOfMics - 1
            series(i).Points.Clear()
            Dim tag As Integer = (i + 1) * 2
            series(i).Points.AddXY(tag, newVal(i))
        Next
    End Sub
End Class