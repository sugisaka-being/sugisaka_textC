using System;

namespace Chapter5_1_1 {
    internal class Program {
        /* [問題5-1-1]
        　　コンソールから入力した2つの文字列が等しいか調べるコードを書いてください。
        　　このとき、大文字、小文字の違いは無視するようにしてください。
        　　コンソールからの入力は、Console.ReadLineメソッドを利用してください。
        */
        static void Main(string[] args) {
            Console.WriteLine("1つ目の文字列を入力してください。");
            var wStr1 = Console.ReadLine();
            Console.WriteLine("2つ目の文字列を入力してください。");
            var wStr2 = Console.ReadLine();
            Console.WriteLine(string.Compare(wStr1, wStr2, ignoreCase: true) == 0 ? "2つの文字列は等しい" : "2つの文字列は異なる");
        }
    }
}
