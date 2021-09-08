using System;

namespace Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintLogo();
            DriversLicense program = new();
            program.Start();
        }



        private static void PrintLogo()
        {
            const string logo = @"
 _______  .______       __  ____    ____  __  .__   __.   _______ 
|       \ |   _  \     |  | \   \  /   / |  | |  \ |  |  /  _____|
|  .--.  ||  |_)  |    |  |  \   \/   /  |  | |   \|  | |  |  __  
|  |  |  ||      /     |  |   \      /   |  | |  . `  | |  | |_ | 
|  '--'  ||  |\  \----.|  |    \    /    |  | |  |\   | |  |__| | 
|_______/ | _| `._____||__|     \__/     |__| |__| \__|  \______|                                                                                                                                            
";

            Console.WriteLine(logo);
        }
        
    }

    
}
