using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HazeronAdviser
{
    static class HMail
    {
        static public byte[] Read(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        static public bool IsCityReport(int messageType) // Give true if MessageType is a City Report (or related) mail.
        {
            if (   messageType == 0x01 // MSG_CityStatusReport
                || messageType == 0x03 // MSG_CityOccupationReport
                || messageType == 0x04 // MSG_CityDistressReport
                || messageType == 0x05 // MSG_CityIntelligenceReport
                || messageType == 0x06 // MSG_CityStatusReportInfo
                || messageType == 0x17 // MSG_CityFinalDecayReport
                )
                return true;
            return false;
        }
        static public bool IsCityReport(HMailObj mail) // Same as above but mail input.
        {
            return IsCityReport(mail.MessageType);
        }
        static public bool IsCityReport(byte[] mailBytes) // Same as above but mailBytes input.
        {
            return IsCityReport(mailBytes[19 + HHelper.ToInt32(mailBytes, 15) + 9]);
        }
        static public bool IsCityReport(string filePath) // Same as above but filePath input.
        {
            return IsCityReport(HMail.Read(filePath));
        }

        static public bool IsShipLog(int messageType) // Give true if MessageType is a Ship Log (or related) mail.
        {
            if (   messageType == 0x0F // MSG_ShipLog
                || messageType == 0x10 // MSG_ShipLogAlert
                || messageType == 0x11 // MSG_ShipLogDistress
                || messageType == 0x12 // MSG_ShipLogFinal
                )
                return true;
            return false;
        }
        static public bool IsShipLog(HMailObj mail) // Same as above but mail input.
        {
            return IsShipLog(mail.MessageType);
        }
        static public bool IsShipLog(byte[] mailBytes) // Same as above but mailBytes input.
        {
            return IsShipLog(mailBytes[19 + HHelper.ToInt32(mailBytes, 15) + 9]);
        }
        static public bool IsShipLog(string filePath) // Same as above but filePath input.
        {
            return IsShipLog(HMail.Read(filePath));
        }

        static public bool IsGovernmentMessage(int messageType) // Give true if MessageType is a Government (or related) mail.
        {
            if (   messageType == 0x13 // MSG_Government
                || messageType == 0x18 // MSG_DiplomaticMessage
                )
                return true;
            return false;
        }
        static public bool IsGovernmentMessage(HMailObj mail) // Same as above but mail input.
        {
            return IsGovernmentMessage(mail.MessageType);
        }
        static public bool IsGovernmentMessage(byte[] mailBytes) // Same as above but mailBytes input.
        {
            return IsGovernmentMessage(mailBytes[19 + HHelper.ToInt32(mailBytes, 15) + 9]);
        }
        static public bool IsGovernmentMessage(string filePath) // Same as above but filePath input.
        {
            return IsGovernmentMessage(HMail.Read(filePath));
        }

        static public bool IsOfficerTenFour(int messageType) // Give true if MessageType is a OfficerUpdate (or related) mail.
        {
            if (   messageType == 0x0C // MSG_OfficerReady
                || messageType == 0x14 // MSG_OfficerContact
                || messageType == 0x16 // MSG_OfficerDeath
                )
                return true;
            return false;
        }
        static public bool IsOfficerTenFour(HMailObj mail) // Same as above but mail input.
        {
            return IsOfficerTenFour(mail.MessageType);
        }
        static public bool IsOfficerTenFour(byte[] mailBytes) // Same as above but mailBytes input.
        {
            return IsOfficerTenFour(mailBytes[19 + HHelper.ToInt32(mailBytes, 15) + 9]);
        }
        static public bool IsOfficerTenFour(string filePath) // Same as above but filePath input.
        {
            return IsOfficerTenFour(HMail.Read(filePath));
        }

        static public bool IsShipReport(int messageType) // Give true if MessageType is a ShipReport (or related) mail.
        {
            if (   messageType == 0x15 // MSG_ShipReport
                )
                return true;
            return false;
        }
        static public bool IsShipReport(HMailObj mail) // Same as above but mail input.
        {
            return IsShipReport(mail.MessageType);
        }
        static public bool IsShipReport(byte[] mailBytes) // Same as above but mailBytes input.
        {
            return IsShipReport(mailBytes[19 + HHelper.ToInt32(mailBytes, 15) + 9]);
        }
        static public bool IsShipReport(string filePath) // Same as above but filePath input.
        {
            return IsShipReport(HMail.Read(filePath));
        }
    }

    class HMailObj
    {
        // Anr's mail header info sheet: http://goo.gl/E0yoYd

        protected string _filePath;
        public string FilePath
        {
            get { return _filePath; }
        }
        protected byte[] _mailBytes;
        public byte[] MailBytes
        {
            get { return _mailBytes; }
        }

        public byte[] Signature
        {
            get { return HHelper.SubArray(_mailBytes, 0, 2); }
        }
        public int MessageID
        {
            get { return HHelper.ToInt32(_mailBytes, 2); }
        }

        public int Date
        {
            get { return HHelper.ToInt32(_mailBytes, 6); }
        }
        public int Time
        {
            get { return HHelper.ToInt32(_mailBytes, 10); }
        }
        public DateTime DateTime
        {
            get
            { // http://mikearnett.wordpress.com/2011/09/13/c-convert-julian-date/
                long L = Date + 68569;
                long N = (long)((4 * L) / 146097);
                L = L - ((long)((146097 * N + 3) / 4));
                long I = (long)((4000 * (L + 1) / 1461001));
                L = L - (long)((1461 * I) / 4) + 31;
                long J = (long)((80 * L) / 2447);
                int Day = (int)(L - (long)((2447 * J) / 80));
                L = (long)(J / 11);
                int Month = (int)(J + 2 - 12 * L);
                int Year = (int)(100 * (N - 49) + I + L);
                return new DateTime(Year, Month, Day).Add(TimeSpan.FromMilliseconds(Time));
            }
        }
        public string DateTimeString
        {
            get
            {
                return DateTime.ToString("dd-MM-yyyy HH:mm:ss"); // TimeDate format information: http://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
            }
        }
        public byte TimeZone
        {
            get { return _mailBytes[13]; }
        }

        protected int _from_l;
        public string From
        {
            get { return HHelper.ToBigEndianUnicodeString(_mailBytes, 19, _from_l); }
        }
        public int SenderID
        {
            get { return HHelper.ToInt32(_mailBytes, 19 + _from_l); }
        }
        public int RecipientID
        {
            get { return HHelper.ToInt32(_mailBytes, 19 + _from_l + 4); }
        }

        public int MessageFlags
        {
            get { return _mailBytes[19 + _from_l + 8]; }
        }
        public bool MessageFlags_Syst
        {
            get { return HHelper.FlagCheck(this.MessageFlags, 0x01); }
        }
        public bool MessageFlags_Plan
        {
            get { return HHelper.FlagCheck(this.MessageFlags, 0x02); }
        }
        public bool MessageFlags_GPS
        {
            get { return HHelper.FlagCheck(this.MessageFlags, 0x04); }
        }

        public int MessageType
        {
            get { return _mailBytes[19 + _from_l + 9]; }
        }

        protected int _subj_l, _body_l;
        public string Subject
        {
            get { return HHelper.ToBigEndianUnicodeString(_mailBytes, 19 + _from_l + 14, _subj_l); }
        }
        public string Body
        {
            get { return HHelper.ToBigEndianUnicodeString(_mailBytes, 19 + _from_l + 14 + _subj_l + 4, _body_l); }
        }

        protected int _syst_l, _systSkipOffset = 0;
        public int SystemID
        {
            get
            {
                if (this.MessageFlags_Syst)
                    return HHelper.ToInt32(_mailBytes, 19 + _from_l + 14 + _subj_l + 4 + _body_l + 1);
                else
                    return 0;
            }
        }
        public string SystemName
        {
            get
            {
                if (this.MessageFlags_Syst)
                    return HHelper.ToBigEndianUnicodeString(_mailBytes, 19 + _from_l + 14 + _subj_l + 4 + _body_l + 9, _syst_l);
                else
                    return "-";
            }
        }

        protected int _plan_l, _planSkipOffset = 0;
        public int PlanetID
        {
            get
            {
                if (this.MessageFlags_Plan)
                    return HHelper.ToInt32(_mailBytes, 19 + _from_l + 14 + _subj_l + 4 + _body_l + 1 + _systSkipOffset);
                else
                    return 0;
            }
        }
        public string PlanetName
        {
            get
            {
                if (this.MessageFlags_Plan)
                    return HHelper.ToBigEndianUnicodeString(_mailBytes, 19 + _from_l + 14 + _subj_l + 4 + _body_l + 1 + _systSkipOffset + 8, _plan_l);
                else
                    return "-";
            }
        }

        public float GPS_X
        {
            get
            {
                if (this.MessageFlags_GPS)
                    return HHelper.ToFloat(_mailBytes, 19 + _from_l + 14 + _subj_l + 4 + _body_l + 1 + _systSkipOffset + _planSkipOffset);
                else
                    return 0;
            }
        }
        public float GPS_Y
        {
            get
            {
                if (this.MessageFlags_GPS)
                    return HHelper.ToFloat(_mailBytes, 19 + _from_l + 14 + _subj_l + 4 + _body_l + 1 + _systSkipOffset + _planSkipOffset + 4);
                else
                    return 0;
            }
        }
        public float GPS_Z
        {
            get
            {
                if (this.MessageFlags_GPS)
                    return HHelper.ToFloat(_mailBytes, 19 + _from_l + 14 + _subj_l + 4 + _body_l + 1 + _systSkipOffset + _planSkipOffset + 8);
                else
                    return 0;
            }
        }
        public int GPS_W
        {
            get
            {
                if (this.MessageFlags_GPS)
                    return _mailBytes[19 + _from_l + 14 + _subj_l + 4 + _body_l + 1 + _systSkipOffset + _planSkipOffset + 12];
                else
                    return 0;
            }
        }

        public HMailObj(string filePath)
        {
            _filePath = filePath;
            _mailBytes = HMail.Read(_filePath);
            _from_l = HHelper.ToInt32(_mailBytes, 15);
            _subj_l = HHelper.ToInt32(_mailBytes, 19 + _from_l + 10);
            _body_l = HHelper.ToInt32(_mailBytes, 19 + _from_l + 14 + _subj_l);
            if (this.MessageFlags_Syst)
            {
                _syst_l = HHelper.ToInt32(_mailBytes, 19 + _from_l + 14 + _subj_l + 4 + _body_l + 1 + 4);
                _systSkipOffset += 8 + _syst_l;
            }
            if (this.MessageFlags_Plan)
            {
                _plan_l = HHelper.ToInt32(_mailBytes, 19 + _from_l + 14 + _subj_l + 4 + _body_l + 1 + _systSkipOffset + 4);
                _planSkipOffset += 8 + _plan_l;
            }
        }
    }
}
