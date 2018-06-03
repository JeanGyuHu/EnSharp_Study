using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Hu_s_WindowExplorer
{
    /// <summary>
    /// SideBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SideBar : UserControl
    {
        string[] drives;
        TreeViewItem[] treeRoots;
        MainPage mainPage;
        TopBar topBar;

        public SideBar()
        {
            InitializeComponent();
            drives = GetDrives();

        }

        public void SetMainPageAndTopBar(MainPage main, TopBar top)
        {
            mainPage = main;
            topBar = top;
        }

        public string[] GetDrives()
        {
            return Environment.GetLogicalDrives();
        }

        public void SetTreeChild(string drive, TreeViewItem root)
        {
            string path = drive;

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach (var files in directoryInfo.GetDirectories().Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden)))
            {
                try
                {
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;

                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri("Images\\folder.png", UriKind.Relative));

                    image.Height = 10;
                    image.Width = 10;

                    TextBlock text = new TextBlock();
                    text.Text = files.Name;
                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(text);

                    TreeViewItem item = new TreeViewItem() { Header = stackPanel };
                    item.DataContext = files.Name;
                    
                    root.Items.Add(item);
                    SetTreeChild(files.FullName.ToString(), item);
                }
                catch (Exception e) { }
            }
        }

        public void MakeTreeView()
        {
            int count = 0;
            treeRoots = new TreeViewItem[drives.Length];


            for (int i = 0; i < drives.Length; i++)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;

                TextBlock text = new TextBlock();
                text.Text = drives[i];

                Image image = new Image();
                image.Source = new BitmapImage(new Uri("Images\\harddisk.png", UriKind.Relative));

                image.Height = 10;
                image.Width = 10;

                stackPanel.Children.Add(image);
                stackPanel.Children.Add(text);

                treeRoots[i] = new TreeViewItem() { Header = stackPanel };
                treeRoots[i].DataContext = drives[i];
            }

            foreach (TreeViewItem item in treeRoots)
            {
                mainTreeView.Items.Add(item);
                SetTreeChild(drives[count], item);
                count++;
            }
        }

        public void SelectTreeView(TreeViewItem node)
        {
            if (node.DisplayMemberPath != null)
            {
                var path = node.DataContext;
                //TreeViewItem grand = GetGrandParent(node);
                for (var i = node.Parent; i != mainTreeView; i = ((TreeViewItem)i).Parent)
                {
                    if(((TreeViewItem)i).DataContext.Equals("C:\\")|| ((TreeViewItem)i).DataContext.Equals("D:\\") || ((TreeViewItem)i).DataContext.Equals("E:\\"))
                        path = ((TreeViewItem)i).DataContext.ToString() + path;
                    else
                        path = ((TreeViewItem)i).DataContext + "\\" + path;
                }

                ViewDirectoryList(path.ToString());
            }
        }

        private void ViewDirectoryList(string path)
        {
            topBar.pathTextBox.Text = path;
            mainPage.SetPath(path);
            topBar.SetPath(path);

            mainPage.SetMainPage(path);
        }

        private void MainTreeView_Selected(object sender, RoutedEventArgs e)
        {
            topBar.AddBackList(topBar.pathTextBox.Text);
            topBar.ClearForwardStack();

            SelectTreeView((TreeViewItem)e.OriginalSource);
        }
    }
}