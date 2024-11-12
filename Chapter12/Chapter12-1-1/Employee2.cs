using System;
using System.Runtime.Serialization;

namespace Chapter12_1_1 {
    /// <summary>
    /// 2つめの従業員クラス
    /// </summary>
    [DataContract]
    public class Employee2 {
        /// <summary>
        /// 社員ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 採用日
        /// </summary>
        [DataMember]
        public DateTime HireDate { get; set; }

        /// <summary>
        /// 情報を表示するメソッド
        /// </summary>
        /// <returns>プロパティの情報</returns>
        public override string ToString() {
            return $"社員ID:{this.Id}, 名前:{this.Name}, 採用日:{this.HireDate:yyyy/MM/dd}";
        }
    }
}
