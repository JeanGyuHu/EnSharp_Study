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
    /// SideMenu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SideMenu : UserControl
    {
        DrawingBoard drawingBoard;

        public SideMenu(DrawingBoard drawingBoard)
        {
            InitializeComponent();

            this.drawingBoard = drawingBoard;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender == penButton)
            {
                drawingBoard.SetDrawMode(Convert.ToString(Constants.MODE.PEN));
            }
            else if(sender == recButton)
            {
                drawingBoard.SetDrawMode(Convert.ToString(Constants.MODE.RECT));
            }
            else if(sender == cirButton)
            {
                drawingBoard.SetDrawMode(Convert.ToString(Constants.MODE.CIRCLE));
            }
            else if(sender == lineButton)
            {
                drawingBoard.SetDrawMode(Convert.ToString(Constants.MODE.LINE));
            }
            else if(sender == eraseButton)
            {
                drawingBoard.SetDrawMode(Convert.ToString(Constants.MODE.ERASE));
            }
            else if (sender == cursorButton)
            {
                drawingBoard.SetDrawMode(Convert.ToString(Constants.MODE.SELECT));
            }
            else if(sender == spoidButton)
            {
                drawingBoard.SetDrawMode(Convert.ToString(Constants.MODE.SPOID));
            }
            else if(sender == paintButton)
            {
                drawingBoard.SetDrawMode(Convert.ToString(Constants.MODE.PAINT));
            }
            else if(sender == thick1Button)
            {
                drawingBoard.SetDrawSize(Convert.ToInt32(Constants.THICK.ONE));
            }
            else if (sender == thick2Button)
            {
                drawingBoard.SetDrawSize(Convert.ToInt32(Constants.THICK.TWO));
            }
            else if (sender == thick3Button)
            {
                drawingBoard.SetDrawSize(Convert.ToInt32(Constants.THICK.THREE));
            }
            else if (sender == thick4Button)
            {
                drawingBoard.SetDrawSize(Convert.ToInt32(Constants.THICK.FOUR));
            }
            else if (sender == thick5Button)
            {
                drawingBoard.SetDrawSize(Convert.ToInt32(Constants.THICK.FIVE));
            }
            else if (sender == thick6Button)
            {
                drawingBoard.SetDrawSize(Convert.ToInt32(Constants.THICK.SIX));
            }
        }

        private void ColorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorBox.SelectedIndex.Equals(0))
            {
                drawingBoard.SetDrawColor(Brushes.Black);
                color.Background = Brushes.Black;
            }
            else if (colorBox.SelectedIndex.Equals(1))
            {
                drawingBoard.SetDrawColor(Brushes.Red);
                color.Background = Brushes.Red;
            }
            else if (colorBox.SelectedIndex.Equals(2))
            {
                drawingBoard.SetDrawColor(Brushes.Yellow);
                color.Background = Brushes.Yellow;
            }
            else if (colorBox.SelectedIndex.Equals(3))
            {
                drawingBoard.SetDrawColor(Brushes.Green);
                color.Background = Brushes.Green;
            }
            else if (colorBox.SelectedIndex.Equals(4))
            {
                drawingBoard.SetDrawColor(Brushes.Blue);
                color.Background = Brushes.Blue;
            }
            else if (colorBox.SelectedIndex.Equals(5))
            {
                drawingBoard.SetDrawColor(Brushes.DarkBlue);
                color.Background = Brushes.DarkBlue;
            }
            else if (colorBox.SelectedIndex.Equals(6))
            {
                drawingBoard.SetDrawColor(Brushes.Purple);
                color.Background = Brushes.Purple;
            }
        }
    }
}
