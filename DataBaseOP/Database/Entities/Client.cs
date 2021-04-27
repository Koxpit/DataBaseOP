using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseOP.Database.Entities
{
    public class Client
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
