using System;
using System.Globalization;

namespace Chapter8_1_1 {
    internal class Program {
        /* [問題8-1-1]
        　　現在の日時を以下のような3種類の書式でコンソールに出力してください。
        　　2019/1/15 19:48
        　　2019年01月15日 19時48分32秒
        　　平成31年 1月15日(火曜日)
        */
        static void Main(string[] args) {
            var wNow = DateTime.Now;
            var wCulture = new CultureInfo("ja-JP");
            wCulture.DateTimeFormat.Calendar = new JapaneseCalendar();
            Console.WriteLine(wNow.ToString("yyyy/MM/dd HH:mm"));
            Console.WriteLine(wNow.ToString("yyyy年MM月dd日 HH時mm分ss秒"));
            Console.WriteLine(wNow.ToString("ggyy年 M月dd日(dddd)"), wCulture);
        }
    }
}
