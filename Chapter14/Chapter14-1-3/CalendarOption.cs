using System.Configuration;

namespace Chapter14_1_3 {
    /// <summary>
    /// 構成セクションクラス（ConfigurationElement）
    /// </summary>
    public class CalendarOption : ConfigurationElement {
        /// <summary>
        /// 日付の表示形式
        /// </summary>
        [ConfigurationProperty("StringFormat")]
        public string StringFormat {
            get { return (string)this["StringFormat"]; }
        }

        /// <summary>
        /// 日付の最小値
        /// </summary>
        [ConfigurationProperty("Minimum")]
        public string Minimum {
            get { return (string)this["Minimum"]; }
        }

        /// <summary>
        /// 日付の最大値
        /// </summary>
        [ConfigurationProperty("Maximum")]
        public string Maximum {
            get { return (string)this["Maximum"]; }
        }

        /// <summary>
        /// 週の最初の日が月曜日かどうか
        /// </summary>
        [ConfigurationProperty("MondayIsFirstDay")]
        public string MondayIsFirstDay {
            get { return (string)this["MondayIsFirstDay"]; }
        }
    }
}
