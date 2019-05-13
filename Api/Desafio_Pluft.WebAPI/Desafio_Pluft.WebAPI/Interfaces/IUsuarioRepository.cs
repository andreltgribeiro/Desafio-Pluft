using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Interfaces
{
    public interface IUsuarioRepository
    {

        /// <summary>
        /// Cadastra um usuário no banco de dados.
        /// </summary>
        /// <param name="usuario">Usuarios Object</param>
        void CadastrarUsuario(CadastrarUsuarioViewModel usuario);

        /// <summary>
        /// Cadastra um cliente no banco de dados.
        /// </summary>
        /// <param name="usuario">ClienteViewModel Object</param>
        void CadastrarCliente(ClienteViewModel clienteModel);

        /// <summary>
        /// Cadastra um lojista no banco de dados.
        /// </summary>
        /// <param name="usuario">LojistaViewModel Object</param>
        void CadastrarLojista(LojistaViewModel lojistaModel);

        /// <summary>
        /// Busca um usuário por E-mail e Senha.
        /// </summary>
        /// <param name="login">LoginViewModel Object</param>
        /// <returns>Usuarios Object</returns>
        Usuarios BuscarPorEmailESenha(LoginViewModel login);

        Usuarios BuscarPorEmail(LoginViewModel login);

        /// <summary>
        /// Retorna um Usuarios a partir da VIewModel.
        /// </summary>
        /// <param name="usuarioViewModel"></param>
        /// <returns></returns>
        Usuarios RetornarEmUsuarios(CadastrarUsuarioViewModel usuarioViewModel);

        /// <summary>
        /// Retorna um CadastrarUsuarioViewModel a partir de um AdministradorStandaloneViewModel
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        CadastrarUsuarioViewModel RetornarUsuarioViewModel(AdministradorStandaloneViewModel usuarioModel);

        /// <summary>
        /// Busca Usuário Por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Usuario</returns>
        Usuarios BuscarPorId(int Id);
    }
}
