using System.Collections.Generic;
using System.Linq;
using Data.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;
using School.Extensions;
using Web.Api.Middleware;

namespace Web.Api
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
            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()))
                .AddJsonOptions(opt => opt.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));

            services.AddOpenApiDocument(options =>
            {
                var authorizationUrl = Configuration["Auth:Swagger:AuthorizationUrl"];
                var apiScope = Configuration["Auth:Swagger:ApiScope"];
                var tokenUrl = Configuration["Auth:Swagger:TokenUrl"];
                options.AddSecurity("oauth2", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    AuthorizationUrl = authorizationUrl,
                    TokenUrl = tokenUrl,
                    Flow = OpenApiOAuth2Flow.Implicit,
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Scopes = new Dictionary<string, string>
                    {
                        
                        [apiScope]= "Access APIs",
                    }
                });

                options.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("oauth2"));



            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = $"https://{Configuration["Auth:Domain"]}/";
                options.Audience = Configuration["Auth:Audience"];
            });

            // Nodatime
            services.AddSingleton<IClock>(SystemClock.Instance);

            // Data storage
            services.AddEntityFrameworkStorage(Configuration.GetConnectionString("DataContext"));

            // Services
            services.AddSchoolServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUi3(options =>
                {
                    options.OAuth2Client = new OAuth2ClientSettings
                    {
                        ClientId = Configuration["Auth:Swagger:ClientId"],
                        AppName = "Swagger UI",
                        AdditionalQueryStringParameters = {{ "audience", Configuration["Auth:Audience"] }},
                    };
                });
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseOpenApi();
        }
    }
}
