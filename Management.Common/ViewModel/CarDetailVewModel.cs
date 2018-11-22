using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Common.ViewModel
{
    public class CarDetailVewModel
    {
        public int ID { get; set; }
        public string NameCar { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public string NameDriver { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string TimeStart { get; set; }
    }
}
