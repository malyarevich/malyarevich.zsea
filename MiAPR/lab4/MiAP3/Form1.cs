using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiAP3 {
    public partial class Form1 : Form {
        int C1, C2, C3, n1, n2;
        int Nstart, Nend;
        double Alpha;
        Dictionary<string, double> qj = new Dictionary<string, double>();
        List<double>qi = new List<double>();
        Dictionary<string, double> pij = new Dictionary<string, double>();
        const double n = 121.0;
        public Form1() 
        {
            InitializeComponent();
            Final();

        

        }
        private void btnGO_Click(object sender, EventArgs e) {
            Final();
          
        }
        void Final()
        {
            grdData.Columns.Clear();
            rtxtOutput.Clear();
            qj.Clear();
            pij.Clear();
            Nstart = int.Parse(txtN.Text);
            Nend = Nstart + 10;
            C1 = int.Parse(txtC1.Text);
            C2 = int.Parse(txtC2.Text);
            C3 = int.Parse(txtC3.Text);
            n1 = int.Parse(txtN1.Text);
            n2 = int.Parse(txtN2.Text);
            Alpha = double.Parse(txtAlpha.Text.Replace('.', ','));


            for (int i = 0; i <= 10; i++)
            {
                grdData.Columns.Add((Nstart + i).ToString(), (Nstart + i).ToString());
            }
            for (int i = Nstart; i <= Nend; i++)
            {
                grdData.Rows.Add();
                grdData.Rows[i - Nstart].HeaderCell.Value = i.ToString();
                for (int j = Nstart; j <= Nend; j++)
                {
                    int value = i <= j ? (i * C2 - i * C1) : (j * C2 - i * C1);
                    if (j - i > n2)
                        value = value - (j - i) * C3;
                    if (i - j > n1)
                        value = value + (i - j - n1) * C2;
                    grdData[j.ToString(), i - Nstart].Value = value;
                }
            }

            MinAndMaxInColumns();
            MinMaxInRow();
            Ver();
            Ideal();
            rtxtOutput.Text += "\nНе идеальный эксперемент\n ";
            double C = 0;
            C = Ne_Ideal1(alfa4, PbettaF1, 1) + Ne_Ideal1(alfa4, PbettaF2, 2) + Ne_Ideal1(alfa4, PbettaF3, 2);
            rtxtOutput.Text += "C<=" +C / 3.8;

            //rtxtOutput.Text += "Критерії прийняття рішення в умовах невизначеності:\n";
            //MiniMax();
            //Laplas();
            //Sedvidj();
            //Gurvic();
            //Summa();
            //rtxtOutput.Text += "\nКритерії прийняття рішення в умовах ризику:\n";
            //HodjLem(BaesLaplas());
            //Geymayer();
            //MoreRes();

        }
        void Ver() {
            for (int i = 1; i <= 11; i++) {
                qj.Add((Nstart + i - 1).ToString(), (12.0 - i) * i / 286.0);
                qi.Add((12.0 - i) * i / 286.0);
                pij.Add((Nstart + i - 1).ToString(), 1 - 0.01 * (Nstart + i));
            }
        }
       double  alfa4;
       List<int> Rij = new List<int>();
        void  Ideal()
        {
           alfa4 = -999999999;
           double betta = 0;
           // rtxtOutput.Text += "Betta(K):  " + Max_in_Row1() + "\n";
            for (int i = 0; i < qj.Count; i++)
            {
                if (alfa4 < qi[i] * Max_in_Row1()) alfa4 = qi[i] * Max_in_Row1();
                betta +=qi[i] * Max_in_Row1();
            }
            int max = -9999999;
            for (int i = 0; i < grdData.RowCount; i++)
            {
                for (int j = 0; j < grdData.RowCount; j++)
                {
                    if (max < Convert.ToInt16(grdData.Rows[i].Cells[j].Value)) max = Convert.ToInt16(grdData.Rows[i].Cells[j].Value);
                }
            }

            for (int i = 0; i < grdData.RowCount; i++)
            {
                for (int j = 0; j < grdData.RowCount; j++)
                {
                    Rij.Add(max - Convert.ToInt16(grdData.Rows[i].Cells[j].Value));
                }
            }
            double c1 =  alfa4;
            for (int i = 0; i < Rij.Count; i++)
            {
                //c1 += Rij[i] * qi[i];
            }
            rtxtOutput.Text += "Идеальный эксперемент" + "\n" + "C<= " + c1 * 0.9 + "\n ALFA = " + (betta - alfa4) + "\n BETA = " + betta + "\n";
        }

       double PbettaF1 = (((12 + 1) * 2) / n);
       double PbettaF2 = (2 * (11 - 2) * (2 - 1)) / n;
       double PbettaF3 = (2 * 3) / n;
        public double Ne_Ideal1(double alfa, double PbettaF,int num)
        {
            double PbettaK1 = 0;
            double maxAlfa = -9999999;
            double AlfaEnd = 0;
            double c = 0;
           
            for (int i = 0; i < qi.Count; i++)
            {
                PbettaK1 += qi[i] * PbettaF;
            }
            double Qik1 = (qi[num] * PbettaF) / PbettaK1;


            List<double> Alfqik = new List<double>();
            for (int i = 0; i < grdData.ColumnCount; i++)
            {
                for (int j = 0; j < grdData.ColumnCount; j++)
                {
                    Alfqik.Add(Convert.ToDouble(grdData.Rows[i].Cells[j].Value) * Qik1);
                    if (maxAlfa < Convert.ToDouble(grdData.Rows[i].Cells[j].Value) * Qik1) maxAlfa = Convert.ToDouble(grdData.Rows[i].Cells[j].Value) * Qik1;
                }
            }
            for (int i = 0; i < Alfqik.Count; i++)
            {
                AlfaEnd += Alfqik[i] * PbettaK1;
            }
            c = AlfaEnd - alfa4;
          
            rtxtOutput.Text +=  "\nВероятность"+num+"\nP(bettaK):" + PbettaK1 +
                "  Alfa*: " + AlfaEnd + "\n" ;
            return c;
        }
    
        public int Max_in_Row1()
        {
            int max = -9999999;

            for (int i = 0; i < grdData.RowCount; i++)
            {
                for (int j = 0; j < grdData.RowCount; j++)
                {
                    if (Convert.ToInt16(grdData.Rows[j].Cells[i].Value) > max)
                        max = Convert.ToInt16(grdData.Rows[j].Cells[i].Value);
                }
            }
            return max;
        }
        void MinAndMaxInColumns() {
            foreach (DataGridViewColumn column in grdData.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                int max = int.MinValue;
                int min = int.MaxValue;
                //double mult=1;
                foreach (DataGridViewRow row in grdData.Rows)
                {
                    max = max < (int)row.Cells[column.Name].Value ? (int)row.Cells[column.Name].Value : max;
                    min = min > (int)row.Cells[column.Name].Value ? (int)row.Cells[column.Name].Value : min;

                }

                column.ToolTipText = max.ToString();
                column.DataPropertyName = min.ToString();
                //column.HeaderCell.ErrorText = 
                //rtxtOutput.Text += column.DataPropertyName+"\n";
            }
        }

        void MinMaxInRow() {
            foreach (DataGridViewRow row in grdData.Rows)
            {

                int max = int.MinValue;
                int min = int.MaxValue;
                foreach (DataGridViewColumn column in grdData.Columns)
                {
                    max = max < (int)row.Cells[column.Name].Value ? (int)row.Cells[column.Name].Value : max;
                    min = min > (int)row.Cells[column.Name].Value ? (int)row.Cells[column.Name].Value : min;
                }
                row.HeaderCell.ToolTipText = max.ToString();
                row.HeaderCell.Tag = min;
            }

        }

        void MiniMax() {
            Dictionary<string, int> minList = new Dictionary<string, int>();
            string min_i = "";
            for (int i = Nstart; i <= Nend; i++) {
                int min = int.MaxValue;
                for (int j = Nstart; j <= Nend; j++) {
                    if (min > (int)grdData[j.ToString(), i - Nstart].Value)
                        min = (int)grdData[j.ToString(), i - Nstart].Value;
                }
                minList.Add(grdData.Rows[i - Nstart].HeaderCell.Value.ToString(), min);
            }
            min_i = minList.Aggregate((p1, p2) => (p1.Value > p2.Value) ? p1 : p2).Key;
            rtxtOutput.Text += "Мінімаксний критерій (критерій Вальда):  " + min_i + "\n";
        }

        void Laplas() {
            Dictionary<string, double> avgList = new Dictionary<string, double>();
            string maxavg = "";
            for (int i = Nstart; i <= Nend; i++) {
                double sum = 0;
                for (int j = Nstart; j <= Nend; j++) {
                    sum += double.Parse(grdData[j.ToString(), i - Nstart].Value.ToString());
                }
                double avg = sum / 11.0;
                avgList.Add(grdData.Rows[i - Nstart].HeaderCell.Value.ToString(), avg);
            }
            maxavg = avgList.Aggregate((p1, p2) => (p1.Value > p2.Value) ? p1 : p2).Key;
            rtxtOutput.Text += "Критерій Лапласа:  " + maxavg + "\n";
        }

        void Sedvidj() {
            //int[,] zhalu = new int[11, 11];
            Dictionary<string, int> maxList = new Dictionary<string, int>();
            string min;
            //foreach (DataGridViewColumn column in grdData.Columns) {
            //    int max = int.MinValue;
            //    int minv = int.MaxValue;
            //    foreach (DataGridViewRow row in grdData.Rows) {
            //        max = max < (int)row.Cells[column.Name].Value ? (int)row.Cells[column.Name].Value : max;
            //    }

            //    column.ToolTipText = max.ToString();
            //    column.DataPropertyName = max.ToString();
            //}

            for (int i = 0; i <= 10; i++) {
                int max = int.MinValue;
                for (int j = 0; j <= 10; j++) {
                    int r = int.Parse(grdData.Columns[j].ToolTipText) - int.Parse(grdData[j, i].Value.ToString());
                    max = max < r ? r : max;
                    //zhalu[i, j] = int.Parse(grdData.Columns[j].ToolTipText) - int.Parse(grdData[j, i].Value.ToString());
                    //   rtxtOutput.Text += zhalu[i, j].ToString() + "\t";
                }
                maxList.Add(grdData.Rows[i].HeaderCell.Value.ToString(), max);
                // rtxtOutput.Text += "\n";
            }
            min = maxList.Aggregate((p1, p2) => (p1.Value < p2.Value) ? p1 : p2).Key;
            rtxtOutput.Text += "Критерій Севіджа:  " + min + "\n";
        }

        void Gurvic() {
            Dictionary<string, double> f = new Dictionary<string, double>();
            string maxF;
            //foreach (DataGridViewColumn column in grdData.Columns) {
            //    f.Add(column.HeaderCell.Value.ToString(), Alpha * double.Parse(column.ToolTipText) + (1 - Alpha) * double.Parse(column.DataPropertyName));
            //}
            foreach (DataGridViewRow dr in grdData.Rows)
            {
                f.Add(dr.HeaderCell.Value.ToString(), Alpha * double.Parse(dr.HeaderCell.ToolTipText) + (1 - Alpha) * double.Parse(dr.HeaderCell.Tag.ToString()));
            }
            maxF = f.Aggregate((p1, p2) => (p1.Value > p2.Value) ? p1 : p2).Key;
            rtxtOutput.Text += "Критерій Гурвіца:  " + maxF + "\n";
        }

        void Summa() {
            Dictionary<string, double> f = new Dictionary<string, double>();
            string maxF;
            int min = int.MaxValue;
            DataGridView newdgr = CopyDataGridView(grdData);
            foreach (DataGridViewRow row in newdgr.Rows) {
                foreach (DataGridViewColumn column in newdgr.Columns) {
                    min = min > (int)row.Cells[column.Name].Value ? (int)row.Cells[column.Name].Value : min;
                }
            }

            if (min <= 0) {
                foreach (DataGridViewRow row in newdgr.Rows) {
                    foreach (DataGridViewColumn column in newdgr.Columns) {
                        row.Cells[column.Name].Value = int.Parse(row.Cells[column.Name].Value.ToString()) + Math.Abs(min) + 1;
                    }
                }
            }

            foreach (DataGridViewRow row in newdgr.Rows) {
                double mult = 0;
                foreach (DataGridViewColumn column in newdgr.Columns) {
                    mult *= double.Parse(row.Cells[column.Name].Value.ToString());
                }
                f.Add(row.HeaderCell.Value.ToString(), mult);
            }

            maxF = f.Aggregate((p1, p2) => (p1.Value > p2.Value) ? p1 : p2).Key;
            rtxtOutput.Text += "Критерій добутку:  " + maxF + "\n";
        }

        Dictionary<string, double> BaesLaplas() {
            Dictionary<string, double> f = new Dictionary<string, double>();
            string maxF;
            foreach (DataGridViewRow dr in grdData.Rows)
            {
                double sum = 0;
                foreach (DataGridViewColumn column in grdData.Columns)
                {
                    sum += int.Parse(dr.Cells[column.Name].Value.ToString()) * pij[column.Name] * qj[column.Name];
                }
                f.Add(dr.HeaderCell.Value.ToString(), sum);
            }
            maxF = f.Aggregate((p1, p2) => (p1.Value > p2.Value) ? p1 : p2).Key;
            rtxtOutput.Text += "Критерій Байеса-Лапласа:  " + maxF + "\n";
            return f;
        }

        void HodjLem(Dictionary<string, double> BL) {
            Dictionary<string, double> HLlist = new Dictionary<string, double>();
            string maxHL;
            foreach (DataGridViewRow dr in grdData.Rows)
            {
                HLlist.Add(dr.HeaderCell.Value.ToString(), Alpha * BL[dr.HeaderCell.Value.ToString()] + (1 - Alpha * double.Parse(dr.HeaderCell.Tag.ToString())));
            }
            maxHL = HLlist.Aggregate((p1, p2) => (p1.Value > p2.Value) ? p1 : p2).Key;
            rtxtOutput.Text += "Критерій Ходжа-Лема:  " + maxHL + "\n";
        }

        void Geymayer() {
            bool IsNegative = false;
            Dictionary<string, double> GList = new Dictionary<string, double>();
            string minG;
            foreach (DataGridViewRow row in grdData.Rows)
            {
                foreach (DataGridViewColumn column in grdData.Columns)
                {
                    if (0 > (int)row.Cells[column.Name].Value) {
                        IsNegative = true;
                        break;
                    }
                }
                if (IsNegative) break;
            }

            foreach (DataGridViewRow row in grdData.Rows)
            {
                double max = double.MinValue;
                foreach (DataGridViewColumn column in grdData.Columns)
                {
                    double x = IsNegative ? double.Parse(row.Cells[column.Name].Value.ToString()) * qj[column.Name] / pij[row.HeaderCell.Value.ToString()] : double.Parse(row.Cells[column.Name].Value.ToString()) * qj[column.Name] * pij[row.HeaderCell.Value.ToString()];
                    max = max < x ? x : max;
                }
                GList.Add(row.HeaderCell.Value.ToString(), max);
            }
            minG = GList.Aggregate((p1, p2) => (p1.Value < p2.Value) ? p1 : p2).Key;
            rtxtOutput.Text += "Критерій Геймайера:  " + minG + "\n";
        }

        void MoreRes() {
            Dictionary<string, double> list = new Dictionary<string, double>();
            string max;
            foreach (DataGridViewRow row in grdData.Rows)
            {
                double sum = 0;
                foreach (DataGridViewColumn column in grdData.Columns)
                {
                    sum += qj[column.Name] * pij[row.HeaderCell.Value.ToString()];
                }
                list.Add(row.HeaderCell.Value.ToString(), sum);
            }
            max = list.Aggregate((p1, p2) => (p1.Value < p2.Value) ? p1 : p2).Key;
            rtxtOutput.Text += "Критерій найбільш вірогідного результату:  " + max + "\n";
        }

        private DataGridView CopyDataGridView(DataGridView dgv_org) {
            DataGridView dgv_copy = new DataGridView();
            try {
                if (dgv_copy.Columns.Count == 0) {
                    foreach (DataGridViewColumn dgvc in dgv_org.Columns) {
                        dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_org.Rows.Count; i++) {
                    row = (DataGridViewRow)dgv_org.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_org.Rows[i].Cells) {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dgv_copy.Rows.Add(row);
                }
                dgv_copy.AllowUserToAddRows = false;
                dgv_copy.Refresh();

            } catch (Exception ex) {
               //cf.ShowExceptionErrorMsg("Copy DataGridViw", ex);
                MessageBox.Show(ex.Message);
            }
            return dgv_copy;
        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblC1_Click(object sender, EventArgs e)
        {

        }  
    }
}
