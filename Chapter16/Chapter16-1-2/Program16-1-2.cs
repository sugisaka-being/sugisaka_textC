using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Chapter16_1_2 {
    internal class Program {
        /* [問題16-1-2]
        　　指定したディレクトリにあるC#のソースファイル（サブディレクトリを含む）の中をすべて検索し、キーワードasyncとawaitの両方を利用しているファイルを列挙してください。
        　　列挙する際はファイルのフルパスを表示してください。表示する順番は問いません。
        　　並列処理をした場合と並列処理をしない場合の2つのバージョンを作成し、どれくらい速度に差があるかも調べてください。
        */
        static async Task Main(string[] args) {
            Console.WriteLine("ファイル検索をしたいディレクトリの絶対パスを入力してください。例) \"C:\\Users\\Documents\\Chapter16\"");
            var wInputDirectory = Console.ReadLine();
            if (!Directory.Exists(wInputDirectory)) {
                Console.WriteLine("指定されたディレクトリが見つかりませんでした。");
                return;
            }
            string[] wAllCsFiles = Directory.GetFiles(wInputDirectory, "*.cs", SearchOption.AllDirectories);

            // 並列処理をする場合
            var wStopWatch = Stopwatch.StartNew();
            var wSearchFileTasks = new List<Task>();
            foreach (string wCsFile in wAllCsFiles) {
                wSearchFileTasks.Add(Task.Run(() => SearchCsFiles(wCsFile)));
            }
            await Task.WhenAll(wSearchFileTasks);
            wStopWatch.Stop();
            Console.WriteLine($"実行時間（並列処理をする場合）：{wStopWatch.ElapsedMilliseconds}ミリ秒");

            // 並列処理をしない場合
            wStopWatch = Stopwatch.StartNew();
            foreach (string wCsFile in wAllCsFiles) {
                SearchCsFiles(wCsFile);
            }
            wStopWatch.Stop();
            Console.WriteLine($"実行時間（並列処理をしない場合）：{wStopWatch.ElapsedMilliseconds}ミリ秒");

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
