using System;
using System.IO;

namespace Chapter16_1_2 {
    /// <summary>
    /// 非並列処理を行うロジックをまとめたクラス
    /// </summary>
    internal class SequentialFileProcessor {

        /// <summary>
        /// 指定されたファイルパスの一覧を処理し、各ファイルに対して検索処理を行うメソッド
        /// </summary>
        /// <param name="vAllCsFilesPaths">C#ソースファイルのファイルパス一覧</param>
        public void ProcessFiles(string[] vAllCsFilesPaths) {
            foreach (string wCsFile in vAllCsFilesPaths) {
                SearchCsFiles(wCsFile);
            }
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
