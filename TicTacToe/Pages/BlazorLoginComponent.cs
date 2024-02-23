namespace TicTacToe.Pages
{
    public partial class BlazorLoginComponent
    {
        private string player1 = "";
        private string player2 = "";
        private string currentPlayer = "";
        private bool isGameRunning = true;

        public string Player1
        {
            get => player1;
            set
            {
                player1 = value;
                
            }
        }
        public string Player2
        {
            get => player2;
            set
            {
                player2 = value;
                
            }
        }
        
    }
}
