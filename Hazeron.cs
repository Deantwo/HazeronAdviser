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

        protected static NumberFormatInfo _numberFormat;
        public static NumberFormatInfo NumberFormat
        {
            get { return _numberFormat; }
            //set { _numberFormat = value; }
        }

        protected static DateTimeFormatInfo _dateTimeFormat;
        public static DateTimeFormatInfo DateTimeFormat
        {
            get { return _dateTimeFormat; }
            //set { _dateTimeFormat = value; }
        }

        protected static string[] _pirateEmpires;
        public static string[] PirateEmpires
        {
            get { return _pirateEmpires; }
            //set { _pirateEmpires = value; }
        }

        protected static Dictionary<string, int> _moraleBuildingThresholds;
        public static Dictionary<string, int> MoraleBuildingThresholds
        {
            get { return _moraleBuildingThresholds; }
            //set { _moraleBuildingThresholds = value; }
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

            _pirateEmpires = new string[] { "Akson"
                                          , "Balorite"
                                          , "Dendrae"
                                          , "Haxu"
                                          , "Kla'tra"
                                          , "Malaco"
                                          , "Myntaka"
                                          , "Ogar"
                                          , "Otari"
                                          , "Seledon"
                                          , "Syth"
                                          , "Tassad"
                                          , "Vilmorti"
                                          , "Vreen"
                                          , "Zuul"
                                          };

            _moraleBuildingThresholds = new Dictionary<string, int>();
            _moraleBuildingThresholds.Add("Church", 45);
            _moraleBuildingThresholds.Add("Cantina", 50);
            _moraleBuildingThresholds.Add("Retail Store", 55);
            _moraleBuildingThresholds.Add("University", 70);
            _moraleBuildingThresholds.Add("Hospital", 80);
            _moraleBuildingThresholds.Add("Park", 90);
            _moraleBuildingThresholds.Add("Grocery", 100);
            _moraleBuildingThresholds.Add("Zoo", 150);
            _moraleBuildingThresholds.Add("Arena", 175);
            _moraleBuildingThresholds.Add("Casino", 200);
        }

        public static int MoraleBuildingsRequired(string buildingType, int population)
        {
            if (!_moraleBuildingThresholds.ContainsKey(buildingType))
                throw new Exception($"Invalid building type. {buildingType}");

            int levelsNeeded = 0;
            if (population >= _moraleBuildingThresholds[buildingType])
                levelsNeeded = Math.Max(population / (_moraleBuildingThresholds[buildingType] * 3), 1);

            if (buildingType == "Church")
                levelsNeeded += 2;
            else if (buildingType == "Cantina")
                levelsNeeded += 1;

            return levelsNeeded;
        }

        public static bool ValidID(string id)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[A-Z]+$");
            System.Text.RegularExpressions.Match regexMatch = regex.Match(id);
            return (id == null || id == "" || !regexMatch.Success);
        }
    }
}
