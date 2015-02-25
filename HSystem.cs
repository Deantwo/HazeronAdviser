#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HSystem
    {
        protected string _name = "-"; // Name of the ship, this can change at any time.
        public string Name
        {
            get { return _name; }
        }
        protected string _id = "######"; // ID of the ship, used in mail names.
        public string ID
        {
            get { return _id; }
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

        protected Dictionary<int, HCity> _cities = new Dictionary<int, HCity>();
        public Dictionary<int, HCity> Cities
        {
            get { return _cities; }
        }

        protected string _sMorale = "-", _sMoraleShort = "-";
        public string SMorale
        {
            get { return _sMorale; }
        }
        public string SMoraleShort
        {
            get { return _sMoraleShort; }
        }

        protected string _sDecayDay = "-";
        public string SDecayDay
        {
            get { return _sDecayDay; }
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

        protected string _sTechnology = "";
        public string STechnology
        {
            get { return _sTechnology; }
        }

        protected Dictionary<string, int> _vFactilitiesTL = new Dictionary<string, int>();
        public Dictionary<string, int> VFactilitiesTL
        {
            get { return _vFactilitiesTL; }
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

        public HSystem()
        {

        }

        public void AddCity(HCity city)
        {

        }

        public void UpdateSystem()
        {
            // String working vars.
            string[] tempArray;
            // Time for City spicific things.
            string race = "";
            int dDay = 0, dDayMax = 0;
            const int abandonmentInterval = 4;
            Dictionary<string, int> reseatchProjects = new Dictionary<string, int>();
            _sTechnology = "";
            _vFactilitiesTL = new Dictionary<string, int>(); // Really need to just have everything be reset when a new mail is read.
            List<string> buildingList = new List<string>();

            // MORALE & Decay
            const string headlineMORALE = "<b>MORALE</b>";
            if (sectionsInReport.Contains(headlineMORALE))
            {
                _sMorale = HHelper.CleanText(GetSectionText(mail.Body, sectionsInReport, headlineMORALE));
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
                    }
                dDay = ((_vMoraleModifiers.Sum() + 1) * abandonmentInterval) - (abandonedDays % abandonmentInterval);
                dDayMax = ((_vMoraleModifiers.Sum() - abandonedPenalty + 1) * abandonmentInterval);
                if (abandonedDays != 0)
                    _sDecayDay = dDay.ToString("00") + " /" + dDayMax.ToString("00") + " days";
                else if (!mail.Body.Contains("<span style=\"color: rgb(255, 255, 0);\">City is decaying.<br></span>"))
                    _sDecayDay = dDay.ToString("00") + "~/" + dDayMax.ToString("00") + " days";
                else
                    _sDecayDay = " Decaying";
                _vMorale = Convert.ToInt32(_sMoraleShort.Substring(_sMoraleShort.LastIndexOf(' ') + 1));
            }

            // POPULATION
            const string headlinePOPULATION = "<b>POPULATION</b>";
            if (sectionsInReport.Contains(headlinePOPULATION))
            {
                _sPopulation = HHelper.CleanText(GetSectionText(mail.Body, sectionsInReport, headlinePOPULATION));
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
                    else if (line.Contains("loyal"))
                    {
                        _vLoyalty = Convert.ToInt32(line.Remove(line.IndexOf(' ')));
                        if (line.Contains("disloyal"))
                        {
                            _vLoyalty = -_vLoyalty;
                            _sLoyalty = "-" + line.Remove(line.Length - 33); // "9 citizens (1%) remain disloyal to the occupier."
                        }
                        else
                            _sLoyalty = line.Remove(line.Length - 11);
                    }
                }
            }

            // LIVING CONDITIONS
            const string headlineLIVING = "<b>LIVING CONDITIONS</b>";
            if (sectionsInReport.Contains(headlineLIVING))
            {
                string tempSection = HHelper.CleanText(GetSectionText(mail.Body, sectionsInReport, headlineLIVING));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in tempArray)
                {
                    if (line.Contains("Jobs"))
                    {
                        _vJobs = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Homes"))
                    {
                        _vHomes = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Food"))
                    {
                        _vFood = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                }
            }

            // RESEARCH AND DEVELOPMENT
            const string headlineRESEARCH = "<b>RESEARCH AND DEVELOPMENT</b>";
            if (sectionsInReport.Contains(headlineRESEARCH))
            {
                string tempSection = HHelper.CleanText(GetSectionText(mail.Body, sectionsInReport, headlineRESEARCH));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 3; i < tempArray.Length; i += 2)
                {
                    if (tempArray[i] != "Technology")
                        reseatchProjects.Add(tempArray[i].Remove(tempArray[i].Length - 11), Convert.ToInt32(tempArray[i + 1]));
                }
            }

            //// SPACECRAFT
            //const string headlineSPACECRAFT = "<b>SPACECRAFT</b>";
            //if (sectionsInReport.Contains(headlineSPACECRAFT))
            //{
            //    string tempSection = HHelper.CleanText(GetSectionText(mail.Body, sectionsInReport, headlineSPACECRAFT));
            //    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //}

            // FACILITIES
            const string headlineFACILITIES = "<b>FACILITIES</b>";
            if (sectionsInReport.Contains(headlineFACILITIES))
            {
                _sFactilities = HHelper.CleanText(GetSectionText(mail.Body, sectionsInReport, headlineFACILITIES));
                tempArray = _sFactilities.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 4; i < tempArray.Length; i += 3)
                {
                    if (tempArray[i] != "Name")
                    {
                        int tl;
                        if (!Int32.TryParse(tempArray[i + 1], out tl))
                            tl = Convert.ToInt32(tempArray[i + 1].Split(new char[] { '-' })[1]) * -1; // Make negitive because it is not all buildings.
                        _vFactilitiesTL.Add(tempArray[i], tl);
                    }
                }
            }

            //// VEHICLES
            //const string headlineVEHICLES = "<b>VEHICLES</b>";
            //if (sectionsInReport.Contains(headlineVEHICLES))
            //{
            //    string tempSection = HHelper.CleanText(GetSectionText(mail.Body, sectionsInReport, headlineVEHICLES));
            //    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //}

            // INVENTORY
            const string headlineINVENTORY = "<b>INVENTORY</b>";
            if (sectionsInReport.Contains(headlineINVENTORY))
            {
                string tempSection = HHelper.CleanText(GetSectionText(mail.Body, sectionsInReport, headlineINVENTORY));
                if (tempSection.Contains("Air"))
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
            if (!mail.Body.Contains("Ringworld Arc"))
            {
                int sub = mail.Body.IndexOf("m dia, ");
                tempArray = mail.Body.Remove(sub).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
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
                if (minutesToLoyal < 120) // Less than two hours.
                    _sPopOverview += " [color=" + (disloyal ? "red" : "orange") + "](" + minutesToLoyal + " minutes to " + (disloyal ? "loyal" : "full") + ")[/color]";
                else if (minutesToLoyal < 2980) // Less than two days.
                    _sPopOverview += " [color=" + (disloyal ? "red" : "orange") + "](" + (minutesToLoyal / 60) + " hours to " + (disloyal ? "loyal" : "full") + ")[/color]";
                else // More than two days.
                    _sPopOverview += " [color=" + (disloyal ? "red" : "orange") + "](" + (minutesToLoyal / 1490) + " days to " + (disloyal ? "loyal" : "full") + ")[/color]";
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

            // Technology overview
            if (sectionsInReport.Contains(headlineRESEARCH))
            {
                _sTechnology = "City's technology projects:";
                foreach (string building in reseatchProjects.Keys)
                {
                    if (_vFactilitiesTL.ContainsKey(building))
                        _sTechnology += Environment.NewLine + " " + reseatchProjects[building].ToString().PadLeft(2) + " (TL" + Math.Abs(_vFactilitiesTL[building]).ToString().PadLeft(2) + ") running, " + building;
                    else
                        _sTechnology += Environment.NewLine + " [color=red]" + reseatchProjects[building].ToString().PadLeft(2) + " running, " + building + " (wasted, none in city)[/color]";
                }
            }
            if (_sTechnology != "")
                _sTechnology += Environment.NewLine + Environment.NewLine;
            _sTechnology += "City's technology levels:";
            buildingList = _vFactilitiesTL.Keys.ToList();
            buildingList.Sort();
            foreach (string building in buildingList)
            {
                _sTechnology += Environment.NewLine + " TL" + Math.Abs(_vFactilitiesTL[building]).ToString().PadLeft(2) + ", " + building;
                if (_vFactilitiesTL[building] < 0)
                    _sTechnology += " [color=red](not all buildings)[/color]";
            }

            // Overview
            _sOverview = "WIP";

            // AttentionCodes
            if ((_vJobs >= _vHomes) || (((float)(_vHomes - _vJobs) / _vHomes) > 0.2)) // More jobs than homes, or too many unemployed.
                _attentionCode = (byte)(_attentionCode | 0x01); // 0b00000001
            if (_vPopulation < _vHomes || _vPopulation > _vHomes) // Population not full, or more than full.
                _attentionCode = (byte)(_attentionCode | 0x02); // 0b00000010
            if (12 > dDay) // Less than 12 days to decay.
                _attentionCode = (byte)(_attentionCode | 0x04); // 0b00000100
            if (4 >= dDay) // Less than 4 days to decay.
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
}
#endif