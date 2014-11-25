using Buddy.Wildstar.Game;
using Buddy.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibus.Helpers
{
    public static class InventoryManager 
    {
        public static IEnumerable<InventoryItem> Items
        {
            get
            {
                return GameManager.Inventory.Bags.Items;
            }
        }

        public static void Dump()
        {
            foreach (var item in Items) 
            {
                Omnibus.Logger.Notice(string.Format("=========== {0} ===========", item.Name));
                foreach (var stat in item.Stats)
                {
                    Omnibus.Logger.Notice(string.Format("Property: {0} Value: {1}", stat.Property.ToString(), stat.Value)); 
                }
                Omnibus.Logger.Notice("=========== END ===========");
            }
        }
    }
}
