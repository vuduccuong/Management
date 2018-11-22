using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web.Models
{
    public class SeatViewModel
    {
        public int ID { get; set; }

        public int IDCar { get; set; }

        public string Row { get; set; }

        public bool? isDel { get; set; }
    }
}