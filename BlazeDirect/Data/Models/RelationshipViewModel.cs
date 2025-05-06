using System.ComponentModel.DataAnnotations;

namespace BlazeDirect.Data.Models
{
    public class RelationshipViewModel
    {
        public RelationshipViewModel()
        {
            this.RelationshipType = new List<RelationshipType>();
        }
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int RelatedPersonId { get; set; }
        public Person RelatedPerson { get; set; } 
        public int RelationshipTypeId { get; set; }
        public DateTime? MarriageStartDate { get; set; }
        public DateTime? MarriageEndDate { get; set; }
        public string? Notes { get; set; }
        public List<RelationshipType> RelationshipType { get; set; }
        public bool ShowFamilyDialog { get; set; }
    }
}
