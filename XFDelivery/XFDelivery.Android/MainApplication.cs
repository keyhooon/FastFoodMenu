using System;

using Android.App;

using Android.Runtime;

using Microsoft.Extensions.DependencyInjection;


using Shiny;

namespace XFDelivery.Droid
{
    [Application(Label = "FoodCenter",
                Icon = "@mipmap/icon")]
    public class MainApplication : ShinyAndroidApplication<XFDelivery.Startup>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
        protected override void OnBuildApplication(IServiceCollection builder)
        {
            base.OnBuildApplication(builder);
        }
    }
}
