namespace ReChapter1_1_1 {
    /// <summary>
    /// 商品クラス
    /// </summary>
    /// 
    internal class Product {
        /// <summary>
        /// 商品コード
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 商品価格（税抜き）
        /// </summary>
        public int Price { get; private set; }

        /// <summary>
        /// 商品クラスのコンストラクタ
        /// </summary>
        /// <param name="vCode">商品コード</param>
        /// <param name="vName">商品名</param>
        /// <param name="vPrice">商品価格（税抜き）</param>
        public Product(int vCode, string vName, int vPrice) {
            this.Code = vCode;
            this.Name = vName;
            this.Price = vPrice;
        }

        /// <summary>
        /// 消費税額を求める
        /// </summary>
        /// <returns>消費税額</returns>
        public int GetTax() {
            return (int)(this.Price * 0.08);
        }

        /// <summary>
        /// 税込価格を求める
        /// </summary>
        /// <returns>税込価格</returns>
        public int GetPriceIncludingTax() {
            return this.Price + GetTax();
        }
    }
}
