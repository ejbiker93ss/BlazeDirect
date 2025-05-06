using System.ComponentModel.DataAnnotations;

namespace BlazeDirect.Data.Models
{
    public class PersonViewModel
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
        [Required] public string Phone { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Address { get; set; }
        public int IsActive { get; set; }
        //public DateTime? JoinedDate { get; set; } = DateTime.Now;
        public DateTime? BirthDate { get; set; }
        public DateTime? BaptismDate { get; set; }
        public string? BirthPlace { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? DeathPlace { get; set; }
        public string? Patronyme { get; set; }
        [Required]
        public int IsMale { get; set; }
        public string? Notes { get; set; }
        public int ChurchId { get; set; }
        public string? Uid { get; set; }
        public string? IdFather { get; set; }
        public string? IdMother { get; set; }
        public string? IdIndividual { get; set; }
        public string? PartnerId { get; set; }
        public bool IsNew { get; set; }
        public List<Church> Churches { get; set; }
        public bool IsDialogVisible { get; set; }        
    }
}
