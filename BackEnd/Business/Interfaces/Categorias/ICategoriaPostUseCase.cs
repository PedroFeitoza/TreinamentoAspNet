using Repository.Entidades;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICategoriaPostUseCase
    {
        public Task Execute(CategoriaInputModel categoria);
    }
}
