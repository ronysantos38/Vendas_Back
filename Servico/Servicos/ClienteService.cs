using Dominio.Interface.Repositorio;
using Dominio.Interface.Services;
using Dominio.Modelo;
using Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        private readonly Contexto _contexto;


        public ClienteService(IClienteRepository clienteRepository,Contexto contexto)
        {
            _clienteRepository = clienteRepository;
            _contexto = contexto;
        }

        public void Atualizar(Cliente cliente)
        {
            try
            {
                _contexto.Clientes.Update(cliente);
                _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        public void Cadastrar(Cliente cliente)
        {
            try
            {
                _contexto.Clientes.AddAsync(cliente);
                _contexto.SaveChanges();
                //_clienteRepository.Cadastrar(cliente);
            }
            catch (Exception ex)
            {
              //  await _contexto.Pessoas.AddAsync(pessoa);
              //  await _contexto.SaveChangesAsync();
                throw ex;
            }
        }

        public void CarregarDados()
        {
           _clienteRepository.CarregarDados();  
        }

        public void Excluir(int Clienteid)
        {
            try
            {
                Cliente cliente = PesquisaPorId(Clienteid);

                _contexto.Clientes.Remove(cliente);
                _contexto.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cliente> Listar()
        {
            try
            {
                var cli = _contexto.Clientes.ToList();

                return cli;
                //_clienteRepository.Listar();  
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Cliente PesquisaPorId(int Clienteid)
        {
            try
            {
                return _contexto.Clientes.Find(Clienteid);              
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
