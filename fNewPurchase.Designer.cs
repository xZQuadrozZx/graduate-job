namespace MotorAuto
{
    partial class fNewPurchase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.cbxPointOfSale = new System.Windows.Forms.ComboBox();
            this.cbxManager = new System.Windows.Forms.ComboBox();
            this.cbxPartner = new System.Windows.Forms.ComboBox();
            this.cbxCashier = new System.Windows.Forms.ComboBox();
            this.lCode = new System.Windows.Forms.Label();
            this.lDate = new System.Windows.Forms.Label();
            this.lPointOfSale = new System.Windows.Forms.Label();
            this.lManager = new System.Windows.Forms.Label();
            this.lPartner = new System.Windows.Forms.Label();
            this.lCashier = new System.Windows.Forms.Label();
            this.dgvNewPurchase = new System.Windows.Forms.DataGridView();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lTotal = new System.Windows.Forms.Label();
            this.btnSpend = new System.Windows.Forms.Button();
            this.dgvNewPurchaseCopy = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRashod = new System.Windows.Forms.DataGridView();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPurchaseCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRashod)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCode.Location = new System.Drawing.Point(16, 31);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 24);
            this.txtCode.TabIndex = 0;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDate.Location = new System.Drawing.Point(16, 80);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 24);
            this.txtDate.TabIndex = 1;
            // 
            // cbxPointOfSale
            // 
            this.cbxPointOfSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxPointOfSale.FormattingEnabled = true;
            this.cbxPointOfSale.Location = new System.Drawing.Point(137, 30);
            this.cbxPointOfSale.Name = "cbxPointOfSale";
            this.cbxPointOfSale.Size = new System.Drawing.Size(250, 25);
            this.cbxPointOfSale.TabIndex = 2;
            // 
            // cbxManager
            // 
            this.cbxManager.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxManager.FormattingEnabled = true;
            this.cbxManager.Location = new System.Drawing.Point(137, 79);
            this.cbxManager.Name = "cbxManager";
            this.cbxManager.Size = new System.Drawing.Size(250, 25);
            this.cbxManager.TabIndex = 3;
            // 
            // cbxPartner
            // 
            this.cbxPartner.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxPartner.FormattingEnabled = true;
            this.cbxPartner.Location = new System.Drawing.Point(407, 30);
            this.cbxPartner.Name = "cbxPartner";
            this.cbxPartner.Size = new System.Drawing.Size(250, 25);
            this.cbxPartner.TabIndex = 4;
            // 
            // cbxCashier
            // 
            this.cbxCashier.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxCashier.FormattingEnabled = true;
            this.cbxCashier.Location = new System.Drawing.Point(407, 79);
            this.cbxCashier.Name = "cbxCashier";
            this.cbxCashier.Size = new System.Drawing.Size(250, 25);
            this.cbxCashier.TabIndex = 5;
            // 
            // lCode
            // 
            this.lCode.AutoSize = true;
            this.lCode.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCode.Location = new System.Drawing.Point(12, 9);
            this.lCode.Name = "lCode";
            this.lCode.Size = new System.Drawing.Size(38, 19);
            this.lCode.TabIndex = 6;
            this.lCode.Text = "Код:";
            // 
            // lDate
            // 
            this.lDate.AutoSize = true;
            this.lDate.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDate.Location = new System.Drawing.Point(12, 58);
            this.lDate.Name = "lDate";
            this.lDate.Size = new System.Drawing.Size(48, 19);
            this.lDate.TabIndex = 7;
            this.lDate.Text = "Дата:";
            // 
            // lPointOfSale
            // 
            this.lPointOfSale.AutoSize = true;
            this.lPointOfSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPointOfSale.Location = new System.Drawing.Point(133, 8);
            this.lPointOfSale.Name = "lPointOfSale";
            this.lPointOfSale.Size = new System.Drawing.Size(110, 19);
            this.lPointOfSale.TabIndex = 8;
            this.lPointOfSale.Text = "Точка продаж:";
            // 
            // lManager
            // 
            this.lManager.AutoSize = true;
            this.lManager.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lManager.Location = new System.Drawing.Point(133, 58);
            this.lManager.Name = "lManager";
            this.lManager.Size = new System.Drawing.Size(168, 19);
            this.lManager.TabIndex = 9;
            this.lManager.Text = "Оформил менеджер:";
            // 
            // lPartner
            // 
            this.lPartner.AutoSize = true;
            this.lPartner.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPartner.Location = new System.Drawing.Point(403, 8);
            this.lPartner.Name = "lPartner";
            this.lPartner.Size = new System.Drawing.Size(90, 19);
            this.lPartner.TabIndex = 10;
            this.lPartner.Text = "Контрагент:";
            // 
            // lCashier
            // 
            this.lCashier.AutoSize = true;
            this.lCashier.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCashier.Location = new System.Drawing.Point(403, 57);
            this.lCashier.Name = "lCashier";
            this.lCashier.Size = new System.Drawing.Size(124, 19);
            this.lCashier.TabIndex = 11;
            this.lCashier.Text = "Провел кассир:";
            // 
            // dgvNewPurchase
            // 
            this.dgvNewPurchase.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvNewPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product,
            this.count,
            this.price,
            this.sum});
            this.dgvNewPurchase.Location = new System.Drawing.Point(16, 110);
            this.dgvNewPurchase.Name = "dgvNewPurchase";
            this.dgvNewPurchase.Size = new System.Drawing.Size(641, 280);
            this.dgvNewPurchase.TabIndex = 12;
            this.dgvNewPurchase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNewPurchase_CellDoubleClick);
            this.dgvNewPurchase.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvNewPurchase_CellValidating);
            this.dgvNewPurchase.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNewPurchase_CellValueChanged);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInvoice.Location = new System.Drawing.Point(476, 456);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(100, 30);
            this.btnInvoice.TabIndex = 13;
            this.btnInvoice.Text = "Накладная";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(582, 456);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTotal.Location = new System.Drawing.Point(557, 396);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 24);
            this.txtTotal.TabIndex = 15;
            // 
            // lTotal
            // 
            this.lTotal.AutoSize = true;
            this.lTotal.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTotal.Location = new System.Drawing.Point(499, 399);
            this.lTotal.Name = "lTotal";
            this.lTotal.Size = new System.Drawing.Size(58, 19);
            this.lTotal.TabIndex = 16;
            this.lTotal.Text = "ИТОГО:";
            // 
            // btnSpend
            // 
            this.btnSpend.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSpend.Location = new System.Drawing.Point(285, 396);
            this.btnSpend.Name = "btnSpend";
            this.btnSpend.Size = new System.Drawing.Size(102, 28);
            this.btnSpend.TabIndex = 18;
            this.btnSpend.Text = "Провести";
            this.btnSpend.UseVisualStyleBackColor = true;
            this.btnSpend.Click += new System.EventHandler(this.btnSpend_Click);
            // 
            // dgvNewPurchaseCopy
            // 
            this.dgvNewPurchaseCopy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewPurchaseCopy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvNewPurchaseCopy.Location = new System.Drawing.Point(-3, 206);
            this.dgvNewPurchaseCopy.Name = "dgvNewPurchaseCopy";
            this.dgvNewPurchaseCopy.ReadOnly = true;
            this.dgvNewPurchaseCopy.Size = new System.Drawing.Size(304, 280);
            this.dgvNewPurchaseCopy.TabIndex = 19;
            this.dgvNewPurchaseCopy.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // dgvRashod
            // 
            this.dgvRashod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRashod.Location = new System.Drawing.Point(16, 110);
            this.dgvRashod.Name = "dgvRashod";
            this.dgvRashod.Size = new System.Drawing.Size(641, 280);
            this.dgvRashod.TabIndex = 20;
            this.dgvRashod.Visible = false;
            // 
            // product
            // 
            this.product.HeaderText = "Товар";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            this.product.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.product.Width = 300;
            // 
            // count
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.count.DefaultCellStyle = dataGridViewCellStyle1;
            this.count.HeaderText = "Количество";
            this.count.Name = "count";
            this.count.Width = 80;
            // 
            // price
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.price.DefaultCellStyle = dataGridViewCellStyle2;
            this.price.HeaderText = "Цена, руб.";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // sum
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.sum.DefaultCellStyle = dataGridViewCellStyle3;
            this.sum.HeaderText = "Сумма, руб.";
            this.sum.Name = "sum";
            this.sum.ReadOnly = true;
            // 
            // fNewPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 498);
            this.Controls.Add(this.dgvRashod);
            this.Controls.Add(this.dgvNewPurchaseCopy);
            this.Controls.Add(this.btnSpend);
            this.Controls.Add(this.lTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.dgvNewPurchase);
            this.Controls.Add(this.lCashier);
            this.Controls.Add(this.lPartner);
            this.Controls.Add(this.lManager);
            this.Controls.Add(this.lPointOfSale);
            this.Controls.Add(this.lDate);
            this.Controls.Add(this.lCode);
            this.Controls.Add(this.cbxCashier);
            this.Controls.Add(this.cbxPartner);
            this.Controls.Add(this.cbxManager);
            this.Controls.Add(this.cbxPointOfSale);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtCode);
            this.Name = "fNewPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новая закупка";
            this.Activated += new System.EventHandler(this.fNewPurchase_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fNewPurchase_FormClosing);
            this.Load += new System.EventHandler(this.fNewPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPurchaseCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRashod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lCode;
        private System.Windows.Forms.Label lDate;
        private System.Windows.Forms.Label lPointOfSale;
        private System.Windows.Forms.Label lManager;
        private System.Windows.Forms.Label lPartner;
        private System.Windows.Forms.Label lCashier;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lTotal;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.TextBox txtDate;
        public System.Windows.Forms.ComboBox cbxPointOfSale;
        public System.Windows.Forms.ComboBox cbxManager;
        public System.Windows.Forms.ComboBox cbxPartner;
        public System.Windows.Forms.ComboBox cbxCashier;
        public System.Windows.Forms.DataGridView dgvNewPurchase;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.Button btnSpend;
        public System.Windows.Forms.DataGridView dgvNewPurchaseCopy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        public System.Windows.Forms.DataGridView dgvRashod;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
    }
}