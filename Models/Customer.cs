using System.ComponentModel.DataAnnotations;

namespace APICustomer.Models
    
{
    public enum CustomerCategory
    {
        nouveau,
        rare,
        fréquent,
        ancien
    }
    public class Customer
    {
        [Key]
        [Display(Name = "Numéro client")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom ne peut être vide.")]
        [Display(Name = "Nom")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Le téléphone ne peut être vide")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numéro de téléphone")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Le format du numéro de téléphone est invalide.")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Le catégorie du client ne peut être vide.")]
        [Display(Name = "Catégorie client")]
        public CustomerCategory? customerCategory { get; set; }

    }
}
