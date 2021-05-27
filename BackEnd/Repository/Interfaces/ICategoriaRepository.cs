using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        public Task<List<CategoriaModel>> GetAll();
        public Task<CategoriaModel> GetById(Guid id);
        public Task<List<CategoriaModel>> GetByDescription(string description);
        public Task Post(CategoriaModel categoria);
        public Task Update(CategoriaModel categoria);
        public Task Delete(Guid id);
    }
}
