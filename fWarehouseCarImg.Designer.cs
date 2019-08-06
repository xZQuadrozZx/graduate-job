namespace MotorAuto
{
    partial class fWarehouseCarImg
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
            this.pbCarPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCarPhoto
            // 
            this.pbCarPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCarPhoto.Location = new System.Drawing.Point(0, 0);
            this.pbCarPhoto.Name = "pbCarPhoto";
            this.pbCarPhoto.Size = new System.Drawing.Size(334, 311);
            this.pbCarPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCarPhoto.TabIndex = 0;
            this.pbCarPhoto.TabStop = false;
            // 
            // fWarehouseCarImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.pbCarPhoto);
            this.Name = "fWarehouseCarImg";
            this.Text = "Изображение товара";
            this.Load += new System.EventHandler(this.fWarehouseCarImg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCarPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbCarPhoto;
    }
}