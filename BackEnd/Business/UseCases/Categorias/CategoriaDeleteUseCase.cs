using System;
using System.Threading.Tasks;
using Repository.Interfaces;
using Business.Excecoes;
using Business.Interface;

namespace Business
{
    public class CategoriaDeleteUseCase : ICategoriaDeleteUseCase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaDeleteUseCase(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(Guid id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (Exception)
            {
                throw new BusinessException("Categoria possui produto cadastrado");
            }
        }
    }
}
