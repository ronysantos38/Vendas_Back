using Dominio.Interface.Repositorio;
using Dominio.Interface.Services;
using Dominio.Modelo;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Servicos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        private readonly Contexto _contexto;

        public ProdutoService(IProdutoRepository produtoRepository , Contexto contexto)
        {
            _produtoRepository = produtoRepository;
            _contexto = contexto;
        }

        public void Atualizar(Produto produto)
        {
            try
            {
                //_produtoRepository.Atualizar(produto);
                _contexto.Produtos.Update(produto);
                _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Produto produto)
        {
            try
            {
                _contexto.Produtos.AddAsync(produto);
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
            _produtoRepository.CarregarDados();
        }

        public void Excluir(int Produtoid)
        {
            try
            {
                Produto produto = PesquisaPorId(Produtoid);

                _contexto.Produtos.Remove(produto);
                _contexto.SaveChanges();

                // _produtoRepository.Excluir(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                var produto = _contexto.Produtos.ToList();

                // Filial filial = _contexto.Filiais.Find(produto[0].Filialid);
            
                var query2 =(from p in _contexto.Produtos
                             join f in _contexto.Filiais on p.Filialid equals f.Filialid
                             select new ProdutoFilial
                             {
                              Produtoid = p.Produtoid,
                              Filialid = p.Filialid,
                              NomeFilial = f.Nome,
                              NomeProduto = p.Nome,
                              valor = p.valor
                             }
                             ).ToList();

                return produto;
                //_clienteRepository.Listar();  
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProdutoFilial> ListarProdutoFilial()
        {
            try
            {
                var query2 = (from p in _contexto.Produtos
                              join f in _contexto.Filiais on p.Filialid equals f.Filialid
                              select new ProdutoFilial
                              {
                                  Produtoid = p.Produtoid,
                                  Filialid = p.Filialid,
                                  NomeFilial = f.Nome,
                                  NomeProduto = p.Nome,
                                  valor = p.valor
                              }
                             ).ToList();

                return query2;                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Produto PesquisaPorId(int Produtoid)
        {
            try
            {
                return _contexto.Produtos.Find(Produtoid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ProdutoFilial PesquisaProdutoFilialId(int Produtoid)
        {
            try
            {
                var query2 = (from p in _contexto.Produtos
                              join f in _contexto.Filiais on p.Filialid equals f.Filialid
                              where p.Produtoid == Produtoid
                              select new ProdutoFilial
                              {
                                  Produtoid = p.Produtoid,
                                  Filialid = p.Filialid,
                                  NomeFilial = f.Nome,
                                  NomeProduto = p.Nome,
                                  valor = p.valor
                              }
                          ).AsQueryable();

                return query2.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }

        }        
       

        public List<Produto> ListarProdutoFilialId(int Filialid)
        {
            try
            {
                var query2 = (from p in _contexto.Produtos where p.Filialid == Filialid
                              select new Produto
                              {
                                  Filialid = p.Filialid,
                                  Nome  = p.Nome,
                                  valor = p.valor
                              }).ToList();

                return query2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Produto PesquisaPorFilialId(int Filialid)
        {
            throw new NotImplementedException();
        }
    }
}
