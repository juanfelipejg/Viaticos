using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Viaticos.Common.Models;
using Viaticos.Prism.Views;

namespace Viaticos.Prism.ViewModels
{
    public class TripItemViewModel : TripResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectTripCommand;

        public TripItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand SelectTripCommand => _selectTripCommand ?? 
        (_selectTripCommand = new DelegateCommand(SelectTripAsync));

        private async void SelectTripAsync()
        {
            var parameters = new NavigationParameters
            {
                { "trip", this }
        
            };
           
        await _navigationService.NavigateAsync(nameof(TripDetailsPage), parameters);
        }
    }
}
