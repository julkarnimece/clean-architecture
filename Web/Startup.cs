using System.Data;
using Application.Behaviors;
using Domain.Abstractions;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

            services.AddControllers().AddApplicationPart(presentationAssembly);

            var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

            services.AddMediatR(applicationAssembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(applicationAssembly);

            services.AddSwaggerGen(c =>
            {
                var presentationDocumentationFile = $"{presentationAssembly.GetName().Name}.xml";

                var presentationDocumentationFilePath = Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);

                c.IncludeXmlComments(presentationDocumentationFilePath);

                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Web", Version = "v1" });

            });

            services.AddDbContext<ApplicationDbContext>(builder => builder.UseNpgsql(Configuration.GetConnectionString("Application")));

            services.AddScoped<IWebinarRepository, WebinarRepository>();

            services.AddScoped<IUnitOfWork>(factory => factory.GetRequiredService<ApplicationDbContext>());


            services.AddScoped<IDbConnection>(factory => factory.GetRequiredService<ApplicationDbContext>().Database.GetDbConnection());





        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();    
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));

            }



        }






    }
}
