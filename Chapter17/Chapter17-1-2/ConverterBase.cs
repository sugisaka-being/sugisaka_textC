namespace Chapter17_1_2 {
    /// <summary>
    /// 距離返換算のベースになるクラス
    /// </summary>
    internal abstract class ConverterBase {
        /// <summary>
        /// 指定された単位名が対応しているものか判定するメソッド
        /// </summary>
        /// <param name="vUnitName">距離の単位</param>
        /// <returns>指定された単位名に対応している場合trueを返す</returns>
        public abstract bool IsMyUnit(string vUnitName);

        /// <summary>
        /// メートルとの比率
        /// </summary>
        protected abstract double Ratio { get; }

        /// <summary>
        /// 距離の単位
        /// </summary>
        public abstract string UnitName { get; }

        /// <summary>
        /// メートルから変換するメソッド
        /// </summary>
        /// <param name="vMeter">メートルの値</param>
        /// <returns>メートルから変換された値</returns>
        public double FromMeter(double vMeter) => vMeter / this.Ratio;

        /// <summary>
        /// メートルへ変換するメソッド
        /// </summary>
        /// <param name="vFeet">変換対象の値</param>
        /// <returns>変換されたメートルの値</returns>
        public double ToMeter(double vFeet) => vFeet * this.Ratio;
    }
}
