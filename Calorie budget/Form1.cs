using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Xml;

namespace Calorie_budget
{
    public partial class Form1 : Form
    {
        int deficet= 0;
        DateTime now;
        string path;
        CalorieData data;

        public Form1()
        {
            InitializeComponent();
            __LoadFile__();
            __LoadData__();
            __initialize__();
        }

        private void __initialize__()
        {
            data  = new CalorieData(this.now, this.deficet);
            string path = $"C:\\Users\\Andre\\OneDrive\\Documents\\WeightCalculator\\Calorie-Count-{this.now.Month}-{this.now.Year}\\{this.now.Day}.json";

            //string json = JsonConvert.SerializeObject(data);
            string json = File.ReadAllText(path);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            var personlist = ser.Deserialize<List<CalorieData>>(json);

            Console.WriteLine(personlist);
        }

        private void __LoadFile__()
        {
            this.now = DateTime.Now;
            this.path = $"C:\\Users\\Andre\\OneDrive\\Documents\\WeightCalculator\\Calorie-Count-{this.now.Month}-{this.now.Year}\\{this.now.Day}.txt";
            lblNotification.Text = "";

            if(!Directory.Exists($"C:\\Users\\Andre\\OneDrive\\Documents\\WeightCalculator\\Calorie-Count-{this.now.Month}-{this.now.Year}"))
            {
                Directory.CreateDirectory($"C:\\Users\\Andre\\OneDrive\\Documents\\WeightCalculator\\Calorie-Count-{this.now.Month}-{this.now.Year}");
            }

            if (!File.Exists(this.path))
            {
                using (StreamWriter sw = File.CreateText(this.path))
                {
                    sw.WriteLine($"Calorie counter {this.now.Month}-{this.now.Year}");
                    sw.WriteLine(deficet.ToString());
                }
            }

            using (StreamReader sr = File.OpenText(this.path))
            {
                string s;
                //string text = "";
                for (int i = 0; (s = sr.ReadLine()) != null; i++)
                {
                    //text += s + "\n";
                    if(i == 0)
                    {
                        this.Text = s;
                    }
                    if(i == 1)
                    {
                        this.deficet = int.Parse(s);
                    };
                }
                //txtDisplay.Text = text;
            }
        }

        private void __LoadData__()
        {
            int calorieBalanece = 1961 - this.deficet;

            lblCalorieBalance.Text = $"Calorie Balance: {calorieBalanece}cal";
        }

        private void __WriteData__()
        {
            using (StreamWriter sw = File.CreateText(this.path))
            {
                sw.WriteLine($"Calorie counter {this.now.Month}-{this.now.Year}");
                sw.WriteLine(deficet.ToString());
            }
        }

        private void __ReadData__(string selectedPath)
        {
            string path = selectedPath;
            string item = "";
            int calorie = 0;

            string s;
            using(StreamReader sr = File.OpenText(path))
            {
                for (int i = 0; (s = sr.ReadLine()) != null; i++)
                {
                    if(i == 0)
                    {
                        item = s;
                    }
                    else if(i == 1)
                    {
                        calorie = int.Parse(s);
                    }
                }
            }

            lblNotification.Text = $"You have added {item}";

            this.deficet += calorie;
            __LoadData__();
            __WriteData__();


        }
        private void btnDebug_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCalories_Click(object sender, EventArgs e)
        {
            int deduct = 0;
            if(int.TryParse(txtAddDeficet.Text.Trim(), out deduct))
            {
                this.deficet += deduct;
                __LoadData__();
                __WriteData__();
            }
            else
            {
                MessageBox.Show("Data entered was not a number, please use a number");
            }
        }

        private void btnLibraryAdd_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Andre\OneDrive\Documents\WeightCalculator\Food-Library\";

            OpenFileDialog library = new OpenFileDialog();
            library.InitialDirectory = path;

            library.Filter = "txt files | *.txt";

            if(library.ShowDialog() == DialogResult.OK)
            {
                __ReadData__(library.FileName);
            }

        }
    }
}
