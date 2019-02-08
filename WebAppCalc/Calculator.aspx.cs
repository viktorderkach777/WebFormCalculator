using System;
using System.Web.UI.WebControls;

namespace WebAppCalc
{
    public partial class Calculator : System.Web.UI.Page
    {
        private readonly IDAL _dal = new EDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        double Parsing(string value)
        {
            double result;
            try
            {
                result = Double.Parse(value);
            }
            catch (Exception)
            {
                Text1.Text = "Error";
                result = 0;
            }
            return result;
        }


        double Evaluate(string number1, string number2, string act)
        {
            double result = 0;

            if (act == "+")
            {
                result = Parsing(number1) + Parsing(number2);
            }
            else if (act == "-")
            {
                result = Parsing(number1) - Parsing(number2);
            }
            else if (act == "*")
            {
                result = Parsing(number1) * Parsing(number2);
            }
            else if (act == "/")
            {
                if (Parsing(number2) == 0)
                {
                    Text1.Text = "Error";
                }
                else
                {
                    result = Parsing(number1) / Parsing(number2);
                }
            }
            else if (act == "=")
            {
                result = Parsing(number1);
            }

            return result;
        }


        void EqualClick()
        {
            if (act1.Value == "=" && number2.Value == "0")
            {
                number1.Value = Text1.Text;
                Text1.Text = number1.Value;
                UpperText.Text += " = " + number1.Value;
                return;
            }

            if (act2.Value == "=")
            {
                number2.Value = Text1.Text;
                string result = Evaluate(number1.Value, number2.Value, act1.Value).ToString();

                if (Text1.Text != "Error")
                {
                    Text1.Text = result;
                    UpperText.Text += " = " + result;
                }
            }
            else if (act2.Value == "+" || act2.Value == "-")
            {
                number3.Value = Text1.Text;
                string result = Evaluate(number1.Value, number2.Value, act1.Value).ToString();
                result = Evaluate(result, number3.Value, act2.Value).ToString();

                if (Text1.Text != "Error")
                {
                    Text1.Text = result;
                    UpperText.Text += " = " + result;
                }
            }
            else if (act2.Value == "*" || act2.Value == "/")
            {
                number3.Value = Text1.Text;
                string result = Evaluate(number2.Value, number3.Value, act2.Value).ToString();
                result = (Evaluate(number1.Value, result, act1.Value)).ToString();

                if (Text1.Text != "Error")
                {
                    Text1.Text = result;
                    UpperText.Text += " = " + result;
                }
            }

            if (Text1.Text != "Error")
            {
                number1.Value = Text1.Text;
            }

            act1.Value = "=";
            act2.Value = "=";
        }


        protected void Action(string act)
        {
            string s = Text1.Text;
            Text1.Text = act;
            string s2 = Text1.Text;
            int index = UpperText.Text.LastIndexOf(s);
            string s3 = UpperText.Text.Substring(0, index);
            UpperText.Text = s3 + Text1.Text;
        }


        protected void butt_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;

            if (UpperText.Text.Contains("="))
            {
                int index = UpperText.Text.IndexOf("=");
                UpperText.Text = UpperText.Text.Remove(0, index + 2);
            }

            if (act2.Value == "=" && (but.Text == "+" || but.Text == "-" || but.Text == "/" || but.Text == "*"))
            {
                if (act1.Value == "=")
                {
                    number1.Value = Text1.Text;
                    act1.Value = but.Text;
                }
                else
                {
                    number2.Value = Text1.Text;
                    act2.Value = but.Text;
                }

                if (Text1.Text != "Error")
                {
                    Text1.Text = but.Text;
                    UpperText.Text += " " + but.Text + " ";
                }
            }
            else if (act2.Value != "=" && (but.Text == "+" || but.Text == "-" || but.Text == "/" || but.Text == "*"))
            {
                if ((act2.Value == "+" || act2.Value == "-"))
                {
                    number3.Value = Text1.Text;
                    number1.Value = Evaluate(number1.Value, number2.Value, act1.Value).ToString();
                    number2.Value = number3.Value;
                    act1.Value = act2.Value;
                    act2.Value = but.Text;
                }
                else if (act2.Value == "*" || act2.Value == "/")
                {
                    number3.Value = Text1.Text;
                    number2.Value = Evaluate(number2.Value, number3.Value, act2.Value).ToString();
                    act2.Value = but.Text;
                }

                if (Text1.Text != "Error")
                {
                    Text1.Text = but.Text;
                    UpperText.Text += " " + but.Text + " ";
                }
            }
            else if (but.Text == "=")
            {
                EqualClick();
                bool IsSave = _dal.SaveExpression(UpperText.Text);
            }
            else if (but.Text == "C")
            {
                number1.Value = "0";
                number2.Value = "0";
                act1.Value = "=";
                act2.Value = "=";
                Text1.Text = "0";
                UpperText.Text = "0";
            }
            else if (but.Text == ",")
            {
                if (Text1.Text.Contains("+") || Text1.Text == "-" || Text1.Text.Contains("*") || Text1.Text.Contains("/"))
                {
                    Text1.Text = "0,";
                    number2.Value = "0";
                    UpperText.Text += "0,";
                }
                else if (Text1.Text == "" || Text1.Text == "Error")
                {
                    Text1.Text = "0,";
                    number1.Value = "0";
                    UpperText.Text += "0,";
                }
                else if (!Text1.Text.Contains(","))
                {
                    Text1.Text += but.Text;
                    UpperText.Text += but.Text;
                }
            }
            else if (but.Text == "M+")
            {
                if (Text1.Text.Contains("+") || Text1.Text == "-" || Text1.Text.Contains("*") || Text1.Text.Contains("/") || Text1.Text == "Error")
                {
                    ValueInMemory.Value = "0";
                }
                else
                {
                    if (Text1.Text.Contains(","))
                    {
                        ValueInMemory.Value = (Parsing(Text1.Text)).ToString();
                    }
                    else
                    {
                        ValueInMemory.Value = Text1.Text;
                    }
                }
            }
            else if (but.Text == "M-")
            {
                Text1.Text = ValueInMemory.Value;
                UpperText.Text += ValueInMemory.Value;
            }
            else if (but.Text == "±")
            {
                if (Text1.Text.StartsWith("-"))
                {
                    Action(Text1.Text.Replace("-", ""));
                }
                else if (!(Text1.Text == "0" || Text1.Text == "Error" || Text1.Text.Contains("+") || Text1.Text.Contains("*") || Text1.Text.Contains("/")))
                {
                    Action("-" + Text1.Text);
                }
            }
            else if (but.Text == "←")
            {
                if (!(Text1.Text == "0" || Text1.Text == "Error" || Text1.Text.Contains("+") || Text1.Text == "-" || Text1.Text.Contains("*") || Text1.Text.Contains("/") || Text1.Text.Length == 0))
                {
                    Text1.Text = Text1.Text.Remove(Text1.Text.Length - 1);
                    UpperText.Text = UpperText.Text.Remove(UpperText.Text.Length - 1);
                }
            }
            else if (but.Text == "1/x")
            {
                if (!(Text1.Text == "0" || Text1.Text == "Error" || Text1.Text.Contains("+") || Text1.Text == "-" || Text1.Text.Contains("*") || Text1.Text.Contains("/")))
                {
                    Action((1 / Parsing(Text1.Text)).ToString());
                }
                else
                {
                    Text1.Text = "Error";
                    UpperText.Text += Text1.Text;
                }
            }
            else if (but.Text == "√")
            {
                if (!(Text1.Text.StartsWith("-") || Text1.Text == "Error" || Text1.Text.Contains("+") || Text1.Text.Contains("-") || Text1.Text.Contains("*") || Text1.Text.Contains("/")))
                {
                    Action(Math.Sqrt(Parsing(Text1.Text)).ToString());
                }
                else
                {
                    Text1.Text = "Error";
                    UpperText.Text += Text1.Text;
                }
            }
            else if (but.Text == "^2")
            {
                if (!(Text1.Text == "Error" || Text1.Text == "+" || Text1.Text == "-" || Text1.Text == "*" || Text1.Text == "/"))
                {
                    Action(Math.Pow(Parsing(Text1.Text), 2).ToString());
                }
                else
                {
                    Text1.Text = "Error";
                    UpperText.Text += Text1.Text;
                }
            }
            else
            {
                if (Text1.Text == "0" || Text1.Text == "Error" || Text1.Text.Contains("+") || Text1.Text.Contains("-") || Text1.Text.Contains("*") || Text1.Text.Contains("/"))
                {
                    Text1.Text = "";
                }

                if (act1.Value == "=" && Text1.Text == "0")
                {
                    UpperText.Text = "0";
                }

                if (!Text1.Text.StartsWith("0") && UpperText.Text.StartsWith("0") && !UpperText.Text.Contains(","))
                {
                    UpperText.Text = UpperText.Text.Remove(0, 1);
                }

                Text1.Text += but.Text;
                UpperText.Text += but.Text;
            }
        }


        protected void Group1_CheckedChanged(Object sender, EventArgs e)
        {
            if (rdoButton1.Checked)
            {
                UpperText.Visible = true;
                Text1.Visible = false;
            }

            if (rdoButton2.Checked)
            {
                UpperText.Visible = false;
                Text1.Visible = true;
            }
        }
    }
}