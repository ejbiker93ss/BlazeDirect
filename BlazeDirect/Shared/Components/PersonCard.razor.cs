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

        [Inject]
        protected IPersonService PersonService { get; set; }
        [Inject]
        protected IChurchService ChurchService { get; set; }
        [Parameter]
        public required ApplicationUser User { get; set; }
        public bool IsEditor { get; set; }
        public PersonViewModel PersonViewModel = new PersonViewModel();
        protected List<Church> Churches = new List<Church>();
        protected List<Person> Peoples = new List<Person>();
        protected List<Person> SearchedItems = new List<Person>();
        public int ActionIndex = 0;

        protected override async Task OnInitializedAsync()
        {
            IsEditor = User.UserLevelID > 1;
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
        protected async Task ShowPersonEditDialog(Person? person = null)
        {
            PersonViewModel = new PersonViewModel();
            if (person != null && person.Id > 0)
                await GetPerson(person.Id);

            PersonViewModel.Churches = await GetChurches();
            PersonViewModel.IsDialogVisible = true;
        }
        public void ShowGridAction(Person person)
        {
            if (ActionIndex == person.Id)
                ActionIndex = 0;
            else
                ActionIndex = person.Id;
        }

        // call from AddEditPersonDialog-EventCallback-
        protected async Task CloseAddEditPersonDialog(PersonViewModel model)
        {
            if (PersonViewModel.IsNew)
            {
                var person = await PersonService.GetPersonByIdAsync(model.Id);
                if (person == null)
                {
                    person = new Person()
                    {
                        Id = model.Id,
                        UserId = model.UserId,
                        FirstName = model.FirstName,
                        MiddleName = model.MiddleName,
                        LastName = model.LastName,
                        Nickname = model.Nickname,
                        Phone = model.Phone,
                        Email = model.Email,
                        Address = model.Address,
                        IsActive = model.IsActive == 1 ? true : false,
                        //JoinedDate = personViewModel.JoinedDate,
                        BirthDate = model.BirthDate,
                        BaptismDate = model.BaptismDate,
                        Patronyme = model.Patronyme,
                        IsMale = model.IsMale == 1 ? true : false,
                        Notes = model.Notes,
                        ChurchId = model.ChurchId,
                        Uid = model.Uid,
                        IdFather = model.IdFather,
                        IdMother = model.IdMother,
                        IdIndividual = model.IdIndividual,
                        PartnerId = model.PartnerId
                    };
                    await PersonService.AddPersonAsync(person);
                }
                else
                {
                    person.UserId = model.UserId;
                    person.FirstName = model.FirstName;
                    person.MiddleName = model.MiddleName;
                    person.LastName = model.LastName;
                    person.Nickname = model.Nickname;
                    person.Phone = model.Phone;
                    person.Email = model.Email;
                    person.Address = model.Address;
                    person.IsActive = model.IsActive == 1 ? true : false;
                    //JoinedDate = personViewModel.JoinedDate,
                    person.BirthDate = model.BirthDate;
                    person.BaptismDate = model.BaptismDate;
                    person.Patronyme = model.Patronyme;
                    person.IsMale = model.IsMale == 1 ? true : false;
                    person.Notes = model.Notes;
                    person.ChurchId = model.ChurchId;
                    person.Uid = model.Uid;
                    person.IdFather = model.IdFather;
                    person.IdMother = model.IdMother;
                    person.IdIndividual = model.IdIndividual;
                    person.PartnerId = model.PartnerId;
                    await PersonService.UpdatePersonAsync(person);
                }

                await GetPersons();
            }

            PersonViewModel.IsDialogVisible = false;
            StateHasChanged();
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
        }
        private async Task GetPerson(int personId)
        {
            Thread.Sleep(100);
            var model = await PersonService.GetPersonByIdAsync(personId);
            if (model != null)
            {
                PersonViewModel = new PersonViewModel()
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Nickname = model.Nickname,
                    Phone = model.Phone,
                    Email = model.Email,
                    Address = model.Address,
                    IsActive = model.IsActive == true ? 1 : 0,
                    //JoinedDate = personViewModel.JoinedDate,
                    BirthDate = model.BirthDate,
                    BaptismDate = model.BaptismDate,
                    Patronyme = model.Patronyme,
                    IsMale = model.IsMale == true ? 1 : 0,
                    Notes = model.Notes,
                    ChurchId = model.ChurchId,
                    Uid = model.Uid,
                    IdFather = model.IdFather,
                    IdMother = model.IdMother,
                    IdIndividual = model.IdIndividual,
                    PartnerId = model.PartnerId
                };
            }
        }
        private async Task<List<Church>> GetChurches()
        {
            return await ChurchService.GetAllChurchAsync();
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
