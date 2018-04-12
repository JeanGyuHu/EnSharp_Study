using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class ControlMember
    {
        //큰 메뉴에 대한 매직넘버
        private const string AddNewMember = "1";
        private const string EditMemberInfo = "2";
        private const string DeleteMember = "3";
        private const string SearchMember = "4";
        private const string PrintMemberInfo = "5";
        private const string Exit = "6";

        //검색 기능에서의 매직넘버
        private const string SearchWithName = "1";
        private const string SearchWithResidentNum = "2";
        private const string SearchWithId = "3";
        private const string SearchWithPassword = "4";
        private const string SearchWithOverdue = "5";
        private const string SearchWithAddress = "6";
        private const string SearchWithPhone = "7";

        private ExceptionHandling exceptionHandling;
        private DrawControlMember drawControlMember;    //창을 그려주기 위한 객체 선언
        private AddMember addMember;                    //회원 추가 창으로 넘어가기 위해 객체 선언
        private string strChoice;                       //어떤 작업을 할지 선택을 받는 변수
        private bool flag = true;                       //회원관리 창을 빠져나가기 위한 Flag
        private string strId;                           //아이디 입력 받는 변수
        private string strPhoneNumber;                  //전화번호 입력 받는 변수
        private string strAddress;                      //주소를 입력받는 변수
        private string strSearch;                       //어떤 값으로 검색할지 입력받는 변수
        private int count = 0;                          //리스트를 전부 검색했나 확인하기 위한 변수
        private int memberIndex = 0;                    //몇번 Member의 위치를 변경할건지 저장

        /// <summary>
        /// 생성자로써 생성되면 메뉴를 그리고 선택에 따라서 원하는 작업을 수행해준다.
        /// </summary>
        /// <param name="list">회원 정보 리스트</param>
        public ControlMember(List<Member> list){

            drawControlMember = new DrawControlMember();
            exceptionHandling = new ExceptionHandling();
            while (flag)
            {
                drawControlMember.DrawMenu();
                strChoice = Console.ReadLine();
                

                switch (strChoice)
                {
                    case AddNewMember:
                        addMember = new AddMember(list);
                        break;

                    case EditMemberInfo:
                        DrawEdit(list);
                        break;

                    case DeleteMember:
                        DrawDelete(list);
                        break;

                    case SearchMember:
                        DrawSearch(list);
                        break;

                    case PrintMemberInfo:
                        DrawPrint(list);
                        break;

                    case Exit:
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
            drawControlMember.DrawInformation(list);

            drawControlMember.DrawEditScreen();

            strId = Console.ReadLine();

            count = 0;
            foreach(Member mem in list)
            {
                if (mem.Id.Equals(strId))
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
                DrawPhoneNum();
                DrawAddress();

                list[memberIndex].PhoneNumber = strPhoneNumber;
                list[memberIndex].Address = strAddress;

                drawControlMember.DrawEditSuccess();
            }

        }
        /// <summary>
        /// 주소 입력받는 메소드
        /// </summary>
        public void DrawAddress()
        {
            Console.Clear();

            drawControlMember.DrawAdressScreen();
            strAddress = Console.ReadLine();
        }
        /// <summary>
        /// 전화번호 입력받는 메소드
        /// </summary>
        public void DrawPhoneNum()
        {
            Console.Clear();
            drawControlMember.DrawPhoneScreen();
            strPhoneNumber = Console.ReadLine();

            if (!exceptionHandling.CheckPhone(strPhoneNumber))
                DrawPhoneNum();
        }
        /// <summary>
        /// 삭제하는 창을 그리고 삭제하는 메소드
        /// </summary>
        /// <param name="list"></param>
        public void DrawDelete(List<Member> list)
        {
            drawControlMember.DrawInformation(list);

            drawControlMember.DrawDeleteScreen();
            strId = Console.ReadLine();

            for (int i = 0;i<list.Count;i++)
            {
                if (list[i].Id.Equals(strId))
                {
                    list.RemoveAt(i);
                }
            }

            drawControlMember.DrawDeleteSuccess();
        }
        /// <summary>
        /// 검색 기능을 담당하는 메소드
        /// </summary>
        /// <param name="list"></param>
        public void DrawSearch(List<Member> list)
        {
            drawControlMember.DrawSearchMenu();
            strId = Console.ReadLine();

            switch (strId)
            {
                case SearchWithName:
                    drawControlMember.DrawWriteName();
                    strSearch = Console.ReadLine();
                    drawControlMember.DrawCategory();
                    drawControlMember.DrawSearchWithName(list,strSearch);
                    break;
                case SearchWithResidentNum:
                    drawControlMember.DrawWriteResidentNum();
                    strSearch = Console.ReadLine();
                    drawControlMember.DrawCategory();
                    drawControlMember.DrawSearchWithResidentNum(list, strSearch);
                    break;
                case SearchWithId:
                    drawControlMember.DrawWriteSignId();
                    strSearch = Console.ReadLine();
                    drawControlMember.DrawCategory();
                    drawControlMember.DrawSearchWithId(list, strSearch);
                    break;
                case SearchWithPassword:
                    drawControlMember.DrawWriteSignPassword();
                    strSearch = Console.ReadLine();
                    drawControlMember.DrawCategory();
                    drawControlMember.DrawSearchWithPassword(list, strSearch);
                    break;

                case SearchWithOverdue:
                    drawControlMember.DrawWriteOverdue();
                    strSearch = Console.ReadLine();
                    drawControlMember.DrawCategory();
                    drawControlMember.DrawSearchWithOverdue(list, strSearch);
                    break;
                case SearchWithAddress:
                    drawControlMember.DrawWriteAddress();
                    strSearch = Console.ReadLine();
                    drawControlMember.DrawCategory();
                    drawControlMember.DrawSearchWithAddress(list, strSearch);
                    break;
                case SearchWithPhone:
                    drawControlMember.DrawWritePhone();
                    strSearch = Console.ReadLine();
                    drawControlMember.DrawCategory();
                    drawControlMember.DrawSearchWithPhone(list, strSearch);
                    break;
                default:
                    DrawSearch(list);
                    break;
            }
            
        }
        /// <summary>
        /// 회원정보를 전부 띄워주는 메소드
        /// </summary>
        /// <param name="list">회원정보리스트</param>
        public void DrawPrint(List<Member> list)
        {
            drawControlMember.DrawInformation(list);

            drawControlMember.DrawPressAnyKey();
        }
        
    }
}
