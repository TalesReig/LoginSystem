using eAgenda.Dominio;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using LoginSystem.Dominio.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LoginSystem.Infra.Orm.ModuloUser
{
    public class RepositorioUser : IRepositorioUser
    {
        private DbSet<User> users;
        private readonly LoginSystemDbContext dbContext;

        public RepositorioUser(IContextoPersistencia contextoPersistencia)
        {
            dbContext = (LoginSystemDbContext)contextoPersistencia;
            users = dbContext.Set<User>();
        }

        public void Inserir(User novoRegistro)
        {
            users.Add(novoRegistro);
            dbContext.GravarDados();
        }

        public User SelecionarPorUsername(string username)
        {
            return users.SingleOrDefault(x => x.UserName == username);
        }
    }
}
