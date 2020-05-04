using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Logs
   {
        public int id { get; set; }
        public int object_id { get; set; }
        public int subject_id { get; set; }
        
        //public int event { get; set; }
        public string time { get; set; }
        public string object_tz { get; set; }

    }
}
