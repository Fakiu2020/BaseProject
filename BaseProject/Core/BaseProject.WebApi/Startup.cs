using System.IO.Compression;
using System.Linq;
using System.Net;
using AutoMapper;
using FluentValidation.AspNetCore;
using BaseProject.WebApi.Extensions;
using BaseProject.WebApi.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Whoever.Web.Extensions;
using Whoever.Web.Filters.Http;
using Whoever.Web.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BaseProject.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Add AutoMapper
            services
                .AddCaching()
                .AddOptions(Configuration)
                .AddBaseProjectIdentity()
                .AddBaseProjectDbContext(Configuration)
                .AddAutoMapperProfiles()
                .AddBaseProjectJwt(Configuration)
                .AddCorsPolicies()
                .AddSwagger()
                .AddCustomServices()
                .AddResponseCaching()
                



                //Add response compression to enable GZIP compression.
                .AddResponseCompression(
                    options => {
                        // Add additional MIME types (other than the built in defaults) to enable GZIP compression for.
                        var settings = Configuration.GetSection<ResponseCompressionSettings>(ResponseCompressionSettings.Key);
                        options.MimeTypes = ResponseCompressionDefaults
                            .MimeTypes
                            .Concat(settings.MimeTypes);
                    })
                .Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal)
                // Customise default API behavour
                .Configure<ApiBehaviorOptions>(options => {
                    options.SuppressModelStateInvalidFilter = true;
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // MVC
            services
                .AddMvc(options => {
                    // Controls how controller actions cache content from the config.json file.
                    var settings = Configuration.GetSection<CacheProfileSettings>(nameof(CacheProfileSettings));
                    foreach (var keyValuePair in settings.CacheProfiles)
                    {
                        options.CacheProfiles.Add(keyValuePair);
                    }
                    options.Filters.Add(typeof(LogExceptionFilterAttribute));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddControllersAsServices()
                // Configures the JSON output formatter to use camel case property names like 'propertyName' instead of
                // pascal case 'PropertyName' as this is the more common JavaScript/JSON style.
                .AddJsonOptions(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
                //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<DeleteCreditCardCommandValidator>());

            services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app
                // Removes the Server HTTP header from the HTTP response for marginally better security and performance.
                .UseNoServerHttpHeader()
                .UseCors(CorsPolicyName.AllowAny)
                //Returns a 500 Internal Server Error response when an unhandled exception occurs.
                .UseInternalServerErrorOnException()
                .UseResponseCaching()
                .UseResponseCompression()
                .UseStaticFilesWithCacheControl(Configuration)
                .UseIfElse(
                    env.IsDevelopment(),
                    x => x
                        .UseDeveloperExceptionPage(),
                    x => x.UseHsts())
                .UseExceptionHandler(
                    builder => {
                        builder.Run(
                            async context => {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                                var error = context.Features.Get<IExceptionHandlerFeature>();
                                if (error != null)
                                {
                                    //context.Response.AddApplicationError(error.Error.Message);
                                    await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                                }
                            });
                    })
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                .UseSwagger()
                .UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials())
                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                // specifying the Swagger JSON endpoint.
                .UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaseProject V1");
                })
                .UseAuthentication()
                .UseMvc();
            //.UseAuthentication()
            //.UseHttpsRedirection();
        }
    }
}
