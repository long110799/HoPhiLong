using System;
using HoPhiLong.Areas.Identity.Data;
using HoPhiLong.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HoPhiLong.Areas.Identity.IdentityHostingStartup))]
namespace HoPhiLong.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HoPhiLongContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HoPhiLongContextConnection")));

                services.AddDefaultIdentity<HoPhiLongUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<HoPhiLongContext>();
            });
        }
    }
}