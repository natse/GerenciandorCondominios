using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandorCondominiosBLL.Models
{
    public class Servico
    {
        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public decimal valor { get; set; }
        public StatusServico Status { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public ICollection<ServicoPredio> ServicoPredios { get; set; }
    }
    public enum StatusServico
    {
        Pendente, Recusado,Aceito
    }
}
