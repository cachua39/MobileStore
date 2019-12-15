using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MobileStore.Areas.Identity.Data;
using MobileStore.Data;

[assembly: HostingStartup(typeof(MobileStore.Areas.Identity.IdentityHostingStartup))]
namespace MobileStore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<MobileStoreContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("MobileStoreContextConnection")));

            //    services.AddDefaultIdentity<MobileStoreUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<MobileStoreContext>();
            //});
        }
    }
}