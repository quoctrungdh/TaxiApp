namespace QL_TaXi
{
    partial class FormKH_CacChuyenDi
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvKh_ChuyenDi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKh_ChuyenDi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "CÁC CHUYẾN ĐI CỦA KHÁCH HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvKh_ChuyenDi
            // 
            this.dgvKh_ChuyenDi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKh_ChuyenDi.Location = new System.Drawing.Point(2, 66);
            this.dgvKh_ChuyenDi.Name = "dgvKh_ChuyenDi";
            this.dgvKh_ChuyenDi.Size = new System.Drawing.Size(477, 182);
            this.dgvKh_ChuyenDi.TabIndex = 1;
            // 
            // FormKH_CacChuyenDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 256);
            this.Controls.Add(this.dgvKh_ChuyenDi);
            this.Controls.Add(this.label1);
            this.Name = "FormKH_CacChuyenDi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Các Chuyến Đi";
            this.Load += new System.EventHandler(this.FormKH_CacChuyenDi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKh_ChuyenDi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvKh_ChuyenDi;
    }
}