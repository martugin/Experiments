using System;
using System.ComponentModel;

namespace PropGrid
{
    public class DataClass
    {
        public DataClass(int a1, double a2, string a3, DateTime a4)
        {
            A1 = a1;
            A2 = a2;
            A3 = a3;
            A4 = a4;
        }

        [DisplayName("Целое число")]
        [Description("Введите сюда целое число")]
        [Category("Числа")]
        public int A1 { get; set; }

        [DisplayName("Действительное число")]
        [Description("Введите сюда действительно число")]
        [Category("Числа")]
        public double A2 { get; set; }

        [DisplayName("Строка")]
        [Description("Введите сюда строку")]
        [Category("Длинные значения")]
        public string A3 { get; set; }

        [DisplayName("Дата Время")]
        [Description("Введите дату и время")]
        [Category("Длинные значения")]
        public DateTime A4 { get; set; }
    }
}