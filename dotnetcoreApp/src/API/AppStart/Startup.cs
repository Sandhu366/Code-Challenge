using Application.Remarks.QueryHandlers;
using AutoMapper;
using Common.Mappings;
using Core.CommandManager;
using Core.QueryManager;
using Factories.Remarks;
using Factories.Shouts;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.UnitOfWork;
using Serilog;
using System.Reflection;
using Validations;

namespace API.AppStart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = configuration.GetConnectionString("CommandConStr");
        }

        public IConfiguration Configuration { get; }

        private string _connectionString;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });


            services
                .AddMvc(options =>
                        {
                            options.Filters.Add(new ValidationFilter());
                        })
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<ControllerValidator<object>>());

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(_connectionString);
            });

            // Dependency injection
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IQueryManager, QueryManager>();
            services.AddScoped<ICommandManager, CommandManager>();
            services.AddScoped<IRemarkFactory, RemarkFactory>();
            services.AddScoped<IShoutFactory, ShoutFactory>();
            services.AddScoped<IPersistenceUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();

            services.AddMediatR(typeof(GetRemarksQueryHandler).GetTypeInfo().Assembly);


            services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy => policy.AllowAnyHeader()
                                                                                .AllowAnyMethod()
                                                                                .WithOrigins("http://localhost:3000"))
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnetcoreApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StartupDatabaseMigrations.Configuration(app.ApplicationServices, Log.Logger);

            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
