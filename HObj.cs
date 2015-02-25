#define CrewMoraleTest
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HObj
    {
        protected string _name = "-"; // Name of the sender (city, ship, etc), this can change at any time.
        public string Name
        {
            get { return _name; }
        }
        protected int _id = 0; // ID of the sender (city, ship, etc), used in mail file names.
        public int ID
        {
            get { return _id; }
        }
        public string IdString
        {
            get { return HHelper.ToID(_id); }
        }

        protected string _systemName = "-"; // Name of the sender's system, may not be present.
        public string SystemName
        {
            get { return _systemName; }
        }
        protected int _systemId = 0; // ID of the sender's system, may not be present.
        public int SystemID
        {
            get { return _systemId; }
        }

        protected string _sOverview = "";
        public string SOverview
        {
            get { return _sOverview; }
        }

        protected DateTime _lastUpdated = new DateTime(2000, 1, 1);
        public DateTime LastUpdared
        {
            get { return _lastUpdated; }
        }
        public string LastUpdaredString
        {
            get
            {
                return LastUpdared.ToString("yyyy-MM-dd HH:mm"); // TimeDate format information: http://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
            }
        }

        protected byte _attentionCode = 0x00; // 0b00000000
        public byte AttentionCode
        {
            get { return _attentionCode; }
        }

        protected List<int> _owners = new List<int>();
        public List<int> Onwers
        {
            get { return _owners; }
        }

        protected HMail _mail;
        public string MailBody
        {
            get { return HHelper.CleanText(_mail.Body); }
        }

        public HObj(HMail mail)
        {
            _id = mail.SenderID;
            CompareMail(mail);
        }

        public virtual void CompareMail(HMail mail)
        {
            int tempOwner = mail.RecipientID;
            if (!_owners.Contains(tempOwner))
                _owners.Add(tempOwner);

            if (DateTime.Compare(_lastUpdated, mail.DateTime) < 0)
            {
                _name = mail.From; // Incase sender changed name.

                _systemId = mail.SystemID; // Incase ships or officers change system.
                _systemName = mail.SystemName; // Incase city's system's name is changed.

                _lastUpdated = mail.DateTime;

                _mail = mail;
            }
        }

        protected string GetSectionText(string mailBody, List<string> reportSecions, string headline)
        {
            int subStart, subEnd;
            subStart = mailBody.IndexOf(headline);
            int index = reportSecions.IndexOf(headline) + 1;
            if (reportSecions.Count != index)
                subEnd = mailBody.IndexOf(reportSecions[index]) - subStart;
            else
                subEnd = mailBody.Length - 1 - subStart;
            return mailBody.Substring(subStart, subEnd);
        }
    }

    class HCity : HObj
    {
        protected string _sMorale = "-", _sMoraleShort = "-";
        public string SMorale
        {
            get { return _sMorale; }
        }
        public string SMoraleShort
        {
            get { return _sMoraleShort; }
        }

        protected int _vAbandonment = 0, vAbandonmentMax = 0;
        public int VAbandonment
        {
            get { return _vAbandonment; }
        }
        public int VAbandonmentMax
        {
            get { return vAbandonmentMax; }
        }

        protected string _sAbandonment = "-";
        public string SAbandonment
        {
            get { return _sAbandonment; }
        }

        protected string _sPopulation = "-", _sPopulationShort = "-";
        public string SPopulation
        {
            get { return _sPopulation; }
        }
        public string SPopulationShort
        {
            get { return _sPopulationShort; }
        }

        protected string _sLoyalty = "-";
        public string SLoyalty
        {
            get { return _sLoyalty; }
        }

        protected string _sLivingConditions = "-", _sLivingConditionsShort = "-";
        public string SLiving
        {
            get { return _sLivingConditions; }
        }
        public string SLivingShort
        {
            get { return _sLivingConditionsShort; }
        }

        protected string _sPopOverview = "-";
        public string SPopOverview
        {
            get { return _sPopOverview; }
        }

        protected string _sFactilities = "-";
        public string SFactilities
        {
            get { return _sFactilities; }
        }

        protected string _sBuildings = "";
        public string SBuildings
        {
            get { return _sBuildings; }
        }

        protected Dictionary<string, int> _lFactilitiesLV = new Dictionary<string, int>();
        public Dictionary<string, int> LFactilitiesLV
        {
            get { return _lFactilitiesLV; }
        }

        protected string _sTechnology = "";
        public string STechnology
        {
            get { return _sTechnology; }
        }

        protected Dictionary<string, int> _lReseatchProjects = new Dictionary<string, int>();
        public Dictionary<string, int> LReseatchProjects
        {
            get { return _lReseatchProjects; }
        }

        protected Dictionary<string, int> _lFactilitiesTL = new Dictionary<string, int>();
        public Dictionary<string, int> LFactilitiesTL
        {
            get { return _lFactilitiesTL; }
        }

        protected int _vMorale = 0;
        public int VMorale
        {
            get { return _vMorale; }
        }

        protected List<int> _vMoraleModifiers = new List<int>();
        public int[] VMoraleModifiers
        {
            get { return _vMoraleModifiers.ToArray(); }
        }

        protected int _vPopulation = 0;
        public int VPopulation
        {
            get { return _vPopulation; }
        }

        protected int _vLoyalty = 0;
        public int VLoyalty
        {
            get { return _vLoyalty; }
        }

        protected int _vHomes = 0;
        public int VHomes
        {
            get { return _vHomes; }
        }

        protected int _vApartments = 0;
        public int VApartments
        {
            get { return _vApartments; }
        }

        protected int _vJobs = 0;
        public int VJobs
        {
            get { return _vJobs; }
        }

        protected int _vPopulationLimit = 0;
        public int VPopulationLimit
        {
            get { return _vPopulationLimit; }
        }

        protected int _vFood = 0;
        public int VFood
        {
            get { return _vFood; }
        }

        protected int _vAir = 0;
        public int VAir
        {
            get { return _vAir; }
        }

        protected bool _vHashEnv = false;
        public bool VHashEnv
        {
            get { return _vHashEnv; }
        }

        public HCity(HMail mail)
            : base(mail)
        {
        }

        public void Initialize()
        {
            // String working vars.
            string[] tempArray;
            List<string> sectionsInReport = new List<string>();
            // This is the order of the sections in the mail body, keep them in same order!
            string[] sections = new string[] {"MORALE"
                                                , "POPULATION"
                                                , "LIVING CONDITIONS"
                                                , "POWER RESERVE"
                                                , "BANK ACTIVITY"
                                                , "RESEARCH AND DEVELOPMENT"
                                                , "SPACECRAFT MANUFACTURING POTENTIAL"
                                                , "SPACECRAFT"
                                                , "FACILITIES"
                                                , "VEHICLES"
                                                , "INVENTORY"
                                                };
            Dictionary<string, int> moraleBuildingsPop = new Dictionary<string, int>();
            moraleBuildingsPop.Add("Church", 45);
            moraleBuildingsPop.Add("Cantina", 50);
            moraleBuildingsPop.Add("Retail Store", 55);
            moraleBuildingsPop.Add("Police Station", 60);
            moraleBuildingsPop.Add("University", 70);
            moraleBuildingsPop.Add("Hospital", 80);
            moraleBuildingsPop.Add("Park", 90);
            moraleBuildingsPop.Add("Grocery", 100);
            moraleBuildingsPop.Add("Zoo", 150);
            moraleBuildingsPop.Add("Arena", 175);
            moraleBuildingsPop.Add("Casino", 200);
            // Time for City spicific things.
            string race = "";
            const int abandonmentInterval = 4;
            int powerConsumption = 0, powerReserve = 0, powerReserveCapacity = 0;
            _sTechnology = "";
            _lFactilitiesTL = new Dictionary<string, int>(); // Really need to just have everything be reset when a new mail is read.
            _lFactilitiesLV = new Dictionary<string, int>();
            _lReseatchProjects = new Dictionary<string, int>();
            List<string> buildingList;

            //INFO
            //if (_mail.MessageType == 0x06 && _mail.Body.Contains("<b>EVENT LOG</b>")) // MSG_CityStatusReportInfo
            //{
            //    subStart = _mail.Body.IndexOf("<b>EVENT LOG</b>");
            //    subEnd = _mail.Body.IndexOf("<b>MORALE</b>") - subStart;
            //    _info = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
            //}

            //DISTRESS
            //if (_mail.MessageType == 0x04 && _mail.Body.Contains("<b style=\"color: rgb(255, 255, 0);\">DISTRESS</b>") // MSG_CityDistressReport
            //{
            //    subStart = _mail.Body.IndexOf("<b style=\"color: rgb(255, 255, 0);\">DISTRESS</b>");
            //    if (_mail.Body.Contains("<b>DECAY</b>"))
            //        subEnd = _mail.Body.IndexOf("<b>DECAY</b>") - subStart;
            //    else
            //        subEnd = _mail.Body.IndexOf("<b>MORALE</b>") - subStart;
            //    _distress = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
            //}

            // Check for sections.
            foreach (string section in sections)
                if (_mail.Body.Contains("<b>" + section + "</b>"))
                    sectionsInReport.Add("<b>" + section + "</b>");

            // MORALE & Abandonment
            const string headlineMORALE = "<b>MORALE</b>";
            if (sectionsInReport.Contains(headlineMORALE))
            {
                _sMorale = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineMORALE));
                tempArray = _sMorale.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _sMoraleShort = tempArray[tempArray.Length - 1].Remove(tempArray[tempArray.Length - 1].Length - 1).Substring(7);
                int abandonedDays = 0;
                int abandonedPenalty = 0;
                _vMoraleModifiers.Clear();
                foreach (string line in tempArray)
                    if (!line.ToLower().Contains("morale"))
                    {
                        _vMoraleModifiers.Add(Convert.ToInt32(line.Remove(line.IndexOf(' '))));
                        string[] tempLineArray = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        if (line.Contains("Abandonment Penalty"))
                        {
                            abandonedPenalty = Convert.ToInt32(tempLineArray[0]);
                            abandonedDays = Convert.ToInt32(tempLineArray[tempLineArray.Length - 2]);
                        }
                        if (line.Contains("Harsh Environment Penalty"))
                        {
                            _vHashEnv = true;
                        }
                    }
                _vAbandonment = ((_vMoraleModifiers.Sum() + 1) * abandonmentInterval) - (abandonedDays % abandonmentInterval);
                vAbandonmentMax = ((_vMoraleModifiers.Sum() - abandonedPenalty + 1) * abandonmentInterval);
                if (_vAbandonment == vAbandonmentMax)
                    _sAbandonment = _vAbandonment.ToString("00") + "~/" + vAbandonmentMax.ToString("00") + " days";
                else if (_vAbandonment > 0)
                    _sAbandonment = _vAbandonment.ToString("00") + " /" + vAbandonmentMax.ToString("00") + " days";
                else
                    _sAbandonment = " Decaying";
                _vMorale = Convert.ToInt32(_sMoraleShort.Substring(_sMoraleShort.LastIndexOf(' ') + 1));
            }

            // POPULATION
            const string headlinePOPULATION = "<b>POPULATION</b>";
            if (sectionsInReport.Contains(headlinePOPULATION))
            {
                _sPopulation = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlinePOPULATION));
                tempArray = _sPopulation.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in tempArray)
                {
                    if (line.Contains("Citizens are"))
                    {
                        race = line.Remove(line.Length - 1).Substring(13);
                    }
                    else if (line.Contains("Population") && !line.Contains("troops"))
                    {
                        _sPopulationShort = line.Remove(line.Length - 1).Substring(11);
                        _vPopulation = Convert.ToInt32(_sPopulationShort.Substring(_sPopulationShort.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Garrison"))
                    {
                        // Nothing yet
                    }
                    else if (line.Contains("arsh environment"))
                    {
                        _vHashEnv = true;
                    }
                    else if (line.Contains("loyal"))
                    {
                        _vLoyalty = Convert.ToInt32(line.Remove(line.IndexOf(' ')));
                        if (line.Contains("disloyal"))
                            _vLoyalty = -_vLoyalty;
                        _sLoyalty = _vLoyalty + " citizens (" + Math.Round(((float)_vLoyalty / _vPopulation) * 100, 2) + "%)";
                    }
                }
            }

            // LIVING CONDITIONS
            const string headlineLIVING = "<b>LIVING CONDITIONS</b>";
            if (sectionsInReport.Contains(headlineLIVING))
            {
                _sLivingConditions = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineLIVING));
                tempArray = _sLivingConditions.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in tempArray)
                {
                    if (line.Contains("Jobs"))
                    {
                        _sLivingConditionsShort = line;
                        _vJobs = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Homes"))
                    {
                        _sLivingConditionsShort += ", " + line;
                        _vHomes = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Apartments"))
                    {
                        _vApartments = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Food"))
                    {
                        _vFood = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                }
            }

            // POWER RESERVE
            const string headlinePOWER = "<b>POWER RESERVE</b>";
            if (sectionsInReport.Contains(headlinePOWER))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlinePOWER));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in tempArray)
                {
                    if (line.Contains("Consumed"))
                    {
                        powerConsumption = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Reserve Power"))
                    {
                        powerReserve = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Reserve Capacity"))
                    {
                        powerReserveCapacity = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                }
            }

            //// BANK ACTIVITY
            //const string headlineBANK = "<b>BANK</b>";
            //if (sectionsInReport.Contains(headlineBANK))
            //{
            //    string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineBANK));
            //    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //}

            // RESEARCH AND DEVELOPMENT
            const string headlineRESEARCH = "<b>RESEARCH AND DEVELOPMENT</b>";
            if (sectionsInReport.Contains(headlineRESEARCH))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineRESEARCH));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 3; i < tempArray.Length; i += 2)
                {
                    if (tempArray[i] != "Technology")
                        _lReseatchProjects.Add(tempArray[i].Remove(tempArray[i].Length - 11), Convert.ToInt32(tempArray[i + 1]));
                }
            }

            //// SPACECRAFT
            //const string headlineSPACECRAFT = "<b>SPACECRAFT</b>";
            //if (sectionsInReport.Contains(headlineSPACECRAFT))
            //{
            //    string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineSPACECRAFT));
            //    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //}

            // FACILITIES
            const string headlineFACILITIES = "<b>FACILITIES</b>";
            if (sectionsInReport.Contains(headlineFACILITIES))
            {
                _sFactilities = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineFACILITIES));
                tempArray = _sFactilities.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 4; i < tempArray.Length; i += 3)
                {
                    if (tempArray[i] != "Name")
                    {
                        int tl;
                        if (!Int32.TryParse(tempArray[i + 1], out tl))
                            tl = Convert.ToInt32(tempArray[i + 1].Split(new char[] { '-' })[1]) * -1; // Make negitive because it is not all buildings.
                        _lFactilitiesTL.Add(tempArray[i], tl);
                        _lFactilitiesLV.Add(tempArray[i], Convert.ToInt32(tempArray[i + 2]));
                    }
                }
            }

            //// VEHICLES
            //const string headlineVEHICLES = "<b>VEHICLES</b>";
            //if (sectionsInReport.Contains(headlineVEHICLES))
            //{
            //    string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineVEHICLES));
            //    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //}

            // INVENTORY
            const string headlineINVENTORY = "<b>INVENTORY</b>";
            if (sectionsInReport.Contains(headlineINVENTORY))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineINVENTORY));
                if (_vHashEnv && tempSection.Contains("Air"))
                {
                    tempSection = tempSection.Substring(tempSection.IndexOf("Air"), 255);
                    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 1; i < tempArray.Length; i++)
                    {
                        if (tempArray[i].Contains(" Q"))
                            _vAir += Convert.ToInt32(tempArray[i].Remove(tempArray[i].IndexOf(' ')));
                        else
                            break;
                    }
                }
            }

            // Planet Size
            if (!_mail.Body.Contains("Ringworld Arc"))
            {
                int sub = _mail.Body.IndexOf("m dia, ");
                tempArray = _mail.Body.Remove(sub).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                _vPopulationLimit = Convert.ToInt32(tempArray[tempArray.Length - 1].Replace(",", ""));
                _vPopulationLimit = Convert.ToInt32(100 * Math.Floor((float)_vPopulationLimit / 1800));
            }
            else
                _vPopulationLimit = 1000;

            // Population overwiew
            _sPopOverview = "City's population:";
            _sPopOverview += Environment.NewLine + " " + _vLoyalty.ToString().PadLeft(4) + ", Loyal citizens";
            if (_vLoyalty != _vPopulation)
            {
                int minutesToLoyal;
                bool disloyal = _vLoyalty < 0;
                if (!disloyal)
                    minutesToLoyal = ((_vPopulation - _vLoyalty) * 13);
                else
                    minutesToLoyal = (Math.Abs(_vLoyalty) * 13);
                _sPopOverview += " [color=" + (disloyal ? "red" : "orange") + "](";
                if (minutesToLoyal < 120) // Less than two hours.
                    _sPopOverview += minutesToLoyal + " minutes";
                else if (minutesToLoyal < 2980) // Less than two days.
                    _sPopOverview += (minutesToLoyal / 60) + " hours";
                else // More than two days.
                    _sPopOverview += (minutesToLoyal / 1490) + " days";
                _sPopOverview += " to " + (disloyal ? "loyal" : "full") + ")[/color]";
            }
            _sPopOverview += Environment.NewLine + " " + _vPopulation.ToString().PadLeft(4) + ", Citizens";
            _sPopOverview += Environment.NewLine + " " + _vHomes.ToString().PadLeft(4) + ", Homes";
            _sPopOverview += Environment.NewLine + " " + _vJobs.ToString().PadLeft(4) + ", Jobs";
            _sPopOverview += Environment.NewLine + " " + _vPopulationLimit.ToString().PadLeft(4) + ", Population limit";
            _sPopOverview += Environment.NewLine + Environment.NewLine + "City's living conditions:";
            _sPopOverview += Environment.NewLine + " Citizens are " + race;
            _sPopOverview += Environment.NewLine + " " + powerConsumption + " power comsumption, ";
            _sPopOverview += Environment.NewLine + " " + powerReserve.ToString().PadLeft(powerConsumption.ToString().Length) + "/" + powerReserveCapacity + " power capacity (" + Math.Floor(((float)powerReserve / powerReserveCapacity) * 100) + "%)";
            {
                _sPopOverview += Environment.NewLine + " ";
                int minutesToStarvation = (_vFood);
                if (minutesToStarvation < 120) // Less than two hours.
                    _sPopOverview += minutesToStarvation + " minutes";
                else if (minutesToStarvation < 2980) // Less than two days.
                    _sPopOverview += (minutesToStarvation / 60) + " hours";
                else // More than two days.
                    _sPopOverview += (minutesToStarvation / 1490) + " days";
                _sPopOverview += " worth of food";
            }
            if (_vHashEnv)
            {
                _sPopOverview += Environment.NewLine + " ";
                int minutesToSuffocation = (_vAir);
                if (minutesToSuffocation < 120) // Less than two hours.
                    _sPopOverview += minutesToSuffocation + " minutes";
                else if (minutesToSuffocation < 2980) // Less than two days.
                    _sPopOverview += (minutesToSuffocation / 60) + " hours";
                else // More than two days.
                    _sPopOverview += (minutesToSuffocation / 1490) + " days";
                _sPopOverview += " worth of air";
            }
            _sPopOverview += Environment.NewLine + " " + Math.Floor(((float)_vApartments / _vHomes) * 100) + "% apartments, " + (((_vHomes / 2) - _vApartments) / 4) + " more levels possible";

            // Technology overview
            if (sectionsInReport.Contains(headlineRESEARCH))
            {
                _sTechnology = "City's technology projects:";
                foreach (string building in _lReseatchProjects.Keys)
                {
                    if (_lFactilitiesTL.ContainsKey(building))
                        _sTechnology += Environment.NewLine + " " + _lReseatchProjects[building].ToString().PadLeft(2) + " (TL" + Math.Abs(_lFactilitiesTL[building]).ToString().PadLeft(2) + ") running, " + building;
                    else
                        _sTechnology += Environment.NewLine + " [color=red]" + _lReseatchProjects[building].ToString().PadLeft(2) + " running, " + building + " (wasted, none in city)[/color]";
                }
            }
            if (_sTechnology != "")
                _sTechnology += Environment.NewLine + Environment.NewLine;
            _sTechnology += "City's technology levels:";
            buildingList = _lFactilitiesTL.Keys.ToList();
            buildingList.Sort();
            foreach (string building in buildingList)
            {
                _sTechnology += Environment.NewLine + " TL" + Math.Abs(_lFactilitiesTL[building]).ToString().PadLeft(2) + ", " + building;
                if (_lFactilitiesTL[building] < 0)
                    _sTechnology += " [color=red](not all buildings)[/color]";
            }

            // Buildings overview
            _sBuildings = "City's buildings:";
            buildingList = _lFactilitiesLV.Keys.ToList();
            foreach (string moraleBuilding in moraleBuildingsPop.Keys)
            {
                if (!_lFactilitiesLV.ContainsKey(moraleBuilding) && _vHomes > moraleBuildingsPop[moraleBuilding])
                    buildingList.Add(moraleBuilding);
            }
            buildingList.Sort();
            foreach (string building in buildingList)
            {
                int levels = 0;
                if (_lFactilitiesLV.ContainsKey(building))
                    levels = _lFactilitiesLV[building];
                _sBuildings += Environment.NewLine + " " + levels.ToString().PadLeft(3) + " levels, " + building;
                if (moraleBuildingsPop.ContainsKey(building))
                {
                    int levelsNeeded = _vHomes / moraleBuildingsPop[building];
                    if (building == "Cantina" || building == "Church")
                        levelsNeeded += 1;
                    if (levels < levelsNeeded)
                        _sBuildings += " [color=red](" + (levelsNeeded - levels) + " levels more needed)[/color]";
                    if (levels > levelsNeeded && !(building == "Church" || building == "University"))
                        _sBuildings += " [color=orange](" + (levels - levelsNeeded) + " levels too many)[/color]";
                }
            }

            // Overview
            _sOverview = "WIP";

            // AttentionCodes
            if ((_vJobs >= _vHomes) || (((float)(_vHomes - _vJobs) / _vHomes) > 0.2)) // More jobs than homes, or too many unemployed.
                _attentionCode = (byte)(_attentionCode | 0x01); // 0b00000001
            if (_vPopulation < _vHomes || _vPopulation > _vHomes) // Population not full, or more than full.
                _attentionCode = (byte)(_attentionCode | 0x02); // 0b00000010
            if (12 > _vAbandonment) // Less than 12 days to decay.
                _attentionCode = (byte)(_attentionCode | 0x04); // 0b00000100
            if (4 >= _vAbandonment) // Less than 4 days to decay.
                _attentionCode = (byte)(_attentionCode | 0x08); // 0b00001000
            if (_vPopulation == 0 || _vPopulation > _vPopulationLimit) // Population is 0, or zone over populated!
                _attentionCode = (byte)(_attentionCode | 0x10); // 0b00010000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x20); // 0b00100000
            if (_vMorale < 20) // Morale not full.
                _attentionCode = (byte)(_attentionCode | 0x40); // 0b01000000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x80); // 0b10000000
        }
    }

    class HShip : HObj
    {
        protected string _decayDay = "-";
        public string DecayDay
        {
            get { return _decayDay; }
        }

        protected string _damage = "-", _damageShort = "-";
        public string Damage
        {
            get { return _damage; }
        }
        public string DamageShort
        {
            get { return _damageShort; }
        }

        protected string _account = "-", _accountShort = "-";
        public string Account
        {
            get { return _account; }
        }
        public string AccountShort
        {
            get { return _accountShort; }
        }

        protected string _fuel = "-", _fuelShort = "-";
        public string Fuel
        {
            get { return _fuel; }
        }
        public string FuelShort
        {
            get { return _fuelShort; }
        }

        protected string _cargo = "-", _cargoShort = "-";
        public string Cargo
        {
            get { return _cargo; }
        }
        public string CargoShort
        {
            get { return _cargoShort; }
        }

        protected string _mission = "-", _missionShort = "-";
        public string Mission
        {
            get { return _mission; }
        }
        public string MissionShort
        {
            get { return _missionShort; }
        }

        protected string _roster = "-", _rosterShort = "-";
        public string Roster
        {
            get { return _roster; }
        }
        public string RosterShort
        {
            get { return _rosterShort; }
        }

        protected string _officerName = "-";
        public string OfficerName
        {
            get { return _officerName; }
        }
        protected string _officerHome = "-";
        public string OfficerHome
        {
            get { return _officerHome; }
        }

        public HShip(HMail mail)
            : base(mail)
        {
        }

        public void Initialize()
        {
            // String working vars.
            int subStart, subEnd;
            string[] tempArray;
            List<string> sectionsInReport = new List<string>();
            // This is the order of the sections in the mail body, keep them in same order!
            string[] sections = new string[] {"DAMAGE REPORT"
                                                , "ACCOUNT"
                                                , "FUEL"
                                                , "CARGO"
                                                , "MISSION"
                                                , "ROSTER"
                                                };

            // Check for sections.
            foreach (string section in sections)
                if (_mail.Body.Contains("<b>" + section + "</b>"))
                    sectionsInReport.Add("<b>" + section + "</b>");

            // Decay
            subStart = _mail.Body.IndexOf("Commander,") + 10; // "I was deployed from ".Length == 20
            subEnd = _mail.Body.Substring(subStart).IndexOf("I was deployed from ");
            string crewMorale = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
            int dDay = 0;
            switch (crewMorale)
            {
                case "The crew has high spirits. Every day seems filled with anticipation.":
                    dDay = 4;
                    break;
                case "More than a week has passed since we were last hailed by command. The crew is quiet, intent on their work as they attend to their duties.":
                    dDay = 3;
                    break;
                case "?":
                    dDay = 2;
                    break;
                case "??":
                    dDay = 1;
                    break;
            }
#if CrewMoraleTest
            if (dDay > 2)
                _decayDay = dDay + " /4 weeks";
            else
            {
                // Debug code. Need to learn the other messages to check for!
                tempArray = _mail.FilePath.Split(new char[] { '\\' });
                _decayDay = tempArray[tempArray.Length - 1];
            }
#else
                _decayDay = dDay + " /4 weeks";
#endif

            // DAMAGE REPORT
            const string headlineDAMAGE = "<b>DAMAGE REPORT</b>";
            if (sectionsInReport.Contains(headlineDAMAGE))
            {
                _damage = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineDAMAGE));
                //temp = _damage.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_damageShort = temp[temp.Length - 1];
            }

            // ACCOUNT
            const string headlineACCOUNT = "<b>ACCOUNT</b>";
            if (sectionsInReport.Contains(headlineACCOUNT))
            {
                _account = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineACCOUNT));
                //temp = _account.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_accountShort = temp[temp.Length - 1];
            }

            // FUEL
            const string headlineFUEL = "<b>FUEL</b>";
            if (sectionsInReport.Contains(headlineFUEL))
            {
                _fuel = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineFUEL));
                tempArray = _fuel.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _fuelShort = tempArray[1];
            }

            // CARGO
            const string headlineCARGO = "<b>CARGO</b>";
            if (sectionsInReport.Contains(headlineCARGO))
            {
                _cargo = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineCARGO));
                //temp = _cargo.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_cargoShort = temp[temp.Length - 1];
            }

            // MISSION
            const string headlineMISSION = "<b>MISSION</b>";
            if (sectionsInReport.Contains(headlineMISSION))
            {
                _mission = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineMISSION));
                //temp = _mission.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_missionShort = temp[temp.Length - 1];
            }

            // ROSTER
            const string headlineROSTER = "<b>ROSTER</b>";
            if (sectionsInReport.Contains(headlineROSTER))
            {
                _roster = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineROSTER));
                //temp = _roster.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_rosterShort = temp[temp.Length - 1];
            }

            // Officer Info
            //// Name
            subStart = _mail.Body.IndexOf("<p>") + 3; // "<p>".Length == 3
            subEnd = _mail.Body.Substring(subStart).IndexOf("<div style");
            _officerName = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
            //// Home
            subStart = _mail.Body.IndexOf("I was deployed from ") + 20; // "I was deployed from ".Length == 20
            subEnd = _mail.Body.Substring(subStart).IndexOf(" in ");
            _officerHome = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));

            // Overview
            _sOverview = "WIP";

            // AttentionCodes
            if (dDay == 2) // 2 weeks until decay.
                _attentionCode = (byte)(_attentionCode | 0x08); // 0b00000001
            if (dDay == 1) // 1 weeks until decay.
                _attentionCode = (byte)(_attentionCode | 0x03); // 0b00000010
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x04); // 0b00000100
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x08); // 0b00001000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x10); // 0b00010000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x20); // 0b00100000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x40); // 0b01000000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x80); // 0b10000000
        }
    }

    class HOfficer : HObj
    {
        protected string _home = "-";
        public string Home
        {
            get { return _home; }
        }

        protected string _location = "-";
        public string Location
        {
            get { return _location; }
        }

        public HOfficer(HMail mail)
            : base(mail)
        {
            _id = mail.SenderID;
            CompareMail(mail);
        }

        public void Initialize()
        {
            // String working vars.
            int subStart, subEnd;
            string[] tempArray;

            if (_mail.MessageType == 0x0C) // MSG_OfficerReady
            {
                subStart = _mail.Body.IndexOf("Assignment Request on ") + 22; // "Assignment Request on ".Length == 22
                subEnd = _mail.Body.IndexOf("<br><br>Commander,") - subStart;
                _home = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
                _location = _home;
            }
            else if (_mail.MessageType == 0x14) // MSG_OfficerContact
            {
                subStart = _mail.Body.IndexOf("I was deployed from ") + 20; // "I was deployed from ".Length == 20
                subEnd = _mail.Body.Substring(subStart).IndexOf(" in ");
                _home = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
                _location = "\"ship name\"";
            }

            // Overview
            _sOverview = "WIP";

            // AttentionCodes
            if (_mail.MessageType == 0x14) // MSG_OfficerContact
                _attentionCode = (byte)(_attentionCode | 0x01); // 0b00000001
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x03); // 0b00000010
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x04); // 0b00000100
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x08); // 0b00001000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x10); // 0b00010000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x20); // 0b00100000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x40); // 0b01000000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x80); // 0b10000000
        }
    }

    class HEvent : HObj
    {
        protected int _messageId = 0;
        public int MessageID
        {
            get { return _messageId; }
        }

        protected string _subject = "-";
        public string Subject
        {
            get { return _subject; }
        }

        protected int _messageType = 0;
        public int MessageType
        {
            get { return _messageType; }
        }

        public HEvent(HMail mail)
            : base(mail)
        {
        }

        public void Initialize()
        {
            // String working vars.
            int subStart, subEnd;
            string[] tempArray;

            _messageId = _mail.MessageID;
            _subject = _mail.Subject;
            _messageType = _mail.MessageType;
            //if (_messageType == 0x03) // MSG_CityOccupationReport
            //{
            //    ?
            //}
            //if (_messageType == 0x05) // MSG_CityIntelligenceReport
            //{
            //    ?
            //}
            //else if (_messageType == 0x12) // MSG_ShipLogFinal
            //{
            //    ?
            //}
            //else if (_messageType == 0x13) // MSG_Government
            //{
            //    ?
            //}
            //else if (_messageType == 0x16) // MSG_OfficerDeath
            //{
            //    ?
            //}
            //else if (_messageType == 0x17) // MSG_CityFinalDecayReport
            //{
            //    ?
            //}
            //else if (_messageType == 0x18) // MSG_DiplomaticMessage
            //{
            //    ?
            //}

            // AttentionCodes
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x01); // 0b00000001
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x03); // 0b00000010
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x04); // 0b00000100
            if (_messageType == 0x05) // MSG_CityIntelligenceReport
                _attentionCode = (byte)(_attentionCode | 0x08); // 0b00001000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x10); // 0b00010000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x20); // 0b00100000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x40); // 0b01000000
            if (_messageType == 0x03 || _messageType == 0x12 || _messageType == 0x16 || _messageType == 0x17) // MSG_CityOccupationReport, MSG_ShipLogFinal, MSG_OfficerDeath or MSG_CityFinalDecayReport
                _attentionCode = (byte)(_attentionCode | 0x80); // 0b10000000
        }
    }
}
