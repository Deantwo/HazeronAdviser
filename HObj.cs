using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HObj
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

        protected bool _flagInfo = false;
        protected bool _flagDistress = false;

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

        public virtual void Update(HMail mail)
        {
            _name = mail.From; // Incase sender changed name.
            _lastUpdated = mail.DateTime;
            _attentionCode = 0x00; // 0b00000000

            int tempOwner = mail.RecipientID;
            if (!_owners.Contains(tempOwner))
                _owners.Add(tempOwner);

            // Full body test, mostly used for debuging.
            _body = mail.Body;
        }

        // Full body test, mostly used for debuging.
        protected string _body = "";
        public string BodyTest
        {
            get { return HHelper.CleanText(_body); }
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

        protected string _sLivingConditions = "-", _sLivingConditionsShort = "-";
        public string SLiving
        {
            get { return _sLivingConditions; }
        }
        public string SLivingShort
        {
            get { return _sLivingConditionsShort; }
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

        public HCity(HMail mail)
        {
            _id = HHelper.ToID(mail.SenderID);
            Update(mail);
        }

        public override void Update(HMail mail)
        {
            if (HMail.IsCityReport(mail.MailBytes) && DateTime.Compare(_lastUpdated, mail.DateTime) < 0)
            {
                base.Update(mail);

                // String working vars.
                int subStart, subEnd;
                string[] tempArray;
                // Time for City spicific things.
                int dDay = 0;
                int dDayMax = 0;
                const int abandonmentInterval = 4;

                //INFO
                //if (mail.MessageType == 0x06 && mail.Body.Contains("<b>EVENT LOG</b>")) // MSG_CityStatusReportInfo
                //{
                //    subStart = mail.Body.IndexOf("<b>EVENT LOG</b>");
                //    subEnd = mail.Body.IndexOf("<b>MORALE</b>") - subStart;
                //    _info = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                //}

                //DISTRESS
                //if (mail.MessageType == 0x04 && mail.Body.Contains("<b style=\"color: rgb(255, 255, 0);\">DISTRESS</b>") // MSG_CityDistressReport
                //{
                //    subStart = mail.Body.IndexOf("<b style=\"color: rgb(255, 255, 0);\">DISTRESS</b>");
                //    if (mail.Body.Contains("<b>DECAY</b>"))
                //        subEnd = mail.Body.IndexOf("<b>DECAY</b>") - subStart;
                //    else
                //        subEnd = mail.Body.IndexOf("<b>MORALE</b>") - subStart;
                //    _distress = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                //}

                // MORALE
                subStart = mail.Body.IndexOf("<b>MORALE</b>");
                subEnd = mail.Body.IndexOf("<b>POPULATION</b>") - subStart;
                _sMorale = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                tempArray = _sMorale.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _sMoraleShort = tempArray[tempArray.Length - 1].Remove(tempArray[tempArray.Length - 1].Length - 1).Substring(7);
                int abandonedDays = 0;
                int abandonedPenalty = 0;
                _vMoraleModifiers.Clear();
                foreach (string line in tempArray)
                    if (!line.ToLower().Contains("morale"))
                    {
                        string[] tempLineArray = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        _vMoraleModifiers.Add(Convert.ToInt32(tempLineArray[0]));
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
                tempArray = _sMoraleShort.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                _vMorale = Convert.ToInt32(tempArray[tempArray.Length - 1]);

                // POPULATION
                subStart = mail.Body.IndexOf("<b>POPULATION</b>");
                subEnd = mail.Body.IndexOf("<b>LIVING CONDITIONS</b>") - subStart;
                _sPopulation = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                tempArray = _sPopulation.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                if (!tempArray[tempArray.Length - 1].Contains("loyal") || tempArray[tempArray.Length - 2].Contains("prevents immigration. Airport needed."))
                    _sPopulationShort = tempArray[tempArray.Length - 1].Remove(tempArray[tempArray.Length - 1].Length - 1).Substring(11);
                else
                    _sPopulationShort = tempArray[tempArray.Length - 2].Remove(tempArray[tempArray.Length - 2].Length - 1).Substring(11);
                tempArray = _sPopulationShort.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                _vPopulation = Convert.ToInt32(tempArray[tempArray.Length - 1]);
                tempArray = _sPopulation.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _sLoyalty = tempArray[tempArray.Length - 1];
                if (_sLoyalty.Contains("loyal"))
                {
                    tempArray = _sLoyalty.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    _vLoyalty = Convert.ToInt32(tempArray[0]);
                    if (_sLoyalty.Contains("disloyal"))
                    {
                        _vLoyalty = -_vLoyalty;
                        _sLoyalty = "-" + _sLoyalty;
                    }
                    _sLoyalty = _sLoyalty.Remove(_sLoyalty.Length - 11);
                }
                else
                    _sLoyalty = "-";

                // LIVING CONDITIONS
                subStart = mail.Body.IndexOf("<b>LIVING CONDITIONS</b>");
                subEnd = mail.Body.IndexOf("<b>POWER RESERVE</b>") - subStart;
                _sLivingConditions = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                tempArray = _sLivingConditions.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in tempArray)
                {
                    if (line.Remove(4) == "Jobs")
                    {
                        _sLivingConditionsShort = line;
                        _vJobs = Convert.ToInt32(line.Split(' ')[1]);
                    }
                    if (line.Remove(5) == "Homes")
                    {
                        _sLivingConditionsShort += ", " + line;
                        _vHomes = Convert.ToInt32(line.Split(' ')[1]);
                    }
                }

                // Planet Size
                if (!mail.Body.Contains("Ringworld Arc"))
                {
                    subStart = mail.Body.IndexOf("m dia, ");
                    tempArray = mail.Body.Remove(subStart).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    _vPopulationLimit = Convert.ToInt32(tempArray[tempArray.Length - 1].Replace(",", ""));
                    _vPopulationLimit = Convert.ToInt32(100 * Math.Floor((float)_vPopulationLimit / 1800));
                }
                else
                    _vPopulationLimit = 1000;

                // AttentionCodes
                if ((_vJobs >= _vHomes) || (((float)(_vHomes - _vJobs) / _vHomes) > 0.2)) // More jobs than homes, or too many unemployed.
                    _attentionCode = (byte)(_attentionCode | 0x01); // 0b00000001
                if (_vPopulation < _vHomes || _vPopulation > _vHomes) // Population not full, or more than full.
                    _attentionCode = (byte)(_attentionCode | 0x02); // 0b00000010
                if (12 > dDay) // Less than 12 days to decay.
                    _attentionCode = (byte)(_attentionCode | 0x04); // 0b00000100
                if (4 >= dDay) // Less than 4 days to decay.
                    _attentionCode = (byte)(_attentionCode | 0x08); // 0b00001000
                if (_vPopulation == 0 || _vPopulation >= _vPopulationLimit) // Population is 0, or zone over populated!
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

    class HShip : HObj
    {
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
        {
            _id = HHelper.ToID(mail.SenderID);
            Update(mail);
        }

        public override void Update(HMail mail)
        {
            if (HMail.IsShipLog(mail.MailBytes) && DateTime.Compare(_lastUpdated, mail.DateTime) < 0)
            {
                base.Update(mail);

                // String working vars.
                int subStart, subEnd;
                string[] tempArray;

                // DAMAGE REPORT
                subStart = mail.Body.IndexOf("<b>DAMAGE REPORT</b>");
                subEnd = mail.Body.IndexOf("<b>ACCOUNT</b>") - subStart;
                _damage = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                //temp = _damage.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_damageShort = temp[temp.Length - 1];

                // ACCOUNT
                subStart = mail.Body.IndexOf("<b>ACCOUNT</b>");
                subEnd = mail.Body.IndexOf("<b>FUEL</b>") - subStart;
                _account = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                //temp = _account.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_accountShort = temp[temp.Length - 1];

                // FUEL
                subStart = mail.Body.IndexOf("<b>FUEL</b>");
                subEnd = mail.Body.IndexOf("<b>CARGO</b>") - subStart;
                _fuel = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                tempArray = _fuel.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _fuelShort = tempArray[1];

                // CARGO
                subStart = mail.Body.IndexOf("<b>CARGO</b>");
                subEnd = mail.Body.IndexOf("<b>MISSION</b>") - subStart;
                _cargo = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                //temp = _cargo.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_cargoShort = temp[temp.Length - 1];

                // MISSION
                subStart = mail.Body.IndexOf("<b>MISSION</b>");
                subEnd = mail.Body.IndexOf("<b>ROSTER</b>") - subStart;
                _mission = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                //temp = _mission.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_missionShort = temp[temp.Length - 1];

                // ROSTER
                subStart = mail.Body.IndexOf("<b>ROSTER</b>");
                _roster = HHelper.CleanText(mail.Body.Substring(subStart)); // All the way to the end.
                //temp = _roster.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //_rosterShort = temp[temp.Length - 1];

                // Officer Info
                //// Name
                subStart = mail.Body.IndexOf("<p>") + 3; // "<p>".Length == 3
                subEnd = mail.Body.Substring(subStart).IndexOf("<div style");
                _officerName = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                //// Home
                subStart = mail.Body.IndexOf("I was deployed from ") + 20; // "I was deployed from ".Length == 20
                subEnd = mail.Body.Substring(subStart).IndexOf(" in ");
                _officerHome = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));

                // AttentionCodes
                if (false) // Nothing yet!
                    _attentionCode = (byte)(_attentionCode | 0x08); // 0b00000001
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
        {
            _id = HHelper.ToID(mail.SenderID);
            Update(mail);
        }

        public override void Update(HMail mail)
        {
            if (HMail.IsOfficerTenFour(mail.MailBytes) && DateTime.Compare(_lastUpdated, mail.DateTime) < 0)
            {
                base.Update(mail);

                // String working vars.
                int subStart, subEnd;
                string[] tempArray;

                if (mail.MessageType == 0x0C) // MSG_OfficerReady
                {
                    subStart = mail.Body.IndexOf("Assignment Request on ") + 22; // "Assignment Request on ".Length == 22
                    subEnd = mail.Body.IndexOf("<br><br>Commander,") - subStart;
                    _home = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    _location = _home;
                }
                else if (mail.MessageType == 0x14) // MSG_OfficerContact
                {
                    subStart = mail.Body.IndexOf("I was deployed from ") + 20; // "I was deployed from ".Length == 20
                    subEnd = mail.Body.Substring(subStart).IndexOf(" in ");
                    _home = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    _location = "\"ship name\"";
                }

                // AttentionCodes
                if (mail.MessageType == 0x14) // MSG_OfficerContact
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
        {
            _id = HHelper.ToID(mail.SenderID);
            Update(mail);
        }

        public override void Update(HMail mail)
        {
            //if (HMail.IsOfficerTenFour(mail.MailBytes) && DateTime.Compare(_lastUpdated, mail.DateTime) < 0)
            //{
                base.Update(mail);

                // String working vars.
                int subStart, subEnd;
                string[] tempArray;

                _messageId = mail.MessageID;
                _subject = mail.Subject;
                _messageType = mail.MessageType;
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

            //}
        }
    }
}
