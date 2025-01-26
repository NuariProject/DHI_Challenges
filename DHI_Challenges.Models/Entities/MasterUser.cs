using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHI_Challenges.Models.Entities
{
    [Table("MasterUsers", Schema = "User")]
    public class MasterUser
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Required]
        [MaxLength(25)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        [MinLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public bool IsDelete { get; set; }
    }
}
