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
    public class VendaRealizadaService : IVendaRealizadaService
    {
        private readonly Contexto _contexto;

        public void Atualizar(VendaRealizada venda)
        {
            try
            {
                //_produtoRepository.Atualizar(produto);
                _contexto.VendaRealizadas.Update(venda);
                _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(VendaRealizada venda)
        {
            try
            {
                _contexto.VendaRealizadas.AddAsync(venda);
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
            throw new NotImplementedException();
        }

        public void Excluir(int VendaRealizadaid)
        {
            try
            {
                VendaRealizada vendaRealizada = PesquisaRealizadaId(VendaRealizadaid);

                _contexto.VendaRealizadas.Remove(vendaRealizada);
                _contexto.SaveChanges();

                // _produtoRepository.Excluir(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VendaRealizada> Listar()
        {
            throw new NotImplementedException();
        }

        public List<VendaRealizada> ListarVendaRealizada()
        {
            throw new NotImplementedException();
        }

        public Venda PesquisaPorId(int VendaRealizadaid)
        {
            throw new NotImplementedException();
        }

        public VendaRealizada PesquisaRealizadaId(int VendaRealizadaid)
        {
         //   throw new NotImplementedException();

            try
            {
                return _contexto.VendaRealizadas.Find(VendaRealizadaid);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}



