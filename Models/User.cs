using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo obrigtório")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo é 100 caracteres")]
        [MinLength(3, ErrorMessage = "Tamanho minimo necessário é 3 caracteres")]
        public string Name { get; set; }

        [MaxLength(80, ErrorMessage = "Tamanho máximo é 80 caracteres")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Campo obrigtório")]
        [MaxLength(200, ErrorMessage = "Tamanho máximo é 200 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigtório")]
        [MinLength(6, ErrorMessage = "Tamanho minimo necessário é 6 caracteres")]
        public string Password { get; set; }
    }
}
