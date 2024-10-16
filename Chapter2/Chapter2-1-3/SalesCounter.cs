using System.Collections.Generic;
using System.IO;

namespace Chapter2_1_3 {
    /// <summary>
    /// 売上集計クラス
    /// </summary>
    internal class SalesCounter {
        private IEnumerable<Sale> _sales;

        /// <summary>
        /// 売上集計クラスのコンストラクタ
        /// </summary>
        /// <param name="vFilePath"></param>
        public SalesCounter(string vFilePath) {
            _sales = ReadSales(vFilePath);
        }

        /// <summary>
        /// 売り上げデータを読み込み、Saleオブジェクトのリストを返す
        /// </summary>
        /// <param name="vFilepath">売り上げデータ</param>
        /// <returns>Saleオブジェクトのリスト</returns>
        private static IEnumerable<Sale> ReadSales(string vFilePath) {
            var wSales = new List<Sale>();
            var wLines = File.ReadAllLines(vFilePath);
            foreach (var line in wLines) {
                var wItems = line.Split(',');
                var wSale = new Sale {
                    ShopName = wItems[0],
                    ProductCategory = wItems[1],
                    Amount = int.Parse(wItems[2])
                };
                wSales.Add(wSale);
            }
            return wSales;
        }

        /// <summary>
        /// 商品カテゴリ別の売上高を求める
        /// </summary>
        /// <returns>商品カテゴリ別の売上高</returns>
        public IDictionary<string, int> GetPerProductSales() {
            var wDict = new Dictionary<string, int>();
            foreach (var sale in _sales) {
                if (wDict.ContainsKey(sale.ProductCategory))
                    wDict[sale.ProductCategory] += sale.Amount;
                else
                    wDict[sale.ProductCategory] = sale.Amount;
            }
            return wDict;
        }
    }
}
