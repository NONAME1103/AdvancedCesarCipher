using System;
using System.Linq;

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
            
            // (ASCII codes lowercase: 97-122)
            
            // Gets key as list of integer numbers to shift cipher by
            int[] k = GetKey();
            // Gets message as string (of length greater than 0)
            string m = GetMessage();
            // Get cipher type
            int type = GetType();
            // Encrypt message
            string secret = type == 1 ? Encrypt1(m, k) : Encrypt2(m, k);
            Test(m, k, secret);
            
        }

        public static int[] GetKey() {
            string n = "";
            while (true) {
                Console.Write("Enter the key length (n): ");
                n = Console.ReadLine();
                try {
                    int intInput = Convert.ToInt32(n);
                    if (0 < intInput) {
                        break;
                    }
                    Console.WriteLine("\nInvalid Input!");
                }
                catch (FormatException) {
                    Console.WriteLine("\nInvalid Input!");
                }
            }
            return MakeKey(Convert.ToInt32(n));
        }

        public static int[] MakeKey(int n) {
            int[] key = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++) {
                int num = rand.Next(1, 27);
                key[i] = num;
            }
            return key;
        }

        public static string GetMessage() {
            while (true) {
                Console.Write("Enter the message to encrypt: ");
                string message = Console.ReadLine();
                if (message.Length > 0) {
                    return message;
                }
                Console.WriteLine("\nInvalid Input!");
            }
        }

        public static int GetType() {
            Console.WriteLine (@"
    Please select a cipher option:
    1) Reset shift each time
    2) Carry on from last shift each time
    ---------------------------------------");
            Console.Write ("    Option: ");
            string type = Console.ReadLine();
            if (Array.IndexOf(new string[] {"1", "2"}, type) != -1) {
                return Convert.ToInt32(type);
            }
            Console.WriteLine ("\nInvalid Option!");
            return GetType();
        }

        public static string Encrypt1(string m, int[] k) {
            char[] secret = m.ToCharArray();
            for (int i = 0; i < secret.Length; i++) {
                char temp = (char) (secret[i] + k[i % k.Length]);
                secret[i] = temp > 122 ? (char) (temp - 26) : temp;
            }
            return new string (secret);
        }
        
        public static string Encrypt2(string m, int[] k) {
            char[] secret = m.ToCharArray();
            int current = 0;
            for (int i = 0; i < secret.Length; i++) {
                char temp = (char) (secret[i] + k[i % k.Length] + current);
                current += k[i % k.Length];
                secret[i] = Normalize(temp);
            }
            return new string (secret);
        }

        public static char Normalize(char temp) {
            while (temp > 122) {
                temp = (char) (temp - 26);
            }
            return temp;
        }
        
        public static void Test(string m, int[] k, string secret) {
            Console.WriteLine($"\nPlain: {m}");
            Console.Write("Key: ");
            k.ToList().ForEach(x => Console.Write($"{Convert.ToString((char) (x + 96))}, "));
            Console.WriteLine($"\nEncrypted: {secret}");
        }
    }
}