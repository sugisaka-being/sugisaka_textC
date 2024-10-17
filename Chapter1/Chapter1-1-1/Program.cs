using System;
// 3.
using ReChapter1_1_1;

namespace Chapter1_1_1 {
    internal class Program {
        /* [問題1-1-1]
        　　テキストで定義したProductクラスを使い、以下のコードを書いてください。

        　　1.
        　　どら焼きオブジェクトを生成するコードを書いてください。
        　　このときの商品番号は"98"、商品価格は"210"としてください。

        　　2.
        　　どら焼きオブジェクトの消費税額を求め、コンソールに出力するコードを書いてください。

        　　3.
        　　Productクラスが属する名前空間を別の名前空間に変更し、Mainメソッドから呼び出すようにしてください。
        　　ただし、MainメソッドのあるProgramクラスの名前空間はそのままとしてください */

        static void Main(string[] args) {
            // 1.
            var wDorayaki = new Product(98, "どら焼き", 210);

            // 2.
            Console.WriteLine($"消費税額は{wDorayaki.GetTax()}円です。");
        }
    }
}
