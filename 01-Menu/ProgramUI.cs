using _01_Menu_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Menu
{
    class ProgramUI
    {
        private Repo _menuRepo = new Repo();

        public void Run()
        {
            string buildNumber = "Menu Editor       Build: 1.0.0";
            string author = "Ian Stowell";

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("{0}    {1}", author, buildNumber);
            Console.ResetColor();

            Console.WriteLine("Hello and welcome to the Komodo Cafe Menu Editor! Press enter to continue...\n" +
                              "<---------------------------------------------------------------------------->");
            Console.ReadLine();
            Seed();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                Console.Clear();
                Console.WriteLine("Hello!\n" +
                    "What would you like to do?\n" +
                    "1.) Add Items To Menu\n" +
                    "2.) View Menu\n" +
                    "3.) Delete Items From Menu\n" +
                    "4.) Exit Menu Editor\n");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddToMenu();
                        break;

                    case "2":
                        ViewMenu();
                        break;

                    case "3":
                        DeleteFromMenu();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Sorry to see you go!\n" +
                            "Press 'Enter' to exit");
                        Console.ReadLine();
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
                Console.Clear();
            }
        }
        public void AddToMenu()
        {
            Console.Clear();
            Menu newItem = new Menu();

            Console.WriteLine("Enter the menu number for this item:");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumberAsString);

            Console.WriteLine("Enter the name of the item:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter a description of the item:");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter a list of ingredients separated by commas:");
            newItem.MealIngredients = Console.ReadLine();


            Console.WriteLine("Enter the price of this item:");
            string mealPriceAsString = Console.ReadLine();
            newItem.MealPrice = double.Parse(mealPriceAsString);

            Console.WriteLine("What type of item is this (Please enter corresponding number):\n" +
                "1. Side\n" +
                "2. Meal\n" +
                "3. Drink");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newItem.TypeOfItem = (ItemType)typeAsInt;
            _menuRepo.AddMenuItem(newItem);

            Console.Clear();
            Console.WriteLine("Your item has been saved!\n" +
                "Press 'Enter' to continue...");

        }


        public void ViewMenu()
        {
            Console.Clear();
            List<Menu> menuItems = _menuRepo.GetItemList();

            foreach (Menu item in menuItems)
            {
                Console.WriteLine("\n" +
                    $" Number: {item.MealNumber}, Name: {item.MealName}\n" +
                    $" Item Type: { item.TypeOfItem},\n" +
                    $" Description: {item.MealDescription}\n" +
                    $" Ingredients: {item.MealIngredients} \n" +
                    $" Price: ${item.MealPrice}\n" +
                    $"");

            }
            Console.WriteLine("Press 'Enter' to continue...");
            Console.ReadLine();
        }

        public void DeleteFromMenu()
        {
            ViewMenu();

            Console.WriteLine("Type the name of the meal that you would like to remove:");
            string input = Console.ReadLine();

            bool wasDeleted = _menuRepo.RemoveItemFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("\n" +
                    "You have successfully removed this item!\n" +
                    "Press 'Enter' to go to the main menu...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n" +
                    "Item could not be deleted...\n" +
                    "Press 'Enter' to go to the main menu...");
                Console.ReadLine();
            }


        }
        public void Seed()
        {
            Menu carmelMacchiato = new Menu(1, "Caramel Macchiato", "An espresso and milk drink with caramel flavoring.", "Espresso shots, caramel, foamed AND steamed milk.", 2.50, ItemType.Drink);
            Menu crossaintWhich = new Menu(2, "Croissant Which", "A croissant breakfast sandwhich.", "Croissant buns, sausage, egg, and cheese.", 3.50, ItemType.Meal);
            Menu coffeeCake = new Menu(3, "Coffee Cake", "A tasty cinnamon pastry.", "Cinnamon, sugar, flour, yeast, and egg.", 1.75, ItemType.Side);

            _menuRepo.AddMenuItem(carmelMacchiato);
            _menuRepo.AddMenuItem(crossaintWhich);
            _menuRepo.AddMenuItem(coffeeCake);
        }
    }
}
