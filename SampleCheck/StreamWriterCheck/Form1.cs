using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamWriterCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine(DateTime.Now.ToString());
            obj = new Temporary() { D1 = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"), Name = "Lucid", Time = DateTime.Now.TimeOfDay };
            fileExists = File.Exists(@"C:\Users\Lucid\Desktop\CSV.csv");
        }

        StreamWriter writer;
        Temporary obj;
        bool fileExists;
        public class Temporary
        {
            public string D1 { get; set; }
            public String Name { get; set; }
            //public TimeSpan Time { get; set; }
            //public String Time { get; set; }

            //[CsvHelper.Configuration.Attributes.Format("c")]
            public TimeSpan Time { get; set; }

            public string FormattedTime => Time.ToString(@"hh\:mm\:ss");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (writer = new StreamWriter(@"C:\Users\Lucid\Desktop\CSV.csv" , append:true))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecord(obj);
                    //csv.WriteComment(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss"));
                    csv.NextRecord();
                }
            }
        }
    }
}
