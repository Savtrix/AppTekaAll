namespace AppTeka.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DrugId { get; set; }
        public int Quantity { get; set; }
    }
}