using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class ControlMember
    {
        private ExceptionHandling exceptionHandling;
        private MemberDAO memberDAO;
        private DatabaseException databaseException;
        private DrawControlMember drawControlMember;    //창을 그려주기 위한 객체 선언
        private AddMember addMember;                    //회원 추가 창으로 넘어가기 위해 객체 선언
        private string choice;                       //어떤 작업을 할지 선택을 받는 변수
        private bool flag = true;                       //회원관리 창을 빠져나가기 위한 Flag
        private string id;                           //아이디 입력 받는 변수
        private string phoneNumber;                  //전화번호 입력 받는 변수
        private string address;                      //주소를 입력받는 변수
        private string search;                       //어떤 값으로 검색할지 입력받는 변수

        /// <summary>
        /// 생성자로써 생성되면 클래스에서 사용되는 객체들을 생성 및 초기화해준다.
        /// </summary>
        /// <param name="list">회원 정보 리스트</param>
        public ControlMember(){
            addMember = new AddMember();
            memberDAO = new MemberDAO();
            drawControlMember = new DrawControlMember();
            exceptionHandling = new ExceptionHandling();
            databaseException = new DatabaseException();
        }

        /// <summary>
        /// 멤버 관리하는 메소드 (메인 역할)
        /// </summary>
        /// <param name="list">회원 정보 목록</param>
        public void MemberManagement()
        {
            flag = true;
            while (flag)
            {
                drawControlMember.Menu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case LibraryConstants.AddNewMember:
                        addMember.DrawAndAdd();
                        break;
                    case LibraryConstants.EditMemberInfo:
                        DrawEdit();
                        break;
                    case LibraryConstants.DeleteMember:
                        DrawDelete();
                        break;
                    case LibraryConstants.SearchMember:
                        DrawSearch();
                        break;
                    case LibraryConstants.PrintMemberInfo:
                        DrawPrint();
                        break;
                    case LibraryConstants.GoBeforePage:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 수정을 위해 체크해주고 그려주는 창
        /// </summary>
        /// <param name="list">회원 정보 리스트</param>
        public void DrawEdit()
        {
            drawControlMember.Category();
            memberDAO.SearchAll();
            
            drawControlMember.EditScreen();

            id = Console.ReadLine();
            if (id.Equals("0"))
                return;

            if (databaseException.IsIdInMemberDB(id))
                DrawEdit();
            else
            {
                DrawPhoneNum();
                if (phoneNumber.Equals("0"))
                    return;
                DrawAddress();
                if (address.Equals("0"))
                    return;
                memberDAO.EditMemberInformation(id, phoneNumber, address);

                drawControlMember.EditSuccess();
            }

        }
        /// <summary>
        /// 주소 입력받는 메소드
        /// </summary>
        public void DrawAddress()
        {
            Console.Clear();

            drawControlMember.WriteAddress((int)LibraryConstants.Mode.Add);
            address = Console.ReadLine();
            if (address.Equals("0"))
                return;
            if (address.Equals("1"))
                DrawPhoneNum();
            if (!exceptionHandling.CheckAddress(address))
            {
                DrawAddress();
            }
        }
        /// <summary>
        /// 전화번호 입력받는 메소드
        /// </summary>
        public void DrawPhoneNum()
        {
            Console.Clear();
            drawControlMember.WritePhone((int)LibraryConstants.Mode.Add);
            phoneNumber = Console.ReadLine();
            if (phoneNumber.Equals("0"))
                return;
            if (phoneNumber.Equals("1"))
                DrawEdit();
            if (!exceptionHandling.CheckPhone(phoneNumber))
                DrawPhoneNum();
        }
        /// <summary>
        /// 삭제하는 하는 부분에서 아이디를 받고 체크해주는 역할을 한다.
        /// </summary>
        /// <param name="list">회원 목록 리스트</param>
        public void DeleteSub()
        {
            drawControlMember.Category();
            memberDAO.SearchAll();

            drawControlMember.DeleteScreen();
            id = Console.ReadLine();

            if (!exceptionHandling.CheckId(id))
                DeleteSub();
        }
        /// <summary>
        /// 삭제하는 창을 그리고 삭제하는 메소드
        /// </summary>
        /// <param name="list"></param>
        public void DrawDelete()
        {
            DeleteSub();

            memberDAO.DeleteMember(id);
        }
        /// <summary>
        /// 검색 기능을 담당하는 메소드
        /// </summary>
        /// <param name="list"></param>
        public void DrawSearch()
        {
            drawControlMember.SearchMenu();
            id = Console.ReadLine();
            Console.Clear();
            switch (id)
            {
                case LibraryConstants.SearchWithName:
                    SearchSub(LibraryConstants.SearchWithName);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    memberDAO.SearchWithQuary("select * from member where name = \"" + search + "\"");
                    drawControlMember.PressAnyKey();
                    break;
                case LibraryConstants.SearchWithResidentNum:
                    SearchSub(LibraryConstants.SearchWithResidentNum);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    memberDAO.SearchWithQuary("select * from member where residentNumber = \"" + search + "\"");
                    drawControlMember.PressAnyKey();
                    break;
                case LibraryConstants.SearchWithId:
                    SearchSub(LibraryConstants.SearchWithId);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    memberDAO.SearchWithQuary("select * from member where id = \"" + search + "\"");
                    drawControlMember.PressAnyKey();
                    break;
                case LibraryConstants.SearchWithPassword:
                    SearchSub(LibraryConstants.SearchWithPassword);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    memberDAO.SearchWithQuary("select * from member where password = \"" + search + "\"");
                    drawControlMember.PressAnyKey();
                    break;
                case LibraryConstants.SearchWithAddress:
                    SearchSub(LibraryConstants.SearchWithAddress);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    memberDAO.SearchWithQuary("select * from member where address = \"" + search + "\"");
                    drawControlMember.PressAnyKey();
                    break;
                case LibraryConstants.SearchWithPhone:
                    SearchSub(LibraryConstants.SearchWithPhone);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    memberDAO.SearchWithQuary("select * from member where phoneNumber = \"" + search + "\"");
                    drawControlMember.PressAnyKey();
                    break;
                case LibraryConstants.ReturnBack:
                    break;
                default:
                    DrawSearch();
                    break;
            }
            
        }

        /// <summary>
        /// 탐색할 때 입력 값에 대한 예외처리를 해주는 메소드
        /// 들어온 enum 값에 따라 해당 작업을 한다.
        /// </summary>
        /// <param name="list">회원 정보 리스트</param>
        /// <param name="mode">어떤 카테고리로 검색할지</param>
        public void SearchSub(string mode)
        {
            switch (mode)
            {
                case LibraryConstants.SearchWithName:
                    drawControlMember.WriteName((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckName(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchWithName);
                    }
                    break;
                case LibraryConstants.SearchWithResidentNum:
                    drawControlMember.WriteResidentNum((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckResidentNum(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchWithResidentNum);
                    }
                    break;
                case LibraryConstants.SearchWithId:
                    drawControlMember.WriteSignId((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if(!exceptionHandling.CheckId(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchWithId);
                    }
                        
                    break;
                case LibraryConstants.SearchWithPassword:
                    drawControlMember.WriteSignPassword((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckPw(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchWithPassword);
                    }
                    break;

                case LibraryConstants.SearchWithAddress:
                    drawControlMember.WriteAddress((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckAddress(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchWithAddress);
                    }
                        break;
                case LibraryConstants.SearchWithPhone:
                    drawControlMember.WritePhone((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckPhone(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchWithPhone);
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 회원정보를 전부 띄워주는 메소드
        /// </summary>
        /// <param name="list">회원정보리스트</param>
        public void DrawPrint()
        {
            drawControlMember.Category();
            memberDAO.SearchAll();

            drawControlMember.PressAnyKey();
        }
        
    }
}
