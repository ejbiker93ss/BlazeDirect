using BlazeDirect.Data.Models;
using BlazeDirect.Data;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using BlazeDirect.Data.Services;

namespace BlazeDirect.Shared.Components
{
    public class AddEditPersonDialogBase : ComponentBase
    {
        [Parameter]
        public PersonViewModel PersonViewModel { get; set; }
        [Parameter]
        public EventCallback<PersonViewModel> CloseAddEditPersonDialog { get; set; }

        protected readonly DialogOptions dialogOptions = new()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true
        };
     
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
        protected override async void OnAfterRender(bool firstRender)
        {
            StateHasChanged();
        }
        protected async Task ClosePersonDialog()
        {
            PersonViewModel = new PersonViewModel()
            {
                IsDialogVisible = false
            };

            await CloseAddEditPersonDialog.InvokeAsync(PersonViewModel);
        }

        //Call from PersonAddForm-EventCallback
        protected async Task UpdatePersonInfo(PersonViewModel person)
        {
            PersonViewModel.IsNew = true;            
            await CloseAddEditPersonDialog.InvokeAsync(PersonViewModel);
        }


        //Family relationship related code
        [Inject]
        protected IRelationshipService RelationshipService { get; set; }       
        protected RelationshipViewModel RelationshipViewModel = new RelationshipViewModel();
        protected List<Relationship> Relationships = new List<Relationship>();        
        protected async Task LoadRelationshipTable()
        {
            Relationships = await RelationshipService.GetAllRelationshipByPersonIdAsync(PersonViewModel.Id);
        }

        protected async Task ShowFamilyDialog()
        {
            RelationshipViewModel = new RelationshipViewModel();
            RelationshipViewModel.RelationshipType = await RelationshipService.GetAllRelationshipTypeAsync();
            RelationshipViewModel.PersonId = PersonViewModel.Id;
            RelationshipViewModel.PersonName = $"{PersonViewModel.FirstName} {PersonViewModel.LastName}";
            RelationshipViewModel.ShowFamilyDialog = true;
        }

        // Call from FamilyRelationshipDialog-EventCallback
        protected async Task UpdateFamilyInfo(RelationshipViewModel model)
        {
            if (model.RelatedPerson != null)
            {
                await RelationshipService.AddRelationshipAsync(new Relationship()
                {
                    PersonId = PersonViewModel.Id,
                    Notes = model.Notes,
                    RelatedPersonId = model.RelatedPerson.Id,
                    RelationshipTypeId = model.RelationshipTypeId,
                    MarriageStartDate = new DateTime(),
                    MarriageEndDate = new DateTime(),
                    CreatedAt = new DateTime()
                });
            }
            RelationshipViewModel = new RelationshipViewModel();
            Relationships = await RelationshipService.GetAllRelationshipByPersonIdAsync(PersonViewModel.Id);
        }
        
        //public async Task Dispose()
        //{
        //    await RelationshipService.Dispose();
        //}
    }
}
