using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chapter10_1_2 {
    internal class Program {
        /* [問題10-1-2]
        　　テキストファイルを読み込み、3文字以上の数字だけから成る部分文字列をすべて抜き出すコードを書いてください。
        */
        static void Main(string[] args) {
            var wTextFile = @"..\..\Sample10-1-2.txt";
            if (!File.Exists(wTextFile)) {
                Console.WriteLine("テキストファイルが存在しませんでした。");
                return;
            }
            File.ReadAllLines(wTextFile).SelectMany(x => Regex.Matches(x, @"\b\d{3,}\b").Cast<Match>())
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Value}"));
        }
    }
}
