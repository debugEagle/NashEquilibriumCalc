using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolNash
{
    public class CFRtrial
    {
        private static int effStack = 0;
        private static bool isAnte = false;
        public void StartCFR(List<int> stacks, List<int> blinds, int nIter)
        {
            effStack = Math.Min(stacks[0], stacks[1]);
            isAnte = (blinds.Count == 3);

            // building tree

            // selecting random hands
            // choosing random actions from strategies
            // selecting flop
            // choosing random actions from strategies
            // selecting turn
            // choosing random actions from strategies
            // selecting river
            // choosing random actions from strategies
            // showdown
            // payouts
            // updating regrets, based on payouts
            // updating strategies, based on regrets

        }
    }
}
