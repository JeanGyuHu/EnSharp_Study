using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace Hu_s_Calculator1
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AllLogPage : UserControl
    {
        public AllLogPage()
        {
            InitializeComponent();
        }

        public void SetTextBox(string before,string now)
        {
            BeforeLog.Text = before;
            NowLog.Text = now;
        }

        public void AddNewMemory(string calculation)
        {
            string problem;
            string answer;
            int index;

            index = calculation.IndexOf('=');
            problem = calculation.Remove(index, calculation.Length-index);
            answer = calculation.Remove(0, index);

            if (storage.Text.Equals("아직 기록이 없음"))
                storage.Text = problem + "\n" + answer + "\n";
            else
            {
                storage.Text += "\n" + problem + "\n" + answer + "\n";
            }
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            int index = -1;
            int checkE = 1;

            string lgsText;
            string point = "";
            string real = "";

            if (NowLog.Text.Length > 1)
            {

                lgsText = NowLog.Text.Replace(",", "");//숫자변환시 콤마로 발생하는 에러 방지

                index = lgsText.IndexOf('.');
                checkE = lgsText.IndexOf('E');

                if (NowLog.Text.Equals("0으로 나눌 수 없습니다."))
                    return;
                else if (index.Equals(-1))
                {
                    real = lgsText;
                    point = "";
                }
                else if (!index.Equals(-1))
                {
                    point = lgsText.Remove(0, index);
                    real = lgsText.Remove(index, lgsText.Length - index);
                }

                if (NowLog.Text.Equals("0."))
                    NowLog.Text = "0.";

                else if (real.Equals("0"))
                {
                    NowLog.Text = real + point;
                }
                else if (!checkE.Equals(-1))
                {
                    NowLog.Text = real + point;
                }
                else
                {
                    NowLog.Text = string.Format("{0:#,###}", Convert.ToDecimal(real)) + point;//천 단위 찍어주기
                }
                NowLog.SelectionStart = NowLog.Text.Length;
                NowLog.SelectionLength = 0;
            }
            AutoFontSize(NowLog.Text);
        }

        public void AutoFontSize(string text)
        {
            Font ft;
            Graphics gp;
            SizeF sz;
            Single Faktor, FaktorX, FaktorY;
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();

            label.Width = 580;
            label.Height = 88;
            label.Text = text;

            gp = label.CreateGraphics();

            sz = gp.MeasureString(text, label.Font);
            gp.Dispose();

            FaktorX = (label.Width) / sz.Width;
            FaktorY = (label.Height) / sz.Height;
            if (FaktorX > FaktorY)
                Faktor = FaktorY;
            else
                Faktor = FaktorX;
            ft = label.Font;

            if (NowLog.Text.Length <= 1)
                NowLog.FontSize = 48;
            else if (Faktor > 0)
                NowLog.FontSize = ft.SizeInPoints * (Faktor);

            else
                NowLog.FontSize = ft.SizeInPoints * (0.1f);

            if (NowLog.FontSize < 12.0)
                NowLog.FontSize = 12.0;
        }
    }
}
