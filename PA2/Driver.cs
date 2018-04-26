using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA2
{
    class Driver
    {

        public void Run()
        {
            EncryptWord ew = new EncryptWord();
            ew.setEncryptedWord("Tester");
            Console.WriteLine(ew.getEncryptedWord());
            Console.ReadLine();
        }
    }
}
