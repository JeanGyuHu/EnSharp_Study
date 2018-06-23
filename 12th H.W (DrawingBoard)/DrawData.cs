using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Hu_s_Drawing_Board
{
    class DrawData
    {
        string mode;
        SolidColorBrush color;
        int thick;
        Point startPoint, finishPoint;

        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public SolidColorBrush Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Thick
        {
            get { return thick; }
            set { thick = value; }
        }

        public Point StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        public Point FinishPoint
        {
            get { return finishPoint; }
            set { finishPoint = value; }
        }

        public DrawData() { }
        public DrawData(string mode,SolidColorBrush color,int thick, Point one,Point two)
        {
            Mode = mode;
            Color = color;
            Thick = thick;
            StartPoint = one;
            FinishPoint = two;
        }
    }
}
