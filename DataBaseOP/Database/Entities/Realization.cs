using System;

namespace DataBaseOP.Database.Entities
{
    public class Realization
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public DateTime RealizeDate { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public decimal AmountDue { get; set; }
        public decimal PaidOf { get; set; }
        public decimal Change { get; set; }
        public int AmountProducts { get; set; }
        public bool Realized { get; set; }
        
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        public int SeniorID { get; set; }
        public Worker Senior { get; set; }
        
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
