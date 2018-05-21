using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu_s_Calculator1
{
    class DataVO
    {
        private double number;
        private Constants.Operation operation;

        public double Number
        {
            get { return number; }
            set { number = value; }
        }

        public Constants.Operation Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public DataVO(double number, Constants.Operation operation)
        {
            Number = number;
            Operation = operation;
        }
    }
}
