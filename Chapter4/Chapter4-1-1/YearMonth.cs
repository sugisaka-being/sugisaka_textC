namespace Chapter4_1_1 {
    // 1.
    /// <summary>
    /// 年月クラス
    /// </summary>
    internal class YearMonth {
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; }

        // 2.
        /// <summary>
        /// 21世紀
        /// </summary>
        public bool Is21Century => 2001 <= this.Year && this.Year <= 2100;

        /// <summary>
        /// YearMonthクラスのコンストラクタ
        /// </summary>
        /// <param name="vYear">年</param>
        /// <param name="vMonth">月</param>
        public YearMonth(int vYear, int vMonth) {
            this.Year = vYear;
            this.Month = vMonth;
        }

        // 3.
        /// <summary>
        /// 1カ月後を求めるメソッド
        /// </summary>
        /// <returns>1カ月後の年月</returns>
        public YearMonth AddOneMonth() {
            if (this.Month == 12) {
                return new YearMonth(this.Year + 1, 1);
            } 
            return new YearMonth(this.Year, this.Month + 1);
        }

        // 4.
        /// <summary>
        /// ToStringをオーバーライドして年月を表示するメソッド
        /// </summary>
        /// <returns>〇年〇月</returns>
        public override string ToString() => $"{this.Year}年{this.Month}月";
    }
}
