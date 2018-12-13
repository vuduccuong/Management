using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Common.ViewModel
{
    public class GetBookViewModel
    {
        public int ID { get; set; }
        public int IDCar { get; set; }
        public int IDCustomer { get; set; }
        public DateTime DateBook { get; set; }
        public int IDSeat { get; set; }
        public int IDSeatNo { get; set; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public bool Status { set; get; }
    }
}
