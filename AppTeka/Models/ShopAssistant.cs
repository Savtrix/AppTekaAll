using System.ComponentModel.DataAnnotations;

namespace AppTeka.Models
{
    public class ShopAssistant //todo
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}