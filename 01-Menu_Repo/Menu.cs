using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Menu_Repo
{
    public enum ItemType
    {
        Side = 1,
        Meal,
        Drink

    }
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; }
        public double MealPrice { get; set; }
        public ItemType TypeOfItem { get; set; }

        public Menu() { }

        public Menu(int mealNumber, string mealName, string mealDescription, string mealIngredients, double mealPrice, ItemType type)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
            TypeOfItem = type;
        }
    }
}
