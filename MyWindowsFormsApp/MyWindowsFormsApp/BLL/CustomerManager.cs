using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.BLL
{
    class CustomerManager
    {
        Customer customer = new Customer();
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }
        public bool Update(string name, string phone,string address , int id)
        {
            return _customerRepository.Update(name, phone,address, id);
        }
        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }
        public DataTable Search(string name)
        {
            return _customerRepository.Search(name);
        }
        public bool IsNameExist(string name,string phone)
        {
            return _customerRepository.IsNameExist(name,phone);
        }
        public bool IsExistCustomerName(int id)
        {
            return _customerRepository.IsExistCustomerName(id);
        }
    }
}
