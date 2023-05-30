using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Locadora_De_Veiculos.Infra.Orm.Compartilhado
{
    public class LoginSystemDbContextDbContextFactory : IDesignTimeDbContextFactory<LoginSystemDbContext>
    {
        public LoginSystemDbContext CreateDbContext(string[] args)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DbLoginSystemOrm;Integrated Security=True";

            return new LoginSystemDbContext(connectionString);
        }
    }
}
