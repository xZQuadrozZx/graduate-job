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
    public partial class fReportSales : Form
    {
        public fReportSales()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }


        string cmd;
        private string cmdText(bool salePOS, string where)
        {
            if (salePOS == true) // Если выбрано "Продажи по точкам продаж"
            {
                cmd = $"SELECT Операция.Дата, ТорговаяТочка.Точка, Операция.ТочкаID, SUM([Количество]*[Цена]) AS Выручка, SUM([Количество]*([Цена]-[ЦенаЗакупки])) AS ВалПрибыль " +
                    $"FROM ТорговаяТочка INNER JOIN (Операция INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID) ON ТорговаяТочка.ID = Операция.ТочкаID " +
                    $"WHERE (((Операция.Закупка) = False) AND ((Операция.Дата) >= {ManyIF.convDate(dtpStart)} AND (Операция.Дата) <= {ManyIF.convDate(dtpEnd)})) {where} " +
                    $"GROUP BY Операция.Дата, ТорговаяТочка.Точка, Операция.ТочкаID";
            }
            else if (salePOS == false) // Если выбрано "Продажи по менеджерам"
            {
                cmd = $"SELECT Операция.Дата, Работник.ФИО, Операция.МенеджерID, Работник.Процент, SUM([Количество]*[Цена]) AS Выручка, SUM([Процент]*[Количество]*[Цена]/100) AS Зарплата " +
                    $"FROM Работник INNER JOIN (Операция INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID) ON Работник.ТабN = Операция.МенеджерID " +
                    $"WHERE (((Операция.Закупка) = False) AND ((Операция.Дата) >= {ManyIF.convDate(dtpStart)} AND (Операция.Дата) <= {ManyIF.convDate(dtpEnd)})) {where} " +
                    $"GROUP BY Операция.Дата, Работник.ФИО, Операция.МенеджерID, Работник.Процент";
            }

            return cmd;
        }

        private void fReportSales_Load(object sender, EventArgs e) // При загрузке окна
        {
            cbSelectPointOfSale.Visible = true;
            cbxSelectPointOfSale.Visible = true;

            workWithDB.fillDTPMinDate(dtpStart);
            workWithDB.fillCombobox(cbxSelectPointOfSale, "Точка", "ID", "SELECT ID, Точка FROM ТорговаяТочка");
            workWithDB.fillCombobox(cbxManager, "ФИО", "ТабN", "SELECT ТабN, ФИО FROM Должность INNER JOIN Работник ON Должность.ID = Работник.ДолжностьID WHERE Работник.ДолжностьID = 2");

            if (cbxReport.Text == "Продажи по точкам продаж")
            {
                workWithDB.fillDGV(cmdText(true, $""), dgvReport);

                dgvReport.Columns[0].HeaderText = "Дата";
                dgvReport.Columns[1].HeaderText = "Точка продаж";
                dgvReport.Columns[3].HeaderText = "Выручка, руб.";
                dgvReport.Columns[4].HeaderText = "Валовая прибыль, руб.";

                cbxManager.Visible = false;
                cbManager.Visible = false;

                cbxSelectPointOfSale.Visible = true;
                cbSelectPointOfSale.Visible = true;
            }
            else if (cbxReport.Text == "Продажи по менеджерам")
            {
                workWithDB.fillDGV(cmdText(false, $""), dgvReport);

                dgvReport.Columns[0].HeaderText = "Дата";
                dgvReport.Columns[1].HeaderText = "ФИО менеджера";
                dgvReport.Columns[3].HeaderText = "Процент от продаж, %";
                dgvReport.Columns[4].HeaderText = "Выручка, руб.";
                dgvReport.Columns[5].HeaderText = "Премиальная часть, руб.";

                cbxManager.Visible = true;
                cbManager.Visible = true;

                cbxSelectPointOfSale.Visible = false;
                cbSelectPointOfSale.Visible = false;
            }

            cbxReport.SelectedIndex = 0;
            cbxSelectPointOfSale.SelectedIndex = 0;

            dgvReport.Columns[2].Visible = false; // Скрыть третий столбец
            dgvReport.Columns[0].Width = 80;
            dgvReport.Columns[1].Width = 180;
        }

        private void btnPrint_Click(object sender, EventArgs e) // Печать
        {
            print.ExportToExcelNew(this, dgvReport, 6, 1, cbxReport.Text + " с " + dtpStart.Value.ToShortDateString() + " по " + dtpEnd.Value.ToShortDateString());
        }

        private void searchFill()
        {
            if (cbxReport.Text == "Продажи по точкам продаж")
            {
                cbManager.Checked = false;

                cbxManager.Visible = false;
                cbManager.Visible = false;

                cbxSelectPointOfSale.Visible = true;
                cbSelectPointOfSale.Visible = true;

                if (cbSelectPointOfSale.Checked == true)
                {
                    workWithDB.fillDGV(cmdText(true, $"AND ТорговаяТочка.ID = {cbxSelectPointOfSale.SelectedValue}"), dgvReport);

                    dgvReport.Columns[0].HeaderText = "Дата";
                    dgvReport.Columns[1].HeaderText = "Точка продаж";
                    dgvReport.Columns[3].HeaderText = "Выручка, руб.";
                    dgvReport.Columns[3].DefaultCellStyle.Format = "N2";
                    dgvReport.Columns[4].HeaderText = "Валовая прибыль, руб.";
                    dgvReport.Columns[4].DefaultCellStyle.Format = "N2";

                    dgvReport.Columns[2].Visible = false; // Скрыть третий столбец
                    dgvReport.Columns[0].Width = 80;
                    dgvReport.Columns[1].Width = 180;
                }
                else if (cbSelectPointOfSale.Checked == false)
                {
                    workWithDB.fillDGV(cmdText(true, $""), dgvReport);

                    dgvReport.Columns[0].HeaderText = "Дата";
                    dgvReport.Columns[1].HeaderText = "Точка продаж";
                    dgvReport.Columns[3].HeaderText = "Выручка, руб.";
                    dgvReport.Columns[3].DefaultCellStyle.Format = "N2";
                    dgvReport.Columns[4].HeaderText = "Валовая прибыль, руб.";
                    dgvReport.Columns[4].DefaultCellStyle.Format = "N2";

                    dgvReport.Columns[2].Visible = false; // Скрыть третий столбец
                    dgvReport.Columns[0].Width = 80;
                    dgvReport.Columns[1].Width = 180;
                }
            }
            else if (cbxReport.Text == "Продажи по менеджерам")
            {
                cbSelectPointOfSale.Checked = false;

                cbxManager.Visible = true;
                cbManager.Visible = true;

                cbxSelectPointOfSale.Visible = false;
                cbSelectPointOfSale.Visible = false;

                if (cbManager.Checked == true)
                {
                    workWithDB.fillDGV(cmdText(false, $"AND Операция.МенеджерID = {cbxManager.SelectedValue}"), dgvReport);

                    dgvReport.Columns[0].HeaderText = "Дата";
                    dgvReport.Columns[1].HeaderText = "ФИО менеджера";
                    dgvReport.Columns[3].HeaderText = "Процент от продаж, %";
                    dgvReport.Columns[4].HeaderText = "Выручка, руб.";
                    dgvReport.Columns[4].DefaultCellStyle.Format = "N2";
                    dgvReport.Columns[5].HeaderText = "Премиальная часть, руб.";
                    dgvReport.Columns[5].DefaultCellStyle.Format = "N2";

                    dgvReport.Columns[2].Visible = false; // Скрыть третий столбец
                    dgvReport.Columns[0].Width = 80;
                    dgvReport.Columns[1].Width = 180;
                }
                else if (cbManager.Checked == false)
                {
                    workWithDB.fillDGV(cmdText(false, $""), dgvReport);

                    dgvReport.Columns[0].HeaderText = "Дата";
                    dgvReport.Columns[1].HeaderText = "ФИО менеджера";
                    dgvReport.Columns[3].HeaderText = "Процент от продаж, %";
                    dgvReport.Columns[4].HeaderText = "Выручка, руб.";
                    dgvReport.Columns[4].DefaultCellStyle.Format = "N2";
                    dgvReport.Columns[5].HeaderText = "Премиальная часть, руб.";
                    dgvReport.Columns[5].DefaultCellStyle.Format = "N2";

                    dgvReport.Columns[2].Visible = false; // Скрыть третий столбец
                    dgvReport.Columns[0].Width = 80;
                    dgvReport.Columns[1].Width = 180;
                }
            }
        }

        private void cbSelectPointOfSale_CheckedChanged(object sender, EventArgs e) // Отобрать по точке продаж
        {
            searchFill();
        }

        private void cbxSelectPointOfSale_SelectedValueChanged(object sender, EventArgs e) // Изменение точки продаж
        {
            searchFill();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e) // Изменение начальной даты
        {
            searchFill();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e) // Изменение конечной даты
        {
            searchFill();
        }

        private void cbxReport_SelectedValueChanged(object sender, EventArgs e) // Изменение вида отчета
        {
            searchFill();
        }

        private void cbManager_CheckedChanged(object sender, EventArgs e) // Отобрать по менеджерам
        {
            searchFill();
        }

        private void cbxManager_SelectedValueChanged(object sender, EventArgs e) // Изменение менеджера
        {
            searchFill();
        }
    }
}
