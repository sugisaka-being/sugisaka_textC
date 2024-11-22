using System;
using System.Diagnostics;
using System.Reflection;

namespace Chapter14_1_2 {
    internal class Program {
        /* [問題14-1-2]
        　　自分自身のファイルバージョンとアセンブリバージョンを表示するコンソールアプリケーションを作成してください。
        */
        static void Main(string[] args) {
            var wFileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine($"ファイルバージョン：{wFileVersion.FileMajorPart} {wFileVersion.FileMinorPart} {wFileVersion.FileBuildPart} {wFileVersion.FilePrivatePart}");
            var wAssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine($"アセンブリバージョン：{wAssemblyVersion.Major} {wAssemblyVersion.Minor} {wAssemblyVersion.Build} {wAssemblyVersion.Revision}");
        }
    }
}
