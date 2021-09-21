using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciandorCondominiosBLL.Models
{
   public class Evento
    {
        public int EventoId { get; set; }
        [Required(ErrorMessage ="O campo{0} é obrigario")]
        [StringLength(50,ErrorMessage ="Use menos carecters")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo{0} é obrigario")]
        public DateTime Date { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
