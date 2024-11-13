using System;
using System.Collections.Generic;

namespace Chapter13_1_1.Models {
    /// <summary>
    /// 著者クラス
    /// </summary>
    public class Author {
        /// <summary>
        /// Id（主キー）
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 生年月日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 本（複数のBookオブジェクトを持つことができる）
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }
    }
}
