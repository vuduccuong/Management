using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Common.ViewModel
{
    public class GetCarByPointVewModel
    {
        public int IDCar { get; set; }
        public int IDRoute { get; set; }
        public string NameCar { get; set; }
        public string Code { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string TimeStart { get; set; }
        public int Count { get; set; }
    }
}
