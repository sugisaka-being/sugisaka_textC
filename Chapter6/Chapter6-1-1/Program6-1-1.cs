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
            Console.WriteLine(wNumbers.Any() ? wNumbers.Max().ToString() : "要素がありません。");

            // 追加課題
            var wMax = 0;
            foreach (var wNumber in wNumbers) {
                if (wNumber > wMax) { wMax = wNumber; }
            }
            Console.WriteLine(wMax);

            // 2.
            Console.WriteLine($"{Environment.NewLine}2.");
            var wTakeOutNumbersCount = 2;
            foreach (var wNumber in wNumbers.Skip(wNumbers.Length - wTakeOutNumbersCount)) {
                Console.WriteLine(wNumber);
            }

            // 追加課題
            Console.WriteLine("数値を入力してください。");
            if (int.TryParse(ToHankakuNumber(Console.ReadLine()), out int wUserInput) && wUserInput <= wNumbers.Length) {
                foreach (var wNumber in wNumbers.Skip(wNumbers.Length - wUserInput)) {
                    Console.WriteLine(wNumber);
                }
            } else {
                Console.WriteLine("無効な数値が入力されました。");
            }

            // 3.
            Console.WriteLine($"{Environment.NewLine}3.");
            foreach (var wNumber in wNumbers.Select(x => x.ToString())) {
                Console.WriteLine(wNumber);
            }

            // 4.
            Console.WriteLine($"{Environment.NewLine}4.");
            wTakeOutNumbersCount = 3;
            foreach (var wNumber in wNumbers.OrderBy(x => x).Take(wTakeOutNumbersCount)) {
                Console.WriteLine(wNumber);
            }

            // 追加課題
            Console.WriteLine("数値を入力してください。");
            if (int.TryParse(ToHankakuNumber(Console.ReadLine()), out wUserInput) && wUserInput <= wNumbers.Length) {
                foreach (var wNumber in wNumbers.OrderBy(x => x).Take(wUserInput)) {
                    Console.WriteLine(wNumber);
                }
            } else {
                Console.WriteLine("無効な数値が入力されました。");
            }

            // 5.
            Console.WriteLine($"{Environment.NewLine}5.");
            Console.WriteLine(wNumbers.Distinct().Count(x => x > 10));

            // 追加課題
            var wCount = 0;
            foreach (var wNumber in wNumbers.Distinct()) {
                if (wNumber > 10) {
                    wCount++;
                }
            }
            Console.WriteLine(wCount);
        }
        /// <summary>
        /// 半角変換メソッド
        /// </summary>
        /// <param name="vInputText">変換前の文字列</param>
        /// <returns>半角に変換後の文字列</returns>
        static string ToHankakuNumber(string vInputText)
            => new string(vInputText.Select(x => '０' <= x && x <= '９' ? (char)(x - '０' + '0') : x).ToArray());
    }
}
