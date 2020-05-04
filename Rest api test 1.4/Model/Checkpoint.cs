using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Checkpoint
   {
        public int id { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int radius { get; set; }
        public string state { get; set; }

    }
}
