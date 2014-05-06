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
                || messageType == 0x04 // MSG_CityDistressReport
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
            if (   messageType == 0x0A // MSG_ShipLog
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

        protected int _from_l, _subj_l, _body_l;
        public string From
        {
            get { return HHelper.ToBigEndianUnicodeString(_mailBytes, 19, _from_l); }
        }
        public string Subject
        {
            get { return HHelper.ToBigEndianUnicodeString(_mailBytes, 19 + _from_l + 14, _subj_l); }
        }
        public string Body
        {
            get { return HHelper.ToBigEndianUnicodeString(_mailBytes, 19 + _from_l + 14 + _subj_l + 4, _body_l); }
        }

        public int MessageType
        {
            get { return _mailBytes[19 + _from_l + 9]; }
        }

        public HMailObj(string filePath)
        {
            _filePath = filePath;
            _mailBytes = HMail.Read(_filePath);
            _from_l = HHelper.ToInt32(_mailBytes, 15);
            _subj_l = HHelper.ToInt32(_mailBytes, 19 + _from_l + 10);
            _body_l = HHelper.ToInt32(_mailBytes, 19 + _from_l + 14 + _subj_l);
        }
    }

    class HHelper
    {
        /// <summary>
        /// Converts a byte array to a Hexadecimal string.
        /// </summary>
        /// <param name="singleByte">Byte to be converted.</param>
        static public string ToHex(byte singleByte) // Based on http://stackoverflow.com/a/10048895
        {
            char[] hex = new char[2];

            byte b;

            b = ((byte)(singleByte >> 4));
            hex[0] = (char)(b > 9 ? b - 10 + 'A' : b + '0');

            b = ((byte)(singleByte & 0x0F));
            hex[1] = (char)(b > 9 ? b - 10 + 'A' : b + '0');

            return new string(hex);
        }
        /// <summary>
        /// Converts a byte array to a Hexadecimal string.
        /// </summary>
        /// <param name="bytes">Bytes to be converted.</param>
        static public string ToHex(byte[] bytes)
        {
            List<string> hexs = new List<string>();
            foreach (byte singleByte in bytes)
                hexs.Add(ToHex(singleByte));
            return string.Join("-",hexs.ToArray());
        }

        /// <summary>
        /// Converts four bytes from a byte array to a int32.
        /// </summary>
        /// <param name="bytes">Bytes to be converted.</param>
        /// <param name="startIndex">Index of the starting byte.</param>
        static public int ToInt32(byte[] bytes, int startIndex)
        {
            byte[] subBytes = HHelper.SubArray(bytes, startIndex, 4);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(subBytes);
            return BitConverter.ToInt32(subBytes, 0);
        }

        /// <summary>
        /// Converts a byte array to a string, using BigEndianUnicode.
        /// </summary>
        /// <param name="bytes">Bytes to be converted.</param>
        /// <param name="startIndex">Index of the starting byte.</param>
        /// <param name="length">Number of bytes to convert.</param>
        static public string ToBigEndianUnicodeString(byte[] bytes, int startIndex, int length)
        {
            byte[] subBytes = HHelper.SubArray(bytes, startIndex, length);
            //subBytes = Helper.ConcatinateArray(new byte[] { 0xFE, 0xFF }, subBytes);
            //if (BitConverter.IsLittleEndian)
            //    Array.Reverse(subBytes);
            string text = Encoding.BigEndianUnicode.GetString(subBytes); // UTF-16 BigEndian to string.
            return text;
        }

        /// <summary>
        /// Returns selected part of a byte array.
        /// </summary>
        /// <param name="bytes">Full byte array.</param>
        /// <param name="startIndex">Index of the starting byte.</param>
        static public byte[] SubArray(byte[] bytes, int startIndex)
        {
            if (startIndex == 0)
                return bytes;
            return SubArray(bytes, startIndex, bytes.Length - startIndex);
        }
        /// <summary>
        /// Returns selected part of a byte array.
        /// </summary>
        /// <param name="bytes">Full byte array.</param>
        /// <param name="startIndex">Index of the starting byte.</param>
        /// <param name="length">Number of bytes to return.</param>
        static public byte[] SubArray(byte[] bytes, int startIndex, int length)
        {
            byte[] rv = new byte[length];
            System.Buffer.BlockCopy(bytes, startIndex, rv, 0, length);
            return rv;
            //return new List<byte>(bytes).GetRange(startIndex, length).ToArray(); // Another ways of doing it.
        }

        /// <summary>
        /// Combine multiple arrays into one.
        /// One after the other.
        /// </summary>
        static public byte[] ConcatinateArray(byte[] array1, byte[] array2)
        {
            byte[] rv = new byte[array1.Length + array2.Length];
            System.Buffer.BlockCopy(array1, 0, rv, 0, array1.Length);
            System.Buffer.BlockCopy(array2, 0, rv, array1.Length, array2.Length);
            return rv;
        }
        /// <summary>
        /// Combine multiple arrays into one.
        /// One after the other.
        /// </summary>
        static public byte[] ConcatinateArray(byte[] array1, byte[] array2, byte[] array3)
        {
            byte[] rv = new byte[array1.Length + array2.Length + array3.Length];
            System.Buffer.BlockCopy(array1, 0, rv, 0, array1.Length);
            System.Buffer.BlockCopy(array2, 0, rv, array1.Length, array2.Length);
            System.Buffer.BlockCopy(array3, 0, rv, array1.Length + array2.Length, array3.Length);
            return rv;
        }

        /// <summary>
        /// Returns a string that is void of HTML tags.
        /// Attempts to add newlines where needed.
        /// </summary>
        /// <param name="input">HTML string.</param>
        static public string CleanText(string input) // Removes the html code tags.
        {
            int tagStart, tagEnd;
            string processed = "";
            while (input.Contains("<") && input.Contains(">"))
            {
                tagStart = input.IndexOf('<');
                tagEnd = input.IndexOf('>') - tagStart;
                processed += input.Remove(tagStart);
                string tag = input.Substring(tagStart + 1, tagEnd - 1);
                input = input.Substring(tagStart + tagEnd + 1);
                switch (tag.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0])
                {
                    case "br":
                    case "div":
                    case "/div":
                    case "/td":
                    case "/tr":
                        processed += Environment.NewLine;
                        break;
                    //case "b":
                    //case "/b":
                    //case "td":
                    //case "tr":
                    //    break;
                }
            }
            return processed.Trim().Replace(Environment.NewLine + Environment.NewLine + Environment.NewLine, Environment.NewLine).Replace("&nbsp;", " "); // Trim for good measure and remove triple NewLine.
        }
    }
}
