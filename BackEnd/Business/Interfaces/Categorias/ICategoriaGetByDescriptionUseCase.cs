using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICategoriaGetByDescriptionUseCase
    {
        public Task<List<CategoriaModel>> Execute(string description);
    }
}
