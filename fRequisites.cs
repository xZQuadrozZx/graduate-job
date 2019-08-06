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
    public partial class fRequisites : Form
    {
        public fRequisites()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e) // Принять - применить изменения и закрыть
        {
            workWithDB.fillDGV("SELECT * FROM Реквизиты", dgvTEXT);

            if (dgvTEXT.Rows[0].Cells[0].Value.ToString() != txtName.Text || dgvTEXT.Rows[0].Cells[1].Value.ToString() != txtFIOGenDir.Text ||
                dgvTEXT.Rows[0].Cells[2].Value.ToString() != txtFIOGenBuh.Text || dgvTEXT.Rows[0].Cells[3].Value.ToString() != txtAddress.Text ||
                dgvTEXT.Rows[0].Cells[4].Value.ToString() != txtBank.Text || dgvTEXT.Rows[0].Cells[5].Value.ToString() != txtINN.Text ||
                dgvTEXT.Rows[0].Cells[6].Value.ToString() != txtKPP.Text)
            {
                if (MessageBox.Show("Вы внесли изменения. Хотите сохранить изменения?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    workWithDB.actionDB($"UPDATE Реквизиты SET Наименование = '{txtName.Text}', ГенДиректор = '{txtFIOGenDir.Text}', " +
                        $"ГлавБух = '{txtFIOGenBuh.Text}', Адрес = '{txtAddress.Text}', Реквизиты = '{txtBank.Text}', ИНН = '{txtINN.Text}', " +
                        $"КПП = '{txtKPP.Text}'");
                    fillAll();
                    workWithDB.saveDB();
                    Close();
                }
                else
                {
                    Close();
                }
            }
        }

        private void fillAll() // Заполнение textbox'ов
        {
            string cmdText = "SELECT Наименование, ГенДиректор, ГлавБух, Адрес, Реквизиты, ИНН, КПП FROM Реквизиты";

            workWithDB.fillTextbox(txtName, cmdText, "Наименование");
            workWithDB.fillTextbox(txtFIOGenDir, cmdText, "ГенДиректор");
            workWithDB.fillTextbox(txtFIOGenBuh, cmdText, "ГлавБух");
            workWithDB.fillTextbox(txtAddress, cmdText, "Адрес");
            workWithDB.fillTextbox(txtBank, cmdText, "Реквизиты");
            workWithDB.fillTextbox(txtINN, cmdText, "ИНН");
            workWithDB.fillTextbox(txtKPP, cmdText, "КПП");
        }

        private void fRequisites_Load(object sender, EventArgs e)
        {
            fillAll();
        }

        private void fRequisites_FormClosing(object sender, FormClosingEventArgs e) // Закрытие окна
        {
            workWithDB.saveDB();
        }
    }
}
