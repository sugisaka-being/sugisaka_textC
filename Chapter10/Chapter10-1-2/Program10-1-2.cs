using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Chapter10_1_2 {
    internal class Program {
        /* [問題10-1-2]
        　　テキストファイルを読み込み、3文字以上の数字だけから成る部分文字列をすべて抜き出すコードを書いてください。
        */
        static void Main(string[] args) {
            var wTextFile = @"..\..\Sample10-1-2.txt";
            var wNumberMoreThree = @"\b\d{3,}\b";
            if (File.Exists(wTextFile)) {
                var wNumberTexts = File.ReadAllLines(wTextFile);
                foreach (var wNumberText in wNumberTexts) {
                    var wMatcheNumbers = Regex.Matches(wNumberText, wNumberMoreThree);
                    foreach (Match wMatcheNumber in wMatcheNumbers) {
                        Console.WriteLine(wMatcheNumber.Value);
                    }
                }
            } else Console.WriteLine("テキストファイルが存在しませんでした。");
        }
    }
}
