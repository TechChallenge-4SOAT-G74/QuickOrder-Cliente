using QuickOrderCliente.Domain.Adapters;
using QuickOrderCliente.Domain.Entities;
using QuickOrderCliente.PostgresDB.Core;

namespace QuickOrderCliente.PostgresDB.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationContext context) :
            base(context)
        {
        }
    }
}
