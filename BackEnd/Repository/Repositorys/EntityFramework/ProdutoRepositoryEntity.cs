using Microsoft.EntityFrameworkCore;
using Repository.Entidades;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositorys
{
    public class ProdutoRepositoryEntity : IProdutoRepository
    {
        private readonly ApiContext _context;
        public ProdutoRepositoryEntity(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<ProdutoModel>> GetAll()
        {
            await using (var db = _context)
            {
                return await db.Produtos
                    .Include(referencia => referencia.Categoria)
                    .ToListAsync();
            }
        }

        public async Task<List<ProdutoModel>> GetByDescription(string descricao)
        {
            await using (var db = _context)
            {
                var produtos = await db.Produtos
                    .Where(produto => produto.Descricao.Contains(descricao))
                    .Include(referencia => referencia.Categoria)
                    .ToListAsync();
                return produtos;
            }
        }

        public async Task<ProdutoModel> GetById(Guid id)
        {
            await using (var db = _context)
            {
                var produto = await db.Produtos
                    .Include(referencia => referencia.Categoria)
                    .FirstOrDefaultAsync(produtoId => produtoId.Id == id);
                return produto;
            }
        }

        public async Task Post(ProdutoModel produto)
        {
            await using (var db = _context)
            {
                await db.Produtos.AddAsync(produto);
                await db.SaveChangesAsync();
            }
        }

        public async Task Update(ProdutoModel produtoModel)
        {
            await using (var db = _context)
            {
                var produto = await db.Produtos.SingleOrDefaultAsync(p => p.Id == produtoModel.Id);
                produto.Codigo = produtoModel.Codigo;
                produto.Descricao = produtoModel.Descricao;
                produto.CategoriaId = produtoModel.CategoriaId;
                produto.Preco = produtoModel.Preco;
                produto.UnidadeMedida = produtoModel.UnidadeMedida;
                await db.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            await using (var db = _context)
            {
                var produto = await db.Produtos.FirstOrDefaultAsync(produtoId => produtoId.Id == id); 
                db.Produtos.Remove(produto);
                await db.SaveChangesAsync();
            }
        }

    }
}
