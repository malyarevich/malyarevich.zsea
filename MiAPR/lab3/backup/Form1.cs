// Decompiled with JetBrains decompiler
// Type: АТП.Form1
// Assembly: АТП, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE68989E-AFC4-4363-A19F-6EAE01B73FF7
// Assembly location: C:\Users\FireNero\Desktop\Lab3.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
      this.dtGdVw1 = new DataGridView();
      this.listBox1 = new ListBox();
      this.label2 = new Label();
      this.txtBxC1 = new TextBox();
      this.label3 = new Label();
      this.txtBxC2 = new TextBox();
      this.label4 = new Label();
      this.txtBxC3 = new TextBox();
      this.label5 = new Label();
      this.txtBxn2 = new TextBox();
      this.label6 = new Label();
      this.txtBxn1 = new TextBox();
      this.label7 = new Label();
      this.txtBxa = new TextBox();
      ((ISupportInitialize) this.dtGdVw1).BeginInit();
      this.SuspendLayout();
      this.dtGdVw1.AllowUserToAddRows = false;
      this.dtGdVw1.AllowUserToDeleteRows = false;
      this.dtGdVw1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      this.dtGdVw1.BackgroundColor = SystemColors.Control;
      this.dtGdVw1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dtGdVw1.Location = new Point(71, 12);
      this.dtGdVw1.Name = "dtGdVw1";
      this.dtGdVw1.ReadOnly = true;
      this.dtGdVw1.Size = new Size(515, 283);
      this.dtGdVw1.TabIndex = 0;
      this.listBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new Point(151, 308);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(381, 225);
      this.listBox1.TabIndex = 2;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(504, 508);
      this.label2.Name = "label2";
      this.label2.Size = new Size(26, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "C1=";
      this.label2.Visible = false;
      this.txtBxC1.Location = new Point(545, 501);
      this.txtBxC1.Name = "txtBxC1";
      this.txtBxC1.Size = new Size(58, 20);
      this.txtBxC1.TabIndex = 5;
      this.txtBxC1.Text = "20";
      this.txtBxC1.Visible = false;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(507, 538);
      this.label3.Name = "label3";
      this.label3.Size = new Size(26, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "C2=";
      this.label3.Visible = false;
      this.txtBxC2.Location = new Point(548, 531);
      this.txtBxC2.Name = "txtBxC2";
      this.txtBxC2.Size = new Size(58, 20);
      this.txtBxC2.TabIndex = 7;
      this.txtBxC2.Text = "50";
      this.txtBxC2.Visible = false;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(507, 569);
      this.label4.Name = "label4";
      this.label4.Size = new Size(26, 13);
      this.label4.TabIndex = 10;
      this.label4.Text = "C3=";
      this.label4.Visible = false;
      this.txtBxC3.Location = new Point(548, 562);
      this.txtBxC3.Name = "txtBxC3";
      this.txtBxC3.Size = new Size(58, 20);
      this.txtBxC3.TabIndex = 9;
      this.txtBxC3.Text = "10";
      this.txtBxC3.Visible = false;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(631, 507);
      this.label5.Name = "label5";
      this.label5.Size = new Size(25, 13);
      this.label5.TabIndex = 14;
      this.label5.Text = "n2=";
      this.label5.Visible = false;
      this.txtBxn2.Location = new Point(672, 500);
      this.txtBxn2.Name = "txtBxn2";
      this.txtBxn2.Size = new Size(58, 20);
      this.txtBxn2.TabIndex = 13;
      this.txtBxn2.Text = "5";
      this.txtBxn2.Visible = false;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(631, 476);
      this.label6.Name = "label6";
      this.label6.Size = new Size(25, 13);
      this.label6.TabIndex = 12;
      this.label6.Text = "n1=";
      this.label6.Visible = false;
      this.txtBxn1.Location = new Point(672, 469);
      this.txtBxn1.Name = "txtBxn1";
      this.txtBxn1.Size = new Size(58, 20);
      this.txtBxn1.TabIndex = 11;
      this.txtBxn1.Text = "5";
      this.txtBxn1.Visible = false;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(756, 476);
      this.label7.Name = "label7";
      this.label7.Size = new Size(19, 13);
      this.label7.TabIndex = 16;
      this.label7.Text = "a=";
      this.label7.Visible = false;
      this.txtBxa.Location = new Point(797, 469);
      this.txtBxa.Name = "txtBxa";
      this.txtBxa.Size = new Size(58, 20);
      this.txtBxa.TabIndex = 15;
      this.txtBxa.Text = "0,2";
      this.txtBxa.Visible = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(696, 562);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.txtBxa);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.txtBxn2);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.txtBxn1);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.txtBxC3);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.txtBxC2);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.txtBxC1);
      this.Controls.Add((Control) this.listBox1);
      this.Controls.Add((Control) this.dtGdVw1);
      this.Name = "Form1";
      this.Text = "Поиск решения в условиях неопределенности и в условиях риска c Коваль В.Н. СП-1-04д";
      this.Load += new EventHandler(this.Form1_Load);
      ((ISupportInitialize) this.dtGdVw1).EndInit();
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
      double @double = Convert.ToDouble(this.txtBxa.Text);
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
            this.Doh = (double) index1 * this.C2 - (double) index1 * this.C1;
          if (index1 < index2)
          {
            this.Doh = (double) index1 * this.C2 - (double) index1 * this.C1;
            if (index2 - index1 > this.n2)
              this.Doh -= (double) (index2 - index1 - this.n2) * this.C3;
          }
          if (index1 > index2)
          {
            this.Doh = (double) index2 * this.C2 - (double) index1 * this.C1;
            if (index1 - index2 > this.n1)
              this.Doh += (double) (index1 - index2 - this.n1) * this.C2;
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
        this.dtGdVw1.Rows[index - this.N].HeaderCell.Value = (object) Convert.ToString(index);
      }
      for (int index1 = this.N; index1 <= this.N2; ++index1)
      {
        for (int index2 = this.N; index2 <= this.N2; ++index2)
          this.dtGdVw1[index2 - this.N, index1 - this.N].Value = (object) Convert.ToString(this.Matreca_dohodov[index1 - this.N][index2 - this.N]);
      }
      this.listBox1.Items.Add((object) "Критерии принятия решения в условиях неопределенности");
      this.listBox1.Items.Add((object) "");
      this.listBox1.Items.Add((object) ("Мини-максный критерий " + this.Min_max()));
      this.listBox1.Items.Add((object) ("Критерий Лапласа " + this.Laplas()));
      this.listBox1.Items.Add((object) ("Критерий найменшего сожаления Сэвиджа " + this.Sevidg()));
      this.listBox1.Items.Add((object) ("Критерий Гурвица " + this.Gurmana()));
      this.listBox1.Items.Add((object) ("Критерий Произведения " + this.Proizvedenie()));
      this.listBox1.Items.Add((object) "");
      this.listBox1.Items.Add((object) "Принятие решения в условиях риска");
      this.listBox1.Items.Add((object) "");
      this.listBox1.Items.Add((object) ("Критерий Байеса-Лапласа " + this.BL()));
      this.listBox1.Items.Add((object) ("Критерий Ходжа-Лемма " + this.HL()));
      this.listBox1.Items.Add((object) ("Критерий Геймайера " + this.G()));
      this.listBox1.Items.Add((object) ("Критерий наиболее вероятного исхода " + this.D()));
    }
  }
}
