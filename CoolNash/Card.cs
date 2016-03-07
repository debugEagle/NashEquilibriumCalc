using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolNash
{
    public class Card
    {
        private int number;
        private int height;
        private int suit;

        public Card(int num)
        {
            number = num;
            suit = num % 13;
            height = num / 13;
        }

        public int Number { get { return number; } set { number = value; } }
        public String ToString()
        {
            return HeightToString(height) + SuitToString(suit);
        }

        private static String HeightToString(int Height)
        {
            switch (Height)
            {
                case 0:
                    return "2";
                case 1:
                    return "3";
                case 2:
                    return "4";
                case 3:
                    return "5";
                case 4:
                    return "6";
                case 5:
                    return "7";
                case 6:
                    return "8";
                case 7:
                    return "9";
                case 8:
                    return "T";
                case 9:
                    return "J";
                case 10:
                    return "Q";
                case 11:
                    return "K";
                case 12:
                    return "A";
                default:
                    return "A";
            }
        }

        private static String SuitToString(int Suit)
        {
            switch (Suit)
            {
                case 0:
                    return "s";
                case 1:
                    return "h";
                case 2:
                    return "c";
                case 3:
                    return "d";
                default:
                    return "d";
            }
        }
    }
}
