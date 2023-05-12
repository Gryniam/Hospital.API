using Hospital.API.Data;
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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Google;
using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Data.DataManager.EntityFrameworkCore;

namespace Hospital.API
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
            services.AddDistributedMemoryCache();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });


            services.AddAuthorization();


            services.AddScoped<HashPassword>();
            services.AddScoped<IUser, EFUser>();
            services.AddScoped<IPatient, EFPatient>();
            services.AddScoped<IDoctor, EFDoctor>();
            services.AddScoped<IHospital, EFHospital>();
            services.AddScoped<IWork, EFWork>();
            services.AddScoped<IDepartament, EFDepartament>();
            services.AddScoped<ICast, EFCast>();
            services.AddScoped<IIndexes, EFIndexes>();
            services.AddScoped<ILocation, EFLocation>();
            services.AddScoped<IAppoiment, EFAppoiment>();
            services.AddScoped<ICase,EFCase>();
            services.AddScoped<ISpecialty, EFSpecialty>();
            services.AddScoped<ISubstance, EFSubstance>();
            services.AddScoped<ITime,EFTime>();
            services.AddScoped<ITreatment, EFTreatment>();
            

            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddDbContext<HospitalDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("HospitalDbConnectionString")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital.API", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy => policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                   );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HospitalDbContext context)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hospital.API v1"));
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



            SampleData.ClearAllTables(context);
            ManualData.fillData(context);
        }
    }
}
