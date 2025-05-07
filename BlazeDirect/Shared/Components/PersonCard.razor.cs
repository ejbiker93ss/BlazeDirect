using BlazeDirect.Data;
using BlazeDirect.Data.Models;
using BlazeDirect.Data.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazeDirect.Shared.Components
{
    public class PersonCardBase : ComponentBase
    {
        public MudDataGrid<Person> dataGrid;
        [Parameter]
        public required ApplicationUser User { get; set; }
        
        [Inject]
        protected IPersonService PersonService { get; set; }
        [Inject]
        protected IChurchService ChurchService { get; set; }
        [Inject]
        protected IDialogService DialogService { get; set; }

        public bool IsEditor { get; set; }        
        protected List<Person> Peoples = new List<Person>();
        protected List<Person> SearchedItems = new List<Person>();
        public int ActionIndex = 0;

        protected override async Task OnInitializedAsync()
        {
            //IsEditor = User.UserLevelID > 1;
            await base.OnInitializedAsync();
        }
      
        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                await GetPersons();
            }

            StateHasChanged();
        }
      
        public void ShowGridAction(Person person)
        {
            if (ActionIndex == person.Id)
                ActionIndex = 0;
            else
                ActionIndex = person.Id;
        }


        // For PersonEdit Dialog     
        protected async Task ShowPersonEditDialog(int personId = 0)
        {
            //var allRelationShip = await RelationshipService.GetAllRelationshipTypeAsync();

            var parameters = new DialogParameters
            {
                ["PersonId"] = personId
            };

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Large,
                FullWidth = true
            };

            var dialog = await DialogService.ShowAsync<AddEditPersonDialog>(
               personId == 0 ? "Add New Person" : "Update Person",
                parameters: parameters,
                options: options
            );

            var result = await dialog.Result;

            if (!result.Canceled && result.Data != null)
            {
                await GetPersons();
            }
        }


        // cod for custom search 
        protected string mainSearchString = string.Empty;
        protected bool IsOpenSearchPanel = false;
        protected bool ShowDeceased = false;
        protected PersonSearchModel PersonSearchModel = new PersonSearchModel();
        protected async Task ShowSearchPanel()
        {
            PersonSearchModel = new PersonSearchModel();
            IsOpenSearchPanel = !IsOpenSearchPanel;

            if (IsOpenSearchPanel)
                SearchedItems = Peoples;
        }
        protected Func<Person, bool> _quickFilter => person =>
        {
            if (string.IsNullOrWhiteSpace(mainSearchString))
                return true;

            var value = $"{person.FirstName} {person.LastName} {person.Email} {person.Address} {person.Phone} {person.Notes}";

            if (value.Contains(mainSearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
        public void Search()
        {
            if (!string.IsNullOrEmpty(PersonSearchModel.Name))
                SearchedItems = SearchedItems.Where(x => $"{x.FirstName} {x.LastName}".Contains(PersonSearchModel.Name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(PersonSearchModel.Area))
                SearchedItems = SearchedItems.Where(x => x.Address.Contains(PersonSearchModel.Area, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(PersonSearchModel.Age))
                SearchedItems = SearchedItems.Where(x => Helper.AgeCalculator(x.BirthDate).ToString().Contains(PersonSearchModel.Age, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(PersonSearchModel.Email))
                SearchedItems = SearchedItems.Where(x => x.Email.Contains(PersonSearchModel.Email, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(PersonSearchModel.Phone))
                SearchedItems = SearchedItems.Where(x => x.Phone.Contains(PersonSearchModel.Phone, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(PersonSearchModel.Status))
                SearchedItems = SearchedItems.Where(x => $"{x.FirstName} {x.LastName}".Contains(PersonSearchModel.Status, StringComparison.OrdinalIgnoreCase)).ToList();

        }
        public void SearchByName(string val)
        {
            SearchedItems = Peoples;
            PersonSearchModel.Name = val;
            Search();
        }
        public void SearchByArea(string val)
        {
            SearchedItems = Peoples;
            PersonSearchModel.Area = val;
            Search();
        }
        public void SearchByAge(string val)
        {
            SearchedItems = Peoples;
            PersonSearchModel.Age = val;
            Search();
        }
        public void SearchByStatus(string val)
        {
            SearchedItems = Peoples;
            PersonSearchModel.Status = val;
            Search();
            // SearchedItems = Peoples.Where(x => x..Contains(val, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void SearchByEmail(string val)
        {
            SearchedItems = Peoples;
            PersonSearchModel.Email = val;
            Search();

        }
        public void SearchByPhone(string val)
        {
            SearchedItems = Peoples;
            PersonSearchModel.Phone = val;
            Search();
        }

        public void ClearFilter()
        {
            SearchedItems = Peoples;
            PersonSearchModel = new PersonSearchModel();
            Search();

        }

        public async Task Dispose()
        {
            PersonService.Dispose();
        }

        // private methods
        private async Task GetPersons()
        {
            Peoples = await PersonService.GetAllPersonAsync();
            SearchedItems = Peoples;
           Thread.Sleep(100);
        }
    
    }
    public class PersonSearchModel
    {
        public string Name { get; set; }
        //Filter by name...
        public string Area { get; set; }
        //Filter by area...
        public string Age { get; set; }
        public string Status { get; set; }
        //Filter by status...
        public string Email { get; set; }
        //Filter by email...
        public string Phone { get; set; }
    }
}
