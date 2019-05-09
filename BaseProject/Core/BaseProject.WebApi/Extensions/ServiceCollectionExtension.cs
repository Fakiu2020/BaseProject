using AutoMapper;
using BaseProject.Application.Infrastructure;
using BaseProject.Application.Infrastructure.AutoMapper;
using BaseProject.Application.Interfaces;
using BaseProject.Application.Managers;
using BaseProject.Application.Users.Queries.GetAllUsers;
using BaseProject.Common;
using BaseProject.Domain;
using BaseProject.Infrastructure;
using BaseProject.Infrastructure.Auth;
using BaseProject.Persistence;
using BaseProject.Persistence.Stores;
using BaseProject.WebApi.Common;
using BaseProject.WebApi.Controller;
using BaseProject.WebApi.Settings;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Whoever.Common.Interfaces;
using Whoever.Common.UniqueIdentifier;
using Whoever.Entities.Interfaces;

namespace BaseProject.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Configures the anti-forgery tokens for better security. See:
        /// http://www.asp.net/mvc/overview/security/xsrfcsrf-prevention-in-aspnet-mvc-and-web-pages
        /// </summary>
        /// <param name="services">The services collection or IoC container.</param>
        public static IServiceCollection AddAntiforgerySecurely(this IServiceCollection services)
        {
            return services.AddAntiforgery(
                options =>
                {
                    // Rename the Anti-Forgery cookie from "__RequestVerificationToken" to "f". This adds a little
                    // security through obscurity and also saves sending a few characters over the wire.
                    options.Cookie.Name = "f";

                    // Rename the form input name from "__RequestVerificationToken" to "f" for the same reason above
                    // e.g. <input name="__RequestVerificationToken" type="hidden" value="..." />
                    options.FormFieldName = "f";

                    // Rename the Anti-Forgery HTTP header from RequestVerificationToken to X-XSRF-TOKEN. X-XSRF-TOKEN
                    // is not a standard but a common name given to this HTTP header popularized by Angular.
                    options.HeaderName = "X-XSRF-TOKEN";
                });
        }

        /// <summary>
        /// Configures caching for the application. Registers the <see cref="IDistrbutedCache"/> and
        /// <see cref="IMemoryCache"/> types with the services collection or IoC container. The
        /// <see cref="IDistrbutedCache"/> is intended to be used in cloud hosted scenarios where there is a shared
        /// cache, which is shared between multiple instances of the application. Use the <see cref="IMemoryCache"/>
        /// otherwise.
        /// </summary>
        /// <param name="services">The services collection or IoC container.</param>
        public static IServiceCollection AddCaching(this IServiceCollection services)
        {
            return services
                // Adds IMemoryCache which is a simple in-memory cache.
                .AddMemoryCache()
                // Adds IDistributedCache which is a distributed cache shared between multiple servers. This adds a
                // default implementation of IDistributedCache which is not distributed. See below:
                .AddDistributedMemoryCache();
        }

        // Uncomment the following line to use the Redis implementation of IDistributedCache. This will
        // override any previously registered IDistributedCache service.
        // Redis is a very fast cache provider and the recommended distributed cache provider.
        // .AddDistributedRedisCache(
        //     options =>
        //     {
        //     });
        // Uncomment the following line to use the Microsoft SQL Server implementation of IDistributedCache.
        // Note that this would require setting up the session state database.
        // Redis is the preferred cache implementation but you can use SQL Server if you don't have an alternative.
        // .AddSqlServerCache(
        //     x =>
        //     {
        //         x.ConnectionString = "Server=.;Database=ASPNET5SessionState;Trusted_Connection=True;";
        //         x.SchemaName = "dbo";
        //         x.TableName = "Sessions";
        //     });


        /// <summary>
        /// Configures the settings by binding the contents of the config.json file to the specified Plain Old CLR
        /// Objects (POCO) and adding <see cref="IOptionsSnapshot{TOptions}"/> objects to the services collection.
        /// </summary>
        /// <param name="services">The services collection or IoC container.</param>
        /// <param name="configuration">Gets or sets the application configuration, where key value pair settings are
        /// stored.</param>
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {

            return services
                .AddConfigOptions<AppSettings>(configuration, AppSettings.Key)
                .AddConfigOptions<CacheProfileSettings>(configuration, CacheProfileSettings.Key)
                .AddConfigOptions<ResponseCompressionSettings>(configuration, ResponseCompressionSettings.Key)
                .AddConfigOptions<AuthSettings>(configuration, AuthSettings.Key)
                .AddConfigOptions<JwtIssuerSettings>(configuration, JwtIssuerSettings.Key);
                // Adds IOptionsSnapshot<AppSettings> to the services container.
                //.Configure<AppSettings>(configuration.GetSection())
                // Adds IOptionsSnapshot<CacheProfileSettings> to the services container.
                //.Configure<CacheProfileSettings>(configuration.GetSection(CacheProfileSettings.Key))
                //.Configure<DevelopmentSettings>(configuration.GetSection(DevelopmentSettings.Key))
                //.Configure<ResponseCompressionSettings>(configuration.GetSection(ResponseCompressionSettings.Key));
        }

        public static IServiceCollection AddConfigOptions<TOptions>(this IServiceCollection services, IConfiguration configuration, string section) 
            where TOptions : class, new()
        {
            services.Configure<TOptions>(configuration.GetSection(section));
            services.AddSingleton(cfg => cfg.GetService<IOptions<TOptions>>().Value);
            return services;
        }

        public static IServiceCollection AddConfigOptions<TOptions>(this IServiceCollection services, Action<TOptions> configuration)
            where TOptions : class, new()
        {
            services.Configure<TOptions>(configuration);
            services.AddSingleton(cfg => cfg.GetService<IOptions<TOptions>>().Value);
            return services;
        }

        /// <summary>
        /// Add cross-origin resource sharing (CORS) services and configures named CORS policies. See
        /// https://docs.asp.net/en/latest/security/cors.html
        /// </summary>
        /// <param name="services">The services collection or IoC container.</param>
        public static IServiceCollection AddCorsPolicies(this IServiceCollection services)
        {
            return services.AddCors(
                options =>
                {
                    options.AddPolicy(
                    options.DefaultPolicyName,
                    x =>
                    {
                        x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
                    });
                    //options.AddPolicy(
                    //    "MyCustomPolicy",
                    //    x =>
                    //    {
                    //    });
                });
        }

        /// <summary>
        /// Add DbContext using SQL Server Provider
        /// </summary>
        public static IServiceCollection AddBaseProjectDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<BaseProjectDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BaseProjectDatabase"), x => x.UseNetTopologySuite()));
        }

        /// <summary>
        /// Add DbContext using SQL Server Provider
        /// </summary>
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            return services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
        }

        /// <summary>
        /// For api unauthorised calls return 401 with no body
        /// </summary>
        public static IServiceCollection AddBaseProjectIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddUserStore<UserStore>()
                .AddRoleStore<RoleStore>()
                .AddUserManager<UserManager>()
                .AddRoleManager<RoleManager>()
                .AddEntityFrameworkStores<BaseProjectDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }

        public static IServiceCollection AddBaseProjectJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var authSettings = configuration.GetSection(AuthSettings.Key);
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authSettings[nameof(AuthSettings.SecretKey)]));

            // jwt wire up
            // Get options from app settings
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerSettings));

            // Configure JwtIssuerOptions
            services.AddConfigOptions<JwtIssuerSettings>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerSettings.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerSettings.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerSettings.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerSettings.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };


                        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerSettings.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;

                configureOptions.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });

            return services;
        }


        public static IServiceCollection AddSwagger(this IServiceCollection services) {
            // Register the Swagger generator, defining 1 or more Swagger documents
            return services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "BaseProject", Version = "v1" });
                // Swagger 2.+ support
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme {
                    In = "header",
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
        /// <summary>
        /// Configures custom services to add to the ASP.NET Core Injection of Control (IoC) container.
        /// </summary>
        /// <param name="services">The services collection or IoC container.</param>
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IGuidGenerator, SequentialGuidGenerator>();
            services.AddScoped<ICurrentUser<int>, CurrentUser>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
            services.AddSingleton<ITokenFactory, TokenFactory>();
            services.AddSingleton<IJwtTokenValidator, JwtTokenValidator>();

            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestResponseLoggerBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetUserListQuery).GetTypeInfo().Assembly);
        
            //// Add your own custom services here e.g.
            //services.AddScoped(x => x)
            // Singleton - Only one instance is ever created and returned.
            // services.AddSingleton<IExampleService, ExampleService>();

            // Scoped - A new instance is created and returned for each request/response cycle.
            // services.AddScoped<IExampleService, ExampleService>();

            // Transient - A new instance is created and returned each time.
            // services.AddTransient<IExampleService, ExampleService>();

            return services;
        }

        
    }
}
