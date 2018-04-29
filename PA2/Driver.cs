using System;

namespace PA2
{
    class Driver
    {
        public void Run()
        {
            Console.WriteLine("");
            EncryptWord ew = new EncryptWord();
            ew.setEncryptedWord("Tester");
            Console.WriteLine(ew.getEncryptedWord());


            Console.WriteLine("Press any key to close window...");
            Console.ReadLine(); // use so console window doesn't disappear immediately
        }
    }
}
