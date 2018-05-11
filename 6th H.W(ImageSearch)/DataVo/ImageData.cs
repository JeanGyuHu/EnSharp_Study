using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSearch
{
    //API를 통해서 받은 이미지를 저장하기 위한 VO
    class ImageData
    {
        private int width;          //사진 너비
        private int height;         //사진 높이
        private string imageURL;    //이미지 주소
        private string tumbNailURL; //이미지 썸네일 주소

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public string ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }

        public string TumbNailURL
        {
            get { return tumbNailURL; }
            set { tumbNailURL = value; }
        }
        public ImageData()      //기본 생성자
        {
            Width = 0;
            Height = 0;
            ImageURL = "";
            TumbNailURL = "";
        }
        // 오버로딩을 통해 만든 변수들을 초기화해주는 생성자
        public ImageData(int width, int height, string imageURL,string tumbNailURL)
        {
            Width = width;
            Height = height;
            ImageURL = imageURL;
            TumbNailURL = tumbNailURL;
        }
    
    }
}
