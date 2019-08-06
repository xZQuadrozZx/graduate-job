namespace MotorAuto
{
    partial class fPartner
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
            this.dgvPartner = new System.Windows.Forms.DataGridView();
            this.lFIO = new System.Windows.Forms.Label();
            this.txtFIOorName = new System.Windows.Forms.TextBox();
            this.cbSupplier = new System.Windows.Forms.CheckBox();
            this.lPassport = new System.Windows.Forms.Label();
            this.lInfo = new System.Windows.Forms.Label();
            this.lAddress = new System.Windows.Forms.Label();
            this.lPhones = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.txtPhones = new System.Windows.Forms.TextBox();
            this.lBank = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.lINN = new System.Windows.Forms.Label();
            this.lKPP = new System.Windows.Forms.Label();
            this.cbSelect = new System.Windows.Forms.CheckBox();
            this.cbxSelect = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.MaskedTextBox();
            this.txtPassport = new System.Windows.Forms.MaskedTextBox();
            this.txtINN = new System.Windows.Forms.MaskedTextBox();
            this.txtKPP = new System.Windows.Forms.MaskedTextBox();
            this.dgvPartnerCopy = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartnerCopy)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPartner
            // 
            this.dgvPartner.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPartner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartner.Location = new System.Drawing.Point(12, 12);
            this.dgvPartner.Name = "dgvPartner";
            this.dgvPartner.Size = new System.Drawing.Size(593, 356);
            this.dgvPartner.TabIndex = 0;
            this.dgvPartner.SelectionChanged += new System.EventHandler(this.dgvPartner_SelectionChanged);
            // 
            // lFIO
            // 
            this.lFIO.AutoSize = true;
            this.lFIO.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lFIO.Location = new System.Drawing.Point(611, 12);
            this.lFIO.Name = "lFIO";
            this.lFIO.Size = new System.Drawing.Size(284, 19);
            this.lFIO.TabIndex = 1;
            this.lFIO.Text = "ФИО / Наименование оранизации (*):";
            // 
            // txtFIOorName
            // 
            this.txtFIOorName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFIOorName.Location = new System.Drawing.Point(615, 32);
            this.txtFIOorName.Name = "txtFIOorName";
            this.txtFIOorName.Size = new System.Drawing.Size(368, 24);
            this.txtFIOorName.TabIndex = 2;
            // 
            // cbSupplier
            // 
            this.cbSupplier.AutoSize = true;
            this.cbSupplier.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSupplier.Location = new System.Drawing.Point(615, 62);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(481, 23);
            this.cbSupplier.TabIndex = 3;
            this.cbSupplier.Text = "Поставщик (снятая галка, означает, что контрагент - покупатель)";
            this.cbSupplier.UseVisualStyleBackColor = true;
            // 
            // lPassport
            // 
            this.lPassport.AutoSize = true;
            this.lPassport.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPassport.Location = new System.Drawing.Point(611, 88);
            this.lPassport.Name = "lPassport";
            this.lPassport.Size = new System.Drawing.Size(74, 19);
            this.lPassport.TabIndex = 4;
            this.lPassport.Text = "Паспорт:";
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lInfo.Location = new System.Drawing.Point(611, 117);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(111, 19);
            this.lInfo.TabIndex = 5;
            this.lInfo.Text = "Информация:";
            // 
            // lAddress
            // 
            this.lAddress.AutoSize = true;
            this.lAddress.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lAddress.Location = new System.Drawing.Point(611, 147);
            this.lAddress.Name = "lAddress";
            this.lAddress.Size = new System.Drawing.Size(78, 19);
            this.lAddress.TabIndex = 6;
            this.lAddress.Text = "Адрес (*):";
            // 
            // lPhones
            // 
            this.lPhones.AutoSize = true;
            this.lPhones.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPhones.Location = new System.Drawing.Point(611, 177);
            this.lPhones.Name = "lPhones";
            this.lPhones.Size = new System.Drawing.Size(105, 19);
            this.lPhones.TabIndex = 7;
            this.lPhones.Text = "Телефоны (*):";
            // 
            // txtInfo
            // 
            this.txtInfo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInfo.Location = new System.Drawing.Point(728, 114);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(255, 24);
            this.txtInfo.TabIndex = 9;
            // 
            // txtPhones
            // 
            this.txtPhones.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPhones.Location = new System.Drawing.Point(728, 174);
            this.txtPhones.Name = "txtPhones";
            this.txtPhones.Size = new System.Drawing.Size(255, 24);
            this.txtPhones.TabIndex = 11;
            this.txtPhones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhones_KeyPress);
            // 
            // lBank
            // 
            this.lBank.AutoSize = true;
            this.lBank.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lBank.Location = new System.Drawing.Point(611, 217);
            this.lBank.Name = "lBank";
            this.lBank.Size = new System.Drawing.Size(171, 19);
            this.lBank.TabIndex = 12;
            this.lBank.Text = "Банковские реквизиты:";
            // 
            // txtBank
            // 
            this.txtBank.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBank.Location = new System.Drawing.Point(615, 239);
            this.txtBank.Multiline = true;
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(368, 96);
            this.txtBank.TabIndex = 13;
            // 
            // lINN
            // 
            this.lINN.AutoSize = true;
            this.lINN.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lINN.Location = new System.Drawing.Point(611, 347);
            this.lINN.Name = "lINN";
            this.lINN.Size = new System.Drawing.Size(43, 19);
            this.lINN.TabIndex = 14;
            this.lINN.Text = "ИНН:";
            // 
            // lKPP
            // 
            this.lKPP.AutoSize = true;
            this.lKPP.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lKPP.Location = new System.Drawing.Point(806, 347);
            this.lKPP.Name = "lKPP";
            this.lKPP.Size = new System.Drawing.Size(41, 19);
            this.lKPP.TabIndex = 15;
            this.lKPP.Text = "КПП:";
            // 
            // cbSelect
            // 
            this.cbSelect.AutoSize = true;
            this.cbSelect.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSelect.Location = new System.Drawing.Point(12, 375);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.Size = new System.Drawing.Size(99, 23);
            this.cbSelect.TabIndex = 19;
            this.cbSelect.Text = "Отобрать:";
            this.cbSelect.UseVisualStyleBackColor = true;
            this.cbSelect.CheckedChanged += new System.EventHandler(this.cbSelect_CheckedChanged);
            // 
            // cbxSelect
            // 
            this.cbxSelect.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxSelect.FormattingEnabled = true;
            this.cbxSelect.Items.AddRange(new object[] {
            "поставщиков",
            "покупателей"});
            this.cbxSelect.Location = new System.Drawing.Point(117, 374);
            this.cbxSelect.Name = "cbxSelect";
            this.cbxSelect.Size = new System.Drawing.Size(131, 25);
            this.cbxSelect.TabIndex = 20;
            this.cbxSelect.SelectedValueChanged += new System.EventHandler(this.cbxSelect_SelectedValueChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrint.Location = new System.Drawing.Point(827, 374);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 30);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(908, 374);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(406, 375);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(118, 30);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Новая запись";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Location = new System.Drawing.Point(530, 375);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEdit.Location = new System.Drawing.Point(299, 375);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEdit.Size = new System.Drawing.Size(101, 30);
            this.btnEdit.TabIndex = 25;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAddress.Location = new System.Drawing.Point(728, 144);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(255, 24);
            this.txtAddress.TabIndex = 26;
            // 
            // txtPassport
            // 
            this.txtPassport.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPassport.Location = new System.Drawing.Point(728, 85);
            this.txtPassport.Mask = "сер 0000 № 000000";
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(255, 24);
            this.txtPassport.TabIndex = 27;
            // 
            // txtINN
            // 
            this.txtINN.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtINN.Location = new System.Drawing.Point(660, 344);
            this.txtINN.Mask = "000000000000";
            this.txtINN.Name = "txtINN";
            this.txtINN.Size = new System.Drawing.Size(130, 24);
            this.txtINN.TabIndex = 28;
            // 
            // txtKPP
            // 
            this.txtKPP.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtKPP.Location = new System.Drawing.Point(853, 344);
            this.txtKPP.Mask = "000000000";
            this.txtKPP.Name = "txtKPP";
            this.txtKPP.Size = new System.Drawing.Size(130, 24);
            this.txtKPP.TabIndex = 29;
            // 
            // dgvPartnerCopy
            // 
            this.dgvPartnerCopy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartnerCopy.Location = new System.Drawing.Point(365, 12);
            this.dgvPartnerCopy.Name = "dgvPartnerCopy";
            this.dgvPartnerCopy.Size = new System.Drawing.Size(240, 150);
            this.dgvPartnerCopy.TabIndex = 30;
            this.dgvPartnerCopy.Visible = false;
            // 
            // fPartner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 412);
            this.Controls.Add(this.dgvPartnerCopy);
            this.Controls.Add(this.txtKPP);
            this.Controls.Add(this.txtINN);
            this.Controls.Add(this.txtPassport);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cbxSelect);
            this.Controls.Add(this.cbSelect);
            this.Controls.Add(this.lKPP);
            this.Controls.Add(this.lINN);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.lBank);
            this.Controls.Add(this.txtPhones);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lPhones);
            this.Controls.Add(this.lAddress);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.lPassport);
            this.Controls.Add(this.cbSupplier);
            this.Controls.Add(this.txtFIOorName);
            this.Controls.Add(this.lFIO);
            this.Controls.Add(this.dgvPartner);
            this.Name = "fPartner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Контрагенты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fPartner_FormClosing);
            this.Load += new System.EventHandler(this.fPartner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartnerCopy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPartner;
        private System.Windows.Forms.Label lFIO;
        private System.Windows.Forms.TextBox txtFIOorName;
        private System.Windows.Forms.CheckBox cbSupplier;
        private System.Windows.Forms.Label lPassport;
        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.Label lAddress;
        private System.Windows.Forms.Label lPhones;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.TextBox txtPhones;
        private System.Windows.Forms.Label lBank;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label lINN;
        private System.Windows.Forms.Label lKPP;
        private System.Windows.Forms.CheckBox cbSelect;
        private System.Windows.Forms.ComboBox cbxSelect;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.MaskedTextBox txtAddress;
        private System.Windows.Forms.MaskedTextBox txtPassport;
        private System.Windows.Forms.MaskedTextBox txtINN;
        private System.Windows.Forms.MaskedTextBox txtKPP;
        private System.Windows.Forms.DataGridView dgvPartnerCopy;
    }
}