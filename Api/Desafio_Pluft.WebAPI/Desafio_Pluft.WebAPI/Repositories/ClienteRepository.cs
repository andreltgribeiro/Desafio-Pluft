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
    public class ClienteRepository : IClienteRepository
    {

        
        public Clientes BuscarClientePorIdUsuario(int idUsuario)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Clientes.Find(idUsuario);
            }
        }


        
        public List<Clientes> ListarTodos()
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Clientes.Include(x => x.IdUsuarioNavigation).ToList();
            }
        }


        public ClienteViewModel RetornarClienteViewModel(ClienteStandaloneViewModel ClienteModel)
        {
            ClienteViewModel cliente = new ClienteViewModel()
            {
                UsuarioViewModel = new CadastrarUsuarioViewModel()
                {
                    Nome = ClienteModel.Nome,
                    Email = ClienteModel.Email,
                    Senha = ClienteModel.Senha,
                    Telefone = ClienteModel.Telefone,
                    DataCriacao = DateTime.Now,
                    IdTipoUsuario = ClienteModel.IdTipoUsuario,
                    IdEstabelecimento = ClienteModel.IdEstabelecimento
                },

                Cliente = new Clientes()
                {
                    IdUsuario = ClienteModel.IdUsuario,
                    Rg = ClienteModel.Rg,
                    Cpf = ClienteModel.Cpf,
                    DataNascimento = ClienteModel.DataNascimento,
                    Endereco = ClienteModel.Endereco
                    
                }
            };

            return cliente;
        }
    }
}
