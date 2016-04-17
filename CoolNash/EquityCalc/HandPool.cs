using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolNash
{
    public class HandPool
    {
        static Hand[] hands;

        public HandPool()
        {
            hands = new Hand[169];
            for (int i = 0; i < 169; i++)
            {
                hands[i] = new Hand(i);
            }
        }

        public static Hand getHand(int value)
        {
            return hands[value];
        }

        public static Hand getHand(String stringHand)
        {
            char c1 = stringHand[0];
            char c2 = stringHand[1];
            if (c1 == c2)
            {
                // pocket pair
                int c = Hand.intValue(c1);
                return hands[c * 13 + c];
            }
            else
            {
                char c3 = stringHand[2];
                if (c3 == 's')
                {
                    // suited
                    return hands[Hand.intValue(c1) * 13 + Hand.intValue(c2)];
                }
                else
                {
                    // offsuit
                    return hands[Hand.intValue(c2) * 13 + Hand.intValue(c1)];
                }
            }
        }
    }
}
