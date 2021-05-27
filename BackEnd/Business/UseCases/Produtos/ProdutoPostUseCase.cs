using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repository;
using Repository.Interfaces;
using Repository.Repositorys;
using Business.Excecoes;
using Business.Interface;
using Repository.Entidades;
using Repository.Entidades.Produto;


namespace Business
{
    public class ProdutoPostUseCase : IProdutoPostUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        public ProdutoPostUseCase(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task Execute(ProdutoInputModel model)
        { 
            if (model.Codigo.Length > 4 || model.Codigo.Length < 4)
                throw new BusinessException("Código deve possuir 4 caracteres!");

           var categoria = (model.Categoria != null) 
                ? await _categoriaRepository.GetById(model.Categoria.Id)
                : null;

            if (categoria == null)
               throw new BusinessException("Categoria Obrigatória");

            var produto = new ProdutoModel()
            {
                Codigo = model.Codigo,
                Descricao = model.Descricao.ToLower(),
                CategoriaId = model.Categoria.Id,
                Preco = model.Preco,
                UnidadeMedida = model.UnidadeMedida
            };  

            await _produtoRepository.Post(produto);  
        }
    }
}
