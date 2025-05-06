using BlazeDirect.Data.Models;
using Microsoft.AspNetCore.Components;

namespace BlazeDirect.Shared.Components
{
    public class AddPersonFormBase : ComponentBase
    {
        [Parameter]
        public PersonViewModel PersonViewModel { get; set; }
        [Parameter]
        public EventCallback<PersonViewModel> UpdatePersonInfo { get; set; }
      
        protected async Task SavePersonAsync()
        {
            PersonViewModel.IsNew = true;

            //Call to PersonDialog-EventCallback
            await UpdatePersonInfo.InvokeAsync(PersonViewModel);
        }
        protected override async void OnAfterRender(bool firstRender)
        {
            StateHasChanged();
        }
    }
}
