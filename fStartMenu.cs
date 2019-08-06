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
    public partial class fStartMenu : Form
    {
        public fStartMenu()
        {
            InitializeComponent();
        }

        // Глобальные переменные //

        public static string roleUser = ""; // Переменная отвечающая за указание должности пользователя в заголовке окна
        public static string userName = ""; // Переменная отвечает за имя пользователя
        public static string lastId = "";

        //***********************//

        // Активация контролов на форме //

        private void activationControls(bool pricelist, bool warehouse, bool moveproduct, 
                                        bool newpurchase, bool newsale, bool bookpurchaseandsale, bool statistic)
        {
            btnPriceList.Enabled = pricelist;
            btnWarehouse.Enabled = warehouse;
            btnMoveProduct.Enabled = moveproduct;
            btnNewPurchase.Enabled = newpurchase;
            btnNewSale.Enabled = newsale;
            btnSalePurchase.Enabled = bookpurchaseandsale;
            btnStat.Enabled = statistic;
        }

        private void activationMenu(bool groupproduct, bool pointofsale, bool workers, bool partner, bool requisite,
                                    bool pricelist, bool warehouse, bool moveproduct, bool newpurchase, bool newsale,
                                    bool bookpurchaseandsale, bool statistic, bool reports)
        {
            // Справочники //

            группыТоваровToolStripMenuItem.Enabled = groupproduct;
            тороговыеТочкиМагазиныToolStripMenuItem.Enabled = pointofsale;
            работникиToolStripMenuItem.Enabled = workers;
            контрагентыToolStripMenuItem.Enabled = partner;
            реквизитыToolStripMenuItem.Enabled = requisite;

            //************//

            // Товар //

            прайслистToolStripMenuItem.Enabled = pricelist;
            складToolStripMenuItem.Enabled = warehouse;
            перемещениеТовараToolStripMenuItem.Enabled = moveproduct;
            новаяЗакупкаToolStripMenuItem.Enabled = newpurchase;
            новаяПродажаToolStripMenuItem.Enabled = newsale;
            книгаПродажПокупокToolStripMenuItem.Enabled = bookpurchaseandsale;

            //*******//

            // Отчеты и статистика //

            статистикаToolStripMenuItem.Enabled = statistic;
            отчетыПоПродажамToolStripMenuItem.Enabled = reports;

            //*********************//
        }

        //*****************************//

        private void btnExit_Click(object sender, EventArgs e) // Выход из приложения
        {
            Application.Exit();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) // Выход из приложения
        {
            Application.Exit();
        }

        private void btnPriceList_Click(object sender, EventArgs e) // Переход к прайс-листу
        {
            fPriceList form_PriceList = new fPriceList();
            form_PriceList.Show();
        }

        private void btnWarehouse_Click(object sender, EventArgs e) // Переход к складу
        {
            fWarehouse form_Warehouse = new fWarehouse();
            form_Warehouse.Show();
        }

        private void btnMoveProduct_Click(object sender, EventArgs e) // Переход к перемещению товара
        {
            fMoveToOtherPointOfSale form_MoveToOtherPointOfSale = new fMoveToOtherPointOfSale();
            form_MoveToOtherPointOfSale.Show();
        }

        private void btnNewPurchase_Click(object sender, EventArgs e) // Переход к новой закупке
        {
            fNewPurchase form_NewPurchase = new fNewPurchase();
            form_NewPurchase.Show();
        }

        private void fStartMenu_Load(object sender, EventArgs e) // При загрузке окна
        {
            Text = "АИС Автосалона: " + roleUser;
            lUserName.Text = "Пользователь: " + userName;
            Bitmap img = new Bitmap("img/background.jpg");
            pbBackImg.Image = img;

            // Активация полей //

            if (roleUser == "Менеджер")
            {
                activationControls(true, true, true, true, false, true, false);
                activationMenu(false, false, false, true, false, true, true, true, true, false, true, false, false);
            }

            else if (roleUser == "Руководитель")
            {
                activationControls(true, true, true, false, false, true, true);
                activationMenu(true, true, true, true, true, true, true, true, false, false, true, true, true);
            }

            else if (roleUser == "Кассир")
            {
                activationControls(false, false, false, false, true, false, false);
                activationMenu(false, false, false, false, false, false, false, false, false, true, false, false, false);
            }

            else if (roleUser == "Администратор")
            {
                activationControls(true, true, true, true, true, true, true);
                activationMenu(true, true, true, true, true, true, true, true, true, true, true, true, true);
            }

            //*****************//
        }

        private void btnSalePurchase_Click(object sender, EventArgs e) // Переход к книги закупки/продажи
        {
            fBookPurchaseAndSales form_BookPurchaseAndSales = new fBookPurchaseAndSales();
            form_BookPurchaseAndSales.Show();
        }

        private void btnStat_Click(object sender, EventArgs e) // Переход к статистике
        {
            fStatistic form_Statistic = new fStatistic();
            form_Statistic.Show();
        }

        private void btnNewSale_Click(object sender, EventArgs e) // Переход к новой продаже
        {
            fNewSale form_NewSale = new fNewSale();
            form_NewSale.Show();
        }

        private void прайслистToolStripMenuItem_Click(object sender, EventArgs e) // Переход к прайс-листу
        {
            fPriceList form_PriceList = new fPriceList();
            form_PriceList.Show();
        }

        private void складToolStripMenuItem_Click(object sender, EventArgs e) // Переход к складу
        {
            fWarehouse form_Warehouse = new fWarehouse();
            form_Warehouse.Show();
        }

        private void перемещениеТовараToolStripMenuItem_Click(object sender, EventArgs e) // Переход к перемещению товара
        {
            fMoveToOtherPointOfSale form_MoveToOtherPointOfSale = new fMoveToOtherPointOfSale();
            form_MoveToOtherPointOfSale.Show();
        }

        private void новаяЗакупкаToolStripMenuItem_Click(object sender, EventArgs e) // Переход к новой закупке
        {
            fNewPurchase form_NewPurchase = new fNewPurchase();
            form_NewPurchase.Show();
        }

        private void новаяПродажаToolStripMenuItem_Click(object sender, EventArgs e) // Переход к новой продаже
        {
            fNewSale form_NewSale = new fNewSale();
            form_NewSale.Show();
        }

        private void книгаПродажПокупокToolStripMenuItem_Click(object sender, EventArgs e) // Переход к книге продаж/покупок
        {
            fBookPurchaseAndSales form_BookPurchaseAndSales = new fBookPurchaseAndSales();
            form_BookPurchaseAndSales.Show();
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e) // Переход к статистике
        {
            fStatistic form_Statistic = new fStatistic();
            form_Statistic.Show();
        }

        private void контрагентыToolStripMenuItem_Click(object sender, EventArgs e) // Переход к контрагентам
        {
            fPartner form_Partner = new fPartner();
            form_Partner.Show();
        }

        private void группыТоваровToolStripMenuItem_Click(object sender, EventArgs e) // Переход к группам товаров
        {
            fGroupProducts form_GroupProduct = new fGroupProducts();
            form_GroupProduct.Show();
        }

        private void тороговыеТочкиМагазиныToolStripMenuItem_Click(object sender, EventArgs e) // Переход к торговым точкам
        {
            fPointOfSale form_PointOfSale = new fPointOfSale();
            form_PointOfSale.Show();
        }

        private void работникиToolStripMenuItem_Click(object sender, EventArgs e) // Переход к работникам
        {
            fWorkers form_Workers = new fWorkers();
            form_Workers.Show();
        }

        private void реквизитыToolStripMenuItem_Click(object sender, EventArgs e) // Переход к реквизитам
        {
            fRequisites form_Requisites = new fRequisites();
            form_Requisites.Show();
        }

        private void отчетыПоПродажамToolStripMenuItem_Click(object sender, EventArgs e) // Переход к отчету по продажам
        {
            fReportSales form_ReportSales = new fReportSales();
            form_ReportSales.Show();
        }
    }
}
