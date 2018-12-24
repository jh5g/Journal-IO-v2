using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for SearchWIndow.xaml
    /// </summary>
    public partial class SearchWIndow : Window
    {
        public List<entry> entries = new List<entry>();
        List<entry> filteredEntries { get; set; }
        System.Globalization.CultureInfo ukCulture = new System.Globalization.CultureInfo("en-GB");

        public SearchWIndow()
        {
            InitializeComponent();
        }

        public string FormatForOutput() //Turns list into string for output
        {
            filteredEntries = filteredEntries.OrderBy(d => d.Date).ToList();
            string output = "";
            foreach (entry entry in filteredEntries)
            {
                output += entry.UnformattedDate;
                output += " : ";
                output += entry.Entry;
                output += "\n";
            }
            return output;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            String date = DateEntry.Text;
            String Text = TextEntry.Text;
            filteredEntries = entries.ToList<entry>();
            if (date != "")
            {
                foreach (entry ent in entries)
                {
                    if (!( ent.UnformattedDate.Contains(date)))
                    {
                        filteredEntries.Remove(ent);
                    }
                }
            }
            if (Text != "")
            {
                foreach (entry ent in entries)
                {
                    if (!( ent.Entry.Contains(Text)))
                    {
                        filteredEntries.Remove(ent);
                    }
                }
            }
            if (date != "" || Text != "")
            {
                Output.Text = FormatForOutput();
            }
            else
            {
                Window1 window1 = new Window1("No Search method was found");
                window1.Title = "Warning";
                window1.Cancel.Content = "Ok";
                window1.Confirm.Visibility = Visibility.Hidden;
                window1.Show();
            }
        }
    }
}
