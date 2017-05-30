using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace АТП
{
	public class Form1 : Form
	{
		private struct S
		{
			public double ZN;

			public string str;
		}

		private string[] mas_car = new string[]
		{
			"Лев",
			"Тигр",
			"Лошадь",
			"Кенгуру"
		};

		private List<List<Form1.S>> LL = new List<List<Form1.S>>();

		private List<string> L_str = new List<string>();

		private List<Form1.S> Integr_oc;

		private List<Form1.S> L_car_maney = new List<Form1.S>();

		private List<Form1.S> L_car_maney_n = new List<Form1.S>();

		private List<List<Form1.S>> LL_R = new List<List<Form1.S>>();

		private IContainer components = null;

		private DataGridView dtGdVw1;

		private MenuStrip menuStrip1;

		private DataGridView dataGridView1;

		private ToolStripMenuItem оценкаСтиляToolStripMenuItem;

		private ToolStripMenuItem оценкаНадежностиToolStripMenuItem;

		private ToolStripMenuItem оценкаЕкономичностиToolStripMenuItem;

		private ToolStripMenuItem весаКритериевToolStripMenuItem;

		private ToolStripMenuItem результатToolStripMenuItem;

		public Form1()
		{
			this.InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click_2(object sender, EventArgs e)
		{
		}

		private void оценкаСтиляToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			form.dtGrdVw2.ColumnCount = 4;
			form.dtGrdVw2.RowCount = 4;
			form.l_o.Text = "Сила";
			form.mas_car = new string[]
			{
				"Лев",
				"Тигр",
				"Лошадь",
				"Кенгуру"
			};
			form.ShowDialog();
			Form1.S item = default(Form1.S);
			List<Form1.S> list = new List<Form1.S>();
			for (int i = 0; i < 4; i++)
			{
				item.ZN = Convert.ToDouble(form.dtGrdVw2[4, i].Value);
				item.str = form.mas_car[i];
				list.Add(item);
			}
			this.LL.Add(list);
			this.L_str.Add("Сила");
			this.оценкаСтиляToolStripMenuItem.Enabled = false;
			this.оценкаНадежностиToolStripMenuItem.Enabled = true;
		}

		private void оценкаНадежностиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			form.dtGrdVw2.ColumnCount = 4;
			form.dtGrdVw2.RowCount = 4;
			form.l_o.Text = "Скорость";
			form.mas_car = new string[]
			{
				"Лев",
				"Тигр",
				"Лошадь",
				"Кенгуру"
			};
			form.ShowDialog();
			Form1.S item = default(Form1.S);
			List<Form1.S> list = new List<Form1.S>();
			for (int i = 0; i < 4; i++)
			{
				item.ZN = Convert.ToDouble(form.dtGrdVw2[4, i].Value);
				item.str = form.mas_car[i];
				list.Add(item);
			}
			this.LL.Add(list);
			this.L_str.Add("Скорость");
			this.оценкаНадежностиToolStripMenuItem.Enabled = false;
			this.оценкаЕкономичностиToolStripMenuItem.Enabled = true;
		}

		private void оценкаЕкономичностиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			form.dtGrdVw2.ColumnCount = 4;
			form.dtGrdVw2.RowCount = 4;
			form.l_o.Text = "Ловкость";
			form.mas_car = new string[]
			{
				"Лев",
				"Тигр",
				"Лошадь",
				"Кенгуру"
			};
			form.ShowDialog();
			Form1.S item = default(Form1.S);
			List<Form1.S> list = new List<Form1.S>();
			for (int i = 0; i < 4; i++)
			{
				item.ZN = Convert.ToDouble(form.dtGrdVw2[4, i].Value);
				item.str = form.mas_car[i];
				list.Add(item);
			}
			this.LL.Add(list);
			this.L_str.Add("Ловкость");
			this.оценкаЕкономичностиToolStripMenuItem.Enabled = false;
			this.весаКритериевToolStripMenuItem.Enabled = true;
		}

		private void весаКритериевToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.dataGridView1.Visible = true;
			Form2 form = new Form2();
			form.dtGrdVw2.ColumnCount = this.L_str.Count;
			if (this.L_str.Count == 0)
			{
				MessageBox.Show("Введите данные оценок");
			}
			else
			{
				form.dtGrdVw2.RowCount = this.L_str.Count;
				form.l_o.Text = "Веса критериев";
				form.mas_car = new string[this.L_str.Count];
				for (int i = 0; i < this.L_str.Count; i++)
				{
					form.mas_car[i] = this.L_str[i];
				}
				form.ShowDialog();
				Form1.S item = default(Form1.S);
				List<Form1.S> list = new List<Form1.S>();
				for (int i = 0; i < this.L_str.Count; i++)
				{
					item.ZN = Convert.ToDouble(form.dtGrdVw2[this.L_str.Count, i].Value);
					item.str = form.mas_car[i];
					list.Add(item);
				}
				this.dataGridView1.ColumnCount = this.LL.Count + 1;
				this.dataGridView1.RowCount = this.LL[0].Count;
				for (int j = 0; j < this.LL.Count; j++)
				{
					this.dataGridView1.Columns[j].HeaderText = this.L_str[j];
					for (int i = 0; i < this.LL[j].Count; i++)
					{
						this.dataGridView1.Rows[i].HeaderCell.Value = this.LL[j][i].str;
						this.dataGridView1[j, i].Value = Convert.ToString(this.LL[j][i].ZN);
					}
				}
				this.Integr_oc = new List<Form1.S>();
				this.dataGridView1.Columns[this.LL.Count].HeaderText = "Функция полезности";
				double num = 0.0;
				for (int j = 0; j < this.LL[0].Count; j++)
				{
					double num2 = 0.0;
					for (int i = 0; i < this.LL.Count; i++)
					{
						num2 += Math.Round(this.LL[i][j].ZN * list[i].ZN, 3);
					}
					item = default(Form1.S);
					item.ZN = num2;
					item.str = this.LL[0][j].str;
					this.Integr_oc.Add(item);
					num += num2;
					this.dataGridView1[this.LL.Count, j].Value = Convert.ToString(num2);
				}
				item.ZN = num;
				item.str = "Summa";
				this.Integr_oc.Add(item);
				this.результатToolStripMenuItem.Enabled = true;
				this.весаКритериевToolStripMenuItem.Enabled = false;
			}
		}

		private void результатToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.dtGdVw1.Visible = true;
			this.dtGdVw1.ColumnCount = 4;
			this.dtGdVw1.RowCount = 5;
			this.dtGdVw1.Columns[0].HeaderText = "Содержание в $";
			this.dtGdVw1.Columns[1].HeaderText = "Содержание нормованная";
			this.dtGdVw1.Columns[2].HeaderText = "Функция полезности";
			this.dtGdVw1.Columns[3].HeaderText = "Отношение";
			double[] array = new double[]
			{
				400.0,
				700.0,
				200.0,
				300.0
			};
			Form1.S item = default(Form1.S);
			double num = 0.0;
			for (int i = 0; i < 4; i++)
			{
				item.ZN = array[i];
				item.str = this.mas_car[i];
				this.L_car_maney.Add(item);
				num += array[i];
			}
			item.ZN = num;
			item.str = "Summa";
			this.L_car_maney.Add(item);
			this.LL_R.Add(this.L_car_maney);
			double num2 = 0.0;
			for (int i = 0; i < 4; i++)
			{
				item.ZN = Math.Round(this.L_car_maney[i].ZN * 1.0 / num, 3);
				item.str = this.mas_car[i];
				this.L_car_maney_n.Add(item);
				num2 += this.L_car_maney_n[i].ZN;
			}
			item.ZN = num2;
			item.str = "Summa";
			this.L_car_maney_n.Add(item);
			this.LL_R.Add(this.L_car_maney_n);
			this.LL_R.Add(this.Integr_oc);
			List<Form1.S> list = new List<Form1.S>();
			for (int i = 0; i < 4; i++)
			{
				item.ZN = Math.Round(Math.Round(this.Integr_oc[i].ZN * 1.0 / this.L_car_maney_n[i].ZN, 3), 3);
				item.str = this.mas_car[i];
				list.Add(item);
			}
			this.LL_R.Add(list);
			for (int j = 0; j < this.LL_R.Count; j++)
			{
				for (int i = 0; i < this.LL_R[j].Count; i++)
				{
					this.dtGdVw1.Rows[i].HeaderCell.Value = this.LL_R[j][i].str;
					this.dtGdVw1[j, i].Value = Convert.ToString(this.LL_R[j][i].ZN);
				}
			}
			List<int> list2 = this.Sort(list);
			for (int j = 0; j < this.LL_R.Count; j++)
			{
				for (int i = 0; i < list2.Count; i++)
				{
					this.dtGdVw1.Rows[i].HeaderCell.Value = this.LL_R[j][list2[i]].str;
					this.dtGdVw1[j, i].Value = Convert.ToString(this.LL_R[j][list2[i]].ZN);
				}
			}
			this.результатToolStripMenuItem.Enabled = false;
		}

		private List<int> Sort(List<Form1.S> l)
		{
			List<int> list = new List<int>();
			bool[] array = new bool[l.Count];
			while (list.Count != l.Count)
			{
				double num = -9999.0;
				int num2 = 0;
				for (int i = 0; i < l.Count; i++)
				{
					if (!array[i] && num <= l[i].ZN)
					{
						num = l[i].ZN;
						num2 = i;
					}
				}
				list.Add(num2);
				array[num2] = true;
			}
			return list;
		}

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
			this.dtGdVw1 = new DataGridView();
			this.menuStrip1 = new MenuStrip();
			this.оценкаСтиляToolStripMenuItem = new ToolStripMenuItem();
			this.оценкаНадежностиToolStripMenuItem = new ToolStripMenuItem();
			this.оценкаЕкономичностиToolStripMenuItem = new ToolStripMenuItem();
			this.весаКритериевToolStripMenuItem = new ToolStripMenuItem();
			this.результатToolStripMenuItem = new ToolStripMenuItem();
			this.dataGridView1 = new DataGridView();
			((ISupportInitialize)this.dtGdVw1).BeginInit();
			this.menuStrip1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.dtGdVw1.AllowUserToAddRows = false;
			this.dtGdVw1.AllowUserToDeleteRows = false;
			this.dtGdVw1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dtGdVw1.BackgroundColor = SystemColors.Control;
			this.dtGdVw1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtGdVw1.Location = new Point(27, 251);
			this.dtGdVw1.Name = "dtGdVw1";
			this.dtGdVw1.ReadOnly = true;
			this.dtGdVw1.RowHeadersWidth = 120;
			this.dtGdVw1.Size = new Size(502, 210);
			this.dtGdVw1.TabIndex = 0;
			this.dtGdVw1.Visible = false;
			this.menuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.оценкаСтиляToolStripMenuItem,
				this.оценкаНадежностиToolStripMenuItem,
				this.оценкаЕкономичностиToolStripMenuItem,
				this.весаКритериевToolStripMenuItem,
				this.результатToolStripMenuItem
			});
			this.menuStrip1.Location = new Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new Size(563, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			this.оценкаСтиляToolStripMenuItem.Name = "оценкаСилыToolStripMenuItem";
			this.оценкаСтиляToolStripMenuItem.Size = new Size(89, 20);
			this.оценкаСтиляToolStripMenuItem.Text = "Оценка силы";
			this.оценкаСтиляToolStripMenuItem.Click += new EventHandler(this.оценкаСтиляToolStripMenuItem_Click);
			this.оценкаНадежностиToolStripMenuItem.Enabled = false;
			this.оценкаНадежностиToolStripMenuItem.Name = "оценкаСкоростиToolStripMenuItem";
			this.оценкаНадежностиToolStripMenuItem.Size = new Size(123, 20);
			this.оценкаНадежностиToolStripMenuItem.Text = "Оценка Скорости";
			this.оценкаНадежностиToolStripMenuItem.Click += new EventHandler(this.оценкаНадежностиToolStripMenuItem_Click);
			this.оценкаЕкономичностиToolStripMenuItem.Enabled = false;
			this.оценкаЕкономичностиToolStripMenuItem.Name = "оценкаЛовкостиToolStripMenuItem";
			this.оценкаЕкономичностиToolStripMenuItem.Size = new Size(137, 20);
			this.оценкаЕкономичностиToolStripMenuItem.Text = "Оценка Ловкости";
			this.оценкаЕкономичностиToolStripMenuItem.Click += new EventHandler(this.оценкаЕкономичностиToolStripMenuItem_Click);
			this.весаКритериевToolStripMenuItem.Enabled = false;
			this.весаКритериевToolStripMenuItem.Name = "весаКритериевToolStripMenuItem";
			this.весаКритериевToolStripMenuItem.Size = new Size(99, 20);
			this.весаКритериевToolStripMenuItem.Text = "Веса критериев";
			this.весаКритериевToolStripMenuItem.Click += new EventHandler(this.весаКритериевToolStripMenuItem_Click);
			this.результатToolStripMenuItem.Enabled = false;
			this.результатToolStripMenuItem.Name = "результатToolStripMenuItem";
			this.результатToolStripMenuItem.Size = new Size(72, 20);
			this.результатToolStripMenuItem.Text = "Результат";
			this.результатToolStripMenuItem.Click += new EventHandler(this.результатToolStripMenuItem_Click);
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.BackgroundColor = SystemColors.Control;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new Point(27, 39);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 120;
			this.dataGridView1.Size = new Size(502, 190);
			this.dataGridView1.TabIndex = 8;
			this.dataGridView1.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(563, 514);
			base.Controls.Add(this.dataGridView1);
			base.Controls.Add(this.dtGdVw1);
			base.Controls.Add(this.menuStrip1);
			base.MainMenuStrip = this.menuStrip1;
			base.Name = "Form1";
			this.Text = "Аналитическая иерархическая процедура Швец СП-13-2";
			base.Load += new EventHandler(this.Form1_Load);
			((ISupportInitialize)this.dtGdVw1).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
