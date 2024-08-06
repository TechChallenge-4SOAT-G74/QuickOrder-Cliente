using System.Diagnostics.CodeAnalysis;

namespace QuickOrderCliente.Api.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCorsConfig
    {
        public static void AddCorsConfiguration(this IServiceCollection service, string myAllowSpecificOrigins)
        {
            service.AddCors(options =>
            {
                options.AddPolicy(name: myAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()
                                            .WithOrigins("http://localhost:8090");
                                  });
            });
        }
    }
}