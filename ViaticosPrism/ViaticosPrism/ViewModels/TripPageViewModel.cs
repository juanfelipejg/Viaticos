using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Viaticos.Common.Services;
using Viaticos.Common.Models;
using ViaticosPrism.ViewModels;
using ViaticosPrism;

namespace Viaticos.Prism.ViewModels
{
    public class TripPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private List<TripResponse> _trips;

        public TripPageViewModel(INavigationService navigationService, IApiService apiService) : base (navigationService)
        {
            _apiService = apiService;
            Title = "Viajes";
            LoadTripsAsync();
        }
        public List<TripResponse> Trips 
        {
            get => _trips;
            set => SetProperty(ref _trips, value); 
        }
        private async void LoadTripsAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<TripResponse>(
                url,
                "/api",
                "/Trips");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                    return;
            }

            Trips = (List<TripResponse>)response.Result;

        }
    }
}
 