namespace ComputerGame
{
    public class Apple : Bonus
    {
        private const int AppleScore = 10;
        public Apple(double xPos, double yPos) : base(xPos, yPos) { }

        public override int Score => AppleScore;
    }
}