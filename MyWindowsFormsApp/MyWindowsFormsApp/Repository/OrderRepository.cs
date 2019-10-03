using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyWindowsFormsApp.BLL;
using MyWindowsFormsApp.Model;

using System.Threading.Tasks;

namespace MyWindowsFormsApp.Repository
{
    public class OrderRepository
    {
        string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
        public bool Add(Order order, double totalPrice)
        {
            bool isAdd = false;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "INSERT INTO Orders(CustomerId, ItemId, Quantity, TotalPrice) VALUES(" + order.CustomerId + "," + order.ItemId + "," + order.Quantity + "," + totalPrice + ")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    isAdd = true;
                }
                sqlConnection.Close();
            }
            catch (Exception exep)
            {
                //MessageBox.Show(exep.Message);
            }
            return isAdd;

        }

        public DataTable Display()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
          
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT o.Id,c.Name AS Customer,i.Name AS Item,Quantity,i.Price,TotalPrice FROM Orders AS o " +
                "INNER JOIN Customers AS c ON o.CustomerId = c.Id INNER JOIN Items AS i ON o.ItemId = i.ID";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;

        }

        public bool Delete(int id)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //DELETE FROM Items WHERE ID = 3
                string commandString = @"DELETE FROM Orders WHERE ID = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Delete
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return false;
        }

        public bool Update(Order order, double totalPrice)
        {
            bool isAdd = false;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "INSERT INTO Orders(CustomerId, ItemId, Quantity, TotalPrice) VALUES(" + order.CustomerId + "," + order.ItemId + "," + order.Quantity + "," + totalPrice + ")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    isAdd = true;
                }
                sqlConnection.Close();
            }
            catch (Exception exep)
            {
                //MessageBox.Show(exep.Message);
            }
            return isAdd;
           
        }

        public DataTable Search(string name)
        {
            DataTable dataTable = new DataTable();
            try
            {
                //Connection
                string connectionString = @"Server = DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Orders WHERE ItemName='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                //if (dataTable.Rows.Count > 0)
                //{
                //    //showDataGridView.DataSource = dataTable;
                //}
                //else
                //{
                //    //MessageBox.Show("No Data Found");
                //}

                ////Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                // MessageBox.Show(exeption.Message);
            }

            return dataTable;
        }

        public DataTable ItemCombo()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT Id, Name FROM Items";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //if (dataTable.Rows.Count > 0)
            //{
            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    //MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();

            return dataTable;

        }
        public DataTable NameCombo()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-J6257UA; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT Id, Name FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //if (dataTable.Rows.Count > 0)
            //{
            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    //MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();

            return dataTable;

        }
    }
}
