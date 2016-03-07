using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolNash
{
    public class Hand
    {
        private int value;
        //0..168
        //0 - AA, 1 - AKs, ..., 168 - 22
        public Hand(int Value)
        {
            value = Value;
        }

        public Hand(String stringHand)
        {
            char c1 = stringHand[0];
            char c2 = stringHand[1];
            if (c1 == c2)
            {
                // pocket pair
                int c = intValue(c1);
                this.value = (c * 13 + c);
                return;
            }
            else
            {
                char c3 = stringHand[2];
                if (c3 == 's')
                {
                    // suited
                    this.value = (intValue(c1) * 13);
                    this.value = (this.value + intValue(c2));
                    return;
                }
                else
                {
                    // offsuit
                    this.value = (intValue(c2) * 13);
                    this.value = (this.value + intValue(c1));
                    return;
                }
            }
        }

        public int getValue()
        {
            return this.value;
        }

        public static String IntToString(int v)
        {
            int card1 = v / 13;
            int card2 = v % 13;
            if (card1 > card2)
            {
                return stringValue(card2) + stringValue(card1) + "o";
            }
            else if (card1 < card2)
            {
                return stringValue(card1) + stringValue(card2) + "s";
            }
            else
            {
                return stringValue(card1) + stringValue(card1);
            }
        }

        public override String ToString()
        {
            return IntToString(this.value);
        }

        public static String stringValue(int card)
        {
            switch (card)
            {
                case 0: return "A";
                case 1: return "K";
                case 2: return "Q";
                case 3: return "J";
                case 4: return "T";
                case 5: return "9";
                case 6: return "8";
                case 7: return "7";
                case 8: return "6";
                case 9: return "5";
                case 10: return "4";
                case 11: return "3";
                case 12: return "2";
                default: return "2";
            }
        }

        public static int intValue(char c)
        {
            switch (c)
            {
                case 'A': return 0;
                case 'K': return 1;
                case 'Q': return 2;
                case 'J': return 3;
                case 'T': return 4;
                case '9': return 5;
                case '8': return 6;
                case '7': return 7;
                case '6': return 8;
                case '5': return 9;
                case '4': return 10;
                case '3': return 11;
                case '2': return 12;
                default: return 12;
            }
        }
    }
}
