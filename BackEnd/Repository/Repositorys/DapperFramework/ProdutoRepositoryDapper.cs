using Dapper;
using Microsoft.EntityFrameworkCore;
using Repository.Entidades;
using Repository.Entidades.Categoria;
using Repository.Entidades.Produto;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorys
{
    public class ProdutoRepositoryDapper : IProdutoRepository
    {
        private readonly Func<IDbConnection> _context;
        private readonly ICategoriaRepository _repository;

        public ProdutoRepositoryDapper(Func<IDbConnection> context, ICategoriaRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public async Task<List<ProdutoModel>> GetAll()
        {
            var query = @"SELECT
                        Id Id,
                        Codigo Codigo,
                        CategoriaId CategoriaId,
                        Descricao Descricao, 
                        Preco Preco,
                        UnidadeMedida UnidadeMedida
                        FROM Produtos";

            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista
                    var produtos = await connection.QueryAsync<ProdutoDapperModel>(query);
                    
                    var produtosMapeados = new List<ProdutoModel>();

                    foreach (var produto in produtos.ToList())
                    {
                        var categoria = await _repository.GetById(Guid.Parse(produto.CategoriaId));
                        // if (categoria == null)
                        //   return produtosMapeados;
                        if (categoria != null)

                        {
                            var mapeamento = new ProdutoModel()
                            {
                                Id = Guid.Parse(produto.Id),
                                Codigo = produto.Codigo,
                                Descricao = produto.Descricao,
                                Categoria = categoria,
                                CategoriaId = categoria.Id,
                                Preco = produto.Preco,
                                UnidadeMedida = produto.UnidadeMedida
                            };
                            produtosMapeados.Add(mapeamento);
                        }
                        }
                    return produtosMapeados;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //Invoke chamar a funçao

        }
        public async Task<List<ProdutoModel>> GetByDescription(string descricao)
        {
            var query = $@"SELECT
                        Id Id,
                        Codigo Codigo,
                        CategoriaId CategoriaId,
                        Descricao Descricao, 
                        Preco Preco,
                        UnidadeMedida UnidadeMedida
                        FROM Produtos
                        WHERE INSTR(Descricao, '{descricao}')";

            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista
                    var produtos = await connection.QueryAsync<ProdutoDapperModel>(query);

                    var produtosMapeados = new List<ProdutoModel>();

                    foreach (var produto in produtos.ToList())
                    {
                        var categoria = await _repository.GetById(Guid.Parse(produto.CategoriaId));
                        if (categoria == null)
                            return await GetAll();

                        var mapeamento = new ProdutoModel()
                        {
                            Id = Guid.Parse(produto.Id),
                            Codigo = produto.Codigo,
                            Descricao = produto.Descricao,
                            Categoria = categoria,
                            CategoriaId = categoria.Id,
                            Preco = produto.Preco,
                            UnidadeMedida = produto.UnidadeMedida
                        };
                        produtosMapeados.Add(mapeamento);
                    }
                    return produtosMapeados;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ProdutoModel> GetById(Guid id)
        {
            var query = $@"SELECT
                        Id Id,
                        Codigo Codigo,
                        CategoriaId CategoriaId,
                        Descricao Descricao, 
                        Preco Preco,
                        UnidadeMedida UnidadeMedida
                        FROM Produtos
                        WHERE Id='{id}'";

            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista
                    var produto = await connection.QueryFirstOrDefaultAsync<ProdutoDapperModel>(query);
                        if (produto == null)
                            return null;
               
                        var categoria = await _repository.GetById(Guid.Parse(produto.CategoriaId));
              
                        var mapeamento = new ProdutoModel()
                        {
                            Id = Guid.Parse(produto.Id),
                            Codigo = produto.Codigo,
                            Descricao = produto.Descricao,
                            Categoria = categoria,
                            CategoriaId = categoria.Id,
                            Preco = produto.Preco,
                            UnidadeMedida = produto.UnidadeMedida
                        };
           
                    return mapeamento;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task Post(ProdutoModel produto)
        {
            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista


                    var produtoMapeado = new ProdutoDapperModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Codigo = produto.Codigo,
                        CategoriaId = produto.CategoriaId.ToString(),
                        Descricao = produto.Descricao,
                        Preco = produto.Preco,
                        UnidadeMedida = produto.UnidadeMedida
                    };
                    var query = $@"INSERT INTO Produtos         
                        Values(
                        '{produtoMapeado.Id}',
                        '{produtoMapeado.Codigo}',
                        '{produtoMapeado.CategoriaId}',
                        '{produtoMapeado.Descricao}',
                        '{produtoMapeado.Preco}',
                        '{produtoMapeado.UnidadeMedida}'
                        )";
                    await connection.ExecuteAsync(query);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task Update(ProdutoModel produto)
        {
            /*
            Codigo VARCHAR(4) NOT NULL,
            CategoriaId char NOT NULL,
            Descricao VARCHAR(15) NOT NULL,
            Preco Decimal(18, 2) NOT NULL,
             UnidadeMedida VARCHAR(5) NOT NULL,
            */
            var mapeamento = new ProdutoDapperModel()
            {
                Codigo = produto.Codigo,
                CategoriaId = produto.CategoriaId.ToString(),
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                UnidadeMedida = produto.UnidadeMedida 
            };


             var query = $@"UPDATE Produtos SET
                        Codigo='{mapeamento.Codigo}',
                        CategoriaId = '{mapeamento.CategoriaId}',
                        Descricao='{mapeamento.Descricao}',
                        Preco='{mapeamento.Preco}',
                        UnidadeMedida='{mapeamento.UnidadeMedida}'
                        WHERE Id='{produto.Id}'";

            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista        
                    await connection.ExecuteAsync(query);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task Delete(Guid id)
        {
            var query = $@"DELETE FROM Produtos WHERE Id='{id}'";

            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista        
                    await connection.ExecuteAsync(query);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
