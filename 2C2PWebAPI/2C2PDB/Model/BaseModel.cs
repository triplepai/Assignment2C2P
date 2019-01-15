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
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(50)]
        [Column("CreateBy")]
        public string CreateBy { get; set; }

        [Required]
        [Column("ModifyDate")]
        public DateTime ModifyDate { get; set; }

        [Required]
        [StringLength(50)]
        [Column("ModifyBy")]
        public string ModifyBy { get; set; }
    }
}
