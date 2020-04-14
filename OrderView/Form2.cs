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
    public partial class Form2 : Form
    {
        private Order order1 { get; set; }
        public  List<Order> orderList2 { get; set; }
        public int orderCount =1;
        public Form2()
        {
            InitializeComponent();         
        }
        public Form2(List<Order>orderlist):this()
        {
            orderList2 = orderlist;

            orderListBindingSource.DataSource = orderList2;
            productBindingSource.DataSource = Form1.orderService.getProductList();
            
        }
        public List<Order> getOrderList2()
        {
            return orderList2;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (orderList2.Count==0)
            {
                MessageBox.Show("未添加订单");
            }
            else
            {
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            String productName2 = comboBox1.SelectedItem.ToString();
            double sum = 0;
            double quantity = double.Parse(textBox1.Text);
            sum = Double.Parse(label4.Text) * quantity;
            order1 = new Order(orderCount.ToString(),Form1.customer.CustomerName,productName2,DateTime.Now,sum,quantity);
            
            Form3 form3 = new Form3(order1);
            try
            {
                if (form3.ShowDialog() == DialogResult.OK)
                {
                    orderList2.Add(order1);
                    orderCount++;
                    orderListBindingSource.ResetBindings(false);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void orderListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
