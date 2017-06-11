using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HSector
    {
        // There is no sector name or ID in the HMails.
        protected string _name = "-"; // Name of the sector, this can change at any time.
        public string Name
        {
            get { return _name; }
        }
        protected int _id = 0; // ID of the sector.
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

        protected List<HSystem> _systems = new List<HSystem>();
        public List<HSystem> Systems
        {
            get { return _systems; }
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

        protected bool _initialized = false;
        public bool Initialized
        {
            get { return _initialized; }
        }

        public HSector(HSystem system)
        {
            //_name = system.SectorName; // Incase sector changed name.
            _id = system.SectorID;

            AddSystem(system);
        }

        public void AddSystem(HSystem system)
        {
            _systems.Add(system);

            if (DateTime.Compare(system.LastUpdared, _lastUpdated) == 1)
                _lastUpdated = system.LastUpdared;

            foreach (int owner in system.Onwers)
                if (!_owners.Contains(owner))
                    _owners.Add(owner);
        }
    }
}
