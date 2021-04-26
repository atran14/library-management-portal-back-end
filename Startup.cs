using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Services.DALs;
using back_end.DatabaseContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace back_end
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "back_end", Version = "v1" });
            });

            //Important
            services.AddCors( options => {
                options.AddDefaultPolicy(
                    builder => {
                        builder.WithOrigins(
                            "http://localhost:3000"
                        )
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                    });
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie("Cookies", options =>
                {
                    options.Cookie.Name = "auth_cookie";
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = redirectContext =>
                        {
                            redirectContext.HttpContext.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddDbContext<LibraryContext>();
            services.AddTransient<IAsyncBookRepository, AsyncBookRepository>();
            services.AddTransient<IAsyncUserRepository, AsyncUserRepository>();
            services.AddTransient<IAsyncCategoryRepository, AsyncCategoryRepository>();
            services.AddTransient<IAsyncBorrowRequestRepository, AsyncBorrowRequestRepository>();
            services.AddTransient<IAsyncBorrowRequestDetailsRepository, AsyncBorrowRequestDetailsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "back_end v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCookiePolicy(
                new CookiePolicyOptions {
                    Secure = CookieSecurePolicy.Always
                }
            );

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
