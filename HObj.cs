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
                return LastUpdared.ToString("dd-MM-yyyy HH:mm:ss"); // TimeDate format information: http://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
            }
        }

        protected bool _info = false;
        protected bool _distress = false;

        protected byte _attentionCode = 0x00; // 0b00000000
        public byte AttentionCode
        {
            get { return _attentionCode; }
        }

        public virtual void Update(HMail mail)
        {
            _name = mail.From; // Incase sender changed name.
            _lastUpdated = mail.DateTime;
            _attentionCode = 0x00; // 0b00000000

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
        protected string _morale = "-", _moraleShort = "-";
        public string Morale
        {
            get { return _morale; }
        }
        public string MoraleShort
        {
            get { return _moraleShort; }
        }

        protected string _population = "-", _populationShort = "-";
        public string Population
        {
            get { return _population; }
        }
        public string PopulationShort
        {
            get { return _populationShort; }
        }

        protected string _livingConditions = "-", _livingConditionsShort = "-";
        public string Living
        {
            get { return _livingConditions; }
        }
        public string LivingShort
        {
            get { return _livingConditionsShort; }
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
                string[] temp;
                // Time for City spicific things.
                int morale, population, homes, jobs;
                int abandonment = 0;

                if (mail.MessageType != 0x17) // MSG_CityFinalDecayReport
                {
                    // MORALE
                    subStart = mail.Body.IndexOf("<b>MORALE</b>");
                    subEnd = mail.Body.IndexOf("<b>POPULATION</b>") - subStart;
                    _morale = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    temp = _morale.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    _moraleShort = temp[temp.Length - 1].Remove(temp[temp.Length - 1].Length - 1).Substring(7);
                    foreach (string line in temp)
                        if (line.Contains("Abandonment Penalty"))
                            abandonment = Convert.ToInt32(line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    temp = _moraleShort.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    morale = Convert.ToInt32(temp[temp.Length - 1]);

                    // POPULATION
                    subStart = mail.Body.IndexOf("<b>POPULATION</b>");
                    subEnd = mail.Body.IndexOf("<b>LIVING CONDITIONS</b>") - subStart;
                    _population = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    temp = _population.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    if (!temp[temp.Length - 1].Contains("loyal") || temp[temp.Length - 2].Contains("prevents immigration. Airport needed."))
                        _populationShort = temp[temp.Length - 1].Remove(temp[temp.Length - 1].Length - 1).Substring(11);
                    else
                        _populationShort = temp[temp.Length - 2].Remove(temp[temp.Length - 2].Length - 1).Substring(11);
                    temp = _populationShort.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    population = Convert.ToInt32(temp[temp.Length - 1]);

                    // LIVING CONDITIONS
                    subStart = mail.Body.IndexOf("<b>LIVING CONDITIONS</b>");
                    subEnd = mail.Body.IndexOf("<b>POWER RESERVE</b>") - subStart;
                    _livingConditions = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    temp = _livingConditions.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    _livingConditionsShort = temp[1] + ", " + temp[4];
                    jobs = Convert.ToInt32(temp[1].Split(' ')[1]);
                    homes = Convert.ToInt32(temp[4].Split(' ')[1]);
                    
                    // AttentionCodes
                    if ((jobs >= homes) || (((float)(homes - jobs) / homes) > 0.2)) // More jobs than homes, or too many unemployed.
                        _attentionCode = (byte)(_attentionCode | 0x01); // 0b00000001
                    if (population < homes) // Population not full.
                        _attentionCode = (byte)(_attentionCode | 0x02); // 0b00000010
                    if (-4 >= abandonment) // There is -4 abandonment.
                        _attentionCode = (byte)(_attentionCode | 0x04); // 0b00000100
                    if (-7 >= abandonment) // There is -7 abandonment.
                        _attentionCode = (byte)(_attentionCode | 0x08); // 0b00001000
                    if (false) // Nothing yet!
                        _attentionCode = (byte)(_attentionCode | 0x10); // 0b00010000
                    if (population == 0) // Population is 0.
                        _attentionCode = (byte)(_attentionCode | 0x20); // 0b00100000
                    if (morale < 20) // Morale not full.
                        _attentionCode = (byte)(_attentionCode | 0x40); // 0b01000000
                    if (mail.MessageType == 0x17) // MSG_CityFinalDecayReport
                        _attentionCode = (byte)(_attentionCode | 0x80); // 0b10000000
                }
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
                string[] temp;

                if (mail.MessageType != 0x12) // MSG_ShipLogFinal
                {
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
                    temp = _fuel.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    _fuelShort = temp[1];

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
                }

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
                if (mail.MessageType == 0x12) // MSG_ShipLogFinal
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
                string[] temp;

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
                    _location = "ship name";
                }

                // AttentionCodes
                if (_location != _home) // MSG_OfficerReady
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
                if (mail.MessageType == 0x16) // MSG_OfficerDeath
                    _attentionCode = (byte)(_attentionCode | 0x80); // 0b10000000

            }
        }
    }
}
