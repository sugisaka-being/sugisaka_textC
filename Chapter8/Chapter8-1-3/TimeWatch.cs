using System;

namespace Chapter8_1_3 {
    internal class TimeWatch {
        private DateTime FMemorytime;
        /// <summary>
        /// 開始時間を記録するメソッド
        /// </summary>
        public void Start() => this.FMemorytime = DateTime.Now;
        /// <summary>
        /// 停止時間と開始時間の差を算出するメソッド
        /// </summary>
        /// <returns>開始時間からの経過時間</returns>
        public TimeSpan Stop() => DateTime.Now - this.FMemorytime;
    }
}
