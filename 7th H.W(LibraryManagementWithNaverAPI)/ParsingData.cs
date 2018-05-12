using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class ParsingData
    {
        private List<Book> list;

        public ParsingData()
        {
            list = new List<Book>();
        }

        public string RequestJson(string query,string category,int count)
        {
            string text = "";
            //string query = "윔피키드 Diary of a Wimpy Kid Box Set : Book 1-11 & DO-IT-YOURSELF Book"; // 검색할 문자열
            string url = "https://openapi.naver.com/v1/search/book_adv?" + category + "=" + query+"&display ="+count; // 결과가 JSON 포맷
            // string url = "https://openapi.naver.com/v1/search/blog.xml?query=" + query;  // 결과가 XML 포맷
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "1qfVtx6gi6giA4Vpr3K3"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "VQtTBnvGkp");       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();
            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                text = reader.ReadToEnd();
                //Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("Error 발생=" + status);
            }
            return text;
        }
        
        public List<Book> ParseJson(string json)
        {
            list.Clear();

            JObject obj = JObject.Parse(json);
            JArray array = JArray.Parse(obj["items"].ToString());

            foreach (JObject item in array)
            {
                Book book = new Book();
                book.Name = item["title"].ToString();
                book.Author = item["author"].ToString();
                book.Price = Convert.ToInt32(item["price"]);
                book.Pbls = item["publisher"].ToString();
                book.PblsDate = DateTime.ParseExact(item["pubdate"].ToString(),"yyyyMMdd",null);
                book.Count = 3;
                book.Isbn = item["isbn"].ToString();
                book.Information = item["description"].ToString();

                list.Add(book);
            }
            return list;
        }
    }
}
