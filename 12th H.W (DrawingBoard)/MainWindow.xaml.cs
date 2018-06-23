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
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DrawingBoard drawingBoard;
        SideMenu sideMenu;

        public MainWindow()
        {
            InitializeComponent();

            drawingBoard = new DrawingBoard();
            sideMenu = new SideMenu(drawingBoard);

            Grid.SetColumn(drawingBoard, 0);
            Grid.SetColumn(sideMenu, 1);

            mainGrid.Children.Add(drawingBoard);
            mainGrid.Children.Add(sideMenu);
        }

    }
}
