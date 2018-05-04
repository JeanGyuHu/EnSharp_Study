using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace LectureTimeTable
{
    class Start
    {
        /// <summary>
        /// 메인 method  시작!
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MenuLogic menuLogic = new MenuLogic();
            menuLogic.Login();
        }
       
    }
}
