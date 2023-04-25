namespace Board.Host.Consumer
{
    public interface IRabbitMqConsumer
    {
        Task Consume();
    }
}
