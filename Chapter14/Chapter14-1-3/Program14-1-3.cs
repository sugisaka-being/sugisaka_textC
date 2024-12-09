using System;
using System.Configuration;

namespace Chapter14_1_3 {
    internal class Program {
        /* [問題14-1-3]
        　　本文で示したmyAppSettings要素に以下のセクションを追加し、プログラムから参照できるようにしてください。
        　　<CalendarOption StringFormat="yyyy年MM月dd日(ddd)"
        　　                Minimum="1900/1/1"
        　　                Maximum="2100/12/31"
        　　                MondayIsFirstDay="True" />
        */
        static void Main(string[] args) {
            var wMyAppSettings = ConfigurationManager.GetSection("myAppSettings") as MyAppSettings;
            if (wMyAppSettings == null) {
                Console.WriteLine("MyAppSettings型へのキャストに失敗しました。");
                return;
            }
            var wCalendarOption = wMyAppSettings.CalendarOption;
            Console.WriteLine(wCalendarOption.StringFormat);
            Console.WriteLine(wCalendarOption.Minimum);
            Console.WriteLine(wCalendarOption.Maximum);
            Console.WriteLine(wCalendarOption.MondayIsFirstDay);
        }
    }
}
