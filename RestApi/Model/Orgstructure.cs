using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Orgstructure
    {
        public int id { get; set; }
        public string name { get; set; }
        public object parent { get; set; }
        public string depnum { get; set; }
        public object firm { get; set; }
        public bool is_firm { get; set; }
    }
}
