using System;

namespace Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skriv din ålder i form av en siffra mellan 1 - 100");

            var age = AskForAge();
            var limitation = AgeLimitation(age);

            Console.Clear();
            Console.WriteLine($"Du är {age} år gammal. \n{limitation}");

            Console.WriteLine("\n\n\nKlicka på Enter för att avsluta programmet");
            Console.ReadKey();
        }

        private static int AskForAge()
        {
            var input = Console.ReadLine();
            var success = int.TryParse(input, out var number);
            while (!success || !CheckNumber(number))
            {
                Console.WriteLine("Inmatningen är felaktig. Skriv din ålder i form av en siffra mellan 1 - 100");
                input = Console.ReadLine();
                success = int.TryParse(input, out number);
            }
            return number;
        }

        private static bool CheckNumber(int number)
        {
            return number is > 1 and < 110;
        }

        #region AgeLimitation
        private static string AgeLimitation(int age)
        {
            var message = "Fordon som du får köra är: ";
            switch (age)
            {
                case < 15:
                    message = "Du får inte köra fordon ännu.";
                    break;
                case 15:
                    message += "\nMoped klass I (EU-moped).";
                    break;
                case 16:
                    message += "\nMoped klass I (EU-moped).\nLätt motorcykel.\nPersonbil.";
                    break;
                case 17:
                    message =
                        "\nMoped klass I (EU-moped).\nLätt motorcykel.\nTung motorcykel. Personbil med lätt släpvagn, lätt lastbil.";
                    break;
                case 18:
                    message +=
                        "\nMoped klass I (EU-moped).\nLätt motorcykel.\nTung motorcykel. Personbil med lätt släpvagn, lätt lastbil.\nPersonbil med tungt släp och lastbil med tungt släp och tung motorcykel.";
                    break;
                case > 20 and < 24:
                    message +=
                        "\nMoped klass I (EU-moped).\nLätt motorcykel.\nTung motorcykel. Personbil med lätt släpvagn, lätt lastbil.\nPersonbil med tungt släp och lastbil med tungt släp och tung motorcykel.\nBuss och buss med släp.";
                    break;
                case > 23:
                    message +=
                        "\nMoped klass I (EU-moped).\nLätt motorcykel.\nTung motorcykel. Personbil med lätt släpvagn, lätt lastbil.\nPersonbil med tungt släp och lastbil med tungt släp och tung motorcykel.\nBuss och buss med släp.\nTung motorcykel med obegränsad effekt";
                    break;
            }

            return message;
        }

        #endregion
        
    }
}
