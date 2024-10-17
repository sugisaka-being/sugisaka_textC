using System;

namespace Chapter1_1_3 {
    /// <summary>
    /// 人間クラス
    /// </summary>
    internal class Person {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 誕生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 年齢を取得する
        /// </summary>
        /// <returns>年齢</returns>
        public int GetAge() {
            DateTime wToday = DateTime.Today;
            int wAge = wToday.Year - Birthday.Year;
            if (wToday < Birthday.AddYears(wAge)) {
                wAge--;
            }
            return wAge;
        }
    }
}
