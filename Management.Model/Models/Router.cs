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
    [Table("Routers")]
    public class Router :Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string StartPoint { get; set; }

        [Required]
        [MaxLength(255)]
        public string EndPoint { get; set; }

        [Required]
        public string TimeStart { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public bool? isDel { get; set; }
    }
}
