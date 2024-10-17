using System.Collections.Generic;
using System.IO;

namespace Chapter2_1_3 {
    /// <summary>
    /// 売上集計クラス
    /// </summary>
    internal class SalesCounter {
        private IEnumerable<Sale> Fsales;

        /// <summary>
        /// 売上集計クラスのコンストラクタ
        /// </summary>
        /// <param name="vFilePath"></param>
        public SalesCounter(string vFilePath) {
            Fsales = ReadSales(vFilePath);
        }

        /// <summary>
        /// 売り上げデータを読み込み、Saleオブジェクトのリストを返す
        /// </summary>
        /// <param name="vFilepath">売り上げデータ</param>
        /// <returns>Saleオブジェクトのリスト</returns>
        private static IEnumerable<Sale> ReadSales(string vFilePath) {
            var wSales = new List<Sale>();
            var wLines = File.ReadAllLines(vFilePath);
            foreach (var wLine in wLines) {
                var wItems = wLine.Split(',');
                var wSale = new Sale(wItems[0], wItems[2], int.Parse(wItems[3]));
                wSales.Add(wSale);
            }
            return wSales;
        }

        /// <summary>
        /// 商品カテゴリ別の売上高を求める
        /// </summary>
        /// <returns>商品カテゴリ別の売上高</returns>
        public IDictionary<string, int> GetPerProductSales() {
            var wSales = new Dictionary<string, int>();
            foreach (var wSale in Fsales) {
                if (wSales.ContainsKey(wSale.ProductCategory))
                    wSales[wSale.ProductCategory] += wSale.Amount;
                else
                    wSales[wSale.ProductCategory] = wSale.Amount;
            }
            return wSales;
        }
    }
}
