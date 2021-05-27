using System.Collections.Generic;
using System.Threading.Tasks;
using Repository;
using Repository.Interfaces;
using Business.Interface;

namespace Business
{
    public class CategoriaGetAllUseCase : ICategoriaGetAllUseCase
    {
        private readonly ICategoriaRepository _repository;
  
        public CategoriaGetAllUseCase(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<CategoriaModel>> Execute()
        {
            return await _repository.GetAll();
        }
    }
}
