using System;
using System.Windows.Forms;
using calculate_spectrum;
using Datalib;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Linq;

namespace SpectrumGraph
{
    public partial class SpectrumGraphForm : Form
    {
        ICalculate_spectrum cs;

        DataSingleton ds = DataSingleton.getInstance;
        public SpectrumGraphForm()
        {
            InitializeComponent();
        }

        private void SpectrumGraphForm_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndex = 0;
            toolStripComboBox2.SelectedIndex = 0;
        }
/*Параметры системы*/
        private String MakeParameters()
        {
            String parameters = ds.SystemName[ds.SystemNumber] + @" \n";
            if (ds.parameter1Name[ds.SystemNumber] != "")
                parameters += ds.parameter1Name[ds.SystemNumber] + @"=" + ds.param1[ds.SystemNumber] + @"  ";
            if (ds.parameter2Name[ds.SystemNumber] != "")
                parameters += ds.parameter2Name[ds.SystemNumber] + @"=" + ds.param2[ds.SystemNumber] + @"  ";
            if (ds.parameter3Name[ds.SystemNumber] != "")
                parameters += ds.parameter3Name[ds.SystemNumber] + @"=" + ds.param3[ds.SystemNumber] + @"  ";
            if (ds.parameter4Name[ds.SystemNumber] != "")
                parameters += ds.parameter4Name[ds.SystemNumber] + @"=" + ds.param4[ds.SystemNumber] + @"  ";
            if (ds.parameter5Name[ds.SystemNumber] != "")
                parameters += ds.parameter5Name[ds.SystemNumber] + @"=" + ds.param5[ds.SystemNumber];

            parameters += @"\nx0=" + ds.x0[ds.SystemNumber] + @"  ";
            parameters += @"y0=" + ds.y0[ds.SystemNumber] + @"  ";
            parameters += @"z0=" + ds.z0[ds.SystemNumber];
            parameters += @"\nВремя=" + ds.T[ds.SystemNumber] + @"  ";
            parameters += @"Шаг=" + ds.dt[ds.SystemNumber];
            return parameters;

        }
/*Расчет спектра*/
        private Double[] ConvertSpectrum (ref Complex[] S, int Param2)
        {
            int N = S.Length;
            Double[] s = new Double[N];
/*Выбор параметров построения*/
            switch (Param2)
            {
                case 0:
                    {
                        for (int i=0; i<N; i++)
                        {
                            s[i] = S[i].Magnitude; //Модуль
                        }
                        break;
                    }
                case 1:
                    {
                        for (int i = 0; i < N; i++)
                        {
                            s[i] = S[i].Phase; // Аргумент
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < N; i++)
                        {
                            s[i] = S[i].Real; // Действительная часть
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < N; i++)
                        {
                            s[i] = S[i].Imaginary; // Мнимая часть
                        }
                        break;
                    }
            }
            return s;
        }
/*Расчет частоты*/
        private Double[] MakeFrequencyArray(ref Complex[] x)
        {
            int N = x.Length;
            Double[] Frequency = new Double[N];
            double fs = 1 / ds.dt[ds.SystemNumber];
            for (int i = 0; i < N; i++)
            {
                Frequency[i] = i * fs / (2 * N); // Частота         
            }
            Frequency[0] += fs/N / 10;
            return Frequency;
        }
/*Построение графика спектра*/
        private void MakeSpectrum(ref Double[] x, ref Double[] y, String title, String x_label, String y_label)
        {
            if (Spectr.Series.Count > 0) Spectr.Series.RemoveAt(0);
            Spectr.Series.Add("Series1");
            Spectr.Series[0].ChartType = SeriesChartType.FastLine;
            Spectr.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            Spectr.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
            Spectr.Titles.Clear();
            Spectr.ChartAreas[0].CursorX.IsUserEnabled = true;
            Spectr.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            Spectr.ChartAreas[0].CursorY.IsUserEnabled = true;
            Spectr.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            Spectr.ChartAreas[0].AxisX.LabelStyle.Format = "G4";
            Spectr.ChartAreas[0].AxisY.LabelStyle.Format = "G4";


            Spectr.Series[0].Points.DataBindXY(x, y);

            Spectr.ChartAreas[0].AxisX.RoundAxisValues();
            Spectr.ChartAreas[0].AxisY.RoundAxisValues();
            Spectr.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            Spectr.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

            Spectr.ChartAreas[0].CursorX.Interval = 0.001 * (Spectr.ChartAreas[0].AxisX.Maximum - Spectr.ChartAreas[0].AxisX.Minimum);
            Spectr.ChartAreas[0].CursorY.Interval = 0.001 * (Spectr.ChartAreas[0].AxisY.Maximum - Spectr.ChartAreas[0].AxisY.Minimum);

            dataChanged.Visible = false;
            Spectr.ChartAreas[0].AxisY.Title = y_label;
            Spectr.ChartAreas[0].AxisX.Title = x_label;

            if (Spectr.Titles.Count == 0) Spectr.Titles.Add("Title1");
            Spectr.Titles[0].Text = title;

            Spectr.Series[0].LegendText = MakeParameters();
            Spectr.Series[0].IsVisibleInLegend = отобразитьПараметрыСистемыToolStripMenuItem.Checked;
        }

        private void построитьСпектрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cs == null) cs = new Calculate_SpectrumProxy();
            int Param = toolStripComboBox1.SelectedIndex;
            int Param2 = toolStripComboBox2.SelectedIndex;
            string[] titles = { "Sx(f)", "Sy(f)", "Sz(f)" };
            switch (Param)
            {
                case 0:
                    {
                        ds.S = cs.calculate_spectrum(ref ds.x); // X
                        break;
                    }
                case 1:
                    {
                        ds.S = cs.calculate_spectrum(ref ds.y);// Y
                        break;
                    }
                case 2:
                    {
                        ds.S = cs.calculate_spectrum(ref ds.z);// Z
                        break;
                    }
            }
            switch (Param2)
                {
                case 0:
                    {
                        Double[] Frequency = MakeFrequencyArray(ref ds.S);
                        double[] Magnitude = ConvertSpectrum(ref ds.S, Param2); 
                        MakeSpectrum(ref Frequency, ref Magnitude, titles[Param], " f","|S(f)|");
                        break;
                    }
                case 1:
                    {
                        Double[] Frequency = MakeFrequencyArray(ref ds.S);
                        double[] Phase = ConvertSpectrum(ref ds.S, Param2);
                        MakeSpectrum(ref Frequency, ref Phase, titles[Param], " f", "Arg (S(f))");
                        break;
                    }
                case 2:
                    {
                        Double[] Frequency = MakeFrequencyArray(ref ds.S);
                        double[] Real = ConvertSpectrum(ref ds.S, Param2);
                        MakeSpectrum(ref Frequency, ref Real, titles[Param], " f", "Re (S(f))");
                        break;
                    }
                case 3:
                    {
                        Double[] Frequency = MakeFrequencyArray(ref ds.S);
                        double[] Imag = ConvertSpectrum(ref ds.S, Param2);
                        MakeSpectrum(ref Frequency, ref Imag, titles[Param], " f", "Im (S(f))");
                        break;
                    }
            }

        }
/*Вывод параметров системы*/
        private void отобразитьПараметрыСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            отобразитьПараметрыСистемыToolStripMenuItem.Checked = !отобразитьПараметрыСистемыToolStripMenuItem.Checked;
            if ((Spectr.Series.Count > 0) && (Spectr.Series[0].LegendText != ""))
                Spectr.Series[0].IsVisibleInLegend = отобразитьПараметрыСистемыToolStripMenuItem.Checked;
        }
/*Сохранение графика*/
        private void сохранитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "png files (*.png)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                Spectr.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
        }
/*Очистка графика при изменении парметров*/
        private void dataChanged_VisibleChanged(object sender, EventArgs e)
        {
            if (dataChanged.Visible)
            {
                if (Spectr.Series.Count > 0) Spectr.Series.RemoveAt(0);
                if (Spectr.Titles.Count > 0) Spectr.Titles.RemoveAt(0);
            }
        }
    }
}
