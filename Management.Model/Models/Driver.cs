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
    [Table("Drivers")]
    public class Driver :Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [MaxLength(15)]
        [Column(TypeName ="varchar")]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public bool? isDel { get; set; }

    }
}
