using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazeDirect.Data
{
    [Table("Places")]
    public class Place
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(100)]
        public string? County { get; set; }

        [StringLength(100)]
        public string? State { get; set; }

        public int? TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public PlaceType? Type { get; set; }

        public int? PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person? Person { get; set; }

        public DateTime CreatedAt { get; set; }
    }
    [Table("PlaceTypes")]
    public class PlaceType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
