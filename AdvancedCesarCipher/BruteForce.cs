using System;
using System.Linq;

namespace AdvancedCesarCipher {
    
    public class BruteForce {

        public static void Force(string secret) {
            Console.WriteLine($"Encrypted: {secret}");
            char[] chars = secret.ToCharArray();
            for (int i = 1; i < 27 ; i++) {
                chars = chars.ToList().Select(x => (char) (x - i)).ToArray();
                Console.WriteLine();
            }
        }
    }
}