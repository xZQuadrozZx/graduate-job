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
    public partial class fBookPurchaseAndSales : Form
    {
        public fBookPurchaseAndSales()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }

        private string cmdText(string having)
        {
            string cmd = "SELECT Операция.ID, Операция.Дата, SUM(СоставОперации.Количество * СоставОперации.Цена) AS Сумма, " +
                "Операция.КонтрагентID, Операция.ТочкаID, Операция.МенеджерID, Операция.КассирID, Операция.Закупка " +
                "FROM Операция INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID " + 
                "GROUP BY Операция.ID, Операция.Дата, Операция.КонтрагентID, Операция.ТочкаID, Операция.МенеджерID, Операция.КассирID, Операция.Закупка " +
                having;

            return cmd;
        }

        private void fullDGV()
        {
            try
            {
                DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn date = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn sum = new DataGridViewTextBoxColumn();

                DataGridViewComboBoxColumn partner = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn point = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn manager = new DataGridViewComboBoxColumn();
                DataGridViewComboBoxColumn cashier = new DataGridViewComboBoxColumn();

                DataGridViewCheckBoxColumn purchase = new DataGridViewCheckBoxColumn();

                workWithDB.fillDGVTextBox(dgvBookPurchaseAndSales, "SELECT ID FROM Операция", id, "ID", "Код");
                workWithDB.fillDGVTextBox(dgvBookPurchaseAndSales, "SELECT Дата FROM Операция", date, "Дата", "Дата");
                workWithDB.fillDGVTextBox(dgvBookPurchaseAndSales, "SELECT SUM(Количество * Цена) AS Сумма FROM СоставОперации", sum, "Сумма", "Сумма, руб.");
                workWithDB.fillDGVComboBox(dgvBookPurchaseAndSales, "SELECT ID, ФИО_Наименование FROM Контрагент", partner, "КонтрагентID", "Контрагент", "ФИО_Наименование", "ID");
                workWithDB.fillDGVComboBox(dgvBookPurchaseAndSales, "SELECT ID, Точка FROM ТорговаяТочка", point, "ТочкаID", "Точка продаж", "Точка", "ID");
                workWithDB.fillDGVComboBox(dgvBookPurchaseAndSales, "SELECT ТабN, ФИО FROM Работник WHERE ДолжностьID = 2", manager, "МенеджерID", "Менеджер", "ФИО", "ТабN");
                workWithDB.fillDGVComboBox(dgvBookPurchaseAndSales, "SELECT ТабN, ФИО FROM Работник WHERE ДолжностьID = 3", cashier, "КассирID", "Кассир", "ФИО", "ТабN");
                workWithDB.fillDGVTextBox(dgvBookPurchaseAndSales, "SELECT Закупка FROM Операция", purchase, "Закупка", "Закупка");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void fBookPurchaseAndSales_Load(object sender, EventArgs e) // Загрузка окна
        {
            workWithDB.fillCombobox(cbxManager, "ФИО", "ТабN", "SELECT ТабN, ФИО FROM Работник WHERE ДолжностьID = 2");
            workWithDB.fillCombobox(cbxCashier, "ФИО", "ТабN", "SELECT ТабN, ФИО FROM Работник WHERE ДолжностьID = 3");
            workWithDB.fillCombobox(cbxPartner, "ФИО_Наименование", "ID", "SELECT ID, ФИО_Наименование FROM Контрагент");
            workWithDB.fillCombobox(cbxPointOfSale, "Точка", "ID", "SELECT ID, Точка FROM ТорговаяТочка");

            fullDGV();

            workWithDB.fillDGV(cmdText(""), dgvBookPurchaseAndSales);

            //***Изменение заголовков столбцов***//
            dgvBookPurchaseAndSales.Columns[0].Visible = false;
            dgvBookPurchaseAndSales.Columns[1].Visible = false;
            dgvBookPurchaseAndSales.Columns[2].Visible = false;
            dgvBookPurchaseAndSales.Columns[3].Visible = false;
            dgvBookPurchaseAndSales.Columns[4].Visible = false;
            dgvBookPurchaseAndSales.Columns[5].Visible = false;
            dgvBookPurchaseAndSales.Columns[6].Visible = false;
            dgvBookPurchaseAndSales.Columns[7].Visible = false;

            dgvBookPurchaseAndSales.Columns[8].Width = 50;
            dgvBookPurchaseAndSales.Columns[9].Width = 90;
            dgvBookPurchaseAndSales.Columns[10].Width = 90;
            dgvBookPurchaseAndSales.Columns[10].DefaultCellStyle.Format = "N2";
            dgvBookPurchaseAndSales.Columns[11].Width = 200;
            dgvBookPurchaseAndSales.Columns[12].Width = 190;
            dgvBookPurchaseAndSales.Columns[13].Width = 200;
            dgvBookPurchaseAndSales.Columns[14].Width = 200;
            dgvBookPurchaseAndSales.Columns[15].Width = 60;
            //***********************************//
        }

        private void btnPrint_Click(object sender, EventArgs e) // Печать
        {
            string max = workWithDB.getLastID($"SELECT MAX(Дата) FROM Операция");
            string maxDate = max.Replace("0:00:00", "");
            string min = workWithDB.getLastID($"SELECT MIN(Дата) FROM Операция");
            string minDate = min.Replace("0:00:00", "");
            string glavBuh = workWithDB.getLastID("SELECT ГлавБух FROM Реквизиты");
            string nameCompany = workWithDB.getLastID("SELECT Наименование FROM Реквизиты");
            string INNKPP = workWithDB.getLastID("SELECT ИНН FROM Реквизиты") + " / " + workWithDB.getLastID("SELECT КПП FROM Реквизиты");

            string[] columns =
            {
                minDate, maxDate, glavBuh, "pokupatel", INNKPP, "prodavec", "INN / KPP prodavca",
                "dannie kompanii", "rekvizity kompanii", "FIO manager", "nomer operacii", "dannie prodavca", "kol-vo zapisei",
                "dannie kontragenta", "avtosalon", "FIO manager", "nachalo", "konec", "dannie prodavca", "rekvizity prodavca",
                "dannie kontagenta", "rekvizity kontragenta", "FIO kassir", nameCompany, "iz avtosalona", "v avtosalon"
            };

            if (rbBookPurchase.Checked == true) // Книга покупок
            {
                workWithDB.fillDGV($"SELECT Операция.ID, Операция.Дата, Операция.Дата, Операция.Дата, Контрагент.ФИО_Наименование, " +
                $"Контрагент.ИНН, Контрагент.КПП, SUM(СоставОперации.Количество * СоставОперации.Цена) AS ВсегоПокупок, (ВсегоПокупок - (ВсегоПокупок*18/100)) AS БезНДС, (ВсегоПокупок - БезНДС) AS СуммаНДС " +
                $"FROM ТорговаяТочка INNER JOIN (Работник INNER JOIN ((Контрагент INNER JOIN Операция ON Контрагент.ID = Операция.КонтрагентID) " +
                $"INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID) ON Работник.ТабN = Операция.МенеджерID) ON ТорговаяТочка.ID = Операция.ТочкаID " +
                $"GROUP BY Операция.ID, Операция.Дата, Операция.Дата, Операция.Дата, Контрагент.ФИО_Наименование, Контрагент.ИНН, " +
                $"Контрагент.КПП, Операция.Закупка " +
                $"HAVING Операция.Закупка = True", dgvPrint);

                print.ExportToExcel(this, dgvPrint, 15, 1, "Книга покупок.xlsx", true, columns);
                dgvPrint.DataSource = null;
            }
            else if (rbBookSales.Checked == true) // Книга продаж
            {
                workWithDB.fillDGV($"SELECT Операция.ID, Операция.Дата, Контрагент.ФИО_Наименование, Контрагент.ИНН, Контрагент.КПП, Операция.Дата, " +
                    $"SUM(СоставОперации.Количество*СоставОперации.Цена) AS ВсегоПродаж, (ВсегоПродаж-(ВсегоПродаж*18/100)) AS БезНДС, (ВсегоПродаж-БезНДС) AS СуммаНДС " +
                    $"FROM (Контрагент INNER JOIN Операция ON Контрагент.ID = Операция.КонтрагентID) INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID " +
                    $"GROUP BY Операция.ID, Операция.Дата, Контрагент.ФИО_Наименование, Контрагент.ИНН, Контрагент.КПП, Операция.Дата, Операция.Закупка " +
                    $"HAVING (((Операция.Закупка) = False))", dgvPrint);

                print.ExportToExcel(this, dgvPrint, 15, 1, "Книга продаж.xlsx", true, columns);
                dgvPrint.DataSource = null;
            }
        }

        #region Фальшивый DataGridView
        // Редактирование колонок
        private void GetNewColumns(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Товар";
            dgv.Columns[0].Width = 350;
            dgv.Columns[1].HeaderText = "Количество";
            dgv.Columns[2].HeaderText = "Цена, руб.";
            dgv.Columns[3].HeaderText = "Сумма, руб.";
        }

        // Заполнение расхода
        private void GetFillField(bool isPurchase, string code, string date, string total, object partner, object POS, object manager, object cashier)
        {
            string cmdText = $"SELECT Товар.Наименование, СоставОперации.Количество, СоставОперации.Цена, " +
                    $"(СоставОперации.Цена * СоставОперации.Количество) AS Сумма " +
                    $"FROM Товар INNER JOIN ((Контрагент INNER JOIN Операция ON Контрагент.ID = Операция.КонтрагентID) INNER JOIN " +
                    $"СоставОперации ON Операция.ID = СоставОперации.ОперацияID) ON Товар.ID = СоставОперации.ТоварID " +
                    $"WHERE СоставОперации.ОперацияID = {code}";

            if (isPurchase == true) // Покупка
            {
                fNewPurchase fNP = new fNewPurchase();
                fNP.Show();

                // Заполнить
                fNP.txtCode.Text = code;                         // Код операции
                fNP.txtDate.Text = date.Replace(" 0:00:00", ""); // Дата
                fNP.txtTotal.Text = total;                       // ИТОГО
                fNP.cbxCashier.SelectedValue = cashier;          // Кассир
                fNP.cbxManager.SelectedValue = manager;          // Менеджер
                fNP.cbxPartner.SelectedValue = partner;          // Контрагент
                fNP.cbxPointOfSale.SelectedValue = POS;          // Точка продаж
                fNP.btnSpend.Visible = false;                    // Кнопка "Провести"

                // Заблокировать
                fNP.txtCode.Enabled = false;          // Код операции
                fNP.txtDate.Enabled = false;          // Дата
                fNP.txtTotal.Enabled = false;         // ИТОГО
                fNP.cbxCashier.Enabled = false;       // Кассир
                fNP.cbxManager.Enabled = false;       // Менеджер
                fNP.cbxPartner.Enabled = false;       // Контрагент
                fNP.cbxPointOfSale.Enabled = false;   // Точка продаж

                // Заполнение таблицы
                fNP.dgvRashod.Visible = true;
                workWithDB.fillDGV(cmdText, fNP.dgvRashod);
                GetNewColumns(fNP.dgvRashod);
            }
            else if (isPurchase == false) // Продажа
            {
                fNewSale fNS = new fNewSale();
                fNS.Show();

                // Заполнить
                fNS.txtCode.Text = code;                         // Код операции
                fNS.txtDate.Text = date.Replace(" 0:00:00", ""); // Дата
                fNS.txtTotal.Text = total;                       // ИТОГО
                fNS.cbxCashier.SelectedValue = cashier;          // Кассир
                fNS.cbxManager.SelectedValue = manager;          // Менеджер
                fNS.cbxPartner.SelectedValue = partner;          // Контрагент
                fNS.cbxPointOfSale.SelectedValue = POS;          // Точка продаж
                fNS.btnSpend.Visible = false;                    // Кнопка "Провести"

                // Заблокировать
                fNS.txtCode.Enabled = false;          // Код операции
                fNS.txtDate.Enabled = false;          // Дата
                fNS.txtTotal.Enabled = false;         // ИТОГО
                fNS.cbxCashier.Enabled = false;       // Кассир
                fNS.cbxManager.Enabled = false;       // Менеджер
                fNS.cbxPartner.Enabled = false;       // Контрагент
                fNS.cbxPointOfSale.Enabled = false;   // Точка продаж

                // Заполнение таблицы
                fNS.dgvRashod.Visible = true;
                workWithDB.fillDGV(cmdText, fNS.dgvRashod);
                GetNewColumns(fNS.dgvRashod);
            }
        }
        #endregion

        private void btnOpenExpense_Click(object sender, EventArgs e) // Открыть расход
        {
            try
            {
                if (rbBookPurchase.Checked == true) // Покупка
                {
                    GetFillField(true, dgvBookPurchaseAndSales.CurrentRow.Cells[8].Value.ToString(),
                        dgvBookPurchaseAndSales.CurrentRow.Cells[9].Value.ToString(),
                        dgvBookPurchaseAndSales.CurrentRow.Cells[10].Value.ToString(),
                        dgvBookPurchaseAndSales.CurrentRow.Cells[11].Value,
                        dgvBookPurchaseAndSales.CurrentRow.Cells[12].Value,
                        dgvBookPurchaseAndSales.CurrentRow.Cells[13].Value,
                        dgvBookPurchaseAndSales.CurrentRow.Cells[14].Value);
                }
                else if (rbBookSales.Checked == true) // Продажа
                {
                    GetFillField(false, dgvBookPurchaseAndSales.CurrentRow.Cells[8].Value.ToString(),
                        dgvBookPurchaseAndSales.CurrentRow.Cells[9].Value.ToString(),
                        dgvBookPurchaseAndSales.CurrentRow.Cells[10].Value.ToString(),
                        dgvBookPurchaseAndSales.CurrentRow.Cells[11].Value,
                        dgvBookPurchaseAndSales.CurrentRow.Cells[12].Value,
                        dgvBookPurchaseAndSales.CurrentRow.Cells[13].Value,
                        dgvBookPurchaseAndSales.CurrentRow.Cells[14].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int days;

        private void cbStart_CheckedChanged(object sender, EventArgs e) // С какой даты
        {
            days = (int)(dtpEnd.Value - dtpStart.Value).TotalDays;

            if (dtpStart.Value > dtpEnd.Value && days >= 1)
            {
                MessageBox.Show("dtpStart = " + dtpStart.Value + "\ndtpEnd = " + dtpEnd.Value +
                    "\nРед.дата старт = " + ManyIF.convDate(dtpStart) + "\nРед.дата = " + ManyIF.convDate(dtpEnd), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //fullDGV();

                workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                    cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                    cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
            }
        }

        private void cbEnd_CheckedChanged(object sender, EventArgs e) // По какую дату
        {
            days = (int)(dtpEnd.Value - dtpStart.Value).TotalDays;

            if (dtpStart.Value > dtpEnd.Value && days >=1)
            {
                MessageBox.Show("dtpStart = " + dtpStart.Value + "\ndtpEnd = " + dtpEnd.Value +
                    "\nРед.дата старт = " + ManyIF.convDate(dtpStart) + "\nРед.дата = " + ManyIF.convDate(dtpEnd), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                    cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                    cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
            }
        }

        private void cbPointOfSale_CheckedChanged(object sender, EventArgs e) // Точка продаж
        {
            workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
        }

        private void cbPartner_CheckedChanged(object sender, EventArgs e) // Контрагент
        {
            workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e) // С какой даты
        {
            days = (int)(dtpEnd.Value - dtpStart.Value).TotalDays;

            if (dtpStart.Value > dtpEnd.Value && days >= 1)
            {
                MessageBox.Show("dtpStart = " + dtpStart.Value + "\ndtpEnd = " + dtpEnd.Value +
                    "\nРед.дата старт = " + ManyIF.convDate(dtpStart) + "\nРед.дата = " + ManyIF.convDate(dtpEnd), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                    cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                    cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e) // По какую дату
        {
            days = (int)(dtpEnd.Value - dtpStart.Value).TotalDays;

            if (dtpStart.Value > dtpEnd.Value && days >= 1)
            {
                MessageBox.Show("dtpStart = " + dtpStart.Value + "\ndtpEnd = " + dtpEnd.Value +
                    "\nРед.дата старт = " + ManyIF.convDate(dtpStart) + "\nРед.дата = " + ManyIF.convDate(dtpEnd), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                    cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                    cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
            }
        }

        private void cbxPointOfSale_SelectedValueChanged(object sender, EventArgs e) // Точка продаж
        {
            workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
        }

        private void cbxPartner_SelectedValueChanged(object sender, EventArgs e) // Контрагент
        {
            workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
        }

        private void cbxManager_SelectedValueChanged(object sender, EventArgs e) // Менеджер
        {
            workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
        }

        private void cbxCashier_SelectedValueChanged(object sender, EventArgs e) // Кассир
        {
            workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
        }

        private void cbManager_CheckedChanged(object sender, EventArgs e) // Менеджер
        {
            workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
        }

        private void cbCashier_CheckedChanged(object sender, EventArgs e) // Кассир
        {
            workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
        }

        private void rbBookSales_CheckedChanged(object sender, EventArgs e) // Продажи
        {
            workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
        }

        private void rbBookPurchase_CheckedChanged(object sender, EventArgs e) // Закупки
        {
            workWithDB.fillDGV(cmdText(ManyIF.where(cbStart.Checked, cbEnd.Checked, cbCashier.Checked, cbManager.Checked,
                cbPartner.Checked, cbPointOfSale.Checked, rbBookSales.Checked, rbBookPurchase.Checked, dtpStart, dtpEnd,
                cbxCashier, cbxManager, cbxPartner, cbxPointOfSale, rbBookSales, rbBookPurchase)), dgvBookPurchaseAndSales);
        }

        private void dgvBookPurchaseAndSales_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnOpenExpense_Click(sender, e);
        }
    }
}
