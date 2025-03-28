namespace Tracker.Infrastructure
{
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Tracker.Infrastructure.Context;
    using Tracker.Infrastructure.Identity;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, bool isProduction)
        {
            ConfigureDatabase(services, configuration, isProduction);
            ConfigureIdentity(services);
            return services;
        }

        private static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration, bool isProduction)
        {
            string host;
            int? port;
            string user;
            string password;
            string dbName;
            string dbEngine;

            switch (isProduction)
            {
                case false:
                    host = configuration["Database:Host"]
                           ?? throw new InvalidOperationException("Database host not set in appsettings.json");
                    port = configuration.GetValue<int?>("Database:Port")
                           ?? throw new InvalidOperationException("Database port not set in appsettings.json");
                    user = configuration["Database:User"]
                           ?? throw new InvalidOperationException("Database user not set in appsettings.json");
                    password = configuration["Database:Password"]
                               ?? throw new InvalidOperationException("Database password not set in appsettings.json");
                    dbName = configuration["Database:Database"]
                             ?? throw new InvalidOperationException("Database name not set in appsettings.json");
                    dbEngine = configuration["Database:Engine"]
                               ?? throw new InvalidOperationException("Database engine not specified in appsettings.json");
                    break;
                case true:
                    host = Environment.GetEnvironmentVariable("DB_HOST")
                           ?? throw new InvalidOperationException("Database host not provided in environment variables");
                    port = int.Parse(Environment.GetEnvironmentVariable("DB_PORT")
                        ?? throw new InvalidOperationException("Database port not provided in environment variables"));
                    user = Environment.GetEnvironmentVariable("DB_USER")
                           ?? throw new InvalidOperationException("Database user not provided in environment variables");
                    password = Environment.GetEnvironmentVariable("DB_PASSWORD")
                               ?? throw new InvalidOperationException("Database password not provided in environment variables");
                    dbName = Environment.GetEnvironmentVariable("DB_NAME")
                             ?? throw new InvalidOperationException("Database name not provided in environment variables");
                    dbEngine = Environment.GetEnvironmentVariable("DB_ENGINE")
                               ?? throw new InvalidOperationException("Database engine not provided in environment variables");
                    break;
            }

            if (string.IsNullOrEmpty(host) ||
                string.IsNullOrEmpty(user) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(dbName) ||
                string.IsNullOrEmpty(dbEngine))
            {
                throw new InvalidOperationException("Database information was not provided.");
            }

            if (dbEngine.Equals("Postgres", StringComparison.OrdinalIgnoreCase))
            {
                var connectionString = $"Host={host};Port={port};Database={dbName};Username={user};Password={password}";
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(connectionString));
            }
            else if (dbEngine.Equals("MySql", StringComparison.OrdinalIgnoreCase))
            {
                var connectionString = $"Server={host};Port={port};Database={dbName};Uid={user};Pwd={password}";
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseMySQL(connectionString));
            }
            else
            {
                throw new InvalidOperationException("The provided database engine is wrong or not supported.");
            }

            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        private static void ConfigureIdentity(IServiceCollection services)
        {
            services.AddCascadingAuthenticationState();
            services.AddScoped<IdentityUserAccessor>();
            services.AddScoped<IdentityRedirectManager>();
            services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
                .AddIdentityCookies();

            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
        }
    }
}