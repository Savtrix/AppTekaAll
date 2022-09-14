using System.ComponentModel.DataAnnotations;

namespace AppTeka.Models
{
    public class Customer //todo
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}