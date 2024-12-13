using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Chapter16_1_1 {
    internal class Program {
        /* [問題16-1-1]
        　　.NET Framework4.5以降のStreamReaderクラスには、非同期処理を実現するReadLineAsyncメソッドが追加されています。
        　　このメソッドを使い、テキストファイルを非同期で読み込むコードを書いてください。
        　　アプリケーションの形態は、WindowsFormsでもWPFでも好きなものを選択してください。
        */
        static async Task Main(string[] args) {
            Console.WriteLine("読み込むテキストファイルの絶対パスを入力してください。例) \"C:\\Users\\Documents\\Sample16-1-1.txt\"");
            var wInputTextFilePath = Console.ReadLine();
            if (!ExistsFileWithExtension(wInputTextFilePath, ".txt")) return;
            var wStringBuilder = new StringBuilder();
            using (var wStreamReader = new StreamReader(wInputTextFilePath)) {
                while (!wStreamReader.EndOfStream) {
                    wStringBuilder.AppendLine(await wStreamReader.ReadLineAsync());
                }
            }
            Console.WriteLine(wStringBuilder);
        }
        /// <summary>
        /// ファイルの存在と拡張子をチェックするメソッド
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        /// <param name="vFileExtension">拡張子</param>
        /// <returns>指定した拡張子でファイルが存在していればtrueを返す</returns>
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
