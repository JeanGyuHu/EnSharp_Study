using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Hu_s_WindowExplorer
{
    /// <summary>
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainPage : UserControl
    {
        TopBar topBar;
        string path;

        public MainPage()
        {
            InitializeComponent();
            
            
        }

        public void SetTopBar(TopBar top)
        {
            this.topBar = top;
            path = topBar.pathTextBox.Text;
        }

        public void SetPath(string path)
        {
            this.path = path;
        }

        public void SetMainPage(string path)
        {
            listView.Items.Clear();    // 전에 있던 목록들을 지우고 새로 나열함.

            string[] directories = Directory.GetDirectories(path);

            foreach (string directory in directories)    // 폴더 나열
            {
                DirectoryInfo info = new DirectoryInfo(directory);
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("Images\\folder.png",UriKind.Relative));

                MakeIcon(info.Name, img);
            }


            string[] files = Directory.GetFiles(path,"*.*",SearchOption.TopDirectoryOnly);

            foreach (string file in files)    // 파일 나열
            {
                FileInfo info = new FileInfo(file);
                Image img = new Image();
                img.Source = GetIcon(file);

                MakeIcon(info.Name, img);
            }
        }

        public void MakeIcon(string name,Image image)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Width = 120;
            stackPanel.Height = 120;

            image.Width = 120;
            image.Height = 50;

            TextBlock textBlock = new TextBlock();
            
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Width = 120;
            textBlock.Height = 60;
            textBlock.Text = name;

            stackPanel.MouseLeftButtonDown += TextBlock_MouseDoubleClick;

            stackPanel.Children.Add(image);
            stackPanel.Children.Add(textBlock);
            stackPanel.DataContext = name;
            listView.Items.Add(stackPanel);
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

        private void TextBlock_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                if (((StackPanel)sender).DataContext.ToString().IndexOf('.') == -1)
                {
                    topBar.AddBackList(path);
                    topBar.ClearForwardStack();

                    topBar.pathTextBox.Text = path + "\\" + ((StackPanel)sender).DataContext.ToString();
                    path = path + "\\" + ((StackPanel)sender).DataContext.ToString();
                    topBar.SetPath(path);
                    
                    SetMainPage(path);
                }
                else
                {
                    Process.Start("explorer.exe", path + "\\" + ((StackPanel)sender).DataContext.ToString());
                }
            }
        
        }
    } 
}
