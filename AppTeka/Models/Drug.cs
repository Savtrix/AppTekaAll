using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTeka.Models
{
    public class Drug
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Range(0, 999.99)]
        public double Price { get; set; }

        public bool NeedPrescribtion { get; set; }
    }
}