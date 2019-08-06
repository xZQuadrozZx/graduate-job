using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MotorAuto
{
    public partial class fNewPurchase : Form
    {
        public fNewPurchase()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }

        private int lastID;

        private void fNewPurchase_Load(object sender, EventArgs e) // При загрузки формы
        {
            dgvNewPurchase.Columns[2].DefaultCellStyle.Format = "N2";
            dgvNewPurchase.Columns[3].DefaultCellStyle.Format = "N2";

            cbxManager.Enabled = false;
            if (fStartMenu.roleUser == "Администратор")
            {
                cbxManager.Enabled = true;
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

            //***Поиск менеджера который находится в данной сессии***//
            int index = cbxManager.FindString(fStartMenu.userName);
            cbxManager.SelectedIndex = index;
            //*******************************************************//
            //***Последний элемент в БД***//
            lastID = Convert.ToInt32(workWithDB.getLastID("SELECT MAX(ID) FROM Операция")) + 1;
            txtCode.Text = lastID.ToString();
            //****************************//

            dgvNewPurchase.CurrentCell = dgvNewPurchase.Rows[0].Cells[0];
        }

        private void btnSpend_Click(object sender, EventArgs e) // Провести операцию
        {
            if (cbxPointOfSale.Text == string.Empty || cbxPartner.Text == string.Empty || cbxManager.Text == string.Empty || cbxCashier.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля перед проведением операции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Проверка на пустой DataGridView
                if (dgvNewPurchase.RowCount == 1)
                {
                    MessageBox.Show("Введите наименование товара и его количество!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DateTimePicker dtp = new DateTimePicker();
                    DateTime dt = Convert.ToDateTime(txtDate.Text);
                    dtp.Value = dt;

                    workWithDB.actionDB($"INSERT INTO Операция (ID, Дата, Закупка, КонтрагентID, ТочкаID, МенеджерID, КассирID) " +
                        $"VALUES({txtCode.Text}, {ManyIF.convDate(dtp)}, True, " +
                            $"{cbxPartner.SelectedValue.ToString()}, " +
                            $"{cbxPointOfSale.SelectedValue.ToString()}, " +
                            $"{cbxManager.SelectedValue.ToString()}, " +
                            $"{cbxCashier.SelectedValue.ToString()})");

                    string idName;
                    string priceSale;

                    // Заполнение таблицы СоставОперации
                    for (int i = 0; i < dgvNewPurchase.RowCount - 1; i++)
                    {
                        idName = workWithDB.getLastID($"SELECT ID FROM Товар WHERE Наименование = '{dgvNewPurchase.Rows[i].Cells[0].Value.ToString()}'");
                        priceSale = workWithDB.getLastID($"SELECT ПрайсЛист.ЦенаЗакупки FROM ПрайсЛист " +
                            $"WHERE ПрайсЛист.Дата = (SELECT MAX(Дата) FROM ПрайсЛист П WHERE П.ТоварID = ПрайсЛист.ТоварID AND ПрайсЛист.ТоварID = {idName})");

                        workWithDB.actionDB($"INSERT INTO СоставОперации (ОперацияID, ТоварID, Количество, Цена) " +
                            $"VALUES({txtCode.Text}, {idName}, {dgvNewPurchase.Rows[i].Cells[1].Value}, {dgvNewPurchase.Rows[i].Cells[2].Value})");

                        if (workWithDB.getLastID($"SELECT ТоварID FROM Склад " +
                            $"WHERE ТоварID = {idName} AND ТочкаID = {cbxPointOfSale.SelectedValue}") != idName)
                        {
                            // Вставляем новую строку если похожего нет в таблице
                            workWithDB.actionDB($"INSERT INTO Склад (ТоварID, ТочкаID, Количество) " +
                                $"VALUES({idName}, {cbxPointOfSale.SelectedValue.ToString()}, {dgvNewPurchase.Rows[i].Cells[1].Value.ToString()})");
                        }
                        else
                        {
                            workWithDB.actionDB($"UPDATE Склад SET Количество = Количество + {dgvNewPurchase.Rows[i].Cells[1].Value.ToString()} " +
                                $"WHERE ТоварID = {idName} AND ТочкаID = {cbxPointOfSale.SelectedValue}");
                        }
                    }
                }

                MessageBox.Show("Операция успешно выполнена", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void fNewPurchase_FormClosing(object sender, FormClosingEventArgs e) // Перед закрытием поля открываются
        {
            txtCode.Enabled = true;          // Код операции
            txtDate.Enabled = true;          // Дата
            txtTotal.Enabled = true;         // ИТОГО
            cbxCashier.Enabled = true;       // Кассир
            cbxManager.Enabled = true;       // Менеджер
            cbxPartner.Enabled = true;       // Контрагент
            cbxPointOfSale.Enabled = true;   // Точка продаж
            btnSpend.Visible = true;

            //dgvNewPurchaseCopy.Visible = false;
            //dgvNewPurchaseCopy.DataSource = null;
        }

        public int currentRow;
        public int currentCell;
        private void dgvNewPurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // Двойной щелчок по первому столбцу для перехода в прайс-лист
        {
            currentCell = dgvNewPurchase.CurrentCell.ColumnIndex; // Выбранный столбец
            currentRow = dgvNewPurchase.CurrentRow.Index; // Выбранная строка

            fPriceList fPrice = new fPriceList();

            if (currentCell == 0)
            {
                fPriceList.moveTo = true;
                fPrice.Show();
                fPriceList.isPurchase = true;
            }
            else
            {
                return;
            }
        }

        private void fNewPurchase_Activated(object sender, EventArgs e) // При активации формы
        {
            dgvNewPurchase.Rows[currentRow].Cells[0].Value = getValue.Name;
            dgvNewPurchase.Rows[currentRow].Cells[2].Value = getValue.Price;
        }

        private void dgvNewPurchase_CellValueChanged(object sender, DataGridViewCellEventArgs e) // При изменении значения ячейки
        {
            if (currentCell == 1)
            {
                int count = Convert.ToInt32(dgvNewPurchase.Rows[currentRow].Cells[1].Value);
                int price = Convert.ToInt32(dgvNewPurchase.Rows[currentRow].Cells[2].Value);
                int sum = 0;

                if (count == 0)
                {
                    dgvNewPurchase.Rows[currentRow].Cells[1].Value = 1;
                    count = 1;
                }

                dgvNewPurchase.Rows[currentRow].Cells[3].Value = count * price;

                for (int i = 0; i < dgvNewPurchase.RowCount; i++)
                {
                    sum += Convert.ToInt32(dgvNewPurchase.Rows[i].Cells[3].Value);
                }

                txtTotal.Text = sum.ToString("#,##0.00");
            }
        }

        private void dgvNewPurchase_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvNewPurchase.CurrentCell.ColumnIndex == 1)
            {
                const string disallowed = @"[^0-9]";
                var newText = Regex.Replace(e.FormattedValue.ToString(), disallowed, string.Empty);
                dgvNewPurchase.Rows[e.RowIndex].ErrorText = "";
                if (dgvNewPurchase.Rows[e.RowIndex].IsNewRow)
                {
                    return;
                }
                if (string.CompareOrdinal(e.FormattedValue.ToString(), newText) == 0)
                {
                    return;
                }
                e.Cancel = true;
                dgvNewPurchase.Rows[e.RowIndex].ErrorText = "Некорректный символ!";
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e) // Накладная печать
        {
            // Добавляем строки в таблицу
            for (int i = 0; i < dgvNewPurchase.RowCount - 1; i++)
            {
                dgvNewPurchaseCopy.Rows.Add();
            }

            // Удаляем и обновляем строки в таблице
            if (dgvNewPurchaseCopy.RowCount > dgvNewPurchase.RowCount)
            {
                dgvNewPurchaseCopy.Rows.Clear();
                dgvNewPurchaseCopy.Rows.Add(dgvNewPurchase.RowCount - 1);
            }

            string requisites = workWithDB.getLastID($"SELECT Наименование FROM Реквизиты");
            string requisitesCompany = " ИНН " + workWithDB.getLastID($"SELECT ИНН FROM Реквизиты") + 
                ", КПП " + workWithDB.getLastID($"SELECT КПП FROM Реквизиты") +
                ", Адрес: " + workWithDB.getLastID($"SELECT Адрес FROM Реквизиты") + ", Реквизиты: " +
                workWithDB.getLastID($"SELECT Реквизиты FROM Реквизиты");
            string dataSaler = workWithDB.getLastID($"SELECT ФИО_Наименование FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}");
            string requisitesSaler = " ИНН " + workWithDB.getLastID($"SELECT ИНН FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") +
                ", КПП " + workWithDB.getLastID($"SELECT КПП FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") + 
                ", Адрес: " + workWithDB.getLastID($"SELECT Адрес FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}") + 
                ", Реквизиты: " + workWithDB.getLastID($"SELECT Реквизиты FROM Контрагент WHERE ID = {cbxPartner.SelectedValue}");

            string[] columns =
            {
                "min date", "max date", workWithDB.getLastID("SELECT ГлавБух FROM Реквизиты"), "pokupatel", "INN / KPP pokupatela", "prodavec", "INN / KPP prodavca",
                requisites, requisitesCompany, cbxManager.Text, txtCode.Text, "dannie prodavca", "kol-vo zapisei",
                "dannie kontragenta", "avtosalon", cbxManager.Text, "nachalo", "konec", dataSaler, requisitesSaler,
                "dannie kontagenta", "rekvizity kontragenta", "FIO kassir", workWithDB.getLastID("SELECT Наименование FROM Реквизиты"), "iz avtosalona", "v avtosalon",
                "True"
            };

            // Заполняем и редактируем таблицу
            for (int i = 0; i < dgvNewPurchase.RowCount - 1; i++)
            {
                for (int j = 0; j < dgvNewPurchase.ColumnCount + 2; j++)
                {
                    if (j == 0)
                    {
                        dgvNewPurchaseCopy.Rows[i].Cells[j].Value = i + 1;
                    }
                    else if (j == 2)
                    {
                        dgvNewPurchaseCopy.Rows[i].Cells[j].Value = "шт.";
                    }
                    else if (j == 1)
                    {
                        dgvNewPurchaseCopy.Rows[i].Cells[j].Value = dgvNewPurchase.Rows[i].Cells[0].Value;
                    }
                    else if (j > 2)
                    {
                        dgvNewPurchaseCopy.Rows[i].Cells[j].Value = dgvNewPurchase.Rows[i].Cells[j - 2].Value;
                    }
                }
            }

            if (dgvNewPurchase.RowCount == 1)
            {
                MessageBox.Show("Таблица пустая, выводить на печать нечего", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                print.ExportToExcel(this, dgvNewPurchaseCopy, 10, 1, "Счет - Накладная.xlsx", true, columns);
            }
        }
    }
}
