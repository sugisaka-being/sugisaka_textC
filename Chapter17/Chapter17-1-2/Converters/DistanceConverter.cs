namespace Chapter17_1_2 {
    /// <summary>
    /// 距離の単位を変換するクラス
    /// </summary>
    internal class DistanceConverter {
        /// <summary>
        /// 変換元の単位コンバーター
        /// </summary>
        public ConverterBase From { get; }

        /// <summary>
        /// 変換先の単位コンバーター
        /// </summary>
        public ConverterBase To { get; }

        /// <summary>
        /// 距離の単位を変換するクラスのコンストラクタ
        /// </summary>
        /// <param name="vFrom">変換元の単位コンバーター</param>
        /// <param name="vTo">変換先の単位コンバーター</param>
        public DistanceConverter(ConverterBase vFrom, ConverterBase vTo) {
            this.From = vFrom;
            this.To = vTo;
        }

        /// <summary>
        /// 指定された値の単位を変換するメソッド
        /// </summary>
        /// <param name="vDistanceValue">距離の値</param>
        /// <returns>変換結果</returns>
        public double Convert(double vDistanceValue) {
            double wMeter = this.From.ToMeter(vDistanceValue);
            return this.To.FromMeter(wMeter);
        }
    }
}
