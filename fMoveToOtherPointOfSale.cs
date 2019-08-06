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
    public partial class fMoveToOtherPointOfSale : Form
    {
        public fMoveToOtherPointOfSale()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }

        private string cmdText(string where) // Запрос на вывод данных в таблицу
        {
            string cmdText = "SELECT " +
                                "Перемещение.ID, " +
                                "Перемещение.Дата, " +
                                "Товар.Наименование, " +
                                "Перемещение.Количество, " +
                                "(SELECT Точка FROM ТорговаяТочка WHERE ID = Перемещение.ТочкаID1) AS ИзТочки, " +
                                "(SELECT Точка FROM ТорговаяТочка WHERE ID = Перемещение.ТочкаID2) AS НаТочку " +
                             "FROM Товар INNER JOIN Перемещение ON Товар.ID = Перемещение.ТоварID " + 
                             where;
            return cmdText;
        }

        public static string cmdTextFrom(string where)
        {
            string cmd = "SELECT " +
                "Товар.ID, " +
                "Товар.Наименование, " +
                "Товар.ЕдИзм, " +
                "Склад.Количество, " +
                "Last(ПрайсЛист.ЦенаЗакупки) AS ЦенаЗакупки1, " +
                "Last(ПрайсЛист.ЦенаПродажи) AS ЦенаПродажи1, " +
                "[ЦенаЗакупки1]*[Количество] AS СуммаЗакупки, " +
                "[ЦенаПродажи1]*[Количество] AS СуммаПродажи, " +
                "ГруппаТовара.Группа, " +
                "ТорговаяТочка.Точка" +
                " FROM ТорговаяТочка INNER JOIN(((ГруппаТовара INNER JOIN Товар ON ГруппаТовара.ID = Товар.ГруппаID) INNER JOIN ПрайсЛист ON Товар.ID = ПрайсЛист.ТоварID) INNER JOIN Склад ON Товар.ID = Склад.ТоварID) ON ТорговаяТочка.ID = Склад.ТочкаID " +
                where +
                " GROUP BY Товар.Наименование, Товар.ID, Товар.ЕдИзм, Склад.Количество, Товар.ГруппаID, Склад.ТочкаID, ГруппаТовара.Группа, ТорговаяТочка.Точка" +
                " HAVING(((Склад.Количество) > 0))";
            return cmd;
        }

        bool isLoad = false;
        private void fMoveToOtherPointOfSale_Load(object sender, EventArgs e) // Загрузка окна
        {
            workWithDB.fillCombobox(cbxFromPointOfSale, "Точка", "ID", "SELECT ID, Точка FROM ТорговаяТочка");
            workWithDB.fillCombobox(cbxToPointOfSale, "Точка", "ID", "SELECT ID, Точка FROM ТорговаяТочка");
            workWithDB.fillCombobox(cbxFromPOS, "Точка", "ID", "SELECT ID, Точка FROM ТорговаяТочка");
            workWithDB.fillCombobox(cbxToPOS, "Точка", "ID", "SELECT ID, Точка FROM ТорговаяТочка");

            workWithDB.fillDGV(cmdTextFrom($"WHERE ТорговаяТочка.ID = {cbxFromPointOfSale.SelectedValue}"), dgvFrom);

            // Видимость столбцов
            dgvFrom.Columns[8].Visible = false; // Скрывает 9 столбец
            dgvFrom.Columns[9].Visible = false; // Скрывает 10 столбец

            // Ширина столбцов
            dgvFrom.Columns[0].Width = 40;
            dgvFrom.Columns[1].Width = 250;
            dgvFrom.Columns[2].Width = 45;
            dgvFrom.Columns[4].Width = 100;
            dgvFrom.Columns[5].Width = 100;
            dgvFrom.Columns[6].Width = 100;
            dgvFrom.Columns[7].Width = 100;
            //dgvFrom.Columns[10].Width = 100;
            //dgvFrom.Columns[11].Width = 200;

            // Заголовки столбцов
            dgvFrom.Columns[1].HeaderText = "Наименование товара";
            dgvFrom.Columns[2].HeaderText = "Ед. изм.";
            dgvFrom.Columns[4].HeaderText = "Цена закупки, руб.";
            dgvFrom.Columns[4].DefaultCellStyle.Format = "N2";
            dgvFrom.Columns[5].HeaderText = "Цена продажи, руб.";
            dgvFrom.Columns[5].DefaultCellStyle.Format = "N2";
            dgvFrom.Columns[6].HeaderText = "Сумма закупки, руб.";
            dgvFrom.Columns[6].DefaultCellStyle.Format = "N2";
            dgvFrom.Columns[7].HeaderText = "Сумма продажи, руб.";
            dgvFrom.Columns[7].DefaultCellStyle.Format = "N2";
            //dgvFrom.Columns[10].HeaderText = "Группа товара";
            //dgvFrom.Columns[11].HeaderText = "Точка продаж";

            workWithDB.fillDGV(cmdText(""), dgvTo);

            // Видимость столбцов
            dgvTo.Columns[0].Visible = false; // Скрывает 1 столбец

            // Ширина столбцов
            dgvTo.Columns[2].Width = 300;
            dgvTo.Columns[3].Width = 80;
            dgvTo.Columns[4].Width = 170;
            dgvTo.Columns[5].Width = 170;

            // Заголовки столбцов
            dgvTo.Columns[2].HeaderText = "Наименование товара";
            dgvTo.Columns[4].HeaderText = "Из точки";
            dgvTo.Columns[5].HeaderText = "На точку";

            isLoad = true;
        }

        private void btnTransfer_Click(object sender, EventArgs e) // Переместить товар (СДЕЛАТЬ)
        {
            DateTimePicker dtp = new DateTimePicker();
            dtp.Value = DateTime.Now;

            if (cbxFromPointOfSale.Text == cbxToPointOfSale.Text)
            {
                MessageBox.Show("Начальная и конечная точки совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Перенести выбранный товар на другую точку?", "Перенос товара", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workWithDB.actionDB($"INSERT INTO Перемещение (ТоварID, ТочкаID1, ТочкаID2, Дата, Количество) " +
                        $"VALUES({dgvFrom.CurrentRow.Cells[0].Value}, {cbxFromPointOfSale.SelectedValue}, {cbxToPointOfSale.SelectedValue}, " +
                        $"{ManyIF.convDate(dtp)}, {nudCount.Value})");

                    if (workWithDB.getLastID($"SELECT ТоварID FROM Склад " +
                        $"WHERE ТоварID = {dgvFrom.CurrentRow.Cells[0].Value} AND ТочкаID = {cbxToPointOfSale.SelectedValue}") == null)
                    {
                        // Вставляем новую строку если похожего нет в таблице
                        workWithDB.actionDB($"INSERT INTO Склад (ТоварID, ТочкаID, Количество) " +
                            $"VALUES({dgvFrom.CurrentRow.Cells[0].Value}, {cbxToPointOfSale.SelectedValue}, {nudCount.Value})");

                        // Отнимаем из прошлой точки
                        workWithDB.actionDB($"UPDATE Склад SET Количество = Количество - {nudCount.Value} " +
                        $"WHERE ТоварID = {dgvFrom.CurrentRow.Cells[0].Value} AND ТочкаID = {cbxFromPointOfSale.SelectedValue}");
                    }
                    else
                    {
                        // Отнимаем из прошлой точки и прибавляем в новую точку
                        workWithDB.actionDB($"UPDATE Склад SET Количество = Количество - {nudCount.Value} " +
                        $"WHERE ТоварID = {dgvFrom.CurrentRow.Cells[0].Value} AND ТочкаID = {cbxFromPointOfSale.SelectedValue}");
                        workWithDB.actionDB($"UPDATE Склад SET Количество = Количество + {nudCount.Value} " +
                            $"WHERE ТоварID = {dgvFrom.CurrentRow.Cells[0].Value} AND ТочкаID = {cbxToPointOfSale.SelectedValue}");
                    }

                    workWithDB.fillDGV(cmdText(""), dgvTo);
                    workWithDB.fillDGV(cmdTextFrom($"WHERE ТорговаяТочка.ID = {cbxFromPointOfSale.SelectedValue}"), dgvFrom);
                }
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
                workWithDB.fillDGV(cmdText(ManyIF.whereForMTOPOS(cbStart.Checked, cbEnd.Checked, cbFromPointOfSale.Checked, cbToPointOfSale.Checked,
                    dtpStart, dtpEnd, cbxFromPOS, cbxToPOS)), dgvTo);
            }
        }

        private void cbEnd_CheckedChanged(object sender, EventArgs e) // До какой даты
        {
            days = (int)(dtpEnd.Value - dtpStart.Value).TotalDays;

            if (dtpStart.Value > dtpEnd.Value && days >= 1)
            {
                MessageBox.Show("dtpStart = " + dtpStart.Value + "\ndtpEnd = " + dtpEnd.Value +
                    "\nРед.дата старт = " + ManyIF.convDate(dtpStart) + "\nРед.дата = " + ManyIF.convDate(dtpEnd), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                workWithDB.fillDGV(cmdText(ManyIF.whereForMTOPOS(cbStart.Checked, cbEnd.Checked, cbFromPointOfSale.Checked, cbToPointOfSale.Checked,
                    dtpStart, dtpEnd, cbxFromPOS, cbxToPOS)), dgvTo);
            }
        }

        private void cbFromPointOfSale_CheckedChanged(object sender, EventArgs e) // Из точки продаж(checkbox)
        {
            workWithDB.fillDGV(cmdText(ManyIF.whereForMTOPOS(cbStart.Checked, cbEnd.Checked, cbFromPointOfSale.Checked, cbToPointOfSale.Checked,
                    dtpStart, dtpEnd, cbxFromPOS, cbxToPOS)), dgvTo);
        }

        private void cbToPointOfSale_CheckedChanged(object sender, EventArgs e) // На точку продаж(checkbox)
        {
            workWithDB.fillDGV(cmdText(ManyIF.whereForMTOPOS(cbStart.Checked, cbEnd.Checked, cbFromPointOfSale.Checked, cbToPointOfSale.Checked,
                    dtpStart, dtpEnd, cbxFromPOS, cbxToPOS)), dgvTo);
        }

        private void cbxFromPOS_SelectedValueChanged(object sender, EventArgs e) // Из точки продаж(combobox)
        {
            workWithDB.fillDGV(cmdText(ManyIF.whereForMTOPOS(cbStart.Checked, cbEnd.Checked, cbFromPointOfSale.Checked, cbToPointOfSale.Checked,
                    dtpStart, dtpEnd, cbxFromPOS, cbxToPOS)), dgvTo);
        }

        private void cbxToPOS_SelectedValueChanged(object sender, EventArgs e) // На точку продаж(combobox)
        {
            workWithDB.fillDGV(cmdText(ManyIF.whereForMTOPOS(cbStart.Checked, cbEnd.Checked, cbFromPointOfSale.Checked, cbToPointOfSale.Checked,
                    dtpStart, dtpEnd, cbxFromPOS, cbxToPOS)), dgvTo);
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e) // Изменение начальной даты
        {
            days = (int)(dtpEnd.Value - dtpStart.Value).TotalDays;

            if (dtpStart.Value > dtpEnd.Value && days >= 1)
            {
                MessageBox.Show("dtpStart = " + dtpStart.Value + "\ndtpEnd = " + dtpEnd.Value +
                    "\nРед.дата старт = " + ManyIF.convDate(dtpStart) + "\nРед.дата = " + ManyIF.convDate(dtpEnd), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                workWithDB.fillDGV(cmdText(ManyIF.whereForMTOPOS(cbStart.Checked, cbEnd.Checked, cbFromPointOfSale.Checked, cbToPointOfSale.Checked,
                    dtpStart, dtpEnd, cbxFromPOS, cbxToPOS)), dgvTo);
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e) // Изменение конечной даты
        {
            days = (int)(dtpEnd.Value - dtpStart.Value).TotalDays;

            if (dtpStart.Value > dtpEnd.Value && days >= 1)
            {
                MessageBox.Show("dtpStart = " + dtpStart.Value + "\ndtpEnd = " + dtpEnd.Value +
                    "\nРед.дата старт = " + ManyIF.convDate(dtpStart) + "\nРед.дата = " + ManyIF.convDate(dtpEnd), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                workWithDB.fillDGV(cmdText(ManyIF.whereForMTOPOS(cbStart.Checked, cbEnd.Checked, cbFromPointOfSale.Checked, cbToPointOfSale.Checked,
                    dtpStart, dtpEnd, cbxFromPOS, cbxToPOS)), dgvTo);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e) // Печать
        {
            workWithDB.fillDGV($"SELECT Товар.Наименование, Товар.ID, Товар.ЕдИзм, Перемещение.Количество, ПрайсЛист.ЦенаЗакупки, (ПрайсЛист.ЦенаЗакупки * Перемещение.Количество) AS Сумма " +
                $"FROM (Товар INNER JOIN Перемещение ON Товар.ID = Перемещение.ТоварID) INNER JOIN ПрайсЛист ON Товар.ID = ПрайсЛист.ТоварID " +
                $"WHERE ПрайсЛист.ЦенаЗакупки = (SELECT ПрайсЛист.ЦенаЗакупки FROM ПрайсЛист WHERE (ПрайсЛист.Дата) = " +
                $"(SELECT MAX(Дата) FROM ПрайсЛист П WHERE П.ТоварID = ПрайсЛист.ТоварID) AND (ПрайсЛист.ТоварID = Товар.ID))", dgvToCopy);

            string[] columns =
            {
                "min date", "max date", "glav buh", "pokupatel", "INN / KPP pokupatela", "prodavec", "INN / KPP prodavca",
                "rekvizity", "rekvizity kompanii", "FIO manager", "nomer operacii", "dannie prodavca", "kol-vo zapisei",
                "dannie kontragenta", "avtosalon", "FIO manager", "nachalo", "konec", "dannie prodavca", "rekvizity prodavca",
                "dannie kontagenta", "rekvizity kontragenta", "FIO kassir", workWithDB.getLastID("SELECT Наименование FROM Реквизиты"), "iz avtosalona", "v avtosalon"
            };

            print.ExportToExcel(this, dgvToCopy, 17, 1, "ТОРГ-13 (Перемещение).xlsx", true, columns);

            dgvToCopy.DataSource = null;
        }

        private void cbxFromPointOfSale_SelectedValueChanged(object sender, EventArgs e) // При изменении
        {
            if (isLoad == true) // После загрузки окна, происходит выборка по условию
            {
                workWithDB.fillDGV(cmdTextFrom($"WHERE ТорговаяТочка.ID = {cbxFromPointOfSale.SelectedValue}"), dgvFrom);
            }
        }
    }
}
