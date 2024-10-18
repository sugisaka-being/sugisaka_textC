using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter3_1_2 {
    internal class Program {
        /* [問題3-1-2]
        　　以下のリストが定義してあります。
        　　var names = new List<string> {
            　　"Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canbera", "Hong Kong",
        　　};
        　　このリストに対して、ラムダ式を使い、次のコードを書いてください。

        　　1.
        　　コンソールから入力した都市名が何番目に格納されているかList<T>のFindIndexメソッドを使って調べ、その結果をコンソールに出力してください。
        　　見つからなかったら、-1を出力してください。なお、コンソールからの入力には、Console.ReadLineメソッドを利用してください。
        　　var line = Console.ReadLine();

        　　2.
        　　LINQのCountメソッドを使い、小文字の'o'が含まれている都市名がいくつあるかカウントし、その結果をコンソールに出力してください。

        　　3.
        　　LINQのWhereメソッドを使い、小文字の'o'が含まれている都市名を抽出し、配列に格納してください。
        　　その後、配列の各要素をコンソールに出力してください。

        　　4.
        　　LINQのWhereメソッドとSelectメソッドを使い、'B'で始まる都市名の文字数を抽出し、その文字数をコンソールに出力してください。
        　　都市名を表示する必要はありません。
        */
        static void Main(string[] args) {
            var wCityNames = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canbera", "Hong Kong",
            };

            // 1.
            Console.WriteLine("都市名を入力してください。");
            var wLine = Console.ReadLine();
            Console.WriteLine($"{wLine}は{wCityNames.FindIndex(n => n == wLine)}番目に格納されている。");

            // 2.
            Console.WriteLine($"'o'が含まれている都市名は{wCityNames.Count(n => n.Contains('o'))}つある。");

            // 3.
            Console.WriteLine("'o'が含まれている都市名を以下に記述する。");
            var wCityNames_o = wCityNames.Where(n => n.Contains('o')).ToArray();
            foreach (var wCityName in wCityNames_o) {
                Console.WriteLine(wCityName);
            }

            // 4.
            Console.WriteLine("'B'で始まる都市名の文字数を以下に記述する。");
            var wCityNames_B = wCityNames.Where(n => n[0] == 'B').Select(n => n.Length).ToArray();
            foreach (var wCityName in wCityNames_B) {
                Console.WriteLine(wCityName);
            }
        }
    }
}
