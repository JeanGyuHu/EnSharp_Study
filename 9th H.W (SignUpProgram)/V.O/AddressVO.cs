using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu_s_SignUp
{
    class AddressVO
    {
        string no;
        string roadAddress;
        string beforeAddress;

        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public string RoadAddress
        {
            get { return roadAddress; }
            set { roadAddress = value; }
        }

        public string BeforeAddress
        {
            get { return beforeAddress; }
            set { beforeAddress = value; }
        }

        public AddressVO() { }

        public AddressVO(string no,string roadAddress, string beforeAddress)
        {
            No = no;
            RoadAddress = roadAddress;
            BeforeAddress = beforeAddress;
        }
    }
}
