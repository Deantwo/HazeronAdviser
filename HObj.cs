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

        protected string _planetName = "-"; // Name of the sender's planet, may not be present.
        public string PlanetName
        {
            get { return _planetName; }
        }
        protected int _planetId = 0; // ID of the sender's planet, may not be present.
        public int PlanetID
        {
            get { return _planetId; }
        }

        protected string _overview = "";
        public string Overview
        {
            get { return _overview; }
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
                return LastUpdared.ToString("F", Hazeron.DateTimeFormat);
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
        public HMail Mail
        {
            get { return _mail; }
        }
        public string MailBody
        {
            get { return HHelper.CleanText(_mail.Body); }
        }

        protected bool _initialized = false;
        public bool Initialized
        {
            get { return _initialized; }
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

                _planetId = mail.PlanetID; // Incase ships or officers change system.
                _planetName = mail.PlanetName; // Incase city's system's name is changed.

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

        public virtual void Initialize()
        {
            _initialized = true;
        }
    }

    class HShip : HObj
    {
        protected string _abandonmentColumn = "-";
        public string AbandonmentColumn
        {
            get { return _abandonmentColumn; }
        }

        protected string _damageOverview = "-";
        public string DamageOverview
        {
            get { return _damageOverview; }
        }

        protected string _damageColumn = "-";
        public string DamageColumn
        {
            get { return _damageColumn; }
        }

        protected string _accountOverview = "-";
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

        protected string _fuelOverview = "-";
        public string FuelOverview
        {
            get { return _fuelOverview; }
        }

        protected string _fuelColumn = "-";
        public string FuelColumn
        {
            get { return _fuelColumn; }
        }

        protected string _cargoOverview = "-";
        public string CargoOverview
        {
            get { return _cargoOverview; }
        }

        protected string _cargoColumn = "-";
        public string CargoColumn
        {
            get { return _cargoColumn; }
        }

        protected string _missionOverview = "-";
        public string MissionOverview
        {
            get { return _missionOverview; }
        }

        protected string _missionColumn = "-";
        public string MissionColumn
        {
            get { return _missionColumn; }
        }

        protected string _rosterOverview = "-";
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
        protected string _officerHome = "-";
        public string OfficerHome
        {
            get { return _officerHome; }
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

            // EVENT LOG
            const string headlineEVENT = "<b>EVENT LOG</b>";
            if (sectionsInReport.Contains(headlineEVENT))
            {
                string tempSection = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineEVENT));
                //tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _overview = tempSection;
            }

            // Decay
            subStart = _mail.Body.IndexOf("Commander,") + 10; // "I was deployed from ".Length == 20
            subEnd = _mail.Body.Substring(subStart).IndexOf("I was deployed from ");
            string crewMorale = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
            int dWeek = 0;
            switch (crewMorale)
            {
                case "The crew has high spirits. Every day seems filled with anticipation.":
                    dWeek = 4;
                    break;
                case "More than a week has passed since we were last hailed by command. The crew is quiet, intent on their work as they attend to their duties.":
                    dWeek = 3;
                    break;
                case "?":
                    dWeek = 2;
                    break;
                case "??":
                    dWeek = 1;
                    break;
            }
#if CrewMoraleTest
            if (dWeek > 2)
                _abandonmentColumn = dWeek + " /4 weeks";
            else
            {
                // Debug code. Need to learn the other messages to check for!
                tempArray = _mail.FilePath.Split(new char[] { '\\' });
                _abandonmentColumn = tempArray[tempArray.Length - 1];
            }
#else
            _Abandonment = dDay + " /4 weeks";
#endif

            // DAMAGE REPORT
            const string headlineDAMAGE = "<b>DAMAGE REPORT</b>";
            if (sectionsInReport.Contains(headlineDAMAGE))
            {
                _damageOverview = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineDAMAGE));
                //tempArray = _damageOverview.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_damageColumn = tempArray[temp.Length - 1];
            }

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
                _fuelOverview = HHelper.CleanText(GetSectionText(_mail.Body, sectionsInReport, headlineFUEL));
                tempArray = _fuelOverview.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _fuelColumn = tempArray[1];
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
            subStart = _mail.Body.IndexOf("I was deployed from ") + 20; // "I was deployed from ".Length == 20
            subEnd = _mail.Body.Substring(subStart).IndexOf(" in ");
            _officerHome = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd)) + ", (system name unavailable)"; // Need to swap system name and planet name once I actually get the system name.

            // Overview
            _overview = _accountOverview;
            _overview += Environment.NewLine;
            _overview += Environment.NewLine;
            _overview += _cargoOverview;

            // AttentionCodes
            if (dWeek == 2) // 2 weeks until decay.
                _attentionCode = (byte)(_attentionCode | 0x08); // 0b00000001
            if (dWeek == 1) // 1 weeks until decay.
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

            base.Initialize();
        }
    }

    class HOfficer : HObj
    {
        protected string _home = "-";
        public string Home
        {
            get { return _home; }
        }

        protected string _ship = "-";
        public string Ship
        {
            get { return _ship; }
        }

        public HOfficer(HMail mail)
            : base(mail)
        {
            _id = mail.SenderID;
            CompareMail(mail);
        }

        public override void Initialize()
        {
            // String working vars.
            int subStart, subEnd;
            string[] tempArray;

            if (_mail.MessageType == 0x0C) // MSG_OfficerReady
            {
                //subStart = _mail.Body.IndexOf("Assignment Request on ") + 22; // "Assignment Request on ".Length == 22
                //subEnd = _mail.Body.IndexOf("<br><br>Commander,") - subStart;
                //_home = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
                _home = _planetName + ", " + _systemName;
                _ship = "";
            }
            else if (_mail.MessageType == 0x14) // MSG_OfficerContact
            {
                subStart = _mail.Body.IndexOf("I was deployed from ") + 20; // "I was deployed from ".Length == 20
                subEnd = _mail.Body.Substring(subStart).IndexOf(" in ");
                _home = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd)) + ", (system name unavailable)";
                _ship = "(ship name unavailable)";
            }

            // Overview
            _overview = "WIP";

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

            base.Initialize();
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

        public override void Initialize()
        {
            // String working vars.
            int subStart, subEnd;
            string[] tempArray;

            _messageId = _mail.MessageID;
            _subject = _mail.Subject;
            _messageType = _mail.MessageType;

            if (_messageType == 0x03) // MSG_CityOccupationReport
            {
                // ?
            }
            if (_messageType == 0x05) // MSG_CityIntelligenceReport
            {
                // ?
            }
            else if (_messageType == 0x12) // MSG_ShipLogFinal
            {
                // ?
            }
            else if (_messageType == 0x13) // MSG_Government
            {
                // ?
            }
            else if (_messageType == 0x16) // MSG_OfficerDeath
            {
                string tempSection = HHelper.CleanText(_mail.Body);
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                _overview = "Location:" + Environment.NewLine;
                _overview += "  " + _systemName + Environment.NewLine;
                _overview += "  " + _planetName + Environment.NewLine;
                _overview += Environment.NewLine;
                _overview += "[color=red]Cause of death:" + Environment.NewLine;
                _overview += "  " + tempArray[tempArray.Length - 3].Replace(". ", "." + Environment.NewLine + "  ") + "[/color]";
            }
            else if (_messageType == 0x17) // MSG_CityFinalDecayReport
            {
                // ?
            }
            else if (_messageType == 0x18) // MSG_DiplomaticMessage
            {
                // ?
            }

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

            base.Initialize();
        }
    }
}
