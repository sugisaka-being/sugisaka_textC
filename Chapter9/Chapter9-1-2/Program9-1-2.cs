using System;
using System.IO;
using System.Linq;

namespace Chapter9_1_2 {
    internal class Program {
        /* [問題9-1-2]
        　　テキストファイルを読み込み、行の先頭に行番号を振り、その結果を別のテキストファイルに出力するプログラムを書いてください。
        　　書式と出力先のファイル名は自由に決めて構いません。出力するファイル名と同名のファイルがあった場合は、上書きしてください。
        */
        static void Main(string[] args) {
            var wFilePath = @"..\..\9_Sample.txt";
            if (File.Exists(wFilePath)) {
                var wOutputFilePath = @"..\..\Output.txt";
                File.WriteAllLines(wOutputFilePath, File.ReadLines(wFilePath).Select((x, y) => string.Format($"{y + 1,2}:{x}")));
            } else Console.WriteLine("読み込むファイルが存在しません。");
        }
    }
}
