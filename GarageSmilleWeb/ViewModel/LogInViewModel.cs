using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GarageSmille_Ui.ViewModel
{
    public class LogInViewModel
    {
        [Required]
        [DisplayName("E-Mail")]
        [MaxLength(30, ErrorMessage = "Máximo de permitido para o emial são 30 caracteres")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [DisplayName("Esqueci minha senha.")]
        public bool RememberMe { get; set; }

        public int PerfilUsuarioId { get; set; }
        public IEnumerable<SelectListItem> PerfilUsuario { get; set; }
    }
}