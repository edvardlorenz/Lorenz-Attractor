using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Datalib;//Здесь хранятся нужные значения
using poincare;//Здесь производится расчёт проекций Сечения Пуанкаре

namespace PoincareGraph
{
    public partial class PoincareGraphForm : Form
    {
        private readonly DataSingleton ds = DataSingleton.getInstance;
        private DataSingleton poinc = DataSingleton.getInstance;
        private bool[] poincare_calculated = { false, false, false };

        //Установка изначальных параметров формы (графика)
        public PoincareGraphForm()
        {
            InitializeComponent();

        }

        //Получаем значения параметров для графика
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


        //Получаем значения для построения графиков на плоскости
        private void MakeGraph(ref Double[] p1, ref Double[] p2, String title,String x_label, String y_label)
    {

        if (chart1.Series.Count > 0) chart1.Series.RemoveAt(0);
        chart1.Series.Add("Series1");
        chart1.Series[0].ChartType = SeriesChartType.FastPoint;
        chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
        chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        chart1.Titles.Clear();
        chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
        chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
        chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
        chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "G4";
        chart1.ChartAreas[0].AxisY.LabelStyle.Format = "G4";

        int NX = p1.Length;
        if (NX == 0)//Если значений нет
        {
            MessageBox.Show(this, "В данное сечение плоскостью не попала ни одна точка.", "Сечение Пуанкаре", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //то выводим сообщение
            if (chart1.Series.Count > 0) chart1.Series.RemoveAt(0);
            if (chart1.Titles.Count > 0) chart1.Titles.RemoveAt(0);
        }
        else
        {

            chart1.Series[0].Points.DataBindXY(p1, p2);

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

            chart1.Series[0].LegendText = MakeParameters();
            chart1.Series[0].IsVisibleInLegend = ShowToolStripMenuItem.Checked;
        }


        }

        //Получаем значения для построения функций последования
        private void MakePoslFunc(ref double[] p,String title, String x_label,String y_label)
        {
            Double[] f1 = new Double[0];
            Double[] f2 = new Double[0];
            int NX = p.Length;
            if (NX>1)
            {
            f1=new Double[NX-1];
            f2=new Double[NX-1];
            for (int i = 0; i < NX - 1; i++)
                {
                    f1[i]=p[i]; 
                    f2[i]=p[i + 1];
                }
            }
            MakeGraph(ref f1, ref f2, title, x_label, y_label);


        }

      

      
        //Обработчик события "Сохранить график"
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
            }
        }  

        //событие - данные были изменены
        private void dataChanged_VisibleChanged(object sender, EventArgs e)
        {


            if (dataChanged.Visible)
            {
                if (chart1.Series.Count > 0) chart1.Series.RemoveAt(0);
                if (chart1.Titles.Count > 0) chart1.Titles.RemoveAt(0);

                poincare_calculated[0] = false;
                poincare_calculated[1] = false;
                poincare_calculated[2] = false;
            }
  
        }

     
        //Обработчик события "Показать параметры системы"
        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowToolStripMenuItem.Checked = !ShowToolStripMenuItem.Checked;

            if ((chart1.Series.Count > 0) && (chart1.Series[0].LegendText != ""))
            {
                chart1.Series[0].IsVisibleInLegend = ShowToolStripMenuItem.Checked;
            }
        }

    
        /*Функции последования для плоскости YOZ*/

        //Функция последования для Y
        private void oXYToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Построение в плоскости YOZ (X=0)
      

            if (!poincare_calculated[0])
            {
                Puancare_facade ploskost = new Puancare_facade();

                ploskost.P_facX(ref poinc.p1, ref poinc.p2, ref poinc.x, ref poinc.y, ref poinc.z);

                poincare_calculated[0] = true;
                poincare_calculated[1] = false;
                poincare_calculated[2] = false;
            }


           
            MakePoslFunc(ref poinc.p1, "Функция последования для сечения плоскостью YOZ", "Y[n]", "Y[n+1]");



        }

        //Функция последования для Z
        private void функцияПоследовательностиДляYToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           

            if (!poincare_calculated[0])
            {
                Puancare_facade ploskost = new Puancare_facade();

                ploskost.P_facX(ref poinc.p1, ref poinc.p2, ref poinc.x, ref poinc.y, ref poinc.z);

                poincare_calculated[0] = true;
                poincare_calculated[1] = false;
                poincare_calculated[2] = false;
            }


          
            MakePoslFunc(ref poinc.p2, "Функция последования для сечения плоскостью YOZ", "Z[n]", "Z[n+1]");

        }


        /*Функции последовательности для плоскости XOZ*/

        //Функция последовательности для X
        private void функцияПоследовательностиДляXToolStripMenuItem1_Click(object sender, EventArgs e)
        {
       

            if (!poincare_calculated[1])
            {
                Puancare_facade ploskost = new Puancare_facade();

                ploskost.P_facY(ref poinc.p1, ref poinc.p2, ref poinc.x, ref poinc.y, ref poinc.z);

                poincare_calculated[0] = false;
                poincare_calculated[1] = true;
                poincare_calculated[2] = false;
            }


            
            MakePoslFunc(ref poinc.p1, "Функция последования для сечения плоскостью XOZ", "X[n]", "X[n+1]");

        }

        //Функция последовательности для Z
        private void функцияПоследовательностиДляYToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!poincare_calculated[1])
            {
                Puancare_facade ploskost = new Puancare_facade();

                ploskost.P_facY(ref poinc.p1, ref poinc.p2, ref poinc.x, ref poinc.y, ref poinc.z);

                poincare_calculated[0] = false;
                poincare_calculated[1] = true;
                poincare_calculated[2] = false;
            }
          
            MakePoslFunc(ref poinc.p2, "Функция последования для сечения плоскостью XOZ", "Z[n]", "Z[n+1]");
        }


        /*Функции последования для плоскости XOY*/
        //Функция последования для X
        private void функцияПоследовательностиДляXToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!poincare_calculated[2])
            {
                Puancare_facade ploskost = new Puancare_facade();

                ploskost.P_facZ(ref poinc.p1, ref poinc.p2, ref poinc.x, ref poinc.y, ref poinc.z);

                poincare_calculated[0] = false;
                poincare_calculated[1] = false;
                poincare_calculated[2] = true;
            }
           
            MakePoslFunc(ref poinc.p1, "Функция последования для сечения плоскостью XOY", "X[n]", "X[n+1]");
        }

        //Функция последования для Y
        private void функцияПоследовательностиДляYToolStripMenuItem3_Click(object sender, EventArgs e)
        {
           

            if (!poincare_calculated[2])
            {
                Puancare_facade ploskost = new Puancare_facade();

                ploskost.P_facZ(ref poinc.p1, ref poinc.p2, ref poinc.x, ref poinc.y, ref poinc.z);

                poincare_calculated[0] = false;
                poincare_calculated[1] = false;
                poincare_calculated[2] = true;
            }


          
            MakePoslFunc(ref poinc.p2, "Функция последования для сечения плоскостью XOY", "Y[n]", "Y[n+1]");

        }


        //Обработчик события "Построить сечение плоскостью YOZ"
        private void xtToolStripMenuItem_Click(object sender, EventArgs e)
        {
         

            if (!poincare_calculated[0])
            {
                Puancare_facade ploskost = new Puancare_facade();

                ploskost.P_facX(ref poinc.p1, ref poinc.p2, ref poinc.x, ref poinc.y, ref poinc.z);

                poincare_calculated[0] = true;
                poincare_calculated[1] = false;
                poincare_calculated[2] = false;
            }


            MakeGraph(ref poinc.p1, ref poinc.p2,  "Сечение Пуанкаре плоскостью YOZ","Y","Z");

        }
        //Обработчик события "Построить сечение плоскостью XOZ"
        private void построитьСечениеПлоскостьюXOZToolStripMenuItem_Click(object sender, EventArgs e)
        {
        

            if (!poincare_calculated[1])
            {
                Puancare_facade ploskost = new Puancare_facade();
                ploskost.P_facY(ref poinc.p1, ref poinc.p2, ref poinc.x, ref poinc.y, ref poinc.z);
                poincare_calculated[0] = false;
                poincare_calculated[1] = true;
                poincare_calculated[2] = false;
            }
            MakeGraph(ref poinc.p1, ref poinc.p2, "Сечение Пуанкаре плоскостью XOZ", "X", "Z");

        }
        //Обработчик события "Построить сечение плоскостью XOY"
        private void построитьСечениеПлоскостьюXOYToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            if (!poincare_calculated[2])
            {

                Puancare_facade ploskost = new Puancare_facade();
                ploskost.P_facZ(ref poinc.p1, ref poinc.p2, ref poinc.x, ref poinc.y, ref poinc.z);
                poincare_calculated[0] = false;
                poincare_calculated[1] = false;
                poincare_calculated[2] = true;

            }
            MakeGraph(ref poinc.p1, ref poinc.p2, "Сечение Пуанкаре плоскостью XOY", "X", "Y");

        }

      



   }
}
