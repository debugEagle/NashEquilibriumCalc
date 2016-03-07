using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolNash
{
    public class MainAI
    {
        List<int> stacks;
        List<int> blinds;
        List<Decision> decisions;
        int position;
        Hand hand;
        Charts charts = new Charts();
        public MainAI()
        {

        }
        Decision GetDecision(List<int> stacks, List<int> blinds, List<Decision> decisions, int position, Hand hand)
        {
            this.stacks = stacks; this.blinds = blinds; this.decisions = decisions; this.position = position; this.hand = hand;
            // examples:
            // stacks: 500, 500, 500, 500, 500, 500
            // decisions: FOLD, FOLD
            // position: 2
            int raises = 0;
            for (int pl = 0; pl < decisions.Count; pl++)
            {
                if (decisions[pl].Name == DName.RAISE)
                    ++raises;
                
            }

            return new Decision(DName.FOLD, 0);
        }

        Decision Open()
        {
            if (stacks.Count == 2)
            {
                return OpenPushHeadsup();
            }
            return new Decision(DName.FOLD, 0);
        }

        Decision OpenPushHeadsup()
        {
            float effStack = Math.Min(stacks[0], stacks[1]) / (float)blinds[1];
            if (effStack < charts.HUpush[hand.getValue()]) return new Decision(DName.RAISE, stacks[0]);
            else return new Decision(DName.FOLD, 0);
        }

        Decision OpenPush3max()
        {

            return new Decision(DName.FOLD, 0);
        }

        int getIndex3max(List<float> effStacks)
        {
            List<int> intStacks = new List<int>();
            int result = 1;
            for (int i = 0; i < effStacks.Count; i++)
            {
                //if (effStacks[i] < 2.0)
                {
                    float efStack = (float)Math.Round((effStacks[i] * 4.0f), 0);
                    //effStacks[i] = (float)Math.Round(effStacks[i], 0);
                    intStacks.Add((int)(efStack + float.Epsilon));
                }
            }
            // intStacks to int

            return 0;
        }
    }
}
