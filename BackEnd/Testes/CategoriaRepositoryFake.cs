using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes
{
    class CategoriaRepositoryFake : ICategoriaRepository
    {
        List<CategoriaModel> listaCategorias = new List<CategoriaModel>();

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoriaModel>> GetAll()
        {
            return listaCategorias;
        }

        public Task<List<CategoriaModel>> GetByDescription(string description)
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Post(CategoriaModel categoria)
        {
            listaCategorias.Add(categoria);
        }

        public Task Update(CategoriaModel categoria)
        {
            throw new NotImplementedException();
        }
    }
}
