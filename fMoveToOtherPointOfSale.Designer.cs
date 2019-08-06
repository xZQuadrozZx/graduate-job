namespace MotorAuto
{
    partial class fMoveToOtherPointOfSale
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
            this.lFromPointOfSale = new System.Windows.Forms.Label();
            this.lToPointOfSale = new System.Windows.Forms.Label();
            this.cbxFromPointOfSale = new System.Windows.Forms.ComboBox();
            this.cbxToPointOfSale = new System.Windows.Forms.ComboBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.lCount = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.cbxToPOS = new System.Windows.Forms.ComboBox();
            this.cbxFromPOS = new System.Windows.Forms.ComboBox();
            this.cbToPointOfSale = new System.Windows.Forms.CheckBox();
            this.cbFromPointOfSale = new System.Windows.Forms.CheckBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cbEnd = new System.Windows.Forms.CheckBox();
            this.cbStart = new System.Windows.Forms.CheckBox();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.dgvToCopy = new System.Windows.Forms.DataGridView();
            this.dgvTo = new MotorAuto.DoubleBufferedDataGridView();
            this.dgvFrom = new MotorAuto.DoubleBufferedDataGridView();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // lFromPointOfSale
            // 
            this.lFromPointOfSale.AutoSize = true;
            this.lFromPointOfSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lFromPointOfSale.Location = new System.Drawing.Point(12, 9);
            this.lFromPointOfSale.Name = "lFromPointOfSale";
            this.lFromPointOfSale.Size = new System.Drawing.Size(69, 19);
            this.lFromPointOfSale.TabIndex = 0;
            this.lFromPointOfSale.Text = "Из точки:";
            // 
            // lToPointOfSale
            // 
            this.lToPointOfSale.AutoSize = true;
            this.lToPointOfSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lToPointOfSale.Location = new System.Drawing.Point(574, 9);
            this.lToPointOfSale.Name = "lToPointOfSale";
            this.lToPointOfSale.Size = new System.Drawing.Size(72, 19);
            this.lToPointOfSale.TabIndex = 1;
            this.lToPointOfSale.Text = "На точку:";
            // 
            // cbxFromPointOfSale
            // 
            this.cbxFromPointOfSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxFromPointOfSale.FormattingEnabled = true;
            this.cbxFromPointOfSale.Location = new System.Drawing.Point(87, 6);
            this.cbxFromPointOfSale.Name = "cbxFromPointOfSale";
            this.cbxFromPointOfSale.Size = new System.Drawing.Size(227, 25);
            this.cbxFromPointOfSale.TabIndex = 2;
            this.cbxFromPointOfSale.SelectedValueChanged += new System.EventHandler(this.cbxFromPointOfSale_SelectedValueChanged);
            // 
            // cbxToPointOfSale
            // 
            this.cbxToPointOfSale.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxToPointOfSale.FormattingEnabled = true;
            this.cbxToPointOfSale.Location = new System.Drawing.Point(652, 6);
            this.cbxToPointOfSale.Name = "cbxToPointOfSale";
            this.cbxToPointOfSale.Size = new System.Drawing.Size(227, 25);
            this.cbxToPointOfSale.TabIndex = 3;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTransfer.Location = new System.Drawing.Point(320, 6);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(119, 25);
            this.btnTransfer.TabIndex = 4;
            this.btnTransfer.Text = "Переместить";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCount.Location = new System.Drawing.Point(522, 9);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(30, 19);
            this.lCount.TabIndex = 6;
            this.lCount.Text = "ед.";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrint.Location = new System.Drawing.Point(746, 569);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 30);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(827, 569);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.cbxToPOS);
            this.gbSettings.Controls.Add(this.cbxFromPOS);
            this.gbSettings.Controls.Add(this.cbToPointOfSale);
            this.gbSettings.Controls.Add(this.cbFromPointOfSale);
            this.gbSettings.Controls.Add(this.dtpEnd);
            this.gbSettings.Controls.Add(this.dtpStart);
            this.gbSettings.Controls.Add(this.cbEnd);
            this.gbSettings.Controls.Add(this.cbStart);
            this.gbSettings.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbSettings.Location = new System.Drawing.Point(12, 569);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(504, 80);
            this.gbSettings.TabIndex = 12;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Отбор операций перемещения";
            // 
            // cbxToPOS
            // 
            this.cbxToPOS.FormattingEnabled = true;
            this.cbxToPOS.Location = new System.Drawing.Point(281, 48);
            this.cbxToPOS.Name = "cbxToPOS";
            this.cbxToPOS.Size = new System.Drawing.Size(217, 25);
            this.cbxToPOS.TabIndex = 7;
            this.cbxToPOS.SelectedValueChanged += new System.EventHandler(this.cbxToPOS_SelectedValueChanged);
            // 
            // cbxFromPOS
            // 
            this.cbxFromPOS.FormattingEnabled = true;
            this.cbxFromPOS.Location = new System.Drawing.Point(281, 21);
            this.cbxFromPOS.Name = "cbxFromPOS";
            this.cbxFromPOS.Size = new System.Drawing.Size(217, 25);
            this.cbxFromPOS.TabIndex = 6;
            this.cbxFromPOS.SelectedValueChanged += new System.EventHandler(this.cbxFromPOS_SelectedValueChanged);
            // 
            // cbToPointOfSale
            // 
            this.cbToPointOfSale.AutoSize = true;
            this.cbToPointOfSale.Location = new System.Drawing.Point(188, 48);
            this.cbToPointOfSale.Name = "cbToPointOfSale";
            this.cbToPointOfSale.Size = new System.Drawing.Size(89, 23);
            this.cbToPointOfSale.TabIndex = 5;
            this.cbToPointOfSale.Text = "на точку:";
            this.cbToPointOfSale.UseVisualStyleBackColor = true;
            this.cbToPointOfSale.CheckedChanged += new System.EventHandler(this.cbToPointOfSale_CheckedChanged);
            // 
            // cbFromPointOfSale
            // 
            this.cbFromPointOfSale.AutoSize = true;
            this.cbFromPointOfSale.Location = new System.Drawing.Point(188, 23);
            this.cbFromPointOfSale.Name = "cbFromPointOfSale";
            this.cbFromPointOfSale.Size = new System.Drawing.Size(87, 23);
            this.cbFromPointOfSale.TabIndex = 4;
            this.cbFromPointOfSale.Text = "из точки:";
            this.cbFromPointOfSale.UseVisualStyleBackColor = true;
            this.cbFromPointOfSale.CheckedChanged += new System.EventHandler(this.cbFromPointOfSale_CheckedChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(61, 48);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(102, 24);
            this.dtpEnd.TabIndex = 3;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(61, 23);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(102, 24);
            this.dtpStart.TabIndex = 2;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // cbEnd
            // 
            this.cbEnd.AutoSize = true;
            this.cbEnd.Location = new System.Drawing.Point(6, 48);
            this.cbEnd.Name = "cbEnd";
            this.cbEnd.Size = new System.Drawing.Size(49, 23);
            this.cbEnd.TabIndex = 1;
            this.cbEnd.Text = "по:";
            this.cbEnd.UseVisualStyleBackColor = true;
            this.cbEnd.CheckedChanged += new System.EventHandler(this.cbEnd_CheckedChanged);
            // 
            // cbStart
            // 
            this.cbStart.AutoSize = true;
            this.cbStart.Location = new System.Drawing.Point(6, 23);
            this.cbStart.Name = "cbStart";
            this.cbStart.Size = new System.Drawing.Size(41, 23);
            this.cbStart.TabIndex = 0;
            this.cbStart.Text = "с:";
            this.cbStart.UseVisualStyleBackColor = true;
            this.cbStart.CheckedChanged += new System.EventHandler(this.cbStart_CheckedChanged);
            // 
            // nudCount
            // 
            this.nudCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudCount.Location = new System.Drawing.Point(445, 7);
            this.nudCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(71, 23);
            this.nudCount.TabIndex = 13;
            this.nudCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgvToCopy
            // 
            this.dgvToCopy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToCopy.Location = new System.Drawing.Point(662, 147);
            this.dgvToCopy.Name = "dgvToCopy";
            this.dgvToCopy.Size = new System.Drawing.Size(240, 150);
            this.dgvToCopy.TabIndex = 16;
            this.dgvToCopy.Visible = false;
            // 
            // dgvTo
            // 
            this.dgvTo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTo.Location = new System.Drawing.Point(12, 303);
            this.dgvTo.Name = "dgvTo";
            this.dgvTo.Size = new System.Drawing.Size(890, 260);
            this.dgvTo.TabIndex = 15;
            // 
            // dgvFrom
            // 
            this.dgvFrom.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFrom.Location = new System.Drawing.Point(12, 37);
            this.dgvFrom.Name = "dgvFrom";
            this.dgvFrom.Size = new System.Drawing.Size(890, 260);
            this.dgvFrom.TabIndex = 14;
            // 
            // fMoveToOtherPointOfSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 658);
            this.Controls.Add(this.dgvToCopy);
            this.Controls.Add(this.dgvTo);
            this.Controls.Add(this.dgvFrom);
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lCount);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.cbxToPointOfSale);
            this.Controls.Add(this.cbxFromPointOfSale);
            this.Controls.Add(this.lToPointOfSale);
            this.Controls.Add(this.lFromPointOfSale);
            this.Name = "fMoveToOtherPointOfSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перемещение товара между точками продаж";
            this.Load += new System.EventHandler(this.fMoveToOtherPointOfSale_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lFromPointOfSale;
        private System.Windows.Forms.Label lToPointOfSale;
        private System.Windows.Forms.ComboBox cbxFromPointOfSale;
        private System.Windows.Forms.ComboBox cbxToPointOfSale;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Label lCount;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.CheckBox cbEnd;
        private System.Windows.Forms.CheckBox cbStart;
        private System.Windows.Forms.ComboBox cbxToPOS;
        private System.Windows.Forms.ComboBox cbxFromPOS;
        private System.Windows.Forms.CheckBox cbToPointOfSale;
        private System.Windows.Forms.CheckBox cbFromPointOfSale;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.NumericUpDown nudCount;
        private DoubleBufferedDataGridView dgvFrom;
        private DoubleBufferedDataGridView dgvTo;
        private System.Windows.Forms.DataGridView dgvToCopy;
    }
}