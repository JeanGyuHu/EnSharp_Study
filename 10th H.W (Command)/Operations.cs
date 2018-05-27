using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu_s_Command
{
    class Operations
    {
        Print print;

        public Operations()
        {
            print = new Print();
        }

        public void Cls()
        {
            Console.Clear();
        }
        public void Help()
        {
            print.Help();
        }
    }
}
