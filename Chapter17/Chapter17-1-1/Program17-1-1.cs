using System;
using System.IO;

namespace Chapter17_1_1 {
    internal class Program {
        /* [問題17-1-1]
        　　テキストで示したTextProcessorクラスを使い、テキストファイルの中の全角数字をすべて半角数字に置き換えて、
        　　置き換えた結果をコンソールに出力するプログラムを作ってください。
        */
        static void Main(string[] args) {
            Console.WriteLine("読み込むファイルの絶対パスを入力してください。例）C:\\Users\\Documents\\Sample17-1-1.txt");
            var wInputFilePath = Console.ReadLine();
            if (!ExistsFileWithExtension(wInputFilePath, ".txt")) return;
            TextProcessor.Run<ToHankakuNumberProcessor>(wInputFilePath);
        }

        /// <summary>
        /// ファイルの存在と拡張子をチェックするメソッド
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        /// <param name="vFileExtension">拡張子</param>
        /// <returns>ファイルが指定された拡張子で存在している場合にtrueを返す</returns>
        static bool ExistsFileWithExtension(string vFilePath, string vFileExtension) {
            if (!File.Exists(vFilePath)) {
                Console.WriteLine("指定されたファイルが存在しませんでした。");
                return false;
            }
            if (Path.GetExtension(vFilePath).ToLower() != vFileExtension) {
                Console.WriteLine($"指定されたファイルは{vFileExtension}拡張子のファイルではありません。");
                return false;
            }
            return true;
        }
    }
}
