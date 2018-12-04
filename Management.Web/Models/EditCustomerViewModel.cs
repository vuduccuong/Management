using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web.Models
{
    public class EditCustomerViewModel
    {
        public int IDCustomer { get; set; }
        public string NameCustomer { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int IDRoute { get; set; }
        public DateTime DateBook { get; set; }
        public string UpdatedBy { get; set; }
        public int TimeStart { get; set; }
        public int IDBook { get; set; }
        public int IDCar { get; set; }
        public int IDSeat { get; set; }
        public int oldIDSeatNo { get; set; }
        public int IDSeatNo { get; set; }
        public string MetaDescription { get; set; }
    }
}