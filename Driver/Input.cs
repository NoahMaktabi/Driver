using System;

namespace Driver
{
    public class Input
    {
        /// <summary>
        /// Writes msgToUser, then converts input into int, checks that int is between or equals min and max before returning.
        /// invalidMsg must be provided in case the user types wrong input
        /// </summary>
        /// <param name="msgToUser"></param>
        /// <param name="invalidMsg"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Valid int from the criteria defined in the parameters</returns>
        public static int GetInt(string msgToUser, string invalidMsg, int min, int max)
        {
            Console.WriteLine(msgToUser);
            var input = Console.ReadLine();
            var success = int.TryParse(input, out var number);
            while (!success || !ValidInput(number, min, max))
            {
                Console.WriteLine(invalidMsg);
                input = Console.ReadLine();
                success = int.TryParse(input, out number);
            }
            return number;
        }

        private static bool ValidInput(int number, int min, int max)
        {
            return number >= min && number <= max;
        }
    }
}
