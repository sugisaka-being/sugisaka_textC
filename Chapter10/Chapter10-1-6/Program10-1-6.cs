using System;
using System.Text.RegularExpressions;

namespace Chapter10_1_6 {
    internal class Program {
        /* [問題10-1-6]
        　　5文字の回文とマッチする正規表現を書いてください。
        　　数字や記号だけから成る回文を除外するにはどうしたら良いかも考えてください。
        */
        static void Main(string[] args) {
            var wText = "とまと しんぶん しんぶんし あいうえお るすにする pop level noon 12321 _____ ああ.ああ";
            var wFivePalindromes = Regex.Matches(wText, @"(?!(?:[\d\W]{5}))\b(\w)(\w)\w\2\1\b");
            foreach (Match wFivePalindrome in wFivePalindromes) Console.WriteLine(wFivePalindrome);
            // (?!(?:[/b\W]{5})
        }
    }
}
