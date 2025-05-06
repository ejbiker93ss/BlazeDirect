using BlazeDirect.Data.Models;
using BlazeDirect.Data;
using Microsoft.AspNetCore.Components;
using System.Net.NetworkInformation;
using BlazeDirect.Data.Services;

namespace BlazeDirect.Shared.Components
{
    public class FamilyRelationshipDialogBase : ComponentBase
    {
        [Parameter]
        public RelationshipViewModel RelationshipViewModel { get; set; }

        [Parameter]
        public List<Relationship> Relationships { get; set; }

        [Parameter]
        public EventCallback<RelationshipViewModel> UpdateFamilyInfo { get; set; }

        [Inject]
        protected IPersonService PersonService { get; set; }
        
        protected List<Person> Persons = new List<Person>();

        protected override async Task OnInitializedAsync()
        {
            Thread.Sleep(100);
            Persons = await PersonService.GetAllPersonAsync();
            await base.OnInitializedAsync();
        }
        protected override async void OnAfterRender(bool firstRender)
        {           
            Persons = Persons.Where(x => !Relationships.Any(p => p.RelatedPersonId == x.Id) && x.Id != RelationshipViewModel.PersonId).ToList();

            if (RelationshipViewModel.RelationshipTypeId == 0 && RelationshipViewModel.RelationshipType.Count > 0)
                RelationshipViewModel.RelationshipTypeId = RelationshipViewModel.RelationshipType.FirstOrDefault().Id;
           
            StateHasChanged();
        }
        protected async Task CloseFamilyDialog()
        {
            RelationshipViewModel.RelatedPerson = null;
            RelationshipViewModel.ShowFamilyDialog = false;

            ////Call to AddEditPersonDialog-EventCallback
            await UpdateFamilyInfo.InvokeAsync(RelationshipViewModel);
        }
        protected async Task SaveRelationshipAsync()
        {
            RelationshipViewModel.ShowFamilyDialog = false;

            ////Call to AddEditPersonDialog-EventCallback
            await UpdateFamilyInfo.InvokeAsync(RelationshipViewModel);
        }

        protected async Task<IEnumerable<Person>> Search(string value, CancellationToken token)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Persons;
            }
            return Persons.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
        public async Task Dispose()
        {
            PersonService.Dispose();
        }
    }
}