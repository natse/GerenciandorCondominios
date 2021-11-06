﻿using GerenciadorCondominios.ViewModels;
using GerenciandorCondominiosBLL.Models;
using GerenciandorCondominiosDAL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GerenciadorCondominios.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UsuariosController( IUsuarioRepositorio usuarioRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel model, IFormFile foto)
        {
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    string diretorioPasta = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens");
                    string nomefoto = Guid.NewGuid().ToString() + foto.FileName;
                    using (FileStream fileStream = new FileStream(Path.Combine(diretorioPasta, nomefoto), FileMode.Create))
                    {
                        await foto.CopyToAsync(fileStream);
                        model.Foto = "~/Imagens/" + nomefoto;

                    }

                    Usuario usuario = new Usuario();
                    IdentityResult usuarioCriado;

                    if (_usuarioRepositorio.VerificarSeExisteRegistro() == 0)
                    {
                        usuario.UserName = model.Nome;
                        usuario.CPF = model.Cpf;
                        usuario.Foto = model.Foto;
                        usuario.Email = model.Email;
                        usuario.PhoneNumber = model.Telefone;
                        usuario.PrimeiroAcesso = false;
                        usuario.Status = StatusConta.Aprovado;
                        usuarioCriado = await _usuarioRepositorio.CriarUsuario(usuario, model.Senha);

                        if (usuarioCriado.Succeeded)
                        {
                            await _usuarioRepositorio.IncluirUsuarioEmFuncao(usuario, "ADministrador");
                            await _usuarioRepositorio.LogarUsuario(usuario, false);
                            return RedirectToAction("Index", "Usuarios");
                        }

                        usuario.UserName = model.Nome;
                        usuario.CPF = model.Cpf;
                        usuario.Foto = model.Foto;
                        usuario.Email = model.Email;
                        usuario.PhoneNumber = model.Telefone;
                        usuario.PrimeiroAcesso = true;
                        usuario.Status = StatusConta.Analisando;
                        usuarioCriado = await _usuarioRepositorio.CriarUsuario(usuario, model.Senha);

                        if (usuarioCriado.Succeeded)
                        {
                            return View("Analise", usuario.UserName);
                        }
                        else
                        {
                            foreach (IdentityError error in usuarioCriado.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                            return View(model);
                        }
                    }
                    
                }
                 
            }
            return View( model);
        }
        public IActionResult Analise(string nome)
        {
            return View(nome);
        }
    }
}
