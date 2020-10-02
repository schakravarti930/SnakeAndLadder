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
            Player p1 = new Player("Player One");
            Player p2 = new Player("Player Two");
            Player currentPlayer = p1;
            bool isGameFinished = false;
            while (!isGameFinished)
            {
                int numOnDice = DiceRoll();
                currentPlayer.throws++;
                int stepsToMove = StepsToMove(numOnDice);
                if (currentPlayer.currentPosition + stepsToMove == FINISH_POS)
                {
                    currentPlayer.nextPosition = FINISH_POS;
                    isGameFinished = true;
                }
                else if (currentPlayer.currentPosition + stepsToMove > FINISH_POS)
                    currentPlayer.nextPosition = currentPlayer.currentPosition;
                else
                    currentPlayer.nextPosition = currentPlayer.currentPosition + stepsToMove;
                if (currentPlayer.nextPosition < START_POS)
                    currentPlayer.currentPosition = START_POS;
                else
                    currentPlayer.currentPosition = currentPlayer.nextPosition;
                //Displaying Current Player Position After Every Dice Roll
                Console.WriteLine($"{currentPlayer.Name}'s Position after dice roll {currentPlayer.throws} is {currentPlayer.currentPosition}");
                // Continue Move if Ladder Occurs and Game is Not Finished
                if (stepsToMove > 0 && !isGameFinished)
                    continue;
                //Switch Players
                else if (!isGameFinished)
                    currentPlayer = currentPlayer == p1 ? currentPlayer = p2 : currentPlayer = p1;
            }
            Console.WriteLine($"The Winner is {currentPlayer.Name} with Total Throws {currentPlayer.throws}");
        }
    }
}
