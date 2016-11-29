using System;
using System.Threading;

namespace CorrDimension
    {
        public class CorrDimensionClass
        {
            public double test(ref double[] ds_x, ref double[] ds_y, ref double[] ds_z, ref int indicator, ref bool doStop, ref  ManualResetEvent manualResetEvent)
            {
                indicator = 0;   //сбрасываем индикатор расчёта
                var N = ds_x.Length;  //N - число точек

                int inach;    //начальное значение
                double ikon;  //конечное значение
                int i;
                double ry;     //среднее расстояние между точками
                double rsum = 0; 
                double rsred;  //среднее значение радиуса

                inach = Convert.ToInt32(Math.Truncate(0.4 * N));  //расчёт начального значения
                ikon = 0.6 * N;  //находим конечное значение
                for (i = inach; i < ikon; i++)   
                {
                    ry = Math.Sqrt(Math.Pow(ds_x[i] - ds_x[i + 1], 2) + Math.Pow(ds_y[i] - ds_y[i + 1], 2) + Math.Pow(ds_z[i] - ds_z[i + 1], 2));//расчёт среднего расстояния между точками
                    rsum += ry;
                }
                rsred = rsum / N / 0.2 / 4;         //среднее значение 
                double[] r = new double[30];        // радиус окружности
                int cnt = 0;
                double[] Cri = new double[30];   
                double[] ri = new double[30];
                Double d, Cr ;   //Cr-функция корреляционной размерности
                for (int k = 0; k < 30 && ! doStop  ; k++)
                {
                    manualResetEvent.WaitOne();
                                    
                    r[k] = k * rsred;    
                    Cr = 0;   //сбрасываем функцию корреляционной размерности
                    for (i = 0; i < N && !doStop; i++)
                    {
                        indicator = 100 * k / 30 + 100 * (i + 1) / N / 29 + 1; if (indicator > 100) indicator = 100; //индикатор выполнения работы

                        for (int j = 0; j < N && !doStop; j++)
                            if (i != j)
                            {
                               d = Math.Sqrt((ds_x[i] * ds_x[i] - 2 * ds_x[i] * ds_x[j] + ds_x[j] * ds_x[j]) +
                                             (ds_y[i] * ds_y[i] - 2 * ds_y[i] * ds_y[j] + ds_y[j] * ds_y[j]) +
                                             (ds_z[i] * ds_z[i] - 2 * ds_z[i] * ds_z[j] + ds_z[j] * ds_z[j]));
                                if (d < r[k])
                                    Cr++;
                            }
                    }
                    Cr = Cr / (N * N);  //находим корреляционную размерность 
                    if (Cr != 0 && r[k] != 1)
                    {
                        Cri[cnt] = Math.Log(Cr);
                        ri[cnt] = Math.Log(r[k]);
                        cnt++;
                    }
                }
                
                if (doStop) return 0;          
                double[] rk = new double[22];   //задаем массив точек
                double [] mas = new double[22];
                Double[] mas2 = new double[20];
                for (int y = 0; y < 22; y++)
                    rk[y] = ri[y];
                for (i = 0; i < 22; i++)
                    mas[i] = (Cri[i + 1] - Cri[i]) / (ri[i + 1] - ri[i]);


                for (i = 0; i < 20; i++)
                    mas2[i] = Math.Abs(mas[i] - mas[i + 1]) + Math.Abs(mas[i + 1] - mas[i + 2]);  

                int minpos = 0;
                for (i = 0; i < mas2.Length; i++)
                    if (mas2[i] < mas2[minpos])
                        minpos = i;      //вывод минимального значения     
                return mas[minpos];

            }
        }
    }
