using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ImageSearch
{
    //검색어와 시간을 저장하는 VO
    class LogData
    {
        
        private string searchWord;      //내가 검색한 검색어
        private DateTime time;          //검색한 시간

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
