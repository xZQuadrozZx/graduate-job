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
    public partial class fPointOfSale : Form
    {
        public fPointOfSale()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e) // Печать
        {
            print.ExportToExcelNew(this, dgvPointOfSaleCopy, 6, 1, "Торговые точки");
        }

        private void fPointOfSale_Load(object sender, EventArgs e)
        {
            workWithDB.fillDGV("SELECT ID, Точка, Адрес, Описание FROM ТорговаяТочка", dgvPointOfSale);
            workWithDB.fillDGV("SELECT ID, Точка, Адрес, Описание FROM ТорговаяТочка", dgvPointOfSaleCopy);

            dgvPointOfSale.Columns[0].Visible = false;
            dgvPointOfSale.ReadOnly = true;
            dgvPointOfSale.Columns[1].Width = 180;
            dgvPointOfSale.Columns[2].Width = 180;
            dgvPointOfSale.Columns[3].Width = 200;
        }

        private void btnAdd_Click(object sender, EventArgs e) // Добавить
        {
            if (txtPoint.Text == string.Empty || txtAddress.Text == string.Empty)
            {
                MessageBox.Show("Нужно обязательно ввести адрес и наименование точки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                workWithDB.actionDB($"INSERT INTO ТорговаяТочка (Точка, Адрес, Описание) " +
                    $"VALUES ('{txtPoint.Text}', '{txtAddress.Text}', '{txtText.Text}')");
                workWithDB.fillDGV("SELECT * FROM ТорговаяТочка", dgvPointOfSale);
                txtPoint.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtText.Text = string.Empty;
            }
        }

        int num;
        private void btnDelete_Click(object sender, EventArgs e) // Удалить
        {
            num = (int)dgvPointOfSale.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Удалить данную строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                workWithDB.actionDB($"DELETE FROM ТорговаяТочка WHERE ID = {num}");
                workWithDB.fillDGV("SELECT * FROM ТорговаяТочка", dgvPointOfSale);
            }
            else
            {
                return;
            }
        }

        private void fPointOfSale_FormClosing(object sender, FormClosingEventArgs e) // Закрытие окна
        {
            // Проверка на внесение изменений
            if (workWithDB.isEqual(workWithDB.dgvToArray(dgvPointOfSale), workWithDB.dgvToArray(dgvPointOfSaleCopy)) == false)
            {
                if (MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    workWithDB.saveDB();
                }
            }
        }
    }
}
