// Developer Express Code Central Example:
// DXGrid - How to embed the ChartControl into the GridControl cell
// 
// It's necessary to implement the CellTemplate with the ChartControl, and bind any
// ChartControl property to a cell value, for example. In the sample, the first
// SeriesPoint in the Points collection is bound to a value in the cell
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2234

// Developer Express Code Central Example:
// DXGrid - How to embed the ChartControl into the GridControl cell
// 
// It's necessary to implement the CellTemplate with the ChartControl, and bind any
// ChartControl property to a cell value, for example. In the sample, the first
// SeriesPoint in the Points collection is bound to a value in the cell
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2234

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using System.Windows.Markup;
using DevExpress.Xpf.Charts;

namespace UnboundCheckColumn {
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1: Window {
		List<TestData> list;

		public Window1() {
			InitializeComponent();
			list = new List<TestData>();
			for (int i = 0; i < 3; i++) {
				list.Add(new TestData() { Id = Guid.NewGuid(), Number = i });
			}
			grid.ItemsSource = list;
		}

		private void grid_CustomUnboundColumnData(object sender, GridColumnDataEventArgs e) {
			if (e.Column.FieldName == "Chart") {
				double key = (int)e.GetListSourceFieldValue("Number");
				if (e.IsGetData) {
					e.Value = (double)key;
				}
			}
		}
	}
	public class TestData {
		public Guid Id { get; set; }
		public int Number { get; set; }
	}
	public static class Helper {
		public static readonly DependencyProperty ValueProperty =
			DependencyProperty.RegisterAttached("Value", typeof(object), typeof(Helper), new PropertyMetadata(null, OnValuePropertyChanged));
		public static object GetValue(DependencyObject obj) {
			return (object)obj.GetValue(ValueProperty);
		}
		public static void SetValue(DependencyObject obj, object value) {
			obj.SetValue(ValueProperty, value);
		}
		static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if (!(e.NewValue is double))
				return;
			PieSeries2D ps = d as PieSeries2D;
			if (ps == null)
				return;
			ps.Points.Clear();
			ps.Points.Add(new SeriesPoint { Value = (double)e.NewValue, Argument = "Missing" });
			ps.Points.Add(new SeriesPoint { Value = 1, Argument = "EnteredAnotherStation" });
			ps.Points.Add(new SeriesPoint { Value = 1, Argument = "Entered" });
		}
	}
}