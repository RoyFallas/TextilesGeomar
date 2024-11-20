using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string UserLastName { get; set; } = null!;

        public string? Address { get; set; }

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }
    }
}

