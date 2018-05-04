using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//////////////////////////////////
/// 매직넘버들을 모아놓은 클래스//
//////////////////////////////////
namespace EnSharp_day3
{
    class LibraryConstants
    {

        //메인 화면에서 각각 어떤 창으로 갈지에 대한 매직넘버
        public const string LoginSuperviserMode = "1";
        public const string LoginUserMode = "2";
        public const string GoToSignUpPage = "3";
        public const string Exit = "4";

        //관리자 모드 메뉴에서의 매직넘버
        public const string MemberControl = "1";
        public const string BookManagement = "2";
        public const string GoReturn = "3";
        public const string GoBack = "4";

        //사용자 모드에서의 매직넘버
        public const string RentBookPage = "1";
        public const string ExtendRentalTimePage = "2";
        public const string ReturnBooks = "3";

        //관리자모드인지 유저모드인지에 대한 플래그
        public const string StartSuperViserMode = "1";
        public const string StartUserMode = "2";

        //책관리모드에서 각 메뉴에 대한 매직넘버
        public const string AddMode = "1";
        public const string EditMode = "2";
        public const string DeleteMode = "3";
        public const string SearchMode = "4";
        public const string PrintMode = "5";
        public const string GoBefore = "6";

        //책 조회를 할때 무엇으로 검색하는 모드인지에 대한 매직넘버
        public const string SearchBookNo = "1";
        public const string SearchBookName = "2";
        public const string SearchBookCount = "3";
        public const string SearchBookAuthor = "4";
        public const string SearchBookPublisher = "5";

        //멤버 관리모드에서 각 메뉴에 대한 매직넘버
        public const string AddNewMember = "1";
        public const string EditMemberInfo = "2";
        public const string DeleteMember = "3";
        public const string SearchMember = "4";
        public const string PrintMemberInfo = "5";
        public const string GoBeforePage = "6";

        //멤버 조회를 할때 무엇으로 검색하는지에 대한 매직넘버
        public const string SearchWithName = "1";
        public const string SearchWithResidentNum = "2";
        public const string SearchWithId = "3";
        public const string SearchWithPassword = "4";
        public const string SearchWithAddress = "5";
        public const string SearchWithPhone = "6";
        public const string SearchWithAge = "7";
        public const string ReturnBack = "8";

        public const string EDIT_ADDRESS = "1";
        public const string EDIT_PHONE = "2";

        public const string EDIT_COUNT = "1";
        public const string EDIT_PRICE = "2";

        public const string EDIT_EXIT = "3";

        //출력할때 add모드인지 Search 모드인지 판단해주기 위한 매직넘버
        public enum Mode { Add=1, Search };
    }
}
