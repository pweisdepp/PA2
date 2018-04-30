// AUTHOR: Peter Weisdepp
// FILENAME: EncryptWord.cs
// DATE: 04/29/18
// REVISION HISTORY: PA2

/*
 * Description:
 * EncryptWord represents a Caeser cipher whereby a word can be supplied and then encrypted by shifting each
 * letter forward by a certain number. For example, given the word "Salad" and shift value 6, EncryptWord will
 * give back the string "Ygrgj". The EncryptWord constructor can take no arguments, in which case the encapsulated
 * word will be an empty string and a default shift value is 5, or the constructor can take an integer argument which
 * serves as the shift value. The constructor can also take a string (at least 4 characters long), which serves as the 
 * word to encapsulate, and finally, the constructor can take both a string and an integer, serving as the word to 
 * encapsulate and the cipher shift to use, respectively.
 * 
 * During use, the supplied word is held by the EncryptWord class and the encrypted version of the word can be retrieved
 * using the getEncryptedWord() method. It is this method that performs the encryption of the word, based on the word itself
 * and the shift value, shifting each letter of the encapsulated word forward by the shift value, and wrapping around the 
 * end of the alphabet if needed. Users can guess the shift value using the guessCipherValue() method, and all guesses are stored
 * in an ArrayList. Some basic statistics based off these guesses can be retrieved, such as getTotalGuesses(), getLowGuesses(),
 * getHighGuesses(), and getAverageGuessValue(). Additionally, the state of the EncryptWord can be reset using the reset() 
 * method, which clears all guesses and sets the encapsulated word to an empty string. All methods have public visibility. 
 * 
 * Assumptions: 
 * For all preconditions, it is assumed that the object has been properly initialized through the constructor. 
 * The given shift value should be a positive integer.
 * For the getEncryptedWord() method to function, it is assumed that the user has supplied a word that is at least 4 characters
 * long and only consist of the 26 letters of the English alphabet. 
 */

using System;
using System.Collections;

public class EncryptWord
{
    /// <summary>
    /// Number of letters in the English alphabet, used to wrap the Caeser shift around.
    /// ie: 'z' will be encoded as 'c' with a shift value of 3. 
    /// </summary>
    private const int ALPHABET_SIZE = 26;

    private const int MINIMIM_WORD_LENGTH = 4;

    /// <summary>
    /// Size of the Caeser shift. A value of 5 will encode the letter 'f' as 'k', for example.
    /// </summary>
    private int shift;

    /// <summary>
    /// Word to be encapsulated and encoded. 
    /// </summary>
    private String word;

    /// <summary>
    /// ArrayList to store user guesses. Statistics on guesses will be calculated using this ArrayList.
    /// </summary>
    private System.Collections.ArrayList guesses = new ArrayList();


    /// <summary>
    /// Default EncryptWord constructor, initialized with the random shift value
    /// </summary>
    /// preconditions: none
    /// postconditions: EncryptWord initialized with a random default value
    public EncryptWord()
    {
        this.shift = getRandom();
    }

    /// <summary>
    /// EncryptWord constructor initialized with a shift value given by the supplied shift argument
    /// </summary>
    /// <param name="shift">The Caeser shift value</param>
    /// preconditions: none
    /// postconditions: EncryptWord initialized with the shift value (adjusted for alphabet size) given
    /// by the shift parameter
    public EncryptWord(int shift)
    {
        this.shift = Math.Abs(shift) % ALPHABET_SIZE;
    }

    /// <summary>
    /// EncryptWord constructor initialized with the given word and a random shift value.
    /// Note: supplied word must be 4 or more characters long, otherwise the encapsulated
    /// word will remain empty.
    /// </summary>
    /// <param name="word">Word to be encapsulated and encrypted</param>
    /// preconditions: none
    /// postconditions: EncryptWord initialized with the default shift value and with the
    /// encapsulated word set to the given word parameter
    public EncryptWord(string word)
    {
        if (word.Length < MINIMIM_WORD_LENGTH)
        {
            this.word = "";
        }
        else
        {
            this.word = word;
        }
        this.shift = getRandom();
    }

    /// <summary>
    /// EncryptWord constructor initialized with both a word to be encrypted and a Caeser shift value.
    /// Note: supplied word must be 4 or more characters long, otherwise the encapsulated
    /// word will remain empty.
    /// </summary>
    /// <param name="word">Word to be encapsulated and encrypted</param>
    /// <param name="shift">The Caeser shift value</param>
    /// preconditions: none
    /// postconditions: EncryptWord initialized with the shift value (adjusted for alphabet size) given
    /// by the shift parameter, and the encapsulated word set to the given word parameter
    public EncryptWord(string word, int shift)
    {
        if (word.Length < MINIMIM_WORD_LENGTH)
        {
            this.word = "";
        }
        else
        {
            this.word = word;
        }
        this.shift = Math.Abs(shift) % ALPHABET_SIZE;
    }

    /// <summary>
    /// Return the encrypted version of the encapsulated word, with each letter shifted forward by
    /// the amount given by the shift value. If no word has been supplied, an empty string will be returned.
    /// </summary>
    /// <returns>The encrypted version of the encapsulated word</returns>
    /// preconditions: A word, greater than 3 characters, has been supplied to the EncryptWord object.
    /// postconditions: None
    public string getEncryptedWord()
    {
        string encryptedWord = "";
        foreach (char c in word)
        {
            // This char offset adjusts for uppercase vs lowercase letters
            char charOffset = char.IsUpper(c) ? 'A' : 'a';
            encryptedWord += (char)((((c + shift) - charOffset) % ALPHABET_SIZE) + charOffset);
        }
        return encryptedWord;
    }

    /// <summary>
    /// Method to set the encapsulated word. If the default, or the shift-only, constructors were used to instantiate this object, 
    /// a word will need to be supplied via this method in order to get an encrypted word. Otherwise, this will overwrite the 
    /// word currently encapsulated. Note: statistics will not be reset when this method is called. The supplied word must 
    /// be 4 or more characters long.
    /// </summary>
    /// <param name="newWord">Word to be encapsulated and encrypted</param>
    /// preconditions: None
    /// postconditions: Encapsulated word set to the supplied word.
    public void setEncryptedWord(String newWord)
    {
        this.word = newWord;
    }

    /// <summary>
    /// Method to guess the value of the cipher shift. Returns true if the guess was correct, false otherwise.
    /// Note: you can still guess the shift value of the cipher even if no word has been encapsulated. 
    /// </summary>
    /// <param name="guess">Value of the guess</param>
    /// <returns>True if the guess was correct, false otherwise.</returns>
    /// preconditions: None
    /// postconditions: The value of the guess is stored in an ArrayList
    public bool guessCipherValue(int guess)
    {
        guesses.Add(guess);
        if (guess == shift)
        {
            return true;
        }
        else return false;
    }

    /// <summary>
    /// Reset the EncryptWord, clearing the encapsulated word and clearing all guesses that have been made.
    /// </summary>
    /// preconditions: None
    /// postconditions: Encapsulated word, if any, set to an empty string. All guesses in the ArrayList
    /// are erased. 
    public void reset()
    {
        guesses.Clear();
        word = "";
    }

    /// <summary>
    /// Get the total number of guesses that have been made for the shift value.
    /// </summary>
    /// <returns>Total number of guesses</returns>
    /// preconditions: None
    /// postconditions: None
    public int getTotalGuesses()
    {
        int numGuesses = guesses.Count;
        return numGuesses;
    }

    /// <summary>
    /// Get the number of guesses that were lower than the shift value.
    /// </summary>
    /// <returns>Number of guesses lowers than the shift value</returns>
    /// preconditions: None
    /// postconditions: None
    public int getLowGuesses()
    {
        int lowCount = 0;
        foreach (int guess in guesses)
        {
            if (guess < shift)
            {
                lowCount++;
            }
        }
        return lowCount;
    }

    /// <summary>
    /// Get the number of guesses that were greater than the shift value.
    /// </summary>
    /// <returns>Number of guesses greater than the shift value</returns>
    /// preconditions: None
    /// postconditions: None
    public int getHighGuesses()
    {
        int highCount = 0;
        foreach (int guess in guesses)
        {
            if (guess > shift)
            {
                highCount++;
            }
        }
        return highCount;
    }

    /// <summary>
    /// Get the average guess value.
    /// </summary>
    /// <returns>Average guess value</returns>
    /// preconditions: None
    /// postconditions: None
    public double getAverageGuessValue()
    {
        if (guesses.Count != 0)
        {
            double avgGuess = 0.0;
            foreach (int guess in guesses)
            {
                avgGuess += guess;
            }
            avgGuess = avgGuess / guesses.Count;
            return avgGuess;
        }
        else return 0;
    }

    /// <summary>
    /// Get a random number between 1 and 26, used to make the shift guessing more interesting. 
    /// </summary>
    /// <returns>Random number between 1-26</returns>
    /// preconditions: None
    /// postconditions: None
    private int getRandom()
    {
        Random rand = new Random();
        int randShift = rand.Next(1, 26);
        return randShift;
    }
}