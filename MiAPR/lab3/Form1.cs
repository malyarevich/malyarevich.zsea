// Decompiled with JetBrains decompiler
// Type: АТП.Form1
// Assembly: АТП, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE68989E-AFC4-4363-A19F-6EAE01B73FF7
// Assembly location: C:\Users\FireNero\Desktop\Lab3.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace АТП
{
  public class Form1 : Form
  {
    private IContainer components = (IContainer) null;
    private DataGridView dtGdVw1;
    private ListBox listBox1;
    private Label label2;
    private TextBox txtBxC1;
    private Label label3;
    private TextBox txtBxC2;
    private Label label4;
    private TextBox txtBxC3;
    private Label label5;
    private TextBox txtBxn2;
    private Label label6;
    private TextBox txtBxn1;
    private Label label7;
    private TextBox txtBxa;
    private int E1;
    private int N;
    private int N2;
    private int n1;
    private int n2;
    private double C1;
    private double C2;
    private double C3;
    private double Doh;
        private Button button1;
        private List<List<double>> Matreca_dohodov;

    public Form1()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.dtGdVw1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxC1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxC2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxC3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBxn2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBxn1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBxa = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGdVw1
            // 
            this.dtGdVw1.AllowUserToAddRows = false;
            this.dtGdVw1.AllowUserToDeleteRows = false;
            this.dtGdVw1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGdVw1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtGdVw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGdVw1.Location = new System.Drawing.Point(71, 12);
            this.dtGdVw1.Name = "dtGdVw1";
            this.dtGdVw1.ReadOnly = true;
            this.dtGdVw1.Size = new System.Drawing.Size(515, 273);
            this.dtGdVw1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(71, 292);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(381, 225);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "C1=";
            // 
            // txtBxC1
            // 
            this.txtBxC1.Location = new System.Drawing.Point(503, 296);
            this.txtBxC1.Name = "txtBxC1";
            this.txtBxC1.Size = new System.Drawing.Size(58, 20);
            this.txtBxC1.TabIndex = 5;
            this.txtBxC1.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "C2=";
            // 
            // txtBxC2
            // 
            this.txtBxC2.Location = new System.Drawing.Point(503, 326);
            this.txtBxC2.Name = "txtBxC2";
            this.txtBxC2.Size = new System.Drawing.Size(58, 20);
            this.txtBxC2.TabIndex = 7;
            this.txtBxC2.Text = "50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "C3=";
            // 
            // txtBxC3
            // 
            this.txtBxC3.Location = new System.Drawing.Point(503, 355);
            this.txtBxC3.Name = "txtBxC3";
            this.txtBxC3.Size = new System.Drawing.Size(58, 20);
            this.txtBxC3.TabIndex = 9;
            this.txtBxC3.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(465, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "n2=";
            // 
            // txtBxn2
            // 
            this.txtBxn2.Location = new System.Drawing.Point(503, 413);
            this.txtBxn2.Name = "txtBxn2";
            this.txtBxn2.Size = new System.Drawing.Size(58, 20);
            this.txtBxn2.TabIndex = 13;
            this.txtBxn2.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(465, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "n1=";
            // 
            // txtBxn1
            // 
            this.txtBxn1.Location = new System.Drawing.Point(503, 382);
            this.txtBxn1.Name = "txtBxn1";
            this.txtBxn1.Size = new System.Drawing.Size(58, 20);
            this.txtBxn1.TabIndex = 11;
            this.txtBxn1.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(465, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "a=";
            // 
            // txtBxa
            // 
            this.txtBxa.Location = new System.Drawing.Point(503, 437);
            this.txtBxa.Name = "txtBxa";
            this.txtBxa.Size = new System.Drawing.Size(58, 20);
            this.txtBxa.TabIndex = 15;
            this.txtBxa.Text = "0,2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 473);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 19);
            this.button1.TabIndex = 17;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 526);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBxa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBxn2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBxn1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBxC3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBxC2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxC1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dtGdVw1);
            this.Name = "Form1";
            this.Text = "Автобусы";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private string BL()
    {
      this.E1 = -1;
      double num1 = -999999.0;
      for (int index1 = 0; index1 < this.Matreca_dohodov.Count; ++index1)
      {
        double num2 = 0.0;
        for (int index2 = 0; index2 < this.Matreca_dohodov[index1].Count; ++index2)
          num2 += this.Matreca_dohodov[index1][index2] * this.Q_j(index2 + 1) * this.P_ij(index1 + 1);
        if (num2 > num1)
        {
          num1 = num2;
          this.E1 = index1 + this.N;
        }
      }
      return Convert.ToString(this.E1);
    }

    private string HL()
    {
      this.E1 = -1;
      double @double = Convert.ToDouble(this.txtBxa.Text);
      double num1 = -999999.0;
      for (int index1 = 0; index1 < this.Matreca_dohodov.Count; ++index1)
      {
        double num2 = 0.0;
        for (int index2 = 0; index2 < this.Matreca_dohodov[index1].Count; ++index2)
          num2 += this.Matreca_dohodov[index1][index2] * this.Q_j(index2 + 1) * this.P_ij(index1 + 1);
        double num3 = @double * num2 + (1.0 - @double) * this.Min(this.Matreca_dohodov[index1]);
        if (num3 > num1)
        {
          num1 = num3;
          this.E1 = index1 + this.N;
        }
      }
      return Convert.ToString(this.E1);
    }

    private string G()
    {
      this.E1 = -1;
      bool flag = false;
      for (int index = 0; index < this.Matreca_dohodov.Count; ++index)
      {
        if (this.Min(this.Matreca_dohodov[index]) < 0.0)
        {
          flag = true;
          break;
        }
      }
      if (flag)
      {
        double num1 = 999999.0;
        for (int index1 = 0; index1 < this.Matreca_dohodov.Count; ++index1)
        {
          double num2 = -99999.0;
          for (int index2 = 0; index2 < this.Matreca_dohodov[index1].Count; ++index2)
          {
            double num3 = this.Matreca_dohodov[index1][index2] * this.Q_j(index2 + 1) * 1.0 / this.P_ij(index1 + 1);
            if (num3 > num2)
              num2 = num3;
          }
          if (num2 < num1)
          {
            num1 = num2;
            this.E1 = index1 + this.N;
          }
        }
        return Convert.ToString(this.E1);
      }
      if (flag)
        return "";
      double num4 = 999999.0;
      for (int index1 = 0; index1 < this.Matreca_dohodov.Count; ++index1)
      {
        double num1 = -99999.0;
        for (int index2 = 0; index2 < this.Matreca_dohodov[index1].Count; ++index2)
        {
          double num2 = this.Matreca_dohodov[index1][index2] * this.Q_j(index2 + 1) * this.P_ij(index1 + 1);
          if (num2 > num1)
            num1 = num2;
        }
        if (num1 < num4)
        {
          num4 = num1;
          this.E1 = index1 + this.N;
        }
      }
      return Convert.ToString(this.E1);
    }

    private string D()
    {
      this.E1 = -1;
      double num1 = -999999.0;
      for (int index1 = 0; index1 < this.Matreca_dohodov.Count; ++index1)
      {
        double num2 = 0.0;
        for (int index2 = 0; index2 < this.Matreca_dohodov[index1].Count; ++index2)
          num2 += this.Q_j(index2 + 1) * this.P_ij(index1 + 1);
        if (num2 > num1)
        {
          num1 = num2;
          this.E1 = index1 + this.N;
        }
      }
      return Convert.ToString(this.E1);
    }

    private double Q_j(int j)
    {
      return (double) ((12 - j) * j) * 1.0 / 286.0;
    }

    private double P_ij(int i)
    {
      return 1.0 - 0.01 * (double) (this.N + i);
    }

    private string Proizvedenie()
    {
      this.E1 = -1;
      List<List<double>> doubleListList = new List<List<double>>();
      for (int index1 = 0; index1 < 11; ++index1)
      {
        List<double> doubleList = new List<double>();
        for (int index2 = 0; index2 < 11; ++index2)
        {
          double num = this.Matreca_dohodov[index1][index2];
          if (num <= 0.0)
            num = num + Math.Abs(this.Min(this.Matreca_dohodov[index1])) + 1.0;
          doubleList.Add(num);
        }
        doubleListList.Add(doubleList);
      }
      double num1 = -1000.0;
      for (int index1 = 0; index1 < 11; ++index1)
      {
        double num2 = 1.0;
        for (int index2 = 0; index2 < 11; ++index2)
          num2 *= doubleListList[index1][index2];
        if (num2 > num1)
        {
          num1 = num2;
          this.E1 = index1 + this.N;
        }
      }
      return Convert.ToString(this.E1);
    }

    private string Gurmana()
    {
      this.E1 = -1;
      double @double = Convert.ToDouble(this.txtBxa.Text, CultureInfo.InvariantCulture);
      this.E1 = -1;
      double num1 = -999999.0;
      for (int index = 0; index < this.Matreca_dohodov.Count; ++index)
      {
        double num2 = @double * this.Max(this.Matreca_dohodov[index]) + (1.0 - @double) * this.Min(this.Matreca_dohodov[index]);
        if (num2 > num1)
        {
          num1 = num2;
          this.E1 = index + this.N;
        }
      }
      return Convert.ToString(this.E1);
    }

    private string Sevidg()
    {
      this.E1 = -1;
      double[,] numArray = new double[11, 11];
      for (int index1 = 0; index1 < this.Matreca_dohodov.Count; ++index1)
      {
        double num = -10000.0;
        for (int index2 = 0; index2 < this.Matreca_dohodov.Count; ++index2)
        {
          if (this.Matreca_dohodov[index2][index1] > num)
            num = this.Matreca_dohodov[index2][index1];
        }
        for (int index2 = 0; index2 < this.Matreca_dohodov.Count; ++index2)
          numArray[index2, index1] = num - this.Matreca_dohodov[index2][index1];
      }
      double num1 = 999999.0;
      for (int index1 = 0; index1 < this.Matreca_dohodov.Count; ++index1)
      {
        double num2 = -9999.0;
        for (int index2 = 0; index2 < this.Matreca_dohodov[index1].Count; ++index2)
        {
          if (numArray[index1, index2] > num2)
            num2 = numArray[index1, index2];
        }
        if (num2 < num1)
        {
          num1 = num2;
          this.E1 = index1 + this.N;
        }
      }
      return Convert.ToString(this.E1);
    }

    private string Laplas()
    {
      this.E1 = -1;
      double num1 = -999999.0;
      for (int index1 = 0; index1 < this.Matreca_dohodov.Count; ++index1)
      {
        double num2 = 0.0;
        for (int index2 = 0; index2 < this.Matreca_dohodov[index1].Count; ++index2)
          num2 += this.Matreca_dohodov[index1][index2];
        double num3 = num2 * 1.0 / (double) this.Matreca_dohodov[index1].Count;
        if (num3 > num1)
        {
          num1 = num3;
          this.E1 = index1 + this.N;
        }
      }
      return Convert.ToString(this.E1);
    }

    private string Min_max()
    {
      this.E1 = -1;
      double num1 = -999999.0;
      for (int index = 0; index < this.Matreca_dohodov.Count; ++index)
      {
        double num2 = this.Min(this.Matreca_dohodov[index]);
        if (num2 > num1)
        {
          num1 = num2;
          this.E1 = index + this.N;
        }
      }
      return Convert.ToString(this.E1);
    }

    private double Min(List<double> list)
    {
      List<double> doubleList = new List<double>();
      for (int index = 0; index < list.Count; ++index)
        doubleList.Add(list[index]);
      doubleList.Sort();
      return doubleList[0];
    }

    private double Max(List<double> list)
    {
      List<double> doubleList = new List<double>();
      for (int index = 0; index < list.Count; ++index)
        doubleList.Add(list[index]);
      doubleList.Sort();
      return doubleList[doubleList.Count - 1];
    }

    private void Form1_Load(object sender, EventArgs e)
    {
            this.listBox1.Items.Clear();
            this.N = 4;
            this.N2 = 10 + this.N;
            this.C1 = Convert.ToDouble(this.txtBxC1.Text);
            this.C2 = Convert.ToDouble(this.txtBxC2.Text);
            this.C3 = Convert.ToDouble(this.txtBxC3.Text);
            this.n1 = Convert.ToInt32(this.txtBxn1.Text);
            this.n2 = Convert.ToInt32(this.txtBxn2.Text);
            this.Matreca_dohodov = new List<List<double>>();
            for (int index1 = this.N; index1 <= this.N2; ++index1)
            {
                List<double> doubleList = new List<double>();
                for (int index2 = this.N; index2 <= this.N2; ++index2)
                {
                    this.Doh = 0.0;
                    if (index1 == index2)
                        this.Doh = (double)index1 * this.C2 - (double)index1 * this.C1;
                    if (index1 < index2)
                    {
                        this.Doh = (double)index1 * this.C2 - (double)index1 * this.C1;
                        if (index2 - index1 > this.n2)
                            this.Doh -= (double)(index2 - index1 - this.n2) * this.C3;
                    }
                    if (index1 > index2)
                    {
                        this.Doh = (double)index2 * this.C2 - (double)index1 * this.C1;
                        if (index1 - index2 > this.n1)
                            this.Doh += (double)(index1 - index2 - this.n1) * this.C2;
                    }
                    doubleList.Add(this.Doh);
                }
                this.Matreca_dohodov.Add(doubleList);
            }
            this.dtGdVw1.RowCount = 11;
            this.dtGdVw1.ColumnCount = 11;
            for (int index = this.N; index <= this.N2; ++index)
            {
                this.dtGdVw1.Columns[index - this.N].HeaderText = Convert.ToString(index);
                this.dtGdVw1.Rows[index - this.N].HeaderCell.Value = (object)Convert.ToString(index);
            }
            for (int index1 = this.N; index1 <= this.N2; ++index1)
            {
                for (int index2 = this.N; index2 <= this.N2; ++index2)
                    this.dtGdVw1[index2 - this.N, index1 - this.N].Value = (object)Convert.ToString(this.Matreca_dohodov[index1 - this.N][index2 - this.N]);
            }
            this.listBox1.Items.Add((object)"Критерии принятия решения в условиях неопределенности");
            this.listBox1.Items.Add((object)"");
            this.listBox1.Items.Add((object)("Мини-максный критерий " + this.Min_max()));
            this.listBox1.Items.Add((object)("Критерий Лапласа " + this.Laplas()));
            this.listBox1.Items.Add((object)("Критерий найменшего сожаления Сэвиджа " + this.Sevidg()));
            this.listBox1.Items.Add((object)("Критерий Гурвица " + this.Gurmana()));
            this.listBox1.Items.Add((object)("Критерий Произведения " + this.Proizvedenie()));
            this.listBox1.Items.Add((object)"");
            this.listBox1.Items.Add((object)"Принятие решения в условиях риска");
            this.listBox1.Items.Add((object)"");
            this.listBox1.Items.Add((object)("Критерий Байеса-Лапласа " + this.BL()));
            this.listBox1.Items.Add((object)("Критерий Ходжа-Лемма " + this.HL()));
            this.listBox1.Items.Add((object)("Критерий Геймайера " + this.G()));
            this.listBox1.Items.Add((object)("Критерий наиболее вероятного исхода " + this.D()));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.N = 4;
            this.N2 = 10 + this.N;
            this.C1 = Convert.ToDouble(this.txtBxC1.Text);
            this.C2 = Convert.ToDouble(this.txtBxC2.Text);
            this.C3 = Convert.ToDouble(this.txtBxC3.Text);
            this.n1 = Convert.ToInt32(this.txtBxn1.Text);
            this.n2 = Convert.ToInt32(this.txtBxn2.Text);
            this.Matreca_dohodov = new List<List<double>>();
            for (int index1 = this.N; index1 <= this.N2; ++index1)
            {
                List<double> doubleList = new List<double>();
                for (int index2 = this.N; index2 <= this.N2; ++index2)
                {
                    this.Doh = 0.0;
                    if (index1 == index2)
                        this.Doh = (double)index1 * this.C2 - (double)index1 * this.C1;
                    if (index1 < index2)
                    {
                        this.Doh = (double)index1 * this.C2 - (double)index1 * this.C1;
                        if (index2 - index1 > this.n2)
                            this.Doh -= (double)(index2 - index1 - this.n2) * this.C3;
                    }
                    if (index1 > index2)
                    {
                        this.Doh = (double)index2 * this.C2 - (double)index1 * this.C1;
                        if (index1 - index2 > this.n1)
                            this.Doh += (double)(index1 - index2 - this.n1) * this.C2;
                    }
                    doubleList.Add(this.Doh);
                }
                this.Matreca_dohodov.Add(doubleList);
            }
            this.dtGdVw1.RowCount = 11;
            this.dtGdVw1.ColumnCount = 11;
            for (int index = this.N; index <= this.N2; ++index)
            {
                this.dtGdVw1.Columns[index - this.N].HeaderText = Convert.ToString(index);
                this.dtGdVw1.Rows[index - this.N].HeaderCell.Value = (object)Convert.ToString(index);
            }
            for (int index1 = this.N; index1 <= this.N2; ++index1)
            {
                for (int index2 = this.N; index2 <= this.N2; ++index2)
                    this.dtGdVw1[index2 - this.N, index1 - this.N].Value = (object)Convert.ToString(this.Matreca_dohodov[index1 - this.N][index2 - this.N]);
            }
            this.listBox1.Items.Add((object)"Критерии принятия решения в условиях неопределенности");
            this.listBox1.Items.Add((object)"");
            this.listBox1.Items.Add((object)("Мини-максный критерий " + this.Min_max()));
            this.listBox1.Items.Add((object)("Критерий Лапласа " + this.Laplas()));
            this.listBox1.Items.Add((object)("Критерий найменшего сожаления Сэвиджа " + this.Sevidg()));
            this.listBox1.Items.Add((object)("Критерий Гурвица " + this.Gurmana()));
            this.listBox1.Items.Add((object)("Критерий Произведения " + this.Proizvedenie()));
            this.listBox1.Items.Add((object)"");
            this.listBox1.Items.Add((object)"Принятие решения в условиях риска");
            this.listBox1.Items.Add((object)"");
            this.listBox1.Items.Add((object)("Критерий Байеса-Лапласа " + this.BL()));
            this.listBox1.Items.Add((object)("Критерий Ходжа-Лемма " + this.HL()));
            this.listBox1.Items.Add((object)("Критерий Геймайера " + this.G()));
            this.listBox1.Items.Add((object)("Критерий наиболее вероятного исхода " + this.D()));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
