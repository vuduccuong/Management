using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web.Models
{
    public class CarViewModel
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int IDtype { get; set; }

        public int IDDriver { get; set; }

        public int IDRouter { get; set; }

        public bool? isDel { get; set; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public bool Status { set; get; }
    }
}