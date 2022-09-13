using System.ComponentModel.DataAnnotations;

namespace AppTeka.Models
{
    public class Prescribtion
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime IssueDate { get; set; }
        
        public DateTime ExpiryDate { get; set; }
    }
}