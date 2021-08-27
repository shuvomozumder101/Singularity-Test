﻿using System;
using HomeOfficeManagement.Data;
using HomeOfficeManagement.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HomeOfficeManagement.Areas.Identity.IdentityHostingStartup))]
namespace HomeOfficeManagement.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                //    services.AddDbContext<ApplicationDbContext>(options =>
                //   options.UseSqlServer(
                //      context.Configuration.GetConnectionString("DefaultConnection")));

                //    services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                //        .AddEntityFrameworkStores<ApplicationDbContext>();
            });
        }
    }
}