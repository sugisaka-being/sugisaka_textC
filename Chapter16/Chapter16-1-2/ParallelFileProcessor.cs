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
            await Task.WhenAll(vAllCsFilePaths.Select(x => Task.Run(() => CsFileSearcher.SearchCsFiles(x))));
        }
    }
}
