using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.Web.Models
{
    public class HistoryActionViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string ActionName { get; set; }
        public DateTime ActionDate { get; set; }
        public bool Status { get; set; }
    }
}