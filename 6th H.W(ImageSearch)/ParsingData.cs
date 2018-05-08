using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Media.Imaging;

namespace ImageSearch
{
    class ParsingData
    {
        private const string key = "fe5ea773dd821f940e6e707c83fb4b8c";
        private string responseFromServer;
        private StringBuilder getParams;
        private List<ImageData> imageList = new List<ImageData>();

        public ParsingData()
        {
            getParams = new StringBuilder();
        }

        public string RequestJson(string title)
        {
            string header = "KakaoAK " + key;
            string Url = string.Format("https://dapi.kakao.com/v2/search/image.json");  //요청 URL

            getParams.Clear();
            getParams.Append("?query=" + HttpUtility.UrlEncode(title));

            HttpWebRequest wReqFirst = (HttpWebRequest)WebRequest.Create(Url + getParams);
            wReqFirst.Headers.Add("Authorization", header);
            wReqFirst.ContentType = "application/json; charset=utf-8";
            wReqFirst.Method = "GET";
            wReqFirst.ServicePoint.Expect100Continue = false;

            HttpWebResponse wRespFirst = (HttpWebResponse)wReqFirst.GetResponse();
            Stream respPostStream = wRespFirst.GetResponseStream();
            StreamReader reader = new StreamReader(respPostStream, Encoding.GetEncoding("EUC-KR"), true);

            responseFromServer = reader.ReadToEnd();

            reader.Close();
            respPostStream.Close();
            wRespFirst.Close();

            return responseFromServer;
        }

        public List<ImageData> ParseJson(string json)
        {
            imageList.Clear();

            JObject obj = JObject.Parse(json);
            JArray array = JArray.Parse(obj["documents"].ToString());

            foreach (JObject item in array)
            {
                ImageData imageData = new ImageData();

                imageData.Height = Convert.ToInt32(item["height"]);
                imageData.Width = Convert.ToInt32(item["width"]);
                imageData.ImageURL = item["image_url"].ToString();
                imageList.Add(imageData);
            }

            return imageList;
        }

        public BitmapImage LoadImage(string url)   //Image URL -> Bitmap으로..
        {
 
            WebClient wc = new WebClient();

            Byte[] MyData = wc.DownloadData(url);

            wc.Dispose();

            BitmapImage bimgTemp = new BitmapImage();

            bimgTemp.BeginInit();

            bimgTemp.StreamSource = new MemoryStream(MyData);

            bimgTemp.EndInit();

            return bimgTemp;
        }
    }
}
