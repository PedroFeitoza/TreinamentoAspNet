using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Interfaces;
using Business.Interface;
using Repository.Entidades;

namespace Business
{
    public class ProdutoGetByDescriptionUseCase : IProdutoGetByDescriptionUseCase
    {
        private readonly IProdutoRepository _repository;
        public ProdutoGetByDescriptionUseCase(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProdutoModel>> Execute(string descricao)
        {
            descricao = descricao != null ? descricao.ToLower() : null;

            if (descricao == null)
                return await _repository.GetAll();

            return await _repository.GetByDescription(descricao);
        }
    }
}
