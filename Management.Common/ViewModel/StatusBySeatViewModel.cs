using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Common.ViewModel
{
    public class StatusBySeatViewModel
    {
        public int IDSeat { get; set; }
        public int IDSeatNo { get; set; }
        public int SeatNb { get; set; }
        public bool? Status { get; set; }
    }
}
