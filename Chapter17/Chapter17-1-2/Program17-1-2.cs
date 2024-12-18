using System;

namespace Chapter17_1_2 {
    internal class Program {
        /* [問題17-1-2]
        　　テキストで示した距離換算プログラムに機能を追加し、マイルとキロメートルも扱えるようにしてください。
        */
        static void Main(string[] args) {
            while (true) {
                ConverterBase wFromConvert = GetConverter("変換元の単位を入力してください　例）キロメートル");
                ConverterBase wToConvert = GetConverter("変換先の単位を入力してください　例）マイル");
                double wDistance = GetDistance(wFromConvert);
                double wConvertResult = new DistanceConverter(wFromConvert, wToConvert).Convert(wDistance);
                Console.WriteLine($"{wDistance}{wFromConvert.UnitName}は、{wConvertResult:0.000}{wToConvert.UnitName}です{Environment.NewLine}");
            }
        }

        /// <summary>
        /// ユーザーの入力から距離を取得するメソッド
        /// </summary>
        /// <param name="vFromConvert">変換元の単位コンバーター</param>
        /// <returns>入力された距離の値を返す</returns>
        static double GetDistance(ConverterBase vFromConvert) {
            while (true) {
                Console.Write($"変換したい距離(単位:{vFromConvert.UnitName})を入力してください　例)100 => ");
                if (double.TryParse(Console.ReadLine(), out double wDistanceValue)) return wDistanceValue;
                Console.WriteLine($"入力された距離は無効です。例を参考に再度入力し直してください");
            }
        }

        /// <summary>
        /// 入力された単位のコンバーターを取得するメソッド
        /// </summary>
        /// <param name="vOutputMessage">ユーザーに表示するメッセージ</param>
        /// <returns>入力された単位に対応するコンバーターを返す</returns>
        static ConverterBase GetConverter(string vOutputMessage) {
            while (true) {
                ConverterBase wConverter;
                Console.Write(vOutputMessage + " => ");
                if ((wConverter = ConverterFactory.GetInstance(Console.ReadLine())) != null) return wConverter;
                Console.WriteLine($"入力された単位は無効です。例を参考に再度入力し直してください");
            }
        }
    }
}
