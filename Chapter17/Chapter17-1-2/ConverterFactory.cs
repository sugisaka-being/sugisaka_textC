using System.Linq;

namespace Chapter17_1_2 {
    /// <summary>
    /// コンバーター管理クラス
    /// </summary>
    internal class ConverterFactory {
        /// <summary>
        /// 様々なコンバーターのインスタンス
        /// </summary>
        private static ConverterBase[] FConverters = new ConverterBase[] {
            new KiloMeterConverter(),
            new MileConverter(),
        };

        /// <summary>
        /// 指定された単位コンバーターのインスタンスを取得するメソッド
        /// </summary>
        /// <param name="vUnitName">単位名</param>
        /// <returns>指定された単位名に対応するコンバーターを返す</returns>
        public static ConverterBase GetInstance(string vUnitName) {
            return FConverters.FirstOrDefault(x => x.IsMyUnit(vUnitName));
        }
    }
}
