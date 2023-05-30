using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystem.Dominio.User
{
    public interface IRepositorioUser
    {

        void Inserir(User novoRegistro);

        User SelecionarPorUsername(string username);
    }
}
