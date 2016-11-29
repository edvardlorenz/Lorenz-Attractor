using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Datalib;
using System.Threading;


namespace AKFGraph
{
    public partial class AKFGraphForm : Form
    {
        DataSingleton ds = DataSingleton.getInstance;
        private bool[] akf_calculated = { false, false, false };

        public AKFGraphForm()//конструктор формы
        {

            InitializeComponent();
          
        }

        delegate void NoArg();  // делегат для безаргументной передачи данных
        private int indicator;  // индикатор выполнения работы
        private bool isProcess1Running;// флаг, первый процесс исполняется
        private bool isProcess2Running;// флаг, второй процесс исполняется
        private bool doStop;// флаг, пользователь хочет остановить потоки

        Thread t;// поток 1
        ManualResetEvent manualResetEvent = new ManualResetEvent(true);
        Thread h;// поток 2
        DateTime StartTime; // 
        DateTime CurrentTime; // 
        DateTime EndTime; // 
        TimeSpan DeltaTime; //



        private String MakeParameters()//создаём параметры расчёта для отображения на графике
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


        private Double[] MakeTimeArray(ref Double[] x)
        {
            int N = x.Length;

            Double[] Time = new Double[N];
            double dx = ds.dt[ds.SystemNumber];
            for (int i = 0; i < N; i++)
            {
                Time[i] = dx * i;
            }
            Time[0] += dx / 10;
            return Time;

        }


        private void MakeGraph(ref Double[] x, ref Double[] y, String title, String x_label, String y_label)
        {
            if (chartAutCh.Series.Count > 0) chartAutCh.Series.RemoveAt(0);
            chartAutCh.Series.Add("Series1");
            chartAutCh.Series[0].ChartType = SeriesChartType.FastLine;
            chartAutCh.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chartAutCh.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
            chartAutCh.Titles.Clear();
            chartAutCh.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartAutCh.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartAutCh.ChartAreas[0].CursorY.IsUserEnabled = true;
            chartAutCh.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartAutCh.ChartAreas[0].AxisX.LabelStyle.Format = "G4";
            chartAutCh.ChartAreas[0].AxisY.LabelStyle.Format = "G4";

            chartAutCh.Series[0].Points.DataBindXY(x, y);

            chartAutCh.ChartAreas[0].AxisX.RoundAxisValues();
            chartAutCh.ChartAreas[0].AxisY.RoundAxisValues();
            chartAutCh.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartAutCh.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

            chartAutCh.ChartAreas[0].CursorX.Interval = 0.001 * (chartAutCh.ChartAreas[0].AxisX.Maximum - chartAutCh.ChartAreas[0].AxisX.Minimum);
            chartAutCh.ChartAreas[0].CursorY.Interval = 0.001 * (chartAutCh.ChartAreas[0].AxisY.Maximum - chartAutCh.ChartAreas[0].AxisY.Minimum);

            dataChanged.Visible = false;
            chartAutCh.ChartAreas[0].AxisY.Title = y_label;
            chartAutCh.ChartAreas[0].AxisX.Title = x_label;

            if (chartAutCh.Titles.Count == 0) chartAutCh.Titles.Add("Title1");
            chartAutCh.Titles[0].Text = title;

            chartAutCh.Series[0].LegendText = MakeParameters();
            chartAutCh.Series[0].IsVisibleInLegend = showSystemParameter.Checked;
        }



        public void DoProgressBar() //метод обновления ПрогрессБара
        {  //проверяем требуется ли вызов потокобезопасного использования ПрогрессБара
            Invoke((NoArg)delegate
            {
                toolStripProgressBar1.Value = indicator;

                CurrentTime = DateTime.Now;
                DeltaTime = CurrentTime.Subtract(StartTime);
                Double delt = DeltaTime.TotalSeconds;
                EndTime = StartTime.AddSeconds(delt * 100 / (indicator + 1));
                if (indicator < 100)
                    endTimeLabel1.Text = "Окончание построения: " + EndTime;
                else endTimeLabel1.Text = "";


            });
        }

        private void Startcalculating(int PassParam, String title, String x_label, String y_label)
        {


            if (isProcess1Running || isProcess2Running)
            {
                //MessageBox.Show("Расчёт уже выполняется");
                MessageBox.Show(this, "Расчёт уже выполняется", "Автокорреляционная функция", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            doStop = false;//сбрасываем флаг остановки
            indicator = 0;//сбрасываем индикатор расчёта
            t = new Thread(new ThreadStart(delegate
            {
                t.Priority = ThreadPriority.Lowest;
               
                isProcess1Running = true;//устанавливаем флаг, что первый поток исполняется
                while (indicator < 100 && !doStop)//работаем до тех пор, пока не завершится расчёт или пользователь не захочет его остановить
                {
                    DoProgressBar();//обновляем ПрогрессБар
                    Thread.Sleep(500);
                    manualResetEvent.WaitOne();
                }
                DoProgressBar();//делаем окончательное обновление ПрогрессБара
                isProcess1Running = false;//сбрасываем флаг
            }));


            h = new Thread(new ThreadStart(delegate
            {
                h.Priority = ThreadPriority.Highest;
          
                isProcess2Running = true;//устанавливаем флаг, что первый поток исполняется                 


                if (!akf_calculated[PassParam])
                {
                    int prov = AKFFACADE.main_operation(PassParam, ref  indicator, ref  doStop, ref  manualResetEvent);
                    if (prov == 0)
                    {
                        akf_calculated[0] = false;
                        akf_calculated[1] = false;
                        akf_calculated[2] = false;
                        if (!doStop) akf_calculated[PassParam] = true;

                    }
                    else
                    {
                        MessageBox.Show("При расчете произошло переполнение, количество точек было уменьшено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else { indicator = 100; }
               
                
               
                isProcess2Running = false;//сбрасываем флаг   
                if (doStop)
                     Invoke((NoArg)delegate
                         {
                             endTimeLabel1.Text = "";
                             MessageBox.Show(this, "Расчёт автокорреляционной функции прерван", "Автокорреляционная функция", MessageBoxButtons.OK, MessageBoxIcon.Error);

                         });
                else
                {
                    Invoke((NoArg)delegate
                         {
                               
                             Double[] Time = MakeTimeArray(ref ds.akf);
                             MakeGraph(ref Time, ref ds.akf, title, x_label, y_label);

                             endTimeLabel1.Text = "";
                             MessageBox.Show(this, "Расчёт автокорреляционной функции успешно завершён", "Автокорреляционная функция", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                          });
                }


            ds.backgroundTask[1] = false;
            }));


            StartTime = DateTime.Now;//запоминаем время начала расчёта
            t.Start();
            h.Start();
            ds.backgroundTask[1] = true;
            dataChanged.Visible = false;
        }


        private void остановитьРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doStop = true;//устанавливаем флаг, что хотим прервать расчёт
        }


        
        private void AKFGraphForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isProcess1Running || isProcess2Running)
            {
                e.Cancel = true;
                manualResetEvent.Reset();
                MessageBox.Show("Окно не может быть закрыто, поскольку выполняются вычисления. Следует дождаться окончания расчёта или выполнить остановку расчёта, а затем закрыть окно", "Автокорреляционная функция", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                manualResetEvent.Set();
            }
            else
                e.Cancel = false;
        }

      

        private void rxτToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Startcalculating(0, "АКФ", "τ", "Rx(τ)");
        }

        private void ryτToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Startcalculating(1, "АКФ", "τ", "Ry(τ)");
        }

        private void пОстроитьRzτToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Startcalculating(2, "АКФ", "τ", "Rz(τ)");
        }






        private void showSystemParameters_Click(object sender, EventArgs e)
        {
            showSystemParameter.Checked = !showSystemParameter.Checked;
            if ((chartAutCh.Series.Count > 0) && (chartAutCh.Series[0].LegendText != ""))
                chartAutCh.Series[0].IsVisibleInLegend = showSystemParameter.Checked;
        }



        private void dataChanged_VisibleChanged(object sender, EventArgs e)
        {
            if (dataChanged.Visible)
            {
                akf_calculated[0] = false;
                akf_calculated[1] = false;
                akf_calculated[2] = false;
                if (chartAutCh.Series.Count > 0) chartAutCh.Series.RemoveAt(0);
                if (chartAutCh.Titles.Count > 0) chartAutCh.Titles.RemoveAt(0);
                toolStripProgressBar1.Value = 0;
            }
        }




        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chartAutCh.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
            }
        }

      
       


    }
}

