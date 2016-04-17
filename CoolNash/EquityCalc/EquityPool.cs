using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CoolNash
{
    public class EquityPool
    {
        static TwoPlayerEquity[][] twoPlayerEquities;
        public EquityPool()
        {
            twoPlayerEquities = new TwoPlayerEquity[169][];
            for (int i = 0; i < 169; i++)
            {
                twoPlayerEquities[i] = new TwoPlayerEquity[169 - i];
                for (int j = 0; j < 169 - i; j++)
                {
                    String equities = getEquitiesString(i, i + j);
                    twoPlayerEquities[i][j] = EquitiesFromString(equities);
                }
            }
        }

        public static TwoPlayerEquity getEquity(Hand h1, Hand h2)
        {
            if (h1.getValue() <= h2.getValue()) return twoPlayerEquities[h1.getValue()][h2.getValue() - h1.getValue()];
            TwoPlayerEquity res = twoPlayerEquities[h2.getValue()][h1.getValue() - h2.getValue()];
            double t = res.win1; res.win1 = res.win2; res.win2 = t;
            return res;
        }

        public static TwoPlayerEquity getEquity(int h1, int h2)
        {
            if (h1 <= h2) return twoPlayerEquities[h1][h2 - h1];
            TwoPlayerEquity res = twoPlayerEquities[h2][h1 - h2];
            double t = res.win1; res.win1 = res.win2; res.win2 = t;
            return res;
        }

        private static TwoPlayerEquity EquitiesFromString(String str)
        {
            TwoPlayerEquity res;
            String[] eq = str.Split(' ');
            res.win1 = double.Parse(eq[0]);
            res.draw = double.Parse(eq[1]);
            res.win2 = double.Parse(eq[2]);
            return res;
        }

        private static int StringIndexTwoPlayers(int p1, int p2)
        {
            // p1 <= p2
            return p1 * (169 - p1) + p1 * (p1 - 1) / 2 + p2 + 1;
        }

        private static String getEquitiesString(int p1, int p2)
        {
            // p1 <= p2
            // WARNING: error prone. 
            // LineLength depends on whether line ending is \n or \r\n (34 and 35 respectively)
            const int LineLength = 34; // or 35
            int stringIndex = StringIndexTwoPlayers(p1, p2);
            int ind1 = (stringIndex - 1) * LineLength;
            int ind2 = stringIndex * LineLength - 1;
            if (ind2 < 0) ind2 = CoolNash.Properties.Resources.HandVsHand.Length - 1;
            return CoolNash.Properties.Resources.HandVsHand.Substring(ind1, ind2 - ind1).Trim();
        }

    }
}
