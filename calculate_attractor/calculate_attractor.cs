using System;
using System.Windows.Forms;
 

namespace calculate_attractor
{
    internal class att_lorenz
    {
        internal int Go(double a, double b, double c, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt)
        {
            Double x = x1, y = y1, z = z1; //начальные условия
            int returnCode = 0; //возвращаемое значение (для отслеживания ошибое)
            ulong N = Convert.ToUInt64(T / dt); //число точек
            mx = new Double[N]; //выделение памяти под массив x
            my = new Double[N]; //выделение памяти под массив y
            mz = new Double[N]; //выделение памяти под массив z
            double kx1, kx2, kx3, kx4, ky1, ky2, ky3, ky4, kz1, kz2, kz3, kz4; //вспомогательные переменные для рассчётов
            for (ulong i = 0; i < N; i++)
            {
                mx[i] = x;
                my[i] = y;
                mz[i] = z;
                Double xi;
                Double yi;
                Double zi;

                kx1 = a * (-x + y);
                ky1 = x * (b - z) - y;
                kz1 = x * y - c * z;

                xi = x + dt / 2 * kx1;
                yi = y + dt / 2 * ky1;
                zi = z + dt / 2 * kz1;

                kx2 = a * (-xi + yi);
                ky2 = (b * xi - yi - zi * xi);
                kz2 = (-c * zi + xi * yi);

                xi = x + dt / 2 * kx2;
                yi = y + dt / 2 * ky2;
                zi = z + dt / 2 * kz2;

                kx3 = a * (-xi + yi);
                ky3 = (b * xi - yi - zi * xi);
                kz3 = (-c * zi + xi * yi);

                xi = x + dt * kx3;
                yi = y + dt * ky3;
                zi = z + dt * kz3;

                kx4 = a * (-xi + yi);
                ky4 = (b * xi - yi - zi * xi);
                kz4 = (-c * zi + xi * yi);
                x = x + dt / 6 * (kx1 + 2 * kx2 + 2 * kx3 + kx4);
                y = y + dt / 6 * (ky1 + 2 * ky2 + 2 * ky3 + ky4);
                z = z + dt / 6 * (kz1 + 2 * kz2 + 2 * kz3 + kz4);

                if (Double.IsPositiveInfinity(x) || Double.IsNegativeInfinity(x) || Double.IsPositiveInfinity(y) || Double.IsNegativeInfinity(y) || Double.IsPositiveInfinity(z) || Double.IsNegativeInfinity(z)
                     || x > 1e6 || x < -1e6 || y > 1e6 || y < -1e6 || z > 1e6 || z < -1e6
                    )
                {
                    //какая-то переменная ушла в бесконечность (ограничение типа)
                    N = i*3/4;
                    i = 0;
                    x = x1;
                    y = y1;
                    z = z1;
                    Array.Resize(ref mx, (int)N);
                    Array.Resize(ref my, (int)N);
                    Array.Resize(ref mz, (int)N);
                    T = N*dt;
                    mx[i] = x;
                    my[i] = y;
                    mz[i] = z;
                    returnCode = 1;
                }
            }
            return returnCode;
        }
    }

    internal class att_chua
    {
        internal int Go(double a, double b, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt)
        {
            Double x = x1, y = y1, z = z1, h; //начальные условия
            int returnCode = 0; //возвращаемое значение (для отслеживания ошибое)
            ulong N = Convert.ToUInt64(T / dt); //число точек
            mx = new Double[N]; //выделение памяти под массив x
            my = new Double[N]; //выделение памяти под массив y
            mz = new Double[N]; //выделение памяти под массив z
            Double m0 = -8.0 / 7, m1 = -5.0 / 7;

            for (ulong i = 0; i < N; i++)
            {
                mx[i] = x;
                my[i] = y;
                mz[i] = z;

                double kx1, kx2, kx3, kx4, ky1, ky2, ky3, ky4, kz1, kz2, kz3, kz4; //вспомогательные переменные для рассчётов
                Double xi;
                Double yi;
                Double zi;

                h = m1 * x + 0.5 * (m0 - m1) * (Math.Abs(x + 1) - Math.Abs(x - 1));

                kx1 = a * (-x + y - h);
                ky1 = (x - y + z);
                kz1 = -b * y;

                xi = x + dt / 2 * kx1;
                yi = y + dt / 2 * ky1;
                zi = z + dt / 2 * kz1;
                h = m1 * xi + 0.5 * (m0 - m1) * (Math.Abs(xi + 1) - Math.Abs(xi - 1));

                kx2 = a * (-xi + yi - h);
                ky2 = (xi - yi + zi);
                kz2 = (-b * yi);

                xi = x + dt / 2 * kx2;
                yi = y + dt / 2 * ky2;
                zi = z + dt / 2 * kz2;
                h = m1 * xi + 0.5 * (m0 - m1) * (Math.Abs(xi + 1) - Math.Abs(xi - 1));

                kx3 = a * (-xi + yi - h);
                ky3 = (xi - yi + zi);
                kz3 = (-b * yi);

                xi = x + dt * kx3;
                yi = y + dt * ky3;
                zi = z + dt * kz3;
                h = m1 * xi + 0.5 * (m0 - m1) * (Math.Abs(xi + 1) - Math.Abs(xi - 1));

                kx4 = a * (-xi + yi - h);
                ky4 = (xi - yi + zi);
                kz4 = (-b * yi);

                x = x + dt / 6 * (kx1 + 2 * kx2 + 2 * kx3 + kx4);
                y = y + dt / 6 * (ky1 + 2 * ky2 + 2 * ky3 + ky4);
                z = z + dt / 6 * (kz1 + 2 * kz2 + 2 * kz3 + kz4);

                if (Double.IsPositiveInfinity(x) || Double.IsNegativeInfinity(x) || Double.IsPositiveInfinity(y) || Double.IsNegativeInfinity(y) || Double.IsPositiveInfinity(z) || Double.IsNegativeInfinity(z)
                    || x>1e6 ||x<-1e6||y>1e6||y<-1e6||z>1e6||z<-1e6
                    
                    )

                {
                    //какая-то переменная ушла в бесконечность (ограничение типа)
                    N = i*3/4;
                    i = 0;
                    x = x1;
                    y = y1;
                    z = z1;
                    Array.Resize(ref mx, (int)N);
                    Array.Resize(ref my, (int)N);
                    Array.Resize(ref mz, (int)N);
                    T = N * dt;
                    mx[i] = x;
                    my[i] = y;
                    mz[i] = z; 
                    returnCode = 1;
                }
            }
            return returnCode;
        }
    }

    internal class att_rassler
    {
        internal int Go(double a, double b, double c, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt)
        {
            Double x = x1, y = y1, z = z1; //начальные условия
            int returnCode = 0; //возвращаемое значение (для отслеживания ошибое)
            ulong N = Convert.ToUInt64(T / dt); //число точек
            mx = new Double[N]; //выделение памяти под массив x
            my = new Double[N]; //выделение памяти под массив y
            mz = new Double[N]; //выделение памяти под массив z
            double kx1, kx2, kx3, kx4, ky1, ky2, ky3, ky4, kz1, kz2, kz3, kz4; //вспомогательные переменные для рассчётов
            for (ulong i = 0; i < N; i++)
            {
                mx[i] = x;
                my[i] = y;
                mz[i] = z;
                Double xi;
                Double yi;
                Double zi;

                kx1 = -y - z;
                ky1 = x + a * y;
                kz1 = b + z * (x - c);

                xi = x + dt / 2 * kx1;
                yi = y + dt / 2 * ky1;
                zi = z + dt / 2 * kz1;

                kx2 = -yi - zi;
                ky2 = xi + a * yi;
                kz2 = b + zi * (xi - c);

                xi = x + dt / 2 * kx2;
                yi = y + dt / 2 * ky2;
                zi = z + dt / 2 * kz2;

                kx3 = -yi - zi;
                ky3 = xi + a * yi;
                kz3 = b + zi * (xi - c);

                xi = x + dt * kx3;
                yi = y + dt * ky3;
                zi = z + dt * kz3;

                kx4 = -yi - zi;
                ky4 = xi + a * yi;
                kz4 = b + zi * (xi - c);
                x = x + dt / 6 * (kx1 + 2 * kx2 + 2 * kx3 + kx4);
                y = y + dt / 6 * (ky1 + 2 * ky2 + 2 * ky3 + ky4);
                z = z + dt / 6 * (kz1 + 2 * kz2 + 2 * kz3 + kz4);

                if (Double.IsPositiveInfinity(x) || Double.IsNegativeInfinity(x) || Double.IsPositiveInfinity(y) || Double.IsNegativeInfinity(y) || Double.IsPositiveInfinity(z) || Double.IsNegativeInfinity(z)
                     || x > 1e6 || x < -1e6 || y > 1e6 || y < -1e6 || z > 1e6 || z < -1e6
                    )
                {
                    //какая-то переменная ушла в бесконечность (ограничение типа)
                    N = i*3/4;
                    i = 0;
                    x = x1;
                    y = y1;
                    z = z1;
                    Array.Resize(ref mx, (int)N);
                    Array.Resize(ref my, (int)N);
                    Array.Resize(ref mz, (int)N);
                    T = N * dt;
                    mx[i] = x;
                    my[i] = y;
                    mz[i] = z;
                    returnCode = 1;
                }
            }
            return returnCode;
        }
    }

    internal class att_sprott
    {
        internal int Go(double a, double b, double c, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt)
        {
            Double x = x1, y = y1, z = z1; //начальные условия
            int returnCode = 0; //возвращаемое значение (для отслеживания ошибое)
            ulong N = Convert.ToUInt64(T / dt); //число точек
            mx = new Double[N]; //выделение памяти под массив x
            my = new Double[N]; //выделение памяти под массив y
            mz = new Double[N]; //выделение памяти под массив z
            double kx1, kx2, kx3, kx4, ky1, ky2, ky3, ky4, kz1, kz2, kz3, kz4; //вспомогательные переменные для рассчётов
            for (ulong i = 0; i < N; i++)
            {
                mx[i] = x;
                my[i] = y;
                mz[i] = z;
                Double xi;
                Double yi;
                Double zi;

                kx1 = y + z;
                ky1 = -x +a*y;
                kz1 = x *x-z;

                xi = x + dt / 2 * kx1;
                yi = y + dt / 2 * ky1;
                zi = z + dt / 2 * kz1;

                kx2 = yi + zi;
                ky2 = -xi + a * yi;
                kz2 = xi * xi - zi;

                xi = x + dt / 2 * kx2;
                yi = y + dt / 2 * ky2;
                zi = z + dt / 2 * kz2;

                kx3 = y + z;
                ky3 = -xi + a * yi;
                kz3 = xi * xi - zi;

                xi = x + dt * kx3;
                yi = y + dt * ky3;
                zi = z + dt * kz3;

                kx4 = y + z;
                ky4 = -xi + a * yi;
                kz4 = xi * xi - zi;
                x = x + dt / 6 * (kx1 + 2 * kx2 + 2 * kx3 + kx4);
                y = y + dt / 6 * (ky1 + 2 * ky2 + 2 * ky3 + ky4);
                z = z + dt / 6 * (kz1 + 2 * kz2 + 2 * kz3 + kz4);

                if (Double.IsPositiveInfinity(x) || Double.IsNegativeInfinity(x) || Double.IsPositiveInfinity(y) || Double.IsNegativeInfinity(y) || Double.IsPositiveInfinity(z) || Double.IsNegativeInfinity(z)
                     || x > 1e6 || x < -1e6 || y > 1e6 || y < -1e6 || z > 1e6 || z < -1e6
                    )
                {
                    //какая-то переменная ушла в бесконечность (ограничение типа)
                    N = i*3/4;
                    i = 0;
                    x = x1;
                    y = y1;
                    z = z1;
                    Array.Resize(ref mx, (int)N);
                    Array.Resize(ref my, (int)N);
                    Array.Resize(ref mz, (int)N);
                    T = N * dt;
                    mx[i] = x;
                    my[i] = y;
                    mz[i] = z;
                    returnCode = 1;
                }
            }
            return returnCode;
        }
    }

    internal class att_tomas
    {
        internal int Go(double b, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt)
        {
            Double x = x1, y = y1, z = z1; //начальные условия
            int returnCode = 0; //возвращаемое значение (для отслеживания ошибое)
            ulong N = Convert.ToUInt64(T / dt); //число точек
            mx = new Double[N]; //выделение памяти под массив x
            my = new Double[N]; //выделение памяти под массив y
            mz = new Double[N]; //выделение памяти под массив z
            double kx1, kx2, kx3, kx4, ky1, ky2, ky3, ky4, kz1, kz2, kz3, kz4; //вспомогательные переменные для рассчётов

            for (ulong i = 0; i < N; i++)
            {
                mx[i] = x;
                my[i] = y;
                mz[i] = z;

                Double xi;
                Double yi;
                Double zi;

                kx1 = Math.Sin(y) - b * x;
                ky1 = Math.Sin(z) - b * y;
                kz1 = Math.Sin(x) - b * z;

                xi = x + dt / 2 * kx1;
                yi = y + dt / 2 * ky1;
                zi = z + dt / 2 * kz1;

                kx2 = Math.Sin(yi) - b * xi;
                ky2 = Math.Sin(zi) - b * xi;
                kz2 = Math.Sin(xi) - b * zi;

                xi = x + dt / 2 * kx2;
                yi = y + dt / 2 * ky2;
                zi = z + dt / 2 * kz2;

                kx3 = Math.Sin(yi) - b * xi;
                ky3 = Math.Sin(zi) - b * xi;
                kz3 = Math.Sin(xi) - b * zi;

                xi = x + dt * kx3;
                yi = y + dt * ky3;
                zi = z + dt * kz3;

                kx4 = Math.Sin(yi) - b * xi;
                ky4 = Math.Sin(zi) - b * xi;
                kz4 = Math.Sin(xi) - b * zi;

                x = x + dt / 6 * (kx1 + 2 * kx2 + 2 * kx3 + kx4);
                y = y + dt / 6 * (ky1 + 2 * ky2 + 2 * ky3 + ky4);
                z = z + dt / 6 * (kz1 + 2 * kz2 + 2 * kz3 + kz4);

                if (Double.IsPositiveInfinity(x) || Double.IsNegativeInfinity(x) || Double.IsPositiveInfinity(y) || Double.IsNegativeInfinity(y) || Double.IsPositiveInfinity(z) || Double.IsNegativeInfinity(z)
                     || x > 1e6 || x < -1e6 || y > 1e6 || y < -1e6 || z > 1e6 || z < -1e6
                    )
                {
                    //какая-то переменная ушла в бесконечность (ограничение типа)
                    N = i*3/4;
                    i = 0;
                    x = x1;
                    y = y1;
                    z = z1;
                    Array.Resize(ref mx, (int)N);
                    Array.Resize(ref my, (int)N);
                    Array.Resize(ref mz, (int)N);
                    T = N * dt;
                    mx[i] = x;
                    my[i] = y;
                    mz[i] = z;
                    returnCode = 1;
                }
            }
            return returnCode;
        }
    }

   internal class Duffing_Holmes
   {
       Double[] mz_;//временный массив для расчёта f*cos(z)

       //базовый расчёт для показателя Ляпунова
        internal int Go_Base(double delta, double f, double omega, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt)
        {
            Double x = x1, y = y1, z = z1; //начальные условия
            int returnCode = 0; //возвращаемое значение (для отслеживания ошибое)
            ulong N = Convert.ToUInt64(T / dt); //число точек
            mx = new Double[N]; //выделение памяти под массив x
            my = new Double[N]; //выделение памяти под массив y
            mz = new Double[N]; //выделение памяти под массив z
            mz_ = new Double[N]; //выделение памяти под массив z'
            double kx1, kx2, kx3, kx4, ky1, ky2, ky3, ky4, kz1, kz2, kz3, kz4; //вспомогательные переменные для рассчётов
            for (ulong i = 0; i < N; i++)
            {
                mx[i] = x;
                my[i] = y;
                mz[i] = z;
                mz_[i] = f * Math.Cos(z);

                Double xi;
                Double yi;
                Double zi;

                kx1 = y;
                ky1 = -delta * y +x- x * x * x + f * Math.Cos(z);
                kz1 = omega;

                xi = x + dt / 2 * kx1;
                yi = y + dt / 2 * ky1;
                zi = z + dt / 2 * kz1;

                kx2 = yi;
                ky2 = -delta * yi+xi-  xi * xi * xi + f * Math.Cos(zi);
                kz2 = omega;

                xi = x + dt / 2 * kx2;
                yi = y + dt / 2 * ky2;
                zi = z + dt / 2 * kz2;

                kx3 = yi;
                ky3 = -delta * yi+xi-  xi * xi * xi + f * Math.Cos(zi);
                kz3 = omega;

                xi = x + dt * kx3;
                yi = y + dt * ky3;
                zi = z + dt * kz3;

                kx4 = yi;
                ky4 = -delta * yi+xi- xi * xi * xi + f * Math.Cos(zi);
                kz4 = omega;
                x = x + dt / 6 * (kx1 + 2 * kx2 + 2 * kx3 + kx4);
                y = y + dt / 6 * (ky1 + 2 * ky2 + 2 * ky3 + ky4);
                z = z + dt / 6 * (kz1 + 2 * kz2 + 2 * kz3 + kz4);

                if (Double.IsPositiveInfinity(x) || Double.IsNegativeInfinity(x) || Double.IsPositiveInfinity(y) || Double.IsNegativeInfinity(y) || Double.IsPositiveInfinity(z) || Double.IsNegativeInfinity(z)
                     || x > 1e6 || x < -1e6 || y > 1e6 || y < -1e6 || z > 1e6 || z < -1e6
                    )
                {
                    //какая-то переменная ушла в бесконечность (ограничение типа)
                    N = i*3/4;
                    i = 0;
                    x = x1;
                    y = y1;
                    z = z1;
                    Array.Resize(ref mx, (int)N);
                    Array.Resize(ref my, (int)N);
                    Array.Resize(ref mz, (int)N);
                    T = N * dt;
                    mx[i] = x;
                    my[i] = y;
                    mz[i] = z;
                    returnCode = 1;
                }
            }

           
          
            return returnCode;
        }

        // расчёт для всех случаев, кроме показателя Ляпунова
        internal int Go(double delta, double f, double omega, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt)
        {

            int returnCode = Go_Base(delta, f, omega, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);

            ulong N = Convert.ToUInt64(mz.Length);
            for (ulong i = 0; i < N; i++)
                mz[i] = mz_[i];

            return returnCode;


        }



    }

    internal class MLC
    {
        Double[] mz_;//временный массив для расчёта f*cos(z)

        //базовый расчёт для показателя Ляпунова
        internal int Go_Base(double f, double beta, double omega, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt)
        {
            
           

            Double x = x1, y = y1, z = z1, h; //начальные условия
            int returnCode = 0; //возвращаемое значение (для отслеживания ошибок)
            ulong N = Convert.ToUInt64(T / dt); //число точек
            Double m0 = -1.02, m1 = -0.55 ;
            mx = new Double[N]; //выделение памяти под массив x
            my = new Double[N]; //выделение памяти под массив y
            mz = new Double[N]; //выделение памяти под массив z

            mz_ = new Double[N]; //выделение памяти под массив z'
           

            for (ulong i = 0; i < N; i++)
            {
                mx[i] = x;
                my[i] = y;
                mz[i] = z;
                mz_[i] = f * Math.Sin(z);

                double kx1, kx2, kx3, kx4, ky1, ky2, ky3, ky4, kz1, kz2, kz3, kz4; //вспомогательные переменные для расчётов
                Double xi;
                Double yi;
                Double zi;

                h = m1 * x + 0.5 * (m0 - m1) * (Math.Abs(x + 1) - Math.Abs(x - 1));

                kx1 = y-h;
                ky1 = -beta * y - beta * x + f * Math.Sin(z);
                kz1 = omega;

                xi = x + dt / 2 * kx1;
                yi = y + dt / 2 * ky1;
                zi = z + dt / 2 * kz1;
                h = m1 * xi + 0.5 * (m0 - m1) * (Math.Abs(xi + 1) - Math.Abs(xi - 1));

                kx2 = yi - h;
                ky2 = -beta * yi - beta * xi + f * Math.Sin(zi);
                kz2 = omega;

                xi = x + dt / 2 * kx2;
                yi = y + dt / 2 * ky2;
                zi = z + dt / 2 * kz2;
                h = m1 * xi + 0.5 * (m0 - m1) * (Math.Abs(xi + 1) - Math.Abs(xi - 1));

                kx3 = yi - h;
                ky3 = -beta * yi - beta * xi + f * Math.Sin(zi);
                kz3 = omega;

                xi = x + dt * kx3;
                yi = y + dt * ky3;
                zi = z + dt * kz3;
                h = m1 * xi + 0.5 * (m0 - m1) * (Math.Abs(xi + 1) - Math.Abs(xi - 1));

                kx4 = yi - h;
                ky4 = -beta * yi - beta * xi + f * Math.Sin(zi);
                kz4 = omega;

                x = x + dt / 6 * (kx1 + 2 * kx2 + 2 * kx3 + kx4);
                y = y + dt / 6 * (ky1 + 2 * ky2 + 2 * ky3 + ky4);
                z = z + dt / 6 * (kz1 + 2 * kz2 + 2 * kz3 + kz4);

                if (Double.IsPositiveInfinity(x) || Double.IsNegativeInfinity(x) || Double.IsPositiveInfinity(y) || Double.IsNegativeInfinity(y) || Double.IsPositiveInfinity(z) || Double.IsNegativeInfinity(z)
                     || x > 1e6 || x < -1e6 || y > 1e6 || y < -1e6 || z > 1e6 || z < -1e6
                    )
                {
                    //какая-то переменная ушла в бесконечность (ограничение типа)
                    N = i*3/4;
                    i = 0;
                    x = x1;
                    y = y1;
                    z = z1;
                    Array.Resize(ref mx, (int)N);
                    Array.Resize(ref my, (int)N);
                    Array.Resize(ref mz, (int)N);
                    T = N * dt;
                    mx[i] = x;
                    my[i] = y;
                    mz[i] = z;
                    
                    returnCode = 1;
                }
            }

            
            

            return returnCode;
        }

        // расчёт для всех случаев, кроме показателя Ляпунова
        internal int Go(double f, double beta, double omega, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt)
        {

            int returnCode=Go_Base(f, beta, omega, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);

            ulong N = Convert.ToUInt64(mz.Length);
            for (ulong i = 0; i < N; i++)
                mz[i] = mz_[i];

            return returnCode;
        }

   
 
    }

    public static class calculate_attractor_facade
    {
        //Метод является шаблоном программирования "фасад".
        //Используется для запуска расчётов аттракторов

        static att_lorenz L = new att_lorenz(); //создаем экземпляр класса "att_lorenz"
        static att_chua Ch = new att_chua(); //создаем экземпляр класса "att_chua"
        static att_rassler R = new att_rassler(); //создаем экземпляр класса "att_rassler"
        static att_sprott S = new att_sprott(); //создаем экземпляр класса "att_sprott"
        static att_tomas Tm = new att_tomas(); //создаем экземпляр класса "att_tomas"
        static Duffing_Holmes DH = new Duffing_Holmes(); //создаем экземпляр класса "Duffing_Holmes"
        static MLC MLC = new MLC(); //создаем экземпляр класса "MLC"

        public static int start(double a, double b, double c, double d, double e, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt, int type)
        {
            //Запускаем на выполнение расчёт аттрактора,
            //который выбрал пользователь
            int code = 0;
            switch (type)
            {
                case 0:
                    code = L.Go(a, b, c, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);
                    break;
                case 1:
                    code = Ch.Go(a, b, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);
                    break;
                case 2:
                    code = R.Go(a, b, c, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);
                    break;
                case 3:
                    code = S.Go(a, b, c, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);
                    break;
                case 4:
                    code = Tm.Go(a, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);
                    break;
                case 5:
                    code = DH.Go(a, b, c, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);
                    break;
                case 6:
                    code = MLC.Go(a, b, c, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);
                    break;
                default:
                    //Ошибка с нумерацией пунктов меню
                    MessageBox.Show("Неверный тип аттактора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            if (code == 1) MessageBox.Show("При расчете значение аттрактора превысило допустимый предел, время было уменьшено до T="+Convert.ToString(T), "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return code;
        }

        //расчёт уравнений на случай использования при поиске показателя Ляпунова
        public static int start_Lyapunov(double a, double b, double c, double d, double e, double x1, double y1, double z1, ref Double[] mx, ref Double[] my, ref Double[] mz, ref Double T, Double dt, int type)
        {
            //Запускаем на выполнение расчёт аттрактора,
            //который выбрал пользователь
            int code = 0;
            switch (type)
            {
                case 0:
                    code = start(a, b, c,d,e, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt,type);
                    break;
                case 1:
                    code = start(a, b, c, d, e, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt, type);
                    break;
                case 2:
                    code = start(a, b, c, d, e, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt, type);
                    break;
                case 3:
                    code = start(a, b, c, d, e, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt, type);
                    break;
                case 4:
                    code = start(a, b, c, d, e, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt, type);
                    break;
                case 5:
                    code = DH.Go_Base(a, b, c, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);
                    //code = start(a, b, c, d, e, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt, type);
                    break;
                case 6:
                    code = MLC.Go_Base(a, b, c, x1, y1, z1, ref mx, ref my, ref mz, ref T, dt);
                   
                    break;
                default:
                    //Ошибка с нумерацией пунктов меню
                    MessageBox.Show("Неверный тип аттактора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

           

            return code;
        }


    }
}