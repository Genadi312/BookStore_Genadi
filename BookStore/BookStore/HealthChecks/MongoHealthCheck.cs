using BookStore.Models.Configurations;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.HealthChecks
{
    public class MongoHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _configuration;
        private readonly IOptionsMonitor<MongoDbConfiguration> _mongoConfig;
        public MongoHealthCheck(IConfiguration configuration, IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            _configuration = configuration;
            _mongoConfig = mongoConfig;
        }

        async Task<HealthCheckResult> IHealthCheck.CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
        {
            try
            {
                var client = new MongoClient(_mongoConfig.CurrentValue.ConnectionString);
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("MongoDB connection unhealthy");
            }
            return HealthCheckResult.Healthy("MongoDB connection iz okay");
        }

    }
}
