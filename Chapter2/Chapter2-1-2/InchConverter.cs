namespace Chapter2_1_2 {
    /// <summary>
    /// インチ変換クラス
    /// </summary>
    internal class InchConverter {
        private const double C_ratio = 0.0254;

        /// <summary>
        /// インチからメートルへの変換
        /// </summary>
        /// <param name="vInch">インチ</param>
        /// <returns>メートルへ変換した値</returns>
        public static double ToMeter(double vInch) {
            return vInch * C_ratio;
        }
    }
}
