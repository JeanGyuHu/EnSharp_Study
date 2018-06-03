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
using System.Security.AccessControl;
using System.Security.Principal;

namespace Hu_s_WindowExplorer
{
    /// <summary>
    /// SideBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SideBar : UserControl
    {
        string[] drives;
        TreeViewItem[] treeRoots;

        public SideBar()
        {
            InitializeComponent();
            
            drives = GetDrives();
            MakeTreeView();
        }
        
        public string[] GetDrives()
        {
            return Environment.GetLogicalDrives();
        }

        public void SetTreeChild(string drive, TreeViewItem root)
        {
            string path = drive;

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach(var files in directoryInfo.GetDirectories().Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden)))
            {
                try
                {
                    TreeViewItem item = new TreeViewItem() { Header = files.Name };
                    root.Items.Add(item);
                    SetTreeChild(files.FullName.ToString(), item);
                }
                catch(Exception e)
                {

                }
            }
        }

        public void MakeTreeView()
        {
            int count = 0;
            treeRoots = new TreeViewItem[drives.Length];

            for(int i = 0; i < drives.Length; i++)
            {
                treeRoots[i] = new TreeViewItem() { Header = drives[i] };
            }

            foreach(TreeViewItem item in treeRoots)
            {
                mainTreeView.Items.Add(item);
                SetTreeChild(drives[count],item);
                count++;
            }
        }
    }
}





//DirectorySecurity dSecurity = Directory.GetAccessControl(files.ToString());
//dSecurity.AddAccessRule(new FileSystemAccessRule(
//       new NTAccount("Users"),
//      FileSystemRights.FullControl,
//       InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
//       PropagationFlags.None,
//       AccessControlType.Allow
//));
//   Directory.SetAccessControl(files.ToString(), dSecurity);
