//AUTHOR:Mengshan Chen
//FILENAME: encryptWord.cs
//DATE: 04/28/2018
//REVISION HISTORY: 1
//REFERENCE:NONE

using System;
using System.Collections.Generic;
using static System.Console;

namespace p1_encryptWord
{
    public class encryptWord
    {
        //define fields
        private string rawWord;               //the input word                 
        private int shift;                    //the caesar cipher shift
        private int total;                    //the total value of guess shift
        private int count;                    //the number of guesses

        //create a guesslist to store a guessing shift
        private Dictionary<int, int> guessList = new Dictionary<int, int>();

        private const int CORRECTSHIFT = 3;    //correct shift
        private const int LENGTHREQUIRED = 4;  //length of word
        private const int TOTALCHAR = 26;      //total alphabets
        private const int MIN = 0;             //minimum non-positive number 
        private const int LOW = 1;             //lowest times of guess
        private const char CAPITAL = 'A';      //lowest capital 
        private const char LOWERCASE = 'a';    //lowest lowercase 

        //Description: constructor to initialize the object
        //preconditions: object created 
        //postconditions: variables of the object are initialized
        public encryptWord(string input)
        {
            rawWord = input;
            total = 0;
            for (int i = 0; i < TOTALCHAR; i++)
            {
                guessList.Add(i, MIN);
            }
        }

        //Description: get the input word
        //preconditions: a word is entered
        //postconditions: none
        public string getWord()
        {
            return rawWord;
        }

        //Description: check whether the length of string is not less than 4
        //preconditions: a word is entered
        //postconditions: the program may stop if it is false or 
        //                keep going if it is true
        public bool checkString()
        {
            if (rawWord.Length < LENGTHREQUIRED)
            {
                return false;
            }
            return true;
        }

        //Description: encrypt the word with the correct shift
        //preconditions: the word is in the right format
        //postconditions: the word is encrypted 
        public string correctEncrypt()
        {
            string output = string.Empty;
            foreach (char letter in rawWord)
            {
                shift = CORRECTSHIFT;
                output += cipher(letter);
            }
            return output;
        }

        //Description: encrypt the word with the guessing shift
        //preconditions: the word is in the right format
        //postconditions: the word is encrypted  
        public string guessEncrypt(int key)
        {
            string output = string.Empty;
            foreach (char letter in rawWord)
            {
                shift = key;
                output += cipher(letter);
            }
            return output;

        }

        //Description: encrypt each letter with the 
        //             correct or guessing shift
        //preconditions: the program get the guessing/correct shifts
        //postconditions: each letter is encrypted 
        public char cipher(char letter)
        {
            char d = char.IsUpper(letter) ? CAPITAL : LOWERCASE;
            char encryptLetter = (char)((((letter + shift) - d) 
                                         % TOTALCHAR) + d);
            return encryptLetter;
        }

        //Description:decrypt the encrypted word with guessing shift
        //preconditions: the program get the guessing/correct shifts
        //postconditions: the dictionary called guessList is not empty
        public string decrypt(int key)
        {
            if (key < MIN || key >= TOTALCHAR)
            {
                Console.WriteLine("Illegal digit!");
            }
            int temp = TOTALCHAR - shift;
            string decryptedWord = guessEncrypt(key);
            guessList[shift]++;
            count++;
            total = total + shift;
            return decryptedWord;
        }

        //Description: check guessing shift is correct or not
        //preconditions: the program get the guessing/correct shifts
        //postconditions: guessing may keep going if true or stop if false
        public bool checkGuess(int key)
        {
            if (key == CORRECTSHIFT)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Description: return the number of wrong guesses
        //preconditions:the dictionary called guessList is not empty
        //postconditions: none
        public int numberOfQueries()
        {
            return count;
        }

        //Description: return the highest number of largest guess shift
        //preconditions:the dictionary called guessList is not empty
        //postconditions: none
        public int getHighGuess()
        {
            int maxGuess = MIN;
            foreach (var pair in guessList)
            {
                if (pair.Value >= guessList[maxGuess])
                {
                    maxGuess = pair.Key;
                }
            }
            return maxGuess;

        }

        //Description: return the lowest number of largest guess shift
        //preconditions:the dictionary called guessList is not empty
        //postconditions: none
        public int getLowGuess()
        {
            int minGuess = MIN;
            foreach (var pair in guessList)
            {
                if (total > MIN)
                {
                    if (pair.Value == LOW)
                    {
                        minGuess = pair.Key;
                    }
                }
                else
                {
                    minGuess = MIN;
                }
            }
            return minGuess;
        }

        //Description: return the average guess value
        //preconditions:the dictionary called guessList is not empty
        //postconditions: none
        public int getAverageGuess()
        {
            if(count == MIN){
                return 0;
            }else{
                int average = total / count;
                return average;
            }
        }

    }
}
