using System.Reflection;
using System.Text;
using Autofac;
using AutoMapper;
using FluentValidation.AspNetCore;
using ifsc.tcc.Portal.Api.DependencyResolution;
using ifsc.tcc.Portal.Api.Filters;
using ifsc.tcc.Portal.Application.TermPaperModule.Models.Commands;
using ifsc.tcc.Portal.Application.TermPaperModule.Profiles;
using ifsc.tcc.Portal.Infra.Data.EF.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ifsc.tcc.Portal.Api
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
            services.AddMvcCore(
                config =>
                {
                    config.Filters.Add(new CheckInvalidIdOnRouteFilterAttribute());
                })
                .AddJsonFormatters()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TermPaperAddCommandCommandValidator>());

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                });
            });
            var key = Encoding.ASCII.GetBytes("1312358653DF49C98DC841974DB3D775");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddDbContext<IFSCContext>(options => options.UseMySql(Configuration.GetConnectionString("MYSQL")));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(TermPaperProfile)));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
