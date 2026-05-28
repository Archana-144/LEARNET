using System.ComponentModel.DataAnnotations;

namespace LEARNET.Common.Model
{
    public class Member
    {
        public int MemberId { get; set; }


        [Required(ErrorMessage = "Member name is required")]
        [StringLength(100)]
        public string MemberName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Phone number must be 10 digits")]
        public string Phone { get; set; }


        [Required]
        public string MembershipType { get; set; }


        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}