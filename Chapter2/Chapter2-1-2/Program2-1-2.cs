using System;

namespace Chapter2_1_2 {
    internal class Program {
        /* [問題2-1-2]
        　　テキストに記載した「距離換算プログラム」のコードを参考に、インチからメートルへの変換表を1インチ刻みでコンソールに出力するプログラムを書いてください。
        　　このときのインチの範囲は、1インチから10インチまでとしてください。1インチは0.0254メートルです。
        */
        static void Main(string[] args) {

            for (int inch = 1; inch <= 10; inch++) {
                Console.WriteLine($"{inch}インチは{InchConverter.ToMeter(inch)}メートルです。");
            }
        }
    }
}
