using LoginSystem.Dominio.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginSystem.Infra.Orm.ModuloUser
{
    public class MapeadorUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TbUser");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.UserName).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Password).IsRequired().HasColumnType("varchar(100)");
        }
    }
}
