using Microsoft.AspNetCore.Builder;
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
using Persistance.RepositoryProfiles.Meal;
using Application.Meal.DataModel.Seeked.Mapping;
using Application.Meal.DataModel.Seeked.Data;
using Application.Meal.DataModel.Sended;
using Application.Meal.Interface;
using Persistance.RepositoryProfiles.Aliment;
using Application.Meal;
using Application.Aliment.DataModel.Seeked.Mapping;
using Application.Aliment.DataModel.Seeked.Data;
using Application.Aliment.DataModel.Sended;
using Application.Aliment;
using Application.Aliment.Interface;
using Persistance.RepositoryProfiles.MealXAliment;
using Application.Node;
using Application.Node.DataModel.Sended;
using Application.Node.Interface;

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
                config.AddProfile(new MealRepositoryProfile(
                    serviceProvider.GetService<IDatabase>()
                ));
                config.AddProfile(new AlimentRepositoryProfile(
                    serviceProvider.GetService<IDatabase>()
                ));
                config.AddProfile(new MealXAlimentRepositoryProfile(
                    serviceProvider.GetService<IDatabase>()
                ));
            }).CreateRepositoryManager());

            //Account app

            services.AddScoped<ISeekedDataMapping<AccountView>, AccountViewMapping>();
            services.AddScoped<ISendedDataValidation<AccountModel>, AccountModelValidation>();

            //Meal app

            services.AddScoped<ISeekedDataMapping<MealView>, MealtViewMapping>();
            services.AddScoped<ISendedDataValidation<MealModel>, MealModelValidation>();

            //Aliment app

            services.AddScoped<ISeekedDataMapping<AlimentView>, AlimentViewMapping>();
            services.AddScoped<ISendedDataValidation<AlimentModel>, AlimentModelValidation>();

            //Node app

            services.AddScoped<ISendedDataValidation<LoginModel>, LoginModelValidation>();

            serviceProvider = services.BuildServiceProvider();


            //Auto Mapper
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.AddProfile(new AccountDataMapProfile(
                    serviceProvider.GetService<ISeekedDataMapping<AccountView>>()
                ));
                config.AddProfile(new MealDataMapProfile(
                    serviceProvider.GetService<ISeekedDataMapping<MealView>>()
                ));
                config.AddProfile(new AlimentDataMapProfile(
                    serviceProvider.GetService<ISeekedDataMapping<AlimentView>>()
                ));
            }).CreateMapper());

            //Data Validator
            services.AddSingleton(new Configuration(config =>
            {
                config.AddProfile(new AccountValidationProfile(
                    serviceProvider.GetService<ISendedDataValidation<AccountModel>>()
                ));
                config.AddProfile(new MealValidationProfile(
                    serviceProvider.GetService<ISendedDataValidation<MealModel>>()
                ));
                config.AddProfile(new AlimentValidationProfile(
                    serviceProvider.GetService<ISendedDataValidation<AlimentModel>>()
                ));
                config.AddProfile(new NodeValidationProfile(
                    serviceProvider.GetService<ISendedDataValidation<LoginModel>>()
                ));
            }).CreateValidator());

            //Account App
            services.AddScoped<IAccountCommand, AccountCommand>();
            services.AddScoped<IAccountQuery, AccountQuery>();

            //Meal App
            services.AddScoped<IMealCommand, MealCommand>();
            services.AddScoped<IMealQuery, MealQuery>();

            //Meal App
            services.AddScoped<IAlimentCommand, AlimentCommand>();
            services.AddScoped<IAlimentQuery, AlimentQuery>();

            //Node App
            services.AddScoped<INodeCommand, NodeCommand>();
            services.AddScoped<INodeQuery, NodeQuery>();

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
