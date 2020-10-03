using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repo
{
    public class Repo
    {
        private List<Claim> _claimscontents = new List<Claim>();
        //Create
        public bool AddClaim(Claim claim)
        {
            int startingCount = _claimscontents.Count;
            _claimscontents.Add(claim);
            bool wasAdded = _claimscontents.Count == startingCount + 1;
            return wasAdded;
        }

        //Read
        public List<Claim> ViewList()
        {
            return _claimscontents;
        }

        public Claim GetClaimByNumber(int claimID)
        {
            foreach (Claim claimItem in _claimscontents)
            {
                if (claimItem.ClaimID == claimID)
                {
                    return claimItem;
                }
            }
            return null;
        }

        public void ClaimSelect(int claimNumber)
        {
            Console.Clear();
            Claim claim = GetClaimByNumber(claimNumber);
            Console.WriteLine($"{"Claim ID",-8} {"Claim Type",-11} {"Description",-25} {"Amount",-7} {"Date of Accident",-17} {"Date of Claim",-15} Claim Valid?");
            Console.WriteLine($"{claim.ClaimID,-8} {claim.ClaimType,-11} {claim.ClaimDescribe,-25} {claim.ClaimAmount,-7} {claim.ClaimAccident.ToString("MM/dd/yyyy"),-17} {claim.ClaimDate.ToString("MM/dd/yyyy"),-15} {claim.ClaimValid}\n");
            Console.WriteLine("Do you wish to take this claim?\n" +
                "Y/N");

            string consoleResponse = Console.ReadLine().ToUpper();

            if (consoleResponse == "Y")
            {
                Console.WriteLine("Claim accepted. Press any key to return to the menu.");
                RemoveClaimFromList(claimNumber);
                Console.ReadKey();
            }
            else if (consoleResponse == "N")
            {
                Console.WriteLine("Claim not accepted. Press any key to return to the menu.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That is not a valid input.");
                Console.ReadKey();
            }

        }

        //Delete
        public bool RemoveClaimFromList(int claimNumber)
        {
            Claim removal = GetClaimByNumber(claimNumber);

            _claimscontents.Remove(removal);
            return true;
        }
    }
}
