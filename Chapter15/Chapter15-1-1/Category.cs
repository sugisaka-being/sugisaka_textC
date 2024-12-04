namespace Chapter15_1_1 {
    /// <summary>
    /// 書籍のカテゴリクラス
    /// </summary>
    internal class Category {
        /// <summary>
        /// カテゴリID
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// カテゴリ名
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 書籍のカテゴリクラスのコンストラクタ
        /// </summary>
        /// <param name="vId">カテゴリID</param>
        /// <param name="vName">カテゴリ名</param>
        public Category(int vId, string vName) {
            this.Id = vId;
            this.Name = vName;
        }

        /// <summary>
        /// 書籍のカテゴリクラスの情報を表示するメソッド
        /// </summary>
        /// <returns>プロパティ（IdとName）の情報</returns>
        public override string ToString() => $"Id：{this.Id}, カテゴリ名：{this.Name}";
    }
}
