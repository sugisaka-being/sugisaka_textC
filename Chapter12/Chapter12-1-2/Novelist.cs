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
    }
}
