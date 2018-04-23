Imports Microsoft.VisualBasic
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
Imports DevExpress.Wpf.Grid

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
			grid.DataSource = list
		End Sub

		Private Sub grid_CustomUnboundColumnData(ByVal sender As Object, ByVal e As GridColumnDataEventArgs)
			If e.Column.FieldName = "Chart" Then
				Dim key As Double = CInt(Fix(e.GetListSourceFieldValue("Number")))
				If e.IsGetData Then
					e.Value = CDbl(key)
				End If
			End If
		End Sub
	End Class
	Public Class TestData
		Private privateId As Guid
		Public Property Id() As Guid
			Get
				Return privateId
			End Get
			Set(ByVal value As Guid)
				privateId = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
	End Class
End Namespace
