using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace calculate_spectrum
{
    ///Интерфейс
    /// Определяет общий для <see cref="Calculate_Spectrum"/> и <see cref="ICalculate_spectrum"/> интерфейс
    public interface ICalculate_spectrum
    {
        Complex[] calculate_spectrum(ref double[] x); 
    }
    ///Proxy
    ///Хранит ссылку, которая позволяет заместителю обратиться к реальному субъекту
    ///Объект класса <see cref="Calculate_SpectrumProxy"/> может обращаться к объекту класса
    ///<see cref="ICalculate_spectrum"/>, если интерфейсы классов <see cref="Calculate_SpectrumProxy"/> 
    ///и <see cref="ICalculate_spectrum"/> одинаковы;

    public class Calculate_SpectrumProxy : ICalculate_spectrum
    {
        MySpectrum spectrum;
        public Calculate_SpectrumProxy()
        {
            spectrum = null;
        }
        public Complex[] calculate_spectrum(ref double[] x)
        {
            if (spectrum == null)
                spectrum = new MySpectrum();
            return spectrum.calculate_spectrum(ref x);
        }
    }
    ///Реальный субьект
    ///Определяет реальный объект, представленный заместителем

    public class MySpectrum : ICalculate_spectrum
    {
        public class fft_main
        {
           

            private Complex w(int k, int N) //Окно
            {
                if (k % N == 0) return 1;
                double arg = -2 * Math.PI * k / N;
                return new Complex(Math.Cos(arg), Math.Sin(arg));
            }

            public Complex[] fft(Complex[] x) //Расчет FFT от массива x
            {
                Complex[] X;
                int N = x.Length;
                if (N == 2)
                {
                    X = new Complex[2];
                    X[0] = x[0] + x[1];
                    X[1] = x[0] - x[1];
                }
                else
                {
                    Complex[] x_even = new Complex[N / 2];
                    Complex[] x_odd = new Complex[N / 2];
                    for (int i = 0; i < N / 2; i++)
                    {
                        x_even[i] = x[2 * i];
                        x_odd[i] = x[2 * i + 1];
                    }
                    Complex[] X_even = fft(x_even);
                    Complex[] X_odd = fft(x_odd);
                    X = new Complex[N];
                    for (int i = 0; i < N / 2; i++)
                    {
                        X[i] = X_even[i] + w(i, N) * X_odd[i];
                        X[i + N / 2] = X_even[i] - w(i, N) * X_odd[i];
                    }
                }
                return X;
            }
            public Complex[] fft_start(ref double[] x) //Основная функция 
            {
                int N = 0, len = 0;
                N = x.Length;
                len = Convert.ToInt32(Math.Pow(2, Math.Truncate(Math.Log(N, 2))));
                Complex[] mas = new Complex[len]; //задание массива для промежуточных данных
                for (int i = 0; i < len; i++)
                {
                    mas[i] = x[N - len + i];
                }
                //Расчет FFT
                Complex[] buf = new Complex[len];
                buf = fft(mas);
                //Копирование в глобальную переменную
                int newLen = len / 2;
                Complex[] S = new Complex[newLen];
                for (int j = 0; j < newLen; j++)
                {
                    S[j] = buf[j];
                }
                return S;

            } 
        }
            public Complex[] calculate_spectrum(ref double[] x)
            {
                fft_main myfft_main = new fft_main();
                return myfft_main.fft_start(ref x);
            }  
    }
}
