﻿using System;

namespace SnakeAndLadder
{
    class Program
    {
        public const int START_POS = 0, FINISH_POS = 100;
        public const int NO_PLAY = 0, LADDER = 1, SNAKE = 2;
        public static Random random = new Random();
        public static int DiceRoll()
        {
            return random.Next(1, 7);
        }
        public static int StepsToMove(int numOnDice)
        {
            int checkOption = random.Next(0, 3);
            int stepsToMove = 0;
            switch (checkOption)
            {
                case LADDER:
                    stepsToMove = numOnDice;
                    break;
                case SNAKE:
                    stepsToMove = -numOnDice;
                    break;
                default:
                    break;
            }
            return stepsToMove;
        }
        static void Main(string[] args)
        {
            int currentPosition = START_POS;
            int numOnDice = DiceRoll();
            int stepsToMove = StepsToMove(numOnDice);
        }
    }
}
