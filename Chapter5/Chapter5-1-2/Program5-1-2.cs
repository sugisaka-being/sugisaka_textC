using System;
using System.Text;

namespace Chapter5_1_2 {
    internal class Program {
        /* [問題5-1-2]
        　　コンソールから入力した数字文字列をint型に変換した後、カンマ付きの数字文字列に変換してください。
        　　入力した文字列は、int.TryParseメソッドで数値に変換してください。
        */
        static void Main(string[] args) {
            if (int.TryParse(Console.ReadLine().Normalize(NormalizationForm.FormKC), out var wNumber)) {
                Console.WriteLine(wNumber.ToString("#,0"));
            } else {
                Console.WriteLine("数字以外の文字列が入力されたため、変換に失敗しました。");
            }
        }
    }
}
