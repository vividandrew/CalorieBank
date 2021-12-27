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
using System.Xml;
using System.Xml.Linq;

namespace Calorie_budget
{
    public partial class Form1 : Form
    {
        int defaultCalories = 1961;
        DateTime now;
        CalorieData data;
        string[] months = {"", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public Form1()
        {
            InitializeComponent();
            __initialize__();
            __LoadData__();
            lblNotification.Text = "";
        }

        private void __initialize__()
        {
            this.now = DateTime.Now;

            this.data  = new CalorieData(this.now, 0, 0);
            string path = Directory.GetCurrentDirectory();
            path += $"\\Storage\\Calorie-Count-{months[this.now.Month]}-{this.now.Year}.xml";

            if (File.Exists(path))
            {
                if (!loadFromXML(path))
                {
                    addtoXML(0, 0, this.now.Day, path);
                }
            }
            else
            {
                createXML(path);
            }

        }

        private void createXML(string path)
        {
            XmlWriter xmlWriter = XmlWriter.Create(path);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement(months[this.now.Month]);

            xmlWriter.WriteStartElement("caloriesdata");
            xmlWriter.WriteAttributeString("calories_burned", this.data.caloriesBurned.ToString());
            xmlWriter.WriteAttributeString("calories_earned", this.data.caloriesEarned.ToString());
            xmlWriter.WriteAttributeString("day", this.data.date.Day.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        private void addtoXML(int caloriesBurned, int caloriesEarned, int day, string path)
        {
            XDocument xDocument = XDocument.Load(path);

            XElement root = xDocument.Element(months[this.now.Month]);
            IEnumerable<XElement> rows = root.Descendants("caloriesdata");
            XElement lastRow = rows.Last();
            lastRow.AddAfterSelf(
               new XElement("caloriesdata",
               new XAttribute("calories_earned", caloriesBurned),
               new XAttribute("calories_burned", caloriesEarned),
               new XAttribute("day", day)));
            xDocument.Save(path);
        }

        private void updateXML(int caloriesBurned, int caloriesEarned, int day, string path)
        {

            int comp;
            XDocument xDocument = XDocument.Load(path);

            foreach (XElement xe in xDocument.Elements().Elements())
            {
                if(int.TryParse(xe.Attribute("day").Value, out comp))
                {
                    if (comp == day)
                    {
                        xe.Attribute("calories_burned").SetValue(caloriesBurned.ToString());
                        xe.Attribute("calories_earned").SetValue(caloriesEarned.ToString());
                    }
                }
            }
            xDocument.Save(path);
            __LoadData__();
        }

        private bool loadFromXML(string path)
        {
            string xmldoc = File.ReadAllText(path);

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmldoc);

            foreach(XmlElement xe in xmlDocument.DocumentElement )
            {
                int comp = int.Parse(xe.GetAttribute("day"));
                if (comp == this.now.Day)
                {
                    this.data.caloriesBurned = int.Parse(xe.GetAttribute("calories_burned"));
                    this.data.caloriesEarned = int.Parse(xe.GetAttribute("calories_earned"));
                    __LoadData__();
                    return true;
                }
            }

            return false;
        }

        private void __LoadData__()
        {
            int calorieBalanece = (this.defaultCalories + this.data.caloriesEarned) - this.data.caloriesBurned;

            lblCalorieBalance.Text = $"Calorie Balance: {calorieBalanece}cal";
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

            this.data.caloriesBurned += calorie;
            __LoadData__();
        }
        private void btnDebug_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCalories_Click(object sender, EventArgs e)
        {
            int deduct = 0;
            string path = Directory.GetCurrentDirectory();
            path += $"\\Storage\\Calorie-Count-{months[this.now.Month]}-{this.now.Year}.xml";

            if (int.TryParse(txtAddDeficet.Text.Trim(), out deduct))
            {
                this.data.caloriesBurned += deduct - this.data.caloriesEarned;
                __LoadData__();
                updateXML(this.data.caloriesBurned, this.data.caloriesEarned, this.now.Day, path);
            }
            else
            {
                MessageBox.Show("Data entered was not a number, please use a number");
            }
        }

        private void btnLibraryAdd_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path += @"\Storage\Food-Library\";

            OpenFileDialog library = new OpenFileDialog();
            library.InitialDirectory = path;

            library.Filter = "txt files | *.txt";

            if(library.ShowDialog() == DialogResult.OK)
            {
                __ReadData__(library.FileName);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalEarned_Click(object sender, EventArgs e)
        {
            int earned = 0;
            string path = Directory.GetCurrentDirectory();
            path += $"\\Storage\\Calorie-Count-{months[this.now.Month]}-{this.now.Year}.xml";

            if (int.TryParse(txtAddDeficet.Text.Trim(), out earned))
            {
                this.data.caloriesEarned = earned;
                __LoadData__();
                updateXML(this.data.caloriesBurned, this.data.caloriesEarned, this.now.Day, path);
            }
            else
            {
                MessageBox.Show("Data entered was not a number, please use a number");
            }
        }
    }
}
