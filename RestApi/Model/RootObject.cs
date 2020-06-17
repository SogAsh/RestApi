using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class RootObject<T>
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<T> results { get; set; }
    }
}
