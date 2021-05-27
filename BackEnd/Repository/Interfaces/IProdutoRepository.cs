using Repository.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProdutoRepository
    {
        public Task<List<ProdutoModel>> GetAll();
        public Task<ProdutoModel> GetById(Guid id);
        public Task<List<ProdutoModel>> GetByDescription(string descricao);
        public Task Post(ProdutoModel produto);
        public Task Update(ProdutoModel produto);
        public Task Delete(Guid id);
    }
}
