﻿using System;
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

        public void Dir(string command, string path)
        {
            long fileSize = 0;
            int fileCount = 0, directoryCount = 0;
            if (!command.Equals(Constants.DIR, StringComparison.OrdinalIgnoreCase))
            {
                while (true)
                {
                    if (command[3].Equals(' ') && command[4].Equals(' '))
                        command = command.Remove(3, 1);
                    else
                        break;
                }
                path = command.Remove(0, 4);
            }
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

                Console.WriteLine("볼륨 일련 번호: " + manageobject["VolumeSerialNumber"].ToString().Insert(manageobject["VolumeSerialNumber"].ToString().Length / 2, "-"));
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

        public void Cd(string command, ref string path)
        {
            if (command.Equals("cd", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine(path + "\n");

            else if (Regex.IsMatch(command, @"^[cC][dD]") && Regex.IsMatch(command, @"[.]{2}\\+[.]{2}$"))
            {
                if (!path.Equals(Path.GetPathRoot(Environment.SystemDirectory)))
                    path = Directory.GetParent(Directory.GetParent(path).ToString()).ToString();

                else if (Directory.GetParent(path).ToString().Equals(Path.GetPathRoot(Environment.SystemDirectory)))
                    path = Path.GetPathRoot(Environment.SystemDirectory);
            }
            else if (Regex.IsMatch(command, @"^[cC][dD]") && Regex.IsMatch(command, @"\\$") && !Regex.IsMatch(command, @"[^cCdD\s\\]"))
            {
                if (Regex.IsMatch(command, @"\\\\"))
                    print.NotApplyAddress();
                else
                    path = Path.GetPathRoot(Environment.SystemDirectory);
            }
            else if (Regex.IsMatch(command, @"^[cC][dD]") && Regex.IsMatch(command, @"[.][.]$") && !Regex.IsMatch(command, @"[.][.][.]"))
            {
                if (!path.Equals(Path.GetPathRoot(Environment.SystemDirectory)))
                    path = Directory.GetParent(path).ToString();
            }

            while (true)
            {
                if (command[2].Equals(' ') && command[3].Equals(' '))
                    command = command.Remove(2, 1);
                else
                {
                    break;
                }   
            }

            if (Regex.IsMatch(command, @"^[cC][dD]") && Directory.Exists(command.Remove(0, 3)) && !command.Remove(0, 3)[0].Equals('.'))
            {
                path = command.Remove(0, 3);
            }
            else if (Regex.IsMatch(command, @"^[cC][dD]") && Directory.Exists(path + "\\" + command.Remove(0, 3)) && !command.Remove(0, 3)[0].Equals('.'))
            {
                path = path + "\\" + command.Remove(0, 3);
            }
            else if (!Directory.Exists(command.Remove(0, 3)) || !Directory.Exists(path + "\\" + command.Remove(0, 3)))
            {
                print.FindPathFail();
            }

            Console.WriteLine();
        }

        public void Move()
        {

        }

        public void Copy()
        {

        }
    }
}
