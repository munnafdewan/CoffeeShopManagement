using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.BLL
{
    public class ItemManager
    {
        Item item = new Item();
        ItemRepository _itemRepository = new ItemRepository();
        public bool Add(Item item)
        {
            return _itemRepository.Add(item);
        }

        public bool IsNameExist(Item item)
        {
            return _itemRepository.IsNameExist(item);
        }

        public bool Update(string name, double price)
        {
            return _itemRepository.Update(name, price);
        }

        public DataTable Display()
        {
            return _itemRepository.Display();
        }

        public bool Delete(int id)
        {
            return _itemRepository.Delete(id);
        }
        public DataTable Search(string name)
        {
            return _itemRepository.Search(name);
        }

        public DataTable ItemCombo()
        {
            return _itemRepository.ItemCombo();
        }

        public DataTable CountPrice(int id)
        {
            return _itemRepository.CountPrice(id);
        }
    }
}
