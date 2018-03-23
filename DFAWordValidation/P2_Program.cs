using System;
using System.Collections.Generic;
using System.Linq;

/*Author:
 * LUIS ALBERTO ANTON DELGADILLO - ANTON DELLUA - antondellua@gmail.com
 */

namespace Lenguajes_P2
{
    class Program
    {
        //Alphabet global variable
        static char[] alphabet = new char[] { };
        //Number of states global var
        static int states;
        //Array of final states
        static List<int> finalStates = new List<int>();
        //Bidimensional array of transitions
        static int[,] transitions;
        //Word variable
        static string word;

        static void Main(string[] args)
        {
            //Greet the user and indicate him/her to capture the alphabet
            Console.WriteLine("DFA Validation, Luis Alberto Anton Delgadillo... Welcome!!! First you need to define the alphabet of symbols:");
            Console.WriteLine("Introduce all symbols without commas and then press enter");
            //Capture alphabet
            string a = Console.ReadLine();
            //Convert string to char array
            alphabet = a.ToCharArray();
            //Clear screen and ask for number of states (q) in the DFA
            Console.Clear();
            Console.WriteLine("INPUT VALIDATION: NO");
            Console.WriteLine("Enter the number of states in the FDA and then press enter. Later, for each state you will have to capture the transition.");
            //Capture number of states
            string b = Console.ReadLine();
            states = Int32.Parse(b);
            //Now the user is going to type the number of the states that are final
            Console.Clear();
            Console.WriteLine("INPUT VALIDATION: NO");
            Console.WriteLine("Nice, now type the numbers of the states that are final, for each number press enter, to exit type -exit");
            Console.WriteLine("REMEMBER, the states go from 0 to the number of states you typed -1");
            //
            string x = "";
            int y;
            do
            {
                x = Console.ReadLine();
                if (x != "-exit")
                {
                    y = Int32.Parse(x);
                    if (y > states) Console.WriteLine("This is not a valid number, try again");
                    else finalStates.Add(y);
                }
            } while (x != "-exit");
            //Delete duplicates from final states and alphabet
            finalStates = finalStates.Distinct().ToList();
            alphabet = alphabet.Distinct().ToArray();
            //Prompt the user to capture the transitions for each state and alphabet letter
            Console.Clear();
            Console.WriteLine("INPUT VALIDATION: NO");
            Console.WriteLine("Now it's time to fill the transitions, for each state * letter of alphabet");
            transitions = new int[states, alphabet.Length];
            for (int i=0; i < states; i++)
            {
                int j = 0;
                foreach(char c in alphabet)
                {
                    Console.Write("d(q" + i + "," + c + ") = ");
                    transitions[i,j] = Int32.Parse(Console.ReadLine());
                    j++;
                }
            }
            //It's time to capture the words and validate
            do
            {
                Console.Clear();
                Console.WriteLine("INPUT VALIDATION: YES");
                Console.WriteLine("Write a word to validate with the DFA");
                word = Console.ReadLine();
                if (!AlphabetValidation(word.ToCharArray())) Console.WriteLine("The word does not belong in the Alphabet");
                else
                {
                    //Matrix state iterator
                    int ite = 0;
                    foreach (char c in word)
                    {
                        //Matrix alphabet iterator
                        int w = 0;
                        while (alphabet[w] != c) w++;
                        Console.Write("d(q" + ite + "," + c + ") = q");
                        ite = transitions[ite,w];
                        Console.WriteLine(ite);
                    }
                    if (finalStates.Contains(ite)) Console.WriteLine("The state q" + ite + " is part of the Final States, therefore, the word is ACCEPTED!");
                    else Console.WriteLine("The state q" + ite + " is not part of the Final States, therefore, the word is REJECTED!");
                }
                Console.WriteLine("Continue? Yes/No");
                word = Console.ReadLine();
                if (word == "No") word = "-exit";
            } while (word != "-exit");
        }

        //Method to validate if a word is part of the alphabet
        static bool AlphabetValidation(char[] word)
        {
            //for each char in the word typed
            foreach (char c in word)
            {
                int i = 0;
                //Check if the char is equal to anyone of the chars or symbols in alphabet
                foreach (char ch in alphabet)
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
