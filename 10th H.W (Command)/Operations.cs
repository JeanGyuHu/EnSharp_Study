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
        string answer;

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
                directoryInfo.Attributes = FileAttributes.ReadOnly;
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

                if(!path.Equals("C:\\"))
                {
                    Console.WriteLine("2018-05-28  오후 05:30     <DIR>         .\n2018-05-28  오후 05:30     <DIR>         ..");
                }

                foreach (var security in directoryInfo.GetFileSystemInfos().Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden)))
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
            while (true)
            {
                if (command[2].Equals(' ') && command[3].Equals(' '))
                    command = command.Remove(2, 1);
                else
                {
                    break;
                }
            }

            if (command.Equals("cd", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine(path + "\n");

            else if (Regex.IsMatch(command, @"^[cC][dD]") && Regex.IsMatch(command, @"[.]{2}\\+[.]{2}$"))
            {

                if (Directory.GetParent(path).ToString().Equals(Path.GetPathRoot(Environment.SystemDirectory)))
                    path = Path.GetPathRoot(Environment.SystemDirectory);
                else if (!path.Equals(Path.GetPathRoot(Environment.SystemDirectory)))
                    path = Directory.GetParent(Directory.GetParent(path).ToString()).ToString();


            }
            else if (Regex.IsMatch(command, @"^[cC][dD]") && Regex.IsMatch(command, @"[\\]") && !Regex.IsMatch(command, @"[^cCdD\s\\]"))
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

            else if (Regex.IsMatch(command, @"^[cC][dD]") && Directory.Exists(command.Remove(0, 3)) && !command.Remove(0, 3)[0].Equals('.'))
            {
                path = command.Remove(0, 3);
            }
            else if (Regex.IsMatch(command, @"^[cC][dD]") && Directory.Exists(path + "\\" + command.Remove(0, 3)) && !command.Remove(0, 3)[0].Equals('.'))
            {
                if (path.Equals("C:\\"))
                    path = path + command.Remove(0, 3);
                else
                    path = path + "\\" + command.Remove(0, 3);
            }
            else if (!Directory.Exists(command.Remove(0, 3)) || !Directory.Exists(path + "\\" + command.Remove(0, 3)))
            {
                print.FindPathFail();
            }

            Console.WriteLine();
        }

        public void CopyAndMove(string command, string path, string mode)
        {
            string[] copyDirectory;
            string departure = "", destination = "";
            string depName = "", desName = "";

            while (true)
            {
                if (command[4].Equals(' ') && command[5].Equals(' '))
                    command.Remove(4, 1);
                else
                {
                    break;
                }
            }
            command = command.Remove(0, 5);

            copyDirectory = command.Split(' ');

            if (copyDirectory.Count() == 1)
            {
                departure = copyDirectory[0].Substring(0, copyDirectory[0].LastIndexOf('\\'));
                depName = copyDirectory[0].Substring(copyDirectory[0].LastIndexOf('\\') + 1, copyDirectory[0].Length - copyDirectory[0].LastIndexOf('\\') - 1);

                if (!Directory.Exists(departure))
                {
                    print.GrammarError(mode, command);
                    return;
                }
            }
            else if (copyDirectory.Count() == 2 && copyDirectory[0].LastIndexOf('\\') != -1 && copyDirectory[1].LastIndexOf('\\') == -1)
            {
                departure = copyDirectory[0].Substring(0, copyDirectory[0].LastIndexOf('\\'));
                depName = copyDirectory[0].Substring(copyDirectory[0].LastIndexOf('\\') + 1, copyDirectory[0].Length - copyDirectory[0].LastIndexOf('\\') - 1);

                desName = copyDirectory[1];
            }
            else if (copyDirectory.Count() == 2 && copyDirectory[1].LastIndexOf('\\') != -1 && copyDirectory[0].LastIndexOf('\\') == -1)
            {
                destination = copyDirectory[1].Substring(0, copyDirectory[1].LastIndexOf('\\'));
                desName = copyDirectory[1].Substring(copyDirectory[1].LastIndexOf('\\') + 1, copyDirectory[1].Length - copyDirectory[1].LastIndexOf('\\') - 1);
            }
            else if (copyDirectory.Count() == 2 && copyDirectory[1].LastIndexOf('\\') != -1 && copyDirectory[0].LastIndexOf('\\') != -1)
            {
                departure = copyDirectory[0].Substring(0, copyDirectory[0].LastIndexOf('\\'));
                depName = copyDirectory[0].Substring(copyDirectory[0].LastIndexOf('\\') + 1, copyDirectory[0].Length - copyDirectory[0].LastIndexOf('\\') - 1);

                destination = copyDirectory[1].Substring(0, copyDirectory[1].LastIndexOf('\\'));
                desName = copyDirectory[1].Substring(copyDirectory[1].LastIndexOf('\\') + 1, copyDirectory[1].Length - copyDirectory[1].LastIndexOf('\\') - 1);
            }

            if (!Directory.Exists(departure) && !Directory.Exists(destination))
            {
                print.GrammarError(mode, command);
                return;
            }

            if (Directory.Exists(departure) && copyDirectory.Count().Equals(1))
            {
                string sourceFile = System.IO.Path.Combine(departure, depName);
                string destFile = System.IO.Path.Combine(path, depName);

                IsFileExist(desName, sourceFile, destFile, mode);
            }
            else if (Directory.Exists(departure) && !Directory.Exists(destination))
            {
                string sourceFile = System.IO.Path.Combine(departure, depName);
                string destFile = System.IO.Path.Combine(departure, desName);

                IsFileExist(desName, sourceFile, destFile, mode);
            }
            else if (!Directory.Exists(departure) && Directory.Exists(destination))
            {
                string sourceFile = System.IO.Path.Combine(path, copyDirectory[0]);
                string destFile = System.IO.Path.Combine(destination, desName);

                IsFileExist(desName, sourceFile, destFile, mode);
            }
            else if (Directory.Exists(departure) && Directory.Exists(destination))
            {
                string sourceFile = System.IO.Path.Combine(departure, depName);
                string destFile = System.IO.Path.Combine(destination, desName);

                IsFileExist(desName, sourceFile, destFile, mode);
            }

        }

        public void IsFileExist(string desName, string sourceFile, string destFile, string mode)
        {
            if (!File.Exists(sourceFile))
                Console.WriteLine("지정된 파일을 찾을 수 없습니다.\n");
            else if (File.Exists(sourceFile) && !File.Exists(destFile))
            {
                print.SuccessMoveCopy(mode);
                if (mode.Equals(Constants.COPY))
                    File.Copy(sourceFile, destFile);
                else if (mode.Equals(Constants.MOVE))
                    File.Move(sourceFile, destFile);
            }
            else if (File.Exists(sourceFile) && File.Exists(destFile))
            {
                YesOrNoQuestion(desName, sourceFile, destFile, mode);
            }
        }

        public void YesOrNoQuestion(string desName, string source, string destination, string mode)
        {
            Console.Write(destination + "을(를) 덮어쓰시겠습니까? (Yes/No/All):");
            answer = Console.ReadLine();

            if (answer.Equals(Constants.YES, StringComparison.OrdinalIgnoreCase) || answer.Equals("y", StringComparison.OrdinalIgnoreCase) || answer.Equals("a", StringComparison.OrdinalIgnoreCase))
                answer = Constants.YES;

            else if (answer.Equals(Constants.NO, StringComparison.OrdinalIgnoreCase) || answer.Equals("n", StringComparison.OrdinalIgnoreCase))
                answer = Constants.NO;

            else if (answer.Equals(Constants.ALL, StringComparison.OrdinalIgnoreCase))
                answer = Constants.ALL;

            switch (answer)
            {
                case Constants.YES:
                case Constants.ALL:
                    print.SuccessMoveCopy(mode);
                    if (mode.Equals(Constants.COPY))
                    {
                        File.Delete(destination);
                        File.Copy(source, destination);
                    }
                    else if (mode.Equals(Constants.MOVE))
                    {
                        File.Delete(destination);
                        File.Move(source, destination);
                    }
                    break;
                case Constants.NO:
                    print.FailMoveCopy(mode);
                    break;
            }
        }
    }
}
