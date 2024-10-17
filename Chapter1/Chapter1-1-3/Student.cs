using System;

namespace Chapter1_1_3 {
    //1.
    /// <summary>
    /// 生徒クラス
    /// </summary>
    internal class Student : Person {
        /// <summary>
        /// 学年
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// 組
        /// </summary>
        public int ClassNumber { get; set; }

        /// <summary>
        /// 生徒クラスのコンストラクタ
        /// </summary>
        /// <param name="vName">名前</param>
        /// <param name="vBirthday">誕生日</param>
        /// <param name="vGrade">学年</param>
        /// <param name="vClassNumber">組</param>
        public Student(string vName, DateTime vBirthday, int vGrade, int vClassNumber) {
            this.Name = vName;
            this.Birthday = vBirthday;
            this.Grade = vGrade;
            this.ClassNumber = vClassNumber;
        }
    }
}
