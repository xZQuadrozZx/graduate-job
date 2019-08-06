namespace MotorAuto
{
    partial class fWarehouse
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
            this.cbxGroupProduct = new System.Windows.Forms.CheckBox();
            this.cbxPointOfSale = new System.Windows.Forms.CheckBox();
            this.cbGroupProduct = new System.Windows.Forms.ComboBox();
            this.cbPointOfSale = new System.Windows.Forms.ComboBox();
            this.btnMoveProduct = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbShowImg = new System.Windows.Forms.CheckBox();
            this.dgvProductCopy = new System.Windows.Forms.DataGridView();
            this.dgvProduct = new MotorAuto.DoubleBufferedDataGridView();
            this.btnSale = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxGroupProduct
            // 
            this.cbxGroupProduct.AutoSize = true;
            this.cbxGroupProduct.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxGroupProduct.Location = new System.Drawing.Point(12, 13);
            this.cbxGroupProduct.Name = "cbxGroupProduct";
            this.cbxGroupProduct.Size = new System.Drawing.Size(137, 23);
            this.cbxGroupProduct.TabIndex = 0;
            this.cbxGroupProduct.Text = "Группа товара:";
            this.cbxGroupProduct.UseVisualStyleBackColor = true;
            this.cbxGroupProduct.CheckedChanged += new System.EventHandler(this.cbxGroupProduct_CheckedChanged);
            // 
            // cbxPointOfSale
            // 
            this.cbxPointOfSale.AutoSize = true;
            this.cbxPointOfSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxPointOfSale.Location = new System.Drawing.Point(571, 14);
            this.cbxPointOfSale.Name = "cbxPointOfSale";
            this.cbxPointOfSale.Size = new System.Drawing.Size(134, 23);
            this.cbxPointOfSale.TabIndex = 1;
            this.cbxPointOfSale.Text = "Торговая точка:";
            this.cbxPointOfSale.UseVisualStyleBackColor = true;
            this.cbxPointOfSale.CheckedChanged += new System.EventHandler(this.cbxPointOfSale_CheckedChanged);
            // 
            // cbGroupProduct
            // 
            this.cbGroupProduct.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbGroupProduct.FormattingEnabled = true;
            this.cbGroupProduct.Location = new System.Drawing.Point(155, 11);
            this.cbGroupProduct.Name = "cbGroupProduct";
            this.cbGroupProduct.Size = new System.Drawing.Size(250, 25);
            this.cbGroupProduct.TabIndex = 2;
            this.cbGroupProduct.SelectedValueChanged += new System.EventHandler(this.cbGroupProduct_SelectedValueChanged);
            // 
            // cbPointOfSale
            // 
            this.cbPointOfSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPointOfSale.FormattingEnabled = true;
            this.cbPointOfSale.Location = new System.Drawing.Point(711, 12);
            this.cbPointOfSale.Name = "cbPointOfSale";
            this.cbPointOfSale.Size = new System.Drawing.Size(250, 25);
            this.cbPointOfSale.TabIndex = 3;
            this.cbPointOfSale.SelectedValueChanged += new System.EventHandler(this.cbPointOfSale_SelectedValueChanged);
            // 
            // btnMoveProduct
            // 
            this.btnMoveProduct.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMoveProduct.Location = new System.Drawing.Point(284, 438);
            this.btnMoveProduct.Name = "btnMoveProduct";
            this.btnMoveProduct.Size = new System.Drawing.Size(181, 30);
            this.btnMoveProduct.TabIndex = 6;
            this.btnMoveProduct.Text = "Перемещение товара";
            this.btnMoveProduct.UseVisualStyleBackColor = true;
            this.btnMoveProduct.Click += new System.EventHandler(this.btnMoveProduct_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrint.Location = new System.Drawing.Point(805, 438);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 30);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(886, 438);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbShowImg
            // 
            this.cbShowImg.AutoSize = true;
            this.cbShowImg.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbShowImg.Location = new System.Drawing.Point(12, 438);
            this.cbShowImg.Name = "cbShowImg";
            this.cbShowImg.Size = new System.Drawing.Size(266, 23);
            this.cbShowImg.TabIndex = 9;
            this.cbShowImg.Text = "Показывать изображение товара";
            this.cbShowImg.UseVisualStyleBackColor = true;
            this.cbShowImg.CheckedChanged += new System.EventHandler(this.cbShowImg_CheckedChanged);
            // 
            // dgvProductCopy
            // 
            this.dgvProductCopy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductCopy.Location = new System.Drawing.Point(627, 215);
            this.dgvProductCopy.Name = "dgvProductCopy";
            this.dgvProductCopy.Size = new System.Drawing.Size(240, 150);
            this.dgvProductCopy.TabIndex = 11;
            this.dgvProductCopy.Visible = false;
            // 
            // dgvProduct
            // 
            this.dgvProduct.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(12, 46);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.Size = new System.Drawing.Size(949, 386);
            this.dgvProduct.TabIndex = 10;
            this.dgvProduct.SelectionChanged += new System.EventHandler(this.dgvProduct_SelectionChanged);
            // 
            // btnSale
            // 
            this.btnSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSale.Location = new System.Drawing.Point(471, 438);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(170, 30);
            this.btnSale.TabIndex = 12;
            this.btnSale.Text = "Товар в расход";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Visible = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // fWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 474);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.dgvProductCopy);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.cbShowImg);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnMoveProduct);
            this.Controls.Add(this.cbPointOfSale);
            this.Controls.Add(this.cbGroupProduct);
            this.Controls.Add(this.cbxPointOfSale);
            this.Controls.Add(this.cbxGroupProduct);
            this.Name = "fWarehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Склад";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fWarehouse_FormClosing);
            this.Load += new System.EventHandler(this.fWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxGroupProduct;
        private System.Windows.Forms.CheckBox cbxPointOfSale;
        private System.Windows.Forms.ComboBox cbGroupProduct;
        private System.Windows.Forms.ComboBox cbPointOfSale;
        private System.Windows.Forms.Button btnMoveProduct;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox cbShowImg;
        private DoubleBufferedDataGridView dgvProduct;
        private System.Windows.Forms.DataGridView dgvProductCopy;
        private System.Windows.Forms.Button btnSale;
    }
}