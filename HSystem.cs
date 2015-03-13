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

        protected string _sOverview = "";
        public string SOverview
        {
            get { return _sOverview; }
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

        protected string _sMorale = "-", _sMoraleShort = "-";
        public string SMorale
        {
            get { return _sMorale; }
        }
        public string SMoraleShort
        {
            get { return _sMoraleShort; }
        }

        protected int _vAbandonment = 0, _vAbandonmentMax = 0;
        public int VAbandonment
        {
            get { return _vAbandonment; }
        }
        public int VAbandonmentMax
        {
            get { return _vAbandonmentMax; }
        }

        protected string _sAbandonment = "-";
        public string SAbandonment
        {
            get { return _sAbandonment; }
        }

        protected string _sPopulation = "-", _sPopulationShort = "-";
        public string SPopulation
        {
            get { return _sPopulation; }
        }
        public string SPopulationShort
        {
            get { return _sPopulationShort; }
        }

        protected string _sLoyalty = "-";
        public string SLoyalty
        {
            get { return _sLoyalty; }
        }

        protected string _sPopOverview = "-";
        public string SPopOverview
        {
            get { return _sPopOverview; }
        }

        protected string _sFactilities = "-";
        public string SFactilities
        {
            get { return _sFactilities; }
        }

        protected string _sBuildings = "";
        public string SBuildings
        {
            get { return _sBuildings; }
        }

        protected string _sTechnology = "";
        public string STechnology
        {
            get { return _sTechnology; }
        }

        protected Dictionary<string, int> _lReseatchProjects = new Dictionary<string, int>();
        public Dictionary<string, int> LReseatchProjects
        {
            get { return _lReseatchProjects; }
        }

        protected Dictionary<string, int> _lFactilitiesTL = new Dictionary<string, int>();
        public Dictionary<string, int> LFactilitiesTL
        {
            get { return _lFactilitiesTL; }
        }

        protected int _vMorale = 0;
        public int VMorale
        {
            get { return _vMorale; }
        }

        protected int _vPopulation = 0;
        public int VPopulation
        {
            get { return _vPopulation; }
        }

        protected int _vHomes = 0;
        public int VHomes
        {
            get { return _vHomes; }
        }

        protected int _vJobs = 0;
        public int VJobs
        {
            get { return _vJobs; }
        }

        protected int _vPopulationLimit = 0;
        public int VPopulationLimit
        {
            get { return _vPopulationLimit; }
        }

        protected int _vLoyalty = 0;
        public int VLoyalty
        {
            get { return _vLoyalty; }
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
                _vMorale = Convert.ToInt32(Cities.Average(city => city.VMorale));
                _sMoraleShort = _vMorale + "/20";
                _sMorale = "WIP";
            }

            // Decay
            {
                _vAbandonment = Cities.Min(city => city.VAbandonment);
                _vAbandonmentMax = Cities.Min(city => city.VAbandonmentMax);
                if (_vAbandonmentMax < Hazeron.AbandonmentInterval)
                    _sAbandonment = " Unstable";
                else if (_vAbandonment == _vAbandonmentMax)
                    _sAbandonment = _vAbandonment.ToString("00") + "~/" + _vAbandonmentMax.ToString("00") + " days";
                else if (_vAbandonment > 0)
                    _sAbandonment = _vAbandonment.ToString("00") + " /" + _vAbandonmentMax.ToString("00") + " days";
                else
                    _sAbandonment = " Decaying";
            }

            // POPULATION & LIVING CONDITIONS
            {
                _vPopulation = Cities.Sum(city => city.VPopulation);
                _vHomes = Cities.Sum(city => city.VHomes);
                _vJobs = Cities.Sum(city => city.VJobs);
                _vPopulationLimit = Cities.Sum(city => city.VPopulationLimit);
                _sPopulationShort = _vPopulation + "/" + _vHomes + "/" + _vPopulationLimit;

                _vLoyalty = Cities.Sum(city => city.VLoyalty);
                _sLoyalty = _vLoyalty + " citizens (" + Math.Round(((float)_vLoyalty / _vPopulation) * 100, 2) + "%)";
            }

            // Population overwiew
            {
                _sPopOverview = "City's population:";
                _sPopOverview += Environment.NewLine + " " + _vLoyalty.ToString().PadLeft(5) + ", Loyal citizens";
                if (_vLoyalty != _vPopulation)
                {
                    int minutesToLoyal;
                    bool disloyal = (_cities.Min(city => city.VLoyalty) < 0);
                    if (!disloyal)
                        minutesToLoyal = ((_cities.Max(city => (city.VPopulation - city.VLoyalty))) * 13);
                    else
                        minutesToLoyal = (Math.Abs(_vLoyalty) * 13);
                    _sPopOverview += " [color=" + (disloyal ? "red" : "orange") + "](";
                    if (minutesToLoyal < 120) // Less than two hours.
                        _sPopOverview += minutesToLoyal + " minutes";
                    else if (minutesToLoyal < 2980) // Less than two days.
                        _sPopOverview += (minutesToLoyal / 60) + " hours";
                    else // More than two days.
                        _sPopOverview += (minutesToLoyal / 1490) + " days";
                    _sPopOverview += " to " + (disloyal ? "loyal" : "full") + ")[/color]";
                }
                _sPopOverview += Environment.NewLine + " " + _vPopulation.ToString().PadLeft(5) + ", Citizens";
                _sPopOverview += Environment.NewLine + " " + _vHomes.ToString().PadLeft(5) + ", Homes";
                _sPopOverview += Environment.NewLine + " " + _vJobs.ToString().PadLeft(5) + ", Jobs";
                _sPopOverview += Environment.NewLine + " " + _vPopulationLimit.ToString().PadLeft(5) + ", Population limit";
            }

            // Technology overview
            {
                _sTechnology = "";
                _lReseatchProjects = new Dictionary<string, int>();
                _lFactilitiesTL = new Dictionary<string, int>();
                // Get all the info from the cities
                foreach (HCity city in Cities)
                {
                    foreach (KeyValuePair<string, int> project in city.LReseatchProjects)
                    {
                        if (!_lReseatchProjects.ContainsKey(project.Key))
                            _lReseatchProjects.Add(project.Key, project.Value);
                        else
                            _lReseatchProjects[project.Key] += project.Value;
                    }
                    foreach (KeyValuePair<string, int> tech in city.LFactilitiesTL)
                    {
                        if (!_lFactilitiesTL.ContainsKey(tech.Key))
                            _lFactilitiesTL.Add(tech.Key, tech.Value);
                        else if (_lFactilitiesTL[tech.Key] != tech.Value)
                        {
                            _lFactilitiesTL[tech.Key] = -Math.Max(Math.Abs(_lFactilitiesTL[tech.Key]), Math.Abs(tech.Value));
                        }
                    }
                }

                if (_lReseatchProjects.Count != 0)
                {
                    _sTechnology = "System's technology projects:";
                    foreach (string building in _lReseatchProjects.Keys)
                    {
                        if (_lFactilitiesTL.ContainsKey(building))
                            _sTechnology += Environment.NewLine + " " + _lReseatchProjects[building].ToString().PadLeft(2) + " (TL" + Math.Abs(_lFactilitiesTL[building]).ToString().PadLeft(2) + ") running, " + building;
                        else
                            _sTechnology += Environment.NewLine + " [color=red]" + _lReseatchProjects[building].ToString().PadLeft(2) + " running, " + building + " (wasted, none in city)[/color]";
                    }
                }
                if (_sTechnology != "")
                    _sTechnology += Environment.NewLine + Environment.NewLine;
                _sTechnology += "System's technology levels:";
                List<string> buildingList = _lFactilitiesTL.Keys.ToList();
                buildingList.Sort();
                foreach (string building in buildingList)
                {
                    _sTechnology += Environment.NewLine + " TL" + Math.Abs(_lFactilitiesTL[building]).ToString().PadLeft(2) + ", " + building;
                    if (_lFactilitiesTL[building] < 0)
                        _sTechnology += " [color=red](not all buildings)[/color]";
                }
            }

            // Overview
            _sOverview = "WIP";

            // AttentionCodes
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x01); // 0b00000001
            if (_vPopulation < _vHomes || _vPopulation > _vHomes) // Population not full, or more than full.
                _attentionCode = (byte)(_attentionCode | 0x02); // 0b00000010
            if (Hazeron.AbandonmentInterval * 2 >= _vAbandonment) // Less than or equal to (Hazeron.AbandonmentInterval * 2) days to decay.
                _attentionCode = (byte)(_attentionCode | 0x04); // 0b00000100
            if (Hazeron.AbandonmentInterval >= _vAbandonment) // Less than or equal to (Hazeron.AbandonmentInterval) days to decay.
                _attentionCode = (byte)(_attentionCode | 0x08); // 0b00001000
            if (_vPopulation == 0 || _vPopulation > _vPopulationLimit) // Population is 0, or zone over populated!
                _attentionCode = (byte)(_attentionCode | 0x10); // 0b00010000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x20); // 0b00100000
            if (_vMorale < 20) // Morale not full.
                _attentionCode = (byte)(_attentionCode | 0x40); // 0b01000000
            if (false) // Nothing yet!
                _attentionCode = (byte)(_attentionCode | 0x80); // 0b10000000

            _initialized = true;
        }
    }
}
