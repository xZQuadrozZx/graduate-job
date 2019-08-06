using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorAuto
{
    public partial class fWorkers : Form
    {
        public fWorkers()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e) // Печать
        {
            print.ExportToExcelNew(this, dgvWorkers, 6, 1, "Работники");
        }

        private void fWorkers_Load(object sender, EventArgs e) // Загрузка окна
        {
            workWithDB.fillDGV($"SELECT Работник.ТабN, Работник.ФИО, Должность.Должность, Работник.Процент, работник.Логин, Работник.Пароль " +
                $"FROM Должность INNER JOIN Работник ON Должность.ID = Работник.ДолжностьID", dgvWorkersCopy);
            workWithDB.fillDGV($"SELECT Работник.ТабN, Работник.ФИО, Должность.Должность, Работник.Процент, Работник.Логин, Работник.Пароль " +
                $"FROM Должность INNER JOIN Работник ON Должность.ID = Работник.ДолжностьID", dgvWorkers);
            workWithDB.fillCombobox(cbxRole, "Должность", "ID", "SELECT ID, Должность FROM Должность");

            dgvWorkers.Columns[0].Width = 50;
            dgvWorkers.Columns[1].Width = 200;

            dgvWorkers.ReadOnly = true;

            cbxRole.SelectedIndex = 0;

            if (cbxRole.Text == "Менеджер")
            {
                txtProcent.Enabled = true;
            }
            else
            {
                txtProcent.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) // Добавить
        {
            if (txtFIO.Text == string.Empty || cbxRole.Text == string.Empty || txtLogin.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                if (txtProcent.Enabled == true && txtProcent.Text == string.Empty)
                {
                    MessageBox.Show("Введите процент.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                if (txtProcent.Enabled == true && txtProcent.Text == string.Empty)
                {
                    MessageBox.Show("Введите процент.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbxRole.Text == "Менеджер")
                {
                    workWithDB.actionDB($"INSERT INTO Работник (ФИО, ДолжностьID, Логин, Пароль, Процент) " +
                        $"VALUES ('{txtFIO.Text}', {cbxRole.SelectedValue}, '{txtLogin.Text}', '{txtPassword.Text}', {txtProcent.Text})");
                }
                else
                {
                    workWithDB.actionDB($"INSERT INTO Работник (ФИО, ДолжностьID, Логин, Пароль) " +
                        $"VALUES ('{txtFIO.Text}', {cbxRole.SelectedValue}, '{txtLogin.Text}', '{txtPassword.Text}')");
                }

                workWithDB.fillDGV($"SELECT Работник.ТабN, Работник.ФИО, Должность.Должность, Работник.Процент, Работник.Логин, Работник.Пароль " +
                    $"FROM Должность INNER JOIN Работник ON Должность.ID = Работник.ДолжностьID", dgvWorkers);

                txtFIO.Text = string.Empty;
                txtLogin.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtProcent.Text = string.Empty;
                cbxRole.SelectedIndex = 0;
            }
        }

        int num;
        private void btnDelete_Click(object sender, EventArgs e) // Удалить
        {
            num = (int)dgvWorkers.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Удалить выбранную запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                workWithDB.actionDB($"DELETE FROM Работник WHERE ТабN = {num}");
                workWithDB.fillDGV($"SELECT Работник.ТабN, Работник.ФИО, Должность.Должность, Работник.Процент, Работник.Логин, Работник.Пароль " +
                    $"FROM Должность INNER JOIN Работник ON Должность.ID = Работник.ДолжностьID", dgvWorkers);
            }
            else
            {
                return;
            }
        }

        private void cbxRole_SelectedValueChanged(object sender, EventArgs e)
        {
            txtProcent.Text = string.Empty;

            if (cbxRole.Text == "Менеджер")
            {
                txtProcent.Enabled = true;
            }
            else
            {
                txtProcent.Enabled = false;
            }
        }

        private void fWorkers_FormClosing(object sender, FormClosingEventArgs e) // Закрытие окна
        {
            // Проверка на внесение изменений
            if (workWithDB.isEqual(workWithDB.dgvToArray(dgvWorkers), workWithDB.dgvToArray(dgvWorkersCopy)) == false)
            {
                if (MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    workWithDB.saveDB();
                }
            }
        }
    }
}
