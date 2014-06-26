using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class HCharacter
    {
        protected int _idNum;
        public int IdNum
        {
            get { return _idNum; }
        }

        protected string _id;
        public string ID
        {
            get { return _id; }
        }

        protected string _name;
        public string Name
        {
            get { return _name; }
        }

        public HCharacter(HMail mail)
        {
            _idNum = mail.SenderID;
            _id = HHelper.ToID(_idNum);
            _name = mail.From;
        }
    }
}
