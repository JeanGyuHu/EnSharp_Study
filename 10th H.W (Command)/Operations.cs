using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;

namespace Hu_s_Command
{
    class Operations
    {
        Print print;

        public Operations()
        {
            print = new Print();
        }

        public void Cls()
        {
            Console.Clear();
        }

        public void Help()
        {
            print.Help();
        }

        public void Dir(string path)
        {
            long fileSize = 0;
            int fileCount = 0, directoryCount = 0;

            path = @"C:\Users\gjwls\AppData";
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                
                foreach (DriveInfo d in allDrives)
                {
                    if (d.Name == "C:\\")
                    {
                        Console.WriteLine("C 드라이브의 볼륨에는 이름이 없습니다.");
                    }
                    else { }       
                }

                ManagementObject manageobject = new ManagementObject("win32_logicaldisk.deviceid=\"" + "C" + ":\"");
                manageobject.Get();

                Console.WriteLine("볼륨 일련 번호: " + manageobject["VolumeSerialNumber"].ToString().Insert(manageobject["VolumeSerialNumber"].ToString().Length/2,"-"));
                Console.WriteLine("\n" + path + " 디렉터리\n");

                foreach (var security in directoryInfo.GetFileSystemInfos())
                {
                    if (security.GetType().ToString().Equals("System.IO.FileInfo"))
                    {
                        fileSize += ((FileInfo)security).Length;
                        fileCount++;
                    }
                    else
                    {
                        directoryCount++;
                    }

                    print.PrintDirectory(security);
                }
                print.PrintFileByte(fileSize, fileCount);
                print.PrintDirectoryByte(allDrives[0].AvailableFreeSpace, directoryCount);
            }
        }

        public void Cd(string command,ref string path)
        {
            if (command.Equals("cd", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine(path + "\n");
            else if (Regex.IsMatch(command, @"^cd")) ;
            else if (Regex.IsMatch(command, @"^cd") && Regex.IsMatch(command, @"\\$"))
                path = Path.GetPathRoot(Environment.SystemDirectory);

            else if (Regex.IsMatch(command, @"^cd") && Regex.IsMatch(command, @"..$"))
                path = Directory.GetParent(path).ToString();

        }
    }
}
