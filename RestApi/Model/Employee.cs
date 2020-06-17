using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Employee
   {
        public int id { get; set; }
        public string photo_preview { get; set; }
        public string photo { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string workernum { get; set; }
        public string state { get; set; }
        public object firm { get; set; }
        public object card { get; set; }
        public object finger_count { get; set; }
        public object palm_count { get; set; }
        public object policy_count { get; set; }
        public object log_last_event { get; set; }
        public object log_last_time { get; set; }
        public int parent { get; set; }
        public object job { get; set; }

    }
}
