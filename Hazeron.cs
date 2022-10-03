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

        protected static Dictionary<string, int> _moraleBuildingCityThresholds;
        public static Dictionary<string, int> MoraleBuildingCityThresholds
        {
            get { return _moraleBuildingCityThresholds; }
            //set { _moraleBuildingCityThresholds = value; }
        }

        protected static Dictionary<string, int> _moraleBuildingBaseThresholds;
        public static Dictionary<string, int> MoraleBuildingBaseThresholds
        {
            get { return _moraleBuildingBaseThresholds; }
            //set { _moraleBuildingBaseThresholds = value; }
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

            _moraleBuildingCityThresholds = new Dictionary<string, int>();
            _moraleBuildingCityThresholds.Add("Church", 45);
            _moraleBuildingCityThresholds.Add("Cantina", 50);
            _moraleBuildingCityThresholds.Add("Retail Store", 55);
            _moraleBuildingCityThresholds.Add("University", 70);
            _moraleBuildingCityThresholds.Add("Hospital", 80);
            _moraleBuildingCityThresholds.Add("Park", 90);
            _moraleBuildingCityThresholds.Add("Grocery", 100);
            _moraleBuildingCityThresholds.Add("Zoo", 150);
            _moraleBuildingCityThresholds.Add("Arena", 175);
            _moraleBuildingCityThresholds.Add("Casino", 200);

            _moraleBuildingBaseThresholds = new Dictionary<string, int>();
            _moraleBuildingBaseThresholds.Add("Cantina", 50);
            _moraleBuildingBaseThresholds.Add("Retail Store", 55);
            _moraleBuildingBaseThresholds.Add("Star Fleet Academy", 250);
        }

        public static int MoraleBuildingsRequiredCity(string buildingType, int population)
        {
            if (!_moraleBuildingCityThresholds.ContainsKey(buildingType))
                throw new Exception($"Invalid building type. {buildingType}");

            int jobsNeeded = 0;
            if (population >= _moraleBuildingCityThresholds[buildingType])
                jobsNeeded = Math.Max(population / (_moraleBuildingCityThresholds[buildingType] * 3), 1);

            if (buildingType == "Church")
                jobsNeeded += 2;
            else if (buildingType == "Cantina")
                jobsNeeded += 1;

            return jobsNeeded;
        }

        public static int MoraleBuildingsRequiredBase(string buildingType, int population)
        {
            if (!_moraleBuildingBaseThresholds.ContainsKey(buildingType))
                throw new Exception($"Invalid building type. {buildingType}");

            int jobsNeeded = 0;
            if (population >= _moraleBuildingBaseThresholds[buildingType])
                jobsNeeded = Math.Max(population / (_moraleBuildingBaseThresholds[buildingType] * 3), 1);

            else if (buildingType == "Cantina")
                jobsNeeded += 1;

            return jobsNeeded;
        }

        public static bool ValidID(string id)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[A-Z]+$");
            System.Text.RegularExpressions.Match regexMatch = regex.Match(id);
            return (id == null || id == "" || !regexMatch.Success);
        }
    }
}
