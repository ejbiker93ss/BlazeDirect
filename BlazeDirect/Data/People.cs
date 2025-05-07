using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazeDirect.Data
{
    [Table("People")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? Nickname { get; set; }
        public string Name => FirstName + " " + MiddleName + " " + LastName;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? JoinedDate { get; set; } = DateTime.Now;
        public DateTime? BirthDate { get; set; }
        public DateTime? BaptismDate { get; set; }
        public string? Patronyme { get; set; }
        [Required]
        public bool? IsMale { get; set; }
        public bool? IsFemale => !IsMale;
        public string? Notes { get; set; }
        public int ChurchId { get; set; }
        public string? Uid { get; set; }
        public string? IdFather { get; set; }
        public string? IdMother { get; set; }
        public string? IdIndividual { get; set; }
        public string? PartnerId { get; set; }


    }

    [Table("Relationships")]
    public class Relationship
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        [Required]
        public int RelatedPersonId { get; set; }
        public Person RelatedPerson { get; set; } = null!;

        [Required]
        public int RelationshipTypeId { get; set; }
        public RelationshipType RelationshipType { get; set; } = null!;

        public DateTime? MarriageStartDate { get; set; }
        public DateTime? MarriageEndDate { get; set; }
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
    [Table("RelationshipTypes")]
    [Index(nameof(Name), IsUnique = true)]
    public class RelationshipType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

    }
    [Table("PersonPlaceTypes")]
    public class PersonPlaceType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Place))]
        public int PlaceId { get; set; }
        public Place Place { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(PlaceType))]
        public int PlaceTypeId { get; set; }
        public PlaceType PlaceType { get; set; } = null!;
    }

}
