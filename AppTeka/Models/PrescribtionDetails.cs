namespace AppTeka.Models
{
    public class PrescribtionDetails
    {
        public int Id { get; set; }
        public int PrescribtionId { get; set; }
        public int DrugId { get; set; }
        public int Quantity { get; set; }
    }
}