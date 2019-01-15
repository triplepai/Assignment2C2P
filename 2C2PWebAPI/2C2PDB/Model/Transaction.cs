namespace _2C2PDB.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string TransactionDate { get; set; }

        public int CustomerFK { get; set; }

        public decimal Amount { get; set; }

        public int CurrencyCode { get; set; }

        public int Status { get; set; }


        public virtual Customer Customer { get; set; }
    }
}