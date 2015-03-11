using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace HazeronAdviser
{
    class Hazeron
    {
        public const int AbandonmentInterval = 7;

        public const int CurrencyPadding = 16;

        static protected NumberFormatInfo _numberFormat;
        static public NumberFormatInfo NumberFormat
        {
            get { return _numberFormat; }
            //set { _numberFormat = value; }
        }

        static protected DateTimeFormatInfo _dateTimeFormat;
        static public DateTimeFormatInfo DateTimeFormat
        {
            get { return _dateTimeFormat; }
            //set { _dateTimeFormat = value; }
        }

        static Hazeron()
        {
            System.Globalization.CultureInfo tempCulture = new System.Globalization.CultureInfo("en-US");
            _numberFormat = tempCulture.NumberFormat;
            _numberFormat.NumberDecimalDigits = 0;
            _numberFormat.NumberDecimalSeparator = ".";
            _numberFormat.NumberGroupSeparator = "'";
            _numberFormat.CurrencyDecimalDigits = 0;
            _numberFormat.CurrencyDecimalSeparator = ".";
            _numberFormat.CurrencyGroupSeparator = "'";
            _numberFormat.CurrencySymbol = "¢";
            _numberFormat.CurrencyPositivePattern = 1; // https://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencypositivepattern.aspx
            _numberFormat.CurrencyNegativePattern = 5; // https://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencynegativepattern.aspx
            _numberFormat.NegativeInfinitySymbol = "-∞";
            _numberFormat.PositiveInfinitySymbol = "∞";
            _dateTimeFormat = tempCulture.DateTimeFormat;
            _dateTimeFormat.FullDateTimePattern = "yyyy-MM-dd HH:mm"; // TimeDate format information: http://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        }
    }
}
