using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HSystem
    {
        protected string _name = "-"; // Name of the ship, this can change at any time.
        public string Name
        {
            get { return _name; }
        }
        protected int _id = 0; // ID of the ship, used in mail names.
        public int ID
        {
            get { return _id; }
        }
        public string IdString
        {
            get { return HHelper.ToID(_id); }
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

        protected List<HCity> _cities = new List<HCity>();
        public List<HCity> Cities
        {
            get { return _cities; }
        }

        protected string _moraleOverview = "-";
        public string MoraleOverview
        {
            get { return _moraleOverview; }
        }

        protected string _moraleColumn = "-";
        public string MoraleColumn
        {
            get { return _moraleColumn; }
        }

        protected int _abandonment = 0, _abandonmentMax = 0;
        public int Abandonment
        {
            get { return _abandonment; }
        }
        public int AbandonmentMax
        {
            get { return _abandonmentMax; }
        }

        protected string _abandonmentColumn = "-";
        public string AbandonmentColumn
        {
            get { return _abandonmentColumn; }
        }

        protected string _populationColumn = "-";
        public string PopulationColumn
        {
            get { return _populationColumn; }
        }

        protected string _loyaltyColumn = "-";
        public string LoyaltyColumn
        {
            get { return _loyaltyColumn; }
        }

        protected string _populationOverview = "-";
        public string PopulationOverview
        {
            get { return _populationOverview; }
        }

        protected string _sFactilities = "-";
        public string SFactilities
        {
            get { return _sFactilities; }
        }

        protected string _buildingsOverview = "";
        public string BuildingsOverview
        {
            get { return _buildingsOverview; }
        }

        protected string _technologyOverview = "";
        public string TechnologyOverview
        {
            get { return _technologyOverview; }
        }

        protected Dictionary<string, int> _reseatchProjects = new Dictionary<string, int>();
        public Dictionary<string, int> ReseatchProjects
        {
            get { return _reseatchProjects; }
        }

        protected Dictionary<string, int> _factilitiesTL = new Dictionary<string, int>();
        public Dictionary<string, int> FactilitiesTL
        {
            get { return _factilitiesTL; }
        }

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

        protected int _loyalty = 0;
        public int Loyalty
        {
            get { return _loyalty; }
        }

        protected bool _initialized = false;
        public bool Initialized
        {
            get { return _initialized; }
        }

        public HSystem(HCity city)
        {
            _name = city.SystemName; // Incase sender changed name.
            _id = city.SystemID;

            AddCity(city);
        }

        public void AddCity(HCity city)
        {
            _cities.Add(city);

            if (DateTime.Compare(city.LastUpdared, _lastUpdated) == 1)
                _lastUpdated = city.LastUpdared;

            foreach (int owner in city.Onwers)
                if (!_owners.Contains(owner))
                    _owners.Add(owner);
        }

        public void Initialize()
        {
            _attentionCode = 0x00; // 0b00000000

            // MORALE
            {
                _morale = Convert.ToInt32(Cities.Average(city => city.Morale));
                _moraleColumn = _morale + "/20";
                _moraleOverview = "WIP";
            }

            // Decay
            {
                _abandonment = Cities.Min(city => city.Abandonment);
                _abandonmentMax = Cities.Min(city => city.AbandonmentMax);
                if (_abandonmentMax < Hazeron.AbandonmentInterval)
                    _abandonmentColumn = " Unstable";
                else if (_abandonment == _abandonmentMax)
                    _abandonmentColumn = _abandonment.ToString("00") + "~/" + _abandonmentMax.ToString("00") + " days";
                else if (_abandonment > 0)
                    _abandonmentColumn = _abandonment.ToString("00") + " /" + _abandonmentMax.ToString("00") + " days";
                else
                    _abandonmentColumn = " Decaying";
            }

            // POPULATION & LIVING CONDITIONS
            {
                _population = Cities.Sum(city => city.Population);
                _homes = Cities.Sum(city => city.Homes);
                _jobs = Cities.Sum(city => city.Jobs);
                _populationLimit = Cities.Sum(city => city.PopulationLimit);
                _populationColumn = _population + "/" + _homes + "/" + _populationLimit;

                _loyalty = Cities.Sum(city => city.Loyalty);
                _loyaltyColumn = _loyalty + " citizens (" + Math.Round(((float)_loyalty / _population) * 100, 2) + "%)";
            }

            // Population overwiew
            {
                _populationOverview = "City's population:";
                _populationOverview += Environment.NewLine + " " + _loyalty.ToString().PadLeft(5) + ", Loyal citizens";
                if (_loyalty != _population)
                {
                    int minutesToLoyal;
                    bool disloyal = (_cities.Min(city => city.Loyalty) < 0);
                    if (!disloyal)
                        minutesToLoyal = ((_cities.Max(city => (city.Population - city.Loyalty))) * 13);
                    else
                        minutesToLoyal = (Math.Abs(_loyalty) * 13);
                    _populationOverview += " [color=" + (disloyal ? "red" : "orange") + "](";
                    if (minutesToLoyal < 120) // Less than two hours.
                        _populationOverview += minutesToLoyal + " minutes";
                    else if (minutesToLoyal < 2980) // Less than two days.
                        _populationOverview += (minutesToLoyal / 60) + " hours";
                    else // More than two days.
                        _populationOverview += (minutesToLoyal / 1490) + " days";
                    _populationOverview += " to " + (disloyal ? "loyal" : "full") + ")[/color]";
                }
                _populationOverview += Environment.NewLine + " " + _population.ToString().PadLeft(5) + ", Citizens";
                _populationOverview += Environment.NewLine + " " + _homes.ToString().PadLeft(5) + ", Homes";
                _populationOverview += Environment.NewLine + " " + _jobs.ToString().PadLeft(5) + ", Jobs";
                _populationOverview += Environment.NewLine + " " + _populationLimit.ToString().PadLeft(5) + ", Population limit";
            }

            // Technology overview
            {
                _technologyOverview = "";
                _reseatchProjects = new Dictionary<string, int>();
                _factilitiesTL = new Dictionary<string, int>();
                // Get all the info from the cities
                foreach (HCity city in Cities)
                {
                    foreach (KeyValuePair<string, int> project in city.ReseatchProjects)
                    {
                        if (!_reseatchProjects.ContainsKey(project.Key))
                            _reseatchProjects.Add(project.Key, project.Value);
                        else
                            _reseatchProjects[project.Key] += project.Value;
                    }
                    foreach (KeyValuePair<string, int> tech in city.FactilitiesTL)
                    {
                        if (!_factilitiesTL.ContainsKey(tech.Key))
                            _factilitiesTL.Add(tech.Key, tech.Value);
                        else if (_factilitiesTL[tech.Key] != tech.Value)
                        {
                            _factilitiesTL[tech.Key] = -Math.Max(Math.Abs(_factilitiesTL[tech.Key]), Math.Abs(tech.Value));
                        }
                    }
                }

                if (_reseatchProjects.Count != 0)
                {
                    _technologyOverview = "System's technology projects:";
                    foreach (string building in _reseatchProjects.Keys)
                    {
                        if (_factilitiesTL.ContainsKey(building))
                            _technologyOverview += Environment.NewLine + " " + _reseatchProjects[building].ToString().PadLeft(2) + " (TL" + Math.Abs(_factilitiesTL[building]).ToString().PadLeft(2) + ") running, " + building;
                        else
                            _technologyOverview += Environment.NewLine + " [color=red]" + _reseatchProjects[building].ToString().PadLeft(2) + " running, " + building + " (wasted, none in city)[/color]";
                    }
                }
                if (_technologyOverview != "")
                    _technologyOverview += Environment.NewLine + Environment.NewLine;
                _technologyOverview += "System's technology levels:";
                List<string> buildingList = _factilitiesTL.Keys.ToList();
                buildingList.Sort();
                foreach (string building in buildingList)
                {
                    _technologyOverview += Environment.NewLine + " TL" + Math.Abs(_factilitiesTL[building]).ToString().PadLeft(2) + ", " + building;
                    if (_factilitiesTL[building] < 0)
                        _technologyOverview += " [color=red](not all buildings)[/color]";
                }
            }

            // Overview
            _overview = "WIP";

            // AttentionCodes
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x01); // 0b00000001
            if (_population < _homes || _population > _homes) // Population not full, or more than full.
                _attentionCode = (byte)(_attentionCode | 0x02); // 0b00000010
            if (Hazeron.AbandonmentInterval * 2 >= _abandonment) // Less than or equal to (Hazeron.AbandonmentInterval * 2) days to decay.
                _attentionCode = (byte)(_attentionCode | 0x04); // 0b00000100
            if (Hazeron.AbandonmentInterval >= _abandonment) // Less than or equal to (Hazeron.AbandonmentInterval) days to decay.
                _attentionCode = (byte)(_attentionCode | 0x08); // 0b00001000
            if (_population == 0 || _population > _populationLimit) // Population is 0, or zone over populated!
                _attentionCode = (byte)(_attentionCode | 0x10); // 0b00010000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x20); // 0b00100000
            if (_morale < 20) // Morale not full.
                _attentionCode = (byte)(_attentionCode | 0x40); // 0b01000000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x80); // 0b10000000

            _initialized = true;
        }
    }
}
