using System;
using System.Text.RegularExpressions;

namespace Chapter10_1_3 {
    internal class Program {
        /* [問題10-1-3]
        　　以下の文字列配列から、単語"time"が含まれる文字列を取り出し、timeの開始位置をすべて出力してください。
        　　大文字/小文字の区別なく検索してください。
        　　var wTexts = new[] {
                "Time is money.",
                "What time is it?",
                "It will take time.",
                "We reorganized the timetable.",
            };
        */
        static void Main(string[] args) {
            var wTexts = new[] {
                "Time is money.",
                "What time is it?",
                "It will take time.",
                "We reorganized the timetable.",
            };
            var wTextPatternTime = @"\b[Tt]ime\b";
            foreach (var wText in wTexts) {
                var wTextsWithTime = Regex.Matches(wText, wTextPatternTime);
                foreach (Match wTextWithTime in wTextsWithTime) {
                    Console.WriteLine($"{wText} での開始位置は {wTextWithTime.Index}");
                }
            }
        }
    }
}
