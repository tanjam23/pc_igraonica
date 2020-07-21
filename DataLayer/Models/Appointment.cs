using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Appointment
    {
        public int id { set; get; }
        public string date { set; get; }
        public string time { set; get; }
        public int bill { set; get; }
        public int res_code { set; get; }
    }
}
