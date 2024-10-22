using System;
using System.Linq;

namespace Chapter4_1_2 {
    internal class Program {
        /* [問題4-1-2]
        　　問題4-1-1で定義したYearMonthクラスを使って、次のコードを書いてください。
        　　本章で学んだイディオムが使えるところでは、イディオムを使ってください。

        　　1.
        　　YearMonthを要素に持つ配列を定義し、初期値として5つのYearMonthオブジェクトをセットしてください。

        　　2.
        　　この配列の要素（YearMonthオブジェクト）をすべて列挙し、その値をコンソールに出力してください。

        　　3.
        　　配列の中の最初に見つかった21世紀のYearMonthオブジェクトを返すメソッドを書いてください。
        　　見つからなかった場合は、nullを返してください。foreach文を使って実装してください。

        　　4.
        　　3.で作成したメソッドを呼び出し、最初に見つかった21世紀のデータの年を表示してください。
        　　見つからなければ、"21世紀のデータはありません"を表示してください。

        　　5.
        　　配列に格納されているすべてのYearMonthの1カ月後を求め、その結果を新たな配列に入れてください。
        　　その後、その配列の要素の内容（年月）を順に表示してください。
        　　LINQを使えるところはLINQを使って実装してみてください。
        */
        static void Main(string[] args) {
            // 1.
            var wYearMonthCollection = new YearMonth[] {
                new YearMonth(1900, 1),
                new YearMonth(2000, 4),
                new YearMonth(2050, 7),
                new YearMonth(2100, 10),
                new YearMonth(2200, 12),
            };

            // 2.
            foreach (var wYearMonth in wYearMonthCollection) {
                Console.WriteLine($"{wYearMonth.Year}年{wYearMonth.Month}月");
            }

            // 4.
            Console.WriteLine(FindFirst21Century(wYearMonthCollection)?.ToString() ?? "21世紀のデータはありません");

            // 5.
            var wOneMonthLaters = wYearMonthCollection.Select(x => x.AddOneMonth()).ToArray();
            foreach (var wOneMonthLater in wOneMonthLaters) {
                Console.WriteLine(wOneMonthLater);
            }

        }
        // 3.
        /// <summary>
        /// 配列の最初の21世紀を見つけるメソッド
        /// </summary>
        /// <param name="vYearMonths">年月</param>
        /// <returns>配列の最初の21世紀（無い場合はnull）</returns>
        static YearMonth FindFirst21Century(YearMonth[] vYearMonths) {
            foreach (var wYearMonth in vYearMonths) {
                if (wYearMonth.Is21Century)
                    return wYearMonth;
            }
            return null;
        }
    }
}
