using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Journal_IO_v2
{
    /// <summary>
    /// Interaction logic for EntryManager.xaml
    /// </summary>
    /// Todo:
    ///     *Deal with date change (from Main: NewEntry.Date = DateTime.Parse(NewEntry.UnformattedDate, ukCulture.DateTimeFormat);)
    public partial class EntryManager : Window
    {
        //public List<entry> entriesAsIn = new List<entry>();
        public List<entry> entries { get; set; }
        //public List<entry> lastCopyOfEntries { get; set; }
        public bool closedFromMain = false;
        System.Globalization.CultureInfo ukCulture = new System.Globalization.CultureInfo("en-GB");
        public EntryManager()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(closedFromMain))
            {
                e.Cancel = true;
                MessageBox.Show("Please close from Main Window");
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = entries;
            //lastCopyOfEntries = entries.ToList<entry>();
            DataGrid.Columns[0].Visibility = Visibility.Hidden;
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column == DataGrid.Columns[1])
            {
                foreach (entry ent in entries)
                {
                    if (ent.Date != DateTime.Parse(ent.UnformattedDate, ukCulture.DateTimeFormat)){
                        ent.Date = DateTime.Parse(ent.UnformattedDate, ukCulture.DateTimeFormat);
                    }
                }
            }
            DataGrid.ItemsSource = entries;

        }
    }

}
