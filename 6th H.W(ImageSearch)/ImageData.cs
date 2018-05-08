using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSearch
{
    class ImageData
    {
        public int width;
        public int height;
        public string imageURL;

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
        public ImageData()
        {
            Width = 0;
            Height = 0;
            ImageURL = "";
        }
        public ImageData(int width, int height, string imageURL)
        {
            Width = width;
            Height = height;
            ImageURL = imageURL;
        }
    
    }
}
