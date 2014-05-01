using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HazeronAdviser
{
    public partial class Main : Form
    {
        List<HCityObj> hCityList = new List<HCityObj>();
        List<HShipObj> hShipList = new List<HShipObj>();

        public Main()
        {
            InitializeComponent();
            toolStripProgressBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] fileList = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Shores of Hazeron\Mail"); // %USERPROFILE%\Shores of Hazeron\Mail
            toolStripStatusLabel1.Text = "Working...";
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = fileList.Length;
            toolStripProgressBar1.Visible = true;
            lbxShip.Items.Clear();
            lbxCity.Items.Clear();
            tbxShip.Clear();
            tbxCity.Clear();
            //textBox2.Text = String.Join(Environment.NewLine, fileList); // Lists all files in the SoH mail folder.
            foreach (string file in fileList)
            {
                if (HMail.IsCityReport(file))
                {
                    HCityObj temp = new HCityObj(new HMailObj(file));
                    if (hCityList.Any(city => city.ID == temp.ID))
                        hCityList[hCityList.FindIndex(city => city.ID == temp.ID)].Update(new HMailObj(file));
                    else
                        hCityList.Add(temp);
                }
                else if (HMail.IsShipLog(file))
                {
                    HShipObj temp = new HShipObj(new HMailObj(file));
                    if (hShipList.Any(ship => ship.ID == temp.ID))
                        hShipList[hShipList.FindIndex(ship => ship.ID == temp.ID)].Update(new HMailObj(file));
                    else
                        hShipList.Add(temp);
                }
                toolStripProgressBar1.Increment(1);
            }
            toolStripProgressBar1.Visible = false;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = hCityList.Count + hShipList.Count;
            toolStripProgressBar1.Visible = true;
            foreach (var hCity in hCityList)
            {
                string text = "";
                text += hCity.Name;
                //text += " - ";
                //text += hCity.ID;
                text += " - ";
                text += hCity.LastUpdaredString;
                text += " - ";
                text += hCity.MoraleShort;
                lbxCity.Items.Add(text);
                toolStripProgressBar1.Increment(1);
            }
            foreach (var hShip in hShipList)
            {
                string text = "";
                text += hShip.Name;
                //text += " - ";
                //text += hShip.ID;
                text += " - ";
                text += hShip.LastUpdaredString;
                text += " - ";
                text += hShip.FuelShort;
                lbxShip.Items.Add(text);
                toolStripProgressBar1.Increment(1);
            }
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel1.Text = "Done!";
        }

        private void lbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxCity.SelectedIndex != -1)
            {
                tbxCity.Text = hCityList[lbxCity.SelectedIndex].BodyTest;
            }
        }

        private void lbxShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxShip.SelectedIndex != -1)
            {
                tbxShip.Text = hShipList[lbxShip.SelectedIndex].BodyTest;
            }
        }
    }
}