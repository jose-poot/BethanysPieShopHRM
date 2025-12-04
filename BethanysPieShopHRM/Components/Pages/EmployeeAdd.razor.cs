using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components.Pages;
public partial class EmployeeAdd
{
    [SupplyParameterFromForm]
    public Employee Employee { get; set; }

    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }
    protected string message = string.Empty;
    protected bool IsSaved = false;
    override protected void OnInitialized()
    {
        Employee ??= new Employee();
    }

    private async Task OnSubmit()
    {
        // Logic to handle form submission, e.g., save the Employee data
        await EmployeeDataService.AddEmployee(Employee);
        IsSaved = true;
        message = "Employee added successfully!";
    }
}
