using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexteAlphabetizer
{
    class Alphabetizer : IComparer
    {

        private Dictionary<char, int> alphabetIndex = new Dictionary<char, int>()
        {
            { ' ', -100 }, //should sort to the front
            { 'a', 0 },
            { 'ā', 1 },
            { 'ω', 2 },
            { 'd', 3 },
            { 'э', 4 },
            { 'и', 5 },
            { 'e', 6 },
            { 'ē', 7 },
            { 'λ', 8 },
            { 'f', 9 },
            { 'g', 10 },
            { 'ж', 11 },
            { 'л', 12 },
            { 'h', 13 },
            { 'c', 14 },
            { 'i', 15 },
            { 'ī', 16 },
            { 'j', 17 },
            { 'k', 18 },
            { 'l', 19 },
            { 'm', 20 },
            { 'n', 21 },
            { 'ц', 22 },
            { 'o', 23 },
            { 'ч', 24 },
            { 'з', 25 },
            { 'ø', 26 },
            { 'p', 27 },
            { 'r', 28 },
            { 's', 29 },
            { 'x', 30 },
            { 't', 31 },
            { 'q', 32 },
            { 'u', 33 },
            { 'ū', 34 },
            { 'π', 35 },
            { 'w', 36 },
            { 'я', 37 },
            { 'v', 38 },
            { 'b', 39 },
            { 'ł', 40 },
            { 'z', 41 },
            { 'ψ', 42 },
            { 'г', 43 },
            { '-', 100 } //should sort to the end
        };

        /**
         * Returns -1 if string a is earlier in the alphabet than string b. Ie: -1 corresponds to a being earlier, 1 to b
         * @param a The first string
         * @param b The second string
         * @return If a is before b, returns -1 | If a is less than b, returns 1 | If they're equal, returns 0
         */
        int IComparer.Compare(object x, object y)
        {
            string a = (string)x;
            string b = (string)y;

            int aSpace = a.IndexOf('.');
            int bSpace = b.IndexOf('.');

            a = a.Substring(0, aSpace).ToLower();
            b = b.Substring(0, bSpace).ToLower();

            string shorter; //The shorter of the two strings.
            if (a.Length < b.Length) { shorter = a; }
            else { shorter = b; }

            for (int i = 0; i < shorter.Length; i++)
            {
                char aChar = a[i];
                char bChar = b[i];

                int aIndex = alphabetIndex[aChar];
                int bIndex = alphabetIndex[bChar];

                if (aIndex < bIndex) //a is before b
                {
                    return -1;
                }
                else if (bIndex < aIndex) //b is before a
                {
                    return 1;
                }
                //Nothing returns here if the characters are the same. On to the next one!
            }

            //If we get here, one string begins the other (eg: "car" and "cars") or they're the same
            if (a.Equals(b)) { return 0; }

            if (shorter.Equals(a)) { return -1; } //a is the shorter and therefore sequentially earlier; return -1
            else { return 1; } //b is the shorter and therefore sequentially earlier; return 1
        }
    }
}
