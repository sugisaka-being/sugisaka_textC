using System;
using System.IO;
using System.IO.Compression;

namespace Chapter14_1_5 {
    internal class Program {
        /* [問題14-1-5]
        　　指定されたZIPファイルから、拡張子が.txtのファイルだけを抽出するコンソールアプリケーションを作成してください。
        　　ZIPファイルと出力先フォルダは以下に示すようにパラメータで指定します。
        　　第１パラメータがZIPファイルのパス、第２パラメータが出力先フォルダです。
        　　出力先フォルダが存在しない場合は新たに作成してください。
        */
        static void Main(string[] args) {
            if (args.Length != 2) {
                Console.WriteLine("コマンドライン引数の数が不正です。2つにしてください。例）..\\..\\Sample.zip ..\\..\\Sample14-1-5");
                return;
            }
            var wZipFilePath = args[0];
            var wOutputFolderPath = args[1];
            if (!IsFileWithExtension(wZipFilePath, ".zip")) return;

            try {
                using (ZipArchive wZipArchive = ZipFile.OpenRead(wZipFilePath)) {
                    foreach (ZipArchiveEntry wEntry in wZipArchive.Entries) {
                        if (Path.GetExtension(wEntry.FullName).ToLower() == ".txt") {
                            var wDestinationPath = Path.Combine(wOutputFolderPath, wEntry.FullName);
                            string wDirectoryPath = Path.GetDirectoryName(wDestinationPath);
                            Directory.CreateDirectory(wDirectoryPath);
                            wEntry.ExtractToFile(wDestinationPath, overwrite: true);
                        }
                    }
                    Console.WriteLine("全ての.txtファイルを抽出しました。");
                }
            } catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました {wEx.Message}");
            }
        }

        /// <summary>
        /// 指定されたファイルの存在と拡張子をチェックするメソッド
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        static bool IsFileWithExtension(string vFilePath, string vFileExtension) {
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
