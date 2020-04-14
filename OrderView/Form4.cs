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
    public partial class Form4 : Form
    {
        String row;
        public List<OrderItem> orderItemList4 = new List<OrderItem>();
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(List <OrderItem> orderItemList) : this()
        {
            orderItemList4 = orderItemList;
            bindingSource1.DataSource = orderItemList4;
            listBindingSource.DataSource = orderItemList4; 
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
