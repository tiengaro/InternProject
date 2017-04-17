using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InternProject.Services;
using Xamarin.Forms;

namespace InternProject.ViewModels
{
    public class HomePageTabSettingViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        public ICommand ClickLogoutCommand { get; private set; }

        public HomePageTabSettingViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ClickLogoutCommand = new Command(async () => await OnClickLogout());
        }

        private async Task OnClickLogout()
        {
            if (await _pageService.DisplayAlert("Notification", "Are you sure logout!", "Yes", "Cancle"))
            {
                await _pageService.PopToRootAsync();
            }
        }
    }

}
