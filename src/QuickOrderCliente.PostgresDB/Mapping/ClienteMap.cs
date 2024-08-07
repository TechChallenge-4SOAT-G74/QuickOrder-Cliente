using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrderCliente.Domain.Entities;
using QuickOrderCliente.PostgresDB.Core;

namespace QuickOrderCliente.PostgresDB.Mapping
{
    public class ClienteMap : IEntityMap<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.OwnsOne(x => x.Endereco, e =>
            {
                e.Property(x => x.Rua)
                .HasColumnName("Rua")
                .HasColumnType("varchar(150)")
                .IsRequired(true);

                e.Property(x => x.Numero)
               .HasColumnName("Numero")
               .HasColumnType("varchar(10)")
               .IsRequired(true);

                e.Property(x => x.Cidade)
               .HasColumnName("Cidade")
               .HasColumnType("varchar(20)")
               .IsRequired(true);

                e.Property(x => x.Cep)
               .HasColumnName("Cep")
               .HasColumnType("varchar(10)")
               .IsRequired(true);
            });


            builder.Property(x => x.Nome)
               .IsRequired();

            builder.Property(x => x.DataNascimento)
               .IsRequired();

            builder.Property(x => x.Cpf)
               .IsRequired();

            builder.Property(x => x.Sexo)
               .IsRequired();

            builder.Property(x => x.Ativo);
        }
    }
}
