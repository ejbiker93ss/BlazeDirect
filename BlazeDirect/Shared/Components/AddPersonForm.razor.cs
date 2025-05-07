using BlazeDirect.Data;
using BlazeDirect.Data.Models;
using BlazeDirect.Data.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazeDirect.Shared.Components
{
    public class AddPersonFormBase : ComponentBase
    {
        [Parameter]
        public int PersonId { get; set; }
        [Parameter]
        public EventCallback<bool> RefreshPersonaGrid { get; set; }
       
        [Inject]
        protected IPersonService PersonService { get; set; }
        [Inject]
        protected IChurchService ChurchService { get; set; }
        [Inject]
        protected ISnackbar Snackbar { get; set; }
        
        protected Person Person=new Person();
        protected List<Church> Churches = new List<Church>();
       
        protected override async Task OnInitializedAsync()
        {
            if (PersonId > 0)
                Person = await GetPerson(PersonId);
            Churches = await GetChurches();
            await base.OnInitializedAsync();
        }
        
        protected override void OnAfterRender(bool firstRender)
        {
        }
       
        protected async Task SavePersonAsync()
        {
            try
            {
                if (Person.Id == 0)
                {
                 await   PersonService.AddPersonAsync(Person);
                    Snackbar.Add("Person adding success", Severity.Success);
                }
                else
                {
                    await PersonService.UpdatePersonAsync(Person);
                    Snackbar.Add("Person updating success", Severity.Success);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Person adding error:{ex.Message} ", Severity.Error);
            }

            await RefreshPersonaGrid.InvokeAsync(false);
        }
       
        protected async Task<Person> GetPerson(int personId)
        {
           return await PersonService.GetPersonByIdAsync(personId);            
        }

        protected async Task<List<Church>> GetChurches()
        {
            return await ChurchService.GetAllChurchAsync();
        }
    }
}
