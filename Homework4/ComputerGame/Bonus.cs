namespace ComputerGame
{
    public abstract class Bonus
    {
        private const int DefaultScore = 5;
        
        protected Bonus(double xPos, double yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }

        public virtual int Score => DefaultScore;
        public double XPos { get; private set; }
        public double YPos { get; private set; }
    }
}