' Developer Express Code Central Example:
' DXGrid - How to embed the ChartControl into the GridControl cell
' 
' It's necessary to implement the CellTemplate with the ChartControl, and bind any
' ChartControl property to a cell value, for example. In the sample, the first
' SeriesPoint in the Points collection is bound to a value in the cell
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2234

' Developer Express Code Central Example:
' DXGrid - How to embed the ChartControl into the GridControl cell
' 
' It's necessary to implement the CellTemplate with the ChartControl, and bind any
' ChartControl property to a cell value, for example. In the sample, the first
' SeriesPoint in the Points collection is bound to a value in the cell
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2234

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports System.Windows.Markup
Imports DevExpress.Xpf.Charts

Namespace UnboundCheckColumn
    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>
    Partial Public Class Window1
        Inherits Window

        Private list As List(Of TestData)

        Public Sub New()
            InitializeComponent()
            list = New List(Of TestData)()
            For i As Integer = 0 To 2
                list.Add(New TestData() With {.Id = Guid.NewGuid(), .Number = i})
            Next i
            grid.ItemsSource = list
        End Sub

        Private Sub grid_CustomUnboundColumnData(ByVal sender As Object, ByVal e As GridColumnDataEventArgs)
            If e.Column.FieldName = "Chart" Then
                Dim key As Double = CInt((e.GetListSourceFieldValue("Number")))
                If e.IsGetData Then
                    e.Value = CDbl(key)
                End If
            End If
        End Sub
    End Class
    Public Class TestData
        Public Property Id() As Guid
        Public Property Number() As Integer
    End Class
    Public NotInheritable Class Helper

        Private Sub New()
        End Sub

        Public Shared ReadOnly ValueProperty As DependencyProperty = DependencyProperty.RegisterAttached("Value", GetType(Object), GetType(Helper), New PropertyMetadata(Nothing, AddressOf OnValuePropertyChanged))
        Public Shared Function GetValue(ByVal obj As DependencyObject) As Object
            Return DirectCast(obj.GetValue(ValueProperty), Object)
        End Function
        Public Shared Sub SetValue(ByVal obj As DependencyObject, ByVal value As Object)
            obj.SetValue(ValueProperty, value)
        End Sub
        Private Shared Sub OnValuePropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            If Not(TypeOf e.NewValue Is Double) Then
                Return
            End If
            Dim ps As PieSeries2D = TryCast(d, PieSeries2D)
            If ps Is Nothing Then
                Return
            End If
            ps.Points.Clear()
            ps.Points.Add(New SeriesPoint With {.Value = DirectCast(e.NewValue, Double), .Argument = "Missing"})
            ps.Points.Add(New SeriesPoint With {.Value = 1, .Argument = "EnteredAnotherStation"})
            ps.Points.Add(New SeriesPoint With {.Value = 1, .Argument = "Entered"})
        End Sub
    End Class
End Namespace