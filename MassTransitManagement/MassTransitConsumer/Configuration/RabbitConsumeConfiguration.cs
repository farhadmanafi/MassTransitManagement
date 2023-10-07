namespace MassTransitConsumer.Configuration
{
    public class RabbitConsumeConfiguration
    {
        public string Connection { get; set; }
        public string QueueName { get; set; }
        public string ExchangeType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PrefetchCount { get; set; }
        public byte MaxPriority { get; set; }
        public bool ConfigureConsumeTopology { get; set; }
        public int ConcurrentMessageLimit { get; set; }
        public int RetryCount { get; set; }
        public int Interval { get; set; }
    }
}
