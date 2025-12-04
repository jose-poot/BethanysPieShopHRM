using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public List<TimeRegistration> TimeRegistrations { get; set; } = [];
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; } = default!;
        [Inject]
        public ITimeRegistrationService? TimeRegistrationService { get; set; } = default!;
        private float itemHeight = 50;
        protected IQueryable<TimeRegistration>? itemsQueryable;
        protected int queryableCount;
        protected async override  Task OnInitializedAsync()
        {
            Employee  = await EmployeeDataService!.GetEmployeeDetails(EmployeeId);
            //TimeRegistrations = await TimeRegistrationService!.GetTimeRegistrationsForEmployee(EmployeeId);

            itemsQueryable = (await TimeRegistrationService!.GetTimeRegistrationsForEmployee(EmployeeId)).AsQueryable();

            queryableCount = itemsQueryable.Count();
        }
        public async ValueTask<ItemsProviderResult<TimeRegistration>> LoadTimeRegistrations(ItemsProviderRequest request)
        {
            int totalNumberOfTimeRegistrations = await TimeRegistrationService.GetTimeRegistrationCountForEmployeeId(EmployeeId);

            var numberOfTimeRegistrations = Math.Min(request.Count, totalNumberOfTimeRegistrations - request.StartIndex);
            var listItems = await TimeRegistrationService.GetPagedTimeRegistrationsForEmployee(EmployeeId, numberOfTimeRegistrations, request.StartIndex);

            return new ItemsProviderResult<TimeRegistration>(listItems, totalNumberOfTimeRegistrations);
        }



        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday=!Employee.IsOnHoliday;
        }
    }
}
