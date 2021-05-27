using Business;
using Business.Excecoes;
using Moq;
using Repository;
using Repository.Entidades;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    public class CategoriaUseCasesTest
    {
        [Fact]
        public async void DadaCategoriaValidaDeveIncluirNoBD()
        {
            //arrange
            var model = new CategoriaInputModel() { Codigo = "1234", Descricao = "teste" };
            var repo = new CategoriaRepositoryFake();
            var useCase = new CategoriaPostUseCase (repo);

            //act
            await useCase.Execute(model);

            //assert
            var listaCategorias = repo.GetAll();
            Assert.NotNull(listaCategorias);
        }

        [Fact]
        public async void DadaCategoriaInvalidaDeveLancarExcessao()
        {
            //arrange
            var model = new CategoriaInputModel() { Codigo = "12345", Descricao = "teste" };
            var repo = new CategoriaRepositoryFake();
            var useCase = new CategoriaPostUseCase(repo);
            string excessao = null;

            //act
            try
            {
                await useCase.Execute(model);
            }
            catch (BusinessException e)
            {
                excessao = e.Message;
            }

            //assert
            var listaCategorias = repo.GetAll();
            Assert.True(listaCategorias.Result.Count == 0);
            Assert.NotNull(excessao);
        }
/*
        [Fact]
        public async void MockDadaCategoriaInvalidaDeveLancarExcessao()
        {
            //arrange
            var model = new CategoriaInputModel() { Codigo = "1235", Descricao = "teste" };
            var categorias = new Task<List<CategoriaModel>>()
            {
                
            };
            var mock = new Mock<ICategoriaRepository>();

           await mock.Setup(r => r.GetAll())
                .Returns(categorias);

            var repo = mock.Object;
            var useCase = new CategoriaPostUseCase(repo);
            string excessao = null;

            //act
            try
            {
                await useCase.Execute(model); //SUT >> CadastraTarefaHandlerExecute
            }
            catch (BusinessException e)
            {
                excessao = e.Message;
            }

            //assert
            var listaCategorias = repo.GetAll();
            Assert.True(listaCategorias == null);
            Assert.NotNull(excessao);
        }*/
    }
}
