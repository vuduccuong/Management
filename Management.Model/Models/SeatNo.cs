using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Model.Models
{
    [Table("SeatNos")]
    public class SeatNo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
         public int IDSeat { get; set; }
        public int SeatNb { get; set; }
        public DateTime DateBook { get; set; }
        public bool? Status { get; set; }
        public bool? isDel { get; set; }
    }
}
