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
using Viaticos.Prism.Helpers;

namespace Viaticos.Prism.ViewModels
{
    public class TripPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private List<TripItemViewModel> _trips;
        private bool _isRunning;

        public TripPageViewModel(INavigationService navigationService, IApiService apiService) : base (navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.MyTrips;
            LoadTripsAsync();
        }

        public bool IsRunning { 
            get=> _isRunning;
            set => SetProperty(ref _isRunning, value);} //This line active interfaz (refresh)
        public List<TripItemViewModel> Trips 
        {
            get => _trips;
            set => SetProperty(ref _trips, value); 
        }
        private async void LoadTripsAsync()
        {
            IsRunning = true;
            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                return;
            }
            Response response = await _apiService.GetListAsync<TripResponse>(
                url,
                "/api",
                "/Trips");
            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
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
 