using System;
using System.IO;

namespace Chapter9_1_3 {
    internal class Program {
        /* [問題9-1-3]
        　　あるテキストファイルの最後に別のテキストファイルの内容を追加するコンソールアプリケーションを書いてください。
        　　コマンドラインで2つのテキストファイルのパス名を指定できるようにしてください。
        */
        static void Main(string[] args) {
            if (args.Length < 2) {
                Console.WriteLine("元のファイルと追加するファイルのパスを入力してください");
                return;
            }
            var wOriginalFile = args[0];
            var wAddFile = args[1];
            if (!File.Exists(wAddFile)) {
                Console.WriteLine("無効なファイルパスが入力されました。");
                return;
            }
            File.AppendAllLines(wOriginalFile, File.ReadLines(wAddFile));
            Console.WriteLine("ファイルの追加が完了しました。");
        }
    }
}
