using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MotorAuto
{
    public partial class fNewSale : Form
    {
        public fNewSale()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }

        private int lastID;

        private void fNewSale_Load(object sender, EventArgs e)
        {
            dgvNewSale.Columns[2].DefaultCellStyle.Format = "N2";
            dgvNewSale.Columns[3].DefaultCellStyle.Format = "N2";

            cbxCashier.Enabled = false;
            if (fStartMenu.roleUser == "Администратор")
            {
                cbxCashier.Enabled = true;
            }
            workWithDB.fillCombobox(cbxPointOfSale, "Точка", "ID", "SELECT ID, Точка FROM ТорговаяТочка");
            workWithDB.fillCombobox(cbxPartner, "ФИО_Наименование", "ID", "SELECT ID, ФИО_Наименование FROM Контрагент");
            workWithDB.fillCombobox(cbxManager, "ФИО", "ТабN", "SELECT Работник.ТабN, Работник.ФИО " +
                                    "FROM Должность INNER JOIN Работник ON Должность.ID = Работник.ДолжностьID " +
                                    "WHERE ДолжностьID = 2");
            workWithDB.fillCombobox(cbxCashier, "ФИО", "ТабN", "SELECT Работник.ТабN, Работник.ФИО " +
                                    "FROM Должность INNER JOIN Работник ON Должность.ID = Работник.ДолжностьID " +
                                    "WHERE ДолжностьID = 3");
            txtDate.Text = DateTime.Now.ToString("dd.MM.yyyy");

            //***Поиск кассира который находится в данной сессии***//
            int index = cbxCashier.FindString(fStartMenu.userName);
            cbxCashier.SelectedIndex = index;
            //*******************************************************//
            //***Последний элемент в БД***//
            lastID = Convert.ToInt32(workWithDB.getLastID("SELECT MAX(ID) FROM Операция")) + 1;
            txtCode.Text = lastID.ToString();
            //****************************//

            dgvNewSale.CurrentCell = dgvNewSale.Rows[0].Cells[0];
        }

        private void btnSpend_Click(object sender, EventArgs e) // Провести
        {
            if (cbxPointOfSale.Text == string.Empty || cbxPartner.Text == string.Empty || cbxManager.Text == string.Empty || cbxCashier.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля перед проведением операции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Проверка на пустой DataGridView
                if (dgvNewSale.RowCount == 1)
                {
                    MessageBox.Show("Введите наименование товара и его количество!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DateTimePicker dtp = new DateTimePicker();
                    DateTime dt = Convert.ToDateTime(txtDate.Text);
                    dtp.Value = dt;

                    string idName;
                    string priceSale;

                    // Заполнение таблицы СоставОперации
                    for (int i = 0; i < dgvNewSale.RowCount - 1; i++)
                    {
                        idName = workWithDB.getLastID($"SELECT ID FROM Товар WHERE Наименование = '{dgvNewSale.Rows[i].Cells[0].Value.ToString()}'");
                        priceSale = workWithDB.getLastID($"SELECT ПрайсЛист.ЦенаПродажи FROM ПрайсЛист " +
                            $"WHERE ПрайсЛист.Дата = (SELECT MAX(Дата) FROM ПрайсЛист П WHERE П.ТоварID = ПрайсЛист.ТоварID AND ПрайсЛист.ТоварID = {idName})");

                        if (Convert.ToInt32(workWithDB.getLastID($"SELECT Количество FROM Склад " +
                            $"WHERE ТоварID = {idName} AND ТочкаID = {cbxPointOfSale.SelectedValue}")) < Convert.ToInt32(dgvNewSale.Rows[i].Cells[1].Value.ToString()) && Convert.ToInt32(workWithDB.getLastID($"SELECT Количество FROM Склад " +
                            $"WHERE ТоварID = {idName} AND ТочкаID = {cbxPointOfSale.SelectedValue}")) != 0)
                        {
                            if (MessageBox.Show("На складе нет столько автомобилей, вы хотите продать оставшиеся?", "Информация", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                dgvNewSale.Rows[i].Cells[1].Value = workWithDB.getLastID($"SELECT Количество FROM Склад WHERE ТоварID = {idName} AND " +
                                    $"ТочкаID = {cbxPointOfSale.SelectedValue}");
                                workWithDB.actionDB($"UPDATE Склад SET Количество = Количество - {dgvNewSale.Rows[i].Cells[1].Value.ToString()} " +
                                    $"WHERE ТоварID = {idName} AND ТочкаID = {cbxPointOfSale.SelectedValue}");

                                // Добавление операции
                                workWithDB.actionDB($"INSERT INTO Операция (ID, Дата, Закупка, КонтрагентID, ТочкаID, МенеджерID, КассирID) " +
                                    $"VALUES({txtCode.Text}, {ManyIF.convDate(dtp)}, False, " +
                                    $"{cbxPartner.SelectedValue.ToString()}, " +
                                    $"{cbxPointOfSale.SelectedValue.ToString()}, " +
                                    $"{cbxManager.SelectedValue.ToString()}, " +
                                    $"{cbxCashier.SelectedValue.ToString()})");
                                workWithDB.actionDB($"INSERT INTO СоставОперации (ОперацияID, ТоварID, Количество, Цена, ЦенаЗакупки) " +
                                    $"VALUES({txtCode.Text}, {idName}, {dgvNewSale.Rows[i].Cells[1].Value}, {priceSale}, {dgvNewSale.Rows[i].Cells[2].Value})");
                            }
                            else
                            {
                                return;
                            }
                        }
                        else if (Convert.ToInt32(workWithDB.getLastID($"SELECT Количество FROM Склад WHERE ТоварID = {idName} AND " +
                            $"ТочкаID = {cbxPointOfSale.SelectedValue}")) == 0)
                        {
                            MessageBox.Show("Данного автомобиля нет на складе, выберите другой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            workWithDB.actionDB($"UPDATE Склад SET Количество = Количество - {dgvNewSale.Rows[i].Cells[1].Value.ToString()} " +
                                $"WHERE ТоварID = {idName} AND ТочкаID = {cbxPointOfSale.SelectedValue}");

                            // Добавление операции
                            workWithDB.actionDB($"INSERT INTO Операция (ID, Дата, Закупка, КонтрагентID, ТочкаID, МенеджерID, КассирID) " +
                                $"VALUES({txtCode.Text}, {ManyIF.convDate(dtp)}, False, " +
                                $"{cbxPartner.SelectedValue.ToString()}, " +
                                $"{cbxPointOfSale.SelectedValue.ToString()}, " +
                                $"{cbxManager.SelectedValue.ToString()}, " +
                                $"{cbxCashier.SelectedValue.ToString()})");
                            workWithDB.actionDB($"INSERT INTO СоставОперации (ОперацияID, ТоварID, Количество, Цена, ЦенаЗакупки) " +
                                $"VALUES({txtCode.Text}, {idName}, {dgvNewSale.Rows[i].Cells[1].Value}, {priceSale}, {dgvNewSale.Rows[i].Cells[2].Value})");
                        }
                    }
                }

                MessageBox.Show("Операция успешно выполнена", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void btnProductCheck_Click(object sender, EventArgs e) // Печать товарного чека
        {
            // Добавляем строки в таблицу
            for (int i = 0; i < dgvNewSale.RowCount - 1; i++)
            {
                dgvNewSaleCopy.Rows.Add();
            }

            // Удаляем и обновляем строки в таблице
            if (dgvNewSaleCopy.RowCount > dgvNewSale.RowCount)
            {
                dgvNewSaleCopy.Rows.Clear();
                dgvNewSaleCopy.Rows.Add(dgvNewSale.RowCount - 1);
            }

            string requisites = workWithDB.getLastID($"SELECT Наименование FROM Реквизиты");
            string requisitesCompany = " ИНН " + workWithDB.getLastID($"SELECT ИНН FROM Реквизиты") +
                ", КПП " + workWithDB.getLastID($"SELECT КПП FROM Реквизиты") +
                ", Адрес: " + workWithDB.getLastID($"SELECT Адрес FROM Реквизиты");
            string dataSaler = workWithDB.getLastID($"SELECT ФИО_Наименование FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}");
            string requisitesSaler = " ИНН " + workWithDB.getLastID($"SELECT ИНН FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") +
                ", КПП " + workWithDB.getLastID($"SELECT КПП FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") +
                ", Адрес: " + workWithDB.getLastID($"SELECT Адрес FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") +
                ", Реквизиты: " + workWithDB.getLastID($"SELECT Реквизиты FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}");

            string[] columns =
            {
                "min date", "max date", workWithDB.getLastID("SELECT ГлавБух FROM Реквизиты"), "pokupatel", "INN / KPP pokupatela", "prodavec", "INN / KPP prodavca",
                requisites + requisitesCompany, "444", cbxManager.Text, txtCode.Text, "dannie prodavca", "kol-vo zapisei",
                "dannie kontragenta", "avtosalon", cbxManager.Text, "nachalo", "konec", dataSaler, requisitesSaler,
                "dannie kontagenta", "rekvizity kontragenta", cbxCashier.Text, workWithDB.getLastID("SELECT Наименование FROM Реквизиты"), "iz avtosalona", "v avtosalon",
                "True"
            };

            // Заполняем и редактируем таблицу
            for (int i = 0; i < dgvNewSale.RowCount - 1; i++)
            {
                for (int j = 0; j < dgvNewSale.ColumnCount + 2; j++)
                {
                    if (j == 0)
                    {
                        dgvNewSaleCopy.Rows[i].Cells[j].Value = i + 1;
                    }
                    else if (j == 2)
                    {
                        dgvNewSaleCopy.Rows[i].Cells[j].Value = "шт.";
                    }
                    else if (j == 1)
                    {
                        dgvNewSaleCopy.Rows[i].Cells[j].Value = dgvNewSale.Rows[i].Cells[0].Value;
                    }
                    else if (j > 2)
                    {
                        dgvNewSaleCopy.Rows[i].Cells[j].Value = dgvNewSale.Rows[i].Cells[j - 2].Value;
                    }
                }
            }

            if (dgvNewSale.RowCount == 1)
            {
                MessageBox.Show("Таблица пустая, выводить на печать нечего", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                print.ExportToExcel(this, dgvNewSaleCopy, 8, 1, "Товарный чек.xlsx", true, columns);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e) // Печать счета
        {
            // Добавляем строки в таблицу
            for (int i = 0; i < dgvNewSale.RowCount - 1; i++)
            {
                dgvNewSaleCopy.Rows.Add();
            }

            // Удаляем и обновляем строки в таблице
            if (dgvNewSaleCopy.RowCount > dgvNewSale.RowCount)
            {
                dgvNewSaleCopy.Rows.Clear();
                dgvNewSaleCopy.Rows.Add(dgvNewSale.RowCount - 1);
            }

            string requisites = workWithDB.getLastID($"SELECT Наименование FROM Реквизиты");
            string requisitesCompany = " ИНН " + workWithDB.getLastID($"SELECT ИНН FROM Реквизиты") +
                ", КПП " + workWithDB.getLastID($"SELECT КПП FROM Реквизиты") +
                ", Адрес: " + workWithDB.getLastID($"SELECT Адрес FROM Реквизиты");
            string dataSaler = workWithDB.getLastID($"SELECT ФИО_Наименование FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}");
            string requisitesSaler = " ИНН " + workWithDB.getLastID($"SELECT ИНН FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") +
                ", КПП " + workWithDB.getLastID($"SELECT КПП FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") +
                ", Адрес: " + workWithDB.getLastID($"SELECT Адрес FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") +
                ", Реквизиты: " + workWithDB.getLastID($"SELECT Реквизиты FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}");

            string[] columns =
            {
                "min date", "max date", workWithDB.getLastID("SELECT ГлавБух FROM Реквизиты"), "pokupatel", "INN / KPP pokupatela", "prodavec", "INN / KPP prodavca",
                requisites + requisitesCompany, "444", cbxManager.Text, txtCode.Text, "dannie prodavca", "kol-vo zapisei",
                "dannie kontragenta", "avtosalon", cbxManager.Text, "nachalo", "konec", dataSaler, requisitesSaler,
                dataSaler, requisitesSaler, cbxCashier.Text, workWithDB.getLastID("SELECT Наименование FROM Реквизиты"), "iz avtosalona", "v avtosalon",
                "False"
            };

            // Заполняем и редактируем таблицу
            for (int i = 0; i < dgvNewSale.RowCount - 1; i++)
            {
                for (int j = 0; j < dgvNewSale.ColumnCount + 2; j++)
                {
                    if (j == 0)
                    {
                        dgvNewSaleCopy.Rows[i].Cells[j].Value = i + 1;
                    }
                    else if (j == 2)
                    {
                        dgvNewSaleCopy.Rows[i].Cells[j].Value = "шт.";
                    }
                    else if (j == 1)
                    {
                        dgvNewSaleCopy.Rows[i].Cells[j].Value = dgvNewSale.Rows[i].Cells[0].Value;
                    }
                    else if (j > 2)
                    {
                        dgvNewSaleCopy.Rows[i].Cells[j].Value = dgvNewSale.Rows[i].Cells[j - 2].Value;
                    }
                }
            }

            if (dgvNewSale.RowCount == 1)
            {
                MessageBox.Show("Таблица пустая, выводить на печать нечего", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                print.ExportToExcel(this, dgvNewSaleCopy, 10, 1, "Счет - Накладная.xlsx", true, columns);
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e) // Печать накладной
        {
            //// Добавляем строки в таблицу
            //for (int i = 0; i < dgvNewSale.RowCount - 1; i++)
            //{
            //    dgvSaleNakl.Rows.Add();
            //}

            //// Удаляем и обновляем строки в таблице
            //if (dgvSaleNakl.RowCount > dgvNewSale.RowCount)
            //{
            //    dgvSaleNakl.Rows.Clear();
            //    dgvSaleNakl.Rows.Add(dgvNewSale.RowCount - 1);
            //}

            //string requisites = workWithDB.getLastID($"SELECT Наименование FROM Реквизиты");
            //string requisitesCompany = " ИНН " + workWithDB.getLastID($"SELECT ИНН FROM Реквизиты") +
            //    ", КПП " + workWithDB.getLastID($"SELECT КПП FROM Реквизиты") +
            //    ", Адрес: " + workWithDB.getLastID($"SELECT Адрес FROM Реквизиты");
            //string dataSaler = workWithDB.getLastID($"SELECT ФИО_Наименование FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}");
            //string requisitesSaler = " ИНН " + workWithDB.getLastID($"SELECT ИНН FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") +
            //    ", КПП " + workWithDB.getLastID($"SELECT КПП FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") +
            //    ", Адрес: " + workWithDB.getLastID($"SELECT Адрес FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") +
            //    ", Реквизиты: " + workWithDB.getLastID($"SELECT Реквизиты FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}");

            //string[] columns =
            //{
            //    "min date", "max date", workWithDB.getLastID("SELECT ГлавБух FROM Реквизиты"), "pokupatel", "INN / KPP pokupatela", "prodavec", "INN / KPP prodavca",
            //    requisites + requisitesCompany, "444", cbxManager.Text, txtCode.Text, "dannie prodavca", "kol-vo zapisei",
            //    "dannie kontragenta", "avtosalon", cbxManager.Text, "nachalo", "konec", dataSaler, requisitesSaler,
            //    dataSaler, requisitesSaler, cbxCashier.Text, workWithDB.getLastID("SELECT Наименование FROM Реквизиты"), "iz avtosalona", "v avtosalon",
            //    "False"
            //};

            //// Заполняем и редактируем таблицу
            //for (int i = 0; i < dgvNewSale.RowCount - 1; i++)
            //{
            //    for (int j = 0; j < 54; j++)
            //    {
            //        if (j == 0)
            //        {
            //            dgvSaleNakl.Rows[i].Cells[0].Value = i + 1;
            //        }
            //        else if (j == 20)
            //        {
            //            dgvSaleNakl.Rows[i].Cells[20].Value = "шт.";
            //        }
            //        else if (j == 3)
            //        {
            //            dgvSaleNakl.Rows[i].Cells[3].Value = dgvNewSale.Rows[i].Cells[0].Value;
            //        }
            //        else if (j == 17)
            //        {
            //            dgvSaleNakl.Rows[i].Cells[17].Value = workWithDB.getLastID($"SELECT ID FROM Товар WHERE Наименование = '{dgvNewSale.Rows[i].Cells[0].Value.ToString()}'");
            //        }
            //        else if (j == 32)
            //        {
            //            dgvSaleNakl.Rows[i].Cells[32].Value = dgvNewSale.Rows[i].Cells[1].Value;
            //        }
            //        else if (j == 37)
            //        {
            //            dgvSaleNakl.Rows[i].Cells[37].Value = dgvNewSale.Rows[i].Cells[1].Value;
            //        }
            //        else if (j == 40)
            //        {
            //            dgvSaleNakl.Rows[i].Cells[40].Value = dgvNewSale.Rows[i].Cells[2].Value;
            //        }
            //        else if (j == 43)
            //        {
            //            double sum = (Convert.ToDouble(dgvNewSale.Rows[i].Cells[2].Value) * 2) - ((Convert.ToDouble(dgvNewSale.Rows[i].Cells[2].Value) * 2) * 0.20);

            //            dgvSaleNakl.Rows[i].Cells[43].Value = sum.ToString();
            //        }
            //        else if (j == 46)
            //        {
            //            dgvSaleNakl.Rows[i].Cells[46].Value = "20";
            //        }
            //        else if (j == 49)
            //        {
            //            double sum = (Convert.ToDouble(dgvNewSale.Rows[i].Cells[2].Value) * 2) * 0.20;

            //            dgvSaleNakl.Rows[i].Cells[49].Value = sum.ToString();
            //        }
            //        else if (j == 53)
            //        {
            //            double sum = Convert.ToDouble(dgvSaleNakl.Rows[i].Cells[43].Value) + Convert.ToDouble(dgvSaleNakl.Rows[i].Cells[49].Value);

            //            dgvSaleNakl.Rows[i].Cells[53].Value = sum.ToString();
            //        }
            //        else
            //        {
            //            dgvSaleNakl.Rows[i].Cells[j].Value = string.Empty;
            //        }
            //    }
            //}

            //if (dgvNewSale.RowCount == 1)
            //{
            //    MessageBox.Show("Таблица пустая, выводить на печать нечего", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    print.ExportToExcel(this, dgvSaleNakl, 34, 1, "ТОРГ-12 (Товарная накладная).xlsx", true, columns);
            //}
        }

        private void fNewSale_FormClosing(object sender, FormClosingEventArgs e) // Перед закрытием открывает поля
        {
            txtCode.Enabled = true;          // Код операции
            txtDate.Enabled = true;          // Дата
            txtTotal.Enabled = true;         // ИТОГО
            cbxCashier.Enabled = true;       // Кассир
            cbxManager.Enabled = true;       // Менеджер
            cbxPartner.Enabled = true;       // Контрагент
            cbxPointOfSale.Enabled = true;   // Точка продаж
            btnSpend.Visible = true;

            //dgvNewSaleCopy.Visible = false;
            //dgvNewSaleCopy.DataSource = null;
        }

        public int currentRow;
        public int currentCell;
        private void dgvNewSale_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // Двойной щелчок по выбранной ячейке для перехода к прайс-листу
        {
            currentCell = dgvNewSale.CurrentCell.ColumnIndex; // Выбранный столбец
            currentRow = dgvNewSale.CurrentRow.Index; // Выбранная строка

            fWarehouse fWarehouse = new fWarehouse();

            if (currentCell == 0)
            {
                fWarehouse.moveTo = true;
                fWarehouse.Show();
                fWarehouse.isPurchase = false;
            }
            else
            {
                return;
            }
        }

        private void fNewSale_Activated(object sender, EventArgs e) // При активации формы
        {
            dgvNewSale.Rows[currentRow].Cells[0].Value = getValue.Name;
            dgvNewSale.Rows[currentRow].Cells[2].Value = getValue.Price;
        }

        private void dgvNewSale_CellValueChanged(object sender, DataGridViewCellEventArgs e) // При изменении значения ячейки
        {
            if (currentCell == 1)
            {
                int count = Convert.ToInt32(dgvNewSale.Rows[currentRow].Cells[1].Value);
                int price = Convert.ToInt32(dgvNewSale.Rows[currentRow].Cells[2].Value);
                int sum = 0;

                if (count == 0)
                {
                    dgvNewSale.Rows[currentRow].Cells[1].Value = 1;
                    count = 1;
                }

                dgvNewSale.Rows[currentRow].Cells[3].Value = count * price;

                for (int i = 0; i < dgvNewSale.RowCount; i++)
                {
                    sum += Convert.ToInt32(dgvNewSale.Rows[i].Cells[3].Value);
                }

                txtTotal.Text = sum.ToString("#,##0.00");
            }
        }

        private void dgvNewSale_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvNewSale.CurrentCell.ColumnIndex == 1)
            {
                const string disallowed = @"[^0-9]";
                var newText = Regex.Replace(e.FormattedValue.ToString(), disallowed, string.Empty);
                dgvNewSale.Rows[e.RowIndex].ErrorText = "";
                if (dgvNewSale.Rows[e.RowIndex].IsNewRow)
                {
                    return;
                }
                if (string.CompareOrdinal(e.FormattedValue.ToString(), newText) == 0)
                {
                    return;
                }
                e.Cancel = true;
                dgvNewSale.Rows[e.RowIndex].ErrorText = "Некорректный символ!";
            }
        }
    }
}
