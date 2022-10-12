using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HSystem
    {
        protected string _name = "-"; // Name of the system, this can change at any time.
        public string Name
        {
            get { return _name; }
        }
        protected int _id = 0; // ID of the system.
        public int ID
        {
            get { return _id; }
        }
        public string IdString
        {
            get { return HHelper.ToID(_id); }
        }

        protected int _sectorId = 0;
        public int SectorID 
        {
            get { return _sectorId;}
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

        protected string _moraleOverview = "";
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

        protected string _populationOverview = "";
        public string PopulationOverview
        {
            get { return _populationOverview; }
        }

        protected string _buildingsOverview = "";
        public string BuildingsOverview
        {
            get { return _buildingsOverview; }
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

        protected List<int> _moraleModifiers = new List<int>();
        public List<int> MoraleModifiers
        {
            get { return _moraleModifiers; }
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
                StringBuilder moraleColumn = new StringBuilder();
                StringBuilder moraleOverview = new StringBuilder();
                moraleColumn.Append($"{_morale.ToString("+#0;-#0;±#0").PadLeft(3)} Avg (");
                moraleOverview.AppendLine("System's morale:");
                foreach (HCity city in _cities)
                {
                    int sum = city.MoraleModifiers.Values.Sum();
                    if (!_moraleModifiers.Contains(sum))
                    {
                        if (_moraleModifiers.Count != 0)
                            moraleColumn.Append(", ");
                        moraleColumn.Append(sum.ToString("+#0;-#0;±#0").PadLeft(3));
                    }
                    _moraleModifiers.Add(sum);

                    moraleOverview.AppendLine();
                    moraleOverview.AppendLine($"  {city.Name}");
                    if (city.Morale >= 0)
                        moraleOverview.Append("[color=green]");
                    else
                        moraleOverview.Append("[color=red]");
                    moraleOverview.Append($"    {city.Morale.ToString("+#0;-#0;±#0").PadLeft(3)}[/color]");
                    moraleOverview.Append($" ([color=green]{city.MoraleModifiers.Values.Where(x => x > 0).Sum().ToString("+#0;-#0;±#0").PadLeft(3)}[/color]");
                    moraleOverview.AppendLine($", [color=red]{city.MoraleModifiers.Values.Where(x => x < 0).Sum().ToString("+#0;-#0;±#0").PadLeft(3)}[/color])");
                }
                moraleColumn.Append(")");
                _moraleColumn = moraleColumn.ToString();
                _moraleOverview = moraleOverview.ToString();
            }

            // Decay
            {
                _abandonment = Cities.Min(city => city.Abandonment);
                _abandonmentMax = Cities.Min(city => city.AbandonmentMax);
                bool decaying = Cities.Any(city => city.DistressOverview.Contains("City is decaying."));
                if (decaying)
                    _abandonmentColumn = " Decaying";
                else if (_abandonmentMax < Hazeron.AbandonmentInterval)
                    _abandonmentColumn = " Unstable";
                else if (_abandonment == _abandonmentMax)
                    _abandonmentColumn = _abandonment.ToString("00") + "~/" + _abandonmentMax.ToString("00") + " days";
                else if (_abandonment > 0)
                    _abandonmentColumn = _abandonment.ToString("00") + " /" + _abandonmentMax.ToString("00") + " days";
                else
                    _abandonmentColumn = " ERROR!?";
            }

            // POPULATION & LIVING CONDITIONS
            {
                _population = Cities.Sum(city => city.Population);
                _homes = Cities.Sum(city => city.Homes);
                _jobs = Cities.Sum(city => city.Jobs);
                _populationColumn = "Population " + _population + ", Homes " + _homes;
            }

            // Population overwiew
            {
                _populationOverview = "City's population:";
                _populationOverview += Environment.NewLine + " " + _population.ToString().PadLeft(5) + ", Citizens";
                _populationOverview += Environment.NewLine + " " + _homes.ToString().PadLeft(5) + ", Homes";
                _populationOverview += Environment.NewLine + " " + _jobs.ToString().PadLeft(5) + ", Jobs";
                _populationOverview += Environment.NewLine + " " + _populationLimit.ToString().PadLeft(5) + ", Population limit";

                if (Cities.Any(x => !string.IsNullOrEmpty(x.OfficerCadet)))
                {
                    _populationOverview += Environment.NewLine;
                    _populationOverview += Environment.NewLine;
                    _populationOverview += "Spacecraft crew:";
                    foreach (string cadet in Cities.Select(x => x.OfficerCadet).Distinct())
                        _populationOverview += $"{Environment.NewLine} Cadet {cadet}";
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

        public override string ToString()
        {
            return _name;
        }
    }
}
