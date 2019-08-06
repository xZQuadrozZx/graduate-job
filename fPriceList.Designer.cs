namespace MotorAuto
{
    partial class fPriceList
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
            this.lGroupProduct = new System.Windows.Forms.Label();
            this.cbxBrand = new System.Windows.Forms.ComboBox();
            this.pbItemImg = new System.Windows.Forms.PictureBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChoicePhoto = new System.Windows.Forms.Button();
            this.btnProductTo = new System.Windows.Forms.Button();
            this.dgvALL = new System.Windows.Forms.DataGridView();
            this.btnAddAuto = new System.Windows.Forms.Button();
            this.dgvPriceList = new MotorAuto.DoubleBufferedDataGridView();
            this.dgvDBProduct = new MotorAuto.DoubleBufferedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvALL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lGroupProduct
            // 
            this.lGroupProduct.AutoSize = true;
            this.lGroupProduct.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lGroupProduct.Location = new System.Drawing.Point(12, 9);
            this.lGroupProduct.Name = "lGroupProduct";
            this.lGroupProduct.Size = new System.Drawing.Size(124, 19);
            this.lGroupProduct.TabIndex = 0;
            this.lGroupProduct.Text = "Группа товаров:";
            // 
            // cbxBrand
            // 
            this.cbxBrand.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxBrand.FormattingEnabled = true;
            this.cbxBrand.Location = new System.Drawing.Point(142, 6);
            this.cbxBrand.Name = "cbxBrand";
            this.cbxBrand.Size = new System.Drawing.Size(387, 25);
            this.cbxBrand.TabIndex = 1;
            this.cbxBrand.SelectedValueChanged += new System.EventHandler(this.cbxBrand_SelectedValueChanged);
            // 
            // pbItemImg
            // 
            this.pbItemImg.Location = new System.Drawing.Point(535, 36);
            this.pbItemImg.Name = "pbItemImg";
            this.pbItemImg.Size = new System.Drawing.Size(384, 300);
            this.pbItemImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbItemImg.TabIndex = 3;
            this.pbItemImg.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrint.Location = new System.Drawing.Point(764, 448);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 30);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(845, 448);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnChoicePhoto
            // 
            this.btnChoicePhoto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChoicePhoto.Location = new System.Drawing.Point(795, 306);
            this.btnChoicePhoto.Name = "btnChoicePhoto";
            this.btnChoicePhoto.Size = new System.Drawing.Size(124, 30);
            this.btnChoicePhoto.TabIndex = 10;
            this.btnChoicePhoto.Text = "Выбрать фото";
            this.btnChoicePhoto.UseVisualStyleBackColor = true;
            this.btnChoicePhoto.Click += new System.EventHandler(this.btnChoicePhoto_Click);
            // 
            // btnProductTo
            // 
            this.btnProductTo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProductTo.Location = new System.Drawing.Point(322, 448);
            this.btnProductTo.Name = "btnProductTo";
            this.btnProductTo.Size = new System.Drawing.Size(136, 30);
            this.btnProductTo.TabIndex = 14;
            this.btnProductTo.Text = "Товар в приход";
            this.btnProductTo.UseVisualStyleBackColor = true;
            this.btnProductTo.Visible = false;
            this.btnProductTo.Click += new System.EventHandler(this.btnProductTo_Click);
            // 
            // dgvALL
            // 
            this.dgvALL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvALL.Location = new System.Drawing.Point(551, 12);
            this.dgvALL.Name = "dgvALL";
            this.dgvALL.Size = new System.Drawing.Size(240, 150);
            this.dgvALL.TabIndex = 16;
            this.dgvALL.Visible = false;
            // 
            // btnAddAuto
            // 
            this.btnAddAuto.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddAuto.Location = new System.Drawing.Point(16, 448);
            this.btnAddAuto.Name = "btnAddAuto";
            this.btnAddAuto.Size = new System.Drawing.Size(202, 30);
            this.btnAddAuto.TabIndex = 19;
            this.btnAddAuto.Text = "Добавить автомобиль";
            this.btnAddAuto.UseVisualStyleBackColor = true;
            this.btnAddAuto.Click += new System.EventHandler(this.btnAddAuto_Click);
            // 
            // dgvPriceList
            // 
            this.dgvPriceList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceList.Location = new System.Drawing.Point(535, 342);
            this.dgvPriceList.Name = "dgvPriceList";
            this.dgvPriceList.ReadOnly = true;
            this.dgvPriceList.Size = new System.Drawing.Size(384, 100);
            this.dgvPriceList.TabIndex = 18;
            // 
            // dgvDBProduct
            // 
            this.dgvDBProduct.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDBProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDBProduct.Location = new System.Drawing.Point(16, 36);
            this.dgvDBProduct.Name = "dgvDBProduct";
            this.dgvDBProduct.ReadOnly = true;
            this.dgvDBProduct.Size = new System.Drawing.Size(513, 406);
            this.dgvDBProduct.TabIndex = 17;
            this.dgvDBProduct.SelectionChanged += new System.EventHandler(this.dgvDBProduct_SelectionChanged);
            // 
            // fPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 487);
            this.Controls.Add(this.btnAddAuto);
            this.Controls.Add(this.dgvPriceList);
            this.Controls.Add(this.dgvDBProduct);
            this.Controls.Add(this.dgvALL);
            this.Controls.Add(this.btnProductTo);
            this.Controls.Add(this.btnChoicePhoto);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pbItemImg);
            this.Controls.Add(this.cbxBrand);
            this.Controls.Add(this.lGroupProduct);
            this.Name = "fPriceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прайс-лист";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fPriceList_FormClosed);
            this.Load += new System.EventHandler(this.fPriceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvALL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lGroupProduct;
        private System.Windows.Forms.ComboBox cbxBrand;
        private System.Windows.Forms.PictureBox pbItemImg;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChoicePhoto;
        private System.Windows.Forms.Button btnProductTo;
        private System.Windows.Forms.DataGridView dgvALL;
        private DoubleBufferedDataGridView dgvPriceList;
        private System.Windows.Forms.Button btnAddAuto;
        public DoubleBufferedDataGridView dgvDBProduct;
    }
}