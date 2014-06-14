#define RELEASE
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
        List<HCity> hCityList = new List<HCity>();
        List<HShip> hShipList = new List<HShip>();
        List<HOfficer> hOfficerList = new List<HOfficer>();

        Image imageCity;
        Image imageShip;
        Image imageOfficer;

        Color attantionMinor = Color.FromArgb(255, 255, 150); // Somewhere between LightYellow and Yellow.
        Color attantionMajor = Color.LightPink;

        public Main()
        {
            InitializeComponent();
            toolStripProgressBar1.Visible = false;
            toolStripProgressBar2.Visible = false;
            imageCity = HazeronAdviser.Properties.Resources.c_Flag;
            imageShip = HazeronAdviser.Properties.Resources.GovSpacecraft;
            imageOfficer = HazeronAdviser.Properties.Resources.Officer;
            dgvCity.Columns["ColumnCityAbandonment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCity.Columns["ColumnCityAbandonment"].DefaultCellStyle.Font = new Font("Lucida Console", 9); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = false;
            toolStripProgressBar2.Visible = false;
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Shores of Hazeron", "Mail")))
            {
                toolStripStatusLabel1.Text = "\""+Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Shores of Hazeron", "Mail")+"\" does not exist.";
                if (DialogResult.Yes == MessageBox.Show("Could not find Hazeron Mail folder:" + Environment.NewLine + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Shores of Hazeron", "Mail") + Environment.NewLine + Environment.NewLine + "Copy directory path to clipboard?", "Mail Folder Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2))
                    Clipboard.SetText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Shores of Hazeron", "Mail"));
                return;
            }
            string[] fileList = Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Shores of Hazeron", "Mail")); // %USERPROFILE%\Shores of Hazeron\Mail
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = fileList.Length;
            toolStripProgressBar1.Visible = true;
            toolStripStatusLabel1.Text = "Scanning mails...";
            toolStripStatusLabel1.Invalidate();
            statusStrip1.Update();
            dgvCity.Rows.Clear();
            dgvShip.Rows.Clear();
            dgvOfficer.Rows.Clear();
            dgvCity.Refresh();
            dgvShip.Refresh();
            dgvOfficer.Refresh();
            tbxCity.Clear();
            tbxShip.Clear();
            tbxOfficer.Clear();
            foreach (string file in fileList)
            {
                #if RELEASE
                try
                {
                #endif
                    if (HMail.IsCityReport(file))
                    {
                        HCity temp = new HCity(new HMail(file));
                        if (hCityList.Any(city => city.ID == temp.ID))
                            hCityList[hCityList.FindIndex(city => city.ID == temp.ID)].Update(new HMail(file));
                        else
                            hCityList.Add(temp);
                    }
                    else if (HMail.IsShipLog(file))
                    {
                        HShip temp = new HShip(new HMail(file));
                        if (hShipList.Any(ship => ship.ID == temp.ID))
                            hShipList[hShipList.FindIndex(ship => ship.ID == temp.ID)].Update(new HMail(file));
                        else
                            hShipList.Add(temp);
                    }
                    else if (HMail.IsOfficerTenFour(file))
                    {
                        HOfficer temp = new HOfficer(new HMail(file));
                        if (hOfficerList.Any(officer => officer.ID == temp.ID))
                            hOfficerList[hOfficerList.FindIndex(ship => ship.ID == temp.ID)].Update(new HMail(file));
                        else
                            hOfficerList.Add(temp);
                    }
                    toolStripProgressBar1.Increment(1);
                #if RELEASE
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("### Error while scanning mail file:");
                    System.Diagnostics.Debug.WriteLine("### " + ex.ToString());
                    toolStripStatusLabel1.Text = "Error while scanning mail file: " + file;
                    if (DialogResult.Yes == MessageBox.Show("Failed reading mail file:" + Environment.NewLine + file + Environment.NewLine + Environment.NewLine + "Copy mail filepath to clipboard?", "Mail Reading Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2))
                        Clipboard.SetText(file);
                    return;
                }
                #endif
            }
            toolStripProgressBar2.Value = 0;
            toolStripProgressBar2.Maximum = hCityList.Count + hShipList.Count + hOfficerList.Count;
            toolStripProgressBar2.Visible = true;
            toolStripStatusLabel1.Text = "Filling tables...";
            toolStripStatusLabel1.Invalidate();
            statusStrip1.Update();
            #region Fill City Table
            foreach (var hCity in hCityList)
            {
                dgvCity.Rows.Add();
                int row = dgvCity.RowCount - 1;
                dgvCity.Rows[row].Cells["ColumnCityIndex"].Value = row;
                dgvCity.Rows[row].Cells["ColumnCitySelection"].Value = false;
                dgvCity.Rows[row].Cells["ColumnCityIcon"].Value = imageCity;
                dgvCity.Rows[row].Cells["ColumnCityName"].Value = hCity.Name;
                dgvCity.Rows[row].Cells["ColumnCityMorale"].Value = hCity.MoraleShort;
                dgvCity.Rows[row].Cells["ColumnCityAbandonment"].Value = hCity.DecayDay;
                dgvCity.Rows[row].Cells["ColumnCityPopulation"].Value = hCity.PopulationShort;
                dgvCity.Rows[row].Cells["ColumnCityLivingConditions"].Value = hCity.LivingShort;
                dgvCity.Rows[row].Cells["ColumnCityDate"].Value = hCity.LastUpdaredString;
                // Graph
                hCity.Timeslice.Sort((x, y) => y.Timestamp.CompareTo(x.Timestamp));
                // AttentionCodes
                if (hCity.AttentionCode != 0x00)
                {
                    dgvCity.Rows[row].Cells["ColumnCityName"].Style.BackColor = attantionMinor;
                    if (HHelper.FlagCheck(hCity.AttentionCode, 0x01)) // 0b00000001 // More jobs than homes, or too many unemployed.
                        dgvCity.Rows[row].Cells["ColumnCityLivingConditions"].Style.BackColor = attantionMinor;
                    if (HHelper.FlagCheck(hCity.AttentionCode, 0x02)) // 0b00000010 // Population not full.
                        dgvCity.Rows[row].Cells["ColumnCityPopulation"].Style.BackColor = attantionMinor;
                    if (HHelper.FlagCheck(hCity.AttentionCode, 0x04)) // 0b00000100 // Less than 21 days to decay.
                        dgvCity.Rows[row].Cells["ColumnCityAbandonment"].Style.BackColor = attantionMinor;
                    if (HHelper.FlagCheck(hCity.AttentionCode, 0x08)) // 0b00001000 // Less than 7 days to decay.
                        dgvCity.Rows[row].Cells["ColumnCityAbandonment"].Style.BackColor = attantionMajor;
                    if (HHelper.FlagCheck(hCity.AttentionCode, 0x10)) // 0b00010000 // Over populated!
                        dgvCity.Rows[row].Cells["ColumnCityPopulatio"].Style.BackColor = attantionMajor;
                    if (HHelper.FlagCheck(hCity.AttentionCode, 0x20)) // 0b00100000 // Population is 0.
                        dgvCity.Rows[row].Cells["ColumnCityPopulation"].Style.BackColor = attantionMajor;
                    if (HHelper.FlagCheck(hCity.AttentionCode, 0x40)) // 0b01000000 // Morale not full.
                        dgvCity.Rows[row].Cells["ColumnCityMorale"].Style.BackColor = attantionMajor;
                    if (HHelper.FlagCheck(hCity.AttentionCode, 0x80)) // 0b10000000 // MSG_CityFinalDecayReport
                        dgvCity.Rows[row].Cells["ColumnCityName"].Style.BackColor = attantionMajor;
                }
                toolStripProgressBar2.Increment(1);
            }
            #endregion
            #region Fill Ship Table
            foreach (var hShip in hShipList)
            {
                dgvShip.Rows.Add();
                int row = dgvShip.RowCount - 1;
                dgvShip.Rows[row].Cells["ColumnShipIndex"].Value = row;
                dgvShip.Rows[row].Cells["ColumnShipSelection"].Value = false;
                dgvShip.Rows[row].Cells["ColumnShipIcon"].Value = imageShip;
                dgvShip.Rows[row].Cells["ColumnShipName"].Value = hShip.Name;
                dgvShip.Rows[row].Cells["ColumnShipFuel"].Value = hShip.FuelShort;
                dgvShip.Rows[row].Cells["ColumnShipDamage"].Value = hShip.DamageShort;
                dgvShip.Rows[row].Cells["ColumnShipDate"].Value = hShip.LastUpdaredString;
                // AttentionCodes
                if (hShip.AttentionCode != 0x00)
                {
                    //if (HHelper.FlagCheck(hShip.AttentionCode, 0x01)) // 0b00000001 // Nothing yet!
                    //    dgvShip.Rows[row].Cells["ColumnShipIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hShip.AttentionCode, 0x02)) // 0b00000010 // Nothing yet!
                    //    dgvShip.Rows[row].Cells["ColumnShipIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hShip.AttentionCode, 0x04)) // 0b00000100 // Nothing yet!
                    //    dgvShip.Rows[row].Cells["ColumnShipIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hShip.AttentionCode, 0x08)) // 0b00001000 // Nothing yet!
                    //    dgvShip.Rows[row].Cells["ColumnShipIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hShip.AttentionCode, 0x10)) // 0b00010000 // Nothing yet!
                    //    dgvShip.Rows[row].Cells["ColumnShipIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hShip.AttentionCode, 0x20)) // 0b00100000 // Nothing yet!
                    //    dgvShip.Rows[row].Cells["ColumnShipIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hShip.AttentionCode, 0x40)) // 0b01000000 // Nothing yet!
                    //    dgvShip.Rows[row].Cells["ColumnShipIndex"].Style.BackColor = attantionMajor;
                    if (HHelper.FlagCheck(hShip.AttentionCode, 0x80)) // 0b10000000 // MSG_ShipLogFinal
                        dgvShip.Rows[row].Cells["ColumnShipName"].Style.BackColor = attantionMajor;
                }
                toolStripProgressBar2.Increment(1);
            }
            #endregion
            #region Fill Officer Table
            foreach (var hOfficer in hOfficerList)
            {
                dgvOfficer.Rows.Add();
                int row = dgvOfficer.RowCount - 1;
                dgvOfficer.Rows[row].Cells["ColumnOfficerIndex"].Value = row;
                dgvOfficer.Rows[row].Cells["ColumnOfficerSelection"].Value = false;
                dgvOfficer.Rows[row].Cells["ColumnOfficerIcon"].Value = imageOfficer;
                dgvOfficer.Rows[row].Cells["ColumnOfficerName"].Value = hOfficer.Name;
                dgvOfficer.Rows[row].Cells["ColumnOfficerHome"].Value = hOfficer.Home;
                dgvOfficer.Rows[row].Cells["ColumnOfficerLocation"].Value = hOfficer.Location;
                dgvOfficer.Rows[row].Cells["ColumnOfficerDate"].Value = hOfficer.LastUpdaredString;
                // AttentionCodes
                if (hOfficer.AttentionCode != 0x00)
                {
                    dgvOfficer.Rows[row].Cells["ColumnOfficerName"].Style.BackColor = attantionMinor;
                    if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x01)) // 0b00000001 // MSG_OfficerReady
                        dgvOfficer.Rows[row].Cells["ColumnOfficerLocation"].Style.BackColor = attantionMinor;
                    //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x02)) // 0b00000010 // Nothing yet!
                    //    dgvOfficer.Rows[row].Cells["ColumnOfficerIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x04)) // 0b00000100 // Nothing yet!
                    //    dgvOfficer.Rows[row].Cells["ColumnOfficerIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x08)) // 0b00001000 // Nothing yet!
                    //    dgvOfficer.Rows[row].Cells["ColumnOfficerIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x10)) // 0b00010000 // Nothing yet!
                    //    dgvOfficer.Rows[row].Cells["ColumnOfficerIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x20)) // 0b00100000 // Nothing yet!
                    //    dgvOfficer.Rows[row].Cells["ColumnOfficerIndex"].Style.BackColor = attantionMajor;
                    //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x40)) // 0b01000000 // Nothing yet!
                    //    dgvOfficer.Rows[row].Cells["ColumnOfficerIndex"].Style.BackColor = attantionMajor;
                    if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x80)) // 0b10000000 // MSG_OfficerDeath
                        dgvOfficer.Rows[row].Cells["ColumnOfficerName"].Style.BackColor = attantionMajor;
                }
                toolStripProgressBar2.Increment(1);
            }
            #endregion
            toolStripProgressBar1.Visible = false;
            toolStripProgressBar2.Visible = false;
            toolStripStatusLabel1.Text = "Done!";
        }

        #region List Selection
        private void dgvCity_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCity.SelectedRows.Count != 0 && dgvCity.SelectedRows[0].Index != -1 && dgvCity.Rows[(int)dgvCity.SelectedRows[0].Index].Cells["ColumnCityIndex"].Value != null)
            {
                tbxCity.Text = hCityList[(int)dgvCity.Rows[(int)dgvCity.SelectedRows[0].Index].Cells["ColumnCityIndex"].Value].BodyTest;
                pCityStatistics.Refresh();
            }
        }

        private void dgvShip_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvShip.SelectedRows.Count != 0 && dgvShip.SelectedRows[0].Index != -1 && dgvShip.Rows[(int)dgvShip.SelectedRows[0].Index].Cells["ColumnShipIndex"].Value != null)
            {
                tbxShip.Text = hShipList[(int)dgvShip.Rows[(int)dgvShip.SelectedRows[0].Index].Cells["ColumnShipIndex"].Value].BodyTest;
            }
        }

        private void dgvOfficer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOfficer.SelectedRows.Count != 0 && dgvOfficer.SelectedRows[0].Index != -1 && dgvOfficer.Rows[(int)dgvOfficer.SelectedRows[0].Index].Cells["ColumnOfficerIndex"].Value != null)
            {
                tbxOfficer.Text = hOfficerList[(int)dgvOfficer.Rows[(int)dgvOfficer.SelectedRows[0].Index].Cells["ColumnOfficerIndex"].Value].BodyTest;
            }
        }
        #endregion

        #region Statistics Graphics
        private void pCityStatistics_Paint(object sender, PaintEventArgs e) // gCityStatistics
        {
            Graphics gCityStatistics = e.Graphics;
            if (dgvCity.SelectedRows.Count != 0 && dgvCity.SelectedRows[0].Index != -1 && dgvCity.Rows[(int)dgvCity.SelectedRows[0].Index].Cells["ColumnCityIndex"].Value != null)
            {
                DrawingTools.DrawGraphAxles(pCityStatistics, gCityStatistics, "Tick", "Pop");
                List<HCitySlice> citySlices = hCityList[(int)dgvCity.Rows[(int)dgvCity.SelectedRows[0].Index].Cells["ColumnCityIndex"].Value].Timeslice;
                int[] yValue;
                yValue = citySlices.Select(x => x.PopulationLimit).ToArray();
                DrawingTools.DrawGraph(pCityStatistics, gCityStatistics, yValue, Color.Red);
                yValue = citySlices.Select(x => x.Population).ToArray();
                DrawingTools.DrawGraph(pCityStatistics, gCityStatistics, yValue, Color.LightGreen);
                yValue = citySlices.Select(x => x.Homes).ToArray();
                DrawingTools.DrawGraph(pCityStatistics, gCityStatistics, yValue, Color.Green);
                yValue = citySlices.Select(x => x.Jobs).ToArray();
                DrawingTools.DrawGraph(pCityStatistics, gCityStatistics, yValue, Color.Blue);
            }
        }
        #endregion
    }
}