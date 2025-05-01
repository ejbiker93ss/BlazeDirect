using System.ComponentModel.DataAnnotations;

namespace BlazeDirect.Data
{
    public class Church
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Area { get; set; }

        [Required]
        public string Address { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int? FellowshipId { get; set; }

        // navigation property if you have a Fellowship entity
        public Fellowship? Fellowship { get; set; }

        public DateTime CreatedAt { get; set; }
    }
    public class Fellowship
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
