namespace ComputerGame
{
    public class Cherry : Bonus
    {
        private const int CherryScore = 5;
        public Cherry(double xPos, double yPos) : base(xPos, yPos) { }
                
        public override int Score => CherryScore;
    }
}