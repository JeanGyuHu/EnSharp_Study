using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class LibraryConstants
    {

        //메인 화면에서 각각 어떤 창으로 갈지에 대한 매직넘버
        public const string LOGIN_SUPERVISER_MODE = "1";
        public const string LOGIN_USER_MODE = "2";
        public const string GOTO_SIGNUP_PAGE = "3";
        public const string EXIT = "4";

        //관리자 모드 메뉴에서의 매직넘버
        public const string MEMBER_CONTROL = "1";
        public const string BOOK_MANAGEMENT = "2";
        public const string CHECK_LOG = "3";
        public const string GO_RETURN = "3";
        public const string GO_BACK = "4";

        //사용자 모드에서의 매직넘버
        public const string RENT_BOOK_PAGE = "1";
        public const string EXTEND_RENTALTIME_PAGE = "2";
        public const string RETURN_BOOKS = "3";

        //관리자모드인지 유저모드인지에 대한 플래그
        public const string START_SUPERVISER_MODE = "1";
        public const string START_USER_MODE = "2";

        //책관리모드에서 각 메뉴에 대한 매직넘버
        public const string ADD_MODE = "1";
        public const string EDIT_MODE = "2";
        public const string DELETE_MODE = "3";
        public const string SEARCH_MODE = "4";
        public const string PRINT_MODE = "5";
        public const string GO_BEFORE = "6";

        //책 조회를 할때 무엇으로 검색하는 모드인지에 대한 매직넘버
        public const string SEARCH_BOOK_NO = "1";
        public const string SEARCH_BOOK_NAME = "2";
        public const string SEARCH_BOOK_COUNT = "3";
        public const string SEARCH_BOOK_AUTHOR = "4";
        public const string SEARCH_BOOK_PUBLISHER = "5";
        public const string SEARCH_BOOK_IN_NAVER = "6";
        public const string SEARCH_GO_BACK = "7";

        public const string SEARCH_NAVER_NAME = "1";
        public const string SEARCH_NAVER_PUBLISHER = "2";
        public const string SEARCH_NAVER_AUTHOR = "3";

        //멤버 관리모드에서 각 메뉴에 대한 매직넘버
        public const string ADD_NEW_MEMBER = "1";
        public const string EDIT_MEMBER_INFO = "2";
        public const string DELETE_MEMBER = "3";
        public const string SEARCH_MEMBER = "4";
        public const string PRINT_MEMBER_INFO = "5";
        public const string GO_BEFORE_PAGE = "6";

        //멤버 조회를 할때 무엇으로 검색하는지에 대한 매직넘버
        public const string SEARCH_WITH_NAME = "1";
        public const string SEARCH_WITH_RESIDENT_NUMBER = "2";
        public const string SEARCH_WITH_ID = "3";
        public const string SEARCH_WITH_PASSWORD = "4";
        public const string SEARCH_WITH_ADDRESS = "5";
        public const string SEARCH_WITH_PHONE = "6";
        public const string SEARCH_WITH_AGE = "7";
        public const string RETURN_BACK = "8";

        public const string EDIT_ADDRESS = "1";
        public const string EDIT_PHONE = "2";

        public const string EDIT_COUNT = "1";
        public const string EDIT_PRICE = "2";
        public const string EDIT_EXIT = "3";

        public const string RENTBOOK = "1";
        public const string EXTENDTIME = "2";
        public const string RETURNBOOK = "3";
        //출력할때 add모드인지 Search 모드인지 판단해주기 위한 매직넘버
        public enum Mode { Add = 1, Search };

        public const string YES = "1";
        public const string NO = "2";

        public const string CONNECTIONINFORMATION = "Server = localhost; Database = ensharpdb;Uid=root;Pwd=123123;";          //DB에 연결할때 사용하는 DB 연결정보
    }
}
