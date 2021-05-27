using Repository.Entidades;
using System;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICategoriaUpdateUseCase
    {
        public Task Execute(Guid id, CategoriaInputModel categoria);
    }
}
