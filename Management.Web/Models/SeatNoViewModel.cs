using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web.Models
{
    public class SeatNoViewModel
    {
        public int ID { get; set; }
        public int IDSeat { get; set; }
        public int SeatNb { get; set; }
        public DateTime DateBook { get; set; }
        public bool? Status { get; set; }
        public bool? isDel { get; set; }
    }
}