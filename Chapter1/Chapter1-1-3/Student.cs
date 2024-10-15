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
        /// <param name="vGrade">学年</param>
        /// <param name="vClassNumber">組</param>
        public Student(int vGrade, int vClassNumber) {
            this.Grade = vGrade;
            this.ClassNumber = vClassNumber;
        }
    }
}
