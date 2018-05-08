using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSearch
{
    class LogData
    {
        private string searchWord;
        private DateTime time;

        public LogData() { }

        public string SearchWord
        {
            get { return searchWord; }
            set { searchWord = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public LogData (string searchWord,DateTime time)
        {
            Time = time;
            SearchWord = searchWord;
        }
    }
}
