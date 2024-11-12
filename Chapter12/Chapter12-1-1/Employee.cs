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
        /// 情報を表示するメソッド
        /// </summary>
        /// <returns>プロパティの情報</returns>
        public override string ToString() {
            return $"社員ID:{this.Id}, 名前:{this.Name}, 採用日:{this.HireDate:yyyy/MM/dd}";
        }
    }
}
