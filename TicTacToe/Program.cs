using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int playerTurn = 1;
    static int choice;

    static void Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine("\n");

            DrawBoard();

            if (CheckForWin() == 1)
            {
                Console.WriteLine("Player 1 wins!");
                break;
            }
            else if (CheckForWin() == 2)
            {
                Console.WriteLine("Player 2 wins!");
                break;
            }
            else if (CheckForTie())
            {
                Console.WriteLine("It's a tie!");
                break;
            }

            Console.WriteLine($"Player {playerTurn}, enter a number: ");
            choice = int.Parse(Console.ReadLine());

            if (choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
            {
                Console.WriteLine("Invalid move! Try again.");
                Console.ReadLine();
            }
            else
            {
                board[choice - 1] = (playerTurn % 2 == 1) ? 'O' : 'X';
                playerTurn = 3 - playerTurn;
            }

        } while (true);
    }

    static void DrawBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    static int CheckForWin()
    {
        #region Horzontal Winning Condtion
        if (board[0] == board[1] && board[1] == board[2])
        {
            return (board[0] == 'X') ? 1 : 2;
        }
        else if (board[3] == board[4] && board[4] == board[5])
        {
            return (board[3] == 'X') ? 1 : 2;
        }
        else if (board[6] == board[7] && board[7] == board[8])
        {
            return (board[6] == 'X') ? 1 : 2;
        }
        #endregion

        #region Vertical Winning Condtion
        else if (board[0] == board[3] && board[3] == board[6])
        {
            return (board[0] == 'X') ? 1 : 2;
        }
        else if (board[1] == board[4] && board[4] == board[7])
        {
            return (board[1] == 'X') ? 1 : 2;
        }
        else if (board[2] == board[5] && board[5] == board[8])
        {
            return (board[2] == 'X') ? 1 : 2;
        }
        #endregion

        #region Diagonal Winning Condtion
        else if (board[0] == board[4] && board[4] == board[8])
        {
            return (board[0] == 'X') ? 1 : 2;
        }
        else if (board[2] == board[4] && board[4] == board[6])
        {
            return (board[2] == 'X') ? 1 : 2;
        }
        #endregion

        return 0;
    }

    static bool CheckForTie()
    {
        foreach (var cell in board)
        {
            if (cell != 'X' && cell != 'O')
            {
                return false;
            }
        }
        return true;
    }
}