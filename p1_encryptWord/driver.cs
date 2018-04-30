//AUTHOR:Mengshan Chen
//FILENAME: driver.cs
//DATE: 04/28/2018
//REVISION HISTORY: 0
//REFERENCE:NONE

using System;
using System.Collections.Generic;
using System.Collections;
using static System.Console;

namespace p1_encryptWord
{
    public class driver
    {
        public encryptWord en;     //create an encryptWord object

        private const int LETTERS = 25;     //guessing range
        private const int MIN_LETTERS = 0;  //minimum number of guessing 

        public driver(string word)
        {
            en = new encryptWord(word);
        }

        public void test(){
            Console.WriteLine("\nThe input word: " + en.getWord());

            //check the length of word
            if (!en.checkString())
            {
                Console.WriteLine("Reject!The length of a word should not " 
                                  + "be less than 4. ");
            }
            else
            {
                //get the encrypted word
                string output = en.correctEncrypt();
                Console.WriteLine("The encryted output: " + output + "\n");

                //guess the shift using random value 
                Random rnd = new Random();
                int guess = rnd.Next(MIN_LETTERS, LETTERS);
                while (!en.checkGuess(guess))
                {
                    string decryptWord = en.decrypt(guess);
                    Console.WriteLine("The guessing shift: " + guess);
                    Console.WriteLine("The decryted output: " + decryptWord);
                    Console.WriteLine("Incorrect!\n");
                    guess = rnd.Next(MIN_LETTERS, LETTERS);
                }
                Console.WriteLine("Correct!");
                Console.WriteLine("The correct shift is 3.");

                //get the statistics 
                int high = en.getHighGuess();
                int low = en.getLowGuess();
                int average = en.getAverageGuess();
                int count = en.numberOfQueries();
                Console.WriteLine("Number of Queries: {0}, High Guesses " +
                                  "= {1} , Low Guesses = {2}, Average " +
                                  "Guess Value = {3}", count, high,
                                  low, average);
            }
        }
    }
}
