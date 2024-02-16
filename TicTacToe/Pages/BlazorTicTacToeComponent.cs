using TicTacToe.Models;

namespace TicTacToe.Pages
{
    public partial class BlazorTicTacToeComponent
    {
        int score = 0;
        string player1 = ""; 
        string player2 = ""; 
        string currentPlayer = "";
        int hitPosition = 0;

        public List<SquareModel> Squares { get; set; } = new List<SquareModel>();

        public BlazorTicTacToeComponent()
        {
            for (int i = 0; i < 9; i++)
            {
                Squares.Add(new SquareModel { Id = i });
            }
        }
    }
}
