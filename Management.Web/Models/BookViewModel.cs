using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string NameCustomer { get; set; }
        public string PhoneCustomer { get; set; }
        public string MailCustomer { get; set; }
        public string AddressCustomer { get; set; }
        public int IDRoute { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public int IDCar { get; set; }
        public int IDSeat { get; set; }
        public int IDSeatNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool? Status { get; set; }
        public bool StatusSeatNo { get; set; }
        public string MetaDescription { get; set; }


    }
}