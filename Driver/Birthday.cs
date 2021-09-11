using System;

namespace Driver
{
    public class Birthday
    {
        private int _year;
        private int _month;
        private int _day;
        public DateTime DateOfBirth { get; private set; }

        public Birthday()
        {
            GetBirthday();
        }

        public void GetBirthday()
        {
            GetYear();
            GetMonth();
            GetDay();
            var dateString = _year.ToString() + "/" + _month.ToString() + "/" + _day.ToString();
            DateOfBirth = DateTime.Parse(dateString);
        }



        #region HelperMethods
        private void GetYear()
        {
            const string msgToUser = "Vilket år är du född? \nSkriv ett fullständigt år t.ex. 1982";
            const string invalidMsg = "Inmatningen är felaktig. \nSkriv ett fullständigt år t.ex. 1982";
            _year = Input.GetIntFromUserInput(msgToUser, invalidMsg, 1900, DateTime.Now.Year);
        }

        private void GetMonth()
        {
            Console.Clear();
            const string msgToUser = "Vilken månad är du född? \nSkriv en siffra mellan 1 - 12, t.ex. 5";
            const string invalidMsg = "Inmatningen är felaktig. \nSkriv en siffra mellan 1 - 12, t.ex. 5";
            _month = Input.GetIntFromUserInput(msgToUser, invalidMsg, 1, 12);
        }

        private void GetDay()
        {
            var maxDays = MaxDaysInMonth(_month);
            var msgToUser = "Vilken dag är du född? \nSkriv en siffra mellan 1 - " + maxDays + ", t.ex. 15";
            var invalidMsg = "Inmatningen är felaktig. \nSkriv en siffra mellan 1 - " + maxDays + ", t.ex. 15";
            _day = Input.GetIntFromUserInput(msgToUser, invalidMsg, 1, maxDays);
        }


        /// <summary>
        /// Provided int representing a month ex: 4 for april. The method returns how many days are in the provided month.
        /// </summary>
        /// <param name="month"></param>
        /// <returns>Returns how many days are in the provided month.</returns>
        private static int MaxDaysInMonth(int month)
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

        #endregion


    }
}
