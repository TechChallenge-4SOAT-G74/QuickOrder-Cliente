using Microsoft.EntityFrameworkCore;
using QuickOrderCliente.Domain.Entities;

namespace QuickOrderCliente.PostgresDB.Core
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
      where TEntity : EntityBase
    {
    }
}
