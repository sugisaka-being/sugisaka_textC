using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1_1_3 {
    internal class Person {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
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
