using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; } = default!;
        protected async override  Task OnInitializedAsync()
        {
            Employee  = await EmployeeDataService!.GetEmployeeDetails(EmployeeId);
        }

        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday=!Employee.IsOnHoliday;
        }
    }
}
