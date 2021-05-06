namespace ComputerGame
{
    public class Bear : Monster
    {
        private const double BearSpeed = 2;
        public override double Speed => BearSpeed;
        
        public Bear(double xPos, double yPos) : base(xPos, yPos) { }
    }
}