using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(1, 99999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Preço")]
        public decimal Price { get; set; }
    }
}
