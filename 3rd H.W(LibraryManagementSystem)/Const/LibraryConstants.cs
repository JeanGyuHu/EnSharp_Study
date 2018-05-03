using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class LibraryConstants
    {
        //매직 넘버들
        public const string LoginSuperviserMode = "1";
        public const string LoginUserMode = "2";
        public const string GoToSignUpPage = "3";
        public const string Exit = "4";

        public const string MemberControl = "1";
        public const string BookManagement = "2";
        public const string ReturnBooks = "3";
        public const string GoReturn = "3";
        public const string GoBack = "4";

        public const string RentBookPage = "1";
        public const string ExtendRentalTimePage = "2";

        public const string StartSuperViserMode = "1";
        public const string StartUserMode = "2";

        public const string AddMode = "1";
        public const string EditMode = "2";
        public const string DeleteMode = "3";
        public const string SearchMode = "4";
        public const string PrintMode = "5";
        public const string GoBefore = "6";

        public const string SearchBookNo = "1";
        public const string SearchBookName = "2";
        public const string SearchBookCount = "3";
        public const string SearchBookAuthor = "4";
        public const string SearchBookPublisher = "5";

        public const string AddNewMember = "1";
        public const string EditMemberInfo = "2";
        public const string DeleteMember = "3";
        public const string SearchMember = "4";
        public const string PrintMemberInfo = "5";
        public const string GoBeforePage = "6";

        public const string SearchWithName = "1";
        public const string SearchWithResidentNum = "2";
        public const string SearchWithId = "3";
        public const string SearchWithPassword = "4";
        public const string SearchWithAddress = "5";
        public const string SearchWithPhone = "6";
        public const string ReturnBack = "7";

        public enum Mode { Add=1, Search };
    }
}
