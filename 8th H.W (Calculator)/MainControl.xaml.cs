using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Hu_s_Calculator1
{
    /// <summary>
    /// MainControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainControl : UserControl
    {
        private bool operationAfter;  // 연산자가 눌린 바로 다음에 true

        private int lastInput = Constants.FIRST;          //처음인지 입력 받은게 있는지 표시
        private List<DataVO> operations;      //숫자와 연산을 저장
        private DataVO last = null;  //마지막 연산에서 들어온 숫자와 연산자 저장
        private bool newLine = true;        //삭제플래그
        private AllLogPage allLogPage;      //여태 총 검색 결과를 저장하는 창

        public MainControl(AllLogPage logPage)
        {
            InitializeComponent();

            NowLog.Text = "0";
            operations = new List<DataVO>();
            allLogPage = logPage;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (newLine && NowLog.Text != "0")
            {
                NowLog.Text = "0";
                newLine = false;
            }

            if (NowLog.Text.Length > 19)
                return;

            lastInput = 0;

            Button btn = (Button)sender;
            String num = btn.Name.Remove(0, 6); // 맨 앞에서 6글자 삭제

            if (operationAfter == true)
            {
                NowLog.Text = num;
                operationAfter = false;
            }
            else if (NowLog.Text.IndexOf('.') != -1)  // 소수점이 있다면, 0. 을 처리하기 위함
            {
                NowLog.Text += num;
            }
            else if (double.Parse(NowLog.Text.Replace(",", "")) == 0)
            {
                NowLog.Text = num;
            }
            else
                NowLog.Text += num;
            newLine = false;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if(NowLog.Text.Length>0)
            NowLog.Text = NowLog.Text.Remove(NowLog.Text.Length - 1);
            if (NowLog.Text.Length == 0)
                NowLog.Text = "0";
        }

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            NowLog.Text = "0";
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            operations.Clear();
            NowLog.Text = "0";
            BeforeLog.Text = "";
            operationAfter = false;
            lastInput = Constants.FIRST;
            newLine = true;
        }

        private void ButtonNegate_Click(object sender, RoutedEventArgs e)
        {
            if (BeforeLog.Text.Equals(""))
            {

            }

            else if (BeforeLog.Text[BeforeLog.Text.Length - 1].Equals(')'))
            {
                if (NowLog.Text[0].Equals('-'))
                {
                    int index = BeforeLog.Text.LastIndexOf(NowLog.Text.Substring(1,NowLog.Text.Length-1));
                    string text = BeforeLog.Text;
                    text = text.Insert(index, "negate(");
                    BeforeLog.Text = text.Insert(index+7 + NowLog.Text.Length, ")");

                }
                else
                {
                    int index = BeforeLog.Text.LastIndexOf(NowLog.Text);
                    string text = BeforeLog.Text;
                    text =text.Insert(index, "negate(");
                    BeforeLog.Text = text.Insert(index+7 + NowLog.Text.Length, ")");
                }
            }
            else 
                BeforeLog.Text += "negate(" + NowLog.Text + ")";

            NowLog.Text = (-double.Parse(NowLog.Text)).ToString();
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            
            //이미 연산중이고 이전에 고른 연산자가 나누기일때 바꿀 필요 없으므로 return
            if (lastInput == Constants.STARTED && operations[operations.Count - 1].Operation == Constants.Operation.DEVIDE)
            {
                return;
            }
            //이미 연산중이고 이전에 고른 연산자가 나누기가 아닐때 연산자를 바꿔준다.
            else if (lastInput == Constants.STARTED)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new DataVO(Convert.ToDouble(NowLog.Text), Constants.Operation.DEVIDE));
                DisplayBeforeLog();
            }
            //=일때 연산자와 숫자를 추가해주고 계산한다.
            else
            {
                operations.Add(new DataVO(Convert.ToDouble(NowLog.Text), Constants.Operation.DEVIDE));
                DisplayBeforeLog();
                Calculate();
            }

            lastInput = Constants.STARTED;
            newLine = true;

        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {

            if (lastInput == Constants.STARTED && operations[operations.Count - 1].Operation == Constants.Operation.MULTIPLY)
            {
                return;
            }

            else if (lastInput == Constants.STARTED)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new DataVO(Convert.ToDouble(NowLog.Text), Constants.Operation.MULTIPLY));
                DisplayBeforeLog();
            }
            else
            {
                operations.Add(new DataVO(Convert.ToDouble(NowLog.Text), Constants.Operation.MULTIPLY));
                DisplayBeforeLog();
                Calculate();
            }
            lastInput = Constants.STARTED;
            newLine = true;
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            

            if (lastInput == Constants.STARTED && operations[operations.Count - 1].Operation == Constants.Operation.SUBTRACT)
            {
                return;
            }
            else if (lastInput == Constants.STARTED)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new DataVO(Convert.ToDouble(NowLog.Text), Constants.Operation.SUBTRACT));
                DisplayBeforeLog();
            }
            else
            {
                operations.Add(new DataVO(Convert.ToDouble(NowLog.Text), Constants.Operation.SUBTRACT));
                DisplayBeforeLog();
                Calculate();
            }

            lastInput = Constants.STARTED;
            newLine = true;


        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            
            if (lastInput == Constants.STARTED && operations[operations.Count - 1].Operation == Constants.Operation.PLUS)
            {
                return;
            }
            else if (lastInput == Constants.STARTED)
            {
                operations.RemoveAt(operations.Count - 1);
                operations.Add(new DataVO(Convert.ToDouble(NowLog.Text), Constants.Operation.PLUS));
                DisplayBeforeLog();
            }
            else
            {
                operations.Add(new DataVO(Convert.ToDouble(NowLog.Text), Constants.Operation.PLUS));
                DisplayBeforeLog();
                Calculate();
            }

            lastInput = Constants.STARTED;
            newLine = true;

        }

        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {
            string log = "";
            string oper ="";

            if (operations.Count > 0)
            {
                // 마지막 연산자가 있을때 연산한다.
                last = new DataVO(Convert.ToDouble(NowLog.Text), operations[operations.Count - 1].Operation);
                operations.Add(last);

                if (BeforeLog.Text.EndsWith(")"))
                    log = BeforeLog.Text;
                else
                log = BeforeLog.Text+NowLog.Text;

                Calculate();             
                allLogPage.AddNewMemory(log + " = " + NowLog.Text);
                operations.Clear();
                BeforeLog.Clear();
            }
            // 해야 할 연산자는 없지만 마지막 작업에 숫자가 있으면 마지막 계산을 한다.
            else if (last != null)
            {
                double value = Convert.ToDouble(NowLog.Text);

                switch (last.Operation)
                {
                    case Constants.Operation.SUBTRACT:
                        oper = " - ";
                        NowLog.Text = Convert.ToString(value - last.Number);
                        break;
                    case Constants.Operation.PLUS:
                        oper = " + ";
                        NowLog.Text = Convert.ToString(value + last.Number);
                        break;
                    case Constants.Operation.MULTIPLY:
                        oper = " × ";
                        NowLog.Text = Convert.ToString(value * last.Number);
                        break;
                    case Constants.Operation.DEVIDE:
                        oper = " ÷ ";
                        NowLog.Text = Convert.ToString(value / last.Number);
                        break;
                }
                allLogPage.AddNewMemory(value + oper + last.Number + " = " + NowLog.Text);
            }
            
            //외 아무 것도 하지 않는다.
            else
            {
                
            }
            
            operations.Clear();
            newLine = true;
            lastInput = Constants.FIRST;

        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (operationAfter == true || double.Parse(NowLog.Text.Replace(",", "")) == 0)
            {
                NowLog.Text = "0.";
                operationAfter = false;
            }
            else if (double.Parse(NowLog.Text.Replace(",", "")) == (int)(double.Parse(NowLog.Text.Replace(",", "")))) // 정수라면
            {
                NowLog.Text += ".";
            }
        }

        private void Calculate()
        {
            if (operations.Count < 2)
            {
                return;
            }
            else
            {
                double result = operations[0].Number;

                for (int i = 0; i < operations.Count - 1; i++)
                {
                    switch (operations[i].Operation)
                    {
                        case Constants.Operation.SUBTRACT:
                            result = result - operations[i + 1].Number;
                            break;
                        case Constants.Operation.PLUS:
                            result = result + operations[i + 1].Number;
                            break;
                        case Constants.Operation.MULTIPLY:
                            result = result * operations[i + 1].Number;
                            break;
                        case Constants.Operation.DEVIDE:
                            if (operations[i + 1].Number == 0)
                            {
                                NowLog.FontSize = 30;
                                NowLog.Text = "0으로 나눌 수 없습니다.";
                                return;
                            }

                            result = result / operations[i + 1].Number;
                            break;
                    }
                }

                NowLog.Text = Convert.ToString(result);
            }
        }

        private void DisplayBeforeLog()
        {
            string log = "";

            for (int i = 0; i < operations.Count; i++)
            {
                log += operations[i].Number;

                switch (operations[i].Operation)
                {
                    case Constants.Operation.SUBTRACT:
                        log += " - ";
                        break;
                    case Constants.Operation.PLUS:
                        log += " + ";
                        break;
                    case Constants.Operation.MULTIPLY:
                        log += " × ";
                        break;
                    case Constants.Operation.DEVIDE:
                        log += " ÷ ";
                        break;
                }
            }

            if (log.Length > 62)
            {
                BeforeLog.Text = log.Remove(62);
            }
            else
            {
                BeforeLog.Text = log;
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

        public string GetBefore()
        {
            return BeforeLog.Text;
        }

        public string GetNow()
        {
            return NowLog.Text;
        }
    }
}
