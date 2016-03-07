using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolNash
{
    public class PostflopRange
    {
        public float[] probability;
        const int NumberOfHands = 1326;
        public PostflopRange()
        {
            probability = new float[NumberOfHands];
        }

        public PostflopRange(float p)
        {
            probability = new float[NumberOfHands];
            if (p < 1.00001 && p >= 0.0)
            {
                for (int i = 0; i < NumberOfHands; i++)
                {
                    probability[i] = p;
                }
            }
        }

        public void UpdateValue(float value, Card c1, Card c2)
        {
            int index = getIndex(c1.Number, c2.Number);
            probability[index] = value;
        }

        public void UpdateValue(float value, int c1, int c2)
        {
            int index = getIndex(c1, c2);
            probability[index] = value;
        }

        public float GetValue(Card c1, Card c2)
        {
            int index = getIndex(c1.Number, c2.Number);
            return probability[index];
        }

        private int getIndex(int c1, int c2) {
            if (c1 < c2)
            {
                int t = c1; c1 = c2; c2 = t;
            }
            // now c1 >= c2
            // 1,0 - 0
            // 2,0 - 2
            // 168, 0 - 168
            // 2, 1 - 169
            // 168, 1 - 335
            // 3, 2 - 336
            // ...
            // 168, 167 - 1325
            int index = 0;
            if (c2  > 0) index = ((168 + (168 - c2 )) * c2 ) / 2;
            index += c1  - c2  - 1;
            return index;
        }
    }
}
