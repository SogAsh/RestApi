using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Devices
    {
        public int id { get; set; }
        public bool online { get; set; }
        public string name { get; set; }
        public string host { get; set; }
        public string port { get; set; }
        public string mask { get; set; }
        public string gate { get; set; }
        public string serial { get; set; }
        public string response_time { get; set; }
        public string server_host { get; set; }
        public string server_port { get; set; }
        public object host_name { get; set; }
        public string direction { get; set; }
        public string state { get; set; }
        public string auto_connect { get; set; }
        public int type { get; set; }
        public string type_name { get; set; }
        public string timezoneid { get; set; }
    }
}
