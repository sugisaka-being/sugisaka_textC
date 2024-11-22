using System;
using System.IO;
using System.IO.Compression;

namespace Chapter14_1_5 {
    internal class Program {
        /* [問題14-1-5]
        　　指定されたZIPファイルから、拡張子が.txtのファイルだけを抽出するコンソールアプリケーションを作成してください。
        　　ZIPファイルと出力先フォルダは以下に示すようにパラメータで指定します。
        　　第１パラメータがZIPファイルのパス、第２パラメータが出力先フォルダです。
        　　"unziptxt.exe d:\temp\sample.zip d\work"
        　　出力先フォルダが存在しない場合は新たに作成してください。
        */
        static void Main(string[] args) {
            if (args.Length != 2) {
                Console.WriteLine("コマンドライン引数を適切に利用してください。例）..\\..\\Sample.zip ..\\..\\Sample14-1-5");
                return;
            }
            var wZipFile = args[0];
            var wOutputFolder = args[1];
            if (!File.Exists(wZipFile)) {
                Console.WriteLine("指定されたzipファイルが存在しませんでした。");
                return;
            }
            if (!Directory.Exists(wOutputFolder)) Directory.CreateDirectory(wOutputFolder);

            try {
                using (ZipArchive wZipArchive = ZipFile.OpenRead(wZipFile)) {
                    foreach (var wEntry in wZipArchive.Entries) {
                        if (Path.GetExtension(wEntry.FullName).ToLower() == ".txt") {
                            var wDestinationPath = Path.Combine(wOutputFolder, wEntry.FullName);
                            string wDirectoryPath = Path.GetDirectoryName(wDestinationPath);
                            if (!Directory.Exists(wDirectoryPath)) {
                                Directory.CreateDirectory(wDirectoryPath);
                            }
                            wEntry.ExtractToFile(wDestinationPath, overwrite: true);
                        }
                    }
                    Console.WriteLine("全ての.txtファイルを抽出しました。");
                }
            } catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました {wEx.Message}");
            }
        }
    }
}
