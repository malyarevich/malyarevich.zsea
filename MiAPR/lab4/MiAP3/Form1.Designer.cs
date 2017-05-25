namespace MiAP3 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pnlMng = new System.Windows.Forms.Panel();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.btnGO = new System.Windows.Forms.Button();
            this.Альфа = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtN2 = new System.Windows.Forms.TextBox();
            this.lblN = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.lblC1 = new System.Windows.Forms.Label();
            this.txtC2 = new System.Windows.Forms.TextBox();
            this.txtN1 = new System.Windows.Forms.TextBox();
            this.lblC2 = new System.Windows.Forms.Label();
            this.lblN1 = new System.Windows.Forms.Label();
            this.lblC3 = new System.Windows.Forms.Label();
            this.txtC1 = new System.Windows.Forms.TextBox();
            this.txtC3 = new System.Windows.Forms.TextBox();
            this.rtxtOutput = new System.Windows.Forms.RichTextBox();
            this.pnlMng.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMng
            // 
            this.pnlMng.Controls.Add(this.grdData);
            this.pnlMng.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMng.Location = new System.Drawing.Point(0, 0);
            this.pnlMng.Name = "pnlMng";
            this.pnlMng.Size = new System.Drawing.Size(680, 307);
            this.pnlMng.TabIndex = 0;
            // 
            // txtAlpha
            // 
            this.txtAlpha.Location = new System.Drawing.Point(322, 507);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(74, 20);
            this.txtAlpha.TabIndex = 14;
            this.txtAlpha.Text = "0.5";
            this.txtAlpha.Visible = false;
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData.BackgroundColor = System.Drawing.Color.White;
            this.grdData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Location = new System.Drawing.Point(8, 8);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdData.Size = new System.Drawing.Size(664, 293);
            this.grdData.TabIndex = 1;
            this.grdData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellContentClick);
            // 
            // btnGO
            // 
            this.btnGO.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGO.Location = new System.Drawing.Point(509, 512);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(159, 65);
            this.btnGO.TabIndex = 12;
            this.btnGO.Text = "Вычислить";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // Альфа
            // 
            this.Альфа.AutoSize = true;
            this.Альфа.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Альфа.Location = new System.Drawing.Point(291, 509);
            this.Альфа.Name = "Альфа";
            this.Альфа.Size = new System.Drawing.Size(16, 15);
            this.Альфа.TabIndex = 13;
            this.Альфа.Text = "А";
            this.Альфа.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(293, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "n2";
            // 
            // txtN2
            // 
            this.txtN2.Location = new System.Drawing.Point(322, 481);
            this.txtN2.Name = "txtN2";
            this.txtN2.Size = new System.Drawing.Size(74, 20);
            this.txtN2.TabIndex = 9;
            this.txtN2.Text = "1";
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblN.Location = new System.Drawing.Point(291, 353);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(16, 15);
            this.lblN.TabIndex = 0;
            this.lblN.Text = "N";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(322, 351);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(74, 20);
            this.txtN.TabIndex = 5;
            this.txtN.Text = "3";
            // 
            // lblC1
            // 
            this.lblC1.AutoSize = true;
            this.lblC1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblC1.Location = new System.Drawing.Point(291, 379);
            this.lblC1.Name = "lblC1";
            this.lblC1.Size = new System.Drawing.Size(23, 15);
            this.lblC1.TabIndex = 1;
            this.lblC1.Text = "N1";
            this.lblC1.Click += new System.EventHandler(this.lblC1_Click);
            // 
            // txtC2
            // 
            this.txtC2.Location = new System.Drawing.Point(322, 377);
            this.txtC2.Name = "txtC2";
            this.txtC2.Size = new System.Drawing.Size(74, 20);
            this.txtC2.TabIndex = 7;
            this.txtC2.Text = "100";
            // 
            // txtN1
            // 
            this.txtN1.Location = new System.Drawing.Point(322, 455);
            this.txtN1.Name = "txtN1";
            this.txtN1.Size = new System.Drawing.Size(74, 20);
            this.txtN1.TabIndex = 8;
            this.txtN1.Text = "1";
            // 
            // lblC2
            // 
            this.lblC2.AutoSize = true;
            this.lblC2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblC2.Location = new System.Drawing.Point(291, 405);
            this.lblC2.Name = "lblC2";
            this.lblC2.Size = new System.Drawing.Size(23, 15);
            this.lblC2.TabIndex = 2;
            this.lblC2.Text = "N2";
            // 
            // lblN1
            // 
            this.lblN1.AutoSize = true;
            this.lblN1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblN1.Location = new System.Drawing.Point(293, 457);
            this.lblN1.Name = "lblN1";
            this.lblN1.Size = new System.Drawing.Size(21, 15);
            this.lblN1.TabIndex = 3;
            this.lblN1.Text = "n1";
            // 
            // lblC3
            // 
            this.lblC3.AutoSize = true;
            this.lblC3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblC3.Location = new System.Drawing.Point(291, 431);
            this.lblC3.Name = "lblC3";
            this.lblC3.Size = new System.Drawing.Size(23, 15);
            this.lblC3.TabIndex = 10;
            this.lblC3.Text = "N3";
            // 
            // txtC1
            // 
            this.txtC1.Location = new System.Drawing.Point(322, 403);
            this.txtC1.Name = "txtC1";
            this.txtC1.Size = new System.Drawing.Size(74, 20);
            this.txtC1.TabIndex = 6;
            this.txtC1.Text = "50";
            // 
            // txtC3
            // 
            this.txtC3.Location = new System.Drawing.Point(322, 429);
            this.txtC3.Name = "txtC3";
            this.txtC3.Size = new System.Drawing.Size(74, 20);
            this.txtC3.TabIndex = 11;
            this.txtC3.Text = "10";
            // 
            // rtxtOutput
            // 
            this.rtxtOutput.BackColor = System.Drawing.Color.White;
            this.rtxtOutput.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtxtOutput.Location = new System.Drawing.Point(0, 307);
            this.rtxtOutput.Name = "rtxtOutput";
            this.rtxtOutput.ReadOnly = true;
            this.rtxtOutput.Size = new System.Drawing.Size(260, 282);
            this.rtxtOutput.TabIndex = 2;
            this.rtxtOutput.TabStop = false;
            this.rtxtOutput.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 589);
            this.Controls.Add(this.txtAlpha);
            this.Controls.Add(this.rtxtOutput);
            this.Controls.Add(this.pnlMng);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.Альфа);
            this.Controls.Add(this.txtC3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtC1);
            this.Controls.Add(this.txtN2);
            this.Controls.Add(this.lblC3);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.lblN1);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.lblC2);
            this.Controls.Add(this.lblC1);
            this.Controls.Add(this.txtN1);
            this.Controls.Add(this.txtC2);
            this.Name = "Form1";
            this.Text = "Laba4";
            this.pnlMng.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMng;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.TextBox txtC3;
        private System.Windows.Forms.Label lblC3;
        private System.Windows.Forms.TextBox txtN2;
        private System.Windows.Forms.TextBox txtN1;
        private System.Windows.Forms.TextBox txtC2;
        private System.Windows.Forms.TextBox txtC1;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label lblN1;
        private System.Windows.Forms.Label lblC2;
        private System.Windows.Forms.Label lblC1;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.RichTextBox rtxtOutput;
        private System.Windows.Forms.TextBox txtAlpha;
        private System.Windows.Forms.Label Альфа;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.Label label1;
    }
}

