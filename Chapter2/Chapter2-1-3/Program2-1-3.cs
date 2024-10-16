using System;

namespace Chapter2_1_3 {
    internal class Program {
        /* [問題2-1-3]
        　　テキストに記載した「売上集計プログラム」のプログラムを変更し、商品カテゴリ別の売上高を求めるプログラムを作成してください。
        */
        static void Main(string[] args) {
            var wSales = new SalesCounter("C:..\\..\\sales.csv");
            var wAmountPerCategory = wSales.GetPerProductSales();
            foreach (var obj in wAmountPerCategory) {
                Console.WriteLine($"商品カテゴリ：{obj.Key}、売上高：{obj.Value}");
            }
        }
    }
}
