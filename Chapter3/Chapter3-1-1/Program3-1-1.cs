using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter3_1_1 {
    internal class Program {
        /* [問題3-1-1]
        　　以下のリストが定義してあります。
        　　var numbers = new List<int> {12, 87, 94, 14, 53, 20, 40, 35,  76, 91, 31, 17, 48 };
        　　このリストに対して、ラムダ式を使い、次のコードを書いてください。

        　　1.
        　　List<T>のExistsメソッドを使い、8か9で割り切れる数があるかどうかを調べ、その結果をコンソールに出力してください。

        　　2.
        　　List<T>のForEachメソッドを使い、各要素を2.0で割った値をコンソールに出力してください。

        　　3.
        　　LINQのWhereメソッドを使い、値が50以上の要素を列挙し、その結果をコンソールに出力してください。

        　　4.
        　　LINQのSelectメソッドを使い、それぞれの値を2倍にし、その結果をList<int>に格納してください。
        　　その後、List<int>の各要素をコンソールに出力してください。
        */
        static void Main(string[] args) {
            var wNumbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 1.
            Console.WriteLine(wNumbers.Exists(n => n % 8 == 0 || n % 9 == 0));

            // 2.
            wNumbers.ForEach(n => Console.WriteLine(n / 2.0));

            // 3.
            foreach (var wNumber in wNumbers.Where(n => n >= 50)) {
                Console.WriteLine(wNumber);
            }

            // 4.
            foreach (int wTwiceNumber in wNumbers.Select(n => n * 2).ToList()) {
                Console.WriteLine(wTwiceNumber);
            }
        }
    }
}
