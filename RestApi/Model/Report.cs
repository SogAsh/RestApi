using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Report
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool is_system { get; set; }
        public bool is_hidden { get; set; }
    }
}
