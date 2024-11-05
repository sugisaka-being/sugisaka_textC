using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Chapter9_1_1 {
    internal class Program {
        /* [問題9-1-1]
        　　以下の問題を解いてください。

        　　1.
        　　指定したC#のソースファイルを読み込み、キーワード"class"が含まれている行数をカウントするコンソールアプリケーションCountClassを作成してください。
        　　このとき、StreamReaderクラスを使い、1行ずつ読み込む処理にしてください。
        　　なお、以下の2点を前提としてかまいません。
        　　・classキーワードの前後には、必ず空白文字がある
        　　・リテラル文字列やコメントの中には、"class"という単語は含まれていない

        　　2.
        　　このプログラムをFile.ReadAAllLinesメソッドを利用して書き換えてください。

        　　3.
        　　このプログラムをFile.ReadLinesメソッドを利用して書き換えてください。
        */
        static void Main(string[] args) {
            var wFilePath = @"..\..\9_CountClass.txt";

            if (File.Exists(wFilePath)) {

                // 1.
                var wCountClass = 0;
                using (var wReader = new StreamReader(wFilePath, Encoding.UTF8)) {
                    while (!wReader.EndOfStream) {
                        if (wReader.ReadLine().Contains("class")) wCountClass++;
                    }
                }
                Console.WriteLine(wCountClass);

                // 2.
                Console.WriteLine(File.ReadAllLines(wFilePath, Encoding.UTF8).Count(x => x.Contains("class")));

                // 3.
                Console.WriteLine(File.ReadLines(wFilePath, Encoding.UTF8).Count(x => x.Contains("class")));

            } else Console.WriteLine("指定されたファイルが存在しません。");
        }
    }
}
