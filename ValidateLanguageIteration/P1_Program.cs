using System;
using System.Collections.Generic;

/*Author:
 * LUIS ALBERTO ANTON DELGADILLO - ANTON DELLUA - antondellua@gmail.com
 */

namespace LenguajesFormales_Practica1
{
    class Program
    {
        //Alphabet global variable
        static char[] alphabet = new char[] { };
        //Language global List
        static List<string> language = new List<string>();
        
        //Main Program
        static void Main(string[] args)
        {
            //Greet the user and indicate him/her to capture the alphabet
            Console.WriteLine("Word-Language Validation, Luis Alberto Anton Delgadillo... Welcome!!! First you need to define the alphabet of symbols:");
            Console.WriteLine("Introduce all symbols without commas and then press enter");
            //Capture alphabet
            string a = Console.ReadLine();
            //Convert string to char array
            alphabet = a.ToCharArray();
            //Tell the user he´s going to capture the language
            Console.Clear();
            Console.WriteLine("Great! Now introduce the language, for each word press enter, once you're done type -exit and press enter");
            //Loop to store language
            string x = "";
            //While the word typed is different from -exit it validates it with the alphabet and stores it at the language
            do
            {
                x = Console.ReadLine();
                if (x != "-exit")
                {
                    var temp = x.ToCharArray();
                    //If word belongs to alphabet, store it
                    if (AlphabetValidation(temp))
                    {
                        language.Add(x);
                    }
                    //else, throw error
                    else Console.WriteLine("Word does not belong to Alphabet, try another one");
                }
                /*else if (language.Count == 0)
                {
                    Console.WriteLine("Language must contain at least one word");
                    x = "";
                }*/
            } while (x != "-exit");
            //Now we´re going to check n number of words typed by the user in the language concatenations
           
            string word = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Now introduce one word to see if it belongs to some iteration of the language:");
                word = Console.ReadLine();
                char[] temp = word.ToCharArray();
                //Check if word belongs to alphabet
                if (!AlphabetValidation(temp))
                {
                    Console.WriteLine("The word does not belong in the Alphabet");
                }
                //Check if word does not belong in alphabet
                else if (!LanguageValidation(word))
                {
                    Console.WriteLine("The word does not belong in the Language");
                }
                //Else, word belongs to language
                else
                {
                    Console.WriteLine("The word belongs to the language!!!");
                }
                Console.WriteLine("Continue? Yes/No");
                word = Console.ReadLine();
                if (word == "No") word = "-exit";
            } while (word != "-exit");
        }

        //Method to validate if a word id part of the language
        static bool LanguageValidation(string word)
        {
            //Control variable to break loop if word does not belong
            int control = 0;
            //while there is a word to compare, loop
            do
            {
                control = 0;
                //compare every word in the language with the given word
                foreach (string w in language)
                {
                    //Here we evaluate only the words that are equal or shorter than the given word
                    //If the evaluated word in the language is part of the beginning of the given word, remove it and shorten the given word, then reevaluate until it's empty or proven false

                    if (w.Length <= word.Length)
                    {
                        if (word.StartsWith(w))
                        {
                            word = word.Remove(0, w.Length);
                            control = 1;
                        }
                    }
                }
                if (control == 0) return false;
            } while (word.Length > 0);
            //If the program makes it all the way here is because the give word is now empty and the control var was never 0, hence, true.
            return true;
        }

        //Method to get length of shortest word of the language
        static int GetShortestWord(List<string> language)
        {
            int n = language[0].Length;
            foreach (string s in language)
            {
                if (s.Length < n) n = s.Length;
            }
            return n;
        }

        //Method to validate if a word is part of the alphabet
        static bool AlphabetValidation(char[] word)
        {
            //for each char in the word typed
            foreach(char c in word)
            {
                int i = 0;
                //Check if the char is equal to anyone of the chars or symbols in alphabet
                foreach(char ch in alphabet)
                {
                    if (ch == c)
                    {
                        i = 1;
                    }
                }
                //if none is equal, return false
                if (i == 0) return false;
            }
            return true;
        }
    }
}
