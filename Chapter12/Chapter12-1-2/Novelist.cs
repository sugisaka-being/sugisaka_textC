using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Chapter12_1_2 {
    /// <summary>
    /// 小説クラス
    /// </summary>
    [XmlRoot("novelist")]
    [DataContract]
    public class Novelist {
        /// <summary>
        /// 名前
        /// </summary>
        [XmlElement("name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 生年月日
        /// </summary>
        [XmlElement("birth")]
        [DataMember(Name = "birth")]
        public DateTime Birth { get; set; }

        /// <summary>
        /// 代表作
        /// </summary>
        [XmlArray("masterpieces")]
        [XmlArrayItem("title")]
        [DataMember(Name = "masterpieces")]
        public string[] Masterpieces { get; set; }

        /// <summary>
        /// 情報を表示するメソッド
        /// </summary>
        /// <returns>小説クラスの情報</returns>
        public override string ToString() {
            return $"名前:{this.Name}, 生年月日:{this.Birth:yyyy年M月d日}, 代表作:{string.Join(", ", this.Masterpieces)}";
        }
    }
}
