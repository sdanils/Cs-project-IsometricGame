using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class BalanceAndResult
    {
        public int money;
        public int score;

        public Castle castle;
        public Gate gate;

        public BalanceAndResult(Castle cast, Gate gate)
        {
            money= 2000;
            score= 0;
            this.castle = cast;
            this.gate = gate;
        }
    }
}
