using LoginSystem.Dominio.User;
using LoginSystem.Infra.Orm.ModuloUser;
using LoginSystem.WinApp.Open;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSystem
{
    public partial class frameRegister : Form
    {
        RepositorioUser repositorio;
        public frameRegister(RepositorioUser repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string validadorCb = Validar(txtUsername.Text, txtPassword.Text, txtConfirmPassword.Text);
            if (validadorCb != "")
            {
                MessageBox.Show(validadorCb);
                return;
            }

            User user = new User();
            user.UserName = txtUsername.Text;
            user.Password = txtPassword.Text;

            repositorio.Inserir(user);
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;

            new Open(user).Show();
            this.Hide();
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConfirmPassword.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frameLogin(repositorio).Show();
            this.Hide();
        }

        private string Validar(string userName, string password, string confirmPassword)
        {
            string result = "";

            if (string.IsNullOrEmpty(userName))
                result += "Username não pode ser nulo ou vazio";
            if (string.IsNullOrEmpty(password))
                result += "\nA senha não pode ser nula";
            if (password != confirmPassword)
                result += "\nAs senhas devem ser iguais";

            return result;
        }
    }
}
