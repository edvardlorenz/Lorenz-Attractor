using System;
using System.Numerics;

namespace Datalib
{
    public sealed class DataSingleton
    {
        private static volatile DataSingleton _instance;
        private static readonly object SyncRoot = new object();

        private DataSingleton() { }

        public static DataSingleton getInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new DataSingleton();
                    }
                }

                return _instance;
            }
        }

        //Это описание наших переменных для практических нужд
        public int dataclass;
        public int SystemNumber = 0; //номер исследуемой системы, по умолчанию - 0
        public string[] SystemName = { "Аттрактор Лоренца", "Цепь Чуа", "Аттрактор Ресслера", "Система Спротта SQF", "Хаотический лабиринт Рене Томаса","Неавтономный осциллятор Дуффинга-Холмса", "Неавтономная MLC-цепь" }; //строка для использования
        public Double[] x, y, z; //временные ряды
        public Double[] p1, p2; //координаты точек в сечении пуанкаре
        public Double[] akf; //автокорреляционная функция
        public Complex[] S; //БПФ для выбранного временного ряда
        public Double[] T = { 200, 300, 500, 300, 1000, 300, 500 }; // t для расчета основного временного ряда
        public Double[] dt = { 0.01, 0.01, 0.01, 0.01, 0.01, 0.01, 0.01 }; //шаг t
        public Double[] x0 = { 0.1, 0.1, 0.1, 0.1, 1, 0.1, 0.1 }; // для x0
        public Double[] y0 = { 0, 0, 0, 0, 0, 0, 0 }; //для y0
        public Double[] z0 = { 0, 0, 0, 0, 0, 0, 0 }; //для z0
        public Double[] param1 = { 10, 10, 0.2, 0.5, 0, 0.5, 0.18 }; //параметр1 системы
        public Double[] param2 = { 28, 14, 0.2, 0, 0, 0.82, 0.9 }; //параметр2 системы
        public Double[] param3 = { 2.666, 0, 5.7, 0, 0, 1, 0.55 }; //параметр3 системы
        public Double[] param4 = { 0, 0, 0, 0, 0, 0, 0 }; //параметр4 системы
        public Double[] param5 = { 0, 0, 0, 0, 0, 0, 0 }; //параметр5 системы
        public string[] parameter1Name = { "σ", "α", "a", "a", "b", "δ", "f" }; //название параметра1 системы
        public string[] parameter2Name = { "r", "β", "b", "", "", "f", "β" }; //название параметра2 системы
        public string[] parameter3Name = { "b", "", "c", "", "", "ω", "ω" }; //название параметра3 системы
        public string[] parameter4Name = { "", "", "", "", "", "", "" }; //название параметра4 системы
        public string[] parameter5Name = { "", "", "", "", "", "", "" }; //название параметра5 системы
        public bool wasChanged = false; //флаг, указывающие на то, что исходные данные были изменены и требуется провести перерасчет
        public string[] backgroundTaskName = { "корреляционная размерность", "автокорреляционная функция" }; //названия для фоновых задач
        public bool[] backgroundTask = { false, false };// флаги, что выполняется фоновая задача

    }
}
