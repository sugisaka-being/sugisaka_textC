using System.IO;

namespace Chapter17_1_1 {
    /// <summary>
    /// テキストファイル処理クラス
    /// </summary>
    internal class TextProcessor {
        /// <summary>
        /// 型引数Tのインスタンスを作成し、指定したファイルを処理するメソッド
        /// </summary>
        /// <typeparam name="T">処理用のクラス</typeparam>
        /// <param name="vFilePath">ファイルパス</param>
        public static void Run<T>(string vFilePath) where T : TextProcessor, new() {
            var wProcessor = new T();
            wProcessor.Process(vFilePath);
        }

        /// <summary>
        /// 読み込んだファイルを1行ずつ処理するメソッド
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        private void Process(string vFilePath) {
            Initialize(vFilePath);
            using (var wStreamReader = new StreamReader(vFilePath)) {
                while (!wStreamReader.EndOfStream) {
                    var wCurrentLine = wStreamReader.ReadLine();
                    Execute(wCurrentLine);
                }
            }
            Terminate();
        }

        /// <summary>
        /// ファイル処理の準備をするメソッド
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        protected virtual void Initialize(string vFilePath) { }

        /// <summary>
        /// ファイルを処理するメソッド
        /// </summary>
        /// <param name="vCurrentLine">ファイルの行</param>
        protected virtual void Execute(string vCurrentLine) { }

        /// <summary>
        /// 終了の処理をするメソッド
        /// </summary>
        protected virtual void Terminate() { }
    }
}
