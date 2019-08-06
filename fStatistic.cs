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
    public partial class fStatistic : Form
    {
        public fStatistic()
        {
            InitializeComponent();
        }

        /*
         
            pContent1 - объемы продаж помесячно за период;
            pContent2 - объемы продаж по точке продаж помесячно за период;
            pContent3 - объемы продаж по менеджерам за период;
            pContent4 - объемы продаж по покупателям за период;
            pContent5 - объемы закупок по поставщикам за период;
            pContent6 - ТОП-10 товаров по выручке за период.
             
        */

        private void backColorBtn(Color btn1, Color btn2, Color btn3, Color btn4, Color btn5, Color btn6)
        {
            btnContent1.BackColor = btn1;
            btnContent2.BackColor = btn2;
            btnContent3.BackColor = btn3;
            btnContent4.BackColor = btn4;
            btnContent5.BackColor = btn5;
            btnContent6.BackColor = btn6;
        }

        private void visiblePanel(bool btn1, bool btn2, bool btn3, bool btn4, bool btn5, bool btn6)
        {
            pContent1.Visible = btn1;
            pContent2.Visible = btn2;
            pContent3.Visible = btn3;
            pContent4.Visible = btn4;
            pContent5.Visible = btn5;
            pContent6.Visible = btn6;
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрытие окна
        {
            Close();
        }

        private void stat1()
        {
            string cmd = $"SELECT (FORMAT([Дата], 'mmm yy')) AS ДатаОп, SUM([Количество]*[Цена]) AS Сумма " +
                $"FROM Операция INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID " +
                $"WHERE (((Операция.Закупка) = False) AND ((Операция.Дата) >= {ManyIF.convDate(dtpStart)} AND (Операция.Дата) <= {ManyIF.convDate(dtpEnd)})) " +
                $"GROUP BY FORMAT([Дата], 'mmm yy'), (YEAR([Дата])*12+MONTH([Дата])-1) " +
                $"ORDER BY (YEAR([Дата])*12+MONTH([Дата])-1)";
            string title = $"Объем продаж за период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}";

            workWithDB.fillChart(chart1, cmd, title, "ДатаОп", "Сумма");
        }

        private void stat2()
        {
            string cmd = $"SELECT (FORMAT([Дата], 'mmm yy')) AS ДатаОп, SUM([Количество]*[Цена]) AS Сумма " +
                $"FROM ТорговаяТочка INNER JOIN(Операция INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID) ON ТорговаяТочка.ID = Операция.ТочкаID " +
                $"WHERE (((Операция.Закупка) = False) AND ((Операция.Дата) >= {ManyIF.convDate(dtpStart)} AND (Операция.Дата) <= {ManyIF.convDate(dtpEnd)}) AND ((Операция.ТочкаID) = {cbxPOS.SelectedValue})) " +
                $"GROUP BY FORMAT([Дата], 'mmm yy'), (YEAR([Дата])*12+MONTH([Дата])-1) " +
                $"ORDER BY (YEAR([Дата])*12+MONTH([Дата])-1)";
            string title = $"Объем продаж в {cbxPOS.Text} помесячно за период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}";

            workWithDB.fillChart(chartPOSMonthSales, cmd, title, "ДатаОп", "Сумма");
        }

        private void stat3()
        {
            string cmd = $"SELECT Работник.ФИО, SUM([Количество]*[Цена]) AS Сумма " +
                $"FROM Работник INNER JOIN (Операция INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID) ON Работник.ТабN = Операция.МенеджерID " +
                $"WHERE (((Операция.Закупка) = False) AND ((Операция.Дата) >= {ManyIF.convDate(dtpStart)} AND (Операция.Дата) <= {ManyIF.convDate(dtpEnd)})) " +
                $"GROUP BY Работник.ФИО";
            string title = $"Объемы продаж по менеджерам помесячно за период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}";

            workWithDB.fillChart(chartManagerSales, cmd, title, "ФИО", "Сумма");
        }

        private void stat4()
        {
            string cmd = $"SELECT Контрагент.ФИО_Наименование, SUM([Количество]*[Цена]) AS Сумма " +
                $"FROM (Контрагент INNER JOIN Операция ON Контрагент.ID = Операция.КонтрагентID) INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID " +
                $"WHERE (((Операция.Закупка) = False) AND ((Операция.Дата) >= {ManyIF.convDate(dtpStart)} AND (Операция.Дата) <= {ManyIF.convDate(dtpEnd)})) " +
                $"GROUP BY Контрагент.ФИО_Наименование";
            string title = $"Объемы продаж по покупателям за период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}";

            workWithDB.fillChart(chartCostumersSales, cmd, title, "ФИО_Наименование", "Сумма");
        }

        private void stat5()
        {
            string cmd = $"SELECT Контрагент.ФИО_Наименование, SUM([Количество]*[Цена]) AS Сумма " +
                $"FROM (Контрагент INNER JOIN Операция ON Контрагент.ID = Операция.КонтрагентID) INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID " +
                $"WHERE (((Операция.Закупка) = True) AND ((Операция.Дата) >= {ManyIF.convDate(dtpStart)} AND (Операция.Дата) <= {ManyIF.convDate(dtpEnd)})) " +
                $"GROUP BY Контрагент.ФИО_Наименование";
            string title = $"Объемы закупок по поставщикам за период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}";

            workWithDB.fillChart(chartPartnerSales, cmd, title, "ФИО_Наименование", "Сумма");
        }

        private void stat6()
        {
            string cmd = $"SELECT TOP 10 Товар.Наименование, SUM([Цена]*[Количество]) AS Сумма " +
                $"FROM Товар INNER JOIN (Операция INNER JOIN СоставОперации ON Операция.ID = СоставОперации.ОперацияID) ON Товар.ID = СоставОперации.ТоварID " +
                $"WHERE Операция.Дата >= {ManyIF.convDate(dtpStart)} AND Операция.Дата <= {ManyIF.convDate(dtpEnd)} " +
                $"GROUP BY Товар.Наименование " +
                $"ORDER BY SUM([Цена]*[Количество]) DESC";
            string title = $"ТОП-10 товаров по выручке за период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}";

            workWithDB.fillChart(chartTOP, cmd, title, "Наименование", "Сумма");
        }

        private void btnContent1_Click(object sender, EventArgs e) // Показ панели pContent1
        {
            backColorBtn(Color.Gainsboro, 
                         Color.Transparent, 
                         Color.Transparent, 
                         Color.Transparent, 
                         Color.Transparent, 
                         Color.Transparent);

            visiblePanel(true, false, false, false, false, false);

            stat1();
        }

        private void btnContent2_Click(object sender, EventArgs e) // Показ панели pContent2
        {
            backColorBtn(Color.Transparent,
                         Color.Gainsboro,
                         Color.Transparent,
                         Color.Transparent,
                         Color.Transparent,
                         Color.Transparent);

            visiblePanel(false, true, false, false, false, false);

            stat2();
        }

        private void btnContent3_Click(object sender, EventArgs e) // Показ панели pContent3
        {
            backColorBtn(Color.Transparent,
                         Color.Transparent,
                         Color.Gainsboro,
                         Color.Transparent,
                         Color.Transparent,
                         Color.Transparent);

            visiblePanel(false, false, true, false, false, false);

            stat3();
        }

        private void btnContent4_Click(object sender, EventArgs e) // Показ панели pContent4
        {
            backColorBtn(Color.Transparent,
                         Color.Transparent,
                         Color.Transparent,
                         Color.Gainsboro,
                         Color.Transparent,
                         Color.Transparent);

            visiblePanel(false, false, false, true, false, false);

            stat4();
        }

        private void btnContent5_Click(object sender, EventArgs e) // Показ панели pContent5
        {
            backColorBtn(Color.Transparent,
                         Color.Transparent,
                         Color.Transparent,
                         Color.Transparent,
                         Color.Gainsboro,
                         Color.Transparent);

            visiblePanel(false, false, false, false, true, false);

            stat5();
        }

        private void btnContent6_Click(object sender, EventArgs e) // Показ панели pContent6
        {
            backColorBtn(Color.Transparent,
                         Color.Transparent,
                         Color.Transparent,
                         Color.Transparent,
                         Color.Transparent,
                         Color.Gainsboro);

            visiblePanel(false, false, false, false, false, true);

            stat6();

            chartTOP.ChartAreas[0].AxisX.Interval = 1;
        }

        private void fStatistic_Load(object sender, EventArgs e) // При загрузке формы
        {
            workWithDB.fillDTPMinDate(dtpStart);

            workWithDB.fillCombobox(cbxPOS, "Точка", "ID", "SELECT ID, Точка FROM ТорговаяТочка");

            cbxPOS.SelectedIndex = 0;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e) // Изменение начальной даты
        {
            stat1();
            stat3();
            stat4();
            stat5();
            stat6();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e) // Изменение конечной даты
        {
            stat1();
            stat3();
            stat4();
            stat5();
            stat6();
        }

        private void cbxPOS_SelectedValueChanged(object sender, EventArgs e) // Изменение содержимого combobox'а
        {
            stat2();

            stat1();
            stat3();
            stat4();
            stat5();
            stat6();
        }

        private void btnPrint_Click(object sender, EventArgs e) // Печать
        {
            if (pContent1.Visible == true)
            {
                chart1.Printing.PrintPreview();
            }
            else if (pContent2.Visible == true)
            {
                chartPOSMonthSales.Printing.PrintPreview();
            }
            else if (pContent3.Visible == true)
            {
                chartManagerSales.Printing.PrintPreview();
            }
            else if (pContent4.Visible == true)
            {
                chartCostumersSales.Printing.PrintPreview();
            }
            else if (pContent5.Visible == true)
            {
                chartPartnerSales.Printing.PrintPreview();
            }
            else if (pContent6.Visible == true)
            {
                chartTOP.Printing.PrintPreview();
            }
            else
            {
                MessageBox.Show("Выберите нужный отчет", "Не выбран отчет", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
