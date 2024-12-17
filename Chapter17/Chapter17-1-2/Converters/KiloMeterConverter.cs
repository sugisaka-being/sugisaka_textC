namespace Chapter17_1_2 {
    /// <summary>
    /// キロメートル変換クラス（親クラス：ConverterBase）
    /// </summary>
    internal class KiloMeterConverter : ConverterBase {
        /// <summary>
        /// 指定された単位名がキロメートルの単位かを判断するメソッド
        /// </summary>
        /// <param name="vUnitName">単位名</param>
        /// <returns>キロメートルの単位であればtrueを返す</returns>
        public override bool IsMyUnit(string vUnitName) => vUnitName.ToLower() == "kilometer" || vUnitName == this.UnitName;

        /// <summary>
        /// メートルとの比率
        /// </summary>
        protected override double Ratio => 1000;

        /// <summary>
        /// 距離の単位（キロメートル）
        /// </summary>
        public override string UnitName => "キロメートル";
    }
}
