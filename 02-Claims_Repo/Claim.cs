using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repo
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimDescribe { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime ClaimAccident { get; set; }
        public DateTime ClaimDate { get; set; }
        public string ClaimValid
        {
            get
            {
                double validityDate = (ClaimDate - ClaimAccident).TotalDays;
                Convert.ToInt32(Math.Floor(validityDate));
                if (validityDate < 30)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }

        public Claim() { }

        public Claim(int claimID, string claimType, string claimDescribe, double claimAmount, DateTime claimAccident, DateTime claimDate)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescribe = claimDescribe;
            ClaimAmount = claimAmount;
            ClaimAccident = claimAccident;
            ClaimDate = claimDate;
        }
    }
}
