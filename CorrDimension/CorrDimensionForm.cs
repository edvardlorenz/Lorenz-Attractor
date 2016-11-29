using System;
using System.Windows.Forms;
using Datalib;
using System.Threading;

namespace CorrDimension
{
    public partial class CorrDimensionForm : Form
    {
        DataSingleton ds = DataSingleton.getInstance;

        public CorrDimensionForm()
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
        DateTime StartTime; // DateTime.Now;
        DateTime CurrentTime; // DateTime.Now;
        DateTime EndTime; // DateTime.Now;
        TimeSpan DeltaTime; // DateTime.Now;

        public void DoProgressBar() //метод обновления ПрогрессБара
        {  //проверяем требуется ли вызов потокобезопасного использования ПрогрессБара

            Invoke((NoArg)delegate
            {  //обновляем позицию ПрогрессБара
               
                toolStripProgressBar1.Value = indicator;             
            });

            Invoke((NoArg)delegate
            {  //обновляем позицию ПрогрессБара
    
                CurrentTime = DateTime.Now;
                DeltaTime = CurrentTime.Subtract(StartTime);
                
                Double delt = DeltaTime.TotalSeconds;

                EndTime=StartTime.AddSeconds(delt*  100/(indicator+1));

                label2.Text = "Начало расчёта:" + StartTime + "; Прошло времени: " + DeltaTime.ToString(@"hh\:mm\:ss") + "; Окончание предполагается:" + EndTime;
            });     
        }

        public void DoOutResult(string str) //метод обновления ЛистБокса
        {//проверяем требуется ли вызов потокобезопасного использования ЛистБокса
            if (label1.InvokeRequired)
            {
                Invoke((NoArg)delegate
                {
                    //добавляем новый элемент в ЛистБокс
                    label1.Text = str;
                });
            }
            else
            {   //добавляем новый элемент в ЛистБокс
                label1.Text = str;
            }
            Invoke((NoArg)delegate
                {
                    dataChanged.Visible = false;
                });
        }

        private void xtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // запускать здесь

            if (isProcess1Running || isProcess2Running)
            {
                MessageBox.Show(this,"Расчёт уже выполняется!", "Корреляционная размерность",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            doStop = false;//сбрасываем флаг остановки
            indicator = 0;//сбрасываем индикатор расчёта

            //создаем поток t для индикации прогресса расчёта
            t = new Thread(new ThreadStart(delegate
            {
                t.Priority = ThreadPriority.Lowest;
                isProcess1Running = true;//устанавливаем флаг, что первый поток исполняется
                while (indicator < 100 && !doStop)//работаем до тех пор, пока не завершится расчёт или пользователь не захочет его остановить
                {
                    DoProgressBar();//обновляем ПрогрессБар
                    //Делаем паузу в 3 секунды между обновлениями
                    //т.к. не имеет смысла их делать чаще
                    //лучше отдать больше времени главному расчёту
                    Thread.Sleep(3000);

                    manualResetEvent.WaitOne();
                }
                DoProgressBar();//делаем окончательное обновление ПрогрессБара
                //т.к. расчёт мог завершится во время паузы между обновлениями ПрогрессБара
                isProcess1Running = false;//сбрасываем флаг
            }));

            //создаём поток для основного расчёта h
            h = new Thread(new ThreadStart(delegate
            {
                h.Priority = ThreadPriority.Highest;
                isProcess2Running = true;//устанавливаем флаг, что первый поток исполняется
                //запускаем расчёт, который может быть прерван установкой флага doStop
                //здесь должен быть алгоритм сложного расчёта, который быстро не может выполниться
               
                   
                //вывод промежуточных результатов расчёта
                //также должен быть потокобезопасным
                  
                CorrDimensionClass cd = new CorrDimensionClass();
                double CD = cd.test(ref ds.x, ref ds.y,ref ds.z,ref indicator, ref doStop, ref manualResetEvent);

                string str = CD.ToString("G4");

                ds.backgroundTask[0] = false;
                isProcess2Running = false;//сбрасываем флаг

                if (doStop) 
                
                    Invoke((NoArg)delegate
                {  
                  DoOutResult("Оценка не была получена");                          
                  MessageBox.Show(this,"Расчёт корреляционной размерности прерван","Корреляционная размерность",MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                });
                else
                
                    Invoke((NoArg)delegate
                {
                 MessageBox.Show(this,"Расчёт корреляционной размерности успешно завершён","Корреляционная размерность",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                 DoOutResult("Оценка корреляционной размерности составила " + str);
                });
                
            }));

            //стартуем потоки

            StartTime = DateTime.Now;
            label1.Text = "";

            t.Start();

            h.Start();

            ds.backgroundTask[0] = true;
        }

        private void остановкаРасчётаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //останавливаем здесь

            doStop = true;//устанавливаем флаг, что хотим прервать расчёт
        }

        private void CorrDimensionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isProcess1Running || isProcess2Running)
            {
                //предотвращаем остановку программы, пока не завершатся фоновые расчёты
                e.Cancel = true;
               
                manualResetEvent.Reset();
                MessageBox.Show("Окно не может быть закрыто, поскольку выполняются вычисления. Следует дождаться окончания расчёта или выполнить остановку расчёта, а затем закрыть окно","Корреляционная размерность",MessageBoxButtons.OK, MessageBoxIcon.Error);
                manualResetEvent.Set();
            }
            else
                e.Cancel = false;
        }

        private void dataChanged_VisibleChanged(object sender, EventArgs e)
        {
            if (dataChanged.Visible)
            {
                label1.Text = "";
            }


        }
    }
}
