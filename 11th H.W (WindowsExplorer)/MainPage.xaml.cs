using System;
using System.Collections.Generic;
using System.IO;
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

namespace Hu_s_WindowExplorer
{
    /// <summary>
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            SetMainPage();
        }

        public void SetMainPage()
        {
            listView.Items.Clear();    // 전에 있던 목록들을 지우고 새로 나열함.

            string[] directories = Directory.GetDirectories("C:\\Users\\gjwls\\Desktop");

            foreach (string directory in directories)    // 폴더 나열
            {
                DirectoryInfo info = new DirectoryInfo(directory);
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("Images\\folder.png",UriKind.Relative));
                StackPanel stack = new StackPanel();
               
                Label lbl = new Label();
                lbl.Width = 40;
                lbl.Content = info.Name;
                img.Width = 30;
                img.Height = 30;
                stack.Children.Add(img);
                stack.Children.Add(lbl);
                listView.Items.Add(stack);
            }

            string[] files = Directory.GetFiles("C:\\Users\\gjwls\\Desktop");

            foreach (string file in files)    // 파일 나열
            {
                FileInfo info = new FileInfo(file);
                StackPanel stack = new StackPanel();
                Image img = new Image();
                Label lbl = new Label();
                lbl.Content = info.Name;
                lbl.Width = 40;
                
                img.Source = GetIcon(file);
                img.Width = 30;
                img.Height = 30;
                stack.Children.Add(img);
                stack.Children.Add(lbl);
                listView.Items.Add(stack);
            }
        }

        public ImageSource GetIcon(string filename)       //File 경로에서 Image 추출
        {
            ImageSource icon;

            using (System.Drawing.Icon sysicon = System.Drawing.Icon.ExtractAssociatedIcon(filename))
            {
                icon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                sysicon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            }
            return icon;
        }
    } 
}
