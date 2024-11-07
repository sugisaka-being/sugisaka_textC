using System;
using System.IO;
using System.Linq;

namespace Chapter9_1_5 {
    internal class Program {
        /* [問題9-1-5]
        　　指定したディレクトリおよびそのサブディレクトリの配下にあるファイルから
        　　ファイルサイズが1Mバイト（1,048,576バイト）以上のファイル名の一覧を表示するプログラムを書いてください。
        */
        static void Main(string[] args) {
            var wTargetDirectory = new DirectoryInfo(@"..\..\CheckFileSize9-1-5");
            const long C_OneMegabyte = 1 * 1024 * 1024;
            var wTargetFiles = wTargetDirectory.EnumerateFiles("*", SearchOption.AllDirectories).Where(x => x.Length >= C_OneMegabyte);
            if (wTargetFiles.Any()) {
                foreach (var wTargetFile in wTargetFiles) {
                    Console.WriteLine(wTargetFile.Name);
                }
            } else {
                Console.WriteLine("該当するファイルが見つかりませんでした。");
            }
        }
    }
}
