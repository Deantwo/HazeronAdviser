using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HShip : HObj
    {
        protected string _homesicknessColumn = "-";
        public string HomesicknessColumn
        {
            get { return _homesicknessColumn; }
        }

        protected int _homesickness = 100;
        public int Homesickness
        {
            get { return _homesickness; }
        }

        protected string _damageOverview = "";
        public string DamageOverview
        {
            get { return _damageOverview; }
        }

        protected string _damageColumn = "-";
        public string DamageColumn
        {
            get { return _damageColumn; }
        }

        protected string _accountOverview = "";
        public string AccountOverview
        {
            get { return _accountOverview; }
        }

        protected string _accountColumn = "-";
        public string AccountColumn
        {
            get { return _accountColumn; }
        }

        protected long _accountBalance = 0;
        public long AccountBalance
        {
            get { return _accountBalance; }
        }

        protected string _fuelColumn = "-";
        public string FuelColumn
        {
            get { return _fuelColumn; }
        }

        protected int _fuel = 0, _fuelCapacity = 0, _fuelQuality;
        public int Fuel
        {
            get { return _fuel; }
        }
        public int FuelCapacity
        {
            get { return _fuelCapacity; }
        }
        public int FuelQuality
        {
            get { return _fuelQuality; }
        }

        protected string _cargoOverview = "";
        public string CargoOverview
        {
            get { return _cargoOverview; }
        }

        protected string _cargoColumn = "-";
        public string CargoColumn
        {
            get { return _cargoColumn; }
        }

        protected int _cargo = 0, _cargoCapacity = 0;
        public int Cargo
        {
            get { return _cargo; }
        }
        public int CargoCapacity
        {
            get { return _cargoCapacity; }
        }

        protected string _missionOverview = "";
        public string MissionOverview
        {
            get { return _missionOverview; }
        }

        protected string _missionColumn = "-";
        public string MissionColumn
        {
            get { return _missionColumn; }
        }

        protected string _rosterOverview = "";
        public string RosterOverview
        {
            get { return _rosterOverview; }
        }

        protected string _rosterColumn = "-";
        public string RosterColumn
        {
            get { return _rosterColumn; }
        }

        protected string _officerName = "-";
        public string OfficerName
        {
            get { return _officerName; }
        }
        protected string _officerHomeSystem = "-";
        public string OfficerHomeSystem
        {
            get { return _officerHomeSystem; }
        }
        protected string _officerHomePlanet = "-";
        public string OfficerHomePlanet
        {
            get { return _officerHomePlanet; }
        }

        protected string _eventOverview = "";
        public string EventOverview
        {
            get { return _eventOverview; }
        }

        protected string _officerOverview = "";
        public string OfficerOverview
        {
            get { return _officerOverview; }
        }

        protected List<AttentionMessage> _attentions = new List<AttentionMessage>();
        public List<AttentionMessage> Attentions
        {
            get { return _attentions; }
        }

        public HShip(HMail mail)
            : base(mail)
        {
        }

        public override void Initialize()
        {
            // String working vars.
            int subStart, subEnd;
            string[] tempArray;
            Dictionary<string, int> sectionsInReport = new Dictionary<string, int>();
            string reportSection;
            // This is the order of the sections in the mail body, keep them in same order!
            const string headlineEVENT = "<b>EVENT LOG</b>";
            const string headlineDAMAGE = "<b>DAMAGE REPORT</b>";
            const string headlineACCOUNT = "<b>ACCOUNT</b>";
            const string headlineFUEL = "<b>FUEL</b>";
            const string headlineCARGO = "<b>CARGO</b>";
            const string headlineMISSION = "<b>MISSION</b>";
            const string headlineROSTER = "<b>ROSTER</b>";
            string[] sections = new string[] { headlineEVENT
                                             , headlineDAMAGE
                                             , headlineACCOUNT
                                             , headlineFUEL
                                             , headlineCARGO
                                             , headlineMISSION
                                             , headlineROSTER
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

            // Time for Ship spicific things.

            // Homesickness
            if (_mail.Body.Contains("I miss my home; "))
            {
                subStart = _mail.Body.IndexOf("I miss my home; it's been ") + 26; // "I miss my home; it's been ".Length == 26
                subEnd = _mail.Body.Substring(subStart).IndexOf(" days since I last heard from my family.");
                _homesickness = 7 - Convert.ToInt32(_mail.Body.Substring(subStart, subEnd));
                _homesicknessColumn = " " + _homesickness + " /7 days";
            }

            // EVENT LOG
            if (TryGetSectionText(sectionsInReport, headlineEVENT, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                //tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _eventOverview = HShip.EventLogStyle(reportSection);
            }

            // DAMAGE REPORT
            if (TryGetSectionText(sectionsInReport, headlineDAMAGE, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                _damageOverview = reportSection;
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _damageColumn = tempArray[tempArray.Length - 1];
            }
            else
                _damageColumn = "All Systems Ok";

            // ACCOUNT
            if (TryGetSectionText(sectionsInReport, headlineACCOUNT, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                _accountOverview = reportSection;
                tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _accountColumn = tempArray[1].Remove(tempArray[1].IndexOf('¢') + 1).Replace(',', '\'').Replace('.', '\'');
                _accountBalance = Convert.ToInt64(_accountColumn.Remove(_accountColumn.IndexOf('¢')).Replace("'", ""));
                _accountColumn = _accountBalance.ToString("C", Hazeron.NumberFormat);
            }

            // FUEL
            if (TryGetSectionText(sectionsInReport, headlineFUEL, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                reportSection = reportSection.Substring(16);
                _fuelColumn = reportSection.Remove(reportSection.IndexOf(Environment.NewLine) - 11);
                tempArray = _fuelColumn.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                _fuel = Convert.ToInt32(tempArray[0]);
                _fuelCapacity = Convert.ToInt32(tempArray[tempArray.Length - 1]);
                _fuelQuality = Convert.ToInt32(tempArray[1].Substring(1));
            }

            // CARGO
            if (TryGetSectionText(sectionsInReport, headlineCARGO, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                _cargoOverview = reportSection;
                //tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_cargoColumn = tempArray[tempArray.Length - 1];
            }

            // MISSION
            if (TryGetSectionText(sectionsInReport, headlineMISSION, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                _missionOverview = reportSection;
                //tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_missionColumn = tempArray[tempArray.Length - 1];
            }

            // ROSTER
            if (TryGetSectionText(sectionsInReport, headlineROSTER, out reportSection))
            {
                reportSection = HHelper.CleanText(reportSection);
                _rosterOverview = reportSection;
                //tempArray = reportSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_rosterColumn = tempArray[tempArray.Length - 1];
            }

            // Officer Info
            //// Name
            subStart = _mail.Body.IndexOf("<p>") + 3; // "<p>".Length == 3
            subEnd = _mail.Body.Substring(subStart).IndexOf("<div style");
            _officerName = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
            //// Home
            _officerHomeSystem = "<system name>";
            subStart = _mail.Body.IndexOf("I was deployed from ") + 20; // "I was deployed from ".Length == 20
            subEnd = _mail.Body.Substring(subStart).IndexOf(" in ");
            _officerHomePlanet = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));

            // Officer Overview
            _officerOverview = "Location:" + Environment.NewLine;
            _officerOverview += "  " + _systemName + Environment.NewLine;
            _officerOverview += "  " + _planetName + Environment.NewLine;
            _officerOverview += Environment.NewLine;
            _officerOverview += "Officer:" + Environment.NewLine;
            _officerOverview += "  " + _officerName + Environment.NewLine;
            _officerOverview += Environment.NewLine;
            _officerOverview += "Officer Home:" + Environment.NewLine;
            _officerOverview += "  " + _officerHomeSystem + Environment.NewLine;
            _officerOverview += "  " + _officerHomePlanet + Environment.NewLine;
            _officerOverview += Environment.NewLine;
            _officerOverview += "Stationed ship:" + Environment.NewLine;
            _officerOverview += "  " + _name;

            // Overview
            _overview = "Location:" + Environment.NewLine;
            _overview += "  " + _systemName + Environment.NewLine;
            _overview += "  " + _planetName + Environment.NewLine;
            if (_eventOverview != "")
                _overview += Environment.NewLine + _eventOverview;

            // Attentions
            if (_homesickness < 7) // Less than 1 week until decay.
                _attentions.Add(new AttentionMessage(3, "ColumnAbandonment", "- Homesick." + Environment.NewLine + "  Suicide happen in " + _homesickness.ToString() + " days."));
            if ((_fuel / (double)_fuelCapacity) <= 0.05 || _fuel <= 50) // No fuel.
                _attentions.Add(new AttentionMessage(2, "ColumnFuel", "- No fuel." + Environment.NewLine + "  " + Math.Round(_fuel / (double)_fuelCapacity * 100, 2).ToString() + "% fuel remaining."));
            else if ((_fuel / (double)_fuelCapacity) <= 0.25) // Low fuel.
                _attentions.Add(new AttentionMessage(1, "ColumnFuel", "- Low fuel." + Environment.NewLine + "  " + Math.Round(_fuel / (double)_fuelCapacity * 100, 2).ToString() + "% fuel remaining."));

            base.Initialize();
        }
    }
}
