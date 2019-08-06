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
    public partial class fAddAuto : Form
    {
        public fAddAuto()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fAddAuto_Load(object sender, EventArgs e)
        {
            workWithDB.fillCombobox(cbxProductGroup, "Группа", "ID", "SELECT ID, Группа FROM ГруппаТовара");

            cbComplete_CheckedChanged(sender, e);
        }

        private void clearTextBoxes()
        {
            txtPlace.Clear();
            txtColor.Clear();
            cbxTransmission.SelectedIndex = 0;
            cbxEngineType.SelectedIndex = 0;
            txtCapacity.Clear();
            txtTextDefect.Clear();
        }

        // Комплектация
        private void cbComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (cbComplete.Checked == true && cbDefect.Checked == false)
            {
                gbDefect.Visible = false;
                gbComplete.Visible = true;
                gbComplete.Location = new Point(6, 167);

                btnSaveChanges.Location = new Point(120, 341);
                btnCancel.Location = new Point(263, 341);

                Size = new Size(428, 430);
            }
            else if (cbComplete.Checked == false && cbDefect.Checked == true)
            {
                gbComplete.Visible = false;
                gbDefect.Visible = true;
                gbDefect.Location = new Point(6, 167);

                btnSaveChanges.Location = new Point(120, 315);
                btnCancel.Location = new Point(263, 315);

                Size = new Size(428, 405);
            }
            else if (cbComplete.Checked == true && cbDefect.Checked == true)
            {
                gbDefect.Visible = true;
                gbComplete.Visible = true;
                gbComplete.Location = new Point(6, 167);
                gbDefect.Location = new Point(6, 341);

                btnSaveChanges.Location = new Point(120, 490);
                btnCancel.Location = new Point(263, 490);

                Size = new Size(428, 578);
            }
            else
            {
                gbDefect.Visible = false;
                gbComplete.Visible = false;

                btnSaveChanges.Location = new Point(120, 167);
                btnCancel.Location = new Point(263, 167);

                Size = new Size(428, 259);
            }
        }

        // Дефекты
        private void cbDefect_CheckedChanged(object sender, EventArgs e)
        {
            if (cbComplete.Checked == true && cbDefect.Checked == false)
            {
                gbDefect.Visible = false;
                gbComplete.Visible = true;
                gbComplete.Location = new Point(6, 167);

                btnSaveChanges.Location = new Point(120, 341);
                btnCancel.Location = new Point(263, 341);

                Size = new Size(428, 430);
            }
            else if (cbComplete.Checked == false && cbDefect.Checked == true)
            {
                gbComplete.Visible = false;
                gbDefect.Visible = true;
                gbDefect.Location = new Point(6, 167);

                btnSaveChanges.Location = new Point(120, 315);
                btnCancel.Location = new Point(263, 315);

                Size = new Size(428, 405);
            }
            else if (cbComplete.Checked == true && cbDefect.Checked == true)
            {
                gbDefect.Visible = true;
                gbComplete.Visible = true;
                gbComplete.Location = new Point(6, 167);
                gbDefect.Location = new Point(6, 341);

                btnSaveChanges.Location = new Point(120, 490);
                btnCancel.Location = new Point(263, 490);

                Size = new Size(428, 578);
            }
            else
            {
                gbDefect.Visible = false;
                gbComplete.Visible = false;

                btnSaveChanges.Location = new Point(120, 167);
                btnCancel.Location = new Point(263, 167);

                Size = new Size(428, 259);
            }
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void fAddAuto_FormClosing(object sender, FormClosingEventArgs e)
        {
            clearTextBoxes();
        }

        // Сохранение
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string text = txtName.Text;

            if (txtEquipment.Text != string.Empty)
            {
                text += $", {txtEquipment.Text}";
            }
            if (cbxType.Text != string.Empty)
            {
                text += $", {cbxType.Text}";
            }

            if (cbxProductGroup.Text == string.Empty || txtName.Text == string.Empty)
            {
                MessageBox.Show("Заполните обязательные поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cbComplete.Checked == true && cbDefect.Checked == false)
            {
                if (txtPlace.Text == string.Empty)
                {
                    text += "";
                }
                if (txtColor.Text == string.Empty)
                {
                    text += "";
                }
                if (cbxTransmission.Text == string.Empty)
                {
                    text += "";
                }
                if (cbxEngineType.Text == string.Empty)
                {
                    text += "";
                }
                if (txtCapacity.Text == string.Empty)
                {
                    text += "";
                }

                // Вставка наименования
                if (txtPlace.Text != string.Empty)
                {
                    text += $", {txtPlace.Text} - местный";
                }
                if (txtColor.Text != string.Empty)
                {
                    text += $", {txtColor.Text}";
                }
                if (cbxTransmission.Text != string.Empty)
                {
                    text += $", {cbxTransmission.Text}";
                }
                if (cbxEngineType.Text != string.Empty)
                {
                    text += $", {cbxEngineType.Text}";
                }
                if (txtCapacity.Text != string.Empty)
                {
                    text += $", {txtCapacity.Text}";
                }

                if (MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workWithDB.actionDB($"INSERT INTO Товар (ГруппаID, Наименование, ЕдИзм) " +
                        $"VALUES ({cbxProductGroup.SelectedValue}, '{text}', 'шт')");
                }
            }
            else if (cbDefect.Checked == true && cbComplete.Checked == false)
            {
                if (txtTextDefect.Text == string.Empty)
                {
                    MessageBox.Show("Заполните сообщение о дефекте или уберите флажок с пункта 'дефекты'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    text += $", {txtTextDefect.Text}";
                }

                if (MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workWithDB.actionDB($"INSERT INTO Товар (ГруппаID, Наименование, ЕдИзм) " +
                        $"VALUES ({cbxProductGroup.SelectedValue}, '{text}', 'шт')");
                }
            }
            else if (cbComplete.Checked == true && cbDefect.Checked == true)
            {
                if (txtPlace.Text == string.Empty)
                {
                    text += "";
                }
                if (txtColor.Text == string.Empty)
                {
                    text += "";
                }
                if (cbxTransmission.Text == string.Empty)
                {
                    text += "";
                }
                if (cbxEngineType.Text == string.Empty)
                {
                    text += "";
                }
                if (txtCapacity.Text == string.Empty)
                {
                    text += "";
                }

                // Вставка наименования
                if (txtPlace.Text != string.Empty)
                {
                    text += $", {txtPlace.Text} - местный";
                }
                if (txtColor.Text != string.Empty)
                {
                    text += $", {txtColor.Text}";
                }
                if (cbxTransmission.Text != string.Empty)
                {
                    text += $", {cbxTransmission.Text}";
                }
                if (cbxEngineType.Text != string.Empty)
                {
                    text += $", {cbxEngineType.Text}";
                }
                if (txtCapacity.Text != string.Empty)
                {
                    text += $", {txtCapacity.Text}";
                }

                if (txtTextDefect.Text == string.Empty)
                {
                    MessageBox.Show("Заполните сообщение о дефекте или уберите флажок с пункта 'дефекты'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    text += $", {txtTextDefect.Text}";
                }

                if (MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workWithDB.actionDB($"INSERT INTO Товар (ГруппаID, Наименование, ЕдИзм) " +
                        $"VALUES ({cbxProductGroup.SelectedValue}, '{text}', 'шт')");
                }
            }
            else if (cbComplete.Checked == false && cbDefect.Checked == false)
            {
                if (MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workWithDB.actionDB($"INSERT INTO Товар (ГруппаID, Наименование, ЕдИзм) " +
                        $"VALUES ({cbxProductGroup.SelectedValue}, '{text}', 'шт')");
                }
            }
        }

        private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
