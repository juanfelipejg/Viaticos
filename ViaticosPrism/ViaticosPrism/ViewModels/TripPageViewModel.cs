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
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private List<TripItemViewModel> _trips;

        public TripPageViewModel(INavigationService navigationService, IApiService apiService) : base (navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "My Trips";
            LoadTripsAsync();
        }
        public List<TripItemViewModel> Trips 
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

            var trips = (List<TripResponse>)response.Result;

            Trips = trips.Select(t => new TripItemViewModel (_navigationService)
            {
            Id = t.Id,
            Name = t.Name,
            StartDate = t.StartDate,
            EndDate = t.EndDate,
            City = t.City,
            TripDetails = t.TripDetails,
            User=t.User
            }).ToList();


        }
    }
}
 