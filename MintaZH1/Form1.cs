using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;   //??
using System.Reflection;

using MintaZH1.Entities;

namespace ZH1_gyak
{
    public partial class Form1 : Form
    {
        List<OlympicResults> results = new List<OlympicResults>();
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;

        public Form1()
        {
            InitializeComponent();
            LoadData("Summer_olympic_Medals.csv");
            CreateYearFilter();
            CalculateOrder();

        }

        private void CalculateOrder()
        {
            foreach (var r in results)
            {
                r.Position = CalculatePosition(r);
            }
        }

        private void CreateYearFilter()
        {
            var years = (from r in results
                         orderby r.Year
                         select r.Year).Distinct();
            comboBoxYears.DataSource = years.ToList();
        }

        private void LoadData(string fileName)
        {
            using (var sr = new StreamReader(fileName, Encoding.Default))
            {
                sr.ReadLine(); // Az első sort eldobjuk
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(',');
                    var or = new OlympicResults()
                    {
                        Year = int.Parse(line[0]),
                        Country = line[3],
                        Medals = new int[]
                        {
                            int.Parse(line[5]),
                            int.Parse(line[6]),
                            int.Parse(line[7])
                        }
                    };


                    results.Add(or);
                }
            }
        }


        private int CalculatePosition(OlympicResults or)
        {
            var betterCountryCount = 0;
            var filteredResults = from r in results
                                  where r.Year == or.Year && r.Country != or.Country
                                  select r;
            foreach (var r in filteredResults)
            {
                if ((r.Medals[0] > or.Medals[0])
                    || (r.Medals[0] == or.Medals[0] && r.Medals[1] > or.Medals[1])
                    || (r.Medals[0] == or.Medals[0] && r.Medals[1] == or.Medals[1] && r.Medals[2] > or.Medals[2]))
                    betterCountryCount++;
            }
            return betterCountryCount; //+ 1;  //miért kell a '+1'?
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;

                CreateExcel();

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        private void CreateExcel()
        {
            var headers = new string[]
            {
                "Helyezés",
                "Ország",
                "Arany",
                "Ezüst",
                "Bronz"
            };
            for (int i = 0; i < headers.Length; i++)
                xlSheet.Cells[1, i + 1] = headers[i];

            var filteredResults = from r in results
                                  where r.Year == (int)comboBoxYears.SelectedItem
                                  orderby r.Position
                                  select r;

            var counter = 2;
            foreach (var r in filteredResults)
            {
                xlSheet.Cells[counter, 1] = r.Position;
                xlSheet.Cells[counter, 2] = r.Country;
                for (int i = 0; i <= 2; i++)
                    xlSheet.Cells[counter, i + 3] = r.Medals[i];
                counter++;
            }
        }
    }
}
