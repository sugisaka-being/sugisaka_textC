using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter16_1_2 {
    /// <summary>
    /// 並列処理を行うロジックをまとめたクラス
    /// </summary>
    internal class ParallelFileProcessor {

        /// <summary>
        /// 指定されたファイルの一覧を非同期で処理し、各ファイルに対して検索処理を行うメソッド
        /// </summary>
        /// <param name="vAllCsFilePaths">C#ソースファイルのファイルパス一覧/param>
        /// <returns>非同期処理の完了を示すタスク</returns>
        public async Task ProcessFilesAsync(string[] vAllCsFilePaths) {
            await Task.WhenAll(vAllCsFilePaths.Select(x => Task.Run(() => SearchCsFiles(x))));
        }

        /// <summary>
        /// 「async」と「await」の両方を含むファイルを検索するメソッド
        /// </summary>
        /// <param name="vCsFile">C#のソースファイル</param>
        static void SearchCsFiles(string vCsFile) {
            try {
                var wCsFileContents = File.ReadAllText(vCsFile);
                if (wCsFileContents.Contains("async") && wCsFileContents.Contains("await")) {
                    Console.WriteLine(Path.GetFullPath(vCsFile));
                }
            }
            catch (UnauthorizedAccessException wEx) {
                Console.WriteLine($"ファイルへのアクセスが拒否されました：{wEx.Message}");
            }
            catch (PathTooLongException wEx) {
                Console.WriteLine($"ファイルパスが長すぎます：{wEx.Message}");
            }
            catch (OutOfMemoryException wEx) {
                Console.WriteLine($"メモリが不足しています：{wEx.Message}");
            }
            catch (Exception wEx) {
                Console.WriteLine($"エラーが発生しました：{wEx.Message}");
            }
        }
    }
}
