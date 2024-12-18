using System;
using System.IO;

namespace Chapter16_1_2 {
    /// <summary>
    /// ファイル処理の共通ロジックをまとめたクラス
    /// </summary>
    internal class CsFileSearcher {
        /// <summary>
        /// 「async」と「await」の両方を含むファイルを検索するメソッド
        /// </summary>
        /// <param name="vCsFile">C#のソースファイル</param>
        public static void SearchCsFiles(string vCsFile) {
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
