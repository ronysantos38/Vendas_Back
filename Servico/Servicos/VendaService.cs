using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dominio.Interface.Services;
using Dominio.Modelo;
using Infra.Contexto;
using Dominio.Interface.Repositorio;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO.Pipelines;


namespace Servico.Servicos
{
    public class VendaService : IVendaService
    {
        private readonly Contexto _contexto;
        //VendaRealizadaService
        private readonly IVendaRealizadaService _vendaRealizadaService;

        public VendaService(Contexto contexto, IVendaRealizadaService vendaRealizadaService)
        {
            _vendaRealizadaService = vendaRealizadaService;
            //  _produtoRepository = produtoRepository;
            _contexto = contexto;
        }

        public void Atualizar(Venda venda)
        {
            try
            {
                //_produtoRepository.Atualizar(produto);
                _contexto.Vendas.Update(venda);
                _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Venda venda)
        {
            try
            {
                venda.statusVenda = 'S';
                _contexto.Vendas.AddAsync(venda);
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


        public void SalvarVendaRealizada(VendaRealizada vendaRealizada)
        {
            try
            {
                _contexto.VendaRealizadas.AddAsync(vendaRealizada);
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


        public void CadastrarVendaRealizada(List<VendaEfetuada> vendaEfetuada)
        {

            Venda venda = new Venda();           

            VendaRealizada vendaEfet = new VendaRealizada();

            int val = 0;

            for (int i = 0; i < vendaEfetuada.Count; i++)
            {
                if (i == 0)
                {
                    venda.Clienteid = vendaEfetuada[i].clienteid;
                    venda.FilialId  = vendaEfetuada[i].filialid;
                    venda.dataVenda = vendaEfetuada[i].dataVenda;
                    Cadastrar(venda);
                    val = _contexto.Vendas.Max(d => d.Vendaid);
                }

                vendaEfet = new VendaRealizada();

                vendaEfet.Vendaid = val;
                vendaEfet.Produtoid = vendaEfetuada[i].produtoid;
                vendaEfet.desconto = vendaEfetuada[i].desconto;
                vendaEfet.dataVenda = vendaEfetuada[i].dataVenda;
                vendaEfet.qtde = vendaEfetuada[i].qtde;

                SalvarVendaRealizada(vendaEfet);
            }

            
        }

        public void CarregarDados()
        {
            throw new NotImplementedException();
        }

        public void Excluir(int Vendaid)
        {
            try
            {
                Venda venda = PesquisaPorId(Vendaid);

                _contexto.Vendas.Remove(venda);
                _contexto.SaveChanges();

                // _produtoRepository.Excluir(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Venda> Listar()
        {
            throw new NotImplementedException();
        }

        public List<ProdutoFilial> ListarVendaProduto()
        {
            throw new NotImplementedException();
        }

        public List<VendaGerada> ListarVendaRealizada()
        {
            try
            {
                var query2 = (from v in _contexto.Vendas
                              join vr in _contexto.VendaRealizadas on v.Vendaid equals vr.Vendaid
                              join c in _contexto.Clientes on v.Clienteid equals c.Clienteid
                              join p in _contexto.Produtos on vr.Produtoid equals p.Produtoid
                              join f in _contexto.Filiais on v.FilialId equals f.Filialid
                              select new VendaGerada
                              {
                                  Vendaid = v.Vendaid,
                                  Produtoid = p.Produtoid,
                                  Filialid = f.Filialid,
                                  Clienteid = c.Clienteid,
                                  NomeCliente = c.Nome,
                                  NomeProduto = p.Nome,
                                  NomeFilial = f.Nome,
                                  dataVenda = vr.dataVenda,
                                  valor = p.valor,
                                  desconto  = vr.desconto,
                                  qtde = vr.qtde,
                                  total = (p.valor * vr.qtde) - vr.desconto
                              }
                             ).ToList();

                return query2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Venda PesquisaPorId(int Vendaid)
        {
            try
            {
                return _contexto.Vendas.Find(Vendaid);
            }
            catch (Exception)
            {

                throw;
            }
        }       

        public List<VendaGerada> PesquisaVendaVendaId(int Vendaid)
        {
            try
            {
                var query2 = (from v in _contexto.Vendas
                              join vr in _contexto.VendaRealizadas on v.Vendaid equals vr.Vendaid
                              join c in _contexto.Clientes on v.Clienteid equals c.Clienteid
                              join p in _contexto.Produtos on vr.Produtoid equals p.Produtoid
                              join f in _contexto.Filiais on v.FilialId equals f.Filialid
                              where v.Vendaid == Vendaid
                              select new VendaGerada
                              {
                                  Vendaid = v.Vendaid,
                                  Produtoid = p.Produtoid,
                                  Filialid = f.Filialid,
                                  Clienteid = c.Clienteid,
                                  NomeCliente = c.Nome,
                                  NomeProduto = p.Nome,
                                  NomeFilial = f.Nome,
                                  dataVenda = vr.dataVenda,
                                  valor = p.valor,
                                  desconto = vr.desconto,
                                  qtde = vr.qtde,
                                  total = (p.valor * vr.qtde) - vr.desconto
                              }
                             ).ToList();



                return query2;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public List<VendaGerada> ListarTipVenda(string pTipo)
        {
            try
            {
                var query2 = (from v in _contexto.Vendas
                              join vr in _contexto.VendaRealizadas on v.Vendaid equals vr.Vendaid
                              join c in _contexto.Clientes on v.Clienteid equals c.Clienteid
                              join p in _contexto.Produtos on vr.Produtoid equals p.Produtoid
                              join f in _contexto.Filiais on v.FilialId equals f.Filialid
                              where v.statusVenda == char.Parse(pTipo)
                              select new VendaGerada
                              {
                                  Vendaid = v.Vendaid,
                                  Produtoid = p.Produtoid,
                                  Filialid = f.Filialid,
                                  Clienteid = c.Clienteid,
                                  NomeCliente = c.Nome,
                                  NomeProduto = p.Nome,
                                  NomeFilial = f.Nome,
                                  dataVenda = vr.dataVenda,
                                  valor = p.valor,
                                  desconto = vr.desconto,
                                  qtde = vr.qtde,
                                  total = (p.valor * vr.qtde) - vr.desconto
                              }
                             ).ToList();

                return query2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<VendaListada> ListarVenda()
        {
            try
            {
                var query2 = (from v in _contexto.Vendas                            
                              join c in _contexto.Clientes on v.Clienteid equals c.Clienteid                              
                              join f in _contexto.Filiais on v.FilialId equals f.Filialid                              
                              select new VendaListada
                              {
                                  Vendaid = v.Vendaid,
                                  FilialId = f.Filialid,
                                  Clienteid = c.Clienteid,
                                  NomeFilial = f.Nome,
                                  NomeCliente = c.Nome,
                                  statusVenda = v.statusVenda,                                 
                                  dataVenda = v.dataVenda
                              }
                             ).ToList();

                return query2;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void CancelarVenda(int Vendaid)
        {            
            Venda venda = PesquisaPorId(Vendaid);
            venda.statusVenda = 'C';
            Atualizar(venda);            
        }

        public void ModificarVenda(VendaEfetuada vendaEfetuada)
        {
            Venda venda = new Venda();

            VendaRealizada vendaEfet = new VendaRealizada();                    

                venda.Clienteid = vendaEfetuada.clienteid;
                venda.FilialId = vendaEfetuada.filialid;
                venda.dataVenda = vendaEfetuada.dataVenda;
                venda.Vendaid   = vendaEfetuada.vendaid;
                venda.statusVenda = 'M';
                Atualizar(venda);                    

                vendaEfet = new VendaRealizada();

                vendaEfet.Vendaid = vendaEfetuada.vendaid;
                vendaEfet.Produtoid = vendaEfetuada.produtoid;
                vendaEfet.desconto = vendaEfetuada.desconto;
                vendaEfet.dataVenda = vendaEfetuada.dataVenda;
                vendaEfet.qtde = vendaEfetuada.qtde;
                vendaEfet.VendaRealizadaid = vendaEfetuada.vendaEfetuadaid; 

                AtualizarVendaRealizada(vendaEfet);
            

        }

        public void AtualizarVendaRealizada(VendaRealizada vendaRealizada)
        {
            try
            {                
                _contexto.VendaRealizadas.Update(vendaRealizada);
                _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VendaListadaGeral PesquisaVendaVendaItem(int Vendaid, int produtoid)
        {
            try
            {
                var query2 = (from v in _contexto.Vendas
                              join vr in _contexto.VendaRealizadas on v.Vendaid equals vr.Vendaid
                              join c in _contexto.Clientes on v.Clienteid equals c.Clienteid
                              join p in _contexto.Produtos on vr.Produtoid equals p.Produtoid
                              join f in _contexto.Filiais on v.FilialId equals f.Filialid
                              where (v.Vendaid == Vendaid) && (p.Produtoid == produtoid)
                              select new VendaListadaGeral
                              {
                                  VendaGeradaid = vr.VendaRealizadaid,
                                  Vendaid = v.Vendaid,
                                  Produtoid = p.Produtoid,
                                  Filialid = f.Filialid,
                                  Clienteid = c.Clienteid,
                                  NomeCliente = c.Nome,
                                  NomeProduto = p.Nome,
                                  NomeFilial = f.Nome,
                                  dataVenda = vr.dataVenda,
                                  valor = p.valor,
                                  desconto = vr.desconto,
                                  qtde = vr.qtde,
                                  total = (p.valor * vr.qtde) - vr.desconto
                              }
                             ).AsQueryable();



                //return (VendaGerada)query2;
                return query2.FirstOrDefault();    

                //GetValueOrDefault
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void ModificarVendaRealizada(List<VendaEfetuada> vendaEfetuada)
        {
            Venda venda = new Venda();

            VendaRealizada vendaEfet = new VendaRealizada();

            int val = 0;

            for (int i = 0; i < vendaEfetuada.Count; i++)
            {
                vendaEfet = new VendaRealizada();

                vendaEfet.Vendaid = val;
                vendaEfet.Produtoid = vendaEfetuada[i].produtoid;
                vendaEfet.desconto = vendaEfetuada[i].desconto;
                vendaEfet.dataVenda = vendaEfetuada[i].dataVenda;
                vendaEfet.qtde = vendaEfetuada[i].qtde;

                if (i == 0)
                {
                    venda.Clienteid = vendaEfetuada[i].clienteid;
                    venda.FilialId = vendaEfetuada[i].filialid;
                    venda.dataVenda = vendaEfetuada[i].dataVenda;
                    venda.Vendaid = vendaEfetuada[i].vendaid;
                    venda.statusVenda = 'M';
                    Atualizar(venda);
                }                

                VendaRealizada vendaRealizada = _vendaRealizadaService.PesquisaRealizadaId(vendaEfetuada[i].vendaEfetuadaid);

                if (vendaRealizada == null)
                {
                    SalvarVendaRealizada(vendaEfet);
                }
                else
                {
                    AtualizarVendaRealizada(vendaEfet);
                }

            }
                 
        }
    }
}
