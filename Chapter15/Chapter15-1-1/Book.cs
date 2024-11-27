namespace Chapter15_1_1 {
    /// <summary>
    /// 書籍クラス
    /// </summary>
    internal class Book {
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 価格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// カテゴリID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 発行年
        /// </summary>
        public int PublishedYear { get; set; }

        /// <summary>
        /// 書籍クラスの情報を表示するメソッド
        /// </summary>
        /// <returns>プロパティ（PublishedYear, CategoryId, Price, Title）の情報</returns>
        public override string ToString() {
            return $"タイトル：{this.Title}, 価格：{this.Price}, 発行年：{this.PublishedYear}, カテゴリ：{this.CategoryId}";
        }
    }
}
