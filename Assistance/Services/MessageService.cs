

using static Assistance.Components.Layout.Noification;

namespace Assistance.Services
{
    public class MessageService
    {
        public event Action<string, NotificationLevel>? OnShow;

        public void ShowNotification(string Message, NotificationLevel NotificationLevel)
        {
            OnShow?.Invoke(Message, NotificationLevel);
        }
    }
}
