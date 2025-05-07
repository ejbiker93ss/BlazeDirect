using BlazeDirect.Data.Models;
using BlazeDirect.Data;
using Microsoft.AspNetCore.Components;
using System.Net.NetworkInformation;
using BlazeDirect.Data.Services;
using MudBlazor;

namespace BlazeDirect.Shared.Components
{
    public class FamilyRelationshipDialogBase : ComponentBase
    {
        protected MudForm Relationshipform;
        [CascadingParameter] 
        public IMudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int PersonId { get; set; }        
        [Parameter]
        public List<RelationshipType> AllRelationShipType { get; set; }        
        [Parameter]
        public List<Relationship> MyRelationships { get; set; }


        [Inject] 
        protected ISnackbar Snackbar { get; set; }
        [Inject]
        protected IPersonService PersonService { get; set; }
       
        public Relationship Relationship = new Relationship();
        protected List<Person> Persons = new List<Person>();
        protected string PersonName = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Thread.Sleep(100);
            Persons = await PersonService.GetAllPersonAsync();
            var person = Persons.FirstOrDefault(x => x.Id == PersonId);
            PersonName = person == null ? string.Empty : $"{person.FirstName} {person.LastName}";

            await base.OnInitializedAsync();
        }
      
        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Persons = Persons.Where(x => !MyRelationships.Any(p => p.RelatedPersonId == x.Id) && x.Id != PersonId).ToList();

                if (Relationship.RelationshipTypeId == 0 && AllRelationShipType.Count > 0)
                    Relationship.RelationshipTypeId = AllRelationShipType.FirstOrDefault().Id;
            }

            StateHasChanged();
        }
        
        protected async Task<IEnumerable<Person>> Search(string value, CancellationToken token)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Persons;
            }
            return Persons.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
        
        protected void Cancel() => MudDialog.Cancel();
        
        protected void Submit()
        {
            Relationship.PersonId = PersonId;
            if (Relationship.RelatedPerson != null)
            {
                Relationship.RelatedPersonId = Relationship.RelatedPerson.Id;
                MudDialog.Close(DialogResult.Ok(Relationship));
            }
            else
                Snackbar.Add("Related Person should not blank", Severity.Error);
        }

    
        public async Task Dispose()
        {
            PersonService.Dispose();
        }
    }
}