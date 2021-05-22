using System;
using System.IO;

namespace CesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Alphabet used for length and comparison
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            
            //Receiving Original Phrase From File Input
            if (!File.Exists("InputText.txt"))
            {
                File.WriteAllLines("InputText.txt", new[]{"//Place The Text You Want To Cipher Bellow:","Replace Me"});
            }
            
            var originalPhrase = File.ReadAllLines("InputText.txt")[1];
            var cipheredPhrase = string.Empty;
            var decipheredPhrase = string.Empty;
            
            //Receiving Key From User Input
            Console.Write("Please insert your Key to Cypher:\n=>");
            var key = int.Parse(Console.ReadLine() ?? "0");

            //Ciphering Block Code
            foreach (var letter in originalPhrase.ToLower())
            {
                if (letter == ' ')
                {
                    cipheredPhrase += " ";
                }
                else
                {
                    cipheredPhrase += alphabet[(letter + key - 97) % alphabet.Length];
                }
            }
            
            //Deciphering Block Code
            foreach (var letter in cipheredPhrase)
            {
                if (letter == ' ')
                {
                    decipheredPhrase += " ";
                }
                else
                {
                    decipheredPhrase += alphabet[Mod(letter - key - 97, alphabet.Length)];
                }
            }

            //Printing Ciphered Phrase To File
            File.WriteAllText("CesarCipher.txt",$"Ciphered Phrase\n=>{cipheredPhrase}");
            
            //Printing Deciphered Phrase To File
            Console.Write("Do You Want To Print The Deciphered File As Well? (y/N)\n=>");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                File.WriteAllText("CesarDeciphered.txt", $"Deciphered Phrase\n=>{decipheredPhrase}");
            }
        }
        
        //Modulo Method That Returns Modulo, To Decipher Cesar Cipher
        private static int Mod(int number, int divider)
        {
            var remainder = number % divider;
            
            if (remainder < 0)
            {
                return remainder + divider;
            }

            return remainder;
        }
    }
}