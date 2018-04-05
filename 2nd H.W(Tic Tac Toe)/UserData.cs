using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enjoy_Day2
{
    

    class UserData
    {
        private string strPlayer;

        public string StrPlayer
        {
            get { return strPlayer; }
            set { strPlayer = value; }
        }
        private int num;

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public UserData(string name,int n)
        {
            StrPlayer = name;
            Num = n;
        }
    }
}
