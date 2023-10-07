namespace MassTransitContract.Models
{
    public class MassTransitModel
    {
        public Type ModelType { get; set; }
        public DateTime PublishTime { get; set; }
        public string Body { get; set; }
    }
}