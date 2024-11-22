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
            Console.WriteLine("読み込むファイルのファイル名を入力してください。例）Sample14-1-1.txt");
            var wInputFile = Console.ReadLine();
            if (!File.Exists(wInputFile)) {
                Console.WriteLine("指定されたファイルが存在しません。");
                return;
            }
            var wInputLines = File.ReadAllLines(wInputFile);
            foreach (var wInputLine in wInputLines) {
                if (string.IsNullOrWhiteSpace(wInputLine)) continue;
                var wLineParts = wInputLine.Split(new char[] { ' ' }, 2); ;
                var wProcessStartInfomation = new ProcessStartInfo {
                    FileName = wLineParts[0],
                    Arguments = wLineParts.Length >= 2 ? wLineParts[1] : null,
                };
                Console.WriteLine($"起動中:{wProcessStartInfomation.FileName} {wProcessStartInfomation.Arguments}");
                try {
                    using (var wProcess = Process.Start(wProcessStartInfomation)) {
                        wProcess.WaitForExit();
                    }
                    Console.WriteLine($"{wProcessStartInfomation.FileName}が終了しました。");
                } catch (Exception wEx) {
                    Console.WriteLine($"プログラム実行時にエラーが発生しました {wEx.Message}");
                }
            }
        }
    }
}
