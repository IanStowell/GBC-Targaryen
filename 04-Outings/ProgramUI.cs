using _04_Outings_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings
{
    class ProgramUI
    {
        private OutingRepo _outingRepo = new OutingRepo();

        public void Run()
        {
            string buildNumber = "Outings Calculator      Build: 1.0.0";
            string author = "Ian Stowell";

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("{0}    {1}", author, buildNumber);
            Console.ResetColor();

            Console.WriteLine("Hello and welcome to the Komodo Outings Event Calculator! Press enter to continue...\n" +
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
                Console.WriteLine("Select an option:\n" +
                    "1.View all outings\n" +
                    "2.Add new outing\n" +
                    "3.View outing cost by type\n" +
                    "4.View total outing cost\n" +
                    "5.Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllOutings();
                        break;
                    case "2":
                        AddNewOuting();
                        break;
                    case "3":
                        CostByType();
                        break;
                    case "4":
                        TotalCost();
                        break;
                    case "5":
                        Console.WriteLine("Sorry to see you go!\n" +
                           "Press 'Enter' to exit");
                        Console.ReadLine();
                        keepRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
            }
        }

        public void ViewAllOutings()
        {
            Console.Clear();
            List<Outing> fullList = _outingRepo.GetList();

            foreach (Outing outing in fullList)
            {
                DateTime outingDate = outing.OutingDate;
                string dateFormat = outingDate.ToString("MM/dd/yyyy");
                Console.WriteLine($"{outing.Name} {dateFormat} {outing.OutingType} Attendance:{outing.OutingAttendance} Total cost:${outing.Total}\n" +
                    $"");
            }
            Console.ReadLine();

        }
        public void AddNewOuting()
        {
            Console.Clear();
            Outing newOuting = new Outing();

            Console.WriteLine("Please enter the name of the outing:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the number that corresponds with the event:\n" +
                "1.Golf\n" +
                "2.Bowling\n" +
                "3.Amusement Park\n" +
                "4.Concert");

            string eventTypeAsString = Console.ReadLine();
            int eventTypeAsInt = int.Parse(eventTypeAsString);
            newOuting.OutingType = (EventType)eventTypeAsInt;

            Console.WriteLine("Enter the number of attendants:");
            string attendanceAsString = Console.ReadLine();
            newOuting.OutingAttendance = int.Parse(attendanceAsString);

            Console.WriteLine("Enter the date of the outing (YYYY, MM, DD):");
            string dateAsString = Console.ReadLine();
            DateTime enteredDate = DateTime.Parse(dateAsString);
            newOuting.OutingDate = enteredDate;

            Console.WriteLine("Enter the cost (per person):");
            string costAsString = Console.ReadLine();
            newOuting.CostPerPerson = double.Parse(costAsString);

            Console.WriteLine("Enter the total cost of the outing:");
            string totalCostAsString = Console.ReadLine();
            newOuting.Total = double.Parse(totalCostAsString);

            _outingRepo.AddNewOuting(newOuting);

            Console.Clear();
            Console.WriteLine("Your item has been saved!\n" +
                                "Press 'Enter' to continue...");
            Console.ReadLine();
        }

        public void CostByType()
        {
            Console.Clear();
            Console.WriteLine(
                $"This years golf costs: ${_outingRepo.CostByType(EventType.Golf)} \n" +
                $"\n" +
                $"This years bowling costs: ${_outingRepo.CostByType(EventType.Bowling)}\n" +
                $"\n" +
                $"This years park costs: ${_outingRepo.CostByType(EventType.AmusementPark)}\n" +
                $"\n" +
                $"This years concert costs ${_outingRepo.CostByType(EventType.Concert)}\n" +
                $"\n" +
                $"Press 'Enter' to continue...");
            Console.ReadLine();
        }

        public void TotalCost()
        {
            Console.Clear();
            Console.WriteLine($"The cost for all of this years outings is:\n " +
                $" ${_outingRepo.TotalCost()}");
            Console.ReadLine();
        }
        public void Seed()
        {
            Outing briarWood = new Outing("Briar Wood", EventType.Golf, 11, new DateTime(2020, 01, 01), 10d, 1000d);
            Outing beaconHills = new Outing("Beacon Hills", EventType.Golf, 22, new DateTime(2020, 02, 02), 20d, 2000d);
            Outing thunderBirdBowling = new Outing("Thunder Bird Lanes", EventType.Bowling, 33, new DateTime(2020, 03, 03), 30d, 3000d);
            Outing caseysLanes = new Outing("Caseys Lanes", EventType.Bowling, 44, new DateTime(2020, 04, 04), 40d, 4000d);
            Outing sixFlags = new Outing("Six Flags", EventType.AmusementPark, 55, new DateTime(2020, 05, 05), 50d, 5000d);
            Outing cedarPoint = new Outing("Cedar Point", EventType.AmusementPark, 66, new DateTime(2020, 06, 06), 60d, 6000d);
            Outing brockHampton = new Outing("Brockhampton", EventType.Concert, 77, new DateTime(2020, 07, 07), 70d, 7000d);
            Outing toto = new Outing("Toto", EventType.Concert, 88, new DateTime(2020, 08, 08), 80d, 8000d);

            _outingRepo.AddNewOuting(briarWood);
            _outingRepo.AddNewOuting(beaconHills);
            _outingRepo.AddNewOuting(thunderBirdBowling);
            _outingRepo.AddNewOuting(caseysLanes);
            _outingRepo.AddNewOuting(sixFlags);
            _outingRepo.AddNewOuting(cedarPoint);
            _outingRepo.AddNewOuting(brockHampton);
            _outingRepo.AddNewOuting(toto);
        }
    }
}
