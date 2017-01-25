using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox
{
    class Item
    {
        public string name;
        public int item_type;
        public int[,] statboost;

        public Item(string Name, int Item_type, int[,] Statboost) {
            name = Name;
            item_type = Item_type;
            statboost = Statboost;
        }
    }
}
