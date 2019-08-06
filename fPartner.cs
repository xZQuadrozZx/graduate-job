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
    public partial class fPartner : Form
    {
        public fPartner()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e) // Печать
        {
            print.ExportToExcelNew(this, dgvPartner, 6, 1, "Контрагенты");
        }

        private string cmdText(string where)
        {
            string cmd = "SELECT ID, ФИО_Наименование, Поставщик, Адрес, Информация, Паспорт, Телефоны, " + 
                         "Реквизиты, ИНН, КПП FROM Контрагент " + 
                         where;

            return cmd;
        }

        private void fPartner_Load(object sender, EventArgs e)
        {
            workWithDB.fillDGV(cmdText(""), dgvPartner);
            workWithDB.fillDGV(cmdText(""), dgvPartnerCopy);

            dgvPartner.ReadOnly = true;
            dgvPartner.Columns[0].Visible = false;
            dgvPartner.Columns[1].Width = 150;
            dgvPartner.Columns[2].Width = 80;
            dgvPartner.Columns[3].Width = 150;
            dgvPartner.Columns[7].Width = 250;

            cbxSelect.SelectedIndex = 0;
        }

        private void dgvPartner_SelectionChanged(object sender, EventArgs e) // Изменился выбор
        {
            int selRowNum = dgvPartner.CurrentCell.RowIndex;

            txtFIOorName.Text = dgvPartner[1, selRowNum].Value.ToString(); // ФИО_Наименование контрагента

            if (dgvPartner[2, selRowNum].Value.ToString() == "True")
            {
                cbSupplier.Checked = true; // Поставщик или нет
            }
            else
            {
                cbSupplier.Checked = false; // Поставщик или нет
            }

            txtAddress.Text = dgvPartner[3, selRowNum].Value.ToString(); // Адрес
            txtInfo.Text = dgvPartner[4, selRowNum].Value.ToString(); // Информация
            txtPassport.Text = dgvPartner[5, selRowNum].Value.ToString(); // Пасспорт
            txtPhones.Text = dgvPartner[6, selRowNum].Value.ToString(); // Телефоны
            txtBank.Text = dgvPartner[7, selRowNum].Value.ToString(); // Реквизиты
            txtINN.Text = dgvPartner[8, selRowNum].Value.ToString(); // ИНН
            txtKPP.Text = dgvPartner[9, selRowNum].Value.ToString(); // КПП
        }

        private void cbSelect_CheckedChanged(object sender, EventArgs e) // Отобрать
        {
            if (cbSelect.Checked == true)
            {
                if (cbxSelect.Text == "поставщиков")
                {
                    workWithDB.fillDGV(cmdText("WHERE Поставщик = True"), dgvPartner);
                }
                else if (cbxSelect.Text == "покупателей")
                {
                    workWithDB.fillDGV(cmdText("WHERE Поставщик = False"), dgvPartner);
                }
            }
            else if (cbSelect.Checked == false)
            {
                workWithDB.fillDGV(cmdText(""), dgvPartner);
            }
        }

        private void cbxSelect_SelectedValueChanged(object sender, EventArgs e) // Отобрать cb
        {
            if (cbSelect.Checked == true)
            {
                if (cbxSelect.Text == "поставщиков")
                {
                    workWithDB.fillDGV(cmdText("WHERE Поставщик = True"), dgvPartner);
                }
                else if (cbxSelect.Text == "покупателей")
                {
                    workWithDB.fillDGV(cmdText("WHERE Поставщик = False"), dgvPartner);
                }
            }
            else if (cbSelect.Checked == false)
            {
                workWithDB.fillDGV(cmdText(""), dgvPartner);
            }
        }

        bool add = false;
        private void btnAdd_Click(object sender, EventArgs e) // Добавить
        {
            string passport = txtPassport.Text;

            if (passport == "сер      № ")
            {
                passport = "";
            }

            if (add == false)
            {
                workWithDB.actionDB($"INSERT INTO Контрагент (ФИО_Наименование) VALUES ('')");
                workWithDB.fillDGV(cmdText(""), dgvPartner);
                int lastRow = dgvPartner.RowCount - 1;
                dgvPartner.CurrentCell = dgvPartner.Rows[lastRow].Cells[1];
                dgvPartner.FirstDisplayedScrollingRowIndex = lastRow;

                txtFIOorName.Text = string.Empty;
                cbSelect.Checked = false;
                txtAddress.Text = string.Empty;
                txtBank.Text = string.Empty;
                txtInfo.Text = string.Empty;
                txtINN.Text = string.Empty;
                txtKPP.Text = string.Empty;
                txtPassport.Text = string.Empty;
                txtPhones.Text = string.Empty;

                add = true;

                btnAdd.Text = "Добавить";
            }
            else
            {
                workWithDB.actionDB($"DELETE FROM Контрагент WHERE ФИО_Наименование = ''");
                if (txtFIOorName.Text == string.Empty || txtAddress.Text == string.Empty || txtPhones.Text == string.Empty)
                {
                    MessageBox.Show("Нужно обязательно заполнить поля с пометкой - (*)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                workWithDB.actionDB($"INSERT INTO Контрагент " +
                    $"(ФИО_Наименование, Поставщик, Информация, Паспорт, Адрес, Телефоны, Реквизиты, ИНН, КПП) " +
                    $"VALUES ('{txtFIOorName.Text}', {cbSupplier.Checked}, '{txtInfo.Text}', " +
                            $"'{passport}', '{txtAddress.Text}', '{txtPhones.Text}', " +
                            $"'{txtBank.Text}', '{txtINN.Text}', '{txtKPP.Text}')");
                workWithDB.fillDGV(cmdText(""), dgvPartner);

                add = false;

                btnAdd.Text = "Новая запись";
            }
        }

        int num;
        private void btnDelete_Click(object sender, EventArgs e) // Удалить
        {
            num = (int)dgvPartner.CurrentRow.Cells[0].Value;

            if (add == true)
            {
                add = false;

                btnAdd.Text = "Новая запись";
            }

            if (MessageBox.Show("Удалить выбранную запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                workWithDB.actionDB($"DELETE FROM Контрагент WHERE ID = {num}");
                workWithDB.fillDGV(cmdText(""), dgvPartner);
            }
            else
            {
                return;
            }
        }

        private void fPartner_FormClosing(object sender, FormClosingEventArgs e) // Закрытие окна
        {
            workWithDB.actionDB($"DELETE FROM Контрагент WHERE ФИО_Наименование = ''");

            // Проверка на внесение изменений
            if (workWithDB.isEqual(workWithDB.dgvToArray(dgvPartner), workWithDB.dgvToArray(dgvPartnerCopy)) == false)
            {
                if (MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    workWithDB.saveDB();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) // Изменить
        {
            int rowIndex = dgvPartner.CurrentRow.Index;
            string passport = txtPassport.Text;

            num = (int)dgvPartner.CurrentRow.Cells[0].Value;

            if (passport == "сер      № ")
            {
                passport = "";
            }

            if (dgvPartner.Rows[rowIndex].Cells[1].Value.ToString() != txtFIOorName.Text || dgvPartner.Rows[rowIndex].Cells[2].Value.ToString() != cbSelect.Checked.ToString() ||
                dgvPartner.Rows[rowIndex].Cells[3].Value.ToString() != txtAddress.Text || dgvPartner.Rows[rowIndex].Cells[4].Value.ToString() != txtInfo.Text ||
                dgvPartner.Rows[rowIndex].Cells[5].Value.ToString() != txtPassport.Text || dgvPartner.Rows[rowIndex].Cells[6].Value.ToString() != txtPhones.Text ||
                dgvPartner.Rows[rowIndex].Cells[7].Value.ToString() != txtBank.Text || dgvPartner.Rows[rowIndex].Cells[8].Value.ToString() != txtINN.Text ||
                dgvPartner.Rows[rowIndex].Cells[9].Value.ToString() != txtKPP.Text)
            {
                if (MessageBox.Show("Вы хотите изменить данную строку?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    workWithDB.actionDB($"UPDATE Контрагент SET ФИО_Наименование = '{txtFIOorName.Text}', Поставщик = {cbSelect.Checked}, Адрес = '{txtAddress.Text}', " +
                        $"Информация = '{txtInfo.Text}', Паспорт = '{passport}', Телефоны = '{txtPhones.Text}', " +
                        $"Реквизиты = '{txtBank.Text}', ИНН = '{txtINN.Text}', КПП = '{txtKPP.Text}' " +
                        $"WHERE ID = {num}");
                    workWithDB.fillDGV(cmdText(""), dgvPartner);
                }
                else
                {
                    return;
                }
            }
        }

        private void txtPhones_KeyPress(object sender, KeyPressEventArgs e) // Ввод только цифр
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
