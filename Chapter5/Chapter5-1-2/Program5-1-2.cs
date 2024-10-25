using System;
using System.Linq;

namespace Chapter5_1_2 {
    internal class Program {
        /* [問題5-1-2]
        　　コンソールから入力した数字文字列をint型に変換した後、カンマ付きの数字文字列に変換してください。
        　　入力した文字列は、int.TryParseメソッドで数値に変換してください。
        */
        static void Main(string[] args) {
            if (int.TryParse(ToHankakuNumber(Console.ReadLine()), out var wNumber)) {
                Console.WriteLine(wNumber.ToString("#,0"));
            } else {
                Console.WriteLine("数字以外の文字列が入力されたため、変換に失敗しました。");
            }
        }
        /// <summary>
        /// 半角変換メソッド
        /// </summary>
        /// <param name="vInputText">読み込んだ文字列</param>
        /// <returns>読み込んだテキストを半角にした文字列</returns>
        static string ToHankakuNumber(string vInputText) => new string(vInputText.Select(x => '０' <= x && x <= '９' ? (char)(x - '０' + '0') : x).ToArray());
    }
}
