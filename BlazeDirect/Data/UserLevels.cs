using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazeDirect.Data
{
    [Table("UserLevels")]
    public class UserLevel
    {
        public UserLevel()
        {

        }



        [Key]
        public int Id { get; set; }
        public int Level { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        // Foreign key to UserLevel
        public int UserLevelId { get; set; }

        // Navigation property for the relationship
        [ForeignKey("UserLevelId")]
        public UserLevel? UserLevel { get; set; }
    }

}