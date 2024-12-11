namespace Chapter15_1_1 {
    /// <summary>
    /// 書籍クラス
    /// </summary>
    internal class Book {
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// 価格
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// カテゴリID
        /// </summary>
        public int CategoryId { get; }

        /// <summary>
        /// 発行年
        /// </summary>
        public int PublishedYear { get; }

        /// <summary>
        /// 書籍クラスのコンストラクタ
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vPrice">価格</param>
        /// <param name="vCategoryId">カテゴリID</param>
        /// <param name="vPublishedYear">発行年</param>
        public Book(string vTitle, int vPrice, int vCategoryId, int vPublishedYear) {
            this.Title = vTitle;
            this.Price = vPrice;
            this.CategoryId = vCategoryId;
            this.PublishedYear = vPublishedYear;
        }

        /// <summary>
        /// 書籍クラスの情報を表示するメソッド
        /// </summary>
        /// <returns>プロパティ（PublishedYear, CategoryId, Price, Title）の情報</returns>
        public override string ToString() => $"タイトル：{this.Title}, 価格：{this.Price}, 発行年：{this.PublishedYear}, カテゴリ：{this.CategoryId}";
    }
}
