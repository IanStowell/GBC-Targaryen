using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repo
{
    public class Badge_Repo
    {
        Dictionary<int, List<string>> _badgeNumbers = new Dictionary<int, List<string>>();

        //Create
        public void AddBadge(int badgeID, List<string> doors)
        {
            _badgeNumbers.Add(badgeID, doors);
        }

        //Read
        public Dictionary<int, List<string>> ViewAllBadges()
        {
            return _badgeNumbers;
        }

        public Badge GetBadgeByID(int id)
        {
            foreach (var item in _badgeNumbers)
            {
                if (item.Key == id)
                {
                    return new Badge(item.Key, item.Value);

                }
            }
            return null;
        }

        //Update
        public bool UpdateBadge(Badge newBadge, int oldID)
        {

            if (_badgeNumbers.ContainsKey(oldID))
            {
                _badgeNumbers[oldID] = newBadge.Access;

                _badgeNumbers[newBadge.ID] = newBadge.Access;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasKey(int key)
        {
            bool validKey = _badgeNumbers.ContainsKey(key);
            if (validKey)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public void DeleteBadge(int badgeID, List<string> lists)
        {
            _badgeNumbers[badgeID].Clear();
        }

    }
}
