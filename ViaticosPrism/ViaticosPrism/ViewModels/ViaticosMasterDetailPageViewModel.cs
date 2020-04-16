using Newtonsoft.Json;
using Prism.Navigation;
using Viaticos.Common.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ViaticosPrism.ViewModels;


namespace Viaticos.Prism.ViewModels
{
    public class ViaticosMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ViaticosMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "plane",
                    PageName = "TripPage",
                    Title = "My Trips"
                },

                new Menu
                {
                    Icon = "user",
                    PageName = "ModifyUserPage",
                    Title = "Modify User"
                },
                new Menu
                {
                    Icon = "login",
                    PageName = "LoginPage",
                    Title = "Login"
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }
}

