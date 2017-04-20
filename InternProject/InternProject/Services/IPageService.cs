using System.Threading.Tasks;
using Xamarin.Forms;

namespace InternProject.Services
{
    public interface IPageService
    {
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
        Task PushAsync(Page page);
        Task PushModelAsync(Page page);
        Task PopToRootAsync();
        Task PopAsync();
        void BackButtonPressed();
    }
}