using System;

namespace Chapter5_1_2 {
    internal class Program {
        /* [問題5-1-2]
        　　コンソールから入力した数字文字列をint型に変換した後、カンマ付きの数字文字列に変換してください。
        　　入力した文字列は、int.TryParseメソッドで数値に変換してください。
        */
        static void Main(string[] args) {
            var wNumericString = int.TryParse(Console.ReadLine(), out var wNumber);
            if (wNumericString) {
                Console.WriteLine(wNumber.ToString());
            } else {
                Console.WriteLine("変換に失敗しました。");
            }
        }
    }
}
