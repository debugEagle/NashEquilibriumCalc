using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolNash
{
    public enum DName { FOLD, CALL, RAISE };
    public class Decision
    {
        public Decision(DName decision, int amount)
        {
            this.name = decision;
            this.amount = amount;
        }
        public DName Name { get { return name; } }
        DName name;
        public int Amount {get {return amount;} }
        int amount;
    }
    
}
