using System;

namespace Driver
{
    public class DriversLicense
    {
        private DateTime _dateOfBirth;
        public string AgeLimitation { get; private set; }
        public int AgeInYears { get; private set; }
        public int AgeInMonths { get; private set; }

        public void Start()
        {
            var birthday = new Birthday();
            _dateOfBirth = birthday.DateOfBirth;
            CheckAgeLimitation();
            ShowInformation();
        }

        private void ShowInformation()
        {
            Console.WriteLine(AgeLimitation);
            Console.WriteLine("Klicka <Enter> för att avsluta programmet");
            Console.ReadKey();
        }

        private void CheckAgeLimitation()
        {
            CalculateAge(_dateOfBirth);
            var message = "Fordon som du får övningsköra är: ";
            if (AgeInYears <= 14) message = "Du får inte köra fordon ännu.";
            if ((AgeInYears == 14 && AgeInMonths >= 9) || AgeInYears > 14) message += "\n-Moped klass I (EU-moped).";

            if (AgeInYears == 15 && AgeInMonths >= 9) message += "\n-Lätt motorcykel.";
            if (AgeInYears > 15) message += "\n-Lätt motorcykel.\n-Personbil.";
            if ((AgeInYears == 17 && AgeInMonths >= 6) || AgeInYears > 17) 
                message += "\n- Tung motorcykel (i trafikskola).\n-Personbil med lätt släpvagn, lätt lastbil, medelstor motorcykel.";

            if (AgeInYears > 17) message += "\n-Personbil med tungt släp och lastbil med tungt släp.";

            if ((AgeInYears == 19 && AgeInMonths >= 6) || AgeInYears > 19)
                message += "\n-Tung motorcykel (om du haft körkort för medelstor motorcykel i minst 1 år och 6 månader).";

            if (AgeInYears >= 21) message += "\n-Buss och buss med släp.";
            if (AgeInYears >= 23) message += "\n-Tung motorcykel med obegränsad effekt (i trafikskola 17 år och 6 månader).";

            AgeLimitation = message;
        }

        
        /// <summary>
        /// Calculates the the age in years and month provided 2 available props:
        /// AgeInYears which will be populated with age and:
        /// AgeInMonths which will be populated with months
        /// </summary>
        /// <param name="dob">The date of birth</param>
        private void CalculateAge(DateTime dob) {  
            var now = DateTime.Now;  
            var years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;  
            var pastYearDate = dob.AddYears(years);  
            var months = 0;  
            for (var i = 1; i <= 12; i++) {  
                if (pastYearDate.AddMonths(i) == now) {  
                    months = i;  
                    break;  
                } else if (pastYearDate.AddMonths(i) >= now) {  
                    months = i - 1;  
                    break;  
                }  
            }  
            var days = now.Subtract(pastYearDate.AddMonths(months)).Days;
            AgeInYears = years;
            AgeInMonths = months;
            
            ShowAgeString(years, months, days);
        }

        private static void ShowAgeString(int years, int months, int days) 
            => Console.WriteLine($"Ålder: {years} År, {months} Månad(er), och {days} Dag(ar)"); 
        
    }
}
