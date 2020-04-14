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
    public partial class Form1 : Form
    {
        public static int  orderListCount=1;
        List<Order> orderList1 { get; set; }

        double sum;

        public static List<OrderItem> orderItemList = new List<OrderItem>();

        public static OrderService orderService = new OrderService();

       public static  Customer customer = new Customer("FG", "China", "1001", 15236975);
        public Form1()
        {
            InitializeComponent();
            orderService.initialProductList();
            orderBindingSource.DataSource=orderItemList;
        }
        public void addOrderItem(OrderItem orderItem1)
        {
           // orderItemList
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            sum = 0;
            orderList1 =new List<Order>();
            Form2 form2 = new Form2(orderList1);
            if (form2.ShowDialog() == DialogResult.OK)
            {

                orderList1 = form2.getOrderList2();
                foreach(Order order in orderList1)
                {
                    sum += order.SumPrice;
                }
                OrderItem orderItem = new OrderItem(form2.orderList2, orderListCount.ToString(),customer.CustomerName,sum,DateTime.Now);
                orderItemList.Add(orderItem);
                orderListCount++;
                orderBindingSource.ResetBindings(false);
            }
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            changeDataFunction();
        }

        private void OrderDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            changeDataFunction();
        }

        private void OrderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void changeDataFunction()
        {

            int r = (OrderDataGridView.CurrentCell.RowIndex);
           // int c = (OrderDataGridView.CurrentCell.ColumnIndex + 1)
            string id = OrderDataGridView[0,r].Value.ToString();
            var q = from orderitem in orderItemList
                    where orderitem.OrderID == id
                    select orderitem;
            List<OrderItem> list = q.ToList();
            Form4 form4 = new Form4(list);
            
            if (form4.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("全部订单");
            comboBox1.Items.Add("ID");
            comboBox1.Items.Add("客户名字");
            comboBox1.Items.Add("价钱");
          
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            int r = (OrderDataGridView.CurrentCell.RowIndex);
            string id = OrderDataGridView[0, r].Value.ToString();
            OrderItem orderitem4 = new OrderItem();
            orderitem4 = orderItemList.Where(o => o.OrderID == id).FirstOrDefault();
            orderItemList.Remove(orderitem4);
            orderBindingSource.ResetBindings(false);
        }

        private void seeBtn_Click(object sender, EventArgs e)
        {
            changeDataFunction();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "全部订单":
                    orderBindingSource.DataSource = orderItemList;
                    break;
                case "ID":
                    String id = textBox1.Text;
                    var a = from orderitem in orderItemList
                            where orderitem.OrderID == id
                            orderby orderitem.OrderID descending
                            select orderitem;
                    a.ToList();
                    orderBindingSource.DataSource = a;
                    orderBindingSource.ResetBindings(false);
                    break;
                case "客户名字":
                    String name = textBox1.Text;
                    var b = from orderitem in orderItemList
                            where orderitem.CustomerName == name
                            orderby orderitem.OrderID descending
                            select orderitem;
                    b.ToList();
                    orderBindingSource.DataSource = b;
                    orderBindingSource.ResetBindings(false);
                    break;
                case "价钱":
                    string price = textBox1.Text;
                    var c = from orderitem in orderItemList
                            where orderitem.ProductPrice.ToString() == price
                            orderby orderitem.ProductPrice descending
                            select orderitem;
                    c.ToList();
                    orderBindingSource.DataSource = c;
                    orderBindingSource.ResetBindings(false);
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
