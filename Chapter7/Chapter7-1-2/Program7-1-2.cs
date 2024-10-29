using System;
using System.Collections.Generic;
namespace Chapter7_1_2 {
    internal class Program {
        /* [問題7-1-2]
        　　テキストで作成したプログラムに、以下の機能を追加してください。

        　　1.
        　　ディクショナリに登録されている用語の数を返すCountプロパティをAbbreviationsクラスに追加してください。

        　　2.
        　　省略語を引数に受け取るRemoveメソッドをAbbreviationsクラスに追加してください。
        　　要素が見つからない場合はfalseを、削除できた場合はtrueを返してください。

        　　3.CountプロパティとRemoveメソッドを利用するコードを書いてください。

        　　4.
        　　3文字の省略語だけを取り出し、以下の形式でコンソールに出力するコードを書いてください。
        　　必要ならAbbreviationsクラスに新たなメソッドを追加してください。
        　　ILO=国際労働機関
        　　IMF=国際通貨基金　...
        */
        static void Main(string[] args) {
            var wAbbrs = new Abbreviations();

            wAbbrs.Add("IOC", "国際オリンピック委員会");

            // 3.
            Console.WriteLine($"{wAbbrs.Count}用語登録されています。");
            Console.WriteLine("削除したい略語を入力してください。例）IOC");
            if (wAbbrs.Remove(Console.ReadLine())) {
                Console.WriteLine("要素が削除されました。");
            } else {
                Console.WriteLine("要素が見つかりませんでした。");
            }

            // 4.
            var wFetcher = new Abbreviations();
             wFetcher.FetchAbbrsWithKey(wAbbrs, 3);
        }
    }
}
