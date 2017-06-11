using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HShip : HObj
    {
        protected string _abandonmentColumn = "-";
        public string AbandonmentColumn
        {
            get { return _abandonmentColumn; }
        }

        protected int _abandonment = 0;
        public int Abandonment
        {
            get { return _abandonment; }
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
            List<string> sectionsInReport = new List<string>();
            // This is the order of the sections in the mail body, keep them in same order!
            string[] sections = new string[] { "<b>EVENT LOG</b>"
                                             , "<b>DAMAGE REPORT</b>"
                                             , "<b>ACCOUNT</b>"
                                             , "<b>FUEL</b>"
                                             , "<b>CARGO</b>"
                                             , "<b>MISSION</b>"
                                             , "<b>ROSTER</b>"
                                             };
            // Check for sections.
            foreach (string section in sections)
                if (_mail.Body.Contains(section))
                    sectionsInReport.Add(section);

            // Time for Ship spicific things.

            // EVENT LOG
            const string headlineEVENT = "<b>EVENT LOG</b>";
            if (sectionsInReport.Contains(headlineEVENT))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineEVENT));
                //tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _eventOverview = HShip.EventLogStyle(tempSection);
            }

            // Decay
            if (!_mail.Body.Contains("I miss my home; "))
            {
                subStart = _mail.Body.IndexOf("Commander,") + 10; // "Commander,".Length == 10
                subEnd = _mail.Body.Substring(subStart).IndexOf("I was deployed from ");
                string crewMorale = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
                _abandonment = 7;
                switch (crewMorale)
                {
                    case "The crew has high spirits. Every day seems filled with anticipation.":
                        _abandonment *= 4;
                        break;
                    case "More than a week has passed since we were last hailed by command. The crew is quiet, intent on their work as they attend to their duties.":
                        _abandonment *= 3;
                        break;
                    case "More than two weeks have passed since we last heard from command. There have been some tense confrontations between the crew members.":
                        _abandonment *= 2;
                        break;
                    case "More than three weeks have passed since we lost contact with command. Some of the crew have become surly and insubordinate. Fighting among them is a daily occurance.":
                        _abandonment *= 1;
                        break;
                }
                _abandonmentColumn = (_abandonment / 7) + " /4 weeks";
            }
            else
            {
                subStart = _mail.Body.IndexOf("I miss my home; it's been ") + 26; // "I miss my home; it's been ".Length == 26
                subEnd = _mail.Body.Substring(subStart).IndexOf(" days since I last heard from my family.");
                _abandonment = 7 - Convert.ToInt32(_mail.Body.Substring(subStart, subEnd));
                _abandonmentColumn = " " + _abandonment + " /7 days";
            }

            // DAMAGE REPORT
            const string headlineDAMAGE = "<b>DAMAGE REPORT</b>";
            if (sectionsInReport.Contains(headlineDAMAGE))
            {
                _damageOverview = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineDAMAGE));
                tempArray = _damageOverview.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _damageColumn = tempArray[tempArray.Length - 1];
            }
            else
                _damageColumn = "All Systems Ok";

            // ACCOUNT
            const string headlineACCOUNT = "<b>ACCOUNT</b>";
            if (sectionsInReport.Contains(headlineACCOUNT))
            {
                _accountOverview = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineACCOUNT));
                tempArray = _accountOverview.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _accountColumn = tempArray[1].Remove(tempArray[1].IndexOf('¢') + 1).Replace(',', '\'').Replace('.', '\'');
                _accountBalance = Convert.ToInt64(_accountColumn.Remove(_accountColumn.IndexOf('¢')).Replace("'", ""));
                _accountColumn = _accountBalance.ToString("C", Hazeron.NumberFormat);
            }

            // FUEL
            const string headlineFUEL = "<b>FUEL</b>";
            if (sectionsInReport.Contains(headlineFUEL))
            {
                string tempString = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineFUEL));
                tempString = tempString.Substring(16);
                _fuelColumn = tempString.Remove(tempString.IndexOf(Environment.NewLine) - 11);
                tempArray = _fuelColumn.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                _fuel = Convert.ToInt32(tempArray[0]);
                _fuelCapacity = Convert.ToInt32(tempArray[tempArray.Length - 1]);
                _fuelQuality = Convert.ToInt32(tempArray[1].Substring(1));
            }

            // CARGO
            const string headlineCARGO = "<b>CARGO</b>";
            if (sectionsInReport.Contains(headlineCARGO))
            {
                _cargoOverview = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineCARGO));
                //tempArray = _cargoOverview.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_cargoColumn = tempArray[tempArray.Length - 1];
            }

            // MISSION
            const string headlineMISSION = "<b>MISSION</b>";
            if (sectionsInReport.Contains(headlineMISSION))
            {
                _missionOverview = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineMISSION));
                //tempArray = _missionOverview.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_missionColumn = tempArray[tempArray.Length - 1];
            }

            // ROSTER
            const string headlineROSTER = "<b>ROSTER</b>";
            if (sectionsInReport.Contains(headlineROSTER))
            {
                _rosterOverview = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineROSTER));
                //tempArray = _rosterOverview.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
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
            _officerOverview += "  " + _officerHomeSystem;
            _officerOverview += "  " + _officerHomePlanet;
            _officerOverview += Environment.NewLine + Environment.NewLine;
            _officerOverview += "Stationed ship:" + Environment.NewLine;
            _officerOverview += "  " + _name;

            // Overview
            _overview = "Location:" + Environment.NewLine;
            _overview += "  " + _systemName + Environment.NewLine;
            _overview += "  " + _planetName + Environment.NewLine;
            if (_eventOverview != "")
                _overview += Environment.NewLine + _eventOverview;

            // Attentions
            if (_abandonment < 7) // Less than 1 week until decay.
                _attentions.Add(new AttentionMessage(3, "ColumnAbandonment", "- Homesick." + Environment.NewLine + "  Suicide happen in " + _abandonment.ToString() + " days."));
            else if (_abandonment <= 7) // 1 weeks until decay.
                _attentions.Add(new AttentionMessage(2, "ColumnAbandonment", "- Abandonment." + Environment.NewLine + "  Mutiny happen in " + (_abandonment / 7).ToString() + " weeks."));
            else if (_abandonment <= 14) // 2 weeks until decay.
                _attentions.Add(new AttentionMessage(1, "ColumnAbandonment", "- Abandonment." + Environment.NewLine + "  Mutiny happen in " + (_abandonment / 7).ToString() + " weeks."));
            if ((_fuel / (double)_fuelCapacity) <= 0.05 || _fuel <= 50) // No fuel.
                _attentions.Add(new AttentionMessage(2, "ColumnFuel", "- No fuel." + Environment.NewLine + "  " + Math.Round(_fuel / (double)_fuelCapacity * 100, 2).ToString() + "% fuel remaining."));
            else if ((_fuel / (double)_fuelCapacity) <= 0.25) // Low fuel.
                _attentions.Add(new AttentionMessage(1, "ColumnFuel", "- Low fuel." + Environment.NewLine + "  " + Math.Round(_fuel / (double)_fuelCapacity * 100, 2).ToString() + "% fuel remaining."));

            base.Initialize();
        }
    }
}
