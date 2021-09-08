using System;

namespace Driver
{
    public class DriversLicense
    {
        private DateTime _dateOfBirth;
        public string AgeLimitation { get; private set; }
        public int AgeInYears { get; private set; }
        public int AgeInMonth { get; private set; }

        public void Start()
        {
            var birthday = new Birthday();
            _dateOfBirth = birthday.DateOfBirth;
            CheckAgeLimitation();
            ShowInformation();
        }

        private void ShowInformation()
        {
            var age = CalculateAge(_dateOfBirth);
            Console.WriteLine(age);
            Console.WriteLine(AgeLimitation);
            Console.WriteLine("Klicka <Enter> för att avsluta programmet");
            Console.ReadKey();
        }

        private void CheckAgeLimitation()
        {
            CalculateAge(_dateOfBirth);
            var message = "Fordon som du får övningsköra är: ";
            if (AgeInYears <= 14) message = "Du får inte köra fordon ännu.";
            if ((AgeInYears == 14 && AgeInMonth >= 9) || AgeInYears > 14) message += "\n-Moped klass I (EU-moped).";

            if (AgeInYears == 15 && AgeInMonth >= 9) message += "\n-Lätt motorcykel.";
            if (AgeInYears > 15) message += "\n-Lätt motorcykel.\n-Personbil.";
            if ((AgeInYears == 17 && AgeInMonth >= 6) || AgeInYears > 17) 
                message += "\n- Tung motorcykel (i trafikskola).\n-Personbil med lätt släpvagn, lätt lastbil, medelstor motorcykel.";

            if (AgeInYears > 17) message += "\n-Personbil med tungt släp och lastbil med tungt släp.";

            if ((AgeInYears == 19 && AgeInMonth >= 6) || AgeInYears > 19)
                message += "\n-Tung motorcykel (om du haft körkort för medelstor motorcykel i minst 1 år och 6 månader).";

            if (AgeInYears >= 21) message += "\n-Buss och buss med släp.";
            if (AgeInYears >= 23) message += "\n-Tung motorcykel med obegränsad effekt (i trafikskola 17 år och 6 månader).";

            AgeLimitation = message;
        }

        

        private string CalculateAge(DateTime dob) {  
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
            AgeInMonth = months;
            
            return $"Ålder: {years} År, {months} Månad(er), och {days} Dag(ar)";  
        } 
    }
}
