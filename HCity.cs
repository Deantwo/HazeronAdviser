using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HCity : HObj
    {
        protected int _zone = 0;
        public int Zone
        {
            get { return _zone; }
        }

        protected bool _capitalEmpire = false;
        public bool CapitalEmpire
        {
            get { return _capitalEmpire; }
        }

        protected bool _capitalGalaxy = false;
        public bool CapitalGalaxy
        {
            get { return _capitalGalaxy; }
        }

        protected bool _capitalSector = false;
        public bool CapitalSector
        {
            get { return _capitalSector; }
        }

        protected string _distressOverview = "";
        public string DistressOverview
        {
            get { return _distressOverview; }
        }

        protected string _decayOverview = "";
        public string DecayOverview
        {
            get { return _decayOverview; }
        }

        protected string _eventOverview = "";
        public string EventOverview
        {
            get { return _eventOverview; }
        }

        protected string _moraleOverview = "";
        public string MoraleOverview
        {
            get { return _moraleOverview; }
        }

        protected string _moraleColumn = "-";
        public string MoraleColumn
        {
            get { return _moraleColumn; }
        }

        protected int _morale = 0;
        public int Morale
        {
            get { return _morale; }
        }

        protected Dictionary<string, int> _moraleModifiers = new Dictionary<string, int>();
        public Dictionary<string, int> MoraleModifiers
        {
            get { return _moraleModifiers; }
        }

        protected int _abandonment = 0, _abandonmentMax = 0;
        public int Abandonment
        {
            get { return _abandonment; }
        }
        public int AbandonmentMax
        {
            get { return _abandonmentMax; }
        }

        protected string _abandonmentColumn = "-";
        public string AbandonmentColumn
        {
            get { return _abandonmentColumn; }
        }

        protected string _populationOverview = "-";
        public string PopulationOverview
        {
            get { return _populationOverview; }
        }

        protected string _populationColumn = "-";
        public string PopulationColumn
        {
            get { return _populationColumn; }
        }

        protected string _livingConditionsColumn = "-";
        public string LivingConditionsColumn
        {
            get { return _livingConditionsColumn; }
        }

        protected string _buildingsOverview = "";
        public string BuildingsOverview
        {
            get { return _buildingsOverview; }
        }

        protected string _race = "";
        public string Race
        {
            get { return _race; }
        }

        protected int _powerReserve = 0, _powerReserveCapacity = 0;
        public int PowerReserve
        {
            get { return _powerReserve; }
        }
        public int PowerReserveCapacity
        {
            get { return _powerReserveCapacity; }
        }

        protected Dictionary<string, int> _factilitiesJobs = new Dictionary<string, int>();
        public Dictionary<string, int> FactilitiesJobs
        {
            get { return _factilitiesJobs; }
        }

        protected Dictionary<string, int> _researchProjects = new Dictionary<string, int>();
        public Dictionary<string, int> ReseatchProjects
        {
            get { return _researchProjects; }
        }

        protected new Dictionary<string, int> _patents = new Dictionary<string, int>();
        public new Dictionary<string, int> Patents
        {
            get { return _patents; }
        }

        protected string _patentsOverview = "";
        public string PatentsOverview
        {
            get { return _patentsOverview; }
        }

        protected int _population = 0;
        public int Population
        {
            get { return _population; }
        }

        protected int _homes = 0;
        public int Homes
        {
            get { return _homes; }
        }

        protected int _homesQuality = 0;
        public int HomesQuality
        {
            get { return _homesQuality; }
        }

        protected int _jobs = 0;
        public int Jobs
        {
            get { return _jobs; }
        }

        protected int _food = 0;
        public int Food
        {
            get { return _food; }
        }

        protected int _foodRate = 0;
        public int FoodRate
        {
            get { return _foodRate; }
        }

        protected int _air = 0;
        public int Air
        {
            get { return _air; }
        }

        protected int _airRate = 0;
        public int AirRate
        {
            get { return _airRate; }
        }

        protected bool _hashEnv = false;
        public bool HashEnv
        {
            get { return _hashEnv; }
        }

        protected bool _militaryBase = false;
        public bool MilitaryBase
        {
            get { return _militaryBase; }
        }

        protected string _officerCadet;
        public string OfficerCadet
        {
            get { return _officerCadet; }
        }

        protected long _bankBalance = 0;
        public long BankBalance
        {
            get { return _bankBalance; }
        }

        protected long _bankBalanceOld = 0;
        public long BankBalanceOld
        {
            get { return _bankBalanceOld; }
        }

        protected long _bankIncomeMinting = 0;
        public long BankIncomeMinting
        {
            get { return _bankIncomeMinting; }
        }

        protected long _bankIncomePayroll = 0;
        public long BankIncomePayroll
        {
            get { return _bankIncomePayroll; }
        }

        protected long _bankIncomeProduct = 0;
        public long BankIncomeProduct
        {
            get { return _bankIncomeProduct; }
        }

        protected long _bankIncomeResearch = 0;
        public long BankIncomeResearch
        {
            get { return _bankIncomeResearch; }
        }

        protected long _bankExpensePayroll = 0;
        public long BankExpensePayroll
        {
            get { return _bankExpensePayroll; }
        }

        protected long _bankExpenseProduct = 0;
        public long BankExpenseProduct
        {
            get { return _bankExpenseProduct; }
        }

        protected long _bankExpenseLoans = 0;
        public long BankExpenseLoans
        {
            get { return _bankExpenseLoans; }
        }

        protected long _bankExpenseRewards = 0;
        public long BankExpenseRewards
        {
            get { return _bankExpenseRewards; }
        }

        protected long _bankExpenseWithdrawals = 0;
        public long BankExpenseWithdrawals
        {
            get { return _bankExpenseWithdrawals; }
        }

        protected long _bankExpenseResearch = 0;
        public long BankExpenseResearch
        {
            get { return _bankExpenseResearch; }
        }

        protected long _bankTribute = 0;
        public long BankTribute
        {
            get { return _bankTribute; }
        }

        protected string _bankOverview = "", _bankTributeColumn = "-";
        public string BankOverview
        {
            get { return _bankOverview; }
        }
        public string BankTributeColumn
        {
            get { return _bankTributeColumn; }
        }

        protected List<AttentionMessage> _attentions = new List<AttentionMessage>();
        public List<AttentionMessage> Attentions
        {
            get { return _attentions; }
        }

        public HCity(HMail mail)
            : base(mail)
        {
        }

        public override void CompareMail(HMail mail)
        {
            base.CompareMail(mail);
        }

        public override void Initialize()
        {
            if (_mail.Body.Remove(4) == "UTC:")
            {
                _lastUpdated = HMail.DecodeUTC(_mail.Body.Remove(12));
            }

            // String working vars.
            string[] tempArray;
            Dictionary<string, int> sectionsInReport = new Dictionary<string, int>();
            string reportSection;
            // This is the order of the sections in the mail body, keep them in same order!
            const string headlineDISTRESS = "<b style=\"color: rgb(255, 255, 0);\">DISTRESS</b>";
            const string headlineDECAY = "<b>DECAY</b>";
            const string headlineEVENT = "<b>EVENT LOG</b>";
            const string headlineMORALE = "<b>MORALE ";
            const string headlinePOPULATION = "<b>POPULATION ";
            const string headlineHOMES = "<b>HOMES ";
            const string headlineBARRACKS = "<b>BARRACKS ";
            const string headlineJOBS = "<b>JOBS ";
            const string headlinePOWER = "<b>POWER RESERVE ";
            const string headlineBANK = "<b>BANK ";
            const string headlineSPACECRAFT = "<b>SPACECRAFT</b>";
            const string headlineFACILITIES = "<b>FACILITIES</b>";
            const string headlineVEHICLES = "<b>VEHICLES</b>";
            const string headlineINVENTORY = "<b>INVENTORY</b>";
            const string headlinePOTENTIAL = "<b>SPACECRAFT MANUFACTURING POTENTIAL</b>";
            const string headlineRESEARCH = "<b>RESEARCH AND DEVELOPMENT</b>";
            const string headlinePATENTS = "<b>PATENTS</b>";
            string[] sections = new string[] { headlineDISTRESS
                                             , headlineDECAY
                                             , headlineEVENT
                                             , headlineMORALE
                                             , headlinePOPULATION
                                             , headlineHOMES
                                             , headlineBARRACKS
                                             , headlineJOBS
                                             , headlinePOWER
                                             , headlineBANK
                                             , headlineSPACECRAFT
                                             , headlineFACILITIES
                                             , headlineVEHICLES
                                             , headlineINVENTORY
                                             , headlineRESEARCH
                                             , headlinePOTENTIAL
                                             , headlinePATENTS
                                             };
            // Check for sections.
            int freakingHell = 0;
            foreach (string section in sections)
            {
                int sigh = _mail.Body.IndexOf(section, freakingHell);
                if (sigh >= 0)
                {
                    freakingHell = sigh;
                    sectionsInReport.Add(section, freakingHell);
                }
            }

            // Time for City spicific things.
            bool decaying = false;
            int populationChange = 0;

            // City Resource Zone & Capital check
            {
                reportSection = HHelper.CleanText(_mail.Body.Remove(sectionsInReport.Values.OrderBy(x => x).FirstOrDefault()));
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in tempArray)
                {
                    if (line.Contains("Resource Zone"))
                        _zone = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    else if (line == "Empire Capital City")
                        _capitalEmpire = true;
                    else if (line == "Galaxy Capital City")
                        _capitalGalaxy = true;
                    else if (line == "Sector Capital City")
                        _capitalSector = true;
                }
            }

            //DISTRESS
            if (TryGetSectionText(sectionsInReport, headlineDISTRESS, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                //tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _distressOverview = "[color=red]" + "Distress:" + Environment.NewLine + "  " + reportSection.Substring(("DISTRESS" + Environment.NewLine).Length).Replace(Environment.NewLine, Environment.NewLine + "  ") + "[/color]";
                decaying = reportSection.Contains("City is decaying.");
            }

            // DECAY
            if (TryGetSectionText(sectionsInReport, headlineDECAY, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                //tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _decayOverview = "[color=red]" + "Decay:" + Environment.NewLine + "  " + reportSection.Substring(("DECAY" + Environment.NewLine).Length).Replace(Environment.NewLine, Environment.NewLine + "  ") + "[/color]";
            }

            // EVENT LOG
            if (TryGetSectionText(sectionsInReport, headlineEVENT, out reportSection))
            {
                reportSection = HHelper.CleanText(GetSectionText(sectionsInReport, headlineEVENT));
                //tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _eventOverview += HCity.EventLogStyle(reportSection);
            }

            // MORALE & Abandonment
            if (TryGetSectionText(sectionsInReport, headlineMORALE, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _morale = Convert.ToInt32(tempArray[0].Substring(tempArray[0].LastIndexOf(' ') + 1));
                tempArray = tempArray.Where((source, index) => index != 0).ToArray(); // Remove first element in array.
                int abandonedDays = 0;
                int abandonedPenalty = 0;
                foreach (string line in tempArray)
                {
                    if (line.Contains("Abandonment Penalty") || line.StartsWith("Abandoned"))
                    {
                        if (line.StartsWith("+") || line.StartsWith("-"))
                        {
                            _moraleModifiers.Add(line.Substring(line.IndexOf(' ') + 1), Convert.ToInt32(line.Remove(line.IndexOf(' '))));
                            abandonedPenalty = Convert.ToInt32(line.Remove(line.IndexOf(' ')));
                        }
                        else
                            _moraleModifiers.Add(line, 0);
                        int posA, posB;
                        posA = line.LastIndexOf(" in ") + 4;
                        posB = line.LastIndexOf(" days.");
                        abandonedDays = Convert.ToInt32(line.Substring(posA, posB - posA));
                    }
                    else if (line != "No citizens.")
                        _moraleModifiers.Add(line.Substring(line.IndexOf(' ') + 1), Convert.ToInt32(line.Remove(line.IndexOf(' '))));
                    if (line == "-1 Harsh Environment.")
                        _hashEnv = true;
                }
                _abandonment = ((_moraleModifiers.Values.Sum() + 1) * Hazeron.AbandonmentInterval) - (abandonedDays % Hazeron.AbandonmentInterval);
                _abandonmentMax = ((_moraleModifiers.Values.Sum() - abandonedPenalty + 1) * Hazeron.AbandonmentInterval);
                if (_moraleModifiers.Any(x => x.Key.StartsWith("Loyalty Bonus."))) // Ignore loyalty morale bonus. 2016-01-01
                {
                    int loyaltyBonusDays = _moraleModifiers.First(x => x.Key.Contains("Loyalty Bonus.")).Value * 7;
                    _abandonment -= loyaltyBonusDays;
                    _abandonmentMax -= loyaltyBonusDays;
                }
                if (decaying)
                    _abandonmentColumn = " Decaying";
                else if (_abandonmentMax < Hazeron.AbandonmentInterval)
                    _abandonmentColumn = " Unstable";
                else if (_abandonment == _abandonmentMax)
                    _abandonmentColumn = $"{_abandonment.ToString("00")}~/{_abandonmentMax.ToString("00")} days";
                else if (_abandonment > 0)
                    _abandonmentColumn = $"{_abandonment.ToString("00")} /{_abandonmentMax.ToString("00")} days";
                else
                    _abandonmentColumn = " ERROR!?";
            }

            // POPULATION
            if (TryGetSectionText(sectionsInReport, headlinePOPULATION, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _population = Convert.ToInt32(tempArray[0].Substring(tempArray[0].LastIndexOf(' ') + 1).Replace(",", ""));
                tempArray = tempArray.Where((source, index) => index != 0).ToArray(); // Remove first element in array.
                // Get race and population changes.
                Dictionary<string, int> populationChanges = new Dictionary<string, int>();
                bool mixedRaces = false;
                foreach (string line in tempArray)
                {
                    if (mixedRaces)
                        _race = "mixed races";
                    else if (line.StartsWith("University graduate ") || line.StartsWith("Star Fleet Academy Cadet ")) // "University graduate <name> is ready for command assignment aboard a spacecraft." and "Star Fleet Academy Cadet <name> is ready for command assignment aboard a fleet spacecraft."
                    {
                        _officerCadet = line.Substring(line.StartsWith("University") ? "University graduate ".Length : "Star Fleet Academy Cadet ".Length);
                        _officerCadet = _officerCadet.Remove(_officerCadet.IndexOf(' '));
                    }
                    else if (line == "Citizens are mixed races." || line == "Troops are mixed races.")
                        mixedRaces = true; // All lines after this one is each of the faces, or a ready cadet.
                    else if (line.StartsWith("Citizens are ") || line.StartsWith("Troops are "))
                        _race = line.Remove(line.Length - 1).Substring(line.StartsWith("Citizens") ? "Citizens are ".Length : "Troops are ".Length);
                    else if (line != "No change.")
                        populationChanges.Add(line.Substring(line.IndexOf(" · ") + 3), Convert.ToInt32(line.Remove(line.IndexOf(" · "))));
                    if (line.StartsWith("Troops "))
                        _militaryBase = true;
                }
                if (populationChanges.Values.Sum() < 0)
                    _populationColumn = $"{_population} (decreased {Math.Abs(populationChanges.Values.Sum())})";
                else if (populationChanges.Values.Sum() > 0)
                    _populationColumn = $"{_population} (increased {populationChanges.Values.Sum()})";
                else
                    _populationColumn = $"{_population} (steady)";
            }

            // LIVING CONDITIONS
            if (TryGetSectionText(sectionsInReport, headlineHOMES, out reportSection) || TryGetSectionText(sectionsInReport, headlineBARRACKS, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _homes = Convert.ToInt32(tempArray[0].Substring(tempArray[0].LastIndexOf(' ') + 1));
                tempArray = tempArray.Where((source, index) => index != 0).ToArray(); // Remove first element in array.
                // Calculate crampedness.
                int large = 0, medium = 0, small = 0;
                foreach (string line in tempArray)
                {
                    if (line.StartsWith("Large "))
                        large = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    else if (line.StartsWith("Medium "))
                        medium = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    else if (line.StartsWith("Small "))
                        small = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                }
                _homesQuality = (large * 2) + medium - small;
            }
            if (TryGetSectionText(sectionsInReport, headlineJOBS, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _jobs = Convert.ToInt32(tempArray[0].Substring(tempArray[0].LastIndexOf(' ') + 1));
                tempArray = tempArray.Where((source, index) => index != 0).ToArray(); // Remove first element in array.
                // Get temporaray jobs. They aren't worth keeping track of.
                int construction = 0;
                foreach (string line in tempArray)
                {
                    if (line.StartsWith("Construction "))
                        construction = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                }
                _jobs -= construction;
            }

            // POWER RESERVE
            if (TryGetSectionText(sectionsInReport, headlinePOWER, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _powerReserve = Convert.ToInt32(tempArray[0].Substring(tempArray[0].LastIndexOf(' ') + 1).Replace(",", ""));
                tempArray = tempArray.Where((source, index) => index != 0).ToArray(); // Remove first element in array.
                // Get reserve capacity.
                foreach (string line in tempArray)
                {
                    if (line.StartsWith("Reserve Capacity "))
                        _powerReserveCapacity = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1).Replace(",", ""));
                }
            }

            // BANK ACTIVITY
            if (TryGetSectionText(sectionsInReport, headlineBANK, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                int startpos = tempArray[0].LastIndexOf(' ') + 1;
                _bankBalance = Convert.ToInt64(tempArray[0].Substring(startpos, tempArray[0].Length - 1 - startpos).Replace(",", ""));
                tempArray = tempArray.Where((source, index) => index != 0).ToArray(); // Remove first element in array.
                bool income = true;
                for (int i = 1; i < tempArray.Length; i++)
                {
                    string line = tempArray[i];
                    if (line == "Income")
                        income = true;
                    else if (line == "Expense")
                        income = false;
                    else if (line == "Sub Total")
                        i++; // Ignore.
                    else if (line == "Ending Balance")
                        i++; // Ignore.
                    else if (line == "Previous Tribute")
                    {
                        i++;
                        //line = tempArray[i].Replace(",", "");
                        //_bankTribute = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Starting Balance")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _bankBalanceOld = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Minted Bullion")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _bankIncomeMinting = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Payroll")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        if (income)
                            _bankIncomePayroll = Convert.ToInt64(line.Remove(line.Length - 1));
                        else
                            _bankExpensePayroll = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Product Sales")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _bankIncomeProduct = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Research and Development Canceled")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _bankIncomeResearch = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Product Purchases")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _bankExpenseProduct = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Citizen Loans")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _bankExpenseLoans = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Withdrawals")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _bankExpenseWithdrawals = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Research and Development")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _bankExpenseResearch = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Rewards")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "");
                        _bankExpenseRewards = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Income Tax")
                    {
                        i++;
                        //line = tempArray[i].Replace(",", "");
                        //_bankTaxIncome = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Sales Tax")
                    {
                        i++;
                        //line = tempArray[i].Replace(",", "");
                        //_bankTaxSale = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                }
            }

            //// SPACECRAFT
            //if (TryGetSectionText(sectionsInReport, headlineSPACECRAFT))
            //{
            //    reportSection = HHelper.CleanText(reportSection);
            //    tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //}

            // FACILITIES
            if (TryGetSectionText(sectionsInReport, headlineFACILITIES, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                // Read every building.
                int lounges = 0, retailers = 0;
                for (int i = 1; i < tempArray.Length; i++)
                {
                    if (tempArray[i].StartsWith("Lounges: "))
                    {
                        string line = tempArray[i];
                        if (line.EndsWith(". Includes local civilian lounges."))
                            line = line.Remove(line.Length - ". Includes local civilian lounges.".Length);
                        lounges = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1).Replace(",", ""));
                    }
                    else if (tempArray[i].StartsWith("Retail Stores: "))
                    {
                        string line = tempArray[i];
                        if (line.EndsWith(". Includes local civilian stores."))
                            line = line.Remove(line.Length - ". Includes local civilian stores.".Length);
                        retailers = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1).Replace(",", ""));
                    }
                    else if (tempArray[i] != "Name")
                    {
                        string name = tempArray[i].TrimStart();
                        int jobs = 0;
                        if (name == "Cantina")
                            jobs = lounges;
                        else if (name == "Retail Store")
                            jobs = retailers;
                        else if (name == "University")
                            jobs = Convert.ToInt32(tempArray[i + 1].Remove(tempArray[i + 1].IndexOf(", ")));
                        else if (tempArray[i + 1].EndsWith(" in use"))
                        {
                            int startpos = tempArray[i + 1].IndexOf(", ") + 2;
                            int length = tempArray[i + 1].IndexOf(" in use") - startpos;
                            jobs = Convert.ToInt32(tempArray[i + 1].Substring(startpos, length).Replace(",", ""));
                        }
                        else
                            jobs = Convert.ToInt32(tempArray[i + 1].Replace(",", ""));
                        _factilitiesJobs.Add(name, jobs);
                        i++; // Skip an extra line.
                    }
                }
                if (!_factilitiesJobs.ContainsKey("Cantina"))
                    _factilitiesJobs.Add("Cantina", lounges);
                if (!_factilitiesJobs.ContainsKey("Retail Store"))
                    _factilitiesJobs.Add("Retail Store", retailers);
            }

            //// VEHICLES
            //if (TryGetSectionText(sectionsInReport, headlineVEHICLES))
            //{
            //    reportSection = HHelper.CleanText(reportSection);
            //    tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //}

            // INVENTORY
            if (TryGetSectionText(sectionsInReport, headlineINVENTORY, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                int startpos, length;
                if (reportSection.Contains("Air:"))
                {
                    _hashEnv = true;

                    startpos = "Air: ".Length;
                    length = tempArray[1].Length - " total units in stock".Length - startpos;
                    _air = ConvertToInt32Max(tempArray[1].Substring(startpos, length).Replace(",", ""));
                    startpos = "Air Consumption: ".Length;
                    length = tempArray[2].Length - " units per report period".Length - startpos;
                    _airRate = Convert.ToInt32(tempArray[2].Substring(startpos, length).Replace(",", ""));
                }
                if (reportSection.Contains("Food: "))
                {
                    startpos = "Food: ".Length;
                    length = tempArray[_hashEnv ? 3 : 1].Length - " total nutrition value in stock".Length - startpos;
                    _food = ConvertToInt32Max(tempArray[_hashEnv ? 3 : 1].Substring(startpos, length).Replace(",", ""));
                    startpos = "Food Consumption: ".Length;
                    length = tempArray[_hashEnv ? 4 : 2].Length - " nutrition value per report period".Length - startpos;
                    _foodRate = Convert.ToInt32(tempArray[_hashEnv ? 4 : 2].Substring(startpos, length).Replace(",", ""));
                }
            }

            // RESEARCH AND DEVELOPMENT
            if (TryGetSectionText(sectionsInReport, headlineRESEARCH, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 3; i < tempArray.Length; i++)
                {
                    if (tempArray[i] != "Technology" && tempArray[i] != "Processes")
                    {
                        string researchName = tempArray[i];
                        int researchAmount = Convert.ToInt32(tempArray[i + 1]);
                        _researchProjects.Add(researchName, researchAmount);
                        i++;
                    }
                }
            }

            //// SPACECRAFT MANUFACTURING POTENTIAL
            //if (TryGetSectionText(sectionsInReport, headlinePOTENTIAL))
            //{
            //    reportSection = HHelper.CleanText(reportSection);
            //    tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //}

            // PATENTS
            if (TryGetSectionText(sectionsInReport, headlinePATENTS, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 3; i < tempArray.Length; i++)
                {
                    const string PATENT_PREFIX = " ";
                    if (tempArray[i].StartsWith(PATENT_PREFIX))
                    {
                        int pos = tempArray[i].LastIndexOf(' ');
                        string patentName = tempArray[i].Substring(PATENT_PREFIX.Length, pos - PATENT_PREFIX.Length);
                        int patentQuality = Convert.ToInt32(tempArray[i].Substring(pos + 2));
                        _patents.Add(patentName, patentQuality);
                    }
                }
            }

            UpdateMoraleOverview();

            UpdatePopulationOverwiew(populationChange);

            //UpdateLivingOverwiew();
            _livingConditionsColumn = $"Jobs {_jobs}, Homes {_homes}";

            UpdateBuildingsOverview();

            UpdateBankOverview();

            UpdatePatentsOverview();

            // Overview
            _overview = "Location:" + Environment.NewLine;
            _overview += "  " + _systemName + Environment.NewLine;
            _overview += "  " + _planetName + Environment.NewLine;
            _overview += "  Zone " + _zone;
            if (_distressOverview != "")
                _overview += Environment.NewLine + Environment.NewLine + _distressOverview;
            if (_decayOverview != "")
                _overview += Environment.NewLine + Environment.NewLine + _decayOverview;
            if (_eventOverview != "")
                _overview += Environment.NewLine + Environment.NewLine + _eventOverview;

            // Attentions
            if (_population > 1 && _jobs >= _homes) // Overworked.
                _attentions.Add(new AttentionMessage(1, "ColumnLivingConditions", "- Overworked." + Environment.NewLine + "  " + (_jobs - _homes + 1).ToString().PadLeft(4) + ", Missing workers"));
            if (_population > 1 && ((float)(_homes - _jobs) / _homes) > 0.2) // High unemployment.
                _attentions.Add(new AttentionMessage(1, "ColumnLivingConditions", "- High unemployment." + Environment.NewLine + "  " + ((_homes * 0.8) - _jobs + 1).ToString().PadLeft(4) + ", Excesseding unemployed"));
            if (decaying) // Decaying.
                _attentions.Add(new AttentionMessage(4, "ColumnAbandonment", "- City is decaying!"));
            else if (_abandonment <= 0) // 0 days till decay.
                _attentions.Add(new AttentionMessage(3, "ColumnAbandonment", "- City has been abandonment." + Environment.NewLine + "  Decay may start at any moment."));
            else if (_abandonment <= Hazeron.AbandonmentInterval) // Less than or equal to (Hazeron.AbandonmentInterval) days to decay.
                _attentions.Add(new AttentionMessage(2, "ColumnAbandonment", "- City has been abandonment." + Environment.NewLine + "  Possible decay in " + _abandonment.ToString() + " days."));
            else if (_abandonment <= Hazeron.AbandonmentInterval * 2) // Less than or equal to (Hazeron.AbandonmentInterval * 2) days to decay.
                _attentions.Add(new AttentionMessage(1, "ColumnAbandonment", "- City has been abandonment." + Environment.NewLine + "  Possible decay in " + _abandonment.ToString() + " days."));
            if (_population <= 1) // Population is 1 or 0.
                _attentions.Add(new AttentionMessage(1, "ColumnPopulation", "- City is desered."));
            if (_population > _homes) // Homelessness.
                _attentions.Add(new AttentionMessage(1, "ColumnPopulation", "- Homeless citizens." + Environment.NewLine + (_population - _homes).ToString().PadLeft(4) + ", Homeless"));
            if (_population > 1 && _morale < 0) // Morale is negative!
                _attentions.Add(new AttentionMessage(2, "ColumnMorale", "- Morale is negative!"));
            else if (_population > 1 && _morale < 3) // Morale is low.
                _attentions.Add(new AttentionMessage(1, "ColumnMorale", "- Morale is low."));
            if (_population > 1 && _moraleModifiers.Values.Sum() < 1) // Morale not positive.
                _attentions.Add(new AttentionMessage(2, "ColumnMorale", "- Morale modifiers are dangerously low."));
            if (_moraleModifiers.Keys.Any(x => x.EndsWith(" wanted."))) // Morale building wanted.
                _attentions.Add(new AttentionMessage(1, "ColumnMorale", "- Missing morale building."));
            if (_population > 1 && !_factilitiesJobs.ContainsKey("Bank")) // No bank.
                _attentions.Add(new AttentionMessage(1, "ColumnBank", "- City has no bank and is not collecting taxes."));

            base.Initialize();
        }

        #region Overviews
        protected void UpdateMoraleOverview()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("City's morale:");
            if (_morale >= 0)
                sb.Append("[color=green]");
            else
                sb.Append("[color=red]");
            sb.AppendLine($"  Morale {_morale.ToString("+#0;-#0;±#0").PadLeft(3)}[/color]");
            sb.AppendLine();
            sb.AppendLine("City's morale modifiers:");
            foreach (KeyValuePair<string, int> moraleModifier in _moraleModifiers)
            {
                if (moraleModifier.Value > 0)
                    sb.Append("[color=green]");
                else
                    sb.Append("[color=red]");
                sb.AppendLine($"  {moraleModifier.Value.ToString("+#0;-#0;±#0").PadLeft(3)}  {moraleModifier.Key}[/color]");
            }
            sb.Append($"Total ");
            if (_morale >= 0)
                sb.Append("[color=green]");
            else
                sb.Append("[color=red]");
            sb.Append($"{_morale.ToString("+#0;-#0;±#0")}[/color]");
            sb.Append($" ([color=green]{_moraleModifiers.Values.Where(x => x > 0).Sum().ToString("+#0;-#0;±#0")}[/color]");
            sb.Append($", [color=red]{_moraleModifiers.Values.Where(x => x < 0).Sum().ToString("+#0;-#0;±#0")}[/color])");
            _moraleOverview = sb.ToString();
            _moraleColumn = $"{_morale.ToString("+#0;-#0;±#0")} ({Math.Abs(_moraleModifiers.Values.Where(y => y < 0).Sum()).ToString("-#0")}, {_moraleModifiers.Values.Where(y => y > 0).Sum().ToString("+#0")})";
        }

        protected void UpdatePopulationOverwiew(int populationChange)
        {
            StringBuilder sb = new StringBuilder();
            const int populationPadding = 6;
            sb.AppendLine("City's population:");
            sb.Append($" {_population.ToString().PadLeft(populationPadding)}, Citizens");
            if (populationChange < 0)
                sb.Append($" [color=red](decreased by {Math.Abs(populationChange)})[/color]");
            else if (populationChange > 0)
                sb.Append($" [color=green](increased by {populationChange})[/color]");
            //else
            //    sb.Append(" (steady)");
            sb.AppendLine();
            sb.Append($" {_homes.ToString().PadLeft(populationPadding)}, Homes");
            if (_jobs >= _homes)
            {
                int needed = (_jobs - _homes + 1); // Need at least one more home than jobs.
                sb.Append($" [color=red](Overworked, {needed} more homes needed)[/color]");
            }
            sb.AppendLine();
            sb.Append($" {_jobs.ToString().PadLeft(populationPadding)}, Jobs");
            if (((float)(_homes - _jobs) / _homes) > 0.2)
            {
                int needed = (int)((_homes * 0.8) - _jobs + 1); // Need at least one more job than 80% homes.
                sb.Append($" [color=red](Unemployment, {needed} more jobs needed)[/color]");
            }
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("City's living conditions:");
            sb.AppendLine($" Citizens are {_race}");
            {
                sb.AppendLine($" {_powerReserve.ToString("N", Hazeron.NumberFormat)}/{_powerReserveCapacity.ToString("N", Hazeron.NumberFormat)} power capacity ({Math.Floor(((float)_powerReserve / _powerReserveCapacity) * 100)}%)");
            }
            {
                int minutesToStarvation = (_foodRate / 13) == 0 ? 0 : (_food / (_foodRate / 13));
                if (minutesToStarvation < 120) // Less than two hours.
                    sb.Append($" {minutesToStarvation} minutes");
                else if (minutesToStarvation < 2980) // Less than two days.
                    sb.Append($" {minutesToStarvation / 60} hours");
                else // More than two days.
                    sb.Append($" {minutesToStarvation / 1490} days");
                sb.AppendLine(" worth of food");
            }
            if (_hashEnv)
            {
                int minutesToSuffocation = (_airRate / 13) == 0 ? 0 : (_air / (_airRate / 13));
                if (minutesToSuffocation < 120) // Less than two hours.
                    sb.Append($" {minutesToSuffocation} minutes");
                else if (minutesToSuffocation < 2980) // Less than two days.
                    sb.Append($" {minutesToSuffocation / 60} hours");
                else // More than two days.
                    sb.Append($" {minutesToSuffocation / 1490} days");
                sb.AppendLine(" worth of air");
            }
            {
                sb.Append($" {Math.Floor(((float)_homesQuality / _homes) * 100)}% apartments");
                int homeAjustment = ((_homes - _homesQuality) - _homesQuality);
                if ((homeAjustment / 4) > 0)
                    sb.Append($" [color=green]({(homeAjustment / 4)} additional small homes possible)[/ color]");
                else if (homeAjustment < 0)
                    sb.Append($" [color=red](Cramped, {Math.Abs(homeAjustment)} more non-small homes needed)[/color]");
            }
            if (!string.IsNullOrEmpty(_officerCadet))
            {
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("Spacecraft crew:");
                sb.Append($" Cadet {_officerCadet}");
            }
            _populationOverview = sb.ToString();
        }

        protected void UpdateBuildingsOverview()
        {
            StringBuilder sb = new StringBuilder();
            List<string> buildingList;
            sb.AppendLine("City's buildings:");
            buildingList = _factilitiesJobs.Keys.ToList();
            foreach (string moraleBuilding in Hazeron.MoraleBuildingCityThresholds.Keys)
            {
                if (!_factilitiesJobs.ContainsKey(moraleBuilding) && _homes >= Hazeron.MoraleBuildingCityThresholds[moraleBuilding])
                    buildingList.Add(moraleBuilding);
            }
            if (!buildingList.Contains("Cantina"))
                buildingList.Add("Cantina");
            if (!buildingList.Contains("Church"))
                buildingList.Add("Church");
            buildingList.Sort();
            foreach (string building in buildingList)
            {
                int jobs = 0;
                if (_factilitiesJobs.ContainsKey(building))
                    jobs = _factilitiesJobs[building];
                sb.AppendLine();
                sb.Append($" {jobs.ToString().PadLeft(4)} jobs, {building}");
                if (_militaryBase)
                {
                    if (Hazeron.MoraleBuildingBaseThresholds.ContainsKey(building))
                    {
                        int jobsNeeded = Hazeron.MoraleBuildingsRequiredBase(building, _homes);
                        if (jobs < jobsNeeded)
                            sb.Append($" [color=red]({jobsNeeded - jobs} professional jobs more needed)[/color]");
                        else if (jobs > jobsNeeded)
                            sb.Append($" [color=orange]({jobs - jobsNeeded} professional jobs too many)[/color]");
                    }
                }
                else
                {
                    if (Hazeron.MoraleBuildingCityThresholds.ContainsKey(building))
                    {
                        int jobsNeeded = Hazeron.MoraleBuildingsRequiredCity(building, _homes);
                        if (jobs < jobsNeeded)
                            sb.Append($" [color=red]({jobsNeeded - jobs} professional jobs more needed)[/color]");
                        else if (jobs > jobsNeeded)
                            sb.Append($" [color=orange]({jobs - jobsNeeded} professional jobs too many)[/color]");
                    }
                }
            }
            _buildingsOverview = sb.ToString();
        }

        protected void UpdateBankOverview()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("City's finances:");
            if (_capitalEmpire && _bankTribute == 0)
            {
                _bankTributeColumn = "No tributing";
                sb.AppendLine($"{"".PadLeft(Hazeron.CurrencyPadding)}  Empire capital does not tribute");
            }
            else
            {
                _bankTributeColumn = _bankTribute.ToString("C", Hazeron.NumberFormat) + " tributed";
                sb.Append($" {_bankTribute.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding)} tributed to ");
                if (_capitalEmpire)
                    sb.AppendLine("(overlord/ally)");
                else if (_capitalGalaxy)
                    sb.AppendLine("empire capital city");
                else if (_capitalSector)
                    sb.AppendLine("galaxy capital city");
                else
                    sb.AppendLine("sector capital city");
            }
            {
                sb.Append($"{"".PadLeft(Hazeron.CurrencyPadding)}  [color=green](");
                int minutesToMidnight = (int)(DateTime.UtcNow.Subtract(DateTime.Now.TimeOfDay).AddDays(1) - _lastUpdated).TotalMinutes;
                if (minutesToMidnight < 120) // Less than two hours.
                    sb.Append($"{minutesToMidnight} minutes");
                else // More than two hours.
                    sb.Append($"{minutesToMidnight / 60} hours");
                sb.AppendLine(" to next tribute)[/color]");
            }
            sb.AppendLine();
            sb.AppendLine($" {_bankIncomeMinting.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding)} bullion minting");
            sb.AppendLine();
            sb.AppendLine($" {(-_bankExpenseWithdrawals).ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding)} withdrawals");
            sb.AppendLine($" {(-_bankExpenseResearch).ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding)} research expense");
            sb.AppendLine();
            sb.AppendLine($" {(_bankBalance - _bankBalanceOld).ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding)} government account net-change");
            sb.AppendLine($" {_bankBalance.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding)} government account balance");
            _bankOverview = sb.ToString();
        }

        protected void UpdatePatentsOverview()
        {
            if (_researchProjects.Count != 0)
            {
                _patentsOverview = "City's patent research:";
                foreach (string patent in _researchProjects.Keys)
                {
                    _patentsOverview += Environment.NewLine + " " + _researchProjects[patent].ToString().PadLeft(2) + " (Q" + (_patents.ContainsKey(patent) ? _patents[patent].ToString().PadLeft(3) : "  0") + ") running, " + patent;
                }
            }
            if (_patentsOverview != "")
                _patentsOverview += Environment.NewLine + Environment.NewLine;
            List<string> patentsList;
            patentsList = _patents.Keys.ToList();
            patentsList.Sort();
            _patentsOverview += "City's patents:";
            foreach (string patent in patentsList)
            {
                _patentsOverview += Environment.NewLine + " Q" + Math.Abs(_patents[patent]).ToString().PadLeft(3) + ", " + patent;
            }
        }
        #endregion

        private int ConvertToInt32Max(string input)
        {
            if (input.Length > 10)
                return int.MaxValue;

            int output;
            try
            {
                output = Convert.ToInt32(input);
            }
            catch (OverflowException)
            {
                output = int.MaxValue;
            }
            return output;
        }
    }
}
