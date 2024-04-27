


namespace MicrosoftAzure.API.Extension
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection Services)
        {
          
            Services.AddTransient<IKeyVaultCore, KeyVaultCore>();
            Services.AddTransient<IKeyVaultBO, KeyVaultBO>();
            Services.AddSingleton<IConfigurationSettings, ConfigurationSettings>();
            return Services;
        }
        public static IServiceCollection AddApiDependencies(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            //Services.Configure<ConfigurationSettings>(builder.Configuration.GetSection("AzureAISearch"));
            Services.AddSwaggerGen();
            Services.AddControllers();
            Services.AddApplicationInsightsTelemetry();
            Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            return Services;
        }
    }
}
