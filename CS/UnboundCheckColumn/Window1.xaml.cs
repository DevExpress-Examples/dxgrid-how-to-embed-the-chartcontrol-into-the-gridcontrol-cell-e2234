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

namespace UnboundCheckColumn {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        List<TestData> list;

        public Window1() {
            InitializeComponent();
            list = new List<TestData>();
            for(int i = 0; i < 3; i++) {
                list.Add(new TestData() { Id = Guid.NewGuid(), Number = i });
            }
            grid.DataSource = list;
        }

        private void grid_CustomUnboundColumnData(object sender, GridColumnDataEventArgs e) {
            if(e.Column.FieldName == "Chart") {
                double key = (int)e.GetListSourceFieldValue("Number");
                if(e.IsGetData) {
                    e.Value = (double) key;
                }
            }
        }
    }
    public class TestData {
        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}
