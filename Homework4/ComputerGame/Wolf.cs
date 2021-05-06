namespace ComputerGame
{
    public class Wolf : Monster
    {
        private const double WolfSpeed = 6;
        public override double Speed => WolfSpeed;
        public Wolf(double xPos, double yPos) : base(xPos, yPos) { }
    }
}