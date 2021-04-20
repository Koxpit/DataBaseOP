﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseOP.Database.Entities
{
    public class Worker
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }

        public int PositionID { get; set; }
        public Position Position { get; set; }
    }
}
