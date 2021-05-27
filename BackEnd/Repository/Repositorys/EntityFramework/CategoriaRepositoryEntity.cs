using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositorys
{
    public class CategoriaRepositoryEntity : ICategoriaRepository
    {
        private readonly ApiContext _context;

        public CategoriaRepositoryEntity(ApiContext context)
        {
            _context = context;
        }
        public async Task<List<CategoriaModel>> GetAll()
        {
            await using (var db = _context)
            {
                return db.Categorias.ToList();
            }
        }

        public async Task<List<CategoriaModel>> GetByDescription(string description)
        {
            await using(var db = _context)
            {
                var categoria = db.Categorias.Where(categoria => categoria.Descricao.Contains(description)).ToList();
                return categoria;
            }
        }

        public async Task<CategoriaModel> GetById(Guid id)
        {
            await using (var db = _context)
            {
                return db.Categorias.SingleOrDefault(categoria => categoria.Id == id);
            }
        }

        public async Task Post(CategoriaModel categoria)
        {
            await using (var db = _context)
            {
                await db.AddAsync(categoria);
                await db.SaveChangesAsync();
            }
        }

        public async Task Update(CategoriaModel categoria)
        {
            await using (var db = _context)
            {  
                db.Categorias.Update(categoria);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            await using (var db = _context)
            {
                var categoria = await db.Categorias.FindAsync(id);
                
                if (categoria == null)
                    return;

                var categoriaemProduto = db.Produtos.SingleOrDefault(p => p.Categoria.Id == categoria.Id);
                if (categoriaemProduto != null)
                    throw new Exception();

                db.Categorias.Remove(categoria);
                await db.SaveChangesAsync();
            }
        }    
    }
}
