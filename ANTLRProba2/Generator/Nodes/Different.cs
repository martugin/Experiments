﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Globalization;

namespace BaseLibrary
{
    //Разные хорошие внешние методы
    public static class Different
    {
        //Минимальное значение даты
        private static readonly DateTime _minDate = new DateTime(1980, 1, 1, 0, 0, 0);
        public static DateTime MinDate { get { return _minDate; } }

        //Максимальное значение даты
        private static readonly DateTime _maxDate = new DateTime(2200, 1, 1, 0, 0, 0);
        public static DateTime MaxDate { get { return _maxDate; } }

        //Сокращает запись string.IsNullOrEmpty
        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
        //Сокращает запись string.IsNullOrWhiteSpace
        public static bool IsWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        //Перенос строки для отображения в Access
        public static string NewLine { get { return "" + ((char) 13) + ((char) 10); } }

        //Преводит дату в формат для запросов Access
        public static string ToAccessString(this DateTime d)
        {
            var culture = new CultureInfo("");
            return "#" + Convert.ToString(d, culture) + "#";
        }

        //Преводит дату в формат для запросов SQL Server
        public static string ToSqlString(this DateTime d)
        {
            //Русский
            //return "'" + d + "'";

            //Английский
            //CultureInfo ci = CultureInfo.CreateSpecificCulture("en-US");
            //return "'" + d.ToString("yyyy-MM-dd HH:mm:ss.fff", ci) + "'";

            return "convert(datetime, '" + d.Year + "-" + d.Month + "-" + d.Day + " " + d.Hour + ":" + d.Minute + ":" + d.Second + "." + d.Millisecond + "', 21)";
        }

        //Преводит дату в формат для запросов Simaic
        public static string ToSimaticString(this DateTime d)
        {
            DateTime dd = d.ToUniversalTime();
            return "'" + dd.Year + "-" + dd.Month + "-" + dd.Day + " " + dd.Hour + ":" + dd.Minute + ":" + dd.Second + "." + dd.Millisecond + "'";
        }

        //Преводит дату в формат для запросов Ovation Historian
        public static string ToOvationString(this DateTime d)
        {
            DateTime dd = d.ToUniversalTime();
            CultureInfo ci = CultureInfo.CreateSpecificCulture("en-US");
            return "#" + dd.ToString("MM/dd/yyyy HH:mm:ss.fff", ci) + "#";
        }
        
        //Переводит время в строку с милисекундами
        public static string ToStringWithMs(this DateTime t)
        {
            return t.ToString() + "," + (1000 + t.Millisecond).ToString().Substring(1);
        }

        //Сравнивает даты с точностью до секунды
        public static bool EqulasToSeconds(this DateTime t1, DateTime t2)
        {
            return Math.Abs(t1.Subtract(t2).TotalSeconds) < 0.5;
        }

        //Сравнивает даты с точностью до милисекунды
        public static bool EqulasToMilliSeconds(this DateTime t1, DateTime t2)
        {
            return Math.Abs(t1.Subtract(t2).TotalMilliseconds) < 0.5;
        }

        //Переводит строку в double, если нельзя, то возвращает def (NaN)
        public static double ToDouble(this string s, double def = double.NaN)
        {
            if (s.IsEmpty()) return def;
            string st = s.Replace(",", ".");
            double d;
            double res = Double.TryParse(st, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = "." }, out d) ? d : def;
            return res;
        }

        //Переводит строку в int, если нельзя, то возвращает def
        public static int ToInt(this string s, int def = 0)
        {
            if (s.IsEmpty()) return def;
            int i;
            return int.TryParse(s, out i) ? i : 0;
        }

        //Переводит строку в DateTime, если нельзя, то возвращает Different.MinDate
        public static DateTime ToDateTime(this string s)
        {
            DateTime t;
            if (DateTime.TryParse(s, out t)) return t;
            return MinDate;
        }

        //Возвращает истинность i-ого бита числа n
        public static bool GetBit(this int n, int i)
        {
            return ((n >> i) & 1) == 1;
        }
        public static bool GetBit(this uint n, int i)
        {
            return ((n >> i) & 1) == 1;
        }

        //Получение строкового значения из ячейки DataGridView, cells - набор ячеек, column - имя колонки
        public static string Get(this DataGridViewCellCollection cells, string column)
        {
            var v = cells[column].Value;
            if (DBNull.Value.Equals(v) || v == null) return null;
            return v.ToString();
        }
        public static string Get(this DataGridViewRow row, string column)
        {
            return row.Cells.Get(column);
        }

        //Получение логического значения из ячейки DataGridView, cells - набор ячеек, column - имя колонки
        public static bool GetBool(this DataGridViewCellCollection cells, string column)
        {
            var v = cells[column].Value;
            if (DBNull.Value.Equals(v) || v == null) return false;
            return (bool)v;
        }
        public static bool GetBool(this DataGridViewRow row, string column)
        {
            return row.Cells.GetBool(column);
        }

        //Выводит информационное сообщение
        public static void MessageInfo(string message, string caption = "InfoTask", MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(message, "InfoTask", MessageBoxButtons.OK, icon);
        }

        //Выводит сообщение об ошибке по заданной строке сообщения и исключению
        public static string MessageError(this Exception ex, string message = null, string caption = "InfoTask", MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            //string mess = message.IsEmpty() ? "" : message + "\n";
            //mess += ex.Source + "\n" + ex.Data +"\n" + ex.GetType()+ "\n" + ex.Message + "\n" + ex.StackTrace;
            string mess = message.IsEmpty() ? "" : message + NewLine;
            mess += ex.Source + NewLine + ex.Data + NewLine + ex.GetType()+ NewLine + ex.Message + NewLine + ex.StackTrace;
            MessageBox.Show(mess, caption, MessageBoxButtons.OK, icon);
            return mess;
        }

        //Выводит сообщение об ошибке
        public static string MessageError(string message, string caption = "InfoTask", MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
            return message;
        }

        //Выводит вопросительное сообщение, возвращает True, если нажали Yes
        public static bool MessageQuestion(string message, string caption = "InfoTask")
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        //Заменяет в регулярном выражении все символы на коды, чтобы избежать символов типа . или \
        //Если saveAsterix - то не заменятет * и ?
        public static string EscapeCharacters(this string s, bool saveAsterix = false)
        {
            if (s.IsEmpty())
                return String.Empty;

            var builder = new StringBuilder(s.Length * 6);
            foreach (var c in s)
                if (!saveAsterix || (c != '*' && c != '?'))
                    builder.Append("\\u").Append(((int) c).ToString("X4"));
                else builder.Append(c);
            return builder.ToString();
        }

        //Проверка, удовлетворяет ли поле заданному условию, сравение производится без учета регистра
        //fieldValue - значение поля, filterValue - строка фильтра, может содержать * и ?
        //Если не содержит * или ?, то фильтр устанавливается как *filterValue*
        //Можно использовать ключевое слово <Все> для фильтра всех
        //nullIsTrue - считать, что не заполненное поле фильтра означает отсутствие фильтра
        public static bool CheckFilter(this string fieldValue, string filterValue, bool nullIsTrue = true)
        {
            bool b = filterValue == "<Все>";
            if (nullIsTrue) b |= filterValue.IsEmpty();
            string fv = filterValue.EscapeCharacters(true);
            if (fv.Contains("*") || fv.Contains("?"))
                fv = fv.Replace("*", @".*").Replace("?", @".");
            fv = "^" + fv + "$";
            b |= Regex.IsMatch(fieldValue ?? "", fv, RegexOptions.IgnoreCase);
            return b;
        }

        //Чтение значения из реестра path - путь к папке свойства, par - имя свойства
        public static string GetRegistry(string path, string par)
        {
            try
            {
                RegistryKey readKey = Registry.LocalMachine.OpenSubKey(path);
                var res = (string)readKey.GetValue(par);
                readKey.Close();
                return res;
            }
            catch { return ""; }
        }

        //Открытие документа при помощи стандартной программы
        public static void OpenDocument(string file)
        {
            var fi = new FileInfo(file);
            if (!fi.Exists)
            {
                MessageError("Не найден файл " + file);
                return;
            }
            if (fi.Extension.IsEmpty())
            {
                MessageError("Файл " + file + " не имеет расширения");
                return;
            }
            try
            {
                Process.Start(file);
            }
            catch
            {
                MessageError("Не удалось открыть файл " + file + ". Возможно, на компьютере не установлено приложение для просмотра файлов типа " + fi.Extension);
            }
        }

        //Заполняет значение контрола pick, по значению поля text
        public static void ChangePickerValue(this TextBox text, DateTimePicker pick)
        {
            try
            {
                var d = text.Text.ToDateTime();
                if (d != MinDate) pick.Value = d;
            }
            catch { }
        }

        //Чтение из реестра пути к каталогу InfoTask, в возвращаемом пути \ на конце
        public static string GetInfoTaskDir()
        {
            var dir = GetRegistry(@"software\InfoTask", "InfoTaskPath");
            if (dir == "") dir = GetRegistry(@"software\Wow6432Node\InfoTask", "InfoTaskPath");
            if (!dir.EndsWith(@"\")) dir += @"\";
            return dir;
        }

        //Путь к каталогу с тестами InfoTask
        public static string GetTestInfoTaskDir()
        {
            var itd = GetInfoTaskDir();
            var n = itd.LastIndexOf(@"\", itd.Length - 2);
            return itd.Substring(0, n + 1) + @"Test\";
        }
    }
}
