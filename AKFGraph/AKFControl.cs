using calculate_akf;
using Datalib;
using System.Threading;
using AKFGraph;

namespace AKFGraph
{

    
    internal class ClassX
    {// класс по Х


        internal int A1(ref int indicator, ref bool doStop, ref ManualResetEvent manualResetEvent)
        {//создаем экземпляры классов используемых при расчете

            base_calculator_akf akfbaseobj = new base_calculator_akf();
            calculator_akf_x akfobjx = new calculator_akf_x();
            akfobjx.SetComponent(akfbaseobj);
            DataSingleton ds = DataSingleton.getInstance;
            return akfobjx.Start(ref ds.x, ref ds.y, ref ds.z, ref ds.akf,ref  indicator, ref  doStop, ref  manualResetEvent);




        }
    }

    internal class ClassY
    {// класс по Y

        internal int A1(ref int indicator, ref bool doStop, ref ManualResetEvent manualResetEvent)
        {//создаем экземпляры классов используемых при расчете
            base_calculator_akf akfbaseobj = new base_calculator_akf();
            calculator_akf_y akfobjy = new calculator_akf_y();
            akfobjy.SetComponent(akfbaseobj);
            DataSingleton ds = DataSingleton.getInstance;
            return akfobjy.Start(ref ds.x, ref ds.y, ref ds.z, ref ds.akf, ref  indicator, ref  doStop, ref  manualResetEvent);
        }



    }

    internal class ClassZ
    {// класс по Z
        internal int A1(ref int indicator, ref bool doStop, ref ManualResetEvent manualResetEvent)
        {//создаем экземпляры классов используемых при расчете
            base_calculator_akf akfbaseobj = new base_calculator_akf();
            calculator_akf_z akfobjz = new calculator_akf_z();
            akfobjz.SetComponent(akfbaseobj);
            DataSingleton ds = DataSingleton.getInstance;
            return akfobjz.Start(ref ds.x, ref ds.y, ref ds.z, ref ds.akf, ref  indicator, ref  doStop, ref  manualResetEvent);
        }




    }
    //применение паттерна Фасад
    internal class AKFFACADE
    {//создаем экземпляры классов по осям
        static ClassX x = new ClassX();
        static ClassY y = new ClassY();
        static ClassZ z = new ClassZ();
         static int operation1(ref int indicator, ref bool doStop, ref ManualResetEvent manualResetEvent)
        {
            return x.A1(ref  indicator, ref doStop, ref manualResetEvent);
        }
         static int operation2(ref int indicator, ref bool doStop, ref ManualResetEvent manualResetEvent)
        {
            return y.A1(ref  indicator, ref doStop, ref manualResetEvent);
          
        }
         static int operation3(ref int indicator, ref bool doStop, ref ManualResetEvent manualResetEvent)
        {
            return z.A1(ref  indicator, ref doStop, ref manualResetEvent);
           
        }


        public static int main_operation(int PassParam, ref int indicator, ref bool doStop, ref ManualResetEvent manualResetEvent)
        {

            switch (PassParam)
            {//выбор операции взависимости от выбраной оси
                case 0: return operation1(ref  indicator, ref  doStop, ref  manualResetEvent);

                case 1: return operation2(ref  indicator, ref  doStop, ref  manualResetEvent);

                case 2: return operation3(ref  indicator, ref  doStop, ref  manualResetEvent);
                default: return -1;
            }



        }







    }

}
