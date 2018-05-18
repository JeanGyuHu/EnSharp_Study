using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu_s_Calculator1
{
    class Data
    {
        private bool eraseDisplay;
        private string display;
        private string lastValue;
        private string memoryValue;
        private Constants.Operation lastOperation;

        public Constants.Operation LastOperation
        {
            get
            {
                return lastOperation;
            }
            set
            {
                lastOperation = value;
            }
        }

        public bool EraseDisplay
        {
            get
            {
                return eraseDisplay;

            }
            set
            {
                eraseDisplay = value;
            }
        }
        //Get/Set Memory cell value
        public Double Memory
        {
            get
            {
                if (memoryValue == string.Empty)
                    return 0.0;
                else
                    return Convert.ToDouble(memoryValue);
            }
            set
            {
                memoryValue = value.ToString();
            }
        }
        //Lats value entered
        public string LastValue
        {
            get
            {
                if (lastValue == string.Empty)
                    return "0";
                return lastValue;

            }
            set
            {
                lastValue = value;
            }
        }
        //The current Calculator display
        public string Display
        {
            get
            {
                return display;
            }
            set
            {
                display = value;
            }
        }
    }
}
