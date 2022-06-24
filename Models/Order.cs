namespace AppTeka.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public int CustomerId { get; set; }
        public int? ShopAssistantId { get; set; }
        public int? PrescribtionId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}