using Microsoft.AspNetCore.Identity;

namespace BlazeDirect.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Church { get; set; }

        //public int UserLevelId { get; set; }

        //// Navigation property for the relationship
        //[ForeignKey("UserLevelId")]
        //public UserLevel? UserLevel { get; set; }
    }
}
