using System;
using System.Collections.Generic;
using System.IO;
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
        List<AddressVO> list;
        SmtpClient client;
        Random random;
        int number;

        public UsingAPI()
        {
            client = new SmtpClient("smtp.gmail.com", 587);
            list = new List<AddressVO>();
            random = new Random();
        }

        public int SendEMail(string email)
        {
            client.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
            client.EnableSsl = true;  // SSL을 사용한다.
            client.DeliveryMethod = SmtpDeliveryMethod.Network; // 이걸 하지 않으면 Gmail에 인증을 받지 못한다.
            client.Credentials = new System.Net.NetworkCredential("gjwlsrb1700@gmail.com", "Q1w2e3r4099!");

            MailAddress from = new MailAddress("gjwlsrb1700@gmail.com", "Hu's", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(email);

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
            return number;
        }

        public List<AddressVO> Find(string search)
        {
            string text = "";
            
            string url = "http://openapi.epost.go.kr/postal/retrieveNewAdressAreaCdService/retrieveNewAdressAreaCdService/getNewAddressListAreaCd"; // 결과가 XML로 포맷
            string ServiceKey = "KLhvysyVkBRKcl2PDgNMvw5dpdXCOLuptvhFJ3m84Pzy5PjlkUmihb5kpkDlxiIoynPEmEgpDB%2BvA%2FTMv4N%2BeA%3D%3D";

            string qry = String.Format("{0}?searchSe={1}&srchwrd={2}&encoding=UTF-8&mediaType=application/json&serviceKey={3}"
                                                                    , url, "road", search, ServiceKey);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(qry);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();

            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                text = reader.ReadToEnd();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(text);
                XmlNodeList address = xmlDoc.GetElementsByTagName("newAddressListAreaCd");
                list.Clear();
                foreach (XmlNode nodeAddress in address)
                {
                    list.Add(new AddressVO(nodeAddress["zipNo"].InnerText, nodeAddress["lnmAdres"].InnerText, nodeAddress["rnAdres"].InnerText)); 
                }
            }
            else
            {
                Console.WriteLine("Error 발생=" + status);
            }
            return list;
        }
    }
}