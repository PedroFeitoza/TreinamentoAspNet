using System.Collections.Generic;
using System.Threading.Tasks;
using Repository;
using Repository.Interfaces;
using Business.Interface;

namespace Business
{
    public class CategoriaGetByDescriptionUseCase : ICategoriaGetByDescriptionUseCase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaGetByDescriptionUseCase(ICategoriaRepository repository)
        {
            _repository = repository;
        }
      
        public async Task<List<CategoriaModel>> Execute(string descricao)
        {   
            descricao = descricao!=null ? descricao.ToLower() : null;

            if (descricao == null)
                return await _repository.GetAll();

            return await _repository.GetByDescription(descricao);
        }
    }
}
