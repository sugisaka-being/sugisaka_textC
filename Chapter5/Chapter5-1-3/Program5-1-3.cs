using System;
using System.Linq;
using System.Text;

namespace Chapter5_1_3 {
    internal class Program {
        /* [問題5-1-3]
        　　"Jackdaws love my big sphinx of quartz"という文字列があります。
        　　この文字列に対して、以下の問題を解いてください。

        　　1.
        　　空白が何文字あるかカウントしてください。

        　　2.
        　　文字列の中の"big"という部分文字列を"small"に置き換えてください。

        　　3.
        　　単語がいくつあるかカウントしてください。

        　　4.
        　　4文字以下の単語を列挙してください。

        　　5.
        　　空白で区切り、配列に格納した後、StringBuilderクラスを使い文字列を連携させ、
        　　元の文字列と同じものを作り出してください。
        　　元の文字列の中には連続した空白は存在しないものとします。
        */
        static void Main(string[] args) {
            var wStr = "Jackdaws love my big sphinx of quartz";

            // 1.
            Console.WriteLine($"空白は{wStr.Count(c => c == ' ')}文字あります。");

            // 2.
            Console.WriteLine(wStr.Replace("big", "small"));

            // 3.
            Console.WriteLine($"単語は{wStr.Split(' ').Count()}つあります。");

            // 4.
            foreach (var wWord in wStr.Split(' ')) {
                if (wWord.Length <= 4) {
                    Console.WriteLine(wWord);
                }
            }

            // 5.
            string[] wWords = wStr.Split(' ');
            var wNewStr = new StringBuilder();
            foreach (var wWord in wWords) {
                wNewStr.Append(wWord + ' ');
            }
            Console.WriteLine(wNewStr.ToString());
        }
    }
}
