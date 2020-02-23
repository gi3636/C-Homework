using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_Calculator
{
    public partial class Form1 : Form
    {
        String num1 = null;
        String num2 = null;
        String num3 = null;
        String symbol = null;//记录算法
        bool btnsgn = false;//按钮信号
        bool calsgn = false;//计算信号
        bool doluse = true;//限制.的数量
        static double total = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txBox.Text == "0" || btnsgn)
            {
                txBox.Text = "7";
                btnsgn = false;
            }
            else
            {
                txBox.Text += "7";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txBox.Text == "0" || btnsgn)
            {
                txBox.Text = "1";
                btnsgn = false;
            }
            else
            {
                txBox.Text += "1";
            }
        }



        private void txBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txBox.Text == "0" || btnsgn)
            {
                txBox.Text = "4";
                btnsgn = false;
            }
            else
            {
                txBox.Text += "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txBox.Text == "0" || btnsgn)
            {
                txBox.Text = "5";
                btnsgn = false;
            }
            else
            {
                txBox.Text += "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txBox.Text == "0" || btnsgn)
            {
                txBox.Text = "6";
                btnsgn = false;
            }
            else
            {
                txBox.Text += "6";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txBox.Text == "0" || btnsgn)
            {
                txBox.Text = "2";
                btnsgn = false;
            }
            else
            {
                txBox.Text += "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txBox.Text == "0" || btnsgn)
            {
                txBox.Text = "3";
                btnsgn = false;
            }
            else
            {
                txBox.Text += "3";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txBox.Text == "0" || btnsgn)
            {
                txBox.Text = "8";
                btnsgn = false;
            }
            else
            {
                txBox.Text += "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txBox.Text == "0" || btnsgn)
            {
                txBox.Text = "9";
                btnsgn = false;
            }
            else
            {
                txBox.Text += "9";
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txBox.Text == "0" || btnsgn)
            {
                txBox.Text = "0";
                btnsgn = false;
            }
            else
            {
                txBox.Text += "0";
            }
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (btnsgn)
            {
                txBox.Text = ".";
                btnsgn = false;
            }
            else
            {
                if (doluse)
                {
                    txBox.Text += ".";
                    doluse = false;

                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txBox.Text != null)
            {
                txBox.Text = txBox.Text.Remove(txBox.Text.Length - 1);
                btnsgn = false;
            }
            else
            {
                MessageBox.Show("You cannot do that again");
            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (txBox.Text != null)
            {
                txBox.Text = txBox.Text.Remove(txBox.Text.Length - txBox.Text.Length);
                btnsgn = false;
                num1 = null;
                num2 = null;
                num3 = null;
                symbol = null;//记录算法
                calsgn = false;//计算信号
                doluse = true;//限制.的数量
                total = 0;
            }
            else
            {
                MessageBox.Show("You cannot do that again");
            }

        }


        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (symbol != "-" && symbol != "*" && symbol != "/")
            {
                if (num1 == null)
                {
                    num1 = txBox.Text;
                    btnsgn = true;
                    doluse = true;
                    symbol = "+";

                }
                else
                {
                    if (!calsgn)
                    {
                        num2 = txBox.Text;
                        total = Double.Parse(num1) + Double.Parse(num2);
                        txBox.Text = total.ToString();
                        num2 = total.ToString();
                        calsgn = true;
                        btnsgn = true;
                        doluse = true;
                        symbol = "+";
                    }
                    else
                    {
                        num3 = txBox.Text;
                        total = Double.Parse(num2) + Double.Parse(num3);
                        txBox.Text = total.ToString();
                        num1 = total.ToString();
                        calsgn = false;
                        btnsgn = true;
                        doluse = true;
                        symbol = "+";
                    }
                }
            }
            else
            {
                switch (symbol)
                {
                    case "-":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "+";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) - Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "+";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) - Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                doluse = true;
                                btnsgn = true;
                                symbol = "+";
                            }
                        }
                        break;
                    case "*":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "+";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) * Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "+";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) * Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "+";
                            }
                        }
                        break;
                    case "/":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "+";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) / Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "+";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) / Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "+";
                            }
                        }
                        break;
                }
            }
        }
        private void btnSub_Click(object sender, EventArgs e)
        {
            if (symbol != "+" && symbol != "*" && symbol != "/")
            {
                if (num1 == null)
                {
                    num1 = txBox.Text;
                    btnsgn = true;
                    doluse = true;
                    symbol = "-";
                }
                else
                {
                    if (!calsgn)
                    {
                        num2 = txBox.Text;
                        total = Double.Parse(num1) - Double.Parse(num2);
                        txBox.Text = total.ToString();
                        num2 = total.ToString();
                        calsgn = true;
                        btnsgn = true;
                        doluse = true;
                        symbol = "-";
                    }
                    else
                    {
                        num3 = txBox.Text;
                        total = Double.Parse(num2) - Double.Parse(num3);
                        txBox.Text = total.ToString();
                        num1 = total.ToString();
                        calsgn = false;
                        btnsgn = true;
                        doluse = true;
                        symbol = "-";
                    }
                }
            }
            else
            {
                switch (symbol)
                {
                    case "+":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "-";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) + Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "-";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num3) + Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "-";
                            }
                        }
                        break;
                    case "*":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "-";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) * Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "-";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) * Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "-";
                            }
                        }
                        break;
                    case "/":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "-";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) / Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "-";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) / Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "-";
                            }
                        }
                        break;
                }
            }
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            if (symbol != "-" && symbol != "+" && symbol != "/")
            {
                if (num1 == null)
                {
                    num1 = txBox.Text;
                    btnsgn = true;
                    doluse = true;
                    symbol = "*";

                }
                else
                {
                    if (!calsgn)
                    {
                        num2 = txBox.Text;
                        total = Double.Parse(num1) * Double.Parse(num2);
                        txBox.Text = total.ToString();
                        num2 = total.ToString();
                        calsgn = true;
                        btnsgn = true;
                        doluse = true;
                        symbol = "*";
                    }
                    else
                    {
                        num3 = txBox.Text;
                        total = Double.Parse(num2) * Double.Parse(num3);
                        txBox.Text = total.ToString();
                        num1 = total.ToString();
                        calsgn = false;
                        btnsgn = true;
                        symbol = "*";
                        doluse = true;
                    }
                }
            }
            else
            {
                switch (symbol)
                {
                    case "-":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "*";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) - Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "*";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) - Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "*";
                            }
                        }
                        break;
                    case "+":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "*";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) + Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "*";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) + Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "*";
                            }
                        }
                        break;
                    case "/":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "*";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) / Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "*";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) / Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "*";
                            }
                        }
                        break;
                }
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (symbol != "-" && symbol != "+" && symbol != "*")
            {
                if (num1 == null)
                {
                    num1 = txBox.Text;
                    btnsgn = true;
                    doluse = true;
                    symbol = "/";

                }
                else
                {
                    if (!calsgn)
                    {
                        num2 = txBox.Text;
                        total = Double.Parse(num1) / Double.Parse(num2);
                        txBox.Text = total.ToString();
                        num2 = total.ToString();
                        calsgn = true;
                        btnsgn = true;
                        doluse = true;
                        symbol = "/";
                    }
                    else
                    {
                        num3 = txBox.Text;
                        total = Double.Parse(num2) / Double.Parse(num3);
                        txBox.Text = total.ToString();
                        num1 = total.ToString();
                        calsgn = false;
                        btnsgn = true;
                        doluse = true;
                        symbol = "/";
                    }
                }

            }
            else
            {
                switch (symbol)
                {
                    case "-":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "/";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) - Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "/";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) - Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "/";
                            }
                        }
                        break;
                    case "+":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "/";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) + Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "/";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) + Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "/";
                            }
                        }
                        break;
                    case "*":
                        if (num1 == null)
                        {
                            num1 = txBox.Text;
                            btnsgn = true;
                            doluse = true;
                            symbol = "/";
                        }
                        else
                        {
                            if (!calsgn)
                            {
                                num2 = txBox.Text;
                                total = Double.Parse(num1) * Double.Parse(num2);
                                txBox.Text = total.ToString();
                                num2 = total.ToString();
                                calsgn = true;
                                btnsgn = true;
                                doluse = true;
                                symbol = "/";
                            }
                            else
                            {
                                num3 = txBox.Text;
                                total = Double.Parse(num2) * Double.Parse(num3);
                                txBox.Text = total.ToString();
                                num1 = total.ToString();
                                calsgn = false;
                                btnsgn = true;
                                doluse = true;
                                symbol = "/";
                            }
                        }
                        break;
                }
            }

        }

        private void btnEql_Click(object sender, EventArgs e)
        {
            switch (symbol)
            {
                case "-":
                    if (num1 == null)
                    {
                        num1 = txBox.Text;
                        btnsgn = true;
                        doluse = true;
                        symbol = null;
                    }
                    else
                    {
                        if (!calsgn)
                        {
                            num2 = txBox.Text;
                            total = Double.Parse(num1) - Double.Parse(num2);
                            txBox.Text = total.ToString();
                            num2 = total.ToString();
                            calsgn = true;
                            btnsgn = true;
                            doluse = true;
                            symbol = null;
                        }
                        else
                        {
                            num3 = txBox.Text;
                            total = Double.Parse(num2) - Double.Parse(num3);
                            txBox.Text = total.ToString();
                            num1 = total.ToString();
                            calsgn = false;
                            btnsgn = true;
                            doluse = true;
                            symbol = null;
                        }
                    }
                    break;
                case "+":
                    if (num1 == null)
                    {
                        num1 = txBox.Text;
                        btnsgn = true;
                        doluse = true;
                        symbol = null;
                    }
                    else
                    {
                        if (!calsgn)
                        {
                            num2 = txBox.Text;
                            total = Double.Parse(num1) + Double.Parse(num2);
                            txBox.Text = total.ToString();
                            num2 = total.ToString();
                            calsgn = true;
                            btnsgn = true;
                            doluse = true;
                            symbol = null;
                        }
                        else
                        {
                            num3 = txBox.Text;
                            total = Double.Parse(num2) + Double.Parse(num3);
                            txBox.Text = total.ToString();
                            num1 = total.ToString();
                            calsgn = false;
                            btnsgn = true;
                            doluse = true;
                            symbol = null;
                        }
                    }
                    break;
                case "*":
                    if (num1 == null)
                    {
                        num1 = txBox.Text;
                        btnsgn = true;
                        doluse = true;
                        symbol = null;
                    }
                    else
                    {
                        if (!calsgn)
                        {
                            num2 = txBox.Text;
                            total = Double.Parse(num1) * Double.Parse(num2);
                            txBox.Text = total.ToString();
                            num2 = total.ToString();
                            calsgn = true;
                            btnsgn = true;
                            doluse = true;
                            symbol = null;
                        }
                        else
                        {
                            num3 = txBox.Text;
                            total = Double.Parse(num2) * Double.Parse(num3);
                            txBox.Text = total.ToString();
                            num1 = total.ToString();
                            calsgn = false;
                            btnsgn = true;
                            doluse = true;
                            symbol = null;
                        }
                    }
                    break;
                case "/":
                    if (num1 == null)
                    {
                        num1 = txBox.Text;
                        btnsgn = true;
                        doluse = true;
                        symbol = null;
                    }
                    else
                    {
                        if (!calsgn)
                        {
                            num2 = txBox.Text;
                            total = Double.Parse(num1) / Double.Parse(num2);
                            txBox.Text = total.ToString();
                            num2 = total.ToString();
                            calsgn = true;
                            btnsgn = true;
                            doluse = true;
                            symbol = null;
                        }
                        else
                        {
                            num3 = txBox.Text;
                            total = Double.Parse(num2) / Double.Parse(num3);
                            txBox.Text = total.ToString();
                            num1 = total.ToString();
                            calsgn = false;
                            btnsgn = true;
                            doluse = true;
                            symbol = null;
                        }
                    }
                    break;
            }
        }
    }
}
