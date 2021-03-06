﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class MemberManagement
    {
        private ExceptionHandler exceptionHandler;
        private MemberDAO memberDAO;
        private DBExceptionHandler dBExceptionHandler;
        private PrintAboutControlMembers printAboutControlMembers;    //창을 그려주기 위한 객체 선언
        private LogDAO logDAO;
        private string choice;                       //어떤 작업을 할지 선택을 받는 변수
        private bool flag = true;                       //회원관리 창을 빠져나가기 위한 Flag
        private string id;                           //아이디 입력 받는 변수
        private string phoneNumber;                  //전화번호 입력 받는 변수
        private string address;                      //주소를 입력받는 변수
        private string search;                       //어떤 값으로 검색할지 입력받는 변수
        private string mode;
        /// <summary>
        /// 생성자로써 생성되면 클래스에서 사용되는 객체들을 생성 및 초기화해준다.
        /// </summary>
        /// <param name="list">회원 정보 리스트</param>
        public MemberManagement()
        {
            logDAO = new LogDAO();
            memberDAO = new MemberDAO();
            printAboutControlMembers = new PrintAboutControlMembers();
            exceptionHandler = new ExceptionHandler();
            dBExceptionHandler = new DBExceptionHandler();
        }

        /// <summary>
        /// 수정을 위해 체크해주고 그려주는 창
        /// </summary>
        /// <param name="list">회원 정보 리스트</param>
        public void PrintEdit()
        {
            printAboutControlMembers.Category();
            memberDAO.SearchAll();

            printAboutControlMembers.EditScreen();

            id = Console.ReadLine();
            if (id.Equals("0"))
                return;

            if (dBExceptionHandler.IsIdInMemberDB(id))
                PrintEdit();
            else
            {
                EditWhichOne();
            }

        }
        public void EditWhichOne()
        {
            bool exitFlag = true;

            while (exitFlag)
            {
                printAboutControlMembers.PrintEditWhich();
                mode = Console.ReadLine();

                switch (mode)
                {
                    case LibraryConstants.EDIT_ADDRESS:
                        PrintAddress();
                        if (address.Equals("0"))
                            return;
                        else if (address.Equals("1"))
                            return;
                        else
                        {
                            memberDAO.EditMemberAddress(id, address);
                            logDAO.AddLog(DateTime.Now, id + " 주소 수정", "정보 수정");
                            //drawControlMember.EditResult("S U C C E S S");
                        }
                        return;
                    case LibraryConstants.EDIT_PHONE:
                        PrintPhoneNumber();
                        if (phoneNumber.Equals("0"))
                            return;
                        else if (phoneNumber.Equals("1"))
                            return;
                        else
                        {
                            memberDAO.EditMemberPhone(id, phoneNumber);
                            logDAO.AddLog(DateTime.Now, id + " 전화번호 수정", "정보 수정");
                        }
                        //drawControlMember.EditResult("S U C C E S S");
                        return;
                    case LibraryConstants.EDIT_EXIT:
                        exitFlag = false;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 주소 입력받는 메소드
        /// </summary>
        public void PrintAddress()
        {
            Console.Clear();

            printAboutControlMembers.PrintAddress((int)LibraryConstants.Mode.Add);
            address = Console.ReadLine();
            if (address.Equals("0"))
                return;
            if (address.Equals("1"))
            {
                EditWhichOne();
                return;
            }
            if (!exceptionHandler.CheckAddress(address))
            {
                PrintAddress();
            }
        }
        /// <summary>
        /// 전화번호 입력받는 메소드
        /// </summary>
        public void PrintPhoneNumber()
        {
            Console.Clear();
            printAboutControlMembers.PrintPhone((int)LibraryConstants.Mode.Add);
            phoneNumber = Console.ReadLine();
            if (phoneNumber.Equals("0"))
                return;
            if (phoneNumber.Equals("1"))
            {
                EditWhichOne();
                return;
            }
            if (!exceptionHandler.CheckPhone(phoneNumber))
                PrintPhoneNumber();
        }
        /// <summary>
        /// 삭제하는 하는 부분에서 아이디를 받고 체크해주는 역할을 한다.
        /// </summary>
        /// <param name="list">회원 목록 리스트</param>
        public void DeleteSub()
        {
            printAboutControlMembers.Category();
            memberDAO.SearchAll();

            printAboutControlMembers.DeleteScreen();
            id = Console.ReadLine();
            if (id.Equals("0"))
                return;
            if (!exceptionHandler.CheckId(id))
                DeleteSub();
        }
        /// <summary>
        /// 삭제하는 창을 그리고 삭제하는 메소드
        /// </summary>
        /// <param name="list"></param>
        public void PrintDelete()
        {
            DeleteSub();
            if (id.Equals("0"))
                return;
            memberDAO.DeleteMember(id);
            logDAO.AddLog(DateTime.Now, id, "회원 삭제");
            printAboutControlMembers.DeleteResult("S U C C E S S");
        }
        /// <summary>
        /// 검색 기능을 담당하는 메소드
        /// </summary>
        /// <param name="list"></param>
        public void PrintSearch()
        {
            bool exitFlag = true;
            while (exitFlag)
            {
                printAboutControlMembers.SearchMenu();
                id = Console.ReadLine();
                Console.Clear();
                switch (id)
                {
                    case LibraryConstants.SEARCH_WITH_NAME:
                        SearchSub(LibraryConstants.SEARCH_WITH_NAME);
                        if (search.Equals("0")) return;
                        printAboutControlMembers.Category();
                        logDAO.AddLog(DateTime.Now, search, "회원 검색");
                        memberDAO.SearchWithQuary("select * from member where name like \"%" + search + "%\"");
                        printAboutControlMembers.PressAnyKey();
                        break;
                    case LibraryConstants.SEARCH_WITH_RESIDENT_NUMBER:
                        SearchSub(LibraryConstants.SEARCH_WITH_RESIDENT_NUMBER);
                        if (search.Equals("0")) return;
                        printAboutControlMembers.Category();
                        logDAO.AddLog(DateTime.Now, search, "회원 검색");
                        memberDAO.SearchWithQuary("select * from member where residentNumber like \"%" + search + "%\"");
                        printAboutControlMembers.PressAnyKey();
                        break;
                    case LibraryConstants.SEARCH_WITH_ID:
                        SearchSub(LibraryConstants.SEARCH_WITH_ID);
                        if (search.Equals("0")) return;
                        printAboutControlMembers.Category();
                        logDAO.AddLog(DateTime.Now, search, "회원 검색");
                        memberDAO.SearchWithQuary("select * from member where id like \"%" + search + "%\"");
                        printAboutControlMembers.PressAnyKey();
                        break;
                    case LibraryConstants.SEARCH_WITH_PASSWORD:
                        SearchSub(LibraryConstants.SEARCH_WITH_PASSWORD);
                        if (search.Equals("0")) return;
                        printAboutControlMembers.Category();
                        logDAO.AddLog(DateTime.Now, search, "회원 검색");
                        memberDAO.SearchWithQuary("select * from member where password like \"%" + search + "%\"");
                        printAboutControlMembers.PressAnyKey();
                        break;
                    case LibraryConstants.SEARCH_WITH_ADDRESS:
                        SearchSub(LibraryConstants.SEARCH_WITH_ADDRESS);
                        if (search.Equals("0")) return;
                        printAboutControlMembers.Category();
                        logDAO.AddLog(DateTime.Now, search, "회원 검색");
                        memberDAO.SearchWithQuary("select * from member where address like \"%" + search + "%\"");
                        printAboutControlMembers.PressAnyKey();
                        break;
                    case LibraryConstants.SEARCH_WITH_PHONE:
                        SearchSub(LibraryConstants.SEARCH_WITH_PHONE);
                        if (search.Equals("0")) return;
                        printAboutControlMembers.Category();
                        logDAO.AddLog(DateTime.Now, search, "회원 검색");
                        memberDAO.SearchWithQuary("select * from member where phoneNumber like \"%" + search + "%\"");
                        printAboutControlMembers.PressAnyKey();
                        break;
                    case LibraryConstants.SEARCH_WITH_AGE:
                        SearchSub(LibraryConstants.SEARCH_WITH_AGE);
                        if (search.Equals("0")) return;
                        printAboutControlMembers.Category();
                        logDAO.AddLog(DateTime.Now, search, "회원 검색");
                        memberDAO.SearchWithQuary("select * from member where age like \"%" + search + "%\"");
                        printAboutControlMembers.PressAnyKey();
                        break;
                    case LibraryConstants.RETURN_BACK:
                        exitFlag = false;
                        return;
                    default:
                        break;
                }
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
                case LibraryConstants.SEARCH_WITH_NAME:
                    printAboutControlMembers.PrintName((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    
                    break;
                case LibraryConstants.SEARCH_WITH_RESIDENT_NUMBER:
                    printAboutControlMembers.PrintResidentNum((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    
                    break;
                case LibraryConstants.SEARCH_WITH_ID:
                    printAboutControlMembers.PrintSignId((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    

                    break;
                case LibraryConstants.SEARCH_WITH_PASSWORD:
                    printAboutControlMembers.PrintSignPassword((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    
                    break;

                case LibraryConstants.SEARCH_WITH_ADDRESS:
                    printAboutControlMembers.PrintAddress((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    
                    break;
                case LibraryConstants.SEARCH_WITH_PHONE:
                    printAboutControlMembers.PrintPhone((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    
                    break;
                case LibraryConstants.SEARCH_WITH_AGE:
                    printAboutControlMembers.PrintSearchAge();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 회원정보를 전부 띄워주는 메소드
        /// </summary>
        /// <param name="list">회원정보리스트</param>
        public void PrintAll()
        {
            printAboutControlMembers.Category();
            memberDAO.SearchAll();

            printAboutControlMembers.PressAnyKey();
        }
    }
}
