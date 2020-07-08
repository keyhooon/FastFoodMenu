using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Logging;

using Shiny.Prism;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFDelivery
{
    public class Startup : PrismStartup
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //Log.UseConsole();
            Log.UseDebug();
            services.AddSingleton<SqliteConnection>();
            services.UseMemoryCache();
            //            services.UseSqliteCache();
            services.AddSingleton<Service.DataService>();
            services.UseBleClient();
            services.UseSqliteLogging(true, true);

            // Register Stuff
        }


    }

}
