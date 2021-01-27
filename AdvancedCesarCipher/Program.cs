using System;

namespace AdvancedCesarCipher {
    
    class Program {
        
        static void Main(string[] args) {
            /* In this version a message M is encoded using a key K.
            This key is an n letter word that is transposed into the
            alphabet Key (A=1 , B=2, C=3) to produce the shift pattern.
            The message is then shifted using the Cesar cipher on this repeating key. 
            You should code two solutions one where:
            1) The shift resets each time
            2) The shift carry on from where the last shift ended
            Using this and a three letter key run some tests to work out which is the
            more secure when it comes to a brute force attack */
            
            // GetKey
            char[] k = GetKey();
            // GetMessage
        }

        public static char[] GetKey() {
            string n = "";
            while (true) {
                Console.Write("Enter the key length (n): ");
                n = Console.ReadLine();
                try {
                    int intInput = Convert.ToInt32(n);
                    if (0 < intInput) {
                        break;
                    }
                    Console.WriteLine("\n\nInvalid Input!");
                }
                catch (FormatException) {
                    Console.WriteLine("\n\nInvalid Input!");
                }
            }
            return MakeKey(Convert.ToInt32(n));
        }

        public static char[] MakeKey(int n) {
            char[] key = new char[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++) {
                // Chooses a random lowercase letter
                int num = rand.Next(1, 26);
                key[i] = num;
            }
            return key;
        }
    }
}