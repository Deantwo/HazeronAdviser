using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronAdviser
{
    class AttentionMessage
    {
        protected int _priority = 0;
        public int Priority
        {
            get { return _priority; }
        }

        protected string _column = "";
        public string Column
        {
            get { return _column; }
        }

        protected string _text = "";
        public string Text
        {
            get { return _text; }
        }

        public AttentionMessage(int priority, string column, string text)
        {
            _priority = priority;
            _column = column;
            _text = text;
        }
        public AttentionMessage()
        {
        }
    }
}
