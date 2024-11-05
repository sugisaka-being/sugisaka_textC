using System;
using System.IO;

namespace Chapter9_1_3 {
    internal class Program {
        /* [問題9-1-3]
        　　あるテキストファイルの最後に別のテキストファイルの内容を追加するコンソールアプリケーションを書いてください。
        　　コマンドラインで2つのテキストファイルのパス名を指定できるようにしてください。
        */
        static void Main(string[] args) {
            Console.WriteLine("追加先のファイルのパスを入力してください");
            var wOriginalFile = Console.ReadLine();
            Console.WriteLine("追加元のファイルのパスを入力してください。");
            var wAddFile = Console.ReadLine();
            if (File.Exists(wAddFile)) {
                File.AppendAllLines(wOriginalFile, File.ReadLines(wAddFile));
            } else {
                Console.WriteLine("無効なファイルパスが入力されました。");
            }
        }
    }
}
