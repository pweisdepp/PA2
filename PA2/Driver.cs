using System;

namespace PA2
{
    class Driver
    {
        public void Run()
        {
            Console.WriteLine("Welcome to the EncryptWord driver");
            EncryptWord ew = new EncryptWord();

            Console.WriteLine("Setting word to 'bodacious'");
            ew.setEncryptedWord("Bodacious");

            Console.WriteLine(ew.getEncryptedWord());


            Console.WriteLine("Press any key to close window...");
            Console.ReadLine(); // use so console window doesn't disappear immediately
        }
    }
}
