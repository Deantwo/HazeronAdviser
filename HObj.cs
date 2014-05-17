using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    static class HMake
    {
        static public HObj Create(HMailObj mail)
        {
            if (HMail.IsCityReport(mail))
                return new HCityObj(mail);
            else if (HMail.IsShipLog(mail))
                return new HShipObj(mail);
            //else if (HMail.IsGovernmentMessage(mail))
            //    return new HGovMObj(mail); // To be made. <-----------------------------------
            else
                return null; // Hate doing it like this, but just don't use HMake.Create() on mails that aren't CityReport, ShipLog or GovernmentMessage. Or at the very lest check the resulte before using it.
        }
    }
    

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

        public virtual void Update(HMailObj mail)
        {
            _name = mail.From; // Incase sender changed name.
            _lastUpdated = mail.DateTime;

            // Full body test, used for debuging.
            _bodyTest = mail.Body;
        }

        // Full body test, used for debuging.
        protected string _bodyTest = "";
        public string BodyTest
        {
            get { return HHelper.CleanText(_bodyTest); }
        }
    }

    class HCityObj : HObj
    {
        protected string _moraleFull = "-", _moraleShort = "-";
        public string MoraleFull
        {
            get { return _moraleFull; }
        }
        public string MoraleShort
        {
            get { return _moraleShort; }
        }

        protected string _populationFull = "-", _populationShort = "-";
        public string PopulationFull
        {
            get { return _populationFull; }
        }
        public string PopulationShort
        {
            get { return _populationShort; }
        }

        protected string _livingFull = "-", _livingShort = "-";
        public string LivingFull
        {
            get { return _livingFull; }
        }
        public string LivingShort
        {
            get { return _livingShort; }
        }

        public HCityObj(HMailObj mail)
        {
            _id = mail.FilePath.Split('.')[mail.FilePath.Split('.').Length - 3];
            Update(mail);
        }

        public override void Update(HMailObj mail)
        {
            if (HMail.IsCityReport(mail.MailBytes) && DateTime.Compare(_lastUpdated, mail.DateTime) < 0)
            {
                base.Update(mail);

                // Time for City spicific things.
                int subStart, subEnd;
                string[] temp;

                if (mail.MessageType != 0x17 // MSG_CityFinalDecayReport
                    )
                {
                    subStart = mail.Body.IndexOf("<b>MORALE</b>");
                    subEnd = mail.Body.IndexOf("<b>POPULATION</b>") - subStart;
                    _moraleFull = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    temp = _moraleFull.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    _moraleShort = temp[temp.Length - 1];

                    subStart = mail.Body.IndexOf("<b>POPULATION</b>");
                    subEnd = mail.Body.IndexOf("<b>LIVING CONDITIONS</b>") - subStart;
                    _populationFull = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    //temp = _moraleFull.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //_populationShort = temp[temp.Length - 1];

                    subStart = mail.Body.IndexOf("<b>LIVING CONDITIONS</b>");
                    subEnd = mail.Body.IndexOf("<b>POWER RESERVE</b>") - subStart;
                    _livingFull = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    temp = _livingFull.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    _livingShort = temp[1] + ", " + temp[4];
                }
            }
        }

        public override bool Equals(object obj)
        {
            HObj e = obj as HObj;
            return e.ID == _id;
        }
        public override int  GetHashCode()
        {
            return Convert.ToInt32(_id);
        }
    }

    class HShipObj : HObj
    {
        protected string _damageFull = "-", _damageShort = "-";
        public string DamageFull
        {
            get { return _damageFull; }
        }
        public string DamageShort
        {
            get { return _damageShort; }
        }

        protected string _accountFull = "-", _accountShort = "-";
        public string AccountFull
        {
            get { return _accountFull; }
        }
        public string AccountShort
        {
            get { return _accountShort; }
        }

        protected string _fuelFull = "-", _fuelShort = "-";
        public string FuelFull
        {
            get { return _fuelFull; }
        }
        public string FuelShort
        {
            get { return _fuelShort; }
        }

        protected string _cargoFull = "-", _cargoShort = "-";
        public string CargoFull
        {
            get { return _cargoFull; }
        }
        public string CargoShort
        {
            get { return _cargoShort; }
        }

        protected string _missionFull = "-", _missionShort = "-";
        public string MissionFull
        {
            get { return _missionFull; }
        }
        public string MissionShort
        {
            get { return _missionShort; }
        }

        protected string _rosterFull = "-", _rosterShort = "-";
        public string RosterFull
        {
            get { return _rosterFull; }
        }
        public string RosterShort
        {
            get { return _rosterShort; }
        }

        public HShipObj(HMailObj mail)
        {
            _id = mail.FilePath.Split('.')[mail.FilePath.Split('.').Length - 3];
            Update(mail);
        }

        public override void Update(HMailObj mail)
        {
            if (HMail.IsShipLog(mail.MailBytes) && DateTime.Compare(_lastUpdated, mail.DateTime) < 0)
            {
                base.Update(mail);

                // Time for City spicific things.
                int subStart, subEnd;
                string[] temp;

                if (mail.MessageType != 0x12 // MSG_ShipLogFinal
                    )
                {
                    subStart = mail.Body.IndexOf("<b>DAMAGE REPORT</b>");
                    subEnd = mail.Body.IndexOf("<b>ACCOUNT</b>") - subStart;
                    _damageFull = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    //temp = _damageFull.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //_damageShort = temp[temp.Length - 1];

                    subStart = mail.Body.IndexOf("<b>ACCOUNT</b>");
                    subEnd = mail.Body.IndexOf("<b>FUEL</b>") - subStart;
                    _accountFull = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    //temp = _accountFull.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //_accountShort = temp[temp.Length - 1];

                    subStart = mail.Body.IndexOf("<b>FUEL</b>");
                    subEnd = mail.Body.IndexOf("<b>CARGO</b>") - subStart;
                    _fuelFull = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    temp = _fuelFull.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    _fuelShort = temp[1];

                    subStart = mail.Body.IndexOf("<b>CARGO</b>");
                    subEnd = mail.Body.IndexOf("<b>MISSION</b>") - subStart;
                    _cargoFull = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    //temp = _cargoFull.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //_cargoShort = temp[temp.Length - 1];

                    subStart = mail.Body.IndexOf("<b>MISSION</b>");
                    subEnd = mail.Body.IndexOf("<b>ROSTER</b>") - subStart;
                    _missionFull = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                    //temp = _missionFull.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //_missionShort = temp[temp.Length - 1];

                    subStart = mail.Body.IndexOf("<b>ROSTER</b>");
                    _rosterFull = HHelper.CleanText(mail.Body.Substring(subStart)); // All the way to the end.
                    //temp = _rosterFull.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //_rosterShort = temp[temp.Length - 1];
                }
            }
        }

        public override bool Equals(object obj)
        {
            HObj e = obj as HObj;
            return e.ID == _id;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(_id);
        }
    }

    class HOfficerObj : HObj
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

        public HOfficerObj(HMailObj mail)
        {
            _id = mail.FilePath.Split('.')[mail.FilePath.Split('.').Length - 3];
            Update(mail);
        }
        public override void Update(HMailObj mail)
        {
            if (HMail.IsOfficerTenFour(mail.MailBytes) && DateTime.Compare(_lastUpdated, mail.DateTime) < 0)
            {
                base.Update(mail);

                // Time for City spicific things.
                int subStart, subEnd;
                string[] temp;

                if (mail.MessageType == 0x0C // MSG_OfficerReady
                    )
                {
                    subStart = mail.Body.IndexOf("Assignment Request on ");
                    subEnd = mail.Body.IndexOf("<br><br>Commander,") - subStart;
                    _home = HHelper.CleanText(mail.Body.Substring(subStart, subEnd)).Replace("Assignment Request on ","");
                    _location = _home;
                }
            }
        }

        public override bool Equals(object obj)
        {
            HObj e = obj as HObj;
            return e.ID == _id;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(_id);
        }
    }
}
