using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;
using UltimateCore.Entities;
using UltimateRepository.Data;

namespace UltimateAPI.Extensions
{
    public class JsonSeederService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<JsonSeederService> _logger;

        public JsonSeederService(IServiceProvider serviceProvider, ILogger<JsonSeederService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<Context>();

                _logger.LogInformation("Seeding data from JSON...");

                // if an entity refrences to another entity seed the refrensed firstly and after the refrencing entity after that
                await SeedFromJsonAsync<ProductBrand>(dbContext, _logger, "C:\\Users\\ST\\source\\repos\\UltimateAPISolution\\UltimateRepository\\Data\\DataSeed\\brands.json");
                await SeedFromJsonAsync<ProductCategory>(dbContext, _logger, "C:\\Users\\ST\\source\\repos\\UltimateAPISolution\\UltimateRepository\\Data\\DataSeed\\categories.json");
                await SeedFromJsonAsync<Product>(dbContext, _logger, "C:\\Users\\ST\\source\\repos\\UltimateAPISolution\\UltimateRepository\\Data\\DataSeed\\products.json");

                _logger.LogInformation("Seeding completed.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private async Task SeedFromJsonAsync<T>(Context dbContext, ILogger logger, string filePath) where T : class
        {
            if (! await dbContext.Set<T>().AnyAsync())// check if the table has seeding data before or empty
            {
                if (File.Exists(filePath))
                {
                    var jsonData = await File.ReadAllTextAsync(filePath);
                    var entities = JsonSerializer.Deserialize<List<T>>(jsonData);

                    if (entities != null && !await dbContext.Set<T>().AnyAsync())
                    {
                        await dbContext.Set<T>().AddRangeAsync(entities);
                        await dbContext.SaveChangesAsync();
                        logger.LogInformation($"Seeded {entities.Count} records into {typeof(T).Name} table.");
                    }
                    else
                    {
                        logger.LogInformation($"{typeof(T).Name} already has data. Skipping seeding.");
                    }
                }
                else
                {
                    logger.LogWarning($"File {filePath} not found. Skipping seeding.");
                } 
            }
        }
    }
}
