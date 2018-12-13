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
    [Table("Bookings")]
    public class Booking:Auditable
    {
        [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int ID { get; set; }
        public int IDCar { get; set; }
        public int IDCustomer { get; set; }
        public DateTime DateBook { get; set; }
        public int IDSeat { get; set; }
        public int IDSeatNo { get; set; }
    }
}
