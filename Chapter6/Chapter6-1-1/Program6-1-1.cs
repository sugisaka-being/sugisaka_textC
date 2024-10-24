using System;
using System.Linq;

namespace Chapter6_1_1 {
    internal class Program {
        /* [問題6-1-1]
        　　次のような配列が定義されています。
        　　var numbers = new int[] {5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35}
        　　この配列に対して、以下のコードを書いてください。

        　　1.
        　　最大値を求め、結果を表示してください。

        　　2.
        　　最後から2つの要素を取り出して表示してください。

        　　3.
        　　それぞれの数値を文字列に変換し、結果を表示してください。

        　　4.
        　　数の小さい順に並べ、先頭から3つを取り出し、結果を表示してください。

        　　5.
        　　重複を排除した後、10より大きい値がいくつあるのかカウントし、結果を表示してください。
        */
        static void Main(string[] args) {
            var wNumbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            // 1.
            Console.WriteLine("1.");
            Console.WriteLine(wNumbers.Max());

            // 2.
            Console.WriteLine($"{Environment.NewLine}2.");
            var wNum = 2;
            foreach (var wNumber in wNumbers.Skip(wNumbers.Length - wNum)) {
                Console.WriteLine(wNumber);
            }

            // 3.
            Console.WriteLine($"{Environment.NewLine}3.");
            foreach (var wNumber in wNumbers.Select(x => x.ToString())) {
                Console.WriteLine(wNumber);
            }

            // 4.
            Console.WriteLine($"{Environment.NewLine}4.");
            wNum = 3;
            foreach (var wNumber in wNumbers.OrderBy(x => x).Take(wNum)) {
                Console.WriteLine(wNumber);
            }

            // 5.
            Console.WriteLine($"{Environment.NewLine}5.");
            Console.WriteLine(wNumbers.Distinct().Count(x => x >10));
        }
    }
}
