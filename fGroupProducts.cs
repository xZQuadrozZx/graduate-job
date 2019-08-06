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
    public partial class fGroupProducts : Form
    {
        public fGroupProducts()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e) // Печать
        {
            print.ExportToExcelNew(this, dgvGroupProduct, 6, 1, "Группы товаров");
        }

        private void fGroupProducts_Load(object sender, EventArgs e) // Загрузка окна
        {
            workWithDB.fillDGV("SELECT ID, Группа FROM ГруппаТовара", dgvGroupProduct);
            workWithDB.fillDGV("SELECT ID, Группа FROM ГруппаТовара", dgvGroupProductCopy);

            dgvGroupProduct.Columns[0].Visible = false;
            dgvGroupProduct.ReadOnly = true;
            dgvGroupProduct.Columns[1].Width = 540;
        }

        private void btnAdd_Click(object sender, EventArgs e) // Добавить
        {
            if (txtGroupName.Text == string.Empty)
            {
                MessageBox.Show("Вы оставили строку пустой, нужно её заполнить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                workWithDB.actionDB($"INSERT INTO ГруппаТовара (Группа) VALUES ('{txtGroupName.Text}')");
                workWithDB.fillDGV("SELECT * FROM ГруппаТовара", dgvGroupProduct);
                txtGroupName.Text = string.Empty;
            }
        }

        int num;
        private void btnDelete_Click(object sender, EventArgs e) // Удалить
        {
            num = (int)dgvGroupProduct.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Удалить данную строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                workWithDB.actionDB($"DELETE FROM ГруппаТовара WHERE ID = {num}");
                workWithDB.fillDGV("SELECT * FROM ГруппаТовара", dgvGroupProduct);
            }
            else
            {
                return;
            }
        }

        private void fGroupProducts_FormClosing(object sender, FormClosingEventArgs e) // Закрытие формы
        {
            // Проверка на внесение изменений
            if (workWithDB.isEqual(workWithDB.dgvToArray(dgvGroupProduct), workWithDB.dgvToArray(dgvGroupProductCopy)) == false)
            {
                if (MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    workWithDB.saveDB();
                }
            }
        }
    }
}
