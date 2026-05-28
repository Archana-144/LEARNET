using System.ComponentModel.DataAnnotations;

namespace LEARNET.Common.DTOs
{
    public class UpdateUserRequest
        
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? MembershipType { get; set; }

            [Required]
            public bool IsActive { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? RoleName { get; set; }
    }
}