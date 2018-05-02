using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class Start
    {
        static void Main(string[] args)
        {
            MemberDAO member = new MemberDAO();
            BookDAO book = new BookDAO();
            DatabaseException db = new DatabaseException();

            //if(db.IsInMemberDB("QNQldRn"))
            //    member.AddMember(new Member("뿌삥구", "434343-1212121", "123123", "QNqLdrn", 1, "서울시 송파구 올림픽로","010-4701-8554"));
            //member.EditMemberInformation("QNQLdrn", "123-1234-1234", "당근시 당근구 당근로");
            //member.DeleteMember("QNQn");
            //member.SearchWithName("허진규");
            //member.SearchWithQuary("Select * from member where password =" + "\"asd123\"");
            //member.SearchAll();

            //book.DeleteBook("12-12341234");
            Console.WriteLine(db.IsInBookDB("12-12341234"));
            if (db.IsInBookDB("12-12341234"))
            {
                book.AddBook(new Book("12-12341234", "호호호웃어요", 3, "뿡뿡이출판사", "뿡뿡이"));
            }

            //Console.WriteLine();

            //StartMenu startMenu = new StartMenu();
            //startMenu.StartMainMenu();
        }
    }
}
