using Microsoft.AspNetCore.Identity;

namespace BlazeDirect.Data
{
    public class ApplicationUser : IdentityUser
    {   
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public int? PersonID { get; set; }
        public int? UserLevelID { get; set; }
        public UserLevel UserLevel { get; set; }

    }
}
