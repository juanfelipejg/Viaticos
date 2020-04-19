using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Viaticos.Common.Interfaces;
using Viaticos.Prism.Resources;
using Xamarin.Forms;

namespace Viaticos.Prism.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            CultureInfo ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            Culture = ci.Name;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Culture { get; set; }

        public static string Accept => Resource.Accept;

        public static string ConnectionError => Resource.ConnectionError;

        public static string Error => Resource.Error;

        public static string Details => Resource.Details;

        public static string Expenses => Resource.Expenses;

        public static string Login => Resource.Login;

        public static string ModifyUser => Resource.ModifyUser;

        public static string MyTrips => Resource.MyTrips;

        public static string Loading => Resource.Loading;
    }

}
