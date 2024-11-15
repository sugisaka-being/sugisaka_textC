using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Chapter12_1_1 {
    /// <summary>
    /// 従業員クラス
    /// </summary>
    [XmlRoot("employee")]
    [DataContract]
    public class Employee {
        /// <summary>
        /// 社員ID
        /// </summary>
        [XmlElement("id")]
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        [XmlElement("name")]
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 採用日
        /// </summary>
        [XmlElement("hiredate")]
        [DataMember]
        public DateTime HireDate { get; set; }

        /// <summary>
        /// 従業員クラスのデフォルトコンストラクタ
        /// </summary>
        public Employee() { }

        /// <summary>
        /// 従業員クラスのコンストラクタ
        /// </summary>
        /// <param name="vId">社員ID</param>
        /// <param name="vName">名前</param>
        /// <param name="vHireDate">採用日</param>
        public Employee(int vId, string vName, DateTime vHireDate) {
            this.Id = vId;
            this.Name = vName;
            this.HireDate = vHireDate;
        }

        /// <summary>
        /// 情報を表示するメソッド
        /// </summary>
        /// <returns>プロパティの情報</returns>
        public override string ToString() {
            return $"社員ID:{this.Id}, 名前:{this.Name}, 採用日:{this.HireDate:yyyy/MM/dd}";
        }
    }
}
