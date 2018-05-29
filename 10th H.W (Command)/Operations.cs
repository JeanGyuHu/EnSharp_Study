using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;

namespace Hu_s_Command
{
    class Operations
    {
        Print print;        //출력 뿌려주는 객체
        string answer;      //yesorno에 대한 대답
        List<string> list;  //추가기능을 위해 만들었지만 구현 실패
        string mode;

        /// <summary>
        /// 기본 생성자 객체들 초기화
        /// </summary>
        public Operations()
        {
            print = new Print();
            list = new List<string>();
        }

        /// <summary>
        /// 창을 클리어 하는 매서드 (cls 기능을 담당)
        /// </summary>
        public void Cls()
        {
            Console.Clear();
        }

        /// <summary>
        /// 도움말을 띄워주는 매서드
        /// </summary>
        public void Help(string command)
        {
            if (Regex.IsMatch(command, @"^[Hh][Ee][lL][pP]") && !Regex.IsMatch(command, @"[^HhEelLpP]"))
                print.Help();

            else
            {
                while (true)
                {
                    if (command[4].Equals(' ') && command[5].Equals(' '))   //dir 명령어 뒤에 space가 많을 시에 1개만 빼고 전부 제거
                        command = command.Remove(4, 1);
                    else
                        break;
                }
                command = command.Remove(0, 5);

                Console.WriteLine("이 명령은 도움말 유틸리티가 지원하지 않습니다. \"{0} /? \"를 사용해 보십시오.\n",command);
            }
                
        }

        /// <summary>
        /// 디렉토리에 있는 파일과 디렉토리에 대한 정보를 얻을 수 있다.
        /// </summary>
        /// <param name="command">우리가 입력한 명령어</param>
        /// <param name="path">현재 우리가 있는 경로</param>
        public void Dir(string command, string path)
        {
            long fileSize = 0;
            int fileCount = 0, directoryCount = 0;

            if (Regex.IsMatch(command, @"^[dD][iI][rR]") && !Regex.IsMatch(command, @"[^dDiIrR\s]")) { }

            else if (!command.Equals(Constants.DIR, StringComparison.OrdinalIgnoreCase) && Regex.IsMatch(command, @"\\"))     //Dir이 아니라 dir + 경로가 들어온 경우 앞에 dir을 없애고 경로만 남긴다
            {
                while (true)
                {
                    if (command[3].Equals(' ') && command[4].Equals(' '))   //dir 명령어 뒤에 space가 많을 시에 1개만 빼고 전부 제거
                        command = command.Remove(3, 1);
                    else
                        break;
                }
                path = command.Remove(0, 4);    //명령어 부분 제거
            }
            else if (!Regex.IsMatch(command, @"\\"))
            {
                while (true)
                {
                    if (command[3].Equals(' ') && command[4].Equals(' '))   //dir 명령어 뒤에 space가 많을 시에 1개만 빼고 전부 제거
                        command = command.Remove(3, 1);
                    else
                        break;
                }
                path = path + "\\" + command.Remove(0, 4);    //명령어 부분 제거
            }

            if (Directory.Exists(path)) //현재 존재하는 경로나 새로 입력받은 경로가 존재할때
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);  //디렉토리 정보를 얻는 객체
                DriveInfo[] allDrives = DriveInfo.GetDrives();          //드라이브 정보를 얻는 객체

                foreach (DriveInfo d in allDrives)  //모든 드라이브 정보를 가져온 후에 
                {
                    if (d.Name == path.Substring(0,3) && d.VolumeLabel =="")   //필요한 C드라이브의 이름을 확인
                    {
                        if (path.Substring(0, 1).Equals("c", StringComparison.OrdinalIgnoreCase))
                            mode = "C";
                        else if (path.Substring(0, 1).Equals("d", StringComparison.OrdinalIgnoreCase))
                            mode = "D";

                        Console.WriteLine("{0} 드라이브의 볼륨에는 이름이 없습니다.",mode);
                        break;
                    }
                    else if(d.Name == path.Substring(0, 3) && d.VolumeLabel != "")
                    {
                        if (path.Substring(0, 1).Equals("c", StringComparison.OrdinalIgnoreCase))
                            mode = "C";
                        else if (path.Substring(0, 1).Equals("d", StringComparison.OrdinalIgnoreCase))
                            mode = "D";
                        Console.WriteLine(" {0} 드라이브의 볼륨: "+d.VolumeLabel,mode);
                        break;
                    }
                    
                }

                ManagementObject manageobject = new ManagementObject("win32_logicaldisk.deviceid=\"" + mode + ":\"");    //내 컴퓨터 볼륨 일련번호를 가져오기 위한 객체
                manageobject.Get();

                Console.WriteLine("볼륨 일련 번호: " + manageobject["VolumeSerialNumber"].ToString().Insert(manageobject["VolumeSerialNumber"].ToString().Length / 2, "-"));
                Console.WriteLine("\n" + path + " 디렉터리\n");

                if((!path.Equals("C:\\")&&mode=="C")||(!path.Equals("D:\\") && mode == "D"))    //C:\\가 아닐경우에는 상위 폴더가 있으므로 .과 ..의 디렉토리가 있다
                {
                    Console.WriteLine("2018-05-28  오후 05:30     <DIR>         .\n2018-05-28  오후 05:30     <DIR>         ..");   
                }

                //경로에 있는 모든 파일과 디렉토리 정보를 가져와서 보여준다. 이때 Attribute를 이용하여 숨김파일은 나타내지 않도록 한다.
                foreach (var security in directoryInfo.GetFileSystemInfos().Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden)))
                {
                    if (security.GetType().ToString().Equals("System.IO.FileInfo"))     //파일일 경우에 개수와 바이트 수를 계산한다
                    {
                        fileSize += ((FileInfo)security).Length;
                        fileCount++;
                    }
                    else    //디렉토리의 개수를 센다.
                    {
                        directoryCount++;
                    }

                    print.PrintDirectory(security);     //입력형식에 따라 파일, 디렉토리를 출력해 준다.
                }
                print.PrintFileByte(fileSize, fileCount);       //파일 정보를 출력
                print.PrintDirectoryByte(allDrives[0].AvailableFreeSpace, directoryCount);  //디렉토리 개수와 남은 용량 표현
            }

        }

        /// <summary>
        /// 디렉토리간의 이동을 할때 사용하는 매서드
        /// 디렉토리에 들어가거나 초기로 돌아가거나 입력한 경로로 이동한다.
        /// </summary>
        /// <param name="command">우리가 입력한 명령어</param>
        /// <param name="path">현재 우리가 있는 경로</param>
        public void Cd(string command, ref string path)
        {

            if (command.Equals("cd", StringComparison.OrdinalIgnoreCase))   //명령어 없이 cd만 입력 했을시
            {
                Console.WriteLine(path + "\n");
                return;
            }
            while (true)    //cd 뒤에 공백이 많을 시에 1개만 빼고 전부 삭제
            {
                if (command[2].Equals(' ') && command[3].Equals(' '))
                    command = command.Remove(2, 1);
                else
                {
                    break;
                }
            }
            
            //cd ..\\\\\\.. 2개 상위 폴더로 가는 것에 대한 예외처리
            if (Regex.IsMatch(command, @"^[cC][dD]") && Regex.IsMatch(command, @"[.]{2}\\+[.]{2}$") && !Regex.IsMatch(command, @"[.]{3}[\\]"))
            {
                //상위 디렉토리가 1개밖에 없는 경우
                if (Directory.GetParent(path).ToString().Equals(Path.GetPathRoot(Environment.SystemDirectory)))
                    path = Path.GetPathRoot(Environment.SystemDirectory);
                else if (!path.Equals(Path.GetPathRoot(Environment.SystemDirectory)))   //상위폴더가 2개있는 경우
                    path = Directory.GetParent(Directory.GetParent(path).ToString()).ToString();
            }
            //cd \ 에 대한 처리
            else if (Regex.IsMatch(command, @"^[cC][dD]") && Regex.IsMatch(command, @"[\\]") && !Regex.IsMatch(command, @"[^cCdD\s\\]"))
            {
                if (Regex.IsMatch(command, @"\\\\"))    //cd  \\ 백슬레시가 2개 이상 있는 경우 접근성에 대한 에러
                    print.NotApplyAddress();
                else
                    path = Path.GetPathRoot(Environment.SystemDirectory);
            }
            //cd ..에 대한 처리
            else if (Regex.IsMatch(command, @"^[cC][dD]") && Regex.IsMatch(command, @"[.]{2}[\\]*[.]*$"))
            {
                if ((!Regex.IsMatch(command.Remove(0,3), @"[^.]") && Regex.IsMatch(command, @"[.]{3}")))    //.만 있을때 점이 3개이상이면 아무 일도 일어나지 않는다. 
                {
                    Console.WriteLine();
                    return;
                }

                else if (Regex.IsMatch(command, @"[.][.][.][\\]"))  //cd 하고 백슬래시 전에 .이 2개보다 많으면 아무 일도 일어나지 않는다.
                {
                    Console.WriteLine();
                    return;
                }
                else if (!path.Equals(Path.GetPathRoot(Environment.SystemDirectory)))   //현재 경로에서 상위경로가 있을때 상위 경로로
                    path = Directory.GetParent(path).ToString();
            }

            //입력한 경로로 경로를 이동한다. (이때 ...으로 시작하는 경로가 존재한다고 판단이 되어 그 부분에 대해서 안되게 막음
            //ex) cd c:\Users
            else if (Regex.IsMatch(command, @"^[cC][dD]") && Directory.Exists(command.Remove(0, 3)) && !command.Remove(0, 3)[0].Equals('.'))
            {
                path = command.Remove(0, 3);
            }

            //현재 경로에서 있는 디렉토리로 들어간다
            //ex cd Desktop
            else if (Regex.IsMatch(command, @"^[cC][dD]") && Directory.Exists(path + "\\" + command.Remove(0, 3)) && !command.Remove(0, 3)[0].Equals('.'))
            {
                if (path.Equals("C:\\")) 
                    path = path + command.Remove(0, 3);
                else if (path.Equals("D:\\"))
                    path = path + command.Remove(0, 3);
                else
                    path = path + "\\" + command.Remove(0, 3);
            }
            //경로가 존재하지 않을때
            else if (!Directory.Exists(command.Remove(0, 3)) || !Directory.Exists(path + "\\" + command.Remove(0, 3)))
            {
                print.FindPathFail();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// copy 와 move는 응답 출력과 사용되는 메서드가 조금만 다르므로 묶어서 같이 사용한다
        /// </summary>
        /// <param name="command">우리가 입력한 명령어</param>
        /// <param name="path">현재 있는 경로</param>
        /// <param name="mode">copy 모드인지 move 모드인지</param>
        public void CopyAndMove(string command, string path, string mode)
        {
            string[] copyDirectory;
            string departure = "", destination = "";
            string depName = "", desName = "";

            while (true)    //copy ,move 뒤에 공백 1개빼고 전부 제거
            {
                if (command[4].Equals(' ') && command[5].Equals(' '))
                    command.Remove(4, 1);
                else
                {
                    break;
                }
            }
            command = command.Remove(0, 5); //copy,move 명령어 제거

            copyDirectory = command.Split(' '); //공백을 가지고 나눈다.

            if (copyDirectory.Count() == 1)     //공백이 없이 하나의 경로일때
            {
                departure = copyDirectory[0].Substring(0, copyDirectory[0].LastIndexOf('\\'));      //복사를 할 파일경로
                depName = copyDirectory[0].Substring(copyDirectory[0].LastIndexOf('\\') + 1, copyDirectory[0].Length - copyDirectory[0].LastIndexOf('\\') - 1); //복사할 파일명

                if (!Directory.Exists(departure))   //경로가 존재하는지 확인
                {
                    print.GrammarError(mode, command);  //없으면 에러문
                    return;
                }
            }
            //2개로 나눠졌을때 앞쪽이 경로이고 뒤쪽은 그냥 파일명일때
            else if (copyDirectory.Count() == 2 && copyDirectory[0].LastIndexOf('\\') != -1 && copyDirectory[1].LastIndexOf('\\') == -1)
            {
                departure = copyDirectory[0].Substring(0, copyDirectory[0].LastIndexOf('\\'));
                depName = copyDirectory[0].Substring(copyDirectory[0].LastIndexOf('\\') + 1, copyDirectory[0].Length - copyDirectory[0].LastIndexOf('\\') - 1);

                desName = copyDirectory[1];
            }

            //else if(copyDirectory.Count() == 2 && File.Exists(path+"\\"+copyDirectory[0]) &&)
            //2개로 나눠졌을때 앞쪽이 파일명이고 뒤쪽이 경로일때
            else if (copyDirectory.Count() == 2 && copyDirectory[1].LastIndexOf('\\') != -1 && copyDirectory[0].LastIndexOf('\\') == -1)
            {
                destination = copyDirectory[1].Substring(0, copyDirectory[1].LastIndexOf('\\'));
                desName = copyDirectory[1].Substring(copyDirectory[1].LastIndexOf('\\') + 1, copyDirectory[1].Length - copyDirectory[1].LastIndexOf('\\') - 1);
            }
            //2개로 나눠졌을때 앞쪽과 뒤쪽이 전부 경로일때
            else if (copyDirectory.Count() == 2 && copyDirectory[1].LastIndexOf('\\') != -1 && copyDirectory[0].LastIndexOf('\\') != -1)
            {
                departure = copyDirectory[0].Substring(0, copyDirectory[0].LastIndexOf('\\'));
                depName = copyDirectory[0].Substring(copyDirectory[0].LastIndexOf('\\') + 1, copyDirectory[0].Length - copyDirectory[0].LastIndexOf('\\') - 1);

                destination = copyDirectory[1].Substring(0, copyDirectory[1].LastIndexOf('\\'));
                desName = copyDirectory[1].Substring(copyDirectory[1].LastIndexOf('\\') + 1, copyDirectory[1].Length - copyDirectory[1].LastIndexOf('\\') - 1);
            }

            //앞쪽과 뒤쪽이 둘다 경로가 아닐때
            if (!Directory.Exists(departure) && !Directory.Exists(destination))
            {
                string destFile="";

                if (Directory.Exists(path + "\\" + destination) && Directory.Exists(path + "\\" + departure))
                {
                    string depart = path + "\\" + departure;
                    string dest = path + "\\" + destination;

                    string sourceFile = System.IO.Path.Combine(depart, depName);
                    destFile = System.IO.Path.Combine(dest, desName);
                    IsFileExist(desName, sourceFile, destFile, mode);   //copy or move
                }
                else
                    print.GrammarError(mode, command);  //에러문
                return;
            }
            //1개의 경로로만 명령어가 되어있고 그 경로가 존재할때 
            if (Directory.Exists(departure) && copyDirectory.Count().Equals(1))
            {
                string sourceFile = System.IO.Path.Combine(departure, depName);
                string destFile = System.IO.Path.Combine(path, depName);

                IsFileExist(desName, sourceFile, destFile, mode);   //파일에 move,copy 가능성을 체크 후 동작
            }
            //보낼 주소가 있고 받은 주소에 없을 때
            else if (Directory.Exists(departure) && !Directory.Exists(destination))
            {
                string destFile;

                string sourceFile = System.IO.Path.Combine(departure, depName);
                if (Directory.Exists(path + "\\" + destination) && Regex.IsMatch(destination,@"\\")) {
                    string space = path + "\\" + destination;
                    destFile = System.IO.Path.Combine(space, desName);
                }
                else
                    destFile = System.IO.Path.Combine(departure, desName);

                IsFileExist(desName, sourceFile, destFile, mode);   //copy or move
            }
            //보내는게 없을때
            else if (!Directory.Exists(departure) && Directory.Exists(destination))
            {
                string sourceFile = System.IO.Path.Combine(path, copyDirectory[0]);
                string destFile = System.IO.Path.Combine(destination, desName);

                IsFileExist(desName, sourceFile, destFile, mode);
            }
            //둘다 경로가 존재할때
            else if (Directory.Exists(departure) && Directory.Exists(destination))
            {
                string sourceFile = System.IO.Path.Combine(departure, depName);
                string destFile = System.IO.Path.Combine(destination, desName);

                IsFileExist(desName, sourceFile, destFile, mode);
            }
        }

        //파일이 존재하는 여부에 따라서 각각 처리
        public void IsFileExist(string desName, string sourceFile, string destFile, string mode)
        {
            //파일 없을시
            if (!File.Exists(sourceFile))
                Console.WriteLine("지정된 파일을 찾을 수 없습니다.\n");
            //보내는 파일은 있고 저장할 위치에 파일이 없는 경우
            else if (File.Exists(sourceFile) && !File.Exists(destFile))
            {
                print.SuccessMoveCopy(mode);
                if (mode.Equals(Constants.COPY))
                    File.Copy(sourceFile, destFile);
                else if (mode.Equals(Constants.MOVE))
                    File.Move(sourceFile, destFile);

            }
            //둘다 있는 경우
            else if (File.Exists(sourceFile) && File.Exists(destFile))
            {
                YesOrNoQuestion(desName, sourceFile, destFile, mode);
            }
        }

        /// <summary>
        /// 있는 경우에 덮어 쓸지 안쓸지에 대해서 확인하는 메서드
        /// </summary>
        /// <param name="desName">저장할 파일명</param>
        /// <param name="source">복사될 파일 경로</param>
        /// <param name="destination">복사할 파일 경로 </param>
        /// <param name="mode">move 할지 copy할지</param>
        public void YesOrNoQuestion(string desName, string source, string destination, string mode)
        {
            bool flag = true;
            while (flag)
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
                        flag = false;
                        break;
                    case Constants.NO:
                        print.FailMoveCopy(mode);
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 드라이브를 변경할때 사용하는 메서드
        /// </summary>
        /// <param name="path">현재 경로</param>
        /// <param name="command">우리가 입력한 명령어</param>
        /// <param name="mode">현재 C인지 D인지</param>
        public void ChangeDrive(ref string path, string command, string mode)
        {
            command = command + "\\";

            string[] drives = Environment.GetLogicalDrives();

            if(mode.Equals(Constants.CDRIVE))
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                return;
            }

            foreach(string drive in drives)
            {
                if (command.Equals(drive,StringComparison.OrdinalIgnoreCase))
                    path = drive;
            }
            
        }
        //자동완성을 위해 현재 경로에 있는 폴더 명들을 받아온다.
        //public List<string> FindDirectories(string path)
        //{
        //    DirectoryInfo directoryInfo = new DirectoryInfo(path);
        //    list.Clear();

        //    foreach (var dir in directoryInfo.GetFileSystemInfos().Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden)))
        //    {
        //        list.Add(dir.Name);
        //    }

        //    return list;
        //}
    }
}
