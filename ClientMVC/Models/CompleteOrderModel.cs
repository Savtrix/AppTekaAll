namespace ClientMVC.Models
{
    public class CompleteOrderModel
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public string CustomerName { get; set; }
        public string ShopAssistantName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public List<OrderItemModel>? OrderElements { get; set; }
    }
}