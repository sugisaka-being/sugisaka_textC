namespace Chapter17_1_3 {
    /// <summary>
    /// テキストファイル処理インターフェース
    /// </summary>
    internal interface ITextFileService {
        /// <summary>
        /// ファイル処理の準備をするメソッド
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        void Initialize(string vFilePath);

        /// <summary>
        /// ファイルを処理するメソッド
        /// </summary>
        /// <param name="vFileLine">ファイルの行</param>
        void Execute(string vFileLine);

        /// <summary>
        /// 終了の処理をするメソッド
        /// </summary>
        void Terminate();
    }
}
