using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHI_Challenges.Models.Entities
{
    [Table("Headers", Schema = "Transaction")]
    public class TransactionHeader
    {
        [Key]
        [Required]
        public int HeaderID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int SummaryQuantity { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [ForeignKey("UserID")]
        public MasterUser MasterUsers { get; set; }
    }
}
