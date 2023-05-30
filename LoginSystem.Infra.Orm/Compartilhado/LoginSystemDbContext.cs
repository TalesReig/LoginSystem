using eAgenda.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Locadora_De_Veiculos.Infra.Orm.Compartilhado
{
    public class LoginSystemDbContext : DbContext, IContextoPersistencia
    {
        private string connectionString;

        public LoginSystemDbContext(string connectionString)
        {
            this.connectionString = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DbLoginSystemOrm;Integrated Security=True";
        }

        public void DesfazerAlteracoes()
        {
            throw new System.NotImplementedException();
        }

        public void GravarDados()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dllComConfiguracoesOrm = typeof(LoginSystemDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);
        }
    }
}
