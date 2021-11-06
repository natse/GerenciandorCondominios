using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "O Campo {0} e obrigatorio")]
        [StringLength(40, ErrorMessage = "Use menos caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo {0} e obrigatorio")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O Campo {0} e obrigatorio")]
        public string Telefone { get; set; }

        public string Foto { get; set; }
        [Required(ErrorMessage = "O Campo {0} e obrigatorio")]
        [StringLength(40, ErrorMessage = "Use menos caracteres")]
        [EmailAddress (ErrorMessage ="Email invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Campo {0} e obrigatorio")]
        [StringLength(40, ErrorMessage = "Use menos caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O Campo {0} e obrigatorio")]
        [StringLength(40, ErrorMessage = "Use menos caracteres")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirme sua senha")]
        [Compare("senha", ErrorMessage ="As senhas não conferes")]
        public string SenhaConfirnada { get; set; }
    }
}
