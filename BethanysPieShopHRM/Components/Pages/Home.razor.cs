namespace BethanysPieShopHRM.Components.Pages;
public partial class Home
{
    public List<Type> Widgets { get; set; } = new List<Type>
    {
        typeof(Widgets.EmployeeCountWidget),
        typeof(Widgets.InboxWidget)
    };
}
