using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Menu_Repo
{
    public class Repo
    {
        public List<Menu> _listOfItems = new List<Menu>();

        //Create
        public void AddMenuItem(Menu item)
        {
            _listOfItems.Add(item);
        }
        //Read
        public List<Menu> GetItemList()
        {
            return _listOfItems;
        }

        //Delete
        public bool RemoveItemFromList(string mealName)
        {
            Menu item = GetItemByNumber(mealName);

            if (item == null)
            {
                return false;
            }

            int initialCount = _listOfItems.Count;
            _listOfItems.Remove(item);

            if (initialCount > _listOfItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Searching method
        public Menu GetItemByNumber(string mealName)
        {
            foreach (Menu item in _listOfItems)
            {
                if (item.MealName == mealName)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
