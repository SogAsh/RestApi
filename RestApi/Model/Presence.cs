using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Summary
    {
        public int presence_without_late_count { get; set; }
        public int missing_count { get; set; }
        public int total_count { get; set; }
        public int presence_with_late_count { get; set; }
        public int presence_count { get; set; }
        public int missing_bad_reason_count { get; set; }
        public int missing_good_reason_count { get; set; }
    }
    /*
    public class Detail<T>
    {
        //public List<T> missing_bad_reason { get; set; }
        //public List<T> presence_without_late { get; set; }
        public List<T> missing_good_reason { get; set; }
        //public List<T> presence_with_late { get; set; }
    }

    public class MissingGoodReason //Пе
    {
        public int missingId { get; set; }
    }
    */
    
}
