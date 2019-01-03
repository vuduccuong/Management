using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web.Models
{
    public class SearchBillViewModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CarCode { get; set; }
        public string SeatName { get; set; }
        public string dateBook { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string TimeStart { get; set; }
    }
}