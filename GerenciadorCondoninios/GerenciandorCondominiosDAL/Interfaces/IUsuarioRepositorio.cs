using GerenciandorCondominiosBLL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerenciandorCondominiosDAL.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioGenerico<Usuario>
    {
        int VerificarSeExisteRegistro();
        Task LogarUsuario(Usuario usuario, bool lembrar);
        Task<IdentityResult> CriarUsuario(Usuario usuario, string senha);
        Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao);
    }
}
