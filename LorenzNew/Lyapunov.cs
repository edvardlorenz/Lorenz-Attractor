using System;
using calculate_attractor;

namespace LorenzNew
{
    class Calculate_Lyapunov
    {//Передаём в функцию следующие параметры из Main:
        public double Calculate(Double ds_param1,Double ds_param2,  Double ds_param3, 
            Double ds_param4, Double ds_param5, ref Double[] ds_x, ref Double[] ds_y,
             ref Double[] ds_z, Double ds_T, Double ds_dt, int index)
        {//Начальные условия:

           

            int len = ds_x.Length;
            int st =   len / 3;
            int en = len-1;// st * 2;
            int N =  en - st;
			//Cчитывается положение первой точки:
            Double Eps = 1e-3;
            Double x1 = ds_x[st];
            Double y1 = ds_y[st];
            Double z1 = ds_z[st];
            Double x2 = ds_x[st + 1];
            Double y2 = ds_y[st + 1];
            Double z2 = ds_z[st + 1];
			//Рассчитывается положение первой возмущенной точки:
            Double A = x2 - x1;
            Double B = y2 - y1;
            Double alpha = A * A + B * B;
            Double beta = -2 * y1 * A * A - 2 * y1 * B * B;
            Double gamma = -A * A * Eps * Eps + A * A * y1 * y1 + B * B * y1 * y1;
            Double D = beta * beta - 4 * alpha * gamma;
            Double y1_ = (-beta + Math.Sqrt(D)) / 2 / alpha;
            Double x1_ = (B * (y1 - y1_) + A * x1) / A;
            Double z1_ = z1;

            Double Eps2 = Math.Sqrt(Math.Pow(x1 - x1_, 2) + Math.Pow(y1 - y1_, 2));
            Double Eps3 = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
           
            Double[] xt = new Double[2]; //Выделение памяти под массив x;
            Double[] yt = new Double[2]; //Выделение памяти под массив y;
            Double[] zt = new Double[2]; //Выделение памяти под массив z;

            Double tay = ds_dt * 2;

            Double sum = 0;

            for (int i = st; i < en; i++)
            {//Передаём в функцию следующие параметры из calcuate_attractor:
                // запускаем расчёт БАЗОВЫХ уравнений для нахождения следующей точки для возмущённой траектории
                calculate_attractor_facade.start_Lyapunov(ds_param1, ds_param2, ds_param3,
                    ds_param4, ds_param5,
                    x1_, y1_, z1_,
                    ref xt, ref yt, ref zt, ref tay, ds_dt, index);
				//Рассчитываем эволюцию от возмущенной точки
                x1 = ds_x[i];
                y1 = ds_y[i];
                z1 = ds_z[i];

                x2 = ds_x[i + 1];
                y2 = ds_y[i + 1];
                z2 = ds_z[i + 1];

                Double x2_ = xt[1];
                Double y2_ = yt[1];
                Double z2_ = zt[1];

                Double delta_x = x2_ - x2;
                Double delta_y = y2_ - y2;
                Double delta_z = z2_ - z2;
				//Находим расстояние от точки, полученной в результате эволюции возмущенной траектории до не возмущенной траектории:
                Double delta = Math.Sqrt(delta_x * delta_x + delta_y * delta_y + delta_z * delta_z);

                Double sum_i = Math.Log(delta / Eps);

                sum = sum + sum_i;

                Double x2__ = x2 + delta_x * Eps / delta;
                Double y2__ = y2 + delta_y * Eps / delta;
                Double z2__ = z2 + delta_z * Eps / delta;

                x1_ = x2__;
                y1_ = y2__;
                z1_ = z2__;
            }
			//Производим расчет старшего показателя Ляпунова:
            Double L = 1 / ds_dt / N * sum;
            
            return L;
        }
    }
}
