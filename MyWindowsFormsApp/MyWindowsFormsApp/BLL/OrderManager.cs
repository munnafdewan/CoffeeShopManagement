using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.BLL
{
    public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();

        public bool Add(Order order, double totalPrice)
        {
            return _orderRepository.Add(order, totalPrice);
        }
        public DataTable Display()
        {
            return _orderRepository.Display();
        }
        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }
        public bool Update(Order order, double totalPrice)
        {
            return _orderRepository.Update(order, totalPrice);
        }
        public DataTable Search(string name)
        {
            return _orderRepository.Search(name);
        }

        public DataTable ItemCombo()
        {
            return _orderRepository.ItemCombo();
        }

        public DataTable NameCombo()
        {
            return _orderRepository.NameCombo();
        }
    }
}
