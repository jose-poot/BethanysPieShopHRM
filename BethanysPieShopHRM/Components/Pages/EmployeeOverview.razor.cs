using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeOverview
    {
        private Employee? _selectedEmployee;

        public List<Employee>? Employees { get; set; }= default!;
        protected async override Task OnInitializedAsync()
        {
           /* await Task.Delay(200);*/ // Simulate async data fetch
            Employees = MockDataService.Employees;
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
           
        }
    }
}
