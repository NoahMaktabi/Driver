using System;

namespace Driver
{
    public class Birthday
    {
        private int _year;
        private int _month;
        private int _day;

        public Birthday()
        {
            GetBirthday();
        }

        public DateTime DateOfBirth { get; set; }

        private void GetYear()
        {
            const string msgToUser = "Vilket år är du född? \nSkriv ett fullständigt år t.ex. 1982";
            const string invalidMsg = "Inmatningen är felaktig. \nSkriv ett fullständigt år t.ex. 1982";
            _year = Input.GetInt(msgToUser, invalidMsg, 1900, DateTime.Now.Year);
        }

        private void GetMonth()
        {
            Console.Clear();
            const string msgToUser = "Vilken månad är du född? \nSkriv en siffra mellan 1 - 12, t.ex. 5";
            const string invalidMsg = "Inmatningen är felaktig. \nSkriv en siffra mellan 1 - 12, t.ex. 5";
            _month = Input.GetInt(msgToUser, invalidMsg, 1, 12);
        }

        private void GetDay()
        {
            var maxDays = MaxDaysPerMonth(_month);
            var msgToUser = "Vilken dag är du född? \nSkriv en siffra mellan 1 - " + maxDays + ", t.ex. 15";
            var invalidMsg = "Inmatningen är felaktig. \nSkriv en siffra mellan 1 - " + maxDays + ", t.ex. 15";
            _day = Input.GetInt(msgToUser, invalidMsg, 1, maxDays);
        }

        public void GetBirthday()
        {
            GetYear();
            GetMonth();
            GetDay();
            var dateString = _year.ToString() + "/" + _month.ToString() + "/" + _day.ToString();
            DateOfBirth = DateTime.Parse(dateString);
        }

        private static int MaxDaysPerMonth(int month)
        {
            var maxDays = month switch
            {
                1 => 31,
                2 => 28,
                3 => 31,
                4 => 30,
                5 => 31,
                6 => 30,
                7 => 31,
                8 => 31,
                9 => 30,
                10 => 31,
                11 => 30,
                12 => 31,
                _ => 0
            };

            return maxDays;
        }
    }
}
