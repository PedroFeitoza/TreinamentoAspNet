using System;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IProdutoDeleteUseCase
    {
        public Task Execute(Guid id);
    }
}
