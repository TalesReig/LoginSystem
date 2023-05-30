using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using LoginSystem.Infra.Orm.ModuloUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MigradorBancoDados.AtualizarBancoDados();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var connectionString = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=DbLoginSystemOrm;Integrated Security=True";
            var contextoDadosOrm = new LoginSystemDbContext(connectionString);
            RepositorioUser repositorio = new(contextoDadosOrm);
            frameRegister register = new(repositorio);
            frameLogin login = new(repositorio);
            Application.Run(register);
        }
    }
}
