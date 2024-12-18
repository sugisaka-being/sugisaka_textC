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
                CsFileSearcher.SearchCsFiles(wCsFile);
            }
        }
    }
}
