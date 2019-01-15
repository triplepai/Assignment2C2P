using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C2PDB.Model
{
    public class BaseModel
    {
        [Required]
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        [Column("CreatedBy")]
        public string CreatedBy { get; set; }

        [Required]
        [Column("ModifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        [Column("ModifiedBy")]
        public string ModifiedBy { get; set; }
    }
}
