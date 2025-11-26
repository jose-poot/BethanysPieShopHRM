using BethanysPieShopHRM.State;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components;
public partial class InboxCounter
{
    [Inject]
    public ApplicationState ApplicationState { get; set; }
    private int MessageCount;

    protected override void OnInitialized()
    {
        // For demonstration purposes, we'll set a static message count.
        // In a real application, you would fetch this data from a service.
        MessageCount =  new Random().Next(10);
        ApplicationState.NumberOfMessages = MessageCount;
    }

}
