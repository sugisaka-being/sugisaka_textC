using System;
using System.Text.RegularExpressions;

namespace Chapter10_1_1 {
    internal class Program {
        /* [問題10-1-1]
        　　指定された文字列が携帯電話の電話番号かどうかを判定するメソッドを定義してください。
        　　電話番号は必ずハイフン（-）で区切られていなければなりません。
        　　また、先頭3文字は"090"、"080"、"070"のいずれかとします。
        */
        static void Main(string[] args) {
            var wNumber = "080-0000-1111";
            var wPhoneNumber = @"^0[789]0-\d{4}-\d{4}$";
            CheckPhoneNumber(wNumber, wPhoneNumber);
        }

        /// <summary>
        /// 電話番号判定メソッド
        /// </summary>
        /// <param name="vNumber">指定された文字列</param>
        /// <param name="vPhoneNumber">電話番号のパターン</param>
        static void CheckPhoneNumber(string vNumber, string vPhoneNumber) {
            if (Regex.IsMatch(vNumber, vPhoneNumber)) {
                Console.WriteLine($"{vNumber} は電話番号です。");
            } else Console.WriteLine($"{vNumber} は電話番号ではありません。");
        }
    }
}
