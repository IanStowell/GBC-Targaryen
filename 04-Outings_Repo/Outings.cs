using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Repo
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }

    public class Outing
    {
        public string Name { get; set; }
        public EventType OutingType { get; set; }
        public int OutingAttendance { get; set; }
        public DateTime OutingDate { get; set; }
        public double CostPerPerson { get; set; }
        public double Total { get; set; }

        public Outing() { }
        public Outing(string name, EventType type, int attendance, DateTime date, double costPerPerson, double total)
        {
            Name = name;
            OutingType = type;
            OutingAttendance = attendance;
            OutingDate = date;
            CostPerPerson = costPerPerson;
            Total = total;
        }
    }
}
