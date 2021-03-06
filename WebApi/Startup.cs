﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using DataValidator.Configuration;
using Application.Account.Interface;
using Application.Account;
using Application.Account.DataModel.Sended;
using Persistance.Database;
using Persistance.Database.Context;
using Persistance.RepositoryProfiles.Account;
using Application.Account.DataModel.Seeked.Data;
using Application.Interface.SeekedDataMapping;
using Application.Account.DataModel.Seeked.Mapping;
using Application.Interface.SendedDataValidation;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //Persistances
            services.AddDbContext<MealSaverContext>(options => options.UseSqlServer("Server=EMILE-PC;Database=MealSaver;Trusted_Connection=True;"));
            services.AddScoped<IDatabase, Database>();

            var serviceProvider = services.BuildServiceProvider();

            //RepositoryManager
            services.AddSingleton(new RepositoryManager.Configuration.Configuration(config =>
            {
                config.AddProfile(new AccountRepositoryProfile(
                    serviceProvider.GetService<IDatabase>()
                ));
            }).CreateRepositoryManager());

            //Account app

            services.AddScoped<ISeekedDataMapping<AccountView>, AccountViewMapping>();

            services.AddScoped<ISendedDataValidation<AccountModel>, AccountModelValidation>();

            //Comment app

            serviceProvider = services.BuildServiceProvider();


            //Auto Mapper
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.AddProfile(new AccountDataMapProfile(
                    serviceProvider.GetService<ISeekedDataMapping<AccountView>>()
                ));
            }).CreateMapper());

            //Data Validator
            services.AddSingleton(new Configuration(config =>
            {
                config.AddProfile(new AccountValidationProfile(
                    serviceProvider.GetService<ISendedDataValidation<AccountModel>>()
                ));
            }).CreateValidator());

            //Account App
            services.AddScoped<IAccountCommand, AccountCommand>();
            services.AddScoped<IAccountQuery, AccountQuery>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
