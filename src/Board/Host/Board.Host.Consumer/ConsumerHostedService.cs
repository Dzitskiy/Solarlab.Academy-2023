namespace Board.Host.Consumer
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IRabbitMqConsumer _consumerService;

        public ConsumerHostedService(IRabbitMqConsumer consumerService)
        {
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           await _consumerService.Consume();
        }
    }
}
