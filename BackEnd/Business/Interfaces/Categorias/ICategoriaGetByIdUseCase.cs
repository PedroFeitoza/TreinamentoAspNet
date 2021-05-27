using Repository;
using System;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICategoriaGetByIdUseCase
    {
        public Task<CategoriaModel> Execute(Guid id);
    }
}
