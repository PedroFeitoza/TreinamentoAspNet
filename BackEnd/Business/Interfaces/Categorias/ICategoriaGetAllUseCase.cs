using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICategoriaGetAllUseCase
    { 
        public Task<List<CategoriaModel>> Execute();
    }
}
