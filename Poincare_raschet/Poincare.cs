using System;


namespace poincare
{

    internal class OYZ  // построение проекции Сечения Пуанкаре на плоскость YOZ (X=0)
    {
         
public void Rasschet
    (//Передаём в функцию след. параметры из Datalib:
        ref double[] p1,//Массив для хранения координат Y
        ref double[] p2,//Массив для хранения координат Z
        ref double[] x,//Временной ряд по х
        ref double[] y,//Временной ряд по y
        ref double[] z //Временной ряz по z
    )
        {
            if (x.Length > 0)
            {
                p1 = new Double[y.Length];//Переопределяем массив для хранения координат Y для построения графика
                p2 = new Double[z.Length];//Переопределяем массив для хранения координат  Z для построения графика
                int i, k = 0;
                for (i = 1; i < x.Length; i++)//Находим точки пересечения Сеч. Пуанкаре с плоскостью X
                                              //обходя все значения по координате X
                {
                    if (x[i] < 0 && x[i - 1] > 0)
                    {

                        p1[k] = (x[i - 1] * y[i] - x[i] * y[i - 1]) / (x[i - 1] - x[i]);//Координата Y
                        p2[k] = (x[i - 1] * z[i] - x[i] * z[i - 1]) / (x[i - 1] - x[i]);//Координата Z
                        k++;
                    }
                }
                Array.Resize(ref p1, k);//Устанавливаем размер K исх. массива p1 
                Array.Resize(ref p2, k);//Устанавливаем размер K исх. массива p2
            }

        }


    }

    internal class OXZ  // построение проекции Сечения Пуанкаре на плоскость XOZ (Y=0)
    {
        /*Комментарии к этому классу аналогичны к классу OYZ*/
        public void Rasschet(ref double[] p1, ref double[] p2, ref double[] x, ref double[] y, ref double[] z)
        
        {
          
            if (y.Length > 0)
            {
                p1 = new Double[x.Length];
                p2 = new Double[z.Length];
                int i, k = 0;
                for (i = 1; i < y.Length; i += 2)
                {
                    if (y[i] < 0 && y[i - 1] > 0)
                    {
                        p1[k] = (y[i - 1] * x[i] - y[i] * x[i - 1]) / (y[i - 1] - y[i]);
                        p2[k] = (y[i - 1] * z[i] - y[i] * z[i - 1]) / (y[i - 1] - y[i]);
                        k++;
                    }
                }
                Array.Resize(ref p1, k);
                Array.Resize(ref p2, k);
            }
        }
    }

    internal class OXY // построение проекции Сечения Пуанкаре на плоскость  XOY (Z=0)
    {
        /*Комментарии к этому классу аналогичны к классу OYZ*/

        public void Rasschet(ref double[] p1, ref double[] p2, ref double[] x, ref double[] y, ref double[] z)
        {
          

            if (z.Length > 0)
            {
                p1 = new Double[x.Length];
                p2 = new Double[y.Length];

                int i, k = 0;
                for (i = 1; i < z.Length; i += 2)
                {
                    if (z[i] < 0 && z[i - 1] > 0)
                    {
                        p1[k] = x[i - 1];
                        p2[k] = y[i - 1];
                        k++;
                    }
                }
                Array.Resize(ref p1, k);
                Array.Resize(ref p2, k);
            }

        }

    }
    
    //Класс(Фасад) для вызова классов-построений проекции Сечения Пуанкаре
    public class Puancare_facade
    {
        OYZ xxx = new OYZ();//Создаём экземпляр для класса OYZ
        OXZ yyy = new OXZ();//Создаём экземпляр для класса OXZ
        OXY zzz = new OXY();//Создаём экземпляр для класса OXY


        public void P_facX(ref double[] p1, ref double[] p2, ref double[] x, ref double[] y, ref double[] z)
        {
            xxx.Rasschet(ref p1, ref p2, ref x, ref y, ref z);
        }
        public void P_facY(ref double[] p1, ref double[] p2, ref double[] x, ref double[] y, ref double[] z)
        {
            yyy.Rasschet(ref p1, ref p2, ref x, ref y, ref z);
        }
        public void P_facZ(ref double[] p1, ref double[] p2, ref double[] x, ref double[] y, ref double[] z)
        {
            zzz.Rasschet(ref p1, ref p2, ref x, ref y, ref z);
        }


      }
}


