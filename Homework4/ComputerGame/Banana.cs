namespace ComputerGame
{
    public class Banana : Bonus
    {
        private const int BananaScore = 15;
        public Banana(double xPos, double yPos) : base(xPos, yPos) { }
        
        public override int Score => BananaScore;
    }
}