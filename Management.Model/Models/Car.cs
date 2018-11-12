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
    [Table("Cars")]
    public class Route:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Code { get; set; }

        [Required]
        public int IDtype { get; set; }

        public int IDDriver { get; set; }

        public int IDRouter { get; set; }

        public bool? isDel { get; set; }
    }
}
