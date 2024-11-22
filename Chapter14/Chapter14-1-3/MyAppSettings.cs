using System.Configuration;

namespace Chapter14_1_3 {
    /// <summary>
    /// 構成セクションクラス（ConfigurationSection）
    /// </summary>
    public class MyAppSettings : ConfigurationSection {
        [ConfigurationProperty("CalendarOption")]
        public CalendarOption CalendarOption {
            get { return (CalendarOption)this["CalendarOption"]; }
            set { this["CalendarOption"] = value; }
        }
    }
}
