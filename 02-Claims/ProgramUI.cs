using _02_Claims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
   public class ProgramUI
    {
        public Repo _repo = new Repo();
        public void Run()
        {
            string buildNumber = "Claims Handler       Build: 1.0.0";
            string author = "Ian Stowell";

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("{0}    {1}", author, buildNumber);
            Console.ResetColor();

            Console.WriteLine("Hello and welcome to the Komodo Claims Handler! Press enter to continue...\n" +
                              "<---------------------------------------------------------------------------->");
            Console.ReadLine();
            Seed();
            RunMenu();
        }
        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Please select an option:\n" +
                    "1. Show all claims\n" +
                    "2. Select a claim\n" +
                    "3. Add a claim\n" +
                    "4. Exit Claims Handler");

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        SelectClaim();
                        break;
                    case "3":
                        AddClaim();
                        break;
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Sorry to see you go!\n" +
                            "Press 'Enter' to exit");
                        Console.ReadLine();
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.\n");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine($"{"Claim ID",-8} {"Claim Type",-11} {"Description",-25} {"Amount",-7} {"Date of Accident",-17} {"Date of Claim",-15} Claim Valid?");
            List<Claim> listOfClaims = _repo.ViewList();
            foreach (Claim claimshow in listOfClaims)
            {
                DisplayContent(claimshow);
            }
        }
        private void DisplayContent(Claim claim)
        {
            Console.WriteLine($"{claim.ClaimID,-8} {claim.ClaimType,-11} {claim.ClaimDescribe,-25} {claim.ClaimAmount,-7} {claim.ClaimAccident.ToString("MM/dd/yyyy"),-17} {claim.ClaimDate.ToString("MM/dd/yyyy"),-15} {claim.ClaimValid}");
        }

        private void DisplayContentID(Claim claim)
        {
            Console.WriteLine($"{claim.ClaimID,-8} {claim.ClaimValid}");
        }

        private void SelectClaim()
        {
            Console.WriteLine("Select a claim ID:");
            List<Claim> claimMenu = _repo.ViewList();
            Console.WriteLine($"{"Claim ID",-8} {"Claim Valid?"}");
            foreach (Claim ID in claimMenu)
            {
                DisplayContentID(ID);
            }
            int claimNumber = Convert.ToInt32(Console.ReadLine());
            _repo.ClaimSelect(claimNumber);
        }

        private void AddClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter the claim ID:");
            int claimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the claim type:");
            string claimType = Console.ReadLine();

            Console.WriteLine("Enter a short description of the claim:");
            string claimDescribe = Console.ReadLine();

            Console.WriteLine("Enter the amount of the claim:");
            double claimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the date of the accident (MM/DD/YYYY): ");
            bool claimAccidentNotValid = true;
            DateTime claimAccident = new DateTime();
            while (claimAccidentNotValid)
            {
                if (DateTime.TryParse(Console.ReadLine(), out claimAccident))
                {
                    claimAccidentNotValid = false;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value.");
                }
            }

            Console.WriteLine("Enter the date of the claim (MM/DD/YYYY):");
            bool claimDateNotValid = true;
            DateTime claimDate = new DateTime();
            while (claimDateNotValid)
            {
                if (DateTime.TryParse(Console.ReadLine(), out claimDate))
                {
                    claimDateNotValid = false;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value.");
                }
            }


            Claim newClaim = new Claim(claimID, claimType, claimDescribe, claimAmount, claimAccident, claimDate);

            _repo.AddClaim(newClaim);
        }

        private void Seed()
        {
            Claim claim1 = new Claim(2584, "Car", "Car accident on 465", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim claim2 = new Claim(8978, "Home", "House fire in kitchen", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim claim3 = new Claim(2426, "Theft", "Stolen Pancakes", 400.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));

            _repo.AddClaim(claim1);
            _repo.AddClaim(claim2);
            _repo.AddClaim(claim3);
        }

    }
}
