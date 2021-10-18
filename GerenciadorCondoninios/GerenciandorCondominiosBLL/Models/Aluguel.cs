using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciandorCondominiosBLL.Models
{
    public class Aluguel
    {
        public int AluquelId { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [Range (0, int.MaxValue,ErrorMessage ="Valor Invalido")]
        public decimal Valor { get; set; }
        [Display(Name ="Mês")]
        public int MesId { get; set; }
        public Mes Mes { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        [Range(2020, 2030, ErrorMessage = "Valor Invalido")]
        public int Ano { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }

    }
}
