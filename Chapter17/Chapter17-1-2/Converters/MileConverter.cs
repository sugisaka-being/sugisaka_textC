namespace Chapter17_1_2 {
    /// <summary>
    /// マイル変換クラス（親クラス：ConverterBase）
    /// </summary>
    internal class MileConverter : ConverterBase {
        /// <summary>
        /// 指定された単位名がマイルの単位かを判断するメソッド
        /// </summary>
        /// <param name="vUnitName">単位名</param>
        /// <returns>マイルの単位であればtureを返す</returns>
        public override bool IsMyUnit(string vUnitName) {
            return vUnitName.ToLower() == "mile" || vUnitName == this.UnitName;
        }

        /// <summary>
        /// メートルとの比率
        /// </summary>
        protected override double FRatio { get { return 1609.344; } }

        /// <summary>
        /// 距離の単位（マイル）
        /// </summary>
        public override string UnitName { get { return "マイル"; } }
    }
}
