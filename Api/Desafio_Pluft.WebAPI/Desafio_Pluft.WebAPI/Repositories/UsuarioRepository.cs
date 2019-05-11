using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.Interfaces;
using Desafio_Pluft.WebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                // terá tanto os usuários, quanto os tipos deles.
                // Retorna um usuário que coincida com o e-mail e senha.
                return ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
            }
        }

        public Usuarios BuscarPorEmail(LoginViewModel login)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                // terá tanto os usuários, quanto os tipos deles.
                // Retorna um usuário que coincida com o e-mail e senha.
                return ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == login.Email);
            }
        }

        public void CadastrarUsuario(CadastrarUsuarioViewModel usuario) // O mesmo que cadastrar um administrador, tb serve para cadastrar um administrador.
        {
            Usuarios usuarioTemp;



            // Defini os valores do objeto Usuario
            usuarioTemp = new Usuarios
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataCriacao = DateTime.Now,
                Telefone = usuario.Telefone,
                IdTipoUsuario = usuario.IdTipoUsuario,
                IdEstabelecimento = usuario.IdEstabelecimento
            };


            usuarioTemp = new Usuarios
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone,
                DataCriacao = DateTime.Now,
                IdTipoUsuario = usuario.IdTipoUsuario,
                IdEstabelecimento = usuario.IdEstabelecimento
            };




            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                ctx.Usuarios.Add(usuarioTemp);
                ctx.SaveChanges();
            }

        }

        public void CadastrarLojista(LojistaViewModel lojistaModel)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                CadastrarUsuario(lojistaModel.UsuarioViewModel);

                Usuarios usuario = ctx.Usuarios.Last();
                lojistaModel.Lojista.IdUsuario = usuario.Id;
                ctx.Lojistas.Add(lojistaModel.Lojista);

                // Salva as alterações no BD.
                ctx.SaveChanges();
            }
        }

        public void CadastrarCliente(ClienteViewModel clienteModel)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                CadastrarUsuario(clienteModel.UsuarioViewModel);

                Usuarios usuario = ctx.Usuarios.Last(); 
                clienteModel.Cliente.IdUsuario = usuario.Id;
                ctx.Clientes.Add(clienteModel.Cliente);
                ctx.SaveChanges();
            }
        }

        public Usuarios RetornarEmUsuarios(CadastrarUsuarioViewModel usuarioViewModel)
        {
            // Defini os valores do objeto Usuario
            Usuarios usuarioTemp = new Usuarios
            {
                Nome = usuarioViewModel.Nome,
                Email = usuarioViewModel.Email,
                Senha = usuarioViewModel.Senha,
                Telefone = usuarioViewModel.Telefone,
                DataCriacao = DateTime.Now,
                IdEstabelecimento = usuarioViewModel.IdEstabelecimento
            };

            return usuarioTemp;
        }

        public CadastrarUsuarioViewModel RetornarUsuarioViewModel(AdministradorStandaloneViewModel usuarioModel)
        {
            CadastrarUsuarioViewModel usuario = new CadastrarUsuarioViewModel()
            {
                Nome = usuarioModel.Nome,
                Email = usuarioModel.Email,
                Senha = usuarioModel.Senha,
                Telefone = usuarioModel.Telefone,
                DataCriacao = DateTime.Now,
                IdTipoUsuario = usuarioModel.IdTipoUsuario,
                IdEstabelecimento = usuarioModel.IdEstabelecimento
            };

            return usuario;
        }

        public Usuarios BuscarPorId(int Id)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Usuarios.Find(Id);
            }
        }
    }
}
