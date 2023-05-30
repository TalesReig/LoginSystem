using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace Locadora_De_Veiculos.Infra.Orm.Compartilhado
{
    public static class MigradorBancoDados
    {
        public static void AtualizarBancoDados()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DbLoginSystemOrm;Integrated Security=True";

            var db = new LoginSystemDbContext(connectionString);

            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
                db.Database.Migrate();
        }
    }
}
