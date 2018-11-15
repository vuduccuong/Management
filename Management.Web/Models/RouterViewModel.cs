using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Management.Web.Models
{
    public class RouterViewModel
    {
        public int ID { get; set; }

        [Required]
        public string StartPoint { get; set; }

        [Required]
        [MaxLength(255)]
        public string EndPoint { get; set; }

        [Required]
        public string TimeStart { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

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