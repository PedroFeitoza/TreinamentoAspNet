using System;
using System.Threading.Tasks;
using Repository.Interfaces;
using Business.Interface;
using Repository.Entidades;

namespace Business
{
    public class ProdutoGetByIdUseCase : IProdutoGetByIdUseCase
    {
        private readonly IProdutoRepository _repository;
        public ProdutoGetByIdUseCase(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoModel> Execute(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
