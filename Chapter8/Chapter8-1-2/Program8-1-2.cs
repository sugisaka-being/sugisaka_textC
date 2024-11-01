using System;
using System.Globalization;

namespace Chapter8_1_2 {
    internal class Program {
        /* [問題8-1-2]
        　　p.215のメソッドを参考に、次の週の指定曜日を求めるメソッドを定義してください。
        */
        static void Main(string[] args) {
            var wCulture = new CultureInfo("ja-JP");
            wCulture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var wNextWeekDay = GetNextWeekDay(DateTime.Today, DayOfWeek.Sunday);
            Console.WriteLine($"次の週の{wNextWeekDay:dddd}は{wNextWeekDay:yyyy年M月d日}です。");
        }
        /// <summary>
        /// 次の週の指定曜日を求めるメソッド
        /// </summary>
        /// <param name="vDate">元の日の日付</param>
        /// <param name="vDayOfWeek">指定する曜日</param>
        /// <returns>次の週の指定曜日の日付</returns>
        public static DateTime GetNextWeekDay(DateTime vDate, DayOfWeek vDayOfWeek) {
            var wDays = (int)vDayOfWeek - (int)(vDate.DayOfWeek);
            if (wDays < 0) wDays += 7;
            return vDate.AddDays(wDays + 7);
        }
    }
}
