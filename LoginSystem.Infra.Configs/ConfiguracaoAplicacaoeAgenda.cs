using Microsoft.Extensions.Configuration;
using System.IO;

namespace LoginSystem.Infra.Configs
{
    public class ConfiguracaoAplicacaoeAgenda
    {
        public ConfiguracaoAplicacaoeAgenda()
        {
            IConfiguration configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            ConnectionStrings = new ConnectionStrings { SqlServer = connectionString };

            var diretorioSaida = configuracao
                .GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida")
                .Value;

            VersaoSistema = configuracao.GetSection("VersaoSistema").Value;
        }

        public string VersaoSistema { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string SqlServer { get; set; }
    }
}
