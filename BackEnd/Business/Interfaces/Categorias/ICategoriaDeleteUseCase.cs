using System;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICategoriaDeleteUseCase
    {
        public Task Execute(Guid id);
    }
}
