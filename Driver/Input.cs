using System;

namespace Driver
{
    public class Input
    {
        /// <summary>
        /// Writes msgToUser, then request input from user,
        /// then converts input into int,
        /// checks that int is between or equals min and max before returning.
        /// invalidMsg must be provided in case the user types wrong input
        /// </summary>
        /// <param name="msgToUser">Msg to write to user before asking for input. Ex: Type your age,</param>
        /// <param name="invalidMsg">Msg to provide in case the input is not a number or not inside the min/max param</param>
        /// <param name="min">Minimum number allowed</param>
        /// <param name="max">Maximum number allowed</param>
        /// <returns>Valid int from the criteria defined in the parameters</returns>
        public static int GetIntFromUserInput(string msgToUser, string invalidMsg, int min, int max)
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
