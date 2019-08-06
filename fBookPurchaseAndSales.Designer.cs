namespace MotorAuto
{
    partial class fBookPurchaseAndSales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.cbxPartner = new System.Windows.Forms.ComboBox();
            this.cbxPointOfSale = new System.Windows.Forms.ComboBox();
            this.cbPartner = new System.Windows.Forms.CheckBox();
            this.cbPointOfSale = new System.Windows.Forms.CheckBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cbEnd = new System.Windows.Forms.CheckBox();
            this.cbStart = new System.Windows.Forms.CheckBox();
            this.cbCashier = new System.Windows.Forms.CheckBox();
            this.cbxCashier = new System.Windows.Forms.ComboBox();
            this.cbxManager = new System.Windows.Forms.ComboBox();
            this.cbManager = new System.Windows.Forms.CheckBox();
            this.rbBookPurchase = new System.Windows.Forms.RadioButton();
            this.rbBookSales = new System.Windows.Forms.RadioButton();
            this.btnOpenExpense = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvBookPurchaseAndSales = new MotorAuto.DoubleBufferedDataGridView();
            this.dgvPrint = new System.Windows.Forms.DataGridView();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookPurchaseAndSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.cbxPartner);
            this.gbSettings.Controls.Add(this.cbxPointOfSale);
            this.gbSettings.Controls.Add(this.cbPartner);
            this.gbSettings.Controls.Add(this.cbPointOfSale);
            this.gbSettings.Controls.Add(this.dtpEnd);
            this.gbSettings.Controls.Add(this.dtpStart);
            this.gbSettings.Controls.Add(this.cbEnd);
            this.gbSettings.Controls.Add(this.cbStart);
            this.gbSettings.Controls.Add(this.cbCashier);
            this.gbSettings.Controls.Add(this.cbxCashier);
            this.gbSettings.Controls.Add(this.cbxManager);
            this.gbSettings.Controls.Add(this.cbManager);
            this.gbSettings.Controls.Add(this.rbBookPurchase);
            this.gbSettings.Controls.Add(this.rbBookSales);
            this.gbSettings.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbSettings.Location = new System.Drawing.Point(12, 354);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(702, 171);
            this.gbSettings.TabIndex = 1;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Отбор записей книги";
            // 
            // cbxPartner
            // 
            this.cbxPartner.FormattingEnabled = true;
            this.cbxPartner.Location = new System.Drawing.Point(442, 53);
            this.cbxPartner.Name = "cbxPartner";
            this.cbxPartner.Size = new System.Drawing.Size(250, 25);
            this.cbxPartner.TabIndex = 13;
            this.cbxPartner.SelectedValueChanged += new System.EventHandler(this.cbxPartner_SelectedValueChanged);
            // 
            // cbxPointOfSale
            // 
            this.cbxPointOfSale.FormattingEnabled = true;
            this.cbxPointOfSale.Location = new System.Drawing.Point(442, 24);
            this.cbxPointOfSale.Name = "cbxPointOfSale";
            this.cbxPointOfSale.Size = new System.Drawing.Size(250, 25);
            this.cbxPointOfSale.TabIndex = 12;
            this.cbxPointOfSale.SelectedValueChanged += new System.EventHandler(this.cbxPointOfSale_SelectedValueChanged);
            // 
            // cbPartner
            // 
            this.cbPartner.AutoSize = true;
            this.cbPartner.Location = new System.Drawing.Point(307, 53);
            this.cbPartner.Name = "cbPartner";
            this.cbPartner.Size = new System.Drawing.Size(108, 23);
            this.cbPartner.TabIndex = 11;
            this.cbPartner.Text = "контрагент:";
            this.cbPartner.UseVisualStyleBackColor = true;
            this.cbPartner.CheckedChanged += new System.EventHandler(this.cbPartner_CheckedChanged);
            // 
            // cbPointOfSale
            // 
            this.cbPointOfSale.AutoSize = true;
            this.cbPointOfSale.Location = new System.Drawing.Point(307, 24);
            this.cbPointOfSale.Name = "cbPointOfSale";
            this.cbPointOfSale.Size = new System.Drawing.Size(129, 23);
            this.cbPointOfSale.TabIndex = 10;
            this.cbPointOfSale.Text = "точка продаж:";
            this.cbPointOfSale.UseVisualStyleBackColor = true;
            this.cbPointOfSale.CheckedChanged += new System.EventHandler(this.cbPointOfSale_CheckedChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(200, 52);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(101, 24);
            this.dtpEnd.TabIndex = 9;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(200, 24);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(101, 24);
            this.dtpStart.TabIndex = 8;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // cbEnd
            // 
            this.cbEnd.AutoSize = true;
            this.cbEnd.Location = new System.Drawing.Point(153, 52);
            this.cbEnd.Name = "cbEnd";
            this.cbEnd.Size = new System.Drawing.Size(49, 23);
            this.cbEnd.TabIndex = 7;
            this.cbEnd.Text = "по:";
            this.cbEnd.UseVisualStyleBackColor = true;
            this.cbEnd.CheckedChanged += new System.EventHandler(this.cbEnd_CheckedChanged);
            // 
            // cbStart
            // 
            this.cbStart.AutoSize = true;
            this.cbStart.Location = new System.Drawing.Point(153, 24);
            this.cbStart.Name = "cbStart";
            this.cbStart.Size = new System.Drawing.Size(41, 23);
            this.cbStart.TabIndex = 6;
            this.cbStart.Text = "с:";
            this.cbStart.UseVisualStyleBackColor = true;
            this.cbStart.CheckedChanged += new System.EventHandler(this.cbStart_CheckedChanged);
            // 
            // cbCashier
            // 
            this.cbCashier.AutoSize = true;
            this.cbCashier.Location = new System.Drawing.Point(262, 91);
            this.cbCashier.Name = "cbCashier";
            this.cbCashier.Size = new System.Drawing.Size(143, 23);
            this.cbCashier.TabIndex = 5;
            this.cbCashier.Text = "Провел кассир:";
            this.cbCashier.UseVisualStyleBackColor = true;
            this.cbCashier.CheckedChanged += new System.EventHandler(this.cbCashier_CheckedChanged);
            // 
            // cbxCashier
            // 
            this.cbxCashier.FormattingEnabled = true;
            this.cbxCashier.Location = new System.Drawing.Point(262, 120);
            this.cbxCashier.Name = "cbxCashier";
            this.cbxCashier.Size = new System.Drawing.Size(250, 25);
            this.cbxCashier.TabIndex = 4;
            this.cbxCashier.SelectedValueChanged += new System.EventHandler(this.cbxCashier_SelectedValueChanged);
            // 
            // cbxManager
            // 
            this.cbxManager.FormattingEnabled = true;
            this.cbxManager.Location = new System.Drawing.Point(6, 120);
            this.cbxManager.Name = "cbxManager";
            this.cbxManager.Size = new System.Drawing.Size(250, 25);
            this.cbxManager.TabIndex = 3;
            this.cbxManager.SelectedValueChanged += new System.EventHandler(this.cbxManager_SelectedValueChanged);
            // 
            // cbManager
            // 
            this.cbManager.AutoSize = true;
            this.cbManager.Location = new System.Drawing.Point(6, 91);
            this.cbManager.Name = "cbManager";
            this.cbManager.Size = new System.Drawing.Size(187, 23);
            this.cbManager.TabIndex = 2;
            this.cbManager.Text = "Оформил менеджер:";
            this.cbManager.UseVisualStyleBackColor = true;
            this.cbManager.CheckedChanged += new System.EventHandler(this.cbManager_CheckedChanged);
            // 
            // rbBookPurchase
            // 
            this.rbBookPurchase.AutoSize = true;
            this.rbBookPurchase.Location = new System.Drawing.Point(6, 52);
            this.rbBookPurchase.Name = "rbBookPurchase";
            this.rbBookPurchase.Size = new System.Drawing.Size(127, 23);
            this.rbBookPurchase.TabIndex = 1;
            this.rbBookPurchase.Text = "Книга покупок";
            this.rbBookPurchase.UseVisualStyleBackColor = true;
            this.rbBookPurchase.CheckedChanged += new System.EventHandler(this.rbBookPurchase_CheckedChanged);
            // 
            // rbBookSales
            // 
            this.rbBookSales.AutoSize = true;
            this.rbBookSales.Checked = true;
            this.rbBookSales.Location = new System.Drawing.Point(6, 23);
            this.rbBookSales.Name = "rbBookSales";
            this.rbBookSales.Size = new System.Drawing.Size(127, 23);
            this.rbBookSales.TabIndex = 0;
            this.rbBookSales.TabStop = true;
            this.rbBookSales.Text = "Книга продаж";
            this.rbBookSales.UseVisualStyleBackColor = true;
            this.rbBookSales.CheckedChanged += new System.EventHandler(this.rbBookSales_CheckedChanged);
            // 
            // btnOpenExpense
            // 
            this.btnOpenExpense.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenExpense.Location = new System.Drawing.Point(779, 370);
            this.btnOpenExpense.Name = "btnOpenExpense";
            this.btnOpenExpense.Size = new System.Drawing.Size(140, 30);
            this.btnOpenExpense.TabIndex = 2;
            this.btnOpenExpense.Text = "Открыть расход";
            this.btnOpenExpense.UseVisualStyleBackColor = true;
            this.btnOpenExpense.Click += new System.EventHandler(this.btnOpenExpense_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrint.Location = new System.Drawing.Point(750, 495);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 30);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(856, 495);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvBookPurchaseAndSales
            // 
            this.dgvBookPurchaseAndSales.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBookPurchaseAndSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookPurchaseAndSales.Location = new System.Drawing.Point(18, 12);
            this.dgvBookPurchaseAndSales.MultiSelect = false;
            this.dgvBookPurchaseAndSales.Name = "dgvBookPurchaseAndSales";
            this.dgvBookPurchaseAndSales.ReadOnly = true;
            this.dgvBookPurchaseAndSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookPurchaseAndSales.Size = new System.Drawing.Size(945, 336);
            this.dgvBookPurchaseAndSales.TabIndex = 5;
            this.dgvBookPurchaseAndSales.VirtualMode = true;
            this.dgvBookPurchaseAndSales.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBookPurchaseAndSales_CellMouseDoubleClick);
            // 
            // dgvPrint
            // 
            this.dgvPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrint.Location = new System.Drawing.Point(406, 112);
            this.dgvPrint.Name = "dgvPrint";
            this.dgvPrint.Size = new System.Drawing.Size(240, 150);
            this.dgvPrint.TabIndex = 6;
            this.dgvPrint.Visible = false;
            // 
            // fBookPurchaseAndSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 537);
            this.Controls.Add(this.dgvPrint);
            this.Controls.Add(this.dgvBookPurchaseAndSales);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnOpenExpense);
            this.Controls.Add(this.gbSettings);
            this.Name = "fBookPurchaseAndSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Книга продаж / покупок";
            this.Load += new System.EventHandler(this.fBookPurchaseAndSales_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookPurchaseAndSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.ComboBox cbxPartner;
        private System.Windows.Forms.ComboBox cbxPointOfSale;
        private System.Windows.Forms.CheckBox cbPartner;
        private System.Windows.Forms.CheckBox cbPointOfSale;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox cbEnd;
        private System.Windows.Forms.CheckBox cbStart;
        private System.Windows.Forms.CheckBox cbCashier;
        private System.Windows.Forms.ComboBox cbxCashier;
        private System.Windows.Forms.ComboBox cbxManager;
        private System.Windows.Forms.CheckBox cbManager;
        private System.Windows.Forms.RadioButton rbBookPurchase;
        private System.Windows.Forms.RadioButton rbBookSales;
        private System.Windows.Forms.Button btnOpenExpense;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private DoubleBufferedDataGridView dgvBookPurchaseAndSales;
        private System.Windows.Forms.DataGridView dgvPrint;
    }
}