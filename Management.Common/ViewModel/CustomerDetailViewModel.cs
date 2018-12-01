using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Common.ViewModel
{
    public class CustomerDetailViewModel
    {
        public int IDBook { get; set; }
        public string DateBook { get; set; }
        public int IDCustomer { get; set; }
        public string NameCustomer { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int IDSeat { get; set; }
        public string Row { get; set; }
        public int IDSeatNo { get; set; }
        public int SeatNb { get; set; }
        public bool? Status { get; set; }
        public string NameCar { get; set; }
    }
}
