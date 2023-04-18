using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using System.Threading.Tasks;
using Ticket_booking_API.Data;
using Ticket_booking_API.DTOMapping;
using Ticket_booking_API.Repository;
using Ticket_booking_API.Repository.IRepository;

namespace Ticket_booking_API
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

            string cs = Configuration.GetConnectionString("constr");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(cs));
      services.AddScoped<IUserRepositroy, UserRepository>();
      //services.AddScoped<ITicketRepository,TicketRepository>();
      // services.AddAutoMapper(typeof(MappingProfile));
      //    services.AddScoped<IMapper,MappingProfile>());
      services.AddScoped<ITicketRepository, TicketRepository>();

      services.AddAutoMapper(typeof(MappingProfile));
    


      services.Configure<EmailSetting>(Configuration.GetSection("EmailSetting"));
      services.AddScoped<IEmailSender, EmailSender>();
    // services.AddAutoMapper(typeof(MappingProfile));

      services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket_booking_API", Version = "v1" });
            });

      services.AddCors(options =>
      {
        options.AddPolicy(name: "My Police",
            builder =>
            {
              builder.WithOrigins("http://localhost:4200")
                      .AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
      });
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket_booking_API v1"));
            }
      app.UseCors("My Police");
      app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
