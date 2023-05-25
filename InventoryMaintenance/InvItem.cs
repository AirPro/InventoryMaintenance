using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    public class InvItem
    {
        public InvItem() { }

        public InvItem(int itemNo, string description, decimal price) 
        {
            this.ItemNo = itemNo;
            this.Description = description;
            this.Price = price;
        }

        public int ItemNo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string GetDisplayText(string sep)
        {
            return $"{ItemNo}{sep}{Description}{sep}{Price.ToString("C")}";
        }
    }
}
