using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseOP.Database.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        
        public int TrademarkID { get; set; }
        public Trademark Trademark { get; set; }
    }
}
