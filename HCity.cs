using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HCity : HObj
    {
        protected int _vZone = 0;
        public int VZone
        {
            get { return _vZone; }
        }

        protected bool _empireCapital = false;
        public bool EmpreCapital
        {
            get { return _empireCapital; }
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

        protected bool _HashEnv = false;
        public bool HashEnv
        {
            get { return _HashEnv; }
        }

        protected int _vBankCitBalance = 0;
        public int VBankCitBalance
        {
            get { return _vBankCitBalance; }
        }

        protected int _vBankCitBalanceOld = 0;
        public int VBankCitOldBalanceOld
        {
            get { return _vBankCitBalanceOld; }
        }

        protected int _vBankProduction = 0;
        public int VBankProduction
        {
            get { return _vBankProduction; }
        }

        protected int _vBankGovBalance = 0;
        public int VBankGovBalance
        {
            get { return _vBankGovBalance; }
        }

        protected int _vBankGovBalanceOld = 0;
        public int VBankGovBalanceOld
        {
            get { return _vBankGovBalanceOld; }
        }

        protected int _vBankTaxIncome = 0;
        public int VBankTaxIncome
        {
            get { return _vBankTaxIncome; }
        }

        protected int _vBankTaxSale = 0;
        public int VBankTaxSale
        {
            get { return _vBankTaxSale; }
        }

        protected int _vBankExpenseResearch = 0;
        public int VBankExpenseResearch
        {
            get { return _vBankExpenseResearch; }
        }

        protected int _vBankExpenseResearchEst = 0;
        public int VBankExpenseResearchEst
        {
            get { return _vBankExpenseResearchEst; }
        }

        protected int _vBankTribute = 0;
        public int VBankTribute
        {
            get { return _vBankTribute; }
        }

        protected string _sBank = "-", _sBankShort = "-";
        public string SBank
        {
            get { return _sBank; }
        }
        public string SBankShort
        {
            get { return _sBankShort; }
        }

        public HCity(HMail mail)
            : base(mail)
        {
        }

        public void Initialize()
        {
            if (_mail.Body.Remove(4) == "UTC:")
            {
                string utcHexTimestamp = _mail.Body.Substring(4, 8);
                int secondsAfterEpoch = Int32.Parse(utcHexTimestamp, System.Globalization.NumberStyles.HexNumber);
                DateTime epoch = new DateTime(1970, 1, 1);
                epoch = TimeZoneInfo.ConvertTimeFromUtc(epoch, TimeZoneInfo.Local);
                _lastUpdated = epoch.AddSeconds(secondsAfterEpoch);
            }

            // String working vars.
            string[] tempArray;
            List<string> sectionsInReport = new List<string>();
            // This is the order of the sections in the mail body, keep them in same order!
            string[] sections = new string[] { "EVENT LOG"
                                             , "MORALE"
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
            const int abandonmentInterval = 7;
            int powerConsumption = 0, powerReserve = 0, powerReserveCapacity = 0;
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

            // City Resource Zone & Capital check
            {
                string tempSection = HHelper.CleanText(_mail.Body.Remove(_mail.Body.IndexOf(sectionsInReport[0])));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in tempArray)
                {
                    if (line.Contains("Resource Zone"))
                        _vZone = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    else if (line == "Empire Capital City")
                        _empireCapital = true;
                }
            }

            //// EVENT LOG
            //const string headlineEVENT = "<b>EVENT LOG</b>";
            //if (sectionsInReport.Contains(headlineEVENT))
            //{
            //    string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineEVENT));
            //    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //}

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
                            _HashEnv = true;
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
                        _HashEnv = true;
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

            // BANK ACTIVITY
            const string headlineBANK = "<b>BANK ACTIVITY</b>";
            if (sectionsInReport.Contains(headlineBANK))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineBANK));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                bool GovAcc = true;
                for (int i = 1; i < tempArray.Length; i++)
                {
                    string line = tempArray[i];
                    if (line == "Citizen Accounts")
                    {
                        GovAcc = false;
                    }
                    else if (!_empireCapital && line == "Previous Tribute")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _vBankTribute = Convert.ToInt32(line.Remove(line.Length - 1));
                    }
                    else if (line == "Starting Balance")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        if (GovAcc)
                            _vBankGovBalanceOld = Convert.ToInt32(line.Remove(line.Length - 1));
                        else
                            _vBankCitBalanceOld = Convert.ToInt32(line.Remove(line.Length - 1));
                    }
                    else if (line == "Current Balance")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        if (GovAcc)
                            _vBankGovBalance = Convert.ToInt32(line.Remove(line.Length - 1));
                        else
                            _vBankCitBalance = Convert.ToInt32(line.Remove(line.Length - 1));
                    }
                    else if (line == "Income Tax")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _vBankTaxIncome = Convert.ToInt32(line.Remove(line.Length - 1));
                    }
                    else if (line == "Sales Tax")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _vBankTaxSale = Convert.ToInt32(line.Remove(line.Length - 1));
                    }
                    else if (line == "Bullion Production")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _vBankProduction = Convert.ToInt32(line.Remove(line.Length - 1));
                    }
                    else if (line == "Research and Development")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _vBankExpenseResearch = Convert.ToInt32(line.Remove(line.Length - 1));
                    }
                }
            }

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
                foreach (int projectProcess in _lReseatchProjects.Values)
                {
                    _vBankExpenseResearchEst += projectProcess;
                }
                _vBankExpenseResearchEst *= 1802;
            }

            //// SPACECRAFT MANUFACTURING POTENTIAL
            //const string headlinePOTENTIAL = "<b>SPACECRAFT MANUFACTURING POTENTIAL</b>";
            //if (sectionsInReport.Contains(headlinePOTENTIAL))
            //{
            //    string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlinePOTENTIAL));
            //    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //}

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
                if (_HashEnv && tempSection.Contains("Air"))
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
            const int populationPadding = 4;
            _sPopOverview = "City's population:";
            _sPopOverview += Environment.NewLine + " " + _vLoyalty.ToString().PadLeft(populationPadding) + ", Loyal citizens";
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
                _sPopOverview += " to " + (disloyal ? "loyal" : "fully") + ")[/color]";
            }
            _sPopOverview += Environment.NewLine + " " + _vPopulation.ToString().PadLeft(populationPadding) + ", Citizens";
            _sPopOverview += Environment.NewLine + " " + _vHomes.ToString().PadLeft(populationPadding) + ", Homes";
            if (_vJobs >= _vHomes)
            {
                int needed = (_vJobs - _vHomes + 1); // Need at least one more home than jobs.
                _sPopOverview += " [color=red](Overworked, " + needed + " more homes needed)[/color]";
            }
            _sPopOverview += Environment.NewLine + " " + _vJobs.ToString().PadLeft(populationPadding) + ", Jobs";
            if (((float)(_vHomes - _vJobs) / _vHomes) > 0.2)
            {
                int needed = (int)((_vHomes * 0.8) - _vJobs + 1); // Need at least one more job than 80% homes.
                _sPopOverview += " [color=red](Unemployment, " + needed + " more jobs needed)[/color]";
            }
            _sPopOverview += Environment.NewLine + " " + _vPopulationLimit.ToString().PadLeft(populationPadding) + ", Population limit";
            if (_vHomes > _vPopulationLimit)
            {
                int needed = (_vHomes - _vPopulationLimit);
                _sPopOverview += " [color=red](Overpopulated, " + needed + " homes too many)[/color]";
            }
            _sPopOverview += Environment.NewLine;
            _sPopOverview += Environment.NewLine + "City's living conditions:";
            _sPopOverview += Environment.NewLine + " Citizens are " + race;
            {
                string powerUse = powerConsumption.ToString("N", Hazeron.NumberFormat);
                string powerSto = powerReserve.ToString("N", Hazeron.NumberFormat);
                int powerPadding = Math.Max(powerUse.Length, powerSto.Length);
                _sPopOverview += Environment.NewLine + " " + powerUse.PadLeft(powerPadding) + " power comsumption";
                _sPopOverview += Environment.NewLine + " " + powerSto.PadLeft(powerPadding) + "/" + powerReserveCapacity.ToString("N", Hazeron.NumberFormat) + " power capacity (" + Math.Floor(((float)powerReserve / powerReserveCapacity) * 100) + "%)";
            }
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
            if (_HashEnv)
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
            {
                _sPopOverview += Environment.NewLine + " " + Math.Floor(((float)_vApartments / _vHomes) * 100) + "% apartments";
                int levelAjustment = ((_vHomes - _vApartments) - _vApartments);
                if ((levelAjustment / 4) > 0)
                    _sPopOverview += " [color=green](" + (levelAjustment / 4) + " more levels possible)[/color]";
                else if (levelAjustment < 0)
                    _sPopOverview += " [color=red](Cramped, " + Math.Abs(levelAjustment) + " more non-apartment homes needed)[/color]";
            }

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

            // Bank overview
            _sBank = "City's finances:";
            if (_empireCapital)
            {
                _sBank += Environment.NewLine + " Empire capital";
                _sBankShort = _vBankGovBalance.ToString("C", Hazeron.NumberFormat) + " balance";
            }
            else
            {
                _sBank += Environment.NewLine + " " + _vBankTribute.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " tributed to capital";
                _sBank += Environment.NewLine + "".PadLeft(Hazeron.CurrencyPadding) + "  [color=green](";
                int minutesToMidnight = (int)(DateTime.UtcNow.Subtract(DateTime.Now.TimeOfDay).AddDays(1) - _lastUpdated).TotalMinutes;
                if (minutesToMidnight < 120) // Less than two hours.
                    _sBank += minutesToMidnight + " minutes";
                else // More than two hours.
                    _sBank += (minutesToMidnight / 60) + " hours";
                _sBank += " to next tribute)[/color]";
                _sBankShort = _vBankTribute.ToString("C", Hazeron.NumberFormat) + " tributed";
            }
            _sBank += Environment.NewLine;
            _sBank += Environment.NewLine + " " + _vBankProduction.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " bullion production";
            _sBank += Environment.NewLine;
            _sBank += Environment.NewLine + " " + (_vBankCitBalance - _vBankCitBalanceOld).ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " citizen account net-change";
            _sBank += Environment.NewLine + " " + _vBankCitBalance.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " citizen account balance";
            _sBank += Environment.NewLine;
            _sBank += Environment.NewLine + " " + _vBankTaxIncome.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " income tax";
            _sBank += Environment.NewLine + " " + _vBankTaxSale.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " Sales tax";
            _sBank += Environment.NewLine;
            _sBank += Environment.NewLine + " " + (-_vBankExpenseResearch).ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " research expense (unreliable)";
            _sBank += Environment.NewLine + " " + (-_vBankExpenseResearchEst).ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " research expense (estimate per report)";
            _sBank += Environment.NewLine;
            _sBank += Environment.NewLine + " " + (_vBankGovBalance - _vBankGovBalanceOld).ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " government account net-change";
            _sBank += Environment.NewLine + " " + _vBankGovBalance.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " government account balance";

            // Overview
            _sOverview = "WIP";

            // AttentionCodes
            if ((_vJobs >= _vHomes) || (((float)(_vHomes - _vJobs) / _vHomes) > 0.2)) // Overworked, or too much unemployment.
                _attentionCode = (byte)(_attentionCode | 0x01); // 0b00000001
            if (_vPopulation < _vHomes || _vPopulation > _vHomes) // Population not full, or more than full.
                _attentionCode = (byte)(_attentionCode | 0x02); // 0b00000010
            if (14 >= _vAbandonment) // Less than or equal to 14 days to decay.
                _attentionCode = (byte)(_attentionCode | 0x04); // 0b00000100
            if (7 >= _vAbandonment) // Less than or equal to 7 days to decay.
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
