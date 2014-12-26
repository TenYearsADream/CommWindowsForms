namespace CommWindowsForms
{
    partial class CommForm
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
            this.components = new System.ComponentModel.Container();
            this.dgvAddress = new System.Windows.Forms.DataGridView();
            this.btnRead = new System.Windows.Forms.Button();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.bsAddress = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tmrComm = new System.Windows.Forms.Timer(this.components);
            this.tmrLine = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddress)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAddress
            // 
            this.dgvAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddress.Location = new System.Drawing.Point(6, 20);
            this.dgvAddress.Name = "dgvAddress";
            this.dgvAddress.RowTemplate.Height = 23;
            this.dgvAddress.Size = new System.Drawing.Size(797, 453);
            this.dgvAddress.TabIndex = 0;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(644, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(87, 38);
            this.btnRead.TabIndex = 1;
            this.btnRead.Text = "btnRead";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(746, 22);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(87, 21);
            this.tbValue.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAddress);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(821, 480);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comm";
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.BlueViolet;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Location = new System.Drawing.Point(0, -1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(628, 56);
            this.pnlTitle.TabIndex = 28;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(82, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(427, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "通讯模块";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrComm
            // 
            this.tmrComm.Enabled = true;
            this.tmrComm.Interval = 3000;
            this.tmrComm.Tick += new System.EventHandler(this.tmrComm_Tick);
            // 
            // tmrLine
            // 
            this.tmrLine.Enabled = true;
            this.tmrLine.Interval = 30000;
            this.tmrLine.Tick += new System.EventHandler(this.tmrLine_Tick);
            // 
            // CommForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 548);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.btnRead);
            this.Name = "CommForm";
            this.Text = "CommForm";
            this.Load += new System.EventHandler(this.CommForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddress)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAddress;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.BindingSource bsAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer tmrComm;
        private System.Windows.Forms.Timer tmrLine;
    }
}