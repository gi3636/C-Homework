using Project8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderView
{
    public partial class Form3 : Form
    {
        private Order order2;
        public Form3()
        {
            InitializeComponent();
           
        }
        public Form3(Order order):this()
        {
            order2 = order;
            bindingSource1.DataSource = order2;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
