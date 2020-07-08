using Prism.Ioc;
using Prism.Mvvm;
using Syncfusion.Licensing;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;
using XFDelivery.Interfaces;
using XFDelivery.Views;

namespace XFDelivery
{
    public partial class App
    {
        public App()
        {

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>("MainPage");
            containerRegistry.RegisterForNavigation<DetailPage>("DetailPage");
            containerRegistry.RegisterForNavigation<NavigationPage>("Nav");
        }

        protected override void OnInitialized()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewName = viewType.FullName;
                viewName = viewName.Replace(".Views.", ".ViewModels.").Replace("Page", "PageViewModel");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewAssemblyName);
                return Type.GetType(viewModelName);

            });
            Device.SetFlags(new[] { "Shapes_Experimental" });
            SyncfusionLicenseProvider.RegisterLicense("NzM3NEAzMTM3MmUzNDJlMzBPRm41TTBEL2hiZ0pjbG93dDZPQ0VocmRCWkJHSXlzWFgrUkxrZVlDaUpzPQ==");
            NavigationService.NavigateAsync("MainPage");


        }
    }
}