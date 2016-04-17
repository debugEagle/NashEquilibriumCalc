using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;

namespace CoolNash
{
    public class Equities
    {
        public static double epsilon = 0.00001;
        public static TwoPlayerEquity HandVsHand(Hand h1, Hand h2)
        {
            return EquityPool.getEquity(h1, h2);
            
        }

        public static TwoPlayerEquity HandVsHand(int h1, int h2)
        {
            return EquityPool.getEquity(h1, h2);
        }

        public static TwoPlayerEquity HandVsRange(Hand h1, Range r2)
        {
            TwoPlayerEquity res;
            res.win1 = 0.0; res.win2 = 0.0; res.draw = 0.0;
            double totalCombos = 0.0;
            for (int i = 0; i < 169; i++)
            {
                if (r2.probability[i] < epsilon) continue;

                Hand h2 = HandPool.getHand(i);
                TwoPlayerEquity temp = HandVsHand(h1, h2);
                double weight = HandCombos.get(i, h1.getValue()) * r2.probability[i];
                res.win1 += temp.win1 * weight;
                res.win2 += temp.win2 * weight;
                res.draw += temp.draw * weight;
                totalCombos += weight;
            }
            res.win1 /= totalCombos;
            res.win2 /= totalCombos;
            res.draw /= totalCombos;

            return res;
        }
        public static TwoPlayerEquity RangeVsRange(Range r1, Range r2)
        {
            TwoPlayerEquity res;
            res.win1 = 0.0; res.win2 = 0.0; res.draw = 0.0;
            double totalCombos = 0.0;
            for (int i = 0; i < 169; i++)
            {
                if (r1.probability[i] < epsilon) continue;
                for (int j = 0; j < 169; j++)
                {
                    if (r2.probability[j] < epsilon) continue;
                    Hand h1 = HandPool.getHand(i);
                    Hand h2 = HandPool.getHand(j);
                    TwoPlayerEquity temp = HandVsHand(h1, h2);
                    double weight = HandCombos.get(i, j) * r1.probability[i] * r2.probability[j];
                    res.win1 += temp.win1 * weight;
                    res.win2 += temp.win2 * weight;
                    res.draw += temp.draw * weight;
                    totalCombos += weight;
                }
            }
            res.win1 /= totalCombos;
            res.win2 /= totalCombos;
            res.draw /= totalCombos;

            return res;
        }

    }
}
