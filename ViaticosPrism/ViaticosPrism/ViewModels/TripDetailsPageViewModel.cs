using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using Viaticos.Common.Models;
using ViaticosPrism.ViewModels;

namespace Viaticos.Prism.ViewModels
{
    public class TripDetailsPageViewModel : ViewModelBase
    {
        private TripResponse _trip;

        private List<TripDetailResponse> _tripDetails;

        public TripDetailsPageViewModel(INavigationService navigationService) : base (navigationService) 
        {
            Title = "Details";
        }

        public List<TripDetailResponse> TripDetails 
        {
            get => _tripDetails;
            set => SetProperty(ref _tripDetails, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _trip = parameters.GetValue<TripResponse>("trip");
            Title = $"Expenses: {_trip.Name}";

            TripDetails = _trip.TripDetails.ToList();
        }
    }
}
