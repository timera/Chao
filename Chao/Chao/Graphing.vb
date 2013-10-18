Imports Microsoft.VisualBasic
Imports System.Windows.Forms.DataVisualization.Charting


Public Class CGraph
    'private global variables
    Protected chart As Chart
    Protected series As System.Collections.Generic.List(Of Series)
    Protected legend As Legend
    Protected TestMode As Modes
    Protected NumOfMics As Integer

    Enum Modes
        A1A2A3
        A4
    End Enum

    Public Sub New()
        chart = New Chart
        chart.Location = New Point(0, 0)
        chart.Size = New Size(100, 100)
        chart.ChartAreas.Add(New ChartArea("ChartArea1"))
        chart.Legends.Add(New Legend("Legend1"))
        series = New List(Of Series)
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
        chart.Location = loc
        chart.Size = size
        parent.Controls.Add(chart)
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

    'constructor
    Public Sub New(ByVal loc As Point,
                   ByVal size As Size,
                   ByVal parent As Control,
                   ByVal mode As Modes
                   )
        MyBase.New(loc, size, parent, SeriesChartType.Line, mode)
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

    'constructor
    Public Sub New(ByVal loc As Point,
                   ByVal size As Size,
                   ByVal parent As Control,
                   ByVal mode As Modes)

        MyBase.New(loc, size, parent, SeriesChartType.Column, mode)
        For i As Integer = 0 To NumOfMics - 1
            Dim tag As Integer = (i + 1) * 2
            series(i).Points.AddXY(tag, 0)
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