using System;
using System.Threading;


namespace calculate_akf
{
    public abstract class component_akf    //интерфейс базового компонента
    {
        public abstract int akfunc(ref double[] AKArray, ref double[] ds_akf, ref int indicator, ref bool doStop, ref  ManualResetEvent manualResetEvent);
    }

    public class base_calculator_akf : component_akf  //базовый компонент
    {
        private int i;
        private double Mu, Disp, xsumm;//объявляем переменные для расчета акф
        public override int akfunc(ref double[] AKArray, ref double[] ds_akf, ref int indicator, ref bool doStop, ref  ManualResetEvent manualResetEvent)
        {
            indicator = 0;
            Mu = 0;
            Disp = 0;
            int n = AKArray.Length;
            ds_akf = new double[n];

            //Среднее арифметическое
            for (i = 0; i < n && !doStop; i++)
                Mu += AKArray[i];
            Mu = Mu / n;

            //Дисперсия
            for (i = 0; i < n && !doStop; i++)
                Disp += (AKArray[i] - Mu) * (AKArray[i] - Mu);
            Disp = Disp / n;


            //Автокоррелляционная функция
           bool flag = false;


           for (int j = 0; j < n && !doStop; j++)
            {
                manualResetEvent.WaitOne();
                xsumm = 0;
                //расчет для полосы индикации выполнения процесса расчета
                indicator = 100 * j / n + 1; if (indicator > 100) indicator = 100;
                for (i = 0; i < n - 1 - j && !doStop; i++)     
                {
                   // indicator = 100 * j / n + 100 * (i + 1) / (n - 1 - j) / n + 1; if (indicator > 100) indicator = 100;



                    xsumm = xsumm + (AKArray[i] - Mu) * (AKArray[i + j] - Mu);

                //ds_akf[j] = xsumm / Disp * (n - j);
                ds_akf[j] = xsumm / n;
                //проверка переполнения
                       if (Double.IsInfinity(ds_akf[j]))
                       {
                           flag = true;
                       }

                       if (flag)  break;
                   }
                   if (flag)
                   {
                       for (int jb = 0; jb < n && !doStop; jb++)
                           for (i = 0; (i < n - 1 - jb) && !doStop; i++)
                               ds_akf[jb] = 0;

                       return 1;
                }
            }
           // расчет нормированной АКФ
              double r0 = ds_akf[0];
              for (i = 0; i < n && !doStop; i++)
              {
                  ds_akf[i] = ds_akf[i] / r0;
              }
            return 0; 
        }             
     }

    public abstract class decorator_akf : component_akf //интерфейс декоратора
    {
        protected component_akf component_;

        public void SetComponent(component_akf component)
        {
            component_ = component;
        }
      
        
        public override int akfunc(ref double[] AKArray, ref double[] ds_akf, ref int indicator, ref bool doStop, ref  ManualResetEvent manualResetEvent)
        {
            if (component_ != null) return component_.akfunc(ref AKArray,ref ds_akf, ref indicator, ref doStop, ref manualResetEvent); else return -1;                            
        }
    }

    public class calculator_akf_x : decorator_akf   //декоратор для вычисления акф по x
    {
        public int Start(ref Double[] ds_x, ref Double[] ds_y, ref Double[] ds_z, ref Double[] ds_akf, ref int indicator, ref bool doStop, ref  ManualResetEvent manualResetEvent)
        {         
             return akfunc(ref ds_x, ref ds_akf, ref indicator, ref  doStop, ref  manualResetEvent);        
        }
    }

    public class calculator_akf_y : decorator_akf   //декоратор для вычисления акф по y
    {
        public int Start(ref Double[] ds_x, ref Double[] ds_y, ref Double[] ds_z, ref Double[] ds_akf, ref int indicator, ref bool doStop, ref  ManualResetEvent manualResetEvent)
        {
            return akfunc(ref ds_y, ref ds_akf, ref indicator, ref  doStop, ref  manualResetEvent);
        }
    }

    public class calculator_akf_z : decorator_akf     //декоратор для вычисления акф по z
    {

        public int Start(ref Double[] ds_x, ref Double[] ds_y, ref Double[] ds_z, ref Double[] ds_akf, ref int indicator, ref bool doStop, ref  ManualResetEvent manualResetEvent)
        {
            return akfunc(ref ds_z, ref ds_akf, ref  indicator, ref  doStop, ref  manualResetEvent);
        }
    }   
}