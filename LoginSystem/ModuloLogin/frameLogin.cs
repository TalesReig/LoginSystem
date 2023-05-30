using LoginSystem.Dominio.User;
using LoginSystem.Infra.Orm.ModuloUser;
using LoginSystem.WinApp.Open;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginSystem
{
    public partial class frameLogin : Form
    {
        RepositorioUser repositorio;
        public frameLogin(RepositorioUser repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string validadorCb = Validar(txtUsername.Text, txtPassword.Text);
            if (validadorCb != "")
            {
                MessageBox.Show(validadorCb);
                return;
            }

            User user = repositorio.SelecionarPorUsername(txtUsername.Text);
            new Open(user).Show();
            this.Hide();
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frameRegister(repositorio).Show();
            this.Hide();
        }

        private string Validar(string username, string password)
        {
            string result = "";

            var userCB = repositorio.SelecionarPorUsername(username);
            if(userCB == null)
            {
                result = "Esse usuário não existe";
                return result;
            }
            if(userCB.Password != password)
            {
                result = "Senha incorreta";
            }

            return result;
        }
    }
}
