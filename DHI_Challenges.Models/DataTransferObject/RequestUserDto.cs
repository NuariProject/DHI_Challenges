using System.ComponentModel.DataAnnotations;

namespace DHI_Challenges.Models.DataTransferObject
{
    public class RequestUserDto
    {
        [Required(ErrorMessage = "FullName Can't Empty")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "FullName Maximal 25 Character")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "PhoneNumber Can't Empty")]
        [Phone(ErrorMessage = "Format PhoneNumber Invalid")]
        public string PhoneNumber { get; set; }
    }
}
