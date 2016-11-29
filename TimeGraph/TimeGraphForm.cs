using System;
using System.Windows.Forms;
using Datalib;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace TimeGraph
{
    public partial class TimeGraphForm : Form
    {
        DataSingleton ds = DataSingleton.getInstance; // Подключаем библиотеку данных

        public TimeGraphForm()
        {
            InitializeComponent();
        }

        private Double[] MakeTimeArray(ref Double[] x) // Создание массива времени
        {
            int N = x.Length; // Кол-во точек

            Double[] Time = new Double[N]; // Массив отсчётов
            double dx = ds.dt[ds.SystemNumber]; // Интервал квантования для текущей системы
            for (int i = 0; i < N; i++)
            {
                Time[i] = dx * i; // Заполняем массив
            }
            Time[0] += dx / 10;
            return Time;

        }

        private String MakeParameters() // Создание параметров графика
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

            parameters += @"\nx0=" + ds.x0[ds.SystemNumber] + @"  "; // Отображение параметров
            parameters += @"y0=" + ds.y0[ds.SystemNumber] + @"  ";
            parameters += @"z0=" + ds.z0[ds.SystemNumber];
            parameters += @"\nВремя=" + ds.T[ds.SystemNumber] + @"  ";
            parameters += @"Шаг=" + ds.dt[ds.SystemNumber];
            return parameters;
        }

        private void MakeGraph(ref Double[] x, ref Double[] y, String title, String x_label, String y_label) // Создание графика
        {
            if (chart1.Series.Count > 0) chart1.Series.RemoveAt(0);

            // Параметры графика
            chart1.Series.Add("Series1");
            chart1.Series[0].ChartType = SeriesChartType.FastLine;
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
            chart1.Titles.Clear();
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "G4";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "G4";

            // Привязываем данные
            chart1.Series[0].Points.DataBindXY(x, y);

            // Вычисляем оси
            chart1.ChartAreas[0].AxisX.RoundAxisValues();
            chart1.ChartAreas[0].AxisY.RoundAxisValues();
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart1.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

            chart1.ChartAreas[0].CursorX.Interval = 0.001 * (chart1.ChartAreas[0].AxisX.Maximum - chart1.ChartAreas[0].AxisX.Minimum);
            chart1.ChartAreas[0].CursorY.Interval = 0.001 * (chart1.ChartAreas[0].AxisY.Maximum - chart1.ChartAreas[0].AxisY.Minimum);

            dataChanged.Visible = false;
            chart1.ChartAreas[0].AxisY.Title = y_label;
            chart1.ChartAreas[0].AxisX.Title = x_label;

            if (chart1.Titles.Count == 0) chart1.Titles.Add("Title1");
            chart1.Titles[0].Text = title;

            // Настройки легенды
            chart1.Series[0].LegendText = MakeParameters();
            chart1.Series[0].IsVisibleInLegend = show_system_parameters.Checked;
        }

        private void xtToolStripMenuItem_Click(object sender, EventArgs e)  // Построение графика во временной области x(t)
        {
            Double[] Time = MakeTimeArray(ref ds.x);
            MakeGraph(ref Time, ref ds.x, "X(t)", "t", "x(t)");
        }

        private void ytToolStripMenuItem_Click(object sender, EventArgs e)  // Построение графика во временной области y(t)
        {
            Double[] Time = MakeTimeArray(ref ds.y);
            MakeGraph(ref Time, ref ds.y, "Y(t)", "t", "y(t)");
        }

        private void ztToolStripMenuItem_Click(object sender, EventArgs e)  // Построение графика во временной области z(t)
        {
            Double[] Time = MakeTimeArray(ref ds.z);
            MakeGraph(ref Time, ref ds.z, "Z(t)", "t", "z(t)");
        }

        private void yxToolStripMenuItem_Click(object sender, EventArgs e)  // Построение графика во временной области y(x)
        {
            MakeGraph(ref ds.x, ref ds.y, "Y(X)", "x", "y");
        }

        private void zxToolStripMenuItem_Click(object sender, EventArgs e)  // Построение графика во временной области z(x)
        {
            MakeGraph(ref ds.x, ref ds.z, "Z(X)", "x", "z");
        }

        private void zyToolStripMenuItem_Click(object sender, EventArgs e)  // Построение графика во временной области z(y)
        {
            MakeGraph(ref ds.y, ref ds.z, "Z(Y)", "z", "y");
        }

        private void dataChanged_VisibleChanged(object sender, EventArgs e) // Очищение окна графиков в случае изменения параметров
        {
            if (dataChanged.Visible)
            {
                if (chart1.Series.Count > 0) chart1.Series.RemoveAt(0);
                if (chart1.Titles.Count > 0) chart1.Titles.RemoveAt(0);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)   // Сохранение графика
        {
            saveFileDialog1.Filter = "png files (*.png)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
        }

        private void show_system_parameters_Click(object sender, EventArgs e)   // Показать название и параметры системы
        {
            show_system_parameters.Checked = !show_system_parameters.Checked;
            if ((chart1.Series.Count > 0) && (chart1.Series[0].LegendText != ""))
                chart1.Series[0].IsVisibleInLegend = show_system_parameters.Checked;
        }
    }
}