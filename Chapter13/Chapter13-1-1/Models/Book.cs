namespace Chapter13_1_1.Models {
    /// <summary>
    /// 本クラス
    /// </summary>
    public class Book {
        /// <summary>
        /// Id（主キー）
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 発行年
        /// </summary>
        public int PublishedYear { get; set; }
        /// <summary>
        /// 著者
        /// </summary>
        public virtual Author Author { get; set; }
    }
}
