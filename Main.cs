//#define BACKUP_FOLDER
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
        Dictionary<int, HCity> hCityList;
        Dictionary<int, HSystem> hSystemList;
        Dictionary<int, HSector> hSectorList;
        Dictionary<int, HShip> hShipList;
        Dictionary<int, HOfficer> hOfficerList;
        Dictionary<int, HEvent> hEventList;

        List<int> charFilterList = new List<int>();
        List<HCharacter> charList = new List<HCharacter>();

        Image imageCity;
        Image imageSystem;
        Image imageShip;
        Image imageOfficer;
        Image imageDiplomacy;
        Image imageFriend;
        Image imageGovernment;
        Image imageChannel;
        Image imageAccept;
        Image imageTreasury;
        Image imageLocator;
        Image imageStation;
        Image imageVoice;
        Image imageFlag;
        Image imageTarget;

        Color attantionMinor = Color.FromArgb(255, 255, 150); // Somewhere between LightYellow and Yellow.
        Color attantionMajor = Color.LightPink;

        string hMailFolder;

        public Main()
        {
            InitializeComponent();

#if DEBUG
            this.Text += " (DEBUG MODE)";
#endif
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //notifyIcon1.BalloonTipTitle = this.Text;
            //notifyIcon1.Text = this.Text;
            //notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            // Hidden these SplitContainer Panels while they remain unused.
            splitContainerCityBank.Panel1Collapsed = true;
            splitContainerShipOverview.Panel1Collapsed = true;
            splitContainerOfficerOverview.Panel1Collapsed = true;
            splitContainerEventOverview.Panel1Collapsed = true;

            toolStripProgressBar1.Visible = false;
            toolStripProgressBar2.Visible = false;

            imageCity = HazeronAdviser.Properties.Resources.MsgCity;
            imageSystem = HazeronAdviser.Properties.Resources.RangeSystem;
            imageShip = HazeronAdviser.Properties.Resources.c_Spacecraft;
            imageOfficer = HazeronAdviser.Properties.Resources.Officer;
            imageDiplomacy = HazeronAdviser.Properties.Resources.CommDiplomacy;
            imageFriend = HazeronAdviser.Properties.Resources.CommFriend;
            imageGovernment = HazeronAdviser.Properties.Resources.CommGovernment;
            imageChannel = HazeronAdviser.Properties.Resources.CommStdChannel;
            imageAccept = HazeronAdviser.Properties.Resources.MsgAccept;
            imageTreasury = HazeronAdviser.Properties.Resources.c_Money;
            imageLocator = HazeronAdviser.Properties.Resources.Locator;
            imageStation = HazeronAdviser.Properties.Resources.CommStation;
            imageVoice = HazeronAdviser.Properties.Resources.CommVoice;
            imageFlag = HazeronAdviser.Properties.Resources.c_Flag;
            imageTarget = HazeronAdviser.Properties.Resources.MsgSpot;

            dgvCity.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvCity.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvSystem.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvSystem.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvShip.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvShip.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvOfficer.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvOfficer.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEvent.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvEvent.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCity.Columns["dgvCityColumnAbandonment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCity.Columns["dgvCityColumnAbandonment"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvCity.Columns["dgvCityColumnMoraleModifiers"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvCity.Columns["dgvCityColumnMorale"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvSystem.Columns["dgvSystemColumnAbandonment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSystem.Columns["dgvSystemColumnAbandonment"].DefaultCellStyle.Font = new Font("Lucida Console", 9);
            dgvShip.Columns["dgvShipColumnAbandonment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvShip.Columns["dgvShipColumnAbandonment"].DefaultCellStyle.Font = new Font("Lucida Console", 9);

            cmbCharFilter.SelectedIndex = 0;

#if BACKUP_FOLDER
            hMailFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Shores of Hazeron", "Mail (Backup)"); // %USERPROFILE%\Shores of Hazeron\Mail (Backup)
#else
            hMailFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Shores of Hazeron", "Mail"); // %USERPROFILE%\Shores of Hazeron\Mail
#endif
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ScanHMails();
        }

        private void ScanHMails()
        {
            toolStripProgressBar1.Visible = false;
            toolStripProgressBar2.Visible = false;

            // Scan the Hazeron Mail folder and get all file names.
            if (!Directory.Exists(hMailFolder))
            {
                toolStripStatusLabel1.Text = "\"" + hMailFolder + "\" does not exist.";
                if (DialogResult.Yes == MessageBox.Show("Could not find Hazeron Mail folder:" + Environment.NewLine + hMailFolder + Environment.NewLine + Environment.NewLine + "Copy directory path to clipboard?", "Mail Folder Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2))
                    Clipboard.SetText(hMailFolder);
                return;
            }
            string[] fileList = Directory.GetFiles(hMailFolder, "*.*.*.m");

            // Clear the DataGridView tables.
            dgvCity.Rows.Clear();
            dgvSystem.Rows.Clear();
            dgvShip.Rows.Clear();
            dgvOfficer.Rows.Clear();
            dgvEvent.Rows.Clear();
            dgvCity.Refresh();
            dgvSystem.Refresh();
            dgvShip.Refresh();
            dgvOfficer.Refresh();
            dgvEvent.Refresh();
            dgvCity.SelectionChanged -= dgvCity_SelectionChanged;
            dgvSystem.SelectionChanged -= dgvSystem_SelectionChanged;
            dgvShip.SelectionChanged -= dgvShip_SelectionChanged;
            dgvOfficer.SelectionChanged -= dgvOfficer_SelectionChanged;
            dgvEvent.SelectionChanged -= dgvEvent_SelectionChanged;

            ClearSelectedInfo();

            hCityList = new Dictionary<int, HCity>();
            hSystemList = new Dictionary<int, HSystem>();
            hSectorList = new Dictionary<int, HSector>();
            hShipList = new Dictionary<int, HShip>();
            hOfficerList = new Dictionary<int, HOfficer>();
            hEventList = new Dictionary<int, HEvent>();

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = fileList.Length;
            toolStripProgressBar1.Visible = true;
            toolStripStatusLabel1.Text = "Scanning mails...";
            toolStripStatusLabel1.Invalidate();
            statusStrip1.Update();
            #region Scan HMails
            foreach (string file in fileList)
            {
#if !DEBUG
                try
#endif
                {
                    if (HMail.IsUni4(file)) // Check if signature is 0x2110 before trying to read it.
                    {
                        HMail mail = new HMail(file);
                        if (HMail.IsCityReport(mail))
                        {
                            if (hCityList.ContainsKey(mail.SenderID))
                                hCityList[mail.SenderID].CompareMail(mail);
                            else
                                hCityList.Add(mail.SenderID, new HCity(mail));
                        }
                        else if (HMail.IsShipLog(mail))
                        {
                            if (hShipList.ContainsKey(mail.SenderID))
                                hShipList[mail.SenderID].CompareMail(mail);
                            else
                                hShipList.Add(mail.SenderID, new HShip(mail));
                        }
                        else if (HMail.IsOfficerTenFour(mail))
                        {
                            if (hOfficerList.ContainsKey(mail.SenderID))
                                hOfficerList[mail.SenderID].CompareMail(mail);
                            else
                                hOfficerList.Add(mail.SenderID, new HOfficer(mail));
                        }
                        else if (HMail.IsEventNotice(mail))
                        {
                            // Using MessageID instead because the sender is not important for events.
                            if (hEventList.ContainsKey(mail.MessageID))
                                hEventList[mail.MessageID].CompareMail(mail);
                            else
                                hEventList.Add(mail.MessageID, new HEvent(mail));
                        }
                        else if (mail.MessageType == 0x00 && !charList.Any(x => x.IdNum == mail.SenderID)) // Add to character list.
                            charList.Add(new HCharacter(mail));
                        if (!charFilterList.Contains(mail.RecipientID))
                            charFilterList.Add(mail.RecipientID);
                    }
                }
#if !DEBUG
                catch (IOException ioex)
                {
                    System.Diagnostics.Debug.WriteLine("### Error while scanning mail file:");
                    System.Diagnostics.Debug.WriteLine("### " + ioex.ToString());
                    toolStripStatusLabel1.Text = "Error while scanning mail file: " + file;
                    if (DialogResult.Yes == MessageBox.Show("Failed to located or open mail file:" + Environment.NewLine + file + Environment.NewLine + Environment.NewLine + "Copy mail filepath to clipboard?", "Mail Scanning Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2))
                        Clipboard.SetText(file);
                    continue; // Continue reading the rest of the mails even though one failed, may cause more than one popup to appear if multiple failures.
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("### Error while reading mail file:");
                    System.Diagnostics.Debug.WriteLine("### " + ex.ToString());
                    toolStripStatusLabel1.Text = "Error while reading mail file: " + file;
                    if (DialogResult.Yes == MessageBox.Show("Failed reading mail file:" + Environment.NewLine + file + Environment.NewLine + Environment.NewLine + "Copy mail filepath to clipboard?", "Mail Reading Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2))
                        Clipboard.SetText(file);
                    continue; // Continue reading the rest of the mails even though one failed, may cause more than one popup to appear if multiple failures.
                }
#endif
                toolStripProgressBar1.Increment(1);
            }
            #endregion

            toolStripProgressBar2.Value = 0;
            toolStripProgressBar2.Maximum = hCityList.Count + hSystemList.Count + (hShipList.Count * 2) + hOfficerList.Count + hEventList.Count;
            toolStripProgressBar2.Visible = true;
            toolStripStatusLabel1.Text = "Filling tables...";
            toolStripStatusLabel1.Invalidate();
            statusStrip1.Update();
            #region Fill City Table
            foreach (var hCity in hCityList.Values)
            {
                if (TryInitialize(hCity))
                {
                    DataGridViewRow row = dgvCity.Rows[dgvCity.Rows.Add()];
                    row.Cells["dgvCityColumnId"].Value = hCity.ID;
                    row.Cells["dgvCityColumnIcon"].Value = imageCity;
                    row.Cells["dgvCityColumnName"].Value = hCity;
                    row.Cells["dgvCityColumnLocation"].Value = hCity.SystemName + ", " + hCity.PlanetName + " z" + hCity.Zone;
                    row.Cells["dgvCityColumnAbandonment"].Value = hCity.AbandonmentColumn;
                    row.Cells["dgvCityColumnMoraleModifiers"].Value = hCity.MoraleModifiersColumn;
                    row.Cells["dgvCityColumnMorale"].Value = hCity.MoraleColumn;
                    row.Cells["dgvCityColumnPopulation"].Value = hCity.PopulationColumn;
                    row.Cells["dgvCityColumnLivingConditions"].Value = hCity.LivingConditionsColumn;
                    row.Cells["dgvCityColumnLoyalty"].Value = hCity.LoyaltyColumn;
                    row.Cells["dgvCityColumnBank"].Value = hCity.BankGovBalance.ToString("C", Hazeron.NumberFormat);
                    row.Cells["dgvCityColumnTribute"].Value = hCity.BankTributeColumn;
                    row.Cells["dgvCityColumnDate"].Value = hCity.LastUpdaredString;
                    // Attentions
                    foreach (AttentionMessage attaction in hCity.Attentions)
                    {
                        DataGridViewCell[] cells = new DataGridViewCell[2];
                        cells[0] = row.Cells["dgvCityColumnName"];
                        cells[1] = row.Cells["dgvCity" + attaction.Column];
                        foreach (DataGridViewCell cell in cells)
                        {
                            if (cell.Style.BackColor != attantionMajor && attaction.Priority == 1)
                            {
                                cell.Style.BackColor = attantionMinor;
                                cell.Style.SelectionBackColor = attantionMinor;
                            }
                            else if (attaction.Priority >= 2)
                            {
                                cell.Style.BackColor = attantionMajor;
                                cell.Style.SelectionBackColor = attantionMajor;
                            }
                            if (cell.ToolTipText == "")
                                cell.ToolTipText = attaction.Text;
                            else
                                cell.ToolTipText += Environment.NewLine + attaction.Text;
                        }
                    }
                    // Create system
                    if (hSystemList.ContainsKey(hCity.SystemID))
                        hSystemList[hCity.SystemID].AddCity(hCity);
                    else
                        hSystemList.Add(hCity.SystemID, new HSystem(hCity));
                }
                toolStripProgressBar2.Increment(1);
            }
            #endregion
            #region Fill System Table
            foreach (var hSystem in hSystemList.Values)
            {
                if (TryInitialize(hSystem))
                {
                    DataGridViewRow row = dgvSystem.Rows[dgvSystem.Rows.Add()];
                    row.Cells["dgvSystemColumnId"].Value = hSystem.ID;
                    row.Cells["dgvSystemColumnIcon"].Value = imageSystem;
                    row.Cells["dgvSystemColumnName"].Value = hSystem;
                    row.Cells["dgvSystemColumnCities"].Value = hSystem.Cities.Count;
                    row.Cells["dgvSystemColumnAbandonment"].Value = hSystem.AbandonmentColumn;
                    row.Cells["dgvSystemColumnMoraleModifiers"].Value = hSystem.MoraleModifiersColumn;
                    row.Cells["dgvSystemColumnMorale"].Value = hSystem.MoraleColumn;
                    row.Cells["dgvSystemColumnPopulation"].Value = hSystem.PopulationColumn;
                    row.Cells["dgvSystemColumnLoyalty"].Value = hSystem.LoyaltyColumn;
                    row.Cells["dgvSystemColumnBank"].Value = hSystem.Cities.Sum(x => x.BankGovBalance).ToString("C", Hazeron.NumberFormat);
                    row.Cells["dgvSystemColumnTribute"].Value = hSystem.Cities.Sum(x => x.BankTribute).ToString("C", Hazeron.NumberFormat);
                    row.Cells["dgvSystemColumnDate"].Value = hSystem.LastUpdaredString;
                    // Attentions
                    foreach (HCity city in hSystem.Cities)
                    {
                        foreach (AttentionMessage attaction in city.Attentions)
                        {
                            DataGridViewCell[] cells = new DataGridViewCell[2];
                            cells[0] = row.Cells["dgvSystemColumnName"];
                            if (attaction.Column == "ColumnLivingConditions")
                                cells[1] = row.Cells["dgvSystem" + "ColumnPopulation"];
                            else
                                cells[1] = row.Cells["dgvSystem" + attaction.Column];
                            foreach (DataGridViewCell cell in cells)
                            {
                                if (cell.Style.BackColor != attantionMajor && attaction.Priority == 1)
                                {
                                    cell.Style.BackColor = attantionMinor;
                                    cell.Style.SelectionBackColor = attantionMinor;
                                }
                                else if (attaction.Priority >= 2)
                                {
                                    cell.Style.BackColor = attantionMajor;
                                    cell.Style.SelectionBackColor = attantionMajor;
                                }
                                if (cell.ToolTipText == "")
                                    cell.ToolTipText = city.Name + Environment.NewLine + attaction.Text;
                                else
                                    cell.ToolTipText += Environment.NewLine + city.Name + Environment.NewLine + attaction.Text;
                            }
                        }
                    }
                    // Create sector
                    if (hSectorList.ContainsKey(hSystem.SectorID))
                        hSectorList[hSystem.SectorID].AddSystem(hSystem);
                    else
                        hSectorList.Add(hSystem.SectorID, new HSector(hSystem));
                }
                toolStripProgressBar2.Increment(1);
            }
            #endregion
            #region Fill Ship Table
            foreach (var hShip in hShipList.Values)
            {
                if (TryInitialize(hShip))
                {
                    DataGridViewRow row = dgvShip.Rows[dgvShip.Rows.Add()];
                    row.Cells["dgvShipColumnId"].Value = hShip.ID;
                    row.Cells["dgvShipColumnIcon"].Value = imageShip;
                    row.Cells["dgvShipColumnName"].Value = hShip;
                    row.Cells["dgvShipColumnLocation"].Value = hShip.SystemName + ", " + hShip.PlanetName;
                    row.Cells["dgvShipColumnAbandonment"].Value = hShip.AbandonmentColumn;
                    row.Cells["dgvShipColumnFuel"].Value = hShip.FuelColumn;
                    row.Cells["dgvShipColumnAccount"].Value = hShip.AccountColumn;
                    row.Cells["dgvShipColumnDamage"].Value = hShip.DamageColumn;
                    row.Cells["dgvShipColumnDate"].Value = hShip.LastUpdaredString;
                    // Attentions
                    foreach (AttentionMessage attaction in hShip.Attentions)
                    {
                        DataGridViewCell[] cells = new DataGridViewCell[2];
                        cells[0] = row.Cells["dgvShipColumnName"];
                        cells[1] = row.Cells["dgvShip" + attaction.Column];
                        foreach (DataGridViewCell cell in cells)
                        {
                            if (cell.Style.BackColor != attantionMajor && attaction.Priority == 1)
                            {
                                cell.Style.BackColor = attantionMinor;
                                cell.Style.SelectionBackColor = attantionMinor;
                            }
                            else if (attaction.Priority >= 2)
                            {
                                cell.Style.BackColor = attantionMajor;
                                cell.Style.SelectionBackColor = attantionMajor;
                            }
                            if (cell.ToolTipText == "")
                                cell.ToolTipText = attaction.Text;
                            else
                                cell.ToolTipText += Environment.NewLine + attaction.Text;
                        }
                    }
                }
                toolStripProgressBar2.Increment(1);
            }
            #endregion
            #region Fill Officer Table
            foreach (var hOfficer in hOfficerList.Values)
            {
                if (TryInitialize(hOfficer))
                {
                    DataGridViewRow row = dgvOfficer.Rows[dgvOfficer.Rows.Add()];
                    row.Cells["dgvOfficerColumnId"].Value = hOfficer.ID;
                    row.Cells["dgvOfficerColumnIcon"].Value = imageOfficer;
                    row.Cells["dgvOfficerColumnName"].Value = hOfficer.Name;
                    row.Cells["dgvOfficerColumnHome"].Value = hOfficer.HomeSystem + ", " + hOfficer.HomePlanet;
                    row.Cells["dgvOfficerColumnShip"].Value = hOfficer.Ship;
                    row.Cells["dgvOfficerColumnDate"].Value = hOfficer.LastUpdaredString;
                    // AttentionCodes
                    if (hOfficer.AttentionCode != 0x00)
                    {
                        row.Cells["dgvOfficerColumnName"].Style.BackColor = attantionMinor;
                        if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x01)) // 0b00000001 // MSG_OfficerContact
                            row.Cells["dgvOfficerColumnShip"].Style.BackColor = attantionMinor;
                        //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x02)) // 0b00000010 // Nothing yet!
                        //    row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                        //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x04)) // 0b00000100 // Nothing yet!
                        //    row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                        //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x08)) // 0b00001000 // Nothing yet!
                        //    row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                        //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x10)) // 0b00010000 // Nothing yet!
                        //    row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                        //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x20)) // 0b00100000 // Nothing yet!
                        //    row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                        //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x40)) // 0b01000000 // Nothing yet!
                        //    row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                        //if (HHelper.FlagCheck(hOfficer.AttentionCode, 0x80)) // 0b10000000 // Nothing yet!
                        //    row.Cells["dgvOfficerColumnName"].Style.BackColor = attantionMajor;
                    }
                }
                toolStripProgressBar2.Increment(1);
            }
            foreach (var hShipOfficer in hShipList.Values)
            {
                if (hShipOfficer.Initialized)
                {
                    dgvOfficer.Rows.Add();
                    DataGridViewRow row = dgvOfficer.Rows[dgvOfficer.RowCount - 1];
                    row.Cells["dgvOfficerColumnId"].Value = -hShipOfficer.ID;
                    row.Cells["dgvOfficerColumnIcon"].Value = imageShip;
                    row.Cells["dgvOfficerColumnName"].Value = hShipOfficer.OfficerName;
                    row.Cells["dgvOfficerColumnHome"].Value = hShipOfficer.OfficerHomeSystem + ", " + hShipOfficer.OfficerHomePlanet;
                    row.Cells["dgvOfficerColumnShip"].Value = hShipOfficer.Name;
                    row.Cells["dgvOfficerColumnDate"].Value = hShipOfficer.LastUpdaredString;
                    // AttentionCodes
                    //if (hShipOfficer.AttentionCode != 0x00)
                    //{
                    //    row.Cells["dgvOfficerColumnName"].Style.BackColor = attantionMinor;
                    //    if (HHelper.FlagCheck(hShipOfficer.AttentionCode, 0x01)) // 0b00000001 // Nothing yet!
                    //        row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                    //    if (HHelper.FlagCheck(hShipOfficer.AttentionCode, 0x02)) // 0b00000010 // Nothing yet!
                    //        row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                    //    if (HHelper.FlagCheck(hShipOfficer.AttentionCode, 0x04)) // 0b00000100 // Nothing yet!
                    //        row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                    //    if (HHelper.FlagCheck(hShipOfficer.AttentionCode, 0x08)) // 0b00001000 // Nothing yet!
                    //        row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                    //    if (HHelper.FlagCheck(hShipOfficer.AttentionCode, 0x10)) // 0b00010000 // Nothing yet!
                    //        row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                    //    if (HHelper.FlagCheck(hShipOfficer.AttentionCode, 0x20)) // 0b00100000 // Nothing yet!
                    //        row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                    //    if (HHelper.FlagCheck(hShipOfficer.AttentionCode, 0x40)) // 0b01000000 // Nothing yet!
                    //        row.Cells["dgvOfficerColumnId"].Style.BackColor = attantionMajor;
                    //    if (HHelper.FlagCheck(hShipOfficer.AttentionCode, 0x80)) // 0b10000000 // Nothing yet!
                    //        row.Cells["dgvOfficerColumnName"].Style.BackColor = attantionMajor;
                    //}
                    toolStripProgressBar2.Increment(1);
                }
            }
            #endregion
            #region Fill Event Table
            foreach (var hEvent in hEventList.Values)
            {
                if (TryInitialize(hEvent))
                {
                    DataGridViewRow row = dgvEvent.Rows[dgvEvent.Rows.Add()];
                    row.Cells["dgvEventColumnId"].Value = hEvent.MessageID;
                    if (hEvent.MessageType == 0x13) // MSG_Government
                    {
                        if (hEvent.Name == "State Department")
                            row.Cells["dgvEventColumnIcon"].Value = imageFriend;
                        if (hEvent.Name == "War Department")
                            row.Cells["dgvEventColumnIcon"].Value = imageTarget;
                        if (hEvent.Name == "Treasury Department")
                            row.Cells["dgvEventColumnIcon"].Value = imageTreasury;
                    }
                    else if (hEvent.MessageType == 0x16) // MSG_OfficerDeath
                        row.Cells["dgvEventColumnIcon"].Value = imageOfficer;
                    else if (hEvent.MessageType == 0x17) // MSG_CityFinalDecayReport
                        row.Cells["dgvEventColumnIcon"].Value = imageCity;
                    else if (hEvent.MessageType == 0x12) // MSG_ShipLogFinal
                        row.Cells["dgvEventColumnIcon"].Value = imageShip;
                    else if (hEvent.MessageType == 0x18) // MSG_DiplomaticMessage (?)
                        row.Cells["dgvEventColumnIcon"].Value = imageDiplomacy;
                    else if (hEvent.MessageType == 0x03 || hEvent.MessageType == 0x05) // MSG_CityOccupationReport or MSG_CityIntelligenceReport
                        row.Cells["dgvEventColumnIcon"].Value = imageFlag;
                    row.Cells["dgvEventColumnName"].Value = hEvent;
                    row.Cells["dgvEventColumnSubject"].Value = hEvent.Subject;
                    row.Cells["dgvEventColumnLocation"].Value = hEvent.SystemName + ", " + hEvent.PlanetName;
                    row.Cells["dgvEventColumnDate"].Value = hEvent.LastUpdaredString;
                    // AttentionCodes
                    if (hEvent.AttentionCode != 0x00)
                    {
                        //dgvEvent.Rows[row].Cells["dgvEventColumnName"].Style.BackColor = attantionMinor;
                        //if (HHelper.FlagCheck(hEvent.AttentionCode, 0x01)) // 0b00000001 // Nothing yet!
                        //    row.Cells["dgvEventColumnId"].Style.BackColor = attantionMinor;
                        //if (HHelper.FlagCheck(hEvent.AttentionCode, 0x02)) // 0b00000010 // Nothing yet!
                        //    row.Cells["dgvEventColumnId"].Style.BackColor = attantionMajor;
                        //if (HHelper.FlagCheck(hEvent.AttentionCode, 0x04)) // 0b00000100 // Nothing yet!
                        //    row.Cells["dgvEventColumnId"].Style.BackColor = attantionMajor;
                        if (HHelper.FlagCheck(hEvent.AttentionCode, 0x08)) // 0b00001000 // Attantion
                            row.Cells["dgvEventColumnName"].Style.BackColor = attantionMinor;
                        //if (HHelper.FlagCheck(hEvent.AttentionCode, 0x10)) // 0b00010000 // Nothing yet!
                        //    row.Cells["dgvEventColumnId"].Style.BackColor = attantionMajor;
                        //if (HHelper.FlagCheck(hEvent.AttentionCode, 0x20)) // 0b00100000 // Nothing yet!
                        //    row.Cells["dgvEventColumnId"].Style.BackColor = attantionMajor;
                        //if (HHelper.FlagCheck(hEvent.AttentionCode, 0x40)) // 0b01000000 // Nothing yet!
                        //    row.Cells["dgvEventColumnId"].Style.BackColor = attantionMajor;
                        if (HHelper.FlagCheck(hEvent.AttentionCode, 0x80)) // 0b10000000 // Death
                            row.Cells["dgvEventColumnName"].Style.BackColor = attantionMajor;
                    }
                }
                toolStripProgressBar2.Increment(1);
            }
            #endregion

            // Clear Character Filter dropdown box.
            cmbCharFilter.Enabled = false;
            cmbCharFilter.Items.Clear();
            cmbCharFilter.Items.Add("Show all");
            cmbCharFilter.SelectedIndex = 0;

            // Fill the Character Filter dropdown box.
            foreach (int charId in charFilterList)
            {
                if (charList.Any(x => x.IdNum == charId))
                {
                    HCharacter hChar = charList.Find(x => x.IdNum == charId);
                    cmbCharFilter.Items.Add(hChar.Name + " (" + hChar.ID + ")");
                }
                else
                    cmbCharFilter.Items.Add("??? (" + HHelper.ToID(charId) + ")");
            }
            cmbCharFilter.Enabled = true;

            toolStripProgressBar1.Visible = false;
            toolStripProgressBar2.Visible = false;
            ClearSeletion();
            dgvCity.SelectionChanged += dgvCity_SelectionChanged;
            dgvSystem.SelectionChanged += dgvSystem_SelectionChanged;
            dgvShip.SelectionChanged += dgvShip_SelectionChanged;
            dgvOfficer.SelectionChanged += dgvOfficer_SelectionChanged;
            dgvEvent.SelectionChanged += dgvEvent_SelectionChanged;

            toolStripStatusLabel1.Text = "Done!";
        }

        #region TryCases
        private bool TryInitialize(HObj hObj)
        {
#if !DEBUG
            try
#endif
            {
                if (hObj.Mail == null) // Temporary fix.
                    return false;
                hObj.Initialize();
            }
#if !DEBUG
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("### Error while processing mail body of mail file: ");
                System.Diagnostics.Debug.WriteLine("### " + ex.ToString());
                toolStripStatusLabel1.Text = "Error while processing mail body of mail file: " + hObj.Mail.FilePath;
                if (DialogResult.Yes == MessageBox.Show("Failed processing mail body of mail file:" + Environment.NewLine + hObj.Mail.FilePath + Environment.NewLine + Environment.NewLine + "Copy mail filepath to clipboard?", "Mail Body Processing Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2))
                    Clipboard.SetText(hObj.Mail.FilePath);
                return false;
            }
#endif
            return true;
        }

        private bool TryInitialize(HSystem hSystem)
        {
#if !DEBUG
            try
#endif
            {
                hSystem.Initialize();
            }
#if !DEBUG
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("### Error while initializing system: ");
                System.Diagnostics.Debug.WriteLine("### " + ex.ToString());
                toolStripStatusLabel1.Text = "Error while initializing system: " + hSystem.Name;
                MessageBox.Show("Failed initializing system:" + Environment.NewLine + hSystem.Name, "Initializing System Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
#endif
            return true;
        }
        #endregion

        private void ClearSeletion()
        {
            dgvCity.ClearSelection();
            dgvSystem.ClearSelection();
            dgvShip.ClearSelection();
            dgvOfficer.ClearSelection();
            dgvEvent.ClearSelection();
        }

        private void ClearSelectedInfo()
        {
            // City
            tabControlCity.Refresh();
            rtbCityOverview.Clear();
            rtbCityMorale.Clear();
            rtbCityPopulation.Clear();
            rtbCityTechnology.Clear();
            rtbCityBuildings.Clear();
            rtbCityDefences.Clear();
            rtbCityBank.Clear();
            tbxCity.Clear();
            // System
            tabControlSystem.Refresh();
            rtbSystemOverview.Clear();
            rtbSystemMorale.Clear();
            rtbSystemPopulation.Clear();
            rtbSystemTechnology.Clear();
            // Ship
            tabControlShip.Refresh();
            rtbShipOverview.Clear();
            tbxShip.Clear();
            // Officer
            tabControlOfficer.Refresh();
            rtbOfficerOverview.Clear();
            tbxOfficer.Clear();
            // Event
            tabControlEvent.Refresh();
            rtbEventOverview.Clear();
            tbxEvent.Clear();
        }

        #region List Selection
        private void dgvCity_SelectionChanged(object sender, EventArgs e)
        {
            ClearSelectedInfo();
            if (dgvCity.CurrentRow != null)
            {
                HCity city = (HCity)dgvCity.CurrentRow.Cells["dgvCityColumnName"].Value;
                RichBBCodeBox(rtbCityOverview, city.Overview);
                RichBBCodeBox(rtbCityMorale, city.MoraleOverview);
                RichBBCodeBox(rtbCityPopulation, city.PopulationOverview);
                RichBBCodeBox(rtbCityTechnology, city.TechnologyOverview);
                RichBBCodeBox(rtbCityBuildings, city.BuildingsOverview);
                RichBBCodeBox(rtbCityDefences, city.DefencesOverview);
                RichBBCodeBox(rtbCityBank, city.BankOverview);
                tbxCity.Text = city.MailBody;
                // Refresh graphs to make them update.
                pCityOverviewMorale.Refresh();
                pCityOverviewPopulation.Refresh();
                pCityMorale.Refresh();
                pCityPopulation.Refresh();
            }
        }
        
        private void dgvSystem_SelectionChanged(object sender, EventArgs e)
        {
            ClearSelectedInfo();
            if (dgvSystem.CurrentRow != null)
            {
                HSystem system = (HSystem)dgvSystem.CurrentRow.Cells["dgvSystemColumnName"].Value;
                RichBBCodeBox(rtbSystemOverview, system.Overview);
                RichBBCodeBox(rtbSystemMorale, system.MoraleOverview);
                RichBBCodeBox(rtbSystemPopulation, system.PopulationOverview);
                RichBBCodeBox(rtbSystemTechnology, system.TechnologyOverview);
                // Refresh graphs to make them update.
                pSystemOverviewMorale.Refresh();
                pSystemOverviewPopulation.Refresh();
                pSystemMorale.Refresh();
                pSystemPopulation.Refresh();
            }
        }

        private void dgvShip_SelectionChanged(object sender, EventArgs e)
        {
            ClearSelectedInfo();
            if (dgvShip.CurrentRow != null)
            {
                HShip ship = (HShip)dgvShip.CurrentRow.Cells["dgvShipColumnName"].Value;
                RichBBCodeBox(rtbShipOverview, ship.Overview);
                RichBBCodeBox(rtbShipMission, ship.MissionOverview);
                RichBBCodeBox(rtbShipRoster, ship.RosterOverview);
                RichBBCodeBox(rtbShipCargo, ship.CargoOverview);
                RichBBCodeBox(rtbShipDamage, ship.DamageOverview);
                tbxShip.Text = ship.MailBody;
            }
        }

        private void dgvOfficer_SelectionChanged(object sender, EventArgs e)
        {
            ClearSelectedInfo();
            if (dgvOfficer.CurrentRow != null)
            {
                int id = (int)dgvOfficer.CurrentRow.Cells["dgvOfficerColumnId"].Value;
                if (id >= 0)
                {
                    HOfficer officer = hOfficerList[id];
                    RichBBCodeBox(rtbOfficerOverview, officer.Overview);
                    tbxOfficer.Text = officer.MailBody;
                }
                else
                {
                    HShip ship = hShipList[Math.Abs(id)];
                    RichBBCodeBox(rtbOfficerOverview, ship.OfficerOverview);
                    tbxOfficer.Text = ship.MailBody;
                }
            }
        }

        private void dgvEvent_SelectionChanged(object sender, EventArgs e)
        {
            ClearSelectedInfo();
            if (dgvEvent.CurrentRow != null)
            {
                HEvent hEvent = (HEvent)dgvEvent.CurrentRow.Cells["dgvEventColumnName"].Value;// "event" is a reserved word.
                RichBBCodeBox(rtbEventOverview, hEvent.Overview);
                tbxEvent.Text = hEvent.MailBody;
            }
        }
        #endregion

        #region Character Filter
        private void cmbCharFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCharFilter.Enabled)
            {
                if (cmbCharFilter.SelectedIndex == 0)
                {
                    foreach (DataGridViewRow row in dgvCity.Rows)
                        row.Visible = true;
                    foreach (DataGridViewRow row in dgvSystem.Rows)
                        row.Visible = true;
                    foreach (DataGridViewRow row in dgvShip.Rows)
                        row.Visible = true;
                    foreach (DataGridViewRow row in dgvOfficer.Rows)
                        row.Visible = true;
                    foreach (DataGridViewRow row in dgvEvent.Rows)
                        row.Visible = true;
                }
                else
                {
                    int charId = charFilterList[cmbCharFilter.SelectedIndex - 1];
                    foreach (DataGridViewRow row in dgvCity.Rows)
                    {
                        row.Visible = ((HCity)row.Cells["dgvCityColumnName"].Value).Onwers.Contains(charId);
                    }
                    foreach (DataGridViewRow row in dgvSystem.Rows)
                    {
                        row.Visible = ((HSystem)row.Cells["dgvSystemColumnName"].Value).Onwers.Contains(charId);
                    }
                    foreach (DataGridViewRow row in dgvShip.Rows)
                    {
                        row.Visible = ((HShip)row.Cells["dgvShipColumnName"].Value).Onwers.Contains(charId);
                    }
                    foreach (DataGridViewRow row in dgvOfficer.Rows)
                    {
                        int id = (int)row.Cells["dgvOfficerColumnId"].Value;
                        if (id >= 0)
                            row.Visible = hOfficerList[id].Onwers.Contains(charId);
                        else
                            row.Visible = hShipList[Math.Abs(id)].Onwers.Contains(charId);
                    }
                    foreach (DataGridViewRow row in dgvEvent.Rows)
                    {
                        row.Visible = ((HEvent)row.Cells["dgvEventColumnName"].Value).Onwers.Contains(charId);
                    }
                }
                ClearSelectedInfo();
                ClearSeletion();
            }
        }
        #endregion

        #region Graph Graphics
        private void pCityPopulation_Paint(object sender, PaintEventArgs e)
        {
            if (dgvCity.CurrentRow != null)
            {
                HCity city = (HCity)dgvCity.CurrentRow.Cells["dgvCityColumnName"].Value;
                int yValue;
                BarGraph graphPop = new BarGraph(sender, e);
                graphPop.DrawXAxle("?", 5);
                graphPop.DrawYAxle("Population", (int)(city.PopulationLimit * 1.05));
                yValue = city.Loyalty;
                if (yValue > 0)
                    graphPop.DrawBar(Color.Yellow, 0, Math.Abs(yValue));
                else if (yValue < 0)
                    graphPop.DrawBar(Color.Orange, 0, Math.Abs(yValue));
                yValue = city.Population;
                graphPop.DrawBar(Color.LightGreen, 1, yValue);
                yValue = city.Homes;
                graphPop.DrawBar(Color.Green, 2, yValue);
                yValue = city.Jobs;
                graphPop.DrawBar(Color.Blue, 3, yValue);
                yValue = city.PopulationLimit;
                graphPop.DrawBar(Color.Red, 4, yValue);
            }
        }

        private void pCityMorale_Paint(object sender, PaintEventArgs e)
        {
            if (dgvCity.CurrentRow != null)
            {
                HCity city = (HCity)dgvCity.CurrentRow.Cells["dgvCityColumnName"].Value;
                int yValue;
                BarGraph graphMorale = new BarGraph(sender, e);
                graphMorale.DrawXAxle("?", 3);
                graphMorale.DrawYAxle("Morale", 20, -20);
                yValue = city.Morale;
                graphMorale.DrawBar(Color.Blue, 0, yValue);
                yValue = city.MoraleModifiers.Values.Sum();
                graphMorale.DrawBar(Color.Yellow, 1, yValue);
                yValue = city.MoraleModifiers.Values.Where(y => y > 0).Sum();
                if (yValue != 0)
                    graphMorale.DrawBar(Color.Green, 2, yValue);
                yValue = city.MoraleModifiers.Values.Where(y => y < 0).Sum();
                if (yValue != 0)
                    graphMorale.DrawBar(Color.Red, 2, yValue);
            }
        }

        private void pCityBank_Paint(object sender, PaintEventArgs e)
        {
            //if (dgvCity.CurrentRow != null)
            //{
            //    HCity city = hCityList[(int)dgvCity.Rows[(int)dgvCity.SelectedRows[0].Index].Cells["dgvCityColumnId"].Value];
            //    int yValue;
            //    BarGraph graphMorale = new BarGraph(sender, e);
            //    graphMorale.DrawXAxle("?", 2);
            //    graphMorale.DrawYAxle("¢", Math.Max(city.VBankExpenseResearchEst / 1000, city.VBankGovBalanceOld / 1000));
            //    yValue = city.VBankExpenseResearchEst / 1000;
            //    graphMorale.DrawBar(Color.Purple, 0, yValue);
            //    yValue = city.VBankGovBalanceOld / 1000;
            //    if (yValue > 0)
            //        graphMorale.DrawBar(Color.Green, 1, yValue);
            //    else if  (yValue < 0)
            //        graphMorale.DrawBar(Color.Red, 1, Math.Abs(yValue));
            //}
        }

        private void pSystemPopulation_Paint(object sender, PaintEventArgs e)
        {
            if (dgvSystem.CurrentRow != null)
            {
                HSystem system = (HSystem)dgvSystem.CurrentRow.Cells["dgvSystemColumnName"].Value;
                int yValue;
                BarGraph graphPop = new BarGraph(sender, e);
                graphPop.DrawXAxle("?", 5);
                graphPop.DrawYAxle("Population", (int)(system.PopulationLimit * 1.05));
                yValue = system.Loyalty;
                if (yValue > 0)
                    graphPop.DrawBar(Color.Yellow, 0, Math.Abs(yValue));
                else if (yValue < 0)
                    graphPop.DrawBar(Color.Orange, 0, Math.Abs(yValue));
                yValue = system.Population;
                graphPop.DrawBar(Color.LightGreen, 1, yValue);
                yValue = system.Homes;
                graphPop.DrawBar(Color.Green, 2, yValue);
                yValue = system.Jobs;
                graphPop.DrawBar(Color.Blue, 3, yValue);
                yValue = system.PopulationLimit;
                graphPop.DrawBar(Color.Red, 4, yValue);
            }
        }

        private void pSystemMorale_Paint(object sender, PaintEventArgs e)
        {
            if (dgvSystem.CurrentRow != null)
            {
                HSystem system = (HSystem)dgvSystem.CurrentRow.Cells["dgvSystemColumnName"].Value;
                int yValue;
                BarGraph graphMorale = new BarGraph(sender, e);
                graphMorale.DrawXAxle("Cities", system.Cities.Count);
                graphMorale.DrawYAxle("Morale", 20, -20);
                for (int i = 0; i < system.Cities.Count; i++)
                {
                    yValue = system.Cities[i].Morale;
                    graphMorale.DrawBar(Color.Blue, i, yValue);
                    yValue = system.Cities[i].MoraleModifiers.Values.Sum();
                    graphMorale.DrawBar(Color.Yellow, i, yValue);
                }
            }
        }

        private void GraphicPanel_SizeChanged(object sender, EventArgs e) // SizeChanged event for all graph panels.
        {
            (sender as Panel).Refresh();
        }
        #endregion

        private void RichBBCodeBox(RichTextBox rtb, string text)
        {
            int tag = 0;
            string command, affectedText;
            rtb.Clear();
            while (text.Contains("[") && text.Contains("]"))
            {
                tag = text.IndexOf('[');
                rtb.AppendText(text.Remove(tag));
                text = text.Substring(tag + 1);
                if (text.Contains(']'))
                {
                    tag = text.IndexOf(']');
                    command = text.Remove(tag);
                    text = text.Substring(tag + 1);
                    if (command.Length > 6 && command.Remove(6) == "color=" && text.Contains("[/color]"))
                    {
                        tag = text.IndexOf("[/color]");
                        affectedText = text.Remove(tag);
                        text = text.Substring(tag + 8);
                        int lengthBeforeAppend = rtb.Text.Length;
                        rtb.AppendText(affectedText);
                        rtb.SelectionStart = lengthBeforeAppend;
                        rtb.SelectionLength = affectedText.Length;
                        rtb.SelectionColor = Color.FromName(command.Substring(6));
                        rtb.Select(rtb.Text.Length, 0);
                        rtb.SelectionColor = Color.Black;
                    }
                }
                else
                    break;
            }
            rtb.AppendText(text);
            rtb.Select(0, 0);
        }

        #region DataGridView ContextMenu RightClick
        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridView dgv = (sender as DataGridView);
                dgv.ContextMenuStrip = cmsRightClick;
                DataGridViewCell currentCell = dgv[e.ColumnIndex, e.RowIndex];
                currentCell.DataGridView.ClearSelection();
                currentCell.DataGridView.CurrentCell = currentCell;
                currentCell.Selected = true;
                //Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                //Point p = new Point(r.X + r.Width, r.Y + r.Height);
                Point p = dgv.PointToClient(Control.MousePosition);
                dgv.ContextMenuStrip.Show(currentCell.DataGridView, p);
                dgv.ContextMenuStrip = null;
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            DataGridView dgv = (sender as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                cmsRightClick_Opening(sender, null);
                if ((e.KeyCode == Keys.F10 && !e.Control && e.Shift) || e.KeyCode == Keys.Apps)
                {
                    dgv.ContextMenuStrip = cmsRightClick;
                    Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                    Point p = new Point(r.X + r.Width, r.Y + r.Height);
                    dgv.ContextMenuStrip.Show(currentCell.DataGridView, p);
                    dgv.ContextMenuStrip = null;
                }
                else if (e.KeyCode == Keys.C && e.Control && !e.Shift)
                    cmsRightClickCopy_Click(sender, null);
            }
        }

        private void cmsRightClick_Opening(object sender, CancelEventArgs e)
        {
            // Get table in question and currentCell.
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = ((sender as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;

            // Nothing here yet.
        }

        private void cmsRightClickCopy_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                // Check if the cell is empty.
                if (!String.IsNullOrEmpty(currentCell.Value.ToString()))
                { // If not empty, add to clipboard and inform the user.
                    Clipboard.SetText(currentCell.Value.ToString());
                    toolStripStatusLabel1.Text = "Cell content copied to clipboard (\"" + currentCell.Value.ToString() + "\")";
                }
                else
                { // Inform the user the cell was empty and therefor no reason to erase the clipboard.
                    toolStripStatusLabel1.Text = "Cell is empty";
                    #if DEBUG
                    // Debug code to see if the cell is null or "".
                    if (dgv.CurrentCell.Value == null)
                        toolStripStatusLabel1.Text += " (null)";
                    else
                        toolStripStatusLabel1.Text += " (\"\")";
                    #endif
                }
            }
        }
        #endregion

        #region DataGridView
        private void dgv_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        { // Override of the DataGridView's normal SortCompare. This version converts some of the fields to numbers before sorting them.
            DataGridView dgv = (sender as DataGridView);

            const int INDEX_COLUMN = 0;
            const int NAME_COLUMN = 3;

            string columnName = e.Column.Name;
            int id1 = (int)dgv.Rows[e.RowIndex1].Cells[INDEX_COLUMN].Value;
            int id2 = (int)dgv.Rows[e.RowIndex2].Cells[INDEX_COLUMN].Value;
            if (columnName == "dgvCityColumnMorale")
            {
                int value1 = hCityList[id1].Morale;
                int value2 = hCityList[id2].Morale;
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvCityColumnMoraleModifiers")
            {
                int value1 = hCityList[id1].MoraleModifiers.Values.Sum();
                int value2 = hCityList[id2].MoraleModifiers.Values.Sum();
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvCityColumnLivingConditions")
            {
                double value1 = ((double)hCityList[id1].Jobs / hCityList[id1].Homes);
                double value2 = ((double)hCityList[id2].Jobs / hCityList[id2].Homes);
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvCityColumnPopulation")
            {
                int value1 = hCityList[id1].Population;
                int value2 = hCityList[id2].Population;
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvCityColumnBank")
            {
                long value1 = hCityList[id1].BankGovBalance;
                long value2 = hCityList[id2].BankGovBalance;
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvCityColumnTribute")
            {
                long value1 = hCityList[id1].BankTribute;
                long value2 = hCityList[id2].BankTribute;
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvCityColumnLoyalty")
            {
                double value1 = Math.Round(((double)hCityList[id1].Loyalty / hCityList[id1].Population) * 100, 2);
                double value2 = Math.Round(((double)hCityList[id2].Loyalty / hCityList[id2].Population) * 100, 2);
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvSystemColumnMorale")
            {
                int value1 = hSystemList[id1].Morale;
                int value2 = hSystemList[id2].Morale;
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvSystemColumnMoraleModifiers")
            {
                int value1 = hSystemList[id1].MoraleModifiers.Sum();
                int value2 = hSystemList[id2].MoraleModifiers.Sum();
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvSystemColumnBank")
            {
                long value1 = hSystemList[id1].Cities.Sum(x => x.BankGovBalance);
                long value2 = hSystemList[id2].Cities.Sum(x => x.BankGovBalance);
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvSystemColumnTribute")
            {
                long value1 = hSystemList[id1].Cities.Sum(x => x.BankTribute);
                long value2 = hSystemList[id2].Cities.Sum(x => x.BankTribute);
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvShipColumnAbandonment")
            {
                int value1 = hShipList[id1].Abandonment;
                int value2 = hShipList[id2].Abandonment;
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvShipColumnFuel")
            {
                double value1 = hShipList[id1].Fuel / (double)hShipList[id1].FuelCapacity;
                double value2 = hShipList[id2].Fuel / (double)hShipList[id2].FuelCapacity;
                e.SortResult = CompareNumbers(value1, value2);
            }
            else if (columnName == "dgvShipColumnAccount")
            {
                string value1 = hShipList[id1].AccountColumn;
                string value2 = hShipList[id2].AccountColumn;
                e.SortResult = CompareNumberStrings(value1, value2);
            }
            else
            {
                // Try to sort based on the cells in the current column as srtings.
                e.SortResult = String.Compare((e.CellValue1 ?? "").ToString(), (e.CellValue2 ?? "").ToString());
            }

            // If the cells are equal, sort based on the ID column.
            if (e.SortResult == 0 && (e.Column.Index != NAME_COLUMN))
                                   /* e.Column.Name != "dgvCityColumnName"
                                    * e.Column.Name != "dgvSystemColumnName"
                                    * e.Column.Name != "dgvShipColumnName"
                                    * e.Column.Name != "dgvOfficerColumnName"
                                    * e.Column.Name != "dgvEventColumnName"
                                    */
            {
                e.SortResult = String.Compare(
                    dgv.Rows[e.RowIndex1].Cells[NAME_COLUMN].Value.ToString(),
                    dgv.Rows[e.RowIndex2].Cells[NAME_COLUMN].Value.ToString());
            }
            e.Handled = true;
        }

        /// <summary>
        /// Makes sure the string has one decimal separated with ".", and then pads the start of the string with spaces (" "s).
        /// </summary>
        private string Normalize(string s, int len)
        {
            s = s.Replace(',', '.');
            if (!s.Contains('.'))
                s += ".00";
            return s.PadLeft(len + 3);
        }

        private int CompareNumberStrings(string value1, string value2)
        {
            int maxLen = Math.Max(value1.Length, value2.Length);
            value1 = Normalize(value1, maxLen);
            value2 = Normalize(value2, maxLen);
            return String.Compare(value1, value2);
        }

        private int CompareNumbers(string value1, string value2)
        {
            double value1double = Double.Parse(value1, Hazeron.NumberFormat);
            double value2double = Double.Parse(value2, Hazeron.NumberFormat);
            return Math.Sign(value1double.CompareTo(value2double));
        }

        private int CompareNumbers(double value1, double value2)
        {
            return Math.Sign(value1.CompareTo(value2));
        }

        private int CompareNumbers(int value1, int value2)
        {
            return Math.Sign(value1.CompareTo(value2));
        }
        #endregion

        #region menuStrip1
        private void menuStrip1FileScan_Click(object sender, EventArgs e)
        {
            ScanHMails();
        }

        private void menuStrip1FileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1HelpGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/Deantwo/HazeronAdviser");
        }

        private void menuStrip1HelpThread_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://hazeron.com/phpBB3/viewtopic.php?f=124&t=6867#p77419");
        }

        private void menuStrip1HelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Program:" + Environment.NewLine +
                "   HazeronAdviser" + Environment.NewLine +
                "" + Environment.NewLine +
                "Version:" + Environment.NewLine +
                "   v" + Application.ProductVersion + Environment.NewLine +
                "" + Environment.NewLine +
                "Creator:" + Environment.NewLine +
                "   Deantwo" + Environment.NewLine +
                "" + Environment.NewLine +
                "Feedback, suggestions, and bug reports should be posted in the forum thread or PMed to Deantwo please."
                , "About HazeronAdviser", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void menuStrip1HelpHowToUse_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "1.  Log into Hazeron with your character" + Environment.NewLine +
                "2.  Open the Governance window (F12)" + Environment.NewLine +
                "3.  Go to the Places tab" + Environment.NewLine +
                "4.  Select all (using CTRL or SHIFT) the cities you govern" + Environment.NewLine +
                "5.  Right-click one of them, then click \"Recent Report by Mail...\"" + Environment.NewLine +
                "6.  Open the Mail window (F2)" + Environment.NewLine +
                "7.  Click the \"Request New Messages\" button" + Environment.NewLine +
                "8.  Start HazeronAdviser (which you already have done!)" + Environment.NewLine +
                "9.  Click the \"Scan HMails\" button in HazeronAdviser"
                , "How to use HazeronAdviser", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }
        #endregion
    }
}