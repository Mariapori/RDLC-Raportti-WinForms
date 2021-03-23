using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting;
using Microsoft.Reporting.WinForms;

namespace Rakettiraportti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Tuote> tuotteet = new List<Tuote>();

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = "Testiraportti.rdlc";

            string reportype = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;
            string devinfo = "<DeviceInfo><OutputFormat>PDF</OutputFormat>" +
            "  <PageWidth>210mm</PageWidth>" +
             "  <PageHeight>297mm</PageHeight>" +
             "  <MarginTop>0in</MarginTop>" +
             "  <MarginLeft>0in</MarginLeft>" +
              "  <MarginRight>0in</MarginRight>" +
              "  <MarginBottom>0in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            report.DataSources.Add(new ReportDataSource("DataSet1", tuotteet));

            renderedBytes = report.Render(reportype,devinfo,out mimeType,out encoding, out fileNameExtension,out streams, out warnings);

            System.IO.File.WriteAllBytes("document.pdf", renderedBytes);
            System.Diagnostics.Process.Start("document.pdf");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tuotteet.Add(new Tuote { Nimi = textBox1.Text, Hinta = Convert.ToDecimal(textBox2.Text) });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                Random random = new Random();
                tuotteet.Add(new Tuote { Nimi = "Tuote " + i, Hinta = random.Next(1, 100) });
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
