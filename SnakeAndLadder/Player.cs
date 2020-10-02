using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeAndLadder
{
    class Player
    {
        public int currentPosition, nextPosition, throws;
        public string Name;
        public Player(string Name)
        {
            this.Name = Name;
            this.currentPosition = 0;
            this.nextPosition = 0;
            this.throws = 0;
        }
    }
}
