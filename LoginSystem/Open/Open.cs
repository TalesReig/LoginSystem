using LoginSystem.Dominio.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSystem.WinApp.Open
{
    public partial class Open : Form
    {
        User user;
        public Open(User user)
        {
            InitializeComponent();
            this.user = user;
            labelName.Text = user.UserName;
        }
    }
}
