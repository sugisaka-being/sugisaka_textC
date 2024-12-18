using System.IO;

namespace Chapter17_1_3 {
    /// <summary>
    /// テキストファイル処理クラス
    /// </summary>
    internal class TextFileProcessor {
        /// <summary>
        /// ファイル処理を行うサービスを保持
        /// </summary>
        private ITextFileService FService;

        /// <summary>
        /// テキストファイル処理クラスのコンストラクタ
        /// </summary>
        /// <param name="vService">ファイル処理を実行するサービス</param>
        public TextFileProcessor(ITextFileService vService) {
            FService = vService;
        }

        /// <summary>
        /// 読み込んだファイルを1行ずつ処理するメソッド
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        public void Run(string vFilePath) {
            FService.Initialize(vFilePath);
            using (var wStreamReader = new StreamReader(vFilePath)) {
                while (!wStreamReader.EndOfStream) {
                    var wCurrentLine = wStreamReader.ReadLine();
                    FService.Execute(wCurrentLine);
                }
            }
            FService.Terminate();
        }
    }
}
