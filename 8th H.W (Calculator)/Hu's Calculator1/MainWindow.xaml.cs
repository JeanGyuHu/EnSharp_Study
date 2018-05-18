using System.Windows;
using System.Drawing;
using System;
using System.Windows.Controls;

namespace Hu_s_Calculator1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 21자
    public partial class MainWindow : Window
    {
        private Data data;

        public MainWindow()
        {
            InitializeComponent();
            data = new Data();
            data.EraseDisplay = true;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();
            
            char[] ids = s.ToCharArray();
            ProcessKey(ids[0]);

        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessOperation(((Button)sender).Name.ToString());
        }

        //public Font AutoFontSize(Label label, string text)
        //{
        //    Font font;
        //    Graphics graphics;
        //    SizeF sz;
        //    Single Faktor, FaktorX, FaktorY;
        //    graphics = label.CreateGraphics();
        //    sz = graphics.MeasureString(text, label.Font);
        //    graphics.Dispose();

        //    FaktorX = (label.Width) / sz.Width;
        //    FaktorY = (label.Height) / sz.Height;
        //    if (FaktorX > FaktorY)
        //        Faktor = FaktorY;
        //    else
        //        Faktor = FaktorX;
        //    font = label.Font;

        //    if (Faktor > 0)
        //        return new Font(font.Name, font.SizeInPoints * (Faktor));
        //    else
        //        return new Font(font.Name, font.SizeInPoints * (0.1f));
        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    NowLog.Text = NowLog.Text;
        //    NowLog.FontSize = AutoFontSize(NowLog, NowLog.Text);
        //}

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            if (NowLog.Text.Length > 17)
                return;
            if (NowLog.Text != "")
            {
                string lgsText;
                lgsText = NowLog.Text.Replace(",", "");//숫자변환시 콤마로 발생하는 에러 방지
                NowLog.Text = String.Format("{0:#,###}", Convert.ToInt64(lgsText));//천 단위 찍어주기
                NowLog.SelectionStart = NowLog.Text.Length;
                NowLog.SelectionLength = 0;
            }
        }

        private void ProcessOperation(string operation)
        {
            switch (operation)
            {
                case Constants.NEGATE:
                    data.LastOperation = Constants.Operation.NEGATE;
                    data.LastValue = data.Display;
                    CalcResults();
                    data.LastValue = data.Display;
                    data.EraseDisplay = true;
                    data.LastOperation = Constants.Operation.NONE;
                    break;
                case Constants.DEVIDE:

                    if (data.EraseDisplay)    //stil wait for a digit...
                    {  //stil wait for a digit...
                        data.LastOperation = Constants.Operation.DEVIDE;
                        break;
                    }
                    CalcResults();
                    data.LastOperation = Constants.Operation.DEVIDE;
                    data.LastValue = data.Display;
                    data.EraseDisplay = true;
                    break;
                case Constants.MULTIFLY:
                    if (data.EraseDisplay)    //stil wait for a digit...
                    {  //stil wait for a digit...
                        data.LastOperation = Constants.Operation.MULTIPLY;
                        break;
                    }
                    CalcResults();
                    data.LastOperation = Constants.Operation.MULTIPLY;
                    data.LastValue = data.Display;
                    data.EraseDisplay = true;
                    break;
                case Constants.SUBTRACT:
                    if (data.EraseDisplay)    //stil wait for a digit...
                    {  //stil wait for a digit...
                        data.LastOperation = Constants.Operation.SUBTRACT;
                        break;
                    }
                    CalcResults();
                    data.LastOperation = Constants.Operation.SUBTRACT;
                    data.LastValue = data.Display;
                    data.EraseDisplay = true;
                    break;
                case Constants.PLUS:
                    if (data.EraseDisplay)
                    {  //stil wait for a digit...
                        data.LastOperation = Constants.Operation.PLUS;
                        break;
                    }
                    CalcResults();
                    data.LastOperation = Constants.Operation.PLUS;
                    data.LastValue = data.Display;
                    data.EraseDisplay = true;
                    break;
                case Constants.EQUAL:
                    if (data.EraseDisplay)    //stil wait for a digit...
                        break;
                    CalcResults();
                    data.EraseDisplay = true;
                    data.LastOperation = Constants.Operation.NONE;
                    data.LastValue = data.Display;
                    //val = Display;
                    break;
                case Constants.CLEAR:  //clear All
                    data.LastOperation = Constants.Operation.NONE;
                    data.Display = data.LastValue = string.Empty;
                    NowLog.Clear();
                    UpdateDisplay();
                    break;
                case Constants.CLEARERROR:  //clear entry
                    data.LastOperation = Constants.Operation.NONE;
                    data.Display = data.LastValue;
                    UpdateDisplay();
                    break;
                case Constants.DELETEONE:
                    data.LastOperation = Constants.Operation.NONE;
                    data.Display = data.LastValue;
                    UpdateDisplay();
                    break;
            }

        }

        private void CalcResults()
        {
            double d;
            if (data.LastOperation == Constants.Operation.NONE)
                return;

            d = Calc(data.LastOperation);
            data.Display = d.ToString();

            UpdateDisplay();
        }

        private double Calc(Constants.Operation LastOperation)
        {
            double d = 0.0;

                switch (LastOperation)
                {
                    case Constants.Operation.DEVIDE:
                        BeforeLog.AppendText(data.LastValue + " / " + data.Display);
                        d = (Convert.ToDouble(data.LastValue) / Convert.ToDouble(data.Display));
                        CheckResult(d);
                        NowLog.Text=d.ToString();
                        break;
                    case Constants.Operation.PLUS:
                        BeforeLog.AppendText(data.LastValue + " + " + data.Display);
                        d = Convert.ToDouble(data.LastValue) + Convert.ToDouble(data.Display);
                        CheckResult(d);
                        NowLog.Text = d.ToString();
                        break;
                    case Constants.Operation.MULTIPLY:
                        BeforeLog.AppendText(data.LastValue + " * " + data.Display);
                        d = Convert.ToDouble(data.LastValue) * Convert.ToDouble(data.Display);
                        CheckResult(d);
                        NowLog.Text = d.ToString();
                        break;
                    case Constants.Operation.SUBTRACT:
                        BeforeLog.AppendText(data.LastValue + " - " + data.Display);
                        d = Convert.ToDouble(data.LastValue) - Convert.ToDouble(data.Display);
                        CheckResult(d);
                        NowLog.Text = d.ToString();
                        break;
                    case Constants.Operation.NEGATE:
                        d = Convert.ToDouble(data.LastValue) * (-1.0F);
                        break;
                }
        
            return d;
        }

        private void CheckResult(double d)
        {
            if (Double.IsNegativeInfinity(d) || Double.IsPositiveInfinity(d) || Double.IsNaN(d))
                throw new Exception("Illegal value");

        }

        private void OnWindowKeyDown(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            string s = e.Text;
            char c = (s.ToCharArray())[0];
            e.Handled = true;

            if ((c >= '0' && c <= '9') || c == '.' || c == '\b')  // '\b' is backspace
            {
                ProcessKey(c);
                return;
            }


            switch (c)
            {
                case '+':
                    ProcessOperation(Constants.PLUS);
                    break;
                case '-':
                    ProcessOperation(Constants.SUBTRACT);
                    break;
                case '*':
                    ProcessOperation(Constants.MULTIFLY);
                    break;
                case '/':
                    ProcessOperation(Constants.DEVIDE);
                    break;
                case '=':
                    ProcessOperation(Constants.EQUAL);
                    break;
            }
        }

        private void ProcessKey(char c)
        {
            if (data.EraseDisplay)
            {
                data.Display = string.Empty;
                data.EraseDisplay = false;
            }
            AddToDisplay(c);
        }

        private void AddToDisplay(char c)
        {
            if (NowLog.Text == String.Empty)
                NowLog.Text = "0";
            if (c == '.')
            {
                if (data.Display.IndexOf('.', 0) >= 0)  //already exists
                    return;
                data.Display = data.Display + c;
            }
            else
            {
                if (c >= '0' && c <= '9')
                {
                    data.Display = data.Display + c;
                }
                else
                if (c == '\b')  //backspace ?
                {
                    if (data.Display.Length <= 1)
                        data.Display = String.Empty;
                    else
                    {
                        int i = data.Display.Length;
                        data.Display = data.Display.Remove(i - 1, 1);  //remove last char 
                    }
                }

            }

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (data.Display == String.Empty)
                NowLog.Text = "0";
            else if (data.Display.Length < 21)
                NowLog.Text = data.Display;
            else
                return;
        }
    }
}
