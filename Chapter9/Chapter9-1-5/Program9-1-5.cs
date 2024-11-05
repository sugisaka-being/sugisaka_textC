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
            var wTargetFiles = wTargetDirectory.EnumerateFiles().Where(x => x.Length > 1048576);
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
