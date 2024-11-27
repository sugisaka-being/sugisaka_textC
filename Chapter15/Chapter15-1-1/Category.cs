namespace Chapter15_1_1 {
    /// <summary>
    /// 書籍のカテゴリクラス
    /// </summary>
    internal class Category {
        /// <summary>
        /// カテゴリID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// カテゴリ名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 書籍のカテゴリクラスの情報を表示するメソッド
        /// </summary>
        /// <returns>プロパティ（IdとName）の情報</returns>
        public override string ToString() {
            return $"Id：{this.Id}, カテゴリ名：{this.Name}";
        }
    }
}
