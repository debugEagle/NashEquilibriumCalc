using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CoolNash
{
    public class HeadsupNash
    {
        public static Form1 form1;

        private static int effStack = 0;
        private static bool isAnte = false;
        public static void BuildNash(List<int> stacks, List<int> blinds, int nIter)
        {
            // range initialization:
            // uniform distribution
            Range sbRange = new Range(0.5f);
            Range bbRange = new Range(0.5f);

            form1.setMaxProgressBar(nIter);
            Range sbBest = new Range(); Range bbBest = new Range();
            effStack = Math.Min(stacks[0], stacks[1]);
            isAnte = (blinds.Count == 3);

            for (int i = 0; i < nIter; i++)
            {
                sbBest = BestResponse(bbRange, stacks, blinds, 0);
                sbRange.UpdateRange(sbBest, 1.0 - 1.0 / (i + 1.5));
                bbBest = BestResponse(sbRange, stacks, blinds, 1);
                bbRange.UpdateRange(bbBest, 1.0 - 1.0 / (i + 1.5));

                form1.updateProgressBar(i + 1);
            }
            form1.print("SB: " + sbRange.ToString() + "\nBB: " + bbRange.ToString());
        }

        private static Range BestResponse(Range oppRange, List<int> stacks, List<int> blinds, int pos)
        {
            Range res = new Range();
            double EVFold = stacks[pos];
            if (isAnte) EVFold -= blinds[2];

            if (pos == 0) EVFold -= blinds[0]; // sb
            else EVFold -= blinds[1]; // bb

            Parallel.For(0, 169, i => { Iteration(oppRange, stacks, blinds, pos, EVFold, i, out res.probability[i]); });

            return res;
        }

        private static void Iteration(Range oppRange, List<int> stacks, List<int> blinds, int pos, double EVFold, int handNum, out float res)
        {
            if (pos == 0) // sb
            {
                double oppCalls = HandCombos.RangeProbabilityKnowingHand(handNum, oppRange);
                TwoPlayerEquity pushEquity = Equities.HandVsRange(HandPool.getHand(handNum), oppRange);
                double EVPush = (1 - oppCalls) * (stacks[0] + Math.Min(stacks[1], blinds[1]))
                    + oppCalls * (pushEquity.win1 * (stacks[0] + effStack) + pushEquity.draw * (stacks[0]) + pushEquity.win2 * (stacks[0] - effStack));
                if (isAnte) EVPush += (1 - oppCalls) * blinds[2];

                if (EVPush > EVFold)
                    res = 1.0f;
                else res = 0.0f;
            }
            else // bb
            {
                TwoPlayerEquity callEquity = Equities.HandVsRange(HandPool.getHand(handNum), oppRange);
                double EVCall = callEquity.win1 * (stacks[0] + effStack) + callEquity.draw * (stacks[0]);

                if (EVCall > EVFold)
                    res = 1.0f;
                else res = 0.0f;
            }
        }
    }
}
