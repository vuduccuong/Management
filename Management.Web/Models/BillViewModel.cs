using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web.Models
{
    public class BillViewModel
    {
        public int ID { get; set; }
        public DateTime DatedBill { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int IDCar { get; set; }
        public string SeatName { get; set; }
        public string dateBook { get; set; }
        public string CountMoney { get; set; }
    }
}