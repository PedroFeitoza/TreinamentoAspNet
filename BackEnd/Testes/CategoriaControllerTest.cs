using API.Controllers;
using Business;
using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    /*
   public class CategoriaControllerTest
    {
        private CategoriasController _controller;

        public CategoriaControllerTest()
        {
            _controller = new CategoriasController();
            _categoriaRepository = new CategoriaRepositoryDapper();
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsOkResult()
        {
            // Act

            var useCase = new CategoriaGetAllUseCase(); 
            var okResult = _controller.GetAll(ICategoriaGetAllUseCase);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
    }
        }*/
}
