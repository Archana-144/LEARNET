
    using System.ComponentModel.DataAnnotations;
namespace LEARNET.Common.Model
{
    public class User
    {
        public int Id { get; set; }

        public string? MemberGuid { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Phone number must contain 10 digits")]
        public string? Phone { get; set; }


        [Required(ErrorMessage = "Membership type is required")]
        public string? MembershipType { get; set; }

        public string? Username { get; set; }

        public string? PasswordHash { get; set; }

        public string? RoleName { get; set; }


        public DateTime CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
        public string Guid { get; set; }


    }
}