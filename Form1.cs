using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorAuto
{
    public partial class fAuth : Form
    {
        public fAuth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Выход из приложения
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e) // Авторизация
        {
            if (txtLogin.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.Hide();
                workWithDB.getUserName(txtLogin.Text, txtPassword.Text);
                workWithDB.getRole(workWithDB.getRoleID(txtLogin.Text, txtPassword.Text));
                workWithDB.auth(txtLogin.Text, txtPassword.Text);
            }
        }
    }
}
