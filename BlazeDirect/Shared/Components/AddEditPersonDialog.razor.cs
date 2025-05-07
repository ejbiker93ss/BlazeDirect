using BlazeDirect.Data;
using BlazeDirect.Data.Models;
using BlazeDirect.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using MudBlazor;

namespace BlazeDirect.Shared.Components
{
    public class AddEditPersonDialogBase : ComponentBase
    {
        [CascadingParameter]
        public IMudDialogInstance MudDialog { get; set; }      
        [Parameter]
        public int PersonId { get; set; }       
        [Inject] 
        protected ISnackbar Snackbar { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
        
        protected override async void OnAfterRender(bool firstRender)
        {
            StateHasChanged();
        }
        
        //Call from PersonAddForm-EventCallback
        protected async Task RefreshPersonaGrid(bool isRefresh)
        {
            //if (isRefresh)
                MudDialog.Close(isRefresh);
        }


        //Family relationship related code
        [Inject]
        protected IDialogService DialogService { get; set; }
        [Inject]
        protected IRelationshipService RelationshipService { get; set; }
        protected List<Relationship> Relationships = new List<Relationship>();        
        
        protected async Task LoadRelationshipTable()
        {
            Relationships = await RelationshipService.GetAllRelationshipByPersonIdAsync(PersonId);
        }
        
        protected async Task ShowFamilyDialog()
        {
            var allRelationShip = await RelationshipService.GetAllRelationshipTypeAsync();

            var parameters = new DialogParameters
            {
                ["AllRelationShipType"] = allRelationShip,
                ["MyRelationships"] = Relationships,
                ["PersonId"] = PersonId
            };

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            var dialog = await DialogService.ShowAsync<FamilyRelationshipDialog>(
                "Add Family Relationship",
                parameters: parameters,
                options: options
            );

            var result = await dialog.Result;

            if (!result.Canceled && result.Data is Relationship relationship)
            {
               // bool ok;

                if (relationship.Id>0)
                {
                    Snackbar.Add("Relationship note created yet", Severity.Warning);
                    return;
                }
                else
                {
                    //ok=   await RelationshipService.AddRelationshipAsync(relationship);
                    await RelationshipService.AddRelationshipAsync(relationship);
                    Snackbar.Add("Relationship created successfully", Severity.Success);
                }


                await LoadRelationshipTable();

            }
        }
       
        
        //public async Task Dispose()
        //{
        //    await RelationshipService.Dispose();
        //}
    }
}
