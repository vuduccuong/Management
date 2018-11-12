using Management.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Model.Models
{
    [Table("Tickets")]
    public class Ticket :Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int IDCar { get; set; }
        public int Customer { get; set; }
        public int SeatNb { get; set; }
        public bool? isDel { get; set; }
    }
}
