using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageSmille_Ui.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Máximo Permitido para o campo nome são 30 caracteres")]
        [MinLength(3, ErrorMessage = "Minimo Permitido para o campo nome são 30 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Máximo Permitido para o campo nome são 30 caracteres")]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public string Senha { get; set; }


        [Required]
        [DisplayName("Perfil Usuario")]
        public int PerfilUsuarioId { get; set; }

        [DisplayName("Perfil Usuario")]
        public IEnumerable<SelectListItem> ComboPerfilUsuario { get; set; }

    }
}