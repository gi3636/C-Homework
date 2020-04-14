using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project9
{
    public partial class Form1 : Form
    {
        // 将课本中例5-31的Cayley树绘图代码进行修改。添加一组控件用以调节树的绘制参数。
        // 参数包括递归深度（n）、主干长度（leng）、右分支长度比（per1）、左分支长度比（per2）、右分支角度（th1）、左分支角度（th2）、画笔颜色（pen）。

        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;
  
        public Form1()
        {
            InitializeComponent();
            Initial();
        }

        public void Initial()
        {
            this.textBox1.Text = "10";
            this.textBox2.Text = "100";
            this.textBox3.Text = "0.6";
            this.textBox4.Text = "0.7";
            this.textBox5.Text = "30";
            this.textBox6.Text = "20";
        }

        public void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
            {
                return;
            }
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        private void drawLine(double x0, double y0, double x1, double y1)
        {
            String color = this.comboBox1.SelectedItem.ToString();
            switch (color)
            {
                case "Red":
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Blue":
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Green":
                    graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            graphics = this.pictureBox1.CreateGraphics();
            int n = int.Parse(textBox1.Text);
            double leng = double.Parse(textBox2.Text);
            this.per1 = double.Parse(textBox3.Text);
            this.per2 = double.Parse(textBox4.Text);
            this.th1 = double.Parse(textBox5.Text) * Math.PI / 180;
            this.th2 = double.Parse(textBox6.Text) * Math.PI / 180;

            drawCayleyTree(n, 200, 400, leng, -Math.PI / 2);
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("Red");
            this.comboBox1.Items.Add("Blue");
            this.comboBox1.Items.Add("Green");
            this.comboBox1.SelectedIndex = 1;
        }

        private void pictureBox1_Click(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red, 2);
            g.DrawLine(p, 0, 0, 100, 100);
        }
    }
}
