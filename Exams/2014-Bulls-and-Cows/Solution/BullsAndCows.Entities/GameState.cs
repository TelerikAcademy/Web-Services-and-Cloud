using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Entities
{
    public enum GameState
    {
        WaitingForOpponent = 0,
        Finished = 1,
        RedInTurn = 2,
        BlueInTurn = 3
    }
}