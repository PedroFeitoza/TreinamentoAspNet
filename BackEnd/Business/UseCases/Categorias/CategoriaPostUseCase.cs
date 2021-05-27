using System.Threading.Tasks;
using Repository;
using Repository.Interfaces;
using Business.Excecoes;
using Business.Interface;
using Repository.Entidades;

namespace Business
{
    public class CategoriaPostUseCase : ICategoriaPostUseCase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaPostUseCase(ICategoriaRepository repository)
        {
            _repository = repository;
        }
     
        public async Task Execute(CategoriaInputModel model)
        {
            var categoria = new CategoriaModel(model.Codigo, model.Descricao.ToLower()); 

            if (categoria.Codigo.Length > 4 || categoria.Codigo.Length < 4)
                throw new BusinessException("Código deve possuir 4 caracteres!");
              
            await _repository.Post(categoria);  
        }
    }
}
