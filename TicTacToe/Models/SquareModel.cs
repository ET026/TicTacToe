namespace TicTacToe.Models
{
    public class SquareModel
    {
        private bool isOccupied;

        public int Id { get; set; }
        public string Style { get; set; }

        public bool IsOccupied
        {
            get => isOccupied;
            set
            {
                isOccupied = value;
                if(isOccupied)
                {
                    Style = "background-color: #f0f0f0; cursor: not-allowed;";
                }
                else
                {
                    Style = "background-color: #f0f0f0; cursor: pointer;";
                }
                
            }
        }
    }
}
