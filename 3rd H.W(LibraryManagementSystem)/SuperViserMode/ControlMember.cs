using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class ControlMember
    {
        private ExceptionHandling exceptionHandling;
        private DrawControlMember drawControlMember;    //창을 그려주기 위한 객체 선언
        private AddMember addMember;                    //회원 추가 창으로 넘어가기 위해 객체 선언
        private string choice;                       //어떤 작업을 할지 선택을 받는 변수
        private bool flag = true;                       //회원관리 창을 빠져나가기 위한 Flag
        private string id;                           //아이디 입력 받는 변수
        private string phoneNumber;                  //전화번호 입력 받는 변수
        private string address;                      //주소를 입력받는 변수
        private string search;                       //어떤 값으로 검색할지 입력받는 변수
        private int count = 0;                          //리스트를 전부 검색했나 확인하기 위한 변수
        private int memberIndex = 0;                    //몇번 Member의 위치를 변경할건지 저장

        /// <summary>
        /// 생성자로써 생성되면 클래스에서 사용되는 객체들을 생성 및 초기화해준다.
        /// </summary>
        /// <param name="list">회원 정보 리스트</param>
        public ControlMember(List<Member> list){
            addMember = new AddMember(list);
            drawControlMember = new DrawControlMember();
            exceptionHandling = new ExceptionHandling();
        }

        /// <summary>
        /// 멤버 관리하는 메소드 (메인 역할)
        /// </summary>
        /// <param name="list">회원 정보 목록</param>
        public void MemberManagement(List<Member> list)
        {
            flag = true;
            while (flag)
            {
                drawControlMember.Menu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case LibraryConstants.AddNewMember:
                        addMember.DrawAndAdd(list);
                        break;

                    case LibraryConstants.EditMemberInfo:
                        DrawEdit(list);
                        break;

                    case LibraryConstants.DeleteMember:
                        DrawDelete(list);
                        break;

                    case LibraryConstants.SearchMember:
                        DrawSearch(list);
                        break;

                    case LibraryConstants.PrintMemberInfo:
                        DrawPrint(list);
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
        public void DrawEdit(List<Member> list)
        {
            drawControlMember.Information(list);

            drawControlMember.EditScreen();

            id = Console.ReadLine();
            if (id.Equals("0"))
                return;
            count = 0;
            foreach(Member mem in list)
            {
                if (mem.Id.Equals(id))
                {
                    memberIndex = list.IndexOf(mem);
                    break;
                }
                count++;
            }
            if (count.Equals(list.Count))
                DrawEdit(list);
            else
            {
                DrawPhoneNum(list);
                if (phoneNumber.Equals("0"))
                    return;
                DrawAddress(list);
                if (address.Equals("0"))
                    return;
                list[memberIndex].PhoneNumber = phoneNumber;
                list[memberIndex].Address = address;

                drawControlMember.EditSuccess();
            }

        }
        /// <summary>
        /// 주소 입력받는 메소드
        /// </summary>
        public void DrawAddress(List<Member> list)
        {
            Console.Clear();

            drawControlMember.WriteAddress((int)LibraryConstants.Mode.Add);
            address = Console.ReadLine();
            if (address.Equals("0"))
                return;
            if (address.Equals("1"))
                DrawPhoneNum(list);
            if (!exceptionHandling.CheckAddress(address))
            {
                DrawAddress(list);
            }
        }
        /// <summary>
        /// 전화번호 입력받는 메소드
        /// </summary>
        public void DrawPhoneNum(List<Member> list)
        {
            Console.Clear();
            drawControlMember.WritePhone((int)LibraryConstants.Mode.Add);
            phoneNumber = Console.ReadLine();
            if (phoneNumber.Equals("0"))
                return;
            if (phoneNumber.Equals("1"))
                DrawEdit(list);
            if (!exceptionHandling.CheckPhone(phoneNumber))
                DrawPhoneNum(list);
        }
        /// <summary>
        /// 삭제하는 하는 부분에서 아이디를 받고 체크해주는 역할을 한다.
        /// </summary>
        /// <param name="list">회원 목록 리스트</param>
        public void DeleteSub(List<Member> list)
        {
            drawControlMember.Information(list);

            drawControlMember.DeleteScreen();
            id = Console.ReadLine();

            if (!exceptionHandling.CheckId(id))
                DeleteSub(list);
        }
        /// <summary>
        /// 삭제하는 창을 그리고 삭제하는 메소드
        /// </summary>
        /// <param name="list"></param>
        public void DrawDelete(List<Member> list)
        {
            count = 0;
            DeleteSub(list);

            for (int i = 0;i<list.Count;i++)
            {
                if (list[i].Id.Equals(id))
                {
                    list.RemoveAt(i);
                    drawControlMember.DeleteSuccess();
                    return;
                }
                count++;
            }
            if (count.Equals(list.Count))
                drawControlMember.DeleteFailed();
        }
        /// <summary>
        /// 검색 기능을 담당하는 메소드
        /// </summary>
        /// <param name="list"></param>
        public void DrawSearch(List<Member> list)
        {
            drawControlMember.SearchMenu();
            id = Console.ReadLine();
            Console.Clear();
            switch (id)
            {
                case LibraryConstants.SearchWithName:
                    SearchSub(list, LibraryConstants.SearchWithName);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    drawControlMember.SearchWithName(list,search);
                    break;
                case LibraryConstants.SearchWithResidentNum:
                    SearchSub(list, LibraryConstants.SearchWithResidentNum);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    drawControlMember.SearchWithResidentNum(list, search);
                    break;
                case LibraryConstants.SearchWithId:
                    SearchSub(list, LibraryConstants.SearchWithId);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    drawControlMember.SearchWithId(list, search);
                    break;
                case LibraryConstants.SearchWithPassword:
                    SearchSub(list, LibraryConstants.SearchWithPassword);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    drawControlMember.SearchWithPassword(list, search);
                    break;

                case LibraryConstants.SearchWithOverdue:
                    SearchSub(list, LibraryConstants.SearchWithOverdue);
                    if (search.Equals("-1")) return;
                    drawControlMember.Category();
                    drawControlMember.SearchWithOverdue(list, search);
                    break;
                case LibraryConstants.SearchWithAddress:
                    SearchSub(list, LibraryConstants.SearchWithAddress);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    drawControlMember.SearchWithAddress(list, search);
                    break;
                case LibraryConstants.SearchWithPhone:
                    SearchSub(list, LibraryConstants.SearchWithPhone);
                    if (search.Equals("0")) return;
                    drawControlMember.Category();
                    drawControlMember.SearchWithPhone(list, search);
                    break;
                case LibraryConstants.ReturnBack:
                    break;
                default:
                    DrawSearch(list);
                    break;
            }
            
        }

        /// <summary>
        /// 탐색할 때 입력 값에 대한 예외처리를 해주는 메소드
        /// 들어온 enum 값에 따라 해당 작업을 한다.
        /// </summary>
        /// <param name="list">회원 정보 리스트</param>
        /// <param name="mode">어떤 카테고리로 검색할지</param>
        public void SearchSub(List<Member> list,string mode)
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
                        SearchSub(list, LibraryConstants.SearchWithName);
                    }
                    break;
                case LibraryConstants.SearchWithResidentNum:
                    drawControlMember.WriteResidentNum((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckResidentNum(search))
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchWithResidentNum);
                    }
                    break;
                case LibraryConstants.SearchWithId:
                    drawControlMember.WriteSignId((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if(!exceptionHandling.CheckId(search))
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchWithId);
                    }
                        
                    break;
                case LibraryConstants.SearchWithPassword:
                    drawControlMember.WriteSignPassword((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckPw(search))
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchWithPassword);
                    }
                    break;

                case LibraryConstants.SearchWithOverdue:
                    drawControlMember.WriteOverdue((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("-1")) return;
                    if (exceptionHandling.CheckBookCount(search).Equals(-1))
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchWithOverdue);
                    }
                    break;
                case LibraryConstants.SearchWithAddress:
                    drawControlMember.WriteAddress((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckAddress(search))
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchWithAddress);
                    }
                        break;
                case LibraryConstants.SearchWithPhone:
                    drawControlMember.WritePhone((int)LibraryConstants.Mode.Search);
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckPhone(search))
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchWithPhone);
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
        public void DrawPrint(List<Member> list)
        {
            drawControlMember.Information(list);

            drawControlMember.PressAnyKey();
        }
        
    }
}
