using _03_Badges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    class ProgramUI
    {
        private Badge_Repo _badgeRepo = new Badge_Repo();

        public void Run()
        {
            string buildNumber = "Badge Access App       Build: 1.0.0";
            string author = "Ian Stowell";

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("{0}    {1}", author, buildNumber);
            Console.ResetColor();

            Console.WriteLine("Hello and welcome to the Komodo Badge Access Modifier! Press enter to continue...\n" +
                              "<-------------------------------------------------------------------------------->");
            Console.ReadLine();
            Seed();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Access Control Configuration App. Please select an option.\n" +
                    "1. View All Badges/Access\n" +
                    "2. Create A New Badge\n" +
                    "3. Update A Badge\n" +
                    "4. Delete Doors From Existing Badge\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllBadges();
                        break;
                    case "2":
                        CreateNewBadge();
                        break;
                    case "3":
                        UpdateExistingBadge();
                        break;
                    case "4":
                        DeleteDoorsFromBadge();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Sorry to see you go!\n" +
                            "Press 'Enter' to exit");
                        Console.ReadLine();
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid menu option.");
                        break;
                }

                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ViewAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> dictionary = _badgeRepo.ViewAllBadges();

            foreach (KeyValuePair<int, List<string>> kvp in dictionary)
            {
                int displayBadgeKey = kvp.Key;
                foreach (string door in kvp.Value)
                {
                    string displayDoor = door;
                    Console.WriteLine("Badge ID:               Room Access:");
                    Console.WriteLine($"{displayBadgeKey,-7} \t\t{displayDoor,-5}\n" +
                        $"");
                }

            }
        }



        public void UpdateExistingBadge()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                Console.WriteLine("What would you like to do?\n" +
                    "1. Add doors to a badge.\n" +
                    "2. Delete doors from a badge.\n" +
                    "3. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddExistingBadgeDoors();
                        break;
                    case "2":
                        DeleteDoorsFromBadge();
                        break;
                    case "3":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            }
        }


        private void CreateNewBadge()
        {
            Console.Clear();

            List<string> doorNames = new List<string>();

            Console.WriteLine("What is the badge ID number:");
            string inputAsInt = Console.ReadLine();
            int iDAsInt = int.Parse(inputAsInt);

            Console.WriteLine("What doors does this badge access?");
            string doorOne = Console.ReadLine();
            doorNames.Add(doorOne);
            Console.WriteLine("Would you like to add another door?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "Y":
                case "Yes":
                case "yes":
                case "y":
                    Console.WriteLine("What door does this badge access?");
                    string doorTwo = Console.ReadLine();
                    doorNames.Add(doorTwo);
                    Console.WriteLine("Would you like to add a third door?");
                    string input2 = Console.ReadLine();

                    if (input2 == "y" || input2 == "Y")
                    {
                        Console.WriteLine("What is the name of this door?");
                        string doorThree = Console.ReadLine();
                        doorNames.Add(doorThree);
                    }
                    break;
                case "N":
                case "No":
                case "no":
                case "n":
                default:
                    break;



            }

            _badgeRepo.AddBadge(iDAsInt, doorNames);

        }

        private void AddExistingBadgeDoors()
        {
            Console.Clear();

            List<string> doorNames = new List<string>();

            Console.WriteLine("What badge would you like to update?");
            string inputAsInt = Console.ReadLine();
            int oldID = int.Parse(inputAsInt);


            Console.WriteLine("What new door would you like this badge to access?");
            string doorOne = Console.ReadLine();
            doorNames.Add(doorOne);
            Console.WriteLine("Would you like to add another door?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "Y":
                case "Yes":
                case "yes":
                case "y":
                    Console.WriteLine("What is the name of the door this badge accesses?");
                    string doorTwo = Console.ReadLine();
                    doorNames.Add(doorTwo);
                    Console.WriteLine("Would you like to add a third door?");
                    string input2 = Console.ReadLine();

                    if (input2 == "y" || input2 == "Y")
                    {
                        Console.WriteLine("What is the name of the third door?");
                        string doorThree = Console.ReadLine();
                        doorNames.Add(doorThree);
                    }
                    break;
                case "N":
                case "No":
                case "no":
                case "n":
                default:
                    break;

            }
            Badge Badge1 = new Badge(oldID, doorNames);

            _badgeRepo.UpdateBadge(Badge1, oldID);


        }

        private void DeleteDoorsFromBadge()
        {
            Console.Clear();

            List<string> doorNames = new List<string>();

            Console.WriteLine("Which badge would you like to remove access from?");
            string inputAsInt = Console.ReadLine();
            int badgeID = int.Parse(inputAsInt);

            Console.WriteLine("What door would you like to remove access allowance to?");
            string doorOne = Console.ReadLine();
            doorNames.Remove(doorOne);
            Console.WriteLine($"{doorOne} has been removed from this badge.");

            Console.WriteLine("Would you like to remove another door?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "Y":
                case "Yes":
                case "yes":
                case "y":

                    Console.WriteLine("Whats the name of the second door?");
                    string doorTwo = Console.ReadLine();
                    doorNames.Remove(doorTwo);

                    Console.WriteLine($"This badge no longer has access to {doorTwo}.\n" +
                        $"");
                    Console.WriteLine("Would you like to remove a third door?");
                    string input2 = Console.ReadLine();

                    if (input2 == "y" || input2 == "Y")
                    {
                        Console.WriteLine("What is the name of the third door?");
                        string doorThree = Console.ReadLine();
                        doorNames.Remove(doorThree);
                        Console.WriteLine($"This badge no longer has access to {doorThree}");
                    }

                    break;
                case "N":
                case "No":
                case "no":
                case "n":
                default:
                    break;



            }
            Badge Badge1 = new Badge(badgeID, doorNames);

            _badgeRepo.UpdateBadge(Badge1, badgeID);
        }

        public void Seed()
        {
            Badge_Repo _badgeRepo = new Badge_Repo();

            _badgeRepo.AddBadge(12345, new List<string> { "A7" });
            _badgeRepo.AddBadge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            _badgeRepo.AddBadge(32345, new List<string> { "A4", "A5" });
        }
    }
}
