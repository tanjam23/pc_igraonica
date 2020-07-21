using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Reservation
    {
        public int code { set; get; }
        public string date { set; get; }
        public string time { set; get; }
        public string username { set; get; }
    }
}
