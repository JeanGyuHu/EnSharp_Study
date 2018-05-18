using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu_s_Calculator1
{
    class Constants
    {
        public enum Operation
        {
            PLUS = 1,
            SUBTRACT,
            MULTIPLY,
            DEVIDE,
            EQUAL,
            DELETE,
            CLEAR,
            CLEARERROR,
            NEGATE,
            NONE
        }

        public const string PLUS = "ButtonPlus";
        public const string SUBTRACT = "ButtonMinus";
        public const string MULTIFLY = "ButtonMultiply";
        public const string DEVIDE = "ButtonDevide";
        public const string NEGATE = "ButtonPM";
        public const string EQUAL = "ButtonEqual";
        public const string CLEAR = "ButtonC";
        public const string CLEARERROR = "ButtonCE";
        public const string DELETEONE = "ButtonDelete";
    }
}
