using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HObj
    {
        public static string EventLogStyle(string log)
        {
            log = log.Replace("EVENT LOG", "Event Log:");
            log = log.Replace("Time" + Environment.NewLine + "Note", "Time               Note");
            while (log.Contains(Environment.NewLine + "UTC:"))
            {
                int utcIndex = log.IndexOf(Environment.NewLine + "UTC:") + Environment.NewLine.Length;
                log = log.Remove(utcIndex) + HMail.DecodeUTC(log.Substring(utcIndex, 12)).ToString("F", Hazeron.DateTimeFormat) + "   " + log.Substring(utcIndex + 12 + Environment.NewLine.Length);
            }
            log = log.Replace(Environment.NewLine, Environment.NewLine + "  ");
            log = log.Replace(". ", "." + Environment.NewLine + "                     ");
            log = log.Replace("! ", "!" + Environment.NewLine + "                     ");
            log = log.Replace("? ", "?" + Environment.NewLine + "                     ");
            return log;
        }

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

        /// <summary>
        /// Compare current mail with new mail,
        /// ignore mail content if timestamp is older than current report.
        /// </summary>
        /// <param name="mail">New mail to compare with.</param>
        public virtual void CompareMail(HMail mail)
        {
            if (!_owners.Contains(mail.RecipientID))
                _owners.Add(mail.RecipientID);

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

        protected string GetSectionText(List<string> reportSecions, string headline)
        {
            int subStart, subEnd;
            subStart = _mail.Body.IndexOf(headline);
            int index = reportSecions.IndexOf(headline) + 1;
            if (reportSecions.Count != index)
                subEnd = _mail.Body.IndexOf(reportSecions[index], subStart) - subStart;
            else
                subEnd = _mail.Body.Length - subStart;
            return _mail.Body.Substring(subStart, subEnd);
        }

        protected string GetSectionText(Dictionary<string, int> reportSecions, string headline)
        {
            int subStart, subEnd;
            subStart = reportSecions[headline];
            subEnd = reportSecions.Values.OrderBy(x => x).FirstOrDefault(x => x > subStart);
            if (subEnd != 0)
                subEnd = subEnd - subStart;
            else
                subEnd = _mail.Body.Length - subStart;
            return _mail.Body.Substring(subStart, subEnd);
        }

        protected bool TryGetSectionText(Dictionary<string, int> reportSecions, string headline, out string reportSection)
        {
            try
            {
                if (reportSecions != null && reportSecions.ContainsKey(headline))
                {
                    reportSection = GetSectionText(reportSecions, headline);
                    return true;
                }
                else
                {
                    reportSection = null;
                    return false;
                }
            }
            catch
            {
                reportSection = null;
                return false;
            }
        }

        public virtual void Initialize()
        {
            _initialized = true;
        }

        public override string ToString()
        {
            return _name;
        }
    }    

    class HOfficer : HObj
    {
        protected string _homeSystem = "-";
        public string HomeSystem
        {
            get { return _homeSystem; }
        }
        protected string _homePlanet = "-";
        public string HomePlanet
        {
            get { return _homePlanet; }
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
                _homeSystem = _systemName;
                //subStart = _mail.Body.IndexOf("Assignment Request on ") + 22; // "Assignment Request on ".Length == 22
                //subEnd = _mail.Body.IndexOf("<br><br>Commander,") - subStart;
                //_homePlanet = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
                _homePlanet = _planetName;
                _ship = "";
            }
            else if (_mail.MessageType == 0x14) // MSG_OfficerContact
            {
                _homeSystem = "<system name>";
                subStart = _mail.Body.IndexOf("I was deployed from ") + 20; // "I was deployed from ".Length == 20
                subEnd = _mail.Body.Substring(subStart).IndexOf(" in ");
                _homePlanet = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
                _ship = "<ship name>";
            }

            // Overview
            _overview = "Location:" + Environment.NewLine;
            _overview += "  " + _systemName + Environment.NewLine;
            _overview += "  " + _planetName + Environment.NewLine;
            _overview += Environment.NewLine;
            _overview += "Officer:" + Environment.NewLine;
            _overview += "  " + _name + Environment.NewLine;
            _overview += Environment.NewLine;
            _overview += "Officer Home:" + Environment.NewLine;
            _overview += "  " + _homeSystem;
            _overview += "  " + _homePlanet;
            if (_mail.MessageType == 0x14) // MSG_OfficerContact
            {
                _overview += Environment.NewLine + Environment.NewLine;
                _overview += "Stationed ship:" + Environment.NewLine;
                _overview += "  " + _ship;
            }

            // AttentionCodes
            if (_mail.MessageType == 0x14) // MSG_OfficerContact
                _attentionCode = (byte)(_attentionCode | 0x01); // 0b00000001

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
                List<string> sectionsInReport = new List<string>();
                // This is the order of the sections in the mail body, keep them in same order!
                string[] sections = new string[] { "<b>SPACECRAFT DESTROYED</b>"
                                                 , "<b>EVENT LOG</b>"
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
                subStart = _mail.Body.IndexOf("<p>") + 3; // "<p>".Length == 3
                subEnd = _mail.Body.Substring(subStart).IndexOf("<div style");
                string officerName = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));
                string officerHomeSystem = "<system name>";
                subStart = _mail.Body.IndexOf("I was deployed from ") + 20; // "I was deployed from ".Length == 20
                subEnd = _mail.Body.Substring(subStart).IndexOf(" in ");
                string officerHomePlanet = HHelper.CleanText(_mail.Body.Substring(subStart, subEnd));

                string shipDestruction = "";
                string shipEvent = "";

                // Check for sections.
                foreach (string section in sections)
                    if (_mail.Body.Contains(section))
                        sectionsInReport.Add(section);

                // SPACECRAFT DESTROYED
                const string headlineSPACECRAFTDESTROYED = "<b>SPACECRAFT DESTROYED</b>";
                if (sectionsInReport.Contains(headlineSPACECRAFTDESTROYED))
                {
                    shipDestruction = HHelper.CleanText(GetSectionText(sectionsInReport, headlineSPACECRAFTDESTROYED));
                    shipDestruction = shipDestruction.Substring(("SPACECRAFT DESTROYED" + Environment.NewLine).Length);
                    shipDestruction = shipDestruction.Replace(Environment.NewLine, Environment.NewLine + "  ");
                    shipDestruction = shipDestruction.Replace(". ", "." + Environment.NewLine + "  ");
                    shipDestruction = shipDestruction.Replace("! ", "!" + Environment.NewLine + "  ");
                    shipDestruction = shipDestruction.Replace("? ", "?" + Environment.NewLine + "  ");
                }

                // EVENT LOG
                const string headlineEVENT = "<b>EVENT LOG</b>";
                if (sectionsInReport.Contains(headlineEVENT))
                {
                    shipEvent = HEvent.EventLogStyle(HHelper.CleanText(GetSectionText(sectionsInReport, headlineEVENT)));
                }

                // Overview
                _overview = "Location:" + Environment.NewLine;
                _overview += "  " + _systemName + Environment.NewLine;
                _overview += "  " + _planetName + Environment.NewLine;
                _overview += Environment.NewLine;
                _overview += "Ship:" + Environment.NewLine;
                _overview += "  " + _name + Environment.NewLine;
                _overview += Environment.NewLine;
                _overview += "Officer:" + Environment.NewLine;
                _overview += "  " + officerName + Environment.NewLine;
                _overview += Environment.NewLine;
                _overview += "Officer Home:" + Environment.NewLine;
                _overview += "  " + officerHomeSystem + Environment.NewLine;
                _overview += "  " + officerHomePlanet + Environment.NewLine;
                _overview += Environment.NewLine;
                _overview += "[color=red]Cause of destruction:" + Environment.NewLine;
                _overview += "  " + shipDestruction + "[/color]" + Environment.NewLine;
                if (shipEvent != "")
                {
                    _overview += Environment.NewLine;
                    _overview += shipEvent;
                }
            }
            else if (_messageType == 0x13) // MSG_Government
            {
                if (_name == "State Department")
                {
                    string tempSection = HHelper.CleanText(_mail.Body);
                    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    string empireName = tempArray[tempArray.Length - 6].Substring(4);
                    string empireEncounter = tempArray[tempArray.Length - 4];
                    string empireStance = tempArray[tempArray.Length - 3];

                    _overview = "Location:" + Environment.NewLine;
                    _overview += "  " + _systemName + Environment.NewLine;
                    _overview += "  " + _planetName + Environment.NewLine;
                    _overview += Environment.NewLine;
                    _overview += "Empire:" + Environment.NewLine;
                    if (Hazeron.PirateEmpires.Contains(empireName))
                        _overview += "  [color=red]" + empireName + " (NPC pirate empire)[/color]" + Environment.NewLine;
                    else
                        _overview += "  " + empireName + Environment.NewLine;
                    _overview += Environment.NewLine;
                    _overview += "Encounter:" + Environment.NewLine;
                    _overview += "  " + empireEncounter + Environment.NewLine;
                    _overview += Environment.NewLine;
                    _overview += "Stance taken:" + Environment.NewLine;
                    if (!empireStance.Contains("competitive"))
                        _overview += "  " + empireStance + Environment.NewLine;
                    else
                        _overview += "  [color=red]" + empireStance + "[/color]" + Environment.NewLine;
                }
                else if (_name == "War Department")
                {
                    // ?
                }
                else if (_name == "Treasury Department")
                {
                    // Levy Tax?
                }
            }
            else if (_messageType == 0x16) // MSG_OfficerDeath
            {
                string officerHomeSystem = "<system name>";
                string officerHomePlanet = "<planet name>";
                string tempSection = HHelper.CleanText(_mail.Body);
                tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string officerDeath = tempArray[tempArray.Length - 3];
                officerDeath = officerDeath.Replace(". ", "." + Environment.NewLine + "  ");
                officerDeath = officerDeath.Replace("! ", "!" + Environment.NewLine + "  ");
                officerDeath = officerDeath.Replace("? ", "?" + Environment.NewLine + "  ");

                _overview = "Location:" + Environment.NewLine;
                _overview += "  " + _systemName + Environment.NewLine;
                _overview += "  " + _planetName + Environment.NewLine;
                _overview += Environment.NewLine;
                _overview += "Officer:" + Environment.NewLine;
                _overview += "  " + _name + Environment.NewLine;
                _overview += Environment.NewLine;
                _overview += "Officer Home:" + Environment.NewLine;
                _overview += "  " + officerHomeSystem + Environment.NewLine;
                _overview += "  " + officerHomePlanet + Environment.NewLine;
                _overview += Environment.NewLine;
                _overview += "[color=red]Cause of death:" + Environment.NewLine;
                _overview += "  " + officerDeath + "[/color]";
            }
            else if (_messageType == 0x17) // MSG_CityFinalDecayReport
            {
                // ?
            }
            //else if (_messageType == 0x18) // MSG_DiplomaticMessage
            //{
            //    string tempSection = HHelper.CleanText(_mail.Body);
            //    tempArray = tempSection.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //    string diplomat = tempArray[tempArray.Length - 2];
            //    diplomat = diplomat.Remove(diplomat.IndexOf(" has asked"));
            //    string diplomaticMessage = tempArray[tempArray.Length - 1];
            //    diplomaticMessage = diplomaticMessage.Replace(". ", "." + Environment.NewLine + "  ");
            //    diplomaticMessage = diplomaticMessage.Replace("! ", "!" + Environment.NewLine + "  ");
            //    diplomaticMessage = diplomaticMessage.Replace("? ", "?" + Environment.NewLine + "  ");
            //
            //    _overview = "Location:" + Environment.NewLine;
            //    _overview += "  " + _systemName + Environment.NewLine;
            //    _overview += "  " + _planetName + Environment.NewLine;
            //    _overview += Environment.NewLine;
            //    _overview += "Diplomat:" + Environment.NewLine;
            //    _overview += "  " + diplomat + Environment.NewLine;
            //    _overview += Environment.NewLine;
            //    _overview += "Diplomatic Message:" + Environment.NewLine;
            //    _overview += "  " + diplomaticMessage;
            //}

            // AttentionCodes
            if (_messageType == 0x05) // MSG_CityIntelligenceReport
                _attentionCode = (byte)(_attentionCode | 0x08); // 0b00001000
            if (_messageType == 0x03 || _messageType == 0x12 || _messageType == 0x16 || _messageType == 0x17) // MSG_CityOccupationReport, MSG_ShipLogFinal, MSG_OfficerDeath or MSG_CityFinalDecayReport
                _attentionCode = (byte)(_attentionCode | 0x80); // 0b10000000

            base.Initialize();
        }
    }
}
