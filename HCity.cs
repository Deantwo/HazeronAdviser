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

        protected bool _empireCapital = false;
        public bool EmpreCapital
        {
            get { return _empireCapital; }
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

        protected string _moraleModifiersColumn = "-";
        public string MoraleModifiersColumn
        {
            get { return _moraleModifiersColumn; }
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

        protected int _neglect = 0;
        public int Neglect
        {
            get { return _neglect; }
        }

        protected string _loyaltyColumn = "-";
        public string LoyaltyColumn
        {
            get { return _loyaltyColumn; }
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

        protected int _powerConsumption = 0, _powerReserve = 0, _powerReserveCapacity = 0;
        public int PowerConsumption
        {
            get { return _powerConsumption; }
        }
        public int PowerReserve
        {
            get { return _powerReserve; }
        }
        public int PowerReserveCapacity
        {
            get { return _powerReserveCapacity; }
        }

        protected string _defencesOverview = "";
        public string DefencesOverview
        {
            get { return _defencesOverview; }
        }

        protected Dictionary<string, int> _factilitiesLV = new Dictionary<string, int>();
        public Dictionary<string, int> FactilitiesLV
        {
            get { return _factilitiesLV; }
        }

        protected string _technologyOverview = "";
        public string TechnologyOverview
        {
            get { return _technologyOverview; }
        }

        protected Dictionary<string, int> _researchProjects = new Dictionary<string, int>();
        public Dictionary<string, int> ReseatchProjects
        {
            get { return _researchProjects; }
        }

        protected Dictionary<string, int> _factilitiesTL = new Dictionary<string, int>();
        public Dictionary<string, int> FactilitiesTL
        {
            get { return _factilitiesTL; }
        }

        protected string _patentsOverview = "";
        public string PatentsOverview
        {
            get { return _patentsOverview; }
        }

        protected new Dictionary<string, int> _researchPatents = new Dictionary<string, int>();
        public new Dictionary<string, int> ReseatchPatents
        {
            get { return _researchPatents; }
        }

        protected int _population = 0;
        public int Population
        {
            get { return _population; }
        }

        protected int _loyalty = 0;
        public int Loyalty
        {
            get { return _loyalty; }
        }

        protected int _homes = 0;
        public int Homes
        {
            get { return _homes; }
        }

        protected int _apartments = 0;
        public int Apartments
        {
            get { return _apartments; }
        }

        protected int _jobs = 0;
        public int Jobs
        {
            get { return _jobs; }
        }

        protected int _populationLimit = 0;
        public int PopulationLimit
        {
            get { return _populationLimit; }
        }

        protected int _food = 0;
        public int Food
        {
            get { return _food; }
        }

        protected int _air = 0;
        public int Air
        {
            get { return _air; }
        }

        protected bool _hashEnv = false;
        public bool HashEnv
        {
            get { return _hashEnv; }
        }

        protected long _bankCitBalance = 0;
        public long BankCitBalance
        {
            get { return _bankCitBalance; }
        }

        protected long _bankCitBalanceOld = 0;
        public long BankCitOldBalanceOld
        {
            get { return _bankCitBalanceOld; }
        }

        protected long _bankMinting = 0;
        public long BankMinting
        {
            get { return _bankMinting; }
        }

        protected long _bankGovBalance = 0;
        public long BankGovBalance
        {
            get { return _bankGovBalance; }
        }

        protected long _bankGovBalanceOld = 0;
        public long BankGovBalanceOld
        {
            get { return _bankGovBalanceOld; }
        }

        protected long _bankTaxIncome = 0;
        public long BankTaxIncome
        {
            get { return _bankTaxIncome; }
        }

        protected long _bankTaxSale = 0;
        public long BankTaxSale
        {
            get { return _bankTaxSale; }
        }

        protected long _bankResearch = 0;
        public long BankResearch
        {
            get { return _bankResearch; }
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
            // This is a small fix to not count MSG_CityDistressReport messages with no report info.
            if (mail.Subject != "City Status Report")
                return;
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
            List<string> sectionsInReport = new List<string>();
            // This is the order of the sections in the mail body, keep them in same order!
            string[] sections = new string[] { "<b style=\"color: rgb(255, 255, 0);\">DISTRESS</b>"
                                             , "<b>DECAY</b>"
                                             , "<b>EVENT LOG</b>"
                                             , "<b>MORALE</b>"
                                             , "<b>POPULATION</b>"
                                             , "<b>LIVING CONDITIONS</b>"
                                             , "<b>POWER RESERVE</b>"
                                             , "<b>BANK ACTIVITY</b>"
                                             , "<b>RESEARCH AND DEVELOPMENT</b>"
                                             , "<b>PATENTS</b>"
                                             , "<b>SPACECRAFT MANUFACTURING POTENTIAL</b>"
                                             , "<b>SPACECRAFT</b>"
                                             , "<b>FACILITIES</b>"
                                             , "<b>VEHICLES</b>"
                                             , "<b>INVENTORY</b>"
                                             };
            // Check for sections.
            foreach (string section in sections)
                if (_mail.Body.Contains(section))
                    sectionsInReport.Add(section);

            // Time for City spicific things.
            bool decaying = false;
            int moraleChange = 0;
            int populationChange = 0;

            // City Resource Zone & Capital check
            {
                string tempSection = HHelper.CleanText(_mail.Body.Remove(_mail.Body.IndexOf(sectionsInReport[0])));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in tempArray)
                {
                    if (line.Contains("Resource Zone"))
                        _zone = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    else if (line == "Empire Capital City")
                        _empireCapital = true;
                }
            }

            //DISTRESS
            const string headlineDISTRESS = "<b style=\"color: rgb(255, 255, 0);\">DISTRESS</b>";
            if (sectionsInReport.Contains(headlineDISTRESS))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineDISTRESS));
                //tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _distressOverview = "[color=red]" + "Distress:" + Environment.NewLine + "  " + tempSection.Substring(("DISTRESS" + Environment.NewLine).Length).Replace(Environment.NewLine, Environment.NewLine + "  ") + "[/color]";
                decaying = tempSection.Contains("City is decaying.");
            }

            // DECAY
            const string headlineDECAY = "<b>DECAY</b>";
            if (sectionsInReport.Contains(headlineDECAY))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineDECAY));
                //tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _decayOverview = "[color=red]" + "Decay:" + Environment.NewLine + "  " + tempSection.Substring(("DECAY" + Environment.NewLine).Length).Replace(Environment.NewLine, Environment.NewLine + "  ") + "[/color]";
            }

            // EVENT LOG
            const string headlineEVENT = "<b>EVENT LOG</b>";
            if (sectionsInReport.Contains(headlineEVENT))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineEVENT));
                //tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _eventOverview += HCity.EventLogStyle(tempSection);
            }

            // MORALE & Abandonment
            const string headlineMORALE = "<b>MORALE</b>";
            if (sectionsInReport.Contains(headlineMORALE))
            {
                _moraleOverview = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineMORALE));
                tempArray = _moraleOverview.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _moraleColumn = tempArray[tempArray.Length - 1].Remove(tempArray[tempArray.Length - 1].Length - 1);
                _morale = Convert.ToInt32(_moraleColumn.Substring(_moraleColumn.LastIndexOf(' ') + 1));
                if (!_moraleColumn.Contains("remained steady"))
                {
                    int posA, posB;
                    posA = _moraleColumn.LastIndexOf(" by ") + 4;
                    posB = _moraleColumn.LastIndexOf(" to ");
                    moraleChange = Convert.ToInt32(_moraleColumn.Substring(posA, posB - posA));
                    if (_moraleColumn.Contains("decreased"))
                    {
                        moraleChange *= -1;
                        _moraleColumn = _morale.ToString().PadLeft(3) + " (decreased " + Math.Abs(moraleChange) + ")";
                    }
                    else
                        _moraleColumn = _morale.ToString().PadLeft(3) + " (increased " + moraleChange + ")";
                }
                else
                    _moraleColumn = _morale.ToString().PadLeft(3) + " (steady)";
                int abandonedDays = 0;
                int abandonedPenalty = 0;
                for (int i = 1; i < tempArray.Length - 1; i++)
                {
                    if (tempArray[i].Contains("Abandonment Penalty") || tempArray[i].StartsWith("Abandoned"))
                    {
                        if (tempArray[i].StartsWith("+") || tempArray[i].StartsWith("-"))
                        {
                            _moraleModifiers.Add(tempArray[i].Substring(tempArray[i].IndexOf(' ') + 1), Convert.ToInt32(tempArray[i].Remove(tempArray[i].IndexOf(' '))));
                            abandonedPenalty = Convert.ToInt32(tempArray[i].Remove(tempArray[i].IndexOf(' ')));
                        }
                        else
                            _moraleModifiers.Add(tempArray[i], 0);
                        int posA, posB;
                        posA = tempArray[i].LastIndexOf(" in ") + 4;
                        posB = tempArray[i].LastIndexOf(" days.");
                        abandonedDays = Convert.ToInt32(tempArray[i].Substring(posA, posB - posA));
                    }
                    else if (tempArray[i].StartsWith("Citizens are increasingly disloyal.") || tempArray[i].StartsWith("Citizens are rebellious."))
                    {
                        // "Citizens are increasingly disloyal. No Foxtail avatar or officer has visited this system in 17 days."
                        // "Citizens are rebellious. No Foxtail avatar or officer has visited this system in 21 days."
                        int posA, posB;
                        posA = tempArray[i].LastIndexOf(" in ") + 4;
                        posB = tempArray[i].LastIndexOf(" days.");
                        _neglect = Convert.ToInt32(tempArray[i].Substring(posA, posB - posA));
                    }
                    else
                        _moraleModifiers.Add(tempArray[i].Substring(tempArray[i].IndexOf(' ') + 1), Convert.ToInt32(tempArray[i].Remove(tempArray[i].IndexOf(' '))));
                    if (tempArray[i].Contains("Harsh Environment Penalty"))
                    {
                        _hashEnv = true;
                    }
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
                    _abandonmentColumn = _abandonment.ToString("00") + "~/" + _abandonmentMax.ToString("00") + " days";
                else if (_abandonment > 0)
                    _abandonmentColumn = _abandonment.ToString("00") + " /" + _abandonmentMax.ToString("00") + " days";
                else
                    _abandonmentColumn = " ERROR!?";
            }

            // POPULATION
            const string headlinePOPULATION = "<b>POPULATION</b>";
            if (sectionsInReport.Contains(headlinePOPULATION))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlinePOPULATION));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in tempArray)
                {
                    if (line.Contains("Citizens are"))
                    {
                        _race = line.Remove(line.Length - 1).Substring(13);
                    }
                    else if (line.Contains("Population") && !line.Contains("troops"))
                    {
                        _population = Convert.ToInt32(line.Remove(line.Length - 1).Substring(line.LastIndexOf(' ') + 1));
                        if (!line.Contains("remained steady"))
                        {
                            int posA, posB;
                            posA = line.LastIndexOf(" by ") + 4;
                            posB = line.LastIndexOf(" to ");
                            populationChange = Convert.ToInt32(line.Substring(posA, posB - posA));
                            if (line.Contains("decreased"))
                            {
                                populationChange *= -1;
                                _populationColumn = _population.ToString() + " (decreased " + Math.Abs(populationChange) + ")";
                            }
                            else
                                _populationColumn = _population.ToString() + " (increased " + populationChange + ")";
                        }
                        else
                            _populationColumn = _population.ToString() + " (steady)";
                    }
                    else if (line.Contains("Garrison"))
                    {
                        // Nothing yet
                    }
                    else if (line.Contains("arsh environment"))
                    {
                        _hashEnv = true;
                    }
                    else if (line.Contains("loyal"))
                    {
                        _loyalty = Convert.ToInt32(line.Remove(line.IndexOf(' ')));
                        if (line.Contains("disloyal"))
                            _loyalty = -_loyalty;
                        _loyaltyColumn = _loyalty + " (" + Math.Round(((double)_loyalty / _population) * 100, 2).ToString(Hazeron.NumberFormat) + "%)";
                    }
                }
            }

            // LIVING CONDITIONS
            const string headlineLIVING = "<b>LIVING CONDITIONS</b>";
            if (sectionsInReport.Contains(headlineLIVING))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineLIVING));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in tempArray)
                {
                    if (line.Contains("Jobs"))
                    {
                        _livingConditionsColumn = line;
                        _jobs = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Homes"))
                    {
                        _livingConditionsColumn += ", " + line;
                        _homes = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Apartments"))
                    {
                        _apartments = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Food"))
                    {
                        _food = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
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
                        _powerConsumption = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Reserve Power"))
                    {
                        _powerReserve = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    else if (line.Contains("Reserve Capacity"))
                    {
                        _powerReserveCapacity = Convert.ToInt32(line.Substring(line.LastIndexOf(' ') + 1));
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
                    else if (line == "Previous Tribute")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "").Replace(".", "");
                        _bankTribute = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Starting Balance")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "").Replace(".", "");
                        if (GovAcc)
                            _bankGovBalanceOld = Convert.ToInt64(line.Remove(line.Length - 1));
                        else
                            _bankCitBalanceOld = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Current Balance")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "").Replace(".", "");
                        if (GovAcc)
                            _bankGovBalance = Convert.ToInt64(line.Remove(line.Length - 1));
                        else
                            _bankCitBalance = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Income Tax")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "").Replace(".", "");
                        _bankTaxIncome = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Sales Tax")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "").Replace(".", "");
                        _bankTaxSale = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Bullion Production")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "").Replace(".", "");
                        _bankMinting = Convert.ToInt64(line.Remove(line.Length - 1));
                    }
                    else if (line == "Research and Development")
                    {
                        i++;
                        line = tempArray[i].Replace(",", "").Replace(".", "");
                        _bankResearch = Convert.ToInt64(line.Remove(line.Length - 1));
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
                        _researchProjects.Add(tempArray[i].Substring(9), Convert.ToInt32(tempArray[i + 1]));
                }
            }

            // PATENTS
            const string headlinePATENTS = "<b>PATENTS</b>";
            if (sectionsInReport.Contains(headlinePATENTS))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlinePATENTS));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 3; i < tempArray.Length; i++)
                {
                    const string PATENT_PREFIX = " ";
                    if (tempArray[i].StartsWith(PATENT_PREFIX))
                    {
                        int pos = tempArray[i].LastIndexOf(' ');
                        string patentName = tempArray[i].Substring(PATENT_PREFIX.Length, pos - PATENT_PREFIX.Length);
                        patentName = patentName.Remove(patentName.Length - 7);
                        int patentQuality = Convert.ToInt32(tempArray[i].Substring(pos + 2));
                        _researchPatents.Add(patentName, patentQuality);
                    }
                }
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
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineFACILITIES));
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 4; i < tempArray.Length; i += 3)
                {
                    if (tempArray[i] != "Name")
                    {
                        string name = tempArray[i].TrimStart();
                        int tl;
                        if (!Int32.TryParse(tempArray[i + 1], out tl))
                            tl = Convert.ToInt32(tempArray[i + 1].Split(new char[] { '-' })[1]) * -1; // Make negitive because it is not all buildings.
                        int levels = Convert.ToInt32(tempArray[i + 2]);
                        _factilitiesTL.Add(name, tl);
                        _factilitiesLV.Add(name, levels);
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
                string tempSection = GetSectionText(_mail.Body, sectionsInReport, headlineINVENTORY);
                if (_hashEnv && tempSection.Contains("Air"))
                {
                    tempSection = tempSection.Substring(tempSection.IndexOf("Air"));
                    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 1; i < tempArray.Length; i++)
                    {
                        if (tempArray[i].Contains(" Q"))
                            _air += Convert.ToInt32(tempArray[i].Remove(tempArray[i].IndexOf(' ')));
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
                _populationLimit = Convert.ToInt32(tempArray[tempArray.Length - 1].Replace(",", ""));
                _populationLimit = Convert.ToInt32(100 * Math.Floor((float)_populationLimit / 1800));
            }
            else
                _populationLimit = 1000;

            UpdateMoraleOverview(moraleChange);

            UpdatePopulationOverwiew(populationChange);

            UpdateTechnologyOverview();

            UpdatePatentsOverview();

            UpdateBuildingsOverview();

            UpdateDefencesOverview();

            UpdateBankOverview();

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
            if (_homes > _populationLimit) // Zone over populated.
                _attentions.Add(new AttentionMessage(1, "ColumnLivingConditions", "- Resource zone over populated." + Environment.NewLine + "  " + _populationLimit.ToString().PadLeft(4) + ", Limit" + Environment.NewLine + "  " + _homes.ToString().PadLeft(4) + ", Homes"));
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
            if (_population > _homes) // Homeless.
                _attentions.Add(new AttentionMessage(1, "ColumnPopulation", "- Homeless citizens." + Environment.NewLine + (_population - _homes).ToString().PadLeft(4) + ", Homeless"));
            if (_population > 1 && _morale < 0) // Morale is negative.
                _attentions.Add(new AttentionMessage(2, "ColumnMorale", "- Morale is negative!"));
            else if (_population > 1 && _morale < 20) // Morale not full.
                _attentions.Add(new AttentionMessage(1, "ColumnMorale", "- Morale not at maximum."));
            if (_population > 1 && _moraleModifiers.Values.Sum() < 1) // Morale not positive.
                _attentions.Add(new AttentionMessage(2, "ColumnMoraleModifiers", "- Morale modifiers are dangerously low."));
            if (_moraleModifiers.Keys.Any(x => x.EndsWith(" wanted."))) // Morale building wanted.
                _attentions.Add(new AttentionMessage(1, "ColumnMoraleModifiers", "- Missing morale building."));
            if (_population > 1 && _loyalty < 0) // Disloyal population.
                _attentions.Add(new AttentionMessage(2, "ColumnLoyalty", "- Disloyal citizens." + Environment.NewLine + "  Occupation under way, " + Math.Abs(_loyalty) + " still disloyal."));
            else if (_neglect > 0) // City feels neglected.
                _attentions.Add(new AttentionMessage(1, "ColumnLoyalty", "- City has been neglected." + Environment.NewLine + "  No visit from empire officer or avatar for " + _neglect + " days."));
            if (_population > 1 && !_factilitiesLV.ContainsKey("Bank")) // No bank.
                _attentions.Add(new AttentionMessage(1, "ColumnBank", "- City has no bank and is not collecting taxes."));

            base.Initialize();
        }

        protected void UpdateMoraleOverview(int moraleChange)
        {
            _moraleOverview = "City's morale:" + Environment.NewLine + "  ";
            if (_morale >= 0)
                _moraleOverview += "[color=green]";
            else
                _moraleOverview += "[color=red]";
            _moraleOverview += "Morale " + _morale.ToString().PadLeft(3) + "[/color]" + Environment.NewLine + "  ";
            if (moraleChange >= 0)
                _moraleOverview += "[color=green]";
            else
                _moraleOverview += "[color=red]";
            _moraleOverview += "Change  ";
            _moraleOverview += moraleChange.ToString("+#0;-#0;±#0") + "[/color]" + Environment.NewLine;
            _moraleOverview += Environment.NewLine;
            _moraleOverview += "City's morale modifiers:" + Environment.NewLine;
            foreach (KeyValuePair<string, int> moraleModifier in _moraleModifiers)
            {
                if (moraleModifier.Value > 0)
                    _moraleOverview += "  [color=green]";
                else
                    _moraleOverview += "  [color=red]";
                _moraleOverview += moraleModifier.Value.ToString("+#0;-#0") + "  " + moraleModifier.Key + "[/color]" + Environment.NewLine;
            }
            if (_moraleModifiers.Values.Sum() > 0)
                _moraleOverview += "[color=green]";
            else if (_moraleModifiers.Values.Sum() < 0)
                _moraleOverview += "[color=red]";
            _moraleOverview += "Total " + _moraleModifiers.Values.Sum().ToString("+#0;-#0;±#0");
            if (_moraleModifiers.Values.Sum() > 0 || _moraleModifiers.Values.Sum() < 0)
                _moraleOverview += "[/color]";
            _moraleModifiersColumn = _moraleModifiers.Values.Sum().ToString("+#0;-#0;±#0");
            _moraleModifiersColumn += " (" + Math.Abs(_moraleModifiers.Values.Where(y => y < 0).Sum()).ToString("-#0") + ", " + _moraleModifiers.Values.Where(y => y > 0).Sum().ToString("+#0") + ")";
        }

        protected void UpdatePopulationOverwiew(int populationChange)
        {
            const int populationPadding = 4;
            _populationOverview = "City's population:";
            _populationOverview += Environment.NewLine + " " + _loyalty.ToString().PadLeft(populationPadding) + ", Loyal citizens";
            if (_loyalty != _population)
            {
                if (Abandonment != AbandonmentMax) // Loyalty decreace when abandonment. 2016-01-01
                    _populationOverview += " [color=red](decreasing)[/color]";
                else
                {
                    int minutesToLoyal;
                    bool disloyal = _loyalty < 0;
                    if (!disloyal)
                        minutesToLoyal = ((_population - _loyalty) * 13);
                    else
                        minutesToLoyal = (Math.Abs(_loyalty) * 13);
                    _populationOverview += " [color=" + (disloyal ? "red" : "orange") + "](";
                    if (minutesToLoyal < 120) // Less than two hours.
                        _populationOverview += minutesToLoyal + " minutes";
                    else if (minutesToLoyal < 2980) // Less than two days.
                        _populationOverview += (minutesToLoyal / 60) + " hours";
                    else // More than two days.
                        _populationOverview += (minutesToLoyal / 1490) + " days";
                    _populationOverview += " to " + (disloyal ? "loyal" : "fully") + ")[/color]";
                }
            }
            //else
            //    _populationOverview += " [color=green](fully)[/color]";
            _populationOverview += Environment.NewLine + " " + _population.ToString().PadLeft(populationPadding) + ", Citizens";
            if (populationChange < 0)
                _populationOverview += " [color=red](decreased by " + Math.Abs(populationChange) + ")[/color]";
            else if (populationChange > 0)
                _populationOverview += " [color=green](increased by " + populationChange + ")[/color]";
            //else
            //    _populationOverview += " (steady)";
            _populationOverview += Environment.NewLine + " " + _homes.ToString().PadLeft(populationPadding) + ", Homes";
            if (_jobs >= _homes)
            {
                int needed = (_jobs - _homes + 1); // Need at least one more home than jobs.
                _populationOverview += " [color=red](Overworked, " + needed + " more homes needed)[/color]";
            }
            _populationOverview += Environment.NewLine + " " + _jobs.ToString().PadLeft(populationPadding) + ", Jobs";
            if (((float)(_homes - _jobs) / _homes) > 0.2)
            {
                int needed = (int)((_homes * 0.8) - _jobs + 1); // Need at least one more job than 80% homes.
                _populationOverview += " [color=red](Unemployment, " + needed + " more jobs needed)[/color]";
            }
            _populationOverview += Environment.NewLine + " " + _populationLimit.ToString().PadLeft(populationPadding) + ", Population limit";
            if (_homes > _populationLimit)
            {
                int needed = (_homes - _populationLimit);
                _populationOverview += " [color=red](Overpopulated, " + needed + " homes too many)[/color]";
            }
            _populationOverview += Environment.NewLine;
            _populationOverview += Environment.NewLine + "City's living conditions:";
            _populationOverview += Environment.NewLine + " Citizens are " + _race;
            {
                string powerUse = _powerConsumption.ToString("N", Hazeron.NumberFormat);
                string powerSto = _powerReserve.ToString("N", Hazeron.NumberFormat);
                int powerPadding = Math.Max(powerUse.Length, powerSto.Length);
                _populationOverview += Environment.NewLine + " " + powerUse.PadLeft(powerPadding) + " power comsumption";
                _populationOverview += Environment.NewLine + " " + powerSto.PadLeft(powerPadding) + "/" + _powerReserveCapacity.ToString("N", Hazeron.NumberFormat) + " power capacity (" + Math.Floor(((float)_powerReserve / _powerReserveCapacity) * 100) + "%)";
            }
            {
                _populationOverview += Environment.NewLine + " ";
                int minutesToStarvation = (_food);
                if (minutesToStarvation < 120) // Less than two hours.
                    _populationOverview += minutesToStarvation + " minutes";
                else if (minutesToStarvation < 2980) // Less than two days.
                    _populationOverview += (minutesToStarvation / 60) + " hours";
                else // More than two days.
                    _populationOverview += (minutesToStarvation / 1490) + " days";
                _populationOverview += " worth of food";
            }
            if (_hashEnv)
            {
                _populationOverview += Environment.NewLine + " ";
                int minutesToSuffocation = (_air);
                if (minutesToSuffocation < 120) // Less than two hours.
                    _populationOverview += minutesToSuffocation + " minutes";
                else if (minutesToSuffocation < 2980) // Less than two days.
                    _populationOverview += (minutesToSuffocation / 60) + " hours";
                else // More than two days.
                    _populationOverview += (minutesToSuffocation / 1490) + " days";
                _populationOverview += " worth of air";
            }
            {
                _populationOverview += Environment.NewLine + " " + Math.Floor(((float)_apartments / _homes) * 100) + "% apartments";
                int levelAjustment = ((_homes - _apartments) - _apartments);
                if ((levelAjustment / 4) > 0)
                    _populationOverview += " [color=green](" + (levelAjustment / 4) + " more levels possible)[/color]";
                else if (levelAjustment < 0)
                    _populationOverview += " [color=red](Cramped, " + Math.Abs(levelAjustment) + " more non-apartment homes needed)[/color]";
            }
        }

        protected void UpdateTechnologyOverview()
        {
            _technologyOverview += "City's technology levels:";
            List<string> buildingList;
            buildingList = _factilitiesTL.Keys.ToList();
            buildingList.Sort();
            foreach (string building in buildingList)
            {
                _technologyOverview += Environment.NewLine + " Q" + Math.Abs(_factilitiesTL[building]).ToString().PadLeft(3) + ", " + building;
                if (_factilitiesTL[building] < 0)
                    _technologyOverview += " [color=red](not all buildings)[/color]";
            }
        }

        protected void UpdatePatentsOverview()
        {
            if (_researchProjects.Count != 0)
            {
                _patentsOverview = "City's patent research:";
                foreach (string patent in _researchProjects.Keys)
                {
                    _patentsOverview += Environment.NewLine + " " + _researchProjects[patent].ToString().PadLeft(2) + " (Q" + (_researchPatents.ContainsKey(patent) ? _researchPatents[patent].ToString().PadLeft(3) : "  0") + ") running, " + patent;
                }
            }
            if (_patentsOverview != "")
                _patentsOverview += Environment.NewLine + Environment.NewLine;
            List<string> patentsList;
            patentsList = _researchPatents.Keys.ToList();
            patentsList.Sort();
            _patentsOverview += "City's patents:";
            foreach (string patent in patentsList)
            {
                _patentsOverview += Environment.NewLine + " Q" + Math.Abs(_researchPatents[patent]).ToString().PadLeft(3) + ", " + patent;
            }
        }

        protected void UpdateBuildingsOverview()
        {
            List<string> buildingList;
            _buildingsOverview = "City's buildings:";
            buildingList = _factilitiesLV.Keys.ToList();
            foreach (string moraleBuilding in Hazeron.MoraleBuildingsPop.Keys)
            {
                if (!_factilitiesLV.ContainsKey(moraleBuilding) && _homes >= Hazeron.MoraleBuildingsPop[moraleBuilding])
                    buildingList.Add(moraleBuilding);
            }
            if (!buildingList.Contains("Military Flag"))
                buildingList.Add("Military Flag");
            if (!buildingList.Contains("Cantina"))
                buildingList.Add("Cantina");
            if (!buildingList.Contains("Church"))
                buildingList.Add("Church");
            buildingList.Sort();
            foreach (string building in buildingList)
            {
                int levels = 0;
                if (_factilitiesLV.ContainsKey(building))
                    levels = _factilitiesLV[building];
                _buildingsOverview += Environment.NewLine + " " + levels.ToString().PadLeft(3) + " levels, " + building;
                if (Hazeron.MoraleBuildingsPop.ContainsKey(building))
                {
                    int levelsNeeded = _homes / Hazeron.MoraleBuildingsPop[building];
                    if (building == "Cantina")
                        levelsNeeded += 1;
                    else if (building == "Church")
                        levelsNeeded += 2;
                    if (levels < levelsNeeded)
                        _buildingsOverview += " [color=red](" + (levelsNeeded - levels) + " levels more needed)[/color]";
                    else if (levels > levelsNeeded && !(building == "Church" || building == "University" || building == "Park"))
                        _buildingsOverview += " [color=orange](" + (levels - levelsNeeded) + " levels too many)[/color]";
                }
                else if (building == "Military Flag")
                {
                    int levelsPossible = (_homes / 150) + 1;
                    if (levels > levelsPossible)
                        _buildingsOverview += " [color=red](" + (levels - levelsPossible) + " flags too many)[/color]";
                    else if (levels < levelsPossible)
                        _buildingsOverview += " [color=green](" + (levelsPossible - levels) + " flags more possible)[/color]";
                }
            }
        }

        protected void UpdateDefencesOverview()
        {
            int militaryFactilities = 0;
            int militaryFactilitiesLimit = 0;
            int sensorStregth = 0;
            int sensorTL = 0;
            _defencesOverview = "City's defensive buildings:";
            if (_factilitiesLV.ContainsKey("Airport Terminal"))
            {
                //_defencesOverview += Environment.NewLine + " " + "Airport Terminal";
                sensorStregth += (1 * _factilitiesLV["Airport Terminal"]);
                sensorTL = Math.Max(sensorTL, _factilitiesTL["Airport Terminal"]);
            }
            if (_factilitiesLV.ContainsKey("Military Guard Tower"))
            {
                _defencesOverview += Environment.NewLine + " " + _factilitiesLV["Military Guard Tower"].ToString().PadLeft(2) + ", TL" + _factilitiesTL["Military Guard Tower"].ToString().PadLeft(2) + " Military Guard Tower";
                militaryFactilities += _factilitiesLV["Military Guard Tower"];
            }
            if (_factilitiesLV.ContainsKey("Military Shield Generator"))
            {
                _defencesOverview += Environment.NewLine + " " + _factilitiesLV["Military Shield Generator"].ToString().PadLeft(2) + ", TL" + _factilitiesTL["Military Shield Generator"].ToString().PadLeft(2) + " Military Shield Generator";
                sensorStregth += (10 * _factilitiesLV["Military Shield Generator"]);
                sensorTL = Math.Max(sensorTL, _factilitiesTL["Military Shield Generator"]);
                militaryFactilities += _factilitiesLV["Military Shield Generator"];
            }
            if (_factilitiesLV.ContainsKey("Military Weapon System"))
            {
                _defencesOverview += Environment.NewLine + " " + _factilitiesLV["Military Weapon System"].ToString().PadLeft(2) + ", TL" + _factilitiesTL["Military Weapon System"].ToString().PadLeft(2) + " Military Weapon System";
                sensorStregth += (10 * _factilitiesLV["Military Weapon System"]);
                sensorTL = Math.Max(sensorTL, _factilitiesTL["Military Weapon System"]);
                militaryFactilities += _factilitiesLV["Military Weapon System"];
            }
            if (_factilitiesLV.ContainsKey("Military Flag"))
            {
                _defencesOverview += Environment.NewLine + " " + _factilitiesLV["Military Flag"].ToString().PadLeft(2) + ", Military Flag";
                militaryFactilitiesLimit = _factilitiesLV["Military Flag"] * 2;
            }
            _defencesOverview += Environment.NewLine + " Military factilities limit: " + militaryFactilities + "/" + militaryFactilitiesLimit;
            if (militaryFactilities > militaryFactilitiesLimit)
                _defencesOverview += " [color=red](Not enough military flags)[/color]";

            _defencesOverview += Environment.NewLine + Environment.NewLine + "System emission sensors:";
            _defencesOverview += Environment.NewLine + " " + sensorStregth.ToString().PadLeft(2) + ", Stregth";
            _defencesOverview += Environment.NewLine + " " + sensorTL.ToString().PadLeft(2) + ", TL";
        }

        protected void UpdateBankOverview()
        {
            _bankOverview = "City's finances:";
            if (_empireCapital && _bankTribute == 0)
            {
                _bankTributeColumn = "No tributing";
                _bankOverview += Environment.NewLine + "".PadLeft(Hazeron.CurrencyPadding) + "  Empire capital does not tribute";
            }
            else
            {
                _bankTributeColumn = _bankTribute.ToString("C", Hazeron.NumberFormat) + " tributed";
                _bankOverview += Environment.NewLine + " " + _bankTribute.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " tributed to ";
                if (_empireCapital)
                    _bankOverview += "(overlord/ally)";
                else
                    _bankOverview += "(empire/sector) capital";
            }
            {
                _bankOverview += Environment.NewLine + "".PadLeft(Hazeron.CurrencyPadding) + "  [color=green](";
                int minutesToMidnight = (int)(DateTime.UtcNow.Subtract(DateTime.Now.TimeOfDay).AddDays(1) - _lastUpdated).TotalMinutes;
                if (minutesToMidnight < 120) // Less than two hours.
                    _bankOverview += minutesToMidnight + " minutes";
                else // More than two hours.
                    _bankOverview += (minutesToMidnight / 60) + " hours";
                _bankOverview += " to next tribute)[/color]";
            }
            _bankOverview += Environment.NewLine;
            _bankOverview += Environment.NewLine + " " + _bankMinting.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " bullion production";
            _bankOverview += Environment.NewLine;
            _bankOverview += Environment.NewLine + " " + (_bankCitBalance - _bankCitBalanceOld).ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " citizen account net-change";
            _bankOverview += Environment.NewLine + " " + _bankCitBalance.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " citizen account balance";
            _bankOverview += Environment.NewLine;
            _bankOverview += Environment.NewLine + " " + _bankTaxIncome.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " income tax";
            _bankOverview += Environment.NewLine + " " + _bankTaxSale.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " Sales tax";
            _bankOverview += Environment.NewLine;
            _bankOverview += Environment.NewLine + " " + (-_bankResearch).ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " research expense";
            _bankOverview += Environment.NewLine;
            _bankOverview += Environment.NewLine + " " + (_bankGovBalance - _bankGovBalanceOld).ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " government account net-change";
            _bankOverview += Environment.NewLine + " " + _bankGovBalance.ToString("C", Hazeron.NumberFormat).PadLeft(Hazeron.CurrencyPadding) + " government account balance";
        }
    }
}
