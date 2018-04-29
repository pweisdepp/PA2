// AUTHOR: Peter Weisdepp
// FILENAME: Driver.cs
// DATE: 04/29/18
// REVISION HISTORY: PA2

/*
 * Description: Driver.cs is a simple driver for the EncryptWord class. The driver
 * instantiates an EncryptWord, then demonstrates the functionality of the EncryptWord
 * class using the console. The program runs in standalone fashion, ie no user input
 * is taken.
 */ 

using System;

namespace PA2
{
    class Driver
    {
        public void Run()
        {
            Console.WriteLine("Welcome to the EncryptWord driver");
            EncryptWord ew = new EncryptWord();

            Console.WriteLine("Setting word to 'Bodacious'");
            ew.setEncryptedWord("Bodacious");
            Console.WriteLine("");

            Console.Write("Print encrypted form of 'Bodacious': ");
            Console.WriteLine(ew.getEncryptedWord());
            Console.WriteLine("");

            Console.WriteLine("Guess a few shift values");
            Console.Write("Shift is 5? ");
            Console.WriteLine(ew.guessCipherValue(5));
            Console.Write("Shift is 10? ");
            Console.WriteLine(ew.guessCipherValue(10));
            Console.Write("Shift is 15? ");
            Console.WriteLine(ew.guessCipherValue(15));
            Console.Write("Shift is 20? ");
            Console.WriteLine(ew.guessCipherValue(20));
            Console.Write("Shift is 25? ");
            Console.WriteLine(ew.guessCipherValue(25));
            Console.WriteLine("");

            Console.Write("Number of guesses below shift value: ");
            Console.WriteLine(ew.getLowGuesses());
            Console.WriteLine("");

            Console.Write("Number of guesses above shift value: ");
            Console.WriteLine(ew.getHighGuesses());
            Console.WriteLine("");

            Console.Write("Total guesses: ");
            Console.WriteLine(ew.getTotalGuesses());
            Console.WriteLine("");

            Console.Write("Average guess value: ");
            Console.WriteLine(ew.getAverageGuessValue());
            Console.WriteLine("");

            Console.WriteLine("Reset the guesses...");
            ew.reset();
            Console.Write("New guess total: ");
            Console.WriteLine(ew.getTotalGuesses());
            Console.WriteLine("");

            Console.WriteLine("Setting new word: 'Tropique'");
            ew.setEncryptedWord("Tropique");
            Console.WriteLine("");
            Console.Write("Print encrypted form of 'Tropique: ");
            Console.WriteLine(ew.getEncryptedWord());

            Console.WriteLine("Press any key to close window...");
            Console.ReadLine(); // use so console window doesn't disappear immediately
        }
    }
}
