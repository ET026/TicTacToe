using TicTacToe.Models;

namespace TicTacToe.Pages
{
    public partial class BlazorTicTacToeComponent
    {
        int player1Score = 0;
        int player2Score = 0;

        string player1 = "Player 1"; 
        string player2 = "Player 2"; 
        string currentPlayer = "";
        int hitPosition = 0;
        bool isGameRunning = true;

        public List<SquareModel> Squares { get; set; } = new List<SquareModel>();

        public BlazorTicTacToeComponent()
        {
            InitializeSquares();
            SetCurrentPlayer();
        }
        private void InitializeSquares()
        {
            for (int i = 0; i < 9; i++)
            {
                Squares.Add(new SquareModel { Id = i });
            }
        }
        private void SetCurrentPlayer()
        {
            Random random = new Random();
            currentPlayer = random.Next(0, 2) == 0 ? player1 : player2;
        }
        private void SwitchPlayers()
        {
            currentPlayer = currentPlayer == player1 ? player2 : player1;
        }

        private int[][] winConditions = new int[][]
        {
            new int[] { 0, 1, 2 }, // Top row
            new int[] { 3, 4, 5 }, // Middle row
            new int[] { 6, 7, 8 }, // Bottom row
            new int[] { 0, 3, 6 }, // Left column
            new int[] { 1, 4, 7 }, // Middle column
            new int[] { 2, 5, 8 }, // Right column
            new int[] { 0, 4, 8 }, // Diagonal from top-left to bottom-right
            new int[] { 2, 4, 6 }  // Diagonal from top-right to bottom-left
        };

        private bool CheckWin(string symbol)
        {
            foreach (var condition in winConditions)
            {
                int count = 0;
                foreach (var index in condition)
                {
                    if (Squares[index].PlayerSymbol == symbol)
                    {
                        count++;
                    }
                }
                if (count == 3)
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckDraw()
        {
            return Squares.All(square => square.PlayerSymbol != null);
        }

        private void EndGame(string winner)
        {
            
            isGameRunning = false;
        }

        private void ValidateHit(SquareModel square)
        {
            if (isGameRunning && square.PlayerSymbol == null)
            {
                square.PlayerSymbol = currentPlayer == player1 ? "x-symbol" : "o-symbol";
                if (CheckWin(square.PlayerSymbol))
                {
                    EndGame(currentPlayer);
                    _ = currentPlayer == player1 ? player1Score++ : player2Score++;
                    ResetGame();
                    
                }
                else if (CheckDraw())
                {
                    
                    EndGame("Draw");
                    ResetGame();
                }
                
                SwitchPlayers();
            }
        }

        private void ResetGame()
        {
            foreach (var square in Squares)
            {
                square.PlayerSymbol = null;
            }
            isGameRunning = true;
            SetCurrentPlayer();
        }


    }
}
