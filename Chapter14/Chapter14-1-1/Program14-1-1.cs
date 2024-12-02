using System;
using System.Diagnostics;
using System.IO;

namespace Chapter14_1_1 {
    internal class Program {
        /* [問題14-1-1]
        　　ファイルにプログラムのパスとパラメータが複数行書かれています。
        　　このファイルを読み込み、プログラムを順に起動するプログラムを書いてください。
        　　１つのプログラムが終わるのを待って次のプログラムを起動してください。
        　　入力するファイルの形式は、通常のテキストファイルでもXMLファイルでも、好みの形式でかまいません。
        */
        static void Main(string[] args) {
            Console.WriteLine($"現在の作業ディレクトリ: {Environment.CurrentDirectory}");
            Console.WriteLine("読み込むファイルの絶対パスを入力してください。例) \"C:\\Users\\Documents\\Sample14-1-1.txt\"");
            var wInputFilePath = Console.ReadLine();
            if (!File.Exists(wInputFilePath)) {
                Console.WriteLine("指定されたファイルが存在しません。");
                return;
            }
            foreach (var wInputLine in File.ReadAllLines(wInputFilePath)) {
                if (string.IsNullOrWhiteSpace(wInputLine)) continue;
                string[] wProgramAndParamsInfo = wInputLine.Split(new char[] { ' ' }, 2);
                var wProcessStartInfo = new ProcessStartInfo(wProgramAndParamsInfo[0], wProgramAndParamsInfo.Length >= 2 ? wProgramAndParamsInfo[1] : null);
                Console.WriteLine($"起動中:{wProcessStartInfo.FileName} {wProcessStartInfo.Arguments}");
                try {
                    using (var wProcess = Process.Start(wProcessStartInfo)) {
                        wProcess.WaitForExit();
                    }
                    Console.WriteLine($"{wProcessStartInfo.FileName}が終了しました。");
                }
                catch (Exception wEx) {
                    Console.WriteLine($"プログラム実行時にエラーが発生しました {wEx.Message}");
                }
            }
        }
    }
}
