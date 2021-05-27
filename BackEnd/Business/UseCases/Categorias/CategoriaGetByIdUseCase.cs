using System;
using System.Threading.Tasks;
using Repository;
using Repository.Interfaces;
using Business.Interface;

namespace Business
{
    public class CategoriaGetByIdUseCase : ICategoriaGetByIdUseCase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaGetByIdUseCase(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoriaModel> Execute(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
