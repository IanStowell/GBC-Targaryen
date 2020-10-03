using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repo
{
    public class Badge
    {
        public List<string> Access { get; set; }
        public int ID { get; set; }

        public Badge() { }

        public Badge(int iD, List<string> access)
        {
            Access = access;
            ID = iD;
        }
    }
}
