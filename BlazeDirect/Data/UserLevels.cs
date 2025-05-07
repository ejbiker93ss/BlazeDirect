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
        public string Level { get; set; }
    }


}