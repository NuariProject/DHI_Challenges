using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHI_Challenges.Models.Entities
{
    [Table("MasterProducts", Schema = "Product")]
    public class MasterProduct
    {
        [Key]
        [Required]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public bool IsDelete { get; set; }
    }
}
