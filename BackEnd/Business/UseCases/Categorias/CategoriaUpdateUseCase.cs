using System;
using System.Threading.Tasks;
using Repository;
using Repository.Interfaces;
using Business.Excecoes;
using Business.Interface;
using Repository.Entidades;

namespace Business
{
    public class CategoriaUpdateUseCase : ICategoriaUpdateUseCase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaUpdateUseCase(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid id, CategoriaInputModel modelInput)
        {
            var categoria = new CategoriaModel(modelInput.Codigo, modelInput.Descricao);
            categoria.Id = id;

            if (categoria.Codigo.Length > 4 || categoria.Codigo.Length < 4)
                throw new BusinessException("Código deve possuir 4 caracteres!");

            try
            {
                await _repository.Update(categoria);
            }
            catch (BusinessException)
            { 
                throw new BusinessException("Categoria não localizada!");
            }          
        }
    }
}
