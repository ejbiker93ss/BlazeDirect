using Microsoft.AspNetCore.Identity;

namespace BlazeDirect.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int PersonID { get; set; }
        public int UserLevelID { get; set; }

    }
}
