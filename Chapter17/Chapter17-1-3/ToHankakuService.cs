﻿using System;
using System.Linq;

namespace Chapter17_1_3 {
    /// <summary>
    /// 全角数字を半角数字に変換するテキスト処理クラス（ITextFileServiceインターフェイスを実装）
    /// </summary>
    internal class ToHankakuService : ITextFileService {
        /// <summary>
        /// ファイル処理の準備をするメソッド
        /// </summary>
        public void Initialize(string vFilePath) {
        }

        /// <summary>
        /// 全角数字を半角数字に変換して出力するメソッド
        /// </summary>
        /// <param name="vTextLine">処理する文字列</param>
        public void Execute(string vTextLine) {
            var wConvertedTextLine = new string(vTextLine.Select(x => '０' <= x && x <= '９' ? (char)(x - '０' + '0') : x).ToArray());
            Console.WriteLine(wConvertedTextLine);
        }

        /// <summary>
        /// 処理が完了したことを知らせるメソッド
        /// </summary>
        public void Terminate() {
            Console.WriteLine("すべての処理が完了しました");
        }
    }
}