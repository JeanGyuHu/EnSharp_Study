using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hu_s_Drawing_Board
{
    /// <summary>
    /// DrawingBoard.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DrawingBoard : UserControl
    {
        List<DrawData> drawList;
        DrawData drawData;

        public DrawingBoard()
        {
            InitializeComponent();
            drawList = new List<DrawData>();
            drawData = new DrawData();

            board.MouseLeftButtonDown += Board_MouseLeftButtonDown;
        }

        public void SetDrawMode(string mode)
        {
            drawData.Mode = mode;
        }
        public void SetDrawColor(SolidColorBrush color)
        {
            drawData.Color = color;
        }
        public void SetDrawSize(int size)
        {
            drawData.Thick = size;
        }

        private void Board_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch(Enum.Parse(typeof(Constants.MODE), drawData.Mode))
            {
                case Constants.MODE.PEN:
                    drawData.StartPoint = e.GetPosition(this);
                    la.Content = e.GetPosition(this).X;
                    break;
                case Constants.MODE.RECT:

                    break;
                case Constants.MODE.CIRCLE:

                    break;
                case Constants.MODE.LINE:

                    break;
                case Constants.MODE.ERASE:

                    break;
                case Constants.MODE.SELECT:

                    break;
            }
        }

        private void Board_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Board_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
