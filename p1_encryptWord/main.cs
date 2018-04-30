//AUTHOR:Mengshan Chen
//FILENAME: main.cs
//DATE: 04/28/2018
//REVISION HISTORY: 0
//REFERENCE:NONE

//DESCRIPTION:
//Overview: The encryptWord object will read a word; 
//          with a shift of 3, the word will be encrypted; 
//          but the words less than 4 characters long will
//          be rejected. Then the program will guess the
//          shift using random values until it gets a correct one. 
//          In this process,object will calculate the number of
//          queries, high guesses, low guesses, and average guess 
//          value;high guesses is the highest number of largest
//          guess shift;low guesses is the lowest number of 
//          largest guess shift;
//Functionality:constructor, getWord(),checkString(),
//          correctEncrypt(), guessEncrypt(), cipher(),
//          decrypt(),checkGuess(),getHighGuess(), 
//          getLowGuess(), getAverageGuess(), numberOfQueries();
//Dependencies: main.cs depends on driver.cs, and 
//              driver.cs depends on encryptWord.cs
//Legal states: encryptword object is created with valid word and 
//          valid guess shift is entered then the state will be on.
//          when the guess shift is correct and related
//          statistic is created, it is off; when the new 
//          object is created, it is reset;
//Legal input: input word should be all alphabetic and 
//          longer or equal to 4 characters; 
//          guess shift should be integer,
//          which is in the range of 0 to 25;
//Illegal input: input word is not alphabetic or 
//          less than 4 characters long, and 
//          guess shift is not integer, or is 
//          negative, or larger than or equal to 26;
//Legal Output: encrypted word will be alphabetic and 
//          equal to or longer to 4 characters; 
//          the statistics should be all numbers; 


//ASSUMPTION:
//Interface invariants: the number of alphabetic character is 
//          constant, which is 26; the correct shift is constant,
//          which is 3. 
//Format restriction: words should be alphabetic;
//          guess shift should be number and not negative;
//Value ranges: guess shift will be in the range of 0 to 25;
//Size of input: input word is longer or equal to 4 characters;
//Error handling: the guess shift is less than zero or larger than 25;
//          the input word is less than 4 characters;
//States transition: when the object initialized by 
//          the word not less than 4 characters, 
//          the object is on; when the guess shift is 
//          correct and related statistic is created, it is off; 
//          when the new object is created, it is reset;
//Class invariant: the calculation of encrypting/decrypting 
//          word is constant

using System;
using System.Collections.Generic;
using static System.Console;

namespace p1_encryptWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin testing...\n");
            List<driver> encryptlist  = new List<driver>{
                new driver("abc"),
                new driver("abcd"),
                new driver("bcdef")};
            foreach (driver word in encryptlist){
                word.test();
            }
            Console.WriteLine("\nTest done!\n");

        }
    }
}
