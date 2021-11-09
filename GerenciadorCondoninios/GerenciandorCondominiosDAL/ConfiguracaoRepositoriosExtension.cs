using GerenciandorCondominiosDAL.Interfaces;
using GerenciandorCondominiosDAL.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandorCondominiosDAL
{
    public static class ConfiguracaoRepositoriosExtension
    {
        public static void ConfigurarRepositorios(this IServiceCollection service)
        {
            service.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}
