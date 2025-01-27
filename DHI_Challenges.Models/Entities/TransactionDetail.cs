using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHI_Challenges.Models.Entities
{
    [Table("Details", Schema = "Transaction")]
    public class TransactionDetail
    {
        [Key]
        [Required]
        public int DetailID { get; set; }

        [Required]
        public int HeaderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("HeaderID")]
        public virtual TransactionHeader TransactionHeader { get; set; }

        [ForeignKey("ProductID")]
        public virtual MasterProduct MasterProducts { get; set; }
    }
}
