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
        private string responseFromServer;          //검색한 결과에 대해서 넘어온 string 정보 값
        private StringBuilder getParams;            //API를 통해 요청하기 위한 문장을 만들기 위한 스트링빌더
        private List<ImageData> imageList = new List<ImageData>();      //파싱한 정보를 저장하기 위한 리스트

        //기본 생성자 초기화를 한다.
        public ParsingData()
        {
            getParams = new StringBuilder();
        }

        /// <summary>
        /// API를 이용하여 내가 원하는 질문에 대한 검색 결과를 요청한다.
        /// </summary>
        /// <param name="title">내가 검색하고자 하는 검색어</param>
        /// <returns>검색결과 string 값</returns>
        public string RequestJson(string title)
        {
            string header = "KakaoAK " + Constants.KEY;     //키값에 대한 정보
            string Url = string.Format("https://dapi.kakao.com/v2/search/image.json");  //요청 URL

            getParams.Clear();      //쿼리문 만들기
            getParams.Append("?query=" + HttpUtility.UrlEncode(title));

            HttpWebRequest wReqFirst = (HttpWebRequest)WebRequest.Create(Url + getParams);      //웹에 요청
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
        /// <summary>
        /// 파싱한 데이터들을 List에 저장 한후에 리스트를 반환한다.
        /// </summary>
        /// <param name="json">json형식으로 반환 받은 정보를 파싱하기 위함</param>
        /// <returns>필요한 정보들을 가진 이미지들에 대한 정보</returns>
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
                imageData.ImageURL = item["thumbnail_url"].ToString();
                imageList.Add(imageData);
            }

            return imageList;
        }

        /// <summary>
        /// 파싱을 통해 얻은 URL 정보를 사진으로 반환
        /// </summary>
        /// <param name="url">파싱을 통해 얻은 URL 정보</param>
        /// <returns>사진으로 변환된 bitmapImage</returns>
        public BitmapImage LoadImage(string url)   //Image URL -> Bitmap으로..
        {
            if (string.IsNullOrEmpty(url))
                return null;

            BitmapImage bimgTemp = new BitmapImage();

            bimgTemp.BeginInit();

            bimgTemp.UriSource = new Uri(url,UriKind.Absolute);

            bimgTemp.EndInit();

            return bimgTemp;
        }
    }
}