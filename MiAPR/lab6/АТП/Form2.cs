using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace АТП
{
	public class Form2 : Form
	{
		private IContainer components = null;

		public DataGridView dtGrdVw2;

		private Button Принять;

		private Button prinyat;

		private Label label3;

		private Label label2;

		private TrackBar trackBar1;

		public Label l_o;

		public string[] mas_car;

		private int i__ = -1;

		private int j__ = 0;

		private int Z = 0;

		private int k = 0;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.dtGrdVw2 = new DataGridView();
			this.Принять = new Button();
			this.prinyat = new Button();
			this.label3 = new Label();
			this.label2 = new Label();
			this.trackBar1 = new TrackBar();
			this.l_o = new Label();
			((ISupportInitialize)this.dtGrdVw2).BeginInit();
			((ISupportInitialize)this.trackBar1).BeginInit();
			base.SuspendLayout();
			this.dtGrdVw2.AllowUserToAddRows = false;
			this.dtGrdVw2.AllowUserToDeleteRows = false;
			this.dtGrdVw2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dtGrdVw2.BackgroundColor = SystemColors.Control;
			this.dtGrdVw2.ColumnHeadersHeight = 30;
			this.dtGrdVw2.Dock = DockStyle.Bottom;
			this.dtGrdVw2.Location = new Point(0, 132);
			this.dtGrdVw2.Name = "dtGrdVw2";
			this.dtGrdVw2.ReadOnly = true;
			this.dtGrdVw2.RowHeadersWidth = 120;
			this.dtGrdVw2.Size = new Size(582, 155);
			this.dtGrdVw2.TabIndex = 9;
			this.Принять.Location = new Point(494, 5);
			this.Принять.Name = "Принять";
			this.Принять.Size = new Size(76, 23);
			this.Принять.TabIndex = 10;
			this.Принять.Text = "EXIT";
			this.Принять.UseVisualStyleBackColor = true;
			this.Принять.Click += new EventHandler(this.button1_Click);
			this.prinyat.Location = new Point(106, 82);
			this.prinyat.Name = "prinyat";
			this.prinyat.Size = new Size(243, 23);
			this.prinyat.TabIndex = 28;
			this.prinyat.Text = "Принять";
			this.prinyat.UseVisualStyleBackColor = true;
			this.prinyat.Click += new EventHandler(this.prinyat_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(390, 36);
			this.label3.Name = "label3";
			this.label3.Size = new Size(35, 13);
			this.label3.TabIndex = 27;
			this.label3.Text = "label3";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(49, 36);
			this.label2.Name = "label2";
			this.label2.Size = new Size(35, 13);
			this.label2.TabIndex = 26;
			this.label2.Text = "label2";
			this.trackBar1.AutoSize = false;
			this.trackBar1.LargeChange = 1;
			this.trackBar1.Location = new Point(106, 31);
			this.trackBar1.Maximum = 8;
			this.trackBar1.Minimum = -8;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.RightToLeft = RightToLeft.No;
			this.trackBar1.Size = new Size(256, 45);
			this.trackBar1.TabIndex = 24;
			this.trackBar1.TickStyle = TickStyle.TopLeft;
			this.l_o.AutoSize = true;
			this.l_o.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
			this.l_o.ForeColor = Color.Red;
			this.l_o.Location = new Point(199, 8);
			this.l_o.Name = "l_o";
			this.l_o.Size = new Size(29, 20);
			this.l_o.TabIndex = 29;
			this.l_o.Text = "11";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(582, 287);
			base.ControlBox = false;
			base.Controls.Add(this.l_o);
			base.Controls.Add(this.prinyat);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.trackBar1);
			base.Controls.Add(this.Принять);
			base.Controls.Add(this.dtGrdVw2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form2";
			base.ShowIcon = false;
			this.Text = "Введите значения";
			base.Load += new EventHandler(this.Form2_Load);
			((ISupportInitialize)this.dtGrdVw2).EndInit();
			((ISupportInitialize)this.trackBar1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public Form2()
		{
			this.InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			this.i__ = 0;
			this.j__ = this.i__ + 1;
			this.label2.Text = this.mas_car[0];
			this.label3.Text = this.mas_car[1];
			for (int i = 0; i < this.dtGrdVw2.ColumnCount; i++)
			{
				this.dtGrdVw2.Rows[i].HeaderCell.Value = this.mas_car[i];
				this.dtGrdVw2.Columns[i].HeaderText = this.mas_car[i];
			}
			for (int i = 0; i < this.dtGrdVw2.ColumnCount; i++)
			{
				this.dtGrdVw2[i, i].Value = Convert.ToString(1);
			}
			this.Z = 0;
			for (int i = 0; i < this.dtGrdVw2.ColumnCount - 1; i++)
			{
				this.Z += i + 1;
			}
		}

		private void prinyat_Click(object sender, EventArgs e)
		{
			double num = 0.0;
			this.k++;
			int num2 = this.trackBar1.Value;
			if (num2 >= 0)
			{
				num2++;
			}
			else
			{
				num2--;
			}
			if (num2 >= 1)
			{
				num = 1.0 / (double)num2;
			}
			if (num2 < 0)
			{
				num = (double)Math.Abs(num2);
			}
			this.dtGrdVw2[this.j__, this.i__].Value = Convert.ToString(Math.Round(num, 3));
			this.dtGrdVw2[this.i__, this.j__].Value = Convert.ToString(Math.Round(1.0 / num, 3));
			if (this.k == this.Z)
			{
				this.prinyat.Enabled = false;
				this.SUM();
			}
			else
			{
				this.j__++;
				if (this.i__ != this.dtGrdVw2.ColumnCount)
				{
					if (this.j__ == this.dtGrdVw2.ColumnCount)
					{
						this.i__++;
						this.j__ = this.i__ + 1;
					}
					this.label2.Text = this.mas_car[this.i__];
					this.label3.Text = this.mas_car[this.j__];
					this.trackBar1.Value = 0;
					if (this.k == this.Z)
					{
					}
				}
			}
		}

		private void SUM()
		{
			int columnCount = this.dtGrdVw2.ColumnCount;
			this.dtGrdVw2.ColumnCount = this.dtGrdVw2.ColumnCount + 1;
			this.dtGrdVw2.RowCount = this.dtGrdVw2.ColumnCount + 1;
			List<double> list = new List<double>();
			double num = 0.0;
			for (int i = 0; i < columnCount; i++)
			{
				double num2 = 0.0;
				for (int j = 0; j < columnCount; j++)
				{
					num2 += Convert.ToDouble(this.dtGrdVw2[j, i].Value);
				}
				num += num2;
				list.Add(num2);
			}
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = Math.Round(list[i] * 1.0 / num, 3);
				this.dtGrdVw2[columnCount, i].Value = Convert.ToString(list[i]);
			}
			this.dtGrdVw2[columnCount, list.Count].Value = Convert.ToString(num / num);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (this.k < this.Z)
			{
				MessageBox.Show("Данные не введены");
			}
			else
			{
				base.Close();
			}
		}
	}
}
