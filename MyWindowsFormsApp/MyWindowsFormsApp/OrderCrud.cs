using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWindowsFormsApp.BLL;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp
{
    public partial class OrderCrud : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        ItemManager _itemManager = new ItemManager();
        OrderManager _orderManager = new OrderManager();

        Customer customer = new Customer();
        Item item = new Item();
        Order order = new Order();

        public OrderCrud()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string cName = nameComboBox.Text;
            string iName = itemComboBox.Text;
            string qty = quantityTextBox.Text;

            if (cName == "" || iName == "" || qty == "")
            {
                MessageBox.Show("Plesae,, Field must not be empty");
                return;
            }


            order.CustomerId = Convert.ToInt32(nameComboBox.SelectedValue);
            order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);
            order.Quantity = Convert.ToInt32(quantityTextBox.Text);
            //order.TotalPrice = Convert.ToDouble(totalPriceTextBox.Text);

            if (_customerManager.IsExistCustomerName(order.CustomerId))
            {
                MessageBox.Show("Customer is Allready Exist..!");
                return;
            }

            showDataGridView.DataSource = _itemManager.CountPrice(order.ItemId);
            string price = showDataGridView.CurrentRow.Cells[0].Value.ToString();
            showDataGridView.DataSource = "";
            double totalPrice = Convert.ToDouble(price) * order.Quantity;
            totalPriceTextBox.Text = totalPrice.ToString();



            if (_orderManager.Add(order, totalPrice))
            {
                showDataGridView.DataSource = _orderManager.Display();
                MessageBox.Show("Saved");
                return;
            }
            else
            {
                MessageBox.Show("Not Save");
            }

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(totalPriceTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Delete
            if (_orderManager.Delete(Convert.ToInt32(totalPriceTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _orderManager.Display();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string cName = nameComboBox.Text;
            string iName = itemComboBox.Text;
            string qty = quantityTextBox.Text;

            if (cName == "" || iName == "" || qty == "")
            {
                MessageBox.Show("Plesae,, Field must not be empty");
                return;
            }


            order.CustomerId = Convert.ToInt32(nameComboBox.SelectedValue);
            order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);
            order.Quantity = Convert.ToInt32(quantityTextBox.Text);
            //order.TotalPrice = Convert.ToDouble(totalPriceTextBox.Text);

            if (_customerManager.IsExistCustomerName(order.CustomerId))
            {
                MessageBox.Show("Customer is Allready Exist..!");
                return;
            }

            showDataGridView.DataSource = _itemManager.CountPrice(order.ItemId);
            string price = showDataGridView.CurrentRow.Cells[0].Value.ToString();
            showDataGridView.DataSource = "";
            double totalPrice = Convert.ToDouble(price) * order.Quantity;
            totalPriceTextBox.Text = totalPrice.ToString();



            if (_orderManager.Add(order, totalPrice))
            {
                showDataGridView.DataSource = _orderManager.Display();
                MessageBox.Show("Updated");
                return;
            }
            else
            {
                MessageBox.Show("Not Updated");
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Search(itemComboBox.Text);
        }

        private void Clear()
        {
            
            quantityTextBox.Clear();
       
        }

        private void OrderCrud_Load(object sender, EventArgs e)
        {
            nameComboBox.DataSource = _orderManager.NameCombo();
            itemComboBox.DataSource = _orderManager.ItemCombo();
        }
    }
}
