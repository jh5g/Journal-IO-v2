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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace Journal_IO_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class entry
    {
        public DateTime Date { get; set; }
        public string UnformattedDate { get; set; }
        public string Entry { get; set; }
        public entry()
        {

        }
        public string OutputAsString()
        {
            this.UnformattedDate = this.Date.ToString("dd/MM/yyyy");
            string output = this.UnformattedDate;
            output += ":";
            output += this.Entry;
            return output;
        }
    }

    public partial class MainWindow : Window
    {
        static string filename = "Untitled";
        public List<entry> entries = new List<entry>();

        public MainWindow() //Prepares for initial use
        {
            InitializeComponent();
            this.Title = "Journal I/O - " + filename;
            this.entries = new List<entry>();
        }

        System.Globalization.CultureInfo ukCulture = new System.Globalization.CultureInfo("en-GB");

        private void Window_1_Loaded(object sender, RoutedEventArgs e) //Sets date in date entry box to be the current date when loaded
        {
            this.dateEntry.Text = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
            Open();
        }

        private void AddNewEntry() //formats info and turns it into entry object, then adds to list ??Does this add a reference to the object will this work
        {
            entry NewEntry = new entry();
            NewEntry.Entry = NewEntryBox.Text;
            NewEntry.UnformattedDate = dateEntry.Text;
            NewEntry.Date = DateTime.Parse(NewEntry.UnformattedDate, ukCulture.DateTimeFormat);
            bool contained = false;
            string entryContainedDate = "";
            foreach (entry entry in entries)
            {
                if (entry.Date == NewEntry.Date)
                {
                    contained = true;
                    entryContainedDate = entry.UnformattedDate;
                }
            }
            if (contained)
            {
                Window1 window1 = new Window1("Do you want to overwrite this entry");
                if (window1.ShowDialog() == true)
                {
                    if (window1.DialogResult == true)
                    {
                        foreach (entry entry in entries.ToList<entry>())
                        {
                            if (entry.Date == NewEntry.Date)
                            {
                                entries.Remove(entry);
                            }
                        }
                        entries.Add(NewEntry);
                    }
                }
            }
            else
            {
                entries.Add(NewEntry);
            }
            
        }

        public string FormatForOutput() //Turns list into string for output
        {
            //todo sort list
            entries = entries.OrderBy(d => d.Date).ToList();
            string output = "";
            foreach (entry entry in entries)
            {
                output += entry.UnformattedDate;
                output += " : ";
                output += entry.Entry;
                output += "\n";
            }
            return output;
        }

        private void AddEntry_Click(object sender, RoutedEventArgs e) //processes a click on Add button
        {
            AddNewEntry();
            Output.Text = FormatForOutput();
        }

        public List<entry> FormatFromInput(string input)// takes string (from a file) and turns it into a List
        {
            List<entry> EntriesOutput = new List<entry>();
            string pat = "(.*?) : (.*)";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(input);
            while (m.Success)
            {
                string Date = "";
                string entrystring = "";
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    if (i == 1)
                    {
                        Date = g.Value;
                    }
                    else if (i == 2)
                    {
                        entrystring = g.Value;
                    }
                }
                entry NewEntry = new entry();
                NewEntry.Entry = entrystring;
                NewEntry.UnformattedDate = Date;
                NewEntry.Date = DateTime.Parse(NewEntry.UnformattedDate, ukCulture.DateTimeFormat);
                EntriesOutput.Add(NewEntry);

                m = m.NextMatch();
            }
            return EntriesOutput;
            
        }

        public void SaveAs()//Saves file As
        {
            string fileText = FormatForOutput();

            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Journal I/O File (*.jour)|*.jour"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, fileText);
                filename = dialog.FileName;
            }
            this.Title = "Journal I/O - " + filename;
        }

        public void SaveOver()//Saves over existing file based on file name
        {
            if (filename != "Untitled")
            {
                File.WriteAllText(filename, FormatForOutput());
            }
            else
            {
                SaveAs();
            }
            this.Title = "Journal I/O - " + filename;
        }

        public void Open()//Opens file as does necessary related actions
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Journal I/O File (*.jour)|*.jour";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                string Text = File.ReadAllText(openFileDialog.FileName);
                filename = openFileDialog.FileName.ToString();
                entries = FormatFromInput(Text);
                Output.Text = FormatForOutput();
                this.Title = "Journal I/O " + filename;
            }
        }

        public void New()//Creates procedure for new file
        {
            NewEntryBox.Text = "";
            Output.Text = "";
        }

        private void Window_1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Title.Substring(this.Title.Length - 1) == "*")
            {
                Window1 window1 = new Window1("Do you want to save before closing?");
                if (window1.ShowDialog() == true)
                {
                    if (window1.DialogResult == true)
                    {
                        SaveOver();
                    }
                }
            }
        } //confirms save before closing

        private void NewEntryBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Title = "Journal I/O - " + filename + "*";
        } //ensures knowledge of change to test for requirement to save before closing

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveOver();
        }

        private void SaveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Open();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            New();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchWIndow searchWIndow = new SearchWIndow();
            searchWIndow.Show();
            searchWIndow.entries = entries;
        }

        //TODO: Search
    }
}
