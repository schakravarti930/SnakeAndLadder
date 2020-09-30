using System;

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
            int currentPosition = START_POS, nextPosition;
            int throws = 0;
            while(currentPosition < FINISH_POS)
            {
                int numOnDice = DiceRoll();
                throws++;
                int stepsToMove = StepsToMove(numOnDice);
                if (currentPosition + stepsToMove > FINISH_POS)
                    nextPosition = currentPosition;
                else
                    nextPosition = currentPosition + stepsToMove;

                if (nextPosition < START_POS)
                    currentPosition = START_POS;
                else
                    currentPosition = nextPosition;
                Console.WriteLine($"The position after dice roll {throws} is {currentPosition}");
            }
            Console.WriteLine($"Final Position is {currentPosition} and Total Number of Dice Rolls is {throws}");
        }
    }
}
