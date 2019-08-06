using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MotorAuto
{
    public partial class fPriceList : Form
    {
        public fPriceList()
        {
            InitializeComponent();
        }

        public static bool moveTo = false;
        public static bool isPurchase = true; // Это закупка?

        private static string[] columns =
        {
            "min date", "max date", "glav buh", "pokupatel", "INN / KPP pokupatela", "prodavec", "INN / KPP prodavca",
            getRequisites(), "rekvizity kompanii", "FIO manager", "nomer operacii", "dannie prodavca", "kol-vo zapisei",
            "dannie kontragenta", "avtosalon", "FIO manager", "nachalo", "konec", "dannie prodavca", "rekvizity prodavca",
            "dannie kontagenta", "rekvizity kontragenta", "FIO kassir", "imya kompanii", "iz avtosalona", "v avtosalon"
        };

        private static string getRequisites()
        {
            string requisites = workWithDB.getLastID("SELECT Наименование FROM Реквизиты") + ", ИНН " + workWithDB.getLastID("SELECT ИНН FROM Реквизиты") + ", КПП " +
                workWithDB.getLastID("SELECT КПП FROM Реквизиты") + ", Адрес: " + workWithDB.getLastID("SELECT Адрес FROM Реквизиты");

            return requisites;
        }

        private void btnExit_Click(object sender, EventArgs e) // Закрыть окно
        {
            moveTo = false;
            Close();
        }

        private void fPriceList_Load(object sender, EventArgs e) // При загрузке окна
        {
            workWithDB.fillCombobox(cbxBrand, "Группа", "ID", $"SELECT ГруппаТовара.ID, ГруппаТовара.Группа " +
                $"FROM ГруппаТовара INNER JOIN Товар ON ГруппаТовара.ID = Товар.ГруппаID " +
                $"GROUP BY ГруппаТовара.ID, ГруппаТовара.Группа, Товар.ГруппаID " +
                $"HAVING Товар.ГруппаID > 0");

            Bitmap path = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory + "img\\no-photo.jpg");
            pbItemImg.Image = path;

            if (moveTo == true)
            {
                btnProductTo.Visible = moveTo;
                btnAddAuto.Visible = false;
            }
            else
            {
                btnProductTo.Visible = moveTo;
                btnAddAuto.Visible = true;
            }
        }

        private void cbxBrand_SelectedValueChanged(object sender, EventArgs e) // При выборе в combobox
        {
            workWithDB.fillDGV("SELECT ID, Наименование, ЕдИзм FROM Товар WHERE ГруппаID LIKE '" + cbxBrand.SelectedValue.ToString() + "'", dgvDBProduct);

            dgvDBProduct.Columns[0].HeaderText = "Код";
            dgvDBProduct.Columns[1].HeaderText = "Наименование товара";
            dgvDBProduct.Columns[2].HeaderText = "Ед. изм.";

            dgvDBProduct.Columns[0].Width = 50;
            dgvDBProduct.Columns[1].Width = 300;
        }


        int num;
        int numPL;
        private void dgvDBProduct_SelectionChanged(object sender, EventArgs e) // При изменении выделения ячейки
        {
            num = (int)dgvDBProduct.CurrentRow.Cells[0].Value;
            workWithDB.fillDGV("SELECT Дата, ЦенаЗакупки, ЦенаПродажи FROM ПрайсЛист WHERE ТоварID = " + num, dgvPriceList);

            dgvPriceList.Columns[0].HeaderText = "Дата";
            dgvPriceList.Columns[1].HeaderText = "Цена закупки, руб.";
            dgvPriceList.Columns[1].DefaultCellStyle.Format = "N2";
            dgvPriceList.Columns[2].HeaderText = "Цена продажи, руб.";
            dgvPriceList.Columns[2].DefaultCellStyle.Format = "N2";

            workWithDB.fillPictureBox(pbItemImg, num.ToString());
        }

        private void btnChoicePhoto_Click(object sender, EventArgs e) // Выбрать фотографию для транспорта
        {
            try
            {
                string startPath; // Начальный путь
                string basePath = System.AppDomain.CurrentDomain.BaseDirectory; // Путь до exe файла
                string finishPath; // Конечный путь
                string fullPath = basePath + "img\\auto\\"; // Путь до папки с изображениями
                string fileName;

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JPG-Files (*.jpg)|*.jpg";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    startPath = ofd.FileName; // Задаем начальный путь где лежал файл который был выбран
                    fileName = Path.GetFileName(ofd.FileName); // Наименование файла
                    finishPath = basePath + "img\\auto\\" + fileName; // Получаем конечный путь до файла

                    // Если нет данного пути, то создаем его
                    if (Directory.Exists(fullPath) == false)
                    {
                        Directory.CreateDirectory(fullPath);
                    }

                    // Если файл уже есть в папке, то ставим его наименование в БД, если же нет, то копируем его
                    if (File.Exists(finishPath) == true)
                    {
                        int indexStr = dgvDBProduct.CurrentRow.Index;

                        workWithDB.actionDB($"UPDATE Товар SET Фото = '{fileName}' WHERE ID = {num}");
                        workWithDB.fillDGV("SELECT ID, Наименование, ЕдИзм FROM Товар WHERE ГруппаID LIKE '" + cbxBrand.SelectedValue.ToString() + "'", dgvDBProduct);

                        dgvDBProduct.ClearSelection();
                        dgvDBProduct.Rows[indexStr].Selected = true;
                        dgvDBProduct.CurrentCell = dgvDBProduct.Rows[indexStr].Cells[0];
                        dgvDBProduct.FirstDisplayedScrollingRowIndex = indexStr;

                        workWithDB.fillPictureBox(pbItemImg, num.ToString());
                    }
                    else
                    {
                        int indexStr = dgvDBProduct.CurrentRow.Index;

                        File.Copy(startPath, finishPath); // Копируем файл в указанную папку
                        workWithDB.actionDB($"UPDATE Товар SET Фото = '{fileName}' WHERE ID = {num}");
                        workWithDB.fillDGV("SELECT ID, Наименование, ЕдИзм FROM Товар WHERE ГруппаID LIKE '" + cbxBrand.SelectedValue.ToString() + "'", dgvDBProduct);

                        dgvDBProduct.ClearSelection();
                        dgvDBProduct.Rows[indexStr].Selected = true;
                        dgvDBProduct.CurrentCell = dgvDBProduct.Rows[indexStr].Cells[0];
                        dgvDBProduct.FirstDisplayedScrollingRowIndex = indexStr;

                        workWithDB.fillPictureBox(pbItemImg, num.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e) // Печать всего прайс-листа
        {
            workWithDB.fillDGV($"SELECT Товар.ID, Товар.Наименование, Товар.ЕдИзм, ПрайсЛист.ЦенаЗакупки " +
                $"FROM Товар INNER JOIN ПрайсЛист ON Товар.ID = ПрайсЛист.ТоварID " +
                $"WHERE ПрайсЛист.ЦенаЗакупки = (" +
                    $"SELECT ПрайсЛист.ЦенаЗакупки " +
                    $"FROM ПрайсЛист " +
                    $"WHERE (((ПрайсЛист.Дата) = (" +
                        $"SELECT MAX(Дата) " +
                        $"FROM ПрайсЛист П WHERE П.ТоварID = ПрайсЛист.ТоварID)) AND ((ПрайсЛист.ТоварID) = Товар.ID))" +
                $")", dgvALL);
            print.ExportToExcel(this, dgvALL, 7, 1, "Прайс-лист.xlsx", false, columns);
            dgvALL.DataSource = null; // Очистка таблицы
        }

        private void btnProductTo_Click(object sender, EventArgs e) // Товар в приход
        {
            numPL = (int)dgvPriceList.CurrentRow.Index; // Индекс выбранной строки

            string name = workWithDB.getLastID("SELECT Наименование FROM Товар WHERE ID = " + num);
            string price = string.Empty;

            if (isPurchase == true)
            {
                price = workWithDB.getLastID($"SELECT ЦенаПродажи FROM ПрайсЛист " +
                    $"WHERE Дата = (SELECT MAX(Дата) FROM ПрайсЛист П WHERE П.ТоварID = ПрайсЛист.ТоварID AND ПрайсЛист.ТоварID = {num})");
                getValue.Name = name;
                getValue.Price = price;

                this.Close();
            }
            else
            {
                price = workWithDB.getLastID($"SELECT ЦенаЗакупки FROM ПрайсЛист " +
                    $"WHERE Дата = (SELECT MAX(Дата) FROM ПрайсЛист П WHERE П.ТоварID = ПрайсЛист.ТоварID AND ПрайсЛист.ТоварID = {num})");
                getValue.Name = name;
                getValue.Price = price;

                this.Close();
            }
        }

        private void fPriceList_FormClosed(object sender, FormClosedEventArgs e)
        {
            moveTo = false;
        }

        private void btnAddAuto_Click(object sender, EventArgs e)
        {
            fAddAuto form_AA = new fAddAuto();
            form_AA.ShowDialog();
        }
    }
}
