using System;

namespace Chapter14_1_6 {
    internal class Program {
        /* [問題14-1-6]
        　　日本（東京）の現地時間（2020/8/10 16:32:20）から、対応する協定世界時とシンガポールの現地時間を表示するコードを書いてください。
        */
        static void Main(string[] args) {
            var wTokyoTime = new DateTimeOffset(2020, 8, 10, 16, 32, 20, TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time").BaseUtcOffset);
            Console.WriteLine($"協定世界時：{wTokyoTime.ToUniversalTime()}");
            Console.WriteLine($"シンガポール：{TimeZoneInfo.ConvertTimeBySystemTimeZoneId(wTokyoTime, "Singapore Standard Time")}");
        }
    }
}
