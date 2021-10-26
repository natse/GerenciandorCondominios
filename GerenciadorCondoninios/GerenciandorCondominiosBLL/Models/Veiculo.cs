﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciandorCondominiosBLL.Models
{
    public class Veiculo
    {
        public int VeiculoID { get; set; }
        [Required (ErrorMessage ="O campo {0} e obrigatorio")]
        [StringLength(20, ErrorMessage ="Use menos caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio")]

        public string Placa { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
