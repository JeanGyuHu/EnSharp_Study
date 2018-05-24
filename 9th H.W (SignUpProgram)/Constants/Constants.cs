using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu_s_SignUp
{
    class Constants
    {
        public const string CONNECTIONINFORMATION = "Server = localhost; Database = signupdb;Uid=root;Pwd=123123;";          //DB에 연결할때 사용하는 DB 연결정보
        public const int SEARCH_WITH_ID = 1;
        public const int SEARCH_WITH_EMAIL = 2;

        public const int ERROR_ID_LENGTH = 0;
        public const int ERROR_ID_SPECIAL = 1;
        public const int ERROR_ID_ALREADY = 2;
        public const int ERROR_ID_SPACE = 3;
        public const int ERRO_ID_KOREAN = 4;
        public const int SUCCESS_ID = 5;
        
        public const int ERROR_PW_LENGTH = 0;
        public const int ERROR_PW_KOREAN = 1;
        public const int ERROR_PW_SPACE = 2;
        public const int SUCCESS_PW = 3;

        public const int ERROR_NAME_LENGTH = 0;
        public const int ERROR_NAME_NOTKOREAN = 1;
        public const int ERROR_NAME_SPACE = 2;
        public const int SUCCESS_NAME = 3;

        public const int ERROR_RESINUM_FORMAT = 0;
        public const int ERROR_RESINUM_ALREADY = 1;
        public const int SUCCESS_RESINUM = 2;

        public const int ERROR_EMAIL_LENGTH = 0;
        public const int ERROR_EMAIL_SPECIAL = 1;
        public const int ERROR_EMAIL_ALREADY = 2;
        public const int ERROR_EMAIL_SPACE = 3;
        public const int ERROR_EMAIL_KOREAN = 4;
        public const int SUCCESS_EMAIL = 5;
    }
}
