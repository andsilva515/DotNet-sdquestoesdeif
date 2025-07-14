using SoQuestoesIF.App.Interfaces;

namespace SoQuestoesIF.API.Workers
{
    public class SubscriptionExpirationWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SubscriptionExpirationWorker> _logger;

        public SubscriptionExpirationWorker(
            IServiceProvider serviceProvider,
            ILogger<SubscriptionExpirationWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var expirationService = scope.ServiceProvider.GetRequiredService<ISubscriptionExpirationService>();

                    try
                    {
                        await expirationService.ExpireExpiredSubscriptionsAsync();
                        _logger.LogInformation("Expiração de assinaturas concluída com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Erro ao expirar assinaturas.");
                    }
                }

                // Espera 24 horas
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }

}
