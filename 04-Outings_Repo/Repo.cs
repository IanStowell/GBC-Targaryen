using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Repo
{
    public class OutingRepo
    {
        private List<Outing> _listOfOutings = new List<Outing>();

        //Create
        public void AddNewOuting(Outing outing)
        {
            _listOfOutings.Add(outing);
        }

        //Read
        public List<Outing> GetList()
        {
            return _listOfOutings;
        }

        public double CostByType(EventType eventType)
        {
            List<Outing> listOfOutings = GetOutingByType(eventType);
            double totalCost = 0.0d;
            foreach (Outing outing in listOfOutings)
            {
                totalCost += outing.Total;
            }
            return totalCost;
        }

        public List<Outing> GetOutingByType(EventType eventType)
        {
            List<Outing> outingList = new List<Outing>();
            foreach (Outing item in _listOfOutings)
            {
                if (item.OutingType == eventType)
                {
                    outingList.Add(item);
                }
            }
            return (outingList);

        }

        public double TotalCost()
        {
            double totalCost = 0.0d;
            foreach (Outing item in _listOfOutings)
            {
                totalCost += item.Total;
            }
            return totalCost;
        }
    }
}
