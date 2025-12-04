
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Client.Pages
{
    public partial class EmployeeOverview
    {
        private Employee? _selectedEmployee;
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }
        public List<Employee>? Employees { get; set; }= default!;
        private string Title ="Employee Overview";
        protected async override Task OnInitializedAsync()
        {
           /* await Task.Delay(200);*/ // Simulate async data fetch
            //Employees = MockDataService.Employees;
            Employees = (await EmployeeDataService!.GetAllEmployees()).ToList();
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
           
        }
    }
}
