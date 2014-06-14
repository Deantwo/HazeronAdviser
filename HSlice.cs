using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HSlice
    {
        protected DateTime _timestamp = new DateTime(2000, 1, 1);
        public DateTime Timestamp
        {
            get { return _timestamp; }
        }

        // Full body test, mostly used for debuging.
        protected string _body = "";
        public string BodyTest
        {
            get { return HHelper.CleanText(_body); }
        }
    }

    class HCitySlice : HSlice
    {
        protected int _morale = 0;
        public int Morale
        {
            get { return _morale; }
        }

        protected int _population = 0;
        public int Population
        {
            get { return _population; }
        }

        protected int _homes = 0;
        public int Homes
        {
            get { return _homes; }
        }

        protected int _jobs = 0;
        public int Jobs
        {
            get { return _jobs; }
        }

        protected int _populationLimit = 0;
        public int PopulationLimit
        {
            get { return _populationLimit; }
        }

        public HCitySlice(HMail mail)
        {
            _timestamp = mail.DateTime;

            // String working vars.
            int subStart, subEnd;
            string[] tempArray;
            // Time for City spicific things.
            string tempMorale, tempPopulation, tempLivingConditions;

            if (mail.MessageType != 0x17) // MSG_CityFinalDecayReport
            {
                // MORALE
                subStart = mail.Body.IndexOf("<b>MORALE</b>");
                subEnd = mail.Body.IndexOf("<b>POPULATION</b>") - subStart;
                tempMorale = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                tempArray = tempMorale.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                tempMorale = tempArray[tempArray.Length - 1].Remove(tempArray[tempArray.Length - 1].Length - 1).Substring(7);
                tempArray = tempMorale.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                _morale = Convert.ToInt32(tempArray[tempArray.Length - 1]);

                // POPULATION
                subStart = mail.Body.IndexOf("<b>POPULATION</b>");
                subEnd = mail.Body.IndexOf("<b>LIVING CONDITIONS</b>") - subStart;
                tempPopulation = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                tempArray = tempPopulation.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                if (!tempArray[tempArray.Length - 1].Contains("loyal") || tempArray[tempArray.Length - 2].Contains("prevents immigration. Airport needed."))
                    tempPopulation = tempArray[tempArray.Length - 1].Remove(tempArray[tempArray.Length - 1].Length - 1).Substring(11);
                else
                    tempPopulation = tempArray[tempArray.Length - 2].Remove(tempArray[tempArray.Length - 2].Length - 1).Substring(11);
                tempArray = tempPopulation.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                _population = Convert.ToInt32(tempArray[tempArray.Length - 1]);

                // LIVING CONDITIONS
                subStart = mail.Body.IndexOf("<b>LIVING CONDITIONS</b>");
                subEnd = mail.Body.IndexOf("<b>POWER RESERVE</b>") - subStart;
                tempLivingConditions = HHelper.CleanText(mail.Body.Substring(subStart, subEnd));
                tempArray = tempLivingConditions.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                _jobs = Convert.ToInt32(tempArray[1].Split(' ')[1]);
                _homes = Convert.ToInt32(tempArray[4].Split(' ')[1]);

                // Planet Size
                if (!mail.Body.Contains("Ringworld Arc"))
                {
                    subStart = mail.Body.IndexOf("m dia, ");
                    tempArray = mail.Body.Remove(subStart).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    _populationLimit = Convert.ToInt32(tempArray[tempArray.Length - 1].Replace(",", ""));
                    _populationLimit = Convert.ToInt32(100 * Math.Floor((float)_populationLimit / 1800));
                }
                else
                    _populationLimit = 1000;



                // Full body test, mostly used for debuging.
                _body = mail.Body;
            }
        }
    }
}
