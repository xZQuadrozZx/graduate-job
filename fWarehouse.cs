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
    public partial class fWarehouse : Form
    {
        public fWarehouse()
        {
            InitializeComponent();
        }

        fWarehouseCarImg form_WCI = new fWarehouseCarImg(); // Форма с изображением
        public bool moveTo = false;
        public bool isPurchase = false;

        private void btnExit_Click(object sender, EventArgs e) // Закрыть окно
        {
            Close();
            form_WCI.Close();
        }

        public static string cmdText(string where)
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

        private void fWarehouse_Load(object sender, EventArgs e) // Загрузка формы
        {
            workWithDB.fillDGV(cmdText(""), dgvProduct);

            // Ширина столбцов
            dgvProduct.Columns[0].Width = 40;
            dgvProduct.Columns[1].Width = 250;
            dgvProduct.Columns[2].Width = 45;
            dgvProduct.Columns[4].Width = 100;
            dgvProduct.Columns[5].Width = 100;
            dgvProduct.Columns[6].Width = 100;
            dgvProduct.Columns[7].Width = 100;
            dgvProduct.Columns[8].Width = 100;
            dgvProduct.Columns[9].Width = 200;
            // Заголовки столбцов
            dgvProduct.Columns[1].HeaderText = "Наименование товара";
            dgvProduct.Columns[2].HeaderText = "Ед. изм.";
            dgvProduct.Columns[4].HeaderText = "Цена закупки, руб.";
            dgvProduct.Columns[4].DefaultCellStyle.Format = "N2";
            dgvProduct.Columns[5].HeaderText = "Цена продажи, руб.";
            dgvProduct.Columns[5].DefaultCellStyle.Format = "N2";
            dgvProduct.Columns[6].HeaderText = "Сумма закупки, руб.";
            dgvProduct.Columns[6].DefaultCellStyle.Format = "N2";
            dgvProduct.Columns[7].HeaderText = "Сумма продажи, руб.";
            dgvProduct.Columns[7].DefaultCellStyle.Format = "N2";
            dgvProduct.Columns[8].HeaderText = "Группа товара";
            dgvProduct.Columns[9].HeaderText = "Точка продаж";

            workWithDB.fillCombobox(cbGroupProduct, "Группа", "ID", "SELECT * FROM ГруппаТовара");
            workWithDB.fillCombobox(cbPointOfSale, "Точка", "ID", "SELECT * FROM ТорговаяТочка");

            if (moveTo == true)
            {
                btnSale.Visible = moveTo;
                btnMoveProduct.Visible = false;
            }
            else
            {
                btnSale.Visible = moveTo;
                btnMoveProduct.Visible = true;
            }
        }

        private void cbShowImg_CheckedChanged(object sender, EventArgs e) // Изменение свойства checked
        {
            if (cbShowImg.Checked == true)
            {
                form_WCI.Show();
            }
            else if (cbShowImg.Checked == false)
            {
                form_WCI.Hide();
            }
        }

        private void cbGroupProduct_SelectedValueChanged(object sender, EventArgs e) // При изменении выбора в combobox'e
        {
            if (cbxGroupProduct.Checked == true && cbxPointOfSale.Checked == false)
            {
                workWithDB.fillDGV(cmdText("WHERE Товар.ГруппаID = " + cbGroupProduct.SelectedValue), dgvProduct);
            }
            else if (cbxGroupProduct.Checked == true && cbxPointOfSale.Checked == true)
            {
                workWithDB.fillDGV(cmdText("WHERE Товар.ГруппаID = " + cbGroupProduct.SelectedValue + " AND Склад.ТочкаID = " + cbPointOfSale.SelectedValue), dgvProduct);
            }
            else
            {
                return;
            }
        }

        private void cbPointOfSale_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxPointOfSale.Checked == true && cbxGroupProduct.Checked == false)
            {
                workWithDB.fillDGV(cmdText("WHERE Склад.ТочкаID = " + cbPointOfSale.SelectedValue), dgvProduct);
            }
            else if (cbxPointOfSale.Checked == true && cbxGroupProduct.Checked == true)
            {
                workWithDB.fillDGV(cmdText("WHERE Товар.ГруппаID = " + cbGroupProduct.SelectedValue + " AND Склад.ТочкаID = " + cbPointOfSale.SelectedValue), dgvProduct);
            }
            else
            {
                return;
            }
        }

        private void cbxGroupProduct_CheckedChanged(object sender, EventArgs e) // При изменении состояния checkbox'a
        {
            if (cbxGroupProduct.Checked == true && cbxPointOfSale.Checked == false)
            {
                workWithDB.fillDGV(cmdText("WHERE Товар.ГруппаID = " + cbGroupProduct.SelectedValue), dgvProduct);
            }
            else if (cbxPointOfSale.Checked == false && cbxGroupProduct.Checked == false)
            {
                workWithDB.fillDGV(cmdText(""), dgvProduct);
            }
            else if (cbxGroupProduct.Checked == true && cbxPointOfSale.Checked == true)
            {
                workWithDB.fillDGV(cmdText("WHERE Товар.ГруппаID = " + cbGroupProduct.SelectedValue + " AND Склад.ТочкаID = " + cbPointOfSale.SelectedValue), dgvProduct);
            }
        }

        private void cbxPointOfSale_CheckedChanged(object sender, EventArgs e) // При изменении состояния checkbox'a
        {
            if (cbxPointOfSale.Checked == true && cbxGroupProduct.Checked == false)
            {
                workWithDB.fillDGV(cmdText("WHERE Склад.ТочкаID = " + cbPointOfSale.SelectedValue), dgvProduct);
            }
            else if (cbxGroupProduct.Checked == false && cbxPointOfSale.Checked == false)
            {
                workWithDB.fillDGV(cmdText(""), dgvProduct);
            }
            else if (cbxGroupProduct.Checked == true && cbxPointOfSale.Checked == true)
            {
                workWithDB.fillDGV(cmdText("WHERE Товар.ГруппаID = " + cbGroupProduct.SelectedValue + " AND Склад.ТочкаID = " + cbPointOfSale.SelectedValue), dgvProduct);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e) // Печать
        {
            string[] columns =
            {
                "", "", "", "pokupatel", "", "prodavec", "INN / KPP prodavca",
                "dannie kompanii", "rekvizity kompanii", "FIO manager", "nomer operacii", "dannie prodavca", "kol-vo zapisei",
                "dannie kontragenta", "avtosalon", "FIO manager", "nachalo", "konec", "dannie prodavca", "rekvizity prodavca",
                "dannie kontagenta", "rekvizity kontragenta", "FIO kassir", "", "iz avtosalona", "v avtosalon"
            };

            string cmd = "SELECT " +
                "Товар.ID, " +
                "Товар.Наименование, " +
                "Товар.ЕдИзм, " +
                "Склад.Количество, " +
                "Last(ПрайсЛист.ЦенаЗакупки) AS ЦенаЗакупки1, " +
                "Last(ПрайсЛист.ЦенаПродажи) AS ЦенаПродажи1, " +
                "[ЦенаЗакупки1]*[Количество] AS СуммаЗакупки, " +
                "[ЦенаПродажи1]*[Количество] AS СуммаПродажи " +
                " FROM ТорговаяТочка INNER JOIN(((ГруппаТовара INNER JOIN Товар ON ГруппаТовара.ID = Товар.ГруппаID) INNER JOIN ПрайсЛист ON Товар.ID = ПрайсЛист.ТоварID) INNER JOIN Склад ON Товар.ID = Склад.ТоварID) ON ТорговаяТочка.ID = Склад.ТочкаID " +
                " GROUP BY Товар.Наименование, Товар.ID, Товар.ЕдИзм, Склад.Количество" +
                " HAVING(((Склад.Количество) > 0))";

            workWithDB.fillDGV(cmd, dgvProductCopy);

            print.ExportToExcel(this, dgvProductCopy, 6, 1, "Остаток товара на складе.xlsx", true, columns);
        }

        private void btnMoveProduct_Click(object sender, EventArgs e) // Перемещение товара
        {
            fMoveToOtherPointOfSale form_MTOPOS = new fMoveToOtherPointOfSale();
            form_MTOPOS.Show();
        }

        int num;
        private void dgvProduct_SelectionChanged(object sender, EventArgs e) // Изменение строки
        {
            num = (int)dgvProduct.CurrentRow.Cells[0].Value;
            string fileName = workWithDB.getLastID($"SELECT Фото FROM Товар WHERE ID = {num}");

            if (fileName == string.Empty)
            {
                Bitmap bm = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory + "img//no-photo.jpg");
                form_WCI.pbCarPhoto.Image = bm;
            }
            else
            {
                Bitmap bm = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory + "img//auto//" + fileName);
                form_WCI.pbCarPhoto.Image = bm;
            }
        }

        private void fWarehouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvProductCopy.DataSource = null;
        }

        private void btnSale_Click(object sender, EventArgs e) // Товар в расход
        {
            int numPL = (int)dgvProduct.CurrentRow.Index; // Индекс выбранной строки

            string name = dgvProduct.Rows[numPL].Cells[1].Value.ToString(); // Наименование товара из выбранной строки
            string price = string.Empty;

            if (isPurchase == true)
            {
                price = dgvProduct.Rows[numPL].Cells[5].Value.ToString(); // Цена продажи из выбранной строки
                getValue.Name = name;
                getValue.Price = price;

                this.Close();
            }
            else
            {
                price = dgvProduct.Rows[numPL].Cells[5].Value.ToString(); // Цена продажи из выбранной строки
                getValue.Name = name;
                getValue.Price = price;

                this.Close();
            }
        }
    }
}
