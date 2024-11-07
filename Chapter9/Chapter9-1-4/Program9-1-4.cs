using System;
using System.IO;

namespace Chapter9_1_4 {
    internal class Program {
        /* [問題9-1-4]
        　　指定したディレクトリ直下にあるファイルを別のディレクトリにコピーするプログラムを作成してください。
        　　その際、コピーするファイル名は拡張子を含まないファイル名の後ろに、_bakを付加してください。
        　　つまり、元のファイル名がGreeting.txtならば、コピー先のファイル名はGreeting_bak.txtという名前にします。
        　　コピー先に同名のファイルがある場合は置き換えてください。
        */
        static void Main(string[] args) {
            var wSpecifyDirectory = new DirectoryInfo(@"..\..\CopySource_9-1-4");
            if (!Directory.Exists(wSpecifyDirectory.FullName)) {
                Console.WriteLine("コピー元のファイルが存在しませんでした。");
                return;
            }
            var wDirectoryFiles = wSpecifyDirectory.GetFiles();
            var wTargetDirectory = @"..\..\CopyTarget_9-1-4";
            if (!Directory.Exists(wTargetDirectory)) {
                Directory.CreateDirectory(wTargetDirectory);
            }
            foreach (var wDirectoryFile in wDirectoryFiles) {
                var wCopyFileName = Path.Combine(wTargetDirectory, Path.GetFileNameWithoutExtension(wDirectoryFile.FullName) + "_bak" + wDirectoryFile.Extension);
                wDirectoryFile.CopyTo(wCopyFileName, overwrite: true);
            }
        }
    }
}
