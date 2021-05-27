using System;
using System.Threading.Tasks;
using Repository.Interfaces;
using Business.Excecoes;
using Business.Interface;
using Repository.Entidades;
using Repository.Entidades.Produto;

namespace Business
{
    public class ProdutoUpdateUseCase : IProdutoUpdateUseCase
    {
        private readonly IProdutoRepository _repository;
        public ProdutoUpdateUseCase(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid id, ProdutoInputModel model)
        {
            var produto = new ProdutoModel()
            {
                Codigo = model.Codigo,
                Descricao = model.Descricao.ToLower(),
                CategoriaId = model.Categoria.Id,
                Preco = model.Preco,
                UnidadeMedida = model.UnidadeMedida
            };
            produto.Id = id;

            if (produto.Codigo.Length > 4 || produto.Codigo.Length < 4)
                throw new BusinessException("Código deve possuir 4 caracteres!");

            try
            {
                await _repository.Update(produto);
            }
            catch (Exception)
            {
                throw new BusinessException("Categoria não localizada!");
            }
        }
    }
}
