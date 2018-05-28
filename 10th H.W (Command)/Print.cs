using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hu_s_Command
{
    class Print
    {


        public void StartPhrase()
        {
            Console.WriteLine("Microsoft Windows [Version 10.0.17134.48]\n(c)2018 Microsoft Corporation.All rights reserved.\n");
        }

        public void Help()
        {
            Console.WriteLine("특정 명령어에 대한 자세한 내용이 필요하면 HELP 명령어 이름을 입력하십시오." +
                "\nASSOC    파일 확장명 연결을 보여주거나 수정합니다." +
                "\nATTRIB   파일 속성을 표시하거나 바꿉니다." +
                "\nBREAK    확장된 CTRL + C 검사를 설정하거나 지웁니다." +
                "\nBCDEDIT        부팅 로딩을 제어하기 위해 부팅 데이터베이스에서 속성을 설정합니다." +
                "\nCALL     한 일괄 프로그램에서 다른 일괄 프로그램을 호출합니다." +
                "\nCD       현재 디렉터리 이름을 보여주거나 바꿉니다." +
                "\nCHCP     활성화된 코드 페이지의 번호를 표시하거나 설정합니다." +
                "\nCHDIR    현재 디렉터리 이름을 보여주거나 바꿉니다." +
                "\nCHKDSK   디스크를 검사하고 상태 보고서를 표시합니다." +
                "\nCHKNTFS  부팅하는 동안 디스크 확인을 화면에 표시하거나 변경합니다." +
                "\nCLS      화면을 지웁니다." +
                "\nCMD      Windows 명령 인터프리터의 새 인스턴스를 시작합니다." +
                "\nCOLOR    콘솔의 기본색과 배경색을 설정합니다." +
                "\nCOMP     두 개 또는 여러 개의 파일을 비교합니다." +
                "\nCOMPACT  NTFS 분할 영역에 있는 파일의 압축을 표시하거나 변경합니다." +
                "\nCONVERT  FAT 볼륨을 NTFS로 변환합니다.현재 드라이브는" +
                "\n         변환할 수 없습니다." +
                "\nCOPY     하나 이상의 파일을 다른 위치로 복사합니다." +
                "\nDATE     날짜를 보여주거나 설정합니다." +
                "\nDEL      하나 이상의 파일을 지웁니다." +
                "\nDIR      디렉터리에 있는 파일과 하위 디렉터리 목록을 보여줍니다." +
                "\nDISKPART       디스크 파티션 속성을 표시하거나 구성합니다." +
                "\nDOSKEY       명령줄을 편집하고, Windows 명령을 다시 호출하고," +
                "\n               매크로를 만듭니다." +
                "\nDRIVERQUERY    현재 장치 드라이버 상태와 속성을 표시합니다." +
                "\nECHO           메시지를 표시하거나 ECHO를 켜거나 끕니다." +
                "\nENDLOCAL       배치 파일에서 환경 변경의 지역화를 끝냅니다." +
                "\nERASE          하나 이상의 파일을 지웁니다." +
                "\nEXIT           CMD.EXE 프로그램(명령 인터프리터)을 종료합니다." +
                "\nFC             두 파일 또는 파일 집합을 비교하여 다른 점을" +
                "\n         표시합니다." +
                " \nFIND           파일에서 텍스트 문자열을 검색합니다." +
                "\nFINDSTR        파일에서 문자열을 검색합니다." +
                "\nFOR            파일 집합의 각 파일에 대해 지정된 명령을 실행합니다." +
                "\nFORMAT         Windows에서 사용할 디스크를 포맷합니다." +
                "\nFSUTIL         파일 시스템 속성을 표시하거나 구성합니다." +
                "\nFTYPE          파일 확장명 연결에 사용되는 파일 형식을 표시하거나" +
                "\n               수정합니다." +
                "\nGOTO           Windows 명령 인터프리터가 일괄 프로그램에서" +
                " \n               이름표가 붙여진 줄로 이동합니다." +
                " \nGPRESULT       컴퓨터 또는 사용자에 대한 그룹 정책 정보를 표시합니다." +
                "\nGRAFTABL       Windows가 그래픽 모드에서 확장 문자 세트를 표시할" +
                "\n         수 있게 합니다." +
                "\nHELP           Windows 명령에 대한 도움말 정보를 제공합니다." +
                "\nICACLS         파일과 디렉터리에 대한 ACL을 표시, 수정, 백업 또는" +
                "\n               복원합니다." +
                "\nIF             일괄 프로그램에서 조건 처리를 수행합니다." +
                "\nLABEL          디스크의 볼륨 이름을 만들거나, 바꾸거나, 지웁니다." +
                "\nMD             디렉터리를 만듭니다." +
                "\nMKDIR          디렉터리를 만듭니다." +
                "\nMKLINK         바로 가기 링크와 하드 링크를 만듭니다." +
                "\nMODE           시스템 장치를 구성합니다." +
                "\nMORE           출력을 한번에 한 화면씩 표시합니다." +
                "\nMOVE           하나 이상의 파일을 한 디렉터리에서 다른 디렉터리로" +
                "\n               이동합니다." +
                "\nOPENFILES      파일 공유에서 원격 사용자에 의해 열린 파일을 표시합니다." +
                "\nPATH           실행 파일의 찾기 경로를 표시하거나 설정합니다." +
                "\nPAUSE          배치 파일의 처리를 일시 중단하고 메시지를 표시합니다." +
                "\nPOPD           PUSHD에 의해 저장된 현재 디렉터리의 이전 값을" +
                "\n               복원합니다." +
                "\nPRINT          텍스트 파일을 인쇄합니다." +
                "\nPROMPT         Windows 명령 프롬프트를 변경합니다." +
                "\nPUSHD          현재 디렉터리를 저장한 다음 변경합니다." +
                "\nRD             디렉터리를 제거합니다." +
                "\nRECOVER        불량이거나 결함이 있는 디스크에서 읽을 수 있는 정보를 복구합니다." +
                "\nREM            배치 파일 또는 CONFIG.SYS에 주석을 기록합니다." +
                "\nREN            파일 이름을 바꿉니다." +
                "\nRENAME         파일 이름을 바꿉니다." +
                "\nREPLACE        파일을 바꿉니다." +
                "\nRMDIR          디렉터리를 제거합니다." +
                "\nROBOCOPY       파일과 디렉터리 트리를 복사할 수 있는 고급 유틸리티입니다." +
                "\nSET            Windows 환경 변수를 표시, 설정 또는 제거합니다." +
                "\nSETLOCAL       배치 파일에서 환경 변경의 지역화를 시작합니다." +
                "\nSC             서비스(백그라운드 프로세스)를 표시하거나 구성합니다." +
                "\nSCHTASKS       컴퓨터에서 실행할 명령과 프로그램을 예약합니다." +
                "\nSHIFT          배치 파일에서 바꿀 수 있는 매개 변수의 위치를 바꿉니다." +
                "\nSHUTDOWN       컴퓨터의 로컬 또는 원격 종료를 허용합니다." +
                "\nSORT           입력을 정렬합니다." +
                "\nSTART          지정한 프로그램이나 명령을 실행할 별도의 창을 시작합니다." +
                "\nSUBST          경로를 드라이브 문자에 연결합니다." +
                "\nSYSTEMINFO     컴퓨터별 속성과 구성을 표시합니다." +
                "\nTASKLIST       서비스를 포함하여 현재 실행 중인 모든 작업을 표시합니다." +
                "\nTASKKILL       실행 중인 프로세스나 응용 프로그램을 중단합니다." +
                "\nTIME           시스템 시간을 표시하거나 설정합니다." +
                "\nTITLE          CMD.EXE 세션에 대한 창 제목을 설정합니다." +
                "\nTREE           드라이브 또는 경로의 디렉터리 구조를 그래픽으로" +
                "\n               표시합니다." +
                "\nTYPE           텍스트 파일의 내용을 표시합니다." +
                "\nVER            Windows 버전을 표시합니다." +
                "\nVERIFY         파일이 디스크에 올바로 기록되었는지 검증할지" +
                "\n         여부를 지정합니다." +
                "\nVOL            디스크 볼륨 레이블과 일련 번호를 표시합니다." +
                "\nXCOPY          파일과 디렉터리 트리를 복사합니다." +
                "\nWMIC           대화형 명령 셸 내의 WMI 정보를 표시합니다.\n"+
                "\n도구에 대한 자세한 내용은 온라인 도움말의 명령줄 참조를 참조하십시오.\n");
        }

        public void PrintDirectory(FileSystemInfo file)
        {
            Console.Write(file.LastWriteTime.ToString("yyyy-MM-dd  tt hh:mm "));

            if (file.GetType().ToString().Equals("System.IO.DirectoryInfo"))
                Console.Write("{0,-17}","    <DIR>");
            else if (file.GetType().ToString().Equals("System.IO.FileInfo"))
            {
                Console.Write("{0,17:N0}", ((FileInfo)file).Length);
            }

            Console.WriteLine(" "+file.Name);
        }
        
        public void PrintFileByte(long bytes, int count)
        {
            Console.WriteLine("\t\t" + count + "개 파일" + "{0,20:N0} 바이트",bytes);
        }

        public void PrintDirectoryByte(long bytes, int count)
        {
            Console.WriteLine("\t\t" + count + "개 디렉터리" + "{0,16:N0} 바이트 남음", bytes);
        }

        public void FindPathFail()
        {
            Console.WriteLine("지정된 경로를 찾을 수 없습니다.");
        }

        public void NotApplyAddress()
        {
            Console.WriteLine("CMD에서 현재 디렉터리로 UNC 경로를 지원하지 않습니다.");
        }

        public void SuccessMoveCopy(string mode)
        {
            switch (mode)
            {
                case Constants.COPY:
                    Console.WriteLine("\t\t1개 파일이 복사되었습니다.\n");
                    break;

                case Constants.MOVE:
                    Console.WriteLine("\t\t1개 파일이 이동했습니다.\n");
                    break;
            }
        }

        public void FailMoveCopy(string mode)
        {
            switch (mode)
            {
                case Constants.COPY:
                    Console.WriteLine("\t\t1개 파일이 복사되었습니다.\n");
                    break;

                case Constants.MOVE:
                    Console.WriteLine("\t\t1개 파일이 이동했습니다.\n");
                    break;
            }
        }

        public void PrintNotCommand(string command)
        {
            Console.WriteLine("'"+command+ "'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n배치 파일이 아닙니다.\n");
        }
    }
}
