using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Windows;
using System.Xml;

namespace Hu_s_SignUp
{
    class UsingAPI
    {
        SmtpClient client;
        Random random;
        int number;

        public UsingAPI()
        {
            client = new SmtpClient("smtp.gmail.com", 587);
            random = new Random();
        }

        public void SendEMail()
        {
            client.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
            client.EnableSsl = true;  // SSL을 사용한다.
            client.DeliveryMethod = SmtpDeliveryMethod.Network; // 이걸 하지 않으면 Gmail에 인증을 받지 못한다.
            client.Credentials = new System.Net.NetworkCredential("gjwlsrb1700@gmail.com", "Hsjk0629!");

            MailAddress from = new MailAddress("gjwlsrb1700@gmail.com", "Hu's", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress("gjwlsrb1700@gmail.com");

            MailMessage message = new MailMessage(from, to);
            number = random.Next(111111, 999999);
            message.Body = "안녕하세요. Hu's SignUp Program입니다." + Environment.NewLine + "인증 번호는 " + number;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "Hu's SignUp 인증메일입니다.";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            try
            {
                // 동기로 메일을 보낸다.
                client.Send(message);

                // Clean up.
                message.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static string Find(string searchWord, int page, int count, List<string> v, out int n)
        {
            n = 0;
            try
            {
                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(
                    "http://openapi.epost.go.kr/postal/retrieveNewAdressAreaCdSearchAllService/retrieveNewAdressAreaCdSearchAllService/getNewAddressListAreaCdSearchAll"
                    + "?ServiceKey=KLhvysyVkBRKcl2PDgNMvw5dpdXCOLuptvhFJ3m84Pzy5PjlkUmihb5kpkDlxiIoynPEmEgpDB%2BvA%2FTMv4N%2BeA%3D%3D" // 서비스키
                    + "&countPerPage=" + 10 // 페이지당 출력될 개수를 지정(최대 50)
                    + "&currentPage=" + 1 // 출력될 페이지 번호
                    + "&srchwrd=" + HttpUtility.UrlPathEncode(searchWord) // 검색어
                    );
                rq.Headers = new WebHeaderCollection();
                rq.Headers.Add("Accept-language", "ko");
                bool bOk = false; // <successYN>Y</successYN> 획득 여부
                searchWord = null; // 에러 메시지
                HttpWebResponse rp = (HttpWebResponse)rq.GetResponse();
                XmlTextReader r = new XmlTextReader(rp.GetResponseStream());

                while (r.Read())
                {
                    if (r.NodeType == XmlNodeType.Element)
                    {
                        if (bOk)
                        {
                            if (r.Name == "zipNo" || // 우편번호
                                r.Name == "lnmAdres" || // 도로명 주소
                                r.Name == "rnAdres") // 지번 주소
                            {
                                v.Add(r.ReadString());
                            }
                            else if (r.Name == "totalCount") // 전체 검색수
                            {
                                int.TryParse(r.ReadString(), out n);
                            }
                            // else if (r.Name == "currentPage") // 현재 페이지 번호
                            // {
                            //  int.TryParse(r.ReadString(), p);
                            // }
                        }
                        else
                        {
                            if (r.Name == "successYN")
                            {
                                if (r.ReadString() == "Y") bOk = true; // 검색 성공
                            }
                            else if (r.Name == "errMsg") // 에러 메시지
                            {
                                searchWord = r.ReadString();
                                break;
                            }
                        }
                    }
                }

                r.Close();
                rp.Close();

                if (searchWord == null)
                { // OK!
                    if (v.Count < 3)
                        searchWord = "검색결과가 없습니다.";
                }
            }
            catch (Exception e)
            {
                searchWord = e.Message;
            }
            return searchWord;
        }
    }
}