using QuickOrderCliente.Domain.Entities;

namespace QuickOrderCliente.Domain.Adapters
{
    public interface IClienteRepository : IBaseRepository, IRepository<Cliente>
    {
    }
}
