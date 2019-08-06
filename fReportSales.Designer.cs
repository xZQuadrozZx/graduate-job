namespace MotorAuto
{
    partial class fReportSales
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
            this.lReport = new System.Windows.Forms.Label();
            this.cbxReport = new System.Windows.Forms.ComboBox();
            this.lStart = new System.Windows.Forms.Label();
            this.lEnd = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.cbSelectPointOfSale = new System.Windows.Forms.CheckBox();
            this.cbxSelectPointOfSale = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.cbManager = new System.Windows.Forms.CheckBox();
            this.cbxManager = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lReport
            // 
            this.lReport.AutoSize = true;
            this.lReport.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lReport.Location = new System.Drawing.Point(12, 9);
            this.lReport.Name = "lReport";
            this.lReport.Size = new System.Drawing.Size(50, 19);
            this.lReport.TabIndex = 0;
            this.lReport.Text = "Отчет:";
            // 
            // cbxReport
            // 
            this.cbxReport.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxReport.FormattingEnabled = true;
            this.cbxReport.Items.AddRange(new object[] {
            "Продажи по точкам продаж",
            "Продажи по менеджерам"});
            this.cbxReport.Location = new System.Drawing.Point(70, 6);
            this.cbxReport.Name = "cbxReport";
            this.cbxReport.Size = new System.Drawing.Size(269, 25);
            this.cbxReport.TabIndex = 1;
            this.cbxReport.SelectedValueChanged += new System.EventHandler(this.cbxReport_SelectedValueChanged);
            // 
            // lStart
            // 
            this.lStart.AutoSize = true;
            this.lStart.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStart.Location = new System.Drawing.Point(362, 9);
            this.lStart.Name = "lStart";
            this.lStart.Size = new System.Drawing.Size(22, 19);
            this.lStart.TabIndex = 2;
            this.lStart.Text = "с:";
            // 
            // lEnd
            // 
            this.lEnd.AutoSize = true;
            this.lEnd.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lEnd.Location = new System.Drawing.Point(514, 9);
            this.lEnd.Name = "lEnd";
            this.lEnd.Size = new System.Drawing.Size(30, 19);
            this.lEnd.TabIndex = 3;
            this.lEnd.Text = "по:";
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(390, 7);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 24);
            this.dtpStart.TabIndex = 4;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(550, 7);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 24);
            this.dtpEnd.TabIndex = 5;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // cbSelectPointOfSale
            // 
            this.cbSelectPointOfSale.AutoSize = true;
            this.cbSelectPointOfSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSelectPointOfSale.Location = new System.Drawing.Point(16, 48);
            this.cbSelectPointOfSale.Name = "cbSelectPointOfSale";
            this.cbSelectPointOfSale.Size = new System.Drawing.Size(220, 23);
            this.cbSelectPointOfSale.TabIndex = 6;
            this.cbSelectPointOfSale.Text = "Отобрать по точке продаж:";
            this.cbSelectPointOfSale.UseVisualStyleBackColor = true;
            this.cbSelectPointOfSale.Visible = false;
            this.cbSelectPointOfSale.CheckedChanged += new System.EventHandler(this.cbSelectPointOfSale_CheckedChanged);
            // 
            // cbxSelectPointOfSale
            // 
            this.cbxSelectPointOfSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxSelectPointOfSale.FormattingEnabled = true;
            this.cbxSelectPointOfSale.Location = new System.Drawing.Point(242, 47);
            this.cbxSelectPointOfSale.Name = "cbxSelectPointOfSale";
            this.cbxSelectPointOfSale.Size = new System.Drawing.Size(260, 25);
            this.cbxSelectPointOfSale.TabIndex = 7;
            this.cbxSelectPointOfSale.Visible = false;
            this.cbxSelectPointOfSale.SelectedValueChanged += new System.EventHandler(this.cbxSelectPointOfSale_SelectedValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrint.Location = new System.Drawing.Point(632, 408);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 30);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(713, 408);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(16, 78);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(772, 324);
            this.dgvReport.TabIndex = 10;
            // 
            // cbManager
            // 
            this.cbManager.AutoSize = true;
            this.cbManager.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbManager.Location = new System.Drawing.Point(16, 48);
            this.cbManager.Name = "cbManager";
            this.cbManager.Size = new System.Drawing.Size(222, 23);
            this.cbManager.TabIndex = 11;
            this.cbManager.Text = "Отобрать по менеджерам:";
            this.cbManager.UseVisualStyleBackColor = true;
            this.cbManager.Visible = false;
            this.cbManager.CheckedChanged += new System.EventHandler(this.cbManager_CheckedChanged);
            // 
            // cbxManager
            // 
            this.cbxManager.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxManager.FormattingEnabled = true;
            this.cbxManager.Location = new System.Drawing.Point(242, 47);
            this.cbxManager.Name = "cbxManager";
            this.cbxManager.Size = new System.Drawing.Size(260, 25);
            this.cbxManager.TabIndex = 12;
            this.cbxManager.Visible = false;
            this.cbxManager.SelectedValueChanged += new System.EventHandler(this.cbxManager_SelectedValueChanged);
            // 
            // fReportSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxManager);
            this.Controls.Add(this.cbManager);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cbxSelectPointOfSale);
            this.Controls.Add(this.cbSelectPointOfSale);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lEnd);
            this.Controls.Add(this.lStart);
            this.Controls.Add(this.cbxReport);
            this.Controls.Add(this.lReport);
            this.Name = "fReportSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчеты по продажам";
            this.Load += new System.EventHandler(this.fReportSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lReport;
        private System.Windows.Forms.ComboBox cbxReport;
        private System.Windows.Forms.Label lStart;
        private System.Windows.Forms.Label lEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.CheckBox cbSelectPointOfSale;
        private System.Windows.Forms.ComboBox cbxSelectPointOfSale;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.CheckBox cbManager;
        private System.Windows.Forms.ComboBox cbxManager;
    }
}